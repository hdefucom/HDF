using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Data.EventLog
{
	                                                                    /// <summary>
	                                                                    ///       用于读取系统日志数据的数据读取器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class EventLogReader : DbDataReader, IRecordCount
	{
		private class ColumnInfo
		{
			public string Name = null;

			public EventLogFieldStyle Style = EventLogFieldStyle.None;

			public bool NullStyle = false;

			public Type ValueType = null;
		}

		private string strLogName = "Application";

		private static string[] strLogNames = null;

		private ArrayList myColumns = new ArrayList();

		private System.Diagnostics.EventLog myLog = null;

		private EventLogEntry[] myEntries = null;

		private EventLogEntry myEntry = null;

		private int intRowIndex = -1;

		private bool bolClosed = false;

		                                                                    /// <summary>
		                                                                    ///       日志类型名称
		                                                                    ///       </summary>
		public string LogName
		{
			get
			{
				return strLogName;
			}
			set
			{
				strLogName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       系统中所有的日志名称
		                                                                    ///       </summary>
		public static string[] LogNames
		{
			get
			{
				if (strLogNames == null)
				{
					System.Diagnostics.EventLog[] eventLogs = System.Diagnostics.EventLog.GetEventLogs();
					if (eventLogs == null)
					{
						strLogNames = new string[0];
					}
					else
					{
						strLogNames = new string[eventLogs.Length];
						for (int i = 0; i < eventLogs.Length; i++)
						{
							strLogNames[i] = eventLogs[i].Log;
						}
					}
				}
				return strLogNames;
			}
		}

		public override int Depth
		{
			get
			{
				throw new NotSupportedException("Depth");
			}
		}

		public override int RecordsAffected
		{
			get
			{
				throw new NotSupportedException("RecordAffected");
			}
		}

		public override object this[int ordinal] => GetValue(ordinal);

		                                                                    /// <summary>
		                                                                    ///       记录总个数
		                                                                    ///       </summary>
		public int RecordCount
		{
			get
			{
				if (myEntries == null)
				{
					return -1;
				}
				return myEntries.Length;
			}
		}

		public override bool IsClosed => bolClosed;

		public override object this[string name]
		{
			get
			{
				int num = 13;
				int ordinal = GetOrdinal(name);
				if (ordinal < 0)
				{
					throw new ArgumentException("Name");
				}
				return GetValue(ordinal);
			}
		}

		public override int FieldCount => myColumns.Count;

		public override bool HasRows => RecordCount > 0;

		public int AddField(string name, string strStyle)
		{
			EventLogFieldStyle style = EventLogFieldStyle.None;
			if (Enum.IsDefined(typeof(EventLogFieldStyle), strStyle))
			{
				style = (EventLogFieldStyle)Enum.Parse(typeof(EventLogFieldStyle), strStyle);
			}
			return AddField(name, style);
		}

		                                                                    /// <summary>
		                                                                    ///       添加字段
		                                                                    ///       </summary>
		                                                                    /// <param name="name">字段名</param>
		                                                                    /// <param name="style">字段数据类型</param>
		                                                                    /// <returns>新字段的序号</returns>
		public int AddField(string name, EventLogFieldStyle style)
		{
			ColumnInfo columnInfo = new ColumnInfo();
			columnInfo.Name = name;
			columnInfo.Style = style;
			switch (style)
			{
			default:
				columnInfo.NullStyle = true;
				break;
			case EventLogFieldStyle.Category:
				columnInfo.ValueType = typeof(string);
				break;
			case EventLogFieldStyle.CategoryNumber:
				columnInfo.ValueType = typeof(int);
				break;
			case EventLogFieldStyle.Data:
				columnInfo.ValueType = typeof(byte[]);
				break;
			case EventLogFieldStyle.EntryType:
				columnInfo.ValueType = typeof(string);
				break;
			case EventLogFieldStyle.Index:
				columnInfo.ValueType = typeof(int);
				break;
			case EventLogFieldStyle.MachineName:
				columnInfo.ValueType = typeof(string);
				break;
			case EventLogFieldStyle.Message:
				columnInfo.ValueType = typeof(string);
				break;
			case EventLogFieldStyle.ReplacementStrings:
				columnInfo.ValueType = typeof(string);
				break;
			case EventLogFieldStyle.Source:
				columnInfo.ValueType = typeof(string);
				break;
			case EventLogFieldStyle.TimeGenerated:
				columnInfo.ValueType = typeof(DateTime);
				break;
			case EventLogFieldStyle.TimeWriten:
				columnInfo.ValueType = typeof(DateTime);
				break;
			case EventLogFieldStyle.UserName:
				columnInfo.ValueType = typeof(string);
				break;
			}
			return myColumns.Add(columnInfo);
		}

		public override bool NextResult()
		{
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       打开对象
		                                                                    ///       </summary>
		                                                                    /// <returns>操作是否成功</returns>
		public bool Open()
		{
			myLog = new System.Diagnostics.EventLog(strLogName);
			ArrayList arrayList = new ArrayList(myLog.Entries);
			myEntries = (EventLogEntry[])arrayList.ToArray(typeof(EventLogEntry));
			intRowIndex = -1;
			bolClosed = false;
			return true;
		}

		public bool OpenReverse()
		{
			myLog = new System.Diagnostics.EventLog(strLogName);
			ArrayList arrayList = new ArrayList(myLog.Entries);
			arrayList.Reverse();
			myEntries = (EventLogEntry[])arrayList.ToArray(typeof(EventLogEntry));
			intRowIndex = -1;
			bolClosed = false;
			return true;
		}

		private void CheckClosed()
		{
			if (bolClosed)
			{
				throw new InvalidOperationException(DataStrings.ReaderClosed);
			}
		}

		private void CheckRowIndex(int RowIndex)
		{
			int num = 11;
			if (myEntries != null)
			{
				throw new InvalidOperationException(DataStrings.NoData);
			}
			if (RowIndex < 0 || RowIndex >= myEntries.Length)
			{
				throw new IndexOutOfRangeException("RowIndex");
			}
		}

		public override void Close()
		{
			if (!bolClosed)
			{
				bolClosed = true;
				if (myLog != null)
				{
					myLog.Dispose();
					myLog = null;
				}
				myEntries = null;
				if (myEntry != null)
				{
					myEntry.Dispose();
					myEntry = null;
				}
			}
		}

		public override bool Read()
		{
			CheckClosed();
			intRowIndex++;
			if (intRowIndex >= 0 && intRowIndex < myEntries.Length)
			{
				myEntry = myEntries[intRowIndex];
				return true;
			}
			myEntry = null;
			return false;
		}

		public override DataTable GetSchemaTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(SchemaTableColumn.ColumnName, typeof(string));
			dataTable.Columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.ColumnSize, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.DataType, typeof(Type));
			dataTable.Columns.Add(SchemaTableColumn.AllowDBNull, typeof(bool));
			dataTable.Columns.Add(SchemaTableColumn.IsUnique, typeof(bool));
			dataTable.Columns.Add(SchemaTableColumn.IsKey, typeof(bool));
			foreach (ColumnInfo myColumn in myColumns)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = myColumn.Name;
				dataRow[1] = myColumns.IndexOf(myColumn);
				if (myColumn.ValueType.Equals(typeof(string)))
				{
					dataRow[2] = 1000000;
				}
				else
				{
					dataRow[2] = -1;
				}
				dataRow[3] = myColumn.ValueType;
				dataRow[4] = true;
				dataRow[5] = false;
				dataRow[6] = false;
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}

		public override int GetInt32(int ordinal)
		{
			return Convert.ToInt32(GetValue(ordinal));
		}

		public override object GetValue(int ordinal)
		{
			int num = 2;
			CheckClosed();
			if (myEntry == null)
			{
				throw new InvalidOperationException(DataStrings.NoCurrentRecord);
			}
			if (ordinal < 0 || ordinal >= myColumns.Count)
			{
				throw new IndexOutOfRangeException("Field index");
			}
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			switch (columnInfo.Style)
			{
			default:
				return DBNull.Value;
			case EventLogFieldStyle.Category:
				return myEntry.Category;
			case EventLogFieldStyle.CategoryNumber:
				return (int)myEntry.CategoryNumber;
			case EventLogFieldStyle.Data:
				return myEntry.Data;
			case EventLogFieldStyle.EntryType:
				return Enum.GetName(typeof(EventLogEntryType), myEntry.EntryType);
			case EventLogFieldStyle.Index:
				return myEntry.Index;
			case EventLogFieldStyle.MachineName:
				return myEntry.MachineName;
			case EventLogFieldStyle.Message:
				return myEntry.Message;
			case EventLogFieldStyle.ReplacementStrings:
			{
				string[] replacementStrings = myEntry.ReplacementStrings;
				if (replacementStrings != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					string[] array = replacementStrings;
					foreach (string value in array)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(value);
					}
					return stringBuilder.ToString();
				}
				return DBNull.Value;
			}
			case EventLogFieldStyle.Source:
				return myEntry.Source;
			case EventLogFieldStyle.TimeGenerated:
				return myEntry.TimeGenerated;
			case EventLogFieldStyle.TimeWriten:
				return myEntry.TimeWritten;
			case EventLogFieldStyle.UserName:
				return myEntry.UserName;
			}
		}

		public override bool IsDBNull(int ordinal)
		{
			int num = 17;
			if (ordinal < 0 || ordinal >= myColumns.Count)
			{
				throw new IndexOutOfRangeException("Field index");
			}
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			if (columnInfo.NullStyle)
			{
				return true;
			}
			object value = GetValue(ordinal);
			return value == null || DBNull.Value.Equals(value);
		}

		public override long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			throw new NotSupportedException("GetBytes");
		}

		public override byte GetByte(int ordinal)
		{
			return Convert.ToByte(GetValue(ordinal));
		}

		public override Type GetFieldType(int ordinal)
		{
			int num = 19;
			CheckClosed();
			if (ordinal < 0 || ordinal >= myColumns.Count)
			{
				throw new IndexOutOfRangeException("Field index");
			}
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			return columnInfo.ValueType;
		}

		public override decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(GetValue(ordinal));
		}

		public override int GetValues(object[] values)
		{
			int num = Math.Min(values.Length, myColumns.Count);
			for (int i = 0; i < num; i++)
			{
				values[i] = GetValue(i);
			}
			return num;
		}

		public override string GetName(int ordinal)
		{
			int num = 3;
			CheckClosed();
			if (ordinal < 0 || ordinal >= myColumns.Count)
			{
				throw new IndexOutOfRangeException("Field index");
			}
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			return columnInfo.Name;
		}

		public override long GetInt64(int ordinal)
		{
			return Convert.ToInt64(GetValue(ordinal));
		}

		public override double GetDouble(int ordinal)
		{
			return Convert.ToDouble(GetValue(ordinal));
		}

		public override bool GetBoolean(int ordinal)
		{
			return Convert.ToBoolean(GetValue(ordinal));
		}

		public override Guid GetGuid(int ordinal)
		{
			throw new NotSupportedException("GetGuid");
		}

		public override DateTime GetDateTime(int ordinal)
		{
			return default(DateTime);
		}

		public override int GetOrdinal(string name)
		{
			int num = 3;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			CheckClosed();
			int num2 = 0;
			while (true)
			{
				if (num2 < myColumns.Count)
				{
					ColumnInfo columnInfo = (ColumnInfo)myColumns[num2];
					if (string.Compare(columnInfo.Name, name, ignoreCase: true) == 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}

		public override string GetDataTypeName(int ordinal)
		{
			int num = 9;
			CheckClosed();
			if (ordinal < 0 || ordinal >= myColumns.Count)
			{
				throw new IndexOutOfRangeException("Field index");
			}
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			return columnInfo.ValueType.Name;
		}

		public override float GetFloat(int ordinal)
		{
			return Convert.ToSingle(GetValue(ordinal));
		}

		public override long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			throw new NotSupportedException("GetChars");
		}

		public override string GetString(int ordinal)
		{
			return Convert.ToString(GetValue(ordinal));
		}

		public override char GetChar(int ordinal)
		{
			return Convert.ToChar(GetValue(ordinal));
		}

		public override short GetInt16(int ordinal)
		{
			return Convert.ToInt16(GetValue(ordinal));
		}

		public override IEnumerator GetEnumerator()
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}

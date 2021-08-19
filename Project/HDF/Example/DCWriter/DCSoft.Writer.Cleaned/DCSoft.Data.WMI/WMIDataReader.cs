using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Management;
using System.Runtime.InteropServices;

namespace DCSoft.Data.WMI
{
	                                                                    /// <summary>
	                                                                    ///       Windows系统管理消息数据读取器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class WMIDataReader : DbDataReader, IRecordCount
	{
		private class ColumnInfo
		{
			public string Name = null;

			public Type ValueType = null;

			public bool NullValue = false;

			public object Value = null;
		}

		private string strQueryString = null;

		private int intRecordCount = 0;

		private ArrayList myColumns = new ArrayList();

		private ManagementObjectSearcher mySearcher = null;

		private ManagementObjectCollection myObjects = null;

		private ManagementObjectCollection.ManagementObjectEnumerator myEnumerator = null;

		private ManagementObject myFirstObject = null;

		private bool bolIsClosed = false;

		                                                                    /// <summary>
		                                                                    ///       查询字符串
		                                                                    ///       </summary>
		public string QueryString => strQueryString;

		                                                                    /// <summary>
		                                                                    ///       记录个数
		                                                                    ///       </summary>
		public int RecordCount => intRecordCount;

		public override int RecordsAffected
		{
			get
			{
				throw new NotSupportedException("RecordAffected");
			}
		}

		public override bool IsClosed => bolIsClosed;

		public override int Depth
		{
			get
			{
				throw new NotSupportedException("Depth");
			}
		}

		public override object this[string name]
		{
			get
			{
				int num = 0;
				CheckOpen();
				int ordinal = GetOrdinal(name);
				if (ordinal < 0)
				{
					throw new IndexOutOfRangeException("name is not existed");
				}
				return GetValue(ordinal);
			}
		}

		public override object this[int ordinal] => GetValue(ordinal);

		public override int FieldCount => myColumns.Count;

		public override bool HasRows => true;

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="queryString">查询字符串</param>
		                                                                    /// <param name="FillFieldInfo">是否自动填充字段信息</param>
		public WMIDataReader(string queryString, bool FillFieldInfo)
		{
			strQueryString = queryString;
			mySearcher = new ManagementObjectSearcher(strQueryString);
			myObjects = mySearcher.Get();
			intRecordCount = myObjects.Count;
			myEnumerator = myObjects.GetEnumerator();
			myEnumerator.Reset();
			myEnumerator.MoveNext();
			myFirstObject = (ManagementObject)myEnumerator.Current;
			if (FillFieldInfo && myFirstObject != null)
			{
				foreach (PropertyData property in myFirstObject.Properties)
				{
					ColumnInfo columnInfo = new ColumnInfo
					{
						Name = property.Name.Trim(),
						ValueType = ConvertToType(property.Type)
					};
					if (property.IsArray)
					{
						columnInfo.ValueType = columnInfo.ValueType.MakeArrayType();
					}
					myColumns.Add(columnInfo);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       添加字段
		                                                                    ///       </summary>
		                                                                    /// <param name="name">字段名</param>
		                                                                    /// <returns>新字段的序号</returns>
		public int AddField(string name)
		{
			int num = 4;
			if (myFirstObject == null)
			{
				return -1;
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			foreach (ColumnInfo myColumn in myColumns)
			{
				if (string.Compare(myColumn.Name, name, ignoreCase: true) == 0)
				{
					return myColumns.IndexOf(myColumn);
				}
			}
			ColumnInfo columnInfo2 = new ColumnInfo();
			columnInfo2.Name = name;
			foreach (PropertyData property in myFirstObject.Properties)
			{
				if (string.Compare(columnInfo2.Name, property.Name.Trim()) == 0)
				{
					columnInfo2.ValueType = ConvertToType(property.Type);
					break;
				}
			}
			return myColumns.Add(columnInfo2);
		}

		private Type ConvertToType(CimType type)
		{
			switch (type)
			{
			case CimType.DateTime:
				return typeof(DateTime);
			case CimType.Reference:
				return typeof(string);
			case CimType.Char16:
				return typeof(char);
			case CimType.SInt16:
				return typeof(short);
			case CimType.SInt32:
				return typeof(int);
			case CimType.Real32:
				return typeof(float);
			case CimType.Real64:
				return typeof(double);
			case CimType.String:
				return typeof(string);
			case CimType.Boolean:
				return typeof(bool);
			case CimType.Object:
				return typeof(object);
			default:
				return typeof(string);
			case CimType.SInt8:
				return typeof(sbyte);
			case CimType.UInt8:
				return typeof(byte);
			case CimType.UInt16:
				return typeof(ushort);
			case CimType.UInt32:
				return typeof(uint);
			case CimType.SInt64:
				return typeof(long);
			case CimType.UInt64:
				return typeof(ulong);
			}
		}

		private void CheckOpen()
		{
			int num = 19;
			if (bolIsClosed)
			{
				throw new InvalidOperationException("Read is closed");
			}
		}

		private void CheckFieldIndex(int index)
		{
			int num = 6;
			if (index < 0 || index >= myColumns.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
		}

		public override bool NextResult()
		{
			return false;
		}

		public override void Close()
		{
			if (!bolIsClosed)
			{
				intRecordCount = -1;
				myColumns.Clear();
				mySearcher.Dispose();
				myObjects.Dispose();
				if (myFirstObject != null)
				{
					myFirstObject.Dispose();
					myFirstObject = null;
				}
				bolIsClosed = true;
			}
		}

		public override bool Read()
		{
			CheckOpen();
			foreach (ColumnInfo myColumn in myColumns)
			{
				myColumn.Value = null;
			}
			ManagementObject managementObject = myFirstObject;
			if (managementObject != null)
			{
				myFirstObject = null;
			}
			else
			{
				if (!myEnumerator.MoveNext())
				{
					return false;
				}
				managementObject = (ManagementObject)myEnumerator.Current;
			}
			foreach (PropertyData property in managementObject.Properties)
			{
				foreach (ColumnInfo myColumn2 in myColumns)
				{
					if (string.Compare(myColumn2.Name, property.Name, ignoreCase: true) == 0)
					{
						myColumn2.Value = property.Value;
						myColumn2.ValueType = ConvertToType(property.Type);
						if (property.IsArray)
						{
							myColumn2.ValueType = myColumn2.ValueType.MakeArrayType();
						}
						myColumn2.NullValue = (myColumn2.Value == null || DBNull.Value.Equals(myColumn2.Value));
						break;
					}
				}
			}
			return true;
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
			int num = 0;
			foreach (ColumnInfo myColumn in myColumns)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = myColumn.Name;
				dataRow[1] = num++;
				dataRow[2] = -1;
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
			CheckOpen();
			CheckFieldIndex(ordinal);
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			return columnInfo.Value;
		}

		public override bool IsDBNull(int ordinal)
		{
			CheckOpen();
			CheckFieldIndex(ordinal);
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			return columnInfo.NullValue;
		}

		public override long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			byte[] array = (byte[])GetValue(ordinal);
			long num = Math.Min(array.Length, length + fieldOffset);
			Array.Copy(array, fieldOffset, buffer, bufferoffset, num);
			return num;
		}

		public override byte GetByte(int ordinal)
		{
			return Convert.ToByte(GetValue(ordinal));
		}

		public override Type GetFieldType(int ordinal)
		{
			CheckOpen();
			CheckFieldIndex(ordinal);
			ColumnInfo columnInfo = (ColumnInfo)myColumns[ordinal];
			return columnInfo.ValueType;
		}

		public override decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(GetValue(ordinal));
		}

		public override int GetValues(object[] values)
		{
			CheckOpen();
			int num = Math.Min(values.Length, myColumns.Count);
			for (int i = 0; i < num; i++)
			{
				ColumnInfo columnInfo = (ColumnInfo)myColumns[i];
				values[i] = columnInfo.Value;
			}
			return num;
		}

		public override string GetName(int ordinal)
		{
			CheckOpen();
			CheckFieldIndex(ordinal);
			return ((ColumnInfo)myColumns[ordinal]).Name;
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
			return Convert.ToDateTime(GetValue(ordinal));
		}

		public override int GetOrdinal(string name)
		{
			int num = 4;
			CheckOpen();
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
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
			CheckOpen();
			CheckFieldIndex(ordinal);
			return ((ColumnInfo)myColumns[ordinal]).ValueType.Name;
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

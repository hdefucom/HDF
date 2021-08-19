using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       自定义数据读取器的基础类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public abstract class BaseDataReader : DbDataReader
	{
		protected ArrayList myColumns = new ArrayList();

		protected bool bolDirectConvert = true;

		public override int RecordsAffected => 0;

		public override int Depth
		{
			get
			{
				throw new NotSupportedException("对象不支持 Depth 方法");
			}
		}

		public override object this[string name] => InnerGetValue(GetOrdinal(name));

		public override object this[int ordinal] => InnerGetValue(ordinal);

		public override int FieldCount => myColumns.Count;

		public override bool HasRows => true;

		protected abstract object InnerGetValue(int index);

		protected abstract bool InnerIsDBNull(int index);

		public override bool NextResult()
		{
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
			for (int i = 0; i < FieldCount; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = GetName(i);
				dataRow[1] = i;
				dataRow[2] = -1;
				dataRow[3] = GetFieldType(i);
				dataRow[4] = true;
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}

		public override int GetInt32(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (int)InnerGetValue(ordinal);
			}
			return Convert.ToInt32(InnerGetValue(ordinal));
		}

		public override object GetValue(int ordinal)
		{
			return InnerGetValue(ordinal);
		}

		public override bool IsDBNull(int ordinal)
		{
			return InnerIsDBNull(ordinal);
		}

		public override long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		public override byte GetByte(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (byte)InnerGetValue(ordinal);
			}
			return Convert.ToByte(InnerGetValue(ordinal));
		}

		public override Type GetFieldType(int ordinal)
		{
			return typeof(string);
		}

		public override decimal GetDecimal(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (decimal)InnerGetValue(ordinal);
			}
			return Convert.ToDecimal(InnerGetValue(ordinal));
		}

		public override int GetValues(object[] values)
		{
			int val = 0;
			for (int i = 0; i < FieldCount && i < values.Length; i++)
			{
				values[i] = InnerGetValue(i);
			}
			return Math.Min(val, values.Length);
		}

		public override long GetInt64(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (long)InnerGetValue(ordinal);
			}
			return Convert.ToInt64(InnerGetValue(ordinal));
		}

		public override double GetDouble(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (double)InnerGetValue(ordinal);
			}
			return Convert.ToDouble(InnerGetValue(ordinal));
		}

		public override bool GetBoolean(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (bool)InnerGetValue(ordinal);
			}
			return Convert.ToBoolean(InnerGetValue(ordinal));
		}

		public override Guid GetGuid(int ordinal)
		{
			return default(Guid);
		}

		public override DateTime GetDateTime(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (DateTime)InnerGetValue(ordinal);
			}
			return Convert.ToDateTime(InnerGetValue(ordinal));
		}

		public override int GetOrdinal(string name)
		{
			int num = 0;
			while (true)
			{
				if (num < FieldCount)
				{
					if (name == GetName(num))
					{
						break;
					}
					num++;
					continue;
				}
				num = 0;
				while (true)
				{
					if (num < FieldCount)
					{
						if (string.Compare(GetName(num), name, ignoreCase: true) == 0)
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				return num;
			}
			return num;
		}

		public override string GetDataTypeName(int ordinal)
		{
			return GetFieldType(ordinal).Name;
		}

		public override float GetFloat(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (float)InnerGetValue(ordinal);
			}
			return Convert.ToSingle(InnerGetValue(ordinal));
		}

		public override long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		public override string GetString(int ordinal)
		{
			return Convert.ToString(InnerGetValue(ordinal));
		}

		public override char GetChar(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (char)InnerGetValue(ordinal);
			}
			return Convert.ToChar(InnerGetValue(ordinal));
		}

		public override short GetInt16(int ordinal)
		{
			if (bolDirectConvert)
			{
				return (short)InnerGetValue(ordinal);
			}
			return Convert.ToInt16(InnerGetValue(ordinal));
		}

		public override IEnumerator GetEnumerator()
		{
			return null;
		}
	}
}

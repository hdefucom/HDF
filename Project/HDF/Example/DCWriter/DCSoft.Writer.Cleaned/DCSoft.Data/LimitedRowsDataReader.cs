using DCSoft.Common;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       受限行数的数据读取器
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class LimitedRowsDataReader : IDataReader
	{
		private IDataReader _BaseReader;

		private int _MaxRowsCount;

		private int _RowsReaded;

		public int Depth => _BaseReader.Depth;

		public bool IsClosed => _BaseReader.IsClosed;

		public int RecordsAffected => _BaseReader.RecordsAffected;

		public int FieldCount => _BaseReader.FieldCount;

		public object this[string name] => _BaseReader[name];

		public object this[int ordinal] => _BaseReader[ordinal];

		public static DataTable CreateDataTable(IDataReader reader, int maxRowsCount)
		{
			int num = 6;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			DataTable dataTable;
			if (maxRowsCount > 0)
			{
				LimitedRowsDataReader reader2 = new LimitedRowsDataReader(reader, maxRowsCount);
				dataTable = new DataTable();
				dataTable.Load(reader2);
				return dataTable;
			}
			dataTable = new DataTable();
			dataTable.Load(reader);
			return dataTable;
		}

		public LimitedRowsDataReader(IDataReader reader, int maxRowsCount)
		{
			int num = 19;
			_BaseReader = null;
			_MaxRowsCount = 0;
			_RowsReaded = 0;
			
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader is LimitedRowsDataReader)
			{
				LimitedRowsDataReader limitedRowsDataReader = (LimitedRowsDataReader)reader;
				_BaseReader = limitedRowsDataReader._BaseReader;
				_MaxRowsCount = Math.Min(limitedRowsDataReader._MaxRowsCount, maxRowsCount);
			}
			else
			{
				_BaseReader = reader;
				_MaxRowsCount = maxRowsCount;
			}
		}

		public void Close()
		{
			_BaseReader.Close();
		}

		public DataTable GetSchemaTable()
		{
			return _BaseReader.GetSchemaTable();
		}

		public bool NextResult()
		{
			return _BaseReader.NextResult();
		}

		public bool Read()
		{
			if (_MaxRowsCount > 0 && _RowsReaded >= _MaxRowsCount)
			{
				return false;
			}
			if (_BaseReader.Read())
			{
				_RowsReaded++;
				return true;
			}
			return false;
		}

		public void Dispose()
		{
			_BaseReader.Dispose();
		}

		public bool GetBoolean(int ordinal)
		{
			return _BaseReader.GetBoolean(ordinal);
		}

		public byte GetByte(int ordinal)
		{
			return _BaseReader.GetByte(ordinal);
		}

		public long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return _BaseReader.GetBytes(ordinal, fieldOffset, buffer, bufferoffset, length);
		}

		public char GetChar(int ordinal)
		{
			return _BaseReader.GetChar(ordinal);
		}

		public long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return _BaseReader.GetChars(ordinal, fieldoffset, buffer, bufferoffset, length);
		}

		public IDataReader GetData(int int_0)
		{
			return _BaseReader.GetData(int_0);
		}

		public string GetDataTypeName(int ordinal)
		{
			return _BaseReader.GetDataTypeName(ordinal);
		}

		public DateTime GetDateTime(int ordinal)
		{
			return _BaseReader.GetDateTime(ordinal);
		}

		public decimal GetDecimal(int ordinal)
		{
			return _BaseReader.GetDecimal(ordinal);
		}

		public double GetDouble(int ordinal)
		{
			return _BaseReader.GetDouble(ordinal);
		}

		public Type GetFieldType(int ordinal)
		{
			return _BaseReader.GetFieldType(ordinal);
		}

		public float GetFloat(int ordinal)
		{
			return _BaseReader.GetFloat(ordinal);
		}

		public Guid GetGuid(int ordinal)
		{
			return _BaseReader.GetGuid(ordinal);
		}

		public short GetInt16(int ordinal)
		{
			return _BaseReader.GetInt16(ordinal);
		}

		public int GetInt32(int ordinal)
		{
			return _BaseReader.GetInt32(ordinal);
		}

		public long GetInt64(int ordinal)
		{
			return _BaseReader.GetInt64(ordinal);
		}

		public string GetName(int ordinal)
		{
			return _BaseReader.GetName(ordinal);
		}

		public int GetOrdinal(string name)
		{
			return _BaseReader.GetOrdinal(name);
		}

		public string GetString(int ordinal)
		{
			return _BaseReader.GetString(ordinal);
		}

		public object GetValue(int ordinal)
		{
			return _BaseReader.GetValue(ordinal);
		}

		public int GetValues(object[] values)
		{
			return _BaseReader.GetValues(values);
		}

		public bool IsDBNull(int ordinal)
		{
			return _BaseReader.IsDBNull(ordinal);
		}
	}
}

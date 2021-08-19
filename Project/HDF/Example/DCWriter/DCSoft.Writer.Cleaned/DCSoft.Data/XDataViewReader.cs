using System;
using System.Data;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       基于数据视图对象(DateView)的数据读取器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XDataViewReader : IDataReader
	{
		protected bool bolDisposeDataView = true;

		                                                                    /// <summary>
		                                                                    ///       数据表对象
		                                                                    ///       </summary>
		protected DataTable myTable = null;

		                                                                    /// <summary>
		                                                                    ///       数据视图对象
		                                                                    ///       </summary>
		protected DataView myView = null;

		                                                                    /// <summary>
		                                                                    ///       当前数据行号
		                                                                    ///       </summary>
		protected int intRowIndex = 0;

		                                                                    /// <summary>
		                                                                    ///       当前数据行对象
		                                                                    ///       </summary>
		protected DataRowView myRow = null;

		private int intRecordsAffected = 0;

		                                                                    /// <summary>
		                                                                    ///       关闭对象时是否销毁内置的数据表对象
		                                                                    ///       </summary>
		public bool DisposeDataView
		{
			get
			{
				return bolDisposeDataView;
			}
			set
			{
				bolDisposeDataView = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       内部提供数据的数据表对象
		                                                                    ///       </summary>
		public DataView InnerDataView => myView;

		                                                                    /// <summary>
		                                                                    ///       记录总个数
		                                                                    ///       </summary>
		public int RecordCount
		{
			get
			{
				if (myView == null)
				{
					return -1;
				}
				return myView.Count;
			}
		}

		                                                                    /// <summary>
		                                                                    ///        通过执行 SQL 语句获取更改、插入或删除的行数。  
		                                                                    ///       </summary>
		public int RecordsAffected => intRecordsAffected;

		                                                                    /// <summary>
		                                                                    ///       数据读取器是否关闭
		                                                                    ///       </summary>
		public bool IsClosed => myView == null;

		                                                                    /// <summary>
		                                                                    ///       本成员未实现
		                                                                    ///       </summary>
		public int Depth => 0;

		                                                                    /// <summary>
		                                                                    ///       返回指定栏目的数据
		                                                                    ///       </summary>
		public object this[string name] => myRow[name];

		object IDataRecord.this[int int_0] => myRow[int_0];

		                                                                    /// <summary>
		                                                                    ///       栏目个数
		                                                                    ///       </summary>
		public int FieldCount => myTable.Columns.Count;

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public XDataViewReader()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       使用一个数据视图对象初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="t">数据视图对象</param>
		public XDataViewReader(DataView dataView_0)
		{
			SetDataView(dataView_0);
		}

		                                                                    /// <summary>
		                                                                    ///       根据数据表设置对象数据
		                                                                    ///       </summary>
		                                                                    /// <param name="t">数据表对象</param>
		public void SetDataView(DataView dataView_0)
		{
			myView = dataView_0;
			myTable = myView.Table;
			intRowIndex = -1;
			myRow = null;
		}

		                                                                    /// <summary>
		                                                                    ///       本成员未实现
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public bool NextResult()
		{
			throw new NotSupportedException("对象不支持 NextResult 成员");
		}

		                                                                    /// <summary>
		                                                                    ///       关闭数据读取器
		                                                                    ///       </summary>
		public void Close()
		{
			if (bolDisposeDataView && myView != null)
			{
				myView.Dispose();
				myView = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       读取一个数据
		                                                                    ///       </summary>
		                                                                    /// <returns>操作是否成功</returns>
		public bool Read()
		{
			intRowIndex++;
			if (intRowIndex >= 0 && intRowIndex < myView.Count)
			{
				myRow = myView[intRowIndex];
				return true;
			}
			myRow = null;
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       本成员未实现
		                                                                    ///       </summary>
		                                                                    /// <returns>数据</returns>
		public DataTable GetSchemaTable()
		{
			throw new NotSupportedException("对象不支持 GetSchemaTable 成员");
		}

		                                                                    /// <summary>
		                                                                    ///       关闭对象
		                                                                    ///       </summary>
		public void Dispose()
		{
			Close();
		}

		                                                                    /// <summary>
		                                                                    ///       返回指定栏目的整数数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>读取的数据</returns>
		public int GetInt32(int ordinal)
		{
			return Convert.ToInt32(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       返回指定栏目的数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>读取的数据</returns>
		public object GetValue(int ordinal)
		{
			return myRow[ordinal];
		}

		                                                                    /// <summary>
		                                                                    ///       判断指定栏目数据是否为空
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>数据是否为空</returns>
		public bool IsDBNull(int ordinal)
		{
			return DBNull.Value.Equals(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       本成员未实现
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <param name="fieldOffset">
		                                                                    /// </param>
		                                                                    /// <param name="buffer">
		                                                                    /// </param>
		                                                                    /// <param name="bufferoffset">
		                                                                    /// </param>
		                                                                    /// <param name="length">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的字节数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目名称</param>
		                                                                    /// <returns>获得的字节数据</returns>
		public byte GetByte(int ordinal)
		{
			return Convert.ToByte(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的数据类型
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目名称</param>
		                                                                    /// <returns>数据类型</returns>
		public Type GetFieldType(int ordinal)
		{
			return myTable.Columns[ordinal].DataType;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的实数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目名称</param>
		                                                                    /// <returns>获得的实数值</returns>
		public decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得多个数据
		                                                                    ///       </summary>
		                                                                    /// <param name="values">保存数据的数组对象</param>
		                                                                    /// <returns>获得的数据个数</returns>
		public int GetValues(object[] values)
		{
			for (int i = 0; i < myTable.Columns.Count; i++)
			{
				values[i] = myRow[i];
			}
			return myTable.Columns.Count;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的名称
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>栏目名称</returns>
		public string GetName(int ordinal)
		{
			return myTable.Columns[ordinal].ColumnName;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的长整数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数据</returns>
		public long GetInt64(int ordinal)
		{
			return Convert.ToInt64(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的双精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数据</returns>
		public double GetDouble(int ordinal)
		{
			return Convert.ToDouble(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的布尔数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数据</returns>
		public bool GetBoolean(int ordinal)
		{
			return Convert.ToBoolean(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       本成员尚未实现
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public Guid GetGuid(int ordinal)
		{
			return default(Guid);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的时间数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的时间数据</returns>
		public DateTime GetDateTime(int ordinal)
		{
			return Convert.ToDateTime(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定名称的栏目序号
		                                                                    ///       </summary>
		                                                                    /// <param name="name">栏目名称</param>
		                                                                    /// <returns>栏目序号</returns>
		public int GetOrdinal(string name)
		{
			int num = 0;
			while (true)
			{
				if (num < myTable.Columns.Count)
				{
					if (string.Compare(name, myTable.Columns[num].ColumnName, ignoreCase: true) == 0)
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

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的数据类型名称
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>栏目数据类型名称</returns>
		public string GetDataTypeName(int ordinal)
		{
			return myTable.Columns[ordinal].DataType.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的单精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数据</returns>
		public float GetFloat(int ordinal)
		{
			return Convert.ToSingle(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       本成员未实现
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public IDataReader GetData(int int_0)
		{
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       本成员未实现
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <param name="fieldoffset">
		                                                                    /// </param>
		                                                                    /// <param name="buffer">
		                                                                    /// </param>
		                                                                    /// <param name="bufferoffset">
		                                                                    /// </param>
		                                                                    /// <param name="length">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的字符串数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数据</returns>
		public string GetString(int ordinal)
		{
			return Convert.ToString(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的字符数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的字符数据</returns>
		public char GetChar(int ordinal)
		{
			return Convert.ToChar(myRow[ordinal]);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的短整数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数据</returns>
		public short GetInt16(int ordinal)
		{
			return Convert.ToInt16(myRow[ordinal]);
		}
	}
}

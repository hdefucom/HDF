using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Data.DBase
{
	                                                                    /// <summary>
	                                                                    ///       DBase的DBF数据库文件的数据读取器抽象类
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public abstract class DBaseFileReader : DbDataReader, IRecordCount
	{
		                                                                    /// <summary>
		                                                                    ///       字段说明
		                                                                    ///       </summary>
		protected class FieldDescriptor
		{
			public string Name = null;

			public char Type = '\0';

			public int Length = 0;

			public Type DataType = null;

			public object Value = null;
		}

		protected string strName = null;

		protected DateTime dtmLastUpdatedDate = DateTime.Now;

		protected int intRecordCount = 0;

		                                                                    /// <summary>
		                                                                    ///       读取文本使用的文本编码对象
		                                                                    ///       </summary>
		protected Encoding myEncoding = Encoding.GetEncoding(936);

		                                                                    /// <summary>
		                                                                    ///       所有的字段列表
		                                                                    ///       </summary>
		protected ArrayList myFields = new ArrayList();

		                                                                    /// <summary>
		                                                                    ///       有效字段列表
		                                                                    ///       </summary>
		protected ArrayList myValidateFields = new ArrayList();

		                                                                    /// <summary>
		                                                                    ///       已经读取的记录个数
		                                                                    ///       </summary>
		protected int intRecordReadCount = 0;

		                                                                    /// <summary>
		                                                                    ///       数据流对象
		                                                                    ///       </summary>
		protected Stream myStream = null;

		                                                                    /// <summary>
		                                                                    ///       数据读取对象
		                                                                    ///       </summary>
		protected BinaryReader myReader = null;

		protected bool bolIsClosed = false;

		                                                                    /// <summary>
		                                                                    ///       对象名称
		                                                                    ///       </summary>
		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数据最后一次更新的日期
		                                                                    ///       </summary>
		public DateTime LastUpdatedDate => dtmLastUpdatedDate;

		                                                                    /// <summary>
		                                                                    ///       记录总个数
		                                                                    ///       </summary>
		public int RecordCount => intRecordCount;

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
		                                                                    ///       对象是否已经关闭
		                                                                    ///       </summary>
		public override bool IsClosed => bolIsClosed;

		public override object this[string name]
		{
			get
			{
				int num = 1;
				foreach (FieldDescriptor myValidateField in myValidateFields)
				{
					if (string.Compare(myValidateField.Name, name, ignoreCase: true) == 0)
					{
						return myValidateField.Value;
					}
				}
				throw new Exception("字段 " + name + " 不存在");
			}
		}

		public override int FieldCount => myValidateFields.Count;

		public override bool HasRows => RecordCount > 0;

		                                                                    /// <summary>
		                                                                    ///       测试对象
		                                                                    ///       </summary>
		internal static void Test()
		{
			int num = 4;
			DBaseIIIFileReader dBaseIIIFileReader = new DBaseIIIFileReader("D:\\擎天公司文档\\东航\\从王家文处获得的数据yy0811\\yy0811.DBF");
			for (int i = 0; i < dBaseIIIFileReader.FieldCount; i++)
			{
				Console.WriteLine(dBaseIIIFileReader.GetName(i));
			}
			Console.WriteLine("RecordCount:" + dBaseIIIFileReader.RecordCount);
			Console.WriteLine("Update:" + dBaseIIIFileReader.LastUpdatedDate);
			for (int i = 0; i < 100; i++)
			{
				dBaseIIIFileReader.Read();
			}
			for (int i = 0; i < dBaseIIIFileReader.FieldCount; i++)
			{
				Console.WriteLine(string.Concat(dBaseIIIFileReader.GetName(i), " ", dBaseIIIFileReader.GetDataTypeName(i), " = \"", dBaseIIIFileReader.GetValue(i), "\""));
			}
			dBaseIIIFileReader.Close();
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">数据文件名</param>
		public DBaseFileReader(string strFileName)
		{
			strName = Path.GetFileNameWithoutExtension(strFileName);
			myStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
			myReader = new BinaryReader(myStream, myEncoding);
			ReadFileHeader();
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="stream">数据流对象</param>
		public DBaseFileReader(Stream stream)
		{
			myStream = stream;
			myReader = new BinaryReader(myStream, myEncoding);
			ReadFileHeader();
		}

		                                                                    /// <summary>
		                                                                    ///       获取某个字段的长度
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public int GetFieldLength(int int_0)
		{
			return ((FieldDescriptor)myValidateFields[int_0]).Length;
		}

		                                                                    /// <summary>
		                                                                    ///       读取指定长度的字节
		                                                                    ///       </summary>
		                                                                    /// <param name="length">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		protected byte[] InnerReadBytes(int length)
		{
			byte[] array = myReader.ReadBytes(length);
			if (array == null || array.Length != length)
			{
				throw new IOException(DataStrings.ReaderEOF);
			}
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       读取头文件
		                                                                    ///       </summary>
		protected abstract void ReadFileHeader();

		                                                                    /// <summary>
		                                                                    ///       读取一条记录
		                                                                    ///       </summary>
		                                                                    /// <returns>操作是否成功</returns>
		protected abstract bool ReadOneRecord();

		public override bool NextResult()
		{
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       关闭对象
		                                                                    ///       </summary>
		public override void Close()
		{
			if (!bolIsClosed)
			{
				bolIsClosed = true;
				myStream.Close();
				myStream = null;
				myReader = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       读取下一条记录
		                                                                    ///       </summary>
		                                                                    /// <returns>操作是否成功</returns>
		public override bool Read()
		{
			if (bolIsClosed)
			{
				throw new Exception(DataStrings.ReaderClosed);
			}
			return ReadOneRecord();
		}

		public override DataTable GetSchemaTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(SchemaTableColumn.ColumnName, typeof(string));
			dataTable.Columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.ColumnSize, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.DataType, typeof(Type));
			dataTable.Columns.Add(SchemaTableColumn.AllowDBNull, typeof(bool));
			foreach (FieldDescriptor myField in myFields)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = myField.Name;
				dataRow[1] = myFields.IndexOf(myField);
				dataRow[2] = myField.Length;
				dataRow[3] = myField.DataType;
				dataRow[4] = true;
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
			return ((FieldDescriptor)myValidateFields[ordinal]).Value;
		}

		public override bool IsDBNull(int ordinal)
		{
			return DBNull.Value.Equals(((FieldDescriptor)myValidateFields[ordinal]).Value);
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
			return ((FieldDescriptor)myValidateFields[ordinal]).DataType;
		}

		public override decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(GetValue(ordinal));
		}

		public override int GetValues(object[] values)
		{
			if (values == null)
			{
				return 0;
			}
			int num = Math.Min(values.Length, myValidateFields.Count);
			for (int i = 0; i < num; i++)
			{
				values[i] = ((FieldDescriptor)myValidateFields[i]).Value;
			}
			return num;
		}

		public override string GetName(int ordinal)
		{
			return ((FieldDescriptor)myValidateFields[ordinal]).Name;
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
			int num = 0;
			while (true)
			{
				if (num < myValidateFields.Count)
				{
					if (string.Compare(((FieldDescriptor)myValidateFields[num]).Name, name, ignoreCase: true) == 0)
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

		public override string GetDataTypeName(int ordinal)
		{
			return ((FieldDescriptor)myValidateFields[ordinal]).DataType.Name;
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

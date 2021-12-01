using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Data.CSV
{
	                                                                    /// <summary>
	                                                                    ///       基于CSV格式的数据读取器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class CSVDataReader : DbDataReader
	{
		private class LineStringReader
		{
			protected string strText = null;

			protected int intLength = 0;

			protected int intPosition = 0;

			public bool EOF => intPosition >= intLength;

			public char PeekChar
			{
				get
				{
					if (intPosition < intLength)
					{
						return strText[intPosition];
					}
					return '\0';
				}
			}

			public LineStringReader(string string_0)
			{
				strText = string_0;
				intLength = strText.Length;
			}

			public string ReadTo(char char_0)
			{
				if (intPosition < intLength)
				{
					int num = strText.IndexOf(char_0, intPosition);
					if (num == -1)
					{
						num = strText.Length;
					}
					string result = strText.Substring(intPosition, num - intPosition);
					intPosition = num + 1;
					return result;
				}
				return null;
			}

			public void MoveAfter(char char_0)
			{
				if (intPosition < intLength)
				{
					int num = strText.IndexOf(char_0, intPosition);
					if (num == -1)
					{
						intPosition = strText.Length;
					}
					else
					{
						intPosition = num + 1;
					}
				}
			}

			public char ReadChar()
			{
				intPosition++;
				if (intPosition < intLength)
				{
					return strText[intPosition];
				}
				return '\0';
			}
		}

		private Encoding myContentEncoding = Encoding.GetEncoding(936);

		private int intStartRowIndex = 0;

		private bool bolIsFirstRowAsColumnNames = false;

		                                                                    /// <summary>
		                                                                    ///       字段分隔符
		                                                                    ///       </summary>
		protected char mySplitChar = ',';

		                                                                    /// <summary>
		                                                                    ///       文本读取器
		                                                                    ///       </summary>
		protected TextReader myReader = null;

		private string[] myColumnHeaders = null;

		private int intRecordIndex = -1;

		private bool bolReadPreData = false;

		                                                                    /// <summary>
		                                                                    ///       保存当前行所有数值的字符串数组
		                                                                    ///       </summary>
		protected string[] myValues = null;

		                                                                    /// <summary>
		                                                                    ///       文档内容编码格式
		                                                                    ///       </summary>
		public Encoding ContentEncoding
		{
			get
			{
				return myContentEncoding;
			}
			set
			{
				myContentEncoding = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       从0开始计算的有效数据的起始行号
		                                                                    ///       </summary>
		public int StartRowIndex
		{
			get
			{
				return intStartRowIndex;
			}
			set
			{
				intStartRowIndex = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       第一行数据是否作为字段标题
		                                                                    ///       </summary>
		public bool IsFirstRowAsColumnNames
		{
			get
			{
				return bolIsFirstRowAsColumnNames;
			}
			set
			{
				bolIsFirstRowAsColumnNames = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       字段分隔符
		                                                                    ///       </summary>
		public char SplitChar
		{
			get
			{
				return mySplitChar;
			}
			set
			{
				mySplitChar = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       从0开始的当前记录的编号
		                                                                    ///       </summary>
		public int RecordIndex => intRecordIndex;

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		public override int RecordsAffected
		{
			get
			{
				throw new NotSupportedException("RecordsAffected");
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断对象是否关闭
		                                                                    ///       </summary>
		public override bool IsClosed
		{
			get
			{
				if (myReader == null)
				{
					return true;
				}
				return false;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		public override int Depth
		{
			get
			{
				throw new NotSupportedException("Depth");
			}
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		public override object this[string name]
		{
			get
			{
				throw new NotSupportedException("This[name]");
			}
		}

		public override object this[int ordinal] => GetValue(ordinal);

		                                                                    /// <summary>
		                                                                    ///       字段个数
		                                                                    ///       </summary>
		public override int FieldCount
		{
			get
			{
				if (myColumnHeaders != null)
				{
					return myColumnHeaders.Length;
				}
				if (myValues == null)
				{
					return 0;
				}
				return myValues.Length;
			}
		}

		public override bool HasRows => true;

		                                                                    /// <summary>
		                                                                    ///       从一个字符串加载CSV数据读取器
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">CSV格式的字符串</param>
		                                                                    /// <returns>新创建的CSV数据读取器</returns>
		public static CSVDataReader FromString(string strText)
		{
			return new CSVDataReader(new StringReader(strText));
		}

		                                                                    /// <summary>
		                                                                    ///       从一个制表符分隔字符串中加载CSV数据读取器
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">CSV格式的字符串</param>
		                                                                    /// <returns>新创建的CSV数据读取器</returns>
		public static CSVDataReader FromTabString(string strText)
		{
			CSVDataReader cSVDataReader = new CSVDataReader(new StringReader(strText));
			cSVDataReader.SplitChar = '\t';
			return cSVDataReader;
		}

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public CSVDataReader()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定文本读取器初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="reader">文本读取器对象</param>
		public CSVDataReader(TextReader reader)
		{
			Open(reader);
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定的流初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="stream">流对象</param>
		                                                                    /// <param name="encoding">文本编码器</param>
		public CSVDataReader(Stream stream, Encoding encoding)
		{
			myContentEncoding = encoding;
			Open(stream);
		}

		                                                                    /// <summary>
		                                                                    ///       使用指定的文件初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strFileName">文件名</param>
		                                                                    /// <param name="encoding">文本编码器</param>
		public CSVDataReader(string strFileName, Encoding encoding)
		{
			myContentEncoding = encoding;
			Open(strFileName);
		}

		public void OpenString(string data)
		{
			Open(new StringReader(data));
		}

		public void Open(string fileName)
		{
			Open(new StreamReader(fileName, myContentEncoding, detectEncodingFromByteOrderMarks: true));
		}

		public void Open(Stream stream)
		{
			Open(new StreamReader(stream, myContentEncoding, detectEncodingFromByteOrderMarks: true));
		}

		public void Open(TextReader reader)
		{
			myReader = reader;
			if (intStartRowIndex > 0)
			{
				int num = intStartRowIndex;
				for (string text = reader.ReadLine(); text != null; text = reader.ReadLine())
				{
					num--;
					if (num == 0)
					{
						break;
					}
				}
			}
			if (bolIsFirstRowAsColumnNames)
			{
				Read();
				if (myValues == null)
				{
					return;
				}
				myColumnHeaders = new string[myValues.Length];
				for (int num = 0; num < myValues.Length; num++)
				{
					myColumnHeaders[num] = myValues[num].Trim();
				}
				bolReadPreData = false;
			}
			else
			{
				Read();
				bolReadPreData = true;
			}
			intRecordIndex = -1;
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override bool NextResult()
		{
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       关闭对象
		                                                                    ///       </summary>
		public override void Close()
		{
			if (myReader != null)
			{
				myReader.Close();
				myReader = null;
				myValues = null;
				myColumnHeaders = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       读取下一条记录
		                                                                    ///       </summary>
		                                                                    /// <returns>是否成功</returns>
		public override bool Read()
		{
			if (myReader == null)
			{
				return false;
			}
			if (bolReadPreData)
			{
				bolReadPreData = false;
				if (myValues != null && myValues.Length > 0)
				{
					intRecordIndex++;
					return true;
				}
				return false;
			}
			ArrayList arrayList = new ArrayList();
			bool flag = false;
			while (true)
			{
				int num = myReader.Peek();
				if (num != -1)
				{
					flag = true;
					SkipBlank();
					string value = ReadFieldValue();
					arrayList.Add(value);
					num = myReader.Peek();
					if (num == mySplitChar)
					{
						myReader.Read();
					}
					else if (num == 13 || num == 10)
					{
						myReader.Read();
						if (num == 13 && myReader.Peek() == 10)
						{
							myReader.Read();
						}
						break;
					}
					continue;
				}
				if (flag)
				{
					break;
				}
				myValues = null;
				return false;
			}
			myValues = (string[])arrayList.ToArray(typeof(string));
			intRecordIndex++;
			return true;
		}

		private string ReadFieldValue()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = myReader.Peek();
			bool flag;
			if (flag = (num == 34))
			{
				myReader.Read();
			}
			while (true)
			{
				num = myReader.Peek();
				if (num != -1)
				{
					if (num == 34 && flag)
					{
						myReader.Read();
						if (myReader.Peek() != 34)
						{
							break;
						}
						stringBuilder.Append('"');
						myReader.Read();
					}
					else
					{
						if (!flag && (num == 13 || num == 10 || num == mySplitChar))
						{
							break;
						}
						stringBuilder.Append((char)num);
						myReader.Read();
					}
					continue;
				}
				return stringBuilder.ToString();
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       跳过空格
		                                                                    ///       </summary>
		private void SkipBlank()
		{
			while (true)
			{
				int num = myReader.Peek();
				if (num != -1 && num != mySplitChar && (num == 32 || num == 9))
				{
					myReader.Read();
					continue;
				}
				break;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
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
				dataRow[3] = typeof(string);
				dataRow[4] = true;
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}

		                                                                    /// <summary>
		                                                                    ///       获得整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目号</param>
		                                                                    /// <returns>获得的数值</returns>
		public override int GetInt32(int ordinal)
		{
			return Convert.ToInt32(GetValue(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定栏目的数值
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的数值</returns>
		public override object GetValue(int ordinal)
		{
			if (myValues != null && ordinal >= 0 && ordinal < myValues.Length)
			{
				return myValues[ordinal];
			}
			return DBNull.Value;
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override bool IsDBNull(int ordinal)
		{
			if (myValues != null && ordinal >= 0 && ordinal < myValues.Length)
			{
				return false;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
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
		public override long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		                                                                    /// <summary>
		                                                                    ///       获得字节数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的字节数据</returns>
		public override byte GetByte(int ordinal)
		{
			return Convert.ToByte(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       返回字符串类型
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override Type GetFieldType(int ordinal)
		{
			return typeof(string);
		}

		                                                                    /// <summary>
		                                                                    ///       获得货币数值
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       获得多个数值
		                                                                    ///       </summary>
		                                                                    /// <param name="values">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override int GetValues(object[] values)
		{
			int num = 8;
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = DBNull.Value;
			}
			for (int i = 0; i < myValues.Length && i < values.Length; i++)
			{
				values[i] = myValues[i];
			}
			return Math.Min(myValues.Length, values.Length);
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定字段的名称
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override string GetName(int ordinal)
		{
			int num = 10;
			if (myColumnHeaders != null && ordinal >= 0 && ordinal < myColumnHeaders.Length)
			{
				return myColumnHeaders[ordinal];
			}
			return "Field" + ordinal;
		}

		                                                                    /// <summary>
		                                                                    ///       获得长整形数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的长整形数据</returns>
		public override long GetInt64(int ordinal)
		{
			return Convert.ToInt64(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       获得双精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的双精度浮点数</returns>
		public override double GetDouble(int ordinal)
		{
			return Convert.ToDouble(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       获得布尔类型数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的布尔类型数据</returns>
		public override bool GetBoolean(int ordinal)
		{
			return Convert.ToBoolean(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override Guid GetGuid(int ordinal)
		{
			throw new NotSupportedException("GetGuid");
		}

		                                                                    /// <summary>
		                                                                    ///       获得日期类型数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目号</param>
		                                                                    /// <returns>获得的日期数据</returns>
		public override DateTime GetDateTime(int ordinal)
		{
			return Convert.ToDateTime(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
		                                                                    ///       </summary>
		                                                                    /// <param name="name">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override int GetOrdinal(string name)
		{
			int num = 4;
			if (myColumnHeaders != null)
			{
				int num2 = 0;
				while (true)
				{
					if (num2 < myColumnHeaders.Length)
					{
						if (string.Compare(myColumnHeaders[num2], name, ignoreCase: true) == 0)
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
			throw new NotSupportedException("GetOrdinal");
		}

		                                                                    /// <summary>
		                                                                    ///       返回"string"
		                                                                    ///       </summary>
		                                                                    /// <param name="i">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override string GetDataTypeName(int ordinal)
		{
			return "string";
		}

		                                                                    /// <summary>
		                                                                    ///       获得单精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的单精度浮点数</returns>
		public override float GetFloat(int ordinal)
		{
			return Convert.ToSingle(GetString(ordinal));
		}

		                                                                    /// <summary>
		                                                                    ///       不支持
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
		public override long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			throw new NotSupportedException("GetChars");
		}

		                                                                    /// <summary>
		                                                                    ///       获得字符串类型数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的字符串数据</returns>
		public override string GetString(int ordinal)
		{
			if (myValues != null && ordinal >= 0 && ordinal < myValues.Length)
			{
				return myValues[ordinal];
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       获得字符数据
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的字符数据</returns>
		public override char GetChar(int ordinal)
		{
			string @string = GetString(ordinal);
			if (@string != null && @string.Length > 0)
			{
				return @string[0];
			}
			return '\0';
		}

		                                                                    /// <summary>
		                                                                    ///       获得短整数
		                                                                    ///       </summary>
		                                                                    /// <param name="i">栏目序号</param>
		                                                                    /// <returns>获得的短整数</returns>
		public override short GetInt16(int ordinal)
		{
			return Convert.ToInt16(GetString(ordinal));
		}

		public override IEnumerator GetEnumerator()
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}

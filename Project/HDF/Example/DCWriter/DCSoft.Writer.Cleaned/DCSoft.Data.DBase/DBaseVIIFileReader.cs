using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Data.DBase
{
	                                                                    /// <summary>
	                                                                    ///       DBaseVII的DBF数据库文件的数据读取器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class DBaseVIIFileReader : DBaseFileReader
	{
		public DBaseVIIFileReader(string strFileName)
			: base(strFileName)
		{
		}

		public DBaseVIIFileReader(Stream stream)
			: base(stream)
		{
		}

		                                                                    /// <summary>
		                                                                    ///       读取文件头信息
		                                                                    ///       </summary>
		protected override void ReadFileHeader()
		{
			myReader.ReadByte();
			byte b = myReader.ReadByte();
			byte month = myReader.ReadByte();
			byte day = myReader.ReadByte();
			dtmLastUpdatedDate = new DateTime(b + 1900, month, day);
			intRecordCount = myReader.ReadInt32();
			myReader.ReadInt16();
			myReader.ReadInt16();
			myReader.ReadBytes(4);
			myReader.ReadBytes(12);
			myReader.ReadBytes(1);
			myReader.ReadBytes(1);
			myReader.ReadBytes(32);
			myReader.ReadBytes(4);
			while (myReader.PeekChar() != 13)
			{
				FieldDescriptor fieldDescriptor = new FieldDescriptor();
				string @string = myEncoding.GetString(InnerReadBytes(32));
				char[] trimChars = new char[1];
				fieldDescriptor.Name = @string.TrimEnd(trimChars);
				fieldDescriptor.Type = Convert.ToChar(myReader.ReadByte());
				switch (fieldDescriptor.Type)
				{
				case 'C':
					fieldDescriptor.DataType = typeof(string);
					break;
				case '@':
				case 'D':
					fieldDescriptor.DataType = typeof(DateTime);
					break;
				case 'F':
					fieldDescriptor.DataType = typeof(float);
					break;
				case 'B':
				case 'G':
					fieldDescriptor.DataType = typeof(byte[]);
					break;
				case 'L':
					fieldDescriptor.DataType = typeof(bool);
					break;
				case 'M':
					fieldDescriptor.DataType = typeof(string);
					break;
				case 'N':
				case 'O':
					fieldDescriptor.DataType = typeof(double);
					break;
				case '+':
				case 'l':
					fieldDescriptor.DataType = typeof(long);
					break;
				}
				fieldDescriptor.Length = myReader.ReadByte();
				myReader.ReadByte();
				myReader.ReadBytes(2);
				myReader.ReadByte();
				myReader.ReadBytes(2);
				myReader.ReadBytes(4);
				myReader.ReadBytes(4);
				if (fieldDescriptor.Type != 'M')
				{
					myValidateFields.Add(fieldDescriptor);
				}
				myFields.Add(fieldDescriptor);
			}
			myReader.ReadByte();
			int num = myReader.ReadInt16();
			myReader.ReadInt16();
			int num2 = myReader.ReadInt16();
			myReader.ReadInt16();
			int num3 = myReader.ReadInt16();
			myReader.ReadInt16();
			myReader.ReadInt16();
			myReader.ReadInt16();
			int num4 = 15 * num + 16;
			myReader.ReadBytes(num4 - 16 + 1);
			int num5 = num4 + 14 * num2;
			myReader.ReadBytes(num5 - (num4 + 1) + 1);
			int num6 = num5 + 22 * num3;
			myReader.ReadBytes(num6 - (num5 + 1) + 1);
		}

		                                                                    /// <summary>
		                                                                    ///       读取一条记录
		                                                                    ///       </summary>
		                                                                    /// <returns>操作是否成功</returns>
		protected override bool ReadOneRecord()
		{
			if (intRecordReadCount >= intRecordCount)
			{
				return false;
			}
			if (myReader == null)
			{
				throw new Exception(DataStrings.ReaderClosed);
			}
			intRecordReadCount++;
			myReader.ReadByte();
			for (int i = 0; i < myFields.Count; i++)
			{
				FieldDescriptor fieldDescriptor = (FieldDescriptor)myFields[i];
				fieldDescriptor.Value = DBNull.Value;
				switch (fieldDescriptor.Type)
				{
				case '@':
				{
					string @string = myEncoding.GetString(InnerReadBytes(8));
					DateTime minValue = DateTime.MinValue;
					if (@string != null)
					{
						@string = @string.Trim();
						if (@string.Length == 8)
						{
							minValue = new DateTime(Convert.ToInt32(@string.Substring(0, 4)), Convert.ToInt32(@string.Substring(4, 2)), Convert.ToInt32(@string.Substring(6, 2)), Convert.ToInt32(@string.Substring(8, 2)), Convert.ToInt32(@string.Substring(10, 2)), Convert.ToInt32(@string.Substring(12, 2)));
							fieldDescriptor.Value = minValue;
						}
					}
					break;
				}
				case 'C':
				{
					string @string = myEncoding.GetString(InnerReadBytes(fieldDescriptor.Length));
					if (@string == null || @string.Trim().Length == 0)
					{
						fieldDescriptor.Value = DBNull.Value;
					}
					else
					{
						fieldDescriptor.Value = @string.Trim();
					}
					break;
				}
				case 'D':
				{
					string @string = myEncoding.GetString(InnerReadBytes(8));
					DateTime minValue = DateTime.MinValue;
					if (@string != null)
					{
						@string = @string.Trim();
						if (@string.Length == 8)
						{
							minValue = new DateTime(Convert.ToInt32(@string.Substring(0, 4)), Convert.ToInt32(@string.Substring(4, 2)), Convert.ToInt32(@string.Substring(6, 2)));
							fieldDescriptor.Value = minValue;
						}
					}
					break;
				}
				case 'B':
				case 'G':
					fieldDescriptor.Value = InnerReadBytes(fieldDescriptor.Length);
					break;
				case 'I':
				{
					string @string = myEncoding.GetString(InnerReadBytes(fieldDescriptor.Length));
					short result2 = 0;
					if (short.TryParse(@string, NumberStyles.Integer, null, out result2))
					{
						fieldDescriptor.Value = result2;
					}
					else
					{
						fieldDescriptor.Value = DBNull.Value;
					}
					break;
				}
				case 'L':
				{
					char c = Convert.ToChar(myReader.ReadByte());
					if (c == 'y' || c == 'Y' || c == 't' || c == 'T')
					{
						fieldDescriptor.Value = true;
					}
					else if (c == 'n' || c == 'N' || c == 'f' || c == 'F')
					{
						fieldDescriptor.Value = false;
					}
					else
					{
						fieldDescriptor.Value = DBNull.Value;
					}
					break;
				}
				case 'M':
					myReader.ReadBytes(10);
					break;
				case 'F':
				case 'N':
				case 'O':
				{
					string @string = myEncoding.GetString(InnerReadBytes(fieldDescriptor.Length));
					double result3 = 0.0;
					if (double.TryParse(@string, NumberStyles.Number, null, out result3))
					{
						fieldDescriptor.Value = result3;
					}
					else
					{
						fieldDescriptor.Value = DBNull.Value;
					}
					break;
				}
				case '+':
				{
					string @string = myEncoding.GetString(InnerReadBytes(fieldDescriptor.Length));
					long result = 0L;
					if (long.TryParse(@string, NumberStyles.Number, null, out result))
					{
						fieldDescriptor.Value = result;
					}
					else
					{
						fieldDescriptor.Value = DBNull.Value;
					}
					break;
				}
				}
			}
			return true;
		}
	}
}

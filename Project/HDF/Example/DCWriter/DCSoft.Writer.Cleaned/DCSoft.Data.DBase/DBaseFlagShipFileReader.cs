using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Data.DBase
{
	                                                                    /// <summary>
	                                                                    ///       FlagShip的DBF数据库文件的数据读取器
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class DBaseFlagShipFileReader : DBaseFileReader
	{
		public DBaseFlagShipFileReader(string strFileName)
			: base(strFileName)
		{
		}

		public DBaseFlagShipFileReader(Stream stream)
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
			myReader.ReadBytes(20);
			while (myReader.PeekChar() != 13)
			{
				FieldDescriptor fieldDescriptor = new FieldDescriptor();
				string @string = myEncoding.GetString(InnerReadBytes(11));
				char[] trimChars = new char[1];
				fieldDescriptor.Name = @string.TrimEnd(trimChars);
				fieldDescriptor.Type = Convert.ToChar(myReader.ReadByte());
				switch (fieldDescriptor.Type)
				{
				case '8':
					fieldDescriptor.DataType = typeof(double);
					break;
				case '2':
					fieldDescriptor.DataType = typeof(short);
					break;
				case '4':
					fieldDescriptor.DataType = typeof(long);
					break;
				case 'V':
					fieldDescriptor.DataType = typeof(object);
					break;
				case 'L':
					fieldDescriptor.DataType = typeof(bool);
					break;
				case 'M':
					fieldDescriptor.DataType = typeof(string);
					break;
				case 'N':
					fieldDescriptor.DataType = typeof(double);
					break;
				case 'C':
					fieldDescriptor.DataType = typeof(string);
					break;
				case 'D':
					fieldDescriptor.DataType = typeof(DateTime);
					break;
				case 'F':
					fieldDescriptor.DataType = typeof(double);
					break;
				}
				myReader.ReadBytes(4);
				fieldDescriptor.Length = myReader.ReadByte();
				myReader.ReadByte();
				myReader.ReadBytes(14);
				if (fieldDescriptor.Type != 'M')
				{
					myValidateFields.Add(fieldDescriptor);
				}
				myFields.Add(fieldDescriptor);
			}
			myReader.ReadByte();
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
				case '2':
				case '4':
				case '8':
					fieldDescriptor.Value = DBNull.Value;
					break;
				case 'V':
					fieldDescriptor.Value = InnerReadBytes(fieldDescriptor.Length);
					break;
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
				case 'F':
				case 'N':
				{
					string @string = myEncoding.GetString(InnerReadBytes(fieldDescriptor.Length));
					double result = 0.0;
					if (double.TryParse(@string, NumberStyles.Number, null, out result))
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

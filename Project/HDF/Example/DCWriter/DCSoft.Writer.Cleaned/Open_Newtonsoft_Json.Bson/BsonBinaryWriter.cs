using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal class BsonBinaryWriter
	{
		private static readonly Encoding Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		private readonly BinaryWriter _writer;

		private byte[] _largeByteBuffer;

		public DateTimeKind DateTimeKindHandling
		{
			get;
			set;
		}

		public BsonBinaryWriter(BinaryWriter writer)
		{
			DateTimeKindHandling = DateTimeKind.Utc;
			_writer = writer;
		}

		public void Flush()
		{
			_writer.Flush();
		}

		public void Close()
		{
			_writer.Close();
		}

		public void WriteToken(BsonToken bsonToken_0)
		{
			CalculateSize(bsonToken_0);
			WriteTokenInternal(bsonToken_0);
		}

		private void WriteTokenInternal(BsonToken bsonToken_0)
		{
			int num = 4;
			switch (bsonToken_0.Type)
			{
			case BsonType.Undefined:
			case BsonType.Null:
				break;
			case BsonType.Number:
			{
				BsonValue bsonValue = (BsonValue)bsonToken_0;
				_writer.Write(Convert.ToDouble(bsonValue.Value, CultureInfo.InvariantCulture));
				break;
			}
			case BsonType.String:
			{
				BsonString bsonString = (BsonString)bsonToken_0;
				WriteString((string)bsonString.Value, bsonString.ByteCount, bsonString.CalculatedSize - 4);
				break;
			}
			case BsonType.Object:
			{
				BsonObject bsonObject = (BsonObject)bsonToken_0;
				_writer.Write(bsonObject.CalculatedSize);
				foreach (BsonProperty item in bsonObject)
				{
					_writer.Write((sbyte)item.Value.Type);
					WriteString((string)item.Name.Value, item.Name.ByteCount, null);
					WriteTokenInternal(item.Value);
				}
				_writer.Write((byte)0);
				break;
			}
			case BsonType.Array:
			{
				BsonArray bsonArray = (BsonArray)bsonToken_0;
				_writer.Write(bsonArray.CalculatedSize);
				ulong num2 = 0uL;
				foreach (BsonToken item2 in bsonArray)
				{
					_writer.Write((sbyte)item2.Type);
					WriteString(num2.ToString(CultureInfo.InvariantCulture), MathUtils.IntLength(num2), null);
					WriteTokenInternal(item2);
					num2++;
				}
				_writer.Write((byte)0);
				break;
			}
			case BsonType.Binary:
			{
				BsonBinary bsonBinary = (BsonBinary)bsonToken_0;
				byte[] array = (byte[])bsonBinary.Value;
				_writer.Write(array.Length);
				_writer.Write((byte)bsonBinary.BinaryType);
				_writer.Write(array);
				break;
			}
			case BsonType.Oid:
			{
				BsonValue bsonValue = (BsonValue)bsonToken_0;
				byte[] array = (byte[])bsonValue.Value;
				_writer.Write(array);
				break;
			}
			case BsonType.Boolean:
			{
				BsonValue bsonValue = (BsonValue)bsonToken_0;
				_writer.Write((bool)bsonValue.Value);
				break;
			}
			case BsonType.Date:
			{
				BsonValue bsonValue = (BsonValue)bsonToken_0;
				long value = 0L;
				if (bsonValue.Value is DateTime)
				{
					DateTime dateTime = (DateTime)bsonValue.Value;
					if (DateTimeKindHandling == DateTimeKind.Utc)
					{
						dateTime = dateTime.ToUniversalTime();
					}
					else if (DateTimeKindHandling == DateTimeKind.Local)
					{
						dateTime = dateTime.ToLocalTime();
					}
					value = DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTime, convertToUtc: false);
				}
				_writer.Write(value);
				break;
			}
			case BsonType.Regex:
			{
				BsonRegex bsonRegex = (BsonRegex)bsonToken_0;
				WriteString((string)bsonRegex.Pattern.Value, bsonRegex.Pattern.ByteCount, null);
				WriteString((string)bsonRegex.Options.Value, bsonRegex.Options.ByteCount, null);
				break;
			}
			case BsonType.Integer:
			{
				BsonValue bsonValue = (BsonValue)bsonToken_0;
				_writer.Write(Convert.ToInt32(bsonValue.Value, CultureInfo.InvariantCulture));
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("t", StringUtils.FormatWith("Unexpected token when writing BSON: {0}", CultureInfo.InvariantCulture, bsonToken_0.Type));
			case BsonType.Long:
			{
				BsonValue bsonValue = (BsonValue)bsonToken_0;
				_writer.Write(Convert.ToInt64(bsonValue.Value, CultureInfo.InvariantCulture));
				break;
			}
			}
		}

		private void WriteString(string string_0, int byteCount, int? calculatedlengthPrefix)
		{
			if (calculatedlengthPrefix.HasValue)
			{
				_writer.Write(calculatedlengthPrefix.Value);
			}
			WriteUtf8Bytes(string_0, byteCount);
			_writer.Write((byte)0);
		}

		public void WriteUtf8Bytes(string string_0, int byteCount)
		{
			if (string_0 != null)
			{
				if (_largeByteBuffer == null)
				{
					_largeByteBuffer = new byte[256];
				}
				if (byteCount <= 256)
				{
					Encoding.GetBytes(string_0, 0, string_0.Length, _largeByteBuffer, 0);
					_writer.Write(_largeByteBuffer, 0, byteCount);
				}
				else
				{
					byte[] bytes = Encoding.GetBytes(string_0);
					_writer.Write(bytes);
				}
			}
		}

		private int CalculateSize(int stringByteCount)
		{
			return stringByteCount + 1;
		}

		private int CalculateSizeWithLength(int stringByteCount, bool includeSize)
		{
			int num = (!includeSize) ? 1 : 5;
			return num + stringByteCount;
		}

		private int CalculateSize(BsonToken bsonToken_0)
		{
			int num = 19;
			switch (bsonToken_0.Type)
			{
			case BsonType.Number:
				return 8;
			case BsonType.String:
			{
				BsonString bsonString = (BsonString)bsonToken_0;
				string text = (string)bsonString.Value;
				bsonString.ByteCount = ((text != null) ? Encoding.GetByteCount(text) : 0);
				bsonString.CalculatedSize = CalculateSizeWithLength(bsonString.ByteCount, bsonString.IncludeLength);
				return bsonString.CalculatedSize;
			}
			case BsonType.Object:
			{
				BsonObject bsonObject = (BsonObject)bsonToken_0;
				int num6 = 4;
				foreach (BsonProperty item in bsonObject)
				{
					int num2 = 1;
					num2 = 1 + CalculateSize(item.Name);
					num2 += CalculateSize(item.Value);
					num6 += num2;
				}
				return bsonObject.CalculatedSize = num6 + 1;
			}
			case BsonType.Array:
			{
				BsonArray bsonArray = (BsonArray)bsonToken_0;
				int num2 = 4;
				ulong num4 = 0uL;
				foreach (BsonToken item2 in bsonArray)
				{
					num2++;
					num2 += CalculateSize(MathUtils.IntLength(num4));
					num2 += CalculateSize(item2);
					num4++;
				}
				num2 = (bsonArray.CalculatedSize = num2 + 1);
				return bsonArray.CalculatedSize;
			}
			case BsonType.Binary:
			{
				BsonBinary bsonBinary = (BsonBinary)bsonToken_0;
				byte[] array = (byte[])bsonBinary.Value;
				bsonBinary.CalculatedSize = 5 + array.Length;
				return bsonBinary.CalculatedSize;
			}
			case BsonType.Oid:
				return 12;
			case BsonType.Boolean:
				return 1;
			case BsonType.Date:
				return 8;
			case BsonType.Undefined:
			case BsonType.Null:
				return 0;
			case BsonType.Regex:
			{
				BsonRegex bsonRegex = (BsonRegex)bsonToken_0;
				int num2 = 0;
				num2 = 0 + CalculateSize(bsonRegex.Pattern);
				num2 = (bsonRegex.CalculatedSize = num2 + CalculateSize(bsonRegex.Options));
				return bsonRegex.CalculatedSize;
			}
			case BsonType.Integer:
				return 4;
			default:
				throw new ArgumentOutOfRangeException("t", StringUtils.FormatWith("Unexpected token when writing BSON: {0}", CultureInfo.InvariantCulture, bsonToken_0.Type));
			case BsonType.Long:
				return 8;
			}
		}
	}
}

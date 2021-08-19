using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Open_Newtonsoft_Json.Bson
{
	/// <summary>
	///       Represents a reader that provides fast, non-cached, forward-only access to serialized JSON data.
	///       </summary>
	[ComVisible(false)]
	public class BsonReader : JsonReader
	{
		[ComVisible(false)]
		private enum BsonReaderState
		{
			Normal,
			ReferenceStart,
			ReferenceRef,
			ReferenceId,
			CodeWScopeStart,
			CodeWScopeCode,
			CodeWScopeScope,
			CodeWScopeScopeObject,
			CodeWScopeScopeEnd
		}

		[ComVisible(false)]
		private class ContainerContext
		{
			public readonly BsonType Type;

			public int Length;

			public int Position;

			public ContainerContext(BsonType type)
			{
				Type = type;
			}
		}

		private const int MaxCharBytesSize = 128;

		private static readonly byte[] SeqRange1 = new byte[2]
		{
			0,
			127
		};

		private static readonly byte[] SeqRange2 = new byte[2]
		{
			194,
			223
		};

		private static readonly byte[] SeqRange3 = new byte[2]
		{
			224,
			239
		};

		private static readonly byte[] SeqRange4 = new byte[2]
		{
			240,
			244
		};

		private readonly BinaryReader _reader;

		private readonly List<ContainerContext> _stack;

		private byte[] _byteBuffer;

		private char[] _charBuffer;

		private BsonType _currentElementType;

		private BsonReaderState _bsonReaderState;

		private ContainerContext _currentContext;

		private bool _readRootValueAsArray;

		private bool _jsonNet35BinaryCompatibility;

		private DateTimeKind _dateTimeKindHandling;

		/// <summary>
		///       Gets or sets a value indicating whether binary data reading should compatible with incorrect Json.NET 3.5 written binary.
		///       </summary>
		/// <value>
		///   <c>true</c> if binary data reading will be compatible with incorrect Json.NET 3.5 written binary; otherwise, <c>false</c>.
		///       </value>
		[Obsolete("JsonNet35BinaryCompatibility will be removed in a future version of Json.NET.")]
		public bool JsonNet35BinaryCompatibility
		{
			get
			{
				return _jsonNet35BinaryCompatibility;
			}
			set
			{
				_jsonNet35BinaryCompatibility = value;
			}
		}

		/// <summary>
		///       Gets or sets a value indicating whether the root object will be read as a JSON array.
		///       </summary>
		/// <value>
		///   <c>true</c> if the root object will be read as a JSON array; otherwise, <c>false</c>.
		///       </value>
		public bool ReadRootValueAsArray
		{
			get
			{
				return _readRootValueAsArray;
			}
			set
			{
				_readRootValueAsArray = value;
			}
		}

		/// <summary>
		///       Gets or sets the <see cref="T:System.DateTimeKind" /> used when reading <see cref="T:System.DateTime" /> values from BSON.
		///       </summary>
		/// <value>The <see cref="T:System.DateTimeKind" /> used when reading <see cref="T:System.DateTime" /> values from BSON.</value>
		public DateTimeKind DateTimeKindHandling
		{
			get
			{
				return _dateTimeKindHandling;
			}
			set
			{
				_dateTimeKindHandling = value;
			}
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Bson.BsonReader" /> class.
		///       </summary>
		/// <param name="stream">The stream.</param>
		public BsonReader(Stream stream)
			: this(stream, readRootValueAsArray: false, DateTimeKind.Local)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Bson.BsonReader" /> class.
		///       </summary>
		/// <param name="reader">The reader.</param>
		public BsonReader(BinaryReader reader)
			: this(reader, readRootValueAsArray: false, DateTimeKind.Local)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Bson.BsonReader" /> class.
		///       </summary>
		/// <param name="stream">The stream.</param>
		/// <param name="readRootValueAsArray">if set to <c>true</c> the root object will be read as a JSON array.</param>
		/// <param name="dateTimeKindHandling">The <see cref="T:System.DateTimeKind" /> used when reading <see cref="T:System.DateTime" /> values from BSON.</param>
		public BsonReader(Stream stream, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
			ValidationUtils.ArgumentNotNull(stream, "stream");
			_reader = new BinaryReader(stream);
			_stack = new List<ContainerContext>();
			_readRootValueAsArray = readRootValueAsArray;
			_dateTimeKindHandling = dateTimeKindHandling;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Bson.BsonReader" /> class.
		///       </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="readRootValueAsArray">if set to <c>true</c> the root object will be read as a JSON array.</param>
		/// <param name="dateTimeKindHandling">The <see cref="T:System.DateTimeKind" /> used when reading <see cref="T:System.DateTime" /> values from BSON.</param>
		public BsonReader(BinaryReader reader, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			_reader = reader;
			_stack = new List<ContainerContext>();
			_readRootValueAsArray = readRootValueAsArray;
			_dateTimeKindHandling = dateTimeKindHandling;
		}

		private string ReadElement()
		{
			_currentElementType = ReadType();
			return ReadString();
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Byte" />[].
		///       </summary>
		/// <returns>
		///       A <see cref="T:System.Byte" />[] or a null reference if the next JSON token is null. This method will return <c>null</c> at the end of an array.
		///       </returns>
		public override byte[] ReadAsBytes()
		{
			return ReadAsBytesInternal();
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.</returns>
		public override decimal? ReadAsDecimal()
		{
			return ReadAsDecimalInternal();
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.</returns>
		public override int? ReadAsInt32()
		{
			return ReadAsInt32Internal();
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.String" />.
		///       </summary>
		/// <returns>A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.</returns>
		public override string ReadAsString()
		{
			return ReadAsStringInternal();
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.</returns>
		public override DateTime? ReadAsDateTime()
		{
			return ReadAsDateTimeInternal();
		}

		/// <summary>
		///       Reads the next JSON token from the stream.
		///       </summary>
		/// <returns>
		///       true if the next token was read successfully; false if there are no more tokens to read.
		///       </returns>
		public override bool Read()
		{
			_readType = Open_Newtonsoft_Json.ReadType.Read;
			return ReadInternal();
		}

		internal override bool ReadInternal()
		{
			int num = 6;
			try
			{
				bool flag;
				switch (_bsonReaderState)
				{
				default:
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected state: {0}", CultureInfo.InvariantCulture, _bsonReaderState));
				case BsonReaderState.Normal:
					flag = ReadNormal();
					break;
				case BsonReaderState.ReferenceStart:
				case BsonReaderState.ReferenceRef:
				case BsonReaderState.ReferenceId:
					flag = ReadReference();
					break;
				case BsonReaderState.CodeWScopeStart:
				case BsonReaderState.CodeWScopeCode:
				case BsonReaderState.CodeWScopeScope:
				case BsonReaderState.CodeWScopeScopeObject:
				case BsonReaderState.CodeWScopeScopeEnd:
					flag = ReadCodeWScope();
					break;
				}
				if (!flag)
				{
					SetToken(JsonToken.None);
					return false;
				}
				return true;
			}
			catch (EndOfStreamException)
			{
				SetToken(JsonToken.None);
				return false;
			}
		}

		/// <summary>
		///       Changes the <see cref="T:Open_Newtonsoft_Json.JsonReader.State" /> to Closed.
		///       </summary>
		public override void Close()
		{
			base.Close();
			if (base.CloseInput && _reader != null)
			{
				_reader.Close();
			}
		}

		private bool ReadCodeWScope()
		{
			int num = 4;
			switch (_bsonReaderState)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case BsonReaderState.CodeWScopeStart:
				SetToken(JsonToken.PropertyName, "$code");
				_bsonReaderState = BsonReaderState.CodeWScopeCode;
				return true;
			case BsonReaderState.CodeWScopeCode:
				ReadInt32();
				SetToken(JsonToken.String, ReadLengthString());
				_bsonReaderState = BsonReaderState.CodeWScopeScope;
				return true;
			case BsonReaderState.CodeWScopeScope:
			{
				if (base.CurrentState == State.PostValue)
				{
					SetToken(JsonToken.PropertyName, "$scope");
					return true;
				}
				SetToken(JsonToken.StartObject);
				_bsonReaderState = BsonReaderState.CodeWScopeScopeObject;
				ContainerContext containerContext = new ContainerContext(BsonType.Object);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				return true;
			}
			case BsonReaderState.CodeWScopeScopeObject:
			{
				bool result;
				if ((result = ReadNormal()) && TokenType == JsonToken.EndObject)
				{
					_bsonReaderState = BsonReaderState.CodeWScopeScopeEnd;
				}
				return result;
			}
			case BsonReaderState.CodeWScopeScopeEnd:
				SetToken(JsonToken.EndObject);
				_bsonReaderState = BsonReaderState.Normal;
				return true;
			}
		}

		private bool ReadReference()
		{
			int num = 0;
			switch (base.CurrentState)
			{
			default:
				throw JsonReaderException.Create(this, "Unexpected state when reading BSON reference: " + base.CurrentState);
			case State.PostValue:
				if (_bsonReaderState == BsonReaderState.ReferenceRef)
				{
					SetToken(JsonToken.PropertyName, "$id");
					_bsonReaderState = BsonReaderState.ReferenceId;
					return true;
				}
				if (_bsonReaderState == BsonReaderState.ReferenceId)
				{
					SetToken(JsonToken.EndObject);
					_bsonReaderState = BsonReaderState.Normal;
					return true;
				}
				throw JsonReaderException.Create(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
			case State.Property:
				if (_bsonReaderState == BsonReaderState.ReferenceRef)
				{
					SetToken(JsonToken.String, ReadLengthString());
					return true;
				}
				if (_bsonReaderState == BsonReaderState.ReferenceId)
				{
					SetToken(JsonToken.Bytes, ReadBytes(12));
					return true;
				}
				throw JsonReaderException.Create(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
			case State.ObjectStart:
				SetToken(JsonToken.PropertyName, "$ref");
				_bsonReaderState = BsonReaderState.ReferenceRef;
				return true;
			}
		}

		private bool ReadNormal()
		{
			int num = 17;
			switch (base.CurrentState)
			{
			case State.Start:
			{
				JsonToken token2 = (!_readRootValueAsArray) ? JsonToken.StartObject : JsonToken.StartArray;
				BsonType type = (!_readRootValueAsArray) ? BsonType.Object : BsonType.Array;
				SetToken(token2);
				ContainerContext containerContext = new ContainerContext(type);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				return true;
			}
			case State.Property:
				ReadType(_currentElementType);
				return true;
			default:
				throw new ArgumentOutOfRangeException();
			case State.Complete:
			case State.Closed:
				return false;
			case State.ObjectStart:
			case State.ArrayStart:
			case State.PostValue:
			{
				ContainerContext currentContext = _currentContext;
				if (currentContext == null)
				{
					return false;
				}
				int num2 = currentContext.Length - 1;
				if (currentContext.Position < num2)
				{
					if (currentContext.Type == BsonType.Array)
					{
						ReadElement();
						ReadType(_currentElementType);
						return true;
					}
					SetToken(JsonToken.PropertyName, ReadElement());
					return true;
				}
				if (currentContext.Position == num2)
				{
					if (ReadByte() != 0)
					{
						throw JsonReaderException.Create(this, "Unexpected end of object byte value.");
					}
					PopContext();
					if (_currentContext != null)
					{
						MovePosition(currentContext.Length);
					}
					JsonToken token = (currentContext.Type == BsonType.Object) ? JsonToken.EndObject : JsonToken.EndArray;
					SetToken(token);
					return true;
				}
				throw JsonReaderException.Create(this, "Read past end of current container context.");
			}
			case State.ConstructorStart:
			case State.Constructor:
			case State.Error:
			case State.Finished:
				return false;
			}
		}

		private void PopContext()
		{
			_stack.RemoveAt(_stack.Count - 1);
			if (_stack.Count == 0)
			{
				_currentContext = null;
			}
			else
			{
				_currentContext = _stack[_stack.Count - 1];
			}
		}

		private void PushContext(ContainerContext newContext)
		{
			_stack.Add(newContext);
			_currentContext = newContext;
		}

		private byte ReadByte()
		{
			MovePosition(1);
			return _reader.ReadByte();
		}

		private void ReadType(BsonType type)
		{
			int num = 2;
			switch (type)
			{
			default:
				throw new ArgumentOutOfRangeException("type", "Unexpected BsonType value: " + type);
			case BsonType.Number:
			{
				double num2 = ReadDouble();
				if (_floatParseHandling == FloatParseHandling.Decimal)
				{
					SetToken(JsonToken.Float, Convert.ToDecimal(num2, CultureInfo.InvariantCulture));
				}
				else
				{
					SetToken(JsonToken.Float, num2);
				}
				break;
			}
			case BsonType.Object:
			{
				SetToken(JsonToken.StartObject);
				ContainerContext containerContext = new ContainerContext(BsonType.Object);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				break;
			}
			case BsonType.Array:
			{
				SetToken(JsonToken.StartArray);
				ContainerContext containerContext = new ContainerContext(BsonType.Array);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				break;
			}
			case BsonType.Binary:
			{
				BsonBinaryType binaryType;
				byte[] array = ReadBinary(out binaryType);
				object value3 = (binaryType != BsonBinaryType.Uuid) ? array : ((object)new Guid(array));
				SetToken(JsonToken.Bytes, value3);
				break;
			}
			case BsonType.Undefined:
				SetToken(JsonToken.Undefined);
				break;
			case BsonType.Oid:
			{
				byte[] value2 = ReadBytes(12);
				SetToken(JsonToken.Bytes, value2);
				break;
			}
			case BsonType.Boolean:
			{
				bool flag = Convert.ToBoolean(ReadByte());
				SetToken(JsonToken.Boolean, flag);
				break;
			}
			case BsonType.Date:
			{
				long javaScriptTicks = ReadInt64();
				DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(javaScriptTicks);
				DateTime dateTime2;
				switch (DateTimeKindHandling)
				{
				case DateTimeKind.Unspecified:
					dateTime2 = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
					break;
				default:
					dateTime2 = dateTime;
					break;
				case DateTimeKind.Local:
					dateTime2 = dateTime.ToLocalTime();
					break;
				}
				SetToken(JsonToken.Date, dateTime2);
				break;
			}
			case BsonType.Null:
				SetToken(JsonToken.Null);
				break;
			case BsonType.Regex:
			{
				string str = ReadString();
				string str2 = ReadString();
				string value = "/" + str + "/" + str2;
				SetToken(JsonToken.String, value);
				break;
			}
			case BsonType.Reference:
				SetToken(JsonToken.StartObject);
				_bsonReaderState = BsonReaderState.ReferenceStart;
				break;
			case BsonType.Code:
				SetToken(JsonToken.String, ReadLengthString());
				break;
			case BsonType.String:
			case BsonType.Symbol:
				SetToken(JsonToken.String, ReadLengthString());
				break;
			case BsonType.CodeWScope:
				SetToken(JsonToken.StartObject);
				_bsonReaderState = BsonReaderState.CodeWScopeStart;
				break;
			case BsonType.Integer:
				SetToken(JsonToken.Integer, (long)ReadInt32());
				break;
			case BsonType.TimeStamp:
			case BsonType.Long:
				SetToken(JsonToken.Integer, ReadInt64());
				break;
			}
		}

		private byte[] ReadBinary(out BsonBinaryType binaryType)
		{
			int count = ReadInt32();
			binaryType = (BsonBinaryType)ReadByte();
			if (binaryType == BsonBinaryType.BinaryOld && !_jsonNet35BinaryCompatibility)
			{
				count = ReadInt32();
			}
			return ReadBytes(count);
		}

		private string ReadString()
		{
			EnsureBuffers();
			StringBuilder stringBuilder = null;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				byte b;
				while (num3 < 128 && (b = _reader.ReadByte()) > 0)
				{
					_byteBuffer[num3++] = b;
				}
				int num4 = num3 - num2;
				num += num4;
				if (num3 >= 128 || stringBuilder != null)
				{
					int lastFullCharStop = GetLastFullCharStop(num3 - 1);
					int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder(256);
					}
					stringBuilder.Append(_charBuffer, 0, chars);
					if (lastFullCharStop < num4 - 1)
					{
						num2 = num4 - lastFullCharStop - 1;
						Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, num2);
						continue;
					}
					if (num3 < 128)
					{
						break;
					}
					num2 = 0;
					continue;
				}
				int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, num4, _charBuffer, 0);
				MovePosition(num + 1);
				return new string(_charBuffer, 0, chars2);
			}
			MovePosition(num + 1);
			return stringBuilder.ToString();
		}

		private string ReadLengthString()
		{
			int num = ReadInt32();
			MovePosition(num);
			string @string = GetString(num - 1);
			_reader.ReadByte();
			return @string;
		}

		private string GetString(int length)
		{
			int num = 16;
			if (length == 0)
			{
				return string.Empty;
			}
			EnsureBuffers();
			StringBuilder stringBuilder = null;
			int num2 = 0;
			int num3 = 0;
			do
			{
				int count = (length - num2 <= 128 - num3) ? (length - num2) : (128 - num3);
				int num4 = _reader.Read(_byteBuffer, num3, count);
				if (num4 != 0)
				{
					num2 += num4;
					num4 += num3;
					int chars;
					if (num4 != length)
					{
						int lastFullCharStop = GetLastFullCharStop(num4 - 1);
						if (stringBuilder == null)
						{
							stringBuilder = new StringBuilder(length);
						}
						chars = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
						stringBuilder.Append(_charBuffer, 0, chars);
						if (lastFullCharStop < num4 - 1)
						{
							num3 = num4 - lastFullCharStop - 1;
							Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, num3);
						}
						else
						{
							num3 = 0;
						}
						continue;
					}
					chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num4, _charBuffer, 0);
					return new string(_charBuffer, 0, chars);
				}
				throw new EndOfStreamException("Unable to read beyond the end of the stream.");
			}
			while (num2 < length);
			return stringBuilder.ToString();
		}

		private int GetLastFullCharStop(int start)
		{
			int num = start;
			int num2 = 0;
			for (; num >= 0; num--)
			{
				num2 = BytesInSequence(_byteBuffer[num]);
				switch (num2)
				{
				case 0:
					continue;
				default:
					num--;
					break;
				case 1:
					break;
				}
				break;
			}
			if (num2 == start - num)
			{
				return start;
			}
			return num;
		}

		private int BytesInSequence(byte byte_0)
		{
			if (byte_0 <= SeqRange1[1])
			{
				return 1;
			}
			if (byte_0 >= SeqRange2[0] && byte_0 <= SeqRange2[1])
			{
				return 2;
			}
			if (byte_0 >= SeqRange3[0] && byte_0 <= SeqRange3[1])
			{
				return 3;
			}
			if (byte_0 >= SeqRange4[0] && byte_0 <= SeqRange4[1])
			{
				return 4;
			}
			return 0;
		}

		private void EnsureBuffers()
		{
			if (_byteBuffer == null)
			{
				_byteBuffer = new byte[128];
			}
			if (_charBuffer == null)
			{
				int maxCharCount = Encoding.UTF8.GetMaxCharCount(128);
				_charBuffer = new char[maxCharCount];
			}
		}

		private double ReadDouble()
		{
			MovePosition(8);
			return _reader.ReadDouble();
		}

		private int ReadInt32()
		{
			MovePosition(4);
			return _reader.ReadInt32();
		}

		private long ReadInt64()
		{
			MovePosition(8);
			return _reader.ReadInt64();
		}

		private BsonType ReadType()
		{
			MovePosition(1);
			return (BsonType)_reader.ReadSByte();
		}

		private void MovePosition(int count)
		{
			_currentContext.Position += count;
		}

		private byte[] ReadBytes(int count)
		{
			MovePosition(count);
			return _reader.ReadBytes(count);
		}
	}
}

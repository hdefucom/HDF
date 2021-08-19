using Open_Newtonsoft_Json.Utilities;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Represents a reader that provides fast, non-cached, forward-only access to JSON text data.
	///       </summary>
	[ComVisible(false)]
	public class JsonTextReader : JsonReader, IJsonLineInfo
	{
		private const char UnicodeReplacementChar = '\ufffd';

		private const int MaximumJavascriptIntegerCharacterLength = 380;

		private readonly TextReader _reader;

		private char[] _chars;

		private int _charsUsed;

		private int _charPos;

		private int _lineStartPos;

		private int _lineNumber;

		private bool _isEndOfFile;

		private StringBuffer _buffer;

		private StringReference _stringReference;

		internal PropertyNameTable NameTable;

		/// <summary>
		///       Gets the current line number.
		///       </summary>
		/// <value>
		///       The current line number or 0 if no line information is available (for example, HasLineInfo returns false).
		///       </value>
		public int LineNumber
		{
			get
			{
				if (base.CurrentState == State.Start && LinePosition == 0)
				{
					return 0;
				}
				return _lineNumber;
			}
		}

		/// <summary>
		///       Gets the current line position.
		///       </summary>
		/// <value>
		///       The current line position or 0 if no line information is available (for example, HasLineInfo returns false).
		///       </value>
		public int LinePosition => _charPos - _lineStartPos;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonReader" /> class with the specified <see cref="T:System.IO.TextReader" />.
		///       </summary>
		/// <param name="reader">The <c>TextReader</c> containing the XML data to read.</param>
		public JsonTextReader(TextReader reader)
		{
			int num = 19;
			
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			_reader = reader;
			_lineNumber = 1;
			_chars = new char[1025];
		}

		internal void SetCharBuffer(char[] chars)
		{
			_chars = chars;
		}

		private StringBuffer GetBuffer()
		{
			if (_buffer == null)
			{
				_buffer = new StringBuffer(1025);
			}
			else
			{
				_buffer.Position = 0;
			}
			return _buffer;
		}

		private void OnNewLine(int int_0)
		{
			_lineNumber++;
			_lineStartPos = int_0 - 1;
		}

		private void ParseString(char quote)
		{
			_charPos++;
			ShiftBufferIfNeeded();
			ReadStringIntoBuffer(quote);
			SetPostValueState(updateIndex: true);
			if (_readType == ReadType.ReadAsBytes)
			{
				Guid guid_;
				byte[] value = (_stringReference.Length == 0) ? new byte[0] : ((_stringReference.Length != 36 || !ConvertUtils.TryConvertGuid(_stringReference.ToString(), out guid_)) ? Convert.FromBase64CharArray(_stringReference.Chars, _stringReference.StartIndex, _stringReference.Length) : guid_.ToByteArray());
				SetToken(JsonToken.Bytes, value, updateIndex: false);
				return;
			}
			string value2;
			if (_readType == ReadType.ReadAsString)
			{
				value2 = _stringReference.ToString();
				SetToken(JsonToken.String, value2, updateIndex: false);
				_quoteChar = quote;
				return;
			}
			value2 = _stringReference.ToString();
			if (_dateParseHandling != 0)
			{
				DateParseHandling dateParseHandling = (_readType == ReadType.ReadAsDateTime) ? DateParseHandling.DateTime : _dateParseHandling;
				if (DateTimeUtils.TryParseDateTime(value2, dateParseHandling, base.DateTimeZoneHandling, base.DateFormatString, base.Culture, out object object_))
				{
					SetToken(JsonToken.Date, object_, updateIndex: false);
					return;
				}
			}
			SetToken(JsonToken.String, value2, updateIndex: false);
			_quoteChar = quote;
		}

		private static void BlockCopyChars(char[] char_0, int srcOffset, char[] char_1, int dstOffset, int count)
		{
			Buffer.BlockCopy(char_0, srcOffset * 2, char_1, dstOffset * 2, count * 2);
		}

		private void ShiftBufferIfNeeded()
		{
			int num = _chars.Length;
			if ((double)(num - _charPos) <= (double)num * 0.1)
			{
				int num2 = _charsUsed - _charPos;
				if (num2 > 0)
				{
					BlockCopyChars(_chars, _charPos, _chars, 0, num2);
				}
				_lineStartPos -= _charPos;
				_charPos = 0;
				_charsUsed = num2;
				_chars[_charsUsed] = '\0';
			}
		}

		private int ReadData(bool append)
		{
			return ReadData(append, 0);
		}

		private int ReadData(bool append, int charsRequired)
		{
			if (_isEndOfFile)
			{
				return 0;
			}
			if (_charsUsed + charsRequired >= _chars.Length - 1)
			{
				if (append)
				{
					int num = Math.Max(_chars.Length * 2, _charsUsed + charsRequired + 1);
					char[] array = new char[num];
					BlockCopyChars(_chars, 0, array, 0, _chars.Length);
					_chars = array;
				}
				else
				{
					int num2 = _charsUsed - _charPos;
					if (num2 + charsRequired + 1 >= _chars.Length)
					{
						char[] array = new char[num2 + charsRequired + 1];
						if (num2 > 0)
						{
							BlockCopyChars(_chars, _charPos, array, 0, num2);
						}
						_chars = array;
					}
					else if (num2 > 0)
					{
						BlockCopyChars(_chars, _charPos, _chars, 0, num2);
					}
					_lineStartPos -= _charPos;
					_charPos = 0;
					_charsUsed = num2;
				}
			}
			int count = _chars.Length - _charsUsed - 1;
			int num3 = _reader.Read(_chars, _charsUsed, count);
			_charsUsed += num3;
			if (num3 == 0)
			{
				_isEndOfFile = true;
			}
			_chars[_charsUsed] = '\0';
			return num3;
		}

		private bool EnsureChars(int relativePosition, bool append)
		{
			if (_charPos + relativePosition >= _charsUsed)
			{
				return ReadChars(relativePosition, append);
			}
			return true;
		}

		private bool ReadChars(int relativePosition, bool append)
		{
			if (_isEndOfFile)
			{
				return false;
			}
			int num = _charPos + relativePosition - _charsUsed + 1;
			int num2 = 0;
			do
			{
				int num3 = ReadData(append, num - num2);
				if (num3 == 0)
				{
					break;
				}
				num2 += num3;
			}
			while (num2 < num);
			if (num2 < num)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       Reads the next JSON token from the stream.
		///       </summary>
		/// <returns>
		///       true if the next token was read successfully; false if there are no more tokens to read.
		///       </returns>
		[DebuggerStepThrough]
		public override bool Read()
		{
			_readType = ReadType.Read;
			if (!ReadInternal())
			{
				SetToken(JsonToken.None);
				return false;
			}
			return true;
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

		internal override bool ReadInternal()
		{
			int num = 8;
			do
			{
				switch (_currentState)
				{
				case State.PostValue:
					break;
				case State.ObjectStart:
				case State.Object:
					return ParseObject();
				case State.Start:
				case State.Property:
				case State.ArrayStart:
				case State.Array:
				case State.ConstructorStart:
				case State.Constructor:
					return ParseValue();
				default:
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected state: {0}.", CultureInfo.InvariantCulture, base.CurrentState));
				case State.Finished:
					if (EnsureChars(0, append: false))
					{
						EatWhitespace(oneOrMore: false);
						if (_isEndOfFile)
						{
							return false;
						}
						if (_chars[_charPos] == '/')
						{
							ParseComment();
							return true;
						}
						throw JsonReaderException.Create(this, StringUtils.FormatWith("Additional text encountered after finished reading JSON content: {0}.", CultureInfo.InvariantCulture, _chars[_charPos]));
					}
					return false;
				}
			}
			while (!ParsePostValue());
			return true;
		}

		private void ReadStringIntoBuffer(char quote)
		{
			int num = 16;
			int num2 = _charPos;
			int charPos = _charPos;
			int num3 = _charPos;
			StringBuffer stringBuffer = null;
			while (true)
			{
				switch (_chars[num2++])
				{
				case '\\':
					_charPos = num2;
					if (EnsureChars(0, append: true))
					{
						int writeToPosition = num2 - 1;
						char c = _chars[num2];
						char c2;
						switch (c)
						{
						case '\\':
							num2++;
							c2 = '\\';
							goto IL_022f;
						case '"':
						case '\'':
						case '/':
							c2 = c;
							num2++;
							goto IL_022f;
						case 'f':
							num2++;
							c2 = '\f';
							goto IL_022f;
						case 'b':
							num2++;
							c2 = '\b';
							goto IL_022f;
						case 'r':
							num2++;
							c2 = '\r';
							goto IL_022f;
						case 't':
							num2++;
							c2 = '\t';
							goto IL_022f;
						case 'u':
							num2 = (_charPos = num2 + 1);
							c2 = ParseUnicode();
							if (StringUtils.IsLowSurrogate(c2))
							{
								c2 = '\ufffd';
							}
							else if (StringUtils.IsHighSurrogate(c2))
							{
								bool flag;
								do
								{
									flag = false;
									if (EnsureChars(2, append: true) && _chars[_charPos] == '\\' && _chars[_charPos + 1] == 'u')
									{
										char writeChar = c2;
										_charPos += 2;
										c2 = ParseUnicode();
										if (!StringUtils.IsLowSurrogate(c2))
										{
											if (StringUtils.IsHighSurrogate(c2))
											{
												writeChar = '\ufffd';
												flag = true;
											}
											else
											{
												writeChar = '\ufffd';
											}
										}
										if (stringBuffer == null)
										{
											stringBuffer = GetBuffer();
										}
										WriteCharToBuffer(stringBuffer, writeChar, num3, writeToPosition);
										num3 = _charPos;
									}
									else
									{
										c2 = '\ufffd';
									}
								}
								while (flag);
							}
							num2 = _charPos;
							goto IL_022f;
						case 'n':
							num2++;
							c2 = '\n';
							goto IL_022f;
						default:
							{
								num2 = (_charPos = num2 + 1);
								throw JsonReaderException.Create(this, StringUtils.FormatWith("Bad JSON escape sequence: {0}.", CultureInfo.InvariantCulture, "\\" + c));
							}
							IL_022f:
							if (stringBuffer == null)
							{
								stringBuffer = GetBuffer();
							}
							WriteCharToBuffer(stringBuffer, c2, num3, writeToPosition);
							num3 = num2;
							break;
						}
						break;
					}
					_charPos = num2;
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Unterminated string. Expected delimiter: {0}.", CultureInfo.InvariantCulture, quote));
				case '"':
				case '\'':
					if (_chars[num2 - 1] != quote)
					{
						break;
					}
					num2--;
					if (charPos == num3)
					{
						_stringReference = new StringReference(_chars, charPos, num2 - charPos);
					}
					else
					{
						if (stringBuffer == null)
						{
							stringBuffer = GetBuffer();
						}
						if (num2 > num3)
						{
							stringBuffer.Append(_chars, num3, num2 - num3);
						}
						_stringReference = new StringReference(stringBuffer.GetInternalBuffer(), 0, stringBuffer.Position);
					}
					num2 = (_charPos = num2 + 1);
					return;
				case '\r':
					_charPos = num2 - 1;
					ProcessCarriageReturn(append: true);
					num2 = _charPos;
					break;
				case '\n':
					_charPos = num2 - 1;
					ProcessLineFeed();
					num2 = _charPos;
					break;
				case '\0':
					if (_charsUsed == num2 - 1)
					{
						num2--;
						if (ReadData(append: true) == 0)
						{
							_charPos = num2;
							throw JsonReaderException.Create(this, StringUtils.FormatWith("Unterminated string. Expected delimiter: {0}.", CultureInfo.InvariantCulture, quote));
						}
					}
					break;
				}
			}
		}

		private void WriteCharToBuffer(StringBuffer buffer, char writeChar, int lastWritePosition, int writeToPosition)
		{
			if (writeToPosition > lastWritePosition)
			{
				buffer.Append(_chars, lastWritePosition, writeToPosition - lastWritePosition);
			}
			buffer.Append(writeChar);
		}

		private char ParseUnicode()
		{
			int num = 9;
			if (!EnsureChars(4, append: true))
			{
				throw JsonReaderException.Create(this, "Unexpected end while parsing unicode character.");
			}
			string s = new string(_chars, _charPos, 4);
			char c = Convert.ToChar(int.Parse(s, NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo));
			char result = c;
			_charPos += 4;
			return result;
		}

		private void ReadNumberIntoBuffer()
		{
			int num = 4;
			int num2 = _charPos;
			while (true)
			{
				switch (_chars[num2])
				{
				case '+':
				case '-':
				case '.':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
				case 'A':
				case 'B':
				case 'C':
				case 'D':
				case 'E':
				case 'F':
				case 'X':
				case 'a':
				case 'b':
				case 'c':
				case 'd':
				case 'e':
				case 'f':
				case 'x':
					num2++;
					continue;
				case '\0':
					_charPos = num2;
					if (_charsUsed != num2 || ReadData(append: true) == 0)
					{
						return;
					}
					continue;
				}
				_charPos = num2;
				char c = _chars[_charPos];
				if (!char.IsWhiteSpace(c) && c != ',' && c != '}' && c != ']' && c != ')' && c != '/')
				{
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected character encountered while parsing number: {0}.", CultureInfo.InvariantCulture, c));
				}
				return;
			}
		}

		private void ClearRecentString()
		{
			if (_buffer != null)
			{
				_buffer.Position = 0;
			}
			_stringReference = default(StringReference);
		}

		private bool ParsePostValue()
		{
			int num = 1;
			while (true)
			{
				char c = _chars[_charPos];
				switch (c)
				{
				default:
					if (char.IsWhiteSpace(c))
					{
						_charPos++;
						break;
					}
					throw JsonReaderException.Create(this, StringUtils.FormatWith("After parsing a value an unexpected character was encountered: {0}.", CultureInfo.InvariantCulture, c));
				case '\n':
					ProcessLineFeed();
					break;
				case '\r':
					ProcessCarriageReturn(append: false);
					break;
				case '\0':
					if (_charsUsed == _charPos)
					{
						if (ReadData(append: false) == 0)
						{
							_currentState = State.Finished;
							return false;
						}
					}
					else
					{
						_charPos++;
					}
					break;
				case '\t':
				case ' ':
					_charPos++;
					break;
				case ')':
					_charPos++;
					SetToken(JsonToken.EndConstructor);
					return true;
				case '/':
					ParseComment();
					return true;
				case ',':
					_charPos++;
					SetStateBasedOnCurrent();
					return false;
				case '}':
					_charPos++;
					SetToken(JsonToken.EndObject);
					return true;
				case ']':
					_charPos++;
					SetToken(JsonToken.EndArray);
					return true;
				}
			}
		}

		private bool ParseObject()
		{
			while (true)
			{
				char c = _chars[_charPos];
				switch (c)
				{
				default:
					if (char.IsWhiteSpace(c))
					{
						_charPos++;
						break;
					}
					return ParseProperty();
				case '\t':
				case ' ':
					_charPos++;
					break;
				case '\n':
					ProcessLineFeed();
					break;
				case '\r':
					ProcessCarriageReturn(append: false);
					break;
				case '\0':
					if (_charsUsed == _charPos)
					{
						if (ReadData(append: false) == 0)
						{
							return false;
						}
					}
					else
					{
						_charPos++;
					}
					break;
				case '}':
					SetToken(JsonToken.EndObject);
					_charPos++;
					return true;
				case '/':
					ParseComment();
					return true;
				}
			}
		}

		private bool ParseProperty()
		{
			int num = 14;
			char c = _chars[_charPos];
			char c2;
			if (c == '"' || c == '\'')
			{
				_charPos++;
				c2 = c;
				ShiftBufferIfNeeded();
				ReadStringIntoBuffer(c2);
			}
			else
			{
				if (!ValidIdentifierChar(c))
				{
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Invalid property identifier character: {0}.", CultureInfo.InvariantCulture, _chars[_charPos]));
				}
				c2 = '\0';
				ShiftBufferIfNeeded();
				ParseUnquotedProperty();
			}
			string text;
			if (NameTable != null)
			{
				text = NameTable.Get(_stringReference.Chars, _stringReference.StartIndex, _stringReference.Length);
				if (text == null)
				{
					text = _stringReference.ToString();
				}
			}
			else
			{
				text = _stringReference.ToString();
			}
			EatWhitespace(oneOrMore: false);
			if (_chars[_charPos] != ':')
			{
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Invalid character after parsing property name. Expected ':' but got: {0}.", CultureInfo.InvariantCulture, _chars[_charPos]));
			}
			_charPos++;
			SetToken(JsonToken.PropertyName, text);
			_quoteChar = c2;
			ClearRecentString();
			return true;
		}

		private bool ValidIdentifierChar(char value)
		{
			return char.IsLetterOrDigit(value) || value == '_' || value == '$';
		}

		private void ParseUnquotedProperty()
		{
			int num = 3;
			int charPos = _charPos;
			while (true)
			{
				if (_chars[_charPos] == '\0')
				{
					if (_charsUsed != _charPos)
					{
						break;
					}
					if (ReadData(append: true) == 0)
					{
						throw JsonReaderException.Create(this, "Unexpected end while parsing unquoted property name.");
					}
					continue;
				}
				char c = _chars[_charPos];
				if (ValidIdentifierChar(c))
				{
					_charPos++;
					continue;
				}
				if (char.IsWhiteSpace(c) || c == ':')
				{
					_stringReference = new StringReference(_chars, charPos, _charPos - charPos);
					return;
				}
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Invalid JavaScript property identifier character: {0}.", CultureInfo.InvariantCulture, c));
			}
			_stringReference = new StringReference(_chars, charPos, _charPos - charPos);
		}

		private bool ParseValue()
		{
			int num = 12;
			while (true)
			{
				char c = _chars[_charPos];
				switch (c)
				{
				default:
					if (char.IsWhiteSpace(c))
					{
						_charPos++;
						break;
					}
					if (char.IsNumber(c) || c == '-' || c == '.')
					{
						ParseNumber();
						return true;
					}
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected character encountered while parsing value: {0}.", CultureInfo.InvariantCulture, c));
				case '\n':
					ProcessLineFeed();
					break;
				case '\r':
					ProcessCarriageReturn(append: false);
					break;
				case '\0':
					if (_charsUsed == _charPos)
					{
						if (ReadData(append: false) == 0)
						{
							return false;
						}
					}
					else
					{
						_charPos++;
					}
					break;
				case '\t':
				case ' ':
					_charPos++;
					break;
				case 'I':
					ParseNumberPositiveInfinity();
					return true;
				case ')':
					_charPos++;
					SetToken(JsonToken.EndConstructor);
					return true;
				case ',':
					SetToken(JsonToken.Undefined);
					return true;
				case '-':
					if (EnsureChars(1, append: true) && _chars[_charPos + 1] == 'I')
					{
						ParseNumberNegativeInfinity();
					}
					else
					{
						ParseNumber();
					}
					return true;
				case '/':
					ParseComment();
					return true;
				case '"':
				case '\'':
					ParseString(c);
					return true;
				case 'f':
					ParseFalse();
					return true;
				case '[':
					_charPos++;
					SetToken(JsonToken.StartArray);
					return true;
				case ']':
					_charPos++;
					SetToken(JsonToken.EndArray);
					return true;
				case 'N':
					ParseNumberNaN();
					return true;
				case '{':
					_charPos++;
					SetToken(JsonToken.StartObject);
					return true;
				case 't':
					ParseTrue();
					return true;
				case 'u':
					ParseUndefined();
					return true;
				case 'n':
					if (EnsureChars(1, append: true))
					{
						char c2 = _chars[_charPos + 1];
						if (c2 == 'u')
						{
							ParseNull();
						}
						else
						{
							if (c2 != 'e')
							{
								throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected character encountered while parsing value: {0}.", CultureInfo.InvariantCulture, _chars[_charPos]));
							}
							ParseConstructor();
						}
						return true;
					}
					throw JsonReaderException.Create(this, "Unexpected end.");
				}
			}
		}

		private void ProcessLineFeed()
		{
			_charPos++;
			OnNewLine(_charPos);
		}

		private void ProcessCarriageReturn(bool append)
		{
			_charPos++;
			if (EnsureChars(1, append) && _chars[_charPos] == '\n')
			{
				_charPos++;
			}
			OnNewLine(_charPos);
		}

		private bool EatWhitespace(bool oneOrMore)
		{
			bool flag = false;
			bool flag2 = false;
			while (!flag)
			{
				char c = _chars[_charPos];
				switch (c)
				{
				default:
					if (c == ' ' || char.IsWhiteSpace(c))
					{
						flag2 = true;
						_charPos++;
					}
					else
					{
						flag = true;
					}
					break;
				case '\r':
					ProcessCarriageReturn(append: false);
					break;
				case '\n':
					ProcessLineFeed();
					break;
				case '\0':
					if (_charsUsed == _charPos)
					{
						if (ReadData(append: false) == 0)
						{
							flag = true;
						}
					}
					else
					{
						_charPos++;
					}
					break;
				}
			}
			return !oneOrMore || flag2;
		}

		private void ParseConstructor()
		{
			int num = 14;
			if (MatchValueWithTrailingSeparator("new"))
			{
				EatWhitespace(oneOrMore: false);
				int charPos = _charPos;
				int charPos2;
				while (true)
				{
					char c = _chars[_charPos];
					if (c != 0)
					{
						if (!char.IsLetterOrDigit(c))
						{
							switch (c)
							{
							case '\r':
								charPos2 = _charPos;
								ProcessCarriageReturn(append: true);
								break;
							case '\n':
								charPos2 = _charPos;
								ProcessLineFeed();
								break;
							default:
								if (char.IsWhiteSpace(c))
								{
									charPos2 = _charPos;
									_charPos++;
									break;
								}
								if (c == '(')
								{
									charPos2 = _charPos;
									break;
								}
								throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected character while parsing constructor: {0}.", CultureInfo.InvariantCulture, c));
							}
							break;
						}
						_charPos++;
					}
					else
					{
						if (_charsUsed != _charPos)
						{
							charPos2 = _charPos;
							_charPos++;
							break;
						}
						if (ReadData(append: true) == 0)
						{
							throw JsonReaderException.Create(this, "Unexpected end while parsing constructor.");
						}
					}
				}
				_stringReference = new StringReference(_chars, charPos, charPos2 - charPos);
				string value = _stringReference.ToString();
				EatWhitespace(oneOrMore: false);
				if (_chars[_charPos] != '(')
				{
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected character while parsing constructor: {0}.", CultureInfo.InvariantCulture, _chars[_charPos]));
				}
				_charPos++;
				ClearRecentString();
				SetToken(JsonToken.StartConstructor, value);
				return;
			}
			throw JsonReaderException.Create(this, "Unexpected content while parsing JSON.");
		}

		private void ParseNumber()
		{
			int num = 14;
			ShiftBufferIfNeeded();
			char c = _chars[_charPos];
			int charPos = _charPos;
			ReadNumberIntoBuffer();
			SetPostValueState(updateIndex: true);
			_stringReference = new StringReference(_chars, charPos, _charPos - charPos);
			bool flag = char.IsDigit(c) && _stringReference.Length == 1;
			bool flag2 = c == '0' && _stringReference.Length > 1 && _stringReference.Chars[_stringReference.StartIndex + 1] != '.' && _stringReference.Chars[_stringReference.StartIndex + 1] != 'e' && _stringReference.Chars[_stringReference.StartIndex + 1] != 'E';
			object value;
			JsonToken newToken;
			if (_readType == ReadType.ReadAsInt32)
			{
				if (flag)
				{
					value = c - 48;
				}
				else if (flag2)
				{
					string text = _stringReference.ToString();
					try
					{
						int num2 = text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? Convert.ToInt32(text, 16) : Convert.ToInt32(text, 8);
						value = num2;
					}
					catch (Exception exception_)
					{
						throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid integer.", CultureInfo.InvariantCulture, text), exception_);
					}
				}
				else
				{
					int value2;
					ParseResult parseResult = ConvertUtils.Int32TryParse(_stringReference.Chars, _stringReference.StartIndex, _stringReference.Length, out value2);
					if (parseResult != ParseResult.Success)
					{
						if (parseResult == ParseResult.Overflow)
						{
							throw JsonReaderException.Create(this, StringUtils.FormatWith("JSON integer {0} is too large or small for an Int32.", CultureInfo.InvariantCulture, _stringReference.ToString()));
						}
						throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid integer.", CultureInfo.InvariantCulture, _stringReference.ToString()));
					}
					value = value2;
				}
				newToken = JsonToken.Integer;
			}
			else if (_readType == ReadType.ReadAsDecimal)
			{
				if (flag)
				{
					value = (decimal)c - 48m;
				}
				else if (flag2)
				{
					string text = _stringReference.ToString();
					try
					{
						long value3 = text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? Convert.ToInt64(text, 16) : Convert.ToInt64(text, 8);
						value = Convert.ToDecimal(value3);
					}
					catch (Exception exception_)
					{
						throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid decimal.", CultureInfo.InvariantCulture, text), exception_);
					}
				}
				else
				{
					string text = _stringReference.ToString();
					if (!decimal.TryParse(text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out decimal result))
					{
						throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid decimal.", CultureInfo.InvariantCulture, _stringReference.ToString()));
					}
					value = result;
				}
				newToken = JsonToken.Float;
			}
			else if (flag)
			{
				value = c - 48L;
				newToken = JsonToken.Integer;
			}
			else if (flag2)
			{
				string text = _stringReference.ToString();
				try
				{
					value = (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? Convert.ToInt64(text, 16) : Convert.ToInt64(text, 8));
				}
				catch (Exception exception_)
				{
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid number.", CultureInfo.InvariantCulture, text), exception_);
				}
				newToken = JsonToken.Integer;
			}
			else
			{
				long value4;
				switch (ConvertUtils.Int64TryParse(_stringReference.Chars, _stringReference.StartIndex, _stringReference.Length, out value4))
				{
				case ParseResult.Success:
					value = value4;
					newToken = JsonToken.Integer;
					break;
				case ParseResult.Overflow:
					throw JsonReaderException.Create(this, StringUtils.FormatWith("JSON integer {0} is too large or small for an Int64.", CultureInfo.InvariantCulture, _stringReference.ToString()));
				default:
				{
					string text = _stringReference.ToString();
					if (_floatParseHandling == FloatParseHandling.Decimal)
					{
						if (!decimal.TryParse(text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out decimal result2))
						{
							throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid decimal.", CultureInfo.InvariantCulture, text));
						}
						value = result2;
					}
					else
					{
						if (!double.TryParse(text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out double result3))
						{
							throw JsonReaderException.Create(this, StringUtils.FormatWith("Input string '{0}' is not a valid number.", CultureInfo.InvariantCulture, text));
						}
						value = result3;
					}
					newToken = JsonToken.Float;
					break;
				}
				}
			}
			ClearRecentString();
			SetToken(newToken, value, updateIndex: false);
		}

		private void ParseComment()
		{
			int num = 19;
			_charPos++;
			if (!EnsureChars(1, append: false))
			{
				throw JsonReaderException.Create(this, "Unexpected end while parsing comment.");
			}
			bool flag;
			if (_chars[_charPos] == '*')
			{
				flag = false;
			}
			else
			{
				if (_chars[_charPos] != '/')
				{
					throw JsonReaderException.Create(this, StringUtils.FormatWith("Error parsing comment. Expected: *, got {0}.", CultureInfo.InvariantCulture, _chars[_charPos]));
				}
				flag = true;
			}
			_charPos++;
			int charPos = _charPos;
			bool flag2 = false;
			while (!flag2)
			{
				switch (_chars[_charPos])
				{
				case '\n':
					if (flag)
					{
						_stringReference = new StringReference(_chars, charPos, _charPos - charPos);
						flag2 = true;
					}
					ProcessLineFeed();
					break;
				case '\0':
					if (_charsUsed == _charPos)
					{
						if (ReadData(append: true) == 0)
						{
							if (!flag)
							{
								throw JsonReaderException.Create(this, "Unexpected end while parsing comment.");
							}
							_stringReference = new StringReference(_chars, charPos, _charPos - charPos);
							flag2 = true;
						}
					}
					else
					{
						_charPos++;
					}
					break;
				default:
					_charPos++;
					break;
				case '*':
					_charPos++;
					if (!flag && EnsureChars(0, append: true) && _chars[_charPos] == '/')
					{
						_stringReference = new StringReference(_chars, charPos, _charPos - charPos - 1);
						_charPos++;
						flag2 = true;
					}
					break;
				case '\r':
					if (flag)
					{
						_stringReference = new StringReference(_chars, charPos, _charPos - charPos);
						flag2 = true;
					}
					ProcessCarriageReturn(append: true);
					break;
				}
			}
			SetToken(JsonToken.Comment, _stringReference.ToString());
			ClearRecentString();
		}

		private bool MatchValue(string value)
		{
			if (!EnsureChars(value.Length - 1, append: true))
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < value.Length)
				{
					if (_chars[_charPos + num] != value[num])
					{
						break;
					}
					num++;
					continue;
				}
				_charPos += value.Length;
				return true;
			}
			return false;
		}

		private bool MatchValueWithTrailingSeparator(string value)
		{
			if (!MatchValue(value))
			{
				return false;
			}
			if (!EnsureChars(0, append: false))
			{
				return true;
			}
			return IsSeparator(_chars[_charPos]) || _chars[_charPos] == '\0';
		}

		private bool IsSeparator(char char_0)
		{
			switch (char_0)
			{
			case ')':
				if (base.CurrentState == State.Constructor || base.CurrentState == State.ConstructorStart)
				{
					return true;
				}
				goto IL_00ac;
			case '\t':
			case '\n':
			case '\r':
			case ' ':
				return true;
			case '/':
			{
				if (!EnsureChars(1, append: false))
				{
					return false;
				}
				char c = _chars[_charPos + 1];
				return c == '*' || c == '/';
			}
			default:
				if (char.IsWhiteSpace(char_0))
				{
					return true;
				}
				goto IL_00ac;
			case ',':
			case ']':
			case '}':
				{
					return true;
				}
				IL_00ac:
				return false;
			}
		}

		private void ParseTrue()
		{
			int num = 12;
			if (!MatchValueWithTrailingSeparator(JsonConvert.True))
			{
				throw JsonReaderException.Create(this, "Error parsing boolean value.");
			}
			SetToken(JsonToken.Boolean, true);
		}

		private void ParseNull()
		{
			int num = 1;
			if (!MatchValueWithTrailingSeparator(JsonConvert.Null))
			{
				throw JsonReaderException.Create(this, "Error parsing null value.");
			}
			SetToken(JsonToken.Null);
		}

		private void ParseUndefined()
		{
			int num = 14;
			if (!MatchValueWithTrailingSeparator(JsonConvert.Undefined))
			{
				throw JsonReaderException.Create(this, "Error parsing undefined value.");
			}
			SetToken(JsonToken.Undefined);
		}

		private void ParseFalse()
		{
			int num = 11;
			if (!MatchValueWithTrailingSeparator(JsonConvert.False))
			{
				throw JsonReaderException.Create(this, "Error parsing boolean value.");
			}
			SetToken(JsonToken.Boolean, false);
		}

		private void ParseNumberNegativeInfinity()
		{
			int num = 1;
			if (MatchValueWithTrailingSeparator(JsonConvert.NegativeInfinity))
			{
				if (_floatParseHandling == FloatParseHandling.Decimal)
				{
					throw new JsonReaderException("Cannot read -Infinity as a decimal.");
				}
				SetToken(JsonToken.Float, double.NegativeInfinity);
				return;
			}
			throw JsonReaderException.Create(this, "Error parsing negative infinity value.");
		}

		private void ParseNumberPositiveInfinity()
		{
			int num = 5;
			if (MatchValueWithTrailingSeparator(JsonConvert.PositiveInfinity))
			{
				if (_floatParseHandling == FloatParseHandling.Decimal)
				{
					throw new JsonReaderException("Cannot read Infinity as a decimal.");
				}
				SetToken(JsonToken.Float, double.PositiveInfinity);
				return;
			}
			throw JsonReaderException.Create(this, "Error parsing positive infinity value.");
		}

		private void ParseNumberNaN()
		{
			int num = 10;
			if (MatchValueWithTrailingSeparator(JsonConvert.NaN))
			{
				if (_floatParseHandling == FloatParseHandling.Decimal)
				{
					throw new JsonReaderException("Cannot read NaN as a decimal.");
				}
				SetToken(JsonToken.Float, double.NaN);
				return;
			}
			throw JsonReaderException.Create(this, "Error parsing NaN value.");
		}

		/// <summary>
		///       Changes the state to closed. 
		///       </summary>
		public override void Close()
		{
			base.Close();
			if (base.CloseInput && _reader != null)
			{
				_reader.Close();
			}
			if (_buffer != null)
			{
				_buffer.Clear();
			}
		}

		/// <summary>
		///       Gets a value indicating whether the class can return line information.
		///       </summary>
		/// <returns>
		///   <c>true</c> if LineNumber and LinePosition can be provided; otherwise, <c>false</c>.
		///       </returns>
		public bool HasLineInfo()
		{
			return true;
		}
	}
}

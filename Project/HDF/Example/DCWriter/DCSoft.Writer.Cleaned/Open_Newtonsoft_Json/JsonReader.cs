using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Represents a reader that provides fast, non-cached, forward-only access to serialized JSON data.
	///       </summary>
	[ComVisible(false)]
	public abstract class JsonReader : IDisposable
	{
		/// <summary>
		///       Specifies the state of the reader.
		///       </summary>
		[ComVisible(false)]
		protected internal enum State
		{
			Start,
			Complete,
			Property,
			ObjectStart,
			Object,
			ArrayStart,
			Array,
			Closed,
			PostValue,
			ConstructorStart,
			Constructor,
			Error,
			Finished
		}

		private JsonToken _tokenType;

		private object _value;

		internal char _quoteChar;

		internal State _currentState;

		internal ReadType _readType;

		private JsonPosition _currentPosition;

		private CultureInfo _culture;

		private DateTimeZoneHandling _dateTimeZoneHandling;

		private int? _maxDepth;

		private bool _hasExceededMaxDepth;

		internal DateParseHandling _dateParseHandling;

		internal FloatParseHandling _floatParseHandling;

		private string _dateFormatString;

		private readonly List<JsonPosition> _stack;

		/// <summary>
		///       Gets the current reader state.
		///       </summary>
		/// <value>The current reader state.</value>
		protected State CurrentState => _currentState;

		/// <summary>
		///       Gets or sets a value indicating whether the underlying stream or
		///       <see cref="T:System.IO.TextReader" /> should be closed when the reader is closed.
		///       </summary>
		/// <value>
		///       true to close the underlying stream or <see cref="T:System.IO.TextReader" /> when
		///       the reader is closed; otherwise false. The default is true.
		///       </value>
		public bool CloseInput
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether multiple pieces of JSON content can
		///       be read from a continuous stream without erroring.
		///       </summary>
		/// <value>
		///       true to support reading multiple pieces of JSON content; otherwise false. The default is false.
		///       </value>
		public bool SupportMultipleContent
		{
			get;
			set;
		}

		/// <summary>
		///       Gets the quotation mark character used to enclose the value of a string.
		///       </summary>
		public virtual char QuoteChar
		{
			get
			{
				return _quoteChar;
			}
			protected internal set
			{
				_quoteChar = value;
			}
		}

		/// <summary>
		///       Get or set how <see cref="T:System.DateTime" /> time zones are handling when reading JSON.
		///       </summary>
		public DateTimeZoneHandling DateTimeZoneHandling
		{
			get
			{
				return _dateTimeZoneHandling;
			}
			set
			{
				_dateTimeZoneHandling = value;
			}
		}

		/// <summary>
		///       Get or set how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON.
		///       </summary>
		public DateParseHandling DateParseHandling
		{
			get
			{
				return _dateParseHandling;
			}
			set
			{
				_dateParseHandling = value;
			}
		}

		/// <summary>
		///       Get or set how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text.
		///       </summary>
		public FloatParseHandling FloatParseHandling
		{
			get
			{
				return _floatParseHandling;
			}
			set
			{
				_floatParseHandling = value;
			}
		}

		/// <summary>
		///       Get or set how custom date formatted strings are parsed when reading JSON.
		///       </summary>
		public string DateFormatString
		{
			get
			{
				return _dateFormatString;
			}
			set
			{
				_dateFormatString = value;
			}
		}

		/// <summary>
		///       Gets or sets the maximum depth allowed when reading JSON. Reading past this depth will throw a <see cref="T:Open_Newtonsoft_Json.JsonReaderException" />.
		///       </summary>
		public int? MaxDepth
		{
			get
			{
				return _maxDepth;
			}
			set
			{
				int num = 6;
				if (value <= 0)
				{
					throw new ArgumentException("Value must be positive.", "value");
				}
				_maxDepth = value;
			}
		}

		/// <summary>
		///       Gets the type of the current JSON token. 
		///       </summary>
		public virtual JsonToken TokenType => _tokenType;

		/// <summary>
		///       Gets the text value of the current JSON token.
		///       </summary>
		public virtual object Value => _value;

		/// <summary>
		///       Gets The Common Language Runtime (CLR) type for the current JSON token.
		///       </summary>
		public virtual Type ValueType => (_value != null) ? _value.GetType() : null;

		/// <summary>
		///       Gets the depth of the current token in the JSON document.
		///       </summary>
		/// <value>The depth of the current token in the JSON document.</value>
		public virtual int Depth
		{
			get
			{
				int count = _stack.Count;
				if (JsonTokenUtils.IsStartToken(TokenType) || _currentPosition.Type == JsonContainerType.None)
				{
					return count;
				}
				return count + 1;
			}
		}

		/// <summary>
		///       Gets the path of the current JSON token. 
		///       </summary>
		public virtual string Path
		{
			get
			{
				if (_currentPosition.Type == JsonContainerType.None)
				{
					return string.Empty;
				}
				IEnumerable<JsonPosition> positions = (_currentState == State.ArrayStart || _currentState == State.ConstructorStart || _currentState == State.ObjectStart) ? _stack : Enumerable.Concat(_stack, new JsonPosition[1]
				{
					_currentPosition
				});
				return JsonPosition.BuildPath(positions);
			}
		}

		/// <summary>
		///       Gets or sets the culture used when reading JSON. Defaults to <see cref="P:System.Globalization.CultureInfo.InvariantCulture" />.
		///       </summary>
		public CultureInfo Culture
		{
			get
			{
				return _culture ?? CultureInfo.InvariantCulture;
			}
			set
			{
				_culture = value;
			}
		}

		internal JsonPosition GetPosition(int depth)
		{
			if (depth < _stack.Count)
			{
				return _stack[depth];
			}
			return _currentPosition;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonReader" /> class with the specified <see cref="T:System.IO.TextReader" />.
		///       </summary>
		protected JsonReader()
		{
			_currentState = State.Start;
			_stack = new List<JsonPosition>(4);
			_dateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
			_dateParseHandling = DateParseHandling.DateTime;
			_floatParseHandling = FloatParseHandling.Double;
			CloseInput = true;
		}

		private void Push(JsonContainerType value)
		{
			int num = 17;
			UpdateScopeWithFinishedValue();
			if (_currentPosition.Type == JsonContainerType.None)
			{
				_currentPosition = new JsonPosition(value);
				return;
			}
			_stack.Add(_currentPosition);
			_currentPosition = new JsonPosition(value);
			if (!_maxDepth.HasValue || !(Depth + 1 > _maxDepth) || _hasExceededMaxDepth)
			{
				return;
			}
			_hasExceededMaxDepth = true;
			throw JsonReaderException.Create(this, StringUtils.FormatWith("The reader's MaxDepth of {0} has been exceeded.", CultureInfo.InvariantCulture, _maxDepth));
		}

		private JsonContainerType Pop()
		{
			JsonPosition currentPosition;
			if (_stack.Count > 0)
			{
				currentPosition = _currentPosition;
				_currentPosition = _stack[_stack.Count - 1];
				_stack.RemoveAt(_stack.Count - 1);
			}
			else
			{
				currentPosition = _currentPosition;
				_currentPosition = default(JsonPosition);
			}
			if (_maxDepth.HasValue && Depth <= _maxDepth)
			{
				_hasExceededMaxDepth = false;
			}
			return currentPosition.Type;
		}

		private JsonContainerType Peek()
		{
			return _currentPosition.Type;
		}

		/// <summary>
		///       Reads the next JSON token from the stream.
		///       </summary>
		/// <returns>true if the next token was read successfully; false if there are no more tokens to read.</returns>
		public abstract bool Read();

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.</returns>
		public abstract int? ReadAsInt32();

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.String" />.
		///       </summary>
		/// <returns>A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.</returns>
		public abstract string ReadAsString();

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Byte" />[].
		///       </summary>
		/// <returns>A <see cref="T:System.Byte" />[] or a null reference if the next JSON token is null. This method will return <c>null</c> at the end of an array.</returns>
		public abstract byte[] ReadAsBytes();

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.</returns>
		public abstract decimal? ReadAsDecimal();

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.</returns>
		public abstract DateTime? ReadAsDateTime();

		internal virtual bool ReadInternal()
		{
			throw new NotImplementedException();
		}

		internal byte[] ReadAsBytesInternal()
		{
			int num = 12;
			_readType = ReadType.ReadAsBytes;
			JsonToken tokenType;
			do
			{
				if (ReadInternal())
				{
					tokenType = TokenType;
					continue;
				}
				SetToken(JsonToken.None);
				return null;
			}
			while (tokenType == JsonToken.Comment);
			if (IsWrappedInTypeObject())
			{
				byte[] array = ReadAsBytes();
				ReadInternal();
				SetToken(JsonToken.Bytes, array, updateIndex: false);
				return array;
			}
			switch (tokenType)
			{
			case JsonToken.String:
			{
				string text = (string)Value;
				Guid guid_;
				byte[] array = (text.Length == 0) ? new byte[0] : ((!ConvertUtils.TryConvertGuid(text, out guid_)) ? Convert.FromBase64String(text) : guid_.ToByteArray());
				SetToken(JsonToken.Bytes, array, updateIndex: false);
				return array;
			}
			case JsonToken.Null:
				return null;
			case JsonToken.Bytes:
				if (ValueType == typeof(Guid))
				{
					byte[] array = ((Guid)Value).ToByteArray();
					SetToken(JsonToken.Bytes, array, updateIndex: false);
					return array;
				}
				return (byte[])Value;
			case JsonToken.StartArray:
			{
				List<byte> list = new List<byte>();
				while (ReadInternal())
				{
					tokenType = TokenType;
					switch (tokenType)
					{
					case JsonToken.Integer:
						list.Add(Convert.ToByte(Value, CultureInfo.InvariantCulture));
						break;
					case JsonToken.Comment:
						break;
					case JsonToken.EndArray:
					{
						byte[] array2 = list.ToArray();
						SetToken(JsonToken.Bytes, array2, updateIndex: false);
						return array2;
					}
					default:
						throw JsonReaderException.Create(this, StringUtils.FormatWith("Unexpected token when reading bytes: {0}.", CultureInfo.InvariantCulture, tokenType));
					}
				}
				throw JsonReaderException.Create(this, "Unexpected end when reading bytes.");
			}
			case JsonToken.EndArray:
				return null;
			default:
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Error reading bytes. Unexpected token: {0}.", CultureInfo.InvariantCulture, tokenType));
			}
		}

		internal decimal? ReadAsDecimalInternal()
		{
			int num = 15;
			_readType = ReadType.ReadAsDecimal;
			JsonToken tokenType;
			do
			{
				if (ReadInternal())
				{
					tokenType = TokenType;
					continue;
				}
				SetToken(JsonToken.None);
				return null;
			}
			while (tokenType == JsonToken.Comment);
			if (tokenType == JsonToken.Integer || tokenType == JsonToken.Float)
			{
				if (!(Value is decimal))
				{
					SetToken(JsonToken.Float, Convert.ToDecimal(Value, CultureInfo.InvariantCulture), updateIndex: false);
				}
				return (decimal)Value;
			}
			switch (tokenType)
			{
			case JsonToken.Null:
				return null;
			case JsonToken.String:
			{
				string text = (string)Value;
				if (string.IsNullOrEmpty(text))
				{
					SetToken(JsonToken.Null);
					return null;
				}
				if (decimal.TryParse(text, NumberStyles.Number, Culture, out decimal result))
				{
					SetToken(JsonToken.Float, result, updateIndex: false);
					return result;
				}
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Could not convert string to decimal: {0}.", CultureInfo.InvariantCulture, Value));
			}
			case JsonToken.EndArray:
				return null;
			default:
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Error reading decimal. Unexpected token: {0}.", CultureInfo.InvariantCulture, tokenType));
			}
		}

		internal int? ReadAsInt32Internal()
		{
			int num = 7;
			_readType = ReadType.ReadAsInt32;
			JsonToken tokenType;
			do
			{
				if (ReadInternal())
				{
					tokenType = TokenType;
					continue;
				}
				SetToken(JsonToken.None);
				return null;
			}
			while (tokenType == JsonToken.Comment);
			if (tokenType == JsonToken.Integer || tokenType == JsonToken.Float)
			{
				if (!(Value is int))
				{
					SetToken(JsonToken.Integer, Convert.ToInt32(Value, CultureInfo.InvariantCulture), updateIndex: false);
				}
				return (int)Value;
			}
			switch (tokenType)
			{
			case JsonToken.Null:
				return null;
			case JsonToken.String:
			{
				string text = (string)Value;
				if (string.IsNullOrEmpty(text))
				{
					SetToken(JsonToken.Null);
					return null;
				}
				if (int.TryParse(text, NumberStyles.Integer, Culture, out int result))
				{
					SetToken(JsonToken.Integer, result, updateIndex: false);
					return result;
				}
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Could not convert string to integer: {0}.", CultureInfo.InvariantCulture, Value));
			}
			case JsonToken.EndArray:
				return null;
			default:
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Error reading integer. Unexpected token: {0}.", CultureInfo.InvariantCulture, TokenType));
			}
		}

		internal string ReadAsStringInternal()
		{
			int num = 7;
			_readType = ReadType.ReadAsString;
			while (ReadInternal())
			{
				JsonToken tokenType = TokenType;
				switch (tokenType)
				{
				case JsonToken.Comment:
					continue;
				case JsonToken.String:
					return (string)Value;
				case JsonToken.Null:
					return null;
				}
				if (JsonTokenUtils.IsPrimitiveToken(tokenType) && Value != null)
				{
					string text = (!(Value is IFormattable)) ? Value.ToString() : ((IFormattable)Value).ToString(null, Culture);
					SetToken(JsonToken.String, text, updateIndex: false);
					return text;
				}
				if (tokenType == JsonToken.EndArray)
				{
					return null;
				}
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Error reading string. Unexpected token: {0}.", CultureInfo.InvariantCulture, tokenType));
			}
			SetToken(JsonToken.None);
			return null;
		}

		internal DateTime? ReadAsDateTimeInternal()
		{
			int num = 15;
			_readType = ReadType.ReadAsDateTime;
			do
			{
				if (!ReadInternal())
				{
					SetToken(JsonToken.None);
					return null;
				}
			}
			while (TokenType == JsonToken.Comment);
			if (TokenType == JsonToken.Date)
			{
				return (DateTime)Value;
			}
			if (TokenType == JsonToken.Null)
			{
				return null;
			}
			if (TokenType == JsonToken.String)
			{
				string text = (string)Value;
				if (string.IsNullOrEmpty(text))
				{
					SetToken(JsonToken.Null);
					return null;
				}
				DateTime value;
				if (DateTimeUtils.TryParseDateTime(text, DateParseHandling.DateTime, DateTimeZoneHandling, _dateFormatString, Culture, out object object_))
				{
					value = (DateTime)object_;
					value = DateTimeUtils.EnsureDateTime(value, DateTimeZoneHandling);
					SetToken(JsonToken.Date, value, updateIndex: false);
					return value;
				}
				if (DateTime.TryParse(text, Culture, DateTimeStyles.RoundtripKind, out value))
				{
					value = DateTimeUtils.EnsureDateTime(value, DateTimeZoneHandling);
					SetToken(JsonToken.Date, value, updateIndex: false);
					return value;
				}
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Could not convert string to DateTime: {0}.", CultureInfo.InvariantCulture, Value));
			}
			if (TokenType == JsonToken.EndArray)
			{
				return null;
			}
			throw JsonReaderException.Create(this, StringUtils.FormatWith("Error reading date. Unexpected token: {0}.", CultureInfo.InvariantCulture, TokenType));
		}

		private bool IsWrappedInTypeObject()
		{
			int num = 16;
			_readType = ReadType.Read;
			if (TokenType == JsonToken.StartObject)
			{
				if (!ReadInternal())
				{
					throw JsonReaderException.Create(this, "Unexpected end when reading bytes.");
				}
				if (Value.ToString() == "$type")
				{
					ReadInternal();
					if (Value != null && Value.ToString().StartsWith("System.Byte[]", StringComparison.Ordinal))
					{
						ReadInternal();
						if (Value.ToString() == "$value")
						{
							return true;
						}
					}
				}
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Error reading bytes. Unexpected token: {0}.", CultureInfo.InvariantCulture, JsonToken.StartObject));
			}
			return false;
		}

		/// <summary>
		///       Skips the children of the current token.
		///       </summary>
		public void Skip()
		{
			if (TokenType == JsonToken.PropertyName)
			{
				Read();
			}
			if (JsonTokenUtils.IsStartToken(TokenType))
			{
				int depth = Depth;
				while (Read() && depth < Depth)
				{
				}
			}
		}

		/// <summary>
		///       Sets the current token.
		///       </summary>
		/// <param name="newToken">The new token.</param>
		protected void SetToken(JsonToken newToken)
		{
			SetToken(newToken, null, updateIndex: true);
		}

		/// <summary>
		///       Sets the current token and value.
		///       </summary>
		/// <param name="newToken">The new token.</param>
		/// <param name="value">The value.</param>
		protected void SetToken(JsonToken newToken, object value)
		{
			SetToken(newToken, value, updateIndex: true);
		}

		internal void SetToken(JsonToken newToken, object value, bool updateIndex)
		{
			_tokenType = newToken;
			_value = value;
			switch (newToken)
			{
			case JsonToken.Comment:
				break;
			case JsonToken.StartObject:
				_currentState = State.ObjectStart;
				Push(JsonContainerType.Object);
				break;
			case JsonToken.StartArray:
				_currentState = State.ArrayStart;
				Push(JsonContainerType.Array);
				break;
			case JsonToken.StartConstructor:
				_currentState = State.ConstructorStart;
				Push(JsonContainerType.Constructor);
				break;
			case JsonToken.PropertyName:
				_currentState = State.Property;
				_currentPosition.PropertyName = (string)value;
				break;
			case JsonToken.EndObject:
				ValidateEnd(JsonToken.EndObject);
				break;
			case JsonToken.EndArray:
				ValidateEnd(JsonToken.EndArray);
				break;
			case JsonToken.EndConstructor:
				ValidateEnd(JsonToken.EndConstructor);
				break;
			case JsonToken.Raw:
			case JsonToken.Integer:
			case JsonToken.Float:
			case JsonToken.String:
			case JsonToken.Boolean:
			case JsonToken.Null:
			case JsonToken.Undefined:
			case JsonToken.Date:
			case JsonToken.Bytes:
				SetPostValueState(updateIndex);
				break;
			}
		}

		internal void SetPostValueState(bool updateIndex)
		{
			if (Peek() != 0)
			{
				_currentState = State.PostValue;
			}
			else
			{
				SetFinished();
			}
			if (updateIndex)
			{
				UpdateScopeWithFinishedValue();
			}
		}

		private void UpdateScopeWithFinishedValue()
		{
			if (_currentPosition.HasIndex)
			{
				_currentPosition.Position++;
			}
		}

		private void ValidateEnd(JsonToken endToken)
		{
			int num = 8;
			JsonContainerType jsonContainerType = Pop();
			if (GetTypeForCloseToken(endToken) != jsonContainerType)
			{
				throw JsonReaderException.Create(this, StringUtils.FormatWith("JsonToken {0} is not valid for closing JsonType {1}.", CultureInfo.InvariantCulture, endToken, jsonContainerType));
			}
			if (Peek() != 0)
			{
				_currentState = State.PostValue;
			}
			else
			{
				SetFinished();
			}
		}

		/// <summary>
		///       Sets the state based on current token type.
		///       </summary>
		protected void SetStateBasedOnCurrent()
		{
			int num = 11;
			JsonContainerType jsonContainerType = Peek();
			switch (jsonContainerType)
			{
			default:
				throw JsonReaderException.Create(this, StringUtils.FormatWith("While setting the reader state back to current object an unexpected JsonType was encountered: {0}", CultureInfo.InvariantCulture, jsonContainerType));
			case JsonContainerType.None:
				SetFinished();
				break;
			case JsonContainerType.Object:
				_currentState = State.Object;
				break;
			case JsonContainerType.Array:
				_currentState = State.Array;
				break;
			case JsonContainerType.Constructor:
				_currentState = State.Constructor;
				break;
			}
		}

		private void SetFinished()
		{
			if (SupportMultipleContent)
			{
				_currentState = State.Start;
			}
			else
			{
				_currentState = State.Finished;
			}
		}

		private JsonContainerType GetTypeForCloseToken(JsonToken token)
		{
			int num = 18;
			switch (token)
			{
			default:
				throw JsonReaderException.Create(this, StringUtils.FormatWith("Not a valid close JsonToken: {0}", CultureInfo.InvariantCulture, token));
			case JsonToken.EndObject:
				return JsonContainerType.Object;
			case JsonToken.EndArray:
				return JsonContainerType.Array;
			case JsonToken.EndConstructor:
				return JsonContainerType.Constructor;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
		}

		/// <summary>
		///       Releases unmanaged and - optionally - managed resources
		///       </summary>
		/// <param name="disposing">
		///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (_currentState != State.Closed && disposing)
			{
				Close();
			}
		}

		/// <summary>
		///       Changes the <see cref="T:Open_Newtonsoft_Json.JsonReader.State" /> to Closed. 
		///       </summary>
		public virtual void Close()
		{
			_currentState = State.Closed;
			_tokenType = JsonToken.None;
			_value = null;
		}
	}
}

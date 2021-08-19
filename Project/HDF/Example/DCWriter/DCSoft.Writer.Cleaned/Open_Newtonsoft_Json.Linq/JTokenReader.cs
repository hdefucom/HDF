using Open_Newtonsoft_Json.Utilities;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a reader that provides fast, non-cached, forward-only access to serialized JSON data.
	///       </summary>
	[ComVisible(false)]
	public class JTokenReader : JsonReader, IJsonLineInfo
	{
		private readonly string _initialPath;

		private readonly JToken _root;

		private JToken _parent;

		private JToken _current;

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> at the reader's current position.
		///       </summary>
		public JToken CurrentToken => _current;

		int IJsonLineInfo.LineNumber
		{
			get
			{
				if (base.CurrentState == State.Start)
				{
					return 0;
				}
				return ((IJsonLineInfo)_current)?.LineNumber ?? 0;
			}
		}

		int IJsonLineInfo.LinePosition
		{
			get
			{
				if (base.CurrentState == State.Start)
				{
					return 0;
				}
				return ((IJsonLineInfo)_current)?.LinePosition ?? 0;
			}
		}

		/// <summary>
		///       Gets the path of the current JSON token. 
		///       </summary>
		public override string Path
		{
			get
			{
				int num = 0;
				string text = base.Path;
				if (!string.IsNullOrEmpty(_initialPath))
				{
					if (string.IsNullOrEmpty(text))
					{
						return _initialPath;
					}
					text = ((!StringUtils.StartsWith(text, '[')) ? (_initialPath + "." + text) : (_initialPath + text));
				}
				return text;
			}
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JTokenReader" /> class.
		///       </summary>
		/// <param name="token">The token to read from.</param>
		public JTokenReader(JToken token)
		{
			ValidationUtils.ArgumentNotNull(token, "token");
			_root = token;
		}

		internal JTokenReader(JToken token, string initialPath)
			: this(token)
		{
			_initialPath = initialPath;
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
			if (base.CurrentState != 0)
			{
				if (_current == null)
				{
					return false;
				}
				JContainer jContainer = _current as JContainer;
				if (jContainer != null && _parent != jContainer)
				{
					return ReadInto(jContainer);
				}
				return ReadOver(_current);
			}
			_current = _root;
			SetToken(_current);
			return true;
		}

		/// <summary>
		///       Reads the next JSON token from the stream.
		///       </summary>
		/// <returns>
		///       true if the next token was read successfully; false if there are no more tokens to read.
		///       </returns>
		public override bool Read()
		{
			_readType = ReadType.Read;
			return ReadInternal();
		}

		private bool ReadOver(JToken jtoken_0)
		{
			if (jtoken_0 == _root)
			{
				return ReadToEnd();
			}
			JToken next = jtoken_0.Next;
			if (next == null || next == jtoken_0 || jtoken_0 == jtoken_0.Parent.Last)
			{
				if (jtoken_0.Parent == null)
				{
					return ReadToEnd();
				}
				return SetEnd(jtoken_0.Parent);
			}
			_current = next;
			SetToken(_current);
			return true;
		}

		private bool ReadToEnd()
		{
			_current = null;
			SetToken(JsonToken.None);
			return false;
		}

		private JsonToken? GetEndToken(JContainer jcontainer_0)
		{
			int num = 7;
			switch (jcontainer_0.Type)
			{
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("Type", jcontainer_0.Type, "Unexpected JContainer type.");
			case JTokenType.Object:
				return JsonToken.EndObject;
			case JTokenType.Array:
				return JsonToken.EndArray;
			case JTokenType.Constructor:
				return JsonToken.EndConstructor;
			case JTokenType.Property:
				return null;
			}
		}

		private bool ReadInto(JContainer jcontainer_0)
		{
			JToken first = jcontainer_0.First;
			if (first == null)
			{
				return SetEnd(jcontainer_0);
			}
			SetToken(first);
			_current = first;
			_parent = jcontainer_0;
			return true;
		}

		private bool SetEnd(JContainer jcontainer_0)
		{
			JsonToken? endToken = GetEndToken(jcontainer_0);
			if (endToken.HasValue)
			{
				SetToken(endToken.Value);
				_current = jcontainer_0;
				_parent = jcontainer_0;
				return true;
			}
			return ReadOver(jcontainer_0);
		}

		private void SetToken(JToken token)
		{
			int num = 0;
			switch (token.Type)
			{
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("Type", token.Type, "Unexpected JTokenType.");
			case JTokenType.Object:
				SetToken(JsonToken.StartObject);
				break;
			case JTokenType.Array:
				SetToken(JsonToken.StartArray);
				break;
			case JTokenType.Constructor:
				SetToken(JsonToken.StartConstructor, ((JConstructor)token).Name);
				break;
			case JTokenType.Property:
				SetToken(JsonToken.PropertyName, ((JProperty)token).Name);
				break;
			case JTokenType.Comment:
				SetToken(JsonToken.Comment, ((JValue)token).Value);
				break;
			case JTokenType.Integer:
				SetToken(JsonToken.Integer, ((JValue)token).Value);
				break;
			case JTokenType.Float:
				SetToken(JsonToken.Float, ((JValue)token).Value);
				break;
			case JTokenType.String:
				SetToken(JsonToken.String, ((JValue)token).Value);
				break;
			case JTokenType.Boolean:
				SetToken(JsonToken.Boolean, ((JValue)token).Value);
				break;
			case JTokenType.Null:
				SetToken(JsonToken.Null, ((JValue)token).Value);
				break;
			case JTokenType.Undefined:
				SetToken(JsonToken.Undefined, ((JValue)token).Value);
				break;
			case JTokenType.Date:
				SetToken(JsonToken.Date, ((JValue)token).Value);
				break;
			case JTokenType.Raw:
				SetToken(JsonToken.Raw, ((JValue)token).Value);
				break;
			case JTokenType.Bytes:
				SetToken(JsonToken.Bytes, ((JValue)token).Value);
				break;
			case JTokenType.Guid:
				SetToken(JsonToken.String, SafeToString(((JValue)token).Value));
				break;
			case JTokenType.Uri:
				SetToken(JsonToken.String, SafeToString(((JValue)token).Value));
				break;
			case JTokenType.TimeSpan:
				SetToken(JsonToken.String, SafeToString(((JValue)token).Value));
				break;
			}
		}

		private string SafeToString(object value)
		{
			return value?.ToString();
		}

		bool IJsonLineInfo.HasLineInfo()
		{
			if (base.CurrentState == State.Start)
			{
				return false;
			}
			return ((IJsonLineInfo)_current)?.HasLineInfo() ?? false;
		}
	}
}

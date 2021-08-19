using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a value in JSON (string, integer, date, etc).
	///       </summary>
	[ComVisible(false)]
	public class JValue : JToken, IComparable, IEquatable<JValue>, IComparable<JValue>, IConvertible, IFormattable
	{
		private JTokenType _valueType;

		private object _value;

		/// <summary>
		///       Gets a value indicating whether this token has child tokens.
		///       </summary>
		/// <value>
		///   <c>true</c> if this token has child values; otherwise, <c>false</c>.
		///       </value>
		public override bool HasValues => false;

		/// <summary>
		///       Gets the node type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <value>The type.</value>
		public override JTokenType Type => _valueType;

		/// <summary>
		///       Gets or sets the underlying token value.
		///       </summary>
		/// <value>The underlying token value.</value>
		public new object Value
		{
			get
			{
				return _value;
			}
			set
			{
				Type type = (_value != null) ? _value.GetType() : null;
				Type type2 = value?.GetType();
				if (type != type2)
				{
					_valueType = GetValueType(_valueType, value);
				}
				_value = value;
			}
		}

		internal JValue(object value, JTokenType type)
		{
			_value = value;
			_valueType = type;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class from another <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> object.
		///       </summary>
		/// <param name="other">A <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> object to copy from.</param>
		public JValue(JValue other)
			: this(other.Value, other.Type)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(long value)
			: this(value, JTokenType.Integer)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(decimal value)
			: this(value, JTokenType.Float)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(char value)
			: this(value, JTokenType.String)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		[CLSCompliant(false)]
		public JValue(ulong value)
			: this(value, JTokenType.Integer)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(double value)
			: this(value, JTokenType.Float)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(float value)
			: this(value, JTokenType.Float)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(DateTime value)
			: this(value, JTokenType.Date)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(bool value)
			: this(value, JTokenType.Boolean)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(string value)
			: this(value, JTokenType.String)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(Guid value)
			: this(value, JTokenType.Guid)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(Uri value)
			: this(value, (value != null) ? JTokenType.Uri : JTokenType.Null)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(TimeSpan value)
			: this(value, JTokenType.TimeSpan)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> class with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		public JValue(object value)
			: this(value, GetValueType(null, value))
		{
		}

		internal override bool DeepEquals(JToken node)
		{
			JValue jValue = node as JValue;
			if (jValue == null)
			{
				return false;
			}
			if (jValue == this)
			{
				return true;
			}
			return ValuesEquals(this, jValue);
		}

		internal static int Compare(JTokenType valueType, object objA, object objB)
		{
			int num = 18;
			if (objA == null && objB == null)
			{
				return 0;
			}
			if (objA != null && objB == null)
			{
				return 1;
			}
			if (objA == null && objB != null)
			{
				return -1;
			}
			switch (valueType)
			{
			case JTokenType.Integer:
				if (objA is ulong || objB is ulong || objA is decimal || objB is decimal)
				{
					return Convert.ToDecimal(objA, CultureInfo.InvariantCulture).CompareTo(Convert.ToDecimal(objB, CultureInfo.InvariantCulture));
				}
				if (objA is float || objB is float || objA is double || objB is double)
				{
					return CompareFloat(objA, objB);
				}
				return Convert.ToInt64(objA, CultureInfo.InvariantCulture).CompareTo(Convert.ToInt64(objB, CultureInfo.InvariantCulture));
			case JTokenType.Float:
				return CompareFloat(objA, objB);
			case JTokenType.Boolean:
			{
				bool flag = Convert.ToBoolean(objA, CultureInfo.InvariantCulture);
				bool value3 = Convert.ToBoolean(objB, CultureInfo.InvariantCulture);
				return flag.CompareTo(value3);
			}
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("valueType", valueType, StringUtils.FormatWith("Unexpected value type: {0}", CultureInfo.InvariantCulture, valueType));
			case JTokenType.Date:
			{
				DateTime dateTime = (DateTime)objA;
				DateTime value2 = Convert.ToDateTime(objB, CultureInfo.InvariantCulture);
				return dateTime.CompareTo(value2);
			}
			case JTokenType.Comment:
			case JTokenType.String:
			case JTokenType.Raw:
			{
				string strA = Convert.ToString(objA, CultureInfo.InvariantCulture);
				string strB = Convert.ToString(objB, CultureInfo.InvariantCulture);
				return string.CompareOrdinal(strA, strB);
			}
			case JTokenType.Bytes:
			{
				if (!(objB is byte[]))
				{
					throw new ArgumentException("Object must be of type byte[].");
				}
				byte[] array = objA as byte[];
				byte[] array2 = objB as byte[];
				if (array == null)
				{
					return -1;
				}
				if (array2 == null)
				{
					return 1;
				}
				return MiscellaneousUtils.ByteArrayCompare(array, array2);
			}
			case JTokenType.Guid:
			{
				if (!(objB is Guid))
				{
					throw new ArgumentException("Object must be of type Guid.");
				}
				Guid guid = (Guid)objA;
				Guid value4 = (Guid)objB;
				return guid.CompareTo(value4);
			}
			case JTokenType.Uri:
			{
				if (!(objB is Uri))
				{
					throw new ArgumentException("Object must be of type Uri.");
				}
				Uri uri = (Uri)objA;
				Uri uri2 = (Uri)objB;
				return Comparer<string>.Default.Compare(uri.ToString(), uri2.ToString());
			}
			case JTokenType.TimeSpan:
			{
				if (!(objB is TimeSpan))
				{
					throw new ArgumentException("Object must be of type TimeSpan.");
				}
				TimeSpan timeSpan = (TimeSpan)objA;
				TimeSpan value = (TimeSpan)objB;
				return timeSpan.CompareTo(value);
			}
			}
		}

		private static int CompareFloat(object objA, object objB)
		{
			double double_ = Convert.ToDouble(objA, CultureInfo.InvariantCulture);
			double num = Convert.ToDouble(objB, CultureInfo.InvariantCulture);
			if (MathUtils.ApproxEquals(double_, num))
			{
				return 0;
			}
			return double_.CompareTo(num);
		}

		internal override JToken CloneToken()
		{
			return new JValue(this);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> comment with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> comment with the given value.</returns>
		public static JValue CreateComment(string value)
		{
			return new JValue(value, JTokenType.Comment);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> string with the given value.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> string with the given value.</returns>
		public static JValue CreateString(string value)
		{
			return new JValue(value, JTokenType.String);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> null value.
		///       </summary>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> null value.</returns>
		public static JValue CreateNull()
		{
			return new JValue(null, JTokenType.Null);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> null value.
		///       </summary>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> null value.</returns>
		public static JValue CreateUndefined()
		{
			return new JValue(null, JTokenType.Undefined);
		}

		private static JTokenType GetValueType(JTokenType? current, object value)
		{
			int num = 4;
			if (value == null)
			{
				return JTokenType.Null;
			}
			if (value == DBNull.Value)
			{
				return JTokenType.Null;
			}
			if (value is string)
			{
				return GetStringValueType(current);
			}
			if (value is long || value is int || value is short || value is sbyte || value is ulong || value is uint || value is ushort || value is byte)
			{
				return JTokenType.Integer;
			}
			if (value is Enum)
			{
				return JTokenType.Integer;
			}
			if (value is double || value is float || value is decimal)
			{
				return JTokenType.Float;
			}
			if (value is DateTime)
			{
				return JTokenType.Date;
			}
			if (value is byte[])
			{
				return JTokenType.Bytes;
			}
			if (value is bool)
			{
				return JTokenType.Boolean;
			}
			if (value is Guid)
			{
				return JTokenType.Guid;
			}
			if (value is Uri)
			{
				return JTokenType.Uri;
			}
			if (value is TimeSpan)
			{
				return JTokenType.TimeSpan;
			}
			throw new ArgumentException(StringUtils.FormatWith("Could not determine JSON object type for type {0}.", CultureInfo.InvariantCulture, value.GetType()));
		}

		private static JTokenType GetStringValueType(JTokenType? current)
		{
			if (!current.HasValue)
			{
				return JTokenType.String;
			}
			JTokenType value = current.Value;
			if (value != JTokenType.Comment && value != JTokenType.String && value != JTokenType.Raw)
			{
				return JTokenType.String;
			}
			return current.Value;
		}

		/// <summary>
		///       Writes this token to a <see cref="T:Open_Newtonsoft_Json.JsonWriter" />.
		///       </summary>
		/// <param name="writer">A <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> into which this method will write.</param>
		/// <param name="converters">A collection of <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> which will be used when writing the token.</param>
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
		{
			int num = 11;
			if (converters != null && converters.Length > 0 && _value != null)
			{
				JsonConverter matchingConverter = JsonSerializer.GetMatchingConverter(converters, _value.GetType());
				if (matchingConverter != null && matchingConverter.CanWrite)
				{
					matchingConverter.WriteJson(writer, _value, JsonSerializer.CreateDefault());
					return;
				}
			}
			switch (_valueType)
			{
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("TokenType", _valueType, "Unexpected token type.");
			case JTokenType.Comment:
				writer.WriteComment((_value != null) ? _value.ToString() : null);
				break;
			case JTokenType.Integer:
				if (_value is int)
				{
					writer.WriteValue((int)_value);
				}
				else if (_value is long)
				{
					writer.WriteValue((long)_value);
				}
				else if (_value is ulong)
				{
					writer.WriteValue((ulong)_value);
				}
				else
				{
					writer.WriteValue(Convert.ToInt64(_value, CultureInfo.InvariantCulture));
				}
				break;
			case JTokenType.Float:
				if (_value is decimal)
				{
					writer.WriteValue((decimal)_value);
				}
				else if (_value is double)
				{
					writer.WriteValue((double)_value);
				}
				else if (_value is float)
				{
					writer.WriteValue((float)_value);
				}
				else
				{
					writer.WriteValue(Convert.ToDouble(_value, CultureInfo.InvariantCulture));
				}
				break;
			case JTokenType.String:
				writer.WriteValue((_value != null) ? _value.ToString() : null);
				break;
			case JTokenType.Boolean:
				writer.WriteValue(Convert.ToBoolean(_value, CultureInfo.InvariantCulture));
				break;
			case JTokenType.Null:
				writer.WriteNull();
				break;
			case JTokenType.Undefined:
				writer.WriteUndefined();
				break;
			case JTokenType.Date:
				writer.WriteValue(Convert.ToDateTime(_value, CultureInfo.InvariantCulture));
				break;
			case JTokenType.Raw:
				writer.WriteRawValue((_value != null) ? _value.ToString() : null);
				break;
			case JTokenType.Bytes:
				writer.WriteValue((byte[])_value);
				break;
			case JTokenType.Guid:
			case JTokenType.Uri:
			case JTokenType.TimeSpan:
				writer.WriteValue((_value != null) ? _value.ToString() : null);
				break;
			}
		}

		internal override int GetDeepHashCode()
		{
			int num = (_value != null) ? _value.GetHashCode() : 0;
			int valueType = (int)_valueType;
			return valueType.GetHashCode() ^ num;
		}

		private static bool ValuesEquals(JValue jvalue_0, JValue jvalue_1)
		{
			return jvalue_0 == jvalue_1 || (jvalue_0._valueType == jvalue_1._valueType && Compare(jvalue_0._valueType, jvalue_0._value, jvalue_1._value) == 0);
		}

		/// <summary>
		///       Indicates whether the current object is equal to another object of the same type.
		///       </summary>
		/// <returns>
		///       true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
		///       </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(JValue other)
		{
			if (other == null)
			{
				return false;
			}
			return ValuesEquals(this, other);
		}

		/// <summary>
		///       Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
		///       </summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
		/// <returns>
		///       true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
		///       </returns>
		/// <exception cref="T:System.NullReferenceException">
		///       The <paramref name="obj" /> parameter is null.
		///       </exception>
		public override bool Equals(object other)
		{
			if (other == null)
			{
				return false;
			}
			JValue jValue = other as JValue;
			if (jValue != null)
			{
				return Equals(jValue);
			}
			return base.Equals(other);
		}

		/// <summary>
		///       Serves as a hash function for a particular type.
		///       </summary>
		/// <returns>
		///       A hash code for the current <see cref="T:System.Object" />.
		///       </returns>
		public override int GetHashCode()
		{
			if (_value == null)
			{
				return 0;
			}
			return _value.GetHashCode();
		}

		/// <summary>
		///       Returns a <see cref="T:System.String" /> that represents this instance.
		///       </summary>
		/// <returns>
		///       A <see cref="T:System.String" /> that represents this instance.
		///       </returns>
		public override string ToString()
		{
			if (_value == null)
			{
				return string.Empty;
			}
			return _value.ToString();
		}

		/// <summary>
		///       Returns a <see cref="T:System.String" /> that represents this instance.
		///       </summary>
		/// <param name="format">The format.</param>
		/// <returns>
		///       A <see cref="T:System.String" /> that represents this instance.
		///       </returns>
		public string ToString(string format)
		{
			return ToString(format, CultureInfo.CurrentCulture);
		}

		/// <summary>
		///       Returns a <see cref="T:System.String" /> that represents this instance.
		///       </summary>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>
		///       A <see cref="T:System.String" /> that represents this instance.
		///       </returns>
		public string ToString(IFormatProvider formatProvider)
		{
			return ToString(null, formatProvider);
		}

		/// <summary>
		///       Returns a <see cref="T:System.String" /> that represents this instance.
		///       </summary>
		/// <param name="format">The format.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>
		///       A <see cref="T:System.String" /> that represents this instance.
		///       </returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (_value == null)
			{
				return string.Empty;
			}
			IFormattable formattable = _value as IFormattable;
			if (formattable != null)
			{
				return formattable.ToString(format, formatProvider);
			}
			return _value.ToString();
		}

		int IComparable.CompareTo(object object_0)
		{
			if (object_0 == null)
			{
				return 1;
			}
			object objB = (object_0 is JValue) ? ((JValue)object_0).Value : object_0;
			return Compare(_valueType, _value, objB);
		}

		/// <summary>
		///       Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		///       </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		///       A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings:
		///       Value
		///       Meaning
		///       Less than zero
		///       This instance is less than <paramref name="obj" />.
		///       Zero
		///       This instance is equal to <paramref name="obj" />.
		///       Greater than zero
		///       This instance is greater than <paramref name="obj" />.
		///       </returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="obj" /> is not the same type as this instance.
		///       </exception>
		public int CompareTo(JValue other)
		{
			if (other == null)
			{
				return 1;
			}
			return Compare(_valueType, _value, other._value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			if (_value == null)
			{
				return TypeCode.Empty;
			}
			return System.Type.GetTypeCode(_value.GetType());
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return (bool)(JToken)this;
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return (char)(JToken)this;
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return (sbyte)(JToken)this;
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return (byte)(JToken)this;
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return (short)(JToken)this;
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return (ushort)(JToken)this;
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return (int)(JToken)this;
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return (uint)(JToken)this;
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return (long)(JToken)this;
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return (ulong)(JToken)this;
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return (float)(JToken)this;
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return (double)(JToken)this;
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return (decimal)(JToken)this;
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return (DateTime)(JToken)this;
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return ToObject(conversionType);
		}
	}
}

using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       对基础数据进行封装，并使之能进行XML序列化和反序列化
	                                                                    ///       </summary>
	[Serializable]
	[TypeConverter(typeof(GClass313))]
	[ComVisible(false)]
	[Editor("DCSoft.Data.WinForms.Design.XValueUIEditor", typeof(UITypeEditor))]
	public struct XValue
	{
		                                                                    /// <summary>
		                                                                    ///       表示空引用的数据
		                                                                    ///       </summary>
		public static readonly XValue NullValue = new XValue(null);

		private XValueType _Type;

		private string _Value;

		private string _CustomTypeName;

		private static Dictionary<XValueType, object> myDefaultValue = null;

		private static Dictionary<XValueType, Type> _TypeTable = null;

		                                                                    /// <summary>
		                                                                    ///       类型列表
		                                                                    ///       </summary>
		private static Dictionary<string, Type> _CustomTypes = new Dictionary<string, Type>();

		private object _RawValue;

		                                                                    /// <summary>
		                                                                    ///       对象数据类型
		                                                                    ///       </summary>
		[XmlAttribute]
		[DefaultValue(XValueType.String)]
		public XValueType Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象数据文本内容
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[XmlText]
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象类型名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string CustomTypeName
		{
			get
			{
				return _CustomTypeName;
			}
			set
			{
				_CustomTypeName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       当前数据类型的默认值
		                                                                    ///       </summary>
		[Browsable(false)]
		public object DefaultValue
		{
			get
			{
				CheckTypeTable();
				return myDefaultValue[Type];
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象数据类型
		                                                                    ///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public Type ValueType
		{
			get
			{
				CheckTypeTable();
				return _TypeTable[Type];
			}
			set
			{
				CheckTypeTable();
				foreach (XValueType key in _TypeTable.Keys)
				{
					if (_TypeTable[key].Equals(value))
					{
						_Type = key;
						break;
					}
				}
				if (_Type == XValueType.Object)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(value);
					if (converter != null && converter.CanConvertFrom(typeof(string)) && converter.CanConvertTo(typeof(string)))
					{
						_CustomTypeName = value.FullName;
					}
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象原始数据
		                                                                    ///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public object RawValue
		{
			get
			{
				if (_RawValue != null)
				{
					return _RawValue;
				}
				switch (_Type)
				{
				default:
					return null;
				case XValueType.String:
					return _Value;
				case XValueType.Null:
					return null;
				case XValueType.DBNull:
					return DBNull.Value;
				case XValueType.Char:
					return Convert.ToChar(_Value);
				case XValueType.Boolean:
					return Convert.ToBoolean(_Value);
				case XValueType.Byte:
					return Convert.ToByte(_Value);
				case XValueType.DateTime:
					return Convert.ToDateTime(_Value);
				case XValueType.Decimal:
					return Convert.ToDecimal(_Value);
				case XValueType.Double:
					return Convert.ToDouble(_Value);
				case XValueType.Int16:
					return Convert.ToInt16(_Value);
				case XValueType.Int32:
					return Convert.ToInt32(_Value);
				case XValueType.Int64:
					return Convert.ToInt64(_Value);
				case XValueType.SByte:
					return Convert.ToSByte(_Value);
				case XValueType.Single:
					return Convert.ToSingle(_Value);
				case XValueType.UInt16:
					return Convert.ToUInt16(_Value);
				case XValueType.UInt32:
					return Convert.ToUInt32(_Value);
				case XValueType.UInt64:
					return Convert.ToUInt64(_Value);
				case XValueType.Binary:
					return Convert.FromBase64String(_Value);
				case XValueType.Size:
					return TypeDescriptor.GetConverter(typeof(Size)).ConvertFromString(_Value);
				case XValueType.SizeF:
					return TypeDescriptor.GetConverter(typeof(SizeF)).ConvertFromString(_Value);
				case XValueType.Point:
					return TypeDescriptor.GetConverter(typeof(Point)).ConvertFromString(_Value);
				case XValueType.PointF:
					return TypeDescriptor.GetConverter(typeof(PointF)).ConvertFromString(_Value);
				case XValueType.Rectangle:
					return TypeDescriptor.GetConverter(typeof(Rectangle)).ConvertFromString(_Value);
				case XValueType.RectangleF:
					return TypeDescriptor.GetConverter(typeof(RectangleF)).ConvertFromString(_Value);
				case XValueType.Color:
					return TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(_Value);
				case XValueType.Font:
					return TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(_Value);
				case XValueType.Object:
				{
					if (_CustomTypeName != null && _CustomTypeName.Length > 0)
					{
						string key = _CustomTypeName.Trim().ToLower();
						if (_CustomTypes.ContainsKey(key))
						{
							Type type = _CustomTypes[key];
							TypeConverter converter = TypeDescriptor.GetConverter(type);
							return converter.ConvertFromString(_Value);
						}
					}
					byte[] buffer = Convert.FromBase64String(_Value);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					return binaryFormatter.Deserialize(new MemoryStream(buffer));
				}
				}
			}
			set
			{
				_RawValue = value;
				if (value == null)
				{
					_Type = XValueType.Null;
					_Value = null;
					return;
				}
				if (DBNull.Value.Equals(value))
				{
					_Type = XValueType.DBNull;
					_Value = null;
					return;
				}
				if (value is byte[])
				{
					_Type = XValueType.Binary;
					_Value = Convert.ToBase64String((byte[])value);
					return;
				}
				if (value is byte)
				{
					_Type = XValueType.Byte;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is sbyte)
				{
					_Type = XValueType.SByte;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is char)
				{
					_Type = XValueType.Char;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is bool)
				{
					_Type = XValueType.Boolean;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is DateTime)
				{
					_Type = XValueType.DateTime;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is decimal)
				{
					_Type = XValueType.Decimal;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is double)
				{
					_Type = XValueType.Double;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is short)
				{
					_Type = XValueType.Int16;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is ushort)
				{
					_Type = XValueType.UInt16;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is int)
				{
					_Type = XValueType.Int32;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is uint)
				{
					_Type = XValueType.UInt32;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is long)
				{
					_Type = XValueType.Int64;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is ulong)
				{
					_Type = XValueType.UInt64;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is float)
				{
					_Type = XValueType.Single;
					_Value = Convert.ToString(value);
					return;
				}
				if (value is string)
				{
					_Type = XValueType.String;
					_Value = (string)value;
					return;
				}
				if (value is Point)
				{
					_Type = XValueType.Point;
					_Value = TypeDescriptor.GetConverter(typeof(Point)).ConvertToString(value);
					return;
				}
				if (value is PointF)
				{
					_Type = XValueType.PointF;
					_Value = TypeDescriptor.GetConverter(typeof(PointF)).ConvertToString(value);
					return;
				}
				if (value is Size)
				{
					_Type = XValueType.Size;
					_Value = TypeDescriptor.GetConverter(typeof(Size)).ConvertToString(value);
					return;
				}
				if (value is SizeF)
				{
					_Type = XValueType.SizeF;
					_Value = TypeDescriptor.GetConverter(typeof(SizeF)).ConvertToString(value);
					return;
				}
				if (value is Rectangle)
				{
					_Type = XValueType.Rectangle;
					_Value = TypeDescriptor.GetConverter(typeof(Rectangle)).ConvertToString(value);
					return;
				}
				if (value is RectangleF)
				{
					_Type = XValueType.RectangleF;
					_Value = TypeDescriptor.GetConverter(typeof(RectangleF)).ConvertToString(value);
					return;
				}
				if (value is Color)
				{
					_Type = XValueType.Color;
					_Value = TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(value);
					return;
				}
				if (value is Font)
				{
					_Type = XValueType.Font;
					_Value = TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(value);
					return;
				}
				Type type = value.GetType();
				TypeConverter converter = TypeDescriptor.GetConverter(type);
				if (converter != null && converter.CanConvertFrom(typeof(string)) && converter.CanConvertTo(typeof(string)))
				{
					_Type = XValueType.Object;
					_CustomTypeName = type.FullName;
					_Value = converter.ConvertToString(value);
					_CustomTypes[_CustomTypeName] = type;
				}
				else if (Attribute.GetCustomAttribute(type, typeof(SerializableAttribute), inherit: false) != null)
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, value);
					memoryStream.Close();
					_Type = XValueType.Object;
					_Value = Convert.ToBase64String(memoryStream.ToArray());
				}
				else
				{
					_Type = XValueType.Null;
					_Value = null;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="rawValue">对象数据</param>
		public XValue(object rawValue)
		{
			if (rawValue is XValue)
			{
				XValue xValue = (XValue)rawValue;
				_Type = xValue._Type;
				_Value = xValue._Value;
				_CustomTypeName = null;
				_RawValue = xValue._RawValue;
			}
			else
			{
				_Type = XValueType.String;
				_Value = null;
				_RawValue = null;
				_CustomTypeName = null;
				RawValue = rawValue;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="type">对象数据类型</param>
		                                                                    /// <param name="Value">对象文本数据</param>
		public XValue(XValueType type, string Value)
		{
			_Type = type;
			_Value = Value;
			_RawValue = null;
			_CustomTypeName = null;
		}

		private static void CheckTypeTable()
		{
			if (myDefaultValue == null)
			{
				myDefaultValue = new Dictionary<XValueType, object>();
				myDefaultValue[XValueType.Binary] = null;
				myDefaultValue[XValueType.Boolean] = false;
				myDefaultValue[XValueType.Byte] = (byte)0;
				myDefaultValue[XValueType.Char] = '\0';
				myDefaultValue[XValueType.DateTime] = DateTime.MinValue;
				myDefaultValue[XValueType.DBNull] = DBNull.Value;
				myDefaultValue[XValueType.Decimal] = 0m;
				myDefaultValue[XValueType.Double] = 0.0;
				myDefaultValue[XValueType.Int16] = (short)0;
				myDefaultValue[XValueType.Int32] = 0;
				myDefaultValue[XValueType.Int64] = 0L;
				myDefaultValue[XValueType.Null] = null;
				myDefaultValue[XValueType.Object] = null;
				myDefaultValue[XValueType.SByte] = (sbyte)0;
				myDefaultValue[XValueType.Single] = 0f;
				myDefaultValue[XValueType.String] = null;
				myDefaultValue[XValueType.UInt16] = (ushort)0;
				myDefaultValue[XValueType.UInt32] = 0u;
				myDefaultValue[XValueType.UInt64] = 0uL;
				myDefaultValue[XValueType.Size] = Size.Empty;
				myDefaultValue[XValueType.SizeF] = SizeF.Empty;
				myDefaultValue[XValueType.Point] = Point.Empty;
				myDefaultValue[XValueType.PointF] = PointF.Empty;
				myDefaultValue[XValueType.Rectangle] = Rectangle.Empty;
				myDefaultValue[XValueType.RectangleF] = RectangleF.Empty;
				myDefaultValue[XValueType.Color] = Color.Empty;
				myDefaultValue[XValueType.Font] = Control.DefaultFont;
			}
			if (_TypeTable == null)
			{
				_TypeTable = new Dictionary<XValueType, Type>();
				_TypeTable[XValueType.Binary] = typeof(byte[]);
				_TypeTable[XValueType.Boolean] = typeof(bool);
				_TypeTable[XValueType.Byte] = typeof(byte);
				_TypeTable[XValueType.Char] = typeof(char);
				_TypeTable[XValueType.Color] = typeof(Color);
				_TypeTable[XValueType.DateTime] = typeof(DateTime);
				_TypeTable[XValueType.DBNull] = typeof(DBNull);
				_TypeTable[XValueType.Decimal] = typeof(decimal);
				_TypeTable[XValueType.Double] = typeof(double);
				_TypeTable[XValueType.Int16] = typeof(short);
				_TypeTable[XValueType.Int32] = typeof(int);
				_TypeTable[XValueType.Int64] = typeof(long);
				_TypeTable[XValueType.Null] = typeof(object);
				_TypeTable[XValueType.Object] = typeof(object);
				_TypeTable[XValueType.Point] = typeof(Point);
				_TypeTable[XValueType.PointF] = typeof(PointF);
				_TypeTable[XValueType.Rectangle] = typeof(Rectangle);
				_TypeTable[XValueType.RectangleF] = typeof(RectangleF);
				_TypeTable[XValueType.SByte] = typeof(sbyte);
				_TypeTable[XValueType.Single] = typeof(float);
				_TypeTable[XValueType.Size] = typeof(Size);
				_TypeTable[XValueType.SizeF] = typeof(SizeF);
				_TypeTable[XValueType.Font] = typeof(Font);
				_TypeTable[XValueType.String] = typeof(string);
				_TypeTable[XValueType.UInt16] = typeof(ushort);
				_TypeTable[XValueType.UInt32] = typeof(uint);
				_TypeTable[XValueType.UInt64] = typeof(ulong);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       返回包含对象数据的字符串
		                                                                    ///       </summary>
		                                                                    /// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 13;
			if (_Value == null)
			{
				return _Type.ToString();
			}
			return _Type.ToString() + ":" + _Value.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public XValue Clone()
		{
			XValue result = default(XValue);
			result._CustomTypeName = _CustomTypeName;
			result._RawValue = _RawValue;
			result._Type = _Type;
			result._Value = _Value;
			return result;
		}
	}
}

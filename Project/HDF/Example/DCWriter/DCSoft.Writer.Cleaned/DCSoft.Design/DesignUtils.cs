using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	[ComVisible(false)]
	public class DesignUtils
	{
		private class MyInheritsLayerComparer : IComparer<Type>
		{
			public int Compare(Type type_0, Type type_1)
			{
				return GetLayer(type_0) - GetLayer(type_1);
			}

			private int GetLayer(Type type_0)
			{
				int num = 0;
				while (type_0 != null)
				{
					num++;
					type_0 = type_0.BaseType;
				}
				return num;
			}
		}

		private enum SerializeStringType
		{
			Null,
			DBNull,
			Boolean,
			Byte,
			SByte,
			Char,
			Int16,
			UInt16,
			Int32,
			UInt32,
			Int64,
			UInt64,
			Decimal,
			Single,
			Double,
			DateTime,
			String,
			Binary,
			Enum,
			Point,
			PointF,
			Size,
			SizeF,
			Rectangle,
			RectangleF,
			Image,
			Icon,
			ConvertString,
			SeralizeBinary
		}

		private static Dictionary<Type, PropertyInfo[]> _TypeProperties = new Dictionary<Type, PropertyInfo[]>();

		private static Dictionary<string, Type> types = new Dictionary<string, Type>();

		private static string _RuntimePath = Path.GetDirectoryName(typeof(string).Assembly.Location);

		private static Dictionary<string, bool> _IsStdAssembly = new Dictionary<string, bool>();

		private static Dictionary<Type, string> _VBTypeNames = null;

		private static Dictionary<Type, string> _CSharpTypeNames = null;

		private static Dictionary<Type, Type> _ElementTypeWithoutAddMethod = new Dictionary<Type, Type>();

		private static Dictionary<Type, Type> _ElementTypeWithAddMethod = new Dictionary<Type, Type>();

		/// <summary>
		///       根据类型的继承层次进行排序。继承层次数比较少的在列表前面，层数比较多的在后面。
		///       </summary>
		/// <param name="types">类型列表</param>
		public static void SortTypesByInheritsLayer(List<Type> types)
		{
			int num = 13;
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			if (types.Count > 1)
			{
				types.Sort(new MyInheritsLayerComparer());
			}
		}

		/// <summary>
		///       从序列化的字符串还原对象值，本函数和ToSerializeString()搭配使用。
		///       </summary>
		/// <param name="str">字符串值</param>
		/// <returns>获得的对象值。</returns>
		public static object FromSerializeString(string string_0)
		{
			int num = 14;
			if (string_0 == null || string_0.Length == 0)
			{
				return null;
			}
			int num2 = string_0.IndexOf(':');
			if (num2 < 0)
			{
				return null;
			}
			string text = string_0.Substring(0, num2);
			string text2 = string_0.Substring(num2 + 1);
			SerializeStringType serializeStringType;
			if (text.StartsWith("+"))
			{
				text = text.Substring(1);
				ArrayList arrayList = new ArrayList();
				serializeStringType = (SerializeStringType)Enum.Parse(typeof(SerializeStringType), text);
				Type type = null;
				switch (serializeStringType)
				{
				case SerializeStringType.DBNull:
					type = typeof(DBNull);
					break;
				case SerializeStringType.Boolean:
					type = typeof(bool);
					break;
				case SerializeStringType.Byte:
					type = typeof(byte);
					break;
				case SerializeStringType.SByte:
					type = typeof(sbyte);
					break;
				case SerializeStringType.Char:
					type = typeof(char);
					break;
				case SerializeStringType.Int16:
					type = typeof(short);
					break;
				case SerializeStringType.UInt16:
					type = typeof(ushort);
					break;
				case SerializeStringType.Int32:
					type = typeof(int);
					break;
				case SerializeStringType.UInt32:
					type = typeof(uint);
					break;
				case SerializeStringType.Int64:
					type = typeof(long);
					break;
				case SerializeStringType.UInt64:
					type = typeof(ulong);
					break;
				case SerializeStringType.Decimal:
					type = typeof(decimal);
					break;
				case SerializeStringType.Single:
					type = typeof(float);
					break;
				case SerializeStringType.Double:
					type = typeof(double);
					break;
				case SerializeStringType.DateTime:
					type = typeof(DateTime);
					break;
				case SerializeStringType.String:
					type = typeof(string);
					break;
				case SerializeStringType.Binary:
					type = typeof(byte[]);
					break;
				case SerializeStringType.Point:
					type = typeof(Point);
					break;
				case SerializeStringType.PointF:
					type = typeof(PointF);
					break;
				case SerializeStringType.Size:
					type = typeof(Size);
					break;
				case SerializeStringType.SizeF:
					type = typeof(SizeF);
					break;
				case SerializeStringType.Rectangle:
					type = typeof(Rectangle);
					break;
				case SerializeStringType.RectangleF:
					type = typeof(RectangleF);
					break;
				case SerializeStringType.Image:
					type = typeof(Image);
					break;
				case SerializeStringType.Icon:
					type = typeof(Icon);
					break;
				}
				string[] array = text2.Split(new string[1]
				{
					"[@]"
				}, StringSplitOptions.None);
				string[] array2 = array;
				foreach (string string_ in array2)
				{
					object obj = FromSingleSeralizeString(serializeStringType, string_);
					if (obj != null && type == null)
					{
						type = obj.GetType();
					}
					arrayList.Add(obj);
				}
				if (type == null)
				{
					return arrayList.ToArray();
				}
				return arrayList.ToArray(type);
			}
			serializeStringType = (SerializeStringType)Enum.Parse(typeof(SerializeStringType), text);
			return FromSingleSeralizeString(serializeStringType, text2);
		}

		private static object FromSingleSeralizeString(SerializeStringType type, string string_0)
		{
			switch (type)
			{
			default:
				return null;
			case SerializeStringType.Null:
				return null;
			case SerializeStringType.DBNull:
				return DBNull.Value;
			case SerializeStringType.Boolean:
				return Convert.ToBoolean(string_0);
			case SerializeStringType.Byte:
				return Convert.ToByte(string_0);
			case SerializeStringType.SByte:
				return Convert.ToSByte(string_0);
			case SerializeStringType.Char:
				return Convert.ToChar(string_0);
			case SerializeStringType.Int16:
				return Convert.ToInt16(string_0);
			case SerializeStringType.UInt16:
				return Convert.ToUInt16(string_0);
			case SerializeStringType.Int32:
				return Convert.ToInt32(string_0);
			case SerializeStringType.UInt32:
				return Convert.ToUInt32(string_0);
			case SerializeStringType.Int64:
				return Convert.ToInt64(string_0);
			case SerializeStringType.UInt64:
				return Convert.ToUInt64(string_0);
			case SerializeStringType.Decimal:
				return Convert.ToDecimal(string_0);
			case SerializeStringType.Single:
				return Convert.ToSingle(string_0);
			case SerializeStringType.Double:
				return Convert.ToDouble(string_0);
			case SerializeStringType.DateTime:
				return DateTime.Parse(string_0);
			case SerializeStringType.String:
				return string_0;
			case SerializeStringType.Binary:
				return Convert.FromBase64String(string_0);
			case SerializeStringType.Enum:
			{
				int num = string_0.IndexOf('=');
				string typeName = string_0.Substring(0, num);
				string_0 = string_0.Substring(num + 1);
				Type typeByName = GetTypeByName(typeName);
				if (typeByName != null && typeByName.IsEnum)
				{
					return Enum.Parse(typeByName, string_0);
				}
				return null;
			}
			case SerializeStringType.Point:
			{
				string[] array2 = string_0.Split(',');
				if (array2 != null && array2.Length >= 2)
				{
					return new Point(Convert.ToInt32(array2[0]), Convert.ToInt32(array2[1]));
				}
				return Point.Empty;
			}
			case SerializeStringType.PointF:
			{
				string[] array2 = string_0.Split(',');
				if (array2 != null && array2.Length >= 2)
				{
					return new PointF(Convert.ToSingle(array2[0]), Convert.ToSingle(array2[1]));
				}
				return PointF.Empty;
			}
			case SerializeStringType.Size:
			{
				string[] array2 = string_0.Split(',');
				if (array2 != null && array2.Length >= 2)
				{
					return new Size(Convert.ToInt32(array2[0]), Convert.ToInt32(array2[1]));
				}
				return Size.Empty;
			}
			case SerializeStringType.SizeF:
			{
				string[] array2 = string_0.Split(',');
				if (array2 != null && array2.Length >= 2)
				{
					return new SizeF(Convert.ToSingle(array2[0]), Convert.ToSingle(array2[1]));
				}
				return SizeF.Empty;
			}
			case SerializeStringType.Rectangle:
			{
				string[] array2 = string_0.Split(',');
				if (array2 != null && array2.Length >= 4)
				{
					return new Rectangle(Convert.ToInt32(array2[0]), Convert.ToInt32(array2[1]), Convert.ToInt32(array2[2]), Convert.ToInt32(array2[3]));
				}
				return Rectangle.Empty;
			}
			case SerializeStringType.RectangleF:
			{
				string[] array2 = string_0.Split(',');
				if (array2 != null && array2.Length >= 4)
				{
					return new RectangleF(Convert.ToSingle(array2[0]), Convert.ToSingle(array2[1]), Convert.ToSingle(array2[2]), Convert.ToSingle(array2[3]));
				}
				return RectangleF.Empty;
			}
			case SerializeStringType.Image:
				if (string_0 != null && string_0.Length > 0)
				{
					byte[] array = Convert.FromBase64String(string_0);
					if (array != null && array.Length > 0)
					{
						MemoryStream memoryStream = new MemoryStream(array);
						Image result3 = Image.FromStream(memoryStream);
						memoryStream.Close();
						return result3;
					}
				}
				return null;
			case SerializeStringType.Icon:
				if (string_0 != null && string_0.Length > 0)
				{
					byte[] array = Convert.FromBase64String(string_0);
					if (array != null && array.Length > 0)
					{
						MemoryStream memoryStream = new MemoryStream(array);
						Icon result2 = new Icon(memoryStream);
						memoryStream.Close();
						return result2;
					}
				}
				return null;
			case SerializeStringType.ConvertString:
			{
				int num = string_0.IndexOf('=');
				string typeName = string_0.Substring(0, num);
				string_0 = string_0.Substring(num + 1);
				Type typeByName = GetTypeByName(typeName);
				if (typeByName != null)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeByName);
					if (converter != null && converter.CanConvertFrom(typeof(string)))
					{
						return converter.ConvertFromString(string_0);
					}
				}
				return null;
			}
			case SerializeStringType.SeralizeBinary:
				if (string_0 != null && string_0.Length > 0)
				{
					byte[] array = Convert.FromBase64String(string_0);
					if (array != null && array.Length > 0)
					{
						MemoryStream memoryStream = new MemoryStream(array);
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						object result = binaryFormatter.Deserialize(memoryStream);
						memoryStream.Close();
						return result;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       将对象转换为一个序列化的字符串,本函数和FromSerializeString()搭配使用。
		///       </summary>
		/// <param name="v">对象数值</param>
		/// <returns>获得的字符串</returns>
		public static string ToSerializeString(object object_0)
		{
			int num = 15;
			if (object_0 == null)
			{
				return SerializeStringType.Null.ToString();
			}
			if (DBNull.Value.Equals(object_0))
			{
				return SerializeStringType.DBNull.ToString();
			}
			if (object_0 is byte[])
			{
				return ToSingleSerializeString(object_0, addPrefix: true);
			}
			if (object_0.GetType().IsArray)
			{
				object_0.GetType().GetElementType();
				StringBuilder stringBuilder = new StringBuilder();
				bool addPrefix = true;
				foreach (object item in (IList)object_0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append("[@]");
					}
					stringBuilder.Append(ToSingleSerializeString(item, addPrefix));
					addPrefix = false;
				}
				stringBuilder.Insert(0, "+");
				return stringBuilder.ToString();
			}
			return ToSingleSerializeString(object_0, addPrefix: true);
		}

		private static string ToSingleSerializeString(object object_0, bool addPrefix)
		{
			int num = 1;
			if (object_0 is bool)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Boolean, ":", Convert.ToString(object_0));
				}
				return Convert.ToString(object_0);
			}
			if (object_0 is byte)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Byte, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is sbyte)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.SByte, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is char)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Char, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is short)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Int16, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is ushort)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.UInt16, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is int)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Int32, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is uint)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.UInt32, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is long)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Int64, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is ulong)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.UInt64, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is decimal)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Decimal, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is float)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Single, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is double)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Double, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is DateTime)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.DateTime, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is string)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.String, ":", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is byte[])
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Binary, ":", Convert.ToBase64String((byte[])object_0));
				}
				return object_0.ToString();
			}
			if (object_0.GetType().IsEnum)
			{
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Enum, ":", object_0.GetType().FullName, "=", object_0.ToString());
				}
				return object_0.ToString();
			}
			if (object_0 is Point)
			{
				Point point = (Point)object_0;
				string text = point.X + "," + point.Y;
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Point, ":", text);
				}
				return text;
			}
			if (object_0 is PointF)
			{
				PointF pointF = (PointF)object_0;
				string text = pointF.X + "," + pointF.Y;
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.PointF, ":", text);
				}
				return text;
			}
			if (object_0 is Size)
			{
				Size size = (Size)object_0;
				string text = size.Width + "," + size.Height;
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Size, ":", text);
				}
				return text;
			}
			if (object_0 is SizeF)
			{
				SizeF sizeF = (SizeF)object_0;
				string text = sizeF.Width + "," + sizeF.Height;
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.SizeF, ":", text);
				}
				return text;
			}
			if (object_0 is Rectangle)
			{
				Rectangle rectangle = (Rectangle)object_0;
				string text = rectangle.Left + "," + rectangle.Top + "," + rectangle.Width + "," + rectangle.Height;
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Rectangle, ":", text);
				}
				return text;
			}
			if (object_0 is RectangleF)
			{
				RectangleF rectangleF = (RectangleF)object_0;
				string text = rectangleF.Left + "," + rectangleF.Top + "," + rectangleF.Width + "," + rectangleF.Height;
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Rectangle, ":", text);
				}
				return text;
			}
			MemoryStream memoryStream;
			if (object_0 is Image)
			{
				Image image = (Image)object_0;
				memoryStream = new MemoryStream();
				image.Save(memoryStream, ImageFormat.Jpeg);
				memoryStream.Close();
				string text = Convert.ToBase64String(memoryStream.ToArray());
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Image, ":", text);
				}
				return text;
			}
			if (object_0 is Icon)
			{
				Icon icon = (Icon)object_0;
				memoryStream = new MemoryStream();
				icon.Save(memoryStream);
				memoryStream.Close();
				string text = Convert.ToBase64String(memoryStream.ToArray());
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.Image, ":", text);
				}
				return text;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(object_0);
			if (converter != null && converter.CanConvertTo(typeof(string)))
			{
				string text = converter.ConvertToString(object_0);
				if (addPrefix)
				{
					return string.Concat(SerializeStringType.ConvertString, ":", object_0.GetType().FullName, "=", text);
				}
				return text;
			}
			memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, object_0);
			memoryStream.Close();
			string text2 = Convert.ToBase64String(memoryStream.ToArray());
			if (addPrefix)
			{
				return string.Concat(SerializeStringType.SeralizeBinary, ":", text2);
			}
			return text2;
		}

		/// <summary>
		///       获得和指定
		///       </summary>
		/// <param name="types">
		/// </param>
		/// <param name="targetType">
		/// </param>
		/// <returns>
		/// </returns>
		public static Type GetNearestType(IEnumerable types, Type targetType)
		{
			int num = 11;
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			int num2 = -1;
			Type result = null;
			foreach (Type type3 in types)
			{
				if (type3.IsAssignableFrom(targetType))
				{
					Type type2 = type3;
					int num3 = 0;
					while (type2 != null)
					{
						num3++;
						type2 = type2.BaseType;
					}
					if (num3 > num2)
					{
						num2 = num3;
						result = type3;
					}
				}
			}
			return result;
		}

		public static PropertyInfo GetDataProperty(Type type_0, string name)
		{
			int num = 15;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			PropertyInfo[] dataProperties = GetDataProperties(type_0);
			if (dataProperties.Length > 0)
			{
				PropertyInfo[] array = dataProperties;
				foreach (PropertyInfo propertyInfo in array)
				{
					if (string.Compare(propertyInfo.Name, name, ignoreCase: true) == 0)
					{
						return propertyInfo;
					}
				}
			}
			return null;
		}

		public static PropertyInfo[] GetDataProperties(Type type_0)
		{
			int num = 14;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (_TypeProperties.ContainsKey(type_0))
			{
				return _TypeProperties[type_0];
			}
			List<PropertyInfo> list = new List<PropertyInfo>();
			PropertyInfo[] properties = type_0.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.CanRead)
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if ((indexParameters == null || indexParameters.Length <= 0) && Attribute.GetCustomAttribute(propertyInfo, typeof(ObsoleteAttribute), inherit: true) == null)
					{
						list.Add(propertyInfo);
					}
				}
			}
			PropertyInfo[] array = list.ToArray();
			_TypeProperties[type_0] = array;
			return array;
		}

		public static bool IsCollectionProperty(PropertyInfo propertyInfo_0)
		{
			int num = 12;
			if (propertyInfo_0 == null)
			{
				throw new ArgumentNullException("p");
			}
			ParameterInfo[] indexParameters = propertyInfo_0.GetIndexParameters();
			if (indexParameters != null && indexParameters.Length > 0)
			{
				return false;
			}
			try
			{
				Attribute[] customAttributes = Attribute.GetCustomAttributes(propertyInfo_0, typeof(XmlArrayItemAttribute), inherit: true);
				if (customAttributes != null && customAttributes.Length > 0)
				{
					return true;
				}
			}
			catch (Exception)
			{
			}
			if (GetCollectionItemType(propertyInfo_0.PropertyType, checkAddMethod: false) != null)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得类型的全名
		///       </summary>
		/// <param name="type">类型对象</param>
		/// <returns>全名</returns>
		public static string GetTypeFullName(Type type)
		{
			int num = 9;
			if (type == null)
			{
				return null;
			}
			string text = type.FullName + "," + type.Assembly.GetName().Name;
			types[text] = type;
			return text;
		}

		/// <summary>
		///       获得控件类型
		///       </summary>
		/// <param name="typeName">类型名称</param>
		/// <param name="specifyBaseType">指定的基础类型</param>
		/// <returns>获得的控件类型</returns>
		public static Type GetTypeByName(string typeName)
		{
			int num = 16;
			if (typeName == null || typeName.Trim().Length == 0)
			{
				return null;
			}
			if (types.ContainsKey(typeName))
			{
				return types[typeName];
			}
			string name = typeName.Trim();
			int num2 = typeName.IndexOf(",");
			string text = null;
			Type type;
			if (num2 > 0)
			{
				text = typeName.Substring(num2 + 1).Trim();
				name = typeName.Substring(0, num2).Trim();
			}
			else
			{
				Assembly callingAssembly = Assembly.GetCallingAssembly();
				type = callingAssembly.GetType(typeName, throwOnError: false, ignoreCase: true);
				if (type == null && typeName.IndexOf(".") < 0)
				{
					Type[] array = callingAssembly.GetTypes();
					foreach (Type type2 in array)
					{
						if (string.Compare(type2.Name, typeName, ignoreCase: true) == 0)
						{
							type = type2;
							break;
						}
					}
				}
				if (type != null)
				{
					types[typeName] = type;
					return type;
				}
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly[] array2 = assemblies;
			int i = 0;
			while (true)
			{
				if (i < array2.Length)
				{
					Assembly callingAssembly = array2[i];
					if (text == null || string.Compare(text, callingAssembly.GetName().Name, ignoreCase: true) == 0)
					{
						type = callingAssembly.GetType(name, throwOnError: false, ignoreCase: true);
						if (type != null)
						{
							break;
						}
					}
					i++;
					continue;
				}
				return null;
			}
			types[typeName] = type;
			return type;
		}

		/// <summary>
		///       判断一个程序集是否是标准运行库中的程序集
		///       </summary>
		/// <param name="asm">程序集对象</param>
		/// <returns>判断结果</returns>
		public static bool IsStdAssembly(Assembly assembly_0)
		{
			int num = 11;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			if (string.IsNullOrEmpty(assembly_0.Location))
			{
				return false;
			}
			if (assembly_0.FullName != null && assembly_0.FullName.StartsWith("Microsoft."))
			{
				return true;
			}
			if (_IsStdAssembly.ContainsKey(assembly_0.Location))
			{
				return _IsStdAssembly[assembly_0.Location];
			}
			if (assembly_0.GlobalAssemblyCache)
			{
				string path = Path.Combine(_RuntimePath, assembly_0.GetName().Name + ".dll");
				if (File.Exists(path))
				{
					_IsStdAssembly[assembly_0.Location] = true;
					return true;
				}
			}
			string location = assembly_0.Location;
			string directoryName = Path.GetDirectoryName(location);
			string directoryName2 = Path.GetDirectoryName(typeof(string).Assembly.Location);
			if (string.Compare(directoryName, directoryName2, ignoreCase: true) == 0)
			{
				_IsStdAssembly[assembly_0.Location] = true;
				return true;
			}
			_IsStdAssembly[assembly_0.Location] = false;
			return false;
		}

		/// <summary>
		///       以列表方式编辑枚举类型数值
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <param name="provider">
		/// </param>
		/// <param name="oldValue">
		/// </param>
		/// <param name="enumType">
		/// </param>
		/// <returns>
		/// </returns>
		public static object EditEnumValue(ITypeDescriptorContext context, IServiceProvider provider, object oldValue, Type enumType)
		{
			object[] array = GClass346.smethod_1(enumType);
			if (array == null || array.Length == 0)
			{
				return oldValue;
			}
			int num = array.Length / 2;
			object[] array2 = new object[num];
			string[] array3 = new string[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = array[i * 2];
				if (!object.Equals(array2[i], oldValue))
				{
				}
				array3[i] = (string)array[i * 2 + 1];
				if (Convert.ToString(array2[i]) == array3[i])
				{
					array3[i] = "";
				}
			}
			return EditValueWidthDescriptions(context, provider, oldValue, array2, array3);
		}

		public static string EditStringValue(ITypeDescriptorContext context, IServiceProvider provider, string oldValue, IEnumerable items)
		{
			using (ListBox listBox = new ListBox())
			{
				foreach (object item in items)
				{
					listBox.Items.Add(item);
				}
				for (int i = 0; i < listBox.Items.Count; i++)
				{
					if (Convert.ToString(listBox.Items[i]) == oldValue)
					{
						listBox.SelectedIndex = i;
						break;
					}
				}
				int num = EditValueUseListBox(listBox, context, provider);
				if (num >= 0)
				{
					return listBox.Text;
				}
				return oldValue;
			}
		}

		public static object EditValueWidthDescriptions(ITypeDescriptorContext context, IServiceProvider provider, object oldValue, IList items, IList descriptions)
		{
			int num = 3;
			using (ListBox listBox = new ListBox())
			{
				string[] array = new string[items.Count];
				int num2 = -1;
				if (descriptions != null && descriptions.Count > 0)
				{
					int num3 = 1;
					for (int i = 0; i < items.Count; i++)
					{
						string text = Convert.ToString(items[i]);
						if (text != null)
						{
							num3 = Math.Max(num3, Encoding.UTF8.GetByteCount(text));
						}
						array[i] = text;
						if (object.Equals(items[i], oldValue))
						{
							num2 = i;
						}
					}
					num3++;
					for (int i = 0; i < array.Length; i++)
					{
						string text = array[i];
						int byteCount = Encoding.UTF8.GetByteCount(text);
						if (byteCount < num3)
						{
							text += new string(' ', num3 - byteCount);
						}
						array[i] = text;
						if (descriptions != null && i < descriptions.Count)
						{
							array[i] = text + " " + descriptions[i];
						}
					}
				}
				else
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Convert.ToString(items[i]);
						if (object.Equals(items[i], oldValue))
						{
							num2 = i;
						}
					}
				}
				listBox.Items.AddRange(array);
				if (num2 >= 0)
				{
					listBox.SelectedIndex = num2;
				}
				int num4 = EditValueUseListBox(listBox, context, provider);
				if (num4 >= 0 && num4 != num2)
				{
					return items[num4];
				}
				return oldValue;
			}
		}

		private static void lst_DrawItem(object sender, DrawItemEventArgs e)
		{
			throw new NotImplementedException();
		}

		private static void lst_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///       使用列表控件编辑数值
		///       </summary>
		/// <param name="lst">列表控件对象</param>
		/// <param name="context">
		/// </param>
		/// <param name="provider">
		/// </param>
		/// <returns>列表控件中选中的项目序号</returns>
		public static int EditValueUseListBox(ListBox listBox_0, ITypeDescriptorContext context, IServiceProvider provider)
		{
			IWindowsFormsEditorService host = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			listBox_0.Tag = host;
			listBox_0.Width = 300;
			listBox_0.Height = 300;
			if (!listBox_0.IsHandleCreated)
			{
				listBox_0.CreateControl();
			}
			Size preferredSize = listBox_0.GetPreferredSize(new Size(200, 400));
			if ((double)preferredSize.Height > (double)Screen.PrimaryScreen.WorkingArea.Height / 2.3)
			{
				preferredSize.Height = (int)((double)Screen.PrimaryScreen.WorkingArea.Height / 2.3);
			}
			listBox_0.Size = preferredSize;
			listBox_0.Click += delegate
			{
				listBox_0.Tag = true;
				host.CloseDropDown();
			};
			host.DropDownControl(listBox_0);
			if (listBox_0.Tag is bool)
			{
				return listBox_0.SelectedIndex;
			}
			return -1;
		}

		public static string ToCShaprValueString(object object_0)
		{
			int num = 3;
			if (object_0 == null)
			{
				return "null";
			}
			if (DBNull.Value.Equals(object_0))
			{
				return "System.DBNull.Value";
			}
			if (object_0 is string)
			{
				string text = (string)object_0;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("\"");
				string text2 = text;
				foreach (char c in text2)
				{
					switch (c)
					{
					case '\r':
						stringBuilder.Append("\r");
						break;
					case '\n':
						stringBuilder.Append("\n");
						break;
					case '"':
						stringBuilder.Append("\\\"");
						break;
					default:
						stringBuilder.Append(c);
						break;
					}
				}
				stringBuilder.Append("\"");
				return stringBuilder.ToString();
			}
			if (object_0 is DateTime)
			{
				DateTime dateTime = (DateTime)object_0;
				if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0)
				{
					return "new DateTime(" + dateTime.Year + ", " + dateTime.Month + ", " + dateTime.Day + ")";
				}
				return "new DateTime(" + dateTime.Year + ", " + dateTime.Month + ", " + dateTime.Day + ", " + dateTime.Hour + ", " + dateTime.Minute + ", " + dateTime.Second + ")";
			}
			if (object_0 is float)
			{
				return object_0.ToString() + "f";
			}
			if (object_0 is Enum)
			{
				Type type = object_0.GetType();
				if (Attribute.GetCustomAttribute(type, typeof(FlagsAttribute), inherit: false) == null)
				{
					return type.FullName + "." + object_0.ToString();
				}
				if (Enum.IsDefined(type, object_0))
				{
					return type.FullName + "." + object_0.ToString();
				}
				return "(" + type.FullName + ")" + Convert.ToInt32(object_0);
			}
			if (object_0 is decimal)
			{
				return object_0.ToString() + "d";
			}
			if (object_0 is long)
			{
				return "(long)" + object_0.ToString();
			}
			if (object_0 is Color)
			{
				Color color = (Color)object_0;
				if (color.IsEmpty)
				{
					return "Color.Empty";
				}
				if (color.IsNamedColor)
				{
					return "Color." + color.Name;
				}
				return "Color.FromArgb(" + color.ToArgb() + ")";
			}
			if (object_0 is bool)
			{
				if ((bool)object_0)
				{
					return "true";
				}
				return "false";
			}
			return object_0.ToString();
		}

		/// <summary>
		///       获得类型的C#语法名称
		///       </summary>
		/// <param name="t">类型</param>
		/// <returns>类型名称</returns>
		public static string GetVBTypeName(Type type_0)
		{
			int num = 2;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (_VBTypeNames == null)
			{
				_VBTypeNames = new Dictionary<Type, string>();
				_VBTypeNames[typeof(bool)] = "Boolean";
				_VBTypeNames[typeof(byte)] = "Byte";
				_VBTypeNames[typeof(sbyte)] = "SByte";
				_VBTypeNames[typeof(short)] = "Short";
				_VBTypeNames[typeof(ushort)] = "UShort";
				_VBTypeNames[typeof(int)] = "Integer";
				_VBTypeNames[typeof(uint)] = "UInteger";
				_VBTypeNames[typeof(long)] = "Long";
				_VBTypeNames[typeof(ulong)] = "ULong";
				_VBTypeNames[typeof(float)] = "Single";
				_VBTypeNames[typeof(double)] = "Double";
				_VBTypeNames[typeof(decimal)] = "Decimal";
				_VBTypeNames[typeof(DateTime)] = "Date";
				_VBTypeNames[typeof(string)] = "String";
				_VBTypeNames[typeof(void)] = "System.Void";
				_VBTypeNames[typeof(object)] = "Object";
				_VBTypeNames[typeof(char)] = "Char";
			}
			if (_VBTypeNames.ContainsKey(type_0))
			{
				return _VBTypeNames[type_0];
			}
			if (type_0.IsArray)
			{
				Type elementType = type_0.GetElementType();
				return GetVBTypeName(elementType) + "()";
			}
			if (type_0.IsGenericType)
			{
				Type genericTypeDefinition = type_0.GetGenericTypeDefinition();
				Type[] genericArguments = type_0.GetGenericArguments();
				string text = genericTypeDefinition.FullName;
				int num2 = text.IndexOf("`");
				if (num2 > 0)
				{
					text = text.Substring(0, num2);
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(text + "(Of ");
				if (genericArguments != null && genericArguments.Length > 0)
				{
					for (int i = 0; i < genericArguments.Length; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(GetVBTypeName(genericArguments[i]));
					}
				}
				stringBuilder.Append(")");
				return stringBuilder.ToString();
			}
			if (type_0.Namespace == "System")
			{
				return type_0.Name;
			}
			return type_0.FullName;
		}

		/// <summary>
		///       获得类型的C#语法名称
		///       </summary>
		/// <param name="t">类型</param>
		/// <returns>类型名称</returns>
		public static string GetCSharpTypeName(Type type_0)
		{
			int num = 7;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (_CSharpTypeNames == null)
			{
				_CSharpTypeNames = new Dictionary<Type, string>();
				_CSharpTypeNames[typeof(bool)] = "bool";
				_CSharpTypeNames[typeof(byte)] = "byte";
				_CSharpTypeNames[typeof(sbyte)] = "sbyte";
				_CSharpTypeNames[typeof(short)] = "short";
				_CSharpTypeNames[typeof(ushort)] = "ushort";
				_CSharpTypeNames[typeof(int)] = "int";
				_CSharpTypeNames[typeof(uint)] = "uint";
				_CSharpTypeNames[typeof(long)] = "long";
				_CSharpTypeNames[typeof(ulong)] = "ulong";
				_CSharpTypeNames[typeof(float)] = "float";
				_CSharpTypeNames[typeof(double)] = "double";
				_CSharpTypeNames[typeof(decimal)] = "decimal";
				_CSharpTypeNames[typeof(DateTime)] = "DateTime";
				_CSharpTypeNames[typeof(string)] = "string";
				_CSharpTypeNames[typeof(void)] = "void";
				_CSharpTypeNames[typeof(object)] = "object";
				_CSharpTypeNames[typeof(char)] = "char";
			}
			if (_CSharpTypeNames.ContainsKey(type_0))
			{
				return _CSharpTypeNames[type_0];
			}
			if (type_0.IsArray)
			{
				Type elementType = type_0.GetElementType();
				return GetCSharpTypeName(elementType) + "[]";
			}
			if (type_0.IsGenericType)
			{
				Type genericTypeDefinition = type_0.GetGenericTypeDefinition();
				Type[] genericArguments = type_0.GetGenericArguments();
				string text = genericTypeDefinition.FullName;
				int num2 = text.IndexOf("`");
				if (num2 > 0)
				{
					text = text.Substring(0, num2);
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(text + "<");
				if (genericArguments != null && genericArguments.Length > 0)
				{
					for (int i = 0; i < genericArguments.Length; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(GetCSharpTypeName(genericArguments[i]));
					}
				}
				stringBuilder.Append(">");
				return stringBuilder.ToString();
			}
			if (type_0.Namespace == "System")
			{
				return type_0.Name;
			}
			string text2 = type_0.FullName;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = type_0.Name;
			}
			if (type_0.IsNested)
			{
				text2 = text2.Replace('+', '.');
			}
			_CSharpTypeNames[type_0] = text2;
			return text2;
		}

		public static string GetTypeID(Type type_0)
		{
			int num = 18;
			if (type_0 == null)
			{
				return null;
			}
			return type_0.FullName + "," + type_0.Assembly.GetName().Name;
		}

		public static Type GetCollectionItemType(Type rootType, bool checkAddMethod)
		{
			int num = 4;
			if (rootType == null)
			{
				throw new ArgumentNullException("rootType");
			}
			if (rootType.Equals(typeof(string)))
			{
				return null;
			}
			if (rootType.IsArray)
			{
				if (checkAddMethod)
				{
					return null;
				}
				Type elementType = rootType.GetElementType();
				if (elementType != null && (elementType.IsPrimitive || elementType == typeof(string) || elementType == typeof(DateTime) || elementType == typeof(decimal)))
				{
					return null;
				}
			}
			if (typeof(XmlNode).IsAssignableFrom(rootType))
			{
				return null;
			}
			if (checkAddMethod)
			{
				if (_ElementTypeWithAddMethod.ContainsKey(rootType))
				{
					return _ElementTypeWithAddMethod[rootType];
				}
			}
			else if (_ElementTypeWithoutAddMethod.ContainsKey(rootType))
			{
				return _ElementTypeWithoutAddMethod[rootType];
			}
			if (rootType.Equals(typeof(XmlNodeList)))
			{
				_ElementTypeWithAddMethod[rootType] = null;
				_ElementTypeWithoutAddMethod[rootType] = typeof(XmlNodeList);
				if (checkAddMethod)
				{
					return null;
				}
				return typeof(XmlNodeList);
			}
			if (rootType.IsArray)
			{
				_ElementTypeWithAddMethod[rootType] = null;
				_ElementTypeWithoutAddMethod[rootType] = rootType.GetElementType();
				if (checkAddMethod)
				{
					return null;
				}
				return rootType.GetElementType();
			}
			bool flag = false;
			Type[] interfaces = rootType.GetInterfaces();
			if (interfaces != null)
			{
				Type[] array = interfaces;
				foreach (Type c in array)
				{
					if (typeof(IEnumerable).IsAssignableFrom(c))
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				_ElementTypeWithoutAddMethod[rootType] = null;
				_ElementTypeWithAddMethod[rootType] = null;
				return null;
			}
			Type type = null;
			MemberInfo[] defaultMembers = rootType.GetDefaultMembers();
			if (defaultMembers != null)
			{
				MemberInfo[] array2 = defaultMembers;
				foreach (MemberInfo memberInfo in array2)
				{
					if (!(memberInfo is PropertyInfo))
					{
						continue;
					}
					PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
					if (!propertyInfo.CanRead)
					{
						continue;
					}
					type = ((PropertyInfo)memberInfo).PropertyType;
					if (checkAddMethod)
					{
						MethodInfo[] methods = rootType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
						foreach (MethodInfo methodInfo in methods)
						{
							if (string.Compare(methodInfo.Name, "Add", ignoreCase: true) != 0)
							{
								continue;
							}
							ParameterInfo[] parameters = methodInfo.GetParameters();
							if (parameters == null || parameters.Length != 1 || !parameters[0].ParameterType.Equals(type))
							{
								continue;
							}
							goto IL_0304;
						}
						continue;
					}
					goto IL_0304;
					IL_0304:
					if (type != null)
					{
						_ElementTypeWithoutAddMethod[rootType] = type;
						if (checkAddMethod)
						{
							_ElementTypeWithAddMethod[rootType] = type;
						}
					}
					return type;
				}
			}
			return null;
		}

		public static string GetDisplayName(MemberInfo memberInfo_0)
		{
			try
			{
				if (memberInfo_0 is PropertyInfo)
				{
					PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(memberInfo_0.DeclaringType);
					PropertyDescriptor propertyDescriptor = properties[memberInfo_0.Name];
					if (propertyDescriptor != null)
					{
						return propertyDescriptor.DisplayName;
					}
				}
				DisplayNameAttribute[] array = (DisplayNameAttribute[])Attribute.GetCustomAttributes(memberInfo_0, typeof(DisplayNameAttribute), inherit: true);
				if (array != null && array.Length > 0)
				{
					return array[0].DisplayName;
				}
			}
			catch
			{
			}
			return null;
		}

		public static string GetDescription(MemberInfo memberInfo_0)
		{
			try
			{
				if (memberInfo_0 is PropertyInfo)
				{
					PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(memberInfo_0.DeclaringType);
					PropertyDescriptor propertyDescriptor = properties[memberInfo_0.Name];
					if (propertyDescriptor != null)
					{
						return propertyDescriptor.Description;
					}
				}
				DescriptionAttribute[] array = (DescriptionAttribute[])Attribute.GetCustomAttributes(memberInfo_0, typeof(DescriptionAttribute), inherit: true);
				if (array != null && array.Length > 0)
				{
					return array[0].Description;
				}
			}
			catch
			{
			}
			return null;
		}

		internal static bool GetBrowsable(MemberInfo memberInfo_0)
		{
			try
			{
				return ((BrowsableAttribute)Attribute.GetCustomAttribute(memberInfo_0, typeof(BrowsableAttribute), inherit: true))?.Browsable ?? true;
			}
			catch
			{
			}
			return true;
		}

		public static Image GetToolboxImage(Type type_0)
		{
			int num = 7;
			Image image = null;
			ToolboxBitmapAttribute toolboxBitmapAttribute = (ToolboxBitmapAttribute)Attribute.GetCustomAttribute(type_0, typeof(ToolboxBitmapAttribute), inherit: true);
			if (toolboxBitmapAttribute != null)
			{
				image = toolboxBitmapAttribute.GetImage(type_0);
			}
			if (image == null)
			{
				Stream manifestResourceStream = type_0.Assembly.GetManifestResourceStream(type_0.FullName + ".bmp");
				if (manifestResourceStream != null)
				{
					try
					{
						Bitmap bitmap = new Bitmap(manifestResourceStream);
						bitmap.MakeTransparent();
						manifestResourceStream.Close();
						image = bitmap;
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
						image = null;
					}
				}
			}
			return image;
		}

		public static string GetParameterCSharpString(ParameterInfo[] parameterInfo_0, bool includeTypeName)
		{
			int num = 4;
			if (parameterInfo_0 == null || parameterInfo_0.Length == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ParameterInfo parameterInfo in parameterInfo_0)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				if (parameterInfo.IsIn && parameterInfo.IsOut)
				{
					stringBuilder.Append(" ref ");
				}
				if (includeTypeName)
				{
					stringBuilder.Append(GetCSharpTypeName(parameterInfo.ParameterType));
				}
				stringBuilder.Append(" " + parameterInfo.Name);
			}
			return stringBuilder.ToString();
		}

		public static string GetParameterVBString(ParameterInfo[] parameterInfo_0, bool includeTypeName)
		{
			int num = 2;
			if (parameterInfo_0 == null || parameterInfo_0.Length == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ParameterInfo parameterInfo in parameterInfo_0)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				if (parameterInfo.IsIn || parameterInfo.IsOut)
				{
					stringBuilder.Append("ByRef ");
				}
				else
				{
					stringBuilder.Append("ByVal ");
				}
				stringBuilder.Append(parameterInfo.Name);
				if (includeTypeName)
				{
					stringBuilder.Append(" As ");
					stringBuilder.Append(GetVBTypeName(parameterInfo.ParameterType));
				}
			}
			return stringBuilder.ToString();
		}
	}
}

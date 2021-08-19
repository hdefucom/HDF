#define DEBUG
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       数值,类型转换相关帮助类
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class ValueTypeHelper
	{
		private static Dictionary<Type, PropertyInfo[]> _GetPropertiesAttributeString_Properties = new Dictionary<Type, PropertyInfo[]>();

		private static Dictionary<Type, Dictionary<string, PropertyInfo>> _GetPropertyValueInfos = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		private static Dictionary<PropertyInfo, object> _PropertyDefaultValues = new Dictionary<PropertyInfo, object>();

		private static Hashtable _TypeDefaultValue = null;

		public static int CopyPropertyValues(object sourceInstance, object targetInstance)
		{
			int num = 19;
			if (sourceInstance == null)
			{
				throw new ArgumentNullException("sourceInstance");
			}
			if (targetInstance == null)
			{
				throw new ArgumentNullException("targetInstance");
			}
			if (sourceInstance.GetType() != targetInstance.GetType())
			{
				throw new InvalidCastException(sourceInstance.GetType().FullName + "<>" + targetInstance.GetType().FullName);
			}
			int num2 = 0;
			PropertyInfo[] properties = sourceInstance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (Attribute.GetCustomAttribute(propertyInfo, typeof(XmlIgnoreAttribute), inherit: true) == null && propertyInfo.CanRead && propertyInfo.CanWrite)
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters == null || indexParameters.Length <= 0)
					{
						propertyInfo.SetValue(targetInstance, propertyInfo.GetValue(sourceInstance, null), null);
						num2++;
					}
				}
			}
			return num2;
		}

		public static int SetPropertiesAttributeString(object instance, string attributeString)
		{
			if (instance == null || string.IsNullOrEmpty(attributeString))
			{
				return 0;
			}
			GClass340 gClass = new GClass340(attributeString);
			int num = 0;
			foreach (GClass341 item in gClass)
			{
				if (SetPropertyValue(instance, item.Name, item.method_0(), throwException: false))
				{
					num++;
				}
			}
			return num;
		}

		public static string GetPropertiesAttributeString(object instance, bool detectDefaultValue)
		{
			if (instance == null)
			{
				return null;
			}
			GClass338 gClass = new GClass338();
			GetPropertiesAttributeString(instance, detectDefaultValue, gClass);
			return gClass.ToString();
		}

		public static void GetPropertiesAttributeString(object instance, bool detectDefaultValue, GClass338 gclass338_0)
		{
			int num = 12;
			if (instance == null)
			{
				return;
			}
			if (gclass338_0 == null)
			{
				throw new ArgumentNullException("str");
			}
			PropertyInfo[] array = null;
			Type type = instance.GetType();
			if (_GetPropertiesAttributeString_Properties.ContainsKey(type))
			{
				array = _GetPropertiesAttributeString_Properties[type];
			}
			else
			{
				array = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				_GetPropertiesAttributeString_Properties[type] = array;
			}
			PropertyInfo[] array2 = array;
			foreach (PropertyInfo propertyInfo in array2)
			{
				if (!propertyInfo.CanWrite || !propertyInfo.CanWrite || XMLSerializeHelper.HasXmlIgnoreAttribute(propertyInfo))
				{
					continue;
				}
				ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
				if (indexParameters != null && indexParameters.Length > 0)
				{
					continue;
				}
				object value = propertyInfo.GetValue(instance, null);
				if (detectDefaultValue)
				{
					object propertyDefaultValue = GetPropertyDefaultValue(propertyInfo);
					if (propertyDefaultValue == value || object.Equals(propertyDefaultValue, value))
					{
						continue;
					}
				}
				if (value == null)
				{
					gclass338_0.method_2(propertyInfo.Name, null);
				}
				if (value is Color)
				{
					gclass338_0.method_2(propertyInfo.Name, ColorTranslator.ToHtml((Color)value));
				}
				else if (value is DateTime)
				{
					gclass338_0.method_2(propertyInfo.Name, FormatUtils.ToYYYY_MM_DD_HH_MM_SS((DateTime)value));
				}
				else
				{
					gclass338_0.method_2(propertyInfo.Name, value.ToString());
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       按照名称调用对象成员方法
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象实例</param>
		                                                                    /// <param name="methodName">方法名称，不区分大小写</param>
		                                                                    /// <param name="parameters">参数值数组</param>
		                                                                    /// <param name="throwException">是否抛出异常</param>
		                                                                    /// <returns>方法返回值</returns>
		public static object CallMethodByName(object instance, string methodName, object[] parameters, bool throwException)
		{
			int num = 16;
			if (instance == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("instance");
				}
				return null;
			}
			if (string.IsNullOrEmpty(methodName))
			{
				if (throwException)
				{
					throw new ArgumentNullException("methodName");
				}
				return null;
			}
			MethodInfo[] methods = instance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
			int num2 = 0;
			MethodInfo methodInfo;
			ParameterInfo[] parameters2;
			int num3;
			while (true)
			{
				if (num2 < methods.Length)
				{
					methodInfo = methods[num2];
					if (string.Compare(methodInfo.Name, methodName, ignoreCase: true) == 0)
					{
						parameters2 = methodInfo.GetParameters();
						num3 = ((parameters2 != null) ? parameters2.Length : 0);
						int num4 = (parameters != null) ? parameters.Length : 0;
						if (num3 == num4)
						{
							break;
						}
					}
					num2++;
					continue;
				}
				if (throwException)
				{
					throw new ArgumentException(instance.GetType().FullName + "." + methodName);
				}
				return null;
			}
			if (throwException)
			{
				object[] array = null;
				if (num3 > 0)
				{
					array = new object[num3];
					for (int i = 0; i < parameters.Length; i++)
					{
						if (parameters[i] != null)
						{
							if (parameters2[i].ParameterType.IsInstanceOfType(parameters[i]))
							{
								array[i] = parameters[i];
							}
							else
							{
								array[i] = ConvertTo(parameters[i], parameters2[i].ParameterType);
							}
						}
						else
						{
							array[i] = GetDefaultValue(parameters2[i].ParameterType);
						}
					}
				}
				return methodInfo.Invoke(instance, array);
			}
			try
			{
				object[] array = null;
				if (num3 > 0)
				{
					array = new object[num3];
					for (int i = 0; i < parameters.Length; i++)
					{
						if (parameters[i] != null)
						{
							if (parameters2[i].ParameterType.IsInstanceOfType(parameters[i]))
							{
								array[i] = parameters[i];
							}
							else
							{
								array[i] = ConvertTo(parameters[i], parameters2[i].ParameterType);
							}
						}
						else
						{
							array[i] = GetDefaultValue(parameters2[i].ParameterType);
						}
					}
				}
				return methodInfo.Invoke(instance, array);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}

		public static object GetPropertyValueMultiLayer(object instance, string propertyName, object defaultValue, bool throwExecption)
		{
			int num = 18;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			string[] array = propertyName.Split('.');
			object obj = instance;
			int num2 = 0;
			object value;
			while (true)
			{
				if (num2 < array.Length)
				{
					string text = array[num2].Trim();
					if (string.IsNullOrEmpty(text))
					{
						if (num2 == array.Length - 1)
						{
							return defaultValue;
						}
					}
					else
					{
						PropertyInfo property = obj.GetType().GetProperty(text, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
						if (property == null)
						{
							property = obj.GetType().GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
						}
						if (property == null)
						{
							if (throwExecption)
							{
								throw new Exception("未找到属性" + obj.GetType().FullName + "." + text);
							}
							return defaultValue;
						}
						value = property.GetValue(obj, null);
						if (value == null)
						{
							return defaultValue;
						}
						obj = value;
						if (num2 == array.Length - 1)
						{
							break;
						}
					}
					num2++;
					continue;
				}
				return defaultValue;
			}
			return value;
		}

		public static bool SetPropertyValueMultiLayer(object instance, string propertyName, object Value, bool throwExecption)
		{
			int num = 1;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			string[] array = propertyName.Split('.');
			object obj = instance;
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					string text = array[num2].Trim();
					if (!string.IsNullOrEmpty(text))
					{
						if (num2 == array.Length - 1)
						{
							return SetPropertyValue(obj, text, Value, throwExecption);
						}
						PropertyInfo property = obj.GetType().GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
						if (property == null && throwExecption)
						{
							throw new Exception("未找到属性" + obj.GetType().FullName + "." + text);
						}
						object value = property.GetValue(obj, null);
						if (value == null)
						{
							break;
						}
						obj = value;
					}
					num2++;
					continue;
				}
				return false;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       设置对象的属性值
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象实例</param>
		                                                                    /// <param name="propertyName">属性名称</param>
		                                                                    /// <param name="Value">属性值</param>
		                                                                    /// <param name="throwException">是否抛出异常</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool SetPropertyValue(object instance, string propertyName, object Value, bool throwException)
		{
			int num = 17;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			PropertyInfo property = instance.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				if (throwException)
				{
					throw new ArgumentException(instance.GetType().FullName + "." + propertyName);
				}
				return false;
			}
			object obj = Value;
			if (Value != null)
			{
				if (property.PropertyType.IsEnum && obj is string)
				{
					obj = Enum.Parse(property.PropertyType, (string)obj, ignoreCase: true);
				}
				else if (obj == null || DBNull.Value.Equals(obj))
				{
					obj = GetDefaultValue(property.PropertyType);
				}
				if (!property.PropertyType.IsInstanceOfType(obj))
				{
					TypeConverter typeConverter = null;
					TypeConverterAttribute typeConverterAttribute = (TypeConverterAttribute)Attribute.GetCustomAttribute(property, typeof(TypeConverterAttribute), inherit: true);
					if (typeConverterAttribute == null)
					{
						typeConverterAttribute = (TypeConverterAttribute)Attribute.GetCustomAttribute(property.PropertyType, typeof(TypeConverterAttribute), inherit: true);
					}
					if (typeConverterAttribute != null)
					{
						Type type = Type.GetType(typeConverterAttribute.ConverterTypeName);
						if (type != null)
						{
							typeConverter = (TypeConverter)Activator.CreateInstance(type);
						}
					}
					if (throwException)
					{
						obj = ((typeConverter == null) ? Convert.ChangeType(obj, property.PropertyType) : typeConverter.ConvertFrom(obj));
					}
					else
					{
						try
						{
							if (typeConverter != null)
							{
								obj = typeConverter.ConvertFrom(obj);
							}
							else
							{
								if (property.PropertyType.IsEnum)
								{
									obj = ((!(obj is string)) ? Enum.ToObject(property.PropertyType, obj) : Enum.Parse(property.PropertyType, (string)obj));
								}
								obj = Convert.ChangeType(obj, property.PropertyType);
							}
						}
						catch (Exception)
						{
							return false;
						}
					}
				}
			}
			if (throwException)
			{
				property.SetValue(instance, obj, null);
				return true;
			}
			try
			{
				property.SetValue(instance, obj, null);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       使用对象属性值来进行格式化输出
		                                                                    ///       </summary>
		                                                                    /// <param name="formatString">格式化字符串</param>
		                                                                    /// <param name="instance">对象</param>
		                                                                    /// <param name="throwException">是否抛出异常</param>
		                                                                    /// <returns>获得的字符串</returns>
		public static string FormStringWithPropertyValue(string formatString, object instance, bool throwException)
		{
			int num = 2;
			if (string.IsNullOrEmpty(formatString))
			{
				return formatString;
			}
			string[] array = VariableString.AnalyseVariableString(formatString, "{", "}");
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				string text = array[i];
				string text2 = null;
				int num2 = text.IndexOf(':');
				if (num2 > 0)
				{
					text2 = text.Substring(num2 + 1);
					text = text.Substring(0, num2);
				}
				object propertyValue = GetPropertyValue(instance, text, throwException);
				if (propertyValue != null)
				{
					if (!string.IsNullOrEmpty(text2) && propertyValue is IFormattable)
					{
						string value = ((IFormattable)propertyValue).ToString(text2, null);
						stringBuilder.Append(value);
					}
					else
					{
						stringBuilder.Append(Convert.ToString(propertyValue));
					}
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       获得对象属性值
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象实例</param>
		                                                                    /// <param name="propertyName">属性名</param>
		                                                                    /// <param name="throwException">是否抛出异常</param>
		                                                                    /// <returns>获得的属性值</returns>
		public static object GetPropertyValue(object instance, string propertyName, bool throwException)
		{
			int num = 0;
			if (instance == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("instance");
				}
				return null;
			}
			if (string.IsNullOrEmpty(propertyName))
			{
				if (throwException)
				{
					throw new ArgumentNullException("propertyName");
				}
				return null;
			}
			Type type = instance.GetType();
			Dictionary<string, PropertyInfo> dictionary = null;
			if (_GetPropertyValueInfos.ContainsKey(type))
			{
				dictionary = _GetPropertyValueInfos[type];
			}
			else
			{
				dictionary = new Dictionary<string, PropertyInfo>();
				_GetPropertyValueInfos[type] = dictionary;
			}
			PropertyInfo propertyInfo = null;
			if (dictionary.ContainsKey(propertyName))
			{
				propertyInfo = dictionary[propertyName];
			}
			else
			{
				dictionary[propertyName] = null;
				propertyInfo = instance.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
				if (propertyInfo == null)
				{
					if (throwException)
					{
						throw new Exception("未找到属性" + propertyName);
					}
					return null;
				}
				if (!propertyInfo.CanRead)
				{
					if (throwException)
					{
						throw new Exception("属性" + propertyName + "无法读取数据");
					}
					return null;
				}
				ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
				if (indexParameters != null && indexParameters.Length > 0)
				{
					if (throwException)
					{
						throw new Exception("属性" + propertyName + "不得有参数");
					}
					return null;
				}
				dictionary[propertyName] = propertyInfo;
			}
			if (propertyInfo == null)
			{
				if (throwException)
				{
					throw new Exception("没有合适的属性" + propertyName);
				}
				return null;
			}
			if (throwException)
			{
				return propertyInfo.GetValue(instance, null);
			}
			try
			{
				return propertyInfo.GetValue(instance, null);
			}
			catch
			{
				return null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       将对象转换为双精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="v">要转换的数据</param>
		                                                                    /// <param name="DefaultValue">默认值</param>
		                                                                    /// <returns>转换结果</returns>
		public static double ObjectToDouble(object object_0, double DefaultValue)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return DefaultValue;
			}
			if (object_0 is byte || object_0 is short || object_0 is int || object_0 is long || object_0 is decimal || object_0 is double)
			{
				return (double)object_0;
			}
			return StringToDouble(Convert.ToString(object_0), DefaultValue);
		}

		                                                                    /// <summary>
		                                                                    ///       将字符串转换为双精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="v">文本值</param>
		                                                                    /// <param name="DefaultValue">默认值</param>
		                                                                    /// <returns>转换结果</returns>
		public static double StringToDouble(string string_0, double DefaultValue)
		{
			if (string_0 == null)
			{
				return DefaultValue;
			}
			string_0 = string_0.Trim();
			if (string_0.Length == 0)
			{
				return DefaultValue;
			}
			double result = 0.0;
			if (double.TryParse(string_0, NumberStyles.Any, null, out result))
			{
				return result;
			}
			return DefaultValue;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定属性的默认值
		                                                                    ///       </summary>
		                                                                    /// <param name="p">属性对象</param>
		                                                                    /// <returns>默认值</returns>
		public static object GetPropertyDefaultValue(PropertyInfo propertyInfo_0)
		{
			int num = 16;
			if (propertyInfo_0 == null)
			{
				throw new ArgumentNullException("p");
			}
			if (_PropertyDefaultValues.ContainsKey(propertyInfo_0))
			{
				return _PropertyDefaultValues[propertyInfo_0];
			}
			object obj = null;
			DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(propertyInfo_0, typeof(DefaultValueAttribute), inherit: false);
			obj = ((defaultValueAttribute == null) ? GetDefaultValue(propertyInfo_0.PropertyType) : defaultValueAttribute.Value);
			_PropertyDefaultValues[propertyInfo_0] = obj;
			return obj;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定类型的默认值
		                                                                    ///       </summary>
		                                                                    /// <param name="ValueType">数据类型</param>
		                                                                    /// <returns>默认值</returns>
		public static object GetDefaultValue(Type ValueType)
		{
			int num = 8;
			if (_TypeDefaultValue == null)
			{
				_TypeDefaultValue = new Hashtable();
				_TypeDefaultValue[typeof(object)] = null;
				_TypeDefaultValue[typeof(byte)] = (byte)0;
				_TypeDefaultValue[typeof(sbyte)] = (sbyte)0;
				_TypeDefaultValue[typeof(short)] = (short)0;
				_TypeDefaultValue[typeof(ushort)] = (ushort)0;
				_TypeDefaultValue[typeof(int)] = 0;
				_TypeDefaultValue[typeof(uint)] = 0u;
				_TypeDefaultValue[typeof(long)] = 0L;
				_TypeDefaultValue[typeof(ulong)] = 0uL;
				_TypeDefaultValue[typeof(char)] = '\0';
				_TypeDefaultValue[typeof(float)] = 0f;
				_TypeDefaultValue[typeof(double)] = 0.0;
				_TypeDefaultValue[typeof(decimal)] = 0m;
				_TypeDefaultValue[typeof(bool)] = false;
				_TypeDefaultValue[typeof(string)] = null;
				_TypeDefaultValue[typeof(DateTime)] = DateTime.MinValue;
				_TypeDefaultValue[typeof(Point)] = Point.Empty;
				_TypeDefaultValue[typeof(PointF)] = PointF.Empty;
				_TypeDefaultValue[typeof(Size)] = Size.Empty;
				_TypeDefaultValue[typeof(SizeF)] = SizeF.Empty;
				_TypeDefaultValue[typeof(Rectangle)] = Rectangle.Empty;
				_TypeDefaultValue[typeof(RectangleF)] = RectangleF.Empty;
				_TypeDefaultValue[typeof(Color)] = Color.Transparent;
			}
			if (ValueType == null)
			{
				throw new ArgumentNullException("ValueType");
			}
			if (ValueType.IsEnum)
			{
				Array values = Enum.GetValues(ValueType);
				object value;
				if (values != null && values.Length > 0)
				{
					value = values.GetValue(0);
					_TypeDefaultValue[ValueType] = value;
					return value;
				}
				value = Activator.CreateInstance(ValueType);
				_TypeDefaultValue[ValueType] = value;
				return value;
			}
			if (_TypeDefaultValue.ContainsKey(ValueType))
			{
				return _TypeDefaultValue[ValueType];
			}
			if (ValueType.IsValueType)
			{
				object value = Activator.CreateInstance(ValueType);
				_TypeDefaultValue[ValueType] = value;
				return value;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       试图进行数据类型转换
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">数值</param>
		                                                                    /// <param name="NewType">新数据类型</param>
		                                                                    /// <param name="Result">转换结果</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryConvertTo(object Value, Type NewType, ref object Result)
		{
			int num = 11;
			if (NewType == null)
			{
				throw new ArgumentNullException("NewType");
			}
			if (Value == null || DBNull.Value.Equals(Value))
			{
				if (NewType.IsClass)
				{
					Result = null;
					return true;
				}
				return false;
			}
			Type type = Value.GetType();
			if (type.Equals(NewType) || type.IsSubclassOf(NewType))
			{
				Result = Value;
				return true;
			}
			try
			{
				bool flag = type.Equals(typeof(string));
				if (NewType.Equals(typeof(string)))
				{
					if (flag)
					{
						Result = (string)Value;
					}
					else
					{
						Result = Convert.ToString(Value);
					}
					return true;
				}
				if (NewType.Equals(typeof(bool)))
				{
					if (flag)
					{
						bool Result2 = false;
						if (TryParseBoolean((string)Value, out Result2))
						{
							Result = Result2;
							return true;
						}
						return false;
					}
					Result = Convert.ToBoolean(Value);
					return true;
				}
				if (NewType.Equals(typeof(char)))
				{
					if (flag)
					{
						char Result3 = '\0';
						if (TryParseChar((string)Value, out Result3))
						{
							Result = Result3;
							return true;
						}
						return false;
					}
					Result = Convert.ToChar(Value);
					return true;
				}
				if (NewType.Equals(typeof(byte)))
				{
					if (flag)
					{
						byte Result4 = 0;
						if (TryParseByte((string)Value, out Result4))
						{
							Result = Result4;
							return true;
						}
						return false;
					}
					Result = Convert.ToByte(Value);
					return true;
				}
				if (NewType.Equals(typeof(sbyte)))
				{
					if (flag)
					{
						sbyte Result5 = 0;
						if (TryParseSByte((string)Value, out Result5))
						{
							Result = Result5;
							return true;
						}
						return false;
					}
					Result = Convert.ToSByte(Value);
					return true;
				}
				if (NewType.Equals(typeof(short)))
				{
					if (flag)
					{
						short Result6 = 0;
						if (TryParseInt16((string)Value, out Result6))
						{
							Result = Result6;
							return true;
						}
						return false;
					}
					Result = Convert.ToInt16(Value);
					return true;
				}
				if (NewType.Equals(typeof(ushort)))
				{
					if (flag)
					{
						ushort Result7 = 0;
						if (TryParseUInt16((string)Value, out Result7))
						{
							Result = Result7;
							return true;
						}
						return false;
					}
					Result = Convert.ToUInt16(Value);
					return true;
				}
				if (NewType.Equals(typeof(int)))
				{
					if (flag)
					{
						int Result8 = 0;
						if (TryParseInt32((string)Value, out Result8))
						{
							Result = Result8;
							return true;
						}
						return false;
					}
					Result = Convert.ToInt32(Value);
					return true;
				}
				if (NewType.Equals(typeof(uint)))
				{
					if (flag)
					{
						uint Result9 = 0u;
						if (TryParseUInt32((string)Value, out Result9))
						{
							Result = Result9;
							return true;
						}
						return false;
					}
					Result = Convert.ToUInt32(Value);
					return true;
				}
				if (NewType.Equals(typeof(long)))
				{
					if (flag)
					{
						long Result10 = 0L;
						if (TryParseInt64((string)Value, out Result10))
						{
							Result = Result10;
							return true;
						}
						return false;
					}
					Result = Convert.ToInt64(Value);
					return true;
				}
				if (NewType.Equals(typeof(ulong)))
				{
					if (flag)
					{
						ulong Result11 = 0uL;
						if (TryParseUInt64((string)Value, out Result11))
						{
							Result = Result11;
							return true;
						}
						return false;
					}
					Result = Convert.ToUInt64(Value);
					return true;
				}
				if (NewType.Equals(typeof(float)))
				{
					if (flag)
					{
						float Result12 = 0f;
						if (TryParseSingle((string)Value, out Result12))
						{
							Result = Result12;
							return true;
						}
						return false;
					}
					Result = Convert.ToSingle(Value);
					return true;
				}
				if (NewType.Equals(typeof(double)))
				{
					if (flag)
					{
						double Result13 = 0.0;
						if (TryParseDouble((string)Value, out Result13))
						{
							Result = Result13;
							return true;
						}
						return false;
					}
					Result = Convert.ToDouble(Value);
					return true;
				}
				if (NewType.Equals(typeof(decimal)))
				{
					if (flag)
					{
						decimal Result14 = 0m;
						if (TryParseDecimal((string)Value, out Result14))
						{
							Result = Result14;
							return true;
						}
						return false;
					}
					Result = Convert.ToDecimal(Convert.ToSingle(Value));
					return true;
				}
				if (NewType.Equals(typeof(DateTime)))
				{
					if (flag)
					{
						DateTime Result15 = DateTime.MinValue;
						if (TryParseDateTime((string)Value, out Result15))
						{
							Result = Result15;
							return true;
						}
						return false;
					}
					Result = Convert.ToDateTime(Value);
					return true;
				}
				if (NewType.Equals(typeof(TimeSpan)))
				{
					if (flag)
					{
						TimeSpan Result16 = TimeSpan.Zero;
						if (TryParseTimeSpan((string)Value, out Result16))
						{
							Result = Result16;
							return true;
						}
						return false;
					}
					Result = new TimeSpan(Convert.ToInt64(Value));
					return true;
				}
				if (NewType.Equals(typeof(byte[])))
				{
					if (flag)
					{
						byte[] array = null;
						try
						{
							array = (byte[])(Result = Convert.FromBase64String((string)Value));
							return true;
						}
						catch
						{
							return false;
						}
					}
					return false;
				}
				if (NewType.IsEnum)
				{
					if (Enum.IsDefined(type, Value))
					{
						if (flag)
						{
							Result = Enum.Parse(NewType, (string)Value, ignoreCase: true);
						}
						else
						{
							Result = Enum.ToObject(NewType, Value);
						}
						return true;
					}
					return false;
				}
				TypeConverter converter = TypeDescriptor.GetConverter(NewType);
				if (converter != null)
				{
					if (converter.CanConvertFrom(Value.GetType()))
					{
						Result = converter.ConvertFrom(Value);
						return true;
					}
					return false;
				}
				if (Value is IConvertible)
				{
					Result = ((IConvertible)Value).ToType(NewType, null);
					return true;
				}
				Result = Convert.ChangeType(Value, NewType);
				return true;
			}
			catch
			{
				return false;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数据类型转换
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">要转换的数据</param>
		                                                                    /// <param name="NewType">新数据类型</param>
		                                                                    /// <param name="DefaultValue">默认值</param>
		                                                                    /// <returns>转换结果</returns>
		public static object ConvertTo(object Value, Type NewType, object DefaultValue)
		{
			int num = 11;
			if (NewType == null)
			{
				throw new ArgumentNullException("NewType");
			}
			if (Value == null || DBNull.Value.Equals(Value))
			{
				return DefaultValue;
			}
			Type type = Value.GetType();
			if (type.Equals(NewType) || type.IsSubclassOf(NewType))
			{
				return Value;
			}
			if (NewType.Equals(typeof(string)))
			{
				return Convert.ToString(Value);
			}
			if (NewType.Equals(typeof(bool)))
			{
				if (Value is string)
				{
					return bool.Parse((string)Value);
				}
				return Convert.ToBoolean(Value);
			}
			try
			{
				if (NewType.Equals(typeof(char)))
				{
					return Convert.ToChar(Value);
				}
				if (NewType.Equals(typeof(byte)))
				{
					return Convert.ToByte(Value);
				}
				if (NewType.Equals(typeof(sbyte)))
				{
					return Convert.ToSByte(Value);
				}
				if (NewType.Equals(typeof(short)))
				{
					return Convert.ToInt16(Value);
				}
				if (NewType.Equals(typeof(ushort)))
				{
					return Convert.ToUInt16(Value);
				}
				if (NewType.Equals(typeof(int)))
				{
					return Convert.ToInt32(Value);
				}
				if (NewType.Equals(typeof(uint)))
				{
					return Convert.ToUInt32(Value);
				}
				if (NewType.Equals(typeof(long)))
				{
					return Convert.ToInt64(Value);
				}
				if (NewType.Equals(typeof(ulong)))
				{
					return Convert.ToUInt64(Value);
				}
				if (NewType.Equals(typeof(float)))
				{
					return Convert.ToSingle(Value);
				}
				if (NewType.Equals(typeof(double)))
				{
					return Convert.ToDouble(Value);
				}
				if (NewType.Equals(typeof(decimal)))
				{
					decimal num2 = Convert.ToDecimal(Convert.ToSingle(Value));
					return num2;
				}
				if (NewType.Equals(typeof(DateTime)))
				{
					DateTime minValue = DateTime.MinValue;
					minValue = ((!type.Equals(typeof(string))) ? Convert.ToDateTime(Value) : DateTime.Parse((string)Value));
					return minValue;
				}
				if (NewType.Equals(typeof(TimeSpan)))
				{
					TimeSpan zero = TimeSpan.Zero;
					zero = ((!type.Equals(typeof(string))) ? TimeSpan.Parse(Convert.ToString(Value)) : TimeSpan.Parse((string)Value));
					return zero;
				}
				if (NewType.Equals(typeof(byte[])))
				{
					if (type.Equals(typeof(string)))
					{
						return Convert.FromBase64String((string)Value);
					}
					return null;
				}
				if (NewType.IsEnum)
				{
					if (Value is string)
					{
						return Enum.Parse(NewType, (string)Value);
					}
					return Enum.ToObject(NewType, Value);
				}
				TypeConverter converter = TypeDescriptor.GetConverter(NewType);
				if (converter != null)
				{
					if (converter.CanConvertFrom(Value.GetType()))
					{
						return converter.ConvertFrom(Value);
					}
					return DefaultValue;
				}
				if (Value is IConvertible)
				{
					return ((IConvertible)Value).ToType(NewType, null);
				}
				return Convert.ChangeType(Value, NewType);
			}
			catch
			{
				return DefaultValue;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数据类型转换
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">旧数据</param>
		                                                                    /// <param name="NewType">新数据类型</param>
		                                                                    /// <returns>转换结果</returns>
		public static object ConvertTo(object Value, Type NewType)
		{
			int num = 19;
			if (NewType == null)
			{
				throw new ArgumentNullException("NewType");
			}
			if (NewType.IsInstanceOfType(Value))
			{
				return Value;
			}
			bool flag = false;
			if (Value is string)
			{
				string text = (string)Value;
				if (text == null || text.Trim().Length == 0)
				{
					flag = true;
				}
			}
			if (Value == null || DBNull.Value.Equals(Value))
			{
				if (NewType.IsClass)
				{
					return null;
				}
				return GetDefaultValue(NewType);
			}
			Type type = Value.GetType();
			if (type.Equals(NewType) || type.IsSubclassOf(NewType))
			{
				return Value;
			}
			if (NewType.Equals(typeof(string)))
			{
				if (Value is double && double.IsNaN((double)Value))
				{
					return null;
				}
				if (Value is float && float.IsNaN((float)Value))
				{
					return null;
				}
				return Convert.ToString(Value);
			}
			if (NewType.Equals(typeof(bool)))
			{
				if (Value is string)
				{
					if (flag)
					{
						return false;
					}
					return bool.Parse((string)Value);
				}
				if (flag)
				{
					return false;
				}
				return Convert.ToBoolean(Value);
			}
			if (NewType.Equals(typeof(char)))
			{
				return Convert.ToChar(Value);
			}
			if (NewType.Equals(typeof(byte)))
			{
				if (flag)
				{
					return (byte)0;
				}
				return Convert.ToByte(Value);
			}
			if (NewType.Equals(typeof(sbyte)))
			{
				if (flag)
				{
					return (sbyte)0;
				}
				return Convert.ToSByte(Value);
			}
			if (NewType.Equals(typeof(short)))
			{
				if (flag)
				{
					return (short)0;
				}
				return Convert.ToInt16(Value);
			}
			if (NewType.Equals(typeof(ushort)))
			{
				if (flag)
				{
					return (ushort)0;
				}
				return Convert.ToUInt16(Value);
			}
			if (NewType.Equals(typeof(int)))
			{
				if (flag)
				{
					return 0;
				}
				return Convert.ToInt32(Value);
			}
			if (NewType.Equals(typeof(uint)))
			{
				if (flag)
				{
					return 0u;
				}
				return Convert.ToUInt32(Value);
			}
			if (NewType.Equals(typeof(long)))
			{
				if (flag)
				{
					return 0L;
				}
				return Convert.ToInt64(Value);
			}
			if (NewType.Equals(typeof(ulong)))
			{
				if (flag)
				{
					return 0uL;
				}
				return Convert.ToUInt64(Value);
			}
			if (NewType.Equals(typeof(float)))
			{
				if (flag)
				{
					return 0f;
				}
				return Convert.ToSingle(Value);
			}
			if (NewType.Equals(typeof(double)))
			{
				if (flag)
				{
					return 0.0;
				}
				return Convert.ToDouble(Value);
			}
			if (NewType.Equals(typeof(decimal)))
			{
				if (flag)
				{
					return 0m;
				}
				decimal num2 = Convert.ToDecimal(Convert.ToSingle(Value));
				return num2;
			}
			if (NewType.Equals(typeof(DateTime)))
			{
				if (flag)
				{
					return DateTime.MinValue;
				}
				DateTime minValue = DateTime.MinValue;
				minValue = ((!type.Equals(typeof(string))) ? Convert.ToDateTime(Value) : DateTime.Parse((string)Value));
				return minValue;
			}
			if (NewType.Equals(typeof(TimeSpan)))
			{
				if (flag)
				{
					return TimeSpan.Zero;
				}
				TimeSpan zero = TimeSpan.Zero;
				zero = ((!type.Equals(typeof(string))) ? TimeSpan.Parse(Convert.ToString(Value)) : TimeSpan.Parse((string)Value));
				return zero;
			}
			if (NewType.IsEnum)
			{
				if (Value is string)
				{
					return Enum.Parse(NewType, (string)Value, ignoreCase: true);
				}
				return Enum.ToObject(NewType, Convert.ToInt32(Value));
			}
			TypeConverter converter = TypeDescriptor.GetConverter(NewType);
			if (converter != null)
			{
				if (converter.CanConvertFrom(Value.GetType()))
				{
					return converter.ConvertFrom(Value);
				}
				throw new ArgumentException("Value");
			}
			if (Value is IConvertible)
			{
				return ((IConvertible)Value).ToType(NewType, null);
			}
			return Convert.ChangeType(Value, NewType);
		}

		                                                                    /// <summary>
		                                                                    ///       将字符串值转换为枚举值，若转换失败则返回默认值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="DefaultValue">默认值</param>
		                                                                    /// <returns>转换的枚举值</returns>
		public static Enum ParseEnum(string Value, Enum DefaultValue)
		{
			string[] names = Enum.GetNames(DefaultValue.GetType());
			string[] array = names;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					string strA = array[num];
					if (string.Compare(strA, Value, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return DefaultValue;
			}
			return (Enum)Enum.Parse(DefaultValue.GetType(), Value);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串值解释成时间长度值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得时间长度值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseTimeSpan(string Value, out TimeSpan Result)
		{
			return TimeSpan.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串值解释成日期数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的日期数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseDateTime(string Value, out DateTime Result)
		{
			Result = DateTime.MinValue;
			if (Value == null || Value.Trim().Length == 0)
			{
				return false;
			}
			Value = Value.Trim();
			return DateTime.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串值解释成日期数值,其中支持全数字的字符串，例如20100302123543
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的日期数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseDateTimeExt(string Value, out DateTime Result)
		{
			int num = 16;
			Result = DateTime.MinValue;
			if (Value == null || Value.Trim().Length == 0)
			{
				return false;
			}
			Value = Value.Trim();
			bool flag = true;
			string text = Value;
			foreach (char value in text)
			{
				if ("0123456789".IndexOf(value) < 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				if (Value.Length < 4)
				{
					return false;
				}
				int num2 = 1;
				int num3 = 1;
				int num4 = 1;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				num2 = Convert.ToInt32(Value.Substring(0, 4));
				if (Value.Length >= 6)
				{
					num3 = Convert.ToInt32(Value.Substring(4, 2));
					if (num3 <= 0 || num3 > 12)
					{
						return false;
					}
				}
				if (Value.Length >= 8)
				{
					num4 = Convert.ToInt32(Value.Substring(6, 2));
					if (num4 <= 0 || num4 > DateTime.DaysInMonth(num2, num3))
					{
						return false;
					}
				}
				if (Value.Length >= 10)
				{
					num5 = Convert.ToInt32(Value.Substring(8, 2));
					if (num5 > 24)
					{
						return false;
					}
				}
				if (Value.Length >= 12)
				{
					num6 = Convert.ToInt32(Value.Substring(10, 2));
					if (num6 > 60)
					{
						return false;
					}
				}
				if (Value.Length >= 14)
				{
					num7 = Convert.ToInt32(Value.Substring(12, 2));
					if (num7 > 60)
					{
						return false;
					}
				}
				Result = new DateTime(num2, num3, num4, num5, num6, num7);
				return true;
			}
			return TryParseDateTime(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串值解释成双精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的双精度浮点数</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseDecimal(string Value, out decimal Result)
		{
			return decimal.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       将字符串值解释成双精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的双精度浮点数</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseDouble(string Value, out double Result)
		{
			return double.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成单精度浮点数
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的单精度浮点数</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseSingle(string Value, out float Result)
		{
			return float.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成字符值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的字符值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseChar(string Value, out char Result)
		{
			Result = '\0';
			if (Value != null && Value.Length == 1)
			{
				Result = Value[0];
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成64位无符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的64位无符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseUInt64(string Value, out ulong Result)
		{
			return ulong.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成64位有符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的64位有符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseInt64(string Value, out long Result)
		{
			return long.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成32位无符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的32位无符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseUInt32(string Value, out uint Result)
		{
			return uint.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成32位有符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的32位有符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseInt32(string Value, out int Result)
		{
			return int.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成16位无符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的16位无符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseUInt16(string Value, out ushort Result)
		{
			return ushort.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成16位有符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的16位有符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseInt16(string Value, out short Result)
		{
			return short.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成单字节无符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的单字节无符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseByte(string Value, out byte Result)
		{
			return byte.TryParse(Value, out Result);
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成单字节有符号整数值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得的单字节有符号整数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseSByte(string Value, out sbyte Result)
		{
			return sbyte.TryParse(Value, out Result);
		}

		private static bool CheckChars(string Value, string chars)
		{
			if (Value != null && Value.Length > 0)
			{
				foreach (char value in Value)
				{
					if (chars.IndexOf(value) < 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       试图将字符串解释成布尔类型值
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">字符串值</param>
		                                                                    /// <param name="Result">获得布尔类型值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool TryParseBoolean(string Value, out bool Result)
		{
			int num = 3;
			Result = false;
			if (Value != null)
			{
				Value = Value.Trim();
				if (Value == "0")
				{
					Result = false;
					return true;
				}
				if (Value == "1")
				{
					Result = true;
					return true;
				}
				if (string.Compare("True", Value, ignoreCase: true) == 0)
				{
					Result = true;
					return true;
				}
				if (string.Compare("False", Value, ignoreCase: true) == 0)
				{
					Result = false;
					return true;
				}
			}
			return false;
		}

		private ValueTypeHelper()
		{
		}
	}
}

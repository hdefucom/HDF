using DCSoft.Common;
using DCSoft.Data.WinForms.Design;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       数据格式化对象
	                                                                    ///       </summary>
	[Serializable]
	[Editor(typeof(ValueFormaterUIEditor), typeof(UITypeEditor))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	[Guid("7BF23387-A98E-4713-9FE2-76B91A1F51A6")]
	[ComDefaultInterface(typeof(IValueFormater))]
	[TypeConverter(typeof(GClass319))]
	public class ValueFormater : ICloneable, IDCStringSerializable, IValueFormater
	{
		private ValueFormatStyle valueFormatStyle_0 = ValueFormatStyle.None;

		private string string_0 = null;

		private string string_1 = null;

		                                                                    /// <summary>
		                                                                    ///       数据源格式化样式
		                                                                    ///       </summary>
		[DefaultValue(ValueFormatStyle.None)]
		public ValueFormatStyle Style
		{
			get
			{
				return valueFormatStyle_0;
			}
			set
			{
				valueFormatStyle_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       格式化字符串
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Format
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对于非数字显示的文本
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string NoneText
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象没有任何有效设置
		                                                                    ///       </summary>
		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (valueFormatStyle_0 == ValueFormatStyle.None)
				{
					return true;
				}
				if (string_0 != null && string_0.Length > 0)
				{
					return false;
				}
				if (string_1 != null && string_1.Length > 0)
				{
					return false;
				}
				return true;
			}
		}

		[DCInternal]
		public static ValueFormater smethod_0(string string_2)
		{
			int num = 1;
			ValueFormater valueFormater = new ValueFormater();
			if (string_2 == null)
			{
				return new ValueFormater();
			}
			int num2 = string_2.IndexOf(":");
			if (num2 > 0)
			{
				string value = string_2.Substring(0, num2).Trim();
				try
				{
					valueFormater.Style = (ValueFormatStyle)Enum.Parse(typeof(ValueFormatStyle), value);
				}
				finally
				{
				}
				if (valueFormater.Style != 0)
				{
					valueFormater.Format = string_2.Substring(num2 + 1).Trim();
					if (valueFormater.Format == "chinese")
					{
						valueFormater.Format = "BigChinese";
					}
				}
			}
			else
			{
				valueFormater.Style = (ValueFormatStyle)Enum.Parse(typeof(ValueFormatStyle), string_2);
			}
			return valueFormater;
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public ValueFormater()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="style">类型</param>
		                                                                    /// <param name="format">格式</param>
		public ValueFormater(ValueFormatStyle valueFormatStyle_1, string string_2)
		{
			valueFormatStyle_0 = valueFormatStyle_1;
			string_0 = string_2;
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="style">类型</param>
		                                                                    /// <param name="format">格式</param>
		                                                                    /// <param name="naNText">数据空时的文本</param>
		public ValueFormater(ValueFormatStyle valueFormatStyle_1, string string_2, string string_3)
		{
			valueFormatStyle_0 = valueFormatStyle_1;
			string_0 = string_2;
			string_1 = NoneText;
		}

		[DCInternal]
		public void method_0(string string_2)
		{
			int num = 8;
			valueFormatStyle_0 = ValueFormatStyle.None;
			string_0 = null;
			string_1 = null;
			if (!smethod_1(string_2))
			{
				return;
			}
			string[] array = string_2.Split(',');
			if (array.Length <= 0)
			{
				return;
			}
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array[0].Trim();
				int num2 = text.IndexOf("=");
				if (num2 >= 0)
				{
					string strA = text.Substring(0, num2).Trim();
					text = text.Substring(num2 + 1).Trim();
					if (string.Compare(strA, "format", ignoreCase: true) == 0)
					{
						string_0 = text;
					}
					else if (string.Compare(strA, "nonetext", ignoreCase: true) == 0)
					{
						string_1 = text;
					}
					continue;
				}
				bool flag = false;
				string[] names = Enum.GetNames(typeof(ValueFormatStyle));
				foreach (string strA in names)
				{
					if (string.Compare(strA, text, ignoreCase: true) == 0)
					{
						valueFormatStyle_0 = (ValueFormatStyle)Enum.Parse(typeof(ValueFormatStyle), strA);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					string_0 = text;
				}
			}
		}

		object ICloneable.Clone()
		{
			return (ValueFormater)MemberwiseClone();
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public ValueFormater Clone()
		{
			return (ValueFormater)((ICloneable)this).Clone();
		}

		public override string ToString()
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(valueFormatStyle_0.ToString());
			if (valueFormatStyle_0 != 0)
			{
				if (smethod_1(string_0))
				{
					stringBuilder.Append("," + string_0);
				}
				if (smethod_1(string_1))
				{
					stringBuilder.Append(",NoneText=" + string_1);
				}
			}
			return stringBuilder.ToString();
		}

		internal static bool smethod_1(string string_2)
		{
			return string_2 != null && string_2.Trim().Length > 0;
		}

		                                                                    /// <summary>
		                                                                    ///       执行数据格式转换,生成转换后的文本
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">原始数据</param>
		                                                                    /// <returns>格式化后生成的文本</returns>
		public string Execute(object Value)
		{
			if (valueFormatStyle_0 == ValueFormatStyle.None)
			{
				if (Value == null || DBNull.Value.Equals(Value))
				{
					return null;
				}
				return Convert.ToString(Value);
			}
			return Execute(Style, Format, NoneText, Value);
		}

		private static bool smethod_2(object object_0)
		{
			return object_0 is byte || object_0 is sbyte || object_0 is short || object_0 is ushort || object_0 is int || object_0 is uint || object_0 is long || object_0 is ulong || object_0 is float || object_0 is double || object_0 is decimal;
		}

		[DCInternal]
		public static string Execute(ValueFormatStyle style, string format, string noneText, object Value)
		{
			int num = 6;
			if (Value == null || DBNull.Value.Equals(Value))
			{
				return noneText;
			}
			if (format == null)
			{
				format = "";
			}
			switch (style)
			{
			default:
				return Convert.ToString(Value);
			case ValueFormatStyle.None:
				return Convert.ToString(Value);
			case ValueFormatStyle.Numeric:
			{
				double result = 0.0;
				bool flag = false;
				if (Value is string)
				{
					string text = (string)Value;
					if (smethod_1(text))
					{
						flag = double.TryParse(text, out result);
					}
				}
				else if (smethod_2(Value))
				{
					result = Convert.ToDouble(Value);
					flag = true;
				}
				else
				{
					try
					{
						result = Convert.ToDouble(Value);
						flag = true;
					}
					catch
					{
					}
				}
				if (flag && !double.IsNaN(result))
				{
					if (smethod_1(format))
					{
						return result.ToString(format);
					}
					return result.ToString();
				}
				return noneText;
			}
			case ValueFormatStyle.Currency:
			{
				decimal result8 = 0m;
				bool flag2 = false;
				if (Value is string)
				{
					string text = (string)Value;
					if (smethod_1(text))
					{
						try
						{
							flag2 = decimal.TryParse(text, out result8);
						}
						catch
						{
						}
					}
				}
				else if (smethod_2(Value) || Value is bool)
				{
					result8 = Convert.ToDecimal(Value);
					flag2 = true;
				}
				if (flag2)
				{
					if (smethod_1(format))
					{
						return result8.ToString(format);
					}
					return result8.ToString();
				}
				return noneText;
			}
			case ValueFormatStyle.DateTime:
			{
				DateTime result7 = DateTime.MinValue;
				bool flag2 = false;
				if (Value is DateTime)
				{
					result7 = (DateTime)Value;
					flag2 = true;
				}
				else if (Value is string)
				{
					string text = (string)Value;
					if (smethod_1(text) && !(flag2 = DateTime.TryParse(text, out result7)))
					{
						flag2 = DateTime.TryParseExact(text, format, null, DateTimeStyles.AllowWhiteSpaces, out result7);
					}
				}
				else if (smethod_2(Value))
				{
					result7 = new DateTime(Convert.ToInt64(Value));
					flag2 = true;
				}
				else
				{
					result7 = Convert.ToDateTime(Value);
					flag2 = true;
				}
				if (flag2)
				{
					if (smethod_1(format))
					{
						string text = result7.ToString(format);
						if (text.IndexOf("星期") >= 0)
						{
							string newValue = "";
							switch (result7.DayOfWeek)
							{
							case DayOfWeek.Sunday:
								newValue = "星期天";
								break;
							case DayOfWeek.Monday:
								newValue = "星期一";
								break;
							case DayOfWeek.Tuesday:
								newValue = "星期二";
								break;
							case DayOfWeek.Wednesday:
								newValue = "星期三";
								break;
							case DayOfWeek.Thursday:
								newValue = "星期四";
								break;
							case DayOfWeek.Friday:
								newValue = "星期五";
								break;
							case DayOfWeek.Saturday:
								newValue = "星期六";
								break;
							}
							text = text.Replace("星期", newValue);
						}
						return text;
					}
					return result7.ToLongDateString();
				}
				return noneText;
			}
			case ValueFormatStyle.String:
			{
				string text = Convert.ToString(Value);
				if (!smethod_1(text))
				{
					return text;
				}
				if (!smethod_1(format))
				{
					return text;
				}
				format = format.Trim();
				if (string.Compare(format, "trim", ignoreCase: true) == 0)
				{
					return text.Trim();
				}
				if (string.Compare(format, "HtmlEncode", ignoreCase: true) == 0)
				{
					return HttpUtility.HtmlEncode(text);
				}
				if (string.Compare(format, "HtmlDecode", ignoreCase: true) == 0)
				{
					return HttpUtility.HtmlDecode(text);
				}
				if (string.Compare(format, "UrlEncode", ignoreCase: true) == 0)
				{
					return HttpUtility.UrlEncode(text);
				}
				if (string.Compare(format, "UrlDecode", ignoreCase: true) == 0)
				{
					return HttpUtility.UrlDecode(text);
				}
				if (string.Compare(format, "HtmlAttributeEncode", ignoreCase: true) == 0)
				{
					return HttpUtility.HtmlAttributeEncode(text);
				}
				if (string.Compare(format, "lower", ignoreCase: true) == 0)
				{
					return text.ToLower();
				}
				if (string.Compare(format, "upper", ignoreCase: true) == 0)
				{
					return text.ToUpper();
				}
				format = format.ToLower();
				if (format.StartsWith("left"))
				{
					int num3 = format.IndexOf(",");
					if (num3 > 0)
					{
						string s = format.Substring(num3 + 1);
						int num4 = 0;
						if (int.TryParse(s, out num4) && num4 > 0 && text.Length > num4)
						{
							return text.Substring(0, num4);
						}
					}
					return text;
				}
				if (format.StartsWith("right"))
				{
					int num3 = format.IndexOf(",");
					if (num3 > 0)
					{
						string s2 = format.Substring(num3 + 1);
						int num4 = 0;
						if (int.TryParse(s2, out num4) && num4 > 0 && text.Length > num4)
						{
							return text.Substring(text.Length - num4 - 1, num4);
						}
					}
					return text;
				}
				return text;
			}
			case ValueFormatStyle.SpecifyLength:
			{
				int result6 = 0;
				string text = Convert.ToString(Value);
				if (int.TryParse(format, out result6) && result6 > 0)
				{
					int num4 = 0;
					string text2 = text;
					foreach (char c in text2)
					{
						num4 = ((c <= 'ÿ') ? (num4 + 1) : (num4 + 2));
					}
					if (num4 < result6)
					{
						return string.Concat(Value, new string(' ', result6 - num4));
					}
				}
				return text;
			}
			case ValueFormatStyle.Boolean:
			{
				if (format == null)
				{
					return Convert.ToString(Value);
				}
				int num3 = format.IndexOf(",");
				string result3 = format;
				string result4 = "";
				if (num3 >= 0)
				{
					result3 = format.Substring(0, num3);
					result4 = format.Substring(num3 + 1);
				}
				bool result5 = false;
				bool flag = false;
				if (Value is bool)
				{
					result5 = (bool)Value;
					flag = true;
				}
				else if (Value is string)
				{
					flag = bool.TryParse((string)Value, out result5);
				}
				else
				{
					try
					{
						result5 = Convert.ToBoolean(Value);
						flag = true;
					}
					catch
					{
						return noneText;
					}
				}
				if (result5)
				{
					return result3;
				}
				return result4;
			}
			case ValueFormatStyle.Percent:
			{
				double result = 0.0;
				int result2 = 0;
				int num2 = 100;
				if (Value is string)
				{
					string text = (string)Value;
					if (!smethod_1(text))
					{
						return noneText;
					}
					if (text.IndexOf("%") > 0)
					{
						num2 = 1;
						text = text.Replace("%", "");
					}
					if (!double.TryParse(text, out result))
					{
						result = double.NaN;
					}
				}
				else if (smethod_2(Value))
				{
					result = Convert.ToDouble(Value);
				}
				else
				{
					try
					{
						result = Convert.ToDouble(Value);
					}
					catch
					{
						return noneText;
					}
				}
				if (!int.TryParse(format, out result2))
				{
					result2 = 0;
				}
				if (result2 < 0)
				{
					result2 = 0;
				}
				if (!double.IsNaN(result))
				{
					result = Math.Round(result * (double)num2, result2);
					if (result2 == 0)
					{
						return result + "%";
					}
					return result.ToString("0." + new string('0', result2)) + "%";
				}
				return noneText;
			}
			}
		}

		[DCInternal]
		public string DCWriteString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		[DCInternal]
		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}
	}
}

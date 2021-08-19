using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       文本验证样式对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[Serializable]
	[Editor("DCSoft.Common.ValueValidateStyleEditor", typeof(UITypeEditor))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IValueValidateStyle))]
	[DCPublishAPI]
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-234567890091")]
	public class ValueValidateStyle : ICloneable, IDCStringSerializable, IValueValidateStyle
	{
		private ValueValidateLevel valueValidateLevel_0 = ValueValidateLevel.Error;

		private string string_0 = null;

		private object object_0 = null;

		private bool bool_0 = false;

		private ValueTypeStyle valueTypeStyle_0 = ValueTypeStyle.Text;

		private bool bool_1 = false;

		private int int_0 = 0;

		private int int_1 = 0;

		private bool bool_2 = false;

		private bool bool_3 = false;

		private double double_0 = 0.0;

		private double double_1 = 0.0;

		private bool bool_4 = false;

		private int int_2 = 0;

		                                                                    /// <summary>
		                                                                    ///       表示为空的日期数值
		                                                                    ///       </summary>
		public static readonly DateTime NullDateTime = new DateTime(1980, 1, 1, 0, 0, 0);

		private DateTime dateTime_0 = NullDateTime;

		private DateTime dateTime_1 = NullDateTime;

		private string string_1 = null;

		private string string_2 = null;

		private string string_3 = null;

		private string string_4 = null;

		private string string_5 = null;

		private int int_3 = -1;

		private string string_6 = null;

		private bool bool_5 = false;

		private static Encoding encoding_0 = Encoding.Default;

		                                                                    /// <summary>
		                                                                    ///       校验等级
		                                                                    ///       </summary>
		[DefaultValue(ValueValidateLevel.Error)]
		public ValueValidateLevel Level
		{
			get
			{
				return valueValidateLevel_0;
			}
			set
			{
				valueValidateLevel_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数据的名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[Category("Design")]
		public string ValueName
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
		                                                                    ///       数值
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[DCInternal]
		[Browsable(false)]
		[XmlIgnore]
		public object Value
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       必填数据
		                                                                    ///       </summary>
		[DefaultValue(false)]
		[Category("Format")]
		public bool Required
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数值类型
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(ValueTypeStyle.Text)]
		public ValueTypeStyle ValueType
		{
			get
			{
				return valueTypeStyle_0;
			}
			set
			{
				valueTypeStyle_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       进行的是二进制长度判断
		                                                                    ///       </summary>
		[DefaultValue(false)]
		public bool BinaryLength
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       最大文本长度
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(0)]
		public int MaxLength
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       最小文本长度
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(0)]
		public int MinLength
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       检查数值或者日期值的最大值
		                                                                    ///       </summary>
		[DefaultValue(false)]
		[Category("Format")]
		public bool CheckMaxValue
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       检查数值或者日期值的最小值
		                                                                    ///       </summary>
		[DefaultValue(false)]
		[Category("Format")]
		public bool CheckMinValue
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数值最大值
		                                                                    ///       </summary>
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(0.0)]
		[Category("Format")]
		public double MaxValue
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数值最小值
		                                                                    ///       </summary>
		[Category("Format")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(0.0)]
		public double MinValue
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否需要判断小数位数
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(false)]
		public bool CheckDecimalDigits
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       小数最大位数
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(0)]
		[RefreshProperties(RefreshProperties.All)]
		public int MaxDecimalDigits
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       最大时间日期值
		                                                                    ///       </summary>
		[XmlElement]
		[Category("Format")]
		[RefreshProperties(RefreshProperties.All)]
		public DateTime DateTimeMaxValue
		{
			get
			{
				return dateTime_0;
			}
			set
			{
				dateTime_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       最小时间日期值
		                                                                    ///       </summary>
		[XmlElement]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Format")]
		public DateTime DateTimeMinValue
		{
			get
			{
				return dateTime_1;
			}
			set
			{
				dateTime_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       数据取值范围
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(null)]
		public string Range
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
		                                                                    ///       正则表达式文字
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string RegExpression
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       允许包含的关键字，各个关键字之间用英文逗号分开。
		                                                                    ///       </summary>
		                                                                    /// <remarks>
		                                                                    ///       如果内容为某个允许包含的关键字，则无需做其他验证项而验证通过。
		                                                                    ///       </remarks>
		[DefaultValue(null)]
		public string IncludeKeywords
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       排除关键字
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string ExcludeKeywords
		{
			get
			{
				return string_4;
			}
			set
			{
				string_4 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       自定义提示信息
		                                                                    ///       </summary>
		[Category("Format")]
		[DefaultValue(null)]
		public string CustomMessage
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       进行数据校验时的相关的内容版本号
		                                                                    ///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public int ContentVersion
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象没有任何有效设置
		                                                                    ///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (bool_0)
				{
					return false;
				}
				if (valueTypeStyle_0 == ValueTypeStyle.Text)
				{
					if (CheckMaxValue || CheckMinValue)
					{
						return false;
					}
					if (ValueType == ValueTypeStyle.RegExpress && !string.IsNullOrEmpty(RegExpression))
					{
						return false;
					}
					if (string_1 != null && string_1.Trim().Length > 0)
					{
						return false;
					}
					if (string_0 != null && string_0.Trim().Length > 0)
					{
						return false;
					}
					if (string_5 != null && string_5.Trim().Length > 0)
					{
						return false;
					}
					if (string_4 != null && string_4.Trim().Length > 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       验证结果
		                                                                    ///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public string Message
		{
			get
			{
				return string_6;
			}
			set
			{
				string_6 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       由于必填项而导致的数据校验无效的标记
		                                                                    ///       </summary>
		public bool RequiredInvalidateFlag => bool_5;

		                                                                    /// <summary>
		                                                                    ///       为获得字节数使用的文本编码格式对象
		                                                                    ///       </summary>
		public static Encoding EncodingForGetBytes
		{
			get
			{
				if (encoding_0 == null)
				{
					encoding_0 = Encoding.Default;
				}
				return encoding_0;
			}
			set
			{
				encoding_0 = value;
			}
		}

		private int method_0(string string_7)
		{
			if (string.IsNullOrEmpty(string_7))
			{
				return 0;
			}
			if (BinaryLength)
			{
				return EncodingForGetBytes.GetByteCount(string_7);
			}
			return string_7.Length;
		}

		public bool method_1()
		{
			int num = 8;
			bool_5 = false;
			string_6 = null;
			string text = CustomMessage;
			if (text == null || text.Trim().Length == 0)
			{
				text = null;
			}
			bool flag = false;
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				flag = true;
			}
			else
			{
				string value = Convert.ToString(object_0);
				if (string.IsNullOrEmpty(value))
				{
					flag = true;
				}
			}
			if (Required)
			{
				if (flag)
				{
					string_6 = ((text != null) ? text : ValueValidateStyleStrings.ForbidEmpty);
					bool_5 = true;
					return false;
				}
			}
			else if (flag)
			{
				return true;
			}
			if (!flag && !string.IsNullOrEmpty(IncludeKeywords))
			{
				string[] array = IncludeKeywords.Split(',');
				string value = Convert.ToString(object_0);
				string[] array2 = array;
				foreach (string a in array2)
				{
					if (a == value)
					{
						return true;
					}
				}
			}
			switch (ValueType)
			{
			case ValueTypeStyle.Text:
			{
				string value = Convert.ToString(object_0);
				if (CheckMaxValue && MaxLength > 0 && value != null && method_0(value) > MaxLength)
				{
					string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MoreThanMaxLength_Length, int_0));
					return false;
				}
				if (CheckMinValue && MinLength > 0 && value != null && method_0(value) < MinLength)
				{
					string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.LessThanMinLength_Length, int_1));
					return false;
				}
				if (string_1 == null || string_1.Length <= 0)
				{
					break;
				}
				bool flag2 = true;
				string[] array = string_1.Split(',');
				string[] array2 = array;
				foreach (string a in array2)
				{
					flag2 = false;
					if (string.Compare(value, a.Trim(), ignoreCase: true) == 0)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.ExcludeRange_Range, string_1));
					return false;
				}
				break;
			}
			case ValueTypeStyle.Integer:
			case ValueTypeStyle.Numeric:
			{
				double result = double.NaN;
				if (object_0 is int || object_0 is float || object_0 is double)
				{
					result = (double)object_0;
				}
				else if (valueTypeStyle_0 == ValueTypeStyle.Numeric)
				{
					if (!double.TryParse(Convert.ToString(object_0), out result))
					{
						string_6 = ((text != null) ? text : ValueValidateStyleStrings.MustNumeric);
						return false;
					}
				}
				else
				{
					int Result = int.MinValue;
					if (!ValueTypeHelper.TryParseInt32(Convert.ToString(object_0), out Result))
					{
						string_6 = ((text != null) ? text : ValueValidateStyleStrings.MustInteger);
						return false;
					}
					result = Result;
				}
				if (double_0 != double_1)
				{
					if (CheckMaxValue && !double.IsNaN(double_0) && result > double_0)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MoreThanMaxValue_Value, double_0));
						return false;
					}
					if (CheckMinValue && !double.IsNaN(double_1) && result < double_1)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.LessThanMinValue_Value, double_1));
						return false;
					}
				}
				if (CheckDecimalDigits)
				{
					string text2 = Convert.ToString(object_0);
					if (text2.Contains("."))
					{
						int num2 = text2.Length - text2.IndexOf('.') - 1;
						if (num2 > int_2)
						{
							string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MoreThanMaxDemicalDigits, int_2));
							return false;
						}
					}
				}
				if (string_1 == null || string_1.Length <= 0)
				{
					break;
				}
				bool flag2 = true;
				string[] array = string_1.Split(',');
				string[] array2 = array;
				foreach (string a in array2)
				{
					flag2 = false;
					int num3 = a.IndexOf('-');
					if (num3 > 0)
					{
						double result2 = 0.0;
						double result3 = 0.0;
						if (double.TryParse(a.Substring(0, num3), out result2) && double.TryParse(a.Substring(num3 + 1), out result3) && result >= result2 && result <= result3)
						{
							flag2 = true;
							break;
						}
					}
					else
					{
						double result4 = double.NaN;
						if (double.TryParse(a, out result4) && result4 == result)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.ExcludeRange_Range, string_1));
					return false;
				}
				break;
			}
			case ValueTypeStyle.Date:
			{
				DateTime result5 = DateTime.MinValue;
				if (!DateTime.TryParse(Convert.ToString(object_0), out result5))
				{
					string_6 = ((text != null) ? text : ValueValidateStyleStrings.MustDateType);
					return false;
				}
				result5 = result5.Date;
				if (CheckMaxValue)
				{
					DateTime t = dateTime_0.Date;
					if (result5 > t)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MoreThanMaxValue_Value, FormatUtils.ToYYYY_MM_DD(t)));
						return false;
					}
				}
				if (CheckMinValue)
				{
					DateTime t2 = dateTime_1.Date;
					if (result5 < t2)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.LessThanMinValue_Value, FormatUtils.ToYYYY_MM_DD(t2)));
						return false;
					}
				}
				break;
			}
			case ValueTypeStyle.Time:
			{
				TimeSpan result6 = TimeSpan.Zero;
				if (!TimeSpan.TryParse(Convert.ToString(object_0), out result6))
				{
					string_6 = ((text != null) ? text : ValueValidateStyleStrings.MustTimeType);
					return false;
				}
				if (CheckMaxValue)
				{
					TimeSpan timeOfDay = dateTime_0.TimeOfDay;
					if (result6 > timeOfDay)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MoreThanMaxValue_Value, timeOfDay));
						return false;
					}
				}
				if (CheckMinValue)
				{
					TimeSpan timeOfDay2 = dateTime_1.TimeOfDay;
					if (result6 < timeOfDay2)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.LessThanMinValue_Value, timeOfDay2));
						return false;
					}
				}
				break;
			}
			case ValueTypeStyle.DateTime:
			{
				DateTime result5 = DateTime.MinValue;
				if (!DateTime.TryParse(Convert.ToString(object_0), out result5))
				{
					string_6 = ((text != null) ? text : ValueValidateStyleStrings.MustDateTimeType);
					return false;
				}
				if (CheckMaxValue)
				{
					DateTime t = dateTime_0;
					if (result5 > t)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MoreThanMaxValue_Value, FormatUtils.ToYYYY_MM_DD_HH_MM_SS(t)));
						return false;
					}
				}
				if (CheckMinValue)
				{
					DateTime t2 = dateTime_1;
					if (result5 < t2)
					{
						string_6 = ((text != null) ? text : string.Format(ValueValidateStyleStrings.LessThanMinValue_Value, FormatUtils.ToYYYY_MM_DD_HH_MM_SS(t2)));
						return false;
					}
				}
				break;
			}
			case ValueTypeStyle.RegExpress:
				if (!flag && !string.IsNullOrEmpty(RegExpression))
				{
					string value = Convert.ToString(Value);
					Regex regex = new Regex(RegExpression);
					if (!regex.IsMatch(value))
					{
						Message = ((text != null) ? text : string.Format(ValueValidateStyleStrings.MustMatch_Expression, RegExpression));
						return false;
					}
				}
				break;
			}
			if (!flag && !string.IsNullOrEmpty(ExcludeKeywords))
			{
				string a = null;
				if (!smethod_0(Convert.ToString(Value), ExcludeKeywords, ref a))
				{
					Message = ((text != null) ? text : string.Format(ValueValidateStyleStrings.CanNotContains_Text, a));
					return false;
				}
			}
			return true;
		}

		public static bool smethod_0(string string_7, string string_8, ref string string_9)
		{
			if (string.IsNullOrEmpty(string_7))
			{
				return true;
			}
			if (string_8.Length > 0)
			{
				string[] array = string_8.Split(',');
				foreach (string text in array)
				{
					if (string_7.IndexOf(text) >= 0)
					{
						string_9 = text;
						return false;
					}
				}
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       返回表示对象的文本
		                                                                    ///       </summary>
		                                                                    /// <returns>文本</returns>
		public override string ToString()
		{
			return method_2();
		}

		[DCInternal]
		public string method_2()
		{
			int num = 3;
			StringBuilder stringBuilder = new StringBuilder();
			if (string_0 != null && string_0.Trim().Length > 0)
			{
				method_3(stringBuilder, "ValueName", string_0);
			}
			if (string_5 != null && string_5.Trim().Length > 0)
			{
				method_3(stringBuilder, "CustomMessage", string_5.Trim());
			}
			if (bool_0)
			{
				method_3(stringBuilder, "Required", "true");
			}
			if (valueTypeStyle_0 != 0)
			{
				method_3(stringBuilder, "ValueType", valueTypeStyle_0.ToString());
			}
			if (valueTypeStyle_0 == ValueTypeStyle.Text)
			{
				if (CheckMaxValue && MaxLength > 0)
				{
					method_3(stringBuilder, "MaxLength", MaxLength.ToString());
				}
				if (CheckMinValue && MinLength > 0)
				{
					method_3(stringBuilder, "MinLength", MinLength.ToString());
				}
			}
			if (valueTypeStyle_0 == ValueTypeStyle.Numeric || valueTypeStyle_0 == ValueTypeStyle.Integer)
			{
				if (CheckMaxValue && !double.IsNaN(double_0))
				{
					method_3(stringBuilder, "MaxValue", double_0.ToString());
				}
				if (CheckMinValue && !double.IsNaN(double_1))
				{
					method_3(stringBuilder, "MinValue", double_1.ToString());
				}
				if (CheckDecimalDigits && MaxDecimalDigits > 0)
				{
					method_3(stringBuilder, "MaxDecimalDigits", MaxDecimalDigits.ToString());
				}
			}
			if ((valueTypeStyle_0 == ValueTypeStyle.Date || valueTypeStyle_0 == ValueTypeStyle.Time || valueTypeStyle_0 == ValueTypeStyle.DateTime) && dateTime_0 != DateTime.MinValue)
			{
				if (CheckMaxValue && DateTimeMaxValue != NullDateTime)
				{
					method_3(stringBuilder, "DateTimeMaxValue", FormatUtils.ToYYYY_MM_DD_HH_MM_SS(dateTime_0));
				}
				if (CheckMinValue && DateTimeMinValue != NullDateTime)
				{
					method_3(stringBuilder, "DateTimeMaxValue", FormatUtils.ToYYYY_MM_DD_HH_MM_SS(dateTime_1));
				}
			}
			if (ValueType == ValueTypeStyle.RegExpress)
			{
				method_3(stringBuilder, "Reg", RegExpression);
			}
			if (string_1 != null && string_1.Trim().Length > 0)
			{
				method_3(stringBuilder, "Range", string_1.Trim());
			}
			if (string_4 != null && string_4.Trim().Length > 0)
			{
				method_3(stringBuilder, "ExcludeKeywords", string_4.Trim());
			}
			if (string_3 != null && string_3.Trim().Length > 0)
			{
				method_3(stringBuilder, "IncludeKeywords", string_3.Trim());
			}
			return stringBuilder.ToString();
		}

		private void method_3(StringBuilder stringBuilder_0, string string_7, string string_8)
		{
			int num = 0;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(";");
			}
			stringBuilder_0.Append(string_7 + ":" + string_8);
		}

		[DCInternal]
		object ICloneable.Clone()
		{
			return (ValueValidateStyle)MemberwiseClone();
		}

		public ValueValidateStyle method_4()
		{
			return (ValueValidateStyle)((ICloneable)this).Clone();
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

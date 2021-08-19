using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       超链接的类型转换器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class HyperlinkInfoTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType.Equals(typeof(string)))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			HyperlinkInfo hyperlinkInfo = new HyperlinkInfo();
			if (Value is string)
			{
				hyperlinkInfo.Reference = Convert.ToString(Value);
				return hyperlinkInfo;
			}
			return base.ConvertFrom(context, culture, Value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)))
			{
				return Convert.ToString(Value);
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(typeof(HyperlinkInfo), attributes).Sort(new string[3]
			{
				"Reference",
				"Target",
				"Title"
			});
		}
	}
}

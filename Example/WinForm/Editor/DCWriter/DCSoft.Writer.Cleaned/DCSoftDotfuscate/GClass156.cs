using DCSoft.Printing;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass156 : TypeConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(typeof(XPageSettings), attributes).Sort(new string[14]
			{
				"PaperKind",
				"PaperWidth",
				"PaperHeight",
				"Landscape",
				"LeftMargin",
				"TopMargin",
				"RightMargin",
				"BottomMargin",
				"PaperSource",
				"PrinterName",
				"StickToPageSize",
				"HeaderDistance",
				"FooterDistance",
				"HeaderFooterDifferentFirstPage"
			});
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType.Equals(typeof(string)))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			if (Value is string)
			{
				XPageSettings xPageSettings = new XPageSettings();
				xPageSettings.method_6((string)Value);
				return xPageSettings;
			}
			return base.ConvertFrom(context, culture, Value);
		}
	}
}

using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass529 : TypeConverter
	{
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(typeof(XBrushStyle), attributes).Sort(new string[5]
			{
				"Style",
				"Color",
				"Color2",
				"Image",
				"Repeat"
			});
		}
	}
}

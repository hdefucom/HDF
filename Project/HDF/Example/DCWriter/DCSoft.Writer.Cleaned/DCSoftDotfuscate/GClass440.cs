using DCSoft.Drawing;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Browsable(false)]
	[ComVisible(false)]
	public class GClass440 : TypeConverter
	{
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(typeof(XFontValue), attributes).Sort(new string[7]
			{
				"Name",
				"Size",
				"Bold",
				"Italic",
				"Underline",
				"Strikeout",
				"Unit"
			});
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(Font))
			{
				return true;
			}
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(Font))
			{
				return true;
			}
			if (destinationType == typeof(string))
			{
				return true;
			}
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			if (Value == null)
			{
				return null;
			}
			if (Value is Font)
			{
				return new XFontValue((Font)Value);
			}
			if (!(Value is string))
			{
				return base.ConvertFrom(context, culture, Value);
			}
			string text = ((string)Value).Trim();
			if (text.Length == 0)
			{
				return null;
			}
			XFontValue xFontValue = new XFontValue();
			xFontValue.method_6(text);
			return xFontValue;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			int num = 16;
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (Value == null)
			{
				return null;
			}
			if (destinationType == typeof(string))
			{
				XFontValue xFontValue = (XFontValue)Value;
				if (xFontValue == null)
				{
					return "错误的类型";
				}
				return xFontValue.ToString();
			}
			if (destinationType == typeof(Font))
			{
				XFontValue xFontValue = (XFontValue)Value;
				return xFontValue.Value;
			}
			if (destinationType == typeof(InstanceDescriptor) && Value is XFontValue)
			{
				XFontValue xFontValue = (XFontValue)Value;
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				arrayList.Add(xFontValue.Name);
				arrayList2.Add(typeof(string));
				arrayList.Add(xFontValue.Size);
				arrayList2.Add(typeof(float));
				if (xFontValue.Style != 0)
				{
					arrayList.Add(xFontValue.Style);
					arrayList2.Add(typeof(FontStyle));
				}
				MemberInfo constructor = typeof(XFontValue).GetConstructor((Type[])arrayList2.ToArray(typeof(Type)));
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, arrayList.ToArray());
				}
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}

		private bool method_0(object object_0)
		{
			if (object_0 == null)
			{
				return false;
			}
			return Convert.ToBoolean(object_0);
		}
	}
}

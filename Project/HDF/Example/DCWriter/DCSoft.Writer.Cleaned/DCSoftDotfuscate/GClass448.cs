using DCSoft.Drawing;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass448 : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			if (Value is string)
			{
				XPaddingF xPaddingF = new XPaddingF();
				XPaddingF.Parse((string)Value, xPaddingF);
				return xPaddingF;
			}
			return base.ConvertFrom(context, CultureInfo.CurrentCulture, Value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			int num = 10;
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (Value is XPaddingF)
			{
				if (destinationType == typeof(string))
				{
					XPaddingF xPaddingF = (XPaddingF)Value;
					return xPaddingF.ToString();
				}
				if (destinationType == typeof(InstanceDescriptor))
				{
					XPaddingF xPaddingF2 = (XPaddingF)Value;
					if (xPaddingF2.Left == xPaddingF2.Top && xPaddingF2.Left == xPaddingF2.Right && xPaddingF2.Left == xPaddingF2.Bottom)
					{
						return new InstanceDescriptor(typeof(XPaddingF).GetConstructor(new Type[1]
						{
							typeof(float)
						}), new object[1]
						{
							xPaddingF2.Left
						});
					}
					return new InstanceDescriptor(typeof(XPaddingF).GetConstructor(new Type[4]
					{
						typeof(float),
						typeof(float),
						typeof(float),
						typeof(float)
					}), new object[4]
					{
						xPaddingF2.Left,
						xPaddingF2.Top,
						xPaddingF2.Right,
						xPaddingF2.Bottom
					});
				}
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}

		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			int num = 5;
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (propertyValues == null)
			{
				throw new ArgumentNullException("propertyValues");
			}
			return new XPaddingF((float)propertyValues["Left"], (float)propertyValues["Top"], (float)propertyValues["Right"], (float)propertyValues["Bottom"]);
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(typeof(XPaddingF), attributes).Sort(new string[4]
			{
				"Left",
				"Top",
				"Right",
				"Bottom"
			});
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}

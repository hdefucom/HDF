using DCSoft.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass319 : TypeConverter
	{
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
				ValueFormater valueFormater = new ValueFormater();
				valueFormater.method_0((string)Value);
				return valueFormater;
			}
			return base.ConvertFrom(context, culture, Value);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.Equals(typeof(InstanceDescriptor)))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			if (destinationType.Equals(typeof(InstanceDescriptor)))
			{
				ValueFormater valueFormater = (ValueFormater)Value;
				ConstructorInfo constructorInfo = null;
				if (valueFormater.Style == ValueFormatStyle.None && valueFormater.Format == null && valueFormater.NoneText == null)
				{
					constructorInfo = typeof(ValueFormater).GetConstructor(new Type[0]);
					return new InstanceDescriptor(constructorInfo, new object[0], isComplete: true);
				}
				constructorInfo = typeof(ValueFormater).GetConstructor(new Type[3]
				{
					typeof(ValueFormatStyle),
					typeof(string),
					typeof(string)
				});
				return new InstanceDescriptor(constructorInfo, new object[3]
				{
					valueFormater.Style,
					valueFormater.Format,
					valueFormater.NoneText
				}, isComplete: true);
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(typeof(ValueFormater), attributes).Sort(new string[3]
			{
				"Style",
				"Format",
				"NoneText"
			});
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}

using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass311 : TypeConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(value, attributes);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType.Equals(typeof(InstanceDescriptor)))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			if (Value is InstanceDescriptor)
			{
				return new GClass309();
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
				return new InstanceDescriptor(typeof(GClass309).GetConstructor(new Type[0]), null, isComplete: false);
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}
	}
}

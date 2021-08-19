using DCSoft.Drawing;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass523 : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType.Equals(typeof(string)) || sourceType.Equals(typeof(Color)) || sourceType.Equals(typeof(InstanceDescriptor)))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
			{
				return new XColorValue();
			}
			if (value is string)
			{
				return new XColorValue((string)value);
			}
			if (value is Color)
			{
				return new XColorValue((Color)value);
			}
			if (value is InstanceDescriptor)
			{
				InstanceDescriptor instanceDescriptor = (InstanceDescriptor)value;
				if (instanceDescriptor.Arguments != null && instanceDescriptor.Arguments.Count > 0)
				{
					IEnumerator enumerator = instanceDescriptor.Arguments.GetEnumerator();
					enumerator.Reset();
					enumerator.MoveNext();
					object current = enumerator.Current;
					if (current is string)
					{
						return new XColorValue((string)current);
					}
					if (current is Color)
					{
						return new XColorValue((Color)current);
					}
					return new XColorValue();
				}
			}
			return null;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)) || destinationType.Equals(typeof(Color)) || destinationType.Equals(typeof(InstanceDescriptor)))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			XColorValue xColorValue = value as XColorValue;
			if (destinationType.Equals(typeof(string)))
			{
				return xColorValue?.StringValue;
			}
			if (destinationType.Equals(typeof(Color)))
			{
				return xColorValue?.Value ?? Color.Empty;
			}
			if (destinationType.Equals(typeof(InstanceDescriptor)))
			{
				return new InstanceDescriptor(typeof(XColorValue).GetConstructor(new Type[1]
				{
					typeof(string)
				}), new object[1]
				{
					xColorValue.StringValue
				});
			}
			return null;
		}
	}
}

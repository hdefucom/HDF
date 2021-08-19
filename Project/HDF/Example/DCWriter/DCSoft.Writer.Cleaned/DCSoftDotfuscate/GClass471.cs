using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass471 : TypeConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object Value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(Value, attributes);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (typeof(string).Equals(sourceType))
			{
				return true;
			}
			if (typeof(InstanceDescriptor).Equals(sourceType))
			{
				return true;
			}
			if (typeof(Point).Equals(sourceType))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object Value)
		{
			int num = 19;
			if (Value is PointClass)
			{
				return (PointClass)Value;
			}
			if (Value is string)
			{
				string text = (string)Value;
				PointClass pointClass = new PointClass();
				if (text != null)
				{
					int num2 = text.IndexOf(",");
					if (num2 > 0)
					{
						int result = 0;
						if (int.TryParse(text.Substring(0, num2), out result))
						{
							pointClass.X = result;
						}
						if (int.TryParse(text.Substring(num2 + 1), out result))
						{
							pointClass.Y = result;
						}
					}
				}
				return pointClass;
			}
			if (Value is Point)
			{
				Point point = (Point)Value;
				return new PointClass(point.X, point.Y);
			}
			return null;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (typeof(string).Equals(destinationType))
			{
				return true;
			}
			if (typeof(InstanceDescriptor).Equals(destinationType))
			{
				return true;
			}
			if (typeof(Point).Equals(destinationType))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (typeof(string).Equals(destinationType))
			{
				return value.ToString();
			}
			if (typeof(Point).Equals(destinationType))
			{
				PointClass pointClass = value as PointClass;
				if (pointClass == null)
				{
					return Point.Empty;
				}
				return new Point(pointClass.X, pointClass.Y);
			}
			if (typeof(InstanceDescriptor).Equals(destinationType))
			{
				PointClass pointClass = value as PointClass;
				if (pointClass != null)
				{
					return new InstanceDescriptor(pointClass.GetType().GetConstructor(new Type[2]
					{
						typeof(int),
						typeof(int)
					}), new object[2]
					{
						pointClass.X,
						pointClass.Y
					});
				}
				return null;
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace DCSoftDotfuscate
{
	public class GClass312 : TypeConverter
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
			Type propertyType = context.PropertyDescriptor.PropertyType;
			FieldInfo fieldInfo = null;
			if (Value is string)
			{
				string text = (string)Value;
				FieldInfo[] fields = propertyType.GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo2 in fields)
				{
					if (fieldInfo == null)
					{
						fieldInfo = fieldInfo2;
					}
					if (string.Compare(text, fieldInfo2.Name, ignoreCase: true) != 0)
					{
						DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo2, typeof(DescriptionAttribute));
						if (descriptionAttribute != null && string.Compare(descriptionAttribute.Description, text, ignoreCase: true) == 0)
						{
							return fieldInfo2.GetValue(null);
						}
						continue;
					}
					return fieldInfo2.GetValue(null);
				}
			}
			return TypeDescriptor.GetConverter(typeof(Enum)).ConvertFrom(context, culture, Value);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			if (destinationType.Equals(typeof(string)))
			{
				Type propertyType = context.PropertyDescriptor.PropertyType;
				FieldInfo[] fields = propertyType.GetFields(BindingFlags.Static | BindingFlags.Public);
				int num = 0;
				FieldInfo fieldInfo;
				while (true)
				{
					if (num < fields.Length)
					{
						fieldInfo = fields[num];
						object value = fieldInfo.GetValue(null);
						if (value.Equals(Value))
						{
							break;
						}
						num++;
						continue;
					}
					return Value.ToString();
				}
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
				if (descriptionAttribute != null)
				{
					string description = descriptionAttribute.Description;
					if (description != null && description.Trim().Length > 0)
					{
						return description;
					}
				}
				return fieldInfo.Name;
			}
			return TypeDescriptor.GetConverter(typeof(Enum)).ConvertTo(context, culture, Value, destinationType);
		}
	}
}

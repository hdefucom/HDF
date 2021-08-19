using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass360 : PropertyDescriptor
	{
		private static bool bool_0 = true;

		private PropertyDescriptor propertyDescriptor_0 = null;

		public override string Name => propertyDescriptor_0.Name;

		public override AttributeCollection Attributes => propertyDescriptor_0.Attributes;

		public override string Category => propertyDescriptor_0.Category;

		public override string Description
		{
			get
			{
				string text = GClass359.smethod_2(propertyDescriptor_0.ComponentType, Name);
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				return propertyDescriptor_0.Description;
			}
		}

		public override bool IsBrowsable => propertyDescriptor_0.IsBrowsable;

		public override bool DesignTimeOnly => propertyDescriptor_0.DesignTimeOnly;

		public override string DisplayName
		{
			get
			{
				string text = propertyDescriptor_0.DisplayName;
				if (bool_0)
				{
					text = GClass359.smethod_3(propertyDescriptor_0.ComponentType, Name);
				}
				if (string.IsNullOrEmpty(text))
				{
					text = propertyDescriptor_0.DisplayName;
				}
				return text;
			}
		}

		public override Type ComponentType => propertyDescriptor_0.ComponentType;

		public override TypeConverter Converter => propertyDescriptor_0.Converter;

		public override bool IsLocalizable => propertyDescriptor_0.IsLocalizable;

		public override bool IsReadOnly => propertyDescriptor_0.IsReadOnly;

		public override Type PropertyType => propertyDescriptor_0.PropertyType;

		public GClass360(PropertyDescriptor propertyDescriptor_1)
			: base(propertyDescriptor_1)
		{
			propertyDescriptor_0 = propertyDescriptor_1;
		}

		public static bool smethod_0()
		{
			return bool_0;
		}

		public static void smethod_1(bool bool_1)
		{
			if (bool_0 != bool_1)
			{
				bool_0 = bool_1;
				GClass359.smethod_8();
			}
		}

		public override void AddValueChanged(object component, EventHandler handler)
		{
			propertyDescriptor_0.AddValueChanged(component, handler);
		}

		public override bool CanResetValue(object component)
		{
			return propertyDescriptor_0.CanResetValue(component);
		}

		public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
		{
			return propertyDescriptor_0.GetChildProperties(instance, filter);
		}

		public override object GetEditor(Type editorBaseType)
		{
			return propertyDescriptor_0.GetEditor(editorBaseType);
		}

		public override object GetValue(object component)
		{
			return propertyDescriptor_0.GetValue(component);
		}

		protected override void OnValueChanged(object sender, EventArgs e)
		{
		}

		public override void RemoveValueChanged(object component, EventHandler handler)
		{
			propertyDescriptor_0.RemoveValueChanged(component, handler);
		}

		public override void ResetValue(object component)
		{
			propertyDescriptor_0.ResetValue(component);
		}

		public override void SetValue(object component, object value)
		{
			propertyDescriptor_0.SetValue(component, value);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return propertyDescriptor_0.ShouldSerializeValue(component);
		}
	}
}

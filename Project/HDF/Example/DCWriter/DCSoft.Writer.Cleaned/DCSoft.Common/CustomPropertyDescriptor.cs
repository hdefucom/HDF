using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	[ComVisible(false)]
	public class CustomPropertyDescriptor : PropertyDescriptor
	{
		private CustomProperty _customProperty = null;

		public override Type ComponentType => _customProperty.GetType();

		public override bool IsReadOnly => _customProperty.IsReadOnly;

		public override Type PropertyType => _customProperty.ValueType;

		public override string Description => _customProperty.Description;

		public override string Category => _customProperty.Category;

		public override string DisplayName => _customProperty.DisplayName;

		public override bool IsBrowsable => _customProperty.IsBrowsable;

		public object CustomProperty => _customProperty;

		public CustomPropertyDescriptor(CustomProperty customProperty, Attribute[] attrs)
			: base(customProperty.Name, attrs)
		{
			_customProperty = customProperty;
		}

		public override bool CanResetValue(object component)
		{
			return _customProperty.DefaultValue != null;
		}

		public override object GetValue(object component)
		{
			return _customProperty.Value;
		}

		public override void ResetValue(object component)
		{
			_customProperty.ResetValue();
		}

		public override void SetValue(object component, object value)
		{
			_customProperty.Value = value;
		}

		public override bool ShouldSerializeValue(object component)
		{
			return true;
		}
	}
}

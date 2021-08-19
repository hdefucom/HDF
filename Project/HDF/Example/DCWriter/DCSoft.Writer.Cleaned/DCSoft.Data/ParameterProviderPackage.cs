using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	[ComVisible(false)]
	public class ParameterProviderPackage : ICustomTypeDescriptor
	{
		private class Class31 : PropertyDescriptor
		{
			private IParameterProvider iparameterProvider_0 = null;

			private ParameterDescriptor parameterDescriptor_0 = null;

			public override string Name => parameterDescriptor_0.Name;

			public override string Description => parameterDescriptor_0.Description;

			public override bool IsBrowsable => parameterDescriptor_0.IsBrowsable;

			public override string DisplayName => parameterDescriptor_0.DisplayName;

			public override Type ComponentType => parameterDescriptor_0.RuntimeValueType;

			public override TypeConverter Converter => TypeDescriptor.GetConverter(parameterDescriptor_0.RuntimeValueType);

			public override bool IsReadOnly => parameterDescriptor_0.Readonly;

			public override Type PropertyType => parameterDescriptor_0.RuntimeValueType;

			public Class31(IParameterProvider iparameterProvider_1, ParameterDescriptor parameterDescriptor_1)
				: base(parameterDescriptor_1.Name, null)
			{
				iparameterProvider_0 = iparameterProvider_1;
				parameterDescriptor_0 = parameterDescriptor_1;
			}

			public override object GetEditor(Type editorBaseType)
			{
				return TypeDescriptor.GetEditor(parameterDescriptor_0.RuntimeValueType, editorBaseType);
			}

			private IParameterProvider method_0(object object_0)
			{
				if (object_0 is ParameterProviderPackage)
				{
					return ((ParameterProviderPackage)object_0)._Provider;
				}
				return object_0 as IParameterProvider;
			}

			public override object GetValue(object component)
			{
				IParameterProvider parameterProvider = method_0(component);
				return parameterProvider.GetParameterValue(parameterDescriptor_0.Name);
			}

			public override void SetValue(object component, object value)
			{
				IParameterProvider parameterProvider = method_0(component);
				parameterProvider.SetParameterValue(parameterDescriptor_0.Name, value);
			}

			public override void ResetValue(object component)
			{
			}

			public override bool CanResetValue(object component)
			{
				return false;
			}

			public override bool ShouldSerializeValue(object component)
			{
				return false;
			}
		}

		private IParameterProvider _Provider;

		public ParameterProviderPackage(IParameterProvider provider)
		{
			int num = 12;
			_Provider = null;
			
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			_Provider = provider;
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(_Provider);
		}

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(_Provider);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(_Provider);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(_Provider);
		}

		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(_Provider);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(_Provider);
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(_Provider, editorBaseType);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(_Provider, attributes);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(_Provider);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			ParameterDescriptorList descriptors = _Provider.GetDescriptors();
			List<PropertyDescriptor> list = new List<PropertyDescriptor>();
			foreach (ParameterDescriptor item in descriptors)
			{
				list.Add(new Class31(_Provider, item));
			}
			return new PropertyDescriptorCollection(list.ToArray());
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return GetProperties(null);
		}

		public object GetPropertyOwner(PropertyDescriptor propertyDescriptor_0)
		{
			return _Provider;
		}
	}
}

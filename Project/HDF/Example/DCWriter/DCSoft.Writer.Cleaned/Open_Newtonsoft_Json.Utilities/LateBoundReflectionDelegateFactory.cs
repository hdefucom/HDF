using Open_Newtonsoft_Json.Serialization;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory
	{
		private static readonly LateBoundReflectionDelegateFactory _instance = new LateBoundReflectionDelegateFactory();

		internal static ReflectionDelegateFactory Instance => _instance;

		public override ObjectConstructor<object> CreateParametrizedConstructor(MethodBase method)
		{
			ValidationUtils.ArgumentNotNull(method, "method");
			ConstructorInfo constructorInfo_0 = method as ConstructorInfo;
			if (constructorInfo_0 != null)
			{
				return (object[] object_0) => constructorInfo_0.Invoke(object_0);
			}
			return (object[] object_0) => method.Invoke(null, object_0);
		}

		public override MethodCall<T, object> CreateMethodCall<T>(MethodBase method)
		{
			ValidationUtils.ArgumentNotNull(method, "method");
			ConstructorInfo constructorInfo_0 = method as ConstructorInfo;
			if (constructorInfo_0 != null)
			{
				return (T gparam_0, object[] object_0) => constructorInfo_0.Invoke(object_0);
			}
			return (T gparam_0, object[] object_0) => method.Invoke(gparam_0, object_0);
		}

		public override Func<T> CreateDefaultConstructor<T>(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			if (TypeExtensions.IsValueType(type))
			{
				return () => (T)Activator.CreateInstance(type);
			}
			ConstructorInfo constructorInfo = ReflectionUtils.GetDefaultConstructor(type, nonPublic: true);
			return () => (T)constructorInfo.Invoke(null);
		}

		public override Func<T, object> CreateGet<T>(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			return (T gparam_0) => propertyInfo.GetValue(gparam_0, null);
		}

		public override Func<T, object> CreateGet<T>(FieldInfo fieldInfo)
		{
			ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
			return (T gparam_0) => fieldInfo.GetValue(gparam_0);
		}

		public override Action<T, object> CreateSet<T>(FieldInfo fieldInfo)
		{
			ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
			return delegate(T gparam_0, object object_0)
			{
				fieldInfo.SetValue(gparam_0, object_0);
			};
		}

		public override Action<T, object> CreateSet<T>(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			return delegate(T gparam_0, object object_0)
			{
				propertyInfo.SetValue(gparam_0, object_0, null);
			};
		}
	}
}

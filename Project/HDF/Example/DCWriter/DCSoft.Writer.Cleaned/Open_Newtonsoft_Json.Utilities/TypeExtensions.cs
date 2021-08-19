using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class TypeExtensions
	{
		public static MethodInfo Method(Delegate delegate_0)
		{
			return delegate_0.Method;
		}

		public static MemberTypes MemberType(MemberInfo memberInfo)
		{
			return memberInfo.MemberType;
		}

		public static bool ContainsGenericParameters(Type type)
		{
			return type.ContainsGenericParameters;
		}

		public static bool IsInterface(Type type)
		{
			return type.IsInterface;
		}

		public static bool IsGenericType(Type type)
		{
			return type.IsGenericType;
		}

		public static bool IsGenericTypeDefinition(Type type)
		{
			return type.IsGenericTypeDefinition;
		}

		public static Type BaseType(Type type)
		{
			return type.BaseType;
		}

		public static Assembly Assembly(Type type)
		{
			return type.Assembly;
		}

		public static bool IsEnum(Type type)
		{
			return type.IsEnum;
		}

		public static bool IsClass(Type type)
		{
			return type.IsClass;
		}

		public static bool IsSealed(Type type)
		{
			return type.IsSealed;
		}

		public static bool IsAbstract(Type type)
		{
			return type.IsAbstract;
		}

		public static bool IsVisible(Type type)
		{
			return type.IsVisible;
		}

		public static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}

		public static bool AssignableToTypeName(Type type, string fullTypeName, out Type match)
		{
			Type type2 = type;
			while (true)
			{
				if (type2 != null)
				{
					if (string.Equals(type2.FullName, fullTypeName, StringComparison.Ordinal))
					{
						break;
					}
					type2 = BaseType(type2);
					continue;
				}
				Type[] interfaces = type.GetInterfaces();
				int num = 0;
				while (true)
				{
					if (num < interfaces.Length)
					{
						Type type3 = interfaces[num];
						if (string.Equals(type3.Name, fullTypeName, StringComparison.Ordinal))
						{
							break;
						}
						num++;
						continue;
					}
					match = null;
					return false;
				}
				match = type;
				return true;
			}
			match = type2;
			return true;
		}

		public static bool AssignableToTypeName(Type type, string fullTypeName)
		{
			Type match;
			return AssignableToTypeName(type, fullTypeName, out match);
		}
	}
}

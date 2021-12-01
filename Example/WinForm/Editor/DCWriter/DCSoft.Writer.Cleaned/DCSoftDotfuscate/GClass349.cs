using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass349
	{
		private class Class194
		{
			public bool bool_0 = false;

			public Type type_0 = null;

			public object object_0 = null;
		}

		private Dictionary<Type, Class194> dictionary_0 = new Dictionary<Type, Class194>();

		public object method_0(Type type_0)
		{
			int num = 18;
			if (type_0 == null)
			{
				throw new ArgumentNullException("baseType");
			}
			if (dictionary_0.ContainsKey(type_0))
			{
				Class194 @class = dictionary_0[type_0];
				if (@class.bool_0 && @class.object_0 != null)
				{
					return @class.object_0;
				}
				object obj = Activator.CreateInstance(@class.type_0);
				if (@class.bool_0)
				{
					@class.object_0 = obj;
				}
				return obj;
			}
			return null;
		}

		public void method_1(Type type_0, Type type_1)
		{
			method_2(type_0, type_1, bool_0: false);
		}

		public void method_2(Type type_0, Type type_1, bool bool_0)
		{
			int num = 18;
			if (type_0 == null)
			{
				throw new ArgumentNullException("baseType");
			}
			if (type_1 == null)
			{
				throw new ArgumentNullException("instanceType");
			}
			if (type_1.IsAbstract)
			{
				throw new ArgumentException(type_1.FullName + " is Abstract");
			}
			if (type_1.IsInterface)
			{
				throw new ArgumentException(type_1.FullName + " is Interface");
			}
			bool flag = false;
			if (type_0.IsInterface)
			{
				Type[] interfaces = type_1.GetInterfaces();
				if (interfaces != null)
				{
					Type[] array = interfaces;
					foreach (Type type in array)
					{
						if (type == type_0)
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (type_1 == type_0 || type_1.IsSubclassOf(type_0))
			{
				flag = true;
			}
			if (!flag)
			{
				throw new ArgumentException(type_1.FullName + " XX " + type_0.FullName);
			}
			Class194 @class = new Class194();
			@class.type_0 = type_1;
			@class.bool_0 = bool_0;
			dictionary_0[type_0] = @class;
		}
	}
}

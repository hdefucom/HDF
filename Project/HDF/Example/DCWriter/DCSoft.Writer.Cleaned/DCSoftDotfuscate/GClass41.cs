using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass41
	{
		private string string_0 = null;

		private bool bool_0 = false;

		private PropertyInfo propertyInfo_0 = null;

		private bool bool_1 = false;

		private object object_0 = null;

		private Dictionary<string, GClass42> dictionary_0 = null;

		public string method_0()
		{
			return propertyInfo_0.Name;
		}

		public string method_1()
		{
			return string_0;
		}

		public void method_2(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_3()
		{
			return bool_0;
		}

		public void method_4(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public PropertyInfo method_5()
		{
			return propertyInfo_0;
		}

		public void method_6(PropertyInfo propertyInfo_1)
		{
			propertyInfo_0 = propertyInfo_1;
		}

		public Type method_7()
		{
			if (propertyInfo_0 == null)
			{
				return null;
			}
			return propertyInfo_0.PropertyType;
		}

		public bool method_8()
		{
			return bool_1;
		}

		public void method_9(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public object method_10()
		{
			return object_0;
		}

		public void method_11(object object_1)
		{
			object_0 = object_1;
		}

		public Dictionary<string, GClass42> method_12()
		{
			return dictionary_0;
		}

		public void method_13(Dictionary<string, GClass42> dictionary_1)
		{
			dictionary_0 = dictionary_1;
		}

		public override string ToString()
		{
			return method_1();
		}
	}
}

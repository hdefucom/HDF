using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass371
	{
		public static readonly object object_0 = new object();

		private static Dictionary<Type, Dictionary<string, GClass371>> dictionary_0 = new Dictionary<Type, Dictionary<string, GClass371>>();

		internal Type type_0 = null;

		private string string_0 = null;

		private Type type_1 = typeof(object);

		private object object_1 = null;

		private TypeConverter typeConverter_0 = null;

		private UITypeEditor uitypeEditor_0 = null;

		private bool bool_0 = false;

		private string string_1 = null;

		private string string_2 = null;

		private bool bool_1 = false;

		private string string_3 = null;

		private bool bool_2 = true;

		private bool bool_3 = true;

		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public static GClass371 smethod_0(string string_4, Type type_2, Type type_3)
		{
			int num = 6;
			if (string_4 == null || string_4.Trim().Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			string_4 = string_4.Trim();
			if (type_2 == null)
			{
				throw new ArgumentNullException("propertyType");
			}
			if (type_3 == null)
			{
				throw new ArgumentNullException("ownerType");
			}
			Dictionary<string, GClass371> dictionary = null;
			if (dictionary_0.ContainsKey(type_3))
			{
				dictionary = dictionary_0[type_3];
			}
			else
			{
				dictionary = new Dictionary<string, GClass371>();
				dictionary_0[type_3] = dictionary;
			}
			if (dictionary.ContainsKey(string_4))
			{
				throw new ArgumentException("Multi " + string_4);
			}
			GClass371 gClass = new GClass371(type_3, string_4, type_2);
			gClass.method_4(ValueTypeHelper.GetDefaultValue(type_2));
			dictionary[string_4] = gClass;
			return gClass;
		}

		public static GClass371 smethod_1(string string_4, Type type_2, Type type_3, object object_2)
		{
			int num = 6;
			if (string_4 == null || string_4.Trim().Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			string_4 = string_4.Trim();
			if (type_2 == null)
			{
				throw new ArgumentNullException("propertyType");
			}
			if (type_3 == null)
			{
				throw new ArgumentNullException("ownerType");
			}
			if (object_2 != null && !type_2.IsInstanceOfType(object_2))
			{
				throw new ArgumentException("bad defaultValue:" + object_2);
			}
			Dictionary<string, GClass371> dictionary = null;
			if (dictionary_0.ContainsKey(type_3))
			{
				dictionary = dictionary_0[type_3];
			}
			else
			{
				dictionary = new Dictionary<string, GClass371>();
				dictionary_0[type_3] = dictionary;
			}
			if (dictionary.ContainsKey(string_4))
			{
				throw new ArgumentException("Multi " + string_4);
			}
			GClass371 gClass = new GClass371(type_3, string_4, type_2);
			gClass.method_4(object_2);
			dictionary[string_4] = gClass;
			return gClass;
		}

		public static GClass371 smethod_2(Type type_2, string string_4)
		{
			int num = 6;
			if (type_2 == null)
			{
				throw new ArgumentNullException("ownerType");
			}
			if (string_4 == null)
			{
				throw new ArgumentNullException("name");
			}
			foreach (Type key in dictionary_0.Keys)
			{
				if (key == type_2 || type_2.IsSubclassOf(key))
				{
					Dictionary<string, GClass371> dictionary = dictionary_0[key];
					if (dictionary.ContainsKey(string_4))
					{
						return dictionary[string_4];
					}
				}
			}
			return null;
		}

		public static GClass371[] smethod_3(Type type_2, bool bool_4)
		{
			int num = 19;
			if (type_2 == null)
			{
				throw new ArgumentNullException("ownerType");
			}
			List<GClass371> list = new List<GClass371>();
			if (bool_4)
			{
				if (dictionary_0.ContainsKey(type_2))
				{
					Dictionary<string, GClass371> dictionary = dictionary_0[type_2];
					foreach (GClass371 value in dictionary.Values)
					{
						list.Add(value);
					}
				}
			}
			else
			{
				foreach (Type key in dictionary_0.Keys)
				{
					if (key == type_2 || type_2.IsSubclassOf(key))
					{
						Dictionary<string, GClass371> dictionary = dictionary_0[key];
						foreach (GClass371 value2 in dictionary.Values)
						{
							list.Add(value2);
						}
					}
				}
			}
			return list.ToArray();
		}

		private GClass371(Type type_2, string string_4, Type type_3)
		{
			type_0 = type_2;
			string_0 = string_4;
			type_1 = type_3;
			object_1 = ValueTypeHelper.GetDefaultValue(type_1);
		}

		private GClass371(Type type_2, string string_4, Type type_3, object object_2)
		{
			type_0 = type_2;
			string_0 = string_4;
			type_1 = type_3;
			object_1 = object_2;
		}

		public Type method_0()
		{
			return type_0;
		}

		public Type method_1()
		{
			return type_1;
		}

		public void method_2(Type type_2)
		{
			type_1 = type_2;
		}

		public object method_3()
		{
			return object_1;
		}

		public void method_4(object object_2)
		{
			object_1 = object_2;
		}

		public bool method_5(object object_2)
		{
			if (object_1 == object_0)
			{
				return false;
			}
			if (object_1 is IComparable)
			{
				return ((IComparable)object_1).CompareTo(object_2) == 0;
			}
			return object.Equals(object_1, object_2);
		}

		public TypeConverter method_6()
		{
			return typeConverter_0;
		}

		public void method_7(TypeConverter typeConverter_1)
		{
			typeConverter_0 = typeConverter_1;
		}

		public UITypeEditor method_8()
		{
			return uitypeEditor_0;
		}

		public void method_9(UITypeEditor uitypeEditor_1)
		{
			uitypeEditor_0 = uitypeEditor_1;
		}

		public bool method_10()
		{
			return bool_0;
		}

		public void method_11(bool bool_4)
		{
			bool_0 = bool_4;
		}

		public string method_12()
		{
			return string_1;
		}

		public void method_13(string string_4)
		{
			string_1 = string_4;
		}

		public string method_14()
		{
			return string_2;
		}

		public void method_15(string string_4)
		{
			string_2 = string_4;
		}

		public bool method_16()
		{
			return bool_1;
		}

		public void method_17(bool bool_4)
		{
			bool_1 = bool_4;
		}

		public string method_18()
		{
			return string_3;
		}

		public void method_19(string string_4)
		{
			string_3 = string_4;
		}

		public bool method_20()
		{
			return bool_2;
		}

		public void method_21(bool bool_4)
		{
			bool_2 = bool_4;
		}

		public bool method_22()
		{
			return bool_3;
		}

		public void method_23(bool bool_4)
		{
			bool_3 = bool_4;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

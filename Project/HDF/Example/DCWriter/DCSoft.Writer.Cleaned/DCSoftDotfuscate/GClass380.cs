using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass380 : ResourceManager
	{
		private class Class198 : IComparer<PropertyInfo>
		{
			public int Compare(PropertyInfo propertyInfo_0, PropertyInfo propertyInfo_1)
			{
				return string.Compare(propertyInfo_0.Name, propertyInfo_1.Name);
			}
		}

		private ResourceManager resourceManager_0;

		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		private static List<string> list_0 = new List<string>();

		private static Dictionary<Type, List<PropertyInfo>> dictionary_1 = new Dictionary<Type, List<PropertyInfo>>();

		public override string BaseName => resourceManager_0.BaseName;

		public override bool IgnoreCase
		{
			get
			{
				return resourceManager_0.IgnoreCase;
			}
			set
			{
				resourceManager_0.IgnoreCase = value;
			}
		}

		public override Type ResourceSetType => resourceManager_0.ResourceSetType;

		private GClass380(ResourceManager resourceManager_1)
		{
			int num = 9;
			resourceManager_0 = null;
			
			if (resourceManager_1 == null)
			{
				throw new ArgumentNullException("man");
			}
			resourceManager_0 = resourceManager_1;
		}

		public override ResourceSet GetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
		{
			return resourceManager_0.GetResourceSet(culture, createIfNotExists, tryParents);
		}

		public override void ReleaseAllResources()
		{
			resourceManager_0.ReleaseAllResources();
		}

		public override object GetObject(string name)
		{
			return resourceManager_0.GetObject(name);
		}

		public override object GetObject(string name, CultureInfo culture)
		{
			return resourceManager_0.GetObject(name, culture);
		}

		public override string GetString(string name)
		{
			if (!smethod_1(name) && dictionary_0.ContainsKey(name))
			{
				return dictionary_0[name];
			}
			return resourceManager_0.GetString(name);
		}

		public override string GetString(string name, CultureInfo culture)
		{
			if (!smethod_1(name) && dictionary_0.ContainsKey(name))
			{
				return dictionary_0[name];
			}
			return resourceManager_0.GetString(name, culture);
		}

		public static void smethod_0(string string_0)
		{
			if (!list_0.Contains(string_0))
			{
				list_0.Add(string_0);
			}
		}

		private static bool smethod_1(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return false;
			}
			if (list_0.Count > 0)
			{
				foreach (string item in list_0)
				{
					if (item == string_0)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static List<string> smethod_2()
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			foreach (Type key in dictionary_1.Keys)
			{
				List<PropertyInfo> collection = dictionary_1[key];
				list.AddRange(collection);
			}
			list.Sort(new Class198());
			List<string> list2 = new List<string>();
			string b = null;
			foreach (PropertyInfo item in list)
			{
				if (item.Name != b)
				{
					b = item.Name;
					if (!smethod_1(item.Name))
					{
						list2.Add(item.Name);
						list2.Add(Convert.ToString(item.GetValue(null, null)));
					}
				}
			}
			return list2;
		}

		public static void smethod_3(string string_0, string string_1)
		{
			if (smethod_1(string_0) || string.IsNullOrEmpty(string_0))
			{
				return;
			}
			if (string.IsNullOrEmpty(string_1))
			{
				if (dictionary_0.ContainsKey(string_0))
				{
					dictionary_0.Remove(string_0);
				}
			}
			else
			{
				dictionary_0[string_0] = string_1;
			}
		}

		public static void smethod_4(Type type_0)
		{
			int num = 3;
			if (type_0 == null)
			{
				throw new ArgumentNullException("resourceContainerType");
			}
			if (dictionary_1.ContainsKey(type_0))
			{
				return;
			}
			PropertyInfo[] properties = type_0.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			int num2 = 0;
			PropertyInfo propertyInfo;
			while (true)
			{
				if (num2 < properties.Length)
				{
					propertyInfo = properties[num2];
					if (propertyInfo.Name == "ResourceManager" && propertyInfo.PropertyType.Equals(typeof(ResourceManager)))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			propertyInfo.GetValue(null, null);
			FieldInfo[] fields = type_0.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			int num3 = 0;
			FieldInfo fieldInfo;
			while (true)
			{
				if (num3 < fields.Length)
				{
					fieldInfo = fields[num3];
					if (fieldInfo.FieldType.Equals(typeof(ResourceManager)))
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			object value = fieldInfo.GetValue(null);
			GClass380 value2 = new GClass380((ResourceManager)value);
			fieldInfo.SetValue(null, value2);
			List<PropertyInfo> list = new List<PropertyInfo>();
			PropertyInfo[] properties2 = type_0.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo2 in properties2)
			{
				if (propertyInfo2.CanRead && propertyInfo2.PropertyType.Equals(typeof(string)))
				{
					list.Add(propertyInfo2);
				}
			}
			dictionary_1[type_0] = list;
		}
	}
}

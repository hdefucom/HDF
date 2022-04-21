using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public static class GClass359
	{
		public const string string_0 = "_Description";

		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		private static List<Assembly> list_0 = new List<Assembly>();

		public static string smethod_0(MemberInfo memberInfo_0)
		{
			int num = 9;
			string text = smethod_6(string.Concat(memberInfo_0.DeclaringType, ".", memberInfo_0.Name));
			string text2 = smethod_7(text, bool_0: true);
			if (text2 == null)
			{
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(memberInfo_0, typeof(DescriptionAttribute), inherit: true);
				if (descriptionAttribute != null)
				{
					dictionary_0[text + "_Description"] = descriptionAttribute.Description;
					return descriptionAttribute.Description;
				}
			}
			return null;
		}

		public static string smethod_1(MemberInfo memberInfo_0)
		{
			string string_ = smethod_6(string.Concat(memberInfo_0.DeclaringType, ".", memberInfo_0.Name));
			string text = smethod_7(string_, bool_0: false);
			if (text == null)
			{
				return memberInfo_0.Name;
			}
			return null;
		}

		public static string smethod_2(Type type_0, string string_1)
		{
			string string_2 = smethod_6(type_0.FullName + "." + string_1);
			return smethod_7(string_2, bool_0: true);
		}

		public static string smethod_3(Type type_0, string string_1)
		{
			string string_2 = smethod_6(type_0.FullName + "." + string_1);
			return smethod_7(string_2, bool_0: false);
		}

		public static string smethod_4(string string_1)
		{
			if (string_1 == null)
			{
				return null;
			}
			return smethod_7(string_1, bool_0: true);
		}

		public static string smethod_5(string string_1)
		{
			return smethod_7(string_1, bool_0: false);
		}

		public static string smethod_6(string string_1)
		{
			if (string_1 == null || string.IsNullOrEmpty(string_1))
			{
				return string_1;
			}
			string_1 = string_1.Replace('.', '_');
			return string_1;
		}

		internal static string smethod_7(string string_1, bool bool_0)
		{
			int num = 1;
			if (string_1 == null)
			{
				return null;
			}
			string key = string_1;
			if (bool_0)
			{
				key = string_1 + "_Description";
			}
			if (dictionary_0.ContainsKey(key))
			{
				return dictionary_0[key];
			}
			if (dictionary_0.ContainsKey(string_1))
			{
				return dictionary_0[string_1];
			}
			return null;
		}

		internal static void smethod_8()
		{
			dictionary_0.Clear();
			list_0.Clear();
		}

		public static void smethod_9(Assembly assembly_0, string string_1)
		{
			int num = 15;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			ResourceManager resourceManager = new ResourceManager(string_1, assembly_0);
			ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, createIfNotExists: true, tryParents: true);
			IDictionaryEnumerator enumerator = resourceSet.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string key = Convert.ToString(enumerator.Key);
				dictionary_0[key] = Convert.ToString(enumerator.Value);
			}
			resourceManager.ReleaseAllResources();
		}

		public static int smethod_10(string string_1)
		{
			int num = 10;
			if (string_1 == null || string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("resxFileName");
			}
			if (!File.Exists(string_1))
			{
				throw new FileNotFoundException(string_1);
			}
			ResXResourceReader resXResourceReader = new ResXResourceReader(string_1);
			IDictionaryEnumerator enumerator = resXResourceReader.GetEnumerator();
			int num2 = 0;
			while (enumerator.MoveNext())
			{
				string key = Convert.ToString(enumerator.Key);
				dictionary_0[key] = Convert.ToString(enumerator.Value);
				num2++;
			}
			resXResourceReader.Close();
			return num2;
		}

		public static Dictionary<string, string> smethod_11(Assembly assembly_0)
		{
			int num = 7;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Type[] types = assembly_0.GetTypes();
			foreach (Type type in types)
			{
				DCDisplayNameAttribute dCDisplayNameAttribute = (DCDisplayNameAttribute)Attribute.GetCustomAttribute(type, typeof(DCDisplayNameAttribute), inherit: true);
				if (dCDisplayNameAttribute != null && !string.IsNullOrEmpty(dCDisplayNameAttribute.ResourceItemName) && !dictionary.ContainsKey(dCDisplayNameAttribute.ResourceItemName))
				{
					dictionary[dCDisplayNameAttribute.ResourceItemName] = dCDisplayNameAttribute.DisplayName;
				}
				DCDescriptionAttribute dCDescriptionAttribute = (DCDescriptionAttribute)Attribute.GetCustomAttribute(type, typeof(DCDescriptionAttribute), inherit: true);
				if (dCDescriptionAttribute != null && !string.IsNullOrEmpty(dCDescriptionAttribute.ResourceItemName) && !dictionary.ContainsKey(dCDescriptionAttribute.ResourceItemName))
				{
					dictionary[dCDescriptionAttribute.ResourceItemName] = dCDescriptionAttribute.Description;
				}
				MemberInfo[] members = type.GetMembers();
				foreach (MemberInfo memberInfo in members)
				{
					dCDisplayNameAttribute = (DCDisplayNameAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(DCDisplayNameAttribute), inherit: true);
					if (dCDisplayNameAttribute != null)
					{
						string text = dCDisplayNameAttribute.ResourceItemName;
						if (string.IsNullOrEmpty(text))
						{
							text = smethod_6(type.FullName + "." + memberInfo.Name);
						}
						dictionary[text] = dCDisplayNameAttribute.DisplayName;
					}
					dCDescriptionAttribute = (DCDescriptionAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(DCDescriptionAttribute), inherit: true);
					if (dCDescriptionAttribute != null)
					{
						string text = dCDescriptionAttribute.ResourceItemName;
						if (string.IsNullOrEmpty(text))
						{
							text = smethod_6(type.FullName + "." + memberInfo.Name + "_Description");
						}
						dictionary[text] = dCDescriptionAttribute.Description;
					}
				}
			}
			return dictionary;
		}

		internal static bool smethod_12(Assembly assembly_0)
		{
			if (assembly_0 == null)
			{
				return false;
			}
			if (list_0.Contains(assembly_0))
			{
				return true;
			}
			list_0.Add(assembly_0);
			List<string> list = new List<string>();
			Type[] types = assembly_0.GetTypes();
			foreach (Type element in types)
			{
				DCDescriptionResourceSourceAttribute dCDescriptionResourceSourceAttribute = (DCDescriptionResourceSourceAttribute)Attribute.GetCustomAttribute(element, typeof(DCDescriptionResourceSourceAttribute));
				if (dCDescriptionResourceSourceAttribute != null && !string.IsNullOrEmpty(dCDescriptionResourceSourceAttribute.ResourceName) && !list.Contains(dCDescriptionResourceSourceAttribute.ResourceName))
				{
					list.Add(dCDescriptionResourceSourceAttribute.ResourceName);
					smethod_9(assembly_0, dCDescriptionResourceSourceAttribute.ResourceName);
				}
			}
			return true;
		}
	}
}

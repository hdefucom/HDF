using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[Guid("1B016C4C-E796-4d29-875A-37541BD4ADEF")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class GAttribute1 : Attribute
	{
		private string string_0 = null;

		private static Hashtable hashtable_0 = new Hashtable();

		public GAttribute1(string string_1)
		{
			string_0 = string_1;
		}

		public string method_0()
		{
			return string_0;
		}

		public static string smethod_0(MemberInfo memberInfo_0)
		{
			Guid g = new Guid("1B016C4C-E796-4d29-875A-37541BD4ADEF");
			if (hashtable_0.ContainsKey(memberInfo_0))
			{
				return (string)hashtable_0[memberInfo_0];
			}
			Attribute[] customAttributes = Attribute.GetCustomAttributes(memberInfo_0);
			foreach (Attribute attribute in customAttributes)
			{
				if (!attribute.GetType().GUID.Equals(g))
				{
					continue;
				}
				PropertyInfo[] properties = attribute.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.CanRead && !propertyInfo.CanWrite && propertyInfo.PropertyType.Equals(typeof(string)))
					{
						string text = (string)propertyInfo.GetValue(attribute, null);
						hashtable_0[memberInfo_0] = text;
						return text;
					}
				}
			}
			hashtable_0[memberInfo_0] = null;
			return null;
		}
	}
}

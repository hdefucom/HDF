using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass372
	{
		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		protected static string smethod_0(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return "";
			}
			string value = null;
			if (dictionary_0.TryGetValue(string_0, out value))
			{
				return value;
			}
			return null;
		}

		protected static void smethod_1(string string_0, string string_1)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				dictionary_0[string_0] = string_1;
			}
		}

		public static void smethod_2(Type type_0)
		{
			if (type_0 == null)
			{
				return;
			}
			PropertyInfo[] properties = type_0.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				object value = propertyInfo.GetValue(null, null);
				if (value != null && value is string)
				{
					smethod_1(propertyInfo.Name, (string)value);
				}
			}
		}

		public static string smethod_3(string string_0, string string_1, Type[] type_0, bool bool_0)
		{
			int num = 11;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("nsName");
			}
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("typeName");
			}
			if (type_0 == null)
			{
				throw new ArgumentNullException("stringsType");
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (!bool_0)
			{
				stringBuilder.AppendLine("namespace " + string_0);
				stringBuilder.AppendLine("{");
				stringBuilder.AppendLine(" public class " + string_1 + ":DCSoft.Common.ResourceStringsContainer");
				stringBuilder.AppendLine(" {");
				stringBuilder.AppendLine("     public " + string_1 + "()");
				stringBuilder.AppendLine("     {}");
			}
			List<string> list = new List<string>();
			foreach (Type type in type_0)
			{
				stringBuilder.AppendLine("     //" + type.FullName);
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					if (propertyInfo.PropertyType.Equals(typeof(string)) && propertyInfo.CanRead && !list.Contains(propertyInfo.Name))
					{
						list.Add(propertyInfo.Name);
						stringBuilder.AppendLine("     public string " + propertyInfo.Name + "{get{ return GetValue(\"" + propertyInfo.Name + "\");} set{ SetValue( \"" + propertyInfo.Name + "\", value ); }}");
					}
				}
			}
			if (!bool_0)
			{
				stringBuilder.AppendLine(" }");
				stringBuilder.AppendLine("}");
			}
			return stringBuilder.ToString();
		}
	}
}

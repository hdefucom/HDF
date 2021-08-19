using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web.UI;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DCPublishAPI]
	public static class GClass38
	{
		private class Class72
		{
			private string string_0 = null;

			private string string_1 = null;

			private string string_2 = null;

			private Delegate delegate_0 = null;

			public string method_0()
			{
				return string_0;
			}

			public void method_1(string string_3)
			{
				string_0 = string_3;
			}

			public string method_2()
			{
				return string_1;
			}

			public void method_3(string string_3)
			{
				string_1 = string_3;
			}

			public string method_4()
			{
				return string_2;
			}

			public void method_5(string string_3)
			{
				string_2 = string_3;
			}

			public Delegate method_6()
			{
				return delegate_0;
			}

			public void method_7(Delegate delegate_1)
			{
				delegate_0 = delegate_1;
			}
		}

		private static List<Class72> list_0 = new List<Class72>();

		public static Delegate smethod_0(string string_0, string string_1, string string_2)
		{
			foreach (Class72 item in list_0)
			{
				if (item.method_0() == string_0 && item.method_2() == string_1 && item.method_4() == string_2)
				{
					return item.method_6();
				}
			}
			return null;
		}

		public static string smethod_1(Control control_0)
		{
			int num = 11;
			if (control_0.Page == null)
			{
				return "";
			}
			string fullName = control_0.Page.GetType().FullName;
			if (fullName.StartsWith("ASP.") && fullName.EndsWith("_aspx"))
			{
				fullName = control_0.Page.GetType().BaseType.FullName;
			}
			return fullName;
		}

		public static void smethod_2(Control control_0, string string_0)
		{
			int num = 9;
			if (control_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("eventName");
			}
			FieldInfo field = control_0.GetType().GetField(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (field != null)
			{
				Type fieldType = field.FieldType;
				if (!fieldType.IsSubclassOf(typeof(Delegate)))
				{
					throw new Exception(control_0.GetType().FullName + "." + string_0 + " 不是委托类型");
				}
				smethod_3(control_0, string_0, (Delegate)field.GetValue(control_0));
				return;
			}
			PropertyInfo property = control_0.GetType().GetProperty(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				if (!property.PropertyType.IsSubclassOf(typeof(Delegate)))
				{
					throw new Exception(control_0.GetType().FullName + "." + string_0 + " 不是委托类型");
				}
				smethod_3(control_0, string_0, (Delegate)property.GetValue(control_0, null));
				return;
			}
			throw new Exception("没找到属性或字段 " + control_0.GetType().FullName + "." + string_0);
		}

		public static void smethod_3(Control control_0, string string_0, Delegate delegate_0)
		{
			int num = 10;
			if (control_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("eventName");
			}
			Class72 @class = null;
			string text = smethod_1(control_0);
			string clientID = control_0.ClientID;
			foreach (Class72 item in list_0)
			{
				if (item.method_0() == text && item.method_2() == clientID && item.method_4() == string_0)
				{
					@class = item;
					break;
				}
			}
			if ((object)delegate_0 == null && @class != null)
			{
				list_0.Remove(@class);
				return;
			}
			if (@class == null)
			{
				@class = new Class72();
				@class.method_1(text);
				@class.method_3(clientID);
				@class.method_5(string_0);
				list_0.Add(@class);
			}
			@class.method_7(delegate_0);
		}
	}
}

using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DCInternal]
	public class GClass114
	{
		private static List<GClass114> list_0 = new List<GClass114>();

		private static List<GClass114> list_1 = new List<GClass114>();

		private Type type_0 = null;

		private string string_0 = null;

		private bool bool_0 = false;

		private List<GClass115> list_2 = new List<GClass115>();

		public static void smethod_0()
		{
			list_0.Clear();
			list_1.Clear();
		}

		public static GClass114 smethod_1(Type type_1, string string_1, bool bool_1)
		{
			int num = 15;
			if (type_1 == null)
			{
				if (bool_1)
				{
					throw new ArgumentNullException("rootType");
				}
				return null;
			}
			foreach (GClass114 item in list_0)
			{
				if (item.method_0().Equals(type_1) && string.Compare(item.method_1(), string_1, ignoreCase: false) == 0)
				{
					return item;
				}
			}
			foreach (GClass114 item2 in list_1)
			{
				if (item2.method_0() == type_1 && item2.method_1() == string_1)
				{
					if (bool_1)
					{
						throw new ArgumentOutOfRangeException("Type=" + type_1.FullName + " Path=" + string_1);
					}
					return null;
				}
			}
			GClass114 gClass = smethod_2(type_1, string_1, bool_1);
			if (gClass != null)
			{
				list_0.Add(gClass);
			}
			else
			{
				GClass114 gClass2 = new GClass114();
				gClass2.type_0 = type_1;
				gClass2.string_0 = string_1;
				list_1.Add(gClass2);
			}
			return gClass;
		}

		private static GClass114 smethod_2(Type type_1, string string_1, bool bool_1)
		{
			int num = 6;
			GClass114 gClass = new GClass114();
			gClass.type_0 = type_1;
			gClass.string_0 = string_1;
			if (string.IsNullOrEmpty(string_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = null;
				gClass2.method_1(type_1);
				gClass.list_2.Add(gClass2);
			}
			else if (typeof(XmlNode).IsAssignableFrom(type_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = string_1;
				gClass2.method_1(type_1);
				gClass2.method_5(GEnum16.const_1);
				gClass.list_2.Add(gClass2);
			}
			else if (typeof(DataRow).IsAssignableFrom(type_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = string_1;
				gClass2.method_1(type_1);
				gClass2.method_5(GEnum16.const_3);
				gClass.list_2.Add(gClass2);
			}
			else if (typeof(DataTable).IsAssignableFrom(type_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = string_1;
				gClass2.method_1(type_1);
				gClass2.method_5(GEnum16.const_3);
				gClass.list_2.Add(gClass2);
			}
			else if (typeof(DataRowView).IsAssignableFrom(type_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = string_1;
				gClass2.method_1(type_1);
				gClass2.method_5(GEnum16.const_3);
				gClass.list_2.Add(gClass2);
			}
			else if (typeof(IDataRecord).IsAssignableFrom(type_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = string_1;
				gClass2.method_1(type_1);
				gClass2.method_5(GEnum16.const_5);
				gClass.list_2.Add(gClass2);
			}
			else if (typeof(IDictionary).IsAssignableFrom(type_1))
			{
				GClass115 gClass2 = new GClass115();
				gClass2.Name = string_1;
				gClass2.method_1(type_1);
				gClass2.method_5(GEnum16.const_2);
				gClass.list_2.Add(gClass2);
			}
			else
			{
				string[] array = string_1.Split('.');
				Type type = gClass.type_0;
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i].Trim();
					if (string.IsNullOrEmpty(text))
					{
						GClass115 gClass2 = new GClass115();
						gClass2.method_1(type);
						gClass2.Name = null;
						type = typeof(string);
						gClass.list_2.Add(gClass2);
						continue;
					}
					PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);
					bool flag = false;
					foreach (PropertyDescriptor item in properties)
					{
						if (string.Compare(item.Name, text, ignoreCase: true) == 0)
						{
							GClass115 gClass2 = new GClass115();
							gClass2.method_1(type);
							gClass2.method_3(item);
							gClass2.Name = item.Name;
							gClass2.method_5(GEnum16.const_4);
							gClass.list_2.Add(gClass2);
							type = item.PropertyType;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						if (bool_1)
						{
							throw new NotSupportedException(type.FullName + "." + text);
						}
						return null;
					}
				}
			}
			gClass.bool_0 = false;
			GClass115 gClass3 = gClass.list_2[gClass.list_2.Count - 1];
			if (gClass3.method_4() == GEnum16.const_4)
			{
				if (gClass3.method_2() == null)
				{
					gClass.bool_0 = true;
				}
				else
				{
					gClass.bool_0 = gClass3.method_2().IsReadOnly;
				}
			}
			else if (gClass3.method_4() == GEnum16.const_3 || gClass3.method_4() == GEnum16.const_2 || gClass3.method_4() == GEnum16.const_1)
			{
				gClass.bool_0 = false;
			}
			else
			{
				gClass.bool_0 = true;
			}
			return gClass;
		}

		private GClass114()
		{
		}

		public Type method_0()
		{
			return type_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public List<GClass115> method_3()
		{
			return list_2;
		}

		public void method_4(List<GClass115> list_3)
		{
			list_2 = list_3;
		}
	}
}

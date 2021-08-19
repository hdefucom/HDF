using DCSoft.Writer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass104
	{
		private static List<GClass104> list_0 = new List<GClass104>();

		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private Image image_0 = null;

		private Type type_0 = null;

		private List<GClass133> list_1 = new List<GClass133>();

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

		public static List<GClass104> smethod_0()
		{
			return list_0;
		}

		public static void smethod_1(List<GClass104> list_2)
		{
			list_0 = list_2;
		}

		public static GClass104 smethod_2(Type type_1, bool bool_0)
		{
			int num = 0;
			if (type_1 == null)
			{
				if (bool_0)
				{
					throw new ArgumentNullException("moduleType");
				}
				return null;
			}
			if (!type_1.IsSubclassOf(typeof(WriterCommandModule)))
			{
				if (bool_0)
				{
					throw new ArgumentException(type_1.FullName);
				}
				return null;
			}
			GClass104 gClass = new GClass104();
			gClass.method_7(type_1);
			gClass.Name = type_1.Name;
			WriterCommandDescriptionAttribute writerCommandDescriptionAttribute = (WriterCommandDescriptionAttribute)Attribute.GetCustomAttribute(gClass.method_6(), typeof(WriterCommandDescriptionAttribute), inherit: false);
			if (writerCommandDescriptionAttribute != null)
			{
				gClass.Name = writerCommandDescriptionAttribute.Name;
				gClass.method_1(writerCommandDescriptionAttribute.Description);
				gClass.method_3(writerCommandDescriptionAttribute.ImageResource);
				string imageResource = writerCommandDescriptionAttribute.ImageResource;
				if (imageResource != null && imageResource.Trim().Length > 0)
				{
					gClass.method_5(GClass131.smethod_1(type_1.Assembly, imageResource.Trim()));
				}
			}
			if (gClass.method_0() == null || gClass.method_0().Trim().Length == 0)
			{
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(gClass.method_6(), typeof(DescriptionAttribute), inherit: true);
				if (descriptionAttribute != null)
				{
					gClass.method_1(descriptionAttribute.Description);
				}
			}
			MethodInfo[] methods = type_1.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			MethodInfo[] array = methods;
			foreach (MethodInfo methodInfo in array)
			{
				if (!methodInfo.DeclaringType.Equals(typeof(Form)) && !methodInfo.DeclaringType.Equals(typeof(Control)) && !methodInfo.DeclaringType.Equals(typeof(object)))
				{
					GClass133 gClass2 = GClass133.smethod_0(type_1, methodInfo, bool_1: false);
					if (gClass2 != null)
					{
						gClass.method_8().Add(gClass2);
					}
				}
			}
			gClass.method_8().Sort();
			return gClass;
		}

		public string method_0()
		{
			return string_1;
		}

		public void method_1(string string_3)
		{
			string_1 = string_3;
		}

		public string method_2()
		{
			return string_2;
		}

		public void method_3(string string_3)
		{
			string_2 = string_3;
		}

		public Image method_4()
		{
			return image_0;
		}

		public void method_5(Image image_1)
		{
			image_0 = image_1;
		}

		public Type method_6()
		{
			return type_0;
		}

		public void method_7(Type type_1)
		{
			type_0 = type_1;
		}

		public List<GClass133> method_8()
		{
			return list_1;
		}

		public void method_9(List<GClass133> list_2)
		{
			list_1 = list_2;
		}

		public override string ToString()
		{
			return "Module:" + Name;
		}
	}
}

using DCSoft.Common;
using DCSoft.Writer.Commands;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	
	public class GClass133 : IComparable
	{
		private GEnum6 genum6_0 = GEnum6.const_0;

		private bool bool_0 = false;

		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private Keys keys_0 = Keys.None;

		private int int_0 = 10;

		private string string_3 = null;

		private Image image_0 = null;

		private Type type_0 = null;

		private Type type_1 = null;

		private object object_0 = null;

		private MethodInfo methodInfo_0 = null;

		public static GClass133 smethod_0(Type type_2, MethodInfo methodInfo_1, bool bool_1)
		{
			int num = 11;
			if (type_2 == null && bool_1)
			{
				throw new ArgumentNullException("moduleType");
			}
			if (methodInfo_1 == null)
			{
				if (bool_1)
				{
					throw new ArgumentNullException("method");
				}
				return null;
			}
			WriterCommandDescriptionAttribute writerCommandDescriptionAttribute = (WriterCommandDescriptionAttribute)Attribute.GetCustomAttribute(methodInfo_1, typeof(WriterCommandDescriptionAttribute), inherit: false);
			ParameterInfo[] parameters = methodInfo_1.GetParameters();
			if (writerCommandDescriptionAttribute == null || !methodInfo_1.ReturnType.Equals(typeof(void)) || parameters == null || parameters.Length != 2)
			{
				if (bool_1)
				{
					throw new ArgumentException(type_2.FullName + "#" + methodInfo_1.Name);
				}
				return null;
			}
			if (parameters[0].ParameterType.Equals(typeof(object)) && parameters[1].ParameterType.Equals(typeof(WriterCommandEventArgs)))
			{
				string name = writerCommandDescriptionAttribute.Name;
				if (name == null || name.Trim().Length == 0)
				{
					name = methodInfo_1.Name;
				}
				GClass133 gClass = new GClass133();
				gClass.method_1(writerCommandDescriptionAttribute.FunctionID);
				gClass.method_5(name);
				gClass.method_19(type_2);
				gClass.method_25(methodInfo_1);
				gClass.method_11(writerCommandDescriptionAttribute.ShortcutKey);
				gClass.method_9(writerCommandDescriptionAttribute.ImageResource);
				gClass.method_15(writerCommandDescriptionAttribute.Description);
				gClass.method_21(writerCommandDescriptionAttribute.ReturnValueType);
				gClass.method_13(writerCommandDescriptionAttribute.Priority);
				ObsoleteAttribute obsoleteAttribute = (ObsoleteAttribute)Attribute.GetCustomAttribute(methodInfo_1, typeof(ObsoleteAttribute), inherit: true);
				if (obsoleteAttribute != null)
				{
					gClass.method_3(bool_1: true);
				}
				string text = writerCommandDescriptionAttribute.ImageResource;
				if (text == null || text.Trim().Length == 0)
				{
					text = type_2.Namespace + "." + name + ".bmp";
				}
				if (text != null)
				{
					gClass.method_17(GClass131.smethod_1(type_2.Assembly, text.Trim()));
				}
				if (gClass.method_14() == null || gClass.method_14().Trim().Length == 0)
				{
					DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo_1, typeof(DescriptionAttribute), inherit: true);
					if (descriptionAttribute != null)
					{
						gClass.method_15(descriptionAttribute.Description);
					}
				}
				return gClass;
			}
			if (bool_1)
			{
				throw new ArgumentException(type_2.FullName + "#" + methodInfo_1.Name);
			}
			return null;
		}

		public static GClass133 smethod_1(Type type_2, bool bool_1)
		{
			int num = 6;
			if (type_2 == null)
			{
				if (bool_1)
				{
					throw new ArgumentNullException("commandType");
				}
				return null;
			}
			if (!type_2.IsSubclassOf(typeof(WriterCommand)))
			{
				if (bool_1)
				{
					throw new ArgumentException(type_2.FullName);
				}
				return null;
			}
			WriterCommandDescriptionAttribute writerCommandDescriptionAttribute = (WriterCommandDescriptionAttribute)Attribute.GetCustomAttribute(type_2, typeof(WriterCommandDescriptionAttribute), inherit: false);
			GClass133 gClass = new GClass133();
			gClass.method_19(type_2);
			gClass.method_5(type_2.Name);
			if (writerCommandDescriptionAttribute != null)
			{
				gClass.method_1(writerCommandDescriptionAttribute.FunctionID);
				gClass.method_5(writerCommandDescriptionAttribute.Name);
				gClass.method_15(writerCommandDescriptionAttribute.Description);
				gClass.method_9(writerCommandDescriptionAttribute.ImageResource);
				gClass.method_11(writerCommandDescriptionAttribute.ShortcutKey);
				gClass.method_23(writerCommandDescriptionAttribute.DefaultResultValue);
				gClass.method_13(writerCommandDescriptionAttribute.Priority);
				string imageResource = writerCommandDescriptionAttribute.ImageResource;
				if (imageResource != null && imageResource.Trim().Length > 0)
				{
					gClass.method_17(GClass131.smethod_1(type_2.Assembly, imageResource.Trim()));
				}
			}
			if (gClass.method_14() == null || gClass.method_14().Trim().Length == 0)
			{
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(type_2, typeof(DescriptionAttribute), inherit: true);
				if (descriptionAttribute != null)
				{
					gClass.method_15(descriptionAttribute.Description);
				}
			}
			return gClass;
		}

		public GEnum6 method_0()
		{
			return genum6_0;
		}

		public void method_1(GEnum6 genum6_1)
		{
			genum6_0 = genum6_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_4)
		{
			string_0 = string_4;
		}

		public string method_6()
		{
			return string_1;
		}

		public void method_7(string string_4)
		{
			string_1 = string_4;
		}

		public string method_8()
		{
			return string_2;
		}

		public void method_9(string string_4)
		{
			string_2 = string_4;
		}

		public Keys method_10()
		{
			return keys_0;
		}

		public void method_11(Keys keys_1)
		{
			keys_0 = keys_1;
		}

		public int method_12()
		{
			return int_0;
		}

		public void method_13(int int_1)
		{
			int_0 = int_1;
		}

		public string method_14()
		{
			return string_3;
		}

		public void method_15(string string_4)
		{
			string_3 = string_4;
		}

		public Image method_16()
		{
			return image_0;
		}

		public void method_17(Image image_1)
		{
			image_0 = image_1;
		}

		public Type method_18()
		{
			return type_0;
		}

		public void method_19(Type type_2)
		{
			type_0 = type_2;
		}

		public Type method_20()
		{
			return type_1;
		}

		public void method_21(Type type_2)
		{
			type_1 = type_2;
		}

		public object method_22()
		{
			if (object_0 == null && method_20() != null)
			{
				return ValueTypeHelper.GetDefaultValue(method_20());
			}
			return object_0;
		}

		public void method_23(object object_1)
		{
			object_0 = object_1;
		}

		public MethodInfo method_24()
		{
			return methodInfo_0;
		}

		public void method_25(MethodInfo methodInfo_1)
		{
			methodInfo_0 = methodInfo_1;
		}

		public override string ToString()
		{
			return "Command:" + method_4();
		}

		int IComparable.CompareTo(object object_1)
		{
			if (object_1 is GClass133)
			{
				return string.Compare(method_4(), ((GClass133)object_1).method_4(), ignoreCase: true);
			}
			return 0;
		}
	}
}

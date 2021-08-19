using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace DCSoftDotfuscate
{
	internal static class Class103
	{
		private static GClass138 gclass138_0 = null;

		private static Random random_0 = new Random();

		private static FieldInfo smethod_0(Type type_0, string string_0)
		{
			FieldInfo[] fields = type_0.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			int num = 0;
			FieldInfo fieldInfo;
			while (true)
			{
				if (num < fields.Length)
				{
					fieldInfo = fields[num];
					DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), inherit: false);
					if (descriptionAttribute != null && descriptionAttribute.Description == string_0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return fieldInfo;
		}

		private static void smethod_1(Type type_0, object object_0, string string_0, object object_1)
		{
			FieldInfo fieldInfo = smethod_0(type_0, string_0);
			if (fieldInfo != null)
			{
				if (fieldInfo.IsStatic)
				{
					fieldInfo.SetValue(null, object_1);
				}
				else if (object_0 != null)
				{
					fieldInfo.SetValue(object_0, object_1);
				}
			}
		}

		private static string smethod_2(Type type_0, object object_0, string string_0)
		{
			FieldInfo fieldInfo = smethod_0(type_0, string_0);
			if (fieldInfo != null)
			{
				if (fieldInfo.IsStatic)
				{
					return (string)fieldInfo.GetValue(null);
				}
				if (object_0 != null)
				{
					return (string)fieldInfo.GetValue(object_0);
				}
			}
			return null;
		}

		internal static GClass138 smethod_3(GClass138 gclass138_1, int int_0)
		{
			Type type = ControlHelper.GetControlType("DCSoft.Writer.Controls.AxWriterControl", null);
			if (type == null)
			{
				type = typeof(XTextDocument);
			}
			return GClass145.smethod_0(gclass138_1, int_0, typeof(XTextDocument), DCPublishDateAttribute.GetValue(type.Assembly));
		}

		internal static GClass138 smethod_4()
		{
			int int_ = 4;
			if (XTextDocument.bool_27)
			{
				int_ = 8;
			}
			GClass138 gClass = smethod_3(gclass138_0, int_);
			if (gClass != gclass138_0)
			{
				gclass138_0 = gClass;
				if (!gclass138_0.method_34())
				{
					XTextDocument.genum13_1 = GEnum13.const_2;
				}
				else
				{
					XTextDocument.genum13_1 = (GEnum13)gclass138_0.method_41();
				}
				string name = "_LicenseLevel";
				typeof(XTextDocument).GetField(name, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic)?.SetValue(null, gclass138_0.method_41());
				Class126.smethod_4();
				string name2 = "DCSoft.Writer.Controls.dlgAbout";
				Type type = typeof(Class103).Assembly.GetType(name2, throwOnError: false, ignoreCase: true);
				if (type != null)
				{
					string name3 = "LicnesedUserName";
					type.GetField(name3, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(null, gclass138_0.method_33());
				}
				string name4 = "_MULSP";
				FieldInfo field = typeof(XTextDocument).GetField(name4, BindingFlags.Static | BindingFlags.NonPublic);
				if (field != null && gclass138_0.method_33() != null)
				{
					string value = "南京都昌";
					int[] array = new int[2]
					{
						32372,
						19847
					};
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append((char)(array[0] + 480));
					stringBuilder.Append((char)(array[1] + 400));
					string value2 = stringBuilder.ToString();
					if (gclass138_0.method_33().IndexOf(value) >= 0 || gclass138_0.method_33().IndexOf(value2) >= 0)
					{
						field.SetValue(null, 0);
					}
					else
					{
						field.SetValue(null, 2);
					}
					if (gclass138_0.method_27())
					{
						field.SetValue(null, 0);
					}
				}
			}
			return gclass138_0;
		}

		internal static bool smethod_5()
		{
			if (random_0.NextDouble() < 0.001)
			{
				bool result;
				if ((result = smethod_4().method_9()) && (Debugger.IsAttached || Debugger.IsLogging()))
				{
					return false;
				}
				return result;
			}
			return false;
		}

		internal static GClass472 smethod_6(WriterViewControl writerViewControl_0)
		{
			GClass472 gClass = XTextDocument.smethod_6((writerViewControl_0 != null && writerViewControl_0.InDesignMode) || Debugger.IsAttached);
			if (writerViewControl_0 != null)
			{
				string name = "_AdditionPageTitle";
				FieldInfo field = writerViewControl_0.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
				if (field != null)
				{
					string text = Convert.ToString(field.GetValue(writerViewControl_0));
					if (text != null && text.Length > 0)
					{
						gClass.method_9(gClass.method_8() + text);
					}
				}
			}
			if (!XTextDocument.IsAssemblyObfuscation && (writerViewControl_0 == null || !writerViewControl_0.DocumentOptions.BehaviorOptions.SpecifyDebugMode))
			{
				gClass.method_23(bool_7: true);
				gClass.method_25(bool_7: true);
			}
			if (!gClass.method_22())
			{
				gClass.method_21(GClass530.smethod_0(writerViewControl_0));
			}
			if (string.IsNullOrEmpty(gClass.method_8()))
			{
				return null;
			}
			return gClass;
		}
	}
}

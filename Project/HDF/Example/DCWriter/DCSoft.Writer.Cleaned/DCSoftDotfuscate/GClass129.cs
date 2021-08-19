using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass129
	{
		private static Type type_0 = typeof(object);

		private static Dictionary<string, Type> dictionary_0 = new Dictionary<string, Type>();

		private static Type type_1 = null;

		public static Type smethod_0(string string_0)
		{
			int num = 16;
			Type type;
			if (dictionary_0.ContainsKey(string_0))
			{
				type = dictionary_0[string_0];
				if (type == type_0)
				{
					return null;
				}
				return type;
			}
			type = type_0;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				if (assembly.FullName.IndexOf("PresentationCore") >= 0)
				{
					type = assembly.GetType(string_0, throwOnError: false, ignoreCase: true);
					if (type != null)
					{
						break;
					}
				}
				if (assembly.FullName.IndexOf("PresentationFramework") >= 0)
				{
					type = assembly.GetType(string_0, throwOnError: false, ignoreCase: true);
					if (type != null)
					{
						break;
					}
				}
			}
			dictionary_0[string_0] = type;
			if (type == type_0)
			{
				return null;
			}
			return type;
		}

		public static Type smethod_1()
		{
			return smethod_0("System.Windows.UIElement");
		}

		public static Type smethod_2()
		{
			int num = 14;
			if (type_1 == null)
			{
				type_1 = type_0;
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (assembly.FullName.IndexOf("WindowsFormsIntegration") >= 0)
					{
						type_1 = assembly.GetType("System.Windows.Forms.Integration.ElementHost", throwOnError: false, ignoreCase: true);
						break;
					}
				}
			}
			if (type_1 == type_0)
			{
				return null;
			}
			return type_1;
		}

		public static bool smethod_3(Type type_2)
		{
			int num = 19;
			if (type_2 == null)
			{
				return false;
			}
			return smethod_0("System.Windows.UIElement")?.IsAssignableFrom(type_2) ?? false;
		}

		public static bool smethod_4(object object_0)
		{
			int num = 7;
			if (object_0 == null)
			{
				return false;
			}
			return smethod_0("System.Windows.UIElement")?.IsInstanceOfType(object_0) ?? false;
		}

		public static Control smethod_5(object object_0)
		{
			int num = 19;
			if (smethod_2() != null)
			{
				Control control = (Control)Activator.CreateInstance(smethod_2());
				if (object_0 != null)
				{
					control.GetType().GetProperty("Child")?.SetValue(control, object_0, null);
				}
				return control;
			}
			return null;
		}

		public static void smethod_6(Control control_0)
		{
			int num = 17;
			if (control_0 != null && smethod_2() != null && smethod_2().IsInstanceOfType(control_0))
			{
				control_0.GetType().GetProperty("Child")?.SetValue(control_0, null, null);
			}
		}

		public static object smethod_7(Control control_0)
		{
			int num = 4;
			if (smethod_2() != null && smethod_2().IsInstanceOfType(control_0))
			{
				PropertyInfo property = control_0.GetType().GetProperty("Child");
				if (property != null)
				{
					return property.GetValue(control_0, null);
				}
			}
			return null;
		}

		public static Size smethod_8(object object_0)
		{
			int num = 11;
			if (smethod_4(object_0))
			{
				Type type = object_0.GetType();
				object value = type.GetProperty("RenderSize").GetValue(object_0, null);
				if (value != null)
				{
					double num2 = (double)value.GetType().GetProperty("Width").GetValue(value, null);
					double num3 = (double)value.GetType().GetProperty("Height").GetValue(value, null);
					if (num2 == 0.0 || num3 == 0.0)
					{
						num2 = (double)type.GetProperty("Width").GetValue(object_0, null);
						num3 = (double)type.GetProperty("Height").GetValue(object_0, null);
					}
					return new Size((int)num2, (int)num3);
				}
			}
			return Size.Empty;
		}

		public static Image smethod_9(object object_0, int int_0, int int_1)
		{
			int num = 18;
			if (object_0 == null)
			{
				throw new ArgumentNullException("wpfElement");
			}
			if (!smethod_4(object_0))
			{
				throw new ArgumentException(object_0.GetType().FullName + " 不是WPF元素类型");
			}
			Type type = smethod_0("System.Windows.Media.Imaging.RenderTargetBitmap");
			if (type != null)
			{
				Type type2 = smethod_0("System.Windows.Media.PixelFormats");
				object obj = Activator.CreateInstance(type, int_0, int_1, 96, 96, type2.GetProperty("Pbgra32").GetValue(null, null));
				obj.GetType().GetMethod("Render").Invoke(obj, new object[1]
				{
					object_0
				});
				object value = smethod_0("System.Windows.Media.Imaging.BitmapFrame").GetMethod("Create", new Type[1]
				{
					smethod_0("System.Windows.Media.Imaging.BitmapFrame")
				}).Invoke(null, new object[1]
				{
					obj
				});
				object obj2 = Activator.CreateInstance(smethod_0("System.Windows.Media.Imaging.PngBitmapEncoder"));
				object value2 = obj2.GetType().GetProperty("Frames").GetValue(obj2, null);
				((IList)value2).Add(value);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					obj2.GetType().GetMethod("Save").Invoke(obj2, new object[1]
					{
						memoryStream
					});
					memoryStream.Position = 0L;
					return Image.FromStream(memoryStream);
				}
			}
			return null;
		}
	}
}

using System;
using System.IO;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	public class GClass273
	{
		private static GClass273 gclass273_0 = new GClass273();

		private Form form_0 = null;

		private string string_0 = null;

		private string string_1 = "sdk/";

		public static GClass273 smethod_0()
		{
			return gclass273_0;
		}

		public static void smethod_1(GClass273 gclass273_1)
		{
			gclass273_0 = gclass273_1;
		}

		public GClass273()
		{
			string[] files = Directory.GetFiles(Application.StartupPath, "*.chm");
			if (files != null && files.Length > 0)
			{
				string_0 = files[0];
			}
		}

		public Form method_0()
		{
			return form_0;
		}

		public void method_1(Form form_1)
		{
			form_0 = form_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_2)
		{
			string_0 = string_2;
		}

		public bool method_4()
		{
			return File.Exists(string_0);
		}

		public string method_5()
		{
			return string_1;
		}

		public void method_6(string string_2)
		{
			string_1 = string_2;
		}

		public void method_7(Type type_0)
		{
			int num = 16;
			if (type_0 == null)
			{
				method_9(null);
			}
			else
			{
				method_9(string_1 + type_0.FullName + ".html");
			}
		}

		public void method_8(Type type_0, string string_2)
		{
			int num = 12;
			if (type_0 == null)
			{
				method_9(null);
			}
			else if (string_2 == null || string_2.Length == 0)
			{
				method_9(string_1 + type_0.FullName + ".html");
			}
			else
			{
				method_9(string_1 + type_0.FullName + "." + string_2 + ".html");
			}
		}

		public void method_9(string string_2)
		{
			int num = 12;
			if (File.Exists(string_0))
			{
				if (string_2 == null)
				{
					Help.ShowHelp(form_0, string_0);
				}
				else
				{
					Help.ShowHelp(form_0, string_0, string_2);
				}
			}
			else
			{
				MessageBox.Show(form_0, "未找到帮助文件 " + string_0 + "!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}
}

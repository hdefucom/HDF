using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass404
	{
		private int int_0 = 0;

		private int int_1 = 0;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private string string_0 = null;

		private string string_1 = null;

		private List<GClass405> list_0 = new List<GClass405>();

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_2)
		{
			int_1 = int_2;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_6()
		{
			return bool_1;
		}

		public void method_7(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public string method_8()
		{
			return string_0;
		}

		public void method_9(string string_2)
		{
			string_0 = string_2;
		}

		public string method_10()
		{
			return string_1;
		}

		public void method_11(string string_2)
		{
			string_1 = string_2;
		}

		public List<GClass405> method_12()
		{
			if (list_0 == null)
			{
				list_0 = new List<GClass405>();
			}
			return list_0;
		}

		public void method_13(List<GClass405> list_1)
		{
			list_0 = list_1;
		}

		public GClass405 method_14(int int_2)
		{
			if (method_12().Count <= int_2)
			{
				for (int i = method_12().Count; i <= int_2; i++)
				{
					method_12().Add(new GClass405());
				}
			}
			if (int_2 < 0)
			{
				if (method_12().Count == 0)
				{
					method_12().Add(new GClass405());
				}
				return method_12()[0];
			}
			return method_12()[int_2];
		}

		public GClass405 method_15(int int_2)
		{
			if (int_2 >= 0 && int_2 < method_12().Count)
			{
				return method_12()[int_2];
			}
			if (method_12().Count > 0)
			{
				return method_12()[0];
			}
			return null;
		}

		public override string ToString()
		{
			return "ID:" + method_0() + " TemplateID:" + method_2();
		}
	}
}

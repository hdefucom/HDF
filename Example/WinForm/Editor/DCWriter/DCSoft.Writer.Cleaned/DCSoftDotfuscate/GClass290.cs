using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass290
	{
		private GEnum69 genum69_0 = GEnum69.const_0;

		private string string_0 = null;

		private static readonly string[] string_1 = new string[0];

		private string[] string_2 = string_1;

		private object object_0 = null;

		private string string_3 = null;

		private string string_4 = null;

		private int int_0 = -1;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private DateTime dateTime_0 = DateTime.MinValue;

		private string string_5 = null;

		private Color color_0 = SystemColors.WindowText;

		private Color color_1 = SystemColors.Window;

		private object object_1 = null;

		private Image image_0 = null;

		private string string_6 = null;

		private string string_7 = null;

		private string string_8 = null;

		private char char_0 = ' ';

		private List<GClass290> list_0 = null;

		private bool bool_3 = true;

		private bool bool_4 = false;

		private int int_1 = 0;

		private object object_2 = null;

		private int int_2 = 0;

		private int int_3 = 0;

		private GClass290 gclass290_0 = null;

		public GEnum69 method_0()
		{
			return genum69_0;
		}

		public void method_1(GEnum69 genum69_1)
		{
			genum69_0 = genum69_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_9)
		{
			string_0 = string_9;
			string_2 = string_1;
		}

		internal string[] method_4(GControl5 gcontrol5_0)
		{
			if (string_2 == string_1)
			{
				if (string.IsNullOrEmpty(method_2()))
				{
					string_2 = null;
				}
				else if (gcontrol5_0.method_2())
				{
					string_2 = method_2().Split(gcontrol5_0.method_4());
				}
				else
				{
					string_2 = new string[1]
					{
						method_2()
					};
				}
			}
			return string_2;
		}

		public object method_5()
		{
			return object_0;
		}

		public void method_6(object object_3)
		{
			object_0 = object_3;
		}

		public string method_7()
		{
			return string_3;
		}

		public void method_8(string string_9)
		{
			string_3 = string_9;
		}

		public string method_9()
		{
			return string_4;
		}

		public void method_10(string string_9)
		{
			string_4 = string_9;
		}

		public int method_11()
		{
			return int_0;
		}

		public void method_12(int int_4)
		{
			int_0 = int_4;
		}

		public bool method_13()
		{
			return bool_0;
		}

		public void method_14(bool bool_5)
		{
			bool_0 = bool_5;
		}

		public bool method_15()
		{
			return bool_1;
		}

		public void method_16(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public bool method_17()
		{
			return bool_2;
		}

		public void method_18(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public DateTime method_19()
		{
			return dateTime_0;
		}

		public void method_20(DateTime dateTime_1)
		{
			dateTime_0 = dateTime_1;
		}

		public string method_21()
		{
			return string_5;
		}

		public void method_22(string string_9)
		{
			string_5 = string_9;
		}

		public Color method_23()
		{
			return color_0;
		}

		public void method_24(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_25()
		{
			return color_1;
		}

		public void method_26(Color color_2)
		{
			color_1 = color_2;
		}

		public object method_27()
		{
			return object_1;
		}

		public void method_28(object object_3)
		{
			object_1 = object_3;
		}

		public Image method_29()
		{
			return image_0;
		}

		public void method_30(Image image_1)
		{
			image_0 = image_1;
		}

		public string method_31()
		{
			return string_6;
		}

		public void method_32(string string_9)
		{
			string_6 = string_9;
		}

		public string method_33()
		{
			return string_7;
		}

		public void method_34(string string_9)
		{
			string_7 = string_9;
		}

		public string method_35()
		{
			return string_8;
		}

		public void method_36(string string_9)
		{
			string_8 = string_9;
		}

		public char method_37()
		{
			return char_0;
		}

		public void method_38(char char_1)
		{
			char_0 = char_1;
		}

		public List<GClass290> method_39()
		{
			return list_0;
		}

		public void method_40(List<GClass290> list_1)
		{
			list_0 = list_1;
		}

		public bool method_41()
		{
			return bool_3;
		}

		public void method_42(bool bool_5)
		{
			bool_3 = bool_5;
		}

		public bool method_43()
		{
			return bool_4;
		}

		public void method_44(bool bool_5)
		{
			bool_4 = bool_5;
		}

		public int method_45()
		{
			return int_1;
		}

		public void method_46(int int_4)
		{
			int_1 = int_4;
		}

		public object method_47()
		{
			return object_2;
		}

		public void method_48(object object_3)
		{
			object_2 = object_3;
		}

		internal int method_49()
		{
			return int_2;
		}

		internal void method_50(int int_4)
		{
			int_2 = int_4;
		}

		internal int method_51()
		{
			return int_3;
		}

		internal void method_52(int int_4)
		{
			int_3 = int_4;
		}

		internal GClass290 method_53()
		{
			return gclass290_0;
		}

		internal void method_54(GClass290 gclass290_1)
		{
			gclass290_0 = gclass290_1;
		}
	}
}

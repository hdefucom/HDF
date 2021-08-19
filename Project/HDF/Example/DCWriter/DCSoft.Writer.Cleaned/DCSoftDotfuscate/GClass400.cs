using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass400 : GClass383
	{
		private string string_0 = null;

		private byte[] byte_0 = null;

		private int int_1 = 100;

		private int int_2 = 100;

		private int int_3 = 0;

		private int int_4 = 0;

		private int int_5 = 0;

		private int int_6 = 0;

		private GEnum86 genum86_0 = GEnum86.const_2;

		private GClass425 gclass425_0 = new GClass425();

		public string method_17()
		{
			return string_0;
		}

		public void method_18(string string_1)
		{
			string_0 = string_1;
		}

		public byte[] method_19()
		{
			return byte_0;
		}

		public void method_20(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public string method_21()
		{
			if (byte_0 == null)
			{
				return null;
			}
			return Convert.ToBase64String(byte_0);
		}

		public void method_22(string string_1)
		{
			if (string_1 != null && string_1.Length > 0)
			{
				byte_0 = Convert.FromBase64String(string_1);
			}
			else
			{
				byte_0 = null;
			}
		}

		public int method_23()
		{
			return int_1;
		}

		public void method_24(int int_7)
		{
			int_1 = int_7;
		}

		public int method_25()
		{
			return int_2;
		}

		public void method_26(int int_7)
		{
			int_2 = int_7;
		}

		public int method_27()
		{
			return int_3;
		}

		public void method_28(int int_7)
		{
			int_3 = int_7;
		}

		public int method_29()
		{
			return int_4;
		}

		public void method_30(int int_7)
		{
			int_4 = int_7;
		}

		public int method_31()
		{
			return int_5;
		}

		public void method_32(int int_7)
		{
			int_5 = int_7;
		}

		public int method_33()
		{
			return int_6;
		}

		public void method_34(int int_7)
		{
			int_6 = int_7;
		}

		public GEnum86 method_35()
		{
			return genum86_0;
		}

		public void method_36(GEnum86 genum86_1)
		{
			genum86_0 = genum86_1;
		}

		public GClass425 method_37()
		{
			return gclass425_0;
		}

		public void method_38(GClass425 gclass425_1)
		{
			gclass425_0 = gclass425_1;
		}

		public override string ToString()
		{
			int num = 6;
			string text = "Image:" + int_5 + "*" + int_6;
			if (byte_0 != null && byte_0.Length > 0)
			{
				text = text + " " + Convert.ToDouble((double)byte_0.Length / 1024.0).ToString("0.00") + "KB";
			}
			return text;
		}
	}
}

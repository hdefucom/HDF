using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass389 : GClass383
	{
		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		private GEnum81 genum81_0 = GEnum81.const_0;

		private string string_0 = null;

		private string string_1 = null;

		private byte[] byte_0 = null;

		private int int_1 = 0;

		private int int_2 = 0;

		private int int_3 = 100;

		private int int_4 = 100;

		public string Name
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		public Dictionary<string, string> method_17()
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<string, string>();
			}
			return dictionary_0;
		}

		public void method_18(Dictionary<string, string> dictionary_1)
		{
			dictionary_0 = dictionary_1;
		}

		public GEnum81 method_19()
		{
			return genum81_0;
		}

		public void method_20(GEnum81 genum81_1)
		{
			genum81_0 = genum81_1;
		}

		public string method_21()
		{
			return string_0;
		}

		public void method_22(string string_2)
		{
			string_0 = string_2;
		}

		public byte[] method_23()
		{
			return byte_0;
		}

		public void method_24(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public string method_25()
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			return Encoding.Default.GetString(byte_0);
		}

		public int method_26()
		{
			return int_1;
		}

		public void method_27(int int_5)
		{
			int_1 = int_5;
		}

		public int method_28()
		{
			return int_2;
		}

		public void method_29(int int_5)
		{
			int_2 = int_5;
		}

		public int method_30()
		{
			return int_3;
		}

		public void method_31(int int_5)
		{
			int_3 = int_5;
		}

		public int method_32()
		{
			return int_4;
		}

		public void method_33(int int_5)
		{
			int_4 = int_5;
		}

		public override string ToString()
		{
			int num = 7;
			string text = "Object:" + method_26() + "*" + method_28();
			if (byte_0 != null && byte_0.Length > 0)
			{
				text = text + " " + Convert.ToDouble((double)byte_0.Length / 1024.0).ToString("0.00") + "KB";
			}
			return text;
		}

		public GClass399 method_34()
		{
			int num = 17;
			foreach (GClass383 item in method_5())
			{
				if (item is GClass399)
				{
					GClass399 gClass2 = (GClass399)item;
					if (gClass2.Name == "result")
					{
						return gClass2;
					}
				}
			}
			return null;
		}
	}
}

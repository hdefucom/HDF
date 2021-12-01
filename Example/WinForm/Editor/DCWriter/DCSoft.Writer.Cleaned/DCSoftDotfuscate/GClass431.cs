using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass431
	{
		private int int_0 = 0;

		private bool bool_0 = false;

		private string string_0 = null;

		private int int_1 = 1;

		private static Dictionary<int, Encoding> dictionary_0 = null;

		private Encoding encoding_0 = null;

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

		public GClass431(int int_2, string string_1)
		{
			int_0 = int_2;
			string_0 = string_1;
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public int method_4()
		{
			return int_1;
		}

		public void method_5(int int_2)
		{
			int_1 = int_2;
			encoding_0 = smethod_2(int_1);
		}

		private static void smethod_0()
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<int, Encoding>();
				dictionary_0[77] = Encoding.GetEncoding(10000);
				dictionary_0[128] = Encoding.GetEncoding(932);
				dictionary_0[130] = Encoding.GetEncoding(1361);
				dictionary_0[134] = Encoding.GetEncoding(936);
				dictionary_0[136] = Encoding.GetEncoding(10002);
				dictionary_0[161] = Encoding.GetEncoding(1253);
				dictionary_0[162] = Encoding.GetEncoding(1254);
				dictionary_0[163] = Encoding.GetEncoding(1258);
				dictionary_0[177] = Encoding.GetEncoding(1255);
				dictionary_0[178] = Encoding.GetEncoding(864);
				dictionary_0[179] = Encoding.GetEncoding(864);
				dictionary_0[180] = Encoding.GetEncoding(864);
				dictionary_0[181] = Encoding.GetEncoding(864);
				dictionary_0[186] = Encoding.GetEncoding(775);
				dictionary_0[204] = Encoding.GetEncoding(866);
				dictionary_0[222] = Encoding.GetEncoding(874);
				dictionary_0[255] = Encoding.GetEncoding(437);
			}
		}

		internal static int smethod_1(Encoding encoding_1)
		{
			smethod_0();
			foreach (int key in dictionary_0.Keys)
			{
				if (dictionary_0[key] == encoding_1)
				{
					return key;
				}
			}
			return 1;
		}

		internal static Encoding smethod_2(int int_2)
		{
			switch (int_2)
			{
			case 0:
				return Class203.class203_0;
			case 1:
				return Encoding.Default;
			default:
				smethod_0();
				if (dictionary_0.ContainsKey(int_2))
				{
					return dictionary_0[int_2];
				}
				return null;
			}
		}

		public Encoding method_6()
		{
			return encoding_0;
		}

		public GClass431 method_7()
		{
			GClass431 gClass = new GClass431(int_0, string_0);
			gClass.int_1 = int_1;
			gClass.int_0 = int_0;
			gClass.encoding_0 = encoding_0;
			gClass.string_0 = string_0;
			return gClass;
		}

		public override string ToString()
		{
			return int_0 + ":" + string_0 + " Charset:" + int_1;
		}
	}
}

using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass656 : GClass655
	{
		private static Hashtable hashtable_0;

		private static Hashtable hashtable_1;

		private string string_0;

		public string method_0()
		{
			return string_0;
		}

		private static void smethod_1()
		{
			hashtable_0 = Hashtable.Synchronized(new Hashtable(29));
			hashtable_1 = Hashtable.Synchronized(new Hashtable(29));
			smethod_2(0, "Cp437");
			smethod_3(1, new string[2]
			{
				"ISO8859_1",
				"ISO-8859-1"
			});
			smethod_2(2, "Cp437");
			smethod_3(3, new string[2]
			{
				"ISO8859_1",
				"ISO-8859-1"
			});
			smethod_2(4, "ISO8859_2");
			smethod_2(5, "ISO8859_3");
			smethod_2(6, "ISO8859_4");
			smethod_2(7, "ISO8859_5");
			smethod_2(8, "ISO8859_6");
			smethod_2(9, "ISO8859_7");
			smethod_2(10, "ISO8859_8");
			smethod_2(11, "ISO8859_9");
			smethod_2(12, "ISO8859_10");
			smethod_2(13, "ISO8859_11");
			smethod_2(15, "ISO8859_13");
			smethod_2(16, "ISO8859_14");
			smethod_2(17, "ISO8859_15");
			smethod_2(18, "ISO8859_16");
			smethod_3(20, new string[2]
			{
				"SJIS",
				"Shift_JIS"
			});
		}

		private GClass656(int int_1, string string_1)
			: base(int_1)
		{
			string_0 = string_1;
		}

		private static void smethod_2(int int_1, string string_1)
		{
			GClass656 value = new GClass656(int_1, string_1);
			hashtable_0[int_1] = value;
			hashtable_1[string_1] = value;
		}

		private static void smethod_3(int int_1, string[] string_1)
		{
			GClass656 value = new GClass656(int_1, string_1[0]);
			hashtable_0[int_1] = value;
			for (int i = 0; i < string_1.Length; i++)
			{
				hashtable_1[string_1[i]] = value;
			}
		}

		public static GClass656 smethod_4(int int_1)
		{
			int num = 16;
			if (hashtable_0 == null)
			{
				smethod_1();
			}
			if (int_1 < 0 || int_1 >= 900)
			{
				throw new ArgumentException("Bad ECI value: " + int_1);
			}
			return (GClass656)hashtable_0[int_1];
		}

		public static GClass656 smethod_5(string string_1)
		{
			if (hashtable_1 == null)
			{
				smethod_1();
			}
			return (GClass656)hashtable_1[string_1];
		}
	}
}

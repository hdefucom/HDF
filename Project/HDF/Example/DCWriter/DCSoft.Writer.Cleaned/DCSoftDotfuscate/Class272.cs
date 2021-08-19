using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class272
	{
		private const string string_0 = "SJIS";

		private const string string_1 = "EUC_JP";

		private const string string_2 = "UTF-8";

		private const string string_3 = "ISO-8859-1";

		private static readonly char[] char_0;

		private static bool bool_0;

		private Class272()
		{
		}

		internal static GClass678 smethod_0(sbyte[] sbyte_0, GClass672 gclass672_0, GClass636 gclass636_0)
		{
			GClass657 gClass = new GClass657(sbyte_0);
			StringBuilder stringBuilder = new StringBuilder(50);
			GClass656 gClass2 = null;
			bool bool_ = false;
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(1));
			GClass653 gClass3;
			do
			{
				if (gClass.method_1() >= 4)
				{
					try
					{
						gClass3 = GClass653.smethod_0(gClass.method_0(4));
					}
					catch (ArgumentException)
					{
						throw GException25.smethod_0();
					}
				}
				else
				{
					gClass3 = GClass653.gclass653_0;
				}
				if (gClass3.Equals(GClass653.gclass653_0))
				{
					continue;
				}
				if (gClass3.Equals(GClass653.gclass653_7) || gClass3.Equals(GClass653.gclass653_8))
				{
					bool_ = true;
					continue;
				}
				if (gClass3.Equals(GClass653.gclass653_3))
				{
					gClass.method_0(16);
					continue;
				}
				if (gClass3.Equals(GClass653.gclass653_5))
				{
					int int_ = smethod_6(gClass);
					gClass2 = GClass656.smethod_4(int_);
					if (gClass2 == null)
					{
						throw GException25.smethod_0();
					}
					continue;
				}
				int int_2 = gClass.method_0(gClass3.method_1(gclass672_0));
				if (gClass3.Equals(GClass653.gclass653_1))
				{
					smethod_4(gClass, stringBuilder, int_2);
					continue;
				}
				if (gClass3.Equals(GClass653.gclass653_2))
				{
					smethod_3(gClass, stringBuilder, int_2, bool_);
					continue;
				}
				if (gClass3.Equals(GClass653.gclass653_4))
				{
					smethod_2(gClass, stringBuilder, int_2, gClass2, arrayList);
					continue;
				}
				if (gClass3.Equals(GClass653.gclass653_6))
				{
					smethod_1(gClass, stringBuilder, int_2);
					continue;
				}
				throw GException25.smethod_0();
			}
			while (!gClass3.Equals(GClass653.gclass653_0));
			return new GClass678(sbyte_0, stringBuilder.ToString(), (arrayList.Count == 0) ? null : arrayList, gclass636_0);
		}

		private static void smethod_1(GClass657 gclass657_0, StringBuilder stringBuilder_0, int int_0)
		{
			int num = 12;
			sbyte[] array = new sbyte[2 * int_0];
			int num2 = 0;
			while (int_0 > 0)
			{
				int num3 = gclass657_0.method_0(13);
				int num4 = (num3 / 192 << 8) | (num3 % 192);
				num4 = ((num4 >= 7936) ? (num4 + 49472) : (num4 + 33088));
				array[num2] = (sbyte)(num4 >> 8);
				array[num2 + 1] = (sbyte)num4;
				num2 += 2;
				int_0--;
			}
			try
			{
				stringBuilder_0.Append(Encoding.GetEncoding("SJIS").GetString(GClass634.smethod_0(array)));
			}
			catch (IOException)
			{
				throw GException25.smethod_0();
			}
		}

		private static void smethod_2(GClass657 gclass657_0, StringBuilder stringBuilder_0, int int_0, GClass656 gclass656_0, ArrayList arrayList_0)
		{
			sbyte[] array = new sbyte[int_0];
			if (int_0 << 3 > gclass657_0.method_1())
			{
				throw GException25.smethod_0();
			}
			for (int i = 0; i < int_0; i++)
			{
				array[i] = (sbyte)gclass657_0.method_0(8);
			}
			string name = (gclass656_0 != null) ? gclass656_0.method_0() : smethod_5(array);
			try
			{
				stringBuilder_0.Append(Encoding.GetEncoding(name).GetString(GClass634.smethod_0(array)));
			}
			catch (IOException)
			{
				throw GException25.smethod_0();
			}
			arrayList_0.Add(GClass634.smethod_0(array));
		}

		private static void smethod_3(GClass657 gclass657_0, StringBuilder stringBuilder_0, int int_0, bool bool_1)
		{
			int length = stringBuilder_0.Length;
			while (int_0 > 1)
			{
				int num = gclass657_0.method_0(11);
				stringBuilder_0.Append(char_0[num / 45]);
				stringBuilder_0.Append(char_0[num % 45]);
				int_0 -= 2;
			}
			if (int_0 == 1)
			{
				stringBuilder_0.Append(char_0[gclass657_0.method_0(6)]);
			}
			if (!bool_1)
			{
				return;
			}
			for (int i = length; i < stringBuilder_0.Length; i++)
			{
				if (stringBuilder_0[i] == '%')
				{
					if (i < stringBuilder_0.Length - 1 && stringBuilder_0[i + 1] == '%')
					{
						stringBuilder_0.Remove(i + 1, 1);
					}
					else
					{
						stringBuilder_0[i] = '\u001d';
					}
				}
			}
		}

		private static void smethod_4(GClass657 gclass657_0, StringBuilder stringBuilder_0, int int_0)
		{
			while (true)
			{
				if (int_0 >= 3)
				{
					int num = gclass657_0.method_0(10);
					if (num >= 1000)
					{
						break;
					}
					stringBuilder_0.Append(char_0[num / 100]);
					stringBuilder_0.Append(char_0[num / 10 % 10]);
					stringBuilder_0.Append(char_0[num % 10]);
					int_0 -= 3;
					continue;
				}
				switch (int_0)
				{
				case 2:
				{
					int num3 = gclass657_0.method_0(7);
					if (num3 >= 100)
					{
						throw GException25.smethod_0();
					}
					stringBuilder_0.Append(char_0[num3 / 10]);
					stringBuilder_0.Append(char_0[num3 % 10]);
					break;
				}
				case 1:
				{
					int num2 = gclass657_0.method_0(4);
					if (num2 >= 10)
					{
						throw GException25.smethod_0();
					}
					stringBuilder_0.Append(char_0[num2]);
					break;
				}
				}
				return;
			}
			throw GException25.smethod_0();
		}

		private static string smethod_5(sbyte[] sbyte_0)
		{
			return "UTF-8";
		}

		private static int smethod_6(GClass657 gclass657_0)
		{
			int num = 17;
			int num2 = gclass657_0.method_0(8);
			if ((num2 & 0x80) == 0)
			{
				return num2 & 0x7F;
			}
			if ((num2 & 0xC0) == 128)
			{
				int num3 = gclass657_0.method_0(8);
				return ((num2 & 0x3F) << 8) | num3;
			}
			if ((num2 & 0xE0) == 192)
			{
				int num4 = gclass657_0.method_0(16);
				return ((num2 & 0x1F) << 16) | num4;
			}
			throw new ArgumentException("Bad ECI bits starting with byte " + num2);
		}

		static Class272()
		{
			char_0 = new char[45]
			{
				'0',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'I',
				'J',
				'K',
				'L',
				'M',
				'N',
				'O',
				'P',
				'Q',
				'R',
				'S',
				'T',
				'U',
				'V',
				'W',
				'X',
				'Y',
				'Z',
				' ',
				'$',
				'%',
				'*',
				'+',
				'-',
				'.',
				'/',
				':'
			};
			bool_0 = false;
		}
	}
}

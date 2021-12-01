using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass614
	{
		internal const string string_0 = "UTF-8";

		private static readonly int[] int_0 = new int[96]
		{
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			36,
			-1,
			-1,
			-1,
			37,
			38,
			-1,
			-1,
			-1,
			-1,
			39,
			40,
			-1,
			41,
			42,
			43,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			44,
			-1,
			-1,
			-1,
			-1,
			-1,
			-1,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			-1,
			-1,
			-1,
			-1,
			-1
		};

		private GClass614()
		{
		}

		private static int smethod_0(GClass658 gclass658_0)
		{
			int num = 0;
			num = 0 + GClass638.smethod_0(gclass658_0);
			num += GClass638.smethod_1(gclass658_0);
			num += GClass638.smethod_2(gclass658_0);
			return num + GClass638.smethod_3(gclass658_0);
		}

		public static void smethod_1(string string_1, GClass636 gclass636_0, GClass632 gclass632_0)
		{
			smethod_2(string_1, gclass636_0, null, gclass632_0);
		}

		public static void smethod_2(string string_1, GClass636 gclass636_0, Hashtable hashtable_0, GClass632 gclass632_0)
		{
			int num = 14;
			string text = (hashtable_0 == null) ? null : ((string)hashtable_0[GClass685.gclass685_1]);
			if (text == null)
			{
				text = "UTF-8";
			}
			GClass653 gClass = smethod_5(string_1, text);
			GClass635 gClass2 = new GClass635();
			smethod_15(string_1, gClass, gClass2, text);
			int int_ = gClass2.method_3();
			smethod_8(int_, gclass636_0, gClass, gclass632_0);
			GClass635 gClass3 = new GClass635();
			if (gClass == GClass653.gclass653_4 && !"UTF-8".Equals(text))
			{
				GClass656 gClass4 = GClass656.smethod_5(text);
				if (gClass4 != null)
				{
					smethod_20(gClass4, gClass3);
				}
			}
			smethod_13(gClass, gClass3);
			int int_2 = gClass.Equals(GClass653.gclass653_4) ? gClass2.method_3() : string_1.Length;
			smethod_14(int_2, gclass632_0.method_4(), gClass, gClass3);
			gClass3.method_6(gClass2);
			smethod_9(gclass632_0.method_12(), gClass3);
			GClass635 gClass5 = new GClass635();
			smethod_11(gClass3, gclass632_0.method_10(), gclass632_0.method_12(), gclass632_0.method_16(), gClass5);
			GClass658 gClass6 = new GClass658(gclass632_0.method_6(), gclass632_0.method_6());
			gclass632_0.method_9(smethod_7(gClass5, gclass632_0.method_2(), gclass632_0.method_4(), gClass6));
			GClass613.smethod_1(gClass5, gclass632_0.method_2(), gclass632_0.method_4(), gclass632_0.method_8(), gClass6);
			gclass632_0.method_19(gClass6);
			if (!gclass632_0.method_20())
			{
				throw new GException26("Invalid QR code: " + gclass632_0.ToString());
			}
		}

		internal static int smethod_3(int int_1)
		{
			if (int_1 < int_0.Length)
			{
				return int_0[int_1];
			}
			return -1;
		}

		public static GClass653 smethod_4(string string_1)
		{
			return smethod_5(string_1, null);
		}

		public static GClass653 smethod_5(string string_1, string string_2)
		{
			if ("Shift_JIS".Equals(string_2))
			{
				return smethod_6(string_1) ? GClass653.gclass653_6 : GClass653.gclass653_4;
			}
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			while (true)
			{
				if (num < string_1.Length)
				{
					char c = string_1[num];
					if (c >= '0' && c <= '9')
					{
						flag = true;
					}
					else
					{
						if (smethod_3(c) == -1)
						{
							break;
						}
						flag2 = true;
					}
					num++;
					continue;
				}
				if (flag2)
				{
					return GClass653.gclass653_2;
				}
				if (flag)
				{
					return GClass653.gclass653_1;
				}
				return GClass653.gclass653_4;
			}
			return GClass653.gclass653_4;
		}

		private static bool smethod_6(string string_1)
		{
			int num = 16;
			sbyte[] array;
			try
			{
				array = GClass634.smethod_13(Encoding.GetEncoding("Shift_JIS").GetBytes(string_1));
			}
			catch (IOException)
			{
				return false;
			}
			int num2 = array.Length;
			if (num2 % 2 != 0)
			{
				return false;
			}
			int num3 = 0;
			while (true)
			{
				if (num3 < num2)
				{
					int num4 = array[num3] & 0xFF;
					if ((num4 < 129 || num4 > 159) && (num4 < 224 || num4 > 235))
					{
						break;
					}
					num3 += 2;
					continue;
				}
				return true;
			}
			return false;
		}

		private static int smethod_7(GClass635 gclass635_0, GClass636 gclass636_0, int int_1, GClass658 gclass658_0)
		{
			int num = int.MaxValue;
			int result = -1;
			for (int i = 0; i < 8; i++)
			{
				GClass613.smethod_1(gclass635_0, gclass636_0, int_1, i, gclass658_0);
				int num2 = smethod_0(gclass658_0);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		private static void smethod_8(int int_1, GClass636 gclass636_0, GClass653 gclass653_0, GClass632 gclass632_0)
		{
			int num = 10;
			gclass632_0.method_3(gclass636_0);
			gclass632_0.method_1(gclass653_0);
			int num2 = 1;
			GClass672 gClass;
			int num3;
			int num4;
			int int_2;
			int num5;
			while (true)
			{
				if (num2 <= 40)
				{
					gClass = GClass672.smethod_1(num2);
					num3 = gClass.method_2();
					GClass672.GClass673 gClass2 = gClass.method_4(gclass636_0);
					num4 = gClass2.method_2();
					int_2 = gClass2.method_1();
					num5 = num3 - num4;
					if (num5 >= int_1 + 3)
					{
						break;
					}
					num2++;
					continue;
				}
				throw new GException26("Cannot find proper rs block info (input data too big?)");
			}
			gclass632_0.method_5(num2);
			gclass632_0.method_11(num3);
			gclass632_0.method_13(num5);
			gclass632_0.method_17(int_2);
			gclass632_0.method_15(num4);
			gclass632_0.method_7(gClass.method_3());
		}

		internal static void smethod_9(int int_1, GClass635 gclass635_0)
		{
			int num = 13;
			int num2 = int_1 << 3;
			if (gclass635_0.method_2() > num2)
			{
				throw new GException26("data bits cannot fit in the QR Code" + gclass635_0.method_2() + " > " + num2);
			}
			for (int i = 0; i < 4; i++)
			{
				if (gclass635_0.method_2() >= num2)
				{
					break;
				}
				gclass635_0.method_4(0);
			}
			int num3 = gclass635_0.method_2() % 8;
			if (num3 > 0)
			{
				int num4 = 8 - num3;
				for (int i = 0; i < num4; i++)
				{
					gclass635_0.method_4(0);
				}
			}
			if (gclass635_0.method_2() % 8 != 0)
			{
				throw new GException26("Number of bits is not a multiple of 8");
			}
			int num5 = int_1 - gclass635_0.method_3();
			for (int i = 0; i < num5; i++)
			{
				if (i % 2 == 0)
				{
					gclass635_0.method_5(236, 8);
				}
				else
				{
					gclass635_0.method_5(17, 8);
				}
			}
			if (gclass635_0.method_2() != num2)
			{
				throw new GException26("Bits size does not equal capacity");
			}
		}

		internal static void smethod_10(int int_1, int int_2, int int_3, int int_4, int[] int_5, int[] int_6)
		{
			int num = 17;
			if (int_4 >= int_3)
			{
				throw new GException26("Block ID too large");
			}
			int num2 = int_1 % int_3;
			int num3 = int_3 - num2;
			int num4 = int_1 / int_3;
			int num5 = num4 + 1;
			int num6 = int_2 / int_3;
			int num7 = num6 + 1;
			int num8 = num4 - num6;
			int num9 = num5 - num7;
			if (num8 != num9)
			{
				throw new GException26("EC bytes mismatch");
			}
			if (int_3 != num3 + num2)
			{
				throw new GException26("RS blocks mismatch");
			}
			if (int_1 != (num6 + num8) * num3 + (num7 + num9) * num2)
			{
				throw new GException26("Total bytes mismatch");
			}
			if (int_4 < num3)
			{
				int_5[0] = num6;
				int_6[0] = num8;
			}
			else
			{
				int_5[0] = num7;
				int_6[0] = num9;
			}
		}

		internal static void smethod_11(GClass635 gclass635_0, int int_1, int int_2, int int_3, GClass635 gclass635_1)
		{
			int num = 17;
			if (gclass635_0.method_3() != int_2)
			{
				throw new GException26("Number of bits and data bytes does not match");
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(int_3));
			for (int i = 0; i < int_3; i++)
			{
				int[] array = new int[1];
				int[] array2 = new int[1];
				smethod_10(int_1, int_2, int_3, i, array, array2);
				GClass671 gClass = new GClass671();
				gClass.method_6(gclass635_0.method_0(), num2, array[0]);
				GClass671 gClass2 = smethod_12(gClass, array2[0]);
				arrayList.Add(new Class252(gClass, gClass2));
				num3 = Math.Max(num3, gClass.method_3());
				num4 = Math.Max(num4, gClass2.method_3());
				num2 += array[0];
			}
			if (int_2 != num2)
			{
				throw new GException26("Data bytes does not match offset");
			}
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < arrayList.Count; j++)
				{
					GClass671 gClass = ((Class252)arrayList[j]).method_0();
					if (i < gClass.method_3())
					{
						gclass635_1.method_5(gClass.method_1(i), 8);
					}
				}
			}
			for (int i = 0; i < num4; i++)
			{
				for (int j = 0; j < arrayList.Count; j++)
				{
					GClass671 gClass2 = ((Class252)arrayList[j]).method_1();
					if (i < gClass2.method_3())
					{
						gclass635_1.method_5(gClass2.method_1(i), 8);
					}
				}
			}
			if (int_1 != gclass635_1.method_3())
			{
				throw new GException26("Interleaving error: " + int_1 + " and " + gclass635_1.method_3() + " differ.");
			}
		}

		internal static GClass671 smethod_12(GClass671 gclass671_0, int int_1)
		{
			int num = gclass671_0.method_3();
			int[] array = new int[num + int_1];
			for (int i = 0; i < num; i++)
			{
				array[i] = gclass671_0.method_1(i);
			}
			new GClass648(GClass618.gclass618_0).method_1(array, int_1);
			GClass671 gClass = new GClass671(int_1);
			for (int i = 0; i < int_1; i++)
			{
				gClass.method_2(i, array[num + i]);
			}
			return gClass;
		}

		internal static void smethod_13(GClass653 gclass653_0, GClass635 gclass635_0)
		{
			gclass635_0.method_5(gclass653_0.method_0(), 4);
		}

		internal static void smethod_14(int int_1, int int_2, GClass653 gclass653_0, GClass635 gclass635_0)
		{
			int num = 3;
			int num2 = gclass653_0.method_1(GClass672.smethod_1(int_2));
			if (int_1 > (1 << num2) - 1)
			{
				throw new GException26(int_1 + "is bigger than" + ((1 << num2) - 1));
			}
			gclass635_0.method_5(int_1, num2);
		}

		internal static void smethod_15(string string_1, GClass653 gclass653_0, GClass635 gclass635_0, string string_2)
		{
			int num = 9;
			if (gclass653_0.Equals(GClass653.gclass653_1))
			{
				smethod_16(string_1, gclass635_0);
				return;
			}
			if (gclass653_0.Equals(GClass653.gclass653_2))
			{
				smethod_17(string_1, gclass635_0);
				return;
			}
			if (gclass653_0.Equals(GClass653.gclass653_4))
			{
				smethod_18(string_1, gclass635_0, string_2);
				return;
			}
			if (gclass653_0.Equals(GClass653.gclass653_6))
			{
				smethod_19(string_1, gclass635_0);
				return;
			}
			throw new GException26("Invalid mode: " + gclass653_0);
		}

		internal static void smethod_16(string string_1, GClass635 gclass635_0)
		{
			int length = string_1.Length;
			int num = 0;
			while (num < length)
			{
				int num2 = string_1[num] - 48;
				if (num + 2 < length)
				{
					int num3 = string_1[num + 1] - 48;
					int num4 = string_1[num + 2] - 48;
					gclass635_0.method_5(num2 * 100 + num3 * 10 + num4, 10);
					num += 3;
				}
				else if (num + 1 < length)
				{
					int num3 = string_1[num + 1] - 48;
					gclass635_0.method_5(num2 * 10 + num3, 7);
					num += 2;
				}
				else
				{
					gclass635_0.method_5(num2, 4);
					num++;
				}
			}
		}

		internal static void smethod_17(string string_1, GClass635 gclass635_0)
		{
			int length = string_1.Length;
			int num = 0;
			while (true)
			{
				if (num >= length)
				{
					return;
				}
				int num2 = smethod_3(string_1[num]);
				if (num2 != -1)
				{
					if (num + 1 < length)
					{
						int num3 = smethod_3(string_1[num + 1]);
						if (num3 == -1)
						{
							break;
						}
						gclass635_0.method_5(num2 * 45 + num3, 11);
						num += 2;
					}
					else
					{
						gclass635_0.method_5(num2, 6);
						num++;
					}
					continue;
				}
				throw new GException26();
			}
			throw new GException26();
		}

		internal static void smethod_18(string string_1, GClass635 gclass635_0, string string_2)
		{
			sbyte[] array;
			try
			{
				array = GClass634.smethod_13(Encoding.GetEncoding(string_2).GetBytes(string_1));
			}
			catch (IOException ex)
			{
				throw new GException26(ex.ToString());
			}
			for (int i = 0; i < array.Length; i++)
			{
				gclass635_0.method_5(array[i], 8);
			}
		}

		internal static void smethod_19(string string_1, GClass635 gclass635_0)
		{
			int num = 18;
			sbyte[] array;
			try
			{
				array = GClass634.smethod_13(Encoding.GetEncoding("Shift_JIS").GetBytes(string_1));
			}
			catch (IOException ex)
			{
				throw new GException26(ex.ToString());
			}
			int num2 = array.Length;
			int num3 = 0;
			while (true)
			{
				if (num3 < num2)
				{
					int num4 = array[num3] & 0xFF;
					int num5 = array[num3 + 1] & 0xFF;
					int num6 = (num4 << 8) | num5;
					int num7 = -1;
					if (num6 >= 33088 && num6 <= 40956)
					{
						num7 = num6 - 33088;
					}
					else if (num6 >= 57408 && num6 <= 60351)
					{
						num7 = num6 - 49472;
					}
					if (num7 == -1)
					{
						break;
					}
					int int_ = (num7 >> 8) * 192 + (num7 & 0xFF);
					gclass635_0.method_5(int_, 13);
					num3 += 2;
					continue;
				}
				return;
			}
			throw new GException26("Invalid byte sequence");
		}

		private static void smethod_20(GClass656 gclass656_0, GClass635 gclass635_0)
		{
			gclass635_0.method_5(GClass653.gclass653_5.method_0(), 4);
			gclass635_0.method_5(gclass656_0.vmethod_0(), 8);
		}
	}
}

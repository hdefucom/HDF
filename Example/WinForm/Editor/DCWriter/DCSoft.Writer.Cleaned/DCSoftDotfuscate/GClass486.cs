#define DEBUG
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass486 : GClass480
	{
		private const string string_1 = "The unicode CMap doesn't exist in the font file";

		private const string string_2 = "Invalid CMap format";

		private ushort ushort_0;

		private ushort ushort_1;

		private int int_0;

		internal ushort[] ushort_2;

		internal ushort[] ushort_3;

		private ushort[] ushort_4;

		private ushort[] ushort_5;

		internal ushort[] ushort_6 = new ushort[256];

		public GClass486(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		public bool method_6(ushort ushort_7)
		{
			if (ushort_3 != null)
			{
				for (int i = 0; i < ushort_3.Length; i++)
				{
					if (ushort_7 >= ushort_3[i] && ushort_7 <= ushort_2[i])
					{
						return true;
					}
				}
			}
			return false;
		}

		public ushort[] method_7()
		{
			if (ushort_3 != null && ushort_3.Length > 0)
			{
				ushort[] array = new ushort[ushort_3.Length * 2];
				for (int i = 0; i < ushort_3.Length; i++)
				{
					array[i * 2] = ushort_3[i];
					array[i * 2 + 1] = ushort_2[i];
				}
				return array;
			}
			return null;
		}

		private void method_8(int int_1)
		{
			int num = int_1;
			for (int i = 0; i < ushort_2.Length; i++)
			{
				num = Math.Max(num, ushort_2[i]);
			}
			if (ushort_6.Length <= num)
			{
				int val = (int)((double)num * 1.5 + 1.0);
				val = Math.Min(65536, val);
				ushort[] destinationArray = new ushort[val];
				Array.Copy(ushort_6, destinationArray, ushort_6.Length);
				ushort_6 = destinationArray;
			}
		}

		private void method_9(GClass498 gclass498_0)
		{
			int int_ = gclass498_0.vmethod_3();
			method_8(0);
			for (int i = 0; i < ushort_2.Length; i++)
			{
				for (int j = ushort_3[i]; j <= ushort_2[i]; j++)
				{
					ushort num = 0;
					if (ushort_5[i] != 0 && j != 65535)
					{
						int int_2 = ((int)ushort_5[i] / 2 + j - ushort_3[i] + i - ushort_5.Length) * 2;
						gclass498_0.method_27(int_);
						gclass498_0.method_26(int_2);
						num = gclass498_0.method_2();
						if (num != 0)
						{
							num = (ushort)((num + ushort_4[i]) & 0xFFFF);
						}
					}
					else
					{
						num = (ushort)((j + ushort_4[i]) & 0xFFFF);
					}
					ushort_6[j] = num;
				}
			}
		}

		private void method_10(GClass498 gclass498_0)
		{
			int num = 14;
			ushort num2 = gclass498_0.method_2();
			if (num2 != 4)
			{
				throw new GException16("Invalid CMap format");
			}
			gclass498_0.method_2();
			ushort_1 = gclass498_0.method_2();
			int_0 = Convert.ToInt32((int)gclass498_0.method_2() / 2);
			ushort_2 = new ushort[int_0];
			ushort_3 = new ushort[int_0];
			ushort_4 = new ushort[int_0];
			ushort_5 = new ushort[int_0];
			gclass498_0.method_26(6);
			for (int i = 0; i < int_0; i++)
			{
				ushort_2[i] = gclass498_0.method_2();
			}
			gclass498_0.method_26(2);
			for (int i = 0; i < int_0; i++)
			{
				ushort_3[i] = gclass498_0.method_2();
			}
			for (int i = 0; i < int_0; i++)
			{
				ushort_4[i] = gclass498_0.method_2();
			}
			for (int i = 0; i < int_0; i++)
			{
				ushort_5[i] = gclass498_0.method_2();
			}
			method_9(gclass498_0);
		}

		private void method_11()
		{
			int num = 0;
			method_8(0);
			for (int i = 0; i < int_0; i++)
			{
				bool flag = true;
				for (int j = ushort_3[i]; j < ushort_2[i]; j++)
				{
					if (ushort_6[j + 1] != ushort_6[j] + 1)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					ushort_5[i] = 0;
					int num2 = ushort_6[ushort_3[i]] - ushort_3[i];
					if (num2 < 0)
					{
						num2 += 65536;
					}
					ushort_4[i] = (ushort)num2;
				}
				else
				{
					ushort_5[i] = (ushort)(num + (ushort_5.Length - i) * 2);
					num += (ushort_2[i] - ushort_3[i] + 1) * 2;
					ushort_4[i] = 0;
				}
			}
		}

		private void method_12(GClass479 gclass479_0)
		{
			int_0 = 0;
			for (int i = 0; i < gclass479_0.char_0.Length - 1; i++)
			{
				if (gclass479_0.char_0[i + 1] != gclass479_0.char_0[i] + 1)
				{
					int_0++;
				}
			}
			int_0 += 2;
			ushort_2 = new ushort[int_0];
			ushort_3 = new ushort[int_0];
			ushort_4 = new ushort[int_0];
			ushort_5 = new ushort[int_0];
			int num = 0;
			if (gclass479_0.char_0.Length > 0)
			{
				ushort_3[0] = gclass479_0.char_0[0];
				for (int i = 0; i < gclass479_0.char_0.Length - 1; i++)
				{
					if (gclass479_0.char_0[i + 1] != gclass479_0.char_0[i] + 1)
					{
						ushort_2[num] = gclass479_0.char_0[i];
						ushort_3[num + 1] = gclass479_0.char_0[i + 1];
						num++;
					}
				}
				ushort_2[num] = gclass479_0.char_0[gclass479_0.char_0.Length - 1];
				ushort[] array = ushort_3;
				int num2 = num + 1;
				ushort_2[num + 1] = ushort.MaxValue;
				array[num2] = ushort.MaxValue;
			}
			method_11();
		}

		private void method_13(GClass498 gclass498_0)
		{
			for (int i = 0; i < ushort_5.Length; i++)
			{
				if (ushort_5[i] != 0)
				{
					for (int j = ushort_3[i]; j <= ushort_2[i]; j++)
					{
						gclass498_0.method_17(ushort_6[j]);
					}
				}
			}
		}

		private void method_14(GClass498 gclass498_0)
		{
			int num = gclass498_0.vmethod_3();
			gclass498_0.method_17(4);
			gclass498_0.method_17(0);
			gclass498_0.method_17(ushort_1);
			gclass498_0.method_17((ushort)(int_0 * 2));
			double num2 = Math.Floor(Math.Log(int_0, 2.0));
			double num3 = Math.Pow(2.0, num2) * 2.0;
			gclass498_0.method_17((ushort)num3);
			gclass498_0.method_17((ushort)num2);
			gclass498_0.method_17((ushort)((double)(int_0 * 2) - num3));
			for (int i = 0; i < ushort_2.Length; i++)
			{
				gclass498_0.method_17(ushort_2[i]);
			}
			gclass498_0.method_17(0);
			for (int i = 0; i < ushort_3.Length; i++)
			{
				gclass498_0.method_17(ushort_3[i]);
			}
			for (int i = 0; i < ushort_4.Length; i++)
			{
				gclass498_0.method_17(ushort_4[i]);
			}
			for (int i = 0; i < ushort_5.Length; i++)
			{
				gclass498_0.method_17(ushort_5[i]);
			}
			method_13(gclass498_0);
			int num4 = gclass498_0.vmethod_3() - num;
			gclass498_0.method_27(num);
			gclass498_0.method_26(2);
			gclass498_0.method_17((ushort)num4);
			gclass498_0.method_27(num);
			gclass498_0.method_26(num4);
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			int num = 5;
			int num2 = gclass498_0.vmethod_3();
			ushort_0 = gclass498_0.method_2();
			int num3 = Convert.ToInt32(gclass498_0.method_2());
			int num4 = -1;
			int num5 = 0;
			for (int i = 0; i < num3; i++)
			{
				ushort num6 = gclass498_0.method_2();
				ushort num7 = gclass498_0.method_2();
				int num8 = (int)gclass498_0.method_4();
				if (num6 != 3 || num7 != 1)
				{
					if (num6 == 1 && num7 == 0)
					{
						num5 = num8;
					}
					continue;
				}
				num4 = num8;
				break;
			}
			if (num4 == -1)
			{
				if (num5 > 0)
				{
					gclass498_0.method_27(num2 + num5);
					switch (gclass498_0.method_3())
					{
					case 0:
						method_15(gclass498_0);
						break;
					}
				}
				Debug.WriteLine("The unicode CMap doesn't exist in the font file");
			}
			else
			{
				gclass498_0.method_27(num2);
				gclass498_0.method_26(num4);
				method_10(gclass498_0);
			}
		}

		private void method_15(GClass498 gclass498_0)
		{
			ushort_3 = new ushort[1];
			ushort_3[0] = 0;
			ushort_2 = new ushort[1];
			ushort_2[0] = 256;
			method_8(256);
			gclass498_0.method_2();
			gclass498_0.method_2();
			byte[] array = gclass498_0.method_11(256);
			for (int i = 0; i < 256; i++)
			{
				ushort_6[i] = array[i];
			}
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			int num = gclass498_0.vmethod_3();
			gclass498_0.method_17(ushort_0);
			gclass498_0.method_17(1);
			gclass498_0.method_17(3);
			gclass498_0.method_17(1);
			gclass498_0.method_19((uint)(gclass498_0.vmethod_3() - num + 4));
			method_14(gclass498_0);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass486 gClass = gclass480_0 as GClass486;
			ushort_0 = gClass.ushort_0;
			ushort_1 = gClass.ushort_1;
			ushort_6 = new ushort[gclass479_0.char_0.Length];
			for (int i = 0; i < gclass479_0.char_0.Length; i++)
			{
				ushort num = gclass479_0.char_0[i];
				method_8(num);
				ushort_6[num] = gClass.method_17(num);
			}
			method_12(gclass479_0);
		}

		protected internal override string vmethod_3()
		{
			return "cmap";
		}

		public int method_16()
		{
			return ushort_6.Length;
		}

		public ushort method_17(ushort ushort_7)
		{
			return ushort_6[ushort_7];
		}

		public override int vmethod_4()
		{
			int num = 14;
			num = 14 + 2 * int_0;
			num += 2;
			num += 2 * int_0 * 3;
			for (int i = 0; i < int_0; i++)
			{
				if (ushort_5[i] != 0)
				{
					num += (ushort_2[i] - ushort_3[i] + 1) * 2;
				}
			}
			return 12 + num;
		}
	}
}

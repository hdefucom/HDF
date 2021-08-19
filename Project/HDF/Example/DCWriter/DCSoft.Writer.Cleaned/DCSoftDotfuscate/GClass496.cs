using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass496
	{
		private GClass478 gclass478_0;

		private byte[] byte_0;

		private ushort ushort_0;

		private ushort ushort_1;

		private ushort ushort_2;

		private ushort ushort_3;

		private ArrayList arrayList_0 = new ArrayList();

		public GClass496(GClass478 gclass478_1)
		{
			gclass478_0 = gclass478_1;
		}

		private void method_0(GClass498 gclass498_0)
		{
			arrayList_0.Clear();
			for (int i = 0; i < method_8(); i++)
			{
				GClass497 gClass = new GClass497();
				gClass.method_0(gclass498_0);
				arrayList_0.Add(gClass);
			}
		}

		private void method_1(GClass498 gclass498_0)
		{
			for (int i = 0; i < method_10(); i++)
			{
				method_11(i).method_1(gclass498_0);
			}
		}

		public void method_2(GClass498 gclass498_0, int int_0)
		{
			gclass498_0.method_27(int_0);
			byte_0 = gclass498_0.method_11(4);
			ushort_0 = gclass498_0.method_2();
			ushort_1 = gclass498_0.method_2();
			ushort_2 = gclass498_0.method_2();
			ushort_3 = gclass498_0.method_2();
			method_0(gclass498_0);
		}

		public void method_3(GClass498 gclass498_0)
		{
			gclass498_0.method_27(0);
			gclass498_0.method_13(byte_0);
			gclass498_0.method_17(ushort_0);
			gclass498_0.method_17(ushort_1);
			gclass498_0.method_17(ushort_2);
			gclass498_0.method_17(ushort_3);
			method_1(gclass498_0);
		}

		public void method_4(GClass480 gclass480_0)
		{
			GClass497 gClass = new GClass497();
			gClass.method_4(gclass480_0);
			arrayList_0.Add(gClass);
		}

		public void method_5(GClass498 gclass498_0)
		{
			gclass498_0.method_27(0);
			gclass498_0.method_26(smethod_0());
			for (int i = 0; i < method_10(); i++)
			{
				method_11(i).method_2(gclass498_0);
			}
		}

		public void method_6(GClass498 gclass498_0)
		{
			gclass498_0.method_27(0);
			gclass498_0.method_26(smethod_0());
			for (int i = 0; i < method_10(); i++)
			{
				method_11(i).method_3(gclass498_0);
			}
		}

		public void method_7(GClass496 gclass496_0)
		{
			byte_0 = new byte[gclass496_0.byte_0.Length];
			gclass496_0.byte_0.CopyTo(byte_0, 0);
			ushort_0 = (ushort)method_10();
			double num = Math.Floor(Math.Log((int)ushort_0, 2.0));
			double num2 = Math.Pow(2.0, num);
			ushort_1 = (ushort)(num2 * 16.0);
			ushort_2 = (ushort)num;
			ushort_3 = (ushort)(ushort_0 * 16 - ushort_1);
		}

		private int method_8()
		{
			return Convert.ToInt32(ushort_0);
		}

		public GClass478 method_9()
		{
			return gclass478_0;
		}

		public int method_10()
		{
			return arrayList_0.Count;
		}

		public GClass497 method_11(int int_0)
		{
			return arrayList_0[int_0] as GClass497;
		}

		public GClass497 method_12(string string_0)
		{
			int num = 0;
			while (true)
			{
				if (num < method_10())
				{
					if (method_11(num).method_6() == string_0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return method_11(num);
		}

		public static int smethod_0()
		{
			return 12;
		}
	}
}

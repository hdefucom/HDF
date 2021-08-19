using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass294
	{
		private enum enumDeviceCapsConst
		{
			DRIVERVERSION = 0,
			TECHNOLOGY = 2,
			HORZSIZE = 4,
			VERTSIZE = 6,
			HORZRES = 8,
			VERTRES = 10,
			LOGPIXELSX = 88,
			LOGPIXELSY = 90,
			PLANES = 14,
			NUMBRUSHES = 0x10,
			NUMCOLORS = 24,
			NUMFONTS = 22,
			NUMPENS = 18,
			ASPECTX = 40,
			ASPECTXY = 44,
			ASPECTY = 42,
			PDEVICESIZE = 26,
			CLIPCAPS = 36,
			SIZEPALETTE = 104,
			NUMRESERVED = 106,
			COLORRES = 108,
			PHYSICALOFFSETX = 112,
			PHYSICALOFFSETY = 113,
			PHYSICALHEIGHT = 111,
			PHYSICALWIDTH = 110,
			SCALINGFACTORX = 114,
			SCALINGFACTORY = 115,
			LISTEN_OUTSTANDING = 1,
			CURVECAPS = 28,
			LINECAPS = 30,
			POLYGONALCAPS = 0x20,
			TEXTCAPS = 34
		}

		private static GClass294 gclass294_0 = null;

		private string string_0 = null;

		private int[] int_0 = null;

		public static GClass294 smethod_0()
		{
			if (gclass294_0 == null)
			{
				gclass294_0 = new GClass294();
				gclass294_0.method_3();
			}
			return gclass294_0;
		}

		public GClass294()
		{
		}

		public GClass294(IntPtr intptr_0)
		{
			method_1(intptr_0);
		}

		public GClass294(string string_1)
		{
			method_2(string_1);
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(IntPtr intptr_0)
		{
			string_0 = null;
			Array values = Enum.GetValues(typeof(enumDeviceCapsConst));
			int_0 = new int[values.Length * 2];
			for (int i = 0; i < values.Length; i++)
			{
				int num = Convert.ToInt32(values.GetValue(i));
				int_0[i * 2] = num;
				int_0[i * 2 + 1] = GetDeviceCaps(intptr_0, num);
			}
		}

		public void method_2(string string_1)
		{
			IntPtr intptr_ = CreateDC(string_1, null, 0, 0);
			if (intptr_.ToInt32() != 0)
			{
				method_1(intptr_);
				DeleteDC(intptr_);
				string_0 = string_1;
			}
		}

		public void method_3()
		{
			method_2("DISPLAY");
		}

		public override string ToString()
		{
			int num = 4;
			if (int_0 == null)
			{
				return "DeviceCapsClass:对象尚未初始化";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DeviceCapsClass");
			if (string_0 != null)
			{
				stringBuilder.Append(" Driver:" + string_0);
			}
			Array values = Enum.GetValues(typeof(enumDeviceCapsConst));
			foreach (enumDeviceCapsConst item in values)
			{
				stringBuilder.Append(Environment.NewLine);
				stringBuilder.Append(item.ToString() + " = " + method_36(item));
			}
			return stringBuilder.ToString();
		}

		public int method_4()
		{
			return method_36(enumDeviceCapsConst.DRIVERVERSION);
		}

		public int method_5()
		{
			return method_36(enumDeviceCapsConst.TECHNOLOGY);
		}

		public int method_6()
		{
			return method_36(enumDeviceCapsConst.HORZSIZE);
		}

		public int method_7()
		{
			return method_36(enumDeviceCapsConst.VERTSIZE);
		}

		public int method_8()
		{
			return method_36(enumDeviceCapsConst.HORZRES);
		}

		public int method_9()
		{
			return method_36(enumDeviceCapsConst.VERTRES);
		}

		public int method_10()
		{
			return method_36(enumDeviceCapsConst.LOGPIXELSX);
		}

		public int method_11()
		{
			return method_36(enumDeviceCapsConst.LOGPIXELSY);
		}

		public int method_12()
		{
			return method_36(enumDeviceCapsConst.PLANES);
		}

		public int method_13()
		{
			return method_36(enumDeviceCapsConst.NUMBRUSHES);
		}

		public int method_14()
		{
			return method_36(enumDeviceCapsConst.NUMCOLORS);
		}

		public int method_15()
		{
			return method_36(enumDeviceCapsConst.NUMFONTS);
		}

		public int method_16()
		{
			return method_36(enumDeviceCapsConst.NUMPENS);
		}

		public int method_17()
		{
			return method_36(enumDeviceCapsConst.ASPECTX);
		}

		public int method_18()
		{
			return method_36(enumDeviceCapsConst.ASPECTXY);
		}

		public int method_19()
		{
			return method_36(enumDeviceCapsConst.ASPECTY);
		}

		public int method_20()
		{
			return method_36(enumDeviceCapsConst.PDEVICESIZE);
		}

		public int method_21()
		{
			return method_36(enumDeviceCapsConst.CLIPCAPS);
		}

		public int method_22()
		{
			return method_36(enumDeviceCapsConst.SIZEPALETTE);
		}

		public int method_23()
		{
			return method_36(enumDeviceCapsConst.NUMRESERVED);
		}

		public int method_24()
		{
			return method_36(enumDeviceCapsConst.COLORRES);
		}

		public int method_25()
		{
			return method_36(enumDeviceCapsConst.PHYSICALOFFSETX);
		}

		public int method_26()
		{
			return method_36(enumDeviceCapsConst.PHYSICALOFFSETY);
		}

		public int method_27()
		{
			return method_36(enumDeviceCapsConst.PHYSICALHEIGHT);
		}

		public int method_28()
		{
			return method_36(enumDeviceCapsConst.PHYSICALWIDTH);
		}

		public int method_29()
		{
			return method_36(enumDeviceCapsConst.SCALINGFACTORX);
		}

		public int method_30()
		{
			return method_36(enumDeviceCapsConst.SCALINGFACTORY);
		}

		public int method_31()
		{
			return method_36(enumDeviceCapsConst.LISTEN_OUTSTANDING);
		}

		public int method_32()
		{
			return method_36(enumDeviceCapsConst.CURVECAPS);
		}

		public int method_33()
		{
			return method_36(enumDeviceCapsConst.LINECAPS);
		}

		public int method_34()
		{
			return method_36(enumDeviceCapsConst.POLYGONALCAPS);
		}

		public int method_35()
		{
			return method_36(enumDeviceCapsConst.TEXTCAPS);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int GetDeviceCaps(IntPtr intptr_0, int int_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ReleaseDC(IntPtr intptr_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateDC(string string_1, string string_2, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int DeleteDC(IntPtr intptr_0);

		private int method_36(enumDeviceCapsConst enumDeviceCapsConst_0)
		{
			if (int_0 == null)
			{
				return int.MinValue;
			}
			int num = 0;
			while (true)
			{
				if (num < int_0.Length)
				{
					if (int_0[num] == Convert.ToInt32(enumDeviceCapsConst_0))
					{
						break;
					}
					num += 2;
					continue;
				}
				return int.MinValue;
			}
			return int_0[num + 1];
		}
	}
}

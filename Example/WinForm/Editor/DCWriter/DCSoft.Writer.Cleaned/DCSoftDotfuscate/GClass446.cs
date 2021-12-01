using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class XPaperSizeCollection
	{
		private static Size[] size_0;

		public static Rectangle smethod_0(PageSettings pageSettings_0)
		{
			int num = 13;
			if (pageSettings_0 == null)
			{
				throw new ArgumentNullException("ps");
			}
			try
			{
				return pageSettings_0.Bounds;
			}
			catch (Exception)
			{
				Size size = Size.Empty;
				try
				{
					if (pageSettings_0.PaperSize.Kind == PaperKind.Custom)
					{
						size.Width = pageSettings_0.PaperSize.Width;
						size.Height = pageSettings_0.PaperSize.Height;
					}
					else
					{
						size = smethod_1(pageSettings_0.PaperSize.Kind);
					}
				}
				catch (Exception)
				{
					size = smethod_1(PaperKind.A4);
				}
				int num2 = size.Width;
				int num3 = size.Height;
				if (pageSettings_0.Landscape)
				{
					int num4 = num2;
					num2 = num3;
					num3 = num4;
				}
				return new Rectangle(0, 0, num2, num3);
			}
		}

		public static Size smethod_1(PaperKind paperKind_0)
		{
			if (paperKind_0 >= PaperKind.Custom && (int)paperKind_0 < size_0.Length)
			{
				return size_0[(int)paperKind_0];
			}
			return Size.Empty;
		}

		static XPaperSizeCollection()
		{
			size_0 = null;
			size_0 = new Size[120];
			size_0[66] = new Size(1654, 2339);
			size_0[8] = new Size(1169, 1654);
			size_0[63] = new Size(1268, 1752);
			size_0[68] = new Size(1268, 1752);
			size_0[76] = new Size(1654, 1169);
			size_0[67] = new Size(1169, 1654);
			size_0[9] = new Size(827, 1169);
			size_0[53] = new Size(929, 1268);
			size_0[60] = new Size(827, 1299);
			size_0[77] = new Size(1169, 827);
			size_0[10] = new Size(827, 1169);
			size_0[55] = new Size(827, 1169);
			size_0[11] = new Size(583, 827);
			size_0[64] = new Size(685, 925);
			size_0[78] = new Size(827, 583);
			size_0[61] = new Size(583, 827);
			size_0[70] = new Size(413, 583);
			size_0[83] = new Size(583, 413);
			size_0[57] = new Size(894, 1402);
			size_0[12] = new Size(984, 1390);
			size_0[33] = new Size(984, 1390);
			size_0[13] = new Size(693, 984);
			size_0[34] = new Size(693, 984);
			size_0[65] = new Size(791, 1087);
			size_0[80] = new Size(1012, 717);
			size_0[62] = new Size(717, 1012);
			size_0[35] = new Size(693, 492);
			size_0[88] = new Size(504, 717);
			size_0[58] = new Size(1201, 1917);
			size_0[29] = new Size(1201, 1917);
			size_0[30] = new Size(902, 1276);
			size_0[28] = new Size(638, 902);
			size_0[32] = new Size(449, 902);
			size_0[31] = new Size(449, 638);
			size_0[24] = new Size(449, 638);
			size_0[27] = new Size(433, 866);
			size_0[25] = new Size(2201, 3402);
			size_0[26] = new Size(3402, 4402);
			size_0[7] = new Size(724, 1051);
			size_0[14] = new Size(850, 1299);
			size_0[41] = new Size(850, 1299);
			size_0[40] = new Size(850, 1201);
			size_0[47] = new Size(866, 866);
			size_0[42] = new Size(984, 1390);
			size_0[36] = new Size(433, 906);
			size_0[69] = new Size(787, 583);
			size_0[82] = new Size(583, 787);
			size_0[43] = new Size(394, 583);
			size_0[81] = new Size(583, 394);
			size_0[4] = new Size(1701, 1098);
			size_0[5] = new Size(850, 1402);
			size_0[51] = new Size(929, 1500);
			size_0[1] = new Size(850, 1098);
			size_0[50] = new Size(929, 1197);
			size_0[56] = new Size(929, 1201);
			size_0[59] = new Size(850, 1268);
			size_0[75] = new Size(1098, 850);
			size_0[2] = new Size(850, 1098);
			size_0[54] = new Size(827, 1098);
			size_0[37] = new Size(386, 752);
			size_0[18] = new Size(850, 1098);
			size_0[20] = new Size(413, 949);
			size_0[38] = new Size(362, 650);
			size_0[93] = new Size(575, 846);
			size_0[106] = new Size(575, 846);
			size_0[94] = new Size(382, 594);
			size_0[95] = new Size(382, 594);
			size_0[108] = new Size(382, 594);
			size_0[107] = new Size(382, 594);
			size_0[96] = new Size(402, 650);
			size_0[105] = new Size(1276, 1803);
			size_0[118] = new Size(1803, 1276);
			size_0[109] = new Size(650, 402);
			size_0[97] = new Size(402, 693);
			size_0[110] = new Size(693, 402);
			size_0[98] = new Size(492, 693);
			size_0[111] = new Size(693, 492);
			size_0[99] = new Size(433, 819);
			size_0[112] = new Size(819, 433);
			size_0[100] = new Size(433, 866);
			size_0[113] = new Size(866, 433);
			size_0[101] = new Size(472, 906);
			size_0[114] = new Size(906, 472);
			size_0[102] = new Size(630, 906);
			size_0[115] = new Size(906, 630);
			size_0[103] = new Size(472, 1217);
			size_0[116] = new Size(1217, 472);
			size_0[104] = new Size(902, 1276);
			size_0[117] = new Size(902, 1276);
			size_0[15] = new Size(846, 1083);
			size_0[45] = new Size(1000, 1098);
			size_0[16] = new Size(1000, 1402);
			size_0[17] = new Size(1098, 1701);
			size_0[90] = new Size(1201, 1098);
			size_0[46] = new Size(1500, 1098);
			size_0[44] = new Size(902, 1098);
			size_0[6] = new Size(551, 850);
			size_0[3] = new Size(1098, 1701);
			size_0[52] = new Size(1169, 1799);
			size_0[39] = new Size(1488, 1098);
		}
	}
}

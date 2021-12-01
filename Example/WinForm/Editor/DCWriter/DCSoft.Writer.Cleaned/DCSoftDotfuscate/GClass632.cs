using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass632
	{
		public const int int_0 = 8;

		private GClass653 gclass653_0;

		private GClass636 gclass636_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private GClass658 gclass658_0;

		public GClass653 method_0()
		{
			return gclass653_0;
		}

		public void method_1(GClass653 gclass653_1)
		{
			gclass653_0 = gclass653_1;
		}

		public GClass636 method_2()
		{
			return gclass636_0;
		}

		public void method_3(GClass636 gclass636_1)
		{
			gclass636_0 = gclass636_1;
		}

		public int method_4()
		{
			return int_1;
		}

		public void method_5(int int_8)
		{
			int_1 = int_8;
		}

		public int method_6()
		{
			return int_2;
		}

		public void method_7(int int_8)
		{
			int_2 = int_8;
		}

		public int method_8()
		{
			return int_3;
		}

		public void method_9(int int_8)
		{
			int_3 = int_8;
		}

		public int method_10()
		{
			return int_4;
		}

		public void method_11(int int_8)
		{
			int_4 = int_8;
		}

		public int method_12()
		{
			return int_5;
		}

		public void method_13(int int_8)
		{
			int_5 = int_8;
		}

		public int method_14()
		{
			return int_6;
		}

		public void method_15(int int_8)
		{
			int_6 = int_8;
		}

		public int method_16()
		{
			return int_7;
		}

		public void method_17(int int_8)
		{
			int_7 = int_8;
		}

		public GClass658 method_18()
		{
			return gclass658_0;
		}

		public void method_19(GClass658 gclass658_1)
		{
			gclass658_0 = gclass658_1;
		}

		public bool method_20()
		{
			return gclass653_0 != null && gclass636_0 != null && int_1 != -1 && int_2 != -1 && int_3 != -1 && int_4 != -1 && int_5 != -1 && int_6 != -1 && int_7 != -1 && smethod_0(int_3) && int_4 == int_5 + int_6 && gclass658_0 != null && int_2 == gclass658_0.method_1() && gclass658_0.method_1() == gclass658_0.method_0();
		}

		public GClass632()
		{
			gclass653_0 = null;
			gclass636_0 = null;
			int_1 = -1;
			int_2 = -1;
			int_3 = -1;
			int_4 = -1;
			int_5 = -1;
			int_6 = -1;
			int_7 = -1;
			gclass658_0 = null;
		}

		public int method_21(int int_8, int int_9)
		{
			int num = 17;
			int num2 = gclass658_0.method_3(int_8, int_9);
			if (num2 != 0 && num2 != 1)
			{
				throw new SystemException("Bad value");
			}
			return num2;
		}

		public override string ToString()
		{
			int num = 18;
			StringBuilder stringBuilder = new StringBuilder(200);
			stringBuilder.Append("<<\n");
			stringBuilder.Append(" mode: ");
			stringBuilder.Append(gclass653_0);
			stringBuilder.Append("\n ecLevel: ");
			stringBuilder.Append(gclass636_0);
			stringBuilder.Append("\n version: ");
			stringBuilder.Append(int_1);
			stringBuilder.Append("\n matrixWidth: ");
			stringBuilder.Append(int_2);
			stringBuilder.Append("\n maskPattern: ");
			stringBuilder.Append(int_3);
			stringBuilder.Append("\n numTotalBytes: ");
			stringBuilder.Append(int_4);
			stringBuilder.Append("\n numDataBytes: ");
			stringBuilder.Append(int_5);
			stringBuilder.Append("\n numECBytes: ");
			stringBuilder.Append(int_6);
			stringBuilder.Append("\n numRSBlocks: ");
			stringBuilder.Append(int_7);
			if (gclass658_0 == null)
			{
				stringBuilder.Append("\n matrix: null\n");
			}
			else
			{
				stringBuilder.Append("\n matrix:\n");
				stringBuilder.Append(gclass658_0.ToString());
			}
			stringBuilder.Append(">>\n");
			return stringBuilder.ToString();
		}

		public static bool smethod_0(int int_8)
		{
			return int_8 >= 0 && int_8 < 8;
		}
	}
}

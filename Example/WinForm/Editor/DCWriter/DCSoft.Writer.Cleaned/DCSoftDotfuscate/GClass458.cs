using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass458 : GClass454
	{
		private GClass468 gclass468_0;

		private GClass476 gclass476_0;

		private float float_0 = 0f;

		private int int_0 = 100;

		private float float_1 = 0f;

		private float float_2 = 0f;

		private GClass542 gclass542_0 = new GClass542();

		public GClass458(GClass468 gclass468_1)
		{
			gclass468_0 = gclass468_1;
		}

		private string method_5(Color color_0)
		{
			return Class207.smethod_1(Math.Round((float)(int)color_0.R / 255f, 3)) + " " + Class207.smethod_1(Math.Round((float)(int)color_0.G / 255f, 3)) + " " + Class207.smethod_1(Math.Round((float)(int)color_0.B / 255f, 3));
		}

		public void method_6()
		{
			gclass542_0.method_0("q");
		}

		public void method_7()
		{
			gclass542_0.method_0("Q");
		}

		public void method_8(float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " " + Class207.smethod_0(float_5) + " " + Class207.smethod_0(float_6) + " " + Class207.smethod_0(float_7) + " " + Class207.smethod_0(float_8) + " cm");
		}

		public void method_9(int int_1)
		{
			int num = 18;
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			if (int_1 > 100)
			{
				int_1 = 100;
			}
			gclass542_0.method_0(Convert.ToString(int_1) + " i");
		}

		internal void method_10(Enum27 enum27_0)
		{
			gclass542_0.method_0(Convert.ToString(Convert.ToInt16(enum27_0)) + " J");
		}

		public void method_11(float[] float_3, int int_1)
		{
			int num = 0;
			gclass542_0.method_1("[", bool_0: false);
			for (int i = 0; i < float_3.Length; i++)
			{
				gclass542_0.method_1(Class207.smethod_0(float_3[i]), bool_0: false);
				if (i < float_3.Length - 1)
				{
					gclass542_0.method_1(" ", bool_0: false);
				}
			}
			gclass542_0.method_0("] " + Convert.ToString(int_1) + " d");
		}

		internal void method_12(Enum28 enum28_0)
		{
			gclass542_0.method_0(Convert.ToString(Convert.ToInt16(enum28_0)) + " j");
		}

		public void method_13(float float_3)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " w");
		}

		public void method_14(int int_1)
		{
			gclass542_0.method_0(Convert.ToString(int_1) + " M");
		}

		public void method_15(Color color_0)
		{
			gclass542_0.method_0(method_5(color_0) + " rg");
		}

		public void method_16(Color color_0)
		{
			gclass542_0.method_0(method_5(color_0) + " RG");
		}

		public void method_17(float float_3, float float_4)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " m");
		}

		public void method_18(float float_3, float float_4)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " l");
		}

		public void method_19(float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " " + Class207.smethod_0(float_5) + " " + Class207.smethod_0(float_6) + " " + Class207.smethod_0(float_7) + " " + Class207.smethod_0(float_8) + " c");
		}

		public void method_20(float float_3, float float_4, float float_5, float float_6)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " " + Class207.smethod_0(float_5) + " " + Class207.smethod_0(float_6) + " v");
		}

		public void method_21(float float_3, float float_4, float float_5, float float_6)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " " + Class207.smethod_0(float_5) + " " + Class207.smethod_0(float_6) + " y");
		}

		public void method_22(float float_3, float float_4, float float_5, float float_6)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " " + Class207.smethod_0(float_5) + " " + Class207.smethod_0(float_6) + " re");
		}

		public void method_23()
		{
			gclass542_0.method_0("h");
		}

		public void method_24()
		{
			gclass542_0.method_0("n");
		}

		public void method_25()
		{
			gclass542_0.method_0("S");
		}

		public void method_26()
		{
			gclass542_0.method_0("s");
		}

		public void method_27()
		{
			gclass542_0.method_0("f");
		}

		public void method_28()
		{
			gclass542_0.method_0("f*");
		}

		public void method_29()
		{
			gclass542_0.method_0("B");
		}

		public void method_30()
		{
			gclass542_0.method_0("b");
		}

		public void method_31()
		{
			gclass542_0.method_0("B*");
		}

		public void method_32()
		{
			gclass542_0.method_0("b*");
		}

		public void method_33()
		{
			gclass542_0.method_0("W");
		}

		public void method_34()
		{
			gclass542_0.method_0("W*");
		}

		public void method_35()
		{
			gclass542_0.method_0("BT");
		}

		public void method_36()
		{
			gclass542_0.method_0("ET");
		}

		public void method_37(GClass476 gclass476_1, float float_3)
		{
			int num = 1;
			if (gclass476_1 != null && gclass476_1.Name != null && !(float_3 < 0f) && !(float_3 > 300f))
			{
				gclass468_0.method_13().method_4(gclass476_1);
				gclass542_0.method_0("/" + gclass476_1.Name + " " + Class207.smethod_0(float_3) + "  Tf");
				gclass476_0 = gclass476_1;
				float_0 = float_3;
			}
		}

		public void method_38(float float_3, float float_4)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " Td");
		}

		public void method_39()
		{
			gclass542_0.method_0("T*");
		}

		public void method_40(string string_0)
		{
			gclass476_0.method_16(string_0);
			gclass542_0.method_2(string_0, gclass476_0);
			gclass542_0.method_0(" Tj");
		}

		public void method_41(string string_0)
		{
			gclass476_0.method_16(string_0);
			gclass542_0.method_2(string_0, gclass476_0);
			gclass542_0.method_0(" '");
		}

		public void method_42(float float_3)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " Tc");
			float_1 = float_3;
		}

		public void method_43(float float_3)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " Tw");
			float_2 = float_3;
		}

		public void method_44(int int_1)
		{
			int num = 14;
			if (int_1 >= 0)
			{
				gclass542_0.method_0(Convert.ToString(int_1) + " Tz");
				int_0 = int_1;
			}
		}

		public void method_45(float float_3)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " TL");
		}

		internal void method_46(Enum26 enum26_0)
		{
			gclass542_0.method_0(Convert.ToString(Convert.ToInt16(enum26_0)) + " Tr");
		}

		public void method_47(int int_1)
		{
			gclass542_0.method_0(Convert.ToString(int_1) + " Ts");
		}

		public void method_48(float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
		{
			gclass542_0.method_0(Class207.smethod_0(float_3) + " " + Class207.smethod_0(float_4) + " " + Class207.smethod_0(float_5) + " " + Class207.smethod_0(float_6) + " " + Class207.smethod_0(float_7) + " " + Class207.smethod_0(float_8) + " Tm");
		}

		public void method_49(GClass455 gclass455_0)
		{
			int num = 3;
			if (gclass455_0 != null)
			{
				gclass542_0.method_0("/" + gclass455_0.Name + " Do");
			}
		}

		public void method_50(float float_3, float float_4, GClass455 gclass455_0)
		{
			if (gclass455_0 != null)
			{
				method_51(float_3, float_4, gclass455_0.vmethod_3(), gclass455_0.vmethod_4(), gclass455_0);
			}
		}

		public void method_51(float float_3, float float_4, float float_5, float float_6, GClass455 gclass455_0)
		{
			if (gclass455_0 != null && gclass468_0 != null)
			{
				gclass468_0.method_12().method_2(gclass455_0);
				method_6();
				method_24();
				method_8(float_5, 0f, 0f, float_6, float_3, float_4);
				method_49(gclass455_0);
				method_23();
				method_7();
			}
		}

		public void method_52(float float_3, float float_4, float float_5, float float_6, float float_7, float float_8, float float_9, float float_10, GClass455 gclass455_0)
		{
			if (gclass455_0 != null && gclass468_0 != null)
			{
				gclass468_0.method_12().method_2(gclass455_0);
				method_6();
				method_22(float_7, float_8, float_9, float_10);
				method_33();
				method_24();
				method_8(float_5, 0f, 0f, float_6, float_3, float_4);
				method_49(gclass455_0);
				method_23();
				method_7();
			}
		}

		public float[] method_53(char[] char_0)
		{
			if (gclass476_0 == null)
			{
				return null;
			}
			if (char_0 == null || char_0.Length == 0)
			{
				return null;
			}
			float[] array = new float[char_0.Length];
			for (int i = 0; i < char_0.Length; i++)
			{
				float num = gclass476_0.method_10(char_0[i]) / 1000f * float_0;
				if (int_0 != 100)
				{
					num *= (float)int_0 / 100f;
				}
				num = (array[i] = ((!(num > 0f)) ? 0f : (num + float_1)));
			}
			return array;
		}

		public float method_54(string string_0)
		{
			if (gclass476_0 == null)
			{
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < string_0.Length; i++)
			{
				float num2 = gclass476_0.method_10(string_0[i]) / 1000f * float_0;
				if (int_0 != 100)
				{
					num2 *= (float)int_0 / 100f;
				}
				num2 = ((!(num2 > 0f)) ? 0f : (num2 + float_1));
				if (string_0[i] == ' ' && i < string_0.Length - 1)
				{
					num2 += float_2;
				}
				num += num2;
			}
			return num;
		}

		public override void vmethod_2()
		{
			gclass542_0.method_4(method_3());
		}
	}
}

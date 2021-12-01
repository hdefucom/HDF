using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass425
	{
		private GClass425 gclass425_0 = null;

		private int int_0 = -1;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private bool bool_3 = false;

		private Color color_0 = Color.Black;

		private int int_1 = 0;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private bool bool_4 = false;

		private int int_2 = 0;

		private bool bool_5 = false;

		private int int_3 = 100;

		private int int_4 = 0;

		private int int_5 = 0;

		private int int_6 = 0;

		private int int_7 = 0;

		private bool bool_6 = false;

		private int int_8 = 0;

		private int int_9 = 0;

		private GEnum80 genum80_0 = GEnum80.const_0;

		private bool bool_7 = false;

		public int int_10 = 0;

		private string string_0 = Control.DefaultFont.Name;

		private float float_0 = 12f;

		private int int_11 = -1;

		private bool bool_8 = false;

		private bool bool_9 = false;

		private bool bool_10 = false;

		private bool bool_11 = false;

		private bool bool_12 = false;

		private Color color_1 = Color.Black;

		private Color color_2 = Color.Empty;

		private string string_1 = null;

		private bool bool_13 = false;

		private bool bool_14 = false;

		private int int_12 = -1;

		private int int_13 = -1;

		private bool bool_15 = true;

		internal bool bool_16 = true;

		public GClass425 method_0()
		{
			return gclass425_0;
		}

		public int method_1()
		{
			return int_0;
		}

		public void method_2(int int_14)
		{
			int_0 = int_14;
		}

		public bool method_3()
		{
			return bool_0;
		}

		public void method_4(bool bool_17)
		{
			bool_0 = bool_17;
		}

		public bool method_5()
		{
			return bool_1;
		}

		public void method_6(bool bool_17)
		{
			bool_1 = bool_17;
		}

		public bool method_7()
		{
			return bool_2;
		}

		public void method_8(bool bool_17)
		{
			bool_2 = bool_17;
		}

		public bool method_9()
		{
			return bool_3;
		}

		public void method_10(bool bool_17)
		{
			bool_3 = bool_17;
		}

		public Color method_11()
		{
			return color_0;
		}

		public void method_12(Color color_3)
		{
			color_0 = color_3;
		}

		public int method_13()
		{
			return int_1;
		}

		public void method_14(int int_14)
		{
			int_1 = int_14;
		}

		public DashStyle method_15()
		{
			return dashStyle_0;
		}

		public void method_16(DashStyle dashStyle_1)
		{
			dashStyle_0 = dashStyle_1;
		}

		public bool method_17()
		{
			return bool_4;
		}

		public void method_18(bool bool_17)
		{
			bool_4 = bool_17;
		}

		public int method_19()
		{
			return int_2;
		}

		public void method_20(int int_14)
		{
			int_2 = int_14;
		}

		public bool method_21()
		{
			return bool_5;
		}

		public void method_22(bool bool_17)
		{
			bool_5 = bool_17;
		}

		public int method_23()
		{
			return int_3;
		}

		public void method_24(int int_14)
		{
			int_3 = int_14;
		}

		public int method_25()
		{
			return int_4;
		}

		public void method_26(int int_14)
		{
			int_4 = int_14;
		}

		public int method_27()
		{
			return int_5;
		}

		public void method_28(int int_14)
		{
			int_5 = int_14;
		}

		public int method_29()
		{
			return int_6;
		}

		public void method_30(int int_14)
		{
			int_6 = int_14;
		}

		public int method_31()
		{
			return int_7;
		}

		public void method_32(int int_14)
		{
			int_7 = int_14;
		}

		public bool method_33()
		{
			return bool_6;
		}

		public void method_34(bool bool_17)
		{
			bool_6 = bool_17;
		}

		public int method_35()
		{
			return int_8;
		}

		public void method_36(int int_14)
		{
			int_8 = int_14;
		}

		public int method_37()
		{
			return int_9;
		}

		public void method_38(int int_14)
		{
			int_9 = int_14;
		}

		public GEnum80 method_39()
		{
			return genum80_0;
		}

		public void method_40(GEnum80 genum80_1)
		{
			genum80_0 = genum80_1;
		}

		public bool method_41()
		{
			return bool_7;
		}

		public void method_42(bool bool_17)
		{
			bool_7 = bool_17;
		}

		public void method_43(StringAlignment stringAlignment_0)
		{
			switch (stringAlignment_0)
			{
			case StringAlignment.Center:
				method_40(GEnum80.const_1);
				break;
			case StringAlignment.Far:
				method_40(GEnum80.const_2);
				break;
			default:
				method_40(GEnum80.const_0);
				break;
			}
		}

		public void method_44(Font font_0)
		{
			if (font_0 != null)
			{
				method_46(font_0.Name);
				method_48(font_0.Size);
				method_52(font_0.Bold);
				method_54(font_0.Italic);
				method_56(font_0.Underline);
				method_58(font_0.Strikeout);
			}
		}

		public string method_45()
		{
			return string_0;
		}

		public void method_46(string string_2)
		{
			string_0 = string_2;
		}

		public float method_47()
		{
			return float_0;
		}

		public void method_48(float float_1)
		{
			float_0 = float_1;
		}

		public int method_49()
		{
			return int_11;
		}

		public void method_50(int int_14)
		{
			int_11 = int_14;
		}

		public bool method_51()
		{
			return bool_8;
		}

		public void method_52(bool bool_17)
		{
			bool_8 = bool_17;
		}

		public bool method_53()
		{
			return bool_9;
		}

		public void method_54(bool bool_17)
		{
			bool_9 = bool_17;
		}

		public bool method_55()
		{
			return bool_10;
		}

		public void method_56(bool bool_17)
		{
			bool_10 = bool_17;
		}

		public bool method_57()
		{
			return bool_11;
		}

		public void method_58(bool bool_17)
		{
			bool_11 = bool_17;
		}

		public bool method_59()
		{
			return bool_12;
		}

		public void method_60(bool bool_17)
		{
			bool_12 = bool_17;
		}

		public Color method_61()
		{
			return color_1;
		}

		public void method_62(Color color_3)
		{
			color_1 = color_3;
		}

		public Color method_63()
		{
			return color_2;
		}

		public void method_64(Color color_3)
		{
			color_2 = color_3;
		}

		public string method_65()
		{
			return string_1;
		}

		public void method_66(string string_2)
		{
			string_1 = string_2;
		}

		public bool method_67()
		{
			return bool_13;
		}

		public void method_68(bool bool_17)
		{
			bool_13 = bool_17;
			if (bool_13)
			{
				bool_14 = false;
			}
		}

		public bool method_69()
		{
			return bool_14;
		}

		public void method_70(bool bool_17)
		{
			bool_14 = bool_17;
			if (bool_14)
			{
				bool_13 = false;
			}
		}

		public int method_71()
		{
			return int_12;
		}

		public void method_72(int int_14)
		{
			int_12 = int_14;
		}

		public int method_73()
		{
			return int_13;
		}

		public void method_74(int int_14)
		{
			int_13 = int_14;
		}

		public bool method_75()
		{
			return bool_15;
		}

		public void method_76(bool bool_17)
		{
			bool_15 = bool_17;
		}

		public bool method_77(GClass425 gclass425_1)
		{
			if (gclass425_1 == this)
			{
				return true;
			}
			if (gclass425_1 == null)
			{
				return false;
			}
			if (method_39() != gclass425_1.method_39())
			{
				return false;
			}
			if (method_63() != gclass425_1.method_63())
			{
				return false;
			}
			if (method_51() != gclass425_1.method_51())
			{
				return false;
			}
			if (method_11() != gclass425_1.method_11())
			{
				return false;
			}
			if (method_3() != gclass425_1.method_3())
			{
				return false;
			}
			if (method_5() != gclass425_1.method_5())
			{
				return false;
			}
			if (method_7() != gclass425_1.method_7())
			{
				return false;
			}
			if (method_9() != gclass425_1.method_9())
			{
				return false;
			}
			if (method_15() != gclass425_1.method_15())
			{
				return false;
			}
			if (method_17() != gclass425_1.method_17())
			{
				return false;
			}
			if (method_19() != gclass425_1.method_19())
			{
				return false;
			}
			if (method_71() != gclass425_1.method_71())
			{
				return false;
			}
			if (method_73() != gclass425_1.method_73())
			{
				return false;
			}
			if (method_45() != gclass425_1.method_45())
			{
				return false;
			}
			if (method_47() != gclass425_1.method_47())
			{
				return false;
			}
			if (method_53() != gclass425_1.method_53())
			{
				return false;
			}
			if (method_59() != gclass425_1.method_59())
			{
				return false;
			}
			if (method_27() != gclass425_1.method_27())
			{
				return false;
			}
			if (method_31() != gclass425_1.method_31())
			{
				return false;
			}
			if (method_65() != gclass425_1.method_65())
			{
				return false;
			}
			if (method_21() != gclass425_1.method_21())
			{
				return false;
			}
			if (method_75() != gclass425_1.method_75())
			{
				return false;
			}
			if (method_25() != gclass425_1.method_25())
			{
				return false;
			}
			if (method_29() != gclass425_1.method_29())
			{
				return false;
			}
			if (method_23() != gclass425_1.method_23())
			{
				return false;
			}
			if (method_57() != gclass425_1.method_57())
			{
				return false;
			}
			if (method_69() != gclass425_1.method_69())
			{
				return false;
			}
			if (method_67() != gclass425_1.method_67())
			{
				return false;
			}
			if (method_61() != gclass425_1.method_61())
			{
				return false;
			}
			if (method_55() != gclass425_1.method_55())
			{
				return false;
			}
			if (bool_16 != gclass425_1.bool_16)
			{
				return false;
			}
			return true;
		}

		public GClass425 method_78()
		{
			return (GClass425)MemberwiseClone();
		}

		public void method_79()
		{
			method_46(Control.DefaultFont.Name);
			method_48(12f);
			method_52(bool_17: false);
			method_54(bool_17: false);
			method_56(bool_17: false);
			method_58(bool_17: false);
			method_62(Color.Black);
			method_64(Color.Empty);
			method_70(bool_17: false);
			method_68(bool_17: false);
			method_22(bool_17: true);
			method_60(bool_17: false);
			method_4(bool_17: false);
			method_6(bool_17: false);
			method_8(bool_17: false);
			method_10(bool_17: false);
			method_16(DashStyle.Solid);
			method_20(0);
			method_18(bool_17: false);
			method_12(Color.Black);
		}

		public void method_80()
		{
			method_2(-1);
			method_74(-1);
			method_26(0);
			method_40(GEnum80.const_0);
			method_72(-1);
			method_28(0);
			method_32(0);
			method_42(bool_17: false);
			method_4(bool_17: false);
			method_6(bool_17: false);
			method_8(bool_17: false);
			method_10(bool_17: false);
			method_16(DashStyle.Solid);
			method_20(0);
			method_18(bool_17: false);
			method_12(Color.Black);
			method_34(bool_17: false);
			method_36(0);
			method_38(0);
		}

		public void method_81()
		{
			method_2(-1);
			method_26(0);
			method_74(-1);
			method_28(0);
			method_28(0);
			method_30(0);
			method_32(0);
			method_34(bool_17: false);
			method_36(0);
			method_38(0);
			method_40(GEnum80.const_0);
			method_46(Control.DefaultFont.Name);
			method_48(12f);
			method_52(bool_17: false);
			method_54(bool_17: false);
			method_56(bool_17: false);
			method_58(bool_17: false);
			method_62(Color.Black);
			method_64(Color.Empty);
			method_66(null);
			method_70(bool_17: false);
			method_68(bool_17: false);
			method_72(-1);
			method_22(bool_17: true);
			method_76(bool_17: true);
			method_4(bool_17: false);
			method_6(bool_17: false);
			method_8(bool_17: false);
			method_10(bool_17: false);
			method_16(DashStyle.Solid);
			method_20(0);
			method_18(bool_17: false);
			method_12(Color.Black);
			bool_16 = true;
			int_10 = 0;
			method_60(bool_17: false);
		}
	}
}

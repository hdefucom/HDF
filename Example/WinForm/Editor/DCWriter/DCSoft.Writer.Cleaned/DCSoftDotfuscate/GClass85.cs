using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass85 : GClass84
	{
		protected internal int int_8;

		protected internal int int_9;

		protected internal int int_10;

		[NonSerialized]
		protected internal GInterface16 ginterface16_0;

		protected internal int int_11;

		protected internal int int_12;

		protected internal int int_13;

		protected internal string string_0;

		protected internal int int_14;

		public GClass85(GInterface12 ginterface12_0)
		{
			int_9 = -1;
			int_8 = 0;
			int_10 = -1;
			string_0 = ginterface12_0.imethod_6();
			int_14 = ginterface12_0.imethod_10();
			int_11 = ginterface12_0.imethod_4();
			int_10 = ginterface12_0.imethod_8();
			int_9 = ginterface12_0.imethod_2();
			int_8 = ginterface12_0.imethod_0();
		}

		public GClass85(int int_15)
		{
			int_9 = -1;
			int_8 = 0;
			int_10 = -1;
			int_14 = int_15;
		}

		public GClass85(int int_15, string string_1)
		{
			int_9 = -1;
			int_8 = 0;
			int_10 = -1;
			int_14 = int_15;
			int_8 = 0;
			string_0 = string_1;
		}

		public GClass85(GInterface16 ginterface16_1, int int_15, int int_16, int int_17, int int_18)
		{
			int_9 = -1;
			int_8 = 0;
			int_10 = -1;
			ginterface16_0 = ginterface16_1;
			int_14 = int_15;
			int_8 = int_16;
			int_12 = int_17;
			int_13 = int_18;
		}

		public override string ToString()
		{
			int num = 2;
			string text = "";
			if (int_8 > 0)
			{
				text = ",channel=" + int_8;
			}
			string text2 = imethod_6();
			text2 = ((text2 == null) ? "<no text>" : text2.Replace("\n", "\\\\n").Replace("\r", "\\\\r").Replace("\t", "\\\\t"));
			return "[@" + imethod_8() + "," + int_12 + ":" + int_13 + "='" + text2 + "',<" + int_14 + ">" + text + "," + int_11 + ":" + imethod_2() + "]";
		}

		public override int imethod_0()
		{
			return int_8;
		}

		public override void imethod_1(int int_15)
		{
			int_8 = int_15;
		}

		public override int imethod_2()
		{
			return int_9;
		}

		public override void imethod_3(int int_15)
		{
			int_9 = int_15;
		}

		public override int imethod_4()
		{
			return int_11;
		}

		public override void imethod_5(int int_15)
		{
			int_11 = int_15;
		}

		public virtual int vmethod_0()
		{
			return int_12;
		}

		public virtual void vmethod_1(int int_15)
		{
			int_12 = int_15;
		}

		public virtual int vmethod_2()
		{
			return int_13;
		}

		public virtual void vmethod_3(int int_15)
		{
			int_13 = int_15;
		}

		public override string imethod_6()
		{
			if (string_0 == null)
			{
				if (ginterface16_0 == null)
				{
					return null;
				}
				string_0 = ginterface16_0.imethod_10(int_12, int_13);
			}
			return string_0;
		}

		public override void imethod_7(string string_1)
		{
			string_0 = string_1;
		}

		public override int imethod_8()
		{
			return int_10;
		}

		public override void imethod_9(int int_15)
		{
			int_10 = int_15;
		}

		public override int imethod_10()
		{
			return int_14;
		}

		public override void imethod_11(int int_15)
		{
			int_14 = int_15;
		}
	}
}

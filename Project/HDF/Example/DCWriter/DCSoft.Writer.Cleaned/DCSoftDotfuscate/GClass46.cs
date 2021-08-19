using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass46 : GClass45, GInterface10
	{
		private const int int_8 = -1;

		protected int int_9;

		protected internal GInterface16 ginterface16_0;

		protected string string_1;

		protected internal GInterface12 ginterface12_0;

		protected internal int int_10;

		protected int int_11;

		protected int int_12;

		protected int int_13;

		public GClass46()
		{
			int_10 = -1;
		}

		public GClass46(GInterface16 ginterface16_1)
		{
			int_10 = -1;
			ginterface16_0 = ginterface16_1;
		}

		public virtual GInterface12 vmethod_33()
		{
			GInterface12 gInterface = new GClass85(ginterface16_0, int_13, int_9, int_10, vmethod_43() - 1);
			gInterface.imethod_5(int_12);
			gInterface.imethod_7(string_1);
			gInterface.imethod_3(int_11);
			vmethod_34(gInterface);
			return gInterface;
		}

		public virtual void vmethod_34(GInterface12 ginterface12_1)
		{
			ginterface12_0 = ginterface12_1;
		}

		public string method_3(int int_14)
		{
			int num = 9;
			string str;
			switch (int_14)
			{
			case 9:
				str = "\\t";
				break;
			case 10:
				str = "\\n";
				break;
			default:
				str = Convert.ToString((char)int_14);
				break;
			case 13:
				str = "\\r";
				break;
			case -1:
				str = "<EOF>";
				break;
			}
			return "'" + str + "'";
		}

		public override string vmethod_13(GException4 gexception4_0, string[] string_2)
		{
			int num = 7;
			if (gexception4_0 is GException9)
			{
				GException9 gException = (GException9)gexception4_0;
				return "mismatched character " + method_3(gexception4_0.method_0()) + " expecting " + method_3(gException.int_4);
			}
			if (gexception4_0 is GException5)
			{
				GException5 gException2 = (GException5)gexception4_0;
				return "no viable alternative at character " + method_3(gException2.method_0());
			}
			if (gexception4_0 is GException11)
			{
				GException11 gException3 = (GException11)gexception4_0;
				return "required (...)+ loop did not match anything at character " + method_3(gException3.method_0());
			}
			if (gexception4_0 is GException6)
			{
				GException6 gException4 = (GException6)gexception4_0;
				return "mismatched character " + method_3(gException4.method_0()) + " expecting set " + gException4.gclass83_0;
			}
			if (gexception4_0 is GException7)
			{
				GException6 gException5 = (GException6)gexception4_0;
				return "mismatched character " + method_3(gException5.method_0()) + " expecting set " + gException5.gclass83_0;
			}
			if (gexception4_0 is GException8)
			{
				GException8 gException6 = (GException8)gexception4_0;
				return "mismatched character " + method_3(gException6.method_0()) + " expecting set " + method_3(gException6.int_4) + ".." + method_3(gException6.int_5);
			}
			return base.vmethod_13(gexception4_0, string_2);
		}

		public virtual void vmethod_35(int int_14)
		{
			if (ginterface16_0.imethod_2(1) != int_14)
			{
				if (int_5 <= 0)
				{
					GException9 gException = new GException9(int_14, ginterface16_0);
					vmethod_40(gException);
					throw gException;
				}
				bool_1 = true;
			}
			else
			{
				ginterface16_0.imethod_0();
				bool_1 = false;
			}
		}

		public virtual void vmethod_36(string string_2)
		{
			int num = 0;
			while (true)
			{
				if (num < string_2.Length)
				{
					if (ginterface16_0.imethod_2(1) != string_2[num])
					{
						break;
					}
					num++;
					ginterface16_0.imethod_0();
					bool_1 = false;
					continue;
				}
				return;
			}
			if (int_5 <= 0)
			{
				GException9 gException = new GException9(string_2[num], ginterface16_0);
				vmethod_40(gException);
				throw gException;
			}
			bool_1 = true;
		}

		public virtual void vmethod_37()
		{
			ginterface16_0.imethod_0();
		}

		public virtual void vmethod_38(int int_14, int int_15)
		{
			if (ginterface16_0.imethod_2(1) < int_14 || ginterface16_0.imethod_2(1) > int_15)
			{
				if (int_5 <= 0)
				{
					GException8 gException = new GException8(int_14, int_15, ginterface16_0);
					vmethod_40(gException);
					throw gException;
				}
				bool_1 = true;
			}
			else
			{
				ginterface16_0.imethod_0();
				bool_1 = false;
			}
		}

		public abstract void vmethod_39();

		public virtual GInterface12 imethod_0()
		{
			while (true)
			{
				ginterface12_0 = null;
				int_9 = 0;
				int_10 = ginterface16_0.imethod_1();
				int_11 = ginterface16_0.imethod_11();
				int_12 = ginterface16_0.imethod_13();
				string_1 = null;
				if (ginterface16_0.imethod_2(1) == -1)
				{
					break;
				}
				try
				{
					vmethod_39();
					if (ginterface12_0 == null)
					{
						vmethod_33();
						goto IL_0034;
					}
					if (ginterface12_0 != GClass84.gclass84_2)
					{
						goto IL_0034;
					}
					goto end_IL_0003;
					IL_0034:
					return ginterface12_0;
					end_IL_0003:;
				}
				catch (GException4 gexception4_)
				{
					vmethod_25(gexception4_);
					vmethod_40(gexception4_);
				}
			}
			return GClass84.gclass84_0;
		}

		public virtual void vmethod_40(GException4 gexception4_0)
		{
			ginterface16_0.imethod_0();
		}

		public override void vmethod_25(GException4 gexception4_0)
		{
			vmethod_8(vmethod_32(), gexception4_0);
		}

		public override void vmethod_26()
		{
			base.vmethod_26();
			ginterface12_0 = null;
			int_13 = 0;
			int_9 = 0;
			int_10 = -1;
			int_11 = -1;
			int_12 = -1;
			string_1 = null;
			if (ginterface16_0 != null)
			{
				ginterface16_0.imethod_7(0);
			}
		}

		public void method_4()
		{
			ginterface12_0 = GClass84.gclass84_2;
		}

		public virtual void vmethod_41(string string_2, int int_14)
		{
			string object_ = (char)ginterface16_0.imethod_9(1) + " line=" + vmethod_46() + ":" + vmethod_44();
			base.vmethod_28(string_2, int_14, object_);
		}

		public virtual void vmethod_42(string string_2, int int_14)
		{
			string object_ = (char)ginterface16_0.imethod_9(1) + " line=" + vmethod_46() + ":" + vmethod_44();
			base.vmethod_29(string_2, int_14, object_);
		}

		public virtual int vmethod_43()
		{
			return ginterface16_0.imethod_1();
		}

		public virtual int vmethod_44()
		{
			return ginterface16_0.imethod_11();
		}

		public virtual void vmethod_45(GInterface16 ginterface16_1)
		{
			ginterface16_0 = null;
			vmethod_26();
			ginterface16_0 = ginterface16_1;
		}

		public override GInterface14 vmethod_31()
		{
			return ginterface16_0;
		}

		public virtual int vmethod_46()
		{
			return ginterface16_0.imethod_13();
		}

		public virtual string vmethod_47()
		{
			if (string_1 != null)
			{
				return string_1;
			}
			return ginterface16_0.imethod_10(int_10, vmethod_43() - 1);
		}

		public virtual void vmethod_48(string string_2)
		{
			string_1 = string_2;
		}
	}
}

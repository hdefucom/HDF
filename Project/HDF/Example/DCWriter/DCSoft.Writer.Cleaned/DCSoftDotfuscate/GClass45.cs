using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass45
	{
		public const int int_0 = 0;

		public const int int_1 = 99;

		public const int int_2 = 100;

		public const int int_3 = -2;

		public const int int_4 = -1;

		protected internal int int_5 = 0;

		protected internal bool bool_0 = false;

		protected internal bool bool_1 = false;

		protected GClass83[] gclass83_0 = new GClass83[100];

		protected int int_6 = -1;

		protected internal int int_7 = -1;

		public static readonly string string_0 = "nextToken";

		protected internal IDictionary[] idictionary_0;

		public virtual bool vmethod_0(GInterface14 ginterface14_0, int int_8)
		{
			int num = vmethod_15(int_8, ginterface14_0.imethod_1());
			switch (num)
			{
			default:
				ginterface14_0.imethod_7(num + 1);
				goto IL_0033;
			case -2:
				bool_1 = true;
				goto IL_0033;
			case -1:
				{
					return false;
				}
				IL_0033:
				return true;
			}
		}

		public virtual void vmethod_1(int int_8)
		{
		}

		public virtual void vmethod_2()
		{
		}

		protected internal virtual GClass83 vmethod_3(bool bool_2)
		{
			int num = int_6;
			GClass83 gClass = new GClass83();
			for (int num2 = num; num2 >= 0; num2--)
			{
				GClass83 gClass2 = gclass83_0[num2];
				gClass.vmethod_6(gClass2);
				if (bool_2 && !gClass2.vmethod_3(1))
				{
					break;
				}
			}
			gClass.vmethod_7(1);
			return gClass;
		}

		protected internal virtual GClass83 vmethod_4()
		{
			return vmethod_3(bool_2: true);
		}

		protected internal virtual GClass83 vmethod_5()
		{
			return vmethod_3(bool_2: false);
		}

		public virtual void vmethod_6(GInterface14 ginterface14_0, GClass83 gclass83_1)
		{
			int num = ginterface14_0.imethod_2(1);
			while (num != GClass84.int_6 && !gclass83_1.vmethod_3(num))
			{
				ginterface14_0.imethod_0();
				num = ginterface14_0.imethod_2(1);
			}
		}

		public virtual void vmethod_7(GInterface14 ginterface14_0, int int_8)
		{
			int num = ginterface14_0.imethod_2(1);
			while (num != GClass84.int_6 && num != int_8)
			{
				ginterface14_0.imethod_0();
				num = ginterface14_0.imethod_2(1);
			}
		}

		public virtual void vmethod_8(string[] string_1, GException4 gexception4_0)
		{
			vmethod_9(vmethod_12(gexception4_0) + " " + vmethod_13(gexception4_0, string_1));
		}

		public virtual void vmethod_9(string string_1)
		{
			Console.Error.WriteLine(string_1);
		}

		public virtual void vmethod_10(int int_8, bool bool_2)
		{
		}

		public virtual void vmethod_11()
		{
		}

		public virtual string vmethod_12(GException4 gexception4_0)
		{
			return "line " + gexception4_0.method_8() + ":" + gexception4_0.method_2();
		}

		public virtual string vmethod_13(GException4 gexception4_0, string[] string_1)
		{
			int num = 12;
			string result = null;
			if (gexception4_0 is GException9)
			{
				GException9 gException = (GException9)gexception4_0;
				string text = "<unknown>";
				return string.Concat(str3: (gException.int_4 != GClass84.int_6) ? string_1[gException.int_4] : "EOF", str0: "mismatched input ", str1: vmethod_16(gexception4_0.method_12()), str2: " expecting ");
			}
			if (gexception4_0 is GException10)
			{
				GException10 gException2 = (GException10)gexception4_0;
				string text2 = "<unknown>";
				text2 = ((gException2.int_4 != GClass84.int_6) ? string_1[gException2.int_4] : "EOF");
				return string.Concat("mismatched tree node: ", gException2.method_10(), " expecting ", text2);
			}
			if (gexception4_0 is GException5)
			{
				return "no viable alternative at input " + vmethod_16(gexception4_0.method_12());
			}
			if (gexception4_0 is GException11)
			{
				return "required (...)+ loop did not match anything at input " + vmethod_16(gexception4_0.method_12());
			}
			if (gexception4_0 is GException6)
			{
				GException6 gException3 = (GException6)gexception4_0;
				return "mismatched input " + vmethod_16(gexception4_0.method_12()) + " expecting set " + gException3.gclass83_0;
			}
			if (gexception4_0 is GException7)
			{
				GException7 gException4 = (GException7)gexception4_0;
				return "mismatched input " + vmethod_16(gexception4_0.method_12()) + " expecting set " + gException4.gclass83_0;
			}
			if (gexception4_0 is GException12)
			{
				GException12 gException5 = (GException12)gexception4_0;
				result = "rule " + gException5.string_1 + " failed predicate: {" + gException5.string_0 + "}?";
			}
			return result;
		}

		public virtual IList vmethod_14()
		{
			string fullName = GetType().FullName;
			return smethod_0(new Exception(), fullName);
		}

		public static IList smethod_0(Exception exception_0, string string_1)
		{
			int num = 6;
			IList list = new ArrayList();
			StackTrace stackTrace = new StackTrace(exception_0);
			int num2 = 0;
			for (num2 = stackTrace.FrameCount - 1; num2 >= 0; num2--)
			{
				StackFrame frame = stackTrace.GetFrame(num2);
				if (!frame.GetMethod().DeclaringType.FullName.StartsWith("Antlr.Runtime.") && !frame.GetMethod().Name.Equals(string_0) && frame.GetMethod().DeclaringType.FullName.Equals(string_1))
				{
					list.Add(frame.GetMethod().Name);
				}
			}
			return list;
		}

		public virtual int vmethod_15(int int_8, int int_9)
		{
			if (idictionary_0[int_8] == null)
			{
				idictionary_0[int_8] = new Hashtable();
			}
			object obj = idictionary_0[int_8][int_9];
			if (obj == null)
			{
				return -1;
			}
			return (int)obj;
		}

		public int method_0()
		{
			int num = 0;
			int num2 = 0;
			while (idictionary_0 != null && num2 < idictionary_0.Length)
			{
				IDictionary dictionary = idictionary_0[num2];
				if (dictionary != null)
				{
					num += dictionary.Count;
				}
				num2++;
			}
			return num;
		}

		public virtual string vmethod_16(GInterface12 ginterface12_0)
		{
			int num = 2;
			string text = ginterface12_0.imethod_6();
			if (text == null)
			{
				text = ((ginterface12_0.imethod_10() != GClass84.int_6) ? ("<" + ginterface12_0.imethod_10() + ">") : "<EOF>");
			}
			text = text.Replace("\n", "\\\\n").Replace("\r", "\\\\r").Replace("\t", "\\\\t");
			return "'" + text + "'";
		}

		public virtual void vmethod_17(GInterface14 ginterface14_0, int int_8, GClass83 gclass83_1)
		{
			if (ginterface14_0.imethod_2(1) == int_8)
			{
				ginterface14_0.imethod_0();
				bool_0 = false;
				bool_1 = false;
			}
			else if (int_5 > 0)
			{
				bool_1 = true;
			}
			else
			{
				vmethod_20(ginterface14_0, int_8, gclass83_1);
			}
		}

		public virtual void vmethod_18(GInterface14 ginterface14_0)
		{
			bool_0 = false;
			bool_1 = false;
			ginterface14_0.imethod_0();
		}

		public virtual void vmethod_19(GInterface14 ginterface14_0, int int_8, int int_9)
		{
			int num = bool_1 ? (-2) : (ginterface14_0.imethod_1() - 1);
			if (idictionary_0[int_8] != null)
			{
				idictionary_0[int_8][int_9] = num;
			}
		}

		protected internal virtual void vmethod_20(GInterface14 ginterface14_0, int int_8, GClass83 gclass83_1)
		{
			GException9 gexception4_ = new GException9(int_8, ginterface14_0);
			vmethod_24(ginterface14_0, gexception4_, int_8, gclass83_1);
		}

		protected void method_1(GClass83 gclass83_1)
		{
			if (int_6 + 1 >= gclass83_0.Length)
			{
				GClass83[] destinationArray = new GClass83[gclass83_0.Length * 2];
				Array.Copy(gclass83_0, 0, destinationArray, 0, gclass83_0.Length - 1);
				gclass83_0 = destinationArray;
			}
			gclass83_0[++int_6] = gclass83_1;
		}

		public virtual void vmethod_21(GInterface14 ginterface14_0, GException4 gexception4_0)
		{
			if (int_7 == ginterface14_0.imethod_1())
			{
				ginterface14_0.imethod_0();
			}
			int_7 = ginterface14_0.imethod_1();
			GClass83 gclass83_ = vmethod_5();
			vmethod_2();
			vmethod_6(ginterface14_0, gclass83_);
			vmethod_11();
		}

		protected internal virtual bool vmethod_22(GInterface14 ginterface14_0, GException4 gexception4_0, GClass83 gclass83_1)
		{
			if (gclass83_1 != null)
			{
				if (gclass83_1.vmethod_3(1))
				{
					GClass83 gClass = vmethod_4();
					gclass83_1 = gclass83_1.vmethod_5(gClass);
					gclass83_1.vmethod_7(1);
				}
				if (gclass83_1.vmethod_3(ginterface14_0.imethod_2(1)))
				{
					vmethod_25(gexception4_0);
					return true;
				}
			}
			return false;
		}

		public virtual void vmethod_23(GInterface14 ginterface14_0, GException4 gexception4_0, GClass83 gclass83_1)
		{
			if (!vmethod_22(ginterface14_0, gexception4_0, gclass83_1))
			{
				throw gexception4_0;
			}
		}

		public virtual void vmethod_24(GInterface14 ginterface14_0, GException4 gexception4_0, int int_8, GClass83 gclass83_1)
		{
			if (ginterface14_0.imethod_2(2) == int_8)
			{
				vmethod_25(gexception4_0);
				vmethod_2();
				ginterface14_0.imethod_0();
				vmethod_11();
				ginterface14_0.imethod_0();
			}
			else if (!vmethod_22(ginterface14_0, gexception4_0, gclass83_1))
			{
				throw gexception4_0;
			}
		}

		public virtual void vmethod_25(GException4 gexception4_0)
		{
			if (!bool_0)
			{
				bool_0 = true;
				vmethod_8(vmethod_32(), gexception4_0);
			}
		}

		public virtual void vmethod_26()
		{
			int_6 = -1;
			bool_0 = false;
			int_7 = -1;
			bool_1 = false;
			int_5 = 0;
			int num = 0;
			while (idictionary_0 != null && num < idictionary_0.Length)
			{
				idictionary_0[num] = null;
				num++;
			}
		}

		public virtual IList vmethod_27(IList ilist_0)
		{
			if (ilist_0 == null)
			{
				return null;
			}
			IList list = new ArrayList(ilist_0.Count);
			for (int i = 0; i < ilist_0.Count; i++)
			{
				list.Add(((GInterface12)ilist_0[i]).imethod_6());
			}
			return list;
		}

		public virtual void vmethod_28(string string_1, int int_8, object object_0)
		{
			int num = 6;
			Console.Out.Write("enter " + string_1 + " " + object_0);
			if (bool_1)
			{
				Console.Out.WriteLine(" failed=" + bool_1);
			}
			if (int_5 > 0)
			{
				Console.Out.Write(" backtracking=" + int_5);
			}
			Console.Out.WriteLine();
		}

		public virtual void vmethod_29(string string_1, int int_8, object object_0)
		{
			int num = 7;
			Console.Out.Write("exit " + string_1 + " " + object_0);
			if (bool_1)
			{
				Console.Out.WriteLine(" failed=" + bool_1);
			}
			if (int_5 > 0)
			{
				Console.Out.Write(" backtracking=" + int_5);
			}
			Console.Out.WriteLine();
		}

		public int method_2()
		{
			return int_5;
		}

		public virtual string vmethod_30()
		{
			return null;
		}

		public abstract GInterface14 vmethod_31();

		public virtual string[] vmethod_32()
		{
			return null;
		}
	}
}

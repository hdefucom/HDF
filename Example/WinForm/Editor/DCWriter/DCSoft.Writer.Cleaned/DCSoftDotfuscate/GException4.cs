using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException4 : Exception
	{
		protected int int_0;

		protected int int_1;

		protected int int_2;

		[NonSerialized]
		protected GInterface14 ginterface14_0;

		protected int int_3;

		protected object object_0;

		protected GInterface12 ginterface12_0;

		public GException4()
			: this(null, null, null)
		{
		}

		public GException4(GInterface14 ginterface14_1)
			: this(null, null, ginterface14_1)
		{
		}

		public GException4(string string_0)
			: this(string_0, null, null)
		{
		}

		public GException4(string string_0, GInterface14 ginterface14_1)
			: this(string_0, null, ginterface14_1)
		{
		}

		public GException4(string string_0, Exception exception_0)
			: this(string_0, exception_0, null)
		{
		}

		public GException4(string string_0, Exception exception_0, GInterface14 ginterface14_1)
			: base(string_0, exception_0)
		{
			ginterface14_0 = ginterface14_1;
			int_2 = ginterface14_1.imethod_1();
			if (ginterface14_1 is GInterface15)
			{
				ginterface12_0 = ((GInterface15)ginterface14_1).imethod_10(1);
				int_3 = ginterface12_0.imethod_4();
				int_1 = ginterface12_0.imethod_2();
			}
			if (ginterface14_1 is GClass89)
			{
				object_0 = ((GClass89)ginterface14_1).imethod_10(1);
				if (object_0 is GClass78)
				{
					ginterface12_0 = ((GClass78)object_0).vmethod_3();
					int_3 = ginterface12_0.imethod_4();
					int_1 = ginterface12_0.imethod_2();
				}
			}
			else if (ginterface14_1 is GInterface16)
			{
				int_0 = ginterface14_1.imethod_2(1);
				int_3 = ((GInterface16)ginterface14_1).imethod_13();
				int_1 = ((GInterface16)ginterface14_1).imethod_11();
			}
			else
			{
				int_0 = ginterface14_1.imethod_2(1);
			}
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_4)
		{
			int_0 = int_4;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_4)
		{
			int_1 = int_4;
		}

		public int method_4()
		{
			return int_2;
		}

		public void method_5(int int_4)
		{
			int_2 = int_4;
		}

		public GInterface14 method_6()
		{
			return ginterface14_0;
		}

		public void method_7(GInterface14 ginterface14_1)
		{
			ginterface14_0 = ginterface14_1;
		}

		public int method_8()
		{
			return int_3;
		}

		public void method_9(int int_4)
		{
			int_3 = int_4;
		}

		public object method_10()
		{
			return object_0;
		}

		public void method_11(object object_1)
		{
			object_0 = object_1;
		}

		public GInterface12 method_12()
		{
			return ginterface12_0;
		}

		public void method_13(GInterface12 ginterface12_1)
		{
			ginterface12_0 = ginterface12_1;
		}

		public virtual int vmethod_0()
		{
			if (ginterface14_0 is GInterface15)
			{
				return ginterface12_0.imethod_10();
			}
			return int_0;
		}
	}
}

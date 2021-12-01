using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass88 : GInterface16
	{
		protected internal int int_0;

		protected internal char[] char_0;

		protected int int_1;

		protected internal int int_2;

		protected internal int int_3;

		protected internal IList ilist_0;

		protected int int_4;

		protected internal int int_5;

		public GClass88()
		{
			int_5 = 0;
			int_2 = 1;
			int_0 = 0;
			int_3 = 0;
		}

		public GClass88(string string_0)
			: this()
		{
			char_0 = string_0.ToCharArray();
			int_4 = string_0.Length;
		}

		public GClass88(char[] char_1, int int_6)
			: this()
		{
			char_0 = char_1;
			int_4 = int_6;
		}

		public virtual void imethod_0()
		{
			if (int_5 < int_4)
			{
				int_0++;
				if (char_0[int_5] == '\n')
				{
					int_2++;
					int_0 = 0;
				}
				int_5++;
			}
		}

		public virtual int imethod_1()
		{
			return int_5;
		}

		public virtual int imethod_2(int int_6)
		{
			if (int_6 == 0)
			{
				return 0;
			}
			if (int_6 < 0)
			{
				int_6++;
				if (int_5 + int_6 - 1 < 0)
				{
					return -1;
				}
			}
			if (int_5 + int_6 - 1 >= int_4)
			{
				return -1;
			}
			return char_0[int_5 + int_6 - 1];
		}

		public virtual int imethod_9(int int_6)
		{
			return imethod_2(int_6);
		}

		public virtual int imethod_3()
		{
			if (ilist_0 == null)
			{
				ilist_0 = new ArrayList();
				ilist_0.Add(null);
			}
			int_3++;
			GClass91 gClass = null;
			if (int_3 >= ilist_0.Count)
			{
				gClass = new GClass91();
				ilist_0.Add(gClass);
			}
			else
			{
				gClass = (GClass91)ilist_0[int_3];
			}
			gClass.int_2 = int_5;
			gClass.int_1 = int_2;
			gClass.int_0 = int_0;
			int_1 = int_3;
			return int_3;
		}

		public virtual void imethod_4(int int_6)
		{
			int_3 = int_6;
			int_3--;
		}

		public virtual void vmethod_0()
		{
			int_5 = 0;
			int_2 = 1;
			int_0 = 0;
			int_3 = 0;
		}

		public virtual void imethod_5()
		{
			imethod_6(int_1);
		}

		public virtual void imethod_6(int int_6)
		{
			GClass91 gClass = (GClass91)ilist_0[int_6];
			imethod_7(gClass.int_2);
			int_2 = gClass.int_1;
			int_0 = gClass.int_0;
			imethod_4(int_6);
		}

		public virtual void imethod_7(int int_6)
		{
			if (int_6 <= int_5)
			{
				int_5 = int_6;
				return;
			}
			while (int_5 < int_6)
			{
				imethod_0();
			}
		}

		public virtual int imethod_8()
		{
			return int_4;
		}

		public virtual string imethod_10(int int_6, int int_7)
		{
			return new string(char_0, int_6, int_7 - int_6 + 1);
		}

		public virtual int imethod_11()
		{
			return int_0;
		}

		public virtual void imethod_12(int int_6)
		{
			int_0 = int_6;
		}

		public virtual int imethod_13()
		{
			return int_2;
		}

		public virtual void imethod_14(int int_6)
		{
			int_2 = int_6;
		}
	}
}

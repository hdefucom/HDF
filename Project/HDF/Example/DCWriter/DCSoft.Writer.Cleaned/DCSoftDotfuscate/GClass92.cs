using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass92 : GInterface15
	{
		protected int int_0;

		protected IDictionary idictionary_0;

		protected bool bool_0;

		protected GClass93 gclass93_0;

		protected int int_1;

		protected int int_2;

		protected IList ilist_0;

		protected GInterface10 ginterface10_0;

		public GClass92()
		{
			bool_0 = false;
			int_2 = -1;
			int_0 = 0;
			ilist_0 = new ArrayList(500);
		}

		public GClass92(GInterface10 ginterface10_1)
			: this()
		{
			ginterface10_0 = ginterface10_1;
		}

		public GClass92(GInterface10 ginterface10_1, int int_3)
			: this(ginterface10_1)
		{
			int_0 = int_3;
		}

		public virtual void imethod_0()
		{
			if (int_2 < ilist_0.Count)
			{
				int_2++;
				int_2 = vmethod_10(int_2);
			}
		}

		public virtual void vmethod_0(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public virtual void vmethod_1(int int_3)
		{
			if (gclass93_0 == null)
			{
				gclass93_0 = new GClass93();
			}
			gclass93_0.Add(int_3.ToString(), int_3);
		}

		protected virtual void vmethod_2()
		{
			int num = 0;
			GInterface12 gInterface = ginterface10_0.imethod_0();
			while (gInterface != null && gInterface.imethod_10() != -1)
			{
				bool flag = false;
				if (idictionary_0 != null)
				{
					object obj = idictionary_0[gInterface.imethod_10()];
					if (obj != null)
					{
						gInterface.imethod_1((int)obj);
					}
				}
				if (gclass93_0 != null && gclass93_0.Contains(gInterface.imethod_10().ToString()))
				{
					flag = true;
				}
				else if (bool_0 && gInterface.imethod_0() != int_0)
				{
					flag = true;
				}
				if (!flag)
				{
					gInterface.imethod_9(num);
					ilist_0.Add(gInterface);
					num++;
				}
				gInterface = ginterface10_0.imethod_0();
			}
			int_2 = 0;
			int_2 = vmethod_10(int_2);
		}

		public virtual GInterface12 imethod_9(int int_3)
		{
			return (GInterface12)ilist_0[int_3];
		}

		public virtual IList vmethod_3()
		{
			if (int_2 == -1)
			{
				vmethod_2();
			}
			return ilist_0;
		}

		public virtual IList vmethod_4(int int_3, int int_4)
		{
			return vmethod_5(int_3, int_4, null);
		}

		public virtual IList vmethod_5(int int_3, int int_4, GClass83 gclass83_0)
		{
			if (int_2 == -1)
			{
				vmethod_2();
			}
			if (int_4 >= ilist_0.Count)
			{
				int_4 = ilist_0.Count - 1;
			}
			if (int_3 < 0)
			{
				int_3 = 0;
			}
			if (int_3 > int_4)
			{
				return null;
			}
			IList list = new ArrayList();
			for (int i = int_3; i <= int_4; i++)
			{
				GInterface12 gInterface = (GInterface12)ilist_0[i];
				if (gclass83_0 == null || gclass83_0.vmethod_3(gInterface.imethod_10()))
				{
					list.Add(gInterface);
				}
			}
			if (list.Count == 0)
			{
				list = null;
			}
			return list;
		}

		public virtual IList vmethod_6(int int_3, int int_4, IList ilist_1)
		{
			return vmethod_5(int_3, int_4, new GClass83(ilist_1));
		}

		public virtual IList vmethod_7(int int_3, int int_4, int int_5)
		{
			return vmethod_5(int_3, int_4, GClass83.smethod_1(int_5));
		}

		public virtual int imethod_1()
		{
			return int_2;
		}

		public virtual int imethod_2(int int_3)
		{
			return imethod_10(int_3).imethod_10();
		}

		protected virtual GInterface12 vmethod_8(int int_3)
		{
			if (int_2 == -1)
			{
				vmethod_2();
			}
			if (int_3 == 0)
			{
				return null;
			}
			if (int_2 - int_3 < 0)
			{
				return null;
			}
			int num = int_2;
			for (int i = 1; i <= int_3; i++)
			{
				num = vmethod_11(num - 1);
			}
			if (num < 0)
			{
				return null;
			}
			return (GInterface12)ilist_0[num];
		}

		public virtual GInterface12 imethod_10(int int_3)
		{
			if (int_2 == -1)
			{
				vmethod_2();
			}
			if (int_3 == 0)
			{
				return null;
			}
			if (int_3 < 0)
			{
				return vmethod_8(-int_3);
			}
			if (int_2 + int_3 - 1 >= ilist_0.Count)
			{
				return GClass84.gclass84_0;
			}
			int num = int_2;
			for (int i = 1; i < int_3; i++)
			{
				num = vmethod_10(num + 1);
			}
			if (num >= ilist_0.Count)
			{
				return GClass84.gclass84_0;
			}
			return (GInterface12)ilist_0[num];
		}

		public virtual int imethod_3()
		{
			if (int_2 == -1)
			{
				vmethod_2();
			}
			int_1 = imethod_1();
			return int_1;
		}

		public virtual void imethod_4(int int_3)
		{
		}

		public virtual void imethod_5()
		{
			imethod_7(int_1);
		}

		public virtual void imethod_6(int int_3)
		{
			imethod_7(int_3);
		}

		public virtual void imethod_7(int int_3)
		{
			int_2 = int_3;
		}

		public virtual void vmethod_9(int int_3, int int_4)
		{
			if (idictionary_0 == null)
			{
				idictionary_0 = new Hashtable();
			}
			idictionary_0[int_3] = int_4;
		}

		public virtual int imethod_8()
		{
			return ilist_0.Count;
		}

		protected virtual int vmethod_10(int int_3)
		{
			int count = ilist_0.Count;
			while (int_3 < count && ((GInterface12)ilist_0[int_3]).imethod_0() != int_0)
			{
				int_3++;
			}
			return int_3;
		}

		protected virtual int vmethod_11(int int_3)
		{
			while (int_3 >= 0 && ((GInterface12)ilist_0[int_3]).imethod_0() != int_0)
			{
				int_3--;
			}
			return int_3;
		}

		public override string ToString()
		{
			if (int_2 == -1)
			{
				vmethod_2();
			}
			return imethod_12(0, ilist_0.Count - 1);
		}

		public virtual string imethod_11(GInterface12 ginterface12_0, GInterface12 ginterface12_1)
		{
			if (ginterface12_0 != null && ginterface12_1 != null)
			{
				return imethod_12(ginterface12_0.imethod_8(), ginterface12_1.imethod_8());
			}
			return null;
		}

		public virtual string imethod_12(int int_3, int int_4)
		{
			if (int_3 < 0 || int_4 < 0)
			{
				return null;
			}
			if (int_2 == -1)
			{
				vmethod_2();
			}
			if (int_4 >= ilist_0.Count)
			{
				int_4 = ilist_0.Count - 1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = int_3; i <= int_4; i++)
			{
				GInterface12 gInterface = (GInterface12)ilist_0[i];
				stringBuilder.Append(gInterface.imethod_6());
			}
			return stringBuilder.ToString();
		}

		public virtual GInterface10 imethod_13()
		{
			return ginterface10_0;
		}

		public virtual void vmethod_12(GInterface10 ginterface10_1)
		{
			ginterface10_0 = ginterface10_1;
			ilist_0.Clear();
			int_2 = -1;
			int_0 = 0;
		}
	}
}

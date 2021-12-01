using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass77 : GInterface11
	{
		protected internal IList ilist_0;

		public GClass77()
		{
		}

		public GClass77(GInterface11 ginterface11_0)
		{
		}

		public virtual void imethod_0(GInterface11 ginterface11_0)
		{
			int num = 2;
			if (ginterface11_0 == null)
			{
				return;
			}
			GClass77 gClass = (GClass77)ginterface11_0;
			if (gClass.imethod_7())
			{
				if (ilist_0 != null && ilist_0 == gClass.ilist_0)
				{
					throw new InvalidOperationException("attempt to add child list to itself");
				}
				if (gClass.ilist_0 == null)
				{
					return;
				}
				if (ilist_0 != null)
				{
					int count = gClass.ilist_0.Count;
					for (int i = 0; i < count; i++)
					{
						ilist_0.Add(gClass.ilist_0[i]);
					}
				}
				else
				{
					ilist_0 = gClass.ilist_0;
				}
			}
			else
			{
				if (ilist_0 == null)
				{
					ilist_0 = vmethod_0();
				}
				ilist_0.Add(ginterface11_0);
			}
		}

		public void method_0(IList ilist_1)
		{
			for (int i = 0; i < ilist_1.Count; i++)
			{
				GInterface11 ginterface11_ = (GInterface11)ilist_1[i];
				imethod_0(ginterface11_);
			}
		}

		protected internal virtual IList vmethod_0()
		{
			return new ArrayList();
		}

		public virtual GClass77 vmethod_1(int int_0)
		{
			if (ilist_0 == null)
			{
				return null;
			}
			object obj = ilist_0[int_0];
			ilist_0.RemoveAt(int_0);
			return (GClass77)obj;
		}

		public abstract GInterface11 imethod_1();

		public virtual GInterface11 imethod_2()
		{
			GInterface11 gInterface = imethod_1();
			int num = 0;
			while (ilist_0 != null && num < ilist_0.Count)
			{
				GInterface11 ginterface11_ = ((GInterface11)ilist_0[num]).imethod_2();
				gInterface.imethod_0(ginterface11_);
				num++;
			}
			return gInterface;
		}

		public virtual GInterface11 imethod_3(int int_0)
		{
			if (ilist_0 == null || int_0 >= ilist_0.Count)
			{
				return null;
			}
			return (GClass77)ilist_0[int_0];
		}

		public virtual void vmethod_2(int int_0, GClass77 gclass77_0)
		{
			if (ilist_0 == null)
			{
				ilist_0 = vmethod_0();
			}
			ilist_0[int_0] = gclass77_0;
		}

		public abstract override string ToString();

		public virtual string imethod_4()
		{
			int num = 2;
			if (ilist_0 == null || ilist_0.Count == 0)
			{
				return ToString();
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (!imethod_7())
			{
				stringBuilder.Append("(");
				stringBuilder.Append(ToString());
				stringBuilder.Append(' ');
			}
			int num2 = 0;
			while (ilist_0 != null && num2 < ilist_0.Count)
			{
				GClass77 gClass = (GClass77)ilist_0[num2];
				if (num2 > 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(gClass.imethod_4());
				num2++;
			}
			if (!imethod_7())
			{
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		public virtual int imethod_5()
		{
			return 0;
		}

		public virtual int imethod_6()
		{
			if (ilist_0 == null)
			{
				return 0;
			}
			return ilist_0.Count;
		}

		public virtual bool imethod_7()
		{
			return false;
		}

		public virtual int imethod_8()
		{
			return 0;
		}

		public abstract string imethod_9();

		public abstract int imethod_10();

		public abstract void imethod_11(int int_0);

		public abstract int imethod_12();

		public abstract void imethod_13(int int_0);

		public abstract int imethod_14();
	}
}

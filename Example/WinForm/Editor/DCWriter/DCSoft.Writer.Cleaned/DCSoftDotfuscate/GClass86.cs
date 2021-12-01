using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass86 : GInterface13
	{
		public virtual void imethod_0(object object_0, object object_1)
		{
			if (object_0 != null)
			{
				((GInterface11)object_0).imethod_0((GInterface11)object_1);
			}
		}

		public virtual object imethod_1(GInterface12 ginterface12_0, object object_0)
		{
			return imethod_2(imethod_3(ginterface12_0), object_0);
		}

		public virtual object imethod_2(object object_0, object object_1)
		{
			int num = 16;
			GInterface11 gInterface = (GInterface11)object_0;
			GInterface11 ginterface11_ = (GInterface11)object_1;
			if (object_1 == null)
			{
				return object_0;
			}
			if (gInterface.imethod_7())
			{
				if (gInterface.imethod_6() > 1)
				{
					throw new SystemException("more than one node as root (TODO: make exception hierarchy)");
				}
				gInterface = gInterface.imethod_3(0);
			}
			gInterface.imethod_0(ginterface11_);
			return gInterface;
		}

		public abstract object imethod_3(GInterface12 ginterface12_0);

		public virtual object imethod_4(int int_0, GInterface12 ginterface12_0)
		{
			ginterface12_0 = vmethod_0(ginterface12_0);
			ginterface12_0.imethod_11(int_0);
			return (GInterface11)imethod_3(ginterface12_0);
		}

		public virtual object imethod_5(int int_0, string string_0)
		{
			GInterface12 ginterface12_ = vmethod_1(int_0, string_0);
			return (GInterface11)imethod_3(ginterface12_);
		}

		public virtual object imethod_6(int int_0, GInterface12 ginterface12_0, string string_0)
		{
			ginterface12_0 = vmethod_0(ginterface12_0);
			ginterface12_0.imethod_11(int_0);
			ginterface12_0.imethod_7(string_0);
			return (GInterface11)imethod_3(ginterface12_0);
		}

		public abstract GInterface12 vmethod_0(GInterface12 ginterface12_0);

		public abstract GInterface12 vmethod_1(int int_0, string string_0);

		public abstract object imethod_7(object object_0);

		public virtual object imethod_8(object object_0)
		{
			return ((GInterface11)object_0).imethod_2();
		}

		public virtual object imethod_9(object object_0, int int_0)
		{
			return ((GInterface11)object_0).imethod_3(int_0);
		}

		public virtual int imethod_10(object object_0)
		{
			return ((GInterface11)object_0).imethod_6();
		}

		public virtual object imethod_11()
		{
			return imethod_3(null);
		}

		public virtual string imethod_12(object object_0)
		{
			return ((GInterface11)object_0).imethod_9();
		}

		public virtual int imethod_13(object object_0)
		{
			((GInterface11)object_0).imethod_14();
			return 0;
		}

		public abstract GInterface12 imethod_14(object object_0);

		public abstract int imethod_15(object object_0);

		public abstract int imethod_16(object object_0);

		public int imethod_17(object object_0)
		{
			return RuntimeHelpers.GetHashCode(object_0);
		}

		public virtual bool imethod_18(object object_0)
		{
			return ((GInterface11)object_0).imethod_7();
		}

		public virtual object imethod_19(object object_0)
		{
			GInterface11 gInterface = (GInterface11)object_0;
			if (gInterface != null && gInterface.imethod_7() && gInterface.imethod_6() == 1)
			{
				gInterface = gInterface.imethod_3(0);
			}
			return gInterface;
		}

		public virtual void imethod_20(object object_0, string string_0)
		{
			throw new NotImplementedException("don't know enough about Tree node");
		}

		public virtual void imethod_21(object object_0, int int_0)
		{
			throw new NotImplementedException("don't know enough about Tree node");
		}

		public abstract void imethod_22(object object_0, GInterface12 ginterface12_0, GInterface12 ginterface12_1);
	}
}

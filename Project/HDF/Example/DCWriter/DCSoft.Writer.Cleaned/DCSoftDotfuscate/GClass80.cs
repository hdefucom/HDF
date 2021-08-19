using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass80
	{
		protected GInterface13 ginterface13_0;

		protected int int_0;

		protected string string_0;

		protected IList ilist_0;

		protected object object_0;

		public GClass80(GInterface13 ginterface13_1, string string_1)
		{
			int_0 = 0;
			string_0 = string_1;
			ginterface13_0 = ginterface13_1;
		}

		public GClass80(GInterface13 ginterface13_1, string string_1, IList ilist_1)
			: this(ginterface13_1, string_1)
		{
			object_0 = null;
			ilist_0 = ilist_1;
		}

		public GClass80(GInterface13 ginterface13_1, string string_1, object object_1)
			: this(ginterface13_1, string_1)
		{
			method_1(object_1);
		}

		protected object method_0()
		{
			if (method_3() == 0)
			{
				throw new GException2(string_0);
			}
			if (int_0 >= method_3())
			{
				if (method_3() != 1)
				{
					throw new GException1(string_0);
				}
				return object_0;
			}
			if (object_0 != null)
			{
				int_0++;
				return vmethod_3(object_0);
			}
			object result = vmethod_3(ilist_0[int_0]);
			int_0++;
			return result;
		}

		public void method_1(object object_1)
		{
			if (object_1 != null)
			{
				if (ilist_0 != null)
				{
					ilist_0.Add(object_1);
					return;
				}
				if (object_0 == null)
				{
					object_0 = object_1;
					return;
				}
				ilist_0 = new ArrayList(5);
				ilist_0.Add(object_0);
				object_0 = null;
				ilist_0.Add(object_1);
			}
		}

		protected abstract object vmethod_0(object object_1);

		public bool method_2()
		{
			return (object_0 != null && int_0 < 1) || (ilist_0 != null && int_0 < ilist_0.Count);
		}

		public virtual object vmethod_1()
		{
			if (int_0 >= method_3() && method_3() == 1)
			{
				object object_ = method_0();
				return vmethod_0(object_);
			}
			return method_0();
		}

		public virtual void vmethod_2()
		{
			int_0 = 0;
		}

		public int method_3()
		{
			int result = 0;
			if (object_0 != null)
			{
				result = 1;
			}
			if (ilist_0 != null)
			{
				return ilist_0.Count;
			}
			return result;
		}

		protected virtual object vmethod_3(object object_1)
		{
			return object_1;
		}

		public string method_4()
		{
			return string_0;
		}
	}
}

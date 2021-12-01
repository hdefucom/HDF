using DCSoft.RTF;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass406
	{
		protected GClass407 gclass407_0 = null;

		protected GClass408 gclass408_0 = null;

		protected string string_0 = null;

		protected bool bool_0 = false;

		protected int int_0 = 0;

		protected GEnum82 genum82_0 = GEnum82.const_6;

		public GClass406()
		{
		}

		public GClass406(GEnum82 genum82_1, string string_1)
		{
			genum82_0 = genum82_1;
			string_0 = string_1;
		}

		public GClass406(GClass412 gclass412_0)
		{
			string_0 = gclass412_0.method_2();
			bool_0 = gclass412_0.method_4();
			int_0 = gclass412_0.method_6();
			if (gclass412_0.method_0() == RTFTokenType.Control)
			{
				genum82_0 = GEnum82.const_3;
			}
			else if (gclass412_0.method_0() == RTFTokenType.Control)
			{
				genum82_0 = GEnum82.const_3;
			}
			else if (gclass412_0.method_0() == RTFTokenType.Keyword)
			{
				genum82_0 = GEnum82.const_1;
			}
			else if (gclass412_0.method_0() == RTFTokenType.ExtKeyword)
			{
				genum82_0 = GEnum82.const_2;
			}
			else if (gclass412_0.method_0() == RTFTokenType.Text)
			{
				genum82_0 = GEnum82.const_4;
			}
			else
			{
				genum82_0 = GEnum82.const_4;
			}
		}

		public virtual GClass407 vmethod_0()
		{
			return gclass407_0;
		}

		public virtual void vmethod_1(GClass407 gclass407_1)
		{
			gclass407_0 = gclass407_1;
		}

		public virtual GClass408 vmethod_2()
		{
			return gclass408_0;
		}

		public virtual void vmethod_3(GClass408 gclass408_1)
		{
			gclass408_0 = gclass408_1;
			if (vmethod_9() != null)
			{
				foreach (GClass406 item in vmethod_9())
				{
					item.vmethod_3(gclass408_1);
				}
			}
		}

		public virtual string vmethod_4()
		{
			return string_0;
		}

		public virtual void vmethod_5(string string_1)
		{
			string_0 = string_1;
		}

		public virtual bool vmethod_6()
		{
			return bool_0;
		}

		public virtual void vmethod_7(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public virtual int vmethod_8()
		{
			return int_0;
		}

		public virtual GClass415 vmethod_9()
		{
			return null;
		}

		public int method_0()
		{
			if (gclass407_0 == null)
			{
				return 0;
			}
			return gclass407_0.vmethod_9().method_6(this);
		}

		public GEnum82 method_1()
		{
			return genum82_0;
		}

		public GClass406 method_2()
		{
			if (gclass407_0 != null)
			{
				int num = gclass407_0.vmethod_9().method_6(this);
				if (num > 0)
				{
					return gclass407_0.vmethod_9().method_0(num - 1);
				}
			}
			return null;
		}

		public GClass406 method_3()
		{
			if (gclass407_0 != null)
			{
				int num = gclass407_0.vmethod_9().method_6(this);
				if (num >= 0 && num < gclass407_0.vmethod_9().Count - 1)
				{
					return gclass407_0.vmethod_9().method_0(num + 1);
				}
			}
			return null;
		}

		public virtual void vmethod_10(GClass414 gclass414_0)
		{
			if (genum82_0 == GEnum82.const_3 || genum82_0 == GEnum82.const_1 || genum82_0 == GEnum82.const_2)
			{
				if (bool_0)
				{
					gclass414_0.method_14(string_0 + int_0, genum82_0 == GEnum82.const_2);
				}
				else
				{
					gclass414_0.method_14(string_0, genum82_0 == GEnum82.const_2);
				}
			}
			else if (genum82_0 == GEnum82.const_4)
			{
				gclass414_0.method_15(string_0);
			}
		}
	}
}

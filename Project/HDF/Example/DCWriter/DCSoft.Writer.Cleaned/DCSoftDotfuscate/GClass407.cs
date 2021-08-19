using DCSoft.RTF;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass407 : GClass406
	{
		protected GClass415 gclass415_0 = new GClass415();

		public GClass407()
		{
			genum82_0 = GEnum82.const_5;
		}

		public override GClass415 vmethod_9()
		{
			return gclass415_0;
		}

		public GClass415 method_4(bool bool_1)
		{
			GClass415 gClass = new GClass415();
			method_5(gClass, bool_1);
			return gClass;
		}

		private void method_5(GClass415 gclass415_1, bool bool_1)
		{
			foreach (GClass406 item in gclass415_0)
			{
				if (item is GClass407)
				{
					if (bool_1)
					{
						gclass415_1.method_8(item);
					}
					((GClass407)item).method_5(gclass415_1, bool_1);
				}
				else
				{
					gclass415_1.method_8(item);
				}
			}
		}

		public GClass406 method_6()
		{
			if (gclass415_0.Count > 0)
			{
				return gclass415_0.method_0(0);
			}
			return null;
		}

		public override string vmethod_4()
		{
			if (gclass415_0.Count > 0)
			{
				return gclass415_0.method_0(0).vmethod_4();
			}
			return null;
		}

		public override void vmethod_5(string string_1)
		{
		}

		public override bool vmethod_6()
		{
			if (gclass415_0.Count > 0)
			{
				return gclass415_0.method_0(0).vmethod_6();
			}
			return false;
		}

		public override void vmethod_7(bool bool_1)
		{
		}

		public override int vmethod_8()
		{
			if (gclass415_0.Count > 0)
			{
				return gclass415_0.method_0(0).vmethod_8();
			}
			return 0;
		}

		public virtual string vmethod_11()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GClass406 item in gclass415_0)
			{
				if (item is GClass407)
				{
					stringBuilder.Append(((GClass407)item).vmethod_11());
				}
				if (item.method_1() == GEnum82.const_4)
				{
					stringBuilder.Append(item.vmethod_4());
				}
			}
			return stringBuilder.ToString();
		}

		internal void method_7()
		{
			int num = 5;
			GClass415 gClass = new GClass415();
			StringBuilder stringBuilder = new StringBuilder();
			GClass413 gClass2 = new GClass413();
			foreach (GClass406 item in gclass415_0)
			{
				if (item.method_1() == GEnum82.const_4)
				{
					method_8(stringBuilder, gClass2);
					stringBuilder.Append(item.vmethod_4());
				}
				else if (item.method_1() == GEnum82.const_3 && item.vmethod_4() == "'" && item.vmethod_6())
				{
					gClass2.method_3((byte)item.vmethod_8());
				}
				else
				{
					if (item.method_1() == GEnum82.const_3 || item.method_1() == GEnum82.const_1)
					{
						if (item.vmethod_4() == "tab")
						{
							method_8(stringBuilder, gClass2);
							stringBuilder.Append('\t');
							continue;
						}
						if (item.vmethod_4() == "emdash")
						{
							method_8(stringBuilder, gClass2);
							stringBuilder.Append('—');
							continue;
						}
						if (item.vmethod_4() == "")
						{
							method_8(stringBuilder, gClass2);
							stringBuilder.Append('–');
							continue;
						}
					}
					method_8(stringBuilder, gClass2);
					if (stringBuilder.Length > 0)
					{
						gClass.method_8(new GClass406(GEnum82.const_4, stringBuilder.ToString()));
						stringBuilder = new StringBuilder();
					}
					gClass.method_8(item);
				}
			}
			method_8(stringBuilder, gClass2);
			if (stringBuilder.Length > 0)
			{
				gClass.method_8(new GClass406(GEnum82.const_4, stringBuilder.ToString()));
			}
			gclass415_0.Clear();
			foreach (GClass406 item2 in gClass)
			{
				item2.vmethod_1(this);
				item2.vmethod_3(gclass408_0);
				gclass415_0.method_8(item2);
			}
		}

		private void method_8(StringBuilder stringBuilder_0, GClass413 gclass413_0)
		{
			if (gclass413_0.vmethod_1() > 0)
			{
				string value = gclass413_0.method_7(gclass408_0.method_24());
				stringBuilder_0.Append(value);
				gclass413_0.method_0();
			}
		}

		public override void vmethod_10(GClass414 gclass414_0)
		{
			gclass414_0.method_10();
			foreach (GClass406 item in gclass415_0)
			{
				item.vmethod_10(gclass414_0);
			}
			gclass414_0.method_11();
		}

		public GClass406 method_9(string string_1, bool bool_1)
		{
			foreach (GClass406 item in gclass415_0)
			{
				if ((item.method_1() == GEnum82.const_1 || item.method_1() == GEnum82.const_2 || item.method_1() == GEnum82.const_3) && item.vmethod_4() == string_1)
				{
					return item;
				}
				if (bool_1 && item is GClass407)
				{
					GClass407 gClass2 = (GClass407)item;
					GClass406 gClass3 = gClass2.method_9(string_1, bool_1: true);
					if (gClass3 != null)
					{
						return gClass3;
					}
				}
			}
			return null;
		}

		public void method_10(GClass406 gclass406_0)
		{
			int num = 13;
			method_13();
			if (gclass406_0 == null)
			{
				throw new ArgumentNullException("node");
			}
			if (gclass406_0 == this)
			{
				throw new ArgumentException("node != this");
			}
			gclass406_0.vmethod_1(this);
			gclass406_0.vmethod_3(gclass408_0);
			vmethod_9().method_8(gclass406_0);
		}

		public void method_11(GClass406 gclass406_0)
		{
			int num = 19;
			method_13();
			if (gclass406_0 == null)
			{
				throw new ArgumentNullException("node");
			}
			if (gclass406_0 == this)
			{
				throw new ArgumentException("node != this");
			}
			vmethod_9().method_9(gclass406_0);
		}

		public void method_12(int int_1, GClass406 gclass406_0)
		{
			int num = 7;
			method_13();
			if (gclass406_0 == null)
			{
				throw new ArgumentNullException("node");
			}
			if (gclass406_0 == this)
			{
				throw new ArgumentException("node != this");
			}
			gclass406_0.vmethod_1(this);
			gclass406_0.vmethod_3(gclass408_0);
			vmethod_9().method_10(int_1, gclass406_0);
		}

		private void method_13()
		{
			if (vmethod_9() == null)
			{
				throw new Exception(RTFResource.ChildNodeInvalidate);
			}
		}
	}
}

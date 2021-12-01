using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass383
	{
		private GClass423 gclass423_0 = new GClass423();

		private GClass409 gclass409_0 = new GClass409();

		private GClass386 gclass386_0 = null;

		private GClass383 gclass383_0 = null;

		private bool bool_0 = false;

		[NonSerialized]
		internal int int_0 = -1;

		public GClass423 method_0()
		{
			return gclass423_0;
		}

		public void method_1(GClass423 gclass423_1)
		{
			gclass423_0 = gclass423_1;
		}

		public bool method_2(string string_0)
		{
			return gclass423_0.method_8(string_0);
		}

		public int method_3(string string_0, int int_1)
		{
			if (gclass423_0.method_8(string_0))
			{
				return gclass423_0.method_1(string_0);
			}
			return int_1;
		}

		internal void method_4()
		{
			if (method_5().Count > 0 && method_5().method_1() is GClass388)
			{
				GClass388 gClass = (GClass388)method_5().method_1();
				if (gClass.method_17() && gClass.method_5().Count == 0)
				{
					method_5().method_5(gClass);
				}
			}
		}

		public GClass409 method_5()
		{
			return gclass409_0;
		}

		public GClass386 method_6()
		{
			return gclass386_0;
		}

		public void method_7(GClass386 gclass386_1)
		{
			gclass386_0 = gclass386_1;
			foreach (GClass383 item in method_5())
			{
				item.method_7(gclass386_1);
			}
		}

		public int method_8(GClass383 gclass383_1)
		{
			method_11();
			gclass383_1.gclass383_0 = this;
			gclass383_1.method_7(gclass386_0);
			return gclass409_0.method_2(gclass383_1);
		}

		public void method_9(string string_0, int int_1)
		{
			method_11();
			gclass423_0.method_2(string_0, int_1);
		}

		public GClass383 method_10()
		{
			return gclass383_0;
		}

		public virtual string vmethod_0()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (gclass409_0 != null)
			{
				foreach (GClass383 item in gclass409_0)
				{
					stringBuilder.Append(item.vmethod_0());
				}
			}
			return stringBuilder.ToString();
		}

		private void method_11()
		{
			int num = 14;
			if (bool_0)
			{
				throw new InvalidOperationException("Element locked");
			}
		}

		public bool method_12()
		{
			return bool_0;
		}

		public void method_13(bool bool_1)
		{
			if (bool_0 != bool_1)
			{
				bool_0 = bool_1;
				if (this is GClass386)
				{
				}
			}
		}

		public void method_14(bool bool_1)
		{
			bool_0 = bool_1;
			if (gclass409_0 != null)
			{
				foreach (GClass383 item in gclass409_0)
				{
					item.method_14(bool_1);
				}
			}
		}

		public void method_15()
		{
			Console.WriteLine(vmethod_1());
		}

		public virtual string vmethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(ToString());
			method_16(method_5(), stringBuilder, 1);
			return stringBuilder.ToString();
		}

		protected void method_16(GClass409 gclass409_1, StringBuilder stringBuilder_0, int int_1)
		{
			foreach (GClass383 item in gclass409_1)
			{
				stringBuilder_0.Append(Environment.NewLine);
				stringBuilder_0.Append(new string(' ', int_1 * 4));
				stringBuilder_0.Append(item.ToString());
				method_16(item.method_5(), stringBuilder_0, int_1 + 1);
			}
		}
	}
}

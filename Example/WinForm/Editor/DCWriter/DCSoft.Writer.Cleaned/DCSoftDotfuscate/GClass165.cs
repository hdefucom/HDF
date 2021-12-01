using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass165 : GClass164
	{
		private GClass228 gclass228_1 = new GClass228();

		public string Name
		{
			get
			{
				return method_9("name");
			}
			set
			{
				method_11("name", value);
			}
		}

		public override string TagName => "FORM";

		public GClass228 method_50()
		{
			return gclass228_1;
		}

		internal void method_51(Interface0 interface0_0)
		{
			if (!gclass228_1.method_5((GClass163)interface0_0))
			{
				gclass228_1.method_6((GClass163)interface0_0);
				interface0_0.imethod_1(this);
			}
		}

		public string method_52()
		{
			return method_9("target");
		}

		public void method_53(string string_0)
		{
			method_11("target", string_0);
		}

		public string method_54()
		{
			return method_9("method");
		}

		public void method_55(string string_0)
		{
			method_11("method", string_0);
		}

		public string method_56()
		{
			return method_9("action");
		}

		public void method_57(string string_0)
		{
			method_11("action", string_0);
		}

		public bool method_58()
		{
			return method_13("disabled");
		}

		public void method_59(bool bool_0)
		{
			int num = 8;
			if (bool_0)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}

		public string method_60()
		{
			return method_9("enctype");
		}

		public void method_61(string string_0)
		{
			method_11("enctype", string_0);
		}

		public string method_62()
		{
			return method_9("title");
		}

		public void method_63(string string_0)
		{
			method_11("title", string_0);
		}
	}
}

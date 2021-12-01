using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass194 : GClass164
	{
		private bool bool_0 = true;

		public override string TagName => "BODY";

		public bool method_50()
		{
			return bool_0;
		}

		public void method_51(bool bool_1)
		{
			bool_0 = bool_1;
		}

		internal override bool vmethod_13(GClass163 gclass163_0)
		{
			if (!method_50() && gclass163_0 is GClass216)
			{
				GClass216 gClass = (GClass216)gclass163_0;
				if (string.IsNullOrEmpty(gClass.vmethod_7()) || gClass.vmethod_7().Trim().Length == 0)
				{
					return false;
				}
			}
			method_51(bool_1: true);
			return base.vmethod_13(gclass163_0);
		}

		public string method_52()
		{
			return method_9("alink");
		}

		public void method_53(string string_0)
		{
			method_11("alink", string_0);
		}

		public string method_54()
		{
			return method_9("background");
		}

		public void method_55(string string_0)
		{
			method_11("background", string_0);
		}

		public string method_56()
		{
			return method_9("bgcolor");
		}

		public void method_57(string string_0)
		{
			method_11("bgcolor", string_0);
		}

		public string method_58()
		{
			return method_9("bottommargin");
		}

		public void method_59(string string_0)
		{
			method_11("bottommargin", string_0);
		}

		public bool method_60()
		{
			return method_13("disabled");
		}

		public void method_61(bool bool_1)
		{
			int num = 18;
			if (bool_1)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}

		public string method_62()
		{
			return method_9("leftmargin");
		}

		public void method_63(string string_0)
		{
			method_11("leftmargin", string_0);
		}

		public string method_64()
		{
			return method_9("link");
		}

		public void method_65(string string_0)
		{
			method_11("link", string_0);
		}

		public string method_66()
		{
			return method_9("nowrap");
		}

		public void method_67(string string_0)
		{
			method_11("nowrap", string_0);
		}

		public string method_68()
		{
			return method_9("rightmargin");
		}

		public void method_69(string string_0)
		{
			method_11("rightmargin", string_0);
		}

		public override string vmethod_7()
		{
			return method_9("text");
		}

		public override void vmethod_8(string string_0)
		{
			method_11("text", string_0);
		}

		public string method_70()
		{
			return method_9("title");
		}

		public void method_71(string string_0)
		{
			method_11("title", string_0);
		}

		public string method_72()
		{
			return method_9("topmargin");
		}

		public void method_73(string string_0)
		{
			method_11("topmargin", string_0);
		}

		public string method_74()
		{
			return method_9("vlink");
		}

		public void method_75(string string_0)
		{
			method_11("vlink", string_0);
		}

		internal override bool CheckChildTagName(string strName)
		{
			return true;
		}
	}
}

using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass208 : GClass163
	{
		public override string TagName => "hta:application";

		public string method_46()
		{
			return method_9("applicationname");
		}

		public void method_47(string string_0)
		{
			method_11("applicationname", string_0);
		}

		public string method_48()
		{
			return method_9("border");
		}

		public void method_49(string string_0)
		{
			method_11("border", string_0);
		}

		public string method_50()
		{
			return method_9("borderstyle");
		}

		public void method_51(string string_0)
		{
			method_11("borderstyle", string_0);
		}

		public string method_52()
		{
			return method_9("caption");
		}

		public void method_53(string string_0)
		{
			method_11("caption", string_0);
		}

		public bool method_54()
		{
			return method_81("contexmenu", bool_0: true);
		}

		public void method_55(bool bool_0)
		{
			method_80("contexmenu", bool_0);
		}

		public string method_56()
		{
			return method_9("icon");
		}

		public void method_57(string string_0)
		{
			method_11("icon", string_0);
		}

		public bool method_58()
		{
			return method_81("innerborder", bool_0: true);
		}

		public void method_59(bool bool_0)
		{
			method_80("innerborder", bool_0);
		}

		public bool method_60()
		{
			return method_81("maximizebutton", bool_0: true);
		}

		public void method_61(bool bool_0)
		{
			method_80("maximizebutton", bool_0);
		}

		public bool method_62()
		{
			return method_81("minimizebutton", bool_0: true);
		}

		public void method_63(bool bool_0)
		{
			method_80("minimizebutton", bool_0);
		}

		public string method_64()
		{
			return method_9("scroll");
		}

		public void method_65(string string_0)
		{
			method_11("scroll", string_0);
		}

		public bool method_66()
		{
			return method_81("scrollflat", bool_0: false);
		}

		public void method_67(bool bool_0)
		{
			method_80("scrollflat", bool_0);
		}

		public bool method_68()
		{
			return method_81("selection", bool_0: true);
		}

		public void method_69(bool bool_0)
		{
			method_80("selection", bool_0);
		}

		public bool method_70()
		{
			return method_81("showintaskbar", bool_0: true);
		}

		public void method_71(bool bool_0)
		{
			method_80("showintaskbar", bool_0);
		}

		public bool method_72()
		{
			return method_81("singleinstance", bool_0: false);
		}

		public void method_73(bool bool_0)
		{
			method_80("singleinstance", bool_0);
		}

		public bool method_74()
		{
			return method_81("sysmenu", bool_0: true);
		}

		public void method_75(bool bool_0)
		{
			method_80("sysmenu", bool_0);
		}

		public string method_76()
		{
			return method_9("version");
		}

		public void method_77(string string_0)
		{
			method_11("version", string_0);
		}

		public string method_78()
		{
			return method_9("windowstate");
		}

		public void method_79(string string_0)
		{
			method_11("windowstate", string_0);
		}

		private void method_80(string string_0, bool bool_0)
		{
			int num = 16;
			method_11(string_0, bool_0 ? "yes" : "no");
		}

		private bool method_81(string string_0, bool bool_0)
		{
			int num = 6;
			string text = method_9(string_0);
			if (text == null)
			{
				return bool_0;
			}
			if (bool_0)
			{
				return !text.ToLower().Trim().Equals("no");
			}
			return text.ToLower().Trim().Equals("yes");
		}
	}
}

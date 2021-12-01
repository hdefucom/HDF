using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass182 : GClass164
	{
		public override string TagName => "MARQUEE";

		public string method_50()
		{
			return method_9("behavior");
		}

		public void method_51(string string_0)
		{
			method_11("behavior", string_0);
		}

		public string method_52()
		{
			return method_9("bgcolor");
		}

		public void method_53(string string_0)
		{
			method_11("bgcolor", string_0);
		}

		public string method_54()
		{
			return method_9("direction");
		}

		public void method_55(string string_0)
		{
			method_11("direction", string_0);
		}

		public bool method_56()
		{
			return method_14("disabled");
		}

		public void method_57(bool bool_0)
		{
			method_15("disabled", bool_0);
		}

		public string method_58()
		{
			return method_9("height");
		}

		public void method_59(string string_0)
		{
			method_11("height", string_0);
		}

		public string method_60()
		{
			return method_9("hspace");
		}

		public void method_61(string string_0)
		{
			method_11("hspace", string_0);
		}

		public string method_62()
		{
			return method_9("loop");
		}

		public void method_63(string string_0)
		{
			method_11("loop", string_0);
		}

		public string method_64()
		{
			return method_9("scrollamount");
		}

		public void method_65(string string_0)
		{
			method_11("scrollamount", string_0);
		}

		public string method_66()
		{
			return method_9("scrolldelay");
		}

		public void method_67(string string_0)
		{
			method_11("scrolldelay", string_0);
		}

		public string method_68()
		{
			return method_9("timecontainer");
		}

		public void method_69(string string_0)
		{
			method_11("timecontainer", string_0);
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
			return method_9("truespeed");
		}

		public void method_73(string string_0)
		{
			method_11("truespeed", string_0);
		}

		public string method_74()
		{
			return method_9("vspace");
		}

		public void method_75(string string_0)
		{
			method_11("vspace", string_0);
		}

		public string method_76()
		{
			return method_9("width");
		}

		public void method_77(string string_0)
		{
			method_11("width", string_0);
		}

		internal override bool CheckChildTagName(string strName)
		{
			int num = 9;
			int result;
			switch (strName)
			{
			default:
				result = ((strName == "FONT") ? 1 : 0);
				break;
			case "B":
			case "SPAN":
			case "A":
			case "I":
			case "#text":
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}
}

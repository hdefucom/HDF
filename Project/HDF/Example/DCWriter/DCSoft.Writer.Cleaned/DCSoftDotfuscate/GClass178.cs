using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass178 : GClass164
	{
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

		public override string TagName => "APPLET";

		public string method_50()
		{
			return method_9("align");
		}

		public void method_51(string string_0)
		{
			method_11("align", string_0);
		}

		public string method_52()
		{
			return method_9("alt");
		}

		public void method_53(string string_0)
		{
			method_11("alt", string_0);
		}

		public string method_54()
		{
			return method_9("code");
		}

		public void method_55(string string_0)
		{
			method_11("code", string_0);
		}

		public string method_56()
		{
			return method_9("codebase");
		}

		public void method_57(string string_0)
		{
			method_11("codebase", string_0);
		}

		public string method_58()
		{
			return method_9("hspace");
		}

		public void method_59(string string_0)
		{
			method_11("hspace", string_0);
		}

		public string method_60()
		{
			return method_9("language");
		}

		public void method_61(string string_0)
		{
			method_11("language", string_0);
		}

		public string method_62()
		{
			return method_9("src");
		}

		public void method_63(string string_0)
		{
			method_11("src", string_0);
		}

		public string method_64()
		{
			return method_9("title");
		}

		public void method_65(string string_0)
		{
			method_11("title", string_0);
		}

		public string method_66()
		{
			return method_9("vspace");
		}

		public void method_67(string string_0)
		{
			method_11("vspace", string_0);
		}

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "PARAM";
		}
	}
}

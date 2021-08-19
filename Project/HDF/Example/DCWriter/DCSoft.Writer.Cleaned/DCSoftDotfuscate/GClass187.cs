using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass187 : GClass164
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

		public override string TagName => "OBJECT";

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
			return method_9("border");
		}

		public void method_55(string string_0)
		{
			method_11("border", string_0);
		}

		public string method_56()
		{
			return method_9("classid");
		}

		public void method_57(string string_0)
		{
			method_11("classid", string_0);
		}

		public string method_58()
		{
			return method_9("code");
		}

		public void method_59(string string_0)
		{
			method_11("code", string_0);
		}

		public string method_60()
		{
			return method_9("codebase");
		}

		public void method_61(string string_0)
		{
			method_11("codebase", string_0);
		}

		public string method_62()
		{
			return method_9("codetype");
		}

		public void method_63(string string_0)
		{
			method_11("codetype", string_0);
		}

		public string method_64()
		{
			return method_9("data");
		}

		public void method_65(string string_0)
		{
			method_11("data", string_0);
		}

		public string method_66()
		{
			return method_9("height");
		}

		public void method_67(string string_0)
		{
			method_11("height", string_0);
		}

		public string method_68()
		{
			return method_9("hspace");
		}

		public void method_69(string string_0)
		{
			method_11("hspace", string_0);
		}

		public string method_70()
		{
			return method_9("language");
		}

		public void method_71(string string_0)
		{
			method_11("language", string_0);
		}

		public string method_72()
		{
			return method_9("title");
		}

		public void method_73(string string_0)
		{
			method_11("title", string_0);
		}

		public string method_74()
		{
			return method_9("type");
		}

		public void method_75(string string_0)
		{
			method_11("type", string_0);
		}

		public string method_76()
		{
			return method_9("width");
		}

		public void method_77(string string_0)
		{
			method_11("width", string_0);
		}

		public string method_78()
		{
			return method_9("vspace");
		}

		public void method_79(string string_0)
		{
			method_11("vspace", string_0);
		}

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "PARAM";
		}
	}
}

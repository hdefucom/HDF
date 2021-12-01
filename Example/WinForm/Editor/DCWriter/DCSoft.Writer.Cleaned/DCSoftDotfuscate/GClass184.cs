using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass184 : GClass164
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

		public override string TagName => "FRAMESET";

		public string method_50()
		{
			return method_9("border");
		}

		public void method_51(string string_0)
		{
			method_11("border", string_0);
		}

		public string method_52()
		{
			return method_9("bordercolor");
		}

		public void method_53(string string_0)
		{
			method_11("bordercolor", string_0);
		}

		public string method_54()
		{
			return method_9("cols");
		}

		public void method_55(string string_0)
		{
			method_11("cols", string_0);
		}

		public string method_56()
		{
			return method_9("frameborder");
		}

		public void method_57(string string_0)
		{
			method_11("frameborder", string_0);
		}

		public string method_58()
		{
			return method_9("framespacing");
		}

		public void method_59(string string_0)
		{
			method_11("framespacing", string_0);
		}

		public string method_60()
		{
			return method_9("hidefocus");
		}

		public void method_61(string string_0)
		{
			method_11("hidefocus", string_0);
		}

		public string method_62()
		{
			return method_9("rows");
		}

		public void method_63(string string_0)
		{
			method_11("rows", string_0);
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
			return method_9("width");
		}

		public void method_67(string string_0)
		{
			method_11("width", string_0);
		}

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "FRAME";
		}
	}
}

using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass166 : GClass164
	{
		public override string TagName => "UL";

		public bool method_50()
		{
			return method_14("disabled");
		}

		public void method_51(bool bool_0)
		{
			method_15("disabled", bool_0);
		}

		public string method_52()
		{
			return method_9("title");
		}

		public void method_53(string string_0)
		{
			method_11("title", string_0);
		}

		public string method_54()
		{
			return method_9("type");
		}

		public void method_55(string string_0)
		{
			method_11("type", string_0);
		}

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "LI";
		}
	}
}

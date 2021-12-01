using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass191 : GClass164
	{
		public override string TagName => "HEAD";

		internal override bool CheckChildTagName(string strName)
		{
			int num = 10;
			int result;
			switch (strName)
			{
			case "title":
				foreach (object item in gclass228_0)
				{
					if (item is GClass197)
					{
						return false;
					}
				}
				return true;
			default:
				result = ((strName == "XML") ? 1 : 0);
				break;
			case "META":
			case "LINK":
			case "SCRIPT":
			case "STYLE":
			case "hta:application":
			case "#comment":
				result = 1;
				break;
			}
			return (byte)result != 0;
		}

		internal override bool vmethod_21(Class171 class171_0, string string_0)
		{
			if (string_0 == "HEAD")
			{
				class171_0.method_23('>');
				return true;
			}
			return false;
		}
	}
}

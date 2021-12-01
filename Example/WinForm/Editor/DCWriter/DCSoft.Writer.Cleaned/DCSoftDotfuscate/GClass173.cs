using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass173 : GClass164
	{
		public override string TagName => "TBODY";

		internal override bool CheckChildTagName(string strName)
		{
			int num = 2;
			return strName == "TR" || strName == "COL";
		}
	}
}

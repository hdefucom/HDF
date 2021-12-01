using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass192 : GClass164
	{
		public override string TagName => "COLGROUP";

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "COL";
		}
	}
}

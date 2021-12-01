using DCSoft.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass442
	{
		private XBrushStyleConst xbrushStyleConst_0 = XBrushStyleConst.Solid;

		private string string_0 = null;

		public GClass442()
		{
		}

		public GClass442(XBrushStyleConst xbrushStyleConst_1, string string_1)
		{
			method_1(xbrushStyleConst_1);
			method_3(string_1);
		}

		public XBrushStyleConst method_0()
		{
			return xbrushStyleConst_0;
		}

		public void method_1(XBrushStyleConst xbrushStyleConst_1)
		{
			xbrushStyleConst_0 = xbrushStyleConst_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}
	}
}

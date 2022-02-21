using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public class GClass96
	{
		private XTextElement xtextElement_0 = null;

		private string string_0 = null;

		private string string_1 = null;

		private GEnum4 genum4_0 = GEnum4.const_0;

		private GEnum5 genum5_0 = GEnum5.const_0;

		private ToolTipContentType toolTipContentType_0 = ToolTipContentType.Unknow;

		private bool bool_0 = false;

		public GClass96()
		{
		}

		public GClass96(XTextElement xtextElement_1, string string_2)
		{
			xtextElement_0 = xtextElement_1;
			method_6(string_2);
		}

		public bool method_0(GClass96 gclass96_0)
		{
			if (gclass96_0 == null)
			{
				return false;
			}
			if (gclass96_0 == this)
			{
				return true;
			}
			return toolTipContentType_0 == gclass96_0.toolTipContentType_0 && bool_0 == gclass96_0.bool_0 && xtextElement_0 == gclass96_0.xtextElement_0 && genum5_0 == gclass96_0.genum5_0 && genum4_0 == gclass96_0.genum4_0 && string_1 == gclass96_0.string_1 && string_0 == gclass96_0.string_0;
		}

		public XTextElement method_1()
		{
			return xtextElement_0;
		}

		public void method_2(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}

		public string method_3()
		{
			return string_0;
		}

		public void method_4(string string_2)
		{
			string_0 = string_2;
		}

		public string method_5()
		{
			return string_1;
		}

		public void method_6(string string_2)
		{
			string_1 = string_2;
		}

		public GEnum4 method_7()
		{
			return genum4_0;
		}

		public void method_8(GEnum4 genum4_1)
		{
			genum4_0 = genum4_1;
		}

		public GEnum5 method_9()
		{
			return genum5_0;
		}

		public void method_10(GEnum5 genum5_1)
		{
			genum5_0 = genum5_1;
		}

		public ToolTipContentType method_11()
		{
			return toolTipContentType_0;
		}

		public void method_12(ToolTipContentType toolTipContentType_1)
		{
			toolTipContentType_0 = toolTipContentType_1;
		}

		public bool method_13()
		{
			return bool_0;
		}

		public void method_14(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}

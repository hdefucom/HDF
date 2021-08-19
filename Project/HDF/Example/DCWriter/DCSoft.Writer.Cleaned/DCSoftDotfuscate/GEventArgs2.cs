using DCSoft.Writer.Dom;
using DCSoft.Writer.Script;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs2 : EventArgs
	{
		private XTextDocument xtextDocument_0 = null;

		private XTextElement xtextElement_0 = null;

		private DomExpression domExpression_0 = null;

		private object object_0 = null;

		public GEventArgs2()
		{
		}

		public GEventArgs2(XTextDocument xtextDocument_1, XTextElement xtextElement_1, DomExpression domExpression_1)
		{
			xtextDocument_0 = xtextDocument_1;
			xtextElement_0 = xtextElement_1;
			domExpression_0 = domExpression_1;
		}

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextElement method_2()
		{
			return xtextElement_0;
		}

		public void method_3(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}

		public DomExpression method_4()
		{
			return domExpression_0;
		}

		public void method_5(DomExpression domExpression_1)
		{
			domExpression_0 = domExpression_1;
		}

		public object method_6()
		{
			return object_0;
		}

		public void method_7(object object_1)
		{
			object_0 = object_1;
		}
	}
}

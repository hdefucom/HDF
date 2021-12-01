using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DCInternal]
	public interface GInterface4
	{
		int imethod_0(XTextElementList xtextElementList_0, Dictionary<string, string> dictionary_0);

		bool imethod_1(XTextElement xtextElement_0, EventExpressionInfoList eventExpressionInfoList_0, string string_0, bool bool_0);

		string imethod_2(XTextElement xtextElement_0);

		void imethod_3();

		void imethod_4(XTextElement xtextElement_0);

		bool imethod_5();

		void imethod_6(bool bool_0);

		bool imethod_7(XTextElement xtextElement_0);

		int imethod_8();

		int imethod_9(XTextElement xtextElement_0);

		int imethod_10(XTextDocument xtextDocument_0, XTextTableElement xtextTableElement_0, int int_0, int int_1);

		int imethod_11(XTextDocument xtextDocument_0, XTextTableElement xtextTableElement_0, int int_0, int int_1);
	}
}

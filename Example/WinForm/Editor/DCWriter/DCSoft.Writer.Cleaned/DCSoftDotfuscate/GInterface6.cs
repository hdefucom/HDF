using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	
	public interface GInterface6
	{
		HighlightInfo imethod_0();

		void imethod_1(HighlightInfo highlightInfo_0);

		HighlightInfoList imethod_2();

		void imethod_3(HighlightInfoList highlightInfoList_0);

		void imethod_4();

		HighlightInfo imethod_5();

		void imethod_6(HighlightInfo highlightInfo_0);

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		void imethod_7();

		void imethod_8(XTextElement xtextElement_0);

		void imethod_9(XTextElement xtextElement_0);

		HighlightInfo imethod_10(XTextElement xtextElement_0);
	}
}

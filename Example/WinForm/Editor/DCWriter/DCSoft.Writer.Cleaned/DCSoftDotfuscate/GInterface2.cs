using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public interface GInterface2
	{
		bool imethod_0(MoveFocusHotKeys moveFocusHotKeys_0, Keys keys_0);

		XTextElement imethod_1(XTextElement xtextElement_0, Keys keys_0, bool bool_0, KeyEventArgs keyEventArgs_0);

		XTextElement imethod_2(XTextElement xtextElement_0, bool bool_0);
	}
}

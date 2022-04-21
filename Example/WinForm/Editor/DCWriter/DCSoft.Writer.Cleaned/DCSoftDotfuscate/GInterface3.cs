using DCSoft.Common;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public interface GInterface3
	{
		bool imethod_0();

		void imethod_1(bool bool_0);

		Form imethod_2();

		void imethod_3(Form form_0);

		XTextDocument imethod_4();

		void imethod_5(XTextDocument xtextDocument_0);

		XTextContent imethod_6();

		void imethod_7(XTextContent xtextContent_0);

		int imethod_8(SearchReplaceCommandArgs searchReplaceCommandArgs_0);

		int imethod_9(SearchReplaceCommandArgs searchReplaceCommandArgs_0);

		int imethod_10(SearchReplaceCommandArgs searchReplaceCommandArgs_0);

		int imethod_11(SearchReplaceCommandArgs searchReplaceCommandArgs_0, bool bool_0, int int_0);

		int imethod_12(SearchReplaceCommandArgs searchReplaceCommandArgs_0, XTextElementList xtextElementList_0, bool bool_0, int int_0);
	}
}

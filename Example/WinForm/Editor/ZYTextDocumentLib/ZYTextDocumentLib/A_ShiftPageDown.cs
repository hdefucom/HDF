using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftPageDown : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftpagedown";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._PageDown();
			return true;
		}

		public A_ShiftPageDown()
		{
			HotKey = (Keys.RButton | Keys.Space | Keys.Shift);
		}
	}
}

using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftPageUp : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftpageup";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._PageUp();
			return true;
		}

		public A_ShiftPageUp()
		{
			HotKey = (Keys.LButton | Keys.Space | Keys.Shift);
		}
	}
}

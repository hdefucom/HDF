using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftMoveUp : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftmoveup";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._MoveUp();
			return true;
		}

		public A_ShiftMoveUp()
		{
			HotKey = (Keys.RButton | Keys.MButton | Keys.Space | Keys.Shift);
		}
	}
}

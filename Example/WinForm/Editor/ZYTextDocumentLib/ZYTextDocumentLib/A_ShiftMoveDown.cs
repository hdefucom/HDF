using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftMoveDown : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftmovedown";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._MoveDown();
			return true;
		}

		public A_ShiftMoveDown()
		{
			HotKey = (Keys.Back | Keys.Space | Keys.Shift);
		}
	}
}

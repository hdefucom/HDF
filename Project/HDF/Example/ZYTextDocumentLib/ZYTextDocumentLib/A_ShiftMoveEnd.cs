using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftMoveEnd : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftmoveend";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._MoveEnd();
			return true;
		}

		public A_ShiftMoveEnd()
		{
			HotKey = (Keys.LButton | Keys.RButton | Keys.Space | Keys.Shift);
		}
	}
}

using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftMoveRight : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftmoveright";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._MoveRight();
			return true;
		}

		public A_ShiftMoveRight()
		{
			HotKey = (Keys.LButton | Keys.RButton | Keys.MButton | Keys.Space | Keys.Shift);
		}
	}
}

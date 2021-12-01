using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftMoveLeft : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftmoveleft";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._MoveLeft();
			return true;
		}

		public A_ShiftMoveLeft()
		{
			HotKey = (Keys.LButton | Keys.MButton | Keys.Space | Keys.Shift);
		}
	}
}

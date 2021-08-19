using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ShiftMoveHome : ZYEditorAction
	{
		public override string ActionName()
		{
			return "shiftmovehome";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = false;
			myOwnerDocument._MoveHome();
			return true;
		}

		public A_ShiftMoveHome()
		{
			HotKey = (Keys.MButton | Keys.Space | Keys.Shift);
		}
	}
}

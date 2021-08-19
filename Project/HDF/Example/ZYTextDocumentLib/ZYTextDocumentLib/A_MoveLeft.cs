using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_MoveLeft : ZYEditorAction
	{
		public override string ActionName()
		{
			return "moveleft";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._MoveLeft();
			return true;
		}

		public A_MoveLeft()
		{
			HotKey = Keys.Left;
		}
	}
}

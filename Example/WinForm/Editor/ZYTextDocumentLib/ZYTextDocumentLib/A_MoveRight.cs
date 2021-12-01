using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_MoveRight : ZYEditorAction
	{
		public override string ActionName()
		{
			return "moveright";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._MoveRight();
			return true;
		}

		public A_MoveRight()
		{
			HotKey = Keys.Right;
		}
	}
}

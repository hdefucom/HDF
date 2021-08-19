using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_MoveHome : ZYEditorAction
	{
		public override string ActionName()
		{
			return "movehome";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._MoveHome();
			return true;
		}

		public A_MoveHome()
		{
			HotKey = Keys.Home;
		}
	}
}

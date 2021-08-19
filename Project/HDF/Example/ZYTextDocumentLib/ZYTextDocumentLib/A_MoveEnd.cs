using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_MoveEnd : ZYEditorAction
	{
		public override string ActionName()
		{
			return "moveend";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._MoveEnd();
			return true;
		}

		public A_MoveEnd()
		{
			HotKey = Keys.End;
		}
	}
}

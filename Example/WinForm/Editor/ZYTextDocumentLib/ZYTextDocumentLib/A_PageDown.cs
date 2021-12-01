using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_PageDown : ZYEditorAction
	{
		public override string ActionName()
		{
			return "pagedown";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._PageDown();
			return true;
		}

		public A_PageDown()
		{
			HotKey = Keys.Next;
		}
	}
}

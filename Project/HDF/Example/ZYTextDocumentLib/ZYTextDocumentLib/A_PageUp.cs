using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_PageUp : ZYEditorAction
	{
		public override string ActionName()
		{
			return "pageup";
		}

		public override bool Execute()
		{
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._PageUp();
			return true;
		}

		public A_PageUp()
		{
			HotKey = Keys.Prior;
		}
	}
}

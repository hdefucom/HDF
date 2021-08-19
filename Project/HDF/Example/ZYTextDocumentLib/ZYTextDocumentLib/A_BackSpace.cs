using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_BackSpace : ZYEditorAction
	{
		public override bool CanHandleKeyDown()
		{
			return false;
		}

		public override string ActionName()
		{
			return "backspace";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._BackSpace();
			return true;
		}

		public A_BackSpace()
		{
			HotKey = Keys.Back;
		}
	}
}

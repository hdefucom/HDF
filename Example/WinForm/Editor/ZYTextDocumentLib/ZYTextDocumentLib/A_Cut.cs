using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_Cut : ZYEditorAction
	{
		public override string ActionName()
		{
			return "cut";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify() && myOwnerDocument.Content.HasSelected();
		}

		public override bool Execute()
		{
			myOwnerDocument._Cut();
			return true;
		}

		public A_Cut()
		{
			HotKey = (Keys)131160;
		}
	}
}

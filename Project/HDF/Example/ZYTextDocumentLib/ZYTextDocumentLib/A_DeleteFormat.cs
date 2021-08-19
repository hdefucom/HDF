using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_DeleteFormat : ZYEditorAction
	{
		public override string ActionName()
		{
			return "deleteformat";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify())
			{
				return myOwnerDocument.Content.HasSelected();
			}
			return base.isEnable();
		}

		public override bool Execute()
		{
			myOwnerDocument._DeleteFormat();
			return true;
		}

		public A_DeleteFormat()
		{
			HotKey = (Keys.RButton | Keys.MButton | Keys.Back | Keys.Space | Keys.Control);
		}
	}
}

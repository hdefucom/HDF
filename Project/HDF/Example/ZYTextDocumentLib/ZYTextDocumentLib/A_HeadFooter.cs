using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_HeadFooter : ZYEditorAction
	{
		public override string ActionName()
		{
			return "headfooter";
		}

		public override bool Execute()
		{
			using (dlgSetHeadFooter dlgSetHeadFooter = new dlgSetHeadFooter())
			{
				dlgSetHeadFooter.myDocument = myOwnerDocument;
				if (dlgSetHeadFooter.ShowDialog() == DialogResult.OK)
				{
					myOwnerDocument.RefreshLine();
					myOwnerDocument.Refresh();
				}
			}
			return true;
		}
	}
}

using System.Windows.Forms;
using XDesignerPrinting;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_PageSetting : ZYEditorAction
	{
		public override string ActionName()
		{
			return "pagesetting";
		}

		public override bool Execute()
		{
			using (XDesignerPrinting.dlgPageSetup dlgPageSetup = new XDesignerPrinting.dlgPageSetup())
			{
				dlgPageSetup.PageSettings = myOwnerDocument.Pages.PageSettings;
				if (dlgPageSetup.ShowDialog() == DialogResult.OK)
				{
					myOwnerDocument.Pages.PageSettings = dlgPageSetup.PageSettings;
					myOwnerDocument.RefreshLine();
					myOwnerDocument.RefreshPages();
					myOwnerDocument.OwnerControl.UpdatePages();
					myOwnerDocument.Refresh();
					bool flag = ZYConfig.SavePaperSetting(myOwnerDocument.DataSource.DBConn.Connection, base.OwnerDocument.Pages.PageSettings, ZYPublic.ModalityName);
					return true;
				}
			}
			return false;
		}
	}
}

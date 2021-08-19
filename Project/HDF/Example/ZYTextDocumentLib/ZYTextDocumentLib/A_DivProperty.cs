using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_DivProperty : ZYEditorAction
	{
		public override string ActionName()
		{
			return "divproperty";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify() && myOwnerDocument.Content.CurrentElement != null && myOwnerDocument.Content.CurrentElement.Parent is ZYTextDiv)
			{
				return base.isEnable();
			}
			return false;
		}

		public override bool Execute()
		{
			ZYTextDiv zYTextDiv = myOwnerDocument.Content.CurrentElement.Parent as ZYTextDiv;
			if (zYTextDiv != null)
			{
				using (dlgDivProperty dlgDivProperty = new dlgDivProperty())
				{
					dlgDivProperty.DivObject = zYTextDiv;
					if (dlgDivProperty.ShowDialog() == DialogResult.OK)
					{
						myOwnerDocument.RefreshLine();
						myOwnerDocument.UpdateView();
					}
				}
			}
			return true;
		}
	}
}

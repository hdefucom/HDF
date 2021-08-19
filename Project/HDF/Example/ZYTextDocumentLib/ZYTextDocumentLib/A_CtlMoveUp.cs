using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_CtlMoveUp : ZYEditorAction
	{
		public override string ActionName()
		{
			return "ctlmoveup";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.Content.CurrentElement != null)
			{
				ZYTextSelect zYTextSelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
				if (zYTextSelect == null)
				{
					zYTextSelect = (myOwnerDocument.Content.CurrentElement.Parent as ZYTextSelect);
				}
				if (!(zYTextSelect?.Parent.Locked ?? true))
				{
					return true;
				}
			}
			return false;
		}

		public override bool Execute()
		{
			if (myOwnerDocument.Content.CurrentElement != null)
			{
				ZYTextSelect zYTextSelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
				if (zYTextSelect == null)
				{
					zYTextSelect = (myOwnerDocument.Content.CurrentElement.Parent as ZYTextSelect);
				}
				if (zYTextSelect != null)
				{
					zYTextSelect.PopupList();
					return true;
				}
			}
			return false;
		}

		public A_CtlMoveUp()
		{
			HotKey = (Keys.RButton | Keys.MButton | Keys.Space | Keys.Control);
		}
	}
}

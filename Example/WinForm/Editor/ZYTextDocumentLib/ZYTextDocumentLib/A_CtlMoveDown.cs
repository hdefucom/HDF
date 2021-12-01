using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_CtlMoveDown : ZYEditorAction
	{
		public override string ActionName()
		{
			return "ctlmovedown";
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

		public A_CtlMoveDown()
		{
			HotKey = (Keys.Back | Keys.Space | Keys.Control);
		}
	}
}

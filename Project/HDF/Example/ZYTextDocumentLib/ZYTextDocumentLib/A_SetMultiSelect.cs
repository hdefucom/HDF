namespace ZYTextDocumentLib
{
	public class A_SetMultiSelect : ZYEditorAction
	{
		public override string ActionName()
		{
			return "setmultiselect";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify() && myOwnerDocument.Content.CurrentElement is ZYTextSelect)
			{
				return base.isEnable();
			}
			return false;
		}

		public override int CheckState()
		{
			ZYTextSelect zYTextSelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
			if (zYTextSelect == null)
			{
				return -1;
			}
			return zYTextSelect.Multiple ? 1 : 0;
		}

		public override bool Execute()
		{
			ZYTextSelect zYTextSelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
			if (zYTextSelect != null)
			{
				zYTextSelect.Multiple = !zYTextSelect.Multiple;
			}
			return true;
		}
	}
}

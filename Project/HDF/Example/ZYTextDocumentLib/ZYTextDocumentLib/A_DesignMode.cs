namespace ZYTextDocumentLib
{
	public class A_DesignMode : ZYEditorAction
	{
		public override string ActionName()
		{
			return "designmode";
		}

		public override bool isEnable()
		{
			return true;
		}

		public override bool Execute()
		{
			myOwnerDocument.Info.DesignMode = !myOwnerDocument.Info.DesignMode;
			myOwnerDocument.RefreshElements();
			myOwnerDocument.RefreshLine();
			myOwnerDocument.UpdateView();
			return true;
		}

		public override int CheckState()
		{
			return myOwnerDocument.Info.DesignMode ? 1 : 0;
		}
	}
}

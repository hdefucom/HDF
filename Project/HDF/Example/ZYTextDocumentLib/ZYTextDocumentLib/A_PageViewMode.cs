namespace ZYTextDocumentLib
{
	public class A_PageViewMode : ZYEditorAction
	{
		public override string ActionName()
		{
			return "pageviewmode";
		}

		public override bool Execute()
		{
			if (myOwnerDocument.OwnerControl != null)
			{
				bool flag = Param1 == "1";
				myOwnerDocument.RefreshLine();
				if (flag)
				{
					myOwnerDocument.OwnerControl.UpdatePages();
				}
				else
				{
					myOwnerDocument.UpdateView();
				}
				myOwnerDocument.Refresh();
				myOwnerDocument.OwnerControl.UpdateTextCaret();
			}
			return true;
		}

		public override int CheckState()
		{
			return 1;
		}
	}
}

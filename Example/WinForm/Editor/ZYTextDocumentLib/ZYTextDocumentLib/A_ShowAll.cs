namespace ZYTextDocumentLib
{
	public class A_ShowAll : ZYEditorAction
	{
		public override string ActionName()
		{
			return "showall";
		}

		public override bool Execute()
		{
			ZYTextElement lastNotDeletedElement = myOwnerDocument.GetLastNotDeletedElement(-1);
			myOwnerDocument.Info.ShowAll = (Param1 == "1");
			myOwnerDocument.RefreshElements();
			myOwnerDocument.RefreshLine();
			if (myOwnerDocument.Elements.Contains(lastNotDeletedElement))
			{
				myOwnerDocument.Content.SetSelection(myOwnerDocument.Elements.IndexOf(lastNotDeletedElement), 0);
			}
			else
			{
				myOwnerDocument.Content.SetSelection(0, 0);
			}
			myOwnerDocument.UpdateView();
			return true;
		}

		public override int CheckState()
		{
			return myOwnerDocument.Info.ShowAll ? 1 : 0;
		}
	}
}

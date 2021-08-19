namespace ZYTextDocumentLib
{
	public class A_ShowMark : ZYEditorAction
	{
		public override string ActionName()
		{
			return "showmark";
		}

		public override bool Execute()
		{
			myOwnerDocument.Info.ShowMark = (Param1 == "1");
			myOwnerDocument.Refresh();
			return true;
		}

		public override int CheckState()
		{
			return myOwnerDocument.Info.ShowMark ? 1 : 0;
		}
	}
}

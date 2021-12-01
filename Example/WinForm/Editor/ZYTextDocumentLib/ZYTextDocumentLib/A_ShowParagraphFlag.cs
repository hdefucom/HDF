namespace ZYTextDocumentLib
{
	public class A_ShowParagraphFlag : ZYEditorAction
	{
		public override string ActionName()
		{
			return "showparagraphflag";
		}

		public override bool Execute()
		{
			myOwnerDocument.Info.ShowParagraphFlag = (Param1 == "1");
			myOwnerDocument.Refresh();
			return true;
		}

		public override int CheckState()
		{
			return myOwnerDocument.Info.ShowParagraphFlag ? 1 : 0;
		}
	}
}

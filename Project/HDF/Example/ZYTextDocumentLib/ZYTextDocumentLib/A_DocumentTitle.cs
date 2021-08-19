namespace ZYTextDocumentLib
{
	public class A_DocumentTitle : ZYEditorAction
	{
		public override string ActionName()
		{
			return "title";
		}

		public override bool Execute()
		{
			myOwnerDocument.Info.Title = Param1;
			myOwnerDocument.Modified = true;
			return true;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string GetText()
		{
			return myOwnerDocument.Info.Title;
		}
	}
}

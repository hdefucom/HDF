namespace ZYTextDocumentLib
{
	public class A_RemoveBlankLine : ZYEditorAction
	{
		public override string ActionName()
		{
			return "removeblankline";
		}

		public override bool Execute()
		{
			myOwnerDocument.RemoveBlankLine();
			return true;
		}
	}
}

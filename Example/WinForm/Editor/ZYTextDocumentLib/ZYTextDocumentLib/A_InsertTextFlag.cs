namespace ZYTextDocumentLib
{
	public class A_InsertTextFlag : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertflag";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertTextFlag("固定文本块");
			return true;
		}
	}
}

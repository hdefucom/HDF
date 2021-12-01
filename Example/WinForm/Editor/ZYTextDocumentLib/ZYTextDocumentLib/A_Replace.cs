namespace ZYTextDocumentLib
{
	public class A_Replace : ZYEditorAction
	{
		public override string ActionName()
		{
			return "replace";
		}

		public override bool Execute()
		{
			myOwnerDocument._Replace(Param1, Param2);
			return true;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}
	}
}

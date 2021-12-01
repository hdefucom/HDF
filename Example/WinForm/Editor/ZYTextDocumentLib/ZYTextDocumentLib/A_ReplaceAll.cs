namespace ZYTextDocumentLib
{
	public class A_ReplaceAll : ZYEditorAction
	{
		public override string ActionName()
		{
			return "replaceall";
		}

		public override bool Execute()
		{
			myOwnerDocument._ReplaceAll(Param1, Param2);
			return true;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}
	}
}

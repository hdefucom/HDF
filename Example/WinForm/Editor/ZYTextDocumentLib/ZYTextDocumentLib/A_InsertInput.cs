namespace ZYTextDocumentLib
{
	public class A_InsertInput : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertinput";
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertInput("新增的输入域", null);
			return true;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}
	}
}

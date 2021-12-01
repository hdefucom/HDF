namespace ZYTextDocumentLib
{
	public class A_SetVariable : ZYEditorAction
	{
		public override string ActionName()
		{
			return "setvariable";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.DataSource.AddQueryVariable(Param1, Param2);
			return true;
		}
	}
}

namespace ZYTextDocumentLib
{
	public class A_RemoveVariable : ZYEditorAction
	{
		public override string ActionName()
		{
			return "removevariable";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.DataSource.RemoveQueryVariable(Param1);
			return true;
		}
	}
}

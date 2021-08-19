namespace ZYTextDocumentLib
{
	public class A_LogicDelete : ZYEditorAction
	{
		public override string ActionName()
		{
			return "logicdelete";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.Info.LogicDelete = (Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			return myOwnerDocument.Info.LogicDelete ? 1 : 0;
		}
	}
}

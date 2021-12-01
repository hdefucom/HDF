namespace ZYTextDocumentLib
{
	public class A_InsertSelect : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertselect";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertSelect("", Param2, bolMultiple: false);
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertSelect a_InsertSelect = new A_InsertSelect();
			a_InsertSelect.BaseCloneFrom(this);
			return a_InsertSelect;
		}
	}
}

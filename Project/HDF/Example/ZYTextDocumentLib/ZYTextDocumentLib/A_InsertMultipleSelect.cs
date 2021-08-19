namespace ZYTextDocumentLib
{
	public class A_InsertMultipleSelect : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertmultipleselect";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertSelect("", Param2, bolMultiple: true);
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertMultipleSelect a_InsertMultipleSelect = new A_InsertMultipleSelect();
			a_InsertMultipleSelect.BaseCloneFrom(this);
			return a_InsertMultipleSelect;
		}
	}
}

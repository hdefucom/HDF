namespace ZYTextDocumentLib
{
	public class A_InsertDiv : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertdiv";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertDiv(Param1);
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertDiv a_InsertDiv = new A_InsertDiv();
			a_InsertDiv.BaseCloneFrom(this);
			return a_InsertDiv;
		}
	}
}

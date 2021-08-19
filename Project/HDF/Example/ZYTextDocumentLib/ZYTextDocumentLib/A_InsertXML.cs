namespace ZYTextDocumentLib
{
	public class A_InsertXML : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertxml";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.InsertByXML(Param1);
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertXML a_InsertXML = new A_InsertXML();
			a_InsertXML.BaseCloneFrom(this);
			return a_InsertXML;
		}
	}
}

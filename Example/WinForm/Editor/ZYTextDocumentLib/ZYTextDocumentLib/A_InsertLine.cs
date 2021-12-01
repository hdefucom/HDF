namespace ZYTextDocumentLib
{
	public class A_InsertLine : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertline";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify())
			{
				return base.isEnable();
			}
			return false;
		}

		public override bool Execute()
		{
			ZYTextHRule newElement = new ZYTextHRule();
			myOwnerDocument._InsertElement(newElement);
			return true;
		}
	}
}

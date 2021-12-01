namespace ZYTextDocumentLib
{
	public class A_InsertString : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertstring";
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
			myOwnerDocument.BeginContentChangeLog();
			myOwnerDocument.BeginUpdate();
			myOwnerDocument.Content.InsertString(Param1);
			myOwnerDocument.EndUpdate();
			myOwnerDocument.EndContentChangeLog();
			return true;
		}
	}
}

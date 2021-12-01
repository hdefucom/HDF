namespace ZYTextDocumentLib
{
	public class A_SetSup : ZYEditorAction
	{
		public override string ActionName()
		{
			return "sup";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectionSup(Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			ZYTextChar zYTextChar = myOwnerDocument.Content.CurrentElement as ZYTextChar;
			if (zYTextChar != null)
			{
				return zYTextChar.Sup ? 1 : 0;
			}
			return -1;
		}

		public override ZYEditorAction Clone()
		{
			A_SetSup a_SetSup = new A_SetSup();
			a_SetSup.BaseCloneFrom(this);
			return a_SetSup;
		}
	}
}

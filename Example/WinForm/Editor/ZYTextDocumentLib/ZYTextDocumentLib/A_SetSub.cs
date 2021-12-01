namespace ZYTextDocumentLib
{
	public class A_SetSub : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "sub";
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectionSub(Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			ZYTextChar zYTextChar = myOwnerDocument.Content.CurrentElement as ZYTextChar;
			if (zYTextChar != null)
			{
				return zYTextChar.Sub ? 1 : 0;
			}
			return -1;
		}

		public override ZYEditorAction Clone()
		{
			A_SetSub a_SetSub = new A_SetSub();
			a_SetSub.BaseCloneFrom(this);
			return a_SetSub;
		}
	}
}

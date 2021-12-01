namespace ZYTextDocumentLib
{
	public class A_FontBold : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "bold";
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectionFontBold(Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			ZYTextChar preChar = myOwnerDocument.Content.GetPreChar();
			if (preChar != null)
			{
				return preChar.FontBold ? 1 : 0;
			}
			return -1;
		}

		public override ZYEditorAction Clone()
		{
			A_FontBold a_FontBold = new A_FontBold();
			a_FontBold.BaseCloneFrom(this);
			return a_FontBold;
		}
	}
}

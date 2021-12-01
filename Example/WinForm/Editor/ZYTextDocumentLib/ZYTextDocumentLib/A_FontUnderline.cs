namespace ZYTextDocumentLib
{
	public class A_FontUnderline : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "underline";
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectionUnderLine(Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			ZYTextChar preChar = myOwnerDocument.Content.GetPreChar();
			if (preChar != null)
			{
				return preChar.FontUnderLine ? 1 : 0;
			}
			return -1;
		}

		public override ZYEditorAction Clone()
		{
			A_FontUnderline a_FontUnderline = new A_FontUnderline();
			a_FontUnderline.BaseCloneFrom(this);
			return a_FontUnderline;
		}
	}
}

namespace ZYTextDocumentLib
{
	public class A_FontItalic : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "italic";
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectionFontItalic(Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			ZYTextChar preChar = myOwnerDocument.Content.GetPreChar();
			if (preChar != null)
			{
				return preChar.FontItalic ? 1 : 0;
			}
			return -1;
		}

		public override ZYEditorAction Clone()
		{
			A_FontItalic a_FontItalic = new A_FontItalic();
			a_FontItalic.BaseCloneFrom(this);
			return a_FontItalic;
		}
	}
}

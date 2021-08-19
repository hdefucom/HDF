namespace ZYTextDocumentLib
{
	public class A_FontName : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "fontname";
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectioinFontName(Param1);
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_FontName a_FontName = new A_FontName();
			a_FontName.BaseCloneFrom(this);
			return a_FontName;
		}
	}
}

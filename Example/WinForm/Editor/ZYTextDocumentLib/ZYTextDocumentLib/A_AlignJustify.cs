namespace ZYTextDocumentLib
{
	public class A_AlignJustify : ZYEditorAction
	{
		public override string ActionName()
		{
			return "alignjustify";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.SetAlign(ParagraphAlignConst.Justify);
			return true;
		}

		public override int CheckState()
		{
			ZYTextParagraph ownerParagraph = myOwnerDocument.GetOwnerParagraph();
			if (ownerParagraph != null && ownerParagraph.Align == ParagraphAlignConst.Justify)
			{
				return 1;
			}
			return 0;
		}
	}
}

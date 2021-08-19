namespace ZYTextDocumentLib
{
	public class A_AlignLeft : ZYEditorAction
	{
		public override string ActionName()
		{
			return "alignleft";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.SetAlign(ParagraphAlignConst.Left);
			return true;
		}

		public override int CheckState()
		{
			ZYTextParagraph ownerParagraph = myOwnerDocument.GetOwnerParagraph();
			if (ownerParagraph != null && ownerParagraph.Align == ParagraphAlignConst.Left)
			{
				return 1;
			}
			return 0;
		}
	}
}

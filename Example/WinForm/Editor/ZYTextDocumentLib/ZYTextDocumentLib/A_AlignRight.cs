namespace ZYTextDocumentLib
{
	public class A_AlignRight : ZYEditorAction
	{
		public override string ActionName()
		{
			return "alignright";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.SetAlign(ParagraphAlignConst.Right);
			return true;
		}

		public override int CheckState()
		{
			ZYTextParagraph ownerParagraph = myOwnerDocument.GetOwnerParagraph();
			if (ownerParagraph != null && ownerParagraph.Align == ParagraphAlignConst.Right)
			{
				return 1;
			}
			return 0;
		}
	}
}

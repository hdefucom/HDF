namespace ZYTextDocumentLib
{
	public class A_AlignCenter : ZYEditorAction
	{
		public override string ActionName()
		{
			return "aligncenter";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument.SetAlign(ParagraphAlignConst.Center);
			return true;
		}

		public override int CheckState()
		{
			ZYTextParagraph ownerParagraph = myOwnerDocument.GetOwnerParagraph();
			if (ownerParagraph != null && ownerParagraph.Align == ParagraphAlignConst.Center)
			{
				return 1;
			}
			return 0;
		}
	}
}

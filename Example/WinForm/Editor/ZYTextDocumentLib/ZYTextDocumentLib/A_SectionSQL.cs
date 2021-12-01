namespace ZYTextDocumentLib
{
	public class A_SectionSQL : ZYEditorAction
	{
		public override string ActionName()
		{
			return "sectionsql";
		}

		public override bool Execute()
		{
			ZYKBBuffer.Instance.SectionSQL = Param1;
			ZYKBBuffer.Instance.UpdateSectionList();
			return true;
		}
	}
}

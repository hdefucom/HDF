namespace ZYTextDocumentLib
{
	public class A_EnableKBSection : ZYEditorAction
	{
		public override string ActionName()
		{
			return "enablekbsection";
		}

		public override bool Execute()
		{
			ZYKBBuffer.Instance.EnableKBSection = (Param1 == "1");
			return true;
		}

		public override int CheckState()
		{
			return ZYKBBuffer.Instance.EnableKBSection ? 1 : 0;
		}
	}
}

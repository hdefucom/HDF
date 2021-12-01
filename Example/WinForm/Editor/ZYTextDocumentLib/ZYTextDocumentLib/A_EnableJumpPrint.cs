namespace ZYTextDocumentLib
{
	public class A_EnableJumpPrint : ZYEditorAction
	{
		public override string ActionName()
		{
			return "enablejumpprint";
		}

		public override bool Execute()
		{
			myOwnerDocument.EnableJumpPrint = !myOwnerDocument.EnableJumpPrint;
			myOwnerDocument.Refresh();
			return true;
		}

		public override int CheckState()
		{
			if (myOwnerDocument.EnableJumpPrint)
			{
				return 1;
			}
			return 0;
		}
	}
}

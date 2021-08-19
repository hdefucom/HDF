namespace ZYTextDocumentLib
{
	public class A_LockDocument : ZYEditorAction
	{
		public override string ActionName()
		{
			return "lock";
		}

		public override bool Execute()
		{
			myOwnerDocument.Locked = (Param1 == "1");
			myOwnerDocument.Refresh();
			return true;
		}

		public override int CheckState()
		{
			return myOwnerDocument.Locked ? 1 : 0;
		}
	}
}

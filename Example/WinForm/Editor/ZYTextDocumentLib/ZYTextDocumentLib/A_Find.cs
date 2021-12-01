using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_Find : ZYEditorAction
	{
		public override string ActionName()
		{
			return "find";
		}

		public override bool Execute()
		{
			myOwnerDocument._Find(Param1);
			return true;
		}

		public A_Find()
		{
			HotKey = Keys.F3;
		}
	}
}

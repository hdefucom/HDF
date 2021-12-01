using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_Delete : ZYEditorAction
	{
		public override string ActionName()
		{
			return "delete";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._Delete();
			return true;
		}

		public A_Delete()
		{
			HotKey = Keys.Delete;
		}
	}
}

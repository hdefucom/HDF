using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_InsertTemplate : ZYEditorAction
	{
		public override string ActionName()
		{
			return "inserttemplate";
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertKB(OnlyTemplate: true);
			return true;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public A_InsertTemplate()
		{
			HotKey = (Keys)131156;
		}
	}
}

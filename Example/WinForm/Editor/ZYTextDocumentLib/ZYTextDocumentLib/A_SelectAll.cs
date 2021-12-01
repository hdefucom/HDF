using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_SelectAll : ZYEditorAction
	{
		public override string ActionName()
		{
			return "selectall";
		}

		public override bool Execute()
		{
			myOwnerDocument._SelectAll();
			return true;
		}

		public A_SelectAll()
		{
			HotKey = (Keys)131137;
		}
	}
}

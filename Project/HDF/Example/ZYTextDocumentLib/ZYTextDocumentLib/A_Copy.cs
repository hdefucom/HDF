using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_Copy : ZYEditorAction
	{
		public override string ActionName()
		{
			return "copy";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.Content.HasSelectedText();
		}

		public override bool Execute()
		{
			myOwnerDocument._Copy();
			return true;
		}

		public A_Copy()
		{
			HotKey = (Keys)131139;
		}
	}
}

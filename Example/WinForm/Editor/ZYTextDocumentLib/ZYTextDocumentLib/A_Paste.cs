using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_Paste : ZYEditorAction
	{
		public override string ActionName()
		{
			return "paste";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify() && ClipboardHandler.CanGetText();
		}

		public override bool Execute()
		{
			myOwnerDocument._Paste();
			return true;
		}

		public A_Paste()
		{
			HotKey = (Keys)131158;
		}
	}
}

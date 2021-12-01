using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_Redo : ZYEditorAction
	{
		public override string ActionName()
		{
			return "redo";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify() && myOwnerDocument.RedoList.Count > 0)
			{
				return base.isEnable();
			}
			return false;
		}

		public override bool Execute()
		{
			return myOwnerDocument._Redo();
		}

		public override string GetText()
		{
			if (isEnable())
			{
				ZYEditorAction zYEditorAction = (ZYEditorAction)myOwnerDocument.RedoList[myOwnerDocument.RedoList.Count - 1];
				return "重复 " + zYEditorAction.UndoName();
			}
			return "无可重复的操作";
		}

		public A_Redo()
		{
			HotKey = (Keys)131161;
		}
	}
}

using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_Undo : ZYEditorAction
	{
		public override string ActionName()
		{
			return "undo";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify() && myOwnerDocument.UndoList.Count > 0)
			{
				return base.isEnable();
			}
			return false;
		}

		public override bool Execute()
		{
			myOwnerDocument._Undo();
			return true;
		}

		public override string GetText()
		{
			if (isEnable())
			{
				ZYEditorAction zYEditorAction = (ZYEditorAction)myOwnerDocument.UndoList[myOwnerDocument.UndoList.Count - 1];
				return "撤销 " + zYEditorAction.UndoName();
			}
			return "无可撤销的操作";
		}

		public A_Undo()
		{
			HotKey = (Keys)131162;
		}
	}
}

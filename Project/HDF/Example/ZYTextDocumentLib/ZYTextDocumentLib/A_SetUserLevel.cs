using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_SetUserLevel : ZYEditorAction
	{
		internal int intLevelBack = 0;

		public override string ActionName()
		{
			return "setuserlevel";
		}

		public override bool Execute()
		{
			int num = StringCommon.ToInt32Value(Param1, -1);
			if (num != myOwnerDocument.Info.VisibleUserLevel)
			{
				intLevelBack = myOwnerDocument.Info.VisibleUserLevel;
				myOwnerDocument.Info.VisibleUserLevel = num;
				myOwnerDocument.RefreshElements();
				myOwnerDocument.RefreshLine();
				myOwnerDocument.UpdateView();
				myOwnerDocument.RegisteUndo(this);
			}
			return true;
		}

		public override bool isUndoable()
		{
			return true;
		}

		public override string UndoName()
		{
			return "设置显示层次" + intLevelBack;
		}

		public override bool Undo()
		{
			myOwnerDocument.Info.VisibleUserLevel = intLevelBack;
			myOwnerDocument.RefreshElements();
			myOwnerDocument.RefreshLine();
			myOwnerDocument.UpdateView();
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_SetUserLevel a_SetUserLevel = new A_SetUserLevel();
			a_SetUserLevel.BaseCloneFrom(this);
			a_SetUserLevel.intLevelBack = intLevelBack;
			return a_SetUserLevel;
		}
	}
}

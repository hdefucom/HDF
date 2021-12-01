using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_MoveUp : ZYEditorAction
	{
		public override string ActionName()
		{
			return "moveup";
		}

		public override bool Execute()
		{
			ZYTextElement zYTextElement = (myOwnerDocument.Content.SelectLength < 0) ? myOwnerDocument.Content.PreElement : myOwnerDocument.Content.CurrentElement;
			ZYTextSelect zYTextSelect = zYTextElement as ZYTextSelect;
			if (zYTextSelect == null)
			{
				zYTextSelect = (zYTextElement.Parent as ZYTextSelect);
			}
			if (zYTextSelect != null && zYTextSelect.ContainsElements(myOwnerDocument.Content.GetSelectElements()))
			{
				zYTextSelect.PopupList();
				return true;
			}
			myOwnerDocument.AutoClearSelection = true;
			myOwnerDocument._MoveUp();
			return true;
		}

		public A_MoveUp()
		{
			HotKey = Keys.Up;
		}
	}
}

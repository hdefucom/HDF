using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_SetBackColor : ZYEditorAction
	{
		public override string ActionName()
		{
			return "setbackcolor";
		}

		public override bool Execute()
		{
			myOwnerDocument.OwnerControl.BackColor = StringCommon.ColorFromHtml(Param1, SystemColors.Window);
			myOwnerDocument.OwnerControl.Refresh();
			return true;
		}
	}
}

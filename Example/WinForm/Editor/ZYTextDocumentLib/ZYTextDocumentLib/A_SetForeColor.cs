using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_SetForeColor : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "forecolor";
		}

		public override bool Execute()
		{
			myOwnerDocument.SetSelectionColor(StringCommon.ColorFromHtml(Param1, SystemColors.WindowText));
			return true;
		}

		public override bool UIExecute()
		{
			using (ColorDialog colorDialog = new ColorDialog())
			{
				colorDialog.FullOpen = true;
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					myOwnerDocument.SetSelectionColor(colorDialog.Color);
					return true;
				}
			}
			return false;
		}

		public override ZYEditorAction Clone()
		{
			A_SetForeColor a_SetForeColor = new A_SetForeColor();
			a_SetForeColor.BaseCloneFrom(this);
			return a_SetForeColor;
		}
	}
}

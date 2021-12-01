using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_NewFilePacs : ZYEditorAction
	{
		public override string ActionName()
		{
			return "newfilepacs";
		}

		public override bool Execute()
		{
			switch (MessageBox.Show("清空内容后将不能恢复,确认清空内容吗?", "系统提示", MessageBoxButtons.YesNo))
			{
			case DialogResult.No:
				return false;
			default:
				myOwnerDocument.BeginUpdate();
				myOwnerDocument.ClearContent();
				myOwnerDocument.EndUpdate();
				myOwnerDocument.OwnerControl.LoadXML(ZYConfig.NewFileXml);
				myOwnerDocument.Modified = false;
				myOwnerDocument.Refresh();
				return true;
			}
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}
	}
}

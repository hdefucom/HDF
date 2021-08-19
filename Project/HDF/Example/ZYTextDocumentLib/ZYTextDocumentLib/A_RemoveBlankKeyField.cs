using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_RemoveBlankKeyField : ZYEditorAction
	{
		public override string ActionName()
		{
			return "removeblankkeyfield";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool UIExecute()
		{
			if (MessageBox.Show(null, "是否真的删除空白的数据域及其周围的字符?", "系统提问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				myOwnerDocument.RemoveBlankKeyField(ContentLog: true);
				return true;
			}
			return false;
		}

		public override bool Execute()
		{
			myOwnerDocument.RemoveBlankKeyField(ContentLog: true);
			return true;
		}
	}
}

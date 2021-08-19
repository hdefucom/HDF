using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_UnderWriteMarkUI : ZYEditorAction
	{
		public override string ActionName()
		{
			return "underwritemarkui";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify())
			{
				return base.isEnable();
			}
			return false;
		}

		public override bool Execute()
		{
			if (myOwnerDocument.Marks.AddMark(myOwnerDocument.SaveLogs.CurrentUserName, Param1) == null)
			{
				MessageBox.Show(null, "签名失败!", "签名", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			return true;
		}

		public override bool UIExecute()
		{
			string text = dlgInputBox.InputBox("当前用户为[" + myOwnerDocument.SaveLogs.CurrentUserName + "],请输入审核人的名称", "文档签名", "");
			if (!StringCommon.isBlankString(text))
			{
				Param1 = text;
				return Execute();
			}
			return false;
		}
	}
}

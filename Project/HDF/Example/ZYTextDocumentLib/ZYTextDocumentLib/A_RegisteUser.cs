using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_RegisteUser : ZYEditorAction
	{
		public override string ActionName()
		{
			return "registeuser";
		}

		public override bool Execute()
		{
			myOwnerDocument.SaveLogs.CurrentUserName = Param1;
			return true;
		}

		public override bool UIExecute()
		{
			string text = dlgInputBox.InputBox("请输入用户名", "用户登录", "");
			if (!StringCommon.isBlankString(text))
			{
				myOwnerDocument.SaveLogs.CurrentUserName = text;
			}
			return true;
		}
	}
}

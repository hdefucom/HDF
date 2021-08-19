using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_EditScript : ZYEditorAction
	{
		public override string ActionName()
		{
			return "editscript";
		}

		public override bool UIExecute()
		{
			if (!base.OwnerDocument.Script.EditPWDChecked)
			{
				string text = dlgInputBox.InputPassword("请输入编辑密码", "系统提示", base.OwnerDocument.Script.CheckEditPWD);
				if (text == null)
				{
					return false;
				}
			}
			using (frmScript frmScript = new frmScript())
			{
				frmScript.ScriptObj = base.OwnerDocument.Script;
				frmScript.ShowDialog();
			}
			return true;
		}
	}
}

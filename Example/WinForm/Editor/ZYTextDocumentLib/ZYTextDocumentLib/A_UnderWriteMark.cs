using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_UnderWriteMark : ZYEditorAction
	{
		public override string ActionName()
		{
			return "underwritemark";
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
	}
}

using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_InsertExDataInput : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertexdatainput";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify())
			{
				ZYTextElement preElement = myOwnerDocument.Content.PreElement;
				if (preElement == null)
				{
					return false;
				}
				if (preElement is ZYTextSelect || preElement.Parent is ZYTextSelect)
				{
					return base.isEnable();
				}
			}
			return false;
		}

		public override bool Execute()
		{
			ZYTextElement preElement = myOwnerDocument.Content.PreElement;
			ZYTextSelect zYTextSelect = preElement as ZYTextSelect;
			if (zYTextSelect == null)
			{
				zYTextSelect = (preElement.Parent as ZYTextSelect);
			}
			if (zYTextSelect != null)
			{
				ZYTextInput zYTextInput = myOwnerDocument._InsertInput(zYTextSelect.ID + "_data", zYTextSelect.Text + " 的说明");
			}
			return true;
		}

		public A_InsertExDataInput()
		{
			HotKey = (Keys)131146;
		}
	}
}

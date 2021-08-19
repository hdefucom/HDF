namespace ZYTextDocumentLib
{
	public class A_SetInputFormat : ZYEditorAction
	{
		public override string ActionName()
		{
			return "setinputformat";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify() && myOwnerDocument.Content.CurrentElement != null && myOwnerDocument.Content.CurrentElement.Parent is ZYTextInput)
			{
				return base.isEnable();
			}
			return false;
		}

		public override bool Execute()
		{
			ZYTextInput zYTextInput = myOwnerDocument.Content.CurrentElement.Parent as ZYTextInput;
			if (zYTextInput != null)
			{
				using (dlgFormat dlgFormat = new dlgFormat())
				{
					dlgFormat.myFormat = zYTextInput.Format;
					dlgFormat.ShowDialog();
					if (dlgFormat.bolModify)
					{
						zYTextInput.TestValueFormat();
						myOwnerDocument.RefreshElement(zYTextInput);
						myOwnerDocument.Modified = true;
						return true;
					}
				}
			}
			return false;
		}
	}
}

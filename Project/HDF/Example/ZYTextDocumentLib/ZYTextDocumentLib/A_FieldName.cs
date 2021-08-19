namespace ZYTextDocumentLib
{
	public class A_FieldName : ZYEditorAction
	{
		public override string ActionName()
		{
			return "fieldname";
		}

		public override string GetText()
		{
			ZYTextElement currentElement = myOwnerDocument.Content.CurrentElement;
			if (currentElement is ZYTextSelect || currentElement is ZYTextInput)
			{
				return currentElement.Attributes.GetString("id");
			}
			return currentElement.Parent.Attributes.GetString("id");
		}

		public override bool Execute()
		{
			ZYTextElement currentElement = myOwnerDocument.Content.CurrentElement;
			if (currentElement is ZYTextSelect || currentElement is ZYTextInput)
			{
				currentElement.Attributes.SetValue("id", Param1);
				if (currentElement is ZYTextInput)
				{
					currentElement.Attributes.SetValue("id", Param1);
					currentElement.RefreshSize();
					myOwnerDocument.RefreshLine();
					myOwnerDocument.UpdateViewNoScroll();
				}
			}
			else
			{
				currentElement.Parent.Attributes.SetValue("id", Param1);
				if (currentElement.Parent is ZYTextDiv)
				{
					currentElement.Parent.Attributes.SetValue("id", Param1);
				}
			}
			return true;
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify())
			{
				return base.isEnable();
			}
			return false;
		}
	}
}

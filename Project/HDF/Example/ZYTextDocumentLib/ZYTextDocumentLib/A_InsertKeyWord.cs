using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_InsertKeyWord : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertkeyword";
		}

		public override bool Execute()
		{
			if (StringCommon.IsInteger(Param1))
			{
				ZYTextKeyWord zYTextKeyWord = new ZYTextKeyWord();
				zYTextKeyWord.Source = StringCommon.ToInt32Value(Param1, -1);
				zYTextKeyWord.OwnerDocument = myOwnerDocument;
				if (zYTextKeyWord.GetTemplateRecord() != null)
				{
					myOwnerDocument._InsertElement(zYTextKeyWord);
				}
				return true;
			}
			return true;
		}
	}
}

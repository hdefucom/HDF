using System;

namespace ZYTextDocumentLib
{
	public class A_FontSize : ZYEditorAction
	{
		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override string ActionName()
		{
			return "fontsize";
		}

		public override bool Execute()
		{
			try
			{
				myOwnerDocument.SetSelectionFontSize(Convert.ToInt32(Param1));
				return true;
			}
			catch
			{
			}
			return false;
		}

		public override ZYEditorAction Clone()
		{
			A_FontSize a_FontSize = new A_FontSize();
			a_FontSize.BaseCloneFrom(this);
			return a_FontSize;
		}
	}
}

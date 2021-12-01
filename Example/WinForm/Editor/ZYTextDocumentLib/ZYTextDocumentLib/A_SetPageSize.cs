using System;

namespace ZYTextDocumentLib
{
	public class A_SetPageSize : ZYEditorAction
	{
		public override string ActionName()
		{
			return "setpagesize";
		}

		public override bool Execute()
		{
			myOwnerDocument.Pages.CustomPageSize = true;
			myOwnerDocument.Pages.LeftMargin = 0;
			myOwnerDocument.Pages.TopMargin = 0;
			myOwnerDocument.Pages.RightMargin = 0;
			myOwnerDocument.Pages.BottomMargin = 0;
			myOwnerDocument.Pages.PaperWidth = Convert.ToInt32(Param1);
			myOwnerDocument.Pages.PaperHeight = Convert.ToInt32(Param2);
			myOwnerDocument.RefreshLine();
			myOwnerDocument.UpdateView();
			return true;
		}
	}
}

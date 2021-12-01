using System.Collections;

namespace ZYTextDocumentLib
{
	public class A_ClearSaveLog : ZYEditorAction
	{
		public override string ActionName()
		{
			return "clearsavelog";
		}

		public override bool Execute()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(myOwnerDocument.DocumentElement);
			myOwnerDocument.DocumentElement.AddElementToListAbs(arrayList);
			foreach (ZYTextElement item in arrayList)
			{
				item.Attributes.RemoveAttribute("creator");
				item.Attributes.RemoveAttribute("deleter");
				item.DeleterIndex = -1;
			}
			myOwnerDocument.SaveLogs.Clear();
			myOwnerDocument.Info.VisibleUserLevel = -1;
			myOwnerDocument.Marks.Clear();
			myOwnerDocument.RefreshElements();
			myOwnerDocument.RefreshLine();
			myOwnerDocument.UpdateView();
			return true;
		}
	}
}

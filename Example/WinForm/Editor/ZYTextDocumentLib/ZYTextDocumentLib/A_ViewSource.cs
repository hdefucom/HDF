using System.Diagnostics;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_ViewSource : ZYEditorAction
	{
		public override string ActionName()
		{
			return "viewsource";
		}

		public override bool Execute()
		{
			string fileName = myOwnerDocument.Info.FileName;
			string text = Application.StartupPath + "\\temp.xml";
			myOwnerDocument.Info.SaveMode = 0;
			myOwnerDocument.ToXMLFile(text);
			Process.Start(text);
			myOwnerDocument.Info.FileName = fileName;
			return true;
		}
	}
}

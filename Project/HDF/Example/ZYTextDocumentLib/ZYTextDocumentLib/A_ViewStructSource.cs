using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class A_ViewStructSource : ZYEditorAction
	{
		public override string ActionName()
		{
			return "viewstructsource";
		}

		public override bool Execute()
		{
			string fileName = myOwnerDocument.Info.FileName;
			string text = Application.StartupPath + "\\temp.xml";
			XmlDocument xmlDocument = new XmlDocument();
			myOwnerDocument.Info.SaveMode = 3;
			myOwnerDocument.ToXMLFile(text);
			Process.Start(text);
			myOwnerDocument.Info.FileName = fileName;
			return true;
		}
	}
}

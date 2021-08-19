using System.IO;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_SaveAs : ZYEditorAction
	{
		public override string ActionName()
		{
			return "saveas";
		}

		public override bool Execute()
		{
			myOwnerDocument.ToXMLFile(Param1);
			myOwnerDocument.Modified = false;
			return true;
		}

		public override bool UIExecute()
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.FileName = myOwnerDocument.Info.FileName;
				saveFileDialog.CheckFileExists = false;
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.Title = "将文档另存为";
				saveFileDialog.Filter = "XML文件或Base64编码文件|*.xml;*.txt|所有文件|*.*";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string iD = myOwnerDocument.Info.ID;
					myOwnerDocument.Info.ID = "";
					myOwnerDocument.Info.SaveMode = 0;
					if (saveFileDialog.FileName.ToUpper().EndsWith("XML"))
					{
						myOwnerDocument.ToXMLFile(saveFileDialog.FileName);
					}
					else
					{
						XmlDocument xmlDocument = new XmlDocument();
						myOwnerDocument.ToXMLDocument(xmlDocument);
						string outerXml = xmlDocument.DocumentElement.OuterXml;
						outerXml = StringCommon.ToBase64String(outerXml);
						outerXml = StringCommon.FormatBase64String(outerXml, 8, 8);
						StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
						streamWriter.Write(outerXml);
						streamWriter.Close();
					}
					myOwnerDocument.Modified = false;
					myOwnerDocument.Info.ID = iD;
				}
			}
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_SaveAs a_SaveAs = new A_SaveAs();
			a_SaveAs.BaseCloneFrom(this);
			return a_SaveAs;
		}
	}
}

using System.IO;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_SaveFile : ZYEditorAction
	{
		public override string ActionName()
		{
			return "save";
		}

		public override bool Execute()
		{
			myOwnerDocument.ToXMLFile(myOwnerDocument.Info.FileName);
			myOwnerDocument.Modified = false;
			return true;
		}

		public override bool UIExecute()
		{
			string fileName = myOwnerDocument.Info.FileName;
			if (fileName == null || fileName.Length == 0)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.FileName = myOwnerDocument.Info.FileName;
					saveFileDialog.CheckFileExists = false;
					saveFileDialog.CheckPathExists = true;
					saveFileDialog.OverwritePrompt = true;
					saveFileDialog.Filter = "XML文件或Base64编码文件|*.xml;*.txt|所有文件|*.*";
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						myOwnerDocument.Info.SaveMode = 0;
						if (saveFileDialog.FileName.ToUpper().EndsWith("XML"))
						{
							myOwnerDocument.ToXMLFile(saveFileDialog.FileName);
						}
						else
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.PreserveWhitespace = true;
							myOwnerDocument.ToXMLDocument(xmlDocument);
							string outerXml = xmlDocument.DocumentElement.OuterXml;
							outerXml = StringCommon.ToBase64String(outerXml);
							outerXml = StringCommon.FormatBase64String(outerXml, 8, 2);
							StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
							streamWriter.Write(outerXml);
							streamWriter.Close();
						}
						myOwnerDocument.Modified = false;
					}
				}
			}
			else
			{
				myOwnerDocument.ToXMLFile(myOwnerDocument.Info.FileName);
			}
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_SaveFile a_SaveFile = new A_SaveFile();
			a_SaveFile.BaseCloneFrom(this);
			return a_SaveFile;
		}
	}
}

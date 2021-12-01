using System.IO;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_Open : ZYEditorAction
	{
		public override string ActionName()
		{
			return "open";
		}

		public override bool Execute()
		{
			string iD = myOwnerDocument.Info.ID;
			myOwnerDocument.BeginUpdate();
			if (Param1.ToUpper().EndsWith("XML"))
			{
				myOwnerDocument.FromXMLFile(Param1);
			}
			else
			{
				StreamReader streamReader = new StreamReader(Param1);
				string strData = streamReader.ReadToEnd();
				streamReader.Close();
				strData = StringCommon.FromBase64String(strData);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.PreserveWhitespace = true;
				xmlDocument.LoadXml(strData);
				myOwnerDocument.FromXML(xmlDocument.DocumentElement);
			}
			myOwnerDocument.RefreshSize();
			myOwnerDocument.ContentChanged();
			myOwnerDocument.Modified = false;
			myOwnerDocument.EndUpdate();
			myOwnerDocument.Info.ID = iD;
			return true;
		}

		public override bool UIExecute()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				openFileDialog.Title = "打开文件";
				openFileDialog.ShowReadOnly = false;
				openFileDialog.Filter = "XML文件或Base64编码文件|*.xml;*.txt|所有文件|*.*";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Param1 = openFileDialog.FileName;
					Execute();
				}
			}
			return true;
		}
	}
}

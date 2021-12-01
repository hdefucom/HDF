using System.Data;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class A_SaveDBFile : ZYEditorAction
	{
		public OnSaveHandler OnSave = null;

		public override string ActionName()
		{
			return "savedbfile";
		}

		public override bool Execute()
		{
			if (myOwnerDocument.OwnerKBItem == null)
			{
				return false;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			myOwnerDocument.Info.SaveMode = 0;
			myOwnerDocument.ToXMLDocument(xmlDocument);
			ET_Document eT_Document = new ET_Document();
			eT_Document.SetKeyWord(myOwnerDocument.Info.ID);
			eT_Document.KeyPreFix = ZYKBBuffer.Instance.KeyPreFix;
			if (eT_Document.isKeyEnable() && myOwnerDocument.DataSource.DBConn.TestRecordExist(eT_Document))
			{
				eT_Document.DataState = DataRowState.Modified;
			}
			else
			{
				eT_Document.DataState = DataRowState.Added;
				eT_Document.ObjectID = null;
			}
			eT_Document.ObjectName = myOwnerDocument.Info.Title;
			eT_Document.ObjectData = xmlDocument.DocumentElement.OuterXml;
			if (myOwnerDocument.DataSource.DBConn.UpdateRecordAuto(eT_Document))
			{
				myOwnerDocument.Info.ID = eT_Document.ObjectID.ToString();
				myOwnerDocument.Modified = false;
				if (OnSave != null)
				{
					OnSave();
				}
				return true;
			}
			return false;
		}
	}
}

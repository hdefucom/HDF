using System;
using System.Windows.Forms;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class A_InsertDocument : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertdocument";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			ET_Document eT_Document = new ET_Document();
			eT_Document.ObjectID = Param1;
			if (eT_Document.isKeyEnable() && myOwnerDocument.DataSource.DBConn.ReadOneRecord(eT_Document))
			{
				using (ZYTextDocument zYTextDocument = new ZYTextDocument())
				{
					myOwnerDocument.BeginContentChangeLog();
					myOwnerDocument.BeginUpdate();
					zYTextDocument.DataSource.DBConn = myOwnerDocument.DataSource.DBConn;
					zYTextDocument.FromXML(eT_Document.GetDataXML().DocumentElement);
					zYTextDocument.DataSource.DBConn = null;
					myOwnerDocument.EndUpdate();
					myOwnerDocument.EndContentChangeLog();
					return true;
				}
			}
			return false;
		}

		public override bool UIExecute()
		{
			using (frmDBFileList frmDBFileList = new frmDBFileList())
			{
				frmDBFileList.DBConn = myOwnerDocument.DataSource.DBConn;
				frmDBFileList.RefreshList();
				if (frmDBFileList.ShowDialog() == DialogResult.OK)
				{
					ET_Document selectedRecord = frmDBFileList.SelectedRecord;
					if (myOwnerDocument.DataSource.DBConn.ReadOneRecord(selectedRecord))
					{
						try
						{
							XmlDocument dataXML = selectedRecord.GetDataXML();
							using (ZYTextDocument zYTextDocument = new ZYTextDocument())
							{
								zYTextDocument.DataSource.DBConn = myOwnerDocument.DataSource.DBConn;
								zYTextDocument.FromXML(dataXML.DocumentElement);
								zYTextDocument.DataSource.DBConn = null;
								return true;
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.ToString());
						}
					}
				}
			}
			return false;
		}
	}
}

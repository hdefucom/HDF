using System;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_OpenDBFile : ZYEditorAction
	{
		public override string ActionName()
		{
			return "opendbfile";
		}

		public override bool isEnable()
		{
			return true;
		}

		public override bool Execute()
		{
			ET_Document eT_Document = new ET_Document();
			myOwnerDocument.StopScript();
			myOwnerDocument.ClearContent();
			if (eT_Document.SetKeyWord(Param1))
			{
				XmlDocument dataXML;
				if (myOwnerDocument.DataSource.DBConn.ReadOneRecord(eT_Document))
				{
					myOwnerDocument.BeginUpdate();
					dataXML = eT_Document.GetDataXML();
					dataXML.PreserveWhitespace = true;
					myOwnerDocument.FromXML(dataXML.DocumentElement);
					myOwnerDocument.Info.ID = eT_Document.ObjectID.ToString();
					myOwnerDocument.Info.Title = eT_Document.ObjectName;
					myOwnerDocument.RefreshSize();
					myOwnerDocument.Content.MoveSelectStart(0);
					myOwnerDocument.ContentChanged();
					myOwnerDocument.Modified = false;
					myOwnerDocument.EndUpdate();
					myOwnerDocument.Refresh();
					return true;
				}
				myOwnerDocument.BeginUpdate();
				dataXML = new XmlDocument();
				dataXML.LoadXml(ZYConfig.NewFileXml);
				dataXML.PreserveWhitespace = true;
				myOwnerDocument.FromXML(dataXML.DocumentElement);
				myOwnerDocument.Info.ID = eT_Document.ObjectID.ToString();
				myOwnerDocument.Info.Title = eT_Document.ObjectName;
				myOwnerDocument.RefreshSize();
				myOwnerDocument.Content.MoveSelectStart(0);
				myOwnerDocument.ContentChanged();
				myOwnerDocument.Modified = false;
				myOwnerDocument.EndUpdate();
				myOwnerDocument.Refresh();
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
							myOwnerDocument.BeginUpdate();
							myOwnerDocument.FromXML(dataXML.DocumentElement);
							myOwnerDocument.Info.ID = selectedRecord.ObjectID.ToString();
							myOwnerDocument.Info.Title = selectedRecord.ObjectName;
							myOwnerDocument.RefreshSize();
							myOwnerDocument.ContentChanged();
							myOwnerDocument.Modified = false;
							myOwnerDocument.EndUpdate();
							myOwnerDocument.Refresh();
							return true;
						}
						catch (Exception ex)
						{
							MessageBox.Show("错误的文件格式\r" + ex.ToString());
						}
					}
				}
			}
			return false;
		}
	}
}

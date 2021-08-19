using System.Data;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_InsertEMRelement : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertemrelement";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			if (myOwnerDocument.DataSource.DBConn.Connection != null && Param1 != "")
			{
				if (MessageBox.Show("插入默认报告内容将会清空当前模板内容,确认插入默认内容吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return false;
				}
				string text = "";
				IDbConnection connection = myOwnerDocument.DataSource.DBConn.Connection;
				IDbCommand dbCommand = connection.CreateCommand();
				dbCommand.CommandText = Param1;
				IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
				if (dataReader.Read())
				{
					text = dataReader.GetString(0);
				}
				dataReader.Close();
				if (text != "")
				{
					string iD = myOwnerDocument.Info.ID;
					string title = myOwnerDocument.Info.Title;
					myOwnerDocument._InsertEMRelement(text);
					myOwnerDocument.Info.ID = iD;
					myOwnerDocument.Info.Title = title;
				}
			}
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertEMRelement a_InsertEMRelement = new A_InsertEMRelement();
			a_InsertEMRelement.BaseCloneFrom(this);
			return a_InsertEMRelement;
		}
	}
}

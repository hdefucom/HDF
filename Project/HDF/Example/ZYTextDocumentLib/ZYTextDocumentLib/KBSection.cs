using System.Collections;
using System.Data;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class KBSection : ZYDBRecordBase
	{
		private string strKBSEQ = "0000000000";

		private string strOwnerSection = "";

		private KB_List myKBList = null;

		private bool bolShowInTree = true;

		public string KBSEQ
		{
			get
			{
				if (myKBList == null)
				{
					return strKBSEQ;
				}
				return myKBList.SEQ;
			}
			set
			{
				strKBSEQ = value;
				if (myKBList != null && myKBList.SEQ != value)
				{
					myKBList = null;
				}
				base.SetModified();
			}
		}

		public string OwnerSection
		{
			get
			{
				return strOwnerSection;
			}
			set
			{
				strOwnerSection = value;
				base.SetModified();
			}
		}

		public bool ShowInTree
		{
			get
			{
				return bolShowInTree;
			}
			set
			{
				bolShowInTree = value;
			}
		}

		public static int GetKBSectionRecords(ArrayList myList, ZYDBConnection myConn, string strSection)
		{
			if (StringCommon.isBlankString(strSection))
			{
				return 0;
			}
			strSection = strSection.Trim();
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				dbCommand.CommandText = "Select KB_SEQ , OwnerSection From KBSection Where OwnerSection =?";
				ZYDBConnection.AddParameter(dbCommand, strSection);
				KBSection myRecord = new KBSection();
				return myConn.ReadRecords(myList, myRecord, dbCommand);
			}
		}

		public static string GetSelectSQL()
		{
			return "Select KB_SEQ , OwnerSection From KBSection ";
		}

		public override ZYDBRecordBase CreateNewRecord()
		{
			return new KBSection();
		}

		public override bool FromReader(IDataReader myReader, ZYDBConnection conn)
		{
			if (myReader.FieldCount == 3)
			{
				strKBSEQ = (myReader.IsDBNull(0) ? null : myReader.GetString(0));
				strOwnerSection = (myReader.IsDBNull(1) ? null : myReader.GetString(1));
				bolShowInTree = (myReader.IsDBNull(2) || myReader.GetString(2) != "0");
				return true;
			}
			if (myReader.FieldCount == 2)
			{
				strKBSEQ = (myReader.IsDBNull(0) ? null : myReader.GetString(0));
				strOwnerSection = (myReader.IsDBNull(1) ? null : myReader.GetString(1));
				return true;
			}
			return false;
		}

		public override string GetTableName()
		{
			return "KBSection";
		}

		public override bool isKeyEnable()
		{
			return true;
		}

		public override bool CustomDelete(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Delete From KBSection Where KB_SEQ =? And OwnerSection=?";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strKBSEQ);
			ZYDBConnection.AddParameter(myCmd, strOwnerSection);
			myCmd.ExecuteNonQuery();
			return true;
		}

		public override bool SetInsertCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Insert Into KBSection ( KB_SEQ , OwnerSection  ) Values(?,?)";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strKBSEQ);
			ZYDBConnection.AddParameter(myCmd, strOwnerSection);
			return true;
		}

		public override bool SetSelectAllCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select KB_SEQ , OwnerSection  From KBSection ";
			return true;
		}

		public override bool SetDeleteCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Delete From KBSection Where KB_SEQ=?";
			ZYDBConnection.AddParameter(myCmd, strKBSEQ);
			return true;
		}

		public override bool SetSelectCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select KB_SEQ , OwnerSection  From KBSection Where OwnerSection = ?";
			ZYDBConnection.AddParameter(myCmd, strOwnerSection);
			return true;
		}
	}
}

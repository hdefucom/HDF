using System.Collections;
using System.Data;

namespace ZYCommon
{
	public abstract class ZYDBRecordBase
	{
		protected bool bolUpdateSuccess = false;

		protected DataRowState intDataState = DataRowState.Added;

		public bool UpdateSuccess
		{
			get
			{
				return bolUpdateSuccess;
			}
			set
			{
				bolUpdateSuccess = value;
			}
		}

		public DataRowState DataState
		{
			get
			{
				return intDataState;
			}
			set
			{
				intDataState = value;
			}
		}

		public static void RemoveDeletedRecord(ArrayList myList, bool CheckSuccess)
		{
			if (myList == null || myList.Count <= 0)
			{
				return;
			}
			for (int num = myList.Count - 1; num >= 0; num--)
			{
				ZYDBRecordBase zYDBRecordBase = (ZYDBRecordBase)myList[num];
				if (zYDBRecordBase.isDeleted() && (!CheckSuccess || zYDBRecordBase.UpdateSuccess))
				{
					myList.RemoveAt(num);
				}
			}
		}

		public static int GetDeletedRecordCount(ArrayList myList)
		{
			int num = 0;
			foreach (ZYDBRecordBase my in myList)
			{
				if (my.isDeleted())
				{
					num++;
				}
			}
			return num;
		}

		public bool isUnchanged()
		{
			return intDataState == DataRowState.Unchanged;
		}

		public bool isNewRecord()
		{
			return intDataState == DataRowState.Added;
		}

		public bool isDeleted()
		{
			return intDataState == DataRowState.Deleted;
		}

		public bool isModified()
		{
			return intDataState == DataRowState.Modified;
		}

		public virtual void SetModified()
		{
			if (intDataState != DataRowState.Added && intDataState != DataRowState.Deleted)
			{
				intDataState = DataRowState.Modified;
			}
		}

		public virtual string GetTableName()
		{
			return null;
		}

		public virtual bool SetKeyWord(string strKey)
		{
			return false;
		}

		public virtual bool isKeyEnable()
		{
			return false;
		}

		public virtual bool FromReader(IDataReader myReader, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetAllocKeyCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			if (myCmd != null && GetTableName() != null)
			{
				myCmd.CommandText = "Select Max(RecordSEQ) From SEQTable Where TableName = '" + GetTableName() + "'";
				myCmd.Parameters.Clear();
				return true;
			}
			return false;
		}

		public virtual bool SetSelectCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetSelectAllCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetSelectCommandForOneRecord(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetInsertCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetUpdateCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetDeleteCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool CustomDelete(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual bool SetTestExistCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			return false;
		}

		public virtual ZYDBRecordBase CreateNewRecord()
		{
			return null;
		}
	}
}

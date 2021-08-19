using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ZYCommon
{
	public class ZYDBConnection : IDisposable
	{
		protected IDbConnection myConn = null;

		private int intLastTick = 0;

		private int intIdleTimeOut = 0;

		private bool bolAutoOpen = true;

		private bool bolAutoClose = false;

		private bool bolAlertDelete = false;

		private bool bolCanUpdate = true;

		private bool bolCancelFlag = false;

		public EventHandler OnOpen = null;

		public EventHandler OnClose = null;

		private static ZYDBConnection myStaticConn = null;

		public bool CancelFlag
		{
			get
			{
				return bolCancelFlag;
			}
			set
			{
				bolCancelFlag = value;
				if (this.OnCancelFlagChanged != null)
				{
					this.OnCancelFlagChanged(this, null);
				}
			}
		}

		public bool CanRead => myConn != null;

		public bool CanUpdate
		{
			get
			{
				return bolCanUpdate;
			}
			set
			{
				bolCanUpdate = value;
			}
		}

		public bool AlertDelete
		{
			get
			{
				return bolAlertDelete;
			}
			set
			{
				bolAlertDelete = value;
			}
		}

		public bool AutoOpen
		{
			get
			{
				return bolAutoOpen;
			}
			set
			{
				bolAutoOpen = value;
			}
		}

		public bool AutoClose
		{
			get
			{
				return bolAutoClose;
			}
			set
			{
				bolAutoClose = value;
			}
		}

		public static ZYDBConnection Instance
		{
			get
			{
				if (myStaticConn == null)
				{
					myStaticConn = new ZYDBConnection();
				}
				return myStaticConn;
			}
			set
			{
				myStaticConn = value;
			}
		}

		public int IdleTimeOut
		{
			get
			{
				return intIdleTimeOut;
			}
			set
			{
				intIdleTimeOut = value;
			}
		}

		public IDbConnection Connection
		{
			get
			{
				return myConn;
			}
			set
			{
				myConn = value;
			}
		}

		public string ConnectionString
		{
			get
			{
				return myConn.ConnectionString;
			}
			set
			{
				myConn.ConnectionString = value;
			}
		}

		public bool IsSQLServer
		{
			get
			{
				if (myConn != null)
				{
					if (myConn is SqlConnection)
					{
						return true;
					}
					if (myConn is OleDbConnection)
					{
						string provider = (myConn as OleDbConnection).Provider;
						return provider.StartsWith("SQLOLEDB");
					}
				}
				return false;
			}
		}

		public bool IsOracle
		{
			get
			{
				if (myConn != null && myConn is OleDbConnection)
				{
					string provider = (myConn as OleDbConnection).Provider;
					return provider.StartsWith("OraOLEDB.Oracle") || provider.StartsWith("MSDAORA");
				}
				return false;
			}
		}

		public bool IsJet40
		{
			get
			{
				if (myConn != null && myConn is OleDbConnection)
				{
					string provider = (myConn as OleDbConnection).Provider;
					return provider.ToUpper() == "MICROSOFT.JET.OLEDB.4.0";
				}
				return false;
			}
		}

		public event EventHandler OnCancelFlagChanged = null;

		public bool TestIdleTimeOut()
		{
			if (intIdleTimeOut > 0 && intLastTick > 0 && Environment.TickCount - intLastTick > intIdleTimeOut && isOpened())
			{
				intLastTick = Environment.TickCount;
				myConn.Close();
				return true;
			}
			return false;
		}

		public void Dispose()
		{
			if (myConn != null)
			{
				AutoOpen = false;
				Close();
				myConn.Dispose();
			}
		}

		public void ExecuteCompleted()
		{
			if (bolAutoClose)
			{
				Close();
			}
		}

		public void Open()
		{
			if (OnOpen != null)
			{
				OnOpen(this, null);
			}
			if (myConn.State != ConnectionState.Open)
			{
				myConn.Open();
			}
		}

		public void Close()
		{
			if (OnClose != null)
			{
				OnClose(this, null);
			}
			if (myConn != null && myConn.State == ConnectionState.Open)
			{
				myConn.Close();
			}
		}

		public bool isOpened()
		{
			if (CancelFlag)
			{
				return false;
			}
			if (OnOpen != null)
			{
				OnOpen(this, null);
			}
			if (myConn == null)
			{
				return false;
			}
			if (myConn.State != ConnectionState.Open)
			{
				if (bolAutoOpen)
				{
					if (myConn.State == ConnectionState.Connecting)
					{
						using (dlgWaiting dlgWaiting = new dlgWaiting())
						{
							dlgWaiting.TopMost = true;
							dlgWaiting.Show();
							dlgWaiting.ShowCancelButton = true;
							while (myConn.State == ConnectionState.Connecting)
							{
								Application.DoEvents();
								if (dlgWaiting.DialogResult == DialogResult.Cancel)
								{
									return false;
								}
							}
							dlgWaiting.Close();
						}
					}
					else
					{
						myConn.Open();
					}
					return true;
				}
				return false;
			}
			return true;
		}

		public IDbCommand CreateCommand()
		{
			if (isOpened())
			{
				return myConn.CreateCommand();
			}
			return null;
		}

		public DbDataAdapter CreateAdapter()
		{
			if (isOpened())
			{
				if (myConn is SqlConnection)
				{
					return new SqlDataAdapter();
				}
				if (myConn is OleDbConnection)
				{
					return new OleDbDataAdapter();
				}
			}
			return null;
		}

		public static IDbDataParameter AddParameter(IDbCommand myCmd, object objValue)
		{
			if (myCmd != null)
			{
				if (myCmd is SqlCommand)
				{
					int count = myCmd.Parameters.Count;
					int num = myCmd.CommandText.IndexOf("?");
					myCmd.CommandText = myCmd.CommandText.Substring(0, num) + " @value" + count + myCmd.CommandText.Substring(num + 1);
					SqlParameter sqlParameter = new SqlParameter("@value" + count, objValue);
					myCmd.Parameters.Add(sqlParameter);
					return sqlParameter;
				}
				IDbDataParameter dbDataParameter = myCmd.CreateParameter();
				if (dbDataParameter != null)
				{
					dbDataParameter.Value = objValue;
					myCmd.Parameters.Add(dbDataParameter);
					return dbDataParameter;
				}
			}
			return null;
		}

		private void FixParameterValue(IDataParameterCollection myPs)
		{
			if (myPs != null)
			{
				foreach (IDataParameter myP in myPs)
				{
					if (myP.Value is string && StringCommon.isBlankString((string)myP.Value))
					{
						myP.Value = " ";
					}
				}
			}
		}

		public ArrayList ReadRecords(ZYDBRecordBase myRecord)
		{
			ArrayList arrayList = new ArrayList();
			if (ReadRecords(arrayList, myRecord) >= 0)
			{
				return arrayList;
			}
			return null;
		}

		public int ReadRecords(ArrayList myList, ZYDBRecordBase myRecord)
		{
			if (myList != null && myRecord != null && isOpened())
			{
				using (IDbCommand dbCommand = CreateCommand())
				{
					intLastTick = Environment.TickCount;
					if (myRecord.SetSelectCommand(dbCommand, this))
					{
						ZYErrorReport.Instance.DebugPrint("查询数据：SQL语句:" + dbCommand.CommandText);
						IDataReader dataReader = dbCommand.ExecuteReader();
						int num = ReadRecordsFromReader(myList, myRecord, dataReader);
						ZYErrorReport.Instance.DebugPrint("供查询 " + num + " 条记录");
						dataReader.Close();
						ExecuteCompleted();
						return num;
					}
				}
			}
			return -1;
		}

		public ArrayList ReadRecords(ZYDBRecordBase myRecord, string strSQL)
		{
			ArrayList arrayList = new ArrayList();
			if (ReadRecords(arrayList, myRecord, strSQL) >= 0)
			{
				return arrayList;
			}
			return null;
		}

		public ArrayList ReadRecords(ZYDBRecordBase myRecord, IDbCommand myCmd)
		{
			ArrayList arrayList = new ArrayList();
			if (ReadRecords(arrayList, myRecord, myCmd) >= 0)
			{
				return arrayList;
			}
			return null;
		}

		public int ReadRecords(ArrayList myList, ZYDBRecordBase myRecord, string strSQL)
		{
			if (myList != null && myRecord != null && isOpened())
			{
				using (IDbCommand dbCommand = CreateCommand())
				{
					intLastTick = Environment.TickCount;
					dbCommand.CommandText = strSQL;
					IDataReader dataReader = dbCommand.ExecuteReader();
					int result = ReadRecordsFromReader(myList, myRecord, dataReader);
					dataReader.Close();
					ExecuteCompleted();
					return result;
				}
			}
			return -1;
		}

		public int ReadRecords(ArrayList myList, ZYDBRecordBase myRecord, IDbCommand myCmd)
		{
			if (myList != null && myRecord != null && myCmd != null)
			{
				ZYErrorReport.Instance.DebugPrint("读取数据" + myCmd.CommandText);
				intLastTick = Environment.TickCount;
				IDataReader dataReader = myCmd.ExecuteReader();
				ZYErrorReport.Instance.DebugPrint("myList=" + myList);
				ZYErrorReport.Instance.DebugPrint("myRecord=" + myRecord);
				ZYErrorReport.Instance.DebugPrint("myReader=" + dataReader);
				if (dataReader == null)
				{
					return -1;
				}
				int num = ReadRecordsFromReader(myList, myRecord, dataReader);
				ZYErrorReport.Instance.DebugPrint("共读取" + num + "条记录");
				dataReader.Close();
				return num;
			}
			return -1;
		}

		public int ReadRecordsFromReader(ArrayList myList, ZYDBRecordBase myRecord, IDataReader myReader)
		{
			if (myList != null && myRecord != null && myReader != null)
			{
				int num = 0;
				while (myReader.Read())
				{
					ZYDBRecordBase zYDBRecordBase = myRecord.CreateNewRecord();
					if (!zYDBRecordBase.FromReader(myReader, this))
					{
						break;
					}
					zYDBRecordBase.DataState = DataRowState.Unchanged;
					myList.Add(zYDBRecordBase);
					num++;
				}
				return num;
			}
			return -1;
		}

		public ArrayList ReadAllRecords(ZYDBRecordBase myRecord)
		{
			ArrayList arrayList = new ArrayList();
			if (ReadAllRecords(arrayList, myRecord) >= 0)
			{
				return arrayList;
			}
			return null;
		}

		public int ReadAllRecords(ArrayList myList, ZYDBRecordBase myRecord)
		{
			if (myList != null && myRecord != null && isOpened())
			{
				using (IDbCommand dbCommand = CreateCommand())
				{
					intLastTick = Environment.TickCount;
					if (myRecord.SetSelectAllCommand(dbCommand, this))
					{
						IDataReader dataReader = dbCommand.ExecuteReader();
						if (dataReader != null)
						{
							int result = ReadRecordsFromReader(myList, myRecord, dataReader);
							dataReader.Close();
							ExecuteCompleted();
							return result;
						}
					}
				}
			}
			return -1;
		}

		public bool ReadOneRecord(ZYDBRecordBase myRecord)
		{
			return ExecuteOneRecord(myRecord, 0);
		}

		public bool DeleteRecord(ZYDBRecordBase myRecord)
		{
			return ExecuteOneRecord(myRecord, 1);
		}

		public bool UpdateRecord(ZYDBRecordBase myRecord)
		{
			return ExecuteOneRecord(myRecord, 2);
		}

		public bool NewRecord(ZYDBRecordBase myRecord)
		{
			return ExecuteOneRecord(myRecord, 3);
		}

		public bool TestRecordExist(ZYDBRecordBase myRecord)
		{
			return ExecuteOneRecord(myRecord, 4);
		}

		protected bool ExecuteOneRecord(ZYDBRecordBase myRecord, int intType)
		{
			bool result = false;
			if (myRecord != null && isOpened())
			{
				using (IDbCommand dbCommand = CreateCommand())
				{
					intLastTick = Environment.TickCount;
					switch (intType)
					{
					case 0:
						if (myRecord.SetSelectCommandForOneRecord(dbCommand, this))
						{
							try
							{
								IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
								if (dataReader.Read() && myRecord.FromReader(dataReader, this))
								{
									result = true;
									myRecord.DataState = DataRowState.Unchanged;
								}
								dataReader.Close();
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
						break;
					case 1:
						if (myRecord.isKeyEnable() && myRecord.SetDeleteCommand(dbCommand, this))
						{
							dbCommand.ExecuteNonQuery();
							result = true;
						}
						break;
					case 2:
						if (myRecord.SetUpdateCommnad(dbCommand, this))
						{
							dbCommand.ExecuteNonQuery();
							myRecord.DataState = DataRowState.Unchanged;
							result = true;
						}
						break;
					case 3:
						if (myRecord.SetInsertCommnad(dbCommand, this))
						{
							dbCommand.ExecuteNonQuery();
							myRecord.DataState = DataRowState.Unchanged;
							result = true;
						}
						break;
					case 4:
						if (myRecord.SetTestExistCommand(dbCommand, this))
						{
							IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
							result = dataReader.Read();
							dataReader.Close();
						}
						break;
					}
				}
				ExecuteCompleted();
			}
			return result;
		}

		public bool UpdateRecordAuto(ZYDBRecordBase myRecord)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(myRecord);
			return UpdateRecords(arrayList, null) == 1;
		}

		public int UpdateRecords(ArrayList myList, ProgressHandler vProgress)
		{
			int num = -1;
			if (myList != null && isOpened())
			{
				if (bolAlertDelete)
				{
					foreach (ZYDBRecordBase my in myList)
					{
						my.UpdateSuccess = false;
					}
				}
				using (IDbCommand dbCommand = CreateCommand())
				{
					num = 0;
					for (int i = 0; i < myList.Count; i++)
					{
						vProgress?.Invoke(i, myList.Count);
						ZYDBRecordBase zYDBRecordBase2 = (ZYDBRecordBase)myList[i];
						dbCommand.Parameters.Clear();
						switch (zYDBRecordBase2.DataState)
						{
						case DataRowState.Added:
							if (!zYDBRecordBase2.isKeyEnable() && zYDBRecordBase2.SetAllocKeyCommand(dbCommand, this) && !zYDBRecordBase2.isKeyEnable())
							{
								IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
								if (dataReader.Read())
								{
									string keyWord = dataReader.IsDBNull(0) ? null : dataReader[0].ToString();
									zYDBRecordBase2.SetKeyWord(keyWord);
								}
								dataReader.Close();
							}
							if (zYDBRecordBase2.isKeyEnable() && zYDBRecordBase2.SetInsertCommnad(dbCommand, this))
							{
								FixParameterValue(dbCommand.Parameters);
								dbCommand.ExecuteNonQuery();
								zYDBRecordBase2.DataState = DataRowState.Unchanged;
								num++;
							}
							break;
						case DataRowState.Deleted:
							if (zYDBRecordBase2.CustomDelete(dbCommand, this))
							{
								myList.Remove(zYDBRecordBase2);
								i--;
								num++;
							}
							else
							{
								dbCommand.Parameters.Clear();
								if (zYDBRecordBase2.isKeyEnable() && zYDBRecordBase2.SetDeleteCommand(dbCommand, this))
								{
									dbCommand.ExecuteNonQuery();
									myList.Remove(zYDBRecordBase2);
									i--;
									num++;
								}
							}
							break;
						case DataRowState.Modified:
							if (zYDBRecordBase2.SetUpdateCommnad(dbCommand, this))
							{
								FixParameterValue(dbCommand.Parameters);
								dbCommand.ExecuteNonQuery();
								zYDBRecordBase2.DataState = DataRowState.Unchanged;
								num++;
							}
							break;
						}
						zYDBRecordBase2.UpdateSuccess = true;
					}
				}
				ExecuteCompleted();
			}
			return num;
		}

		public string[] GetValueList(string strSQL)
		{
			return GetValueList(strSQL, OnlyFirstField: false, OnlyFirstRecord: false);
		}

		public string[] GetValueList(string strSQL, bool OnlyFirstField, bool OnlyFirstRecord)
		{
			if (StringCommon.isBlankString(strSQL) || !isOpened())
			{
				return null;
			}
			string[] result = null;
			using (IDbCommand dbCommand = CreateCommand())
			{
				dbCommand.CommandText = strSQL;
				result = GetValueList(dbCommand, OnlyFirstField, OnlyFirstRecord);
			}
			ExecuteCompleted();
			return result;
		}

		public static string[] GetValueList(IDbCommand cmd, bool OnlyFirstField, bool OnlyFirstRecord)
		{
			ArrayList arrayList = new ArrayList();
			IDataReader dataReader = (!OnlyFirstRecord) ? cmd.ExecuteReader(CommandBehavior.SingleResult) : cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
			while (dataReader.Read())
			{
				if (OnlyFirstField || dataReader.FieldCount == 1)
				{
					arrayList.Add(dataReader.IsDBNull(0) ? null : dataReader[0].ToString());
				}
				else
				{
					for (int i = 0; i < dataReader.FieldCount; i++)
					{
						arrayList.Add(dataReader.IsDBNull(i) ? null : dataReader[i].ToString());
					}
				}
				if (OnlyFirstRecord)
				{
					break;
				}
			}
			dataReader.Close();
			return (string[])arrayList.ToArray(typeof(string));
		}

		public string GetSingleValue(string strSQL)
		{
			if (StringCommon.HasContent(strSQL) && isOpened())
			{
				using (IDbCommand dbCommand = CreateCommand())
				{
					dbCommand.CommandText = strSQL;
					return GetSingleValue(dbCommand);
				}
			}
			return null;
		}

		public static string GetSingleValue(IDbCommand myCmd)
		{
			if (myCmd != null)
			{
				IDataReader dataReader = myCmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
				string result = null;
				if (dataReader.Read() && !dataReader.IsDBNull(0))
				{
					result = dataReader[0].ToString();
				}
				dataReader.Close();
				return result;
			}
			return null;
		}

		public static int[] GetInt32ValueList(IDbCommand myCmd)
		{
			if (myCmd != null)
			{
				Int32Buffer int32Buffer = new Int32Buffer();
				IDataReader dataReader = myCmd.ExecuteReader(CommandBehavior.SingleResult);
				while (dataReader.Read())
				{
					int32Buffer.Append(Convert.ToInt32(dataReader[0]));
				}
				dataReader.Close();
				return int32Buffer.ToArray();
			}
			return null;
		}
	}
}

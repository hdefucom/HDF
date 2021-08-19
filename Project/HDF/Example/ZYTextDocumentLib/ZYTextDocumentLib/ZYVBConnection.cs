using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYVBConnection
	{
		private class DBListItem
		{
			public string ItemName;

			public string ItemValue;
		}

		private Hashtable myListTable = new Hashtable();

		private ZYDBConnection myDBConn = null;

		public ZYVBConnection(ZYDBConnection conn)
		{
			myDBConn = conn;
		}

		public bool BuildListItem(string strName, string strSQL)
		{
			try
			{
				using (IDbCommand dbCommand = myDBConn.CreateCommand())
				{
					ArrayList arrayList = new ArrayList();
					dbCommand.CommandText = strSQL;
					IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
					if (dataReader.FieldCount >= 2)
					{
						while (dataReader.Read())
						{
							DBListItem dBListItem = new DBListItem();
							dBListItem.ItemName = (dataReader.IsDBNull(0) ? null : dataReader[0].ToString());
							dBListItem.ItemValue = (dataReader.IsDBNull(1) ? null : dataReader[1].ToString());
							arrayList.Add(dBListItem);
						}
					}
					dataReader.Close();
					myListTable.Add(strName, arrayList);
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("加载列表错误" + ex.ToString());
			}
			return false;
		}

		public string GetListItemValue(string strName, string strCode)
		{
			ArrayList arrayList = myListTable[strName] as ArrayList;
			if (arrayList != null)
			{
				foreach (DBListItem item in arrayList)
				{
					if (item.ItemName == strName)
					{
						return item.ItemValue;
					}
				}
			}
			return null;
		}

		public string[] GetFirstFieldValues(string strSQL)
		{
			return myDBConn.GetValueList(strSQL, OnlyFirstField: true, OnlyFirstRecord: false);
		}

		public string[] GetFirstRecordValue(string strSQL)
		{
			return myDBConn.GetValueList(strSQL, OnlyFirstField: false, OnlyFirstRecord: true);
		}

		public string GetSingleValue(string strSQL)
		{
			return myDBConn.GetSingleValue(strSQL);
		}
	}
}

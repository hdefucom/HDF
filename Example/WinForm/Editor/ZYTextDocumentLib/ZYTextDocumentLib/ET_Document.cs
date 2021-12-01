using System;
using System.Data;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ET_Document : ZYDBRecordBase
	{
		private string strObjectID = null;

		private string strObjectName = " ";

		private int intObjectType = -1;

		private string strOwnerSection = " ";

		public string strObjectData = " ";

		public static string strDeptment = " ";

		public string KeyPreFix = "000";

		public string ObjectID
		{
			get
			{
				return strObjectID;
			}
			set
			{
				strObjectID = value;
			}
		}

		public string ObjectName
		{
			get
			{
				return strObjectName;
			}
			set
			{
				strObjectName = value;
			}
		}

		public int ObjectType
		{
			get
			{
				return intObjectType;
			}
			set
			{
				intObjectType = value;
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
			}
		}

		public string ObjectData
		{
			get
			{
				return strObjectData;
			}
			set
			{
				strObjectData = value;
			}
		}

		public XmlDocument GetDataXML()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			xmlDocument.LoadXml(strObjectData);
			return xmlDocument;
		}

		public ZYTextDocument LoadDocument(ZYDBConnection conn)
		{
			if (conn == null)
			{
				conn = ZYDBConnection.Instance;
			}
			if (conn.ReadOneRecord(this))
			{
				ZYTextDocument zYTextDocument = new ZYTextDocument();
				zYTextDocument.DataSource.DBConn = conn;
				zYTextDocument.FromXML(GetDataXML().DocumentElement);
				return zYTextDocument;
			}
			return null;
		}

		public static void SetSelectSEQCommand(IDbCommand myCmd)
		{
			myCmd.CommandText = "Select ObjectID From ET_Document Order by ObjectID";
		}

		public static string GetSelectSQL()
		{
			return "Select ObjectID , ObjectName , ObjectType , OwnerSection , ObjectData From ET_Document ";
		}

		public override ZYDBRecordBase CreateNewRecord()
		{
			return new ET_Document();
		}

		public override bool FromReader(IDataReader myReader, ZYDBConnection conn)
		{
			if (myReader != null && (myReader.FieldCount == 4 || myReader.FieldCount == 5))
			{
				strObjectID = (myReader.IsDBNull(0) ? null : myReader.GetString(0));
				strObjectName = (myReader.IsDBNull(1) ? " " : myReader.GetString(1));
				intObjectType = (myReader.IsDBNull(2) ? (-1) : Convert.ToInt32(myReader[2]));
				strOwnerSection = (myReader.IsDBNull(3) ? " " : myReader.GetString(3));
				if (myReader.FieldCount == 5)
				{
					strObjectData = (myReader.IsDBNull(4) ? " " : myReader.GetString(4));
				}
				return true;
			}
			return false;
		}

		public override string GetTableName()
		{
			return "ET_Document";
		}

		public override bool isKeyEnable()
		{
			return strObjectID != null && strObjectID.Length == 12;
		}

		public override bool SetDeleteCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Delete From ET_Document Where ObjectID = " + strObjectID;
			return true;
		}

		public override bool SetInsertCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Insert Into ET_Document ( objectid, ObjectName , ObjectType , OwnerSection , ObjectData ) Values ( ? , ? , ? ,? , ?)";
			ZYDBConnection.AddParameter(myCmd, strObjectID);
			ZYDBConnection.AddParameter(myCmd, strObjectName);
			ZYDBConnection.AddParameter(myCmd, intObjectType);
			ZYDBConnection.AddParameter(myCmd, strDeptment);
			ZYDBConnection.AddParameter(myCmd, strObjectData);
			return true;
		}

		public override bool SetKeyWord(string strKey)
		{
			strObjectID = strKey;
			return true;
		}

		public override bool SetSelectCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select ObjectID , ObjectName , ObjectType , OwnerSection  From ET_Document Order by ObjectName ";
			return true;
		}

		public override bool SetSelectCommandForOneRecord(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select ObjectID , ObjectName , ObjectType , OwnerSection , ObjectData From ET_Document Where ObjectID = ? ";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strObjectID);
			return true;
		}

		public override bool SetAllocKeyCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			SEQCreator sEQCreator = new SEQCreator();
			sEQCreator.FixLength = 12;
			myCmd.CommandText = "Select Max( objectid )  From ET_Document Where OWNERSECTION='" + strDeptment + "'";
			IDataReader dataReader = myCmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
			if (dataReader.Read() && !dataReader.IsDBNull(0))
			{
				sEQCreator.SEQ = dataReader.GetString(0);
			}
			else
			{
				sEQCreator.SEQ = KeyPreFix + "0000000";
			}
			dataReader.Close();
			strObjectID = sEQCreator.Create();
			return true;
		}

		public override bool SetTestExistCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "select objectid from et_Document Where objectid = '" + strObjectID + "'";
			return true;
		}

		public override bool SetUpdateCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Update ET_Document Set ObjectName = ? , ObjectType = ?  , ObjectData = ?  Where ObjectID = ? ";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strObjectName);
			ZYDBConnection.AddParameter(myCmd, intObjectType);
			ZYDBConnection.AddParameter(myCmd, strObjectData);
			ZYDBConnection.AddParameter(myCmd, strObjectID);
			return true;
		}
	}
}

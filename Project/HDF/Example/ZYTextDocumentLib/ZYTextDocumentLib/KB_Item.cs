using System;
using System.Data;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class KB_Item : ZYDBRecordBase, IListIndex
	{
		private int intItemSEQ = -1;

		private string strKBSEQ = null;

		private string strItemText = " ";

		private string strItemValue = " ";

		private string strItemDesc = " ";

		private int intListIndex = 0;

		private int intItemStyle = 0;

		private KB_List myOwnerList = null;

		public static string strDeptment = " ";

		private static string[] strKBItemStyleDesc = null;

		public int ItemSEQ
		{
			get
			{
				return intItemSEQ;
			}
			set
			{
				intItemSEQ = value;
			}
		}

		public string KBSEQ
		{
			get
			{
				if (myOwnerList == null)
				{
					return strKBSEQ;
				}
				return myOwnerList.SEQ;
			}
			set
			{
				strKBSEQ = value;
				base.SetModified();
			}
		}

		public string ItemText
		{
			get
			{
				return strItemText;
			}
			set
			{
				if (strItemText != value && value != null)
				{
					if (strItemText == strItemValue)
					{
						strItemValue = value;
					}
					strItemText = value;
					base.SetModified();
				}
			}
		}

		public string ItemValue
		{
			get
			{
				return strItemValue;
			}
			set
			{
				if (strItemValue != value && value != null)
				{
					strItemValue = value;
					base.SetModified();
				}
			}
		}

		public string ItemDesc
		{
			get
			{
				return strItemDesc;
			}
			set
			{
				if (strItemDesc != value && value != null)
				{
					strItemDesc = value;
					base.SetModified();
				}
			}
		}

		public int ListIndex
		{
			get
			{
				return intListIndex;
			}
			set
			{
				if (intListIndex != value)
				{
					intListIndex = value;
					base.SetModified();
				}
			}
		}

		public int ItemStyle
		{
			get
			{
				return intItemStyle;
			}
			set
			{
				if (intItemStyle != value)
				{
					intItemStyle = value;
					base.SetModified();
				}
			}
		}

		public KB_List OwnerList
		{
			get
			{
				return myOwnerList;
			}
			set
			{
				myOwnerList = value;
			}
		}

		public static bool CheckItemText(string strText)
		{
			if (strText == null)
			{
				return false;
			}
			strText = strText.Trim();
			if (strText.Length == 0 || strText.Length > 100)
			{
				return false;
			}
			return true;
		}

		public bool FromXML(XmlElement myElement)
		{
			intItemSEQ = Convert.ToInt32(myElement.GetAttribute("seq"));
			strKBSEQ = myElement.GetAttribute("kb");
			strItemText = myElement.GetAttribute("text");
			strItemValue = myElement.GetAttribute("value");
			strItemDesc = myElement.GetAttribute("desc");
			intListIndex = Convert.ToInt32(myElement.GetAttribute("index"));
			intItemStyle = Convert.ToInt32(myElement.GetAttribute("style"));
			if (intItemStyle < 0)
			{
				intItemStyle = 0;
			}
			return true;
		}

		public bool ToXML(XmlElement myElement)
		{
			myElement.SetAttribute("seq", intItemSEQ.ToString());
			myElement.SetAttribute("kb", strKBSEQ);
			myElement.SetAttribute("text", strItemText);
			myElement.SetAttribute("value", strItemValue);
			myElement.SetAttribute("desc", strItemDesc);
			myElement.SetAttribute("index", intListIndex.ToString());
			myElement.SetAttribute("style", intItemStyle.ToString());
			return true;
		}

		public bool isNormalItem()
		{
			return intItemStyle <= 1;
		}

		public bool isSystemItem()
		{
			return intItemStyle >= 11 && intItemStyle <= 19;
		}

		public bool isTemplate()
		{
			return intItemStyle == 100;
		}

		public bool isLink()
		{
			return intItemStyle == 101;
		}

		public bool isCreated()
		{
			return intItemStyle == 1;
		}

		public bool isUnit()
		{
			return intItemStyle == 102;
		}

		public static string[] GetKBItemStyleDescList()
		{
			if (strKBItemStyleDesc == null)
			{
				strKBItemStyleDesc = "普通列表项目,模板,文本框单位".Split(",".ToCharArray());
			}
			return strKBItemStyleDesc;
		}

		public static int KBItemStyleToIndex(int Style)
		{
			switch (Style)
			{
			case -1:
				return 0;
			case 0:
				return 0;
			case 100:
				return 1;
			case 102:
				return 2;
			default:
				return -1;
			}
		}

		public static int IndexToKBItemStyle(int index)
		{
			if (index < 0)
			{
				index = 0;
			}
			switch (index)
			{
			case 0:
				return 0;
			case 1:
				return 100;
			case 2:
				return 102;
			default:
				return 0;
			}
		}

		public static string KBItemStyleToDesc(int Style)
		{
			string[] kBItemStyleDescList = GetKBItemStyleDescList();
			int num = KBItemStyleToIndex(Style);
			if (num >= 0 && num < kBItemStyleDescList.Length)
			{
				return kBItemStyleDescList[num];
			}
			return "未知类型" + Style;
		}

		public static string GetSelectSQL()
		{
			return "Select ITEM_SEQ, KB_SEQ,ITEM_TEXT,ITEM_VALUE,ITEM_DESC ,ListIndex , Item_Style,OWNERSECTION FROM KB_ITEM ";
		}

		public static void SetSelectAllCommandWidthSection(IDbCommand myCmd, string strSection)
		{
			myCmd.CommandText = "Select KB_ITEM.ITEM_SEQ, KB_ITEM.KB_SEQ,KB_ITEM.ITEM_TEXT,KB_ITEM.ITEM_VALUE,KB_ITEM.ITEM_DESC ,KB_ITEM.ListIndex , KB_ITEM.Item_Style FROM KB_ITEM , KBSection where kb_item.kb_seq = kbsection.kb_seq and kbsection.ownersection = ? Order By kb_item.KB_SEQ , kb_item.ListIndex ";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strSection);
		}

		public static void SetSelectSEQCommand(IDbCommand myCmd)
		{
			myCmd.CommandText = "Select ITEM_SEQ From KB_Item Order by ITEM_SEQ ";
		}

		public override string GetTableName()
		{
			return "KB_ITEM";
		}

		public override ZYDBRecordBase CreateNewRecord()
		{
			return new KB_Item();
		}

		public override bool FromReader(IDataReader myReader, ZYDBConnection conn)
		{
			if (myReader != null && myReader.FieldCount == 8)
			{
				intItemSEQ = Convert.ToInt32(myReader[0]);
				strKBSEQ = (myReader.IsDBNull(1) ? null : myReader.GetString(1));
				strItemText = (myReader.IsDBNull(2) ? " " : myReader.GetString(2));
				strItemValue = (myReader.IsDBNull(3) ? " " : myReader.GetString(3));
				strItemDesc = (myReader.IsDBNull(4) ? " " : myReader.GetString(4));
				intListIndex = (myReader.IsDBNull(5) ? (-1) : Convert.ToInt32(myReader[5]));
				intItemStyle = ((!myReader.IsDBNull(6)) ? Convert.ToInt32(myReader[6]) : 0);
				if (intItemStyle < 0)
				{
					intItemStyle = 0;
				}
				return true;
			}
			return false;
		}

		public override bool isKeyEnable()
		{
			return intItemSEQ >= 0;
		}

		public override bool SetAllocKeyCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = " Select Max(ITEM_SEQ)+1 FROM KB_ITEM";
			return true;
		}

		public override bool SetDeleteCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Delete From KB_Item Where ITEM_SEQ = " + intItemSEQ;
			return true;
		}

		public override bool SetInsertCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Insert Into KB_Item ( KB_SEQ,ITEM_TEXT,ITEM_VALUE,ITEM_DESC,ListIndex,Item_Style,OWNERSECTION) VALUES(?,?,?,?,?,?,?)";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, KBSEQ);
			ZYDBConnection.AddParameter(myCmd, strItemText);
			ZYDBConnection.AddParameter(myCmd, strItemValue);
			ZYDBConnection.AddParameter(myCmd, strItemDesc);
			ZYDBConnection.AddParameter(myCmd, intListIndex);
			ZYDBConnection.AddParameter(myCmd, intItemStyle);
			ZYDBConnection.AddParameter(myCmd, strDeptment);
			return true;
		}

		public override bool SetKeyWord(string strKey)
		{
			try
			{
				intItemSEQ = Convert.ToInt32(strKey);
				return true;
			}
			catch
			{
			}
			return false;
		}

		public override bool CustomDelete(IDbCommand myCmd, ZYDBConnection conn)
		{
			if (isTemplate() && StringCommon.IsInteger(strItemValue))
			{
				myCmd.CommandText = "Delete From ET_Document Where ObjectID = '" + strItemValue + "'";
				myCmd.ExecuteNonQuery();
			}
			myCmd.CommandText = "Delete From KB_Item Where ITEM_SEQ = " + intItemSEQ;
			myCmd.ExecuteNonQuery();
			return true;
		}

		public override bool SetSelectAllCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select ITEM_SEQ, KB_SEQ,ITEM_TEXT,ITEM_VALUE,ITEM_DESC ,ListIndex , Item_Style FROM KB_ITEM Order By KB_SEQ , ListIndex ";
			return true;
		}

		public override bool SetSelectCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select ITEM_SEQ, KB_SEQ,ITEM_TEXT,ITEM_VALUE,ITEM_DESC ,ListIndex , Item_Style FROM KB_ITEM Where KB_SEQ = " + strKBSEQ.ToString() + " Order By ListIndex ";
			return true;
		}

		public override bool SetSelectCommandForOneRecord(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select ITEM_SEQ, KB_SEQ,ITEM_TEXT,ITEM_VALUE,ITEM_DESC , ListIndex , Item_Style FROM KB_ITEM Where Item_seq = " + intItemSEQ;
			return true;
		}

		public override bool SetTestExistCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select Item_seq From KB_ITEM WHERE ITEM_SEQ =" + intItemSEQ;
			return true;
		}

		public override bool SetUpdateCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Update KB_ITEM SET KB_SEQ = ? , ITEM_TEXT = ? , ITEM_VALUE = ? , ITEM_DESC=? , ListIndex = ? , Item_Style = ? WHERE ITEM_SEQ= " + intItemSEQ;
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, KBSEQ);
			ZYDBConnection.AddParameter(myCmd, strItemText);
			ZYDBConnection.AddParameter(myCmd, strItemValue);
			ZYDBConnection.AddParameter(myCmd, strItemDesc);
			ZYDBConnection.AddParameter(myCmd, intListIndex);
			ZYDBConnection.AddParameter(myCmd, intItemStyle);
			return true;
		}
	}
}

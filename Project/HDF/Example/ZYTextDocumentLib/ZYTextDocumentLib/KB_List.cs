using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class KB_List : ZYDBRecordBase, IListIndex
	{
		public static string strDeptment;

		public int RefCount = 0;

		public string ChineseSpell = null;

		private string strSEQ = null;

		private string strParent = null;

		private string strName = " ";

		private string strDesc = " ";

		private int intListIndex = 0;

		private string strListSQL = " ";

		private int intKBStyle = 0;

		private string strOwnerSection = "";

		private string strKBGroup = "";

		private string strFullPath = null;

		private bool bolShowInTree = true;

		private KB_List myParent = null;

		public bool Visible = true;

		public static NameValueList Variables;

		private ArrayList myItems = null;

		private ArrayList myChildNodes = null;

		public bool HasLaunchSystemItems = false;

		public bool InputBoxAttribute
		{
			get
			{
				return CommonFunction.GetIntAttribute(intKBStyle, 1);
			}
			set
			{
				intKBStyle = CommonFunction.SetIntAttribute(intKBStyle, 1, value);
				base.SetModified();
			}
		}

		public bool PreAppendNameAttribute
		{
			get
			{
				return CommonFunction.GetIntAttribute(intKBStyle, 2);
			}
			set
			{
				intKBStyle = CommonFunction.SetIntAttribute(intKBStyle, 2, value);
				base.SetModified();
			}
		}

		public bool AfterAppendNameAttribute
		{
			get
			{
				return CommonFunction.GetIntAttribute(intKBStyle, 4);
			}
			set
			{
				intKBStyle = CommonFunction.SetIntAttribute(intKBStyle, 4, value);
				base.SetModified();
			}
		}

		public bool YesNoAttribute
		{
			get
			{
				return CommonFunction.GetIntAttribute(intKBStyle, 8);
			}
			set
			{
				intKBStyle = CommonFunction.SetIntAttribute(intKBStyle, 8, value);
				base.SetModified();
			}
		}

		public string SEQ
		{
			get
			{
				return strSEQ;
			}
			set
			{
				strSEQ = value;
			}
		}

		public string ParentSEQ
		{
			get
			{
				if (myParent == null)
				{
					return strParent;
				}
				return myParent.SEQ;
			}
			set
			{
				strParent = value;
				base.SetModified();
			}
		}

		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				if (strName != value)
				{
					strName = value;
					if (strName == null)
					{
						strName = " ";
					}
					base.SetModified();
				}
			}
		}

		public string Desc
		{
			get
			{
				return strDesc;
			}
			set
			{
				strDesc = value;
			}
		}

		public string ListSQL
		{
			get
			{
				return strListSQL;
			}
			set
			{
				if (strListSQL != value)
				{
					strListSQL = value;
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

		public int KBStyle
		{
			get
			{
				return intKBStyle;
			}
			set
			{
				intKBStyle = value;
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
				if (StringCommon.isBlankString(strOwnerSection))
				{
					strOwnerSection = null;
				}
				base.SetModified();
			}
		}

		public string KBGroup
		{
			get
			{
				return strKBGroup;
			}
			set
			{
				strKBGroup = value;
				base.SetModified();
			}
		}

		public string FullPath
		{
			get
			{
				return strFullPath;
			}
			set
			{
				strFullPath = value;
			}
		}

		public KB_List Parent
		{
			get
			{
				return myParent;
			}
			set
			{
				myParent = value;
			}
		}

		public ArrayList Items
		{
			get
			{
				return myItems;
			}
			set
			{
				myItems = value;
			}
		}

		public ArrayList ChildNodes
		{
			get
			{
				return myChildNodes;
			}
			set
			{
				myChildNodes = value;
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

		public string KeyPreFix
		{
			get
			{
				if (strSEQ != null && strSEQ.Length > 5)
				{
					return strSEQ.Substring(0, 5);
				}
				return null;
			}
		}

		public static bool CheckName(string strText)
		{
			if (strText == null)
			{
				return false;
			}
			strText = strText.Trim();
			if (strText.Length == 0 || strText.Length > 50)
			{
				return false;
			}
			return true;
		}

		public bool FromXML(XmlElement myElement)
		{
			strSEQ = myElement.GetAttribute("seq");
			strParent = myElement.GetAttribute("parent");
			strName = myElement.GetAttribute("name");
			strDesc = myElement.GetAttribute("desc");
			intListIndex = Convert.ToInt32(myElement.GetAttribute("index"));
			strListSQL = myElement.GetAttribute("sql");
			intKBStyle = Convert.ToInt32(myElement.GetAttribute("style"));
			OwnerSection = myElement.GetAttribute("section");
			strKBGroup = myElement.GetAttribute("group");
			return true;
		}

		public bool ToXML(XmlElement myElement)
		{
			myElement.SetAttribute("seq", strSEQ);
			myElement.SetAttribute("parent", strParent);
			myElement.SetAttribute("name", strName);
			myElement.SetAttribute("desc", strDesc);
			myElement.SetAttribute("index", intListIndex.ToString());
			myElement.SetAttribute("sql", strListSQL);
			myElement.SetAttribute("style", intKBStyle.ToString());
			myElement.SetAttribute("section", (strOwnerSection == null) ? "" : strOwnerSection);
			myElement.SetAttribute("group", strKBGroup);
			return true;
		}

		public string GetRealFullPath()
		{
			string text = strName;
			KB_List parent = Parent;
			while (parent != null && parent.SEQ != null)
			{
				text = parent.Name + "." + text;
				parent = parent.Parent;
			}
			return text;
		}

		public bool HasChildObjects()
		{
			return HasItems() || HasChildren() || StringCommon.HasContent(strListSQL);
		}

		public void LoadAllChildObjects(ArrayList myList, ZYDBConnection conn)
		{
			if (myList == null)
			{
				return;
			}
			if (HasChildren())
			{
				myList.AddRange(myChildNodes);
				return;
			}
			if (!HasLaunchSystemItems)
			{
				LaunchSystemItems(conn);
			}
			if (HasItems())
			{
				myList.AddRange(myItems);
			}
		}

		public bool EnableAddChild()
		{
			if (!HasItems() && StringCommon.isBlankString(ListSQL) && !InputBoxAttribute)
			{
				return true;
			}
			return false;
		}

		public bool EnableAddItem()
		{
			if (!HasChildren() && StringCommon.isBlankString(ListSQL))
			{
				return true;
			}
			return false;
		}

		public bool AppendChild(KB_List myList)
		{
			if (myList != null && EnableAddChild() && myList.SEQ != SEQ)
			{
				if (myChildNodes == null)
				{
					myChildNodes = new ArrayList();
				}
				if (myList.Parent != null)
				{
					myList.Parent.ChildNodes.Remove(myList);
				}
				foreach (KB_List myChildNode in myChildNodes)
				{
					if (myList.ListIndex <= myChildNode.ListIndex)
					{
						myList.ListIndex = myChildNode.ListIndex + 1;
					}
				}
				myChildNodes.Add(myList);
				myList.Parent = this;
				myList.OwnerSection = OwnerSection;
				myList.SetModified();
				return true;
			}
			return false;
		}

		public bool AppendItem(KB_Item myItem)
		{
			if (myItem != null && EnableAddItem())
			{
				if (myItems == null)
				{
					myItems = new ArrayList();
				}
				if (myItem.OwnerList != null)
				{
					myItem.OwnerList.Items.Remove(myItem);
				}
				foreach (KB_Item myItem2 in myItems)
				{
					if (myItem.ListIndex <= myItem2.ListIndex)
					{
						myItem.ListIndex = myItem2.ListIndex + 1;
					}
				}
				myItems.Add(myItem);
				myItem.OwnerList = this;
				myItem.SetModified();
				return true;
			}
			return false;
		}

		public void SimpleAppendItem(KB_Item myItem)
		{
			if (myItems == null)
			{
				myItems = new ArrayList();
			}
			myItems.Add(myItem);
			myItem.ListIndex = myItems.Count;
			myItem.OwnerList = this;
		}

		public void SimpleAppendChild(KB_List myList)
		{
			if (myChildNodes == null)
			{
				myChildNodes = new ArrayList();
			}
			myChildNodes.Add(myList);
			myList.ListIndex = myChildNodes.Count;
			myList.Parent = this;
		}

		public KB_Item NewItem(string strText)
		{
			if (!EnableAddItem())
			{
				return null;
			}
			if (myChildNodes != null && myChildNodes.Count > 0)
			{
				return null;
			}
			KB_Item kB_Item = new KB_Item();
			kB_Item.OwnerList = this;
			kB_Item.ItemText = strText;
			if (myItems == null)
			{
				myItems = new ArrayList();
			}
			kB_Item.ListIndex = 0;
			foreach (KB_Item myItem in myItems)
			{
				if (kB_Item.ListIndex <= myItem.ListIndex)
				{
					kB_Item.ListIndex = myItem.ListIndex + 1;
				}
			}
			myItems.Add(kB_Item);
			kB_Item.DataState = DataRowState.Added;
			return kB_Item;
		}

		public KB_List NewChildList(string strName)
		{
			if (!EnableAddChild())
			{
				return null;
			}
			if (myItems != null && myItems.Count > 0)
			{
				return null;
			}
			KB_List kB_List = new KB_List();
			kB_List.Parent = this;
			kB_List.Name = strName;
			kB_List.OwnerSection = OwnerSection;
			if (myChildNodes == null)
			{
				myChildNodes = new ArrayList();
			}
			kB_List.ListIndex = 0;
			foreach (KB_List myChildNode in myChildNodes)
			{
				if (kB_List.ListIndex <= myChildNode.ListIndex)
				{
					kB_List.ListIndex = myChildNode.ListIndex + 1;
				}
			}
			myChildNodes.Add(kB_List);
			kB_List.DataState = DataRowState.Added;
			return kB_List;
		}

		public bool HasChildren()
		{
			return myChildNodes != null && myChildNodes.Count > 0;
		}

		public bool HasItems()
		{
			return myItems != null && myItems.Count > 0;
		}

		public bool isFixItem()
		{
			if (myItems != null && myItems.Count > 0)
			{
				foreach (KB_Item myItem in myItems)
				{
					if (myItem.ItemStyle != 0 && myItem.ItemStyle != 100)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public void LaunchSystemItems(ZYDBConnection conn)
		{
			HasLaunchSystemItems = true;
			ArrayList outItems = new ArrayList();
			ExecuteSystemItem(conn, outItems);
			myItems = outItems;
		}

		public bool HasSystemItem()
		{
			foreach (KB_Item myItem in myItems)
			{
				if (myItem.isSystemItem())
				{
					return true;
				}
			}
			return false;
		}

		public int ExecuteSystemItem(ZYDBConnection conn, ArrayList OutItems)
		{
			int count = OutItems.Count;
			try
			{
				ArrayList arrayList = new ArrayList();
				if (!StringCommon.isBlankString(strListSQL) && conn != null && conn.isOpened())
				{
					using (IDbCommand dbCommand = conn.CreateCommand())
					{
						dbCommand.CommandText = strListSQL;
						IDataReader dataReader = dbCommand.ExecuteReader();
						ArrayList arrayList2 = new ArrayList();
						while (dataReader.Read())
						{
							KB_Item kB_Item = new KB_Item();
							kB_Item.ItemStyle = 1;
							kB_Item.OwnerList = this;
							kB_Item.ItemText = (dataReader.IsDBNull(0) ? "" : dataReader.GetString(0));
							if (dataReader.FieldCount > 1)
							{
								kB_Item.ItemValue = (dataReader.IsDBNull(1) ? " " : dataReader.GetString(1));
							}
							else
							{
								kB_Item.ItemValue = kB_Item.ItemText;
							}
							if (kB_Item.isNormalItem())
							{
								OutItems.Add(kB_Item);
							}
							else
							{
								arrayList.Add(kB_Item);
							}
							kB_Item.DataState = DataRowState.Unchanged;
						}
						dataReader.Close();
						dbCommand.Parameters.Clear();
					}
					conn.ExecuteCompleted();
				}
				if (myItems != null)
				{
					for (int num = myItems.Count - 1; num >= 0; num--)
					{
						KB_Item kB_Item2 = (KB_Item)myItems[num];
						if (kB_Item2.isSystemItem())
						{
							arrayList.Add(kB_Item2);
						}
						else
						{
							OutItems.Insert(0, kB_Item2);
						}
					}
				}
				if (arrayList.Count > 0 && conn != null && conn.isOpened())
				{
					using (IDbCommand dbCommand = conn.CreateCommand())
					{
						foreach (KB_Item item in arrayList)
						{
							switch (item.ItemStyle)
							{
							case 11:
								dbCommand.CommandText = ((Variables == null) ? item.ItemText : Variables.FixVariableString(item.ItemText));
								break;
							case 12:
								ZYDBConnection.AddParameter(dbCommand, (Variables == null) ? item.ItemText : Variables.FixVariableString(item.ItemText));
								break;
							case 13:
							{
								IDataReader dataReader2 = dbCommand.ExecuteReader();
								while (dataReader2.Read())
								{
									KB_Item kB_Item = new KB_Item();
									kB_Item.OwnerList = this;
									kB_Item.ItemText = (dataReader2.IsDBNull(0) ? " " : dataReader2[0].ToString());
									if (dataReader2.FieldCount > 1)
									{
										kB_Item.ItemValue = (dataReader2.IsDBNull(1) ? " " : dataReader2[1].ToString());
									}
									else
									{
										kB_Item.ItemValue = kB_Item.ItemText;
									}
									OutItems.Add(kB_Item);
								}
								dataReader2.Close();
								break;
							}
							case 14:
								dbCommand.ExecuteNonQuery();
								break;
							case 15:
								foreach (KB_Item OutItem in OutItems)
								{
									if (OutItem.ItemText == item.ItemText)
									{
										OutItem.ItemText = item.ItemValue;
									}
								}
								break;
							case 16:
								foreach (KB_Item OutItem2 in OutItems)
								{
									OutItem2.ItemText = StringCommon.FormatDateTime(OutItem2.ItemText, item.ItemText, item.ItemValue);
								}
								break;
							case 17:
							{
								KB_Item kB_Item4 = new KB_Item();
								kB_Item4.ItemText = ((Variables == null) ? item.ItemText : Variables.FixVariableString(item.ItemText));
								OutItems.Add(kB_Item4);
								break;
							}
							case 18:
								if (Variables != null)
								{
									Variables.SetValue(item.ItemText, item.ItemValue);
								}
								break;
							case 19:
								goto IL_04f0;
							}
						}
					}
					conn.ExecuteCompleted();
					goto IL_04f0;
				}
				goto IL_0556;
				IL_04f0:
				int num2 = 0;
				foreach (KB_Item OutItem3 in OutItems)
				{
					OutItem3.ListIndex = num2;
					OutItem3.DataState = DataRowState.Unchanged;
					num2++;
				}
				goto IL_0556;
				IL_0556:
				return OutItems.Count - count;
			}
			catch (Exception ex)
			{
				MessageBox.Show(null, "程序运行错误\r\n" + ex.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				myItems = new ArrayList();
				NewItem("知识库列表加载错误!!!");
				conn?.ExecuteCompleted();
				return 0;
			}
		}

		public string GetValue()
		{
			if (myItems != null && myItems.Count > 0)
			{
				return (myItems[0] as KB_Item).ItemText;
			}
			return "";
		}

		public static void SetSelectAllCommandWidthSection(IDbCommand myCmd, string strSection)
		{
			myCmd.CommandText = "Select KB_List.KB_SEQ, KB_List.KB_PARENT , KB_List.KB_NAME , KB_List.KB_DESC , KB_List.ListIndex , KB_List.ListSQL , KB_List.KB_Style , KB_List.OwnerSection , KB_List.KB_Group , KBSection.ShowInTree From KB_List,KBSection where kb_list.kb_seq = kbsection.kb_seq and kbsection.ownersection = ? Order by KB_Parent , ListIndex ";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strSection);
		}

		public static void SetSelectSEQCommand(IDbCommand myCmd)
		{
			myCmd.CommandText = "Select KB_SEQ From KB_List Order by KB_SEQ ";
		}

		public static string GetSelectSQL()
		{
			return "Select KB_SEQ, KB_PARENT , KB_NAME , KB_DESC , ListIndex , ListSQL , KB_Style , OwnerSection , KB_Group From KB_List ";
		}

		public override ZYDBRecordBase CreateNewRecord()
		{
			return new KB_List();
		}

		public override string GetTableName()
		{
			return "KB_LIST";
		}

		public override bool isKeyEnable()
		{
			return strSEQ != null && strSEQ.Length == 12;
		}

		public override bool SetAllocKeyCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			if (myCmd != null)
			{
				myCmd.CommandText = " Select Max(KB_SEQ) From KB_List ";
				myCmd.Parameters.Clear();
				return true;
			}
			return false;
		}

		public override bool SetSelectAllCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select KB_SEQ, KB_PARENT , KB_NAME , KB_DESC , ListIndex , ListSQL , KB_Style , OwnerSection , KB_Group From KB_List  Order by KB_Parent , ListIndex ";
			return true;
		}

		public override bool SetSelectCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select KB_SEQ, KB_PARENT , KB_NAME , KB_DESC , ListIndex , ListSQL , KB_Style , OwnerSection , KB_Group From KB_List Where kb_Parent =? Order by ListIndex ";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, strParent);
			return true;
		}

		public override bool SetSelectCommandForOneRecord(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Select KB_SEQ, KB_PARENT , KB_NAME , KB_DESC , ListIndex , ListSQL , KB_Style , OwnerSection , KB_Group From KB_List Where kb_seq= ? ";
			ZYDBConnection.AddParameter(myCmd, strSEQ);
			return true;
		}

		public override bool SetKeyWord(string strKey)
		{
			try
			{
				strSEQ = strKey;
				return true;
			}
			catch
			{
			}
			return false;
		}

		public override bool SetTestExistCommand(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "select kb_seq from kb_list where kb_seq=" + strSEQ;
			return true;
		}

		public override bool FromReader(IDataReader myReader, ZYDBConnection conn)
		{
			if (myReader == null)
			{
				return false;
			}
			if (myReader.FieldCount >= 9)
			{
				strSEQ = (myReader.IsDBNull(0) ? null : myReader.GetString(0));
				strParent = (myReader.IsDBNull(1) ? null : myReader.GetString(1));
				if (StringCommon.isBlankString(strSEQ))
				{
					strSEQ = null;
				}
				if (StringCommon.isBlankString(strParent))
				{
					strParent = null;
				}
				strName = (myReader.IsDBNull(2) ? " " : myReader.GetString(2));
				strDesc = (myReader.IsDBNull(3) ? " " : myReader.GetString(3));
				intListIndex = (myReader.IsDBNull(4) ? (-1) : Convert.ToInt32(myReader[4]));
				strListSQL = (myReader.IsDBNull(5) ? " " : myReader.GetString(5));
				intKBStyle = ((!myReader.IsDBNull(6)) ? Convert.ToInt32(myReader[6]) : 0);
				OwnerSection = (myReader.IsDBNull(7) ? "" : myReader.GetString(7).Trim());
				KBGroup = (myReader.IsDBNull(8) ? "" : myReader.GetString(8).Trim());
				if (StringCommon.isBlankString(strOwnerSection))
				{
					strOwnerSection = null;
				}
				if (StringCommon.isBlankString(strKBGroup))
				{
					strKBGroup = null;
				}
				if (myReader.FieldCount == 10)
				{
					bolShowInTree = (myReader.IsDBNull(9) || myReader.GetString(9) != "0");
				}
				else
				{
					bolShowInTree = true;
				}
				return true;
			}
			return false;
		}

		public override bool SetInsertCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			if (myCmd != null)
			{
				myCmd.CommandText = "Insert Into KB_List ( KB_SEQ, KB_PARENT , KB_NAME , KB_DESC, ListIndex , ListSQL , KB_Style , OwnerSection , KB_Group) values( ? , ? ,? ,? , ? , ? , ? , ? , ?)";
				myCmd.Parameters.Clear();
				ZYDBConnection.AddParameter(myCmd, strSEQ);
				ZYDBConnection.AddParameter(myCmd, ParentSEQ);
				ZYDBConnection.AddParameter(myCmd, strName);
				ZYDBConnection.AddParameter(myCmd, strDesc);
				ZYDBConnection.AddParameter(myCmd, intListIndex);
				ZYDBConnection.AddParameter(myCmd, strListSQL);
				ZYDBConnection.AddParameter(myCmd, intKBStyle);
				ZYDBConnection.AddParameter(myCmd, strDeptment);
				ZYDBConnection.AddParameter(myCmd, (strKBGroup == null) ? " " : strKBGroup);
				return true;
			}
			return false;
		}

		public override bool SetUpdateCommnad(IDbCommand myCmd, ZYDBConnection conn)
		{
			myCmd.CommandText = "Update KB_LIST set KB_PARENT = ? , KB_NAME = ? , KB_DESC = ? , ListIndex = ? , ListSQL = ?  , KB_Style = ? , OwnerSection = ? , KB_Group = ? WHERE KB_SEQ = ?";
			myCmd.Parameters.Clear();
			ZYDBConnection.AddParameter(myCmd, ParentSEQ);
			ZYDBConnection.AddParameter(myCmd, strName);
			ZYDBConnection.AddParameter(myCmd, strDesc);
			ZYDBConnection.AddParameter(myCmd, intListIndex);
			ZYDBConnection.AddParameter(myCmd, strListSQL);
			ZYDBConnection.AddParameter(myCmd, intKBStyle);
			ZYDBConnection.AddParameter(myCmd, strDeptment);
			ZYDBConnection.AddParameter(myCmd, (strKBGroup == null) ? " " : strKBGroup);
			ZYDBConnection.AddParameter(myCmd, strSEQ);
			return true;
		}

		public override bool CustomDelete(IDbCommand myCmd, ZYDBConnection conn)
		{
			if (isKeyEnable())
			{
				myCmd.Parameters.Clear();
				myCmd.CommandText = "Delete From KB_LIST WHERE KB_SEQ=?";
				ZYDBConnection.AddParameter(myCmd, strSEQ);
				myCmd.ExecuteNonQuery();
				myCmd.Parameters.Clear();
				myCmd.CommandText = "Delete From KB_Item Where KB_SEQ=?";
				ZYDBConnection.AddParameter(myCmd, strSEQ);
				myCmd.ExecuteNonQuery();
				myCmd.Parameters.Clear();
			}
			return true;
		}
	}
}

using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYKBBuffer
	{
		public string Custom_KBLIST_SQL = null;

		public string Custom_KBITEM_SQL = null;

		private static ZYKBBuffer myInstance = new ZYKBBuffer();

		public int Mod = 0;

		private KB_List myRootList = new KB_List();

		public ZYDBConnection myConn = null;

		private bool bolLoading = false;

		private ArrayList myAllKBList = new ArrayList();

		private ArrayList myTemplateList = new ArrayList();

		public string strKeyPreFix = "00000";

		private bool bolEnableKBSection = true;

		private ArrayList myKBSectionList = new ArrayList();

		public string strOwnerSection = null;

		public bool OnlyCheckYesNoAttribute = false;

		public bool DesignMode = false;

		public string[] SectionList = null;

		public string SectionSQL = null;

		public string ProjectName;

		public bool SearchTemplateOnly = false;

		public static ZYKBBuffer Instance => myInstance;

		public bool EnableKBSection
		{
			get
			{
				return bolEnableKBSection;
			}
			set
			{
				bolEnableKBSection = value;
			}
		}

		public ArrayList KBSectionList => myKBSectionList;

		public string KeyPreFix
		{
			get
			{
				return strKeyPreFix;
			}
			set
			{
				strKeyPreFix = value;
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

		public ZYDBConnection Connection
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

		public bool Loading
		{
			get
			{
				return bolLoading;
			}
			set
			{
				bolLoading = value;
			}
		}

		public KB_List RootList => myRootList;

		public ArrayList AllKBList => myAllKBList;

		public ArrayList TemplateList => myTemplateList;

		public ET_Document CreateET_Document(string strObjectID)
		{
			ET_Document eT_Document = new ET_Document();
			eT_Document.ObjectID = strObjectID;
			if (myConn.ReadOneRecord(eT_Document))
			{
				return eT_Document;
			}
			return null;
		}

		public int GetAllET_Document(ArrayList myList)
		{
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				dbCommand.CommandText = ET_Document.GetSelectSQL() + " Where ObjectID Like '" + strKeyPreFix + "%'";
				IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
				int num = 0;
				while (dataReader.Read())
				{
					ET_Document eT_Document = new ET_Document();
					if (eT_Document.FromReader(dataReader, myConn))
					{
						myList.Add(eT_Document);
						num++;
					}
				}
				dataReader.Close();
				return num;
			}
		}

		public void LoadKBSection()
		{
			if (bolEnableKBSection && myConn != null)
			{
				if (myKBSectionList != null)
				{
					myKBSectionList.Clear();
				}
				myKBSectionList = myConn.ReadAllRecords(new KBSection());
			}
		}

		public bool BindKBToSection(KB_List myRootKB, bool bolSet, bool ShowInTree)
		{
			if (StringCommon.HasContent(strOwnerSection) && myRootKB != null)
			{
				bool result = InnerBindKBToSection(myRootKB, bolSet, ShowInTree);
				if (bolSet)
				{
					KB_List parent = myRootKB.Parent;
					while (parent != null && parent.SEQ != null)
					{
						if (BindKBToSection(parent.SEQ, bolSet, ShowInTree))
						{
							result = true;
						}
						parent = parent.Parent;
					}
				}
				return result;
			}
			return false;
		}

		private bool InnerBindKBToSection(KB_List myRootKB, bool bolSet, bool ShowInTree)
		{
			if (StringCommon.HasContent(strOwnerSection) && myRootKB != null)
			{
				bool result = BindKBToSection(myRootKB.SEQ, bolSet, ShowInTree);
				if (myRootKB.ChildNodes != null)
				{
					foreach (KB_List childNode in myRootKB.ChildNodes)
					{
						if (BindKBToSection(childNode, bolSet, ShowInTree))
						{
							result = true;
						}
					}
				}
				return result;
			}
			return false;
		}

		public bool BindKBToSection(string KBSEQ, bool bolSet, bool ShowInTree)
		{
			KBSection kBSection = FindKBSection(strOwnerSection, KBSEQ);
			if (bolSet)
			{
				if (kBSection == null)
				{
					kBSection = new KBSection();
					kBSection.OwnerSection = strOwnerSection;
					kBSection.KBSEQ = KBSEQ;
					kBSection.DataState = DataRowState.Added;
					kBSection.ShowInTree = ShowInTree;
					myKBSectionList.Add(kBSection);
					return true;
				}
			}
			else if (kBSection != null)
			{
				if (kBSection.isNewRecord())
				{
					myKBSectionList.Remove(kBSection);
				}
				else
				{
					kBSection.DataState = DataRowState.Deleted;
				}
				return true;
			}
			return false;
		}

		public KBSection FindKBSection(string strSection, string KBSEQ)
		{
			if (StringCommon.HasContent(strSection) && KBSEQ != null)
			{
				strSection = strSection.Trim();
				foreach (KBSection myKBSection in myKBSectionList)
				{
					if (strSection.Equals(myKBSection.OwnerSection) && myKBSection.KBSEQ == KBSEQ && !myKBSection.isDeleted())
					{
						return myKBSection;
					}
				}
			}
			return null;
		}

		public bool HasBindKBSection(string strSection, string KBSEQ)
		{
			if (StringCommon.HasContent(strSection) && KBSEQ != null && myKBSectionList.Count > 0)
			{
				strSection = strSection.Trim();
				foreach (KBSection myKBSection in myKBSectionList)
				{
					if (!myKBSection.isDeleted() && strSection.Equals(myKBSection.OwnerSection) && myKBSection.KBSEQ == KBSEQ)
					{
						return true;
					}
				}
			}
			return false;
		}

		public Color GetItemForeColor(KB_List myList)
		{
			if (myList != null && !myList.InputBoxAttribute && !myList.HasItems() && !myList.HasChildren() && StringCommon.isBlankString(myList.ListSQL))
			{
				return Color.Blue;
			}
			return SystemColors.WindowText;
		}

		public void UpdateSectionList()
		{
			SectionList = myConn.GetValueList(SectionSQL, OnlyFirstField: false, OnlyFirstRecord: false);
		}

		public bool CanReadKB()
		{
			return !bolLoading && myAllKBList != null && myAllKBList.Count > 0;
		}

		public void RefreshAllKBList()
		{
			ZYDBRecordBase.RemoveDeletedRecord(myAllKBList, CheckSuccess: true);
			foreach (KB_List myAllKB in myAllKBList)
			{
				ZYDBRecordBase.RemoveDeletedRecord(myAllKB.ChildNodes, CheckSuccess: true);
				ZYDBRecordBase.RemoveDeletedRecord(myAllKB.Items, CheckSuccess: true);
			}
			ZYDBRecordBase.RemoveDeletedRecord(myKBSectionList, CheckSuccess: true);
			myAllKBList.Clear();
			myTemplateList.Clear();
			RefreshAllKBList(myRootList);
			RefreshKBChineseSpell();
		}

		public void RefreshAllKBList(KB_List vRootList)
		{
			myAllKBList.Add(vRootList);
			if (vRootList.ChildNodes != null && vRootList.ChildNodes.Count > 0)
			{
				foreach (KB_List childNode in vRootList.ChildNodes)
				{
					RefreshAllKBList(childNode);
				}
			}
			if (vRootList.Items != null && vRootList.Items.Count > 0)
			{
				foreach (KB_Item item in vRootList.Items)
				{
					if (item.isTemplate())
					{
						myTemplateList.Add(item);
					}
				}
			}
		}

		public KB_List GetKBList(string vSEQ)
		{
			if (myAllKBList != null)
			{
				foreach (KB_List myAllKB in myAllKBList)
				{
					if (myAllKB.SEQ == vSEQ)
					{
						return myAllKB;
					}
				}
			}
			return null;
		}

		public void GetAllChangedRecord(ArrayList myOutList)
		{
			InnerGetChangedKB(myRootList, myOutList);
			foreach (KBSection myKBSection in myKBSectionList)
			{
				if (!myKBSection.isUnchanged())
				{
					myOutList.Add(myKBSection);
				}
			}
		}

		private void InnerGetChangedKB(KB_List myRootKB, ArrayList myOutList)
		{
			if (myRootKB.Items != null)
			{
				foreach (KB_Item item in myRootKB.Items)
				{
					if (!item.isUnchanged())
					{
						myOutList.Add(item);
					}
				}
			}
			if (myRootKB.ChildNodes != null)
			{
				foreach (KB_List childNode in myRootKB.ChildNodes)
				{
					if (!childNode.isUnchanged())
					{
						myOutList.Add(childNode);
					}
					InnerGetChangedKB(childNode, myOutList);
				}
			}
		}

		public KB_List GetKBListByName(string strName, bool bolMatchAll)
		{
			if (myAllKBList != null)
			{
				foreach (KB_List myAllKB in myAllKBList)
				{
					if (myAllKB.Visible && (myAllKB.Name == strName || (!bolMatchAll && myAllKB.Name.IndexOf(strName) >= 0)))
					{
						return myAllKB;
					}
				}
			}
			return null;
		}

		public KB_Item GetTemplateByID(int id)
		{
			if (myTemplateList != null)
			{
				foreach (KB_Item myTemplate in myTemplateList)
				{
					if (myTemplate.ItemSEQ == id)
					{
						return myTemplate;
					}
				}
			}
			return null;
		}

		public bool GetTemplatesByName(string strName, ArrayList myOutList)
		{
			if (bolLoading)
			{
				return false;
			}
			if (StringCommon.isBlankString(strName))
			{
				myOutList.AddRange(myTemplateList);
				return false;
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			bool result = false;
			foreach (KB_Item myTemplate in myTemplateList)
			{
				if (myTemplate.ItemText == strName)
				{
					arrayList2.Add(myTemplate);
					result = true;
				}
				else if (myTemplate.ItemText.IndexOf(strName) >= 0 || strName.IndexOf(myTemplate.ItemText) >= 0)
				{
					arrayList.Add(myTemplate);
					result = true;
				}
				else
				{
					arrayList3.Add(myTemplate);
				}
			}
			myOutList.AddRange(arrayList2);
			myOutList.AddRange(arrayList);
			myOutList.AddRange(arrayList3);
			return result;
		}

		public static void AddToKBListArray(ArrayList myList, KB_List myKBList)
		{
			for (int i = 0; i < myList.Count; i++)
			{
				KB_List kB_List = (KB_List)myList[i];
				if (kB_List.RefCount < myKBList.RefCount)
				{
					myList.Insert(i, myKBList);
					return;
				}
			}
			myList.Add(myKBList);
		}

		public bool GetKBListsByName(string strName, ArrayList myOutList, bool bolCompareName)
		{
			if (bolLoading)
			{
				return false;
			}
			if (myOutList == null)
			{
				return false;
			}
			if (StringCommon.isBlankString(strName))
			{
				return false;
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			bool result = false;
			string text = strName.Trim().ToUpper();
			if (!SearchTemplateOnly && myAllKBList != null)
			{
				foreach (KB_List myAllKB in myAllKBList)
				{
					if (myAllKB.Visible && myAllKB.SEQ != null && (myAllKB.HasItems() || (myAllKB.ListSQL != null && myAllKB.ListSQL.Length > 0)))
					{
						if (OnlyCheckYesNoAttribute)
						{
							if (myAllKB.YesNoAttribute)
							{
								AddToKBListArray(arrayList2, myAllKB);
							}
						}
						else if ((bolCompareName && myAllKB.Name == strName) || myAllKB.ChineseSpell == text)
						{
							AddToKBListArray(arrayList2, myAllKB);
							result = true;
						}
						else if ((bolCompareName && myAllKB.Name.IndexOf(strName) >= 0) || myAllKB.ChineseSpell.StartsWith(text))
						{
							arrayList.Insert(0, myAllKB);
							result = true;
						}
						else if (bolCompareName && strName.IndexOf(myAllKB.Name) >= 0)
						{
							arrayList.Add(myAllKB);
						}
					}
				}
			}
			if (!OnlyCheckYesNoAttribute && myTemplateList != null)
			{
				foreach (KB_Item myTemplate in myTemplateList)
				{
					if (myTemplate.OwnerList.Visible)
					{
						string chineseSpell = StringCommon.GetChineseSpell(myTemplate.ItemText);
						if ((bolCompareName && myTemplate.ItemText == strName) || chineseSpell == text)
						{
							arrayList2.Add(myTemplate);
						}
						else if ((bolCompareName && myTemplate.ItemText.IndexOf(strName) >= 0) || strName.IndexOf(myTemplate.ItemText) >= 0 || chineseSpell.StartsWith(text))
						{
							arrayList.Insert(0, myTemplate);
						}
						result = true;
					}
				}
			}
			if (arrayList2.Count > 0)
			{
				myOutList.AddRange(arrayList2);
			}
			if (arrayList.Count > 0)
			{
				myOutList.AddRange(arrayList);
			}
			if (!SearchTemplateOnly)
			{
				if (myOutList.Count > 0)
				{
					myOutList.Add(null);
				}
				if (myRootList.ChildNodes != null)
				{
					foreach (KB_List childNode in myRootList.ChildNodes)
					{
						if (childNode.Visible)
						{
							myOutList.Add(childNode);
						}
					}
				}
			}
			return result;
		}

		public void AllKBListToXML(XmlElement RootElement)
		{
			XmlDocument ownerDocument = RootElement.OwnerDocument;
			foreach (KB_List myAllKB in myAllKBList)
			{
				if (myAllKB.SEQ != null)
				{
					XmlElement xmlElement = ownerDocument.CreateElement("list");
					myAllKB.ToXML(xmlElement);
					RootElement.AppendChild(xmlElement);
					if (myAllKB.Items != null && myAllKB.Items.Count > 0)
					{
						foreach (KB_Item item in myAllKB.Items)
						{
							xmlElement = ownerDocument.CreateElement("item");
							item.ToXML(xmlElement);
							RootElement.AppendChild(xmlElement);
						}
					}
				}
			}
		}

		public void Close()
		{
		}

		public int KBListToObjList(ArrayList myObjList, KB_List vRootList, bool IncludeTemplate, IDbCommand myCmd)
		{
			int num = 0;
			if (myObjList != null && vRootList != null)
			{
				if (vRootList.ChildNodes != null && vRootList.ChildNodes.Count > 0)
				{
					myObjList.AddRange(vRootList.ChildNodes);
					num += vRootList.ChildNodes.Count;
					foreach (KB_List childNode in vRootList.ChildNodes)
					{
						num += KBListToObjList(myObjList, childNode, IncludeTemplate, myCmd);
						if (myKBSectionList != null)
						{
							foreach (KBSection myKBSection in myKBSectionList)
							{
								if (myKBSection.KBSEQ == childNode.SEQ)
								{
									myObjList.Add(myKBSection);
									num++;
								}
							}
						}
					}
				}
				else if (vRootList.Items != null && vRootList.Items.Count > 0)
				{
					myObjList.AddRange(vRootList.Items);
					num += vRootList.Items.Count;
					foreach (KB_Item item in vRootList.Items)
					{
						if (item.isTemplate() && StringCommon.IsInteger(item.ItemValue) && IncludeTemplate && myCmd != null)
						{
							try
							{
								ET_Document eT_Document = new ET_Document();
								eT_Document.SetKeyWord(item.ItemValue);
								eT_Document.SetSelectCommandForOneRecord(myCmd, null);
								IDataReader dataReader = myCmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
								if (dataReader.Read() && eT_Document.FromReader(dataReader, null))
								{
									myObjList.Add(eT_Document);
								}
								dataReader.Close();
							}
							catch (Exception ex)
							{
								MessageBox.Show(null, "导出模板 " + item.ItemText + " 数据错误:\r\n" + ex.ToString() + myCmd.CommandText, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
					}
				}
			}
			return num;
		}

		public int KBListToXML(XmlElement vRootElement, KB_List vRootList, bool IncludeTemplate, IDbCommand myCmd)
		{
			int num = 0;
			if (vRootElement != null && vRootList != null)
			{
				XmlDocument ownerDocument = vRootElement.OwnerDocument;
				XmlElement xmlElement = null;
				if (vRootList.ChildNodes != null && vRootList.ChildNodes.Count > 0)
				{
					foreach (KB_List childNode in vRootList.ChildNodes)
					{
						xmlElement = ownerDocument.CreateElement("kb");
						vRootElement.AppendChild(xmlElement);
						childNode.ToXML(xmlElement);
						num++;
						num += KBListToXML(xmlElement, childNode, IncludeTemplate, myCmd);
						if (myKBSectionList != null)
						{
							StringBuilder stringBuilder = new StringBuilder();
							bool flag = true;
							foreach (KBSection myKBSection in myKBSectionList)
							{
								if (myKBSection.KBSEQ == childNode.SEQ)
								{
									stringBuilder.Append(myKBSection.OwnerSection);
									if (!flag)
									{
										stringBuilder.Append(",");
									}
									flag = false;
								}
							}
							if (stringBuilder.Length > 0)
							{
								xmlElement.SetAttribute("bindsection", stringBuilder.ToString());
							}
						}
					}
				}
				else if (vRootList.Items != null && vRootList.Items.Count > 0)
				{
					foreach (KB_Item item in vRootList.Items)
					{
						xmlElement = ownerDocument.CreateElement("item");
						vRootElement.AppendChild(xmlElement);
						item.ToXML(xmlElement);
						num++;
						if (item.isTemplate() && StringCommon.IsInteger(item.ItemValue) && IncludeTemplate && myCmd != null)
						{
							try
							{
								myCmd.CommandText = "Select ObjectData From ET_Document Where ObjectID = " + item.ItemValue;
								IDataReader dataReader = myCmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
								string text = null;
								if (dataReader.Read())
								{
									text = dataReader.GetString(0);
								}
								dataReader.Close();
								if (text != null)
								{
									XmlDocument xmlDocument = new XmlDocument();
									xmlDocument.LoadXml(text);
									XmlNode newChild = ownerDocument.ImportNode(xmlDocument.DocumentElement, deep: true);
									xmlElement.AppendChild(newChild);
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show(null, "导出模板 " + item.ItemText + " 数据错误:\r\n" + ex.ToString() + myCmd.CommandText, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
					}
				}
			}
			return num;
		}

		public static int KBListFromXML(XmlElement vRootElement, KB_List vRootList)
		{
			int num = 0;
			if (vRootElement != null && vRootList != null)
			{
				foreach (XmlNode childNode in vRootElement.ChildNodes)
				{
					if (childNode.Name == "kb")
					{
						if (vRootList.ChildNodes == null)
						{
							vRootList.ChildNodes = new ArrayList();
						}
						KB_List kB_List = new KB_List();
						kB_List.FromXML(childNode as XmlElement);
						kB_List.SEQ = null;
						kB_List.Parent = vRootList;
						vRootList.ChildNodes.Add(kB_List);
						num++;
						num += KBListFromXML(childNode as XmlElement, kB_List);
					}
					else if (childNode.Name == "item")
					{
						if (vRootList.Items == null)
						{
							vRootList.Items = new ArrayList();
						}
						KB_Item kB_Item = new KB_Item();
						kB_Item.FromXML(childNode as XmlElement);
						kB_Item.ItemSEQ = -1;
						kB_Item.OwnerList = vRootList;
						vRootList.Items.Add(kB_Item);
						num++;
					}
				}
				if (vRootList.ChildNodes != null && vRootList.ChildNodes.Count == 0)
				{
					vRootList.ChildNodes = null;
				}
				if (vRootList.Items != null && vRootList.Items.Count == 0)
				{
					vRootList.Items = null;
				}
			}
			return num;
		}

		public KB_List LoadAllKBList(XmlElement RootElement, bool FixListIndex)
		{
			bolLoading = true;
			myRootList = new KB_List();
			myRootList.OwnerSection = null;
			myRootList.SEQ = null;
			myAllKBList = new ArrayList();
			ArrayList arrayList = new ArrayList();
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				if (childNode.Name == "list")
				{
					KB_List kB_List = new KB_List();
					kB_List.FromXML((XmlElement)childNode);
					kB_List.DataState = DataRowState.Unchanged;
					if (kB_List.SEQ != null)
					{
						myAllKBList.Add(kB_List);
					}
				}
				if (childNode.Name == "item")
				{
					KB_Item kB_Item = new KB_Item();
					kB_Item.FromXML((XmlElement)childNode);
					kB_Item.DataState = DataRowState.Unchanged;
					arrayList.Add(kB_Item);
				}
			}
			StructAllKBList(myRootList, myAllKBList, arrayList, FixListIndex);
			RefreshKBChineseSpell();
			bolLoading = false;
			return myRootList;
		}

		public int UniteKB(ArrayList myObjList, ObjectProgressHandler setStatus)
		{
			int num = 0;
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				KB_List.SetSelectSEQCommand(dbCommand);
				int[] int32ValueList = ZYDBConnection.GetInt32ValueList(dbCommand);
				ET_Document.SetSelectSEQCommand(dbCommand);
				int[] int32ValueList2 = ZYDBConnection.GetInt32ValueList(dbCommand);
				StringBuffer stringBuffer = new StringBuffer();
				ArrayList arrayList = new ArrayList();
				int num2 = 0;
				foreach (object myObj in myObjList)
				{
					if (myObj is KB_List)
					{
						num++;
						KB_List kB_List = (KB_List)myObj;
						stringBuffer.Append(kB_List.SEQ);
						if (kB_List.Items != null && kB_List.Items.Count > 0)
						{
							foreach (KB_Item item in kB_List.Items)
							{
								item.SetInsertCommnad(dbCommand, myConn);
								dbCommand.ExecuteNonQuery();
							}
						}
						setStatus?.Invoke(myObj, num2, myObjList.Count);
					}
					if (myObj is ET_Document)
					{
						num++;
						ET_Document eT_Document = (ET_Document)myObj;
						dbCommand.ExecuteNonQuery();
						setStatus?.Invoke(myObj, num2, myObjList.Count);
					}
					if (myObj is KBSection)
					{
						num++;
						arrayList.Add(myObj);
						setStatus?.Invoke(myObj, num2, myObjList.Count);
					}
					num2++;
				}
				setStatus?.Invoke("正在更新科室绑定信息...", myObjList.Count, myObjList.Count);
				if (stringBuffer.Count > 0)
				{
					dbCommand.CommandText = "Delete From KBSection Where KB_SEQ in (" + stringBuffer.ToStringList(',') + ")";
					dbCommand.ExecuteNonQuery();
				}
				foreach (KBSection item2 in arrayList)
				{
					item2.SetInsertCommnad(dbCommand, myConn);
					dbCommand.ExecuteNonQuery();
				}
			}
			return num;
		}

		public int[] LoadAllKBSEQ()
		{
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				Int32Buffer int32Buffer = new Int32Buffer();
				KB_List.SetSelectSEQCommand(dbCommand);
				IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
				while (dataReader.Read())
				{
					int32Buffer.Append(Convert.ToInt32(dataReader[0]));
				}
				dataReader.Close();
				return int32Buffer.ToArray();
			}
		}

		public string GetSEQString(string strSQL, IDbCommand myCmd)
		{
			string text = null;
			myCmd.CommandText = "Select Max(KB_SEQ) From KB_List Where KB_SEQ like '" + strKeyPreFix + "%'";
			IDataReader dataReader = myCmd.ExecuteReader(CommandBehavior.SingleRow);
			text = ((!dataReader.Read() || dataReader.IsDBNull(0)) ? (strKeyPreFix + "0000000") : dataReader.GetString(0));
			dataReader.Close();
			return text;
		}

		public int UpdateDataBase(ArrayList myRecords, ProgressHandler p)
		{
			SEQCreator sEQCreator = new SEQCreator();
			SEQCreator sEQCreator2 = new SEQCreator();
			sEQCreator.FixLength = 12;
			int num = 1;
			using (IDbCommand myCmd = myConn.CreateCommand())
			{
				sEQCreator.SEQ = GetSEQString("Select Max(KB_SEQ) From KB_List Where OWNERSECTION='" + strOwnerSection + "'", myCmd);
				sEQCreator2.SEQ = GetSEQString("Select Max(ObjectID) From ET_Document Where OWNERSECTION='" + strOwnerSection + "'", myCmd);
				num = Convert.ToInt32(myConn.GetSingleValue("Select Max(Item_SEQ)+1 From KB_Item"));
			}
			foreach (ZYDBRecordBase myRecord in myRecords)
			{
				if (!myRecord.isKeyEnable() && myRecord.isNewRecord())
				{
					if (myRecord is KB_List)
					{
						myRecord.SetKeyWord(sEQCreator.Create());
					}
					else if (myRecord is KB_Item)
					{
						myRecord.SetKeyWord(num.ToString());
						num++;
					}
					else
					{
						myRecord.SetKeyWord(sEQCreator2.Create());
					}
				}
			}
			return myConn.UpdateRecords(myRecords, p);
		}

		public int DeleteRecords(int Style, IDbCommand myCmd)
		{
			myCmd.Parameters.Clear();
			switch (Style)
			{
			case 0:
				myCmd.CommandText = "Delete From KB_List Where KB_SEQ Like '" + strKeyPreFix + "%'";
				break;
			case 1:
				myCmd.CommandText = "Delete From KB_Item Where KB_SEQ Like '" + strKeyPreFix + "%'";
				break;
			case 2:
				myCmd.CommandText = "Delete From KBSection Where KB_SEQ Like '" + strKeyPreFix + "%'";
				break;
			case 3:
				myCmd.CommandText = "Delete From ET_Document Where ObjectID Like '" + strKeyPreFix + "%'";
				break;
			default:
				return -1;
			}
			return myCmd.ExecuteNonQuery();
		}

		public int LoadRecords(ArrayList myList, int Style, IDbCommand myCmd)
		{
			int result = -1;
			myCmd.Parameters.Clear();
			switch (Style)
			{
			case 0:
				if (Custom_KBLIST_SQL != null && Custom_KBLIST_SQL.Length > 0)
				{
					myCmd.CommandText = Custom_KBLIST_SQL;
				}
				else
				{
					myCmd.CommandText = KB_List.GetSelectSQL() + " Where OWNERSECTION = '" + strKeyPreFix + "' Order by KB_Parent , ListIndex ";
				}
				result = myConn.ReadRecords(myList, new KB_List(), myCmd);
				break;
			case 1:
				if (Custom_KBITEM_SQL != null && Custom_KBITEM_SQL.Length > 0)
				{
					myCmd.CommandText = Custom_KBITEM_SQL;
				}
				else
				{
					myCmd.CommandText = KB_Item.GetSelectSQL() + " Where OWNERSECTION = '" + strKeyPreFix + "' Order by KB_SEQ , ListIndex ";
				}
				result = myConn.ReadRecords(myList, new KB_Item(), myCmd);
				break;
			case 2:
				myCmd.CommandText = KBSection.GetSelectSQL() + " Where OWNERSECTION = '" + strKeyPreFix + "'";
				ZYDBConnection.AddParameter(myCmd, strOwnerSection);
				result = myConn.ReadRecords(myList, new KBSection(), myCmd);
				break;
			case 3:
				myCmd.CommandText = ET_Document.GetSelectSQL() + " Where OWNERSECTION = '" + strKeyPreFix + "'";
				result = myConn.ReadRecords(myList, new ET_Document(), myCmd);
				break;
			case 4:
				myCmd.CommandText = KBSection.GetSelectSQL() + " Where OWNERSECTION = '" + strKeyPreFix + "'";
				result = myConn.ReadRecords(myList, new KBSection(), myCmd);
				break;
			}
			return result;
		}

		public KB_List LoadAllKBList(bool FixListIndex)
		{
			ZYErrorReport.Instance.DebugPrint("开始加载知识库");
			if (myConn == null)
			{
				return null;
			}
			try
			{
				bolLoading = true;
				myRootList = new KB_List();
				myRootList.SEQ = null;
				myRootList.OwnerSection = null;
				if (StringCommon.isBlankString(strOwnerSection))
				{
					strOwnerSection = null;
				}
				else
				{
					strOwnerSection = strOwnerSection.Trim();
				}
				myAllKBList = new ArrayList();
				ArrayList arrayList = new ArrayList();
				using (IDbCommand myCmd = myConn.CreateCommand())
				{
					myAllKBList = new ArrayList();
					if (LoadRecords(myAllKBList, 0, myCmd) == -1)
					{
						return null;
					}
					arrayList = new ArrayList();
					if (LoadRecords(arrayList, 1, myCmd) == -1)
					{
						return null;
					}
					if (!DesignMode && bolEnableKBSection && strOwnerSection != null)
					{
						ArrayList arrayList2 = new ArrayList();
						if (LoadRecords(arrayList2, 4, myCmd) == -1)
						{
							return null;
						}
						foreach (KB_List myAllKB in myAllKBList)
						{
							bool visible = false;
							foreach (KBSection item in arrayList2)
							{
								if (item.KBSEQ == myAllKB.SEQ)
								{
									visible = true;
								}
							}
							myAllKB.Visible = visible;
						}
					}
				}
				myConn.ExecuteCompleted();
				myRootList.Visible = true;
				StructAllKBList(myRootList, myAllKBList, arrayList, FixListIndex);
				RefreshKBChineseSpell();
				bolLoading = false;
				return myRootList;
			}
			catch (Exception ex)
			{
				ZYErrorReport.Instance.DebugPrint("加载知识库错误:" + ex.ToString());
				ZYErrorReport.Instance.MemberName = "ZYKBBuffer.LoadAllKBList( bool )";
				ZYErrorReport.Instance.UserMessage = "加载知识库错误";
				ZYErrorReport.Instance.SourceException = ex;
				ZYErrorReport.Instance.SourceObject = myConn;
				ZYErrorReport.Instance.ReportError();
				return null;
			}
		}

		private void LoadKBRefCount()
		{
			if (myAllKBList != null && myAllKBList.Count != 0)
			{
				try
				{
					string text = Path.Combine(Application.StartupPath, "kbrefcount.dat");
					if (File.Exists(text))
					{
						FileInfo fileInfo = new FileInfo(text);
						if (fileInfo.Length % 4 == 0)
						{
							FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read);
							byte[] array = new byte[fileStream.Length];
							fileStream.Read(array, 0, array.Length);
							fileStream.Close();
							for (int i = 0; i < array.Length && i < myAllKBList.Count; i += 4)
							{
								int num = BitConverter.ToInt32(array, i) % 256;
								if (num < 0)
								{
									num = 0;
								}
								((KB_List)myAllKBList[i]).RefCount = num;
							}
						}
					}
				}
				catch
				{
				}
			}
		}

		private void SaveKBRefCount()
		{
			if (myAllKBList != null && myAllKBList.Count != 0)
			{
				try
				{
					string path = Path.Combine(Application.StartupPath, "kbrefcount.dat");
					if (File.Exists(path))
					{
						File.SetAttributes(path, FileAttributes.Normal);
					}
					FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
					foreach (KB_List myAllKB in myAllKBList)
					{
						fileStream.Write(BitConverter.GetBytes(myAllKB.RefCount), 0, 4);
					}
					fileStream.Close();
				}
				catch
				{
				}
			}
		}

		private void RefreshKBChineseSpell()
		{
			foreach (KB_List myAllKB in myAllKBList)
			{
				myAllKB.ChineseSpell = StringCommon.GetChineseSpell(myAllKB.Name);
			}
		}

		private void StructAllKBList(KB_List vRootList, ArrayList myKBList, ArrayList myItemList, bool FixListIndex)
		{
			if (vRootList != null && myKBList != null)
			{
				vRootList.SEQ = strKeyPreFix + "0000000";
				if (Mod == 1)
				{
					vRootList.Name = "元素库";
				}
				else
				{
					vRootList.Name = "模板库";
				}
				vRootList.ChildNodes = new ArrayList();
				vRootList.Items = new ArrayList();
				vRootList.DataState = DataRowState.Unchanged;
				KB_List kB_List = vRootList;
				foreach (KB_List myKB in myKBList)
				{
					if (kB_List.SEQ != myKB.ParentSEQ)
					{
						kB_List = null;
						foreach (KB_List myAllKB in myAllKBList)
						{
							if (myAllKB.SEQ == myKB.ParentSEQ)
							{
								kB_List = myAllKB;
								if (kB_List.ChildNodes == null)
								{
									kB_List.ChildNodes = new ArrayList();
								}
								break;
							}
						}
					}
					if (kB_List != null)
					{
						kB_List.ChildNodes.Add(myKB);
						myKB.Parent = kB_List;
					}
					else
					{
						kB_List = vRootList;
					}
				}
				if (myKBList.Contains(vRootList))
				{
					myKBList.Remove(vRootList);
				}
				myKBList.Insert(0, vRootList);
				if (myItemList != null)
				{
					myTemplateList = new ArrayList();
					KB_Item kB_Item = new KB_Item();
					kB_List = vRootList;
					foreach (KB_Item myItem in myItemList)
					{
						if (myItem.isTemplate())
						{
							myTemplateList.Add(myItem);
						}
						if (StringCommon.isBlankString(myItem.ItemValue))
						{
							myItem.ItemValue = myItem.ItemText;
						}
						if (kB_List == null || kB_List.SEQ != myItem.KBSEQ)
						{
							kB_List = null;
							foreach (KB_List myAllKB2 in myAllKBList)
							{
								if (myAllKB2.SEQ == myItem.KBSEQ)
								{
									kB_List = myAllKB2;
									if (kB_List.Items == null)
									{
										kB_List.Items = new ArrayList();
									}
									break;
								}
							}
						}
						if (kB_List != null)
						{
							kB_List.Items.Add(myItem);
							myItem.OwnerList = kB_List;
						}
						myItem.DataState = DataRowState.Unchanged;
					}
				}
				if (FixListIndex)
				{
					foreach (KB_List myKB2 in myKBList)
					{
						int num = 0;
						if (myKB2.ChildNodes != null && myKB2.ChildNodes.Count > 0)
						{
							foreach (KB_List childNode in myKB2.ChildNodes)
							{
								if (childNode.ListIndex < num)
								{
									childNode.ListIndex = num;
								}
								num = childNode.ListIndex + 1;
							}
						}
						if (myKB2.Items != null && myKB2.Items.Count > 0)
						{
							num = 0;
							foreach (KB_Item item in myKB2.Items)
							{
								if (item.ListIndex < num)
								{
									item.ListIndex = num;
								}
								num = item.ListIndex + 1;
							}
						}
					}
				}
				foreach (KB_List myKB3 in myKBList)
				{
					if (myKB3.Items != null && myKB3.Items.Count == 0)
					{
						myKB3.Items = null;
					}
					if (myKB3.ChildNodes != null && myKB3.ChildNodes.Count == 0)
					{
						myKB3.ChildNodes = null;
					}
					if (myKB3.ChildNodes != null)
					{
						myKB3.Items = null;
					}
				}
			}
		}

		public int UpdateEMR(string strXMLFileName, ZYDBConnection myConn, bool CanUpdate, ObjectProgressHandler setStatus)
		{
			if (!StringCommon.isBlankString(strXMLFileName) && myConn != null && myConn.isOpened() && myAllKBList != null && myAllKBList.Count > 0)
			{
				int num = 0;
				string strSQL = "Select ElementName From ERMSECTIONCOMPOSEINFO Where ErmxslFileName = '" + strXMLFileName + "'";
				string[] valueList = myConn.GetValueList(strSQL);
				using (IDbCommand dbCommand = myConn.CreateCommand())
				{
					using (IDbCommand dbCommand2 = myConn.CreateCommand())
					{
						dbCommand.CommandText = "Insert Into ERMSECTIONCOMPOSEINFO (ERMXSLFILENAME,ELEMENTDESC , ELEMENTNAME, MULTIVALUEFLAG,AIDFLAG) Values('" + strXMLFileName + "', ? , ? , '0' , '2')";
						dbCommand.Parameters.Add(dbCommand.CreateParameter());
						dbCommand.Parameters.Add(dbCommand.CreateParameter());
						if (CanUpdate)
						{
							dbCommand2.CommandText = "Update ERMSECTIONCOMPOSEINFO Set ELEMENTDESC = ? Where ELEMENTNAME = ? And  ERMXSLFILENAME='" + strXMLFileName + "'";
							dbCommand2.Parameters.Add(dbCommand.CreateParameter());
							dbCommand2.Parameters.Add(dbCommand.CreateParameter());
						}
						bool flag = false;
						foreach (KB_List myAllKB in myAllKBList)
						{
							if (myAllKB.SEQ != null)
							{
								string value = "kb" + myAllKB.SEQ.ToString();
								flag = false;
								if (valueList != null)
								{
									string[] array = valueList;
									foreach (string text in array)
									{
										if (text != null && text.Equals(value))
										{
											flag = true;
											break;
										}
									}
								}
								int num2 = num * 100 / myAllKBList.Count;
								if (flag)
								{
									if (CanUpdate)
									{
										setStatus?.Invoke(myAllKB, num, myAllKBList.Count);
										(dbCommand2.Parameters[0] as IDataParameter).Value = myAllKB.Name;
										(dbCommand2.Parameters[1] as IDataParameter).Value = value;
										dbCommand2.ExecuteNonQuery();
									}
								}
								else
								{
									setStatus?.Invoke(myAllKB, num, myAllKBList.Count);
									(dbCommand.Parameters[0] as IDataParameter).Value = myAllKB.Name;
									(dbCommand.Parameters[1] as IDataParameter).Value = value;
									dbCommand.ExecuteNonQuery();
								}
								num++;
							}
						}
					}
				}
				return num;
			}
			return -1;
		}
	}
}

using System;
using System.Collections;
using System.Data;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYDataSource
	{
		private const string DS_SQL = "sql";

		private const string DS_SetValue = "setvalue";

		private const string DS_DataSource = "datasource";

		private const string DS_SQLParam = "sqlparam";

		private const string DS_SQLText = "sqltext";

		private const string DS_SQLQuery = "sqlquery";

		private const string DS_SQLExecute = "sqlexecute";

		private const string DS_ALL = "all";

		private const string DS_One = "one";

		private const string DS_Execute = "execute";

		private const string DS_Value = "value";

		private const string DS_Type = "type";

		private const string DS_Text = "text";

		private const string DS_List = "list";

		private const string DS_ValueHead = "[";

		private const string DS_ValueEnd = "]";

		private const string DS_Convert = "convert";

		private const string DS_From = "from";

		private const string DS_To = "to";

		private const string DS_Option = "option";

		private const string DS_Item = "item";

		private const string DS_Get = "get";

		private const string DS_Set = "set";

		private const string DS_Name = "name";

		private const string DS_FormatTime = "formattime";

		private const string DS_Exit = "exit";

		private const string DS_ErrConn = "错误:未能连接数据库";

		private const int DS_ExitFlag = -2;

		private const int DS_Normal = 0;

		private XmlDocument myDefineXML = null;

		private Hashtable myVariables = new Hashtable();

		private ZYDBConnection myDBConn;

		private IDbCommand myCmd;

		private NameValueList myQueryVariables = new NameValueList();

		private ArrayList myQueryNames = new ArrayList();

		public ZYDBConnection DBConn
		{
			get
			{
				return myDBConn;
			}
			set
			{
				myDBConn = value;
			}
		}

		public ZYDataSource()
		{
			myDBConn = ZYDBConnection.Instance;
		}

		public void ClearQueryVariables()
		{
			myQueryVariables.Clear();
		}

		public void ClearQueryNames()
		{
			myQueryNames.Clear();
		}

		public void AddQueryVariable(string strName, string strValue)
		{
			myQueryVariables.SetValue(strName, strValue);
		}

		public void RemoveQueryVariable(string strName)
		{
			myQueryVariables.Remove(strName);
		}

		public void AddQueryVariablesByXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				foreach (XmlNode childNode in RootElement.ChildNodes)
				{
					XmlElement xmlElement = childNode as XmlElement;
					if (xmlElement != null)
					{
						myQueryVariables.SetValue(xmlElement.GetAttribute("name"), xmlElement.InnerText);
					}
				}
			}
		}

		public void SaveQueryVariablesToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				for (int i = 0; i < myQueryVariables.Count; i++)
				{
					XmlElement xmlElement = RootElement.OwnerDocument.CreateElement("value");
					xmlElement.SetAttribute("name", myQueryVariables.GetName(i));
					xmlElement.InnerText = myQueryVariables.GetValue(i);
					RootElement.AppendChild(xmlElement);
				}
			}
		}

		public void AddQueryName(string strName)
		{
			if (strName != null && strName.Trim().Length > 0)
			{
				strName = strName.Trim();
				foreach (string myQueryName in myQueryNames)
				{
					if (myQueryName.Equals(strName))
					{
						return;
					}
				}
				myQueryNames.Add(strName);
			}
		}

		public XmlDocument ExecuteQuery()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = null;
			xmlDocument.LoadXml("<datasources />");
			for (int i = 0; i < myQueryVariables.Count; i++)
			{
				xmlElement = xmlDocument.CreateElement("setvalue");
				xmlElement.SetAttribute("name", myQueryVariables.GetName(i));
				xmlElement.InnerText = myQueryVariables.GetValue(i);
				xmlDocument.DocumentElement.AppendChild(xmlElement);
			}
			foreach (string myQueryName in myQueryNames)
			{
				xmlElement = xmlDocument.CreateElement("datasource");
				xmlElement.SetAttribute("name", myQueryName);
				xmlDocument.DocumentElement.AppendChild(xmlElement);
			}
			executeDataSource(xmlDocument.DocumentElement);
			return xmlDocument;
		}

		public void LoadDataSourceDefine(string strDefineFile)
		{
		}

		public string fixVariableString(string strText)
		{
			return StringCommon.fixVariableString(strText, "[", "]", myVariables);
		}

		public void executeDataSource(XmlElement myXMLElement)
		{
			try
			{
				ArrayList arrayList = new ArrayList();
				XmlNodeList childNodes = myXMLElement.ChildNodes;
				for (int i = 0; i < childNodes.Count; i++)
				{
					if (i > childNodes.Count - 1)
					{
						i = childNodes.Count - 1;
					}
					if (childNodes[i] is XmlElement)
					{
						XmlElement xmlElement = (XmlElement)childNodes[i];
						try
						{
							string name = xmlElement.Name;
							if (name.Equals("setvalue"))
							{
								myVariables[xmlElement.GetAttribute("name")] = xmlElement.InnerText;
							}
							else if (name.Equals("datasource"))
							{
								string attribute = xmlElement.GetAttribute("name");
								bool flag = false;
								foreach (string item in arrayList)
								{
									if (item.Equals(attribute))
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									myXMLElement.RemoveChild(xmlElement);
									i--;
								}
								else
								{
									arrayList.Add(attribute);
									XmlElement elementByName = XMLCommon.GetElementByName(myDefineXML.DocumentElement, attribute, Deep: true);
									elementByName = XMLCommon.GetElementByName(elementByName, "get", Deep: false);
									if (runDataSourceElement(xmlElement, elementByName) == -2)
									{
										return;
									}
								}
							}
						}
						catch (Exception ex)
						{
							xmlElement.InnerText = ex.ToString();
						}
					}
				}
			}
			catch
			{
			}
		}

		public int runDataSourceElement(XmlElement sourceElement, XmlElement defineElement)
		{
			if (sourceElement == null || defineElement == null)
			{
				return 0;
			}
			foreach (XmlNode childNode in defineElement.ChildNodes)
			{
				if (childNode is XmlElement)
				{
					XmlElement xmlElement = (XmlElement)childNode;
					string name = xmlElement.Name;
					if (name.Equals("sql"))
					{
						if (!myDBConn.isOpened())
						{
							return -2;
						}
						if (runDataSourceElement(sourceElement, xmlElement) == -2)
						{
							return -2;
						}
					}
					else if (name.Equals("sqltext"))
					{
						myCmd = myDBConn.CreateCommand();
						myCmd.CommandText = fixVariableString(xmlElement.InnerText);
					}
					else if (name.Equals("sqlparam"))
					{
						ZYDBConnection.AddParameter(myCmd, myVariables[xmlElement.GetAttribute("name")]);
					}
					else if (name.Equals("sqlquery"))
					{
						IDataReader dataReader = myCmd.ExecuteReader();
						XmlElement xmlElement2 = null;
						int fieldCount = dataReader.FieldCount;
						string text = null;
						text = xmlElement.GetAttribute("type");
						if (text == null)
						{
							text = "list";
						}
						if (text.Equals("list"))
						{
							while (dataReader.Read())
							{
								xmlElement2 = sourceElement.OwnerDocument.CreateElement("option");
								sourceElement.AppendChild(xmlElement2);
								xmlElement2.SetAttribute("value", dataReader.IsDBNull(0) ? "" : dataReader[0].ToString());
								if (dataReader.FieldCount == 1)
								{
									xmlElement2.InnerText = (dataReader.IsDBNull(0) ? "" : dataReader[0].ToString());
								}
								else
								{
									xmlElement2.InnerText = (dataReader.IsDBNull(1) ? "" : dataReader[1].ToString());
								}
							}
						}
						else if (text.Equals("text"))
						{
							if (dataReader.Read())
							{
								sourceElement.InnerText = (dataReader.IsDBNull(0) ? "" : dataReader[0].ToString());
							}
						}
						else if (text.Equals("all"))
						{
							saveResultSetToXML(sourceElement, dataReader, null, bolOneRecord: false, bolSaveToAttribute: false);
						}
						dataReader.Close();
						myCmd.Dispose();
						myCmd = null;
					}
					else if (name.Equals("convert"))
					{
						string text2 = xmlElement.GetAttribute("from");
						string text3 = xmlElement.GetAttribute("to");
						string text4 = sourceElement.InnerText;
						if (text2 == null)
						{
							text2 = "";
						}
						if (text3 == null)
						{
							text3 = "";
						}
						if (text4 == null)
						{
							text4 = "";
						}
						text4 = text4.Trim();
						if (text4.Equals(text2))
						{
							XMLCommon.ClearChildNode(sourceElement);
							sourceElement.InnerText = text3;
						}
					}
					else if (name.Equals("value"))
					{
						XMLCommon.ClearChildNode(sourceElement);
						sourceElement.InnerText = fixVariableString(xmlElement.InnerText);
					}
					else if (name.Equals("item"))
					{
						string innerText = xmlElement.InnerText;
						XmlElement xmlElement2 = sourceElement.OwnerDocument.CreateElement("option");
						sourceElement.AppendChild(xmlElement2);
						xmlElement2.SetAttribute("value", xmlElement.HasAttribute("value") ? xmlElement.GetAttribute("value") : innerText);
						xmlElement2.InnerText = innerText;
					}
					else if (name.Equals("formattime"))
					{
						string text2 = xmlElement.GetAttribute("from");
						string text3 = xmlElement.GetAttribute("to");
						string text5 = sourceElement.InnerText;
						if (text2 == null)
						{
							text2 = "";
						}
						if (text3 == null)
						{
							text3 = "";
						}
						if (text5 == null)
						{
							text5 = "";
						}
						if (text3.Length > 0 && text5.Length > 0)
						{
							sourceElement.InnerText = StringCommon.FormatDateTime(text5, text2, text3);
						}
					}
					else if (name.Equals("exit"))
					{
						return -2;
					}
				}
			}
			return 0;
		}

		public int saveResultSetToXML(XmlElement rootElement, IDataReader myReader, string strRecordName, bool bolOneRecord, bool bolSaveToAttribute)
		{
			if (rootElement == null || myReader == null)
			{
				return -1;
			}
			XmlDocument ownerDocument = rootElement.OwnerDocument;
			int num = 0;
			if (!bolOneRecord)
			{
				if (strRecordName == null || strRecordName.Trim().Length == 0)
				{
					strRecordName = "record";
				}
				strRecordName = strRecordName.Trim();
			}
			while (myReader.Read())
			{
				num++;
				XmlElement xmlElement;
				if (bolOneRecord)
				{
					xmlElement = rootElement;
				}
				else
				{
					xmlElement = ownerDocument.CreateElement(strRecordName);
					rootElement.AppendChild(xmlElement);
				}
				for (int i = 0; i < myReader.FieldCount; i++)
				{
					string text = myReader.IsDBNull(i) ? "" : myReader[i].ToString();
					if (bolSaveToAttribute)
					{
						xmlElement.SetAttribute(myReader.GetName(i).ToLower(), text);
						continue;
					}
					XmlElement xmlElement2 = ownerDocument.CreateElement(myReader.GetName(i).ToLower());
					xmlElement.AppendChild(xmlElement2);
					xmlElement2.InnerText = text;
				}
				if (bolOneRecord)
				{
					break;
				}
			}
			return num;
		}
	}
}

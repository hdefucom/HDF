using System;
using System.Data;
using System.IO;
using System.Xml;

namespace ZYCommon
{
	public class XMLHttpServer
	{
		private IDbConnection myConnection;

		public static string SessionID;

		public IDbConnection Connection
		{
			get
			{
				return myConnection;
			}
			set
			{
				myConnection = value;
			}
		}

		public static string ExecuteTestCommand(XmlDocument InputXMLDoc)
		{
			string attribute = InputXMLDoc.DocumentElement.GetAttribute("text");
			if (attribute == "[testconnection]")
			{
				if (InputXMLDoc.DocumentElement.GetAttribute("data") == "test_ok_中文测试")
				{
					return "test_ok_中文测试";
				}
				return "错误的输入编码";
			}
			return null;
		}

		public static string CreateTestCommand()
		{
			return "<xmlhttpconnection text=\"[testconnection]\" data=\"test_ok_中文测试\" />";
		}

		public string Execute(XmlDocument InputXMLDoc)
		{
			int num = 0;
			StringWriter stringWriter = null;
			XmlTextWriter xmlTextWriter = null;
			try
			{
				string attribute = InputXMLDoc.DocumentElement.GetAttribute("text");
				string attribute2 = InputXMLDoc.DocumentElement.GetAttribute("type");
				Console.WriteLine("收到命令" + InputXMLDoc.DocumentElement.OuterXml);
				string text = ExecuteTestCommand(InputXMLDoc);
				if (text != null)
				{
					return text;
				}
				stringWriter = new StringWriter();
				xmlTextWriter = new XmlTextWriter(stringWriter);
				if (InputXMLDoc.DocumentElement.GetAttribute("indent") == "1")
				{
					xmlTextWriter.Indentation = 4;
					xmlTextWriter.IndentChar = ' ';
					xmlTextWriter.Formatting = Formatting.Indented;
				}
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("xmlhttpconnection");
				xmlTextWriter.WriteAttributeString("version", "1.0");
				xmlTextWriter.WriteAttributeString("session", SessionID);
				if (myConnection != null && myConnection.State == ConnectionState.Open)
				{
					using (IDbCommand dbCommand = myConnection.CreateCommand())
					{
						dbCommand.CommandText = attribute;
						foreach (XmlNode childNode in InputXMLDoc.DocumentElement.ChildNodes)
						{
							if (childNode.Name == "param" && childNode is XmlElement)
							{
								IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
								string innerText = childNode.InnerText;
								if (innerText == "[NULL]")
								{
									dbDataParameter.Value = "";
								}
								else
								{
									dbDataParameter.Value = innerText;
								}
								dbCommand.Parameters.Add(dbDataParameter);
							}
						}
						if (attribute2 == "0")
						{
							IDataReader dataReader = dbCommand.ExecuteReader();
							int fieldCount = dataReader.FieldCount;
							for (int i = 0; i < fieldCount; i++)
							{
								xmlTextWriter.WriteAttributeString("f" + i, dataReader.GetName(i).ToLower());
							}
							while (dataReader.Read())
							{
								num++;
								xmlTextWriter.WriteStartElement("r");
								for (int i = 0; i < fieldCount; i++)
								{
									xmlTextWriter.WriteElementString("f" + i, dataReader.IsDBNull(i) ? "[NULL]" : dataReader[i].ToString());
								}
								xmlTextWriter.WriteEndElement();
							}
							dataReader.Close();
						}
						if (attribute2 == "1")
						{
							xmlTextWriter.WriteString(dbCommand.ExecuteNonQuery().ToString());
						}
					}
				}
				else
				{
					xmlTextWriter.WriteAttributeString("error", "1");
					xmlTextWriter.WriteString("数据库未打开");
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndDocument();
				xmlTextWriter.Flush();
				string text2 = stringWriter.ToString();
				xmlTextWriter.Close();
				xmlTextWriter = null;
				int num2 = text2.IndexOf("?>");
				if (num2 > 0)
				{
					text2 = text2.Substring(num2 + 2);
				}
				return text2;
			}
			catch (Exception ext)
			{
				xmlTextWriter?.Close();
				return CreateErrorMessage(ext);
			}
		}

		public static string CreateErrorMessage(Exception ext)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml("<xmlhttpconnection />");
			xmlDocument.DocumentElement.SetAttribute("error", "1");
			xmlDocument.DocumentElement.SetAttribute("session", SessionID);
			xmlDocument.DocumentElement.InnerText = ext.ToString();
			return xmlDocument.DocumentElement.OuterXml;
		}
	}
}

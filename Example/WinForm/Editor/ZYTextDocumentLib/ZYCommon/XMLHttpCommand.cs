using System;
using System.Data;
using System.Xml;

namespace ZYCommon
{
	public class XMLHttpCommand : IDbCommand, IDisposable
	{
		private const string c_NullFlag = "[NULL]";

		private CommandType intCommandType = CommandType.Text;

		private CommandBehavior intCmdBehavior = CommandBehavior.Default;

		private UpdateRowSource intUpdatedRowSource = UpdateRowSource.Both;

		private XMLHttpParameterCollection myParameters = new XMLHttpParameterCollection();

		private int intCommandTimeout = 0;

		internal bool bolCancel = false;

		private string strCommandText = null;

		private int intExecuteType = 0;

		private XMLHttpConnection myConnection = null;

		private int intExecuteState = 0;

		private XmlDocument myXMLDoc = new XmlDocument();

		public XMLHttpDBExecutingHandler ExecuteEvent = null;

		private string strHttpMethod = "POST";

		public int ExecuteState => intExecuteState;

		public string HttpMethod
		{
			get
			{
				return strHttpMethod;
			}
			set
			{
				strHttpMethod = value;
			}
		}

		public CommandType CommandType
		{
			get
			{
				return intCommandType;
			}
			set
			{
				intCommandType = value;
			}
		}

		public int CommandTimeout
		{
			get
			{
				return intCommandTimeout;
			}
			set
			{
				intCommandTimeout = value;
			}
		}

		public IDbConnection Connection
		{
			get
			{
				return myConnection;
			}
			set
			{
				myConnection = (XMLHttpConnection)value;
				myConnection.OnCancelPostData += myConnection_OnCancelPostData;
			}
		}

		public UpdateRowSource UpdatedRowSource
		{
			get
			{
				return intUpdatedRowSource;
			}
			set
			{
				intUpdatedRowSource = value;
			}
		}

		public string CommandText
		{
			get
			{
				return strCommandText;
			}
			set
			{
				strCommandText = value;
			}
		}

		public IDataParameterCollection Parameters => myParameters;

		public IDbTransaction Transaction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool FromXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				intExecuteType = StringCommon.ToInt32Value(myElement.GetAttribute("type"), 0);
				strCommandText = myElement.GetAttribute("text");
				myParameters.Clear();
				foreach (XmlNode childNode in myElement.ChildNodes)
				{
					if (childNode.Name == "param")
					{
						XmlElement xmlElement = childNode as XmlElement;
						XMLHttpParameter xMLHttpParameter = new XMLHttpParameter();
						xMLHttpParameter.ParameterName = xmlElement.GetAttribute("name");
						xMLHttpParameter.Value = xmlElement.InnerText;
						myParameters.Add(xMLHttpParameter);
					}
				}
			}
			return true;
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				myElement.SetAttribute("text", strCommandText);
				myElement.SetAttribute("type", intExecuteType.ToString());
				foreach (XMLHttpParameter myParameter in myParameters)
				{
					XmlElement xmlElement = myElement.OwnerDocument.CreateElement("param");
					myElement.AppendChild(xmlElement);
					xmlElement.SetAttribute("name", myParameter.ParameterName);
					xmlElement.InnerText = ((myParameter.Value == null) ? "[NULL]" : myParameter.Value.ToString());
				}
			}
			return true;
		}

		private bool ExecuteCommand()
		{
			myXMLDoc.LoadXml("<xmlhttpconnection />");
			ToXML(myXMLDoc.DocumentElement);
			string outerXml = myXMLDoc.DocumentElement.OuterXml;
			byte[] bytes = myConnection.SendEncod.GetBytes(outerXml);
			byte[] array = myConnection.PostData(bytes, this);
			if (bolCancel)
			{
				return false;
			}
			if (array == null)
			{
				throw new Exception("远程WEB服务器未返回任何数据");
			}
			intExecuteState = 3;
			char[] chars = myConnection.ReserveEncod.GetChars(array);
			string text = new string(chars);
			text = text.Trim();
			if (myXMLDoc == null)
			{
				myXMLDoc = new XmlDocument();
			}
			myXMLDoc.PreserveWhitespace = true;
			try
			{
				myXMLDoc.LoadXml(text);
			}
			catch (Exception innerException)
			{
				throw new Exception("远程Web数据库获得的数据格式错误!\r\n返回的数据为:" + text, innerException);
			}
			intExecuteState = 0;
			if (myXMLDoc.DocumentElement.GetAttribute("error") == "1")
			{
				throw new Exception("远程WEB数据库操作错误\r\n" + StringCommon.ClearBlankLine(myXMLDoc.DocumentElement.InnerText));
			}
			return true;
		}

		public string ExecuteString()
		{
			if (ExecuteCommand())
			{
				return myXMLDoc.DocumentElement.InnerText;
			}
			return null;
		}

		public void Cancel()
		{
			bolCancel = true;
		}

		public void Prepare()
		{
		}

		public IDataReader ExecuteReader(CommandBehavior behavior)
		{
			intCmdBehavior = behavior;
			intExecuteType = 0;
			if (ExecuteCommand())
			{
				XMLHttpReader xMLHttpReader = new XMLHttpReader();
				xMLHttpReader.FromXML(myXMLDoc.DocumentElement);
				return xMLHttpReader;
			}
			return null;
		}

		IDataReader IDbCommand.ExecuteReader()
		{
			intExecuteType = 0;
			if (ExecuteCommand())
			{
				XMLHttpReader xMLHttpReader = new XMLHttpReader();
				xMLHttpReader.FromXML(myXMLDoc.DocumentElement);
				return xMLHttpReader;
			}
			return null;
		}

		public object ExecuteScalar()
		{
			return null;
		}

		public int ExecuteNonQuery()
		{
			intExecuteType = 1;
			if (ExecuteCommand())
			{
				return Convert.ToInt32(myXMLDoc.DocumentElement.InnerText);
			}
			return -1;
		}

		public IDbDataParameter CreateParameter()
		{
			return new XMLHttpParameter();
		}

		public void Dispose()
		{
		}

		private void myConnection_OnCancelPostData(object sender, EventArgs e)
		{
			bolCancel = true;
		}
	}
}

using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Windows32;

namespace ZYCommon
{
	public class XMLHttpConnection : IDbConnection, IDisposable
	{
		private string strConnectionString = null;

		private ConnectionState intState = ConnectionState.Closed;

		private string strDataBase = null;

		private int intConnectionTimeout = 0;

		private string strIECookies = null;

		private bool bolWinInetAPI = true;

		private int intRetryNum = 3;

		private Encoding mySendEncod = null;

		private Encoding myReserveEncod = null;

		private Cookie mySessionCookie = null;

		public XMLHttpDBExecutingHandler ExecuteEvent = null;

		private string strHttpMethod = "POST";

		private WinInet myInet = new WinInet();

		public int RetryNum
		{
			get
			{
				return (intRetryNum <= 0) ? 1 : intRetryNum;
			}
			set
			{
				intRetryNum = value;
			}
		}

		public bool WinInetAPI
		{
			get
			{
				return bolWinInetAPI;
			}
			set
			{
				bolWinInetAPI = value;
			}
		}

		public Encoding SendEncod => mySendEncod;

		public Encoding ReserveEncod => myReserveEncod;

		public string IECookies
		{
			get
			{
				return strIECookies;
			}
			set
			{
				strIECookies = value;
			}
		}

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

		public ConnectionState State => intState;

		public string ConnectionString
		{
			get
			{
				return strConnectionString;
			}
			set
			{
				strConnectionString = value;
				intState = ConnectionState.Closed;
			}
		}

		public string Database => strDataBase;

		public int ConnectionTimeout => intConnectionTimeout;

		public event EventHandler OnCancelPostData = null;

		public void CancelPostData()
		{
			if (this.OnCancelPostData != null)
			{
				this.OnCancelPostData(this, null);
			}
		}

		public XMLHttpConnection()
		{
		}

		public XMLHttpConnection(string strConn)
		{
			strConnectionString = strConn;
		}

		internal HttpWebRequest CreateHttpRequest()
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strConnectionString);
			if (mySessionCookie != null)
			{
				httpWebRequest.CookieContainer = new CookieContainer();
				httpWebRequest.CookieContainer.Add(mySessionCookie);
			}
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.Method = strHttpMethod;
			return httpWebRequest;
		}

		public void ChangeDatabase(string databaseName)
		{
			strDataBase = databaseName;
		}

		public IDbTransaction BeginTransaction(IsolationLevel il)
		{
			return null;
		}

		IDbTransaction IDbConnection.BeginTransaction()
		{
			return null;
		}

		public IDbCommand CreateCommand()
		{
			XMLHttpCommand xMLHttpCommand = new XMLHttpCommand();
			xMLHttpCommand.Connection = this;
			xMLHttpCommand.ExecuteEvent = ExecuteEvent;
			xMLHttpCommand.HttpMethod = HttpMethod;
			return xMLHttpCommand;
		}

		public void Open()
		{
			intState = ConnectionState.Connecting;
			mySendEncod = Encoding.GetEncoding("gb2312");
			myReserveEncod = Encoding.GetEncoding("gb2312");
			intState = ConnectionState.Open;
		}

		public void Close()
		{
			if (bolWinInetAPI)
			{
				myInet.Close();
			}
		}

		public static ArrayList GetHttpPostEncoding(HttpPostDataHandler vPostData)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(Encoding.GetEncoding(936));
			arrayList.Add(Encoding.UTF8);
			arrayList.Add(Encoding.Unicode);
			arrayList.Add(Encoding.UTF7);
			arrayList.Add(Encoding.ASCII);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml("<xmlhttpconnection />");
			xmlDocument.DocumentElement.SetAttribute("text", "[testconnection]");
			xmlDocument.DocumentElement.SetAttribute("data", "test_ok_中文测试");
			string outerXml = xmlDocument.DocumentElement.OuterXml;
			for (int i = 0; i < arrayList.Count; i++)
			{
				byte[] bytes = (arrayList[i] as Encoding).GetBytes(outerXml);
				byte[] array = vPostData(bytes);
				if (array == null)
				{
					return null;
				}
				for (int j = 0; j < arrayList.Count; j++)
				{
					Encoding encoding = (Encoding)arrayList[j];
					char[] chars = encoding.GetChars(array);
					string text = new string(chars);
					if (text.IndexOf("test_ok_中文测试") >= 0)
					{
						ArrayList arrayList2 = new ArrayList();
						arrayList2.Add(arrayList[i]);
						arrayList2.Add(arrayList[j]);
						return arrayList2;
					}
				}
			}
			return null;
		}

		private byte[] InnerPostData(byte[] bytSend)
		{
			return PostData(bytSend, null);
		}

		public byte[] PostData(byte[] bytSend, XMLHttpCommand cmd)
		{
			for (int i = 0; i < RetryNum; i++)
			{
				if (cmd != null && cmd.bolCancel)
				{
					return null;
				}
				byte[] array;
				if (bolWinInetAPI)
				{
					array = null;
					array = ((cmd == null) ? myInet.PostData(bytSend) : myInet.PostData(bytSend, ref cmd.bolCancel));
					if (array != null)
					{
						return array;
					}
					continue;
				}
				HttpWebRequest httpWebRequest = CreateHttpRequest();
				if (mySessionCookie == null)
				{
					httpWebRequest.CookieContainer = new CookieContainer();
				}
				Stream requestStream = httpWebRequest.GetRequestStream();
				int num = 0;
				while (num < bytSend.Length && (cmd == null || !cmd.bolCancel))
				{
					if (num + 1024 > bytSend.Length)
					{
						requestStream.Write(bytSend, num, bytSend.Length - num);
						num = bytSend.Length;
					}
					else
					{
						requestStream.Write(bytSend, num, 1024);
						num += 1024;
					}
				}
				requestStream.Close();
				if (!(cmd?.bolCancel ?? false))
				{
					httpWebRequest.Abort();
					return null;
				}
				HttpWebResponse httpWebResponse = null;
				httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
				if (mySessionCookie == null)
				{
					foreach (Cookie cooky in httpWebResponse.Cookies)
					{
						if (cooky.Name.ToUpper().IndexOf("SESSION") >= 0)
						{
							mySessionCookie = cooky;
							string[] array2 = StringCommon.AnalyseStringList(strIECookies, ';', '=', AllowSameName: false);
							if (array2 != null)
							{
								for (int j = 0; j < array2.Length; j += 2)
								{
									if (mySessionCookie.Name == array2[j])
									{
										mySessionCookie.Value = array2[j + 1].Trim();
										break;
									}
								}
							}
							break;
						}
					}
				}
				if (!(cmd?.bolCancel ?? false))
				{
					httpWebRequest.Abort();
					return null;
				}
				requestStream = httpWebResponse.GetResponseStream();
				MemoryStream memoryStream = new MemoryStream(1024);
				byte[] buffer = new byte[1024];
				while (cmd == null || !cmd.bolCancel)
				{
					int num2 = requestStream.Read(buffer, 0, 1024);
					if (num2 == 0)
					{
						break;
					}
					memoryStream.Write(buffer, 0, num2);
				}
				requestStream.Close();
				httpWebResponse.Close();
				httpWebRequest.Abort();
				array = memoryStream.ToArray();
				memoryStream.Close();
				if (array != null)
				{
					return array;
				}
			}
			return null;
		}

		public override string ToString()
		{
			return "XMLHttpConnection:" + strConnectionString;
		}

		public void Dispose()
		{
			myInet.Close();
		}
	}
}

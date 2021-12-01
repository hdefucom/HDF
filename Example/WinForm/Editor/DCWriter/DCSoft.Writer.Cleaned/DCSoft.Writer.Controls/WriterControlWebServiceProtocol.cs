#define DEBUG
using DCSoft.Printing;
using DCSoft.Writer.Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器控件WEB方法控制器,DCWriter内部使用。
	///       </summary>
	[Browsable(false)]
	[ComVisible(false)]
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	[WebServiceBinding(Namespace = "http://dcwriter.cn/")]
	internal class WriterControlWebServiceProtocol : SoapHttpClientProtocol, IWriterControlWebServiceProtocol
	{
		private WebServiceServerType _ServerType = WebServiceServerType.ASPNET;

		private bool _DebugMode = false;

		private Control _OwnerUIControl = null;

		private WriterControlWebServiceProtocolForJava _Java = null;

		private bool _ASPNETServer = true;

		private WriterControlWebMethodTypes _SupportedMethods = WriterControlWebMethodTypes.Invalidate;

		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				int num = 11;
				if (value != null)
				{
					if (value.StartsWith("java:"))
					{
						base.Url = value.Substring(5);
						_ServerType = WebServiceServerType.Java;
					}
					else
					{
						base.Url = value;
						_ServerType = WebServiceServerType.ASPNET;
					}
				}
				else
				{
					base.Url = value;
				}
				Reset();
			}
		}

		/// <summary>
		///       服务器类型
		///       </summary>
		[DefaultValue(WebServiceServerType.ASPNET)]
		public WebServiceServerType ServerType
		{
			get
			{
				return _ServerType;
			}
			set
			{
				if (_ServerType != value)
				{
					_ServerType = value;
					Reset();
				}
			}
		}

		/// <summary>
		///       是否处于调试模式
		///       </summary>
		public bool DebugMode
		{
			get
			{
				return _DebugMode;
			}
			set
			{
				_DebugMode = value;
			}
		}

		internal WriterControlWebServiceProtocolForJava Java
		{
			get
			{
				int num = 5;
				if (ServerType != WebServiceServerType.Java)
				{
					throw new InvalidOperationException("没有指定 " + Url + " 为JAVA类型的WEB服务.");
				}
				if (_Java == null)
				{
					_Java = new WriterControlWebServiceProtocolForJava();
					_Java.Url = Url;
					_Java.UseDefaultCredentials = base.UseDefaultCredentials;
					_Java.UserAgent = base.UserAgent;
					_Java.AllowAutoRedirect = base.AllowAutoRedirect;
					_Java.CookieContainer = base.CookieContainer;
					_Java.Credentials = base.Credentials;
					_Java.EnableDecompression = base.EnableDecompression;
					_Java.ConnectionGroupName = base.ConnectionGroupName;
				}
				return _Java;
			}
		}

		/// <summary>
		///       服务器端是ASP.NET
		///       </summary>
		public bool ASPNETServer => _ASPNETServer;

		/// <summary>
		///       初始化对象
		///       </summary>
		internal WriterControlWebServiceProtocol(WriterControl writerControl_0)
		{
			Url = "http://localhost/asp.net/writercontrol.asmx";
			_OwnerUIControl = writerControl_0;
		}

		private void Reset()
		{
			_SupportedMethods = WriterControlWebMethodTypes.Invalidate;
		}

		/// <summary>
		///       输出调试信息
		///       </summary>
		/// <param name="txt">
		/// </param>
		private void DebugWriteLine(string string_0)
		{
			if (_DebugMode)
			{
				if (_OwnerUIControl != null && _OwnerUIControl.InvokeRequired)
				{
					EventHandler method = WriteLineForInvoke;
					_OwnerUIControl.Invoke(method, string_0, null);
				}
				else
				{
					Debug.WriteLine(string_0);
				}
			}
		}

		private void WriteLineForInvoke(object sender, EventArgs e)
		{
			Debug.WriteLine((string)sender);
		}

		protected override XmlReader GetReaderForMessage(SoapClientMessage message, int bufferSize)
		{
			return base.GetReaderForMessage(message, bufferSize);
		}

		protected override XmlWriter GetWriterForMessage(SoapClientMessage message, int bufferSize)
		{
			return base.GetWriterForMessage(message, bufferSize);
		}

		protected override WebResponse GetWebResponse(WebRequest request)
		{
			WebResponse webResponse = base.GetWebResponse(request);
			webResponse.GetResponseStream();
			return webResponse;
		}

		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public WriterControlWebMethodTypes GetSupportedMethods()
		{
			int num = 14;
			if (_SupportedMethods == WriterControlWebMethodTypes.Invalidate)
			{
				if (_Java != null)
				{
					_Java.Dispose();
					_Java = null;
				}
				if (ServerType == WebServiceServerType.ASPNET)
				{
					if (DebugMode)
					{
						DebugWriteLine("调用 " + Url + "#GetSupportedMethods");
					}
					object[] array = Invoke("GetSupportedMethods", new object[0]);
					_SupportedMethods = (WriterControlWebMethodTypes)array[0];
					if (_SupportedMethods == WriterControlWebMethodTypes.Invalidate)
					{
						_SupportedMethods = WriterControlWebMethodTypes.None;
					}
					if (DebugMode)
					{
						DebugWriteLine("返回" + _SupportedMethods);
					}
				}
				else if (ServerType == WebServiceServerType.Java)
				{
					string supportedMethods = Java.GetSupportedMethods();
					_SupportedMethods = (WriterControlWebMethodTypes)Enum.Parse(typeof(WriterControlWebMethodTypes), supportedMethods);
				}
			}
			return _SupportedMethods;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public KBLibrary GetKBLibrary()
		{
			int num = 4;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#GetKBLibrary");
			}
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array = Invoke("GetKBLibrary", new object[0]);
				return (KBLibrary)array[0];
			}
			if (ServerType == WebServiceServerType.Java)
			{
				return Java.GetKBLibrary();
			}
			return null;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ListItem[] QueryListItems(string listSourceName, string spellCode, string preText, string specifyValue)
		{
			int num = 5;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#QueryListItems?listSourceName=" + listSourceName + "&SpellCode=" + spellCode + "&PreText=" + preText + "&SpecifyValue=" + specifyValue);
			}
			ListItem[] array = null;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array2 = Invoke("QueryListItems", new object[4]
				{
					listSourceName,
					spellCode,
					preText,
					specifyValue
				});
				array = (ListItem[])array2[0];
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				array = Java.MyQueryListItems(listSourceName, spellCode, preText, specifyValue);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回" + Convert.ToString((array != null) ? array.Length : 0) + "个项目");
			}
			return array;
		}

		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ListItem[] QueryListItemsWithDocumentParameter(string listSourceName, string spellCode, string preText, string specifyValue, string documentParameters)
		{
			int num = 2;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#QueryListItemsWithDocumentParameter?listSourceName=" + listSourceName + "&SpellCode=" + spellCode + "&PreText=" + preText + "&SpecifyValue=" + specifyValue + "&documentParameters=" + documentParameters);
			}
			ListItem[] array = null;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array2 = Invoke("QueryListItemsWithDocumentParameter", new object[5]
				{
					listSourceName,
					spellCode,
					preText,
					specifyValue,
					documentParameters
				});
				array = (ListItem[])array2[0];
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				array = Java.MyQueryListItemsWithDocumentParameter(listSourceName, spellCode, preText, specifyValue, documentParameters);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回" + Convert.ToString((array != null) ? array.Length : 0) + "个项目");
			}
			return array;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string[] QueryAssistInputItems(string preWord)
		{
			int num = 0;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#QueryAssistInputItems?PreWord=" + preWord);
			}
			string[] array = null;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array2 = Invoke("QueryAssistInputItems", new object[1]
				{
					preWord
				});
				array = (string[])array2[0];
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				array = Java.QueryAssistInputItems(preWord);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回" + Convert.ToString((array != null) ? array.Length : 0) + "个项目");
			}
			return array;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool SaveFileContent(string fileName, string fileSystemName, string fileFormat, [XmlElement(DataType = "base64Binary")] byte[] fileContent)
		{
			int num = 11;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#SaveFileContent?FileName=" + fileName + "&FileFormat=" + fileFormat + "&BytesLength=" + Convert.ToString((fileContent != null) ? fileContent.Length : 0));
			}
			bool flag = false;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array = Invoke("SaveFileContent", new object[4]
				{
					fileName,
					fileSystemName,
					fileFormat,
					fileContent
				});
				flag = (bool)array[0];
			}
			else
			{
				flag = Java.SaveFileContent(fileName, fileSystemName, fileFormat, fileContent);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回 " + flag);
			}
			return flag;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool SaveFileContentForAutoSave(string fileName, string fileSystemName, string fileFormat, [XmlElement(DataType = "base64Binary")] byte[] fileContent)
		{
			int num = 0;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#SaveFileContentForAutoSave?FileName=" + fileName + "&FileFormat=" + fileFormat + "&BytesLength=" + Convert.ToString((fileContent != null) ? fileContent.Length : 0));
			}
			bool flag = false;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array = Invoke("SaveFileContentForAutoSave", new object[4]
				{
					fileName,
					fileSystemName,
					fileFormat,
					fileContent
				});
				flag = (bool)array[0];
			}
			else
			{
				flag = Java.SaveFileContentForAutoSave(fileName, fileSystemName, fileFormat, fileContent);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回 " + flag);
			}
			return flag;
		}

		/// <remarks />
		[SoapDocumentMethod("http://dcwriter.cn/ReadFileContent", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement(DataType = "base64Binary")]
		public byte[] ReadFileContent(string fileName, string fileSystemName)
		{
			int num = 2;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#ReadFileContent?FileName=" + fileName + "&FileSystemName=" + fileSystemName);
			}
			byte[] array = null;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array2 = Invoke("ReadFileContent", new object[2]
				{
					fileName,
					fileSystemName
				});
				array = (byte[])array2[0];
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				array = Java.ReadFileContent(fileName, fileSystemName);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回字节数 " + Convert.ToString((array != null) ? array.Length : 0));
			}
			return array;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool UIStartEditContent(string documentID)
		{
			int num = 3;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#UIStartEditContent?DocumentID=" + documentID);
			}
			bool flag = false;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array = Invoke("UIStartEditContent", new object[1]
				{
					documentID
				});
				flag = (bool)array[0];
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				flag = Java.UIStartEditContent(documentID);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回 " + flag);
			}
			return flag;
		}

		/// <remarks />
		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public void ReportError(int errorCode, string message, string details)
		{
			int num = 12;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#ReportError?ErrorCode=" + errorCode + "&Message=" + message);
			}
			if (ServerType == WebServiceServerType.ASPNET)
			{
				Invoke("ReportError", new object[3]
				{
					errorCode,
					message,
					details
				});
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				Java.ReportError(errorCode, message, details);
			}
		}

		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public void ButtonClick(string elementID, string commandName)
		{
			int num = 6;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#ButtonClick?ElementID=" + elementID + "&CommandName=" + commandName);
			}
			if (ServerType == WebServiceServerType.ASPNET)
			{
				Invoke("ButtonClick", new object[2]
				{
					elementID,
					commandName
				});
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				Java.ButtonClick(elementID, commandName);
			}
		}

		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public void DocumentPrinted(string documentID, PrintResultStates states, int printedPages, string message)
		{
			int num = 10;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#DocumentPrinted?DocumentID=" + documentID + "&States=" + states);
			}
			if (ServerType == WebServiceServerType.ASPNET)
			{
				Invoke("DocumentPrinted", new object[4]
				{
					documentID,
					states,
					printedPages,
					message
				});
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				Java.DocumentPrinted(documentID, states, printedPages, message);
			}
		}

		[SoapDocumentMethod(RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string BeforePlayMedia(string documentID, string elementID, string sourceFileName)
		{
			int num = 7;
			if (DebugMode)
			{
				DebugWriteLine("调用 " + Url + "#BeforePlayMedia?documentID=" + documentID + "&elementID=" + elementID + "&sourceFileName" + sourceFileName);
			}
			string text = null;
			if (ServerType == WebServiceServerType.ASPNET)
			{
				object[] array = Invoke("BeforePlayMedia", new object[3]
				{
					documentID,
					elementID,
					sourceFileName
				});
				text = (string)array[0];
			}
			else if (ServerType == WebServiceServerType.Java)
			{
				text = Java.BeforePlayMedia(documentID, elementID, sourceFileName);
			}
			if (DebugMode)
			{
				DebugWriteLine("返回 " + text);
			}
			return text;
		}
	}
}

using DCSoft.Printing;
using DCSoft.Writer.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器控件WEB方法控制器,DCWriter内部使用。
	///       </summary>
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	[WebServiceBinding(Name = "DCWriterServiceSoap", Namespace = "http://dcwriter.cn/")]
	[Browsable(false)]
	[ComVisible(false)]
	internal class WriterControlWebServiceProtocolForJava : SoapHttpClientProtocol
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		internal WriterControlWebServiceProtocolForJava()
		{
		}

		protected override XmlReader GetReaderForMessage(SoapClientMessage message, int bufferSize)
		{
			return base.GetReaderForMessage(message, bufferSize);
		}

		protected override XmlWriter GetWriterForMessage(SoapClientMessage message, int bufferSize)
		{
			return base.GetWriterForMessage(message, bufferSize);
		}

		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public string GetSupportedMethods()
		{
			object[] array = Invoke("GetSupportedMethods", new object[0]);
			return (string)array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public KBLibrary GetKBLibrary()
		{
			object[] array = Invoke("GetKBLibrary", new object[0]);
			return (KBLibrary)array[0];
		}

		internal ListItem[] MyQueryListItemsWithDocumentParameter(string listSourceName, string spellCode, string preText, string specifyValue, string documentParameters)
		{
			WriterControlWebServiceProtocolForJavaListItem[] array = QueryListItemsWithDocumentParameter(listSourceName, spellCode, preText, specifyValue, documentParameters);
			if (array != null)
			{
				List<ListItem> list = new List<ListItem>();
				WriterControlWebServiceProtocolForJavaListItem[] array2 = array;
				foreach (WriterControlWebServiceProtocolForJavaListItem writerControlWebServiceProtocolForJavaListItem in array2)
				{
					list.Add(writerControlWebServiceProtocolForJavaListItem.CreateItem());
				}
				return list.ToArray();
			}
			return null;
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public WriterControlWebServiceProtocolForJavaListItem[] QueryListItemsWithDocumentParameter([XmlElement(Form = XmlSchemaForm.Unqualified)] string listSourceName, [XmlElement(Form = XmlSchemaForm.Unqualified)] string spellCode, [XmlElement(Form = XmlSchemaForm.Unqualified)] string preText, [XmlElement(Form = XmlSchemaForm.Unqualified)] string specifyValue, [XmlElement(Form = XmlSchemaForm.Unqualified)] string documentParameters)
		{
			object[] array = Invoke("QueryListItemsWithDocumentParameter", new object[5]
			{
				listSourceName,
				spellCode,
				preText,
				specifyValue,
				documentParameters
			});
			return (WriterControlWebServiceProtocolForJavaListItem[])array[0];
		}

		internal ListItem[] MyQueryListItems(string listSourceName, string spellCode, string preText, string specifyValue)
		{
			WriterControlWebServiceProtocolForJavaListItem[] array = QueryListItems(listSourceName, spellCode, preText, specifyValue);
			if (array != null)
			{
				List<ListItem> list = new List<ListItem>();
				WriterControlWebServiceProtocolForJavaListItem[] array2 = array;
				foreach (WriterControlWebServiceProtocolForJavaListItem writerControlWebServiceProtocolForJavaListItem in array2)
				{
					list.Add(writerControlWebServiceProtocolForJavaListItem.CreateItem());
				}
				return list.ToArray();
			}
			return null;
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public WriterControlWebServiceProtocolForJavaListItem[] QueryListItems([XmlElement(Form = XmlSchemaForm.Unqualified)] string listSourceName, [XmlElement(Form = XmlSchemaForm.Unqualified)] string spellCode, [XmlElement(Form = XmlSchemaForm.Unqualified)] string preText, [XmlElement(Form = XmlSchemaForm.Unqualified)] string specifyValue)
		{
			object[] array = Invoke("QueryListItems", new object[4]
			{
				listSourceName,
				spellCode,
				preText,
				specifyValue
			});
			return (WriterControlWebServiceProtocolForJavaListItem[])array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public string[] QueryAssistInputItems(string preWord)
		{
			object[] array = Invoke("QueryAssistInputItems", new object[1]
			{
				preWord
			});
			return (string[])array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public bool SaveFileContent(string fileName, string fileSystemName, string fileFormat, [XmlElement(DataType = "base64Binary")] byte[] fileContent)
		{
			object[] array = Invoke("SaveFileContent", new object[4]
			{
				fileName,
				fileSystemName,
				fileFormat,
				fileContent
			});
			return (bool)array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public bool SaveFileContentForAutoSave(string fileName, string fileSystemName, string fileFormat, [XmlElement(DataType = "base64Binary")] byte[] fileContent)
		{
			object[] array = Invoke("SaveFileContentForAutoSave", new object[4]
			{
				fileName,
				fileSystemName,
				fileFormat,
				fileContent
			});
			return (bool)array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", DataType = "base64Binary")]
		public byte[] ReadFileContent(string fileName, string fileSystemName)
		{
			object[] array = Invoke("ReadFileContent", new object[2]
			{
				fileName,
				fileSystemName
			});
			return (byte[])array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public bool UIStartEditContent(string documentID)
		{
			object[] array = Invoke("UIStartEditContent", new object[1]
			{
				documentID
			});
			return (bool)array[0];
		}

		/// <remarks />
		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public void ReportError(int errorCode, string message, string details)
		{
			Invoke("ReportError", new object[3]
			{
				errorCode,
				message,
				details
			});
		}

		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public void ButtonClick(string elementID, string commandName)
		{
			Invoke("ButtonClick", new object[2]
			{
				elementID,
				commandName
			});
		}

		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public void DocumentPrinted(string documentID, PrintResultStates states, int printedPages, string message)
		{
			Invoke("DocumentPrinted", new object[4]
			{
				documentID,
				states,
				printedPages,
				message
			});
		}

		[SoapDocumentMethod(Action = "", RequestNamespace = "http://dcwriter.cn", ResponseNamespace = "http://dcwriter.cn", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public string BeforePlayMedia(string documentID, string elementID, string sourceFileName)
		{
			object[] array = Invoke("BeforePlayMedia", new object[3]
			{
				documentID,
				elementID,
				sourceFileName
			});
			return (string)array[0];
		}
	}
}

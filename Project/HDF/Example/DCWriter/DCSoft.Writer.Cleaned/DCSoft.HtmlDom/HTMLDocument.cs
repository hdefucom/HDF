using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace DCSoft.HtmlDom
{
	[ComVisible(false)]
	public class HTMLDocument : GClass164
	{
		protected GClass233 myWriteOptions = new GClass233();

		private bool bolLoadingFlag = false;

		private string strBaseURL = null;

		private string strLocation;

		private GClass228 _AllStyles = null;

		private string strCharSet = "gb2312";

		private bool _PreserveWhitespace = false;

		public GClass233 WriteOptions
		{
			get
			{
				return myWriteOptions;
			}
			set
			{
				myWriteOptions = value;
				value?.method_1(this);
			}
		}

		public string BaseURL
		{
			get
			{
				return strBaseURL;
			}
			set
			{
				strBaseURL = value;
				FixBaseUrl();
			}
		}

		public string Location
		{
			get
			{
				return strLocation;
			}
			set
			{
				strLocation = value;
			}
		}

		internal bool LoadingFlag => bolLoadingFlag;

		public override string TagName => "HTML";

		[Browsable(false)]
		public GClass228 AllStyles
		{
			get
			{
				if (_AllStyles == null)
				{
					_AllStyles = new GClass228();
					foreach (GClass163 allElement in AllElements)
					{
						if (allElement is GClass212)
						{
							_AllStyles.method_6(allElement);
						}
					}
				}
				return _AllStyles;
			}
		}

		public GClass228 AllElements
		{
			get
			{
				GClass228 gClass = new GClass228();
				vmethod_18(gClass);
				return gClass;
			}
		}

		public GClass194 Body
		{
			get
			{
				foreach (object item in gclass228_0)
				{
					if (item is GClass194)
					{
						return (GClass194)item;
					}
				}
				return null;
			}
		}

		public GClass191 Head
		{
			get
			{
				foreach (object item in gclass228_0)
				{
					if (item is GClass191)
					{
						return (GClass191)item;
					}
				}
				return null;
			}
		}

		public string Title
		{
			get
			{
				GClass191 head = Head;
				if (head != null)
				{
					foreach (GClass163 item in head.vmethod_2())
					{
						if (item is GClass197)
						{
							return item.vmethod_4();
						}
					}
				}
				return strLocation;
			}
			set
			{
				GClass191 head = Head;
				if (head != null)
				{
					foreach (GClass163 item in head.vmethod_2())
					{
						if (item is GClass197)
						{
							item.vmethod_5(value);
							break;
						}
					}
				}
			}
		}

		public override string InnerText
		{
			get
			{
				if (Body == null)
				{
					return null;
				}
				StringBuilder stringBuilder = new StringBuilder();
				Body.vmethod_20(stringBuilder);
				string s = stringBuilder.ToString();
				return HttpUtility.HtmlDecode(s);
			}
		}

		public string CharSet
		{
			get
			{
				return strCharSet;
			}
			set
			{
				strCharSet = value;
			}
		}

		public bool PreserveWhitespace
		{
			get
			{
				return _PreserveWhitespace;
			}
			set
			{
				_PreserveWhitespace = value;
			}
		}

		public static void About()
		{
			string text = "XDesignerHTMLDom 是 DCSoft 于2006年5月16号发布的实现了HTML文档对象模型的库，特点为：\r\n   1 运行在微软 DOTNET1.1 的环境下，不依赖其他非标准库。\r\n   2 可解析静态HTML并生成文档对象模型树，不支持动态HTML。\r\n   3 可处理某些劣质的HTML文档。\r\n   4 不严格遵守HTML相关国际标准。\r\n   5 可将结构保存到XML或XSLT文件中。\r\n   6 一般可用于对静态HTML文档的结构化分析处理。\r\n更多信息请访问 http://xdesigner.cnblogs.com";
			MessageBox.Show(null, text, "关于XDesignerHTMLDom", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public HTMLDocument()
		{
			htmldocument_0 = this;
			myWriteOptions.method_1(this);
		}

		public HTMLDocument(byte[] byte_0, string contentEncoding)
		{
			htmldocument_0 = this;
			myWriteOptions.method_1(this);
			if (byte_0 != null)
			{
				Encoding encoding = Encoding.GetEncoding(936);
				if (contentEncoding != null && contentEncoding.Trim().Length > 0)
				{
					encoding = Encoding.GetEncoding(contentEncoding);
				}
				string @string = encoding.GetString(byte_0);
				try
				{
					CharSet = encoding.BodyName;
					LoadHTML(@string);
				}
				catch (GException14)
				{
					try
					{
						encoding = Encoding.GetEncoding(CharSet);
					}
					catch
					{
						encoding = Encoding.GetEncoding(936);
					}
					@string = encoding.GetString(byte_0);
					LoadHTML(@string);
				}
			}
		}

		private void FixBaseUrl()
		{
			int num = 9;
			if (strBaseURL != null)
			{
				strBaseURL = strBaseURL.Trim();
				while (strBaseURL.EndsWith("/") || strBaseURL.EndsWith("\\"))
				{
					strBaseURL = strBaseURL.Substring(0, strBaseURL.Length - 1).Trim();
				}
			}
		}

		public GClass163 GetElementById(string vID)
		{
			if (Body != null)
			{
				return Body.vmethod_19(vID);
			}
			return null;
		}

		public GClass228 GetElementsByName(string vName)
		{
			GClass228 gClass = new GClass228();
			if (Body != null)
			{
				Body.vmethod_17(vName, gClass);
			}
			return gClass;
		}

		public GClass228 GetElementsByTagName(string vName)
		{
			GClass228 gClass = new GClass228();
			if (Body != null)
			{
				Body.vmethod_16(vName, gClass);
			}
			return gClass;
		}

		internal override bool CheckChildTagName(string strName)
		{
			return true;
		}

		private bool PrivateCheckChildTagName(string strName)
		{
			int num = 18;
			int result;
			switch (strName)
			{
			default:
				result = ((strName == "XML") ? 1 : 0);
				break;
			case "HEAD":
			case "BODY":
			case "SCRIPT":
			case "STYLE":
			case "FRAMESET":
			case "NOFRAMES":
			case "NOSCRIPT":
			case "#comment":
				result = 1;
				break;
			}
			return (byte)result != 0;
		}

		public bool LoadBinary(byte[] bsByte)
		{
			bool flag = false;
			CharSet = Encoding.Default.WebName;
			Encoding encoding = Encoding.GetEncoding(CharSet);
			string @string = encoding.GetString(bsByte);
			try
			{
				return LoadHTML(@string);
			}
			catch (GException14)
			{
				encoding = Encoding.GetEncoding(CharSet);
				@string = encoding.GetString(bsByte);
				return LoadHTML(@string);
			}
		}

		public bool Load(TextReader reader)
		{
			int num = 10;
			string text = reader.ReadToEnd();
			if (text == null)
			{
				return false;
			}
			text = text.Trim();
			if (text.StartsWith("Version:"))
			{
				StringReader stringReader = new StringReader(text);
				for (int i = 0; i < 10; i++)
				{
					string text2 = stringReader.ReadLine();
					if (text2 == null)
					{
						break;
					}
					if (!text2.StartsWith("SourceURL:"))
					{
						continue;
					}
					string text3 = text2.Substring(10);
					if (string.IsNullOrEmpty(text3))
					{
						break;
					}
					if (text3.EndsWith("/"))
					{
						strBaseURL = text3;
					}
					else
					{
						int num2 = text3.LastIndexOf("/");
						strBaseURL = text3.Substring(0, num2 + 1);
						if (string.Compare(strBaseURL, "http://", ignoreCase: true) == 0 || string.Compare(strBaseURL, "https://", ignoreCase: true) == 0 || string.Compare(strBaseURL, "ftp://", ignoreCase: true) == 0)
						{
							strBaseURL = text3;
						}
					}
					FixBaseUrl();
					break;
				}
				byte[] bytes = Encoding.Default.GetBytes(text);
				string @string = Encoding.UTF8.GetString(bytes);
				@string = @string.Replace("\ufffd?", "<");
				text = @string;
			}
			CharSet = Encoding.Default.WebName;
			bolLoadingFlag = true;
			Class171 @class = new Class171(text);
			@class.method_1(bool_1: false);
			bool result = Read(@class);
			bolLoadingFlag = false;
			return result;
		}

		public bool Load(Stream stream)
		{
			method_8().Clear();
			vmethod_2().method_8();
			MemoryStream memoryStream = new MemoryStream();
			byte[] array = new byte[1024];
			while (true)
			{
				int num = stream.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			memoryStream.Close();
			array = memoryStream.ToArray();
			return LoadBinary(array);
		}

		public bool LoadUrl(string strUrl)
		{
			int num = 3;
			gclass242_0.Clear();
			gclass228_0.method_8();
			Uri uri = new Uri(strUrl);
			byte[] array = null;
			if (uri.Scheme == Uri.UriSchemeFile)
			{
				string localPath = uri.LocalPath;
				if (!File.Exists(localPath))
				{
					throw new FileNotFoundException(localPath);
				}
				FileInfo fileInfo = new FileInfo(localPath);
				array = new byte[fileInfo.Length];
				using (FileStream fileStream = new FileStream(localPath, FileMode.Open, FileAccess.Read))
				{
					fileStream.Read(array, 0, array.Length);
				}
			}
			else
			{
				using (WebClient webClient = new WebClient())
				{
					array = webClient.DownloadData(strUrl);
				}
			}
			if (array == null || array.Length == 0)
			{
				return false;
			}
			if (LoadBinary(array))
			{
				if (strUrl.EndsWith("/"))
				{
					strBaseURL = strUrl;
				}
				else
				{
					int num2 = strUrl.LastIndexOf("/");
					strBaseURL = strUrl.Substring(0, num2 + 1);
					if (string.Compare(strBaseURL, "http://", ignoreCase: true) == 0 || string.Compare(strBaseURL, "https://", ignoreCase: true) == 0 || string.Compare(strBaseURL, "ftp://", ignoreCase: true) == 0)
					{
						strBaseURL = strUrl;
					}
				}
				FixBaseUrl();
				return true;
			}
			return false;
		}

		public string GetAbsoluteURL(string strURL)
		{
			string text = strURL;
			if (text.IndexOf("://") > 0 || string.IsNullOrEmpty(BaseURL))
			{
				return Class172.smethod_1(text);
			}
			Uri uri = new Uri(strBaseURL);
			text = ((!(uri.Scheme == Uri.UriSchemeFile)) ? new Uri(uri, text).AbsoluteUri : Path.Combine(uri.LocalPath, text));
			return Class172.smethod_1(text);
		}

		public bool Load(string strFile)
		{
			bolLoadingFlag = true;
			StreamReader streamReader = new StreamReader(strFile, Encoding.Default);
			string string_ = streamReader.ReadToEnd();
			streamReader.Close();
			Class171 myReader = new Class171(string_);
			bool result = Read(myReader);
			bolLoadingFlag = false;
			strLocation = strFile;
			return result;
		}

		public bool LoadHTML(string strHTML)
		{
			bolLoadingFlag = true;
			Class171 myReader = new Class171(strHTML);
			bool result = Read(myReader);
			bolLoadingFlag = false;
			return result;
		}

		internal string CompressWhitespace(string string_0)
		{
			if (PreserveWhitespace)
			{
				return string_0;
			}
			string_0 = string_0.Trim();
			string_0 = Class172.smethod_0(string_0);
			return string_0;
		}

		public override bool AppendChild(GClass163 gclass163_0)
		{
			if (gclass163_0 == this)
			{
				return true;
			}
			if (PrivateCheckChildTagName(gclass163_0.TagName))
			{
				return base.AppendChild(gclass163_0);
			}
			foreach (GClass163 item in gclass228_0)
			{
				if (item is GClass164)
				{
					GClass164 gClass2 = (GClass164)item;
					if (gClass2.vmethod_13(gclass163_0))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal override bool Read(Class171 myReader)
		{
			gclass242_0.Clear();
			gclass228_0.method_8();
			GClass163 gClass = new GClass191();
			gClass.method_40(this);
			gClass.method_7(this);
			gclass228_0.method_6(gClass);
			gClass = new GClass194();
			gClass.method_40(this);
			gClass.method_7(this);
			((GClass194)gClass).method_51(bool_1: false);
			gclass228_0.method_6(gClass);
			vmethod_10(myReader);
			bool result = vmethod_11(myReader);
			vmethod_1();
			return result;
		}

		public bool Write(string strFileName)
		{
			using (FileStream w = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(w, Encoding.UTF8);
				xmlTextWriter.Indentation = 4;
				xmlTextWriter.IndentChar = ' ';
				xmlTextWriter.Formatting = Formatting.Indented;
				bool result = Write(xmlTextWriter);
				xmlTextWriter.Close();
				return result;
			}
		}

		public XmlDocument CreateXMLDocument()
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			Write(xmlTextWriter);
			xmlTextWriter.Close();
			string xml = stringWriter.ToString();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			return xmlDocument;
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 8;
			if (myWriteOptions.bool_0)
			{
				myWriter.WriteStartElement("xsl:stylesheet");
				myWriter.WriteAttributeString("xmlns:xsl", "http://www.w3.org/1999/XSL/Transform");
				myWriter.WriteAttributeString("version", "1.0");
				myWriter.WriteStartElement("xsl:template");
				myWriter.WriteAttributeString("match", "/*");
				bool result = base.Write(myWriter);
				myWriter.WriteEndElement();
				myWriter.WriteEndElement();
				return result;
			}
			return base.Write(myWriter);
		}

		public GClass163 CreateElement(string TagName)
		{
			return InnerCreateElement(TagName, null);
		}

		internal GClass163 InnerCreateElement(string TagName, GClass164 vParent)
		{
			int num = 10;
			if (Class171.smethod_4(TagName))
			{
				return null;
			}
			GClass163 gClass = null;
			TagName = TagName.ToUpper().Trim();
			switch (TagName)
			{
			case "HTML":
				gClass = ((vParent != null && vParent != this) ? ((GClass164)new GClass189()) : ((GClass164)this));
				break;
			case "HEAD":
				if (vParent is HTMLDocument)
				{
					gClass = Head;
					if (gClass == null)
					{
						gClass = new GClass191();
					}
				}
				break;
			case "BODY":
				if (vParent is HTMLDocument)
				{
					gClass = Body;
					if (gClass == null)
					{
						gClass = new GClass194();
					}
					((GClass194)gClass).method_51(bool_1: true);
				}
				else
				{
					gClass = new GClass189();
				}
				break;
			case "ie:devicerect":
				gClass = new GClass171();
				break;
			case "ie:headerfooter":
				gClass = new GClass213();
				break;
			case "ie:layoutrect":
				gClass = new GClass199();
				break;
			case "ie:templateprinter":
				gClass = new GClass206();
				break;
			case "H1":
				gClass = new GClass188();
				((GClass188)gClass).method_51(1);
				break;
			case "H2":
				gClass = new GClass188();
				((GClass188)gClass).method_51(2);
				break;
			case "H3":
				gClass = new GClass188();
				((GClass188)gClass).method_51(3);
				break;
			case "H4":
				gClass = new GClass188();
				((GClass188)gClass).method_51(4);
				break;
			case "H5":
				gClass = new GClass188();
				((GClass188)gClass).method_51(5);
				break;
			case "H6":
				gClass = new GClass188();
				((GClass188)gClass).method_51(6);
				break;
			case "INPUT":
				gClass = new GClass198();
				break;
			case "TEXTAREA":
				gClass = new GClass217();
				break;
			case "SELECT":
				gClass = new GClass170();
				break;
			case "OPTION":
				gClass = new GClass209();
				break;
			case "FORM":
				gClass = new GClass165();
				break;
			case "A":
				gClass = new GClass176();
				break;
			case "B":
				gClass = new GClass168();
				break;
			case "PRE":
				gClass = new GClass193();
				break;
			case "SPAN":
				gClass = new GClass186();
				break;
			case "DIV":
				gClass = new GClass189();
				break;
			case "P":
				gClass = new GClass179();
				break;
			case "BR":
				gClass = new GClass211();
				break;
			case "APPLET":
				gClass = new GClass178();
				break;
			case "#text":
				gClass = new GClass216();
				break;
			case "OBJECT":
				gClass = new GClass187();
				break;
			case "SCRIPT":
				gClass = new GClass205();
				break;
			case "LINK":
				gClass = new GClass210();
				break;
			case "FONT":
				gClass = new GClass181();
				break;
			case "META":
				gClass = new GClass201();
				break;
			case "GBSOUND":
				gClass = new GClass218();
				break;
			case "PARAM":
				gClass = new GClass200();
				break;
			case "#comment":
				gClass = new GClass215();
				break;
			case "HR":
				gClass = new GClass202();
				break;
			case "TABLE":
				gClass = new GClass185();
				break;
			case "TBODY":
				gClass = new GClass173();
				break;
			case "TR":
				gClass = new GClass190();
				break;
			case "TD":
				gClass = new GClass172();
				break;
			case "COL":
				gClass = new GClass203();
				break;
			case "STYLE":
				gClass = new GClass212();
				break;
			case "IMG":
				gClass = new GClass204();
				break;
			case "TITLE":
				gClass = new GClass197();
				break;
			case "UL":
				gClass = new GClass166();
				break;
			case "LI":
				gClass = new GClass175();
				break;
			case "MAP":
				gClass = new GClass174();
				break;
			case "AREA":
				gClass = new GClass195();
				break;
			case "hta:application":
				gClass = new GClass208();
				break;
			case "FRAMESET":
				gClass = new GClass184();
				break;
			case "FRAME":
				gClass = new GClass207();
				break;
			case "LABEL":
				gClass = new GClass180();
				break;
			case "MARQUEE":
				gClass = new GClass182();
				break;
			case "IFRAME":
				gClass = new GClass196();
				break;
			case "XML":
				gClass = new GClass214();
				break;
			case "SUP":
				gClass = new GClass169();
				break;
			case "SUB":
				gClass = new GClass183();
				break;
			case "NOBR":
				gClass = new GClass167();
				break;
			case "COLGROUP":
				gClass = new GClass192();
				break;
			default:
				gClass = new GClass177();
				((GClass177)gClass).method_50(TagName);
				break;
			}
			if (gClass != null)
			{
				gClass.method_7(this);
				gClass.method_40(vParent);
			}
			return gClass;
		}
	}
}

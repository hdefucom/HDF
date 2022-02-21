using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       文档视图模式,DCWriter内部使用
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	
	public class DocumentViewState
	{
		public const string ViewStateElementID = "DCDocumentViewState";

		private string _ScriptText;

		private ScriptLanguageType _ScriptLanguage;

		private RepeatedImageValueList _RepeatedImages;

		private MotherTemplateInfo _MotherTemplate;

		private LocalConfig _LocalConfig;

		private XPageSettings _PageSettings;

		private DocumentOptions _Options;

		private DocumentInfo _Info;

		/// <summary>
		///       VBA脚本代码
		///       </summary>
		[DefaultValue(null)]
		public string ScriptText
		{
			get
			{
				return _ScriptText;
			}
			set
			{
				_ScriptText = value;
			}
		}

		[DefaultValue(ScriptLanguageType.VBNET)]
		public ScriptLanguageType ScriptLanguage
		{
			get
			{
				return _ScriptLanguage;
			}
			set
			{
				_ScriptLanguage = value;
			}
		}

		/// <summary>
		///       重复引用的图片对象,DCWriter内部使用。
		///       </summary>
		[DefaultValue(null)]
		[XmlArrayItem("Image", typeof(RepeatedImageValue))]
		[Browsable(true)]
		public RepeatedImageValueList RepeatedImages
		{
			get
			{
				if (_RepeatedImages == null)
				{
					_RepeatedImages = new RepeatedImageValueList();
				}
				return _RepeatedImages;
			}
			set
			{
				_RepeatedImages = value;
			}
		}

		/// <summary>
		///       文档母版信息
		///       </summary>
		[DefaultValue(null)]
		public MotherTemplateInfo MotherTemplate
		{
			get
			{
				return _MotherTemplate;
			}
			set
			{
				_MotherTemplate = value;
			}
		}

		/// <summary>
		///       本地设置
		///       </summary>
		public LocalConfig LocalConfig
		{
			get
			{
				return _LocalConfig;
			}
			set
			{
				_LocalConfig = value;
			}
		}

		/// <summary>
		///       页面设置
		///       </summary>
		public XPageSettings PageSettings
		{
			get
			{
				return _PageSettings;
			}
			set
			{
				_PageSettings = value;
			}
		}

		/// <summary>
		///       文档选项
		///       </summary>
		public DocumentOptions Options
		{
			get
			{
				return _Options;
			}
			set
			{
				_Options = value;
			}
		}

		/// <summary>
		///       文档信息
		///       </summary>
		public DocumentInfo Info
		{
			get
			{
				return _Info;
			}
			set
			{
				_Info = value;
			}
		}

		public static string GetViewStateString(XTextDocument document)
		{
			int num = 18;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			XTextDocument xTextDocument = document.method_89();
			xTextDocument.Body.Elements.Clear();
			xTextDocument.Options = document.Options.Clone();
			xTextDocument.Options.BehaviorOptions.OutputFormatedXMLSource = false;
			xTextDocument.Options.BehaviorOptions.EnableCompressUserHistories = false;
			MemoryStream memoryStream = new MemoryStream();
			xTextDocument.Save(memoryStream, "xml");
			byte[] byte_ = memoryStream.ToArray();
			byte[] inArray = FileHelper.GZipCompress(byte_);
			return Convert.ToBase64String(inArray);
		}

		public static bool LoadViewStateString(XTextDocument document, string Value)
		{
			int num = 7;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (string.IsNullOrEmpty(Value))
			{
				return false;
			}
			byte[] byte_ = Convert.FromBase64String(Value);
			byte[] buffer = FileHelper.GZipDecompress(byte_);
			MemoryStream stream = new MemoryStream(buffer);
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.Load(stream, "xml");
			document.method_126(xTextDocument, bool_32: true);
			document.Body.Elements.Clear();
			document.Body.Elements.bool_0 = false;
			document.Comments.Clear();
			document.FixDomState();
			return true;
		}

		public DocumentViewState()
		{
			_ScriptText = null;
			_ScriptLanguage = ScriptLanguageType.VBNET;
			_RepeatedImages = null;
			_MotherTemplate = null;
			_LocalConfig = null;
			_PageSettings = null;
			_Options = null;
			_Info = null;
			
		}

		public DocumentViewState(XTextDocument document)
		{
			int num = 1;
			_ScriptText = null;
			_ScriptLanguage = ScriptLanguageType.VBNET;
			_RepeatedImages = null;
			_MotherTemplate = null;
			_LocalConfig = null;
			_PageSettings = null;
			_Options = null;
			_Info = null;
			
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			_PageSettings = document.PageSettings;
			_Options = document.Options;
			_Info = document.Info;
			_LocalConfig = document.LocalConfig;
			_MotherTemplate = document.MotherTemplate;
			_RepeatedImages = document.RepeatedImages;
			_ScriptText = document.ScriptText;
			_ScriptLanguage = document.ScriptLanguage;
		}

		public void WriteToDocument(XTextDocument document)
		{
			int num = 0;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			document.PageSettings = _PageSettings;
			document.Options = Options;
			document.Info = Info;
			document.LocalConfig = LocalConfig;
			document.MotherTemplate = MotherTemplate;
			document.RepeatedImages = RepeatedImages;
			document.ScriptText = ScriptText;
			document.ScriptLanguage = ScriptLanguage;
		}

		public string ToSerializeString()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, this);
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			return Convert.ToBase64String(inArray);
		}

		public void FromSerializeString(string base64String)
		{
			byte[] buffer = Convert.FromBase64String(base64String);
			MemoryStream memoryStream = new MemoryStream(buffer);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			DocumentViewState documentViewState = (DocumentViewState)binaryFormatter.Deserialize(memoryStream);
			memoryStream.Close();
			_Info = documentViewState._Info;
			_LocalConfig = documentViewState._LocalConfig;
			_MotherTemplate = documentViewState._MotherTemplate;
			_Options = documentViewState._Options;
			_PageSettings = documentViewState._PageSettings;
			_RepeatedImages = documentViewState._RepeatedImages;
			_ScriptText = documentViewState._ScriptText;
			_ScriptLanguage = documentViewState._ScriptLanguage;
		}
	}
}

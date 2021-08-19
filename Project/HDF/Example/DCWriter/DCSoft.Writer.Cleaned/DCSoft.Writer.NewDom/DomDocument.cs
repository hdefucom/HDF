using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       文档对象元素
	///       </summary>
	[ComVisible(false)]
	public class DomDocument : DomElement
	{
		private List<DomAttribute> _Attributes = null;

		private string _BaseUrl = null;

		private string _BodyText = null;

		private DocumentInfo _Info = null;

		private DomContainerElement _Header = null;

		private DomContainerElement _Body = null;

		private DomContainerElement _Footer = null;

		private List<DomComment> _Comments = null;

		private string _EditorVersion = null;

		private string _FileName = null;

		private string _FileFormat = null;

		private LocalConfig _LocalConfig = null;

		private DocumentOptions _LocalOptions = null;

		private string _LocalExcludeKeywords = null;

		private XPageSettings _PageSettings = null;

		private List<DocumentParameter> _Parameters = null;

		private string _ScriptText = null;

		private string _TagValue = null;

		/// <summary>
		///       附加属性列表
		///       </summary>
		[XmlArrayItem("Attribute", typeof(DomAttribute))]
		[DefaultValue(null)]
		public List<DomAttribute> Attributes
		{
			get
			{
				return _Attributes;
			}
			set
			{
				_Attributes = value;
			}
		}

		/// <summary>
		///       基础路径
		///       </summary>
		[DefaultValue(null)]
		public string BaseUrl
		{
			get
			{
				return _BaseUrl;
			}
			set
			{
				_BaseUrl = value;
			}
		}

		/// <summary>
		///       文档正文内容
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string BodyText
		{
			get
			{
				return _BodyText;
			}
			set
			{
				_BodyText = value;
			}
		}

		/// <summary>
		///       文档信息
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
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

		/// <summary>
		///       页眉元素
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public DomContainerElement Header
		{
			get
			{
				return _Header;
			}
			set
			{
				_Header = value;
			}
		}

		/// <summary>
		///       文档正文
		///       </summary>
		[XmlElement]
		public DomContainerElement Body
		{
			get
			{
				return _Body;
			}
			set
			{
				_Body = value;
			}
		}

		/// <summary>
		///       页脚内容
		///       </summary>
		[XmlElement]
		public DomContainerElement Footer
		{
			get
			{
				return _Footer;
			}
			set
			{
				_Footer = value;
			}
		}

		/// <summary>
		///       文档批注
		///       </summary>
		[XmlArrayItem("Comment", typeof(DomComment))]
		[DefaultValue(null)]
		public List<DomComment> Comments
		{
			get
			{
				return _Comments;
			}
			set
			{
				_Comments = value;
			}
		}

		/// <summary>
		///       编辑器版本号
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string EditorVersion
		{
			get
			{
				return _EditorVersion;
			}
			set
			{
				_EditorVersion = value;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		[DefaultValue(null)]
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		[DefaultValue(null)]
		public string FileFormat
		{
			get
			{
				return _FileFormat;
			}
			set
			{
				_FileFormat = value;
			}
		}

		/// <summary>
		///       本地配置信息
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
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
		///       本地文档选项
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public DocumentOptions LocalOptions
		{
			get
			{
				return _LocalOptions;
			}
			set
			{
				_LocalOptions = value;
			}
		}

		/// <summary>
		///       本地的违禁关键字列表
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string LocalExcludeKeywords
		{
			get
			{
				return _LocalExcludeKeywords;
			}
			set
			{
				_LocalExcludeKeywords = value;
			}
		}

		/// <summary>
		///       页面设置
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
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
		///       文档参数
		///       </summary>
		[XmlArrayItem("Parameter", typeof(DocumentParameter))]
		[DefaultValue(null)]
		public List<DocumentParameter> Parameters
		{
			get
			{
				return _Parameters;
			}
			set
			{
				_Parameters = value;
			}
		}

		/// <summary>
		///       脚本文本
		///       </summary>
		[XmlElement]
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

		/// <summary>
		///       额外的数据
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string TagValue
		{
			get
			{
				return _TagValue;
			}
			set
			{
				_TagValue = value;
			}
		}
	}
}

using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       病程记录信息对象
	///       </summary>
	[ComClass("289826B1-6045-4983-ACC9-F329A8756311", "9D7E53C3-8B67-41FA-9064-8769393DA91F")]
	[ComVisible(true)]
	[Guid("289826B1-6045-4983-ACC9-F329A8756311")]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(ISectionCourseRecord))]
	public class SectionCourseRecord : ISectionCourseRecord
	{
		internal const string CLASSID = "289826B1-6045-4983-ACC9-F329A8756311";

		internal const string CLASSID_Interface = "9D7E53C3-8B67-41FA-9064-8769393DA91F";

		private SectionCourseRecordSource _RecordSource;

		private DocumentOptions _DocumentOptions;

		/// <summary>
		///       控制器对象
		///       </summary>
		private SectionCourseRecordDocumentController _Controller;

		internal int _Index;

		private DocumentInfo _DocumentInfo;

		private XAttributeList _DocumentAttributes;

		private string _FileName;

		private string _FileFormat;

		private XTextSectionElement _SectionElement;

		private XTextContainerElement _ContentElement;

		private int _ContentVersion;

		internal SectionCourseRecordSource RecordSource => _RecordSource;

		/// <summary>
		///       记录被锁定，无法设置为编辑状态
		///       </summary>
		public bool Locked => _RecordSource.Locked;

		/// <summary>
		///       是否启用授权控制及痕迹保留
		///       </summary>
		public bool EnablePermission
		{
			get
			{
				return RecordSource.EnablePermission;
			}
			set
			{
				if (RecordSource.EnablePermission != value)
				{
					RecordSource.EnablePermission = value;
					if (_Controller.CurrentRecord == this || _Controller.ViewControl != null)
					{
						_Controller.ViewControl.DocumentOptions.SecurityOptions.EnablePermission = value;
					}
				}
			}
		}

		internal DocumentOptions DocumentOptions
		{
			get
			{
				return _DocumentOptions;
			}
			set
			{
				_DocumentOptions = value;
			}
		}

		/// <summary>
		///       从0开始计算的记录序号
		///       </summary>
		public int Index
		{
			set
			{
				_Index = value;
			}
		}

		/// <summary>
		///       文档信息对象
		///       </summary>
		public DocumentInfo DocumentInfo
		{
			get
			{
				if (_DocumentInfo == null)
				{
					_DocumentInfo = new DocumentInfo();
				}
				return _DocumentInfo;
			}
		}

		/// <summary>
		///       文档属性列表
		///       </summary>
		public XAttributeList DocumentAttributes
		{
			get
			{
				if (_DocumentAttributes == null)
				{
					_DocumentAttributes = new XAttributeList();
				}
				return _DocumentAttributes;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		public string Title => _RecordSource.Title;

		/// <summary>
		///       文件名
		///       </summary>
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
		///       作者
		///       </summary>
		public string Author
		{
			get
			{
				return GetDocumentAttributeValue(_Controller.AuthorNameAttributeName);
			}
			set
			{
				SetDocumentAttribute(_Controller.AuthorNameAttributeName, value);
			}
		}

		/// <summary>
		///       本记录是当前的
		///       </summary>
		public bool IsCurrent
		{
			get
			{
				return _Controller.CurrentRecord == this;
			}
			set
			{
				_ContentElement.Focus();
			}
		}

		internal XTextSectionElement SectionElement => _SectionElement;

		/// <summary>
		///       承载记录正文内容的输入域对象
		///       </summary>
		public XTextContainerElement ContentElement => _ContentElement;

		/// <summary>
		///       记录是否只读
		///       </summary>
		public bool Readonly
		{
			get
			{
				return _ContentElement.RuntimeContentReadonly;
			}
			set
			{
				if (Readonly != value)
				{
					_Controller.SetReadonly(this, value);
				}
			}
		}

		/// <summary>
		///       记录内容是否修改了
		///       </summary>
		public bool Modified
		{
			get
			{
				return _ContentVersion != _ContentElement.ContentVersion;
			}
			set
			{
				if (value)
				{
					_ContentVersion = _ContentElement.ContentVersion - 1;
				}
				else
				{
					_ContentVersion = _ContentElement.ContentVersion;
				}
			}
		}

		/// <summary>
		///       获得文档内容XML字符串
		///       </summary>
		public string XMLText
		{
			get
			{
				using (XTextDocument xTextDocument = CreateRecordDocument())
				{
					return xTextDocument.XMLText;
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="section">
		/// </param>
		/// <param name="field">
		/// </param>
		/// <param name="sourceDocument">
		/// </param>
		internal SectionCourseRecord(SectionCourseRecordDocumentController sectionCourseRecordDocumentController_0, XTextSectionElement section, XTextContainerElement field, XTextDocument sourceDocument, SectionCourseRecordSource recordSource)
		{
			int num = 1;
			_RecordSource = null;
			_DocumentOptions = null;
			_Controller = null;
			_Index = 0;
			_DocumentInfo = null;
			_DocumentAttributes = null;
			_FileName = null;
			_FileFormat = null;
			_SectionElement = null;
			_ContentElement = null;
			_ContentVersion = 0;
			
			if (sectionCourseRecordDocumentController_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (section == null)
			{
				throw new ArgumentNullException("section");
			}
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (sourceDocument == null)
			{
				throw new ArgumentNullException("sourceDocument");
			}
			_Controller = sectionCourseRecordDocumentController_0;
			_SectionElement = section;
			_ContentElement = field;
			_ContentVersion = field.ContentVersion;
			_DocumentInfo = sourceDocument.Info;
			_DocumentAttributes = sourceDocument.Attributes;
			_SectionElement.Attributes = _DocumentAttributes;
			_FileName = sourceDocument.FileName;
			_FileFormat = sourceDocument.FileFormat;
			_DocumentOptions = sourceDocument.Options;
			_RecordSource = recordSource;
			Author = recordSource.Author;
		}

		/// <summary>
		///       获得文档属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		public string GetDocumentAttributeValue(string name)
		{
			return DocumentAttributes.GetValue(name);
		}

		/// <summary>
		///       设置文档属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		public void SetDocumentAttribute(string name, string Value)
		{
			DocumentAttributes.SetValue(name, Value);
		}

		/// <summary>
		///       获得记录中指定编号的文档元素对象
		///       </summary>
		/// <param name="id">编号</param>
		/// <returns>获得的文档 元素对象</returns>
		[ComVisible(false)]
		public XTextElement GetElementById(string string_0)
		{
			if (ContentElement == null)
			{
				return null;
			}
			return ContentElement.GetElementById(string_0);
		}

		/// <summary>
		///       创建单个病程记录文档对象
		///       </summary>
		/// <returns>创建的文档对象</returns>
		public XTextDocument CreateRecordDocument()
		{
			XTextContainerElement contentElement = ContentElement;
			bool enablePermission = contentElement.OwnerDocument.Options.SecurityOptions.EnablePermission;
			contentElement.OwnerDocument.Options.SecurityOptions.EnablePermission = _RecordSource.EnablePermission;
			XTextDocument xTextDocument = contentElement.CreateContentDocument(includeThis: false);
			contentElement.OwnerDocument.Options.SecurityOptions.EnablePermission = enablePermission;
			xTextDocument.Options.SecurityOptions.EnablePermission = true;
			if (xTextDocument != null)
			{
				_ = xTextDocument.Body.Elements;
				if (_DocumentInfo != null)
				{
					xTextDocument.Info = _DocumentInfo.Clone();
				}
				if (_DocumentAttributes != null)
				{
					xTextDocument.Attributes = _DocumentAttributes.Clone();
				}
			}
			xTextDocument.FileName = _FileName;
			xTextDocument.FileFormat = FileFormat;
			return xTextDocument;
		}
	}
}

using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       病程记录来源
	///       </summary>
	[ComVisible(true)]
	[ComDefaultInterface(typeof(ISectionCourseRecordSource))]
	[Guid("EA3F7154-5D49-4585-BFD0-DBE64DF64DF3")]
	[DocumentComment]
	[ComClass("EA3F7154-5D49-4585-BFD0-DBE64DF64DF3", "7E0BD05C-275D-4BAD-9774-E543118D813E")]
	[ClassInterface(ClassInterfaceType.None)]
	public class SectionCourseRecordSource : ISectionCourseRecordSource
	{
		internal const string CLASSID = "EA3F7154-5D49-4585-BFD0-DBE64DF64DF3";

		internal const string CLASSID_Interface = "7E0BD05C-275D-4BAD-9774-E543118D813E";

		private string _FileName;

		private XTextDocument _Document;

		private bool _Modified;

		private bool _Readonly;

		private bool _Locked;

		private bool _NewPage;

		private bool _EnablePermission;

		private Color _RecordBorderColor;

		private Color _SpecifyBackgroundCololr;

		private float _RecordSpacing;

		/// <summary>
		///       文件名
		///       </summary>
		public string FileName
		{
			get
			{
				if (string.IsNullOrEmpty(_FileName) && _Document != null)
				{
					return _Document.FileName;
				}
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		/// <summary>
		///       内容修改标记
		///       </summary>
		public bool Modified
		{
			get
			{
				return _Modified;
			}
			set
			{
				_Modified = value;
			}
		}

		/// <summary>
		///       内容只读
		///       </summary>
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		/// <summary>
		///       内容被锁定，不能再次修改
		///       </summary>
		public bool Locked
		{
			get
			{
				return _Locked;
			}
			set
			{
				_Locked = value;
			}
		}

		/// <summary>
		///       强制分页
		///       </summary>
		public bool NewPage
		{
			get
			{
				return _NewPage;
			}
			set
			{
				_NewPage = value;
			}
		}

		/// <summary>
		///       是否启用授权控制及痕迹保留
		///       </summary>
		public bool EnablePermission
		{
			get
			{
				return _EnablePermission;
			}
			set
			{
				_EnablePermission = value;
			}
		}

		/// <summary>
		///       记录边框线颜色
		///       </summary>
		public Color RecordBorderColor
		{
			get
			{
				return _RecordBorderColor;
			}
			set
			{
				_RecordBorderColor = value;
			}
		}

		/// <summary>
		///       指定的背景色
		///       </summary>
		[ComVisible(true)]
		public Color SpecifyBackgroundCololr
		{
			get
			{
				return _SpecifyBackgroundCololr;
			}
			set
			{
				_SpecifyBackgroundCololr = value;
			}
		}

		/// <summary>
		///       记录之间的间距
		///       </summary>
		public float RecordSpacing
		{
			get
			{
				return _RecordSpacing;
			}
			set
			{
				_RecordSpacing = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[Obsolete("!!!请使用Document.Info.Title属性")]
		public string Title
		{
			get
			{
				if (_Document != null)
				{
					return _Document.Info.Title;
				}
				return null;
			}
			set
			{
				if (_Document != null)
				{
					_Document.Info.Title = value;
				}
			}
		}

		/// <summary>
		///       病程记录作者
		///       </summary>
		[Obsolete("!!!请使用Document.Info.Author属性")]
		public string Author
		{
			get
			{
				if (_Document == null)
				{
					return null;
				}
				return _Document.Info.Author;
			}
			set
			{
				if (_Document != null)
				{
					_Document.Info.Author = value;
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public SectionCourseRecordSource()
		{
			_FileName = null;
			_Document = null;
			_Modified = false;
			_Readonly = true;
			_Locked = false;
			_NewPage = false;
			_EnablePermission = false;
			_RecordBorderColor = Color.Transparent;
			_SpecifyBackgroundCololr = Color.Empty;
			_RecordSpacing = 0f;
			
		}

		internal SectionCourseRecordSource(XTextDocument document, SectionCourseRecordDocumentController sectionCourseRecordDocumentController_0)
		{
			int num = 19;
			_FileName = null;
			_Document = null;
			_Modified = false;
			_Readonly = true;
			_Locked = false;
			_NewPage = false;
			_EnablePermission = false;
			_RecordBorderColor = Color.Transparent;
			_SpecifyBackgroundCololr = Color.Empty;
			_RecordSpacing = 0f;
			
			Document = document;
			if (document.Attributes.ContainsByName(sectionCourseRecordDocumentController_0.NewPageFlagAttributeName))
			{
				string value = document.Attributes.GetValue(sectionCourseRecordDocumentController_0.NewPageFlagAttributeName);
				bool flag2 = NewPage = (string.Compare(value, "true", ignoreCase: false) == 0);
			}
			EnablePermission = document.Options.SecurityOptions.EnablePermission;
		}
	}
}

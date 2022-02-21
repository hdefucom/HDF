using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       设置容器元素方法参数
	///       </summary>
	[ComDefaultInterface(typeof(ISetContainerTextArgs))]
	[ComClass("BA1506BC-CC0F-4683-B9C0-6CA1596EA4DB", "12D3C309-EADD-4676-A08A-BE94889047AC")]
	
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("BA1506BC-CC0F-4683-B9C0-6CA1596EA4DB")]
	public class SetContainerTextArgs : ISetContainerTextArgs
	{
		internal const string CLASSID = "BA1506BC-CC0F-4683-B9C0-6CA1596EA4DB";

		internal const string CLASSID_Interface = "12D3C309-EADD-4676-A08A-BE94889047AC";

		private ContentChangedEventSource _EventSource = ContentChangedEventSource.Default;

		private string _NewText = null;

		private bool _IgnoreDisplayFormat = false;

		private DomAccessFlags _AccessFlags = DomAccessFlags.None;

		private bool _DisablePermission = false;

		private bool _UpdateContent = true;

		private bool _LogUndo = true;

		private bool _FocusContainer = false;

		private bool _RaiseDocumentContentChangedEvent = true;

		private DocumentContentStyle _NewTextStyle = null;

		private DocumentContentStyle _NewParagraphStyle = null;

		private bool _RaiseEvent = true;

		private bool _ShowUI = false;

		/// <summary>
		///       事件来源
		///       </summary>
		
		public ContentChangedEventSource EventSource
		{
			get
			{
				return _EventSource;
			}
			set
			{
				_EventSource = value;
			}
		}

		/// <summary>
		///       新文本
		///       </summary>
		
		public string NewText
		{
			get
			{
				return _NewText;
			}
			set
			{
				_NewText = value;
			}
		}

		/// <summary>
		///       忽略掉显示格式
		///       </summary>
		
		public bool IgnoreDisplayFormat
		{
			get
			{
				return _IgnoreDisplayFormat;
			}
			set
			{
				_IgnoreDisplayFormat = value;
			}
		}

		/// <summary>
		///       访问标记
		///       </summary>
		
		public DomAccessFlags AccessFlags
		{
			get
			{
				return _AccessFlags;
			}
			set
			{
				_AccessFlags = value;
			}
		}

		/// <summary>
		///       禁止授权操作
		///       </summary>
		
		public bool DisablePermission
		{
			get
			{
				return _DisablePermission;
			}
			set
			{
				_DisablePermission = value;
			}
		}

		/// <summary>
		///       文本文档视图
		///       </summary>
		
		public bool UpdateContent
		{
			get
			{
				return _UpdateContent;
			}
			set
			{
				_UpdateContent = value;
			}
		}

		/// <summary>
		///       是否记录撤销操作信息
		///       </summary>
		
		public bool LogUndo
		{
			get
			{
				return _LogUndo;
			}
			set
			{
				_LogUndo = value;
			}
		}

		/// <summary>
		///       让容器获得输入焦点
		///       </summary>
		
		public bool FocusContainer
		{
			get
			{
				return _FocusContainer;
			}
			set
			{
				_FocusContainer = value;
			}
		}

		/// <summary>
		///       是否触发文档的DocumentContentChanged事件
		///       </summary>
		
		public bool RaiseDocumentContentChangedEvent
		{
			get
			{
				return _RaiseDocumentContentChangedEvent;
			}
			set
			{
				_RaiseDocumentContentChangedEvent = value;
			}
		}

		/// <summary>
		///       新文本的样式
		///       </summary>
		
		public DocumentContentStyle NewTextStyle
		{
			get
			{
				return _NewTextStyle;
			}
			set
			{
				_NewTextStyle = value;
			}
		}

		/// <summary>
		///       新的段落样式
		///       </summary>
		
		public DocumentContentStyle NewParagraphStyle
		{
			get
			{
				return _NewParagraphStyle;
			}
			set
			{
				_NewParagraphStyle = value;
			}
		}

		/// <summary>
		///       是否触发事件
		///       </summary>
		
		public bool RaiseEvent
		{
			get
			{
				return _RaiseEvent;
			}
			set
			{
				_RaiseEvent = value;
			}
		}

		/// <summary>
		///       是否显示用户界面
		///       </summary>
		
		public bool ShowUI
		{
			get
			{
				return _ShowUI;
			}
			set
			{
				_ShowUI = value;
			}
		}
	}
}

using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器控件选项
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("8E445C4C-1EC3-4D48-A158-A632827EA688", "64724F79-BCEA-4324-9019-0183EE7C984E")]
	[Guid("8E445C4C-1EC3-4D48-A158-A632827EA688")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDocumentWriterControlOptions))]
	public class DocumentWriterControlOptions : IDocumentWriterControlOptions
	{
		internal const string CLASSID = "8E445C4C-1EC3-4D48-A158-A632827EA688";

		internal const string CLASSID_Interface = "64724F79-BCEA-4324-9019-0183EE7C984E";

		private bool _AutoSetDocumentDefaultFont = true;

		private bool _ReadViewMode = false;

		/// <summary>
		///       页面显示模式
		///       </summary>
		private PageViewMode intViewMode = PageViewMode.Page;

		private bool _AllowDragContent = false;

		private bool _AllowDrop = false;

		private bool _Readonly = false;

		private PageTitlePosition _PageTitlePosition = PageTitlePosition.TopLeft;

		private MoveFocusHotKeys _MoveFocusHotKey = MoveFocusHotKeys.None;

		private bool _IsAdministrator = false;

		private WriterDataFormats _AcceptDataFormats = WriterDataFormats.All;

		private WriterDataFormats _CreationDataFormats = WriterDataFormats.All;

		private bool _AutoUserLogin = false;

		private FunctionControlVisibility _CommentVisibility = FunctionControlVisibility.Auto;

		private bool _EnabledElementEvent = true;

		private FormViewMode _FormView = FormViewMode.Disable;

		private bool _HeaderFooterReadonly = false;

		private Font _Font = null;

		/// <summary>
		///       自动设置文档默认字体
		///       </summary>
		[DefaultValue(true)]
		public bool AutoSetDocumentDefaultFont
		{
			get
			{
				return _AutoSetDocumentDefaultFont;
			}
			set
			{
				_AutoSetDocumentDefaultFont = value;
			}
		}

		/// <summary>
		///       阅读版式视图模式
		///       </summary>
		[DefaultValue(false)]
		public bool ReadViewMode
		{
			get
			{
				return _ReadViewMode;
			}
			set
			{
				_ReadViewMode = value;
			}
		}

		/// <summary>
		///       页面显示模式
		///       </summary>
		[Browsable(false)]
		[DefaultValue(PageViewMode.Page)]
		public PageViewMode ViewMode
		{
			get
			{
				return intViewMode;
			}
			set
			{
				intViewMode = value;
			}
		}

		/// <summary>
		///       允许拖拽内容
		///       </summary>
		[DefaultValue(false)]
		public bool AllowDragContent
		{
			get
			{
				return _AllowDragContent;
			}
			set
			{
				_AllowDragContent = value;
			}
		}

		/// <summary>
		///       允许拖拽
		///       </summary>
		[DefaultValue(false)]
		public bool AllowDrop
		{
			get
			{
				return _AllowDrop;
			}
			set
			{
				_AllowDrop = value;
			}
		}

		/// <summary>
		///       文档内容是否只读
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
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
		///       页面标题位置
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(PageTitlePosition.TopLeft)]
		public PageTitlePosition PageTitlePosition
		{
			get
			{
				return _PageTitlePosition;
			}
			set
			{
				_PageTitlePosition = value;
			}
		}

		/// <summary>
		///       移动焦点使用的快捷键
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(MoveFocusHotKeys.None)]
		[Description("移动输入焦点使用的快捷键模式")]
		public MoveFocusHotKeys MoveFocusHotKey
		{
			get
			{
				return _MoveFocusHotKey;
			}
			set
			{
				_MoveFocusHotKey = value;
			}
		}

		/// <summary>
		///       是否以管理员模式运行
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool IsAdministrator
		{
			get
			{
				return _IsAdministrator;
			}
			set
			{
				_IsAdministrator = value;
			}
		}

		/// <summary>
		///       编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据
		///       </summary>
		[Category("Behavior")]
		[Description("编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据")]
		[DefaultValue(WriterDataFormats.All)]
		public WriterDataFormats AcceptDataFormats
		{
			get
			{
				return _AcceptDataFormats;
			}
			set
			{
				_AcceptDataFormats = value;
			}
		}

		/// <summary>
		///       编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作
		///       </summary>
		[Category("Behavior")]
		[Description("编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作")]
		[DefaultValue(WriterDataFormats.All)]
		public WriterDataFormats CreationDataFormats
		{
			get
			{
				return _CreationDataFormats;
			}
			set
			{
				_CreationDataFormats = value;
			}
		}

		/// <summary>
		///       每打开文档时自动进行用户登录
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool AutoUserLogin
		{
			get
			{
				return _AutoUserLogin;
			}
			set
			{
				_AutoUserLogin = value;
			}
		}

		/// <summary>
		///       是否显示文档批注
		///       </summary>
		[DefaultValue(FunctionControlVisibility.Auto)]
		[Category("Appearance")]
		public FunctionControlVisibility CommentVisibility
		{
			get
			{
				return _CommentVisibility;
			}
			set
			{
				_CommentVisibility = value;
			}
		}

		/// <summary>
		///       是否允许触发文档元素级事件
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool EnabledElementEvent
		{
			get
			{
				return _EnabledElementEvent;
			}
			set
			{
				_EnabledElementEvent = value;
			}
		}

		/// <summary>
		///       表单视图模式
		///       </summary>
		[DefaultValue(FormViewMode.Disable)]
		[Category("Behavior")]
		public FormViewMode FormView
		{
			get
			{
				return _FormView;
			}
			set
			{
				_FormView = value;
			}
		}

		/// <summary>
		///       页眉页脚是否只读
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool HeaderFooterReadonly
		{
			get
			{
				return _HeaderFooterReadonly;
			}
			set
			{
				_HeaderFooterReadonly = value;
			}
		}

		/// <summary>
		///       字体
		///       </summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		public Font Font
		{
			get
			{
				return _Font;
			}
			set
			{
				_Font = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DocumentWriterControlOptions()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		public DocumentWriterControlOptions(WriterControl writerControl_0)
		{
			AutoSetDocumentDefaultFont = writerControl_0.AutoSetDocumentDefaultFont;
			AcceptDataFormats = writerControl_0.AcceptDataFormats;
			CreationDataFormats = writerControl_0.CreationDataFormats;
			AutoUserLogin = writerControl_0.AutoUserLogin;
			CommentVisibility = writerControl_0.CommentVisibility;
			EnabledElementEvent = writerControl_0.EnabledElementEvent;
			FormView = writerControl_0.FormView;
			HeaderFooterReadonly = writerControl_0.HeaderFooterReadonly;
			IsAdministrator = writerControl_0.IsAdministrator;
			MoveFocusHotKey = writerControl_0.MoveFocusHotKey;
			PageTitlePosition = writerControl_0.PageTitlePosition;
			Readonly = writerControl_0.Readonly;
			AllowDrop = writerControl_0.AllowDrop;
			AllowDragContent = writerControl_0.AllowDragContent;
			ViewMode = writerControl_0.ViewMode;
			ReadViewMode = writerControl_0.ReadViewMode;
			Font = writerControl_0.Font;
		}

		/// <summary>
		///       应用到控件
		///       </summary>
		/// <param name="ctl">
		/// </param>
		[Browsable(false)]
		public void ApplyTo(WriterControl writerControl_0)
		{
			if (writerControl_0 != null)
			{
				writerControl_0.AutoSetDocumentDefaultFont = AutoSetDocumentDefaultFont;
				writerControl_0.AcceptDataFormats = AcceptDataFormats;
				writerControl_0.CreationDataFormats = CreationDataFormats;
				writerControl_0.AutoUserLogin = AutoUserLogin;
				writerControl_0.CommentVisibility = CommentVisibility;
				writerControl_0.EnabledElementEvent = EnabledElementEvent;
				writerControl_0.FormView = FormView;
				writerControl_0.HeaderFooterReadonly = HeaderFooterReadonly;
				writerControl_0.IsAdministrator = IsAdministrator;
				writerControl_0.MoveFocusHotKey = MoveFocusHotKey;
				writerControl_0.PageTitlePosition = PageTitlePosition;
				writerControl_0.Readonly = Readonly;
				writerControl_0.AllowDrop = AllowDrop;
				writerControl_0.AllowDragContent = AllowDragContent;
				writerControl_0.ViewMode = ViewMode;
				writerControl_0.ReadViewMode = ReadViewMode;
				if (Font != null)
				{
					writerControl_0.Font = Font;
				}
			}
		}
	}
}

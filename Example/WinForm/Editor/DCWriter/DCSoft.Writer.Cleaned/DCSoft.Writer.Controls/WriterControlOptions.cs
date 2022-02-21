using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器控件选项
	///       </summary>
	
	[DocumentComment]
	[ComVisible(false)]
	public class WriterControlOptions
	{
		private string _CurrentPageBorderColor = null;

		private bool _RuleVisible = true;

		private string _RuleBackColor = null;

		private bool _RuleEnabled = true;

		/// <summary>
		///       是否强制显示光标而不管控件是否获得输入焦点
		///       </summary>
		private bool _ForceShowCaret = false;

		/// <summary>
		///       获取或设置一个值，该值指示在控件中按 TAB 键时，是否在控件中键入一个 TAB 字符，而不是按选项卡的顺序将焦点移动到下一个控件。
		///       </summary>
		private bool _AcceptsTab = true;

		private CurrentUserInfo _UserInfo = null;

		private DocumentOptions _DocumentOptions = null;

		private XFontValue _Font = null;

		private string _PageBackColor = null;

		private string _PageBorderColor = null;

		private string _AdditionPageTitle = null;

		private bool _AllowDrop = false;

		private string _DefaultPrinterName = null;

		private int _StartPageIndex = -1;

		private int _EndPageIndex = -1;

		/// <summary>
		///       页面显示模式
		///       </summary>
		private PageViewMode intViewMode = PageViewMode.Page;

		private bool _ReadViewMode = false;

		private FormViewMode _FormView = FormViewMode.Disable;

		private HeaderFooterFlagVisible _HeaderFooterFlagVisible = HeaderFooterFlagVisible.None;

		private bool _HeaderFooterReadonly = false;

		private bool _HideCaretWhenHasSelection = true;

		/// <summary>
		///       当前是否处于插入模式,若处于插入模式,则光标比较细,否则处于改写模式,光标比较粗
		///       </summary>
		private bool _InsertMode = true;

		private bool _IsAdministrator = false;

		private JumpPrintInfo _JumpPrint = null;

		/// <summary>
		///       处于页面视图模式时各个页面间的距离，像素为单位
		///       </summary>
		protected int intPageSpacing = 20;

		private PageTitlePosition _PageTitlePosition = PageTitlePosition.TopLeft;

		private bool _Readonly = false;

		private string _StatusText = null;

		private bool _BackgroundMode = false;

		private string _KBLibraryUrl = null;

		[DefaultValue(null)]
		public string CurrentPageBorderColor
		{
			get
			{
				return _CurrentPageBorderColor;
			}
			set
			{
				_CurrentPageBorderColor = value;
			}
		}

		/// <summary>
		///       标尺是否可见
		///       </summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool RuleVisible
		{
			get
			{
				return _RuleVisible;
			}
			set
			{
				_RuleVisible = value;
			}
		}

		/// <summary>
		///       标尺背景色
		///       </summary>
		[DefaultValue(null)]
		public string RuleBackColor
		{
			get
			{
				return _RuleBackColor;
			}
			set
			{
				_RuleBackColor = value;
			}
		}

		/// <summary>
		///       标尺是否可用
		///       </summary>
		[DefaultValue(true)]
		public bool RuleEnabled
		{
			get
			{
				return _RuleEnabled;
			}
			set
			{
				_RuleEnabled = value;
			}
		}

		/// <summary>
		///       是否强制显示光标而不管控件是否获得输入焦点
		///       </summary>
		[DefaultValue(false)]
		public bool ForceShowCaret
		{
			get
			{
				return _ForceShowCaret;
			}
			set
			{
				_ForceShowCaret = value;
			}
		}

		/// <summary>
		///       获取或设置一个值，该值指示在控件中按 TAB 键时，是否在控件中键入一个 TAB 字符，而不是按选项卡的顺序将焦点移动到下一个控件。
		///       </summary>
		[DefaultValue(true)]
		public bool AcceptsTab
		{
			get
			{
				return _AcceptsTab;
			}
			set
			{
				_AcceptsTab = value;
			}
		}

		/// <summary>
		///       当前用户信息对象
		///       </summary>
		[DefaultValue(null)]
		public CurrentUserInfo UserInfo
		{
			get
			{
				return _UserInfo;
			}
			set
			{
				_UserInfo = value;
			}
		}

		[DefaultValue(null)]
		public DocumentOptions DocumentOptions
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
		///       字体对象
		///       </summary>
		[DefaultValue(null)]
		public XFontValue Font
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

		[DefaultValue(null)]
		public string PageBackColor
		{
			get
			{
				return _PageBackColor;
			}
			set
			{
				_PageBackColor = value;
			}
		}

		[DefaultValue(null)]
		public string PageBorderColor
		{
			get
			{
				return _PageBorderColor;
			}
			set
			{
				_PageBorderColor = value;
			}
		}

		/// <summary>
		///       显示在已经注册的页码标题文本后面的额外的页码标题文本
		///       </summary>
		[DefaultValue(null)]
		public string AdditionPageTitle
		{
			get
			{
				return _AdditionPageTitle;
			}
			set
			{
				_AdditionPageTitle = value;
			}
		}

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

		[DefaultValue(null)]
		public string DefaultPrinterName
		{
			get
			{
				return _DefaultPrinterName;
			}
			set
			{
				_DefaultPrinterName = value;
			}
		}

		/// <summary>
		///       从0开始的计算的开始显示的页码号,只有处于分页视图模式下该属性才有效。小于0则不启用该设置。
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(-1)]
		public int StartPageIndex
		{
			get
			{
				return _StartPageIndex;
			}
			set
			{
				_StartPageIndex = value;
			}
		}

		/// <summary>
		///       从0开始计算的最后显示的页码号,为0表示没有设置。只有处于分页视图模式下该属性才有效。小于0则不启用该设置。
		///       </summary>
		[DefaultValue(-1)]
		[Category("Appearance")]
		public int EndPageIndex
		{
			get
			{
				return _EndPageIndex;
			}
			set
			{
				_EndPageIndex = value;
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
		///       表单视图模式
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(FormViewMode.Disable)]
		public FormViewMode FormView
		{
			get
			{
				return _FormView;
			}
			set
			{
				if (_FormView != value)
				{
					_FormView = value;
				}
			}
		}

		/// <summary>
		///       是否显示页眉页脚标记
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual HeaderFooterFlagVisible HeaderFooterFlagVisible
		{
			get
			{
				return _HeaderFooterFlagVisible;
			}
			set
			{
				_HeaderFooterFlagVisible = value;
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
		///       当选择了文档内容时隐藏光标
		///       </summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool HideCaretWhenHasSelection
		{
			get
			{
				return _HideCaretWhenHasSelection;
			}
			set
			{
				_HideCaretWhenHasSelection = value;
			}
		}

		/// <summary>
		///       当前是否处于插入模式,若处于插入模式,则光标比较细,否则处于改写模式,光标比较粗
		///       </summary>
		[DefaultValue(true)]
		public virtual bool InsertMode
		{
			get
			{
				return _InsertMode;
			}
			set
			{
				_InsertMode = value;
			}
		}

		/// <summary>
		///       是否以管理员模式运行
		///       </summary>
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
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
		///       续打信息
		///       </summary>
		[DefaultValue(null)]
		public JumpPrintInfo JumpPrint
		{
			get
			{
				return _JumpPrint;
			}
			set
			{
				_JumpPrint = value;
			}
		}

		/// <summary>
		///       处于页面视图模式时各个页面间的距离，像素为单位
		///       </summary>
		[DefaultValue(20)]
		public int PageSpacing
		{
			get
			{
				return intPageSpacing;
			}
			set
			{
				intPageSpacing = value;
			}
		}

		/// <summary>
		///       页面标题位置
		///       </summary>
		[DefaultValue(PageTitlePosition.TopLeft)]
		[Category("Appearance")]
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
		///       文档内容只读标记
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
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
		///       状态文本
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string StatusText
		{
			get
			{
				return _StatusText;
			}
			set
			{
				_StatusText = value;
			}
		}

		/// <summary>
		///       后台运行模式
		///       </summary>
		/// <remarks>
		///       后台模式下，任何控件、文档只读和授权内容保护无效，可以任意修改文档内容。
		///       但仍然会根据需要留下历史修改痕迹。
		///       </remarks>
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool BackgroundMode
		{
			get
			{
				return _BackgroundMode;
			}
			set
			{
				_BackgroundMode = value;
			}
		}

		/// <summary>
		///       知识库文件URL
		///       </summary>
		[DefaultValue(null)]
		public string KBLibraryUrl
		{
			get
			{
				return _KBLibraryUrl;
			}
			set
			{
				_KBLibraryUrl = value;
			}
		}

		/// <summary>
		///       将数据填充到编辑器控件中
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		public void WriteToControl(WriterControl writerControl_0)
		{
			int num = 5;
			if (writerControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (Font != null)
			{
				writerControl_0.Font = Font.Value;
			}
			if (DocumentOptions != null)
			{
				writerControl_0.DocumentOptions = DocumentOptions;
			}
			if (UserInfo != null)
			{
				writerControl_0.AppHost.Services.AddService(typeof(CurrentUserInfo), UserInfo);
			}
			writerControl_0.CurrentPageBorderColor = XMLSerializeHelper.StringToColor(CurrentPageBorderColor, Color.Black);
			writerControl_0.RuleEnabled = RuleEnabled;
			writerControl_0.RuleVisible = RuleVisible;
			writerControl_0.RuleBackColor = XMLSerializeHelper.StringToColor(RuleBackColor, DCRulerControl.color_0);
			writerControl_0.ForceShowCaret = ForceShowCaret;
			writerControl_0.AcceptsTab = AcceptsTab;
			writerControl_0.PageBackColor = XMLSerializeHelper.StringToColor(PageBackColor, SystemColors.Window);
			writerControl_0.PageBorderColor = XMLSerializeHelper.StringToColor(PageBorderColor, Color.Black);
			writerControl_0.PageTitlePosition = PageTitlePosition;
			writerControl_0.Readonly = Readonly;
			writerControl_0.PageSpacing = PageSpacing;
			writerControl_0.AdditionPageTitle = AdditionPageTitle;
			writerControl_0.AllowDrop = AllowDrop;
			writerControl_0.DefaultPrinterName = DefaultPrinterName;
			writerControl_0.StartPageIndex = StartPageIndex;
			writerControl_0.EndPageIndex = EndPageIndex;
			writerControl_0.ViewMode = ViewMode;
			writerControl_0.ReadViewMode = ReadViewMode;
			writerControl_0.FormView = FormView;
			writerControl_0.HeaderFooterFlagVisible = HeaderFooterFlagVisible;
			writerControl_0.HeaderFooterReadonly = HeaderFooterReadonly;
			writerControl_0.HideCaretWhenHasSelection = HideCaretWhenHasSelection;
			writerControl_0.InsertMode = InsertMode;
			writerControl_0.IsAdministrator = IsAdministrator;
			writerControl_0.JumpPrint = JumpPrint;
			writerControl_0.StatusText = StatusText;
			writerControl_0.BackgroundMode = BackgroundMode;
			writerControl_0.KBLibraryUrl = KBLibraryUrl;
		}

		/// <summary>
		///       从编辑器控件获得数据
		///       </summary>
		/// <param name="ctl">控件对象</param>
		public void ReadFromControl(WriterControl writerControl_0)
		{
			int num = 16;
			if (writerControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			CurrentPageBorderColor = XMLSerializeHelper.ColorToString(writerControl_0.CurrentPageBorderColor, Color.Black);
			RuleEnabled = writerControl_0.RuleEnabled;
			RuleBackColor = XMLSerializeHelper.ColorToString(writerControl_0.RuleBackColor, DCRulerControl.color_0);
			RuleVisible = writerControl_0.RuleVisible;
			UserInfo = (CurrentUserInfo)writerControl_0.AppHost.Services.GetService(typeof(CurrentUserInfo));
			AcceptsTab = writerControl_0.AcceptsTab;
			ForceShowCaret = writerControl_0.ForceShowCaret;
			DocumentOptions = writerControl_0.DocumentOptions;
			Font = new XFontValue(writerControl_0.Font);
			PageBackColor = XMLSerializeHelper.ColorToString(writerControl_0.PageBackColor, SystemColors.Window);
			PageBorderColor = XMLSerializeHelper.ColorToString(writerControl_0.PageBorderColor, Color.Black);
			PageTitlePosition = writerControl_0.PageTitlePosition;
			Readonly = writerControl_0.Readonly;
			PageSpacing = writerControl_0.PageSpacing;
			AdditionPageTitle = writerControl_0.AdditionPageTitle;
			AllowDrop = writerControl_0.AllowDrop;
			DefaultPrinterName = writerControl_0.DefaultPrinterName;
			StartPageIndex = writerControl_0.StartPageIndex;
			EndPageIndex = writerControl_0.EndPageIndex;
			ViewMode = writerControl_0.ViewMode;
			ReadViewMode = writerControl_0.ReadViewMode;
			FormView = writerControl_0.FormView;
			HeaderFooterFlagVisible = writerControl_0.HeaderFooterFlagVisible;
			HeaderFooterReadonly = writerControl_0.HeaderFooterReadonly;
			HideCaretWhenHasSelection = writerControl_0.HideCaretWhenHasSelection;
			InsertMode = writerControl_0.InsertMode;
			IsAdministrator = writerControl_0.IsAdministrator;
			JumpPrint = writerControl_0.JumpPrint;
			StatusText = writerControl_0.StatusText;
			BackgroundMode = writerControl_0.BackgroundMode;
			KBLibraryUrl = writerControl_0.KBLibraryUrl;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public WriterControlOptions Clone()
		{
			WriterControlOptions writerControlOptions = (WriterControlOptions)MemberwiseClone();
			if (_DocumentOptions != null)
			{
				writerControlOptions._DocumentOptions = _DocumentOptions.Clone();
			}
			return writerControlOptions;
		}
	}
}

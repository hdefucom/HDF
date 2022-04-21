using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       增强型的文本文档编辑控件,仅提供兼容性支持,不推荐使用.
	///       </summary>
	[ToolboxItem(false)]
	[Guid("00012345-6789-ABCD-EF01-234567890001")]
	[ToolboxBitmap(typeof(WriterControl))]
	
	[ComVisible(false)]
	public class WriterControlExt : UserControl, IObjectSafety
	{
		private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";

		private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";

		private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";

		private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";

		private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

		private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 1;

		private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 2;

		private const int S_OK = 0;

		private const int E_FAIL = -2147467259;

		private const int E_NOINTERFACE = -2147467262;

		/// <summary> 
		///       必需的设计器变量。
		///       </summary>
		private IContainer components;

		public MenuStrip mainMenuStrip;

		public ToolStripMenuItem menuFile;

		public ToolStripMenuItem menuPageSettings;

		public WriterCommandControler myCommandControler;

		public ToolStripMenuItem mPrint;

		public ToolStripMenuItem mCleanPrint;

		public ToolStripMenuItem menuEdit;

		public ToolStripMenuItem mUndo;

		public ToolStripMenuItem mRedo;

		public ToolStripSeparator toolStripSeparator4;

		public ToolStripMenuItem mCut;

		public ToolStripMenuItem mCopy;

		public ToolStripMenuItem mPaste;

		public ToolStripMenuItem mSpecifyPaste;

		public ToolStripMenuItem mDelete;

		public ToolStripSeparator toolStripSeparator5;

		public ToolStripMenuItem mSelectAll;

		public ToolStripSeparator toolStripSeparator6;

		public ToolStripMenuItem mSearch;

		public ToolStripSeparator toolStripSeparator17;

		public ToolStripMenuItem mEditImageShape;

		public ToolStripSeparator toolStripSeparator1;

		public ToolStripMenuItem mSignDocument;

		public ToolStripMenuItem menuView;

		public ToolStripMenuItem mJumpPrint;

		public ToolStripSeparator toolStripSeparator18;

		public ToolStripMenuItem mPageViewMode;

		public ToolStripMenuItem mNormalViewMode;

		public ToolStripSeparator toolStripSeparator21;

		public ToolStripMenuItem mCleanViewMode;

		public ToolStripMenuItem mComplexViewMode;

		public ToolStripMenuItem menuInsert;

		public ToolStripMenuItem mInsertImage;

		public ToolStripMenuItem mInsertInputField;

		public ToolStripMenuItem mInsertParameter;

		public ToolStripMenuItem mInsertCheckBox;

		public ToolStripMenuItem mInsertMedicalExpression;

		public ToolStripMenuItem mInsertBarcode;

		public ToolStripMenuItem mInsertPageInfo;

		public ToolStripMenuItem mInsertXML;

		public ToolStripMenuItem mInsertFileContent;

		public ToolStripMenuItem mInsertContentLink;

		public ToolStripSeparator toolStripMenuItem1;

		public ToolStripMenuItem mDeleteField;

		public ToolStripMenuItem menuFormat;

		public ToolStripMenuItem mParagraphFormat;

		public ToolStripMenuItem mFont;

		public ToolStripMenuItem mTextColor;

		public ToolStripMenuItem mBackColor;

		public ToolStripSeparator toolStripSeparator7;

		public ToolStripMenuItem mSup;

		public ToolStripMenuItem mSub;

		public ToolStripSeparator toolStripSeparator8;

		public ToolStripMenuItem mAlignLeft;

		public ToolStripMenuItem mCenterAlign;

		public ToolStripMenuItem mRightAlign;

		public ToolStripSeparator toolStripSeparator9;

		public ToolStripMenuItem mNumerList;

		public ToolStripMenuItem mBulleteList;

		public ToolStripMenuItem mFirstIndent;

		public ToolStripSeparator toolStripSeparator26;

		public ToolStripMenuItem mFieldFixedWidth;

		public ToolStripMenuItem mTable;

		public ToolStripMenuItem mInsertTable;

		public ToolStripMenuItem mDeleteTable;

		public ToolStripSeparator toolStripSeparator20;

		public ToolStripMenuItem mCellAlign;

		public ToolStripMenuItem mAlignTopLeft;

		public ToolStripMenuItem mAlignTopCenter;

		public ToolStripMenuItem mAlignTopRight;

		public ToolStripMenuItem mAlignMiddleLeft;

		public ToolStripMenuItem mAlignMiddleCenter;

		public ToolStripMenuItem mAlignMiddleRight;

		public ToolStripMenuItem mAlignBottomLeft;

		public ToolStripMenuItem mAlignBottomCenter;

		public ToolStripMenuItem mAlignBottomRight;

		public ToolStripSeparator toolStripSeparator16;

		public ToolStripMenuItem mInsertRowUp;

		public ToolStripMenuItem mInsertRowDown;

		public ToolStripMenuItem mDeleteRow;

		public ToolStripSeparator toolStripMenuItem3;

		public ToolStripMenuItem mInsertColumnLeft;

		public ToolStripMenuItem mInsertColumnRight;

		public ToolStripMenuItem mDeleteColumn;

		public ToolStripSeparator toolStripMenuItem2;

		public ToolStripMenuItem mMergeCell;

		public ToolStripMenuItem mSplitCell;

		public ToolStripSeparator toolStripSeparator19;

		public ToolStripMenuItem mHeaderRow;

		public ToolStripMenuItem mTools;

		public ToolStripMenuItem mWordCount;

		public ToolStripSeparator toolStripSeparator10;

		public ToolStripMenuItem mConfig;

		public ToolStripMenuItem mDocumentValueValidate;

		public ToolStripMenuItem mEditVBAScript;

		public ToolStrip mainToolStrip;

		public ToolStripButton btnCut;

		public ToolStripButton btnCopy;

		public ToolStripButton btnPaste;

		public ToolStripSeparator toolStripSeparator12;

		public ToolStripButton btnUndo;

		public ToolStripButton btnRedo;

		public ToolStripSeparator toolStripSeparator13;

		public ToolStripComboBox cboFontName;

		public ToolStripComboBox cboFontSize;

		public ToolStripButton btnFont;

		public ToolStripButton btnBold;

		public ToolStripButton btnItalic;

		public ToolStripButton btnUnderline;

		public ToolStripButton btnColor;

		public ToolStripButton btnBackColor;

		public ToolStripButton btnSup;

		public ToolStripButton btnSub;

		public ToolStripSeparator toolStripSeparator14;

		public ToolStripButton btnAlignLeft;

		public ToolStripButton btnAlignCenter;

		public ToolStripButton btnAlignRight;

		public ToolStripSeparator toolStripSeparator15;

		public ToolStripButton btnNumberedList;

		public ToolStripButton btnBulletedList;

		public ToolStripMenuItem cmCut;

		public ToolStripMenuItem cmCopy;

		public ToolStripMenuItem cmUndo;

		public ToolStripMenuItem cmPaste;

		public ToolStripMenuItem cmRedo;

		public ToolStripMenuItem cmDelete;

		public ToolStripMenuItem cmColor;

		public ToolStripMenuItem cmFont;

		public ToolStripMenuItem cmAlignLeft;

		public ToolStripMenuItem cmAlignCenter;

		public ToolStripMenuItem cmAlignRight;

		public ToolStripMenuItem cmProperties;

		public ImageList myImageList;

		public ToolStripSeparator toolStripMenuItem4;

		public ToolStripSeparator toolStripMenuItem5;

		public ContextMenuStrip cmEdit;

		public ToolStripSeparator toolStripMenuItem6;

		public ToolStripSeparator toolStripMenuItem8;

		public WriterControl myEditControl;

		public ContextMenuStrip cmImage;

		public ToolStripMenuItem cmi_Redo;

		public ToolStripMenuItem cmi_Undo;

		public ToolStripSeparator toolStripSeparator27;

		public ToolStripMenuItem cmi_Cut;

		public ToolStripMenuItem cmi_Copy;

		public ToolStripMenuItem cmi_Paste;

		public ToolStripMenuItem cmi_Delete;

		public ToolStripSeparator toolStripSeparator28;

		public ToolStripMenuItem cmi_Properties;

		public ToolStripSeparator toolStripSeparator31;

		public ToolStripMenuItem cmi_BorderBackground;

		public ToolStripMenuItem cmi_EditImage;

		public ToolStripMenuItem mDocumentGridLine;

		public ContextMenuStrip cmTableCell;

		public ToolStripMenuItem cmc_Redo;

		public ToolStripMenuItem cmc_Undo;

		public ToolStripSeparator toolStripSeparator34;

		public ToolStripMenuItem cmc_Cut;

		public ToolStripMenuItem cmc_Copy;

		public ToolStripMenuItem cmc_Paste;

		public ToolStripMenuItem cmc_TableRowProperties;

		public ToolStripMenuItem cmc_CellProperties;

		public ToolStripSeparator toolStripSeparator37;

		public ToolStripMenuItem cmc_CellContentAlign;

		public ToolStripMenuItem toolStripMenuItem28;

		public ToolStripMenuItem toolStripMenuItem29;

		public ToolStripMenuItem toolStripMenuItem30;

		public ToolStripMenuItem toolStripMenuItem31;

		public ToolStripMenuItem toolStripMenuItem32;

		public ToolStripMenuItem toolStripMenuItem33;

		public ToolStripMenuItem toolStripMenuItem34;

		public ToolStripMenuItem toolStripMenuItem35;

		public ToolStripMenuItem toolStripMenuItem36;

		public ToolStripMenuItem cmc_Insert;

		public ToolStripMenuItem toolStripMenuItem37;

		public ToolStripMenuItem toolStripMenuItem38;

		public ToolStripSeparator toolStripSeparator38;

		public ToolStripMenuItem toolStripMenuItem40;

		public ToolStripMenuItem toolStripMenuItem9;

		public ToolStripMenuItem cmc_DeleteRow;

		public ToolStripMenuItem cmc_DeleteColumn;

		public ToolStripSeparator toolStripSeparator39;

		public ToolStripMenuItem cmc_MergeCell;

		public ToolStripMenuItem cmc_SplitCell;

		public ToolStripSeparator toolStripMenuItem14;

		public ToolStripMenuItem cmc_CellBorderBackground;

		public ToolStripMenuItem mPrintPreview;

		public ToolStripMenuItem cmc_Properties;

		public ToolStripSeparator toolStripMenuItem17;

		public ToolStripMenuItem mHeaderBottomLine;

		public ToolStripSeparator toolStripSeparator2;

		public ToolStripMenuItem cmi_EmitInText;

		public ToolStripMenuItem cmi_TextSurrdings;

		public TreeView tvwNavigate;

		public SplitContainer mySplitContainer;

		private TabControl tabFunction;

		private TabPage tpNavigate;

		private TabPage tpTrack;

		private ListBox lstTrack;

		public ContextMenuStrip cmField;

		public ToolStripMenuItem cmf_Undo;

		public ToolStripMenuItem cmf_Redo;

		public ToolStripSeparator toolStripSeparator3;

		public ToolStripMenuItem cmf_Cut;

		public ToolStripMenuItem cmf_Copy;

		public ToolStripMenuItem cmf_Paste;

		public ToolStripMenuItem cmf_Delete;

		private ToolStripMenuItem cmf_ClearFieldValue;

		public ToolStripSeparator toolStripSeparator11;

		public ToolStripMenuItem cmf_Color;

		public ToolStripMenuItem cmf_Font;

		public ToolStripSeparator toolStripSeparator22;

		public ToolStripMenuItem cmf_LeftAlign;

		public ToolStripMenuItem cmf_AlignCenter;

		public ToolStripMenuItem cmf_AlignRight;

		public ToolStripSeparator toolStripSeparator23;

		public ToolStripMenuItem cmf_ElementProperties;

		private bool _fSafeForScripting;

		private bool _fSafeForInitializing;

		private FunctionControlVisibility _TrackListVisible;

		private TrackListBoxControler _TrackList;

		private FunctionControlVisibility _NavigateTreeVisible;

		private NavigateTreeViewControler _NavigateTreeView;

		/// <summary>
		///       布局停靠样式，仅仅向COM接口提供该属性
		///       </summary>
		[Browsable(false)]
		[DefaultValue(0)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LayoutDock
		{
			get
			{
				return (int)Dock;
			}
			set
			{
				Dock = (DockStyle)value;
			}
		}

		/// <summary>
		///       移动焦点使用的快捷键
		///       </summary>
		[DefaultValue(MoveFocusHotKeys.None)]
		[Category("Behavior")]
		[Description("移动输入焦点使用的快捷键模式")]
		public MoveFocusHotKeys MoveFocusHotKey
		{
			get
			{
				return myEditControl.MoveFocusHotKey;
			}
			set
			{
				myEditControl.MoveFocusHotKey = value;
			}
		}

		/// <summary>
		///       当前文档内容版本号，对文档内容的任何修改都会使得该版本号增加
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DocumentContentVersion => myEditControl.DocumentContentVersion;

		/// <summary>
		///       文档控制器
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentControler DocumentControler => myEditControl.DocumentControler;

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public WriterAppHost AppHost
		{
			get
			{
				return myEditControl.AppHost;
			}
			set
			{
				myEditControl.AppHost = value;
			}
		}

		/// <summary>
		///       当前元素样式
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentContentStyle CurrentStyle => myEditControl.CurrentStyle;

		/// <summary>
		///       当前插入点所在的元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextElement CurrentElement => myEditControl.CurrentElement;

		/// <summary>
		///       鼠标悬停的元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextElement HoverElement => myEditControl.HoverElement;

		/// <summary>
		///       当前文本行
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextLine CurrentLine => myEditControl.CurrentLine;

		/// <summary>
		///       文档中当前元素或被选择区域的开始位置在编辑器控件客户区中的坐标
		///       </summary>
		public Point SelectionStartPosition => myEditControl.SelectionStartPosition;

		/// <summary>
		///       获得从1开始计算的当前列号
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int CurrentColumnIndex => myEditControl.CurrentColumnIndex;

		/// <summary>
		///       当前行号
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int CurrentLineIndex => myEditControl.CurrentLineIndex;

		/// <summary>
		///       获得从1开始计算的当前文本行在页中的序号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int CurrentLineIndexInPage => myEditControl.CurrentLineIndexInPage;

		/// <summary>
		///       获得从1开始计算的当前页号
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int CurrentPageIndex => Document.PageIndex;

		/// <summary>
		///       文档选择的部分
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextSelection Selection => myEditControl.Selection;

		/// <summary>
		///       页面标题位置
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PageTitlePosition PageTitlePosition
		{
			get
			{
				return myEditControl.PageTitlePosition;
			}
			set
			{
				myEditControl.PageTitlePosition = value;
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
				return myEditControl.ViewMode;
			}
			set
			{
				myEditControl.ViewMode = value;
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[Category("Data")]
		[DefaultValue(null)]
		public string RegisterCode
		{
			get
			{
				return myEditControl.RegisterCode;
			}
			set
			{
				myEditControl.RegisterCode = value;
			}
		}

		/// <summary>
		///       违禁关键字
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string ExcludeKeywords
		{
			get
			{
				return myEditControl.ExcludeKeywords;
			}
			set
			{
				myEditControl.ExcludeKeywords = value;
			}
		}

		/// <summary>
		///       内置的文档编辑器控件
		///       </summary>
		[Browsable(false)]
		public WriterControl InnerWriterControl => myEditControl;

		internal bool InDesignMode => base.DesignMode;

		/// <summary>
		///       自动设置文档的默认字体
		///       </summary>
		/// <remarks>若该属性值为true，则编辑器会自动将控件的字体和前景色设置到文档的默认字体和文本颜色。</remarks>
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool AutoSetDocumentDefaultFont
		{
			get
			{
				return myEditControl.AutoSetDocumentDefaultFont;
			}
			set
			{
				myEditControl.AutoSetDocumentDefaultFont = value;
			}
		}

		/// <summary>
		///       能否直接拖拽文档内容
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool AllowDragContent
		{
			get
			{
				return myEditControl.AllowDragContent;
			}
			set
			{
				myEditControl.AllowDragContent = value;
			}
		}

		/// <summary>
		///       表示文档内容的纯文本内容
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				return myEditControl.Text;
			}
			set
			{
				myEditControl.Text = value;
			}
		}

		/// <summary>
		///       表示文档内容的RTF文本
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string RTFText
		{
			get
			{
				return myEditControl.RTFText;
			}
			set
			{
				myEditControl.RTFText = value;
			}
		}

		/// <summary>
		///       表示文档内容的XML文本
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string XMLText
		{
			get
			{
				return myEditControl.XMLText;
			}
			set
			{
				myEditControl.XMLText = value;
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
				return myEditControl.Readonly;
			}
			set
			{
				myEditControl.Readonly = value;
			}
		}

		/// <summary>
		///       页眉页脚是否只读
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool HeaderFooterReadonly
		{
			get
			{
				return myEditControl.HeaderFooterReadonly;
			}
			set
			{
				myEditControl.HeaderFooterReadonly = value;
			}
		}

		/// <summary>
		///       初始化是用的参数列表，格式为“参数名:参数值;参数名:参数值;”。
		///       </summary>
		[Category("Data")]
		[DefaultValue(null)]
		public string InitalizeParameterValues
		{
			get
			{
				return myEditControl.InitalizeParameterValues;
			}
			set
			{
				myEditControl.InitalizeParameterValues = value;
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
				return myEditControl.FormView;
			}
			set
			{
				myEditControl.FormView = value;
			}
		}

		/// <summary>
		///       文档内容改变标记
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Modified
		{
			get
			{
				return myEditControl.Modified;
			}
			set
			{
				myEditControl.Modified = value;
			}
		}

		/// <summary>
		///       服务器对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public object ServerObject
		{
			get
			{
				return myEditControl.ServerObject;
			}
			set
			{
				myEditControl.ServerObject = value;
			}
		}

		/// <summary>
		///       文档设置
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentOptions DocumentOptions
		{
			get
			{
				return myEditControl.DocumentOptions;
			}
			set
			{
				myEditControl.DocumentOptions = value;
			}
		}

		/// <summary>
		///       文档基础路径
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string DocumentBaseUrl
		{
			get
			{
				return myEditControl.DocumentBaseUrl;
			}
			set
			{
				myEditControl.DocumentBaseUrl = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextDocument Document
		{
			get
			{
				return myEditControl.Document;
			}
			set
			{
				myEditControl.Document = value;
			}
		}

		/// <summary>
		///       是否以管理员模式运行
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsAdministrator
		{
			get
			{
				return myEditControl.IsAdministrator;
			}
			set
			{
				myEditControl.IsAdministrator = true;
			}
		}

		/// <summary>
		///       文档内容导航者
		///       </summary>
		[Browsable(false)]
		public DocumentNavigator Navigator => myEditControl.Navigator;

		/// <summary>
		///       每打开文档时自动进行用户登录
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AutoUserLogin
		{
			get
			{
				return myEditControl.AutoUserLogin;
			}
			set
			{
				myEditControl.AutoUserLogin = value;
			}
		}

		/// <summary>
		///       执行自动登录时使用的用户登录信息
		///       </summary>
		[Obsolete("★★★★推荐使用WriterAppHost.Services.AddService( CurrentUserInfo类型的对象实例)")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public UserLoginInfo AutoUserLoginInfo
		{
			get
			{
				return myEditControl.AutoUserLoginInfo;
			}
			set
			{
				myEditControl.AutoUserLoginInfo = value;
			}
		}

		/// <summary>
		///       表单数据组成在字典
		///       </summary>
		[ComVisible(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Hashtable FormValues => myEditControl.FormValues;

		/// <summary>
		///       表单数据组成的字符串数组，序号为偶数的元素为名称，序号为奇数的元素为数值。
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string[] FormValuesArray => myEditControl.FormValuesArray;

		/// <summary>
		///       是否允许续打
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool EnableJumpPrint
		{
			get
			{
				return myEditControl.EnableJumpPrint;
			}
			set
			{
				myEditControl.EnableJumpPrint = value;
			}
		}

		/// <summary>
		///       续打位置
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public float JumpPrintPosition
		{
			get
			{
				return myEditControl.JumpPrintPosition;
			}
			set
			{
				myEditControl.JumpPrintPosition = value;
			}
		}

		/// <summary>
		///       续打结束位置
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public float JumpPrintEndPosition
		{
			get
			{
				return myEditControl.JumpPrintEndPosition;
			}
			set
			{
				myEditControl.JumpPrintEndPosition = value;
			}
		}

		/// <summary>
		///       状态文本
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string StatusText
		{
			get
			{
				return myEditControl.StatusText;
			}
			set
			{
				myEditControl.SetStatusText(value);
			}
		}

		/// <summary>
		///        表示当前插入点位置信息的字符串
		///       </summary>
		[Browsable(false)]
		public string PositionInfoText => myEditControl.PositionInfoText;

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[Browsable(false)]
		public TextWindowsFormsEditorHost EditorHost => myEditControl.EditorHost;

		/// <summary>
		///       是否允许触发文档元素级事件
		///       </summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool EnabledElementEvent
		{
			get
			{
				return InnerWriterControl.EnabledElementEvent;
			}
			set
			{
				InnerWriterControl.EnabledElementEvent = value;
			}
		}

		/// <summary>
		///       文档元素事件模板列表
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ElementEventTemplateList EventTemplates
		{
			get
			{
				return InnerWriterControl.EventTemplates;
			}
			set
			{
				InnerWriterControl.EventTemplates = value;
			}
		}

		/// <summary>
		///       全局文档元素事件模板列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ElementEventTemlateMap GlobalEventTemplates
		{
			get
			{
				return InnerWriterControl.GlobalEventTemplates;
			}
			set
			{
				InnerWriterControl.GlobalEventTemplates = value;
			}
		}

		/// <summary>
		///       文本域元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_Field
		{
			get
			{
				return InnerWriterControl.GlobalEventTemplate_Field;
			}
			set
			{
				InnerWriterControl.GlobalEventTemplate_Field = value;
			}
		}

		/// <summary>
		///       单元格元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_Cell
		{
			get
			{
				return InnerWriterControl.GlobalEventTemplate_Cell;
			}
			set
			{
				InnerWriterControl.GlobalEventTemplate_Cell = value;
			}
		}

		/// <summary>
		///       图片元素全局事件模板对象。
		///       </summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_Image
		{
			get
			{
				return InnerWriterControl.GlobalEventTemplate_Image;
			}
			set
			{
				InnerWriterControl.GlobalEventTemplate_Image = value;
			}
		}

		/// <summary>
		///       所有类型元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_Element
		{
			get
			{
				return InnerWriterControl.GlobalEventTemplate_Element;
			}
			set
			{
				InnerWriterControl.GlobalEventTemplate_Element = value;
			}
		}

		/// <summary>
		///       用户修改痕迹列表可见性设置
		///       </summary>
		[Description("用户修改痕迹列表可见性设置")]
		[DefaultValue(FunctionControlVisibility.Auto)]
		public FunctionControlVisibility TrackListVisible
		{
			get
			{
				return _TrackListVisible;
			}
			set
			{
				if (_TrackListVisible != value)
				{
					_TrackListVisible = value;
					if (myEditControl.IsHandleCreated && tvwNavigate.IsHandleCreated)
					{
						RefreshFunctionControl();
					}
				}
			}
		}

		/// <summary>
		///       导航树状列表可见性设置
		///       </summary>
		[Description("导航树状列表可见性设置")]
		[DefaultValue(FunctionControlVisibility.Auto)]
		public FunctionControlVisibility NavigateTreeVisible
		{
			get
			{
				return _NavigateTreeVisible;
			}
			set
			{
				_NavigateTreeVisible = value;
				if (myEditControl.IsHandleCreated && tvwNavigate.IsHandleCreated)
				{
					RefreshFunctionControl();
				}
			}
		}

		/// <summary>
		///       针对COM而声明的文档内容选择状态发生改变事件
		///       </summary>
		[Browsable(false)]
		public event VoidEventHandler ComEventSelectionChanged;

		/// <summary>
		///       针对COM声明的事件
		///       </summary>
		[Browsable(false)]
		public event VoidEventHandler ComEventDocumentLoad;

		/// <summary>
		///       针对COM声明的事件
		///       </summary>
		[Browsable(false)]
		public event VoidEventHandler ComEventDocumentContentChanged;

		/// <summary>
		///       针对COM声明的事件
		///       </summary>
		[Browsable(false)]
		public event VoidEventHandler ComEventStatusTextChanged;

		/// <summary>
		///       解释列表项目的事件
		///       </summary>
		[Description("解释列表项目的事件")]
		public event ParseSelectedItemsEventHandler EventParseSelectedItems;

		/// <summary>
		///       获得列表显示文本事件
		///       </summary>
		[Description("获得列表显示文本事件")]
		public event FormatListItemsEventHandler EventFormatListItems;

		/// <summary>
		///       未知编辑器命令事件
		///       </summary>
		[Description("未知编辑器命令事件")]
		public event WriterCommandEventHandler EventUnknowCommand;

		/// <summary>
		///       查询知识库节点列表事件
		///       </summary>
		[Description("查询知识库节点列表事件")]
		public event QueryKBEntriesEventHandler QueryKBEntries;

		/// <summary>
		///       增强型鼠标按下事件
		///       </summary>
		[Description("增强型鼠标按下事件")]
		public event WriterMouseEventHandler MouseDownExt;

		/// <summary>
		///       增强型鼠标移动事件
		///       </summary>
		[Description("增强型鼠标移动事件")]
		public event WriterMouseEventHandler MouseMoveExt;

		/// <summary>
		///       增强型鼠标按键松开事件
		///       </summary>
		[Description("增强型鼠标按键松开事件")]
		public event WriterMouseEventHandler MouseUpExt;

		/// <summary>
		///       数据过滤事件
		///       </summary>
		[Description("数据过滤事件")]
		public event FilterValueEventHandler FilterValue;

		/// <summary>
		///       根据知识库节点创建文档元素对象的事件
		///       </summary>
		[Description("根据知识库节点创建文档元素对象的事件")]
		public event CreateElementsByKBEntryEventHandler EventCreateElementsByKBEntry;

		/// <summary>
		///       当前鼠标悬浮的元素改变事件
		///       </summary>
		[Description("当前鼠标悬浮的元素改变事件")]
		public event WriterEventHandler HoverElementChanged;

		/// <summary>
		///       文档加载事件
		///       </summary>
		[Description("文档加载事件")]
		public event WriterEventHandler DocumentLoad;

		/// <summary>
		///       向文档插入对象事件
		///       </summary>
		[Description("向文档插入对象事件")]
		public event InsertObjectEventHandler EventInsertObject;

		/// <summary>
		///       判断能否插入对象事件
		///       </summary>
		[Description("判断能否插入对象事件")]
		public event CanInsertObjectEventHandler EventCanInsertObject;

		/// <summary>
		///       状态栏文本发生改变事件
		///       </summary>
		[Description("状态栏文本发生改变事件")]
		public event StatusTextChangedEventHandler StatusTextChanged;

		/// <summary>
		///       文档选择状态正在发生改变事件
		///       </summary>
		[Description("文档选择状态正在发生改变事件")]
		public event SelectionChangingEventHandler SelectionChanging;

		/// <summary>
		///       文档选择状态发生改变后的事件
		///       </summary>
		[Description("文档选择状态发生改变后的事件")]
		public event WriterEventHandler SelectionChanged;

		/// <summary>
		///       文档内容发生改变事件
		///       </summary>
		[Description("文档内容发生改变事件")]
		public event WriterEventHandler DocumentContentChanged;

		/// <summary>
		///       查询下拉列表项目事件
		///       </summary>
		[Description("查询下拉列表项目事件")]
		public event QueryListItemsEventHandler QueryListItems;

		/// <summary>
		///       文档内容中的用户修改痕迹列表信息发生改变事件
		///       </summary>
		[Description("文档内容中的用户修改痕迹列表信息发生改变事件")]
		public event WriterEventHandler UserTrackListChanged;

		/// <summary>
		///       文档内容的导航数据发生改变事件
		///       </summary>
		[Description("文档内容的导航数据发生改变事件")]
		public event WriterEventHandler DocumentNavigateContentChanged;

		/// <summary>
		///       结束执行编辑器命令事件
		///       </summary>
		[Description("结束执行编辑器命令事件")]
		public event WriterCommandEventHandler AfterExecuteCommand;

		/// <summary>
		///       脚本发生错误事件
		///       </summary>
		[Description("脚本发生错误事件")]
		public event WriterEventHandler ScriptError;

		/// <summary>
		///       自定义处理命令错误的事件
		///       </summary>
		[Description("自定义处理命令错误的事件")]
		public event CommandErrorEventHandler CommandError;

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.WriterControlExt));
			myEditControl = new DCSoft.Writer.Controls.WriterControl();
			cmEdit = new System.Windows.Forms.ContextMenuStrip(components);
			cmRedo = new System.Windows.Forms.ToolStripMenuItem();
			cmUndo = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			cmCut = new System.Windows.Forms.ToolStripMenuItem();
			cmCopy = new System.Windows.Forms.ToolStripMenuItem();
			cmPaste = new System.Windows.Forms.ToolStripMenuItem();
			cmDelete = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			cmColor = new System.Windows.Forms.ToolStripMenuItem();
			cmFont = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			cmAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
			cmAlignCenter = new System.Windows.Forms.ToolStripMenuItem();
			cmAlignRight = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			cmProperties = new System.Windows.Forms.ToolStripMenuItem();
			mainMenuStrip = new System.Windows.Forms.MenuStrip();
			menuFile = new System.Windows.Forms.ToolStripMenuItem();
			menuPageSettings = new System.Windows.Forms.ToolStripMenuItem();
			mPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			mPrint = new System.Windows.Forms.ToolStripMenuItem();
			mCleanPrint = new System.Windows.Forms.ToolStripMenuItem();
			menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mUndo = new System.Windows.Forms.ToolStripMenuItem();
			mRedo = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			mCut = new System.Windows.Forms.ToolStripMenuItem();
			mCopy = new System.Windows.Forms.ToolStripMenuItem();
			mPaste = new System.Windows.Forms.ToolStripMenuItem();
			mSpecifyPaste = new System.Windows.Forms.ToolStripMenuItem();
			mDelete = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			mSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			mSearch = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			mEditImageShape = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			mSignDocument = new System.Windows.Forms.ToolStripMenuItem();
			menuView = new System.Windows.Forms.ToolStripMenuItem();
			mJumpPrint = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			mPageViewMode = new System.Windows.Forms.ToolStripMenuItem();
			mNormalViewMode = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			mCleanViewMode = new System.Windows.Forms.ToolStripMenuItem();
			mComplexViewMode = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
			mDocumentGridLine = new System.Windows.Forms.ToolStripMenuItem();
			mHeaderBottomLine = new System.Windows.Forms.ToolStripMenuItem();
			menuInsert = new System.Windows.Forms.ToolStripMenuItem();
			mInsertImage = new System.Windows.Forms.ToolStripMenuItem();
			mInsertInputField = new System.Windows.Forms.ToolStripMenuItem();
			mInsertParameter = new System.Windows.Forms.ToolStripMenuItem();
			mInsertCheckBox = new System.Windows.Forms.ToolStripMenuItem();
			mInsertMedicalExpression = new System.Windows.Forms.ToolStripMenuItem();
			mInsertBarcode = new System.Windows.Forms.ToolStripMenuItem();
			mInsertPageInfo = new System.Windows.Forms.ToolStripMenuItem();
			mInsertXML = new System.Windows.Forms.ToolStripMenuItem();
			mInsertFileContent = new System.Windows.Forms.ToolStripMenuItem();
			mInsertContentLink = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			mDeleteField = new System.Windows.Forms.ToolStripMenuItem();
			menuFormat = new System.Windows.Forms.ToolStripMenuItem();
			mParagraphFormat = new System.Windows.Forms.ToolStripMenuItem();
			mFont = new System.Windows.Forms.ToolStripMenuItem();
			mTextColor = new System.Windows.Forms.ToolStripMenuItem();
			mBackColor = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			mSup = new System.Windows.Forms.ToolStripMenuItem();
			mSub = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			mAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
			mCenterAlign = new System.Windows.Forms.ToolStripMenuItem();
			mRightAlign = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			mNumerList = new System.Windows.Forms.ToolStripMenuItem();
			mBulleteList = new System.Windows.Forms.ToolStripMenuItem();
			mFirstIndent = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
			mFieldFixedWidth = new System.Windows.Forms.ToolStripMenuItem();
			mTable = new System.Windows.Forms.ToolStripMenuItem();
			mInsertTable = new System.Windows.Forms.ToolStripMenuItem();
			mDeleteTable = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			mCellAlign = new System.Windows.Forms.ToolStripMenuItem();
			mAlignTopLeft = new System.Windows.Forms.ToolStripMenuItem();
			mAlignTopCenter = new System.Windows.Forms.ToolStripMenuItem();
			mAlignTopRight = new System.Windows.Forms.ToolStripMenuItem();
			mAlignMiddleLeft = new System.Windows.Forms.ToolStripMenuItem();
			mAlignMiddleCenter = new System.Windows.Forms.ToolStripMenuItem();
			mAlignMiddleRight = new System.Windows.Forms.ToolStripMenuItem();
			mAlignBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
			mAlignBottomCenter = new System.Windows.Forms.ToolStripMenuItem();
			mAlignBottomRight = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			mInsertRowUp = new System.Windows.Forms.ToolStripMenuItem();
			mInsertRowDown = new System.Windows.Forms.ToolStripMenuItem();
			mDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			mInsertColumnLeft = new System.Windows.Forms.ToolStripMenuItem();
			mInsertColumnRight = new System.Windows.Forms.ToolStripMenuItem();
			mDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			mMergeCell = new System.Windows.Forms.ToolStripMenuItem();
			mSplitCell = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			mHeaderRow = new System.Windows.Forms.ToolStripMenuItem();
			mTools = new System.Windows.Forms.ToolStripMenuItem();
			mWordCount = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			mConfig = new System.Windows.Forms.ToolStripMenuItem();
			mDocumentValueValidate = new System.Windows.Forms.ToolStripMenuItem();
			mEditVBAScript = new System.Windows.Forms.ToolStripMenuItem();
			mainToolStrip = new System.Windows.Forms.ToolStrip();
			btnCut = new System.Windows.Forms.ToolStripButton();
			btnCopy = new System.Windows.Forms.ToolStripButton();
			btnPaste = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			btnUndo = new System.Windows.Forms.ToolStripButton();
			btnRedo = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			cboFontName = new System.Windows.Forms.ToolStripComboBox();
			cboFontSize = new System.Windows.Forms.ToolStripComboBox();
			btnFont = new System.Windows.Forms.ToolStripButton();
			btnBold = new System.Windows.Forms.ToolStripButton();
			btnItalic = new System.Windows.Forms.ToolStripButton();
			btnUnderline = new System.Windows.Forms.ToolStripButton();
			btnColor = new System.Windows.Forms.ToolStripButton();
			btnBackColor = new System.Windows.Forms.ToolStripButton();
			btnSup = new System.Windows.Forms.ToolStripButton();
			btnSub = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			btnAlignLeft = new System.Windows.Forms.ToolStripButton();
			btnAlignCenter = new System.Windows.Forms.ToolStripButton();
			btnAlignRight = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			btnNumberedList = new System.Windows.Forms.ToolStripButton();
			btnBulletedList = new System.Windows.Forms.ToolStripButton();
			myImageList = new System.Windows.Forms.ImageList(components);
			myCommandControler = new DCSoft.Writer.Commands.WriterCommandControler(components);
			cmi_Redo = new System.Windows.Forms.ToolStripMenuItem();
			cmi_Undo = new System.Windows.Forms.ToolStripMenuItem();
			cmi_Cut = new System.Windows.Forms.ToolStripMenuItem();
			cmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
			cmi_Paste = new System.Windows.Forms.ToolStripMenuItem();
			cmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
			cmi_Properties = new System.Windows.Forms.ToolStripMenuItem();
			cmi_EditImage = new System.Windows.Forms.ToolStripMenuItem();
			cmi_BorderBackground = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Redo = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Undo = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Cut = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Copy = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Paste = new System.Windows.Forms.ToolStripMenuItem();
			cmc_TableRowProperties = new System.Windows.Forms.ToolStripMenuItem();
			cmc_CellProperties = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem30 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem34 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem35 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem36 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem37 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem38 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			cmc_DeleteRow = new System.Windows.Forms.ToolStripMenuItem();
			cmc_DeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
			cmc_MergeCell = new System.Windows.Forms.ToolStripMenuItem();
			cmc_SplitCell = new System.Windows.Forms.ToolStripMenuItem();
			cmc_CellBorderBackground = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Properties = new System.Windows.Forms.ToolStripMenuItem();
			cmi_EmitInText = new System.Windows.Forms.ToolStripMenuItem();
			cmi_TextSurrdings = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Undo = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Redo = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Cut = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Copy = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Paste = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Delete = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Color = new System.Windows.Forms.ToolStripMenuItem();
			cmf_Font = new System.Windows.Forms.ToolStripMenuItem();
			cmf_LeftAlign = new System.Windows.Forms.ToolStripMenuItem();
			cmf_AlignCenter = new System.Windows.Forms.ToolStripMenuItem();
			cmf_AlignRight = new System.Windows.Forms.ToolStripMenuItem();
			cmf_ElementProperties = new System.Windows.Forms.ToolStripMenuItem();
			cmf_ClearFieldValue = new System.Windows.Forms.ToolStripMenuItem();
			cmImage = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			cmTableCell = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator37 = new System.Windows.Forms.ToolStripSeparator();
			cmc_CellContentAlign = new System.Windows.Forms.ToolStripMenuItem();
			cmc_Insert = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator39 = new System.Windows.Forms.ToolStripSeparator();
			tvwNavigate = new System.Windows.Forms.TreeView();
			mySplitContainer = new System.Windows.Forms.SplitContainer();
			tabFunction = new System.Windows.Forms.TabControl();
			tpNavigate = new System.Windows.Forms.TabPage();
			tpTrack = new System.Windows.Forms.TabPage();
			lstTrack = new System.Windows.Forms.ListBox();
			cmField = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			cmEdit.SuspendLayout();
			mainMenuStrip.SuspendLayout();
			mainToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)myCommandControler).BeginInit();
			cmImage.SuspendLayout();
			cmTableCell.SuspendLayout();
			mySplitContainer.Panel1.SuspendLayout();
			mySplitContainer.Panel2.SuspendLayout();
			mySplitContainer.SuspendLayout();
			tabFunction.SuspendLayout();
			tpNavigate.SuspendLayout();
			tpTrack.SuspendLayout();
			cmField.SuspendLayout();
			SuspendLayout();
			myEditControl.AllowDrop = true;
			resources.ApplyResources(myEditControl, "myEditControl");
			myEditControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
			myEditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			myEditControl.ContextMenuStrip = cmEdit;
			myEditControl.CurrentContentPartyStyle = DCSoft.Drawing.PageContentPartyStyle.Body;
			myEditControl.Name = "myEditControl";
			cmEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[16]
			{
				cmRedo,
				cmUndo,
				toolStripMenuItem4,
				cmCut,
				cmCopy,
				cmPaste,
				cmDelete,
				toolStripMenuItem5,
				cmColor,
				cmFont,
				toolStripMenuItem6,
				cmAlignLeft,
				cmAlignCenter,
				cmAlignRight,
				toolStripMenuItem8,
				cmProperties
			});
			cmEdit.Name = "cmEdit";
			resources.ApplyResources(cmEdit, "cmEdit");
			myCommandControler.SetCommandName(cmRedo, "Redo");
			resources.ApplyResources(cmRedo, "cmRedo");
			cmRedo.Name = "cmRedo";
			myCommandControler.SetCommandName(cmUndo, "Undo");
			resources.ApplyResources(cmUndo, "cmUndo");
			cmUndo.Name = "cmUndo";
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			resources.ApplyResources(toolStripMenuItem4, "toolStripMenuItem4");
			myCommandControler.SetCommandName(cmCut, "Cut");
			resources.ApplyResources(cmCut, "cmCut");
			cmCut.Name = "cmCut";
			myCommandControler.SetCommandName(cmCopy, "Copy");
			resources.ApplyResources(cmCopy, "cmCopy");
			cmCopy.Name = "cmCopy";
			myCommandControler.SetCommandName(cmPaste, "Paste");
			resources.ApplyResources(cmPaste, "cmPaste");
			cmPaste.Name = "cmPaste";
			myCommandControler.SetCommandName(cmDelete, "Delete");
			resources.ApplyResources(cmDelete, "cmDelete");
			cmDelete.Name = "cmDelete";
			toolStripMenuItem5.Name = "toolStripMenuItem5";
			resources.ApplyResources(toolStripMenuItem5, "toolStripMenuItem5");
			myCommandControler.SetCommandName(cmColor, "Color");
			cmColor.Name = "cmColor";
			resources.ApplyResources(cmColor, "cmColor");
			myCommandControler.SetCommandName(cmFont, "Font");
			resources.ApplyResources(cmFont, "cmFont");
			cmFont.Name = "cmFont";
			toolStripMenuItem6.Name = "toolStripMenuItem6";
			resources.ApplyResources(toolStripMenuItem6, "toolStripMenuItem6");
			myCommandControler.SetCommandName(cmAlignLeft, "AlignLeft");
			resources.ApplyResources(cmAlignLeft, "cmAlignLeft");
			cmAlignLeft.Name = "cmAlignLeft";
			myCommandControler.SetCommandName(cmAlignCenter, "AlignCenter");
			resources.ApplyResources(cmAlignCenter, "cmAlignCenter");
			cmAlignCenter.Name = "cmAlignCenter";
			myCommandControler.SetCommandName(cmAlignRight, "AlignRight");
			resources.ApplyResources(cmAlignRight, "cmAlignRight");
			cmAlignRight.Name = "cmAlignRight";
			toolStripMenuItem8.Name = "toolStripMenuItem8";
			resources.ApplyResources(toolStripMenuItem8, "toolStripMenuItem8");
			myCommandControler.SetCommandName(cmProperties, "ElementProperties");
			cmProperties.Name = "cmProperties";
			resources.ApplyResources(cmProperties, "cmProperties");
			mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[7]
			{
				menuFile,
				menuEdit,
				menuView,
				menuInsert,
				menuFormat,
				mTable,
				mTools
			});
			resources.ApplyResources(mainMenuStrip, "mainMenuStrip");
			mainMenuStrip.Name = "mainMenuStrip";
			menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				menuPageSettings,
				mPrintPreview,
				mPrint,
				mCleanPrint
			});
			menuFile.Name = "menuFile";
			resources.ApplyResources(menuFile, "menuFile");
			myCommandControler.SetCommandName(menuPageSettings, "FilePageSettings");
			resources.ApplyResources(menuPageSettings, "menuPageSettings");
			menuPageSettings.Name = "menuPageSettings";
			myCommandControler.SetCommandName(mPrintPreview, "FilePrintPreview");
			resources.ApplyResources(mPrintPreview, "mPrintPreview");
			mPrintPreview.Name = "mPrintPreview";
			myCommandControler.SetCommandName(mPrint, "FilePrint");
			resources.ApplyResources(mPrint, "mPrint");
			mPrint.Name = "mPrint";
			myCommandControler.SetCommandName(mCleanPrint, "FileCleanPrint");
			resources.ApplyResources(mCleanPrint, "mCleanPrint");
			mCleanPrint.Name = "mCleanPrint";
			menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[16]
			{
				mUndo,
				mRedo,
				toolStripSeparator4,
				mCut,
				mCopy,
				mPaste,
				mSpecifyPaste,
				mDelete,
				toolStripSeparator5,
				mSelectAll,
				toolStripSeparator6,
				mSearch,
				toolStripSeparator17,
				mEditImageShape,
				toolStripSeparator1,
				mSignDocument
			});
			menuEdit.Name = "menuEdit";
			resources.ApplyResources(menuEdit, "menuEdit");
			myCommandControler.SetCommandName(mUndo, "Undo");
			resources.ApplyResources(mUndo, "mUndo");
			mUndo.Name = "mUndo";
			myCommandControler.SetCommandName(mRedo, "Redo");
			resources.ApplyResources(mRedo, "mRedo");
			mRedo.Name = "mRedo";
			toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
			myCommandControler.SetCommandName(mCut, "Cut");
			resources.ApplyResources(mCut, "mCut");
			mCut.Name = "mCut";
			myCommandControler.SetCommandName(mCopy, "Copy");
			resources.ApplyResources(mCopy, "mCopy");
			mCopy.Name = "mCopy";
			myCommandControler.SetCommandName(mPaste, "Paste");
			resources.ApplyResources(mPaste, "mPaste");
			mPaste.Name = "mPaste";
			myCommandControler.SetCommandName(mSpecifyPaste, "SpecifyPaste");
			resources.ApplyResources(mSpecifyPaste, "mSpecifyPaste");
			mSpecifyPaste.Name = "mSpecifyPaste";
			myCommandControler.SetCommandName(mDelete, "Delete");
			resources.ApplyResources(mDelete, "mDelete");
			mDelete.Name = "mDelete";
			toolStripSeparator5.Name = "toolStripSeparator5";
			resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
			myCommandControler.SetCommandName(mSelectAll, "SelectAll");
			mSelectAll.Name = "mSelectAll";
			resources.ApplyResources(mSelectAll, "mSelectAll");
			toolStripSeparator6.Name = "toolStripSeparator6";
			resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
			myCommandControler.SetCommandName(mSearch, "SearchReplace");
			resources.ApplyResources(mSearch, "mSearch");
			mSearch.Name = "mSearch";
			toolStripSeparator17.Name = "toolStripSeparator17";
			resources.ApplyResources(toolStripSeparator17, "toolStripSeparator17");
			myCommandControler.SetCommandName(mEditImageShape, "EditImageAdditionShape");
			resources.ApplyResources(mEditImageShape, "mEditImageShape");
			mEditImageShape.Name = "mEditImageShape";
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			myCommandControler.SetCommandName(mSignDocument, "SignDocument");
			resources.ApplyResources(mSignDocument, "mSignDocument");
			mSignDocument.Name = "mSignDocument";
			menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10]
			{
				mJumpPrint,
				toolStripSeparator18,
				mPageViewMode,
				mNormalViewMode,
				toolStripSeparator21,
				mCleanViewMode,
				mComplexViewMode,
				toolStripMenuItem17,
				mDocumentGridLine,
				mHeaderBottomLine
			});
			menuView.Name = "menuView";
			resources.ApplyResources(menuView, "menuView");
			myCommandControler.SetCommandName(mJumpPrint, "JumpPrintMode");
			mJumpPrint.Name = "mJumpPrint";
			resources.ApplyResources(mJumpPrint, "mJumpPrint");
			toolStripSeparator18.Name = "toolStripSeparator18";
			resources.ApplyResources(toolStripSeparator18, "toolStripSeparator18");
			myCommandControler.SetCommandName(mPageViewMode, "PageViewMode");
			mPageViewMode.Name = "mPageViewMode";
			resources.ApplyResources(mPageViewMode, "mPageViewMode");
			myCommandControler.SetCommandName(mNormalViewMode, "NormalViewMode");
			mNormalViewMode.Name = "mNormalViewMode";
			resources.ApplyResources(mNormalViewMode, "mNormalViewMode");
			toolStripSeparator21.Name = "toolStripSeparator21";
			resources.ApplyResources(toolStripSeparator21, "toolStripSeparator21");
			myCommandControler.SetCommandName(mCleanViewMode, "CleanViewMode");
			mCleanViewMode.Name = "mCleanViewMode";
			resources.ApplyResources(mCleanViewMode, "mCleanViewMode");
			myCommandControler.SetCommandName(mComplexViewMode, "ComplexViewMode");
			mComplexViewMode.Name = "mComplexViewMode";
			resources.ApplyResources(mComplexViewMode, "mComplexViewMode");
			toolStripMenuItem17.Name = "toolStripMenuItem17";
			resources.ApplyResources(toolStripMenuItem17, "toolStripMenuItem17");
			myCommandControler.SetCommandName(mDocumentGridLine, "DocumentGridLineVisible");
			resources.ApplyResources(mDocumentGridLine, "mDocumentGridLine");
			mDocumentGridLine.Name = "mDocumentGridLine";
			myCommandControler.SetCommandName(mHeaderBottomLine, "HeaderBottomLineVisible");
			mHeaderBottomLine.Name = "mHeaderBottomLine";
			resources.ApplyResources(mHeaderBottomLine, "mHeaderBottomLine");
			menuInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				mInsertImage,
				mInsertInputField,
				mInsertParameter,
				mInsertCheckBox,
				mInsertMedicalExpression,
				mInsertBarcode,
				mInsertPageInfo,
				mInsertXML,
				mInsertFileContent,
				mInsertContentLink,
				toolStripMenuItem1,
				mDeleteField
			});
			menuInsert.Name = "menuInsert";
			resources.ApplyResources(menuInsert, "menuInsert");
			myCommandControler.SetCommandName(mInsertImage, "InsertImage");
			resources.ApplyResources(mInsertImage, "mInsertImage");
			mInsertImage.Name = "mInsertImage";
			myCommandControler.SetCommandName(mInsertInputField, "InsertInputField");
			mInsertInputField.Name = "mInsertInputField";
			resources.ApplyResources(mInsertInputField, "mInsertInputField");
			myCommandControler.SetCommandName(mInsertParameter, "InsertParameter");
			resources.ApplyResources(mInsertParameter, "mInsertParameter");
			mInsertParameter.Name = "mInsertParameter";
			myCommandControler.SetCommandName(mInsertCheckBox, "InsertCheckBox");
			resources.ApplyResources(mInsertCheckBox, "mInsertCheckBox");
			mInsertCheckBox.Name = "mInsertCheckBox";
			myCommandControler.SetCommandName(mInsertMedicalExpression, "InsertMedicalExpression");
			mInsertMedicalExpression.Name = "mInsertMedicalExpression";
			resources.ApplyResources(mInsertMedicalExpression, "mInsertMedicalExpression");
			myCommandControler.SetCommandName(mInsertBarcode, "InsertBarcode");
			resources.ApplyResources(mInsertBarcode, "mInsertBarcode");
			mInsertBarcode.Name = "mInsertBarcode";
			myCommandControler.SetCommandName(mInsertPageInfo, "InsertPageInfo");
			mInsertPageInfo.Name = "mInsertPageInfo";
			resources.ApplyResources(mInsertPageInfo, "mInsertPageInfo");
			myCommandControler.SetCommandName(mInsertXML, "InsertXML");
			mInsertXML.Name = "mInsertXML";
			resources.ApplyResources(mInsertXML, "mInsertXML");
			myCommandControler.SetCommandName(mInsertFileContent, "InsertFileContent");
			mInsertFileContent.Name = "mInsertFileContent";
			resources.ApplyResources(mInsertFileContent, "mInsertFileContent");
			myCommandControler.SetCommandName(mInsertContentLink, "InsertContentLink");
			mInsertContentLink.Name = "mInsertContentLink";
			resources.ApplyResources(mInsertContentLink, "mInsertContentLink");
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
			myCommandControler.SetCommandName(mDeleteField, "DeleteField");
			mDeleteField.Name = "mDeleteField";
			resources.ApplyResources(mDeleteField, "mDeleteField");
			menuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[17]
			{
				mParagraphFormat,
				mFont,
				mTextColor,
				mBackColor,
				toolStripSeparator7,
				mSup,
				mSub,
				toolStripSeparator8,
				mAlignLeft,
				mCenterAlign,
				mRightAlign,
				toolStripSeparator9,
				mNumerList,
				mBulleteList,
				mFirstIndent,
				toolStripSeparator26,
				mFieldFixedWidth
			});
			menuFormat.Name = "menuFormat";
			resources.ApplyResources(menuFormat, "menuFormat");
			myCommandControler.SetCommandName(mParagraphFormat, "ParagraphFormat");
			mParagraphFormat.Name = "mParagraphFormat";
			resources.ApplyResources(mParagraphFormat, "mParagraphFormat");
			myCommandControler.SetCommandName(mFont, "Font");
			resources.ApplyResources(mFont, "mFont");
			mFont.Name = "mFont";
			myCommandControler.SetCommandName(mTextColor, "Color");
			mTextColor.Name = "mTextColor";
			resources.ApplyResources(mTextColor, "mTextColor");
			myCommandControler.SetCommandName(mBackColor, "BorderBackgroundFormat");
			mBackColor.Name = "mBackColor";
			resources.ApplyResources(mBackColor, "mBackColor");
			toolStripSeparator7.Name = "toolStripSeparator7";
			resources.ApplyResources(toolStripSeparator7, "toolStripSeparator7");
			myCommandControler.SetCommandName(mSup, "Superscript");
			resources.ApplyResources(mSup, "mSup");
			mSup.Name = "mSup";
			myCommandControler.SetCommandName(mSub, "Subscript");
			resources.ApplyResources(mSub, "mSub");
			mSub.Name = "mSub";
			toolStripSeparator8.Name = "toolStripSeparator8";
			resources.ApplyResources(toolStripSeparator8, "toolStripSeparator8");
			myCommandControler.SetCommandName(mAlignLeft, "AlignLeft");
			resources.ApplyResources(mAlignLeft, "mAlignLeft");
			mAlignLeft.Name = "mAlignLeft";
			myCommandControler.SetCommandName(mCenterAlign, "AlignCenter");
			resources.ApplyResources(mCenterAlign, "mCenterAlign");
			mCenterAlign.Name = "mCenterAlign";
			myCommandControler.SetCommandName(mRightAlign, "AlignRight");
			resources.ApplyResources(mRightAlign, "mRightAlign");
			mRightAlign.Name = "mRightAlign";
			toolStripSeparator9.Name = "toolStripSeparator9";
			resources.ApplyResources(toolStripSeparator9, "toolStripSeparator9");
			myCommandControler.SetCommandName(mNumerList, "NumberedList");
			resources.ApplyResources(mNumerList, "mNumerList");
			mNumerList.Name = "mNumerList";
			myCommandControler.SetCommandName(mBulleteList, "BulletedList");
			resources.ApplyResources(mBulleteList, "mBulleteList");
			mBulleteList.Name = "mBulleteList";
			myCommandControler.SetCommandName(mFirstIndent, "FirstLineIndent");
			resources.ApplyResources(mFirstIndent, "mFirstIndent");
			mFirstIndent.Name = "mFirstIndent";
			toolStripSeparator26.Name = "toolStripSeparator26";
			resources.ApplyResources(toolStripSeparator26, "toolStripSeparator26");
			myCommandControler.SetCommandName(mFieldFixedWidth, "FieldFixedWidth");
			mFieldFixedWidth.Name = "mFieldFixedWidth";
			resources.ApplyResources(mFieldFixedWidth, "mFieldFixedWidth");
			mTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[17]
			{
				mInsertTable,
				mDeleteTable,
				toolStripSeparator20,
				mCellAlign,
				toolStripSeparator16,
				mInsertRowUp,
				mInsertRowDown,
				mDeleteRow,
				toolStripMenuItem3,
				mInsertColumnLeft,
				mInsertColumnRight,
				mDeleteColumn,
				toolStripMenuItem2,
				mMergeCell,
				mSplitCell,
				toolStripSeparator19,
				mHeaderRow
			});
			mTable.Name = "mTable";
			resources.ApplyResources(mTable, "mTable");
			myCommandControler.SetCommandName(mInsertTable, "Table_InsertTable");
			resources.ApplyResources(mInsertTable, "mInsertTable");
			mInsertTable.Name = "mInsertTable";
			myCommandControler.SetCommandName(mDeleteTable, "Table_DeleteTable");
			mDeleteTable.Name = "mDeleteTable";
			resources.ApplyResources(mDeleteTable, "mDeleteTable");
			toolStripSeparator20.Name = "toolStripSeparator20";
			resources.ApplyResources(toolStripSeparator20, "toolStripSeparator20");
			mCellAlign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9]
			{
				mAlignTopLeft,
				mAlignTopCenter,
				mAlignTopRight,
				mAlignMiddleLeft,
				mAlignMiddleCenter,
				mAlignMiddleRight,
				mAlignBottomLeft,
				mAlignBottomCenter,
				mAlignBottomRight
			});
			mCellAlign.Name = "mCellAlign";
			resources.ApplyResources(mCellAlign, "mCellAlign");
			myCommandControler.SetCommandName(mAlignTopLeft, "AlignTopLeft");
			resources.ApplyResources(mAlignTopLeft, "mAlignTopLeft");
			mAlignTopLeft.Name = "mAlignTopLeft";
			myCommandControler.SetCommandName(mAlignTopCenter, "AlignTopCenter");
			resources.ApplyResources(mAlignTopCenter, "mAlignTopCenter");
			mAlignTopCenter.Name = "mAlignTopCenter";
			myCommandControler.SetCommandName(mAlignTopRight, "AlignTopRight");
			resources.ApplyResources(mAlignTopRight, "mAlignTopRight");
			mAlignTopRight.Name = "mAlignTopRight";
			myCommandControler.SetCommandName(mAlignMiddleLeft, "AlignMiddleLeft");
			resources.ApplyResources(mAlignMiddleLeft, "mAlignMiddleLeft");
			mAlignMiddleLeft.Name = "mAlignMiddleLeft";
			myCommandControler.SetCommandName(mAlignMiddleCenter, "AlignMiddleCenter");
			resources.ApplyResources(mAlignMiddleCenter, "mAlignMiddleCenter");
			mAlignMiddleCenter.Name = "mAlignMiddleCenter";
			myCommandControler.SetCommandName(mAlignMiddleRight, "AlignMiddleRight");
			resources.ApplyResources(mAlignMiddleRight, "mAlignMiddleRight");
			mAlignMiddleRight.Name = "mAlignMiddleRight";
			myCommandControler.SetCommandName(mAlignBottomLeft, "AlignBottomLeft");
			resources.ApplyResources(mAlignBottomLeft, "mAlignBottomLeft");
			mAlignBottomLeft.Name = "mAlignBottomLeft";
			myCommandControler.SetCommandName(mAlignBottomCenter, "AlignBottomCenter");
			resources.ApplyResources(mAlignBottomCenter, "mAlignBottomCenter");
			mAlignBottomCenter.Name = "mAlignBottomCenter";
			myCommandControler.SetCommandName(mAlignBottomRight, "AlignBottomRight");
			resources.ApplyResources(mAlignBottomRight, "mAlignBottomRight");
			mAlignBottomRight.Name = "mAlignBottomRight";
			toolStripSeparator16.Name = "toolStripSeparator16";
			resources.ApplyResources(toolStripSeparator16, "toolStripSeparator16");
			myCommandControler.SetCommandName(mInsertRowUp, "Table_InsertRowUp");
			resources.ApplyResources(mInsertRowUp, "mInsertRowUp");
			mInsertRowUp.Name = "mInsertRowUp";
			myCommandControler.SetCommandName(mInsertRowDown, "Table_InsertRowDown");
			resources.ApplyResources(mInsertRowDown, "mInsertRowDown");
			mInsertRowDown.Name = "mInsertRowDown";
			myCommandControler.SetCommandName(mDeleteRow, "Table_DeleteRow");
			resources.ApplyResources(mDeleteRow, "mDeleteRow");
			mDeleteRow.Name = "mDeleteRow";
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
			myCommandControler.SetCommandName(mInsertColumnLeft, "Table_InsertColumnLeft");
			resources.ApplyResources(mInsertColumnLeft, "mInsertColumnLeft");
			mInsertColumnLeft.Name = "mInsertColumnLeft";
			myCommandControler.SetCommandName(mInsertColumnRight, "Table_InsertColumnRight");
			resources.ApplyResources(mInsertColumnRight, "mInsertColumnRight");
			mInsertColumnRight.Name = "mInsertColumnRight";
			myCommandControler.SetCommandName(mDeleteColumn, "Table_DeleteColumn");
			resources.ApplyResources(mDeleteColumn, "mDeleteColumn");
			mDeleteColumn.Name = "mDeleteColumn";
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
			myCommandControler.SetCommandName(mMergeCell, "Table_MergeCell");
			resources.ApplyResources(mMergeCell, "mMergeCell");
			mMergeCell.Name = "mMergeCell";
			myCommandControler.SetCommandName(mSplitCell, "Table_SplitCell");
			resources.ApplyResources(mSplitCell, "mSplitCell");
			mSplitCell.Name = "mSplitCell";
			toolStripSeparator19.Name = "toolStripSeparator19";
			resources.ApplyResources(toolStripSeparator19, "toolStripSeparator19");
			myCommandControler.SetCommandName(mHeaderRow, "Table_HeaderRow");
			mHeaderRow.Name = "mHeaderRow";
			resources.ApplyResources(mHeaderRow, "mHeaderRow");
			mTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
			{
				mWordCount,
				toolStripSeparator10,
				mConfig,
				mDocumentValueValidate,
				mEditVBAScript
			});
			mTools.Name = "mTools";
			resources.ApplyResources(mTools, "mTools");
			myCommandControler.SetCommandName(mWordCount, "WordCount");
			resources.ApplyResources(mWordCount, "mWordCount");
			mWordCount.Name = "mWordCount";
			toolStripSeparator10.Name = "toolStripSeparator10";
			resources.ApplyResources(toolStripSeparator10, "toolStripSeparator10");
			myCommandControler.SetCommandName(mConfig, "DocumentOptions");
			mConfig.Name = "mConfig";
			resources.ApplyResources(mConfig, "mConfig");
			myCommandControler.SetCommandName(mDocumentValueValidate, "DocumentValueValidate");
			mDocumentValueValidate.Name = "mDocumentValueValidate";
			resources.ApplyResources(mDocumentValueValidate, "mDocumentValueValidate");
			myCommandControler.SetCommandName(mEditVBAScript, "EditVBAScript");
			resources.ApplyResources(mEditVBAScript, "mEditVBAScript");
			mEditVBAScript.Name = "mEditVBAScript";
			mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[24]
			{
				btnCut,
				btnCopy,
				btnPaste,
				toolStripSeparator12,
				btnUndo,
				btnRedo,
				toolStripSeparator13,
				cboFontName,
				cboFontSize,
				btnFont,
				btnBold,
				btnItalic,
				btnUnderline,
				btnColor,
				btnBackColor,
				btnSup,
				btnSub,
				toolStripSeparator14,
				btnAlignLeft,
				btnAlignCenter,
				btnAlignRight,
				toolStripSeparator15,
				btnNumberedList,
				btnBulletedList
			});
			resources.ApplyResources(mainToolStrip, "mainToolStrip");
			mainToolStrip.Name = "mainToolStrip";
			myCommandControler.SetCommandName(btnCut, "Cut");
			btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnCut, "btnCut");
			btnCut.Name = "btnCut";
			myCommandControler.SetCommandName(btnCopy, "Copy");
			btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnCopy, "btnCopy");
			btnCopy.Name = "btnCopy";
			myCommandControler.SetCommandName(btnPaste, "Paste");
			btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnPaste, "btnPaste");
			btnPaste.Name = "btnPaste";
			toolStripSeparator12.Name = "toolStripSeparator12";
			resources.ApplyResources(toolStripSeparator12, "toolStripSeparator12");
			myCommandControler.SetCommandName(btnUndo, "Undo");
			btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnUndo, "btnUndo");
			btnUndo.Name = "btnUndo";
			myCommandControler.SetCommandName(btnRedo, "Redo");
			btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnRedo, "btnRedo");
			btnRedo.Name = "btnRedo";
			toolStripSeparator13.Name = "toolStripSeparator13";
			resources.ApplyResources(toolStripSeparator13, "toolStripSeparator13");
			resources.ApplyResources(cboFontName, "cboFontName");
			myCommandControler.SetCommandName(cboFontName, "FontName");
			cboFontName.Name = "cboFontName";
			resources.ApplyResources(cboFontSize, "cboFontSize");
			myCommandControler.SetCommandName(cboFontSize, "FontSize");
			cboFontSize.Name = "cboFontSize";
			myCommandControler.SetCommandName(btnFont, "Font");
			btnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnFont, "btnFont");
			btnFont.Name = "btnFont";
			myCommandControler.SetCommandName(btnBold, "Bold");
			btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnBold, "btnBold");
			btnBold.Name = "btnBold";
			myCommandControler.SetCommandName(btnItalic, "Italic");
			btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnItalic, "btnItalic");
			btnItalic.Name = "btnItalic";
			myCommandControler.SetCommandName(btnUnderline, "Underline");
			btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnUnderline, "btnUnderline");
			btnUnderline.Name = "btnUnderline";
			myCommandControler.SetCommandName(btnColor, "Color");
			btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnColor, "btnColor");
			btnColor.Name = "btnColor";
			myCommandControler.SetCommandName(btnBackColor, "BackColor");
			btnBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnBackColor, "btnBackColor");
			btnBackColor.Name = "btnBackColor";
			myCommandControler.SetCommandName(btnSup, "Superscript");
			btnSup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnSup, "btnSup");
			btnSup.Name = "btnSup";
			myCommandControler.SetCommandName(btnSub, "Subscript");
			btnSub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnSub, "btnSub");
			btnSub.Name = "btnSub";
			toolStripSeparator14.Name = "toolStripSeparator14";
			resources.ApplyResources(toolStripSeparator14, "toolStripSeparator14");
			myCommandControler.SetCommandName(btnAlignLeft, "AlignLeft");
			btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnAlignLeft, "btnAlignLeft");
			btnAlignLeft.Name = "btnAlignLeft";
			myCommandControler.SetCommandName(btnAlignCenter, "AlignCenter");
			btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnAlignCenter, "btnAlignCenter");
			btnAlignCenter.Name = "btnAlignCenter";
			myCommandControler.SetCommandName(btnAlignRight, "AlignRight");
			btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnAlignRight, "btnAlignRight");
			btnAlignRight.Name = "btnAlignRight";
			toolStripSeparator15.Name = "toolStripSeparator15";
			resources.ApplyResources(toolStripSeparator15, "toolStripSeparator15");
			myCommandControler.SetCommandName(btnNumberedList, "NumberedList");
			btnNumberedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnNumberedList, "btnNumberedList");
			btnNumberedList.Name = "btnNumberedList";
			myCommandControler.SetCommandName(btnBulletedList, "BulletedList");
			btnBulletedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnBulletedList, "btnBulletedList");
			btnBulletedList.Name = "btnBulletedList";
			myImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("myImageList.ImageStream");
			myImageList.TransparentColor = System.Drawing.Color.White;
			myImageList.Images.SetKeyName(0, "");
			myImageList.Images.SetKeyName(1, "");
			myImageList.Images.SetKeyName(2, "");
			myImageList.Images.SetKeyName(3, "");
			myImageList.Images.SetKeyName(4, "");
			myImageList.Images.SetKeyName(5, "");
			myImageList.Images.SetKeyName(6, "");
			myImageList.Images.SetKeyName(7, "");
			myImageList.Images.SetKeyName(8, "");
			myImageList.Images.SetKeyName(9, "");
			myImageList.Images.SetKeyName(10, "");
			myImageList.Images.SetKeyName(11, "");
			myImageList.Images.SetKeyName(12, "");
			myImageList.Images.SetKeyName(13, "");
			myImageList.Images.SetKeyName(14, "");
			myImageList.Images.SetKeyName(15, "");
			myImageList.Images.SetKeyName(16, "");
			myImageList.Images.SetKeyName(17, "");
			myImageList.Images.SetKeyName(18, "");
			myImageList.Images.SetKeyName(19, "");
			myImageList.Images.SetKeyName(20, "");
			myImageList.Images.SetKeyName(21, "");
			myImageList.Images.SetKeyName(22, "");
			myImageList.Images.SetKeyName(23, "");
			myImageList.Images.SetKeyName(24, "");
			myImageList.Images.SetKeyName(25, "");
			myImageList.Images.SetKeyName(26, "");
			myImageList.Images.SetKeyName(27, "");
			myImageList.Images.SetKeyName(28, "");
			myImageList.Images.SetKeyName(29, "");
			myImageList.Images.SetKeyName(30, "");
			myImageList.Images.SetKeyName(31, "");
			myImageList.Images.SetKeyName(32, "");
			myCommandControler.SetCommandName(cmi_Redo, "Redo");
			resources.ApplyResources(cmi_Redo, "cmi_Redo");
			cmi_Redo.Name = "cmi_Redo";
			myCommandControler.SetCommandName(cmi_Undo, "Undo");
			resources.ApplyResources(cmi_Undo, "cmi_Undo");
			cmi_Undo.Name = "cmi_Undo";
			myCommandControler.SetCommandName(cmi_Cut, "Cut");
			resources.ApplyResources(cmi_Cut, "cmi_Cut");
			cmi_Cut.Name = "cmi_Cut";
			myCommandControler.SetCommandName(cmi_Copy, "Copy");
			resources.ApplyResources(cmi_Copy, "cmi_Copy");
			cmi_Copy.Name = "cmi_Copy";
			myCommandControler.SetCommandName(cmi_Paste, "Paste");
			resources.ApplyResources(cmi_Paste, "cmi_Paste");
			cmi_Paste.Name = "cmi_Paste";
			myCommandControler.SetCommandName(cmi_Delete, "Delete");
			resources.ApplyResources(cmi_Delete, "cmi_Delete");
			cmi_Delete.Name = "cmi_Delete";
			myCommandControler.SetCommandName(cmi_Properties, "ElementProperties");
			cmi_Properties.Name = "cmi_Properties";
			resources.ApplyResources(cmi_Properties, "cmi_Properties");
			myCommandControler.SetCommandName(cmi_EditImage, "EditImageAdditionShape");
			resources.ApplyResources(cmi_EditImage, "cmi_EditImage");
			cmi_EditImage.Name = "cmi_EditImage";
			myCommandControler.SetCommandName(cmi_BorderBackground, "BorderBackgroundFormat");
			resources.ApplyResources(cmi_BorderBackground, "cmi_BorderBackground");
			cmi_BorderBackground.Name = "cmi_BorderBackground";
			myCommandControler.SetCommandName(cmc_Redo, "Redo");
			resources.ApplyResources(cmc_Redo, "cmc_Redo");
			cmc_Redo.Name = "cmc_Redo";
			myCommandControler.SetCommandName(cmc_Undo, "Undo");
			resources.ApplyResources(cmc_Undo, "cmc_Undo");
			cmc_Undo.Name = "cmc_Undo";
			myCommandControler.SetCommandName(cmc_Cut, "Cut");
			resources.ApplyResources(cmc_Cut, "cmc_Cut");
			cmc_Cut.Name = "cmc_Cut";
			myCommandControler.SetCommandName(cmc_Copy, "Copy");
			resources.ApplyResources(cmc_Copy, "cmc_Copy");
			cmc_Copy.Name = "cmc_Copy";
			myCommandControler.SetCommandName(cmc_Paste, "Paste");
			resources.ApplyResources(cmc_Paste, "cmc_Paste");
			cmc_Paste.Name = "cmc_Paste";
			myCommandControler.SetCommandName(cmc_TableRowProperties, "TableRowProperties");
			resources.ApplyResources(cmc_TableRowProperties, "cmc_TableRowProperties");
			cmc_TableRowProperties.Name = "cmc_TableRowProperties";
			myCommandControler.SetCommandName(cmc_CellProperties, "TableCellProperties");
			resources.ApplyResources(cmc_CellProperties, "cmc_CellProperties");
			cmc_CellProperties.Name = "cmc_CellProperties";
			myCommandControler.SetCommandName(toolStripMenuItem28, "AlignTopLeft");
			resources.ApplyResources(toolStripMenuItem28, "toolStripMenuItem28");
			toolStripMenuItem28.Name = "toolStripMenuItem28";
			myCommandControler.SetCommandName(toolStripMenuItem29, "AlignTopCenter");
			resources.ApplyResources(toolStripMenuItem29, "toolStripMenuItem29");
			toolStripMenuItem29.Name = "toolStripMenuItem29";
			myCommandControler.SetCommandName(toolStripMenuItem30, "AlignTopRight");
			resources.ApplyResources(toolStripMenuItem30, "toolStripMenuItem30");
			toolStripMenuItem30.Name = "toolStripMenuItem30";
			myCommandControler.SetCommandName(toolStripMenuItem31, "AlignMiddleLeft");
			resources.ApplyResources(toolStripMenuItem31, "toolStripMenuItem31");
			toolStripMenuItem31.Name = "toolStripMenuItem31";
			myCommandControler.SetCommandName(toolStripMenuItem32, "AlignMiddleCenter");
			resources.ApplyResources(toolStripMenuItem32, "toolStripMenuItem32");
			toolStripMenuItem32.Name = "toolStripMenuItem32";
			myCommandControler.SetCommandName(toolStripMenuItem33, "AlignMiddleRight");
			resources.ApplyResources(toolStripMenuItem33, "toolStripMenuItem33");
			toolStripMenuItem33.Name = "toolStripMenuItem33";
			myCommandControler.SetCommandName(toolStripMenuItem34, "AlignBottomLeft");
			resources.ApplyResources(toolStripMenuItem34, "toolStripMenuItem34");
			toolStripMenuItem34.Name = "toolStripMenuItem34";
			myCommandControler.SetCommandName(toolStripMenuItem35, "AlignBottomCenter");
			resources.ApplyResources(toolStripMenuItem35, "toolStripMenuItem35");
			toolStripMenuItem35.Name = "toolStripMenuItem35";
			myCommandControler.SetCommandName(toolStripMenuItem36, "AlignBottomRight");
			resources.ApplyResources(toolStripMenuItem36, "toolStripMenuItem36");
			toolStripMenuItem36.Name = "toolStripMenuItem36";
			myCommandControler.SetCommandName(toolStripMenuItem37, "Table_InsertRowUp");
			resources.ApplyResources(toolStripMenuItem37, "toolStripMenuItem37");
			toolStripMenuItem37.Name = "toolStripMenuItem37";
			myCommandControler.SetCommandName(toolStripMenuItem38, "Table_InsertRowDown");
			resources.ApplyResources(toolStripMenuItem38, "toolStripMenuItem38");
			toolStripMenuItem38.Name = "toolStripMenuItem38";
			myCommandControler.SetCommandName(toolStripMenuItem40, "Table_InsertColumnLeft");
			resources.ApplyResources(toolStripMenuItem40, "toolStripMenuItem40");
			toolStripMenuItem40.Name = "toolStripMenuItem40";
			myCommandControler.SetCommandName(toolStripMenuItem9, "Table_InsertColumnRight");
			resources.ApplyResources(toolStripMenuItem9, "toolStripMenuItem9");
			toolStripMenuItem9.Name = "toolStripMenuItem9";
			myCommandControler.SetCommandName(cmc_DeleteRow, "Table_DeleteRow");
			resources.ApplyResources(cmc_DeleteRow, "cmc_DeleteRow");
			cmc_DeleteRow.Name = "cmc_DeleteRow";
			myCommandControler.SetCommandName(cmc_DeleteColumn, "Table_DeleteColumn");
			resources.ApplyResources(cmc_DeleteColumn, "cmc_DeleteColumn");
			cmc_DeleteColumn.Name = "cmc_DeleteColumn";
			myCommandControler.SetCommandName(cmc_MergeCell, "Table_MergeCell");
			resources.ApplyResources(cmc_MergeCell, "cmc_MergeCell");
			cmc_MergeCell.Name = "cmc_MergeCell";
			myCommandControler.SetCommandName(cmc_SplitCell, "Table_SplitCellExt");
			resources.ApplyResources(cmc_SplitCell, "cmc_SplitCell");
			cmc_SplitCell.Name = "cmc_SplitCell";
			myCommandControler.SetCommandName(cmc_CellBorderBackground, "BorderBackgroundFormat");
			resources.ApplyResources(cmc_CellBorderBackground, "cmc_CellBorderBackground");
			cmc_CellBorderBackground.Name = "cmc_CellBorderBackground";
			myCommandControler.SetCommandName(cmc_Properties, "ElementProperties");
			resources.ApplyResources(cmc_Properties, "cmc_Properties");
			cmc_Properties.Name = "cmc_Properties";
			myCommandControler.SetCommandName(cmi_EmitInText, "EmbedInText");
			resources.ApplyResources(cmi_EmitInText, "cmi_EmitInText");
			cmi_EmitInText.Name = "cmi_EmitInText";
			myCommandControler.SetCommandName(cmi_TextSurrdings, "TextSurroundings");
			resources.ApplyResources(cmi_TextSurrdings, "cmi_TextSurrdings");
			cmi_TextSurrdings.Name = "cmi_TextSurrdings";
			myCommandControler.SetCommandName(cmf_Undo, "Redo");
			resources.ApplyResources(cmf_Undo, "cmf_Undo");
			cmf_Undo.Name = "cmf_Undo";
			myCommandControler.SetCommandName(cmf_Redo, "Undo");
			resources.ApplyResources(cmf_Redo, "cmf_Redo");
			cmf_Redo.Name = "cmf_Redo";
			myCommandControler.SetCommandName(cmf_Cut, "Cut");
			resources.ApplyResources(cmf_Cut, "cmf_Cut");
			cmf_Cut.Name = "cmf_Cut";
			myCommandControler.SetCommandName(cmf_Copy, "Copy");
			resources.ApplyResources(cmf_Copy, "cmf_Copy");
			cmf_Copy.Name = "cmf_Copy";
			myCommandControler.SetCommandName(cmf_Paste, "Paste");
			resources.ApplyResources(cmf_Paste, "cmf_Paste");
			cmf_Paste.Name = "cmf_Paste";
			myCommandControler.SetCommandName(cmf_Delete, "Delete");
			resources.ApplyResources(cmf_Delete, "cmf_Delete");
			cmf_Delete.Name = "cmf_Delete";
			myCommandControler.SetCommandName(cmf_Color, "Color");
			cmf_Color.Name = "cmf_Color";
			resources.ApplyResources(cmf_Color, "cmf_Color");
			myCommandControler.SetCommandName(cmf_Font, "Font");
			resources.ApplyResources(cmf_Font, "cmf_Font");
			cmf_Font.Name = "cmf_Font";
			myCommandControler.SetCommandName(cmf_LeftAlign, "AlignLeft");
			resources.ApplyResources(cmf_LeftAlign, "cmf_LeftAlign");
			cmf_LeftAlign.Name = "cmf_LeftAlign";
			myCommandControler.SetCommandName(cmf_AlignCenter, "AlignCenter");
			resources.ApplyResources(cmf_AlignCenter, "cmf_AlignCenter");
			cmf_AlignCenter.Name = "cmf_AlignCenter";
			myCommandControler.SetCommandName(cmf_AlignRight, "AlignRight");
			resources.ApplyResources(cmf_AlignRight, "cmf_AlignRight");
			cmf_AlignRight.Name = "cmf_AlignRight";
			myCommandControler.SetCommandName(cmf_ElementProperties, "ElementProperties");
			cmf_ElementProperties.Name = "cmf_ElementProperties";
			resources.ApplyResources(cmf_ElementProperties, "cmf_ElementProperties");
			myCommandControler.SetCommandName(cmf_ClearFieldValue, "ClearFieldValue");
			cmf_ClearFieldValue.Name = "cmf_ClearFieldValue";
			resources.ApplyResources(cmf_ClearFieldValue, "cmf_ClearFieldValue");
			cmImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[15]
			{
				cmi_Redo,
				cmi_Undo,
				toolStripSeparator27,
				cmi_Cut,
				cmi_Copy,
				cmi_Paste,
				cmi_Delete,
				toolStripSeparator28,
				cmi_Properties,
				toolStripSeparator31,
				cmi_BorderBackground,
				cmi_EditImage,
				toolStripSeparator2,
				cmi_EmitInText,
				cmi_TextSurrdings
			});
			cmImage.Name = "cmEdit";
			resources.ApplyResources(cmImage, "cmImage");
			toolStripSeparator27.Name = "toolStripSeparator27";
			resources.ApplyResources(toolStripSeparator27, "toolStripSeparator27");
			toolStripSeparator28.Name = "toolStripSeparator28";
			resources.ApplyResources(toolStripSeparator28, "toolStripSeparator28");
			toolStripSeparator31.Name = "toolStripSeparator31";
			resources.ApplyResources(toolStripSeparator31, "toolStripSeparator31");
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			cmTableCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[19]
			{
				cmc_Redo,
				cmc_Undo,
				toolStripSeparator34,
				cmc_Cut,
				cmc_Copy,
				cmc_Paste,
				toolStripMenuItem14,
				cmc_Properties,
				cmc_TableRowProperties,
				cmc_CellProperties,
				cmc_CellBorderBackground,
				toolStripSeparator37,
				cmc_CellContentAlign,
				cmc_Insert,
				cmc_DeleteRow,
				cmc_DeleteColumn,
				toolStripSeparator39,
				cmc_MergeCell,
				cmc_SplitCell
			});
			cmTableCell.Name = "cmEdit";
			resources.ApplyResources(cmTableCell, "cmTableCell");
			toolStripSeparator34.Name = "toolStripSeparator34";
			resources.ApplyResources(toolStripSeparator34, "toolStripSeparator34");
			toolStripMenuItem14.Name = "toolStripMenuItem14";
			resources.ApplyResources(toolStripMenuItem14, "toolStripMenuItem14");
			toolStripSeparator37.Name = "toolStripSeparator37";
			resources.ApplyResources(toolStripSeparator37, "toolStripSeparator37");
			cmc_CellContentAlign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9]
			{
				toolStripMenuItem28,
				toolStripMenuItem29,
				toolStripMenuItem30,
				toolStripMenuItem31,
				toolStripMenuItem32,
				toolStripMenuItem33,
				toolStripMenuItem34,
				toolStripMenuItem35,
				toolStripMenuItem36
			});
			cmc_CellContentAlign.Name = "cmc_CellContentAlign";
			resources.ApplyResources(cmc_CellContentAlign, "cmc_CellContentAlign");
			cmc_Insert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
			{
				toolStripMenuItem37,
				toolStripMenuItem38,
				toolStripSeparator38,
				toolStripMenuItem40,
				toolStripMenuItem9
			});
			cmc_Insert.Name = "cmc_Insert";
			resources.ApplyResources(cmc_Insert, "cmc_Insert");
			toolStripSeparator38.Name = "toolStripSeparator38";
			resources.ApplyResources(toolStripSeparator38, "toolStripSeparator38");
			toolStripSeparator39.Name = "toolStripSeparator39";
			resources.ApplyResources(toolStripSeparator39, "toolStripSeparator39");
			resources.ApplyResources(tvwNavigate, "tvwNavigate");
			tvwNavigate.HideSelection = false;
			tvwNavigate.Name = "tvwNavigate";
			resources.ApplyResources(mySplitContainer, "mySplitContainer");
			mySplitContainer.Name = "mySplitContainer";
			mySplitContainer.Panel1.Controls.Add(tabFunction);
			mySplitContainer.Panel2.Controls.Add(myEditControl);
			tabFunction.Controls.Add(tpNavigate);
			tabFunction.Controls.Add(tpTrack);
			resources.ApplyResources(tabFunction, "tabFunction");
			tabFunction.Name = "tabFunction";
			tabFunction.SelectedIndex = 0;
			tpNavigate.Controls.Add(tvwNavigate);
			resources.ApplyResources(tpNavigate, "tpNavigate");
			tpNavigate.Name = "tpNavigate";
			tpNavigate.UseVisualStyleBackColor = true;
			tpTrack.Controls.Add(lstTrack);
			resources.ApplyResources(tpTrack, "tpTrack");
			tpTrack.Name = "tpTrack";
			tpTrack.UseVisualStyleBackColor = true;
			resources.ApplyResources(lstTrack, "lstTrack");
			lstTrack.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			lstTrack.FormattingEnabled = true;
			lstTrack.Name = "lstTrack";
			cmField.Items.AddRange(new System.Windows.Forms.ToolStripItem[17]
			{
				cmf_Undo,
				cmf_Redo,
				toolStripSeparator3,
				cmf_Cut,
				cmf_Copy,
				cmf_Paste,
				cmf_Delete,
				cmf_ClearFieldValue,
				toolStripSeparator11,
				cmf_Color,
				cmf_Font,
				toolStripSeparator22,
				cmf_LeftAlign,
				cmf_AlignCenter,
				cmf_AlignRight,
				toolStripSeparator23,
				cmf_ElementProperties
			});
			cmField.Name = "cmEdit";
			resources.ApplyResources(cmField, "cmField");
			toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
			toolStripSeparator11.Name = "toolStripSeparator11";
			resources.ApplyResources(toolStripSeparator11, "toolStripSeparator11");
			toolStripSeparator22.Name = "toolStripSeparator22";
			resources.ApplyResources(toolStripSeparator22, "toolStripSeparator22");
			toolStripSeparator23.Name = "toolStripSeparator23";
			resources.ApplyResources(toolStripSeparator23, "toolStripSeparator23");
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(mySplitContainer);
			base.Controls.Add(mainToolStrip);
			base.Controls.Add(mainMenuStrip);
			base.Name = "WriterControlExt";
			cmEdit.ResumeLayout(false);
			mainMenuStrip.ResumeLayout(false);
			mainMenuStrip.PerformLayout();
			mainToolStrip.ResumeLayout(false);
			mainToolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)myCommandControler).EndInit();
			cmImage.ResumeLayout(false);
			cmTableCell.ResumeLayout(false);
			mySplitContainer.Panel1.ResumeLayout(false);
			mySplitContainer.Panel2.ResumeLayout(false);
			mySplitContainer.ResumeLayout(false);
			tabFunction.ResumeLayout(false);
			tpNavigate.ResumeLayout(false);
			tpTrack.ResumeLayout(false);
			cmField.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       面向COM的设置控件属性
		///       </summary>
		/// <remarks>有些属性值类型不是COM公开的，无法直接设置。因此采用字符串的方式来试图设置控件属性值。</remarks>
		/// <param name="propertyName">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		public bool ComSetProperty(string propertyName, string Value)
		{
			return ControlHelper.SetControlValue(this, propertyName, Value);
		}

		/// <summary>
		///       创建指定名称的类型的对象实例
		///       </summary>
		/// <param name="typeName">类型名称</param>
		/// <returns>创建的对象实例</returns>
		public object CreateInstanceByTypeName(string typeName)
		{
			Type controlType = ControlHelper.GetControlType(typeName, null);
			if (controlType != null)
			{
				return Activator.CreateInstance(controlType);
			}
			return null;
		}

		/// <summary>
		///       将控件添加到指定句柄的窗体中
		///       </summary>
		/// <param name="containerHandle">指定的窗体句柄对象</param>
		/// <returns>操作是否成功</returns>
		public bool AppendToContainerControl(int containerHandle)
		{
			GClass271 gClass = new GClass271();
			gClass.method_3(new IntPtr(containerHandle));
			gClass.method_1(base.Handle);
			gClass.method_5(Dock);
			return gClass.method_6();
		}

		/// <summary>
		///       测试
		///       </summary>
		public void TestFireComEventSelectionChanged()
		{
			int num = 1;
			if (this.ComEventSelectionChanged != null)
			{
				MessageBox.Show("绑定了事件");
				this.ComEventSelectionChanged();
			}
			else
			{
				MessageBox.Show("没有绑定事件");
			}
		}

		/// <summary>
		///       接口实现
		///       </summary>
		/// <param name="riid">
		/// </param>
		/// <param name="pdwSupportedOptions">
		/// </param>
		/// <param name="pdwEnabledOptions">
		/// </param>
		/// <returns>
		/// </returns>
		
		[ComVisible(true)]
		public int GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
		{
			int num = 13;
			int num2 = -2147467259;
			string text = riid.ToString("B");
			pdwSupportedOptions = 3;
			switch (text)
			{
			case "{0000010A-0000-0000-C000-000000000046}":
			case "{00000109-0000-0000-C000-000000000046}":
			case "{37D84F60-42CB-11CE-8135-00AA004BB851}":
				num2 = 0;
				pdwEnabledOptions = 0;
				if (_fSafeForInitializing)
				{
					pdwEnabledOptions = 2;
				}
				break;
			case "{00020400-0000-0000-C000-000000000046}":
			case "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}":
				num2 = 0;
				pdwEnabledOptions = 0;
				if (_fSafeForScripting)
				{
					pdwEnabledOptions = 1;
				}
				break;
			default:
				num2 = -2147467262;
				pdwEnabledOptions = 3;
				break;
			}
			return num2;
		}

		/// <summary>
		///       接口实现
		///       </summary>
		/// <param name="riid">
		/// </param>
		/// <param name="dwOptionSetMask">
		/// </param>
		/// <param name="dwEnabledOptions">
		/// </param>
		/// <returns>
		/// </returns>
		
		[ComVisible(true)]
		public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
		{
			int num = 11;
			int result = -2147467259;
			switch (riid.ToString("B"))
			{
			case "{0000010A-0000-0000-C000-000000000046}":
			case "{00000109-0000-0000-C000-000000000046}":
			case "{37D84F60-42CB-11CE-8135-00AA004BB851}":
				if ((dwEnabledOptions & dwOptionSetMask) == 2 && _fSafeForInitializing)
				{
					result = 0;
				}
				break;
			case "{00020400-0000-0000-C000-000000000046}":
			case "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}":
				if ((dwEnabledOptions & dwOptionSetMask) == 1 && _fSafeForScripting)
				{
					result = 0;
				}
				break;
			default:
				result = -2147467262;
				break;
			}
			return result;
		}

		/// <summary>
		///       将插入点移动到指定位置
		///       </summary>
		/// <param name="target">移动的目标</param>
		public void MoveTo(MoveTarget target)
		{
			myEditControl.MoveTo(target);
		}

		/// <summary>
		///       获得当前插入点所在的指定类型的文档元素对象。
		///       </summary>
		/// <param name="elementType">指定的文档元素类型</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(false)]
		public XTextElement GetCurrentElement(Type elementType)
		{
			return myEditControl.GetCurrentElement(elementType);
		}

		/// <summary>
		///       获得当前插入点所在的指定类型的文档元素对象。
		///       </summary>
		/// <param name="typeName">指定的文档元素类型的名称</param>
		/// <returns>获得的文档元素对象</returns>
		public XTextElement GetCurrentElementByTypeName(string typeName)
		{
			int num = 13;
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType == null)
			{
				throw new ArgumentException("TypeName=" + typeName);
			}
			return Document.GetCurrentElement(controlType, includeThis: true);
		}

		/// <summary>
		///       获得指定ID号的文档元素对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">编号</param>
		/// <returns>找到的文档元素对象</returns>
		public XTextElement GetElementById(string string_0)
		{
			return myEditControl.GetElementById(string_0);
		}

		/// <summary>
		///       获得指定元素承载的对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>承载的对象</returns>
		public object GetHostedInstance(XTextControlHostElement element)
		{
			return myEditControl.GetHostedInstance(element);
		}

		/// <summary>
		///       获得控件客户区中指定位置处的文档元素对象
		///       </summary>
		/// <param name="x">X坐标</param>
		/// <param name="y">Y坐标</param>
		/// <returns>
		/// </returns>
		public XTextElement GetElementByPosition(int int_0, int int_1)
		{
			return myEditControl.GetElementByPosition(int_0, int_1);
		}

		/// <summary>
		///       获得指定的文档元素在编辑器控件客户区中的边界
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>边界</returns>
		public Rectangle GetElementClientBounds(XTextElement element)
		{
			return myEditControl.GetElementClientBounds(element);
		}

		/// <summary>
		///       获得文档中所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementType">元素类型</param>
		/// <returns>获得的元素列表</returns>
		[ComVisible(false)]
		public XTextElementList GetSpecifyElements(Type elementType)
		{
			return myEditControl.GetSpecifyElements(elementType);
		}

		/// <summary>
		///       获得文档中所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="typeName">元素类型名称</param>
		/// <returns>获得的元素列表</returns>
		public XTextElementList GetSpecifyElementsByTypeName(string typeName)
		{
			int num = 8;
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType == null)
			{
				throw new ArgumentException("TypeName=" + typeName);
			}
			return GetSpecifyElements(controlType);
		}

		/// <summary>
		///       根据当前操作员信息进行用户登录
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool UserLogin()
		{
			return myEditControl.UserLogin();
		}

		/// <summary>
		///       以指定的格式加载文本文档内容
		///       </summary>
		/// <param name="text">文本</param>
		/// <param name="format">格式</param>
		/// <returns>操作是否成功</returns>
		public bool LoadDocumentFromString(string text, string format)
		{
			return myEditControl.LoadDocumentFromString(text, format);
		}

		/// <summary>
		///       滚动视图到光标位置
		///       </summary>
		public void ScrollToCaret()
		{
			myEditControl.ScrollToCaret();
		}

		/// <summary>
		///       根据指定的文档元素对象更新光标
		///       </summary>
		/// <param name="element">指定的文档元素对象</param>
		public void UpdateTextCaret(XTextElement element)
		{
			myEditControl.UpdateTextCaretByElement(element);
		}

		/// <summary>
		///       根据当前元素更新光标
		///       </summary>
		public void UpdateTextCaret()
		{
			myEditControl.UpdateTextCaret();
		}

		/// <summary>
		///       根据当前元素更新光标，而且不会造成用户视图区域的滚动
		///       </summary>
		public void UpdateTextCaretWithoutScroll()
		{
			myEditControl.UpdateTextCaretWithoutScroll();
		}

		/// <summary>
		///       选中文档所有内容
		///       </summary>
		public void SelectAll()
		{
			myEditControl.SelectAll();
		}

		/// <summary>
		///       显示关于对话框
		///       </summary>
		public void ShowAboutDialog()
		{
			myEditControl.ShowAboutDialog();
		}

		/// <summary>
		///       初始化控件
		///       </summary>
		public WriterControlExt()
		{
			WriterCommandEventHandler writerCommandEventHandler = null;
			CommandErrorEventHandler commandErrorEventHandler = null;
			WriterEventHandler writerEventHandler = null;
			WriterEventHandler writerEventHandler2 = null;
			StatusTextChangedEventHandler statusTextChangedEventHandler = null;
			SelectionChangingEventHandler selectionChangingEventHandler = null;
			WriterEventHandler writerEventHandler3 = null;
			WriterEventHandler writerEventHandler4 = null;
			InsertObjectEventHandler insertObjectEventHandler = null;
			CanInsertObjectEventHandler canInsertObjectEventHandler = null;
			CreateElementsByKBEntryEventHandler createElementsByKBEntryEventHandler = null;
			FilterValueEventHandler filterValueEventHandler = null;
			WriterEventHandler writerEventHandler5 = null;
			QueryListItemsEventHandler queryListItemsEventHandler = null;
			WriterEventHandler writerEventHandler6 = null;
			WriterEventHandler writerEventHandler7 = null;
			WriterMouseEventHandler writerMouseEventHandler = null;
			WriterMouseEventHandler writerMouseEventHandler2 = null;
			WriterMouseEventHandler writerMouseEventHandler3 = null;
			QueryKBEntriesEventHandler queryKBEntriesEventHandler = null;
			ParseSelectedItemsEventHandler parseSelectedItemsEventHandler = null;
			FormatListItemsEventHandler formatListItemsEventHandler = null;
			WriterCommandEventHandler writerCommandEventHandler2 = null;
			components = null;
			this.ComEventSelectionChanged = null;
			this.ComEventDocumentLoad = null;
			this.ComEventDocumentContentChanged = null;
			this.ComEventStatusTextChanged = null;
			_fSafeForScripting = true;
			_fSafeForInitializing = true;
			this.EventParseSelectedItems = null;
			this.EventFormatListItems = null;
			this.EventUnknowCommand = null;
			this.QueryKBEntries = null;
			this.MouseDownExt = null;
			this.MouseMoveExt = null;
			this.MouseUpExt = null;
			this.FilterValue = null;
			this.EventCreateElementsByKBEntry = null;
			this.HoverElementChanged = null;
			this.DocumentLoad = null;
			this.EventInsertObject = null;
			this.EventCanInsertObject = null;
			this.StatusTextChanged = null;
			this.SelectionChanging = null;
			this.SelectionChanged = null;
			this.DocumentContentChanged = null;
			this.QueryListItems = null;
			this.UserTrackListChanged = null;
			this.DocumentNavigateContentChanged = null;
			this.AfterExecuteCommand = null;
			this.ScriptError = null;
			this.CommandError = null;
			_TrackListVisible = FunctionControlVisibility.Hide;
			_TrackList = null;
			_NavigateTreeVisible = FunctionControlVisibility.Auto;
			_NavigateTreeView = null;
			
			InitializeComponent();
			mySplitContainer.Panel1Collapsed = true;
			WriterControl writerControl = myEditControl;
			writerCommandEventHandler = delegate(object sender, WriterCommandEventArgs e)
			{
				if (this.AfterExecuteCommand != null)
				{
					this.AfterExecuteCommand(this, e);
				}
			};
			writerControl.AfterExecuteCommand += writerCommandEventHandler;
			WriterControl writerControl2 = myEditControl;
			commandErrorEventHandler = delegate(object sender, CommandErrorEventArgs e)
			{
				if (this.CommandError != null)
				{
					this.CommandError(this, e);
				}
			};
			writerControl2.CommandError += commandErrorEventHandler;
			WriterControl writerControl3 = myEditControl;
			writerEventHandler = delegate(object sender, WriterEventArgs e)
			{
				if (this.DocumentLoad != null)
				{
					this.DocumentLoad(sender, e);
				}
				if (this.ComEventDocumentLoad != null)
				{
					this.ComEventDocumentLoad();
				}
			};
			writerControl3.DocumentLoad += writerEventHandler;
			WriterControl writerControl4 = myEditControl;
			writerEventHandler2 = delegate(object sender, WriterEventArgs e)
			{
				if (this.DocumentContentChanged != null)
				{
					this.DocumentContentChanged(sender, e);
				}
				if (this.ComEventDocumentContentChanged != null)
				{
					this.ComEventDocumentContentChanged();
				}
			};
			writerControl4.DocumentContentChanged += writerEventHandler2;
			WriterControl writerControl5 = myEditControl;
			statusTextChangedEventHandler = delegate(object sender, StatusTextChangedEventArgs e)
			{
				if (this.StatusTextChanged != null)
				{
					this.StatusTextChanged(sender, e);
				}
				if (this.ComEventStatusTextChanged != null)
				{
					this.ComEventStatusTextChanged();
				}
			};
			writerControl5.StatusTextChanged += statusTextChangedEventHandler;
			WriterControl writerControl6 = myEditControl;
			selectionChangingEventHandler = delegate(object sender, SelectionChangingEventArgs e)
			{
				if (this.SelectionChanging != null)
				{
					this.SelectionChanging(sender, e);
				}
			};
			writerControl6.SelectionChanging += selectionChangingEventHandler;
			WriterControl writerControl7 = myEditControl;
			writerEventHandler3 = delegate(object sender, WriterEventArgs e)
			{
				if (this.SelectionChanged != null)
				{
					this.SelectionChanged(sender, e);
				}
				if (this.ComEventSelectionChanged != null)
				{
					this.ComEventSelectionChanged();
				}
				_NavigateTreeView.HandleWriterControlSelectionChanged();
			};
			writerControl7.SelectionChanged += writerEventHandler3;
			WriterControl writerControl8 = myEditControl;
			writerEventHandler4 = delegate(object sender, WriterEventArgs e)
			{
				if (this.DocumentNavigateContentChanged != null)
				{
					this.DocumentNavigateContentChanged(sender, e);
				}
				RefreshFunctionControl();
			};
			writerControl8.DocumentNavigateContentChanged += writerEventHandler4;
			WriterControl writerControl9 = myEditControl;
			insertObjectEventHandler = delegate(object sender, InsertObjectEventArgs e)
			{
				if (this.EventInsertObject != null)
				{
					this.EventInsertObject(sender, e);
				}
			};
			writerControl9.EventInsertObject += insertObjectEventHandler;
			WriterControl writerControl10 = myEditControl;
			canInsertObjectEventHandler = delegate(object sender, CanInsertObjectEventArgs e)
			{
				if (this.EventCanInsertObject != null)
				{
					this.EventCanInsertObject(sender, e);
				}
			};
			writerControl10.EventCanInsertObject += canInsertObjectEventHandler;
			WriterControl writerControl11 = myEditControl;
			createElementsByKBEntryEventHandler = delegate(object sender, CreateElementsByKBEntryEventArgs e)
			{
				if (this.EventCreateElementsByKBEntry != null)
				{
					this.EventCreateElementsByKBEntry(sender, e);
				}
			};
			writerControl11.EventCreateElementsByKBEntry += createElementsByKBEntryEventHandler;
			WriterControl writerControl12 = myEditControl;
			filterValueEventHandler = delegate(object sender, FilterValueEventArgs e)
			{
				if (this.FilterValue != null)
				{
					this.FilterValue(sender, e);
				}
			};
			writerControl12.FilterValue += filterValueEventHandler;
			WriterControl writerControl13 = myEditControl;
			writerEventHandler5 = delegate(object sender, WriterEventArgs e)
			{
				if (this.HoverElementChanged != null)
				{
					this.HoverElementChanged(sender, e);
				}
			};
			writerControl13.HoverElementChanged += writerEventHandler5;
			WriterControl writerControl14 = myEditControl;
			queryListItemsEventHandler = delegate(object sender, QueryListItemsEventArgs e)
			{
				if (this.QueryListItems != null)
				{
					this.QueryListItems(sender, e);
				}
			};
			writerControl14.QueryListItems += queryListItemsEventHandler;
			WriterControl writerControl15 = myEditControl;
			writerEventHandler6 = delegate(object sender, WriterEventArgs e)
			{
				if (this.ScriptError != null)
				{
					this.ScriptError(sender, e);
				}
			};
			writerControl15.ScriptError += writerEventHandler6;
			WriterControl writerControl16 = myEditControl;
			writerEventHandler7 = delegate(object sender, WriterEventArgs e)
			{
				if (this.UserTrackListChanged != null)
				{
					this.UserTrackListChanged(sender, e);
				}
			};
			writerControl16.UserTrackListChanged += writerEventHandler7;
			WriterControl writerControl17 = myEditControl;
			writerMouseEventHandler = delegate(object sender, WriterMouseEventArgs e)
			{
				if (this.MouseDownExt != null)
				{
					this.MouseDownExt(sender, e);
				}
			};
			writerControl17.EventMouseDownExt += writerMouseEventHandler;
			WriterControl writerControl18 = myEditControl;
			writerMouseEventHandler2 = delegate(object sender, WriterMouseEventArgs e)
			{
				if (this.MouseMoveExt != null)
				{
					this.MouseMoveExt(sender, e);
				}
			};
			writerControl18.EventMouseMoveExt += writerMouseEventHandler2;
			WriterControl writerControl19 = myEditControl;
			writerMouseEventHandler3 = delegate(object sender, WriterMouseEventArgs e)
			{
				if (this.MouseUpExt != null)
				{
					this.MouseUpExt(sender, e);
				}
			};
			writerControl19.EventMouseUpExt += writerMouseEventHandler3;
			WriterControl writerControl20 = myEditControl;
			queryKBEntriesEventHandler = delegate(object sender, QueryKBEntriesEventArgs e)
			{
				if (this.QueryKBEntries != null)
				{
					this.QueryKBEntries(sender, e);
				}
			};
			writerControl20.QueryKBEntries += queryKBEntriesEventHandler;
			WriterControl writerControl21 = myEditControl;
			parseSelectedItemsEventHandler = delegate(object sender, ParseSelectedItemsEventArgs e)
			{
				if (this.EventParseSelectedItems != null)
				{
					this.EventParseSelectedItems(sender, e);
				}
			};
			writerControl21.EventParseSelectedItems += parseSelectedItemsEventHandler;
			WriterControl writerControl22 = myEditControl;
			formatListItemsEventHandler = delegate(object sender, FormatListItemsEventArgs e)
			{
				if (this.EventFormatListItems != null)
				{
					this.EventFormatListItems(sender, e);
				}
			};
			writerControl22.EventFormatListItems += formatListItemsEventHandler;
			WriterControl writerControl23 = myEditControl;
			writerCommandEventHandler2 = delegate(object sender, WriterCommandEventArgs e)
			{
				if (this.EventUnknowCommand != null)
				{
					this.EventUnknowCommand(sender, e);
				}
			};
			writerControl23.EventUnknowCommand += writerCommandEventHandler2;
			_NavigateTreeView = new NavigateTreeViewControler(tvwNavigate, myEditControl);
			_TrackList = new TrackListBoxControler(lstTrack, myEditControl);
		}

		/// <summary>
		///       控件加载事件处理
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				myEditControl.ContextMenuManager.DefaultMenu = cmEdit;
				myEditControl.ContextMenuManager.TableCellMenu = cmTableCell;
				myEditControl.ContextMenuManager.ImageMenu = cmImage;
				myEditControl.ContextMenuManager.SetMenu(typeof(XTextInputFieldElement), cmField);
				myEditControl.CommandControler = myCommandControler;
				myCommandControler.Start();
				_ = WriterAppHost.Default;
				_NavigateTreeView.Start();
				_TrackList.Start();
			}
		}

		/// <summary>
		///       获得收集到的事件名称列表，各个事件名称之间用逗号分开。
		///       </summary>
		/// <remarks>目前支持的事件名称有DocumentContentChanged、DocumentLoad、
		///       SelectionChanged、SelectionChanging、StatusTextChanged。
		///       当编辑器控件嵌入在HTML页面中运行时，JavaScript可能无法响应控件事件，此时可以
		///       调用定时器定期调用这个函数来获得已经触发的事件名称，然后进行事件处理。</remarks>
		/// <returns>事件名称列表。</returns>
		public string GetLastEventNames()
		{
			return myEditControl.GetLastEventNames();
		}

		/// <summary>
		///       获得文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		public object GetDocumnetParameterValue(string name)
		{
			return myEditControl.GetDocumnetParameterValue(name);
		}

		/// <summary>
		///       设置文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">新的参数值</param>
		public void SetDocumentParameterValue(string name, object Value)
		{
			myEditControl.SetDocumentParameterValue(name, Value);
		}

		/// <summary>
		///       设置XML格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="xmlText">参数值</param>
		public void SetDocumentParameterValueXml(string name, string xmlText)
		{
			myEditControl.SetDocumentParameterValueXml(name, xmlText);
		}

		/// <summary>
		///       获得Xml格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		public string GetDocumentParameterValueXml(string name)
		{
			return myEditControl.GetDocumentParameterValueXml(name);
		}

		/// <summary>
		///       将文档输入域中的表单数据写入到文档对象绑定的数据源中
		///       </summary>
		/// <returns>写入的数据条数</returns>
		public int WriteDataSource()
		{
			return myEditControl.WriteDataFromDocumentToDataSource();
		}

		/// <summary>
		///       导航到节点指定的位置
		///       </summary>
		/// <param name="node">节点</param>
		/// <returns>操作是否成功</returns>
		public bool Navigate(NavigateNode node)
		{
			return myEditControl.Navigate(node);
		}

		/// <summary>
		///       判断指定名称功能命令是否可用
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>功能命令是否可用</returns>
		public bool IsCommandEnabled(string commandName)
		{
			return myEditControl.IsCommandEnabled(commandName);
		}

		/// <summary>
		///       判断指定名称的功能命令是否处于勾选状态
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>功能命令是否处于勾选状态</returns>
		public bool IsCommandChecked(string commandName)
		{
			return myEditControl.IsCommandChecked(commandName);
		}

		/// <summary>
		///       判断是否支持指定名称的功能命令
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>是否支持功能命令</returns>
		public bool IsCommandSupported(string commandName)
		{
			return myEditControl.IsCommandSupported(commandName);
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <returns>执行命令后的结果</returns>
		public object ExecuteCommand(string commandName, bool showUI, object parameter)
		{
			return myEditControl.ExecuteCommand(commandName, showUI, parameter);
		}

		/// <summary>
		///       处理退格键
		///       </summary>
		/// <remarks>
		///       当控件承载在IE浏览器中运行时，默认会按下Backspace键时浏览器会跳到上一个历史页面。
		///       本控件提供一个HandleBackspace方法，而在浏览器中编写javascript函数响应浏览器的
		///       onkeydown事件。若按键为backspace键，则javascript调用HandleBackspace方法。
		///       若该方法返回true，表示编辑器处理了backspace事件。浏览器无需继续执行该方法。
		///       若返回false，表示编辑器没有处理backspace事件，浏览器可按默认方式进行处理。
		///       </remarks>
		/// <returns>控件是否处理了backspace按键事件</returns>
		public bool HandleBackspace()
		{
			return myEditControl.HandleBackspace();
		}

		/// <summary>
		///       用户登录
		///       </summary>
		/// <param name="userID">用户编号</param>
		/// <param name="userName">用户名</param>
		/// <param name="permissionLevel">用户等级</param>
		/// <returns>操作是否成功</returns>
		public bool UserLogin(string userID, string userName, int permissionLevel)
		{
			return myEditControl.UserLogin(userID, userName, permissionLevel);
		}

		/// <summary>
		///       执行用户登录操作
		///       </summary>
		/// <param name="loginInfo">登录信息</param>
		/// <param name="updateUI">是否更新用户界面</param>
		/// <returns>操作是否成功</returns>
		public bool UserLogin(UserLoginInfo loginInfo, bool updateUI)
		{
			return myEditControl.UserLogin(loginInfo, updateUI);
		}

		/// <summary>
		///       加载文档
		///       </summary>
		/// <param name="strUrl">URL</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		public bool LoadDocument(string strUrl, string format)
		{
			return myEditControl.LoadDocument(strUrl, format);
		}

		/// <summary>
		///       从指定的文件流中加载文档
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		[ComVisible(false)]
		public bool LoadDocument(Stream stream, string format)
		{
			return myEditControl.LoadDocument(stream, format);
		}

		/// <summary>
		///       保存文档到指定名称的文件中
		///       </summary>
		/// <param name="strUrl">文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		public bool SaveDocument(string strUrl, string format)
		{
			return myEditControl.SaveDocument(strUrl, format);
		}

		/// <summary>
		///       保存文档到指定的流中
		///       </summary>
		/// <param name="stream">文档流</param>
		/// <param name="style">文件格式</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(false)]
		public bool SaveDocument(Stream stream, string style)
		{
			return myEditControl.SaveDocument(stream, style);
		}

		/// <summary>
		///       更新用户历史记录的时间
		///       </summary>
		public void UpdateUserInfoSaveTime()
		{
			myEditControl.UpdateUserInfoSaveTime();
		}

		/// <summary>
		///       清空文档内容
		///       </summary>
		public void ClearContent()
		{
			myEditControl.ClearContent();
		}

		/// <summary>
		///       刷新文档
		///       </summary>
		public void RefreshDocument()
		{
			myEditControl.RefreshDocument();
		}

		/// <summary>
		///       刷新功能控件状态
		///       </summary>
		public void RefreshFunctionControl()
		{
			_NavigateTreeView.Refresh(NavigateTreeVisible);
			_TrackList.Refresh(TrackListVisible);
			if (_NavigateTreeView.Visible || _TrackList.Visible)
			{
				mySplitContainer.Panel1Collapsed = false;
				if (tabFunction.TabPages.Contains(tpNavigate) != _NavigateTreeView.Visible)
				{
					if (_NavigateTreeView.Visible)
					{
						tabFunction.TabPages.Add(tpNavigate);
					}
					else
					{
						tabFunction.TabPages.Remove(tpNavigate);
					}
				}
				if (tabFunction.TabPages.Contains(tpTrack) != _TrackList.Visible)
				{
					if (_TrackList.Visible)
					{
						tabFunction.TabPages.Add(tpTrack);
					}
					else
					{
						tabFunction.TabPages.Remove(tpTrack);
					}
				}
			}
			else
			{
				mySplitContainer.Panel1Collapsed = true;
			}
		}
	}
}

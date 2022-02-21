#define DEBUG
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using DCSoft.Writer.Extension;
using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///        WriterControl编辑器控件的ActiveX控件版本.本控件用于COM和B/S开发,不要用于.NET开发.
	///       </summary>
	/// <remarks>
	///       本控件用于COM和B/S开发,不用于.NET开发.
	///       编制 袁永福
	///       </remarks>
	[DocumentComment]
	[ComClass("00012345-6789-ABCD-EF01-2345678900FF", "FCA69A82-5224-4AF5-BA57-C3E41F61806E", "2638F759-6C8F-4758-8A5C-D0436A76E4FC")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IAxWriterControl))]
	[ToolboxBitmap(typeof(AxWriterControl))]
	[ToolboxItem(false)]
	[Guid("00012345-6789-ABCD-EF01-2345678900FF")]
	
	[ComSourceInterfaces(typeof(IAxWriterControlComEvents))]
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class AxWriterControl : WriterControl, IObjectSafety, IAxWriterControl
	{
		private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";

		private const string _IID_IDispatchEx = "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}";

		private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";

		private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";

		private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

		private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 1;

		private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 2;

		private const int S_OK = 0;

		private const int E_FAIL = -2147467259;

		private const int E_NOINTERFACE = -2147467262;

		internal const string CLASSID = "00012345-6789-ABCD-EF01-2345678900FF";

		internal const string CLASSID_Interface = "FCA69A82-5224-4AF5-BA57-C3E41F61806E";

		internal const string CLASSID_ComEventInterface = "2638F759-6C8F-4758-8A5C-D0436A76E4FC";

		private static int _InstanceIndexCount = 0;

		private int _InstanceIndex;

		private bool _fSafeForScripting;

		private bool _fSafeForInitializing;

		private List<AxWriterControl> _Ctls;

		private string _DebugFileNameForAxContentBase64String;

		private GClass299 gclass299_0;

		private string string_5;

		private InstanceFactoryForCOM instanceFactoryForCOM_0;

		private SectionCourseRecordDocumentController _CourseRecordController;

		/// <summary>
		///       是否作为ActiveX控件的模式运行
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		
		[ComVisible(false)]
		public override bool IsAxControl => true;

		/// <summary>
		///       调试文件名
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DefaultValue(false)]
		public string DebugFileNameForAxContentBase64String
		{
			get
			{
				return _DebugFileNameForAxContentBase64String;
			}
			set
			{
				_DebugFileNameForAxContentBase64String = value;
			}
		}

		/// <summary>
		///       供下载新版文件的CodeBase值,本功能仅供WEB开发使用。
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		public string CodeBaseForUpdateAssembly
		{
			get
			{
				return GClass292.smethod_0().method_2();
			}
			set
			{
				GClass292.smethod_0().method_5(this);
				GClass292.smethod_0().method_3(value);
				GClass292.smethod_0().method_16();
			}
		}

		/// <summary>
		///       AX格式的文档BASE64字符串
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		public string AxContentBase64String
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
				if (base.IsHandleCreated)
				{
					method_81(null, null);
				}
				else
				{
					ReloadAxContentBase64String();
				}
			}
		}

		/// <summary>
		///       对象实例创建工厂对象
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		public InstanceFactoryForCOM InstanceFactory
		{
			get
			{
				if (instanceFactoryForCOM_0 == null)
				{
					instanceFactoryForCOM_0 = new InstanceFactoryForCOM();
				}
				return instanceFactoryForCOM_0;
			}
		}

		/// <summary>
		///       控件是否获得输入焦点
		///       </summary>
		[Browsable(false)]
		public bool ComFocused => Focused;

		/// <summary>
		///       内置的病程记录控制器
		///       </summary>
		[ComVisible(true)]
		public SectionCourseRecordDocumentController CourseRecordController
		{
			get
			{
				CollectOuterReference(_CourseRecordController);
				return _CourseRecordController;
			}
		}

		/// <summary>
		///       返回Html文本的COM接口
		///       </summary>
		[ComVisible(true)]
		public string ComHtmlText => GetHtmlText();

		WriterDataFormats IAxWriterControl.AcceptDataFormats
		{
			get
			{
				return base.AcceptDataFormats;
			}
			set
			{
				base.AcceptDataFormats = value;
			}
		}

		string IAxWriterControl.AdditionPageTitle
		{
			get
			{
				return base.AdditionPageTitle;
			}
			set
			{
				base.AdditionPageTitle = value;
			}
		}

		bool IAxWriterControl.AllowDragContent
		{
			get
			{
				return base.AllowDragContent;
			}
			set
			{
				base.AllowDragContent = value;
			}
		}

		WriterAppHost IAxWriterControl.AppHost
		{
			get
			{
				return base.AppHost;
			}
			set
			{
				base.AppHost = value;
			}
		}

		bool IAxWriterControl.AutoDisposeContextMenu
		{
			get
			{
				return base.AutoDisposeContextMenu;
			}
			set
			{
				base.AutoDisposeContextMenu = value;
			}
		}

		bool IAxWriterControl.AutoDisposeDocument
		{
			get
			{
				return base.AutoDisposeDocument;
			}
			set
			{
				base.AutoDisposeDocument = value;
			}
		}

		bool IAxWriterControl.AutoUserLogin
		{
			get
			{
				return base.AutoUserLogin;
			}
			set
			{
				base.AutoUserLogin = value;
			}
		}

		string IAxWriterControl.BackColorString
		{
			get
			{
				return base.BackColorString;
			}
			set
			{
				base.BackColorString = value;
			}
		}

		bool IAxWriterControl.BackgroundMode
		{
			get
			{
				return base.BackgroundMode;
			}
			set
			{
				base.BackgroundMode = value;
			}
		}

		BorderStyle IAxWriterControl.BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				base.BorderStyle = value;
			}
		}

		bool IAxWriterControl.CommandStateNeedRefreshFlag
		{
			get
			{
				return base.CommandStateNeedRefreshFlag;
			}
			set
			{
				base.CommandStateNeedRefreshFlag = value;
			}
		}

		FunctionControlVisibility IAxWriterControl.CommentVisibility
		{
			get
			{
				return base.CommentVisibility;
			}
			set
			{
				base.CommentVisibility = value;
			}
		}

		WriterDataFormats IAxWriterControl.CreationDataFormats
		{
			get
			{
				return base.CreationDataFormats;
			}
			set
			{
				base.CreationDataFormats = value;
			}
		}

		bool IAxWriterControl.CurrentBold => base.CurrentBold;

		int IAxWriterControl.CurrentColumnIndex => base.CurrentColumnIndex;

		DocumentComment IAxWriterControl.CurrentComment => base.CurrentComment;

		PageContentPartyStyle IAxWriterControl.CurrentContentPartyStyle
		{
			get
			{
				return base.CurrentContentPartyStyle;
			}
			set
			{
				base.CurrentContentPartyStyle = value;
			}
		}

		XTextElement IAxWriterControl.CurrentElement => base.CurrentElement;

		string IAxWriterControl.CurrentFontName => base.CurrentFontName;

		float IAxWriterControl.CurrentFontSize => base.CurrentFontSize;

		XTextInputFieldElement IAxWriterControl.CurrentInputField => base.CurrentInputField;

		bool IAxWriterControl.CurrentItalic => base.CurrentItalic;

		XTextLine IAxWriterControl.CurrentLine => base.CurrentLine;

		int IAxWriterControl.CurrentLineIndex => base.CurrentLineIndex;

		int IAxWriterControl.CurrentLineIndexInPage => base.CurrentLineIndexInPage;

		int IAxWriterControl.CurrentLineOwnerPageIndex => base.CurrentLineOwnerPageIndex;

		int IAxWriterControl.CurrentLinePrivateIndexInPage => base.CurrentLinePrivateIndexInPage;

		NavigateNode IAxWriterControl.CurrentNavigateNode => base.CurrentNavigateNode;

		DocumentOutlineNode IAxWriterControl.CurrentOutlineNode => base.CurrentOutlineNode;

		PrintPage IAxWriterControl.CurrentPage
		{
			get
			{
				return base.CurrentPage;
			}
			set
			{
				base.CurrentPage = value;
			}
		}

		Color IAxWriterControl.CurrentPageBorderColor
		{
			get
			{
				return base.CurrentPageBorderColor;
			}
			set
			{
				base.CurrentPageBorderColor = value;
			}
		}

		string IAxWriterControl.CurrentPageBorderColorString
		{
			get
			{
				return base.CurrentPageBorderColorString;
			}
			set
			{
				base.CurrentPageBorderColorString = value;
			}
		}

		int IAxWriterControl.CurrentPageIndex
		{
			get
			{
				return base.CurrentPageIndex;
			}
			set
			{
				base.CurrentPageIndex = value;
			}
		}

		DocumentContentAlignment IAxWriterControl.CurrentParagraphAlign => base.CurrentParagraphAlign;

		XTextParagraphFlagElement IAxWriterControl.CurrentParagraphEOF => base.CurrentParagraphEOF;

		XTextSectionElement IAxWriterControl.CurrentSection => base.CurrentSection;

		DocumentContentStyle IAxWriterControl.CurrentStyle => base.CurrentStyle;

		XTextSubDocumentElement IAxWriterControl.CurrentSubDocument => base.CurrentSubDocument;

		bool IAxWriterControl.CurrentSubscript => base.CurrentSubscript;

		bool IAxWriterControl.CurrentSuperscript => base.CurrentSuperscript;

		XTextTableElement IAxWriterControl.CurrentTable => base.CurrentTable;

		XTextTableCellElement IAxWriterControl.CurrentTableCell => base.CurrentTableCell;

		XTextTableRowElement IAxWriterControl.CurrentTableRow => base.CurrentTableRow;

		bool IAxWriterControl.CurrentUnderline => base.CurrentUnderline;

		UserHistoryInfo IAxWriterControl.CurrentUser => base.CurrentUser;

		WriterDataObjectRange IAxWriterControl.DataObjectRange
		{
			get
			{
				return base.DataObjectRange;
			}
			set
			{
				base.DataObjectRange = value;
			}
		}

		string IAxWriterControl.DialogTitlePrefix => base.DialogTitlePrefix;

		XTextDocument IAxWriterControl.Document
		{
			get
			{
				return base.Document;
			}
			set
			{
				base.Document = value;
			}
		}

		string IAxWriterControl.DocumentBaseUrl
		{
			get
			{
				return base.DocumentBaseUrl;
			}
			set
			{
				base.DocumentBaseUrl = value;
			}
		}

		DocumentBehaviorOptions IAxWriterControl.DocumentBehaviorOptions => base.DocumentBehaviorOptions;

		int IAxWriterControl.DocumentContentVersion => base.DocumentContentVersion;

		DocumentEditOptions IAxWriterControl.DocumentEditOptions => base.DocumentEditOptions;

		DocumentOptions IAxWriterControl.DocumentOptions
		{
			get
			{
				return base.DocumentOptions;
			}
			set
			{
				base.DocumentOptions = value;
			}
		}

		string IAxWriterControl.DocumentOptionsXML
		{
			get
			{
				return base.DocumentOptionsXML;
			}
			set
			{
				base.DocumentOptionsXML = value;
			}
		}

		DocumentSecurityOptions IAxWriterControl.DocumentSecurityOptions => base.DocumentSecurityOptions;

		DocumentViewOptions IAxWriterControl.DocumentViewOptions => base.DocumentViewOptions;

		DCStdImageList IAxWriterControl.DomImageList => base.DomImageList;

		bool IAxWriterControl.DoubleClickToEditComment
		{
			get
			{
				return base.DoubleClickToEditComment;
			}
			set
			{
				base.DoubleClickToEditComment = value;
			}
		}

		bool IAxWriterControl.EnabledControlEvent
		{
			get
			{
				return base.EnabledControlEvent;
			}
			set
			{
				base.EnabledControlEvent = value;
			}
		}

		bool IAxWriterControl.EnabledElementEvent
		{
			get
			{
				return base.EnabledElementEvent;
			}
			set
			{
				base.EnabledElementEvent = value;
			}
		}

		bool IAxWriterControl.EnableJumpPrint
		{
			get
			{
				return base.EnableJumpPrint;
			}
			set
			{
				base.EnableJumpPrint = value;
			}
		}

		bool IAxWriterControl.EnableUIEventStartEditContent
		{
			get
			{
				return base.EnableUIEventStartEditContent;
			}
			set
			{
				base.EnableUIEventStartEditContent = value;
			}
		}

		int IAxWriterControl.EndPageIndex
		{
			get
			{
				return base.EndPageIndex;
			}
			set
			{
				base.EndPageIndex = value;
			}
		}

		ElementEventTemplateList IAxWriterControl.EventTemplates
		{
			get
			{
				return base.EventTemplates;
			}
			set
			{
				base.EventTemplates = value;
			}
		}

		string IAxWriterControl.ExcludeKeywords
		{
			get
			{
				return base.ExcludeKeywords;
			}
			set
			{
				base.ExcludeKeywords = value;
			}
		}

		WriterControlExtViewMode IAxWriterControl.ExtViewMode
		{
			get
			{
				return base.ExtViewMode;
			}
			set
			{
				base.ExtViewMode = value;
			}
		}

		string[] IAxWriterControl.FormValuesArray => base.FormValuesArray;

		string IAxWriterControl.FormValuesString => base.FormValuesString;

		string IAxWriterControl.FormValuesXml => base.FormValuesXml;

		FormViewMode IAxWriterControl.FormView
		{
			get
			{
				return base.FormView;
			}
			set
			{
				base.FormView = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_Cell
		{
			get
			{
				return base.GlobalEventTemplate_Cell;
			}
			set
			{
				base.GlobalEventTemplate_Cell = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_CheckBox
		{
			get
			{
				return base.GlobalEventTemplate_CheckBox;
			}
			set
			{
				base.GlobalEventTemplate_CheckBox = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_Element
		{
			get
			{
				return base.GlobalEventTemplate_Element;
			}
			set
			{
				base.GlobalEventTemplate_Element = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_Field
		{
			get
			{
				return base.GlobalEventTemplate_Field;
			}
			set
			{
				base.GlobalEventTemplate_Field = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_Image
		{
			get
			{
				return base.GlobalEventTemplate_Image;
			}
			set
			{
				base.GlobalEventTemplate_Image = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_Table
		{
			get
			{
				return base.GlobalEventTemplate_Table;
			}
			set
			{
				base.GlobalEventTemplate_Table = value;
			}
		}

		ElementEventTemplate IAxWriterControl.GlobalEventTemplate_TableRow
		{
			get
			{
				return base.GlobalEventTemplate_TableRow;
			}
			set
			{
				base.GlobalEventTemplate_TableRow = value;
			}
		}

		ElementEventTemlateMap IAxWriterControl.GlobalEventTemplates
		{
			get
			{
				return base.GlobalEventTemplates;
			}
			set
			{
				base.GlobalEventTemplates = value;
			}
		}

		HeaderFooterFlagVisible IAxWriterControl.HeaderFooterFlagVisible
		{
			get
			{
				return base.HeaderFooterFlagVisible;
			}
			set
			{
				base.HeaderFooterFlagVisible = value;
			}
		}

		bool IAxWriterControl.HeaderFooterReadonly
		{
			get
			{
				return base.HeaderFooterReadonly;
			}
			set
			{
				base.HeaderFooterReadonly = value;
			}
		}

		XTextElement IAxWriterControl.HoverElement => base.HoverElement;

		XTextElementList IAxWriterControl.Images => base.Images;

		XTextElementList IAxWriterControl.InputFields => base.InputFields;

		bool IAxWriterControl.IsAdministrator
		{
			get
			{
				return base.IsAdministrator;
			}
			set
			{
				base.IsAdministrator = value;
			}
		}

		JumpPrintInfo IAxWriterControl.JumpPrint
		{
			get
			{
				return base.JumpPrint;
			}
			set
			{
				base.JumpPrint = value;
			}
		}

		float IAxWriterControl.JumpPrintEndPosition
		{
			get
			{
				return base.JumpPrintEndPosition;
			}
			set
			{
				base.JumpPrintEndPosition = value;
			}
		}

		float IAxWriterControl.JumpPrintPosition
		{
			get
			{
				return base.JumpPrintPosition;
			}
			set
			{
				base.JumpPrintPosition = value;
			}
		}

		string IAxWriterControl.KBLibraryUrl
		{
			get
			{
				return base.KBLibraryUrl;
			}
			set
			{
				base.KBLibraryUrl = value;
			}
		}

		SystemAlertInfoList IAxWriterControl.LastAlertInfos => base.LastAlertInfos;

		WriterControlEventMessage IAxWriterControl.LastEventMessage => base.LastEventMessage;

		int IAxWriterControl.LastPrintPosition
		{
			get
			{
				return base.LastPrintPosition;
			}
			set
			{
				base.LastPrintPosition = value;
			}
		}

		PrintResult IAxWriterControl.LastPrintResult
		{
			get
			{
				return base.LastPrintResult;
			}
			set
			{
				base.LastPrintResult = value;
			}
		}

		DCLicenceDisplayMode IAxWriterControl.LicenceDisplayMode
		{
			get
			{
				return base.LicenceDisplayMode;
			}
			set
			{
				base.LicenceDisplayMode = value;
			}
		}

		bool IAxWriterControl.Modified
		{
			get
			{
				return base.Modified;
			}
			set
			{
				base.Modified = value;
			}
		}

		XTextElementList IAxWriterControl.ModifiedInputFields => base.ModifiedInputFields;

		MoveFocusHotKeys IAxWriterControl.MoveFocusHotKey
		{
			get
			{
				return base.MoveFocusHotKey;
			}
			set
			{
				base.MoveFocusHotKey = value;
			}
		}

		DocumentNavigator IAxWriterControl.Navigator => base.Navigator;

		DocumentOutlineNodeList IAxWriterControl.OutlineNodes => base.OutlineNodes;

		Color IAxWriterControl.PageBackColor
		{
			get
			{
				return base.PageBackColor;
			}
			set
			{
				base.PageBackColor = value;
			}
		}

		string IAxWriterControl.PageBackColorString
		{
			get
			{
				return base.PageBackColorString;
			}
			set
			{
				base.PageBackColorString = value;
			}
		}

		Color IAxWriterControl.PageBorderColor
		{
			get
			{
				return base.PageBorderColor;
			}
			set
			{
				base.PageBorderColor = value;
			}
		}

		string IAxWriterControl.PageBorderColorString
		{
			get
			{
				return base.PageBorderColorString;
			}
			set
			{
				base.PageBorderColorString = value;
			}
		}

		int IAxWriterControl.PageCount => base.PageCount;

		int IAxWriterControl.PageIndex
		{
			get
			{
				return base.PageIndex;
			}
			set
			{
				base.PageIndex = value;
			}
		}

		PrintPageCollection IAxWriterControl.Pages
		{
			get
			{
				return base.Pages;
			}
			set
			{
				base.Pages = value;
			}
		}

		int IAxWriterControl.PageSpacing
		{
			get
			{
				return base.PageSpacing;
			}
			set
			{
				base.PageSpacing = value;
			}
		}

		PageTitlePosition IAxWriterControl.PageTitlePosition
		{
			get
			{
				return base.PageTitlePosition;
			}
			set
			{
				base.PageTitlePosition = value;
			}
		}

		string IAxWriterControl.PositionInfoText => base.PositionInfoText;

		string IAxWriterControl.ProductVersion => base.ProductVersion;

		bool IAxWriterControl.Readonly
		{
			get
			{
				return base.Readonly;
			}
			set
			{
				base.Readonly = value;
			}
		}

		string IAxWriterControl.RegisterCode
		{
			get
			{
				return base.RegisterCode;
			}
			set
			{
				base.RegisterCode = value;
			}
		}

		string IAxWriterControl.RegisterCodeFileUrl
		{
			get
			{
				return base.RegisterCodeFileUrl;
			}
			set
			{
				base.RegisterCodeFileUrl = value;
			}
		}

		string IAxWriterControl.RTFText
		{
			get
			{
				return base.RTFText;
			}
			set
			{
				base.RTFText = value;
			}
		}

		Color IAxWriterControl.RuleBackColor
		{
			get
			{
				return base.RuleBackColor;
			}
			set
			{
				base.RuleBackColor = value;
			}
		}

		bool IAxWriterControl.RuleVisible
		{
			get
			{
				return base.RuleVisible;
			}
			set
			{
				base.RuleVisible = value;
			}
		}

		XTextSelection IAxWriterControl.Selection => base.Selection;

		Point IAxWriterControl.SelectionStartPosition => base.SelectionStartPosition;

		bool IAxWriterControl.ShowTooltip
		{
			get
			{
				return base.ShowTooltip;
			}
			set
			{
				base.ShowTooltip = value;
			}
		}

		XTextElement IAxWriterControl.SingleSelectedElement => base.SingleSelectedElement;

		string IAxWriterControl.SpecifyLoadFileNameOnce
		{
			get
			{
				return base.SpecifyLoadFileNameOnce;
			}
			set
			{
				base.SpecifyLoadFileNameOnce = value;
			}
		}

		int IAxWriterControl.StartPageIndex
		{
			get
			{
				return base.StartPageIndex;
			}
			set
			{
				base.StartPageIndex = value;
			}
		}

		string IAxWriterControl.StatusText
		{
			get
			{
				return base.StatusText;
			}
			set
			{
				base.StatusText = value;
			}
		}

		XTextElementList IAxWriterControl.SubDocuments => base.SubDocuments;

		XTextElementList IAxWriterControl.Tables => base.Tables;

		UserTrackInfoList IAxWriterControl.UserTrackInfos => base.UserTrackInfos;

		string IAxWriterControl.WebServiceUrl
		{
			get
			{
				return base.WebServiceUrl;
			}
			set
			{
				base.WebServiceUrl = value;
			}
		}

		string IAxWriterControl.XMLText
		{
			get
			{
				return base.XMLText;
			}
			set
			{
				base.XMLText = value;
			}
		}

		string IAxWriterControl.XMLTextForSave
		{
			get
			{
				return base.XMLTextForSave;
			}
			set
			{
				base.XMLTextForSave = value;
			}
		}

		string IAxWriterControl.XMLTextUnFormatted => base.XMLTextUnFormatted;

		/// <summary>
		///       当前记录发生改变事件
		///       </summary>
		public event WriterEventHandler CurrentRecordChanged;

		/// <summary>
		///       记录删除事件
		///       </summary>
		public event WriterCancelEventHandler BeforeRecordDeleted;

		/// <summary>
		///       初始化对象
		///       </summary>
		public AxWriterControl()
		{
			int num = 18;
			_InstanceIndex = _InstanceIndexCount++;
			_fSafeForScripting = true;
			_fSafeForInitializing = true;
			_Ctls = new List<AxWriterControl>();
			_DebugFileNameForAxContentBase64String = null;
			gclass299_0 = null;
			string_5 = null;
			instanceFactoryForCOM_0 = null;
			this.CurrentRecordChanged = null;
			this.BeforeRecordDeleted = null;
			_CourseRecordController = null;
			
			base.AllowApplyLocalDocumentOptions = false;
			EnabledEventReadSaveFileContent = false;
			base.AutoDisposeDocument = true;
			try
			{
				base.BorderStyle = BorderStyle.Fixed3D;
				base.InnerViewControl.BackColor = SystemColors.AppWorkspace;
				BackColor = SystemColors.AppWorkspace;
				CreateHandle();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("AxWriterControlLoad:" + ex.ToString());
				MessageBox.Show(ex.ToString());
			}
			Debug.WriteLine("AxWriterControlLoaded");
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
			int num = 9;
			int num2 = -2147467259;
			string text = riid.ToString("B").ToUpper();
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
			case "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}":
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
			int num = 5;
			int result = -2147467259;
			switch (riid.ToString("B").ToUpper())
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
			case "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}":
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

		protected override void OnHandleDestroyed(EventArgs eventArgs_0)
		{
			base.OnHandleDestroyed(eventArgs_0);
			GC.KeepAlive(this);
			GC.KeepAlive(this.CurrentRecordChanged);
			GC.KeepAlive(this.BeforeRecordDeleted);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		protected override void InnerClearMemberValues()
		{
			base.InnerClearMemberValues();
			string_5 = null;
			gclass299_0 = null;
			_CourseRecordController = null;
			instanceFactoryForCOM_0 = null;
			_InstanceIndex = 0;
		}

		[ComVisible(true)]
		public Color StringToColor(string string_6)
		{
			return XMLSerializeHelper.StringToColor(string_6, Color.Transparent);
		}

		/// <summary>
		///       为PB而关闭编辑器，用于解决PB中关闭编辑器而导致的程序闪退现象。
		///       </summary>
		[ComVisible(true)]
		public void CloseForPB()
		{
			_Ctls.Add(this);
			try
			{
				if (base.InnerViewControl != null)
				{
					base.InnerViewControl.method_111();
				}
				GClass124.smethod_6(this);
				ClearContent();
				InnerClearMemberValues();
				List<Control> list = new List<Control>();
				foreach (Control control in base.Controls)
				{
					list.Add(control);
				}
				foreach (Control item in list)
				{
					base.Controls.Remove(item);
					item.Dispose();
				}
				GC.SuppressFinalize(this);
				GC.Collect();
				dlgAxWriterControlDock.AddControl(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		/// <summary>
		///       为PB而关闭编辑器，用于解决PB中关闭编辑器而导致的程序闪退现象。本函数不会控件停靠到系统内置的垃圾堆窗体中。
		///       </summary>
		[ComVisible(true)]
		public void CloseForPBWithoutDock()
		{
			_Ctls.Add(this);
			try
			{
				GClass124.smethod_6(this);
				ClearContent();
				InnerClearMemberValues();
				List<Control> list = new List<Control>();
				foreach (Control control in base.Controls)
				{
					list.Add(control);
				}
				foreach (Control item in list)
				{
					base.Controls.Remove(item);
					item.Dispose();
				}
				GC.SuppressFinalize(this);
				GC.Collect();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		/// <summary>
		///       COM中注销控件，释放资源
		///       </summary>
		[ComVisible(true)]
		public void ComDispose()
		{
			if (!base.IsDisposed)
			{
				Dispose();
			}
			GC.Collect();
		}

		/// <summary>
		///       获得文档校验不通过信息的个数
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public int GetDocumentValueValidateResultCount()
		{
			return base.Document.ValueValidate()?.Count ?? 0;
		}

		protected override void OnBackColorChanged(EventArgs eventArgs_0)
		{
			base.OnBackColorChanged(eventArgs_0);
			base.InnerViewControl.BackColor = BackColor;
		}

		/// <summary>
		///       控件加载时处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			method_20(eventArgs_0);
			method_17();
			OnResize(null);
			if (!base.InDesignMode)
			{
				ReloadAxContentBase64String();
			}
		}

		private void ReloadAxContentBase64String()
		{
			int num = 3;
			if (!base.IsDisposed)
			{
				try
				{
					if (!string.IsNullOrEmpty(string_5))
					{
						gclass299_0 = new GClass299();
						gclass299_0.method_1(method_81);
						if (gclass299_0 != null)
						{
							gclass299_0.method_2(300);
						}
					}
					else if (gclass299_0 != null)
					{
						gclass299_0.method_4();
						gclass299_0 = null;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private void method_81(object sender, EventArgs e)
		{
			if (!base.IsDisposed && !base.InDesignMode && !string.IsNullOrEmpty(string_5))
			{
				byte[] byte_ = Convert.FromBase64String(string_5);
				byte_ = FileHelper.GZipDecompress(byte_);
				bool enableDataBinding = base.DocumentOptions.BehaviorOptions.EnableDataBinding;
				try
				{
					base.DocumentOptions.BehaviorOptions.EnableDataBinding = false;
					if (!string.IsNullOrEmpty(DebugFileNameForAxContentBase64String))
					{
						string directoryName = Path.GetDirectoryName(DebugFileNameForAxContentBase64String);
						if (Directory.Exists(directoryName))
						{
							File.WriteAllBytes(DebugFileNameForAxContentBase64String, byte_);
						}
					}
					LoadDocumentFromBinary(byte_, null);
				}
				finally
				{
					base.DocumentOptions.BehaviorOptions.EnableDataBinding = enableDataBinding;
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。
		///       </summary>
		/// <param name="base64">
		/// </param>
		/// <returns>
		/// </returns>
		public static XTextDocument InnerLoadAxContentBase64String(string base64)
		{
			byte[] byte_ = Convert.FromBase64String(base64);
			byte_ = FileHelper.GZipDecompress(byte_);
			XTextDocument xTextDocument = new XTextDocument();
			MemoryStream stream = new MemoryStream(byte_);
			xTextDocument.Load(stream, null);
			return xTextDocument;
		}

		/// <summary>
		///       DCWriter内部使用。解析Base64字符串
		///       </summary>
		/// <param name="base64">
		/// </param>
		/// <returns>
		/// </returns>
		public static byte[] InnerParseBase64String(string base64)
		{
			if (!string.IsNullOrEmpty(base64))
			{
				byte[] byte_ = Convert.FromBase64String(base64);
				return FileHelper.GZipDecompress(byte_);
			}
			return null;
		}

		/// <summary>
		///       处理EventAfterLoadRawDOM事件
		///       </summary>
		/// <param name="args">事件参数</param>
		public override void OnEventAfterLoadRawDOM(WriterEventArgs args)
		{
			base.OnEventAfterLoadRawDOM(args);
			if (base.AllowApplyLocalDocumentOptions && args.Document.DocumentOptionsToSaveFile != null)
			{
				base.DocumentOptions = args.Document.DocumentOptionsToSaveFile;
			}
			if (args.Document.ControlOptionsForDebug != null)
			{
				args.Document.ControlOptionsForDebug.WriteToControl(this);
				args.Document.ControlOptionsForDebug = null;
			}
		}

		[ComVisible(true)]
		public string SaveToAxContentBase64String()
		{
			return SaveToAxContentBase64String(base.Document);
		}

		/// <summary>
		///       DCWriter内部使用。将文档内容保存为AX格式的BASE64字符串
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>字符串</returns>
		
		[Browsable(false)]
		public static string SaveToAxContentBase64String(XTextDocument document)
		{
			int num = 15;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			byte[] byte_ = document.SaveToBinary(null);
			byte_ = FileHelper.GZipCompress(byte_);
			return Convert.ToBase64String(byte_);
		}

		/// <summary>
		///       将字符串转换为UTF8编码
		///       </summary>
		/// <param name="unicodeString">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public string ConverToUTF8DecodedString(string unicodeString)
		{
			if (string.IsNullOrEmpty(unicodeString))
			{
				return "";
			}
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] bytes = uTF8Encoding.GetBytes(unicodeString);
			return uTF8Encoding.GetString(bytes);
		}

		[Obsolete("仅供都昌公司内部测试使用，未来可能会删除的")]
		public static byte[] smethod_3(byte[] byte_0)
		{
			return FileHelper.GZipCompress(byte_0);
		}

		/// <summary>
		///       仅供兼容性支持，不要使用。
		///       </summary>
		/// <param name="xmlText">
		/// </param>
		/// <returns>
		/// </returns>
		[Obsolete("!!!仅供兼容性支持，不要使用。!!!")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public bool LoadDocumentString(string xmlText)
		{
			return LoadDocumentFromString(xmlText, null);
		}

		/// <summary>
		///       设置文档选项
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">参数值</param>
		[Browsable(false)]
		[Obsolete("!!!仅供COM支持，不推荐在.NET中使用。!!!")]
		[ComVisible(true)]
		public bool ComSetDocumentOption(string name, string Value)
		{
			if (string.IsNullOrEmpty(name))
			{
				return false;
			}
			return ValueTypeHelper.SetPropertyValueMultiLayer(base.DocumentOptions, name, Value, throwExecption: false);
		}

		/// <summary>
		///       获得文档选项
		///       </summary>
		/// <param name="name">选项名称</param>
		/// <returns>选项值</returns>
		[Obsolete("!!!仅供COM支持，不推荐在.NET中使用。!!!")]
		[ComVisible(true)]
		[Browsable(false)]
		public string ComGetDocumentOptionValue(string name)
		{
			return null;
		}

		/// <summary>
		///       设置当前部门信息
		///       </summary>
		/// <param name="departmentID">部门编号</param>
		/// <param name="departmentName">部门名称</param>
		[Obsolete("!!!仅供COM支持，不推荐在.NET中使用。!!!")]
		[ComVisible(true)]
		[Browsable(false)]
		public void SetCurrentDepartmentInfo(string departmentID, string departmentName)
		{
			CurrentDepartmentInfo currentDepartmentInfo = new CurrentDepartmentInfo();
			currentDepartmentInfo.ID = departmentID;
			currentDepartmentInfo.Name = departmentName;
			base.AppHost.Services.AddService(typeof(CurrentDepartmentInfo), currentDepartmentInfo);
		}

		/// <summary>
		///       获得指定的文档元素在编辑器控件客户区中的边界
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>边界</returns>
		[ComVisible(true)]
		public RectangleClass ComGetElementClientBounds(XTextElement element)
		{
			Rectangle elementClientBounds = GetElementClientBounds(element);
			return new RectangleClass(elementClientBounds);
		}

		[ComRegisterFunction]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private static void Register(Type type_0)
		{
			GClass305.smethod_1(type_0, "1");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComUnregisterFunction]
		private static void Unregister(Type type_0)
		{
			GClass305.smethod_2(type_0);
		}

		/// <summary>
		///       执行InsertInputField命令
		///       </summary>
		/// <param name="showUI">是否显示用户界面</param>
		/// <param name="parameter">参数</param>
		/// <returns>操作生成的输入域对象</returns>
		[ComVisible(true)]
		public XTextInputFieldElement Command_InsertInputField(bool showUI, object parameter)
		{
			return ExecuteCommand("InsertInputField", showUI, parameter) as XTextInputFieldElement;
		}

		/// <summary>
		///       执行ElementProperties命令
		///       </summary>
		/// <param name="showUI">是否显示用户界面</param>
		/// <param name="parameter">参数</param>
		/// <returns>操作的文档元素对象</returns>
		[ComVisible(true)]
		public XTextElement Command_ElementProperties(bool showUI, object parameter)
		{
			return ExecuteCommand("ElementProperties", showUI, parameter) as XTextElement;
		}

		/// <summary>
		///       开始启用病程记录模式
		///       </summary>
		[ComVisible(true)]
		public void StartCourseRecordMode()
		{
			_CourseRecordController = new SectionCourseRecordDocumentController();
			_CourseRecordController.ViewControl = this;
			_CourseRecordController.CurrentRecordChanged += _CourseRecordController_CurrentRecordChanged;
			_CourseRecordController.BeforeRecordDeleted += _CourseRecordController_BeforeRecordDeleted;
			_CourseRecordController.Start();
		}

		private void _CourseRecordController_BeforeRecordDeleted(object sender, WriterCancelEventArgs e)
		{
			if (this.BeforeRecordDeleted != null && base.EnabledControlEvent)
			{
				if (IsAxControl)
				{
					try
					{
						this.BeforeRecordDeleted(this, e);
					}
					catch (Exception ex)
					{
						if (!WriterUtils.smethod_31(ex))
						{
							throw ex;
						}
					}
				}
				else
				{
					this.BeforeRecordDeleted(this, e);
				}
			}
		}

		private void _CourseRecordController_CurrentRecordChanged(object sender, WriterEventArgs e)
		{
			if (this.CurrentRecordChanged != null)
			{
				if (IsAxControl)
				{
					try
					{
						this.CurrentRecordChanged(this, e);
					}
					catch (Exception ex)
					{
						if (!WriterUtils.smethod_31(ex))
						{
							throw ex;
						}
					}
				}
				else
				{
					this.CurrentRecordChanged(this, e);
				}
			}
		}

		/// <summary>
		///       创建XTextCustomShapeElement对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public XTextCustomShapeElement ComCreateXTextCustomShapeElement()
		{
			return new XTextCustomShapeElement();
		}

		[ComVisible(true)]
		public XTextCustomShapeElement ComConvertToXTextCustomShapeElement(object sourceValue)
		{
			return sourceValue as XTextCustomShapeElement;
		}

		/// <summary>
		///       创建ValueValidateStyle对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public ValueValidateStyle ComCreateValueValidateStyle()
		{
			return new ValueValidateStyle();
		}

		/// <summary>
		///       创建ValueFormater对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public ValueFormater ComCreateValueFormater()
		{
			return new ValueFormater();
		}

		/// <summary>
		///       创建GridLineInfo对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public GridLineInfo ComCreateGridLineInfo()
		{
			return new GridLineInfo();
		}

		/// <summary>
		///       创建JumpPrintInfo对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public JumpPrintInfo ComCreateJumpPrintInfo()
		{
			return new JumpPrintInfo();
		}

		/// <summary>
		///       创建PrintPageCollection对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public PrintPageCollection ComCreatePrintPageCollection()
		{
			return new PrintPageCollection();
		}

		/// <summary>
		///       创建PrintResult对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public PrintResult ComCreatePrintResult()
		{
			return new PrintResult();
		}

		/// <summary>
		///       创建XPageSettings对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public XPageSettings ComCreateXPageSettings()
		{
			return new XPageSettings();
		}

		/// <summary>
		///       创建BorderBackgroundCommandParameter对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public BorderBackgroundCommandParameter ComCreateBorderBackgroundCommandParameter()
		{
			return new BorderBackgroundCommandParameter();
		}

		/// <summary>
		///       创建FileOpenCommandParameter对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public FileOpenCommandParameter ComCreateFileOpenCommandParameter()
		{
			return new FileOpenCommandParameter();
		}

		/// <summary>
		///       创建FilePrintPreviewCommandParameter对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public FilePrintPreviewCommandParameter ComCreateFilePrintPreviewCommandParameter()
		{
			return new FilePrintPreviewCommandParameter();
		}

		/// <summary>
		///       创建FilePrintCommandParameter对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public FilePrintCommandParameter ComCreateFilePrintCommandParameter()
		{
			return new FilePrintCommandParameter();
		}

		/// <summary>
		///       创建FileSaveCommandParameter对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public FileSaveCommandParameter ComCreateFileSaveCommandParameter()
		{
			return new FileSaveCommandParameter();
		}

		/// <summary>
		///       创建InsertDocumentCommandParameter对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public InsertDocumentCommandParameter ComCreateInsertDocumentCommandParameter()
		{
			return new InsertDocumentCommandParameter();
		}

		[ComVisible(true)]
		public InsertStringCommandParameter ComCreateInsertStringCommandParameter()
		{
			return new InsertStringCommandParameter();
		}

		[ComVisible(true)]
		public MegeCellCommandParameter ComCreateMegeCellCommandParameter()
		{
			return new MegeCellCommandParameter();
		}

		[ComVisible(true)]
		public ParagraphFormatCommandParameter ComCreateParagraphFormatCommandParameter()
		{
			return new ParagraphFormatCommandParameter();
		}

		[ComVisible(true)]
		public SearchReplaceCommandArgs ComCreateSearchReplaceCommandArgs()
		{
			return new SearchReplaceCommandArgs();
		}

		[ComVisible(true)]
		public SplitCellExtCommandParameter ComCreateSplitCellExtCommandParameter()
		{
			return new SplitCellExtCommandParameter();
		}

		[ComVisible(true)]
		public TableCommandArgs ComCreateTableCommandArgs()
		{
			return new TableCommandArgs();
		}

		[ComVisible(true)]
		public ContentChangedEventArgs ComCreateContentChangedEventArgs()
		{
			return new ContentChangedEventArgs();
		}

		[ComVisible(true)]
		public ContentChangingEventArgs ComCreateContentChangingEventArgs()
		{
			return new ContentChangingEventArgs();
		}

		[ComVisible(true)]
		public CommandErrorEventArgs ComCreateCommandErrorEventArgs()
		{
			return new CommandErrorEventArgs();
		}

		[ComVisible(true)]
		public CurrentDepartmentInfo ComCreateCurrentDepartmentInfo()
		{
			return new CurrentDepartmentInfo();
		}

		[ComVisible(true)]
		public CurrentUserInfo ComCreateCurrentUserInfo()
		{
			return new CurrentUserInfo();
		}

		[ComVisible(true)]
		public KBEntry ComCreateKBEntry()
		{
			return new KBEntry();
		}

		[ComVisible(true)]
		public KBEntryList ComCreateKBEntryList()
		{
			return new KBEntryList();
		}

		[ComVisible(true)]
		public KBLibrary ComCreateKBLibrary()
		{
			return new KBLibrary();
		}

		[ComVisible(true)]
		public ListItem ComCreateListItem()
		{
			return new ListItem();
		}

		[ComVisible(true)]
		public ListItemCollection ComCreateListItemCollection()
		{
			return new ListItemCollection();
		}

		[ComVisible(true)]
		public ListSourceInfo ComCreateListSourceInfo()
		{
			return new ListSourceInfo();
		}

		[ComVisible(true)]
		public XTextRadioBoxElement ComCreateXTextRadioBoxElement()
		{
			return new XTextRadioBoxElement();
		}

		[ComVisible(true)]
		public CopySourceInfo ComCreateCopySourceInfo()
		{
			return new CopySourceInfo();
		}

		[ComVisible(true)]
		public CurrentContentStyleInfo ComCreateCurrentContentStyleInfo()
		{
			return new CurrentContentStyleInfo();
		}

		[ComVisible(true)]
		public DocumentComment ComCreateDocumentComment()
		{
			return new DocumentComment();
		}

		[ComVisible(true)]
		public DCGridLineInfo ComCreateDCGridLineInfo()
		{
			return new DCGridLineInfo();
		}

		[ComVisible(true)]
		public DocumentContentStyle ComCreateDocumentContentStyle()
		{
			return new DocumentContentStyle();
		}

		[ComVisible(true)]
		public FileContentSource ComCreateFileContentSource()
		{
			return new FileContentSource();
		}

		[ComVisible(true)]
		public InputFieldSettings ComCreateInputFieldSettings()
		{
			return new InputFieldSettings();
		}

		[ComVisible(true)]
		public XAttribute ComCreateXAttribute()
		{
			return new XAttribute();
		}

		[ComVisible(true)]
		public XAttributeList ComCreateXAttributeList()
		{
			return new XAttributeList();
		}

		[ComVisible(true)]
		public XDataBinding ComCreateXDataBinding()
		{
			return new XDataBinding();
		}

		[ComVisible(true)]
		public XTextBarcodeFieldElement ComCreateXTextBarcodeFieldElement()
		{
			return new XTextBarcodeFieldElement();
		}

		[ComVisible(true)]
		public XTextCheckBoxElement ComCreateXTextCheckBoxElement()
		{
			return new XTextCheckBoxElement();
		}

		[ComVisible(true)]
		public XTextContentLinkFieldElement ComCreateXTextContentLinkFieldElement()
		{
			return new XTextContentLinkFieldElement();
		}

		[ComVisible(true)]
		public XTextControlHostElement ComCreateXTextControlHostElement()
		{
			return new XTextControlHostElement();
		}

		[ComVisible(true)]
		public XTextDocument ComCreateXTextDocument()
		{
			return new XTextDocument();
		}

		[ComVisible(true)]
		public XTextDocumentList ComCreateXTextDocumentList()
		{
			return new XTextDocumentList();
		}

		[ComVisible(true)]
		public XTextElementList ComCreateXTextElementList()
		{
			return new XTextElementList();
		}

		[ComVisible(true)]
		public XTextFileBlockElement ComCreateXTextFileBlockElement()
		{
			return new XTextFileBlockElement();
		}

		[ComVisible(true)]
		public XTextHorizontalLineElement ComCreateXTextHorizontalLineElement()
		{
			return new XTextHorizontalLineElement();
		}

		[ComVisible(true)]
		public XTextImageElement ComCreateXTextImageElement()
		{
			return new XTextImageElement();
		}

		[ComVisible(true)]
		public XTextInputFieldElement ComCreateXTextInputFieldElement()
		{
			return new XTextInputFieldElement();
		}

		[ComVisible(true)]
		public XTextLabelElement ComCreateXTextLabelElement()
		{
			return new XTextLabelElement();
		}

		[ComVisible(true)]
		public XTextLineBreakElement ComCreateXTextLineBreakElement()
		{
			return new XTextLineBreakElement();
		}

		[ComVisible(true)]
		public XTextPageBreakElement ComCreateXTextPageBreakElement()
		{
			return new XTextPageBreakElement();
		}

		[ComVisible(true)]
		public XTextPageInfoElement ComCreateXTextPageInfoElement()
		{
			return new XTextPageInfoElement();
		}

		[ComVisible(true)]
		public XTextParagraphFlagElement ComCreateXTextParagraphFlagElement()
		{
			return new XTextParagraphFlagElement();
		}

		[ComVisible(true)]
		public XTextSectionElement ComCreateXTextSectionElement()
		{
			return new XTextSectionElement();
		}

		[ComVisible(true)]
		public XTextSignElement ComCreateXTextSignElement()
		{
			return new XTextSignElement();
		}

		[ComVisible(true)]
		public XTextTableCellElement ComCreateXTextTableCellElement()
		{
			return new XTextTableCellElement();
		}

		[ComVisible(true)]
		public XTextTableColumnElement ComCreateXTextTableColumnElement()
		{
			return new XTextTableColumnElement();
		}

		[ComVisible(true)]
		public XTextTableElement ComCreateXTextTableElement()
		{
			return new XTextTableElement();
		}

		[ComVisible(true)]
		public XTextTableRowElement ComCreateXTextTableRowElement()
		{
			return new XTextTableRowElement();
		}

		[ComVisible(true)]
		public XTextTemperatureChartElement ComCreateXTextTemperatureChartElement()
		{
			return new XTextTemperatureChartElement();
		}

		[ComVisible(true)]
		public ElementEventArgs ComCreateElementEventArgs()
		{
			return new ElementEventArgs();
		}

		[ComVisible(true)]
		public ElementEventTemplate ComCreateElementEventTemplate()
		{
			return new ElementEventTemplate();
		}

		[ComVisible(true)]
		public EventExpressionInfo ComCreateEventExpressionInfo()
		{
			return new EventExpressionInfo();
		}

		[ComVisible(true)]
		public EventExpressionInfoList ComCreateEventExpressionInfoList()
		{
			return new EventExpressionInfoList();
		}

		[ComVisible(true)]
		public DataSourceDescriptor ComCreateDataSourceDescriptor()
		{
			return new DataSourceDescriptor();
		}

		[ComVisible(true)]
		public DataSourceDescriptorList ComCreateDataSourceDescriptorList()
		{
			return new DataSourceDescriptorList();
		}

		[ComVisible(true)]
		public XTextMedicalExpressionFieldElement ComCreateXTextMedicalExpressionFieldElement()
		{
			return new XTextMedicalExpressionFieldElement();
		}

		[ComVisible(true)]
		public XTextNewMedicalExpressionElement ComCreateXTextNewMedicalExpressionElement()
		{
			return new XTextNewMedicalExpressionElement();
		}

		[ComVisible(true)]
		public SectionCourseRecordDocumentController ComCreateSectionCourseRecordDocumentController()
		{
			return new SectionCourseRecordDocumentController();
		}

		[ComVisible(true)]
		public GridLineSettings ComCreateGridLineSettings()
		{
			return new GridLineSettings();
		}

		[ComVisible(true)]
		public TrackVisibleConfig ComCreateTrackVisibleConfig()
		{
			return new TrackVisibleConfig();
		}

		/// <summary>
		///       将对象转换为ValueValidateStyle类型
		///       </summary>
		/// <param name="sourceValue">原始对象</param>
		/// <returns>转换后的对象,若转换失败则返回空引用</returns>
		[ComVisible(true)]
		public ValueValidateStyle ComConvertToValueValidateStyle(object sourceValue)
		{
			return sourceValue as ValueValidateStyle;
		}

		[ComVisible(true)]
		public ValueFormater ComConvertToValueFormater(object sourceValue)
		{
			return sourceValue as ValueFormater;
		}

		[ComVisible(true)]
		public GridLineInfo ComConvertToGridLineInfo(object sourceValue)
		{
			return sourceValue as GridLineInfo;
		}

		[ComVisible(true)]
		public JumpPrintInfo ComConvertToJumpPrintInfo(object sourceValue)
		{
			return sourceValue as JumpPrintInfo;
		}

		[ComVisible(true)]
		public PrintPageCollection ComConvertToPrintPageCollection(object sourceValue)
		{
			return sourceValue as PrintPageCollection;
		}

		[ComVisible(true)]
		public PrintResult ComConvertToPrintResult(object sourceValue)
		{
			return sourceValue as PrintResult;
		}

		[ComVisible(true)]
		public XPageSettings ComConvertToXPageSettings(object sourceValue)
		{
			return sourceValue as XPageSettings;
		}

		[ComVisible(true)]
		public CanInsertObjectEventArgs ComConvertToCanInsertObjectEventArgs(object sourceValue)
		{
			return sourceValue as CanInsertObjectEventArgs;
		}

		[ComVisible(true)]
		public BorderBackgroundCommandParameter ComConvertToBorderBackgroundCommandParameter(object sourceValue)
		{
			return sourceValue as BorderBackgroundCommandParameter;
		}

		[ComVisible(true)]
		public FileOpenCommandParameter ComConvertToFileOpenCommandParameter(object sourceValue)
		{
			return sourceValue as FileOpenCommandParameter;
		}

		[ComVisible(true)]
		public FilePrintPreviewCommandParameter ComConvertToFilePrintPreviewCommandParameter(object sourceValue)
		{
			return sourceValue as FilePrintPreviewCommandParameter;
		}

		[ComVisible(true)]
		public FileSaveCommandParameter ComConvertToFileSaveCommandParameter(object sourceValue)
		{
			return sourceValue as FileSaveCommandParameter;
		}

		[ComVisible(true)]
		public InsertDocumentCommandParameter ComConvertToInsertDocumentCommandParameter(object sourceValue)
		{
			return sourceValue as InsertDocumentCommandParameter;
		}

		[ComVisible(true)]
		public InsertStringCommandParameter ComConvertToInsertStringCommandParameter(object sourceValue)
		{
			return sourceValue as InsertStringCommandParameter;
		}

		[ComVisible(true)]
		public MegeCellCommandParameter ComConvertToMegeCellCommandParameter(object sourceValue)
		{
			return sourceValue as MegeCellCommandParameter;
		}

		[ComVisible(true)]
		public ParagraphFormatCommandParameter ComConvertToParagraphFormatCommandParameter(object sourceValue)
		{
			return sourceValue as ParagraphFormatCommandParameter;
		}

		[ComVisible(true)]
		public SearchReplaceCommandArgs ComConvertToSearchReplaceCommandArgs(object sourceValue)
		{
			return sourceValue as SearchReplaceCommandArgs;
		}

		[ComVisible(true)]
		public SplitCellExtCommandParameter ComConvertToSplitCellExtCommandParameter(object sourceValue)
		{
			return sourceValue as SplitCellExtCommandParameter;
		}

		[ComVisible(true)]
		public TableCommandArgs ComConvertToTableCommandArgs(object sourceValue)
		{
			return sourceValue as TableCommandArgs;
		}

		[ComVisible(true)]
		public ElementEventTemplate ComConvertToElementEventTemplate(object sourceValue)
		{
			return sourceValue as ElementEventTemplate;
		}

		[ComVisible(true)]
		public WriterCommandEventArgs ComConvertToWriterCommandEventArgs(object sourceValue)
		{
			return sourceValue as WriterCommandEventArgs;
		}

		[ComVisible(true)]
		public ContentChangedEventArgs ComConvertToContentChangedEventArgs(object sourceValue)
		{
			return sourceValue as ContentChangedEventArgs;
		}

		[ComVisible(true)]
		public ContentChangingEventArgs ComConvertToContentChangingEventArgs(object sourceValue)
		{
			return sourceValue as ContentChangingEventArgs;
		}

		[ComVisible(true)]
		public CommandErrorEventArgs ComConvertToCommandErrorEventArgs(object sourceValue)
		{
			return sourceValue as CommandErrorEventArgs;
		}

		[ComVisible(true)]
		public FormatListItemsEventArgs ComConvertToFormatListItemsEventArgs(object sourceValue)
		{
			return sourceValue as FormatListItemsEventArgs;
		}

		[ComVisible(true)]
		public ParseSelectedItemsEventArgs ComConvertToParseSelectedItemsEventArgs(object sourceValue)
		{
			return sourceValue as ParseSelectedItemsEventArgs;
		}

		[ComVisible(true)]
		public QueryListItemsEventArgs ComConvertToQueryListItemsEventArgs(object sourceValue)
		{
			return sourceValue as QueryListItemsEventArgs;
		}

		[ComVisible(true)]
		public StatusTextChangedEventArgs ComConvertToStatusTextChangedEventArgs(object sourceValue)
		{
			return sourceValue as StatusTextChangedEventArgs;
		}

		[ComVisible(true)]
		public CreateElementsByKBEntryEventArgs ComConvertToCreateElementsByKBEntryEventArgs(object sourceValue)
		{
			return sourceValue as CreateElementsByKBEntryEventArgs;
		}

		[ComVisible(true)]
		public CurrentDepartmentInfo ComConvertToCurrentDepartmentInfo(object sourceValue)
		{
			return sourceValue as CurrentDepartmentInfo;
		}

		[ComVisible(true)]
		public CurrentUserInfo ComConvertToCurrentUserInfo(object sourceValue)
		{
			return sourceValue as CurrentUserInfo;
		}

		[ComVisible(true)]
		public KBEntry ComConvertToKBEntry(object sourceValue)
		{
			return sourceValue as KBEntry;
		}

		[ComVisible(true)]
		public KBEntryList ComConvertToKBEntryList(object sourceValue)
		{
			return sourceValue as KBEntryList;
		}

		[ComVisible(true)]
		public KBLibrary ComConvertToKBLibrary(object sourceValue)
		{
			return sourceValue as KBLibrary;
		}

		[ComVisible(true)]
		public ListItem ComConvertToListItem(object sourceValue)
		{
			return sourceValue as ListItem;
		}

		[ComVisible(true)]
		public ListItemCollection ComConvertToListItemCollection(object sourceValue)
		{
			return sourceValue as ListItemCollection;
		}

		[ComVisible(true)]
		public ListSourceInfo ComConvertToListSourceInfo(object sourceValue)
		{
			return sourceValue as ListSourceInfo;
		}

		[ComVisible(true)]
		public CopySourceInfo ComConvertToCopySourceInfo(object sourceValue)
		{
			return sourceValue as CopySourceInfo;
		}

		[ComVisible(true)]
		public CurrentContentStyleInfo ComConvertToCurrentContentStyleInfo(object sourceValue)
		{
			return sourceValue as CurrentContentStyleInfo;
		}

		[ComVisible(true)]
		public DocumentComment ComConvertToDocumentComment(object sourceValue)
		{
			return sourceValue as DocumentComment;
		}

		[ComVisible(true)]
		public DocumentContentStyle ComConvertToDocumentContentStyle(object sourceValue)
		{
			return sourceValue as DocumentContentStyle;
		}

		[ComVisible(true)]
		public FileContentSource ComConvertToFileContentSource(object sourceValue)
		{
			return sourceValue as FileContentSource;
		}

		[ComVisible(true)]
		public InputFieldSettings ComConvertToInputFieldSettings(object sourceValue)
		{
			return sourceValue as InputFieldSettings;
		}

		[ComVisible(true)]
		public XAttribute ComConvertToXAttribute(object sourceValue)
		{
			return sourceValue as XAttribute;
		}

		[ComVisible(true)]
		public XAttributeList ComConvertToXAttributeList(object sourceValue)
		{
			return sourceValue as XAttributeList;
		}

		[ComVisible(true)]
		public XTextBarcodeFieldElement ComConvertToXTextBarcodeFieldElement(object sourceValue)
		{
			return sourceValue as XTextBarcodeFieldElement;
		}

		[ComVisible(true)]
		public XTextCheckBoxElement ComConvertToXTextCheckBoxElement(object sourceValue)
		{
			return sourceValue as XTextCheckBoxElement;
		}

		[ComVisible(true)]
		public XTextRadioBoxElement ComConvertToXTextRadioBoxElement(object sourceValue)
		{
			return sourceValue as XTextRadioBoxElement;
		}

		[ComVisible(true)]
		public XTextContentLinkFieldElement ComConvertToXTextContentLinkFieldElement(object sourceValue)
		{
			return sourceValue as XTextContentLinkFieldElement;
		}

		[ComVisible(true)]
		public XTextControlHostElement ComConvertToXTextControlHostElement(object sourceValue)
		{
			return sourceValue as XTextControlHostElement;
		}

		[ComVisible(true)]
		public XTextDocument ComConvertToXTextDocument(object sourceValue)
		{
			return sourceValue as XTextDocument;
		}

		[ComVisible(true)]
		public XTextDocumentList ComConvertToXTextDocumentList(object sourceValue)
		{
			return sourceValue as XTextDocumentList;
		}

		[ComVisible(true)]
		public XTextElementList ComConvertToXTextElementList(object sourceValue)
		{
			return sourceValue as XTextElementList;
		}

		[ComVisible(true)]
		public XTextFileBlockElement ComConvertToXTextFileBlockElement(object sourceValue)
		{
			return sourceValue as XTextFileBlockElement;
		}

		[ComVisible(true)]
		public XTextHorizontalLineElement ComConvertToXTextHorizontalLineElement(object sourceValue)
		{
			return sourceValue as XTextHorizontalLineElement;
		}

		[ComVisible(true)]
		public XTextImageElement ComConvertToXTextImageElement(object sourceValue)
		{
			return sourceValue as XTextImageElement;
		}

		[ComVisible(true)]
		public XTextInputFieldElement ComConvertToXTextInputFieldElement(object sourceValue)
		{
			return sourceValue as XTextInputFieldElement;
		}

		[ComVisible(true)]
		public XTextLabelElement ComConvertToXTextLabelElement(object sourceValue)
		{
			return sourceValue as XTextLabelElement;
		}

		[ComVisible(true)]
		public XTextLineBreakElement ComConvertToXTextLineBreakElement(object sourceValue)
		{
			return sourceValue as XTextLineBreakElement;
		}

		[ComVisible(true)]
		public XTextPageBreakElement ComConvertToXTextPageBreakElement(object sourceValue)
		{
			return sourceValue as XTextPageBreakElement;
		}

		[ComVisible(true)]
		public XTextPageInfoElement ComConvertToXTextPageInfoElement(object sourceValue)
		{
			return sourceValue as XTextPageInfoElement;
		}

		[ComVisible(true)]
		public XTextParagraphFlagElement ComConvertToXTextParagraphFlagElement(object sourceValue)
		{
			return sourceValue as XTextParagraphFlagElement;
		}

		[ComVisible(true)]
		public XTextSectionElement ComConvertToXTextSectionElement(object sourceValue)
		{
			return sourceValue as XTextSectionElement;
		}

		[ComVisible(true)]
		public XTextSignElement ComConvertToXTextSignElement(object sourceValue)
		{
			return sourceValue as XTextSignElement;
		}

		[ComVisible(true)]
		public XTextTableCellElement ComConvertToXTextTableCellElement(object sourceValue)
		{
			return sourceValue as XTextTableCellElement;
		}

		[ComVisible(true)]
		public XTextTableColumnElement ComConvertToXTextTableColumnElement(object sourceValue)
		{
			return sourceValue as XTextTableColumnElement;
		}

		[ComVisible(true)]
		public XTextTableElement ComConvertToXTextTableElement(object sourceValue)
		{
			return sourceValue as XTextTableElement;
		}

		[ComVisible(true)]
		public XTextTableRowElement ComConvertToXTextTableRowElement(object sourceValue)
		{
			return sourceValue as XTextTableRowElement;
		}

		[ComVisible(true)]
		public ElementCancelEventArgs ComConvertToElementCancelEventArgs(object sourceValue)
		{
			return sourceValue as ElementCancelEventArgs;
		}

		[ComVisible(true)]
		public ElementEventArgs ComConvertToElementEventArgs(object sourceValue)
		{
			return sourceValue as ElementEventArgs;
		}

		[ComVisible(true)]
		public ElementExpressionEventArgs ComConvertToElementExpressionEventArgs(object sourceValue)
		{
			return sourceValue as ElementExpressionEventArgs;
		}

		[ComVisible(true)]
		public ElementKeyEventArgs ComConvertToElementKeyEventArgs(object sourceValue)
		{
			return sourceValue as ElementKeyEventArgs;
		}

		[ComVisible(true)]
		public ElementLoadEventArgs ComConvertToElementLoadEventArgs(object sourceValue)
		{
			return sourceValue as ElementLoadEventArgs;
		}

		[ComVisible(true)]
		public ElementMouseEventArgs ComConvertToElementMouseEventArgs(object sourceValue)
		{
			return sourceValue as ElementMouseEventArgs;
		}

		[ComVisible(true)]
		public ElementPaintEventArgs ComConvertToElementPaintEventArgs(object sourceValue)
		{
			return sourceValue as ElementPaintEventArgs;
		}

		[ComVisible(true)]
		public ElementQueryStateEventArgs ComConvertToElementQueryStateEventArgs(object sourceValue)
		{
			return sourceValue as ElementQueryStateEventArgs;
		}

		[ComVisible(true)]
		public ElementValidatingEventArgs ComConvertToElementValidatingEventArgs(object sourceValue)
		{
			return sourceValue as ElementValidatingEventArgs;
		}

		[ComVisible(true)]
		public EventExpressionInfo ComConvertToEventExpressionInfo(object sourceValue)
		{
			return sourceValue as EventExpressionInfo;
		}

		[ComVisible(true)]
		public EventExpressionInfoList ComConvertToEventExpressionInfoList(object sourceValue)
		{
			return sourceValue as EventExpressionInfoList;
		}

		[ComVisible(true)]
		public DataSourceDescriptor ComConvertToDataSourceDescriptor(object sourceValue)
		{
			return sourceValue as DataSourceDescriptor;
		}

		[ComVisible(true)]
		public DataSourceDescriptorList ComConvertToDataSourceDescriptorList(object sourceValue)
		{
			return sourceValue as DataSourceDescriptorList;
		}

		[ComVisible(true)]
		public XTextMedicalExpressionFieldElement ComConvertToXTextMedicalExpressionFieldElement(object sourceValue)
		{
			return sourceValue as XTextMedicalExpressionFieldElement;
		}

		[ComVisible(true)]
		public SectionCourseRecord ComConvertToSectionCourseRecord(object sourceValue)
		{
			return sourceValue as SectionCourseRecord;
		}

		[ComVisible(true)]
		public SectionCourseRecordDocumentController ComConvertToSectionCourseRecordDocumentController(object sourceValue)
		{
			return sourceValue as SectionCourseRecordDocumentController;
		}

		[ComVisible(true)]
		public FilterValueEventArgs ComConvertToFilterValueEventArgs(object sourceValue)
		{
			return sourceValue as FilterValueEventArgs;
		}

		[ComVisible(true)]
		public GridLineSettings ComConvertToGridLineSettings(object sourceValue)
		{
			return sourceValue as GridLineSettings;
		}

		[ComVisible(true)]
		public InsertObjectEventArgs ComConvertToInsertObjectEventArgs(object sourceValue)
		{
			return sourceValue as InsertObjectEventArgs;
		}

		[ComVisible(true)]
		public QueryUserHistoryDisplayTextEventArgs ComConvertToQueryUserHistoryDisplayTextEventArgs(object sourceValue)
		{
			return sourceValue as QueryUserHistoryDisplayTextEventArgs;
		}

		[ComVisible(true)]
		public TrackVisibleConfig ComConvertToTrackVisibleConfig(object sourceValue)
		{
			return sourceValue as TrackVisibleConfig;
		}

		[ComVisible(true)]
		public WriterEventArgs ComConvertToWriterEventArgs(object sourceValue)
		{
			return sourceValue as WriterEventArgs;
		}

		[ComVisible(true)]
		public WriterMouseEventArgs ComConvertToWriterMouseEventArgs(object sourceValue)
		{
			return sourceValue as WriterMouseEventArgs;
		}

		[ComVisible(true)]
		public XTextButtonElement ComConvertToXTextButtonElement(object sourceValue)
		{
			return sourceValue as XTextButtonElement;
		}

		[ComVisible(true)]
		public XTextElement ComConvertToXTextElement(object sourceValue)
		{
			return sourceValue as XTextElement;
		}

		[ComVisible(true)]
		public XTextButtonElement ComCreateXTextButtonElement()
		{
			return new XTextButtonElement();
		}

		[ComVisible(true)]
		public UserHistoryInfo ComCreateUserHistoryInfo()
		{
			return new UserHistoryInfo();
		}

		[ComVisible(true)]
		public UserHistoryInfo ComConvertToUserHistoryInfo(object sourceValue)
		{
			return sourceValue as UserHistoryInfo;
		}

		[ComVisible(true)]
		public ValueValidateResultList ComConvertToValueValidateResultList(object sourceValue)
		{
			return sourceValue as ValueValidateResultList;
		}

		[ComVisible(true)]
		public SectionCourseRecordSource ComCreateSectionCourseRecordSource()
		{
			return new SectionCourseRecordSource();
		}

		[ComVisible(true)]
		public SectionCourseRecordSource ComConvertToSectionCourseRecordSource(object sourceValue)
		{
			return sourceValue as SectionCourseRecordSource;
		}

		[ComVisible(true)]
		public XMLLinkListProvider ComCreateXMLLinkListProvider()
		{
			return new XMLLinkListProvider();
		}

		[ComVisible(true)]
		public XMLLinkListProvider ComConvertToXMLLinkListProvider(object sourceValue)
		{
			return sourceValue as XMLLinkListProvider;
		}

		[ComVisible(true)]
		public LinkListBindingInfo ComCreateLinkListBindingInfo()
		{
			return new LinkListBindingInfo();
		}

		[ComVisible(true)]
		public LinkListBindingInfo ComConvertToLinkListBindingInfo(object sourceValue)
		{
			return sourceValue as LinkListBindingInfo;
		}

		[ComVisible(true)]
		public XTextSubDocumentElement ComCreateXTextSubDocumentSectionElement()
		{
			return new XTextSubDocumentElement();
		}

		[ComVisible(true)]
		public XTextSubDocumentElement ComCreateXTextSubDocumentElement()
		{
			XTextSubDocumentElement xTextSubDocumentElement = new XTextSubDocumentElement();
			xTextSubDocumentElement.OwnerDocument = base.Document;
			return xTextSubDocumentElement;
		}

		[ComVisible(true)]
		public XTextSubDocumentElement ComConvertToXTextSubDocumentElement(object sourceValue)
		{
			return sourceValue as XTextSubDocumentElement;
		}

		[ComVisible(true)]
		public XTextSubDocumentElement ComConvertToXTextSubDocumentSectionElement(object sourceValue)
		{
			return sourceValue as XTextSubDocumentElement;
		}

		[ComVisible(true)]
		public int ComGetAutoScrollPositionX()
		{
			return base.InnerViewControl.AutoScrollPosition.X;
		}

		[ComVisible(true)]
		public int ComGetAutoScrollPositionY()
		{
			return base.InnerViewControl.AutoScrollPosition.Y;
		}

		[ComVisible(true)]
		public void ComSetAutoScrollPosition(int int_4, int int_5)
		{
			Point autoScrollPosition = default(Point);
			autoScrollPosition.X = int_4;
			autoScrollPosition.Y = -int_5;
			base.InnerViewControl.AutoScrollPosition = autoScrollPosition;
		}

		[ComVisible(true)]
		public int ComGetCurrentPageIndexByScrollPosition()
		{
			int maximum = base.InnerViewControl.VerticalScroll.Maximum;
			int value = base.InnerViewControl.VerticalScroll.Value;
			int pageCount = base.PageCount;
			double num = base.PageSettings.ViewPaperHeight;
			double num2 = base.PageSettings.ViewTopMargin;
			_ = (double)base.PageSettings.ViewBottomMargin;
			double num3 = (double)maximum / ((double)pageCount * (num2 + num));
			double num4 = num3 * (num + num2);
			return value / (int)num4;
		}

		[ComVisible(true)]
		public string ComGetCurrentCoreVersion()
		{
			return WriterControl.StaticCoreVersion;
		}

		void IAxWriterControl.AddBufferedListItems(string param0, ListItemCollection param1, bool param2)
		{
			AddBufferedListItems(param0, param1, param2);
		}

		void IAxWriterControl.AddContextMenuItem(string param0, string param1)
		{
			AddContextMenuItem(param0, param1);
		}

		void IAxWriterControl.AddContextMenuItemByTypeName(string param0, string param1, string param2, string param3)
		{
			AddContextMenuItemByTypeName(param0, param1, param2, param3);
		}

		void IAxWriterControl.AddContextMenuSeparatorByTypeName(string param0)
		{
			AddContextMenuSeparatorByTypeName(param0);
		}

		bool IAxWriterControl.AddDropdownListItem(string param0, string param1, string param2, bool param3)
		{
			return AddDropdownListItem(param0, param1, param2, param3);
		}

		void IAxWriterControl.AddXMLLinkListProvider(string param0, string param1)
		{
			AddXMLLinkListProvider(param0, param1);
		}

		void IAxWriterControl.AppendSubDocument(XTextSubDocumentElement param0)
		{
			AppendSubDocument(param0);
		}

		void IAxWriterControl.AutoSaveDelete(string param0)
		{
			AutoSaveDelete(param0);
		}

		bool IAxWriterControl.AutoSaveExists(string param0, bool param1)
		{
			return AutoSaveExists(param0, param1);
		}

		bool IAxWriterControl.AutoSaveLoadDocument(string param0)
		{
			return AutoSaveLoadDocument(param0);
		}

		bool IAxWriterControl.BeginEditElementValue(XTextElement param0)
		{
			return BeginEditElementValue(param0);
		}

		bool IAxWriterControl.BeginEditElementValueById(string param0)
		{
			return BeginEditElementValueById(param0);
		}

		bool IAxWriterControl.BeginInsertKB()
		{
			return BeginInsertKB();
		}

		void IAxWriterControl.BeginUpdate()
		{
			BeginUpdate();
		}

		bool IAxWriterControl.CancelEditElementValue()
		{
			return CancelEditElementValue();
		}

		void IAxWriterControl.ClearContent()
		{
			ClearContent();
		}

		void IAxWriterControl.ClearContextMenuItem()
		{
			ClearContextMenuItem();
		}

		void IAxWriterControl.ClearEventMessage()
		{
			ClearEventMessage();
		}

		void IAxWriterControl.ClearUndo()
		{
			ClearUndo();
		}

		object IAxWriterControl.ComCallInstanceMethodByName(object param0, string param1, string param2)
		{
			return ComCallInstanceMethodByName(param0, param1, param2);
		}

		object IAxWriterControl.ComCallMethodByName(string param0, string param1)
		{
			return ComCallMethodByName(param0, param1);
		}

		bool IAxWriterControl.ComFocus()
		{
			return ComFocus();
		}

		object IAxWriterControl.ComGetProperty(string param0)
		{
			return ComGetProperty(param0);
		}

		void IAxWriterControl.ComInvalidate()
		{
			ComInvalidate();
		}

		bool IAxWriterControl.CommitContentUserTrace(XTextContainerElement param0)
		{
			return CommitContentUserTrace(param0);
		}

		bool IAxWriterControl.CommitContentUserTraceById(string param0)
		{
			return CommitContentUserTraceById(param0);
		}

		bool IAxWriterControl.CommitDocumentUserTrace()
		{
			return CommitDocumentUserTrace();
		}

		void IAxWriterControl.ComSelect()
		{
			ComSelect();
		}

		bool IAxWriterControl.ComSetProperty(string param0, string param1)
		{
			return ComSetProperty(param0, param1);
		}

		bool IAxWriterControl.Copy()
		{
			return Copy();
		}

		XTextDocument IAxWriterControl.CreateDocumentFromClipboard()
		{
			return CreateDocumentFromClipboard();
		}

		object IAxWriterControl.CreateInstanceByTypeName(string param0)
		{
			return CreateInstanceByTypeName(param0);
		}

		void IAxWriterControl.DelayFocus(int param0)
		{
			DelayFocus(param0);
		}

		DetectResultForValueBindingModifiedList IAxWriterControl.DetectValueBindingModified()
		{
			return DetectValueBindingModified();
		}

		ValueValidateResultList IAxWriterControl.DocumentValueValidate()
		{
			return DocumentValueValidate();
		}

		ValueValidateResultList IAxWriterControl.DocumentValueValidateWithCreateDocumentComments()
		{
			return DocumentValueValidateWithCreateDocumentComments();
		}

		string IAxWriterControl.DocumentValueValidateXML()
		{
			return DocumentValueValidateXML();
		}

		bool IAxWriterControl.EditLabelPageText(XTextLabelElement param0)
		{
			return EditLabelPageText(param0);
		}

		void IAxWriterControl.EndUpdate()
		{
			EndUpdate();
		}

		object IAxWriterControl.ExecuteCommand(string param0, bool param1, object param2)
		{
			return ExecuteCommand(param0, param1, param2);
		}

		object IAxWriterControl.ExecuteStringCommand(string param0)
		{
			return ExecuteStringCommand(param0);
		}

		bool IAxWriterControl.FocusElementById(string param0)
		{
			return FocusElementById(param0);
		}

		void IAxWriterControl.GCCollect()
		{
			GCCollect();
		}

		string IAxWriterControl.GetBindingDataSources()
		{
			return GetBindingDataSources();
		}

		string IAxWriterControl.GetCheckedValueList(string param0, bool param1, bool param2, bool param3, bool param4)
		{
			return GetCheckedValueList(param0, param1, param2, param3, param4);
		}

		string IAxWriterControl.GetCommandNameList()
		{
			return GetCommandNameList();
		}

		XTextElement IAxWriterControl.GetCurrentElementByTypeName(string param0)
		{
			return GetCurrentElementByTypeName(param0);
		}

		string IAxWriterControl.GetCustomAttribute(string param0)
		{
			return GetCustomAttribute(param0);
		}

		DataSourceBindingDescriptionList IAxWriterControl.GetDataSourceBindingDescriptions()
		{
			return GetDataSourceBindingDescriptions();
		}

		string IAxWriterControl.GetDataSourceBindingDescriptionsXML()
		{
			return GetDataSourceBindingDescriptionsXML();
		}

		string IAxWriterControl.GetDetectValueBindingModifiedMessage()
		{
			return GetDetectValueBindingModifiedMessage();
		}

		bool IAxWriterControl.GetDocumentParameterEnabled(string param0)
		{
			return GetDocumentParameterEnabled(param0);
		}

		string IAxWriterControl.GetDocumentParameterValueXml(string param0)
		{
			return GetDocumentParameterValueXml(param0);
		}

		object IAxWriterControl.GetDocumnetParameterValue(string param0)
		{
			return GetDocumnetParameterValue(param0);
		}

		string IAxWriterControl.GetElementAttribute(string param0, string param1)
		{
			return GetElementAttribute(param0, param1);
		}

		XTextElement IAxWriterControl.GetElementById(string param0)
		{
			return GetElementById(param0);
		}

		XTextElement IAxWriterControl.GetElementByPosition(int param0, int param1)
		{
			return GetElementByPosition(param0, param1);
		}

		bool IAxWriterControl.GetElementChecked(string param0)
		{
			return GetElementChecked(param0);
		}

		Rectangle IAxWriterControl.GetElementClientBounds(XTextElement param0)
		{
			return GetElementClientBounds(param0);
		}

		string IAxWriterControl.GetElementProperty(string param0, string param1)
		{
			return GetElementProperty(param0, param1);
		}

		XTextElementList IAxWriterControl.GetElementsById(string param0)
		{
			return GetElementsById(param0);
		}

		XTextElementList IAxWriterControl.GetElementsByName(string param0)
		{
			return GetElementsByName(param0);
		}

		XTextElementList IAxWriterControl.GetElementsByTypeName(string param0)
		{
			return GetElementsByTypeName(param0);
		}

		string IAxWriterControl.GetElementText(string param0)
		{
			return GetElementText(param0);
		}

		string IAxWriterControl.GetElementTextByID(string param0)
		{
			return GetElementTextByID(param0);
		}

		bool IAxWriterControl.GetElementVisible(string param0)
		{
			return GetElementVisible(param0);
		}

		WriterControlEventMessage IAxWriterControl.GetEventMessage()
		{
			return GetEventMessage();
		}

		XTextElement IAxWriterControl.GetFirstElementByTypeName(string param0)
		{
			return GetFirstElementByTypeName(param0);
		}

		XTextInputFieldElement IAxWriterControl.GetInputFieldElementById(string param0)
		{
			return GetInputFieldElementById(param0);
		}

		string IAxWriterControl.GetLastEventNames()
		{
			return GetLastEventNames();
		}

		string IAxWriterControl.GetNavigateNodesString()
		{
			return GetNavigateNodesString();
		}

		string IAxWriterControl.GetNavigateNodesXMLString()
		{
			return GetNavigateNodesXMLString();
		}

		XTextElement IAxWriterControl.GetNextElementByTypeName(XTextElement param0, string param1)
		{
			return GetNextElementByTypeName(param0, param1);
		}

		DateTime IAxWriterControl.GetNowDateTime()
		{
			return GetNowDateTime();
		}

		string IAxWriterControl.GetOptionValue(string param0)
		{
			return GetOptionValue(param0);
		}

		XTextElementList IAxWriterControl.GetSpecifyElementsByTypeName(string param0)
		{
			return GetSpecifyElementsByTypeName(param0);
		}

		int IAxWriterControl.GetStyleIndexByString(string param0)
		{
			return GetStyleIndexByString(param0);
		}

		XTextTableCellElement IAxWriterControl.GetTableCell(string param0, int param1, int param2)
		{
			return GetTableCell(param0, param1, param2);
		}

		XTextTableElement IAxWriterControl.GetTableElementById(string param0)
		{
			return GetTableElementById(param0);
		}

		bool IAxWriterControl.HandleBackspace()
		{
			return HandleBackspace();
		}

		void IAxWriterControl.InsertSubDocuentAtCurrentPosition(XTextSubDocumentElement param0, bool param1)
		{
			InsertSubDocuentAtCurrentPosition(param0, param1);
		}

		bool IAxWriterControl.IsCommandChecked(string param0)
		{
			return IsCommandChecked(param0);
		}

		bool IAxWriterControl.IsCommandEnabled(string param0)
		{
			return IsCommandEnabled(param0);
		}

		bool IAxWriterControl.IsCommandSupported(string param0)
		{
			return IsCommandSupported(param0);
		}

		bool IAxWriterControl.LoadDocumentFromBase64String(string param0, string param1)
		{
			return LoadDocumentFromBase64String(param0, param1);
		}

		bool IAxWriterControl.LoadDocumentFromBinary(byte[] param0, string param1)
		{
			return LoadDocumentFromBinary(param0, param1);
		}

		bool IAxWriterControl.LoadDocumentFromFile(string param0, string param1)
		{
			return LoadDocumentFromFile(param0, param1);
		}

		bool IAxWriterControl.LoadDocumentFromString(string param0, string param1)
		{
			return LoadDocumentFromString(param0, param1);
		}

		bool IAxWriterControl.LockContentByElement(XTextContainerElement param0, string param1, string param2, bool param3)
		{
			return LockContentByElement(param0, param1, param2, param3);
		}

		bool IAxWriterControl.LockContentByElementID(string param0, string param1, string param2, bool param3)
		{
			return LockContentByElementID(param0, param1, param2, param3);
		}

		bool IAxWriterControl.LockContentByTableRow(string param0, int param1, string param2, string param3, bool param4)
		{
			return LockContentByTableRow(param0, param1, param2, param3, param4);
		}

		void IAxWriterControl.MoveDownOneLine()
		{
			MoveDownOneLine();
		}

		void IAxWriterControl.MoveEnd()
		{
			MoveEnd();
		}

		void IAxWriterControl.MoveHome()
		{
			MoveHome();
		}

		void IAxWriterControl.MoveLeft()
		{
			MoveLeft();
		}

		void IAxWriterControl.MoveRight()
		{
			MoveRight();
		}

		void IAxWriterControl.MoveTo(MoveTarget param0)
		{
			MoveTo(param0);
		}

		bool IAxWriterControl.MoveToClientPosition(int param0, int param1)
		{
			return MoveToClientPosition(param0, param1);
		}

		bool IAxWriterControl.MoveToPage(int param0)
		{
			return MoveToPage(param0);
		}

		void IAxWriterControl.MoveToPosition(int param0)
		{
			MoveToPosition(param0);
		}

		void IAxWriterControl.MoveUpOneLine()
		{
			MoveUpOneLine();
		}

		bool IAxWriterControl.Navigate(NavigateNode param0)
		{
			return Navigate(param0);
		}

		bool IAxWriterControl.NavigateByNodeID(string param0)
		{
			return NavigateByNodeID(param0);
		}

		bool IAxWriterControl.NavigateByUserTrackInfo(UserTrackInfo param0)
		{
			return NavigateByUserTrackInfo(param0);
		}

		void IAxWriterControl.PreloadSystem()
		{
			PreloadSystem();
		}

		void IAxWriterControl.PrintDocumentExt(bool param0, string param1)
		{
			PrintDocumentExt(param0, param1);
		}

		void IAxWriterControl.RaiseElementContentChangedEvent(XTextElement param0)
		{
			RaiseElementContentChangedEvent(param0);
		}

		void IAxWriterControl.RedrawDocument()
		{
			RedrawDocument();
		}

		void IAxWriterControl.RefreshDocument()
		{
			RefreshDocument();
		}

		void IAxWriterControl.RefreshDocumentLayout()
		{
			RefreshDocumentLayout();
		}

		void IAxWriterControl.RefreshInnerView(bool param0)
		{
			RefreshInnerView(param0);
		}

		bool IAxWriterControl.RejectUserTrace()
		{
			return RejectUserTrace();
		}

		void IAxWriterControl.RemoveContextMenuItemByTypeName(string param0, string param1)
		{
			RemoveContextMenuItemByTypeName(param0, param1);
		}

		void IAxWriterControl.ResetAutoSaveTask()
		{
			ResetAutoSaveTask();
		}

		bool IAxWriterControl.ResetFormValue()
		{
			return ResetFormValue();
		}

		void IAxWriterControl.ResetOutlineNodes()
		{
			ResetOutlineNodes();
		}

		string IAxWriterControl.SaveDocumentToBase64String(string param0)
		{
			return SaveDocumentToBase64String(param0);
		}

		bool IAxWriterControl.SaveDocumentToFile(string param0, string param1)
		{
			return SaveDocumentToFile(param0, param1);
		}

		string IAxWriterControl.SaveDocumentToString(string param0)
		{
			return SaveDocumentToString(param0);
		}

		void IAxWriterControl.SaveLongImageFile(string param0)
		{
			SaveLongImageFile(param0);
		}

		void IAxWriterControl.SaveLongImageFileZoom(string param0, float param1)
		{
			SaveLongImageFileZoom(param0, param1);
		}

		string IAxWriterControl.SaveLongImageToBase64String(string param0)
		{
			return SaveLongImageToBase64String(param0);
		}

		string IAxWriterControl.SaveLongImageToBase64StringZoom(string param0, float param1)
		{
			return SaveLongImageToBase64StringZoom(param0, param1);
		}

		void IAxWriterControl.SavePageImageFile(int param0, string param1)
		{
			SavePageImageFile(param0, param1);
		}

		void IAxWriterControl.SavePageImageFileZoom(int param0, string param1, float param2)
		{
			SavePageImageFileZoom(param0, param1, param2);
		}

		string IAxWriterControl.SavePageImageToBase64String(int param0, string param1)
		{
			return SavePageImageToBase64String(param0, param1);
		}

		string IAxWriterControl.SavePageImageToBase64StringZoom(int param0, string param1, float param2)
		{
			return SavePageImageToBase64StringZoom(param0, param1, param2);
		}

		void IAxWriterControl.ScrollToCaret()
		{
			ScrollToCaret();
		}

		void IAxWriterControl.ScrollToCaretExt(ScrollToViewStyle param0)
		{
			ScrollToCaretExt(param0);
		}

		void IAxWriterControl.ScrollToViewPosition(float param0)
		{
			ScrollToViewPosition(param0);
		}

		void IAxWriterControl.SelectAll()
		{
			SelectAll();
		}

		bool IAxWriterControl.SelectElementById(string param0)
		{
			return SelectElementById(param0);
		}

		bool IAxWriterControl.SetCommandEnabled(string param0, bool param1)
		{
			return SetCommandEnabled(param0, param1);
		}

		bool IAxWriterControl.SetCommandEnableHotKey(string param0, bool param1)
		{
			return SetCommandEnableHotKey(param0, param1);
		}

		bool IAxWriterControl.SetCommandEnableLowLevel(string param0, bool param1)
		{
			return SetCommandEnableLowLevel(param0, param1);
		}

		void IAxWriterControl.SetCustomAttribute(string param0, string param1)
		{
			SetCustomAttribute(param0, param1);
		}

		void IAxWriterControl.SetDocumentParameterEnabled(string param0, bool param1)
		{
			SetDocumentParameterEnabled(param0, param1);
		}

		void IAxWriterControl.SetDocumentParameterValue(string param0, object param1)
		{
			SetDocumentParameterValue(param0, param1);
		}

		void IAxWriterControl.SetDocumentParameterValueXml(string param0, string param1)
		{
			SetDocumentParameterValueXml(param0, param1);
		}

		void IAxWriterControl.SetDomImageByBase64String(DCStdImageKey param0, string param1)
		{
			SetDomImageByBase64String(param0, param1);
		}

		void IAxWriterControl.SetDomImageByFileName(DCStdImageKey param0, string param1)
		{
			SetDomImageByFileName(param0, param1);
		}

		bool IAxWriterControl.SetElementAttribute(string param0, string param1, string param2)
		{
			return SetElementAttribute(param0, param1, param2);
		}

		bool IAxWriterControl.SetElementChecked(string param0, bool param1)
		{
			return SetElementChecked(param0, param1);
		}

		bool IAxWriterControl.SetElementProperty(string param0, string param1, string param2)
		{
			return SetElementProperty(param0, param1, param2);
		}

		bool IAxWriterControl.SetElementText(string param0, string param1)
		{
			return SetElementText(param0, param1);
		}

		bool IAxWriterControl.SetElementTextByID(string param0, string param1)
		{
			return SetElementTextByID(param0, param1);
		}

		bool IAxWriterControl.SetElementVisible(string param0, bool param1)
		{
			return SetElementVisible(param0, param1);
		}

		bool IAxWriterControl.SetInputFieldInnerValue(string param0, string param1)
		{
			return SetInputFieldInnerValue(param0, param1);
		}

		bool IAxWriterControl.SetNativeHostedControlHandle(string param0, IntPtr param1)
		{
			return SetNativeHostedControlHandle(param0, param1);
		}

		bool IAxWriterControl.SetOptionValue(string param0, string param1)
		{
			return SetOptionValue(param0, param1);
		}

		void IAxWriterControl.SetRegisterCode(string param0)
		{
			SetRegisterCode(param0);
		}

		void IAxWriterControl.SetResourceStringValue(string param0, string param1)
		{
			SetResourceStringValue(param0, param1);
		}

		void IAxWriterControl.SetToMSWordVisualStyle()
		{
			SetToMSWordVisualStyle();
		}

		void IAxWriterControl.ShowAboutDialog()
		{
			ShowAboutDialog();
		}

		bool IAxWriterControl.StartLocalAutoSave()
		{
			return StartLocalAutoSave();
		}

		void IAxWriterControl.SynchroServerTime(DateTime param0)
		{
			SynchroServerTime(param0);
		}

		void IAxWriterControl.SynchroServerTimeByParameters(int param0, int param1, int param2, int param3, int param4, int param5)
		{
			SynchroServerTimeByParameters(param0, param1, param2, param3, param4, param5);
		}

		int IAxWriterControl.UpdateDataSourceForView()
		{
			return UpdateDataSourceForView();
		}

		void IAxWriterControl.UpdateTextCaret()
		{
			UpdateTextCaret();
		}

		void IAxWriterControl.UpdateTextCaretByElement(XTextElement param0)
		{
			UpdateTextCaretByElement(param0);
		}

		void IAxWriterControl.UpdateTextCaretWithoutScroll()
		{
			UpdateTextCaretWithoutScroll();
		}

		void IAxWriterControl.UpdateUserInfoSaveTime()
		{
			UpdateUserInfoSaveTime();
		}

		void IAxWriterControl.UpdateUserInfoSaveTimeExt(bool param0)
		{
			UpdateUserInfoSaveTimeExt(param0);
		}

		int IAxWriterControl.UpdateViewForDataSource()
		{
			return UpdateViewForDataSource();
		}

		bool IAxWriterControl.UserLoginByCurrentUserInfo()
		{
			return UserLoginByCurrentUserInfo();
		}

		bool IAxWriterControl.UserLoginByParameter(string param0, string param1, int param2)
		{
			return UserLoginByParameter(param0, param1, param2);
		}

		bool IAxWriterControl.UserLoginByUserLoginInfo(UserLoginInfo param0, bool param1)
		{
			return UserLoginByUserLoginInfo(param0, param1);
		}

		bool IAxWriterControl.Win32SetFoucs()
		{
			return Win32SetFoucs();
		}

		int IAxWriterControl.WriteDataFromDataSourceToDocument()
		{
			return WriteDataFromDataSourceToDocument();
		}

		int IAxWriterControl.WriteDataFromDataSourceToDocumentSpecifyParameterNames(string param0)
		{
			return WriteDataFromDataSourceToDocumentSpecifyParameterNames(param0);
		}

		int IAxWriterControl.WriteDataFromDocumentToDataSource()
		{
			return WriteDataFromDocumentToDataSource();
		}

		int IAxWriterControl.WriteDataSource()
		{
			return WriteDataSource();
		}
	}
}

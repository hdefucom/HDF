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
using System.Collections;
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
    ///        专门用于PB开发的控件接口。
    ///       </summary>
    /// <remarks>
    ///       本控件用于COM和B/S开发,不用于.NET开发.
    ///       编制 袁永福
    ///       </remarks>
    
    [ComSourceInterfaces(typeof(IAxWriterControlForPBComEvents))]
    [ToolboxItem(false)]
    [DocumentComment]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IAxWriterControlForPB))]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("D8190F0B-A516-4352-985F-A6DF956D4978")]
    [ComClass("D8190F0B-A516-4352-985F-A6DF956D4978", "2EF03C7A-528E-4FDE-BCCF-CC186D3BBFAC", "0AE0E8E8-3A75-4A4C-9F0D-077312A860BA")]
    [ToolboxBitmap(typeof(AxWriterControl))]
    public sealed class AxWriterControlForPB : WriterControl, IObjectSafety, IAxWriterControlForPB
    {
        internal const string CLASSID = "D8190F0B-A516-4352-985F-A6DF956D4978";

        internal const string CLASSID_Interface = "2EF03C7A-528E-4FDE-BCCF-CC186D3BBFAC";

        internal const string CLASSID_ComEventInterface = "0AE0E8E8-3A75-4A4C-9F0D-077312A860BA";

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

        private bool _fSafeForScripting;

        private bool _fSafeForInitializing;

        private static int _InstanceIndexCount = 0;

        private int _InstanceIndex;

        private static List<AxWriterControlForPB> _Ctls = new List<AxWriterControlForPB>();

        private ArrayList _OuterReferences;

        private string _DebugFileNameForAxContentBase64String;

        private GClass299 gclass299_0;

        private string string_5;

        private InstanceFactoryForCOM instanceFactoryForCOM_0;

        private SectionCourseRecordDocumentController _CourseRecordController;

        /// <summary>
        ///       是否作为ActiveX控件的模式运行
        ///       </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComVisible(false)]
        [Browsable(false)]
        
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
        [ComVisible(true)]
        [DefaultValue(null)]
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
        [Browsable(false)]
        [ComVisible(true)]
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

        WriterDataFormats IAxWriterControlForPB.AcceptDataFormats
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

        string IAxWriterControlForPB.AdditionPageTitle
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

        bool IAxWriterControlForPB.AllowDragContent
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

        WriterAppHost IAxWriterControlForPB.AppHost
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

        bool IAxWriterControlForPB.AutoUserLogin
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

        string IAxWriterControlForPB.BackColorString
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

        bool IAxWriterControlForPB.BackgroundMode
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

        BorderStyle IAxWriterControlForPB.BorderStyle
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

        bool IAxWriterControlForPB.CommandStateNeedRefreshFlag
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

        FunctionControlVisibility IAxWriterControlForPB.CommentVisibility
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

        WriterDataFormats IAxWriterControlForPB.CreationDataFormats
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

        bool IAxWriterControlForPB.CurrentBold => base.CurrentBold;

        int IAxWriterControlForPB.CurrentColumnIndex => base.CurrentColumnIndex;

        DocumentComment IAxWriterControlForPB.CurrentComment => base.CurrentComment;

        PageContentPartyStyle IAxWriterControlForPB.CurrentContentPartyStyle
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

        XTextElement IAxWriterControlForPB.CurrentElement => base.CurrentElement;

        string IAxWriterControlForPB.CurrentFontName => base.CurrentFontName;

        float IAxWriterControlForPB.CurrentFontSize => base.CurrentFontSize;

        XTextInputFieldElement IAxWriterControlForPB.CurrentInputField => base.CurrentInputField;

        bool IAxWriterControlForPB.CurrentItalic => base.CurrentItalic;

        XTextLine IAxWriterControlForPB.CurrentLine => base.CurrentLine;

        int IAxWriterControlForPB.CurrentLineIndex => base.CurrentLineIndex;

        int IAxWriterControlForPB.CurrentLineIndexInPage => base.CurrentLineIndexInPage;

        int IAxWriterControlForPB.CurrentLineOwnerPageIndex => base.CurrentLineOwnerPageIndex;

        int IAxWriterControlForPB.CurrentLinePrivateIndexInPage => base.CurrentLinePrivateIndexInPage;

        NavigateNode IAxWriterControlForPB.CurrentNavigateNode => base.CurrentNavigateNode;

        DocumentOutlineNode IAxWriterControlForPB.CurrentOutlineNode => base.CurrentOutlineNode;

        PrintPage IAxWriterControlForPB.CurrentPage
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

        Color IAxWriterControlForPB.CurrentPageBorderColor
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

        string IAxWriterControlForPB.CurrentPageBorderColorString
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

        int IAxWriterControlForPB.CurrentPageIndex
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

        DocumentContentAlignment IAxWriterControlForPB.CurrentParagraphAlign => base.CurrentParagraphAlign;

        XTextParagraphFlagElement IAxWriterControlForPB.CurrentParagraphEOF => base.CurrentParagraphEOF;

        XTextSectionElement IAxWriterControlForPB.CurrentSection => base.CurrentSection;

        DocumentContentStyle IAxWriterControlForPB.CurrentStyle => base.CurrentStyle;

        XTextSubDocumentElement IAxWriterControlForPB.CurrentSubDocument => base.CurrentSubDocument;

        bool IAxWriterControlForPB.CurrentSubscript => base.CurrentSubscript;

        bool IAxWriterControlForPB.CurrentSuperscript => base.CurrentSuperscript;

        XTextTableElement IAxWriterControlForPB.CurrentTable => base.CurrentTable;

        XTextTableCellElement IAxWriterControlForPB.CurrentTableCell => base.CurrentTableCell;

        XTextTableRowElement IAxWriterControlForPB.CurrentTableRow => base.CurrentTableRow;

        bool IAxWriterControlForPB.CurrentUnderline => base.CurrentUnderline;

        UserHistoryInfo IAxWriterControlForPB.CurrentUser => base.CurrentUser;

        WriterDataObjectRange IAxWriterControlForPB.DataObjectRange
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

        string IAxWriterControlForPB.DialogTitlePrefix => base.DialogTitlePrefix;

        XTextDocument IAxWriterControlForPB.Document
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

        string IAxWriterControlForPB.DocumentBaseUrl
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

        int IAxWriterControlForPB.DocumentContentVersion => base.DocumentContentVersion;

        DocumentOptions IAxWriterControlForPB.DocumentOptions
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

        string IAxWriterControlForPB.DocumentOptionsXML
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

        DCStdImageList IAxWriterControlForPB.DomImageList => base.DomImageList;

        bool IAxWriterControlForPB.DoubleClickToEditComment
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

        bool IAxWriterControlForPB.EnabledControlEvent
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

        bool IAxWriterControlForPB.EnabledElementEvent
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

        bool IAxWriterControlForPB.EnableJumpPrint
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

        bool IAxWriterControlForPB.EnableUIEventStartEditContent
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

        int IAxWriterControlForPB.EndPageIndex
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

        ElementEventTemplateList IAxWriterControlForPB.EventTemplates
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

        string IAxWriterControlForPB.ExcludeKeywords
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

        WriterControlExtViewMode IAxWriterControlForPB.ExtViewMode
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

        string[] IAxWriterControlForPB.FormValuesArray => base.FormValuesArray;

        string IAxWriterControlForPB.FormValuesString => base.FormValuesString;

        string IAxWriterControlForPB.FormValuesXml => base.FormValuesXml;

        FormViewMode IAxWriterControlForPB.FormView
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_Cell
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_CheckBox
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_Element
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_Field
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_Image
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_Table
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

        ElementEventTemplate IAxWriterControlForPB.GlobalEventTemplate_TableRow
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

        ElementEventTemlateMap IAxWriterControlForPB.GlobalEventTemplates
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

        HeaderFooterFlagVisible IAxWriterControlForPB.HeaderFooterFlagVisible
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

        bool IAxWriterControlForPB.HeaderFooterReadonly
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

        XTextElement IAxWriterControlForPB.HoverElement => base.HoverElement;

        XTextElementList IAxWriterControlForPB.Images => base.Images;

        XTextElementList IAxWriterControlForPB.InputFields => base.InputFields;

        bool IAxWriterControlForPB.IsAdministrator
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

        JumpPrintInfo IAxWriterControlForPB.JumpPrint
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

        float IAxWriterControlForPB.JumpPrintEndPosition
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

        float IAxWriterControlForPB.JumpPrintPosition
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

        string IAxWriterControlForPB.KBLibraryUrl
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

        SystemAlertInfoList IAxWriterControlForPB.LastAlertInfos => base.LastAlertInfos;

        WriterControlEventMessage IAxWriterControlForPB.LastEventMessage => base.LastEventMessage;

        int IAxWriterControlForPB.LastPrintPosition
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

        PrintResult IAxWriterControlForPB.LastPrintResult
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

        DCLicenceDisplayMode IAxWriterControlForPB.LicenceDisplayMode
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

        bool IAxWriterControlForPB.Modified
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

        XTextElementList IAxWriterControlForPB.ModifiedInputFields => base.ModifiedInputFields;

        MoveFocusHotKeys IAxWriterControlForPB.MoveFocusHotKey
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

        DocumentNavigator IAxWriterControlForPB.Navigator => base.Navigator;

        DocumentOutlineNodeList IAxWriterControlForPB.OutlineNodes => base.OutlineNodes;

        Color IAxWriterControlForPB.PageBackColor
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

        string IAxWriterControlForPB.PageBackColorString
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

        Color IAxWriterControlForPB.PageBorderColor
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

        string IAxWriterControlForPB.PageBorderColorString
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

        int IAxWriterControlForPB.PageCount => base.PageCount;

        int IAxWriterControlForPB.PageIndex
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

        PrintPageCollection IAxWriterControlForPB.Pages
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

        int IAxWriterControlForPB.PageSpacing
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

        PageTitlePosition IAxWriterControlForPB.PageTitlePosition
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

        string IAxWriterControlForPB.PositionInfoText => base.PositionInfoText;

        string IAxWriterControlForPB.ProductVersion => base.ProductVersion;

        bool IAxWriterControlForPB.Readonly
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

        string IAxWriterControlForPB.RegisterCode
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

        string IAxWriterControlForPB.RegisterCodeFileUrl
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

        string IAxWriterControlForPB.RTFText
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

        Color IAxWriterControlForPB.RuleBackColor
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

        bool IAxWriterControlForPB.RuleVisible
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

        XTextSelection IAxWriterControlForPB.Selection => base.Selection;

        Point IAxWriterControlForPB.SelectionStartPosition => base.SelectionStartPosition;

        bool IAxWriterControlForPB.ShowTooltip
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

        XTextElement IAxWriterControlForPB.SingleSelectedElement => base.SingleSelectedElement;

        string IAxWriterControlForPB.SpecifyLoadFileNameOnce
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

        int IAxWriterControlForPB.StartPageIndex
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

        string IAxWriterControlForPB.StatusText
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

        XTextElementList IAxWriterControlForPB.SubDocuments => base.SubDocuments;

        XTextElementList IAxWriterControlForPB.Tables => base.Tables;

        UserTrackInfoList IAxWriterControlForPB.UserTrackInfos => base.UserTrackInfos;

        string IAxWriterControlForPB.WebServiceUrl
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

        string IAxWriterControlForPB.XMLText
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

        string IAxWriterControlForPB.XMLTextForSave
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

        string IAxWriterControlForPB.XMLTextUnFormatted => base.XMLTextUnFormatted;

        /// <summary>
        ///       当前记录发生改变事件
        ///       </summary>
        public event WriterEventHandler CurrentRecordChanged;

        /// <summary>
        ///       记录删除事件
        ///       </summary>
        public event WriterCancelEventHandler BeforeRecordDeleted;

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
            int num = 5;
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
            int num = 4;
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

        [ComVisible(true)]
        public bool PBSetTableCellText(ref string tableID, ref int rowIndex, ref int colIndex, ref string newText)
        {
            string tableID2 = (tableID == null) ? null : string.Copy(tableID);
            string newText2 = (newText == null) ? null : string.Copy(newText);
            bool result = SetTableCellText(tableID2, rowIndex, colIndex, newText2);
            GC.KeepAlive(tableID);
            GC.KeepAlive(rowIndex);
            GC.KeepAlive(colIndex);
            GC.KeepAlive(newText);
            return result;
        }

        [ComVisible(true)]
        public XTextTableElement PBGetTableElementById(ref string string_6)
        {
            string text = (string_6 == null) ? null : string.Copy(string_6);
            XTextTableElement tableElementById = GetTableElementById(text);
            GC.KeepAlive(string_6);
            return tableElementById;
        }

        [ComVisible(true)]
        public void PBCourseRecordControllerSetAttributeNameLabelIDMap(ref string attributeName, ref string labelID)
        {
            string attributeName2 = (attributeName == null) ? null : string.Copy(attributeName);
            string labelID2 = (labelID == null) ? null : string.Copy(labelID);
            if (CourseRecordController != null)
            {
                CourseRecordController.SetAttributeNameLabelIDMap(attributeName2, labelID2);
            }
            GC.KeepAlive(attributeName);
            GC.KeepAlive(labelID);
        }

        [ComVisible(true)]
        public XTextElement PBGetElementById(ref string string_6)
        {
            if (string_6 == null)
            {
                object _ = null;
            }
            else
                string.Copy(string_6);
            XTextElement elementById = GetElementById(string_6);
            GC.KeepAlive(string_6);
            return elementById;
        }

        [ComVisible(true)]
        public bool PBSetElementChecked(ref string string_6, ref bool bool_12)
        {
            if (string_6 == null)
            {
                object _ = null;
            }
            else
                string.Copy(string_6);
            bool result = SetElementChecked(string_6, bool_12);
            GC.KeepAlive(string_6);
            GC.KeepAlive(bool_12);
            return result;
        }

        [ComVisible(true)]
        public bool PBSetElementTextByID(ref string string_6, ref string text)
        {
            string string_7 = (string_6 == null) ? null : string.Copy(string_6);
            string text2 = (text == null) ? null : string.Copy(text);
            bool result = base.Document.SetElementTextByID(string_7, text2);
            GC.Collect();
            GC.KeepAlive(string_6);
            GC.KeepAlive(text);
            return result;
        }

        [ComVisible(true)]
        public void PBSetDocumentScriptText(ref string script)
        {
            if (script == null)
            {
                object _ = null;
            }
            else
                string.Copy(script);
            base.Document.ScriptText = script;
            GC.Collect();
            GC.KeepAlive(script);
        }

        [ComVisible(true)]
        public string PBGetHtmlText(ref bool includeSelectionOnly)
        {
            string htmlText = GetHtmlText(includeSelectionOnly);
            GC.Collect();
            GC.KeepAlive(htmlText);
            return htmlText;
        }

        [ComVisible(true)]
        public string PBGetXMLTextForSave()
        {
            string xMLTextForSave = base.XMLTextForSave;
            GC.Collect();
            GC.KeepAlive(xMLTextForSave);
            return xMLTextForSave;
        }

        [ComVisible(true)]
        public object PBExecuteCommand(ref string commandName, ref bool showUI, ref object parameter)
        {
            string commandName2 = (commandName == null) ? null : string.Copy(commandName);
            object result = ExecuteCommand(commandName2, showUI, parameter);
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.KeepAlive(commandName);
            GC.KeepAlive(showUI);
            GC.KeepAlive(parameter);
            return result;
        }

        [ComVisible(true)]
        public XTextInputFieldElement PBGetInputFieldElementById(ref string string_6)
        {
            string text = (string_6 == null) ? null : string.Copy(string_6);
            XTextInputFieldElement inputFieldElementById = GetInputFieldElementById(text);
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.KeepAlive(string_6);
            return inputFieldElementById;
        }

        /// <summary>
        ///       面向COM的设置控件属性值
        ///       </summary>
        /// <remarks>有些属性值类型不是COM公开的，无法直接设置。因此采用字符串的方式来试图设置控件属性值。
        ///       例如 ctl.PBComSetProperty("DocumentOptions.ViewOptions.ShowParagraphFlag","false");
        ///       或者ctl.PBComSetProperty("PageBackColor","Red");</remarks>
        /// <param name="propertyName">属性名</param>
        /// <param name="Value">属性值</param>
        /// <returns>操作是否成功</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("仅向PB COM公开，在.NET中不要调用")]
        public bool PBComSetProperty(ref string propertyName, ref string Value)
        {
            string propertyName2 = (propertyName == null) ? null : string.Copy(propertyName);
            string value = (Value == null) ? null : string.Copy(Value);
            bool result = ValueTypeHelper.SetPropertyValueMultiLayer(this, propertyName2, value, throwExecption: true);
            GC.KeepAlive(propertyName);
            GC.KeepAlive(Value);
            return result;
        }

        /// <summary>
        ///       面向COM的获得控件的属性值
        ///       </summary>
        /// <remarks>有些属性值类型不是COM公开的，无法直接设置。因此采用指定名称来试图设置控件属性值。
        ///       例如 ctl.ComGetProperty("DocumentOptions.BehaviorOptions.EnableScript") 返回true/false.</remarks>
        /// <param name="propertyName">属性名</param>
        /// <returns>获得的属性值</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("仅向PB COM公开，在.NET中不要调用")]
        public string PBComGetProperty(ref string propertyName)
        {
            if (propertyName == null)
            {
                object _ = null;
            }
            else
                string.Copy(propertyName);
            return ValueTypeHelper.GetPropertyValueMultiLayer(this, propertyName, null, throwExecption: true)?.ToString();
        }

        [ComVisible(true)]
        public bool PBLoadDocumentFromFile(ref string fileName, ref string format)
        {
            string text = (fileName == null) ? null : string.Copy(fileName);
            string format2 = (format == null) ? null : string.Copy(format);
            bool result = LoadDocumentFromFile(text, format2);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.KeepAlive(fileName);
            GC.KeepAlive(format);
            return result;
        }

        [ComVisible(true)]
        public bool PBLoadDocumentFromString(ref string text, ref string format)
        {
            string text2 = (text == null) ? null : string.Copy(text);
            string format2 = (format == null) ? null : string.Copy(format);
            bool result = LoadDocumentFromString(text2, format2);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.KeepAlive(text);
            GC.KeepAlive(format);
            return result;
        }

        /// <summary>
        ///       没有任何功能的函数，仅供测试
        ///       </summary>
        /// <param name="text">文本</param>
        /// <param name="format">格式</param>
        /// <returns>操作是否成功</returns>
        
        public bool NoneLoadDocumentFromString(string text, string format)
        {
            LoadDocumentFromFile("D:\\金山快盘\\项目文件\\浙江联众\\都昌控件稳定性测试3\\(呼吸科)(天医)入院记录copd_ver2.xml", null);
            return false;
        }

        /// <summary>
        ///       初始化对象
        ///       </summary>
        public AxWriterControlForPB()
        {
            int num = 11;
            _fSafeForScripting = true;
            _fSafeForInitializing = true;
            _InstanceIndex = _InstanceIndexCount++;
            _OuterReferences = null;
            _DebugFileNameForAxContentBase64String = null;
            gclass299_0 = null;
            string_5 = null;
            instanceFactoryForCOM_0 = null;
            this.CurrentRecordChanged = null;
            this.BeforeRecordDeleted = null;
            _CourseRecordController = null;

            base.AllowApplyLocalDocumentOptions = false;
            base.AutoDisposeContextMenu = true;
            base.AutoDisposeDocument = true;
            EnabledEventReadSaveFileContent = false;
            base.AutoDisposeDocument = true;
            _Ctls.Add(this);
            try
            {
                base.BorderStyle = BorderStyle.Fixed3D;
                base.InnerViewControl.BackColor = SystemColors.AppWorkspace;
                BackColor = SystemColors.AppWorkspace;
                OnCreateControl();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AxWriterControlForPBLoad:" + ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            Debug.WriteLine("AxWriterControlForPBLoaded");
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
            GC.Collect();
            GC.WaitForFullGCComplete(5000);
            GC.WaitForPendingFinalizers();
        }

        protected override void InnerClearMemberValues()
        {
            base.InnerClearMemberValues();
            string_5 = null;
            gclass299_0 = null;
            _CourseRecordController = null;
            _DebugFileNameForAxContentBase64String = null;
            instanceFactoryForCOM_0 = null;
            _InstanceIndex = 0;
            if (_OuterReferences != null && _OuterReferences.Count > 0)
            {
                foreach (object outerReference in _OuterReferences)
                {
                    if (outerReference is IDisposable)
                    {
                        ((IDisposable)outerReference).Dispose();
                    }
                    if (outerReference is XTextContainerElement)
                    {
                        XTextContainerElement xTextContainerElement = (XTextContainerElement)outerReference;
                        xTextContainerElement.Elements = null;
                        xTextContainerElement.ElementsForSerialize = null;
                    }
                    else if (outerReference is XTextElementList)
                    {
                        ((XTextElementList)outerReference).Clear();
                    }
                    else if (outerReference is InputFieldSettings)
                    {
                        InputFieldSettings inputFieldSettings = (InputFieldSettings)outerReference;
                        inputFieldSettings.ListItems = null;
                        inputFieldSettings.ListSource = null;
                    }
                    else if (outerReference is ListSourceInfo)
                    {
                        ListSourceInfo listSourceInfo = (ListSourceInfo)outerReference;
                        listSourceInfo.Items = null;
                        listSourceInfo.RuntimeItems = null;
                    }
                    else if (outerReference is WriterControlEventMessage)
                    {
                        WriterControlEventMessage writerControlEventMessage = (WriterControlEventMessage)outerReference;
                        writerControlEventMessage.method_0();
                    }
                }
            }
        }

        [ComVisible(true)]
        public Color StringToColor(string string_6)
        {
            return XMLSerializeHelper.StringToColor(string_6, Color.Transparent);
        }

        [ComVisible(false)]
        
        public override void CollectOuterReference(object instance)
        {
            if (instance != null && base.EnableCollectOuterReference)
            {
                if (_OuterReferences == null)
                {
                    _OuterReferences = new ArrayList();
                }
                _OuterReferences.Add(instance);
            }
        }

        [ComVisible(false)]
        
        public override void CollectOuterReferences(IList instances)
        {
            if (instances != null && base.EnableCollectOuterReference)
            {
                if (_OuterReferences == null)
                {
                    _OuterReferences = new ArrayList();
                }
                _OuterReferences.Add(instances);
            }
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
                GClass124.smethod_6(this);
                ClearContent();
                InnerClearMemberValues();
                List<Control> list = new List<Control>();
                foreach (Control control in base.Controls)
                {
                    list.Add(control);
                }
                base.Controls.Clear();
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
            dlgAxWriterControlDock.RemoveControl(this);
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
                Dispose();
                GC.SuppressFinalize(this);
                GC.Collect();
                GC.WaitForFullGCComplete(3000);
                GC.WaitForPendingFinalizers();
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
            if (base.IsDisposed)
            {
                return;
            }
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

        public override void OnEventAfterLoadRawDOM(WriterEventArgs args)
        {
            base.OnEventAfterLoadRawDOM(args);
            if (args.Document.DocumentOptionsToSaveFile != null)
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
            int num = 11;
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
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadDocumentString(string xmlText)
        {
            return LoadDocumentFromString(xmlText, null);
        }

        /// <summary>
        ///       设置文档选项
        ///       </summary>
        /// <param name="name">参数名</param>
        /// <param name="Value">参数值</param>
        [ComVisible(true)]
        [Browsable(false)]
        [Obsolete("!!!仅供COM支持，不推荐在.NET中使用。!!!")]
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
        [Browsable(false)]
        [ComVisible(true)]
        [Obsolete("!!!仅供COM支持，不推荐在.NET中使用。!!!")]
        public string ComGetDocumentOptionValue(string name)
        {
            return null;
        }

        /// <summary>
        ///       设置当前部门信息
        ///       </summary>
        /// <param name="departmentID">部门编号</param>
        /// <param name="departmentName">部门名称</param>
        [Browsable(false)]
        [Obsolete("!!!仅供COM支持，不推荐在.NET中使用。!!!")]
        [ComVisible(true)]
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

        [ComUnregisterFunction]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        void IAxWriterControlForPB.AddBufferedListItems(string param0, ListItemCollection param1, bool param2)
        {
            AddBufferedListItems(param0, param1, param2);
        }

        void IAxWriterControlForPB.AddContextMenuItem(string param0, string param1)
        {
            AddContextMenuItem(param0, param1);
        }

        void IAxWriterControlForPB.AddContextMenuItemByTypeName(string param0, string param1, string param2, string param3)
        {
            AddContextMenuItemByTypeName(param0, param1, param2, param3);
        }

        void IAxWriterControlForPB.AddContextMenuSeparatorByTypeName(string param0)
        {
            AddContextMenuSeparatorByTypeName(param0);
        }

        bool IAxWriterControlForPB.AddDropdownListItem(string param0, string param1, string param2, bool param3)
        {
            return AddDropdownListItem(param0, param1, param2, param3);
        }

        void IAxWriterControlForPB.AddXMLLinkListProvider(string param0, string param1)
        {
            AddXMLLinkListProvider(param0, param1);
        }

        void IAxWriterControlForPB.AppendSubDocument(XTextSubDocumentElement param0)
        {
            AppendSubDocument(param0);
        }

        void IAxWriterControlForPB.AutoSaveDelete(string param0)
        {
            AutoSaveDelete(param0);
        }

        bool IAxWriterControlForPB.AutoSaveExists(string param0, bool param1)
        {
            return AutoSaveExists(param0, param1);
        }

        bool IAxWriterControlForPB.AutoSaveLoadDocument(string param0)
        {
            return AutoSaveLoadDocument(param0);
        }

        bool IAxWriterControlForPB.BeginEditElementValue(XTextElement param0)
        {
            return BeginEditElementValue(param0);
        }

        bool IAxWriterControlForPB.BeginEditElementValueById(string param0)
        {
            return BeginEditElementValueById(param0);
        }

        bool IAxWriterControlForPB.BeginInsertKB()
        {
            return BeginInsertKB();
        }

        void IAxWriterControlForPB.BeginUpdate()
        {
            BeginUpdate();
        }

        bool IAxWriterControlForPB.CancelEditElementValue()
        {
            return CancelEditElementValue();
        }

        void IAxWriterControlForPB.ClearContent()
        {
            ClearContent();
        }

        void IAxWriterControlForPB.ClearContextMenuItem()
        {
            ClearContextMenuItem();
        }

        void IAxWriterControlForPB.ClearEventMessage()
        {
            ClearEventMessage();
        }

        void IAxWriterControlForPB.ClearUndo()
        {
            ClearUndo();
        }

        object IAxWriterControlForPB.ComCallInstanceMethodByName(object param0, string param1, string param2)
        {
            return ComCallInstanceMethodByName(param0, param1, param2);
        }

        object IAxWriterControlForPB.ComCallMethodByName(string param0, string param1)
        {
            return ComCallMethodByName(param0, param1);
        }

        bool IAxWriterControlForPB.ComFocus()
        {
            return ComFocus();
        }

        object IAxWriterControlForPB.ComGetProperty(string param0)
        {
            return ComGetProperty(param0);
        }

        void IAxWriterControlForPB.ComInvalidate()
        {
            ComInvalidate();
        }

        bool IAxWriterControlForPB.CommitContentUserTrace(XTextContainerElement param0)
        {
            return CommitContentUserTrace(param0);
        }

        bool IAxWriterControlForPB.CommitContentUserTraceById(string param0)
        {
            return CommitContentUserTraceById(param0);
        }

        bool IAxWriterControlForPB.CommitDocumentUserTrace()
        {
            return CommitDocumentUserTrace();
        }

        void IAxWriterControlForPB.ComSelect()
        {
            ComSelect();
        }

        bool IAxWriterControlForPB.ComSetProperty(string param0, string param1)
        {
            return ComSetProperty(param0, param1);
        }

        XTextDocument IAxWriterControlForPB.CreateDocumentFromClipboard()
        {
            return CreateDocumentFromClipboard();
        }

        object IAxWriterControlForPB.CreateInstanceByTypeName(string param0)
        {
            return CreateInstanceByTypeName(param0);
        }

        void IAxWriterControlForPB.DelayFocus(int param0)
        {
            DelayFocus(param0);
        }

        ValueValidateResultList IAxWriterControlForPB.DocumentValueValidate()
        {
            return DocumentValueValidate();
        }

        string IAxWriterControlForPB.DocumentValueValidateXML()
        {
            return DocumentValueValidateXML();
        }

        bool IAxWriterControlForPB.EditLabelPageText(XTextLabelElement param0)
        {
            return EditLabelPageText(param0);
        }

        void IAxWriterControlForPB.EndUpdate()
        {
            EndUpdate();
        }

        object IAxWriterControlForPB.ExecuteCommand(string param0, bool param1, object param2)
        {
            return ExecuteCommand(param0, param1, param2);
        }

        object IAxWriterControlForPB.ExecuteStringCommand(string param0)
        {
            return ExecuteStringCommand(param0);
        }

        bool IAxWriterControlForPB.FocusElementById(string param0)
        {
            return FocusElementById(param0);
        }

        void IAxWriterControlForPB.GCCollect()
        {
            GCCollect();
        }

        string IAxWriterControlForPB.GetBindingDataSources()
        {
            return GetBindingDataSources();
        }

        string IAxWriterControlForPB.GetCheckedValueList(string param0, bool param1, bool param2, bool param3, bool param4)
        {
            return GetCheckedValueList(param0, param1, param2, param3, param4);
        }

        string IAxWriterControlForPB.GetCommandNameList()
        {
            return GetCommandNameList();
        }

        XTextElement IAxWriterControlForPB.GetCurrentElementByTypeName(string param0)
        {
            return GetCurrentElementByTypeName(param0);
        }

        string IAxWriterControlForPB.GetCustomAttribute(string param0)
        {
            return GetCustomAttribute(param0);
        }

        DataSourceBindingDescriptionList IAxWriterControlForPB.GetDataSourceBindingDescriptions()
        {
            return GetDataSourceBindingDescriptions();
        }

        string IAxWriterControlForPB.GetDataSourceBindingDescriptionsXML()
        {
            return GetDataSourceBindingDescriptionsXML();
        }

        bool IAxWriterControlForPB.GetDocumentParameterEnabled(string param0)
        {
            return GetDocumentParameterEnabled(param0);
        }

        string IAxWriterControlForPB.GetDocumentParameterValueXml(string param0)
        {
            return GetDocumentParameterValueXml(param0);
        }

        object IAxWriterControlForPB.GetDocumnetParameterValue(string param0)
        {
            return GetDocumnetParameterValue(param0);
        }

        string IAxWriterControlForPB.GetElementAttribute(string param0, string param1)
        {
            return GetElementAttribute(param0, param1);
        }

        XTextElement IAxWriterControlForPB.GetElementById(string param0)
        {
            return GetElementById(param0);
        }

        XTextElement IAxWriterControlForPB.GetElementByPosition(int param0, int param1)
        {
            return GetElementByPosition(param0, param1);
        }

        bool IAxWriterControlForPB.GetElementChecked(string param0)
        {
            return GetElementChecked(param0);
        }

        Rectangle IAxWriterControlForPB.GetElementClientBounds(XTextElement param0)
        {
            return GetElementClientBounds(param0);
        }

        string IAxWriterControlForPB.GetElementProperty(string param0, string param1)
        {
            return GetElementProperty(param0, param1);
        }

        XTextElementList IAxWriterControlForPB.GetElementsById(string param0)
        {
            return GetElementsById(param0);
        }

        XTextElementList IAxWriterControlForPB.GetElementsByName(string param0)
        {
            return GetElementsByName(param0);
        }

        XTextElementList IAxWriterControlForPB.GetElementsByTypeName(string param0)
        {
            return GetElementsByTypeName(param0);
        }

        string IAxWriterControlForPB.GetElementText(string param0)
        {
            return GetElementText(param0);
        }

        string IAxWriterControlForPB.GetElementTextByID(string param0)
        {
            return GetElementTextByID(param0);
        }

        bool IAxWriterControlForPB.GetElementVisible(string param0)
        {
            return GetElementVisible(param0);
        }

        WriterControlEventMessage IAxWriterControlForPB.GetEventMessage()
        {
            return GetEventMessage();
        }

        XTextElement IAxWriterControlForPB.GetFirstElementByTypeName(string param0)
        {
            return GetFirstElementByTypeName(param0);
        }

        XTextInputFieldElement IAxWriterControlForPB.GetInputFieldElementById(string param0)
        {
            return GetInputFieldElementById(param0);
        }

        string IAxWriterControlForPB.GetLastEventNames()
        {
            return GetLastEventNames();
        }

        string IAxWriterControlForPB.GetNavigateNodesString()
        {
            return GetNavigateNodesString();
        }

        string IAxWriterControlForPB.GetNavigateNodesXMLString()
        {
            return GetNavigateNodesXMLString();
        }

        XTextElement IAxWriterControlForPB.GetNextElementByTypeName(XTextElement param0, string param1)
        {
            return GetNextElementByTypeName(param0, param1);
        }

        DateTime IAxWriterControlForPB.GetNowDateTime()
        {
            return GetNowDateTime();
        }

        string IAxWriterControlForPB.GetOptionValue(string param0)
        {
            return GetOptionValue(param0);
        }

        XTextElementList IAxWriterControlForPB.GetSpecifyElementsByTypeName(string param0)
        {
            return GetSpecifyElementsByTypeName(param0);
        }

        XTextTableCellElement IAxWriterControlForPB.GetTableCell(string param0, int param1, int param2)
        {
            return GetTableCell(param0, param1, param2);
        }

        XTextTableElement IAxWriterControlForPB.GetTableElementById(string param0)
        {
            return GetTableElementById(param0);
        }

        bool IAxWriterControlForPB.HandleBackspace()
        {
            return HandleBackspace();
        }

        void IAxWriterControlForPB.InsertSubDocuentAtCurrentPosition(XTextSubDocumentElement param0, bool param1)
        {
            InsertSubDocuentAtCurrentPosition(param0, param1);
        }

        bool IAxWriterControlForPB.IsCommandChecked(string param0)
        {
            return IsCommandChecked(param0);
        }

        bool IAxWriterControlForPB.IsCommandEnabled(string param0)
        {
            return IsCommandEnabled(param0);
        }

        bool IAxWriterControlForPB.IsCommandSupported(string param0)
        {
            return IsCommandSupported(param0);
        }

        bool IAxWriterControlForPB.LoadDocumentFromBase64String(string param0, string param1)
        {
            return LoadDocumentFromBase64String(param0, param1);
        }

        bool IAxWriterControlForPB.LoadDocumentFromBinary(byte[] param0, string param1)
        {
            return LoadDocumentFromBinary(param0, param1);
        }

        bool IAxWriterControlForPB.LoadDocumentFromFile(string param0, string param1)
        {
            return LoadDocumentFromFile(param0, param1);
        }

        bool IAxWriterControlForPB.LoadDocumentFromString(string param0, string param1)
        {
            return LoadDocumentFromString(param0, param1);
        }

        bool IAxWriterControlForPB.LockContentByElement(XTextContainerElement param0, string param1, string param2, bool param3)
        {
            return LockContentByElement(param0, param1, param2, param3);
        }

        bool IAxWriterControlForPB.LockContentByElementID(string param0, string param1, string param2, bool param3)
        {
            return LockContentByElementID(param0, param1, param2, param3);
        }

        bool IAxWriterControlForPB.LockContentByTableRow(string param0, int param1, string param2, string param3, bool param4)
        {
            return LockContentByTableRow(param0, param1, param2, param3, param4);
        }

        void IAxWriterControlForPB.MoveDownOneLine()
        {
            MoveDownOneLine();
        }

        void IAxWriterControlForPB.MoveEnd()
        {
            MoveEnd();
        }

        void IAxWriterControlForPB.MoveHome()
        {
            MoveHome();
        }

        void IAxWriterControlForPB.MoveLeft()
        {
            MoveLeft();
        }

        void IAxWriterControlForPB.MoveRight()
        {
            MoveRight();
        }

        void IAxWriterControlForPB.MoveTo(MoveTarget param0)
        {
            MoveTo(param0);
        }

        bool IAxWriterControlForPB.MoveToClientPosition(int param0, int param1)
        {
            return MoveToClientPosition(param0, param1);
        }

        bool IAxWriterControlForPB.MoveToPage(int param0)
        {
            return MoveToPage(param0);
        }

        void IAxWriterControlForPB.MoveToPosition(int param0)
        {
            MoveToPosition(param0);
        }

        void IAxWriterControlForPB.MoveUpOneLine()
        {
            MoveUpOneLine();
        }

        bool IAxWriterControlForPB.Navigate(NavigateNode param0)
        {
            return Navigate(param0);
        }

        bool IAxWriterControlForPB.NavigateByNodeID(string param0)
        {
            return NavigateByNodeID(param0);
        }

        bool IAxWriterControlForPB.NavigateByUserTrackInfo(UserTrackInfo param0)
        {
            return NavigateByUserTrackInfo(param0);
        }

        void IAxWriterControlForPB.PreloadSystem()
        {
            PreloadSystem();
        }

        void IAxWriterControlForPB.PrintDocumentExt(bool param0, string param1)
        {
            PrintDocumentExt(param0, param1);
        }

        void IAxWriterControlForPB.RaiseElementContentChangedEvent(XTextElement param0)
        {
            RaiseElementContentChangedEvent(param0);
        }

        void IAxWriterControlForPB.RedrawDocument()
        {
            RedrawDocument();
        }

        void IAxWriterControlForPB.RefreshDocument()
        {
            RefreshDocument();
        }

        void IAxWriterControlForPB.RefreshDocumentLayout()
        {
            RefreshDocumentLayout();
        }

        void IAxWriterControlForPB.RefreshInnerView(bool param0)
        {
            RefreshInnerView(param0);
        }

        bool IAxWriterControlForPB.RejectUserTrace()
        {
            return RejectUserTrace();
        }

        void IAxWriterControlForPB.RemoveContextMenuItemByTypeName(string param0, string param1)
        {
            RemoveContextMenuItemByTypeName(param0, param1);
        }

        void IAxWriterControlForPB.ResetAutoSaveTask()
        {
            ResetAutoSaveTask();
        }

        bool IAxWriterControlForPB.ResetFormValue()
        {
            return ResetFormValue();
        }

        void IAxWriterControlForPB.ResetOutlineNodes()
        {
            ResetOutlineNodes();
        }

        string IAxWriterControlForPB.SaveDocumentToBase64String(string param0)
        {
            return SaveDocumentToBase64String(param0);
        }

        bool IAxWriterControlForPB.SaveDocumentToFile(string param0, string param1)
        {
            return SaveDocumentToFile(param0, param1);
        }

        string IAxWriterControlForPB.SaveDocumentToString(string param0)
        {
            return SaveDocumentToString(param0);
        }

        void IAxWriterControlForPB.SaveLongImageFile(string param0)
        {
            SaveLongImageFile(param0);
        }

        void IAxWriterControlForPB.SaveLongImageFileZoom(string param0, float param1)
        {
            SaveLongImageFileZoom(param0, param1);
        }

        string IAxWriterControlForPB.SaveLongImageToBase64String(string param0)
        {
            return SaveLongImageToBase64String(param0);
        }

        string IAxWriterControlForPB.SaveLongImageToBase64StringZoom(string param0, float param1)
        {
            return SaveLongImageToBase64StringZoom(param0, param1);
        }

        void IAxWriterControlForPB.SavePageImageFile(int param0, string param1)
        {
            SavePageImageFile(param0, param1);
        }

        void IAxWriterControlForPB.SavePageImageFileZoom(int param0, string param1, float param2)
        {
            SavePageImageFileZoom(param0, param1, param2);
        }

        string IAxWriterControlForPB.SavePageImageToBase64String(int param0, string param1)
        {
            return SavePageImageToBase64String(param0, param1);
        }

        string IAxWriterControlForPB.SavePageImageToBase64StringZoom(int param0, string param1, float param2)
        {
            return SavePageImageToBase64StringZoom(param0, param1, param2);
        }

        void IAxWriterControlForPB.ScrollToCaret()
        {
            ScrollToCaret();
        }

        void IAxWriterControlForPB.ScrollToCaretExt(ScrollToViewStyle param0)
        {
            ScrollToCaretExt(param0);
        }

        void IAxWriterControlForPB.ScrollToViewPosition(float param0)
        {
            ScrollToViewPosition(param0);
        }

        void IAxWriterControlForPB.SelectAll()
        {
            SelectAll();
        }

        bool IAxWriterControlForPB.SelectElementById(string param0)
        {
            return SelectElementById(param0);
        }

        bool IAxWriterControlForPB.SetCommandEnabled(string param0, bool param1)
        {
            return SetCommandEnabled(param0, param1);
        }

        bool IAxWriterControlForPB.SetCommandEnableHotKey(string param0, bool param1)
        {
            return SetCommandEnableHotKey(param0, param1);
        }

        bool IAxWriterControlForPB.SetCommandEnableLowLevel(string param0, bool param1)
        {
            return SetCommandEnableLowLevel(param0, param1);
        }

        void IAxWriterControlForPB.SetCustomAttribute(string param0, string param1)
        {
            SetCustomAttribute(param0, param1);
        }

        void IAxWriterControlForPB.SetDocumentParameterEnabled(string param0, bool param1)
        {
            SetDocumentParameterEnabled(param0, param1);
        }

        void IAxWriterControlForPB.SetDocumentParameterValue(string param0, object param1)
        {
            SetDocumentParameterValue(param0, param1);
        }

        void IAxWriterControlForPB.SetDocumentParameterValueXml(string param0, string param1)
        {
            SetDocumentParameterValueXml(param0, param1);
        }

        void IAxWriterControlForPB.SetDomImageByBase64String(DCStdImageKey param0, string param1)
        {
            SetDomImageByBase64String(param0, param1);
        }

        void IAxWriterControlForPB.SetDomImageByFileName(DCStdImageKey param0, string param1)
        {
            SetDomImageByFileName(param0, param1);
        }

        bool IAxWriterControlForPB.SetElementAttribute(string param0, string param1, string param2)
        {
            return SetElementAttribute(param0, param1, param2);
        }

        bool IAxWriterControlForPB.SetElementChecked(string param0, bool param1)
        {
            return SetElementChecked(param0, param1);
        }

        bool IAxWriterControlForPB.SetElementProperty(string param0, string param1, string param2)
        {
            return SetElementProperty(param0, param1, param2);
        }

        bool IAxWriterControlForPB.SetElementText(string param0, string param1)
        {
            return SetElementText(param0, param1);
        }

        bool IAxWriterControlForPB.SetElementTextByID(string param0, string param1)
        {
            return SetElementTextByID(param0, param1);
        }

        bool IAxWriterControlForPB.SetElementVisible(string param0, bool param1)
        {
            return SetElementVisible(param0, param1);
        }

        bool IAxWriterControlForPB.SetInputFieldInnerValue(string param0, string param1)
        {
            return SetInputFieldInnerValue(param0, param1);
        }

        bool IAxWriterControlForPB.SetNativeHostedControlHandle(string param0, IntPtr param1)
        {
            return SetNativeHostedControlHandle(param0, param1);
        }

        bool IAxWriterControlForPB.SetOptionValue(string param0, string param1)
        {
            return SetOptionValue(param0, param1);
        }

        void IAxWriterControlForPB.SetRegisterCode(string param0)
        {
            SetRegisterCode(param0);
        }

        void IAxWriterControlForPB.SetResourceStringValue(string param0, string param1)
        {
            SetResourceStringValue(param0, param1);
        }

        void IAxWriterControlForPB.SetToMSWordVisualStyle()
        {
            SetToMSWordVisualStyle();
        }

        void IAxWriterControlForPB.ShowAboutDialog()
        {
            ShowAboutDialog();
        }

        bool IAxWriterControlForPB.StartLocalAutoSave()
        {
            return StartLocalAutoSave();
        }

        void IAxWriterControlForPB.SynchroServerTime(DateTime param0)
        {
            SynchroServerTime(param0);
        }

        void IAxWriterControlForPB.SynchroServerTimeByParameters(int param0, int param1, int param2, int param3, int param4, int param5)
        {
            SynchroServerTimeByParameters(param0, param1, param2, param3, param4, param5);
        }

        int IAxWriterControlForPB.UpdateDataSourceForView()
        {
            return UpdateDataSourceForView();
        }

        void IAxWriterControlForPB.UpdateTextCaret()
        {
            UpdateTextCaret();
        }

        void IAxWriterControlForPB.UpdateTextCaretByElement(XTextElement param0)
        {
            UpdateTextCaretByElement(param0);
        }

        void IAxWriterControlForPB.UpdateTextCaretWithoutScroll()
        {
            UpdateTextCaretWithoutScroll();
        }

        void IAxWriterControlForPB.UpdateUserInfoSaveTime()
        {
            UpdateUserInfoSaveTime();
        }

        void IAxWriterControlForPB.UpdateUserInfoSaveTimeExt(bool param0)
        {
            UpdateUserInfoSaveTimeExt(param0);
        }

        int IAxWriterControlForPB.UpdateViewForDataSource()
        {
            return UpdateViewForDataSource();
        }

        bool IAxWriterControlForPB.UserLoginByCurrentUserInfo()
        {
            return UserLoginByCurrentUserInfo();
        }

        bool IAxWriterControlForPB.UserLoginByParameter(string param0, string param1, int param2)
        {
            return UserLoginByParameter(param0, param1, param2);
        }

        bool IAxWriterControlForPB.UserLoginByUserLoginInfo(UserLoginInfo param0, bool param1)
        {
            return UserLoginByUserLoginInfo(param0, param1);
        }

        bool IAxWriterControlForPB.Win32SetFoucs()
        {
            return Win32SetFoucs();
        }

        int IAxWriterControlForPB.WriteDataFromDataSourceToDocument()
        {
            return WriteDataFromDataSourceToDocument();
        }

        int IAxWriterControlForPB.WriteDataFromDataSourceToDocumentSpecifyParameterNames(string param0)
        {
            return WriteDataFromDataSourceToDocumentSpecifyParameterNames(param0);
        }

        int IAxWriterControlForPB.WriteDataFromDocumentToDataSource()
        {
            return WriteDataFromDocumentToDataSource();
        }

        int IAxWriterControlForPB.WriteDataSource()
        {
            return WriteDataSource();
        }
    }
}

#define DEBUG
using AxNsoOfficeLib;
using DCSoft.Common;
using DCSoft.Design.Web;
using DCSoft.HtmlDom;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       在WEB页面中显示文档内容的WEB控件
	///       </summary>
	[ControlBuilder(typeof(WebWriterControlBuilder))]
	[ComVisible(false)]
	[DocumentComment]
	[ToolboxBitmap(typeof(WriterControl))]
	[Designer(typeof(WebWriterControlDesigner))]
	[DCPublishAPI]
	public sealed class WebWriterControl : WebControl
	{
		/// <summary>
		///       读取文件内容事件
		///       </summary>
		public WriterReadFileContentEventHandler EventReadFileContent = null;

		/// <summary>
		///       保存文件内容事件
		///       </summary>
		public WriterSaveFileContentEventHandler EventSaveFileContent = null;

		/// <summary>
		///       保存文档中被选中内容事件
		///       </summary>
		public WriterSaveFileContentEventHandler EventSaveSelectionContent = null;

		/// <summary>
		///       查询下拉列表项目事件
		///       </summary>
		[Description("查询下拉列表项目事件")]
		public QueryListItemsEventHandler EventQueryListItems = null;

		/// <summary>
		///       用户界面层的开始编辑文档内容事件
		///       </summary>
		[Description("开始编辑文档内容事件")]
		public WriterStartEditEventHandler EventUIStartEditContent = null;

		private static byte[] byte_0 = null;

		private static string string_0 = null;

		private static int int_0 = 0;

		private static int int_1 = 0;

		private int int_2 = int_1++;

		private int int_3 = -1;

		private WriterControlOptions writerControlOptions_0 = new WriterControlOptions();

		private DocumentOptions documentOptions_0 = new DocumentOptions();

		private XTextDocumentList xtextDocumentList_0 = null;

		private static string string_1 = null;

		private static int int_4 = 0;

		private static bool bool_0 = false;

		private static string string_2 = null;

		private bool bool_1 = true;

		private static int int_5 = Class65.int_0;

		private bool bool_2 = true;

		private static Bitmap bitmap_0 = null;

		private static int int_6 = 0;

		private string ServerEventNameList
		{
			get
			{
				int num = 14;
				StringBuilder stringBuilder = new StringBuilder();
				if (EventQueryListItems != null)
				{
					stringBuilder.Append("EventQueryListItems,");
				}
				if (EventUIStartEditContent != null)
				{
					stringBuilder.Append("EventUIStartEditContent,");
				}
				if (EventReadFileContent != null)
				{
					stringBuilder.Append("EventReadFileContent,");
				}
				if (EventSaveFileContent != null)
				{
					stringBuilder.AppendLine("EventSaveFileContent,");
				}
				if (EventSaveSelectionContent != null)
				{
					stringBuilder.AppendLine("EventSaveSelectionContent");
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       默认版本号
		///       </summary>
		internal static string DefaultVersion
		{
			get
			{
				Version version = typeof(WebWriterControl).Assembly.GetName().Version;
				return version.ToString();
			}
		}

		/// <summary>
		///       打印时使用的内容缩放比率
		///       </summary>
		[DefaultValue(false)]
		public bool ImageDataEmbedInHtml
		{
			get
			{
				return (bool)method_0("ImageDataEmbedInHtml", false);
			}
			set
			{
				ViewState["ImageDataEmbedInHtml"] = value;
			}
		}

		/// <summary>
		///       打印时使用的内容缩放比率
		///       </summary>
		[DefaultValue(1f)]
		public float PrintZoomRate
		{
			get
			{
				return (float)method_0("PrintZoomRate", 1f);
			}
			set
			{
				ViewState["PrintZoomRate"] = value;
			}
		}

		/// <summary>
		///       使用图片模式时的缩放视图
		///       </summary>
		[DefaultValue(1f)]
		[Category("Appearance")]
		public float PageZoomRate
		{
			get
			{
				return (float)method_0("PageZoomRate", 1f);
			}
			set
			{
				ViewState["PageZoomRate"] = value;
			}
		}

		/// <summary>
		///       自由选择内容模式
		///       </summary>
		[DefaultValue(true)]
		public bool AllowCopy
		{
			get
			{
				return (bool)method_0("AllowCopy", true);
			}
			set
			{
				ViewState["AllowCopy"] = value;
			}
		}

		/// <summary>
		///       自由选择内容模式
		///       </summary>
		[DefaultValue(false)]
		public bool FreeSelection
		{
			get
			{
				return (bool)method_0("FreeSelection", false);
			}
			set
			{
				ViewState["FreeSelection"] = value;
			}
		}

		/// <summary>
		///       背景文字输出模式
		///       </summary>
		[DefaultValue(DCBackgroundTextOutputMode.Output)]
		public DCBackgroundTextOutputMode BackgroundTextOutputMode
		{
			get
			{
				return (DCBackgroundTextOutputMode)method_0("BackgroundTextOutputMode", DCBackgroundTextOutputMode.Output);
			}
			set
			{
				ViewState["BackgroundTextOutputMode"] = value;
			}
		}

		/// <summary>
		///       固定页眉页脚
		///       </summary>
		[DefaultValue(false)]
		public bool FixedHeader
		{
			get
			{
				return (bool)method_0("FixedHeader", false);
			}
			set
			{
				ViewState["FixedHeader"] = value;
			}
		}

		/// <summary>
		///       序列化参数值
		///       </summary>
		[DefaultValue(true)]
		public bool SerializeParameterValue
		{
			get
			{
				return (bool)method_0("SerializeParameterValue", true);
			}
			set
			{
				ViewState["SerializeParameterValue"] = value;
			}
		}

		/// <summary>
		///       缓存报表文档使用的名称
		///       </summary>
		[Category("Data")]
		[DefaultValue("DCWriterDocument")]
		public string DocumentBufferedName
		{
			get
			{
				int num = 1;
				string text = (string)ViewState["DocumentBufferedName"];
				if (string.IsNullOrEmpty(text))
				{
					text = "DCWriterDocument";
				}
				return text;
			}
			set
			{
				ViewState["DocumentBufferedName"] = value;
			}
		}

		private string RuntimeDocumentBufferedName
		{
			get
			{
				int num = 5;
				if (string.IsNullOrEmpty(DocumentBufferedName))
				{
					return "DCWriterDocument";
				}
				return DocumentBufferedName;
			}
		}

		/// <summary>
		///       允许接受拖拽的数据
		///       </summary>
		[DefaultValue(true)]
		public bool AllowDrop
		{
			get
			{
				return (bool)method_0("AllowDrop", true);
			}
			set
			{
				ViewState["AllowDrop"] = value;
			}
		}

		/// <summary>
		///       启用多文档模式时是否显示主文档正文内容
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool ShowMainDocumentBodyWhenMultiDocument
		{
			get
			{
				return (bool)method_0("ShowMainDocumentBodyWhenMultiDocument", true);
			}
			set
			{
				ViewState["ShowMainDocumentBodyWhenMultiDocument"] = value;
			}
		}

		/// <summary>
		///       启用多文档模式
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool MultiDocument
		{
			get
			{
				return (bool)method_0("MultiDocument", false);
			}
			set
			{
				ViewState["MultiDocument"] = value;
			}
		}

		/// <summary>
		///       当前文档编号
		///       </summary>
		[Browsable(false)]
		public int CurrentDocumentIndex
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		/// <summary>
		///       压缩服务器端回话数据
		///       </summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool CompressSessionData
		{
			get
			{
				return (bool)method_0("CompressSessionData", true);
			}
			set
			{
				ViewState["CompressSessionData"] = value;
			}
		}

		/// <summary>
		///       违禁关键字
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public string ExcludeKeywords
		{
			get
			{
				return (string)method_0("ExcludeKeywords", null);
			}
			set
			{
				ViewState["ExcludeKeywords"] = value;
			}
		}

		/// <summary>
		///       工作区域背景色
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public string InsertImageButtonID
		{
			get
			{
				return (string)method_0("InsertImageButtonID", null);
			}
			set
			{
				ViewState["InsertImageButtonID"] = value;
			}
		}

		/// <summary>
		///       在移动设备中自适应高度
		///       </summary>
		[DefaultValue(true)]
		public bool AutoHeightInMobileDevice
		{
			get
			{
				return (bool)method_0("AutoHeightInMobileDevice", true);
			}
			set
			{
				ViewState["AutoHeightInMobileDevice"] = value;
			}
		}

		/// <summary>
		///       是否为移动设备
		///       </summary>
		[DefaultValue(DCOptionMode.AutoDetect)]
		public DCOptionMode IsMobileDevice
		{
			get
			{
				return (DCOptionMode)method_0("IsMobileDevice", DCOptionMode.AutoDetect);
			}
			set
			{
				ViewState["IsMobileDevice"] = value;
			}
		}

		/// <summary>
		///       是否运行在移动设备
		///       </summary>
		[Browsable(false)]
		private bool RuntimeIsMobileDevice
		{
			get
			{
				int num = 14;
				if (IsMobileDevice == DCOptionMode.True)
				{
					return true;
				}
				if (IsMobileDevice == DCOptionMode.False)
				{
					return false;
				}
				if (Page.Request.Browser.IsMobileDevice)
				{
					return true;
				}
				string userAgent = Page.Request.UserAgent;
				if (userAgent != null)
				{
					if (userAgent.IndexOf("android", StringComparison.CurrentCultureIgnoreCase) >= 0)
					{
						return true;
					}
					if (userAgent.IndexOf("ipad;", StringComparison.CurrentCultureIgnoreCase) >= 0)
					{
						return true;
					}
					if (userAgent.IndexOf("mobile/", StringComparison.CurrentCultureIgnoreCase) >= 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否允许客户端弹出快捷菜单
		///       </summary>
		[DefaultValue(true)]
		public bool EnabledClientContextMenu
		{
			get
			{
				return (bool)method_0("EnabledClientContextMenu", true);
			}
			set
			{
				ViewState["EnabledClientContextMenu"] = value;
			}
		}

		/// <summary>
		///       工作区域背景色
		///       </summary>
		[Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string WorkspaceBackgroundImage
		{
			get
			{
				return (string)method_0("WorkspaceBackgroundImage", null);
			}
			set
			{
				ViewState["WorkspaceBackgroundImage"] = value;
			}
		}

		/// <summary>
		///       工作区域背景色
		///       </summary>
		[TypeConverter(typeof(WebColorConverter))]
		[DefaultValue(typeof(Color), "")]
		public Color WorkspaceBackColor
		{
			get
			{
				return (Color)method_0("WorkspaceBackColor", SystemColors.AppWorkspace);
			}
			set
			{
				ViewState["WorkspaceBackColor"] = value;
			}
		}

		/// <summary>
		///       工作区域背景色
		///       </summary>
		[DefaultValue(typeof(Color), "white")]
		[TypeConverter(typeof(WebColorConverter))]
		public Color PageBackColor
		{
			get
			{
				return (Color)method_0("PageBackColor", Color.White);
			}
			set
			{
				ViewState["PageBackColor"] = value;
			}
		}

		/// <summary>
		///       PageImage模式下的最大页数。如果为0则表示无限制，如果大于0则表示已PageImage模式下显示的总页数不会超过最大页数。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		public int MaxPageCount
		{
			get
			{
				return (int)method_0("MaxPageCount", 0);
			}
			set
			{
				ViewState["MaxPageCount"] = value;
			}
		}

		/// <summary>
		///       客户端控件选项
		///       </summary>
		[Browsable(false)]
		public WriterControlOptions ControlOptions
		{
			get
			{
				return writerControlOptions_0;
			}
			set
			{
				writerControlOptions_0 = value;
			}
		}

		/// <summary>
		///       文档选项
		///       </summary>
		[Browsable(false)]
		public DocumentOptions DocumentOptions
		{
			get
			{
				return documentOptions_0;
			}
			set
			{
				documentOptions_0 = value;
			}
		}

		/// <summary>
		///       获取或设置一个值，该值指示打印文档是否逐份打印。默认为 false。
		///       </summary>
		[Category("Print")]
		[DefaultValue(false)]
		public bool PrintCollate
		{
			get
			{
				return (bool)method_0("PrintCollate", false);
			}
			set
			{
				ViewState["PrintCollate"] = value;
			}
		}

		/// <summary>
		///       打印份数
		///       </summary>
		[DefaultValue(1)]
		[Category("Print")]
		public int PrintCopies
		{
			get
			{
				return (int)method_0("PrintCopies", 1);
			}
			set
			{
				ViewState["PrintCopies"] = value;
			}
		}

		/// <summary>
		///       打印模式
		///       </summary>
		[Category("Print")]
		[DefaultValue(DCPrintMode.Normal)]
		public DCPrintMode PrintMode
		{
			get
			{
				return (DCPrintMode)method_0("PrintMode", DCPrintMode.Normal);
			}
			set
			{
				ViewState["PrintMode"] = value;
			}
		}

		/// <summary>
		///       打印时指定输出的页码列表，页码从0开始计算，各个页码之间用逗号分开。
		///       </summary>
		[Category("Print")]
		[DefaultValue(null)]
		public string PrintSpecifyPageIndexsString
		{
			get
			{
				return (string)method_0("PrintSpecifyPageIndexsString", null);
			}
			set
			{
				ViewState["PrintSpecifyPageIndexsString"] = value;
			}
		}

		/// <summary>
		///       是否生成HTML表单元素
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool GenerateFormElement
		{
			get
			{
				return (bool)method_0("GenerateFormElement", false);
			}
			set
			{
				ViewState["GenerateFormElement"] = value;
			}
		}

		/// <summary>
		///       自动缩放视图
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool AutoZoom
		{
			get
			{
				return (bool)method_0("AutoZoom", false);
			}
			set
			{
				ViewState["AutoZoom"] = value;
			}
		}

		/// <summary>
		///       运行时的页面窄边框
		///       </summary>
		private bool RuntimeAutoZoom => AutoZoom;

		/// <summary>
		///       页面窄边框
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool NarrowBorder
		{
			get
			{
				return (bool)method_0("NarrowBorder", false);
			}
			set
			{
				ViewState["NarrowBorder"] = value;
			}
		}

		/// <summary>
		///       运行时的页面窄边框
		///       </summary>
		private bool RuntimeNarrowBorder
		{
			get
			{
				if (RuntimeIsMobileDevice)
				{
					return true;
				}
				return NarrowBorder;
			}
		}

		/// <summary>
		///       自动创建CAB文件,此时CABUrl和CABVersion属性无效。
		///       </summary>
		[DefaultValue(true)]
		public bool AutoGenerateCABFile
		{
			get
			{
				return (bool)method_0("AutoGenerateCABFile", true);
			}
			set
			{
				ViewState["AutoGenerateCABFile"] = value;
			}
		}

		/// <summary>
		///       运行时使用的自动创建CAB文件。
		///       </summary>
		private bool RuntimeAutoGenerateCABFile
		{
			get
			{
				if (AutoGenerateCABFile && typeof(XTextDocument).Assembly == typeof(WebWriterControl).Assembly)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       Web服务页面地址
		///       </summary>
		[Category("Data")]
		[ComVisible(true)]
		[Editor(typeof(ASMXUrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string WriterControlWebServiceUrl
		{
			get
			{
				return (string)method_0("WriterControlWebServiceUrl", null);
			}
			set
			{
				ViewState["WriterControlWebServiceUrl"] = value;
			}
		}

		/// <summary>
		///       实际使用的服务页面地址
		///       </summary>
		[Browsable(false)]
		private string RuntimeWriterControlWebServiceUrl => method_1(WriterControlWebServiceUrl);

		/// <summary>
		///       自动回发数据
		///       </summary>
		/// <remarks>
		///       当控件的ContentRenderMode为ActiveXControl或NormalHtmlEditable模式时该属性才有效。
		///       当该属性值为true时，当页面回发时也会回发客户端控件处的文档内容，控件内部自动加载回发的文档数据，生成
		///       新的文档，此时控件的Document对象就是当前编辑后的文档内容。
		///       </remarks>
		[DefaultValue(true)]
		public bool AutoPostBack
		{
			get
			{
				return (bool)method_0("AutoPostBack", true);
			}
			set
			{
				ViewState["AutoPostBack"] = value;
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
				return (FunctionControlVisibility)method_0("CommentVisibility", FunctionControlVisibility.Auto);
			}
			set
			{
				ViewState["CommentVisibility"] = value;
			}
		}

		/// <summary>
		///       运行时是否显示文档批注
		///       </summary>
		[Browsable(false)]
		internal bool RuntimeCommentVisible
		{
			get
			{
				XTextDocument document = Document;
				if (document != null)
				{
					switch (CommentVisibility)
					{
					case FunctionControlVisibility.Auto:
						return document != null && document.Comments.Count > 0;
					case FunctionControlVisibility.Visible:
						return true;
					case FunctionControlVisibility.Hide:
						return false;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否启用授权控制
		///       </summary>
		[DefaultValue(false)]
		public bool EnablePermission
		{
			get
			{
				return (bool)method_0("EnablePermission", false);
			}
			set
			{
				ViewState["EnablePermission"] = value;
			}
		}

		/// <summary>
		///       CAB文件URL地址
		///       </summary>
		[Editor(typeof(UrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string CABUrl
		{
			get
			{
				return (string)method_0("CABUrl", null);
			}
			set
			{
				ViewState["CABUrl"] = value;
			}
		}

		/// <summary>
		///       CAB版本号
		///       </summary>
		[DefaultValue(null)]
		public string CABVersion
		{
			get
			{
				return (string)method_0("CABVersion", null);
			}
			set
			{
				ViewState["CABVersion"] = value;
			}
		}

		/// <summary>
		///       运行时客户端使用的CAB文件下载地址
		///       </summary>
		private string RuntimeCABUrl
		{
			get
			{
				int num = 5;
				string string_ = CABUrl;
				if (RuntimeAutoGenerateCABFile)
				{
					string_ = RuntimeServicePageURL + "?" + Class65.string_13 + "=" + Class65.string_6 + "&" + Class65.string_14 + "=" + Class65.string_9;
				}
				else if (!string.IsNullOrEmpty(CABUrl))
				{
					string_ = ResolveClientUrl(CABUrl);
				}
				return method_1(string_);
			}
		}

		/// <summary>
		///       运行时使用的CABCodeBase值
		///       </summary>
		private string RuntimeCABCodeBase
		{
			get
			{
				int num = 17;
				string runtimeCABUrl = RuntimeCABUrl;
				string text = CABVersion;
				if (string.IsNullOrEmpty(text))
				{
					text = typeof(WebWriterControl).Assembly.GetName().Version.ToString();
				}
				return runtimeCABUrl + "#" + text;
			}
		}

		/// <summary>
		///       运行时使用的CABCodeBase值
		///       </summary>
		private string RuntimeKBLibraryUrl => method_1(KBLibraryUrl);

		/// <summary>
		///       内容呈现方式
		///       </summary>
		[DefaultValue(WebWriterControlRenderMode.PageImage)]
		public WebWriterControlRenderMode ContentRenderMode
		{
			get
			{
				return (WebWriterControlRenderMode)method_0("ContentRenderMode", WebWriterControlRenderMode.PageImage);
			}
			set
			{
				ViewState["ContentRenderMode"] = value;
			}
		}

		/// <summary>
		///       控件是否只读
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool Readonly
		{
			get
			{
				return (bool)method_0("Readonly", false);
			}
			set
			{
				ViewState["Readonly"] = value;
			}
		}

		/// <summary>
		///       自动换行模式,默认为false。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AutoLine
		{
			get
			{
				return (bool)method_0("AutoLine", false);
			}
			set
			{
				ViewState["AutoLine"] = value;
			}
		}

		/// <summary>
		///       正文的最小像素高度
		///       </summary>
		[DefaultValue(0)]
		[Category("Behavior")]
		public int MinContentPixelHeight
		{
			get
			{
				return (int)method_0("MinContentPixelHeight", 0);
			}
			set
			{
				ViewState["MinContentPixelHeight"] = value;
			}
		}

		/// <summary>
		///       显示在已经注册的页码标题文本后面的额外的页码标题文本
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Browsable(false)]
		public string AdditionPageTitle
		{
			get
			{
				return (string)method_0("AdditionPageTitle", null);
			}
			set
			{
				ViewState["AdditionPageTitle"] = value;
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		public string RegisterCode
		{
			get
			{
				return null;
			}
			set
			{
				XTextDocument.StaticRegisterCode = value;
			}
		}

		/// <summary>
		///       是否显示表示页边距的灰色线段
		///       </summary>
		[DefaultValue(false)]
		[Category("Appearance")]
		public bool ShowMarginLine
		{
			get
			{
				return (bool)method_0("ShowMarginLine", false);
			}
			set
			{
				ViewState["ShowMarginLine"] = value;
			}
		}

		/// <summary>
		///       显示调试信息
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool ShowDebugInfo
		{
			get
			{
				return (bool)method_0("ShowDebugInfo", false);
			}
			set
			{
				ViewState["ShowDebugInfo"] = value;
			}
		}

		/// <summary>
		///       HTML代码文本是否缩进
		///       </summary>
		[DefaultValue(false)]
		public bool IndentHtmlCode
		{
			get
			{
				return (bool)method_0("IndentHtmlCode", false);
			}
			set
			{
				ViewState["IndentHtmlCode"] = value;
			}
		}

		/// <summary>
		///       是否使用纸张阴影效果
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool PageShadow
		{
			get
			{
				return (bool)method_0("PageShadow", false);
			}
			set
			{
				ViewState["PageShadow"] = value;
			}
		}

		/// <summary>
		///       控件要显示的报表文档对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextDocument Document
		{
			get
			{
				if (Documents == null)
				{
					return null;
				}
				return Documents.FirstDocument;
			}
			set
			{
				if (value != null)
				{
					bool_1 = false;
					Documents = new XTextDocumentList(value);
				}
				else
				{
					Documents = new XTextDocumentList();
				}
			}
		}

		/// <summary>
		///       控件要显示的报表文档对象列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextDocumentList Documents
		{
			get
			{
				if (xtextDocumentList_0 == null)
				{
					xtextDocumentList_0 = new XTextDocumentList();
				}
				return xtextDocumentList_0;
			}
			set
			{
				if (value != null && value.Count > 0)
				{
					bool_1 = false;
				}
				xtextDocumentList_0 = value;
			}
		}

		/// <summary>
		///       服务页面地址
		///       </summary>
		[DefaultValue(null)]
		[Editor(typeof(ASPXUrlEditor), typeof(UITypeEditor))]
		public string ServicePageURL
		{
			get
			{
				return (string)method_0("ServicePageURL", null);
			}
			set
			{
				ViewState["ServicePageURL"] = value;
			}
		}

		/// <summary>
		///       实际使用的服务页面地址
		///       </summary>
		[Browsable(false)]
		internal string RuntimeServicePageURL
		{
			get
			{
				if (string.IsNullOrEmpty(ServicePageURL))
				{
					return "";
				}
				return method_1(ServicePageURL);
			}
		}

		/// <summary>
		///       知识库URL路径
		///       </summary>
		[Editor(typeof(UrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string KBLibraryUrl
		{
			get
			{
				return (string)method_0("KBLibraryUrl", null);
			}
			set
			{
				ViewState["KBLibraryUrl"] = value;
			}
		}

		/// <summary>
		///       像素为单位的页面间距
		///       </summary>
		[DefaultValue(20)]
		public int PixelPageSpacing
		{
			get
			{
				return (int)method_0("PixelPageSpacing", 20);
			}
			set
			{
				ViewState["PixelPageSpacing"] = value;
			}
		}

		/// <summary>
		///       是否双倍压缩空格
		///       </summary>
		internal bool DoubleCompressWhitespace
		{
			get
			{
				int num = 4;
				if (BrowserStyle == XWebBrowsersStyle.Chrome)
				{
					string platform = Page.Request.Browser.Platform;
					if (platform != null)
					{
						platform = platform.Trim();
						if (platform.StartsWith("winnt", StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
						if (platform.StartsWith("windows", StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       客户端是否为旧的浏览器，此时部分功能不可用。
		///       </summary>
		private bool OldBrowser
		{
			get
			{
				XWebBrowsersStyle browserStyle = BrowserStyle;
				if ((browserStyle == XWebBrowsersStyle.InternetExplorer || browserStyle == XWebBrowsersStyle.InternetExplorer7 || browserStyle == XWebBrowsersStyle.InternetExplorer8) && Page.Request.Browser.MajorVersion < 9)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       浏览器类型
		///       </summary>
		internal XWebBrowsersStyle BrowserStyle
		{
			get
			{
				int num = 2;
				XWebBrowsersStyle xWebBrowsersStyle = XWebBrowsersStyle.Standard;
				string userAgent = Page.Request.UserAgent;
				if (string.IsNullOrEmpty(userAgent))
				{
					return XWebBrowsersStyle.InternetExplorer8;
				}
				if (userAgent.IndexOf("Trident/7.0;", StringComparison.CurrentCultureIgnoreCase) >= 0)
				{
					if (userAgent.IndexOf("MSIE 7.0", StringComparison.CurrentCultureIgnoreCase) >= 0)
					{
						return XWebBrowsersStyle.InternetExplorer7;
					}
					return XWebBrowsersStyle.InternetExplorer8;
				}
				HttpBrowserCapabilities browser = Page.Request.Browser;
				return (browser.Browser == "InternetExplorer" || (userAgent != null && userAgent.IndexOf("MSIE", StringComparison.CurrentCultureIgnoreCase) > -1)) ? ((browser.MajorVersion == 7) ? XWebBrowsersStyle.InternetExplorer7 : ((browser.MajorVersion <= 7) ? XWebBrowsersStyle.InternetExplorer : XWebBrowsersStyle.InternetExplorer8)) : ((browser.Browser.IndexOf("Firefox", StringComparison.CurrentCultureIgnoreCase) >= 0) ? XWebBrowsersStyle.FireFox : ((browser.Browser.IndexOf("Chrome", StringComparison.CurrentCultureIgnoreCase) >= 0) ? XWebBrowsersStyle.Chrome : ((browser.Browser.IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) >= 0) ? XWebBrowsersStyle.AppleMAC_Safari : ((userAgent.IndexOf("Trident/") <= 0) ? XWebBrowsersStyle.Standard : XWebBrowsersStyle.InternetExplorer))));
			}
		}

		private WebWriterControlLoadDocumentOptions CurrentLoadOptions
		{
			get
			{
				WebWriterControlLoadDocumentOptions webWriterControlLoadDocumentOptions = WebWriterControlLoadDocumentOptions.None;
				if (DoubleCompressWhitespace)
				{
					webWriterControlLoadDocumentOptions |= WebWriterControlLoadDocumentOptions.DoubleCompressWhitespace;
				}
				if (CompressSessionData)
				{
					webWriterControlLoadDocumentOptions |= WebWriterControlLoadDocumentOptions.CompressSessionData;
				}
				return webWriterControlLoadDocumentOptions;
			}
		}

		/// <summary>
		///       DCWriter内部使用。是否保存来自客户端返回的HTML代码，只用于内部调试功能。保存目录为控件所在ASPX页面的目录下的“DCSoft.Debug”子目录下。
		///       </summary>
		public static bool SaveRequestHtmlForDebug
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。保存着调试模式下的客户端HTML代码的文件名。
		///       </summary>
		public static string DebugFileNameSavedRequestHtml
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
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
				return (FormViewMode)method_0("FormView", FormViewMode.Disable);
			}
			set
			{
				ViewState["FormView"] = value;
			}
		}

		protected override HtmlTextWriterTag TagKey
		{
			get
			{
				if ((ContentRenderMode == WebWriterControlRenderMode.ActiveXControl || ContentRenderMode == WebWriterControlRenderMode.NsoControl || ContentRenderMode == WebWriterControlRenderMode.AxPrintPreviewControl) && !base.DesignMode)
				{
					return HtmlTextWriterTag.Object;
				}
				return HtmlTextWriterTag.Div;
			}
		}

		private bool InDesignMode
		{
			get
			{
				if (Page != null && Page.Site != null && Page.Site.DesignMode)
				{
					return true;
				}
				return false;
			}
		}

		private string HiddenInputName => ClientID + "_AxContentBase64String";

		/// <summary>
		///       是否具有dcwriter_mini.js文件
		///       </summary>
		private bool Hasdcwriter_mini_js => GetType().Assembly.GetManifestResourceInfo("DCSoft.Writer.Controls.Resources.dcwriter_mini.js") != null;

		/// <summary>
		///       应用程序标志图片位置
		///       </summary>
		[DefaultValue(null)]
		[Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
		public string CustomLogoImage
		{
			get
			{
				return ViewState["CustomLogoImage"] as string;
			}
			set
			{
				ViewState["CustomLogoImage"] = value;
			}
		}

		private Bitmap DCLogon64
		{
			get
			{
				if (bitmap_0 == null)
				{
					bitmap_0 = (Bitmap)WriterUtils.DCLogon64.Clone();
					bitmap_0.MakeTransparent(Color.Red);
				}
				return bitmap_0;
			}
		}

		/// <summary>
		///       保存文件
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		public bool SaveDocument(Stream stream, string format)
		{
			int num = 19;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			Document.Save(stream, format);
			return true;
		}

		/// <summary>
		///       保存文件
		///       </summary>
		/// <param name="fileName">本地文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		public bool SaveDocument(string fileName, string format)
		{
			int num = 11;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			Document.Save(fileName, format);
			return true;
		}

		/// <summary>
		///       从指定的文件地址中加载文档
		///       </summary>
		/// <param name="strUrl">文件地址</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		public bool LoadDocument(string strUrl, string format)
		{
			int num = 14;
			if (string.IsNullOrEmpty(strUrl))
			{
				throw new ArgumentNullException("strUrl");
			}
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			Document.Load(strUrl, format);
			Document.SerializeParameterValue = SerializeParameterValue;
			return true;
		}

		/// <summary>
		///       从指定的文件流中加载文档
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		public bool LoadDocument(Stream stream, string format)
		{
			int num = 3;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			bool_1 = false;
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			Document.Load(stream, format);
			Document.SerializeParameterValue = SerializeParameterValue;
			return true;
		}

		/// <summary>
		///       从指定的文本读取器中加载文档
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">文件格式</param>
		/// <returns>是佛加载成功</returns>
		public bool LoadDocument(TextReader reader, string format)
		{
			int num = 6;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			bool_1 = false;
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			Document.Load(reader, format);
			Document.SerializeParameterValue = SerializeParameterValue;
			return true;
		}

		/// <summary>
		///       从一个字符串中加载文档
		///       </summary>
		/// <param name="txt">字符串</param>
		/// <param name="format">文件格式</param>
		/// <returns>加载是否成功</returns>
		public bool LoadFromString(string string_3, string format)
		{
			int num = 15;
			if (string.IsNullOrEmpty(string_3))
			{
				throw new ArgumentException("txt");
			}
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			StringReader reader = new StringReader(string_3);
			Document.Load(reader, format);
			Document.SerializeParameterValue = SerializeParameterValue;
			return true;
		}

		/// <summary>
		///       内部的加载文档的方法
		///       </summary>
		/// <param name="txt">文本</param>
		/// <returns>操作是否成功</returns>
		[Obsolete("！！！！仅供内部使用。！！！")]
		public bool ___OpenDocumentWithString(string string_3)
		{
			int num = 6;
			if (string.IsNullOrEmpty(string_3))
			{
				throw new ArgumentException("txt");
			}
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			byte[] array = Convert.FromBase64String(string_3);
			bool result = AxNsoControlBase.InnerOpenDocumentBinary(null, array, Document);
			Document.SerializeParameterValue = SerializeParameterValue;
			return result;
		}

		public bool ___MergeDocumentsWithString(string string_3)
		{
			int num = 1;
			if (string.IsNullOrEmpty(string_3))
			{
				throw new ArgumentException("txt");
			}
			if (Document == null)
			{
				Document = new XTextDocument();
			}
			Document.SerializeParameterValue = SerializeParameterValue;
			byte[] array = Convert.FromBase64String(string_3);
			return AxNsoControlBase.MergeDocumentsWithString(null, array, Document);
		}

		/// <summary>
		///       处理ASP.NET页面服务
		///       </summary>
		/// <returns>
		/// </returns>
		public static bool HandleService()
		{
			return Class65.smethod_0(HttpContext.Current.Request, HttpContext.Current.Response, HttpContext.Current.Session);
		}

		/// <summary>
		///       执行编辑器WEB控件配套的服务器页面功能
		///       </summary>
		/// <param name="page">页面对象</param>
		/// <returns>是否执行了功能</returns>
		public static bool HandleServicePage(Page page)
		{
			return Class65.smethod_0(page.Request, page.Response, page.Session);
		}

		internal static byte[] smethod_0()
		{
			int num = 17;
			if (typeof(XTextDocument).Assembly != typeof(WebWriterControl).Assembly)
			{
				return null;
			}
			if (byte_0 != null)
			{
				return byte_0;
			}
			if (int_0 > 4)
			{
				if (string_0 == null)
				{
					return null;
				}
				return Encoding.Default.GetBytes(string_0);
			}
			string_0 = null;
			string text = Path.Combine(Path.GetTempPath(), "DCWriterCAB." + DefaultVersion + ".cab");
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			lock (typeof(WebWriterControl))
			{
				try
				{
					string directoryName = Path.GetDirectoryName(text);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					string text2 = Path.Combine(directoryName, "cabarc.exe");
					FileHelper.ReleaseResourceFile(typeof(WebWriterControl), "DCSoft.Writer.WebCabSource.cabarc.exe", text2, overWrite: true, throwException: false);
					string text3 = Path.Combine(directoryName, "DCSoft.Writer.ClientConfig.exe");
					string resourceName = "DCSoft.Writer.WebCabSource.DCSoft.Writer.ClientConfig.exe";
					if (Environment.Version.Major == 4)
					{
						resourceName = "DCSoft.Writer.WebCabSource.DCSoft.Writer.ClientConfigForNET40.exe";
					}
					FileHelper.ReleaseResourceFile(typeof(WebWriterControl), resourceName, text3, overWrite: true, throwException: false);
					string text4 = Path.Combine(directoryName, "install.inf");
					FileHelper.ReleaseResourceFile(typeof(WebWriterControl), "DCSoft.Writer.WebCabSource.install.inf", text4, overWrite: true, throwException: false);
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = text2;
					processStartInfo.Arguments = "N \"" + text + "\" \"" + typeof(WebWriterControl).Assembly.Location + "\" \"" + text3 + "\"   \"" + text4 + "\"";
					processStartInfo.UseShellExecute = false;
					processStartInfo.CreateNoWindow = true;
					processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					Process process = Process.Start(processStartInfo);
					process.WaitForExit(10000);
					if (!process.HasExited)
					{
						process.Kill();
					}
					File.Delete(text2);
					File.Delete(text4);
					File.Delete(text3);
					if (File.Exists(text))
					{
						byte_0 = File.ReadAllBytes(text);
						int_0 = 0;
						File.Delete(text);
						return byte_0;
					}
				}
				catch (Exception ex)
				{
					int_0++;
					Debug.WriteLine("CheckAutoCABFile:" + ex.Message);
					string_0 = ex.ToString();
				}
			}
			return null;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WebWriterControl()
			: base("span")
		{
			DCWriterPublish.Start();
		}

		private object method_0(string string_3, object object_0)
		{
			if (ViewState[string_3] == null)
			{
				return object_0;
			}
			return ViewState[string_3];
		}

		/// <summary>
		///       仅保持兼容性，请使用SetElementTextByID()。
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[Obsolete("仅保持兼容性，请使用SetElementTextByID()。")]
		public bool SetElementText(string string_3, string text)
		{
			return Document.SetElementTextByID(string_3, text);
		}

		/// <summary>
		///       设置文档元素文本内容
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public bool SetElementTextByID(string string_3, string text)
		{
			return Document.SetElementTextByID(string_3, text);
		}

		/// <summary>
		///       设置文档元素可见性
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="visible">可见性</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public bool SetElementVisible(string string_3, bool visible)
		{
			return Document.SetElementVisible(string_3, visible);
		}

		private string method_1(string string_3)
		{
			int num = 10;
			if (string.IsNullOrEmpty(string_3))
			{
				return null;
			}
			string_3 = string_3.Trim();
			if (string_3.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || string_3.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
			{
				return string_3;
			}
			string text = ResolveUrl(string_3);
			if (text.IndexOf("//") < 0)
			{
				string text2 = Page.Request.Url.AbsoluteUri;
				int num2 = text2.IndexOf("//");
				if (num2 > 0)
				{
					int num3 = text2.IndexOf("/", num2 + 2);
					if (num3 > 0)
					{
						text2 = text2.Substring(0, num3);
					}
				}
				text = text2 + text;
			}
			return text.Replace("/../", "/");
		}

		/// <summary>
		///       设置注册码的静态方法
		///       </summary>
		/// <param name="regCode">注册码</param>
		public static void StaticSetRegisterCode(string regCode)
		{
			XTextDocument.StaticRegisterCode = regCode;
		}

		/// <summary>
		///       获得文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		[ComVisible(true)]
		public object GetDocumnetParameterValue(string name)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.Parameters.GetValue(name);
		}

		/// <summary>
		///       设置文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">新的参数值</param>
		[ComVisible(true)]
		public void SetDocumentParameterValue(string name, object Value)
		{
			if (Document != null)
			{
				Document.Parameters.SetValue(name, Value);
			}
		}

		/// <summary>
		///       设置XML格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="xmlText">参数值</param>
		[ComVisible(true)]
		public void SetDocumentParameterValueXml(string name, string xmlText)
		{
			if (Document != null)
			{
				Document.Parameters.SetXmlValue(name, xmlText);
			}
		}

		/// <summary>
		///       获得Xml格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		[ComVisible(true)]
		public string GetDocumentParameterValueXml(string name)
		{
			if (Document != null)
			{
				return Document.Parameters.GetXmlValue(name);
			}
			return null;
		}

		/// <summary>
		///       本方法无任何作用，只是为了和WinForm报表显示控件XPreviewControl的RefreshView方法保持一只，以方便进行代码的移植。
		///       </summary>
		public void RefreshView()
		{
		}

		internal static XTextDocumentList smethod_1(HttpSessionState httpSessionState_0, string string_3)
		{
			XTextDocumentList result = null;
			object obj = httpSessionState_0[string_3];
			if (obj != null)
			{
				if (obj is XTextDocument)
				{
					result = new XTextDocumentList((XTextDocument)obj);
				}
				else if (obj is XTextDocumentList)
				{
					result = (XTextDocumentList)obj;
				}
			}
			return result;
		}

		internal static void smethod_2(HttpSessionState httpSessionState_0, string string_3, object object_0)
		{
			XTextDocumentList xTextDocumentList = object_0 as XTextDocumentList;
			if (xTextDocumentList == null)
			{
				xTextDocumentList = new XTextDocumentList();
				if (object_0 is XTextDocument)
				{
					xTextDocumentList.Add((XTextDocument)object_0);
				}
			}
			httpSessionState_0[string_3] = xTextDocumentList;
		}

		private static void smethod_3(object sender, WriterReadFileContentEventArgs e)
		{
			int num = 13;
			if (e.FileName == null)
			{
				return;
			}
			int num2 = e.FileName.IndexOf(Class65.string_23 + "=");
			if (num2 > 0)
			{
				string text = e.FileName.Substring(num2 + Class65.string_23.Length + 1).Trim();
				int num3 = text.IndexOf("&");
				if (num3 > 0)
				{
					text = text.Substring(0, num3);
				}
				e.ResultBinary = (HttpContext.Current.Session[text] as byte[]);
				if (e.ResultBinary != null && (e.Document.InnerFlag & 2) == 2)
				{
					HttpContext.Current.Session.Remove(text);
				}
			}
		}

		internal static XTextDocumentList smethod_4(HttpRequest httpRequest_0)
		{
			string string_ = GClass334.smethod_1(httpRequest_0.Url.AbsoluteUri);
			if (httpRequest_0.UrlReferrer != null)
			{
				string absoluteUri = httpRequest_0.UrlReferrer.AbsoluteUri;
				if (!string.IsNullOrEmpty(absoluteUri))
				{
					string_ = GClass334.smethod_1(absoluteUri);
				}
			}
			byte[] bytes = FileHelper.LoadBinaryStream(httpRequest_0.InputStream);
			string @string = httpRequest_0.ContentEncoding.GetString(bytes);
			return smethod_6(@string, string_, bool_3: true);
		}

		private static void smethod_5(string string_3, string string_4)
		{
			int num = 9;
			if (SaveRequestHtmlForDebug && int_4++ <= 100)
			{
				string text = HttpContext.Current.Server.MapPath("DCSoft.Debug");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string path = Path.Combine(text, "RequestHtml_" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".html");
				using (StreamWriter streamWriter = new StreamWriter(path, append: false, Encoding.Default))
				{
					streamWriter.WriteLine("<!-- BaseURL=[" + string_4 + "] -->");
					streamWriter.Write(string_3);
				}
			}
		}

		private static XTextDocumentList smethod_6(string string_3, string string_4, bool bool_3)
		{
			int num = 9;
			smethod_5(string_3, string_4);
			if (!string.IsNullOrEmpty(string_2) && File.Exists(string_2))
			{
				string_3 = File.ReadAllText(string_2, Encoding.Default);
			}
			HTMLDocument hTMLDocument = new HTMLDocument();
			hTMLDocument.BaseURL = string_4;
			float tickCountFloat = CountDown.GetTickCountFloat();
			hTMLDocument.LoadHTML(string_3);
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			XTextDocumentList xTextDocumentList = new XTextDocumentList();
			string text = hTMLDocument.Body.method_9("currentdocumentindex");
			if (!string.IsNullOrEmpty(text))
			{
				int result = 0;
				if (int.TryParse(text, out result))
				{
					xTextDocumentList.CurrentDocumentIndex = result;
				}
			}
			foreach (GClass163 item in hTMLDocument.Body.vmethod_2())
			{
				if (item.method_9("dctype") == typeof(XTextDocumentBodyElement).Name)
				{
					WebWriterControlLoadDocumentOptions webWriterControlLoadDocumentOptions = WebWriterControlLoadDocumentOptions.None;
					if (item.method_13("currentloadoptions"))
					{
						webWriterControlLoadDocumentOptions = (WebWriterControlLoadDocumentOptions)Enum.Parse(typeof(WebWriterControlLoadDocumentOptions), item.method_9("currentloadoptions"));
					}
					XTextDocument xTextDocument = new XTextDocument();
					xTextDocument.RunAtWebServer = true;
					xTextDocument.BaseUrl = item.method_9("baseurl");
					if (string.IsNullOrEmpty(xTextDocument.BaseUrl))
					{
						xTextDocument.BaseUrl = string_4;
					}
					xTextDocument.Options.BehaviorOptions.DoubleCompressHtmlWhitespace = ((webWriterControlLoadDocumentOptions & WebWriterControlLoadDocumentOptions.DoubleCompressWhitespace) == WebWriterControlLoadDocumentOptions.DoubleCompressWhitespace);
					if (bool_3)
					{
						webWriterControlLoadDocumentOptions = (WebWriterControlLoadDocumentOptions)MathCommon.smethod_25((int)webWriterControlLoadDocumentOptions, 2, bool_0: false);
					}
					xTextDocument.BaseUrl = string_4;
					xTextDocument.method_40(DomReadyStates.Loading);
					xTextDocument.FileFormat = "html";
					xTextDocument.InnerFlag = (int)webWriterControlLoadDocumentOptions;
					string value = item.method_9("DCDocumentViewState");
					DocumentViewState.LoadViewStateString(xTextDocument, value);
					if (xTextDocument.Info != null && xTextDocument.Info.SubDocumentSettings != null)
					{
						xTextDocument.Info.SubDocumentSettings.Readonly = (item.method_9("readonly") == "true");
					}
					xTextDocument.Body.Elements.Clear();
					ReadHTMLEventArgs readHTMLEventArgs_ = new ReadHTMLEventArgs(null, item, xTextDocument, null);
					xTextDocument.writerReadFileContentEventHandler_0 = smethod_3;
					xTextDocument.Body.vmethod_17(readHTMLEventArgs_);
					xTextDocument.writerReadFileContentEventHandler_0 = null;
					xTextDocument.method_40(DomReadyStates.Loaded);
					xTextDocument.FixDomState();
					xTextDocument.Header.FixElements();
					xTextDocument.Body.FixElements();
					xTextDocument.Footer.FixElements();
					xTextDocument.method_110();
					xTextDocument.Modified = (item.method_9("dcmodified") != "false");
					if (xTextDocument.SerializeParameterValue)
					{
						xTextDocument.WriteDataFromDocumentToDataSource();
					}
					xTextDocumentList.Add(xTextDocument);
				}
				else if (item.method_9("dctype") == typeof(DocumentComment).Name)
				{
					ReadHTMLEventArgs readHTMLEventArgs_ = new ReadHTMLEventArgs(null, item, null, null);
					DocumentComment documentComment = new DocumentComment();
					readHTMLEventArgs_.ReadDCCustomAttributes(item, documentComment);
					int num2 = readHTMLEventArgs_.ToInt32(item.method_9("documentindex"));
					if (num2 >= 0 && num2 < xTextDocumentList.Count)
					{
						xTextDocumentList[num2].Comments.Add(documentComment);
					}
					foreach (GClass163 item2 in item.vmethod_2())
					{
						if (item2.method_37() != null && item2.method_37().StartsWith("dcmcontent"))
						{
							documentComment.Text = item2.InnerText;
							if (documentComment.Text != null)
							{
								documentComment.Text = documentComment.Text.Trim();
							}
						}
					}
				}
			}
			foreach (XTextDocument item3 in xTextDocumentList)
			{
				item3.method_125();
			}
			return xTextDocumentList;
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			int num = 8;
			base.OnLoad(eventArgs_0);
			if (Page.IsPostBack && AutoPostBack)
			{
				_ = (ClientID ?? "");
				string text = Page.Request.Form[HiddenInputName];
				if (!string.IsNullOrEmpty(text) && bool_1)
				{
					if (ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable)
					{
						string text2 = text.Replace("[3#$~!]", "<");
						text2 = text2.Replace("[!$~$#]", ">");
						text2 = text2.Replace("[!$~$%]", "&");
						WebWriterControlLoadDocumentOptions currentLoadOptions = CurrentLoadOptions;
						if (DoubleCompressWhitespace)
						{
							currentLoadOptions |= WebWriterControlLoadDocumentOptions.DoubleCompressWhitespace;
						}
						XTextDocumentList xTextDocumentList = smethod_6(text2, GClass334.smethod_1(Page.Request.Url.AbsoluteUri), bool_3: false);
						if (xTextDocumentList != null && xTextDocumentList.Count > 0 && xTextDocumentList[0].DocumentOptionsToSaveFile != null)
						{
							DocumentOptions = xTextDocumentList[0].DocumentOptionsToSaveFile;
						}
						CurrentDocumentIndex = xTextDocumentList.CurrentDocumentIndex;
						Documents = xTextDocumentList;
					}
					else if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl)
					{
						byte[] array = Convert.FromBase64String(text);
						array = FileHelper.GZipDecompress(array);
						XTextDocument xTextDocument = Document;
						if (xTextDocument == null)
						{
							xTextDocument = (Document = new XTextDocument());
						}
						xTextDocument.Load(new MemoryStream(array), null);
						xTextDocument.SerializeParameterValue = SerializeParameterValue;
						if (xTextDocument.SerializeParameterValue)
						{
							xTextDocument.WriteDataFromDocumentToDataSource();
						}
						if (xTextDocument.DocumentOptionsToSaveFile != null)
						{
							DocumentOptions = xTextDocument.DocumentOptionsToSaveFile;
						}
					}
				}
			}
			if (!base.DesignMode && Document == null)
			{
				Document = new XTextDocument();
				Document.RunAtWebServer = true;
			}
			if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), "DCWebWriterControlSelfChecking"))
			{
				string script = "\r\n// DCWriter编辑器控件客户端自我检测\r\nfunction DCWebWriterControlSelfChecking(element) {\r\n    //debugger;\r\n    if (element == null) {\r\n        return false;\r\n    }\r\n    if (element.getAttribute('dctype') != 'WebWriterControl') {\r\n        return false;\r\n    }\r\n    var funcShowErrorMessage = function (element, msg) {\r\n        var node = document.createElement('div');\r\n        node.style.fontSize = '20px';\r\n        node.style.fontWeight = 'bold';\r\n        node.style.color = 'red';\r\n        node.style.backgroundColor = 'yellow';\r\n        node.style.border = '1px solid black';\r\n        node.appendChild(document.createTextNode('编辑器控件[' + element.id + ']自检错误：' + msg));\r\n        if (element.firstChild == null) {\r\n            element.appendChild(node);\r\n        }\r\n        else {\r\n            element.insertBefore(node, element.firstChild);\r\n        }\r\n    };\r\n\r\n    var servicePageUrl = element.getAttribute('servicepageurl');\r\n    if (servicePageUrl == null || servicePageUrl.length == 0) {\r\n        funcShowErrorMessage(element, '没配置ServicePageUrl属性!');\r\n    }\r\n    else {\r\n        var xmlhttp = null;\r\n        if (window.XMLHttpRequest) {// code for all new browsers\r\n            xmlhttp = new XMLHttpRequest();\r\n        }\r\n        else if (window.ActiveXObject) {// code for IE5 and IE6\r\n            xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');\r\n        }\r\n        if (xmlhttp != null) {\r\n            xmlhttp.onreadystatechange = function () {\r\n                if (xmlhttp.readyState == 4) {// 4 = loaded\r\n                    var txt = xmlhttp.responseText;\r\n                    if (xmlhttp.status != 200) {\r\n                        funcShowErrorMessage(element, '配置的服务器页面地址[' + servicePageUrl + ']测试未通过,HTTP状态为:' + xmlhttp.status);\r\n                        return false;\r\n                    }\r\n                    else if (txt == null || txt.indexOf('dcwriter_test_ok') < 0) {\r\n                        funcShowErrorMessage(element, '配置的服务器页面地址[' + servicePageUrl + ']测试未通过，返回:' + txt);\r\n                    }\r\n                }\r\n            };\r\n            xmlhttp.open('GET', servicePageUrl + '?dcwritertest=1', true);\r\n            xmlhttp.send(null);\r\n        }\r\n        else {\r\n            funcShowErrorMessage(element, '浏览器不支持XMLHttp。');\r\n        }\r\n    }\r\n    return true;\r\n}\r\n";
				Page.ClientScript.RegisterClientScriptBlock(GetType(), "DCWebWriterControlSelfChecking", script, addScriptTags: true);
			}
			if (xtextDocumentList_0 != null)
			{
				foreach (XTextDocument item in xtextDocumentList_0)
				{
					item.RunAtWebServer = true;
				}
			}
		}

		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			int num = 1;
			base.OnPreRender(eventArgs_0);
			if (base.DesignMode)
			{
				return;
			}
			if (Document == null)
			{
				Document = new XTextDocument();
				Document.RunAtWebServer = true;
			}
			if ((ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable || ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml) && !Page.ClientScript.IsClientScriptIncludeRegistered(GetType(), "DCWriterControJS"))
			{
				Page.ClientScript.RegisterClientScriptInclude(GetType(), "DCWriterControJS", method_11("DCSoft.Writer.Controls.Resources.DCBrowserCompabitility.js"));
				Page.ClientScript.RegisterClientScriptInclude(GetType(), "DCWriterControJS4", method_11("DCSoft.Writer.Controls.Resources.DCWriterControl.js"));
			}
			if (AutoPostBack && ContentRenderMode == WebWriterControlRenderMode.ActiveXControl && !Page.ClientScript.IsOnSubmitStatementRegistered(GetType(), ClientID + "OnSubmitStatement"))
			{
				StringBuilder stringBuilder = new StringBuilder();
				string text = "axWriterControl_" + ClientID;
				stringBuilder.AppendLine("    var " + text + " = document.getElementById('" + ClientID + "');");
				stringBuilder.AppendLine("    var " + HiddenInputName + " = document.getElementById('" + HiddenInputName + "');");
				stringBuilder.AppendLine("    if( " + text + " != null && " + text + ".SaveToAxContentBase64String )");
				stringBuilder.AppendLine("    {");
				stringBuilder.AppendLine("        " + HiddenInputName + ".value = " + text + ".SaveToAxContentBase64String();");
				stringBuilder.AppendLine("    }");
				Page.ClientScript.RegisterHiddenField(HiddenInputName, "");
				Page.ClientScript.RegisterOnSubmitStatement(GetType(), ClientID + "OnSubmitStatement", stringBuilder.ToString());
			}
			if (ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable && !Page.ClientScript.IsOnSubmitStatementRegistered(GetType(), ClientID + "OnSubmitStatement"))
			{
				StringBuilder stringBuilder = new StringBuilder();
				_ = Page.Form.ClientID;
				string text2 = "dcWebWriterControl" + int_2;
				stringBuilder.AppendLine("var " + text2 + " = document.getElementById('" + ClientID + "');");
				stringBuilder.AppendLine("if( typeof( Sys ) != 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager && Sys.WebForms.PageRequestManager.getInstance ){// 处于ASP.NET AJAX模式");
				stringBuilder.AppendLine("}else{");
				stringBuilder.AppendLine("if( " + text2 + ".ShowAppProcessing){");
				stringBuilder.AppendLine("    " + text2 + ".ShowAppProcessing();");
				stringBuilder.AppendLine("}}");
				if (AutoPostBack)
				{
					stringBuilder.AppendLine("if( " + text2 + ".GetContentHtml && document.getElementById('" + HiddenInputName + "') != null ){");
					stringBuilder.AppendLine("document.getElementById('" + HiddenInputName + "').value = " + text2 + ".GetContentHtml();");
					stringBuilder.AppendLine("}");
				}
				Page.ClientScript.RegisterOnSubmitStatement(GetType(), ClientID + "OnSubmitStatement", stringBuilder.ToString());
			}
			if ((ContentRenderMode == WebWriterControlRenderMode.NormalHtml || ContentRenderMode == WebWriterControlRenderMode.NormalHtmlKeepLinebreak) && GenerateFormElement)
			{
				string resourceName = "DCSoft.Writer.Controls.Resources.DCWriterWeb.js";
				Page.ClientScript.RegisterClientScriptResource(GetType(), resourceName);
			}
			if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl)
			{
				Page.ClientScript.RegisterClientScriptBlock(GetType(), "HandleBackspace", "\r\n<script language='javascript'>\r\n\r\n document.onkeydown = function () {\r\n            if (event.keyCode == 8) {\r\n                // 首先让编辑器试图处理back键\r\n                if (document.getElementById('" + ClientID + "').HandleBackspace() == true) {\r\n                    // 若编辑器成功的处理了back键，则浏览器无需处理\r\n                    return false;\r\n                }\r\n            }\r\n            return true;\r\n        };\r\n\r\n</script>\r\n");
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			int num = 1;
			try
			{
				if (string_1 != null)
				{
					writer.WriteLine("Render:" + string_1);
				}
				if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl || ContentRenderMode == WebWriterControlRenderMode.AxPrintPreviewControl || ContentRenderMode == WebWriterControlRenderMode.NsoControl)
				{
					base.Render(writer);
				}
				else
				{
					if (Page.Site != null && Page.Site.DesignMode)
					{
					}
					base.Render(writer);
				}
				if (Page.Site != null && !Page.Site.DesignMode)
				{
					writer.WriteBeginTag("script");
					writer.WriteAttribute("language", "javascript");
					writer.Write(">");
					writer.WriteLine();
					writer.WriteLine("DCWebWriterControlSelfChecking( document.getElementById('" + ClientID + "'));");
					writer.WriteLine();
					writer.WriteEndTag("script");
					smethod_7(int_2)?.method_51();
				}
			}
			catch (Exception ex)
			{
				string text = ex.ToString();
				text = text.Replace("\r", "<br/>");
				text = text.Replace("\n", "");
				writer.WriteBeginTag("span");
				writer.WriteAttribute("style", "color:red;font-weight:bold;word-wrap:break-word");
				writer.Write(">");
				writer.WriteLine(text);
				writer.WriteEndTag("span");
			}
		}

		private string method_2()
		{
			return null;
		}

		private string method_3(Color color_0)
		{
			return GClass23.smethod_0(color_0);
		}

		/// <summary>
		/// </summary>
		/// <param name="writer">
		/// </param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			int num = 10;
			base.AddAttributesToRender(writer);
			if (Page != null && Page.Site != null && Page.Site.DesignMode)
			{
				return;
			}
			writer.AddAttribute("version", XTextDocument.CurrentEditorVersion.ToString());
			writer.AddAttribute("ServicePageURL", RuntimeServicePageURL);
			writer.AddAttribute("controlinstanceid", int_2.ToString());
			writer.AddAttribute("contentrendermode", ContentRenderMode.ToString());
			writer.AddAttribute("dctype", typeof(WebWriterControl).Name);
			if (RuntimeIsMobileDevice)
			{
				writer.AddAttribute("ismobiledevice", "true");
				if (AutoHeightInMobileDevice)
				{
					writer.AddAttribute("height", "");
					writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "");
				}
			}
			if (!OldBrowser)
			{
				writer.AddAttribute("insertimagebuttonid", InsertImageButtonID);
			}
			if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl || ContentRenderMode == WebWriterControlRenderMode.NsoControl || ContentRenderMode == WebWriterControlRenderMode.AxPrintPreviewControl)
			{
				Type typeFromHandle = typeof(AxWriterControl);
				if (ContentRenderMode == WebWriterControlRenderMode.NsoControl)
				{
					typeFromHandle = typeof(NsoControl);
				}
				else if (ContentRenderMode == WebWriterControlRenderMode.AxPrintPreviewControl)
				{
					typeFromHandle = typeof(AxWriterPrintPreviewControl);
				}
				GuidAttribute guidAttribute = (GuidAttribute)Attribute.GetCustomAttribute(typeFromHandle, typeof(GuidAttribute), inherit: true);
				writer.AddAttribute("classid", "clsid:" + guidAttribute.Value);
				string runtimeCABCodeBase = RuntimeCABCodeBase;
				if (runtimeCABCodeBase != null)
				{
					writer.AddAttribute("codebase", runtimeCABCodeBase);
				}
				return;
			}
			if (ContentRenderMode != WebWriterControlRenderMode.NormalHtmlEditable && ContentRenderMode != WebWriterControlRenderMode.PagePreviewHtml)
			{
				writer.AddStyleAttribute("overflow", "auto");
			}
			if (ContentRenderMode == WebWriterControlRenderMode.PageImage)
			{
				writer.AddAttribute("align", "center");
				writer.AddStyleAttribute("background-color", method_3(WorkspaceBackColor));
			}
			if (Document != null)
			{
				writer.AddStyleAttribute("font-name", Document.DefaultFont.Name);
				writer.AddStyleAttribute("font-size", Document.DefaultFont.Size + "pt");
			}
			if (base.Page != null && base.Page.Form != null)
			{
				writer.AddAttribute("FormID", base.Page.Form.ClientID);
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="writer">
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			int num = 13;
			if (Page.Site != null && Page.Site.DesignMode)
			{
				Type type = GetType();
				writer.WriteLine("<b>" + ID + "</b>");
				writer.WriteLine("<br />Width = " + Width);
				writer.WriteLine("<br />Height = " + Height);
				writer.WriteLine("<br />Type = " + type.FullName);
				writer.WriteLine("<br />Version = " + type.Assembly.FullName);
				writer.WriteLine("<br />PageShadow = " + PageShadow);
				writer.WriteLine("<br />ServicePageURL = " + ServicePageURL);
				writer.WriteLine("<br />WriterControlWebServiceUrl = " + WriterControlWebServiceUrl);
				writer.WriteLine("<br />ContentRenderMode = " + ContentRenderMode);
				writer.WriteLine("<br />南京都昌信息科技有限公司，发布时间：" + WriterControl.StaticCoreVersion);
				writer.WriteLine("<br />" + WriterStrings.AboutWebControl);
				return;
			}
			base.RenderContents(writer);
			string text = method_2();
			if (text != null)
			{
				writer.Write(text);
				return;
			}
			XTextDocumentList xTextDocumentList = Documents;
			if (xTextDocumentList == null || xTextDocumentList.Count == 0)
			{
				xTextDocumentList = new XTextDocumentList();
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.FixDomState();
				xTextDocumentList.Add(xTextDocument);
			}
			Documents = xTextDocumentList;
			foreach (XTextDocument item in xTextDocumentList)
			{
				if (DocumentOptions != null)
				{
					item.Options = DocumentOptions;
				}
				item.vmethod_31(bool_17: true);
			}
			if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl || ContentRenderMode == WebWriterControlRenderMode.NsoControl || ContentRenderMode == WebWriterControlRenderMode.AxPrintPreviewControl)
			{
				method_4(writer);
				return;
			}
			if (ShowDebugInfo)
			{
				writer.WriteBeginTag("div");
				writer.WriteAttribute("style", "border:1 solid black;text-align:left");
				writer.WriteLine("<br />");
				writer.Write("Control Version:" + GetType().Assembly.FullName);
				writer.WriteLine("<br />");
				writer.Write("Control ID:" + ClientID);
				writer.WriteLine("<br />");
				writer.Write("DLL Path:" + GetType().Assembly.CodeBase);
				writer.WriteLine("<br />");
				writer.WriteLine("<br />");
				writer.Write("DocumentVersion:" + Document.Info.Version);
				writer.WriteLine("<br />");
				writer.Write("Document Title:" + Document.Info.Title);
				writer.WriteLine("<br />");
				writer.Write("FileName:" + Document.FileName);
				writer.WriteLine("<br />");
				writer.Write("Page Count:" + Document.Pages.Count);
				writer.WriteLine("<br />");
				writer.Write("<br/>Browser:" + BrowserStyle.ToString() + " | " + Page.Request.Browser.MajorVersion);
				writer.Write("<br/>Platform:" + Page.Request.Browser.Platform);
				writer.Write("<br/>IsMobileDevice:" + RuntimeIsMobileDevice);
				writer.Write("<br/>BrowserID:" + Page.Request.Browser.Id);
				writer.WriteLine("<script language='javascript'>DCWriterControllerClass.WriteDebugInfo();</script>");
				writer.WriteEndTag("div");
			}
			if (ContentRenderMode == WebWriterControlRenderMode.PageImage)
			{
				method_6(writer, xTextDocumentList);
			}
			else if (ContentRenderMode == WebWriterControlRenderMode.NormalHtml || ContentRenderMode == WebWriterControlRenderMode.NormalHtmlKeepLinebreak)
			{
				method_5(writer, xTextDocumentList);
			}
			else if (ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable || ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml)
			{
				method_8(writer, xTextDocumentList);
			}
		}

		private void method_4(HtmlTextWriter htmlTextWriter_0)
		{
			int num = 2;
			if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl && !string.IsNullOrEmpty(WriterControlWebServiceUrl))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "WebServiceUrl");
				htmlTextWriter_0.WriteAttribute("value", RuntimeWriterControlWebServiceUrl);
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			if (!string.IsNullOrEmpty(RegisterCode))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "RegisterCode");
				htmlTextWriter_0.WriteAttribute("value", RegisterCode);
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			string runtimeCABCodeBase = RuntimeCABCodeBase;
			if (!string.IsNullOrEmpty(runtimeCABCodeBase))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "CodeBaseForUpdateAssembly");
				string value = runtimeCABCodeBase;
				htmlTextWriter_0.WriteAttribute("value", value);
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			if (ContentRenderMode == WebWriterControlRenderMode.ActiveXControl && (Readonly || XTextDocument.InnerLicenseViewerOnly))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "Readonly");
				htmlTextWriter_0.WriteAttribute("value", "true");
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			if (!string.IsNullOrEmpty(AdditionPageTitle))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "AdditionPageTitle");
				htmlTextWriter_0.WriteAttribute("value", AdditionPageTitle);
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			string runtimeKBLibraryUrl = RuntimeKBLibraryUrl;
			if (!string.IsNullOrEmpty(runtimeKBLibraryUrl))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "KBLibraryUrl");
				htmlTextWriter_0.WriteAttribute("value", runtimeKBLibraryUrl);
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			if (FormView != FormViewMode.Normal)
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "FormView");
				htmlTextWriter_0.WriteAttribute("value", FormView.ToString());
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			if (Document != null && (ContentRenderMode == WebWriterControlRenderMode.AxPrintPreviewControl || ContentRenderMode == WebWriterControlRenderMode.ActiveXControl))
			{
				htmlTextWriter_0.WriteBeginTag("param");
				htmlTextWriter_0.WriteAttribute("name", "AxContentBase64String");
				Document.DocumentOptionsToSaveFile = DocumentOptions;
				Document.ControlOptionsForDebug = ControlOptions;
				string s = AxWriterControl.SaveToAxContentBase64String(Document);
				htmlTextWriter_0.WriteAttribute("value", HttpUtility.HtmlAttributeEncode(s));
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("param");
				htmlTextWriter_0.WriteLine();
			}
			htmlTextWriter_0.WriteBeginTag("div");
			htmlTextWriter_0.WriteAttribute("style", "border-width:1;border-style:solid;border-color:black;background-color:yellow;overflow:auto");
			htmlTextWriter_0.Write(">");
			if (RuntimeAutoGenerateCABFile)
			{
				smethod_0();
				if (!string.IsNullOrEmpty(string_0))
				{
					htmlTextWriter_0.WriteBeginTag("pre");
					htmlTextWriter_0.Write(">");
					htmlTextWriter_0.WriteLine(string_0);
					htmlTextWriter_0.WriteEndTag("pre");
					htmlTextWriter_0.WriteLine("<hr />");
				}
			}
			htmlTextWriter_0.Write(WriterStrings.PromptActiveXControlInWeb);
			htmlTextWriter_0.WriteLine("<br/>----- 客户端浏览器诊断信息 ------");
			htmlTextWriter_0.WriteLine("<br/>ActiveXControls=" + base.Page.Request.Browser.ActiveXControls);
			Version[] clrVersions = base.Page.Request.Browser.GetClrVersions();
			if (clrVersions != null && clrVersions.Length > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				Version[] array = clrVersions;
				foreach (Version version in array)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(version.ToString());
				}
				htmlTextWriter_0.WriteLine("<br/>.NET CLR Version=" + stringBuilder.ToString());
			}
			htmlTextWriter_0.WriteLine("<br/>Browser=" + base.Page.Request.Browser.Type);
			htmlTextWriter_0.WriteLine("<br/>Platform=" + base.Page.Request.Browser.Platform);
			string activeXSuggest = WriterStrings.ActiveXSuggest;
			activeXSuggest = activeXSuggest.Replace("@CABURL", RuntimeCABUrl);
			htmlTextWriter_0.WriteLine(activeXSuggest);
			htmlTextWriter_0.WriteEndTag("div");
		}

		private void method_5(HtmlTextWriter htmlTextWriter_0, XTextDocumentList xtextDocumentList_1)
		{
			int num = 19;
			for (int i = 0; i < xtextDocumentList_1.Count; i++)
			{
				XTextDocument xTextDocument = xtextDocumentList_1[i];
				xTextDocument.CheckPageRefreshed();
				float tickCountFloat = CountDown.GetTickCountFloat();
				htmlTextWriter_0.WriteLine("<!--  开始  " + xTextDocument.Info.RuntimeTitle + " -->");
				xTextDocument.vmethod_31(bool_17: true);
				xTextDocument.CheckPageRefreshed();
				Class57 @class = new Class57();
				@class.gdelegate21_0 = (GDelegate21)Delegate.Combine(@class.gdelegate21_0, new GDelegate21(method_13));
				@class.method_148(xtextDocumentList_1[0]);
				@class.method_23(bool_8: false);
				@class.imethod_46().method_15(ContentRenderMode == WebWriterControlRenderMode.NormalHtmlKeepLinebreak);
				@class.imethod_46().method_17(GenerateFormElement);
				@class.imethod_46().method_3(IndentHtmlCode);
				@class.imethod_46().method_5(bool_9: false);
				@class.imethod_46().method_11(ImageDataEmbedInHtml);
				@class.imethod_56(BackgroundTextOutputMode);
				@class.imethod_58(xTextDocument.Options.ViewOptions.EnableEncryptView);
				@class.method_35();
				xTextDocument.Body.vmethod_18(@class);
				string value = @class.method_38();
				if (!string.IsNullOrEmpty(value))
				{
					htmlTextWriter_0.WriteBeginTag("style");
					htmlTextWriter_0.WriteLine();
					htmlTextWriter_0.Write(value);
					htmlTextWriter_0.Write(Environment.NewLine);
					htmlTextWriter_0.WriteEndTag("style");
				}
				htmlTextWriter_0.WriteLine();
				htmlTextWriter_0.WriteLine(@class.method_34());
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				htmlTextWriter_0.WriteLine("<!--  结束  " + xTextDocument.Info.RuntimeTitle + " 耗时 " + tickCountFloat + " 毫秒 -->");
			}
		}

		private void method_6(HtmlTextWriter htmlTextWriter_0, XTextDocumentList xtextDocumentList_1)
		{
			int num = 15;
			bool_2 = false;
			Page.Session[RuntimeDocumentBufferedName] = xtextDocumentList_1;
			htmlTextWriter_0.WriteLine("<div style='height:" + PixelPageSpacing + "px' ></div>");
			int num2 = 0;
			int maxPageCount = MaxPageCount;
			for (int i = 0; i < xtextDocumentList_1.Count; i++)
			{
				XTextDocument xTextDocument = xtextDocumentList_1[i];
				xTextDocument.CheckPageRefreshed();
				string str = "border:1 solid black";
				if (PageShadow)
				{
					str += ";progid:DXImageTransform.Microsoft.Shadow(color='black', Direction=135, Strength=5)";
				}
				for (int j = 0; j < xTextDocument.Pages.Count; j++)
				{
					if (maxPageCount > 0 && num2 >= maxPageCount)
					{
						break;
					}
					num2++;
					string text = "map" + Convert.ToString(int_5++);
					string text2 = null;
					if (ImageDataEmbedInHtml)
					{
						MemoryStream memoryStream = new MemoryStream();
						using (Bitmap bitmap = xTextDocument.CreatePageBmp(j, showMarginLine: true))
						{
							bitmap.Save(memoryStream, ImageFormat.Png);
						}
						memoryStream.Close();
						byte[] inArray = memoryStream.ToArray();
						string str2 = Convert.ToBase64String(inArray);
						text2 = "data:image/png;base64," + str2;
					}
					else
					{
						text2 = RuntimeServicePageURL + "?" + Class65.string_13 + "=" + Class65.string_6 + "&" + Class65.string_16 + "=" + HttpUtility.HtmlAttributeEncode(RuntimeDocumentBufferedName) + "&" + Class65.string_14 + "=" + Class65.string_7 + "&" + Class65.string_18 + "=" + i + "&" + Class65.string_15 + "=" + j + "&NoneFlag=" + Convert.ToString(int_5++);
					}
					htmlTextWriter_0.Write("<img src=\"" + text2 + "\" border='1' usemap='#" + text + "' style='zoom: " + PageZoomRate + "' ");
					htmlTextWriter_0.WriteLine("/>");
					xTextDocument.LastDrawAbsoluteBounds = new Dictionary<XTextElement, PointF[]>();
					using (xTextDocument.CreatePageBmp(j, showMarginLine: true))
					{
					}
					if (xTextDocument.LastDrawAbsoluteBounds.Count > 0)
					{
						htmlTextWriter_0.WriteLine("<map name='" + text + "'>");
						foreach (XTextElement key in xTextDocument.LastDrawAbsoluteBounds.Keys)
						{
							HyperlinkInfo hyperlinkInfo = null;
							if (key is XTextObjectElement)
							{
								hyperlinkInfo = ((XTextObjectElement)key).LinkInfo;
							}
							if (!(hyperlinkInfo?.IsEmpty ?? true))
							{
								PointF[] array = xTextDocument.LastDrawAbsoluteBounds[key];
								StringBuilder stringBuilder = new StringBuilder();
								for (int k = 0; k < array.Length; k++)
								{
									if (k > 0)
									{
										stringBuilder.Append(",");
									}
									stringBuilder.Append(xTextDocument.ToPixel(array[k].X));
									stringBuilder.Append(",");
									stringBuilder.Append(xTextDocument.ToPixel(array[k].Y));
								}
								string text3 = hyperlinkInfo.Title;
								if (string.IsNullOrEmpty(text3))
								{
									text3 = hyperlinkInfo.Reference;
								}
								htmlTextWriter_0.Indent++;
								htmlTextWriter_0.WriteLine("<area shape='poly' coords='" + stringBuilder.ToString() + "' href='" + HttpUtility.HtmlAttributeEncode(hyperlinkInfo.Reference) + "' title='" + HttpUtility.HtmlAttributeEncode(text3) + "' target='" + hyperlinkInfo.Target + "' >");
								htmlTextWriter_0.Indent--;
							}
						}
						htmlTextWriter_0.WriteLine("</map>");
						xTextDocument.LastDrawAbsoluteBounds = null;
					}
					htmlTextWriter_0.WriteLine("<div style='height:" + PixelPageSpacing + "px' ></div>");
				}
			}
		}

		internal static Class52 smethod_7(int int_7)
		{
			int num = 0;
			if (HttpContext.Current != null && HttpContext.Current.Session != null)
			{
				return HttpContext.Current.Session["htmlgenerator-" + int_7] as Class52;
			}
			return null;
		}

		private Class52 method_7()
		{
			string string_ = GClass38.smethod_1(this);
			Class52 @class = new Class52();
			Page.Session["htmlgenerator-" + int_2] = @class;
			@class.AdditionPageTitle = AdditionPageTitle;
			@class.method_54(DocumentOptions);
			@class.method_1(int_2);
			Class61 class2 = new Class61();
			class2.method_15(FreeSelection);
			class2.method_19(AllowDrop);
			class2.AutoGenerateCABFile = AutoGenerateCABFile;
			class2.AutoHeightInMobileDevice = AutoHeightInMobileDevice;
			class2.AutoLine = AutoLine;
			class2.AutoPostBack = AutoPostBack;
			class2.AutoZoom = AutoZoom;
			class2.BackgroundTextOutputMode = BackgroundTextOutputMode;
			class2.CABUrl = CABUrl;
			class2.CABVersion = CABVersion;
			class2.CommentVisibility = CommentVisibility;
			class2.CompressSessionData = CompressSessionData;
			class2.ContentRenderMode = ContentRenderMode;
			class2.EnablePermission = EnablePermission;
			class2.ExcludeKeywords = ExcludeKeywords;
			class2.method_17(FixedHeader);
			class2.FormView = FormView;
			class2.GenerateFormElement = GenerateFormElement;
			class2.IndentHtmlCode = IndentHtmlCode;
			class2.InsertImageButtonID = InsertImageButtonID;
			class2.IsMobileDevice = IsMobileDevice;
			class2.KBLibraryUrl = KBLibraryUrl;
			class2.MaxPageCount = MaxPageCount;
			class2.method_21(MinContentPixelHeight);
			class2.MultiDocument = MultiDocument;
			class2.NarrowBorder = NarrowBorder;
			class2.method_25(PageBackColor);
			class2.PageShadow = PageShadow;
			class2.PixelPageSpacing = PixelPageSpacing;
			class2.Readonly = (Readonly || XTextDocument.InnerLicenseViewerOnly);
			class2.SerializeParameterValue = SerializeParameterValue;
			class2.ShowDebugInfo = ShowDebugInfo;
			class2.ShowMainDocumentBodyWhenMultiDocument = ShowMainDocumentBodyWhenMultiDocument;
			class2.ShowMarginLine = ShowMarginLine;
			class2.method_23(WorkspaceBackColor);
			class2.WorkspaceBackgroundImage = WorkspaceBackgroundImage;
			class2.method_27(WriterControlWebServiceUrl);
			class2.method_5(AllowCopy);
			class2.method_7(PrintCollate);
			class2.method_9(PrintCopies);
			class2.method_11(PrintMode);
			class2.method_13(PrintSpecifyPageIndexsString);
			class2.method_3(PrintZoomRate);
			class2.AutoZoom = RuntimeAutoZoom;
			class2.AutoGenerateCABFile = RuntimeAutoGenerateCABFile;
			class2.ServicePageURL = RuntimeServicePageURL;
			class2.CABUrl = RuntimeCABUrl;
			class2.NarrowBorder = RuntimeNarrowBorder;
			class2.KBLibraryUrl = RuntimeKBLibraryUrl;
			class2.method_27(RuntimeWriterControlWebServiceUrl);
			class2.EnabledClientContextMenu = EnabledClientContextMenu;
			class2.method_1(ImageDataEmbedInHtml);
			@class.method_3(class2);
			@class.method_7(@class.method_6());
			@class.method_19(BrowserStyle);
			@class.method_21(Page.Response.Charset);
			@class.method_57(RuntimeCommentVisible);
			@class.method_25(ClientID);
			@class.method_9(CurrentLoadOptions);
			@class.method_11(ShowDebugInfo);
			@class.method_27(RuntimeIsMobileDevice);
			@class.method_23(string_);
			@class.method_61(ServerEventNameList);
			@class.method_59(Page.Session.Timeout);
			@class.method_7(OldBrowser);
			@class.method_15(Page.Request.Browser.ActiveXControls || @class.method_18() == XWebBrowsersStyle.InternetExplorer || @class.method_18() == XWebBrowsersStyle.InternetExplorer7 || @class.method_18() == XWebBrowsersStyle.InternetExplorer8);
			@class.queryListItemsEventHandler_0 = EventQueryListItems;
			@class.method_31(GClass334.smethod_1(Page.Request.Url.AbsoluteUri));
			@class.CurrentDocumentIndex = CurrentDocumentIndex;
			@class.gdelegate21_0 = method_13;
			return @class;
		}

		private void method_8(HtmlTextWriter htmlTextWriter_0, XTextDocumentList xtextDocumentList_1)
		{
			int num = 10;
			GClass38.smethod_2(this, "EventQueryListItems");
			GClass38.smethod_2(this, "EventSaveFileContent");
			GClass38.smethod_2(this, "EventReadFileContent");
			GClass38.smethod_2(this, "EventSaveSelectionContent");
			if (xtextDocumentList_1 == null)
			{
				xtextDocumentList_1 = new XTextDocumentList();
			}
			if (xtextDocumentList_1.Count == 0)
			{
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.FixDomState();
				xtextDocumentList_1.Add(xTextDocument);
			}
			Class52 @class = method_7();
			if (xtextDocumentList_1.Count == 0)
			{
				htmlTextWriter_0.WriteLine(WriterStrings.NoDocument);
				return;
			}
			if (string.IsNullOrEmpty(ServicePageURL))
			{
				htmlTextWriter_0.WriteLine("<b>" + WriterStrings.RequireServicePageURL + "</b>");
				return;
			}
			XTextDocument xTextDocument2 = xtextDocumentList_1[0];
			if (ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml)
			{
				xTextDocument2.States.Printing = true;
			}
			else
			{
				xTextDocument2.States.Printing = false;
			}
			xTextDocument2.Options.BehaviorOptions.DoubleCompressHtmlWhitespace = DoubleCompressWhitespace;
			xTextDocument2.PageRefreshed = false;
			float tickCountFloat = CountDown.GetTickCountFloat();
			xTextDocument2.CheckPageRefreshed();
			foreach (XTextDocument item in xtextDocumentList_1)
			{
				item.CheckPageRefreshed();
			}
			string text = null;
			if (ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml)
			{
				@class.method_2().Readonly = true;
				text = @class.method_50(Documents, bool_7: false);
			}
			else
			{
				text = @class.method_49(Documents);
			}
			htmlTextWriter_0.WriteBeginTag("div");
			htmlTextWriter_0.WriteAttribute("id", ClientID + "_ControlMask");
			htmlTextWriter_0.WriteAttribute("style", "position:absolute;width:400px;height:400px;display:none;text-align:center;vertical-align:middle;filter:Alpha(style=4,opacity=60);filter:progid:DXImageTransform.Microsoft.Alpha(opacity=60);opacity:0.6;background-color:#cccccc;z-index:10002");
			htmlTextWriter_0.Write(">");
			htmlTextWriter_0.WriteLine();
			htmlTextWriter_0.WriteEndTag("div");
			htmlTextWriter_0.WriteLine();
			string text2 = method_12(@class);
			htmlTextWriter_0.Write("<table id='" + ClientID + "_Processing' style='display:none;position:absolute;width:300px;height:100px;font-size:12pt;color:Black;background-color:" + ColorTranslator.ToHtml(GClass445.smethod_4()) + ";border:1px solid black;z-index:10003; -moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'><tr style='height:100px'><td valign='middle' style='width:300px'><img width='64' height='64' align='middle' style='background-color:white' src='" + text2 + "'><span id='" + ClientID + "_ProcessingLabel'>" + WriterStrings.AppProcessing + "</span></td></tr></table>");
			htmlTextWriter_0.WriteLine();
			string text3 = "\r\n<table id='@ClientID_Dialog' unselectable='on' cellpadding='0' cellspacing='0' style='table-layout:fixed;display:none;position:absolut;width:430px;height:220px;background-color:rgb(198,226,253);border:1px solid black;z-index:10003;border-radius:5px;overflow:hidden;cursor:default'>\r\n    <tr height='19px'>\r\n        <td style='padding-left:7px;' valign='middle' unselectable='on'>\r\n            <span id='@ClientID_DialogTitle' style='font-weight:bold;font-size:10pt' ></span>\r\n        </td>\r\n        <td align='right' unselectable='on' style='padding-right:6px;width:49px' >\r\n            <img src='@url1' border='0' onmouseenter=#this.src='@url2';# onmouseout=#this.src='@url1';# style='cursor:default' title='关闭' onclick=#document.getElementById('@ClientID').CloseMaskDialog();#/>\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td style='padding:2px' colspan='2'>\r\n            <iframe id='@ClientID_DialogContent' unselectable='on' style='background-color:white;border:0px' width='100%' height='200px' src='about:blank'></iframe>\r\n        </td>\r\n    </tr>\r\n</table>";
			text3 = text3.Replace("@ClientID", ClientID);
			text3 = text3.Replace("#", "\"");
			text3 = text3.Replace("@url1", @class.method_65("DCSoft.Writer.Controls.Resources.closebutton.png"));
			text3 = text3.Replace("@url2", @class.method_65("DCSoft.Writer.Controls.Resources.closebutton2.png"));
			htmlTextWriter_0.Write(text3);
			htmlTextWriter_0.WriteLine();
			htmlTextWriter_0.WriteBeginTag("iframe");
			htmlTextWriter_0.WriteAttribute("id", ClientID + "_Frame");
			htmlTextWriter_0.WriteAttribute("border", "0");
			htmlTextWriter_0.WriteAttribute("FRAMEBORDER", "no");
			htmlTextWriter_0.WriteAttribute("hspace", "0");
			htmlTextWriter_0.WriteAttribute("vspace", "0");
			htmlTextWriter_0.WriteAttribute("src", "about:blank");
			htmlTextWriter_0.WriteAttribute("width", "100%");
			htmlTextWriter_0.WriteAttribute("height", "100%");
			htmlTextWriter_0.WriteAttribute("style", "3px solid red");
			if (RuntimeIsMobileDevice)
			{
				htmlTextWriter_0.WriteAttribute("scrolling", "no");
			}
			htmlTextWriter_0.Write(">");
			htmlTextWriter_0.WriteEndTag("iframe");
			htmlTextWriter_0.WriteLine();
			method_9(htmlTextWriter_0, xTextDocument2);
			if (AutoPostBack)
			{
				htmlTextWriter_0.WriteBeginTag("textarea");
				htmlTextWriter_0.WriteAttribute("id", HiddenInputName);
				htmlTextWriter_0.WriteAttribute("name", HiddenInputName);
				htmlTextWriter_0.WriteAttribute("style", "display:none");
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("textarea");
			}
			htmlTextWriter_0.WriteBeginTag("textarea");
			htmlTextWriter_0.WriteAttribute("dctype", "DCHtmlSource");
			htmlTextWriter_0.WriteAttribute("style", "display:none");
			htmlTextWriter_0.Write(">");
			htmlTextWriter_0.Write(HttpUtility.HtmlEncode(text));
			htmlTextWriter_0.WriteEndTag("textarea");
			htmlTextWriter_0.WriteLine();
			string text4 = "WebWriterControl_" + int_2 + "_Init";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("function " + text4 + "(){");
			stringBuilder.AppendLine();
			if (ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable)
			{
				string text5 = GClass112.smethod_2(xTextDocument2.Options, bool_0: true);
				stringBuilder.AppendLine("document.getElementById(\"" + ClientID + "\").DocumentOptions = " + text5 + ";");
			}
			stringBuilder.AppendLine("if( typeof( DCWriterControllerClass )!= 'undefined') DCWriterControllerClass.InitController( document.getElementById(\"" + ClientID + "\") );");
			stringBuilder.AppendLine("if( typeof( DCWriterControllerClass )!= 'undefined') DCWriterControllerClass.loadContent( document.getElementById(\"" + ClientID + "\") );");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine(text4 + "();");
			if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), text4))
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.AppendLine(stringBuilder.ToString());
				stringBuilder2.AppendLine("if( typeof( Sys ) != 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager && Sys.WebForms.PageRequestManager.getInstance){");
				stringBuilder2.AppendLine("\t// 遇到ASP.NET AJAX框架");
				stringBuilder2.AppendLine("\tSys.WebForms.PageRequestManager.getInstance().add_endRequest(" + text4 + ");");
				stringBuilder2.AppendLine("}");
				Page.ClientScript.RegisterStartupScript(GetType(), text4, stringBuilder2.ToString(), addScriptTags: true);
			}
			htmlTextWriter_0.WriteLine();
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			htmlTextWriter_0.WriteLine("<!--  结束  " + xTextDocument2.Info.RuntimeTitle + " 耗时 " + tickCountFloat + " 毫秒,输出" + text.Length + "个字符 -->");
		}

		private void method_9(HtmlTextWriter htmlTextWriter_0, XTextDocument xtextDocument_0)
		{
			htmlTextWriter_0.WriteLine("<script language='javascript'>");
			string text = string.Format(WriterStrings.Loading_FileName, xtextDocument_0.RuntimeTitle);
			text = XMLHelper.AllToXMLEntry(text);
			htmlTextWriter_0.WriteLine();
			string text2 = "frame_" + Guid.NewGuid().ToString("N");
			htmlTextWriter_0.WriteLine(" var " + text2 + " = document.getElementById('" + ClientID + "_Frame');");
			htmlTextWriter_0.WriteLine("if( " + text2 + " != null && " + text2 + ".contentWindow != null && " + text2 + ".contentWindow.document != null ){");
			htmlTextWriter_0.WriteLine(text2 + ".contentWindow.document.write(\"" + text + "\");");
			htmlTextWriter_0.WriteLine(text2 + ".contentWindow.document.close();");
			htmlTextWriter_0.WriteLine("}");
			htmlTextWriter_0.WriteLine();
			htmlTextWriter_0.WriteLine("</script>");
		}

		private void method_10(HtmlTextWriter htmlTextWriter_0, XTextDocumentList xtextDocumentList_1)
		{
			int num = 5;
			GClass38.smethod_2(this, "EventQueryListItems");
			GClass38.smethod_2(this, "EventSaveFileContent");
			GClass38.smethod_2(this, "EventReadFileContent");
			GClass38.smethod_2(this, "EventSaveSelectionContent");
			if (xtextDocumentList_1 == null)
			{
				xtextDocumentList_1 = new XTextDocumentList();
			}
			if (xtextDocumentList_1.Count == 0)
			{
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.FixDomState();
				xtextDocumentList_1.Add(xTextDocument);
			}
			Class52 @class = method_7();
			if (xtextDocumentList_1.Count == 0)
			{
				htmlTextWriter_0.WriteLine(WriterStrings.NoDocument);
				return;
			}
			if (string.IsNullOrEmpty(ServicePageURL))
			{
				htmlTextWriter_0.WriteLine("<b>" + WriterStrings.RequireServicePageURL + "</b>");
				return;
			}
			XTextDocument xTextDocument2 = xtextDocumentList_1[0];
			xTextDocument2.States.PrintPreviewing = true;
			xTextDocument2.Options.BehaviorOptions.DoubleCompressHtmlWhitespace = DoubleCompressWhitespace;
			xTextDocument2.PageRefreshed = false;
			xTextDocument2.CheckPageRefreshed();
			float tickCountFloat = CountDown.GetTickCountFloat();
			xTextDocument2.CheckPageRefreshed();
			string text = null;
			if (ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml)
			{
				@class.method_2().Readonly = true;
				text = @class.method_50(Documents, bool_7: false);
			}
			else
			{
				text = @class.method_49(Documents);
			}
			htmlTextWriter_0.WriteBeginTag("div");
			htmlTextWriter_0.WriteAttribute("id", ClientID + "_ControlMask");
			htmlTextWriter_0.WriteAttribute("style", "position:absolute;width:400px;height:400px;display:none;text-align:center;vertical-align:middle;filter:Alpha(style=4,opacity=60);filter:progid:DXImageTransform.Microsoft.Alpha(opacity=60);opacity:0.6;background-color:#cccccc;z-index:10002");
			htmlTextWriter_0.Write(">");
			htmlTextWriter_0.WriteLine();
			htmlTextWriter_0.WriteEndTag("div");
			htmlTextWriter_0.WriteLine();
			string text2 = method_12(@class);
			htmlTextWriter_0.Write("<table id='" + ClientID + "_Processing' style='display:none;position:absolute;width:300px;height:100px;font-size:12pt;color:Black;background-color:white;border:1px solid black;z-index:10003; -moz-border-radius:5px;-webkit-border-radius:5px;border-radius:5px;'><tr style='height:100px'><td valign='middle' style='width:300px'><img width='64' height='64' align='middle' style='background-color:white' src='" + text2 + "'>" + WriterStrings.AppProcessing + "</td></tr></table>");
			htmlTextWriter_0.WriteLine();
			string text3 = "\r\n<table id='@ClientID_Dialog' unselectable='on' cellpadding='0' cellspacing='0' style='table-layout:fixed;display:none;position:absolut;width:430px;height:220px;background-color:rgb(198,226,253);border:1px solid black;z-index:10003;border-radius:5px;overflow:hidden;cursor:default'>\r\n    <tr height='19px'>\r\n        <td style='padding-left:7px;' valign='middle' unselectable='on'>\r\n            <span id='@ClientID_DialogTitle' style='font-weight:bold;font-size:10pt' ></span>\r\n        </td>\r\n        <td align='right' unselectable='on' style='padding-right:6px;width:49px' >\r\n            <img src='@url1' border='0' onmouseenter=#this.src='@url2';# onmouseout=#this.src='@url1';# style='cursor:default' title='关闭' onclick=#document.getElementById('@ClientID').CloseMaskDialog();#/>\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td style='padding:2px' colspan='2'>\r\n            <iframe id='@ClientID_DialogContent' unselectable='on' style='background-color:white;border:0px' width='100%' height='200px' src='about:blank'></iframe>\r\n        </td>\r\n    </tr>\r\n</table>";
			text3 = text3.Replace("@ClientID", ClientID);
			text3 = text3.Replace("#", "\"");
			text3 = text3.Replace("@url1", @class.method_65("DCSoft.Writer.Controls.Resources.closebutton.png"));
			text3 = text3.Replace("@url2", @class.method_65("DCSoft.Writer.Controls.Resources.closebutton2.png"));
			htmlTextWriter_0.Write(text3);
			htmlTextWriter_0.WriteLine();
			htmlTextWriter_0.WriteBeginTag("iframe");
			htmlTextWriter_0.WriteAttribute("id", ClientID + "_Frame");
			htmlTextWriter_0.WriteAttribute("border", "0");
			htmlTextWriter_0.WriteAttribute("FRAMEBORDER", "no");
			htmlTextWriter_0.WriteAttribute("hspace", "0");
			htmlTextWriter_0.WriteAttribute("vspace", "0");
			htmlTextWriter_0.WriteAttribute("src", "about:blank");
			htmlTextWriter_0.WriteAttribute("width", "100%");
			htmlTextWriter_0.WriteAttribute("height", "100%");
			htmlTextWriter_0.Write(">");
			htmlTextWriter_0.WriteEndTag("iframe");
			htmlTextWriter_0.WriteLine();
			method_9(htmlTextWriter_0, xTextDocument2);
			if (AutoPostBack)
			{
				htmlTextWriter_0.WriteBeginTag("textarea");
				htmlTextWriter_0.WriteAttribute("id", HiddenInputName);
				htmlTextWriter_0.WriteAttribute("name", HiddenInputName);
				htmlTextWriter_0.WriteAttribute("style", "display:none");
				htmlTextWriter_0.Write(">");
				htmlTextWriter_0.WriteEndTag("textarea");
			}
			htmlTextWriter_0.WriteBeginTag("textarea");
			htmlTextWriter_0.WriteAttribute("dctype", "DCHtmlSource");
			htmlTextWriter_0.WriteAttribute("style", "display:none");
			htmlTextWriter_0.Write(">");
			htmlTextWriter_0.Write(HttpUtility.HtmlEncode(text));
			htmlTextWriter_0.WriteEndTag("textarea");
			htmlTextWriter_0.WriteLine();
			string text4 = "WebWriterControl_" + int_2 + "_Init";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("function " + text4 + "(){");
			stringBuilder.AppendLine();
			string text5 = GClass112.smethod_2(xTextDocument2.Options, bool_0: true);
			stringBuilder.AppendLine("document.getElementById(\"" + ClientID + "\").DocumentOptions = " + text5 + ";");
			stringBuilder.AppendLine(" DCWriterControllerClass.InitController( document.getElementById(\"" + ClientID + "\") );");
			stringBuilder.AppendLine(" DCWriterControllerClass.loadContent( document.getElementById(\"" + ClientID + "\") );");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine(text4 + "();");
			if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), text4))
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.AppendLine(stringBuilder.ToString());
				stringBuilder2.AppendLine("if( typeof( Sys ) != 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager && Sys.WebForms.PageRequestManager.getInstance){");
				stringBuilder2.AppendLine("\t// 遇到ASP.NET AJAX框架");
				stringBuilder2.AppendLine("\tSys.WebForms.PageRequestManager.getInstance().add_endRequest(" + text4 + ");");
				stringBuilder2.AppendLine("}");
				Page.ClientScript.RegisterStartupScript(GetType(), text4, stringBuilder2.ToString(), addScriptTags: true);
			}
			htmlTextWriter_0.WriteLine();
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			htmlTextWriter_0.WriteLine("<!--  结束  " + xTextDocument2.Info.RuntimeTitle + " 耗时 " + tickCountFloat + " 毫秒,输出" + text.Length + "个字符 -->");
		}

		public override void Dispose()
		{
			base.Dispose();
			if (bool_2 && xtextDocumentList_0 != null)
			{
				foreach (XTextDocument item in xtextDocumentList_0)
				{
					item.Dispose();
				}
				xtextDocumentList_0 = null;
			}
			writerControlOptions_0 = null;
			documentOptions_0 = null;
		}

		private string method_11(string string_3)
		{
			Class52 @class = method_7();
			return @class.method_55(string_3);
		}

		private string method_12(Class52 class52_0)
		{
			int num = 5;
			string text = CustomLogoImage;
			if (!string.IsNullOrEmpty(text) && !XTextDocument.IsEnableCustomLogoImage)
			{
				text = null;
			}
			if (string.IsNullOrEmpty(text))
			{
				GClass357 gClass = class52_0.method_32(DCLogon64, "a.png");
				text = gClass.method_0();
			}
			return text;
		}

		private void method_13(object object_0, GClass355 gclass355_0)
		{
			int num = 11;
			string text = null;
			if (object_0 is GInterface5)
			{
				text = ((GInterface5)object_0).imethod_31();
			}
			if (string.IsNullOrEmpty(text))
			{
				text = RuntimeServicePageURL;
			}
			if (gclass355_0.method_0().method_12() is XTextMedicalExpressionFieldElement)
			{
				XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = (XTextMedicalExpressionFieldElement)gclass355_0.method_0().method_12();
				gclass355_0.method_0().method_1(text + "?" + Class65.string_25 + "=" + xTextMedicalExpressionFieldElement.ExpressionStyle.ToString() + "&text=" + HttpUtility.UrlEncode(xTextMedicalExpressionFieldElement.Text) + "&width=" + Convert.ToInt32(xTextMedicalExpressionFieldElement.OwnerDocument.ToPixel(xTextMedicalExpressionFieldElement.Width)) + "&height=" + Convert.ToInt32(xTextMedicalExpressionFieldElement.OwnerDocument.ToPixel(xTextMedicalExpressionFieldElement.Height)) + "&fontsize=" + xTextMedicalExpressionFieldElement.Style.FontSize);
				return;
			}
			int_6++;
			string text2 = "img" + Convert.ToString(int_6);
			gclass355_0.method_0().method_1(text + "?" + Class65.string_23 + "=" + text2 + "&flag=" + Class65.int_0);
			Page.Session[text2] = gclass355_0.method_0().method_8();
		}

		private void method_14(XTextElement xtextElement_0, HtmlTextWriter htmlTextWriter_0, int int_7, int int_8, int int_9)
		{
		}

		internal static string smethod_8(string string_3, string string_4)
		{
			int num = 18;
			if (string.IsNullOrEmpty(string_3))
			{
				string_3 = "~/";
			}
			if (!string_3.EndsWith("/"))
			{
				string_3 += "/";
			}
			return string_3 + string_4;
		}
	}
}

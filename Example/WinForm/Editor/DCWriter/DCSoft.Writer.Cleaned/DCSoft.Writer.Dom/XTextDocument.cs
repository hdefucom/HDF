#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Script;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Script;
using DCSoft.Writer.Security;
using DCSoft.Writer.Serialization;
using DCSoft.Writer.Serialization.Html;
using DCSoft.Writer.Serialization.RTF;
using DCSoft.Writer.Serialization.Xml;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文本文档对象
	///       </summary>
	/// <remarks>
	///       XTextDocument 是文本文档对象模型的顶级对象,是外部程序访问文档对象模型的入口点,
	///       它包含了一些控制文本文档整体的成员.包括文档对象的组织,文档视图内容的绘制,用户界面事件处理.
	///       编制 袁永福 2012-4-12
	///       </remarks>
	/// <summary>
	///       文档参数、数据相关的代码群
	///       </summary>
	/// <summary>
	///       文档加载和保存的代码群
	///       </summary>
	[Serializable]
	[XmlInclude(typeof(XTextInputFieldElementBase))]
	[XmlInclude(typeof(XTextInputFieldElement))]
	[XmlInclude(typeof(XTextButtonElement))]
	[XmlType("XTextDocument")]
	[XmlInclude(typeof(XTextParagraphFlagElement))]
	[XmlInclude(typeof(XTextObjectElement))]
	[DocumentComment]
	[DCPublishAPI]
	[XmlInclude(typeof(XTextImageElement))]
	[XmlInclude(typeof(XTextLineBreakElement))]
	[XmlInclude(typeof(XTextBookmark))]
	[XmlInclude(typeof(XTextStringElement))]
	[XmlInclude(typeof(XTextDocumentHeaderElement))]
	[XmlInclude(typeof(XTextDocumentBodyElement))]
	[XmlInclude(typeof(XTextDocumentFooterElement))]
	[XmlInclude(typeof(XTextDocumentHeaderForFirstPageElement))]
	[XmlInclude(typeof(XTextDocumentFooterForFirstPageElement))]
	[XmlInclude(typeof(XTextTableElement))]
	[XmlInclude(typeof(XTextTableRowElement))]
	[XmlInclude(typeof(XTextTableColumnElement))]
	[XmlInclude(typeof(XTextTableCellElement))]
	[XmlInclude(typeof(XTextPageBreakElement))]
	[XmlInclude(typeof(XTextFieldElementBase))]
	[ComClass("00012345-6789-ABCD-EF01-23456789000A", "8E2EF4DB-94EE-40C9-B5F1-D81600FCC154", "6A816920-3A16-40C6-93CF-6C24F1EBCBBE")]
	[XmlInclude(typeof(XTextCheckBoxElement))]
	[XmlInclude(typeof(XTextRadioBoxElement))]
	[XmlInclude(typeof(XTextSignElement))]
	[XmlInclude(typeof(XTextDocumentFieldElement))]
	[XmlInclude(typeof(XTextPageInfoElement))]
	[XmlInclude(typeof(XTextContentLinkFieldElement))]
	[XmlInclude(typeof(XTextHorizontalLineElement))]
	[XmlInclude(typeof(XTextBeanFieldElement))]
	[XmlInclude(typeof(XTextFileBlockElement))]
	[XmlInclude(typeof(XTextLabelElement))]
	[XmlInclude(typeof(XTextDirectoryFieldElement))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextDocument))]
	[Guid("00012345-6789-ABCD-EF01-23456789000A")]
	[XmlInclude(typeof(XTextCustomShapeElement))]
	[ComSourceInterfaces(typeof(IXTextDocumentComEvents))]
	[XmlInclude(typeof(XTextControlHostElement))]
	[XmlInclude(typeof(XTextSectionElement))]
	[XmlInclude(typeof(XTextSubDocumentElement))]
	public sealed class XTextDocument : XTextContainerElement, IXTextDocument, IPageDocument
	{
		private class Class15
		{
			public object object_0 = null;

			public string string_0 = null;

			public string string_1 = null;

			public string string_2 = null;

			public XTextElement xtextElement_0 = null;

			public override string ToString()
			{
				return string_0 + "." + string_1 + "=" + string_2;
			}
		}

		private class Class16 : List<Class15>
		{
			private bool bool_0 = false;

			public bool method_0()
			{
				return bool_0;
			}

			public void method_1(bool bool_1)
			{
				bool_0 = bool_1;
			}

			public Class15 method_2(XDataBinding xdataBinding_0, bool bool_1)
			{
				method_1(bool_1: false);
				if (xdataBinding_0 == null)
				{
					return null;
				}
				if (xdataBinding_0.Readonly)
				{
					return null;
				}
				if (!xdataBinding_0.Enabled)
				{
					return null;
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Class15 current = enumerator.Current;
						if (xdataBinding_0.DataSource == current.string_0 && current.string_1 == xdataBinding_0.WriteTextBindingPath)
						{
							method_1(bool_1: true);
							return current;
						}
					}
				}
				if (bool_1)
				{
					Class15 current = new Class15();
					current.string_0 = xdataBinding_0.DataSource;
					if (string.IsNullOrEmpty(xdataBinding_0.DataSource) || string.IsNullOrEmpty(xdataBinding_0.WriteTextBindingPath))
					{
						return null;
					}
					current.string_1 = xdataBinding_0.WriteTextBindingPath;
					Add(current);
					return current;
				}
				return null;
			}
		}

		private class Class17
		{
			public XTextElement xtextElement_0 = null;

			public string string_0 = null;
		}

		private class Class18 : IMessageFilter
		{
			private static Class18 class18_0 = null;

			public static void smethod_0()
			{
				if (class18_0 == null)
				{
					class18_0 = new Class18();
					Application.AddMessageFilter(class18_0);
				}
			}

			public bool PreFilterMessage(ref Message message_0)
			{
				if (message_0.Msg == 1134)
				{
					try
					{
						if (message_0.WParam != IntPtr.Zero)
						{
							GClass244 gClass = new GClass244(message_0.HWnd);
							if (gClass.method_37())
							{
								string text = Marshal.PtrToStringBSTR(message_0.WParam);
								Marshal.FreeBSTR(message_0.WParam);
								if (!string.IsNullOrEmpty(text) && text.Length < 100)
								{
									string str = "未注册版本只能用于开发过程，严禁正式商业使用，否则视为盗版，违反法律，严重者将面临刑事处罚。软件供应商将保留追究法律责任的权利。";
									text = text + Environment.NewLine + str;
									if (!bool_28)
									{
										Control control = Control.FromHandle(gClass.Handle);
										if (control != null)
										{
											control.BeginInvoke(new Delegate0(smethod_4), control, text);
										}
										else
										{
											bool_28 = true;
											try
											{
												MessageBox.Show(gClass, text, WriterStringsCore.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
											}
											finally
											{
												bool_28 = false;
											}
										}
									}
								}
							}
						}
					}
					catch (Exception)
					{
					}
					finally
					{
						bool_28 = false;
					}
					return true;
				}
				return false;
			}
		}

		private delegate void Delegate0(Control control_0, string string_0);

		private delegate void Delegate1(Control control_0, string string_0);

		private enum Enum2
		{
			const_0,
			const_1,
			const_2
		}

		internal const string string_14 = "00012345-6789-ABCD-EF01-23456789000A";

		internal const string string_15 = "8E2EF4DB-94EE-40C9-B5F1-D81600FCC154";

		internal const string string_16 = "6A816920-3A16-40C6-93CF-6C24F1EBCBBE";

		[NonSerialized]
		private WriterExpressionFunctionEventHandler writerExpressionFunctionEventHandler_0 = null;

		[NonSerialized]
		private EventHandler eventHandler_0 = null;

		[NonSerialized]
		private EventHandler eventHandler_1 = null;

		[NonSerialized]
		private SelectionChangingEventHandler selectionChangingEventHandler_0 = null;

		[NonSerialized]
		private EventHandler eventHandler_2 = null;

		[NonSerialized]
		private ElementValidatingEventHandler elementValidatingEventHandler_0 = null;

		[NonSerialized]
		private ElementPaintEventHandler elementPaintEventHandler_0 = null;

		[NonSerialized]
		private ElementPaintEventHandler elementPaintEventHandler_1 = null;

		[NonSerialized]
		private WriterPrintEventHandler writerPrintEventHandler_0 = null;

		[NonSerialized]
		private WriterPrintQueryPageSettingsEventHandler writerPrintQueryPageSettingsEventHandler_0 = null;

		[NonSerialized]
		private WriterPrintPageEventHandler writerPrintPageEventHandler_0 = null;

		[NonSerialized]
		private WriterPrintEventHandler writerPrintEventHandler_1 = null;

		/// <summary>
		///       加载文档DOM原始结构后的事件.本事件是加载文档原始DOM结构后的触发的事件.这是一个很早期的事件，此时文档元素内容布局、数据源绑定、表达式和脚本尚未开始执行。
		///       </summary>
		[NonSerialized]
		[ComVisible(true)]
		[XmlIgnore]
		public WriterEventHandler EventAfterLoadRawDOM = null;

		[NonSerialized]
		private bool bool_17 = false;

		private AppErrorInfo appErrorInfo_0 = null;

		private DocumentOutlineNodeList documentOutlineNodeList_0 = null;

		private DomReadyStates domReadyStates_0 = DomReadyStates.UnInitialized;

		private static int int_10;

		[NonSerialized]
		private Dictionary<string, XTextElement> dictionary_0 = null;

		private float float_5 = 0f;

		private RepeatedImageValueList repeatedImageValueList_0 = null;

		[NonSerialized]
		private WriterControlOptions writerControlOptions_0 = null;

		private bool bool_18 = false;

		private DocumentOptions documentOptions_0 = null;

		[NonSerialized]
		private GClass123 gclass123_0 = null;

		internal bool bool_19 = true;

		private MotherTemplateInfo motherTemplateInfo_0 = null;

		[NonSerialized]
		private PrintResult printResult_0 = null;

		private PageContentVersionInfoList pageContentVersionInfoList_0 = null;

		[NonSerialized]
		private int int_11 = -1;

		[NonSerialized]
		private BoundsSelectionPrintInfo boundsSelectionPrintInfo_0 = null;

		private List<string> list_0 = null;

		private string string_17 = null;

		private string string_18 = null;

		private ScriptLanguageType scriptLanguageType_0 = ScriptLanguageType.VBNET;

		[NonSerialized]
		private IDocumentScriptEngine idocumentScriptEngine_0 = null;

		[NonSerialized]
		private Dictionary<XTextCharElement, char> dictionary_1 = null;

		private string string_19 = null;

		private Version version_0 = new Version();

		[NonSerialized]
		private DocumentContentSourceTypes documentContentSourceTypes_0 = DocumentContentSourceTypes.None;

		[NonSerialized]
		private DocumentOptions documentOptions_1 = null;

		private DocumentInfo documentInfo_0 = new DocumentInfo();

		[NonSerialized]
		private WriterAppHost writerAppHost_0 = null;

		[NonSerialized]
		private DocumentControler documentControler_0 = null;

		[NonSerialized]
		private XTextDocumentContentElement xtextDocumentContentElement_0 = null;

		private int int_12 = 0;

		[NonSerialized]
		private XTextDocumentUndoList xtextDocumentUndoList_0 = null;

		private bool bool_20 = false;

		[NonSerialized]
		private XTextElementList xtextElementList_2 = null;

		[NonSerialized]
		private WriterControl writerControl_0 = null;

		[NonSerialized]
		private Class136 class136_0 = null;

		[NonSerialized]
		private Class135 class135_0 = null;

		private bool bool_21 = true;

		[NonSerialized]
		private DocumentCommentList documentCommentList_0 = new DocumentCommentList();

		private DocumentCommentList documentCommentList_1 = new DocumentCommentList();

		[NonSerialized]
		internal bool bool_22 = false;

		[NonSerialized]
		private GClass132 gclass132_0 = null;

		[NonSerialized]
		private ElementEventTemplate elementEventTemplate_0 = null;

		[NonSerialized]
		private GInterface7 ginterface7_0 = null;

		[NonSerialized]
		private Class114 class114_0 = null;

		[NonSerialized]
		private GInterface4 ginterface4_0 = null;

		[NonSerialized]
		private IDCElementIDForEditableDependentExecuter idcelementIDForEditableDependentExecuter_0 = null;

		[NonSerialized]
		private GInterface2 ginterface2_0 = null;

		[NonSerialized]
		private GInterface6 ginterface6_0 = null;

		[NonSerialized]
		private XTextElement xtextElement_0 = null;

		[NonSerialized]
		private GClass95 gclass95_0 = null;

		private MeasureMode measureMode_0 = MeasureMode.Default;

		[NonSerialized]
		private DocumentStates documentStates_0 = new DocumentStates();

		private LocalConfig localConfig_0 = new LocalConfig();

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private XPageSettings xpageSettings_0 = new XPageSettings();

		private PrintPageCollection printPageCollection_0 = new PrintPageCollection();

		[NonSerialized]
		private PrintPageCollection printPageCollection_1 = null;

		[NonSerialized]
		private bool bool_23 = false;

		[NonSerialized]
		private PrintPage printPage_0 = null;

		private int int_13 = 0;

		[NonSerialized]
		private Dictionary<XTextElement, PointF[]> dictionary_2 = null;

		[NonSerialized]
		private XTextElementList xtextElementList_3 = null;

		[NonSerialized]
		private float float_6 = 0f;

		[NonSerialized]
		private MemoryStream memoryStream_0 = null;

		/// <summary>
		///       绘制文档内容之前的执行的功能委托
		///       </summary>
		[NonSerialized]
		[Browsable(false)]
		[DCInternal]
		[ComVisible(false)]
		[XmlIgnore]
		public PageDocumentPaintEventHandler BeforeDrawContent = null;

		/// <summary>
		///       绘制文档内容之后的执行的功能委托
		///       </summary>
		[NonSerialized]
		[XmlIgnore]
		[ComVisible(false)]
		[Browsable(false)]
		[DCInternal]
		public PageDocumentPaintEventHandler AfterDrawContent = null;

		[NonSerialized]
		private RectangleF rectangleF_0 = RectangleF.Empty;

		[NonSerialized]
		private AdornTextManager adornTextManager_0 = null;

		[NonSerialized]
		private GClass108 gclass108_0 = null;

		private UserHistoryInfoList userHistoryInfoList_0 = new UserHistoryInfoList();

		[NonSerialized]
		internal SizeF sizeF_0 = SizeF.Empty;

		[NonSerialized]
		internal float float_7 = 0f;

		[NonSerialized]
		private PageViewMode pageViewMode_0 = PageViewMode.Page;

		[NonSerialized]
		private List<XTextContentElement> list_1 = null;

		[NonSerialized]
		private float[] float_8 = null;

		private bool bool_24 = false;

		[NonSerialized]
		private BinaryContentBuffer binaryContentBuffer_0 = null;

		[NonSerialized]
		private object object_1 = null;

		private string string_20 = null;

		[NonSerialized]
		private SystemAlertInfoList systemAlertInfoList_0 = null;

		[NonSerialized]
		private XTextElementList xtextElementList_4 = null;

		private List<string> list_2 = null;

		[NonSerialized]
		private DataSourceTreeDocument dataSourceTreeDocument_0 = null;

		[NonSerialized]
		private DataSourceTreeDocument dataSourceTreeDocument_1 = null;

		private bool bool_25 = false;

		private DocumentParameterCollection documentParameterCollection_0 = new DocumentParameterCollection();

		[NonSerialized]
		private DocumentParameterCollection documentParameterCollection_1 = new DocumentParameterCollection();

		[NonSerialized]
		private object object_2 = null;

		internal bool bool_26 = false;

		private int int_14 = 0;

		private static float float_9;

		private DocumentContentStyleContainer documentContentStyleContainer_0 = null;

		[NonSerialized]
		private CurrentContentStyleInfo currentContentStyleInfo_0 = null;

		private static GEnum13[] genum13_0;

		/// <summary>
		///       耗时翻倍数,对于普及版授权，一些操作耗时是翻倍的。
		///       </summary>
		internal static int _MULSP;

		internal static bool bool_27;

		private static string _RegisterCodeFileUrl;

		private static string _RegisterCode;

		[NonSerialized]
		private static string string_21;

		private static System.Windows.Forms.Timer timer_0;

		private static bool bool_28;

		private static string string_22;

		private static int _LicenseLevel;

		internal static GEnum13 genum13_1;

		private static int int_15;

		[NonSerialized]
		[XmlIgnore]
		[Browsable(false)]
		[ComVisible(false)]
		public WriterReadFileContentEventHandler writerReadFileContentEventHandler_0 = null;

		private string string_23 = null;

		private string string_24 = null;

		private string string_25 = null;

		[NonSerialized]
		private int int_16 = 0;

		private bool bool_29 = true;

		private int int_17 = 0;

		[NonSerialized]
		internal XTextElement xtextElement_1 = null;

		[NonSerialized]
		private ContentSerializeOptions contentSerializeOptions_0 = null;

		private bool bool_30 = false;

		[NonSerialized]
		private XTextElement xtextElement_2 = null;

		internal bool bool_31 = true;

		[CompilerGenerated]
		private static GDelegate5 gdelegate5_0;

		/// <summary>
		///       程序集是否混淆加密
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public static bool IsAssemblyObfuscation => typeof(Class116).Name != "TableStructInfo";

		/// <summary>
		///       是否记录元素呈现结果信息
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[XmlIgnore]
		public bool LogElementRenderResult
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		public override string DomDisplayName => "Document:" + RuntimeTitle;

		/// <summary>
		///       是否用TRY-CATCH模式触发事件
		///       </summary>
		/// <returns>
		/// </returns>
		internal bool IsTryCathForRaiseEvent
		{
			get
			{
				if (EditorControl != null && EditorControl.IsTryCathForRaiseEvent)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       文档大纲层次的根节点列表
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		[XmlIgnore]
		public DocumentOutlineNodeList OutlineNodes
		{
			get
			{
				if (documentOutlineNodeList_0 == null)
				{
					documentOutlineNodeList_0 = new DocumentOutlineNodeList();
					documentOutlineNodeList_0.Fill(Body.RootParagraphFlag, string.Empty);
				}
				return documentOutlineNodeList_0;
			}
		}

		/// <summary>
		///       当前文档大纲结构节点对象
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		[ComVisible(true)]
		public DocumentOutlineNode CurrentOutlineNode
		{
			get
			{
				if (CurrentContentElement == Body)
				{
					DocumentOutlineNode documentOutlineNode = OutlineNodes.Search(CurrentElement.ViewIndex);
					if (documentOutlineNode == null && OutlineNodes.Count > 0)
					{
						documentOutlineNode = OutlineNodes[0];
					}
					return documentOutlineNode;
				}
				return null;
			}
		}

		/// <summary>
		///       文档加载状态
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[ComVisible(true)]
		[Browsable(false)]
		public DomReadyStates ReadyState => domReadyStates_0;

		/// <summary>
		///       文档正文布局偏移量
		///       </summary>
		[XmlIgnore]
		[DefaultValue(0f)]
		[DCPublishAPI]
		public float BodyLayoutOffset
		{
			get
			{
				return float_5;
			}
			set
			{
				float_5 = value;
			}
		}

		/// <summary>
		///       DOM使用的图标列表
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[XmlIgnore]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCStdImageList DomImageList => DCStdImageList.Instance;

		/// <summary>
		///       重复引用的图片对象,DCWriter内部使用。
		///       </summary>
		[XmlArrayItem("Image", typeof(RepeatedImageValue))]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(true)]
		[ComVisible(false)]
		public RepeatedImageValueList RepeatedImages
		{
			get
			{
				if (repeatedImageValueList_0 == null)
				{
					repeatedImageValueList_0 = new RepeatedImageValueList();
				}
				return repeatedImageValueList_0;
			}
			set
			{
				repeatedImageValueList_0 = value;
			}
		}

		/// <summary>
		///       为调试模式而存放的编辑器控件配置信息
		///       </summary>
		[DefaultValue(null)]
		public WriterControlOptions ControlOptionsForDebug
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
		///       保存文档选项设置到文件中
		///       </summary>
		[DefaultValue(false)]
		[ComVisible(true)]
		public bool SaveDocumentOptionsToFile
		{
			get
			{
				return bool_18;
			}
			set
			{
				bool_18 = value;
			}
		}

		/// <summary>
		///       保存到文件中的文档选项对象.当SaveDocumentOptionsToFile==true时该属性值才有效。
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		[XmlElement]
		[DefaultValue(null)]
		public DocumentOptions DocumentOptionsToSaveFile
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
		///       DCWriter内部使用，强类型的元素列表查询结果缓存区
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DCInternal]
		public GClass123 TypedElements
		{
			get
			{
				if (gclass123_0 == null)
				{
					gclass123_0 = new GClass123();
				}
				return gclass123_0;
			}
		}

		/// <summary>
		///       文档母版信息
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public MotherTemplateInfo MotherTemplate
		{
			get
			{
				return motherTemplateInfo_0;
			}
			set
			{
				motherTemplateInfo_0 = value;
			}
		}

		/// <summary>
		///       元素类型
		///       </summary>
		[Browsable(false)]
		public override ElementType _ElementType => ElementType.Document;

		/// <summary>
		///       最后一次打印的结果
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public PrintResult LastPrintResult
		{
			get
			{
				return printResult_0;
			}
			set
			{
				printResult_0 = value;
			}
		}

		/// <summary>
		///       页面内容版本号信息列表
		///       </summary>
		[XmlArrayItem("Item", typeof(PageContentVersionInfo))]
		[Browsable(false)]
		[DefaultValue(null)]
		public PageContentVersionInfoList PageContentVersions
		{
			get
			{
				return pageContentVersionInfoList_0;
			}
			set
			{
				pageContentVersionInfoList_0 = value;
			}
		}

		/// <summary>
		///       上一次开始搜索的起始位置
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		[DCPublishAPI]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LastSearchStartPosition
		{
			get
			{
				return int_11;
			}
			set
			{
				int_11 = value;
			}
		}

		/// <summary>
		///       区域选择信息
		///       </summary>
		[Browsable(false)]
		internal BoundsSelectionPrintInfo BoundsSelection
		{
			get
			{
				return boundsSelectionPrintInfo_0;
			}
			set
			{
				boundsSelectionPrintInfo_0 = value;
			}
		}

		/// <summary>
		///       成员无效
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[Obsolete]
		public override string RuntimeAdornText => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[XmlIgnore]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete]
		public override CopySourceInfo CopySource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       成员无效
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		private new XTextTableCellElement OwnerCell => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new XTextDocumentContentElement DocumentContentElement => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new XTextContainerElement ContentElement => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new XTextLine OwnerLine => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new XTextParagraphFlagElement OwnerParagraphEOF => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new XTextElement PreviousElement => null;

		/// <summary>
		///       成员无效
		///       </summary>
		[Obsolete]
		[Browsable(false)]
		private new int ViewIndex => 0;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new int ColumnIndex => 0;

		/// <summary>
		///       成员无效
		///       </summary>
		[Browsable(false)]
		[Obsolete]
		private new int ElementIndex => 0;

		/// <summary>
		///       全局性的JavaScript文件的引用路径
		///       </summary>
		[DCInternal]
		[DefaultValue(null)]
		[DCPublishAPI]
		[XmlArrayItem("Reference", typeof(string))]
		[Category("Behavior")]
		public List<string> GlobalJavaScriptReferences
		{
			get
			{
				if (list_0 == null)
				{
					list_0 = new List<string>();
				}
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		/// <summary>
		///       全局性的JavaScript脚本代码
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[HtmlAttribute]
		[DCPublishAPI]
		public string GlobalJavaScript
		{
			get
			{
				return string_17;
			}
			set
			{
				string_17 = value;
			}
		}

		/// <summary>
		///       VBA脚本代码
		///       </summary>
		[Category("Behavior")]
		[HtmlAttribute]
		[DefaultValue(null)]
		[DCPublishAPI]
		public string ScriptText
		{
			get
			{
				return string_18;
			}
			set
			{
				if (string_18 != value)
				{
					string_18 = value;
					ResetScriptEngine();
				}
			}
		}

		/// <summary>
		///       脚本语言类型
		///       </summary>
		[DefaultValue(ScriptLanguageType.VBNET)]
		[XmlElement]
		[DCPublishAPI]
		[HtmlAttribute]
		[Browsable(true)]
		[ComVisible(true)]
		public ScriptLanguageType ScriptLanguage
		{
			get
			{
				return scriptLanguageType_0;
			}
			set
			{
				scriptLanguageType_0 = value;
			}
		}

		/// <summary>
		///       脚本引擎
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		public IDocumentScriptEngine ScriptEngine
		{
			get
			{
				if (idocumentScriptEngine_0 == null)
				{
					idocumentScriptEngine_0 = method_45();
				}
				return idocumentScriptEngine_0;
			}
			set
			{
				idocumentScriptEngine_0 = value;
			}
		}

		/// <summary>
		///       特殊的附加数据,这种数据能保存在复制粘贴过程中生成的临时XML文档，当不包含在其保存的XML文档。
		///       </summary>
		/// <remarks>
		///       这是一种特殊的附加数据,可用于复制粘贴操作时的额外处理,由于复制粘贴操作中
		///       被复制的文档内容会创建一个小的文档复制品然后进行XML序列化,此时该值也会
		///       随着被包含进去,粘贴时就会跟着还原出来,此时可用于额外控制.
		///       例如，若设置本标记为病历号，则可以通过这个属性来实现不同病历之间数据不能复制粘贴的功能。
		///       </remarks>
		[XmlElement]
		[DCPublishAPI]
		[Browsable(false)]
		public string SpecialTag
		{
			get
			{
				return string_19;
			}
			set
			{
				string_19 = value;
			}
		}

		/// <summary>
		///       内容版本号
		///       </summary>
		[DefaultValue(0)]
		[ReadOnly(true)]
		public int DocumentContentVersion
		{
			get
			{
				return _ContentVersion;
			}
			set
			{
				_ContentVersion = value;
			}
		}

		/// <summary>
		///       当前编辑器组件版本号
		///       </summary>
		[Browsable(false)]
		public static Version CurrentEditorVersion => typeof(XTextDocument).Assembly.GetName().Version;

		/// <summary>
		///       最后编辑该文档使用的编辑器组件的版本号
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public Version EditorVersion
		{
			get
			{
				return version_0;
			}
			set
			{
				version_0 = value;
			}
		}

		/// <summary>
		///       编辑器版本号
		///       </summary>
		[XmlAttribute]
		[DCPublishAPI]
		[Category("Data")]
		public string EditorVersionString
		{
			get
			{
				return version_0.ToString();
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					version_0 = new Version();
				}
				else
				{
					version_0 = new Version(value);
				}
			}
		}

		/// <summary>
		///       文档内容来源
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DocumentContentSourceTypes ContentSourceType
		{
			get
			{
				return documentContentSourceTypes_0;
			}
			set
			{
				if (documentContentSourceTypes_0 != value)
				{
					documentContentSourceTypes_0 = value;
				}
			}
		}

		/// <summary>
		///       文档相关的配置项目,该对象不参与二进制和XML序列化.
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentOptions Options
		{
			get
			{
				if (writerControl_0 != null && writerControl_0.DocumentOptions != null)
				{
					return writerControl_0.DocumentOptions;
				}
				if (documentOptions_1 == null)
				{
					documentOptions_1 = new DocumentOptions();
				}
				return documentOptions_1;
			}
			set
			{
				documentOptions_1 = value;
			}
		}

		/// <summary>
		///       文档相关信息
		///       </summary>
		[HtmlAttribute]
		[DCPublishAPI]
		[Browsable(true)]
		public DocumentInfo Info
		{
			get
			{
				return documentInfo_0;
			}
			set
			{
				documentInfo_0 = value;
			}
		}

		/// <summary>
		///       文档标题
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[ComVisible(true)]
		public string Title
		{
			get
			{
				if (Info == null)
				{
					return null;
				}
				return Info.Title;
			}
			set
			{
				if (Info == null)
				{
					Info = new DocumentInfo();
				}
				Info.Title = value;
			}
		}

		/// <summary>
		///       运行时标题
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public string RuntimeTitle
		{
			get
			{
				if (!string.IsNullOrEmpty(Info.Title))
				{
					return Info.Title;
				}
				if (!string.IsNullOrEmpty(FileName))
				{
					return FileName;
				}
				return base.ID;
			}
		}

		/// <summary>
		///       对象所属文档就是自己
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override XTextDocument OwnerDocument
		{
			get
			{
				return this;
			}
			set
			{
			}
		}

		/// <summary>
		///       文档对象没有父节点
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlIgnore]
		public override XTextContainerElement Parent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       应用程序宿主
		///       </summary>
		/// <remarks>
		///       本属性首先使用文档对象自己的宿主对象，若没有则使用文档对象绑定的编
		///       辑器控件的宿主对象，若没有则使用默认宿主对象。</remarks>
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public WriterAppHost AppHost
		{
			get
			{
				if (writerAppHost_0 != null)
				{
					return writerAppHost_0;
				}
				if (EditorControl != null && EditorControl.InnerViewControl != null)
				{
					return EditorControl.AppHost;
				}
				return WriterAppHost.Default;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       文档控制器
		///       </summary>
		/// <remarks>
		///       本属性内部首先使用其绑定的编辑器控件的控制器，若没有使用
		///       文档自己的控制器，若没有则创建一个新的控制器。</remarks>
		[DCInternal]
		[Browsable(false)]
		[XmlIgnore]
		public DocumentControler DocumentControler
		{
			get
			{
				DocumentControler documentControler = null;
				if (EditorControl != null)
				{
					documentControler = EditorControl.DocumentControler;
					if (documentControler != null)
					{
						return documentControler;
					}
				}
				if (documentControler_0 == null)
				{
					documentControler_0 = new DocumentControler();
				}
				documentControler_0.Document = this;
				return documentControler_0;
			}
			set
			{
				documentControler_0 = value;
			}
		}

		/// <summary>
		///       首页页眉对象
		///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextDocumentHeaderForFirstPageElement HeaderForFirstPage
		{
			get
			{
				method_49();
				return (XTextDocumentHeaderForFirstPageElement)Elements[3];
			}
		}

		/// <summary>
		///       页眉对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DefaultValue(null)]
		[XmlIgnore]
		public XTextDocumentHeaderElement Header
		{
			get
			{
				method_49();
				return (XTextDocumentHeaderElement)Elements[0];
			}
		}

		/// <summary>
		///       文档正文对象
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		[DefaultValue(null)]
		public XTextDocumentBodyElement Body
		{
			get
			{
				method_49();
				return (XTextDocumentBodyElement)Elements[1];
			}
		}

		/// <summary>
		///       文档正文纯文本内容
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DCPublishAPI]
		[DefaultValue(null)]
		public string BodyText
		{
			get
			{
				return Body.Text;
			}
			set
			{
			}
		}

		/// <summary>
		///       页脚对象
		///       </summary>
		[DefaultValue(null)]
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextDocumentFooterElement Footer
		{
			get
			{
				method_49();
				return (XTextDocumentFooterElement)Elements[2];
			}
		}

		/// <summary>
		///       首页页脚对象
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		[DefaultValue(null)]
		public XTextDocumentFooterForFirstPageElement FooterForFirstPage
		{
			get
			{
				method_49();
				return (XTextDocumentFooterForFirstPageElement)Elements[4];
			}
		}

		/// <summary>
		///       当前插入点所在的文档内容块对象，它是Header,Body或Footer中的某个。
		///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		[Browsable(false)]
		public XTextDocumentContentElement CurrentContentElement
		{
			get
			{
				if (xtextDocumentContentElement_0 == null)
				{
					xtextDocumentContentElement_0 = Body;
				}
				return xtextDocumentContentElement_0;
			}
			set
			{
				if (xtextDocumentContentElement_0 != value)
				{
					if (EditorControl != null && EditorControl.InnerViewControl != null && EditorControl.InnerViewControl.ViewHandleManager != null)
					{
						EditorControl.InnerViewControl.ViewHandleManager.method_0();
					}
					xtextDocumentContentElement_0 = value;
				}
			}
		}

		/// <summary>
		///       文档中是否有内容被选择
		///       </summary>
		[Browsable(false)]
		public override bool HasSelection
		{
			get
			{
				XTextDocumentContentElement currentContentElement = CurrentContentElement;
				return currentContentElement != null && currentContentElement.Selection.Length != 0;
			}
		}

		/// <summary>
		///       当前文档内容模块样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(null)]
		public PageContentPartyStyle CurrentContentPartyStyle
		{
			get
			{
				if (CurrentContentElement == Header)
				{
					return PageContentPartyStyle.Header;
				}
				if (CurrentContentElement == Footer)
				{
					return PageContentPartyStyle.Footer;
				}
				if (CurrentContentElement == HeaderForFirstPage)
				{
					return PageContentPartyStyle.HeaderForFirstPage;
				}
				if (CurrentContentElement == FooterForFirstPage)
				{
					return PageContentPartyStyle.FooterForFirstPage;
				}
				return PageContentPartyStyle.Body;
			}
		}

		/// <summary>
		///       当前内容
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextContent Content => CurrentContentElement.Content;

		/// <summary>
		///       当前被选择的内容
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public XTextSelection Selection => CurrentContentElement.Selection;

		/// <summary>
		///       获得当前被选中的唯一的元素
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public XTextElement SingleSelectedElement
		{
			get
			{
				if (Selection.AbsLength == 1)
				{
					return Selection.ContentElements[0];
				}
				return null;
			}
		}

		/// <summary>
		///       当前元素。在WEB开发中本属性也是有效的。
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public XTextElement CurrentElement
		{
			get
			{
				if (RunAtWebServer)
				{
					return xtextElement_2;
				}
				return CurrentContentElement.CurrentElement;
			}
		}

		/// <summary>
		///       当前文本域元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public XTextFieldElementBase CurrentField => (XTextFieldElementBase)GetCurrentElement(typeof(XTextFieldElementBase), includeThis: true);

		/// <summary>
		///       当前输入域元素
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextInputFieldElement CurrentInputField => (XTextInputFieldElement)GetCurrentElement(typeof(XTextInputFieldElement), includeThis: true);

		/// <summary>
		///       当前子文档节元素
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextSubDocumentElement CurrentSubDocument => (XTextSubDocumentElement)GetCurrentElement(typeof(XTextSubDocumentElement), includeThis: true);

		/// <summary>
		///       当前文档节元素
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlIgnore]
		public XTextSectionElement CurrentSection => (XTextSectionElement)GetCurrentElement(typeof(XTextSectionElement), includeThis: true);

		/// <summary>
		///       当前单元格元素
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextTableCellElement CurrentTableCell => (XTextTableCellElement)GetCurrentElement(typeof(XTextTableCellElement), includeThis: true);

		/// <summary>
		///       当前表格元素
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextTableElement CurrentTable => (XTextTableElement)GetCurrentElement(typeof(XTextTableElement), includeThis: true);

		/// <summary>
		///       当前段落对象
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[Browsable(false)]
		public XTextParagraphFlagElement CurrentParagraphEOF => CurrentContentElement.CurrentParagraphEOF;

		/// <summary>
		///       用户界面是否锁定了，正在更新中。
		///       </summary>
		[DCPublishAPI]
		[DCInternal]
		[Browsable(false)]
		[ComVisible(false)]
		public override bool UIIsUpdating => EditorControl != null && EditorControl.IsUpdating;

		/// <summary>
		///       当前是否可以记录撤销操作信息
		///       </summary>
		[DCInternal]
		public bool CanLogUndo
		{
			get
			{
				if (ReadyState != DomReadyStates.Complete)
				{
					return false;
				}
				if (!Options.BehaviorOptions.EnableLogUndo)
				{
					return false;
				}
				if (xtextDocumentUndoList_0 != null)
				{
					return xtextDocumentUndoList_0.method_15();
				}
				return false;
			}
		}

		/// <summary>
		///       撤销信息列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		public XTextDocumentUndoList UndoList => xtextDocumentUndoList_0;

		/// <summary>
		///       判断当前位置是否在一个表格的第一个单元格的第一个位置，而且
		///       在这个表格所在的文档容器元素中，该表格前面没有任何元素
		///       </summary>
		internal bool IsCurrentPositionAtFirstCell
		{
			get
			{
				if (Selection.Length == 0)
				{
					XTextElement currentElement = CurrentElement;
					XTextTableCellElement ownerCell = currentElement.OwnerCell;
					if (ownerCell != null && ownerCell.PrivateContent.IndexOf(currentElement) == 0 && ownerCell.RowIndex == 0 && ownerCell.ColIndex == 0)
					{
						XTextTableElement ownerTable = ownerCell.OwnerTable;
						XTextContentElement contentElement = ownerTable.ContentElement;
						int num = contentElement.PrivateContent.IndexOf(ownerTable);
						if (num == 0)
						{
							return true;
						}
						if (num > 0 && contentElement.PrivateContent[num - 1] is XTextFieldBorderElement)
						{
							XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)contentElement.PrivateContent[num - 1];
							if (xTextFieldBorderElement.Position == BorderElementPosition.Start)
							{
								return true;
							}
						}
						XTextElement preElement = contentElement.PrivateContent.GetPreElement(ownerTable);
						if (preElement is XTextTableElement || preElement is XTextTableElement)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断当前位置是否在一个文档节的第一个位置，而且
		///       在这个文档节所在的文档容器元素中，该文档节前面没有任何元素
		///       </summary>
		internal bool IsCurrentPositionAtFirstSection
		{
			get
			{
				if (Selection.Length == 0)
				{
					XTextElement currentElement = CurrentElement;
					XTextSectionElement ownerSection = currentElement.OwnerSection;
					if (ownerSection != null && ownerSection.PrivateContent.IndexOf(currentElement) == 0)
					{
						XTextContentElement contentElement = ownerSection.Parent.ContentElement;
						if (contentElement.PrivateContent.IndexOf(ownerSection) == 0)
						{
							return true;
						}
						XTextElement preElement = contentElement.PrivateContent.GetPreElement(ownerSection);
						if (preElement is XTextTableElement || preElement is XTextSectionElement)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       为插入回车而修正当前样式信息
		///       </summary>
		internal bool FixCurrentStyleInfoForEnter
		{
			get
			{
				return bool_20;
			}
			set
			{
				bool_20 = value;
			}
		}

		/// <summary>
		///       最后一次执行的操作而在文档中新增的元素列表，本属性值可以清除掉。
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextElementList LastNewElements
		{
			get
			{
				return xtextElementList_2;
			}
			set
			{
				xtextElementList_2 = null;
			}
		}

		/// <summary>
		///       文档绑定的控件
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[Browsable(false)]
		public WriterControl EditorControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				if (writerControl_0 != value)
				{
					writerControl_0 = value;
				}
			}
		}

		/// <summary>
		///       文档所属编辑器控件
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DCPublishAPI]
		public override WriterControl WriterControl => writerControl_0;

		/// <summary>
		///       内容快照
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		internal Class136 ContentSnapshot
		{
			get
			{
				if (class136_0 == null)
				{
					class136_0 = new Class136(this);
				}
				return class136_0;
			}
		}

		/// <summary>
		///       获得文档中文档节列表
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public XTextElementList Sections
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				foreach (XTextElement element in Body.Elements)
				{
					if (element is XTextSectionElement)
					{
						xTextElementList.Add(element);
					}
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       获得文档中包含的图片对象列表
		///       </summary>
		[XmlIgnore]
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public XTextElementList Images => GetElementsByType(typeof(XTextImageElement));

		/// <summary>
		///       文档中包含的表格对象列表
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		public XTextElementList Tables
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				method_65(this, xTextElementList);
				return xTextElementList;
			}
		}

		/// <summary>
		///       文档中包含的子文档对象列表
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		public XTextElementList SubDocuments => Body.GetElementsByType(typeof(XTextSubDocumentElement));

		/// <summary>
		///       文档中包含的文本域列表对象
		///       </summary>
		[XmlIgnore]
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public XTextElementList Fields => GetElementsByType(typeof(XTextFieldElementBase));

		/// <summary>
		///       文档中包含的文本输入域列表对象
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[XmlIgnore]
		[DCPublishAPI]
		public XTextElementList InputFields => GetElementsByType(typeof(XTextInputFieldElement));

		/// <summary>
		///       文档中包含的内容被修改的文本输入域列表对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElementList ModifiedInputFields
		{
			get
			{
				XTextElementList elementsByType = GetElementsByType(typeof(XTextInputFieldElement));
				for (int num = elementsByType.Count - 1; num >= 0; num--)
				{
					if (!((XTextInputFieldElement)elementsByType[num]).Modified)
					{
						elementsByType.RemoveAt(num);
					}
				}
				return elementsByType;
			}
		}

		/// <summary>
		///       复选框分组信息
		///       </summary>
		internal Class135 CheckBoxGroupInfo
		{
			get
			{
				if (class135_0 == null || class135_0.method_0() != this)
				{
					class135_0 = new Class135(this);
				}
				return class135_0;
			}
		}

		/// <summary>
		/// </summary>
		internal GInterface9 CommentManager
		{
			get
			{
				if (EditorControl == null)
				{
					return null;
				}
				return EditorControl.CommentManager;
			}
		}

		/// <summary>
		///       内部生成的文档批注对象列表
		///       </summary>
		internal DocumentCommentList InnerComments
		{
			get
			{
				if (documentCommentList_0 == null)
				{
					documentCommentList_0 = new DocumentCommentList();
				}
				return documentCommentList_0;
			}
		}

		/// <summary>
		///       文档批注记录列表
		///       </summary>
		[XmlArrayItem("Comment", typeof(DocumentComment))]
		[DefaultValue(null)]
		[DCPublishAPI]
		public DocumentCommentList Comments
		{
			get
			{
				if (documentCommentList_1 == null)
				{
					documentCommentList_1 = new DocumentCommentList();
				}
				return documentCommentList_1;
			}
			set
			{
				documentCommentList_1 = value;
			}
		}

		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public DocumentCommentList RuntimeComments
		{
			get
			{
				if (documentCommentList_0 == null || documentCommentList_0.Count == 0)
				{
					return documentCommentList_1;
				}
				if (Comments == null || Comments.Count == 0)
				{
					return documentCommentList_0;
				}
				DocumentCommentList documentCommentList = new DocumentCommentList();
				if (InnerComments != null && InnerComments.Count > 0)
				{
					documentCommentList.AddRange(InnerComments);
				}
				if (Comments != null && Comments.Count > 0)
				{
					documentCommentList.AddRange(Comments);
				}
				return documentCommentList;
			}
		}

		/// <summary>
		///       鼠标捕获操作对象
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[ComVisible(false)]
		public GClass132 MouseCapture
		{
			get
			{
				return gclass132_0;
			}
			set
			{
				if (gclass132_0 != value)
				{
					gclass132_0 = value;
				}
			}
		}

		/// <summary>
		///       全局文档事件列表
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		public ElementEventTemplate GlobalEvents
		{
			get
			{
				return elementEventTemplate_0;
			}
			set
			{
				elementEventTemplate_0 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。内容复制执行器对象
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public GInterface7 CopySourceExecuter
		{
			get
			{
				if (ginterface7_0 == null)
				{
					ginterface7_0 = AppHost.Tools.CreateCopySourceExecuter(this);
				}
				return ginterface7_0;
			}
		}

		/// <summary>
		///       联动列表执行器
		///       </summary>
		internal Class114 LinkListExecuter
		{
			get
			{
				if (class114_0 == null)
				{
					class114_0 = new Class114();
				}
				return class114_0;
			}
			set
			{
				class114_0 = value;
			}
		}

		/// <summary>
		///       表达式执行器
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public GInterface4 ExpressionExecuter
		{
			get
			{
				if (ginterface4_0 == null)
				{
					ginterface4_0 = AppHost.Tools.CreateDocumentExpressionExecuter(this);
				}
				return ginterface4_0;
			}
			set
			{
				ginterface4_0 = value;
			}
		}

		/// <summary>
		///       元素设置到容器可编辑性的行为执行器
		///       </summary>
		[DCInternal]
		public IDCElementIDForEditableDependentExecuter ElementIDForEditableDependentExecuter
		{
			get
			{
				if (idcelementIDForEditableDependentExecuter_0 == null)
				{
					idcelementIDForEditableDependentExecuter_0 = AppHost.Tools.CreateDCElementIDForEditableDependentExecuter(this);
				}
				return idcelementIDForEditableDependentExecuter_0;
			}
		}

		/// <summary>
		///       Tab切换操作管理器
		///       </summary>
		internal GInterface2 TabIndexManager
		{
			get
			{
				if (ginterface2_0 == null)
				{
					ginterface2_0 = AppHost.Tools.CreateTabIndexManager(this);
				}
				return ginterface2_0;
			}
		}

		/// <summary>
		///       文档视图中高亮度显示区域管理器
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GInterface6 HighlightManager
		{
			get
			{
				if (ginterface6_0 == null)
				{
					ginterface6_0 = AppHost.Tools.CreateHighlightManager(this);
				}
				return ginterface6_0;
			}
			set
			{
				ginterface6_0 = value;
			}
		}

		/// <summary>
		///       鼠标悬停的元素
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[XmlIgnore]
		public XTextElement HoverElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
				if (HighlightManager != null)
				{
					HighlightManager.imethod_1(null);
				}
			}
		}

		/// <summary>
		///       绘制文档内容的视图对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		public GClass95 Render
		{
			get
			{
				if (bool_24)
				{
					return null;
				}
				if (gclass95_0 == null)
				{
					gclass95_0 = new GClass95();
				}
				if (gclass95_0 != null)
				{
					gclass95_0.method_1(this);
				}
				return gclass95_0;
			}
			set
			{
				gclass95_0 = value;
			}
		}

		/// <summary>
		///       字符测量模式
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(MeasureMode.Default)]
		[DCInternal]
		public MeasureMode MeasureMode
		{
			get
			{
				return measureMode_0;
			}
			set
			{
				if (measureMode_0 != value)
				{
					measureMode_0 = value;
				}
			}
		}

		/// <summary>
		///       文档状态
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public DocumentStates States
		{
			get
			{
				if (documentStates_0 == null)
				{
					documentStates_0 = new DocumentStates();
				}
				return documentStates_0;
			}
			set
			{
				documentStates_0 = value;
			}
		}

		/// <summary>
		///       运行时的文档处于打印视图模式
		///       </summary>
		[Browsable(false)]
		internal bool PrintingViewMode
		{
			get
			{
				if (States.Printing)
				{
					return true;
				}
				if (EditorControl != null && EditorControl.ReadViewMode)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在本地系统配置
		///       </summary>
		[Browsable(false)]
		internal bool HasLocalConfig => localConfig_0 != null;

		/// <summary>
		///       本地系统配置
		///       </summary>
		public LocalConfig LocalConfig
		{
			get
			{
				if (localConfig_0 == null)
				{
					localConfig_0 = new LocalConfig();
				}
				return localConfig_0;
			}
			set
			{
				localConfig_0 = value;
			}
		}

		/// <summary>
		///       文档坐标单位
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DefaultValue(GraphicsUnit.Document)]
		public GraphicsUnit DocumentGraphicsUnit
		{
			get
			{
				return graphicsUnit_0;
			}
			set
			{
				graphicsUnit_0 = value;
			}
		}

		/// <summary>
		///       页面设置信息对象
		///       </summary>
		[RefreshProperties(RefreshProperties.All)]
		[DCPublishAPI]
		[Category("Layout")]
		public XPageSettings PageSettings
		{
			get
			{
				if (xpageSettings_0 == null)
				{
					xpageSettings_0 = new XPageSettings();
					PageRefreshed = false;
				}
				return xpageSettings_0;
			}
			set
			{
				xpageSettings_0 = value;
				if (xpageSettings_0 == null)
				{
					xpageSettings_0 = new XPageSettings();
				}
				PageRefreshed = false;
			}
		}

		/// <summary>
		///       页面集合
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public PrintPageCollection Pages
		{
			get
			{
				if (printPageCollection_0 == null)
				{
					printPageCollection_0 = new PrintPageCollection();
				}
				return printPageCollection_0;
			}
			set
			{
				printPageCollection_0 = value;
			}
		}

		/// <summary>
		///       判断文档中最后一页是否为空白页而无需打印.DCWriter内部使用。
		///       </summary>
		/// <returns>最后一页是否为空白页</returns>
		[ComVisible(false)]
		[XmlIgnore]
		[Browsable(false)]
		public bool LastPageIsEmpty
		{
			get
			{
				XTextLine lastLine = Body.PrivateLines.LastLine;
				if (lastLine != null)
				{
					bool flag = true;
					foreach (XTextElement item in lastLine)
					{
						if (!(item is XTextParagraphFlagElement))
						{
							if (!(item is XTextCharElement))
							{
								flag = false;
								break;
							}
							char charValue = ((XTextCharElement)item).CharValue;
							if (!char.IsWhiteSpace(charValue))
							{
								flag = false;
								break;
							}
						}
					}
					if (flag)
					{
						float absTop = lastLine.AbsTop;
						if (absTop - Pages.LastPage.Top > 10f)
						{
							return false;
						}
						XTextElement preElement = Body.Content.GetPreElement(lastLine[0]);
						if (preElement != null && preElement.OwnerPageIndex != lastLine[0].OwnerPageIndex)
						{
							XTextTableElement xTextTableElement = (XTextTableElement)preElement.GetOwnerParent(typeof(XTextTableElement), includeThis: false);
							if (xTextTableElement != null)
							{
								float num = xTextTableElement.AbsTop + xTextTableElement.Height;
								PrintPage lastPage = Pages.LastPage;
								if (num > lastPage.Top + 2f)
								{
									return false;
								}
							}
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       全局页面集合
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public PrintPageCollection GlobalPages
		{
			get
			{
				if (printPageCollection_1 == null)
				{
					return Pages;
				}
				return printPageCollection_1;
			}
			set
			{
				printPageCollection_1 = value;
			}
		}

		/// <summary>
		///       文档已经执行的排版和分页操作
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public bool PageRefreshed
		{
			get
			{
				return bool_23;
			}
			set
			{
				if (bool_23 != value)
				{
					bool_23 = value;
				}
			}
		}

		/// <summary>
		///       当前处理的文档页对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public PrintPage CurrentPage
		{
			get
			{
				return printPage_0;
			}
			set
			{
				printPage_0 = value;
			}
		}

		/// <summary>
		///       显示的页码修正值
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		[DCPublishAPI]
		public int PageIndexfix
		{
			get
			{
				return int_13;
			}
			set
			{
				int_13 = value;
			}
		}

		/// <summary>
		///       从0开始计算的全局页码数
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		public int GlobalPageIndex
		{
			get
			{
				if (CurrentPage == null || GlobalPages == null)
				{
					return 0;
				}
				return GlobalPages.IndexOf(CurrentPage);
			}
		}

		/// <summary>
		///       从0开始计算的当前打印的页面序号
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public int PageIndex
		{
			get
			{
				if (CurrentPage == null || Pages == null)
				{
					return 1;
				}
				return Pages.IndexOf(CurrentPage);
			}
			set
			{
				int num = 15;
				if (value < 0 || value > Pages.Count)
				{
					throw new ArgumentOutOfRangeException("value=" + value);
				}
				CurrentPage = Pages[value];
			}
		}

		/// <summary>
		///       最后一次绘制元素使用的在画布中的绝对坐标区域
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public Dictionary<XTextElement, PointF[]> LastDrawAbsoluteBounds
		{
			get
			{
				return dictionary_2;
			}
			set
			{
				dictionary_2 = value;
			}
		}

		/// <summary>
		///       最后一次绘制的文档元素列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlIgnore]
		[ComVisible(false)]
		[DCInternal]
		public XTextElementList ElementsRendered
		{
			get
			{
				return xtextElementList_3;
			}
			set
			{
				xtextElementList_3 = value;
			}
		}

		/// <summary>
		///       全局的最后一个内容网格线的高度
		///       </summary>
		internal float GlobalLastGridLineHeight
		{
			get
			{
				return float_6;
			}
			set
			{
				float_6 = value;
			}
		}

		/// <summary>
		///       最后一次绘制的所有文档内容的最小外切矩形
		///       </summary>
		[XmlIgnore]
		[ComVisible(false)]
		[DCInternal]
		[Browsable(false)]
		public RectangleF EnclosingBoundsForDrawContent
		{
			get
			{
				return rectangleF_0;
			}
			set
			{
				rectangleF_0 = value;
			}
		}

		/// <summary>
		///       运行时是否显示页眉下面的横线
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public bool RuntimeShowHeaderBottomLine
		{
			get
			{
				bool flag = true;
				if (Info.ShowHeaderBottomLine == DCBooleanValue.True)
				{
					return true;
				}
				if (Info.ShowHeaderBottomLine == DCBooleanValue.False)
				{
					return false;
				}
				return Options.ViewOptions.ShowHeaderBottomLine;
			}
		}

		/// <summary>
		///       扩展文本控制器 
		///       </summary>
		[ComVisible(false)]
		[DCInternal]
		[Browsable(false)]
		[XmlIgnore]
		public AdornTextManager AdornTextMan
		{
			get
			{
				if (adornTextManager_0 == null)
				{
					adornTextManager_0 = new AdornTextManager(EditorControl, this);
				}
				return adornTextManager_0;
			}
			set
			{
				adornTextManager_0 = value;
			}
		}

		/// <summary>
		///       当前受保护的文档元素信息列表
		///       </summary>
		internal GClass108 ContentProtectedInfos
		{
			get
			{
				if (gclass108_0 == null)
				{
					gclass108_0 = new GClass108();
				}
				return gclass108_0;
			}
			set
			{
				gclass108_0 = value;
			}
		}

		/// <summary>
		///       判断是否存在内容保护相关信息
		///       </summary>
		internal bool HasContentProtectedInfos => gclass108_0 != null && gclass108_0.Count > 0;

		/// <summary>
		///       用户历史记录列表
		///       </summary>
		[XmlArrayItem("History", typeof(UserHistoryInfo))]
		[DefaultValue(null)]
		[DCPublishAPI]
		public UserHistoryInfoList UserHistories
		{
			get
			{
				if (userHistoryInfoList_0 == null)
				{
					userHistoryInfoList_0 = new UserHistoryInfoList();
				}
				return userHistoryInfoList_0;
			}
			set
			{
				userHistoryInfoList_0 = value;
			}
		}

		/// <summary>
		///       当前用户信息
		///       </summary>
		[ComVisible(true)]
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		[DefaultValue(null)]
		public UserHistoryInfo CurrentUser => UserHistories.CurrentInfo;

		/// <summary>
		///       文档中是否存在表格标题行
		///       </summary>
		[Browsable(false)]
		public bool HasHeaderStyleTableRow
		{
			get
			{
				bool result = false;
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Body);
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item is XTextTableElement)
					{
						XTextTableElement xTextTableElement = (XTextTableElement)item;
						if (xTextTableElement.HasHeaderRow)
						{
							return true;
						}
					}
				}
				return result;
			}
		}

		/// <summary>
		///       页面视图方式
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public PageViewMode PageViewMode
		{
			get
			{
				if (PrintingViewMode)
				{
					return PageViewMode.Page;
				}
				if (writerControl_0 == null)
				{
					return pageViewMode_0;
				}
				return writerControl_0.InnerViewControl.RuntimeViewMode;
			}
			set
			{
				pageViewMode_0 = value;
			}
		}

		/// <summary>
		///       需要为分页线而微调内容的文档元素对象列表
		///       </summary>
		internal List<XTextContentElement> FixContentForPageLineElements
		{
			get
			{
				if (list_1 == null)
				{
					list_1 = new List<XTextContentElement>();
				}
				return list_1;
			}
		}

		/// <summary>
		///       指定的分页线的位置,仅供DCWriter内部使用。
		///       </summary>
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public float[] SpecifyPageLinePosition
		{
			get
			{
				return float_8;
			}
			set
			{
				float_8 = value;
			}
		}

		/// <summary>
		///       二进制缓存区
		///       </summary>
		[XmlIgnore]
		[ComVisible(false)]
		[DCInternal]
		[Browsable(false)]
		public BinaryContentBuffer BinaryBuffer
		{
			get
			{
				return binaryContentBuffer_0;
			}
			set
			{
				binaryContentBuffer_0 = value;
			}
		}

		/// <summary>
		///       私有数据源对象，对DCSoft.FW提供支持。
		///       </summary>
		[DCInternal]
		[ComVisible(false)]
		[XmlIgnore]
		public object PrivateDataSources
		{
			get
			{
				return object_1;
			}
			set
			{
				object_1 = value;
			}
		}

		/// <summary>
		///       获得XML格式的表单数据字典
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[ComVisible(true)]
		[DCPublishAPI]
		public string FormValuesXml
		{
			get
			{
				int num = 10;
				Hashtable formValues = FormValues;
				StringWriter stringWriter = new StringWriter();
				XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.Indentation = 1;
				xmlTextWriter.IndentChar = ' ';
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("Values");
				foreach (string key in formValues.Keys)
				{
					string text2 = (string)formValues[key];
					xmlTextWriter.WriteStartElement("Value");
					xmlTextWriter.WriteAttributeString("Name", key);
					xmlTextWriter.WriteString(text2);
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndDocument();
				xmlTextWriter.Close();
				string xmlText = stringWriter.ToString();
				return XMLHelper.CleanupXMLHeader(xmlText);
			}
		}

		/// <summary>
		///       获得文档中的表单数据字典
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(false)]
		[XmlIgnore]
		public Hashtable FormValues
		{
			get
			{
				int num = 11;
				Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
				foreach (XTextInputFieldElementBase item in GetElementsByType(typeof(XTextInputFieldElementBase)))
				{
					string name = item.Name;
					if (!string.IsNullOrEmpty(name))
					{
						if (!dictionary.ContainsKey(name))
						{
							dictionary[name] = new List<string>();
						}
						dictionary[name].Add(item.Text);
					}
				}
				foreach (XTextCheckBoxElementBase item2 in GetElementsByType(typeof(XTextCheckBoxElementBase)))
				{
					if (item2.Checked)
					{
						string name = item2.Name;
						if (!string.IsNullOrEmpty(name))
						{
							if (!dictionary.ContainsKey(name))
							{
								dictionary[name] = new List<string>();
							}
							dictionary[name].Add(item2.CheckedValue);
						}
					}
				}
				Hashtable hashtable = new Hashtable();
				foreach (string key in dictionary.Keys)
				{
					List<string> list = dictionary[key];
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < list.Count; i++)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(list[i]);
					}
					hashtable[key] = stringBuilder.ToString();
				}
				return hashtable;
			}
		}

		/// <summary>
		///       文档本地设置的排除内容的关键字列表
		///       </summary>
		/// <remarks>本属性值是保存在文档文件中的</remarks>
		[DefaultValue(null)]
		public string LocalExcludeKeywords
		{
			get
			{
				return string_20;
			}
			set
			{
				string_20 = value;
			}
		}

		/// <summary>
		///       最后一次操作产生的系统警告信息列表
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		[ComVisible(true)]
		public SystemAlertInfoList LastAlertInfos
		{
			get
			{
				if (systemAlertInfoList_0 == null)
				{
					systemAlertInfoList_0 = new SystemAlertInfoList();
				}
				return systemAlertInfoList_0;
			}
		}

		/// <summary>
		///       最后一次调用WriteDataSource()函数进行的填充数据源操作涉及的文档元素对象列表
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		[ComVisible(true)]
		[DCPublishAPI]
		[XmlIgnore]
		public XTextElementList LastElementsForWriteDataSource => xtextElementList_4;

		/// <summary>
		///       被禁止的数据源的名称
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlArrayItem("Name", typeof(string))]
		[DCInternal]
		[DefaultValue(null)]
		public List<string> DisabledParameterNames
		{
			get
			{
				return list_2;
			}
			set
			{
				list_2 = value;
			}
		}

		/// <summary>
		///       用户指定的树状数据源对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(null)]
		public DataSourceTreeDocument SpecifyDataSourceTree
		{
			get
			{
				return dataSourceTreeDocument_0;
			}
			set
			{
				dataSourceTreeDocument_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的树状数据源对象
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(null)]
		public DataSourceTreeDocument RuntimeDataSourceTree
		{
			get
			{
				if (SpecifyDataSourceTree != null)
				{
					return SpecifyDataSourceTree;
				}
				if (dataSourceTreeDocument_1 == null)
				{
					dataSourceTreeDocument_1 = new DataSourceTreeDocument();
					if (Parameters != null)
					{
						foreach (DocumentParameter parameter in Parameters)
						{
							dataSourceTreeDocument_1.AddRootNode(parameter.Name, parameter.Value);
						}
					}
					if (InnerParameters != null)
					{
						foreach (DocumentParameter innerParameter in InnerParameters)
						{
							dataSourceTreeDocument_1.AddRootNode(innerParameter.Name, innerParameter.Value);
						}
					}
				}
				return dataSourceTreeDocument_1;
			}
		}

		/// <summary>
		///       序列化参数值
		///       </summary>
		[DCInternal]
		[DefaultValue(false)]
		public bool SerializeParameterValue
		{
			get
			{
				return bool_25;
			}
			set
			{
				bool_25 = value;
			}
		}

		/// <summary>
		///       参数列表
		///       </summary>
		[XmlArray("Parameters")]
		[XmlArrayItem("Parameter", typeof(DocumentParameter))]
		[DefaultValue(null)]
		[DCPublishAPI]
		public DocumentParameterCollection Parameters
		{
			get
			{
				if (documentParameterCollection_0 == null)
				{
					documentParameterCollection_0 = new DocumentParameterCollection();
				}
				return documentParameterCollection_0;
			}
			set
			{
				documentParameterCollection_0 = value;
			}
		}

		/// <summary>
		///       内置参数列表
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentParameterCollection InnerParameters
		{
			get
			{
				int num = 0;
				if (documentParameterCollection_1 == null)
				{
					documentParameterCollection_1 = new DocumentParameterCollection();
				}
				DateTime nowDateTime = GetNowDateTime();
				documentParameterCollection_1.SetValue("Page", PageIndex);
				documentParameterCollection_1.SetValue("NumPages", Pages.Count);
				documentParameterCollection_1.SetValue("Author", Info.Author);
				documentParameterCollection_1.SetValue("Title", Info.Title);
				documentParameterCollection_1.SetValue("Date", nowDateTime.Date);
				documentParameterCollection_1.SetValue("Time", nowDateTime.TimeOfDay);
				documentParameterCollection_1.SetValue("Server", ServerObject);
				return documentParameterCollection_1;
			}
		}

		/// <summary>
		///       服务器对象
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public object ServerObject
		{
			get
			{
				return object_2;
			}
			set
			{
				object_2 = value;
			}
		}

		/// <summary>
		///       成员无效
		///       </summary>
		[Obsolete]
		[Browsable(false)]
		private new DocumentContentStyle RuntimeStyle
		{
			get
			{
				throw new NotSupportedException("Document.RuntimeStyle");
			}
		}

		/// <summary>
		///       成员无效
		///       </summary>
		[Obsolete]
		[Browsable(false)]
		private new DocumentContentStyle Style
		{
			get
			{
				throw new NotSupportedException("Document.Style");
			}
			set
			{
				throw new NotSupportedException("Document.Style");
			}
		}

		/// <summary>
		///       成员无效
		///       </summary>
		[Obsolete]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public override int StyleIndex => -1;

		/// <summary>
		///       默认字体大小
		///       </summary>
		public static float DefaultFontSize
		{
			get
			{
				return float_9;
			}
			set
			{
				float_9 = value;
			}
		}

		/// <summary>
		///       默认字体
		///       </summary>
		[Category("Appearance")]
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public XFontValue DefaultFont
		{
			get
			{
				return DefaultStyle.Font;
			}
			set
			{
				DefaultStyle.Font = value;
			}
		}

		/// <summary>
		///       文档样式容器
		///       </summary>
		[DCPublishAPI]
		public DocumentContentStyleContainer ContentStyles
		{
			get
			{
				if (documentContentStyleContainer_0 == null)
				{
					documentContentStyleContainer_0 = new DocumentContentStyleContainer();
					documentContentStyleContainer_0.Document = this;
				}
				return documentContentStyleContainer_0;
			}
			set
			{
				documentContentStyleContainer_0 = value;
				if (documentContentStyleContainer_0 != null)
				{
					documentContentStyleContainer_0.Document = this;
				}
			}
		}

		/// <summary>
		///       当前文档样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCInternal]
		public DocumentContentStyle InternalCurrentStyle
		{
			get
			{
				XTextElement currentStyleElement = CurrentStyleElement;
				if (currentStyleElement == null)
				{
					return (DocumentContentStyle)ContentStyles.Default;
				}
				return currentStyleElement.RuntimeStyle.Parent;
			}
		}

		/// <summary>
		///       获得当前文档内容样式的基准的元素对象
		///       </summary>
		[DCInternal]
		internal XTextElement CurrentStyleElement
		{
			get
			{
				if (CurrentElement == null)
				{
					return null;
				}
				XTextElement xTextElement = CurrentElement;
				XTextContentElement contentElement = xTextElement.ContentElement;
				if (CurrentContentElement.Selection.Length == 0)
				{
					XTextElement preElement = contentElement.PrivateContent.GetPreElement(xTextElement);
					if (xTextElement is XTextParagraphFlagElement && preElement is XTextParagraphFlagElement)
					{
						return xTextElement;
					}
					if (preElement != null && !(preElement is XTextParagraphFlagElement) && !(preElement is XTextTableElement))
					{
						if (preElement.Parent is XTextFieldElementBase)
						{
							XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)preElement.Parent;
							if (xTextFieldElementBase.EndElement != preElement)
							{
								xTextElement = preElement;
							}
						}
						else
						{
							xTextElement = preElement;
						}
					}
					return xTextElement;
				}
				return CurrentContentElement.Content.CurrentElement;
			}
		}

		/// <summary>
		///       编辑器中当前样式信息对象
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public CurrentContentStyleInfo CurrentStyleInfo
		{
			get
			{
				if (currentContentStyleInfo_0 == null)
				{
					currentContentStyleInfo_0 = new CurrentContentStyleInfo();
					currentContentStyleInfo_0.method_0(this);
				}
				return currentContentStyleInfo_0;
			}
			set
			{
				currentContentStyleInfo_0 = value;
			}
		}

		/// <summary>
		///       默认的文档样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public DocumentContentStyle DefaultStyle
		{
			get
			{
				return (DocumentContentStyle)ContentStyles.Default;
			}
			set
			{
				ContentStyles.Default = value;
			}
		}

		internal static string StaticRegisterCodeFileUrl
		{
			get
			{
				return _RegisterCodeFileUrl;
			}
			set
			{
				_RegisterCodeFileUrl = value;
			}
		}

		[DCPublishAPI]
		public static string StaticRegisterCode
		{
			set
			{
				_RegisterCode = value;
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public string RegisterCode
		{
			get
			{
				return null;
			}
			set
			{
				_RegisterCode = value;
				smethod_14();
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DCInternal]
		public static bool InnerLicenseViewerOnly => Class103.smethod_4().method_47();

		[DCInternal]
		public static string LimitedFunctionString
		{
			get
			{
				if (string_22 == null)
				{
					string_22 = WriterStringsCore.LimitedFunction;
					if (string.IsNullOrEmpty(string_22))
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append('功');
						stringBuilder.Append('能');
						stringBuilder.Append('受');
						stringBuilder.Append('限');
						string text = string_22 = stringBuilder.ToString();
					}
				}
				return string_22;
			}
		}

		/// <summary>
		///       DCWriter内部使用。
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public static bool IsEnableCustomLogoImage
		{
			get
			{
				GClass138 gClass = Class103.smethod_4();
				if (gClass != null && gClass.method_34() && gClass.method_44())
				{
					return true;
				}
				return int_15-- > 0;
			}
		}

		/// <summary>
		///       判断控件是否已经注册了
		///       </summary>
		internal static bool IsRegistered => Class103.smethod_4().method_34();

		/// <summary>
		///       是否是给浙江联众的授权
		///       </summary>
		internal static bool IsLZLicense
		{
			get
			{
				GClass138 gClass = Class103.smethod_4();
				if (gClass != null && gClass.method_34())
				{
					int[] array = new int[2]
					{
						32668,
						20015
					};
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append((char)(array[0] + 184));
					stringBuilder.Append((char)(array[1] + 232));
					string value = stringBuilder.ToString();
					if (gClass.method_33() != null && gClass.method_33().IndexOf(value) >= 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[XmlElement]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string FileName
		{
			get
			{
				return string_23;
			}
			set
			{
				string_23 = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		[ReadOnly(true)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlElement]
		[DefaultValue(null)]
		public string FileFormat
		{
			get
			{
				return string_24;
			}
			set
			{
				string_24 = value;
			}
		}

		/// <summary>
		///       基础URL路径
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[ReadOnly(true)]
		public string BaseUrl
		{
			get
			{
				return string_25;
			}
			set
			{
				string_25 = value;
			}
		}

		/// <summary>
		///       内部使用的一些标志。
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int InnerFlag
		{
			get
			{
				return int_16;
			}
			set
			{
				int_16 = value;
			}
		}

		/// <summary>
		///       获得未格式化的字符串
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public string XMLTextUnFormatted => GetXMLText(formatted: false);

		/// <summary>
		///       文档所有的XML字符串
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public string XMLText
		{
			get
			{
				return GetXMLText(Options.BehaviorOptions.OutputFormatedXMLSource);
			}
			set
			{
				int num = 16;
				if (string.IsNullOrEmpty(value))
				{
					Clear();
					return;
				}
				ContentSerializer contentSerializer = null;
				if (AppHost != null)
				{
					contentSerializer = AppHost.ContentSerializers.GetSerializer("xml");
				}
				if (contentSerializer == null)
				{
					contentSerializer = new XMLContentSerializer();
				}
				int num2 = value.IndexOf("<");
				if (num2 > 0)
				{
					value = value.Substring(num2);
				}
				StringReader reader = new StringReader(value);
				Load(reader, "xml");
			}
		}

		/// <summary>
		///       文档的所有的RTF文本代码
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public string RTFText
		{
			get
			{
				return GetRTFText(IncludeSelectionOnly: false);
			}
			set
			{
				int num = 0;
				if (value == null || value.IndexOf("{") < 0 || value.IndexOf("}") < 0)
				{
					Text = value;
					return;
				}
				StringReader reader = new StringReader(value);
				Load(reader, "rtf");
			}
		}

		/// <summary>
		///       文档的所有的Html文本代码
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[Browsable(false)]
		public string HtmlText
		{
			get
			{
				return GetHtmlText(IncludeSelectionOnly: false);
			}
			set
			{
				int num = 9;
				if (value == null || value.IndexOf("<") < 0 || value.IndexOf(">") < 0)
				{
					Text = value;
					return;
				}
				StringReader reader = new StringReader(value);
				Load(reader, "html");
			}
		}

		[Browsable(false)]
		public string PreviewText
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (PageSettings.RuntimeHeaderFooterDifferentFirstPage && HeaderForFirstPage != null && HeaderForFirstPage.HasContentElement)
				{
					stringBuilder.Append(HeaderForFirstPage.Text);
				}
				else if (Header.HasContentElement)
				{
					stringBuilder.Append(Header.Text);
				}
				if (Body.HasContentElement)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(Body.Text);
				}
				if (PageSettings.RuntimeHeaderFooterDifferentFirstPage && FooterForFirstPage != null && FooterForFirstPage.HasContentElement)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(FooterForFirstPage.Text);
				}
				else if (Footer.HasContentElement)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(Footer.Text);
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       文档所有的文本内容
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public override string Text
		{
			get
			{
				return Body.PrivateContent.GetInnerText();
			}
			set
			{
				Clear();
				XTextElementList xTextElementList = CreateTextElements(value, null, null);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					method_57();
					Body.Elements.Clear();
					Body.Elements.AddRange(xTextElementList);
					Body.vmethod_36(bool_22: true);
				}
			}
		}

		/// <summary>
		///       允许执行AfterLoad()功能
		///       </summary>
		internal bool EnableAfterLoad
		{
			get
			{
				return bool_29;
			}
			set
			{
				bool_29 = value;
			}
		}

		/// <summary>
		///       是否正在加载文档
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public bool IsLoadingDocument => int_17 > 0;

		/// <summary>
		///       判断是否允许触发ContentChanged事件
		///       </summary>
		/// <returns>
		/// </returns>
		internal bool EnableContentChangedEvent
		{
			get
			{
				if (!Options.BehaviorOptions.EnableContentChangedEventWhenLoadDocument && IsLoadingDocument)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       运行在WEB服务器端
		///       </summary>
		[DCInternal]
		[DefaultValue(false)]
		[XmlIgnore]
		[ComVisible(false)]
		[Browsable(false)]
		public bool RunAtWebServer
		{
			get
			{
				return bool_30;
			}
			set
			{
				bool_30 = value;
			}
		}

		/// <summary>
		///       Web客户端中的当前输入域对象
		///       </summary>
		[ComVisible(false)]
		[DefaultValue(null)]
		[XmlIgnore]
		[Browsable(false)]
		public XTextElement WebClientCurrentElement
		{
			get
			{
				if (RunAtWebServer)
				{
					return xtextElement_2;
				}
				return null;
			}
		}

		/// <summary>
		///       执行表达式函数功能事件
		///       </summary>
		[DCPublishAPI]
		public event WriterExpressionFunctionEventHandler EventExpressionFunction
		{
			add
			{
				WriterExpressionFunctionEventHandler writerExpressionFunctionEventHandler = writerExpressionFunctionEventHandler_0;
				WriterExpressionFunctionEventHandler writerExpressionFunctionEventHandler2;
				do
				{
					writerExpressionFunctionEventHandler2 = writerExpressionFunctionEventHandler;
					WriterExpressionFunctionEventHandler value2 = (WriterExpressionFunctionEventHandler)Delegate.Combine(writerExpressionFunctionEventHandler2, value);
					writerExpressionFunctionEventHandler = Interlocked.CompareExchange(ref writerExpressionFunctionEventHandler_0, value2, writerExpressionFunctionEventHandler2);
				}
				while ((object)writerExpressionFunctionEventHandler != writerExpressionFunctionEventHandler2);
			}
			remove
			{
				WriterExpressionFunctionEventHandler writerExpressionFunctionEventHandler = writerExpressionFunctionEventHandler_0;
				WriterExpressionFunctionEventHandler writerExpressionFunctionEventHandler2;
				do
				{
					writerExpressionFunctionEventHandler2 = writerExpressionFunctionEventHandler;
					WriterExpressionFunctionEventHandler value2 = (WriterExpressionFunctionEventHandler)Delegate.Remove(writerExpressionFunctionEventHandler2, value);
					writerExpressionFunctionEventHandler = Interlocked.CompareExchange(ref writerExpressionFunctionEventHandler_0, value2, writerExpressionFunctionEventHandler2);
				}
				while ((object)writerExpressionFunctionEventHandler != writerExpressionFunctionEventHandler2);
			}
		}

		/// <summary>
		///       文档内容发生改变事件,当用户修改了文档的任何内容时就会触发该事件。
		///       </summary>
		[DCPublishAPI]
		public event EventHandler DocumentContentChanged
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       文档选择状态发生改变后的事件,包括选择区域改变或插入点位置的改变。
		///       </summary>
		[DCPublishAPI]
		public event EventHandler SelectionChanged
		{
			add
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       文档选择状态正在发生改变事件
		///       </summary>
		[DCPublishAPI]
		public event SelectionChangingEventHandler SelectionChanging
		{
			add
			{
				SelectionChangingEventHandler selectionChangingEventHandler = selectionChangingEventHandler_0;
				SelectionChangingEventHandler selectionChangingEventHandler2;
				do
				{
					selectionChangingEventHandler2 = selectionChangingEventHandler;
					SelectionChangingEventHandler value2 = (SelectionChangingEventHandler)Delegate.Combine(selectionChangingEventHandler2, value);
					selectionChangingEventHandler = Interlocked.CompareExchange(ref selectionChangingEventHandler_0, value2, selectionChangingEventHandler2);
				}
				while ((object)selectionChangingEventHandler != selectionChangingEventHandler2);
			}
			remove
			{
				SelectionChangingEventHandler selectionChangingEventHandler = selectionChangingEventHandler_0;
				SelectionChangingEventHandler selectionChangingEventHandler2;
				do
				{
					selectionChangingEventHandler2 = selectionChangingEventHandler;
					SelectionChangingEventHandler value2 = (SelectionChangingEventHandler)Delegate.Remove(selectionChangingEventHandler2, value);
					selectionChangingEventHandler = Interlocked.CompareExchange(ref selectionChangingEventHandler_0, value2, selectionChangingEventHandler2);
				}
				while ((object)selectionChangingEventHandler != selectionChangingEventHandler2);
			}
		}

		/// <summary>
		///       文档加载事件
		///       </summary>
		[DCPublishAPI]
		public event EventHandler DocumentLoad
		{
			add
			{
				EventHandler eventHandler = eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       文档元素内容校验事件
		///       </summary>
		[DCPublishAPI]
		public event ElementValidatingEventHandler EventElementValidating
		{
			add
			{
				ElementValidatingEventHandler elementValidatingEventHandler = elementValidatingEventHandler_0;
				ElementValidatingEventHandler elementValidatingEventHandler2;
				do
				{
					elementValidatingEventHandler2 = elementValidatingEventHandler;
					ElementValidatingEventHandler value2 = (ElementValidatingEventHandler)Delegate.Combine(elementValidatingEventHandler2, value);
					elementValidatingEventHandler = Interlocked.CompareExchange(ref elementValidatingEventHandler_0, value2, elementValidatingEventHandler2);
				}
				while ((object)elementValidatingEventHandler != elementValidatingEventHandler2);
			}
			remove
			{
				ElementValidatingEventHandler elementValidatingEventHandler = elementValidatingEventHandler_0;
				ElementValidatingEventHandler elementValidatingEventHandler2;
				do
				{
					elementValidatingEventHandler2 = elementValidatingEventHandler;
					ElementValidatingEventHandler value2 = (ElementValidatingEventHandler)Delegate.Remove(elementValidatingEventHandler2, value);
					elementValidatingEventHandler = Interlocked.CompareExchange(ref elementValidatingEventHandler_0, value2, elementValidatingEventHandler2);
				}
				while ((object)elementValidatingEventHandler != elementValidatingEventHandler2);
			}
		}

		/// <summary>
		///       元素绘制前事件
		///       </summary>
		[DCPublishAPI]
		public event ElementPaintEventHandler EventBeforePaintElement
		{
			add
			{
				ElementPaintEventHandler elementPaintEventHandler = elementPaintEventHandler_0;
				ElementPaintEventHandler elementPaintEventHandler2;
				do
				{
					elementPaintEventHandler2 = elementPaintEventHandler;
					ElementPaintEventHandler value2 = (ElementPaintEventHandler)Delegate.Combine(elementPaintEventHandler2, value);
					elementPaintEventHandler = Interlocked.CompareExchange(ref elementPaintEventHandler_0, value2, elementPaintEventHandler2);
				}
				while ((object)elementPaintEventHandler != elementPaintEventHandler2);
			}
			remove
			{
				ElementPaintEventHandler elementPaintEventHandler = elementPaintEventHandler_0;
				ElementPaintEventHandler elementPaintEventHandler2;
				do
				{
					elementPaintEventHandler2 = elementPaintEventHandler;
					ElementPaintEventHandler value2 = (ElementPaintEventHandler)Delegate.Remove(elementPaintEventHandler2, value);
					elementPaintEventHandler = Interlocked.CompareExchange(ref elementPaintEventHandler_0, value2, elementPaintEventHandler2);
				}
				while ((object)elementPaintEventHandler != elementPaintEventHandler2);
			}
		}

		/// <summary>
		///       元素绘制前事件
		///       </summary>
		[DCPublishAPI]
		public event ElementPaintEventHandler EventAfterPaintElement
		{
			add
			{
				ElementPaintEventHandler elementPaintEventHandler = elementPaintEventHandler_1;
				ElementPaintEventHandler elementPaintEventHandler2;
				do
				{
					elementPaintEventHandler2 = elementPaintEventHandler;
					ElementPaintEventHandler value2 = (ElementPaintEventHandler)Delegate.Combine(elementPaintEventHandler2, value);
					elementPaintEventHandler = Interlocked.CompareExchange(ref elementPaintEventHandler_1, value2, elementPaintEventHandler2);
				}
				while ((object)elementPaintEventHandler != elementPaintEventHandler2);
			}
			remove
			{
				ElementPaintEventHandler elementPaintEventHandler = elementPaintEventHandler_1;
				ElementPaintEventHandler elementPaintEventHandler2;
				do
				{
					elementPaintEventHandler2 = elementPaintEventHandler;
					ElementPaintEventHandler value2 = (ElementPaintEventHandler)Delegate.Remove(elementPaintEventHandler2, value);
					elementPaintEventHandler = Interlocked.CompareExchange(ref elementPaintEventHandler_1, value2, elementPaintEventHandler2);
				}
				while ((object)elementPaintEventHandler != elementPaintEventHandler2);
			}
		}

		/// <summary>
		///       开始打印事件
		///       </summary>
		[DCPublishAPI]
		public event WriterPrintEventHandler EventBeginPrint
		{
			add
			{
				WriterPrintEventHandler writerPrintEventHandler = writerPrintEventHandler_0;
				WriterPrintEventHandler writerPrintEventHandler2;
				do
				{
					writerPrintEventHandler2 = writerPrintEventHandler;
					WriterPrintEventHandler value2 = (WriterPrintEventHandler)Delegate.Combine(writerPrintEventHandler2, value);
					writerPrintEventHandler = Interlocked.CompareExchange(ref writerPrintEventHandler_0, value2, writerPrintEventHandler2);
				}
				while ((object)writerPrintEventHandler != writerPrintEventHandler2);
			}
			remove
			{
				WriterPrintEventHandler writerPrintEventHandler = writerPrintEventHandler_0;
				WriterPrintEventHandler writerPrintEventHandler2;
				do
				{
					writerPrintEventHandler2 = writerPrintEventHandler;
					WriterPrintEventHandler value2 = (WriterPrintEventHandler)Delegate.Remove(writerPrintEventHandler2, value);
					writerPrintEventHandler = Interlocked.CompareExchange(ref writerPrintEventHandler_0, value2, writerPrintEventHandler2);
				}
				while ((object)writerPrintEventHandler != writerPrintEventHandler2);
			}
		}

		/// <summary>
		///       打印时查询页面设置事件
		///       </summary>
		[DCPublishAPI]
		public event WriterPrintQueryPageSettingsEventHandler EventPrintQueryPageSettings
		{
			add
			{
				WriterPrintQueryPageSettingsEventHandler writerPrintQueryPageSettingsEventHandler = writerPrintQueryPageSettingsEventHandler_0;
				WriterPrintQueryPageSettingsEventHandler writerPrintQueryPageSettingsEventHandler2;
				do
				{
					writerPrintQueryPageSettingsEventHandler2 = writerPrintQueryPageSettingsEventHandler;
					WriterPrintQueryPageSettingsEventHandler value2 = (WriterPrintQueryPageSettingsEventHandler)Delegate.Combine(writerPrintQueryPageSettingsEventHandler2, value);
					writerPrintQueryPageSettingsEventHandler = Interlocked.CompareExchange(ref writerPrintQueryPageSettingsEventHandler_0, value2, writerPrintQueryPageSettingsEventHandler2);
				}
				while ((object)writerPrintQueryPageSettingsEventHandler != writerPrintQueryPageSettingsEventHandler2);
			}
			remove
			{
				WriterPrintQueryPageSettingsEventHandler writerPrintQueryPageSettingsEventHandler = writerPrintQueryPageSettingsEventHandler_0;
				WriterPrintQueryPageSettingsEventHandler writerPrintQueryPageSettingsEventHandler2;
				do
				{
					writerPrintQueryPageSettingsEventHandler2 = writerPrintQueryPageSettingsEventHandler;
					WriterPrintQueryPageSettingsEventHandler value2 = (WriterPrintQueryPageSettingsEventHandler)Delegate.Remove(writerPrintQueryPageSettingsEventHandler2, value);
					writerPrintQueryPageSettingsEventHandler = Interlocked.CompareExchange(ref writerPrintQueryPageSettingsEventHandler_0, value2, writerPrintQueryPageSettingsEventHandler2);
				}
				while ((object)writerPrintQueryPageSettingsEventHandler != writerPrintQueryPageSettingsEventHandler2);
			}
		}

		/// <summary>
		///       打印页面事件
		///       </summary>
		[DCPublishAPI]
		public event WriterPrintPageEventHandler EventPrintPage
		{
			add
			{
				WriterPrintPageEventHandler writerPrintPageEventHandler = writerPrintPageEventHandler_0;
				WriterPrintPageEventHandler writerPrintPageEventHandler2;
				do
				{
					writerPrintPageEventHandler2 = writerPrintPageEventHandler;
					WriterPrintPageEventHandler value2 = (WriterPrintPageEventHandler)Delegate.Combine(writerPrintPageEventHandler2, value);
					writerPrintPageEventHandler = Interlocked.CompareExchange(ref writerPrintPageEventHandler_0, value2, writerPrintPageEventHandler2);
				}
				while ((object)writerPrintPageEventHandler != writerPrintPageEventHandler2);
			}
			remove
			{
				WriterPrintPageEventHandler writerPrintPageEventHandler = writerPrintPageEventHandler_0;
				WriterPrintPageEventHandler writerPrintPageEventHandler2;
				do
				{
					writerPrintPageEventHandler2 = writerPrintPageEventHandler;
					WriterPrintPageEventHandler value2 = (WriterPrintPageEventHandler)Delegate.Remove(writerPrintPageEventHandler2, value);
					writerPrintPageEventHandler = Interlocked.CompareExchange(ref writerPrintPageEventHandler_0, value2, writerPrintPageEventHandler2);
				}
				while ((object)writerPrintPageEventHandler != writerPrintPageEventHandler2);
			}
		}

		/// <summary>
		///       结束打印事件
		///       </summary>
		[DCPublishAPI]
		public event WriterPrintEventHandler EventEndPrint
		{
			add
			{
				WriterPrintEventHandler writerPrintEventHandler = writerPrintEventHandler_1;
				WriterPrintEventHandler writerPrintEventHandler2;
				do
				{
					writerPrintEventHandler2 = writerPrintEventHandler;
					WriterPrintEventHandler value2 = (WriterPrintEventHandler)Delegate.Combine(writerPrintEventHandler2, value);
					writerPrintEventHandler = Interlocked.CompareExchange(ref writerPrintEventHandler_1, value2, writerPrintEventHandler2);
				}
				while ((object)writerPrintEventHandler != writerPrintEventHandler2);
			}
			remove
			{
				WriterPrintEventHandler writerPrintEventHandler = writerPrintEventHandler_1;
				WriterPrintEventHandler writerPrintEventHandler2;
				do
				{
					writerPrintEventHandler2 = writerPrintEventHandler;
					WriterPrintEventHandler value2 = (WriterPrintEventHandler)Delegate.Remove(writerPrintEventHandler2, value);
					writerPrintEventHandler = Interlocked.CompareExchange(ref writerPrintEventHandler_1, value2, writerPrintEventHandler2);
				}
				while ((object)writerPrintEventHandler != writerPrintEventHandler2);
			}
		}

		[ComVisible(true)]
		public string PBSaveToString(ref string format)
		{
			string format2 = (format == null) ? null : string.Copy(format);
			string text = SaveToString(format2);
			GC.KeepAlive(format);
			GC.KeepAlive(text);
			return text;
		}

		[ComVisible(true)]
		public XTextElementList PBGetElementsByTypeName(ref string name)
		{
			string elementTypeName = (name == null) ? null : string.Copy(name);
			XTextElementList elementsByTypeName = GetElementsByTypeName(elementTypeName);
			GC.KeepAlive(name);
			return elementsByTypeName;
		}

		[ComVisible(true)]
		public XTextElementList PBGetElementsById(ref string string_26)
		{
			string text = (string_26 == null) ? null : string.Copy(string_26);
			XTextElementList elementsById = GetElementsById(text);
			GC.KeepAlive(string_26);
			return elementsById;
		}

		[ComVisible(true)]
		public XTextElementList PBGetElementsByName(ref string name)
		{
			string name2 = (name == null) ? null : string.Copy(name);
			XTextElementList elementsByName = GetElementsByName(name2);
			GC.KeepAlive(name);
			return elementsByName;
		}

		[ComVisible(true)]
		public XTextElement PBGetElementById(ref string string_26)
		{
			string text = (string_26 == null) ? null : string.Copy(string_26);
			XTextElement elementById = GetElementById(text);
			GC.KeepAlive(string_26);
			return elementById;
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
		public bool PBSetElementTextByID(ref string string_26, ref string text)
		{
			string string_27 = (string_26 == null) ? null : string.Copy(string_26);
			string text2 = (text == null) ? null : string.Copy(text);
			bool result = SetElementTextByID(string_27, text2);
			GC.Collect();
			GC.KeepAlive(string_26);
			GC.KeepAlive(text);
			return result;
		}

		[ComVisible(true)]
		public void PBLoadFromString(ref string text, ref string format)
		{
			string text2 = (text == null) ? null : string.Copy(text);
			string format2 = (format == null) ? null : string.Copy(format);
			LoadFromString(text2, format2);
			GC.Collect();
			GC.WaitForFullGCComplete();
			if (text != null)
			{
				GC.KeepAlive(text);
			}
			if (format != null)
			{
				GC.KeepAlive(format);
			}
		}

		[DCInternal]
		public void method_26(WriterExpressionFunctionEventArgs writerExpressionFunctionEventArgs_0)
		{
			int num = 8;
			if (Options.BehaviorOptions.EnableScript && ScriptEngine != null)
			{
				MethodInfo scriptMethod = ScriptEngine.GetScriptMethod(writerExpressionFunctionEventArgs_0.FunctionName);
				if (scriptMethod != null)
				{
					try
					{
						ParameterInfo[] parameters = scriptMethod.GetParameters();
						object[] array = null;
						if (parameters != null && parameters.Length > 0)
						{
							array = new object[parameters.Length];
							for (int i = 0; i < array.Length; i++)
							{
								if (i < writerExpressionFunctionEventArgs_0.ParametersCount)
								{
									object obj = array[i] = ValueTypeHelper.ConvertTo(writerExpressionFunctionEventArgs_0.GetParameterValue(i), parameters[i].ParameterType);
								}
								else
								{
									array[i] = ValueTypeHelper.GetDefaultValue(parameters[i].ParameterType);
								}
							}
						}
						object obj3 = writerExpressionFunctionEventArgs_0.Result = scriptMethod.Invoke(null, array);
						writerExpressionFunctionEventArgs_0.Handled = true;
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
						ScriptEngine.Errors.Add(new ScriptError(ScriptEngine as XVBAEngine, ScriptErrorStyle.Runtime, scriptMethod.Name, (ex.InnerException == null) ? ex : ex.InnerException));
					}
					return;
				}
			}
			method_46("EventExpressionFunction", new object[1]
			{
				writerExpressionFunctionEventArgs_0
			});
			if (writerExpressionFunctionEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerExpressionFunctionEventHandler_0(this, writerExpressionFunctionEventArgs_0);
				}
				else
				{
					try
					{
						writerExpressionFunctionEventHandler_0(this, writerExpressionFunctionEventArgs_0);
					}
					catch (Exception ex)
					{
						method_39(writerExpressionFunctionEventArgs_0.Element, ex, "EventExpressionFunction");
					}
				}
			}
		}

		/// <summary>
		///       触发文档内容发生改变事件.本方法内部还会调用文档对象绑定的编辑器控件的OnDocumentContentChanged方法。
		///       </summary>
		public void OnDocumentContentChanged()
		{
			int num = 9;
			if (UIIsUpdating)
			{
				return;
			}
			if (EnableContentChangedEvent)
			{
				method_46("DocumentContentChanged", new object[2]
				{
					this,
					null
				});
			}
			if (EditorControl != null)
			{
				EditorControl.CommandStateNeedRefreshFlag = true;
			}
			if (dictionary_1 != null)
			{
				dictionary_1.Clear();
			}
			if (EnableContentChangedEvent && Options.BehaviorOptions.EnableScript && vmethod_1(bool_32: false) && ScriptEngine != null)
			{
				ScriptEngine.ExecuteSub(this, "Document_DocumentContentChanged");
			}
			xtextElement_0 = null;
			if (EnableContentChangedEvent)
			{
				if (EditorControl != null)
				{
					EditorControl.OnDocumentContentChanged(EventArgs.Empty);
					method_75();
				}
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。文档内容状态发生改变处理,本方法还会调用文档对象绑定的编辑器控件的OnSelectionChanged方法。
		///       </summary>
		[DCInternal]
		public void OnSelectionChanged()
		{
			int num = 15;
			if (UIIsUpdating)
			{
				return;
			}
			LastSearchStartPosition = -1;
			if (EditorControl != null)
			{
				EditorControl.CommandStateNeedRefreshFlag = true;
				XTextContainerElement container = null;
				int elementIndex = 0;
				Content.GetCurrentPositionInfo(out container, out elementIndex);
				XTextElement dragableElement = null;
				while (container != null)
				{
					if (!(container is XTextTableElement) || !DocumentControler.CanModify(container))
					{
						container = container.Parent;
						continue;
					}
					dragableElement = container;
					break;
				}
				EditorControl.DragableElement = dragableElement;
			}
			for (XTextElement xTextElement = CurrentElement; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				if (AdornTextMan != null && AdornTextMan.method_1(xTextElement))
				{
					method_69(xTextElement);
				}
			}
			if (Options.BehaviorOptions.EnableScript && vmethod_1(bool_32: false) && ScriptEngine != null)
			{
				ScriptEngine.ExecuteSub(this, "Document_SelectionChanged");
			}
			_ = CurrentContentElement;
			if (EditorControl != null)
			{
				EditorControl.OnSelectionChanged(EventArgs.Empty);
				if (EditorControl.InnerViewControl.vmethod_26())
				{
					EditorControl.InnerViewControl.OnCurrentPageChanged();
				}
			}
			method_46("SelectionChanged", new object[2]
			{
				this,
				EventArgs.Empty
			});
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, EventArgs.Empty);
			}
		}

		private void method_27()
		{
			if (EditorControl != null)
			{
				EditorControl.OnSelectionChanged(EventArgs.Empty);
			}
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, EventArgs.Empty);
			}
		}

		internal void method_28(SelectionChangingEventArgs selectionChangingEventArgs_0)
		{
			int num = 8;
			if (Options.ViewOptions.AdornTextVisibility == DCAdornTextVisibility.Actived)
			{
				for (XTextElement xTextElement = CurrentElement; xTextElement != null; xTextElement = xTextElement.Parent)
				{
					if (AdornTextMan.method_3(xTextElement))
					{
						method_69(xTextElement);
					}
				}
			}
			_ = CurrentContentElement;
			if (EditorControl != null)
			{
				EditorControl.vmethod_50(selectionChangingEventArgs_0);
			}
			method_46("SelectionChanging", new object[2]
			{
				this,
				selectionChangingEventArgs_0
			});
			if (selectionChangingEventHandler_0 != null)
			{
				selectionChangingEventHandler_0(this, selectionChangingEventArgs_0);
			}
		}

		public void method_29(EventArgs eventArgs_0)
		{
			method_46("DocumentLoad", new object[2]
			{
				this,
				eventArgs_0
			});
			if (eventHandler_2 != null)
			{
				eventHandler_2(this, eventArgs_0);
			}
		}

		internal void method_30(ElementValidatingEventArgs elementValidatingEventArgs_0)
		{
			method_46("EventElementValidating", new object[2]
			{
				this,
				elementValidatingEventArgs_0
			});
			if (elementValidatingEventArgs_0.Handled)
			{
				return;
			}
			if (elementValidatingEventHandler_0 != null)
			{
				elementValidatingEventHandler_0(this, elementValidatingEventArgs_0);
				if (elementValidatingEventArgs_0.Handled)
				{
					return;
				}
			}
			if (EditorControl != null)
			{
				EditorControl.vmethod_10(elementValidatingEventArgs_0);
			}
		}

		internal void method_31(ElementPaintEventArgs elementPaintEventArgs_0)
		{
			method_46("EventBeforePaintElement", new object[2]
			{
				this,
				elementPaintEventArgs_0
			});
			if (elementPaintEventHandler_0 != null)
			{
				elementPaintEventHandler_0(this, elementPaintEventArgs_0);
			}
		}

		internal void method_32(ElementPaintEventArgs elementPaintEventArgs_0)
		{
			method_46("EventAfterPaintElement", new object[2]
			{
				this,
				elementPaintEventArgs_0
			});
			if (elementPaintEventHandler_1 != null)
			{
				elementPaintEventHandler_1(this, elementPaintEventArgs_0);
			}
		}

		internal void method_33(WriterPrintEventEventArgs writerPrintEventEventArgs_0)
		{
			method_46("EventBeginPrint", new object[2]
			{
				this,
				writerPrintEventEventArgs_0
			});
			if (writerPrintEventHandler_0 != null)
			{
				writerPrintEventHandler_0(this, writerPrintEventEventArgs_0);
			}
			if (EditorControl != null && EditorControl.method_4(this))
			{
				EditorControl.method_51(writerPrintEventEventArgs_0);
			}
		}

		internal void method_34(WriterPrintQueryPageSettingsEventArgs writerPrintQueryPageSettingsEventArgs_0)
		{
			method_46("EventPrintQueryPageSettings", new object[2]
			{
				this,
				writerPrintQueryPageSettingsEventArgs_0
			});
			if (writerPrintQueryPageSettingsEventHandler_0 != null)
			{
				writerPrintQueryPageSettingsEventHandler_0(this, writerPrintQueryPageSettingsEventArgs_0);
			}
			if (EditorControl != null && EditorControl.method_4(this))
			{
				EditorControl.method_52(writerPrintQueryPageSettingsEventArgs_0);
			}
		}

		internal void method_35(WriterPrintPageEventEventArgs writerPrintPageEventEventArgs_0)
		{
			method_46("EventPrintPage", new object[2]
			{
				this,
				writerPrintPageEventEventArgs_0
			});
			if (writerPrintPageEventHandler_0 != null)
			{
				writerPrintPageEventHandler_0(this, writerPrintPageEventEventArgs_0);
			}
			if (EditorControl != null && EditorControl.method_4(this))
			{
				EditorControl.method_53(writerPrintPageEventEventArgs_0);
			}
		}

		internal void method_36(WriterPrintEventEventArgs writerPrintEventEventArgs_0)
		{
			method_46("EventEndPrint", new object[2]
			{
				this,
				writerPrintEventEventArgs_0
			});
			if (writerPrintEventHandler_1 != null)
			{
				writerPrintEventHandler_1(this, writerPrintEventEventArgs_0);
			}
			if (EditorControl != null && EditorControl.method_4(this))
			{
				EditorControl.method_54(writerPrintEventEventArgs_0);
			}
		}

		private void method_37(WriterEventArgs writerEventArgs_0)
		{
			if (EventAfterLoadRawDOM != null)
			{
				EventAfterLoadRawDOM(this, writerEventArgs_0);
			}
			if (EditorControl != null)
			{
				EditorControl.OnEventAfterLoadRawDOM(writerEventArgs_0);
			}
		}

		static XTextDocument()
		{
			int_10 = 0;
			float_9 = 12f;
			genum13_0 = null;
			_MULSP = 0;
			bool_27 = false;
			_RegisterCodeFileUrl = GClass144.smethod_0("DCSoft.Writer");
			_RegisterCode = null;
			string_21 = null;
			timer_0 = null;
			bool_28 = false;
			string_22 = null;
			_LicenseLevel = -1;
			genum13_1 = GEnum13.const_2;
			int_15 = 5;
			GClass380.smethod_0("AboutWebControl");
			GClass380.smethod_0("PromptDevelopmentDog_Name");
			GClass380.smethod_0("DCLicenseTo_Name");
			GClass380.smethod_0("DCName");
			GClass380.smethod_0("DCWriterProductName");
			GClass380.smethod_0("GridLinePreviewText");
			GClass380.smethod_0("RegisterWithBitchFail");
			GClass380.smethod_0("UnRegisterFormTitlePrefix");
			GClass380.smethod_0("UnRegisterPageTitle");
			GClass380.smethod_0("UnRegisterTitle");
			GClass380.smethod_0("LoadLicenseFromDog");
			GClass380.smethod_0("PromptRegister");
			GClass380.smethod_0("RegiserFail");
			GClass380.smethod_0("RegisterOK");
			GClass380.smethod_0("RegisterTitle_UserName");
			GClass380.smethod_0("Command_Register");
			GClass380.smethod_0("DCSoftTestVersion");
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument()
		{
			WriterUtils.smethod_6();
			base.OwnerDocument = this;
			base.Parent = this;
			AppendChildElement(new XTextDocumentHeaderElement());
			AppendChildElement(new XTextDocumentBodyElement());
			AppendChildElement(new XTextDocumentFooterElement());
			xtextDocumentUndoList_0 = new XTextDocumentUndoList(this);
			ContentStyles.Default.Spacing = 1f;
			ContentStyles.Default.LineSpacing = 4f;
			ContentStyles.Default.SpacingBeforeParagraph = 9f;
			ContentStyles.Default.FontSize = float_9;
		}

		[DCInternal]
		public AppErrorInfo method_38()
		{
			AppErrorInfo result = appErrorInfo_0;
			appErrorInfo_0 = null;
			return result;
		}

		internal void method_39(XTextElement xtextElement_3, Exception exception_0, string string_26)
		{
			if (WriterUtils.smethod_31(exception_0))
			{
				return;
			}
			appErrorInfo_0 = new AppErrorInfo((xtextElement_3 == null) ? this : xtextElement_3, exception_0, string_26);
			switch (Options.BehaviorOptions.AppErrorHandleMode)
			{
			case AppErrorHandleModeConsts.None:
			case AppErrorHandleModeConsts.Ignore:
				break;
			case AppErrorHandleModeConsts.ThrowException:
				throw exception_0;
			case AppErrorHandleModeConsts.ShowMessge:
				if (EditorControl != null && EditorControl.UITools != null)
				{
					EditorControl.UITools.ShowErrorMessageBox(EditorControl, exception_0.Message);
				}
				break;
			case AppErrorHandleModeConsts.ShowDetailMessage:
				if (EditorControl != null && EditorControl.UITools != null)
				{
					EditorControl.UITools.ShowErrorMessageBox(EditorControl, exception_0.ToString());
				}
				break;
			}
		}

		/// <summary>
		///       重新设置OutlineNodes属性值
		///       </summary>
		[DCPublishAPI]
		public void ResetOutlineNodes()
		{
			documentOutlineNodeList_0 = null;
		}

		[DCInternal]
		public void method_40(DomReadyStates domReadyStates_1)
		{
			domReadyStates_0 = domReadyStates_1;
		}

		[DCInternal]
		public void method_41(XTextElementList xtextElementList_5)
		{
			if (xtextElementList_5 != null && Options.BehaviorOptions.RemoveLastParagraphFlagWhenInsertDocument && xtextElementList_5.LastElement is XTextParagraphFlagElement)
			{
				xtextElementList_5.RemoveAt(xtextElementList_5.Count - 1);
			}
		}

		internal string method_42(XTextElement xtextElement_3)
		{
			int num = 15;
			if (xtextElement_3 == null)
			{
				return null;
			}
			if (xtextElement_3 is XTextCharElement)
			{
				return null;
			}
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<string, XTextElement>();
			}
			string text = xtextElement_3.ID;
			if (string.IsNullOrEmpty(text))
			{
				text = "dcid" + Convert.ToString(int_10++);
			}
			if (dictionary_0.ContainsKey(text))
			{
				XTextElement xTextElement = dictionary_0[text];
				if (xTextElement != xtextElement_3)
				{
					text = "dcid" + Convert.ToString(int_10++);
					dictionary_0[text] = xtextElement_3;
				}
			}
			else
			{
				dictionary_0[text] = xtextElement_3;
			}
			if (text == null)
			{
				text = string.Empty;
			}
			xtextElement_3.ID = text;
			return text;
		}

		internal void method_43()
		{
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Elements);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement)
				{
					((XTextContainerElement)item).InnerPrintedFlag = false;
				}
			}
		}

		internal void method_44()
		{
			if (gclass123_0 != null)
			{
				gclass123_0.method_3();
			}
			if (ginterface7_0 != null)
			{
				ginterface7_0.imethod_0();
			}
		}

		/// <summary>
		///       修正文档对象模型
		///       </summary>
		public override void FixDomState()
		{
			method_44();
			if (!bool_19)
			{
				return;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			base.FixDomState();
			XTextDocumentBodyElement body = Body;
			for (int num = Elements.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = Elements[num];
				if (xTextElement is XTextDocumentContentElement)
				{
					((XTextDocumentContentElement)xTextElement).method_55();
				}
				else
				{
					Elements.method_15(num);
					body.Elements.method_13(0, xTextElement);
					xTextElement.SetParentRaw(body);
					xTextElement.method_5(this);
				}
			}
			if (documentCommentList_1 != null)
			{
				Comments.FixDomState();
				foreach (DocumentComment comment in Comments)
				{
					comment.Document = this;
				}
			}
			ContentStyles.Document = this;
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		public IDocumentScriptEngine method_45()
		{
			if (!smethod_13(GEnum6.const_124))
			{
				return null;
			}
			return AppHost.Tools.CreateDocumentScriptEngine(this);
		}

		/// <summary>
		///       执行脚本中的方法
		///       </summary>
		/// <param name="methodName">方法名</param>
		public void ExecuteScriptSub(string methodName)
		{
			if (ScriptEngine != null)
			{
				ScriptEngine.ExecuteSub(this, methodName);
			}
		}

		/// <summary>
		///       重置脚本引擎
		///       </summary>
		public void ResetScriptEngine()
		{
			if (idocumentScriptEngine_0 != null)
			{
				idocumentScriptEngine_0.Dispose();
				idocumentScriptEngine_0 = null;
			}
		}

		/// <summary>
		///       获得调试信息文本
		///       </summary>
		/// <returns>文本</returns>
		[DCPublishAPI]
		[DCInternal]
		public string GetDebugText()
		{
			int num = 5;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Title:" + Info.Title);
			stringBuilder.AppendLine("FileName:" + FileName);
			stringBuilder.AppendLine("Body Elements:" + ((Body.Elements == null) ? "NULL" : Body.Elements.Count.ToString()));
			string text = BodyText;
			if (text != null && text.Length > 100)
			{
				text = text.Substring(0, 100);
				text = text.Replace("\r", " ");
				text = text.Replace("\n", " ");
			}
			stringBuilder.AppendLine("Body XElements:" + ((Body.ElementsForSerialize == null) ? "NULL" : Body.ElementsForSerialize.Count.ToString()));
			stringBuilder.AppendLine("Body Text:" + text);
			stringBuilder.AppendLine("Parameters:" + Parameters.Count);
			return stringBuilder.ToString();
		}

		/// <summary>
		///       启动VBA脚本引擎
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		public bool StartScriptEngine()
		{
			if (ScriptEngine != null)
			{
				return ScriptEngine.Start();
			}
			return false;
		}

		[Browsable(false)]
		[DCInternal]
		public override bool vmethod_1(bool bool_32)
		{
			if (!string.IsNullOrEmpty(string_18))
			{
				return true;
			}
			return base.vmethod_1(bool_32);
		}

		internal void method_46(string string_26, object[] object_3)
		{
			if (Options.BehaviorOptions.EnableScript && vmethod_1(bool_32: false) && ScriptEngine != null)
			{
				ScriptEngine.RaiseDocumentEventHandler(string_26, object_3);
			}
		}

		internal void method_47(XTextElement xtextElement_3, string string_26, object[] object_3)
		{
			if (Options.BehaviorOptions.EnableScript && vmethod_1(bool_32: false) && ScriptEngine != null)
			{
				ScriptEngine.RaiseElementEventHandler(xtextElement_3, string_26, object_3);
			}
		}

		/// <summary>
		///       获得指定文档元素的属性
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="attributeName">属性名称</param>
		/// <returns>属性值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetElementAttribute(string string_26, string attributeName)
		{
			return GetElementById(string_26)?.GetAttribute(attributeName);
		}

		/// <summary>
		///       设置文档元素的属性值
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="attributeName">属性名</param>
		/// <param name="attributeValue">属性值</param>
		/// <returns>操作是否完成</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetElementAttribute(string string_26, string attributeName, string attributeValue)
		{
			return GetElementById(string_26)?.SetAttribute(attributeName, attributeValue) ?? false;
		}

		/// <summary>
		///       添加子元素
		///       </summary>
		/// <param name="element">新添加的元素</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override bool AppendChildElement(XTextElement element)
		{
			if (element is XTextDocumentContentElement)
			{
				return base.AppendChildElement(element);
			}
			return Body.AppendChildElement(element);
		}

		/// <summary>
		///        分配新的文档元素编号
		///       </summary>
		/// <param name="prefix">编号前缀</param>
		/// <param name="element">元素对象</param>
		/// <returns>是否修改了元素ID属性值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool AllocElementID(string prefix, XTextElement element)
		{
			if (element != null)
			{
				if (string.IsNullOrEmpty(prefix))
				{
					prefix = element.ElementIDPrefix;
				}
				if (string.IsNullOrEmpty(element.ID))
				{
					element.ID = AllocElementID(prefix, element.GetType());
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       分配新的文档元素编号
		///       </summary>
		/// <param name="prefix">编号前缀</param>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>分配的编号</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public string AllocElementID(string prefix, Type elementType)
		{
			int num = 18;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (string.IsNullOrEmpty(prefix))
			{
				prefix = "e";
			}
			XTextElementList elementsByType = GetElementsByType(elementType);
			int num2 = elementsByType.Count + 1;
			string text;
			bool flag;
			do
			{
				text = prefix + num2;
				flag = false;
				foreach (XTextElement item in elementsByType)
				{
					if (string.Compare(item.ID, text, ignoreCase: true) == 0)
					{
						flag = true;
						num2++;
						break;
					}
				}
			}
			while (flag);
			return text;
		}

		[DCInternal]
		internal char method_48(XTextCharElement xtextCharElement_0)
		{
			return xtextCharElement_0.CharValue;
		}

		/// <summary>
		///       更新文档元素的状态，包括OwernDocument、Parent、Content、PrivateContent属性
		///       </summary>
		[DCInternal]
		public void UpdateElementState()
		{
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			domTreeNodeEnumerable.ExcludeParagraphFlag = false;
			domTreeNodeEnumerable.ExcludeCharElement = false;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (domTreeNodeEnumerable.CurrentParent is XTextContainerElement)
				{
					item.Parent = (XTextContainerElement)domTreeNodeEnumerable.CurrentParent;
				}
				item.OwnerDocument = this;
				if (item is XTextContentElement)
				{
					((XTextContentElement)item).vmethod_36(bool_22: false);
				}
				else if (item is XTextTableElement)
				{
					((XTextTableElement)item).method_35();
				}
			}
		}

		private void method_49()
		{
			if (xtextElementList_1 != null && xtextElementList_1.Count > 0)
			{
				method_18(bool_17: false);
			}
			XTextElementList elements = Elements;
			if (elements.Count != 5 || !(elements[0] is XTextDocumentHeaderElement) || !(elements[1] is XTextDocumentBodyElement) || !(elements[2] is XTextDocumentFooterElement) || !(elements[3] is XTextDocumentHeaderForFirstPageElement) || !(elements[4] is XTextDocumentFooterForFirstPageElement))
			{
				XTextDocumentHeaderForFirstPageElement xTextDocumentHeaderForFirstPageElement = (XTextDocumentHeaderForFirstPageElement)elements.method_5(typeof(XTextDocumentHeaderForFirstPageElement));
				if (xTextDocumentHeaderForFirstPageElement == null)
				{
					xTextDocumentHeaderForFirstPageElement = new XTextDocumentHeaderForFirstPageElement();
					xTextDocumentHeaderForFirstPageElement.Parent = this;
					xTextDocumentHeaderForFirstPageElement.OwnerDocument = this;
				}
				XTextDocumentFooterForFirstPageElement xTextDocumentFooterForFirstPageElement = (XTextDocumentFooterForFirstPageElement)elements.method_5(typeof(XTextDocumentFooterForFirstPageElement));
				if (xTextDocumentFooterForFirstPageElement == null)
				{
					xTextDocumentFooterForFirstPageElement = new XTextDocumentFooterForFirstPageElement();
					xTextDocumentFooterForFirstPageElement.Parent = this;
					xTextDocumentFooterForFirstPageElement.OwnerDocument = this;
				}
				XTextDocumentHeaderElement xTextDocumentHeaderElement = (XTextDocumentHeaderElement)elements.method_5(typeof(XTextDocumentHeaderElement));
				if (xTextDocumentHeaderElement == null)
				{
					xTextDocumentHeaderElement = new XTextDocumentHeaderElement();
					xTextDocumentHeaderElement.Parent = this;
					xTextDocumentHeaderElement.OwnerDocument = this;
				}
				XTextDocumentFooterElement xTextDocumentFooterElement = (XTextDocumentFooterElement)elements.method_5(typeof(XTextDocumentFooterElement));
				if (xTextDocumentFooterElement == null)
				{
					xTextDocumentFooterElement = new XTextDocumentFooterElement();
					xTextDocumentFooterElement.Parent = this;
					xTextDocumentFooterElement.OwnerDocument = this;
				}
				XTextDocumentBodyElement xTextDocumentBodyElement = (XTextDocumentBodyElement)elements.method_5(typeof(XTextDocumentBodyElement));
				if (xTextDocumentBodyElement == null)
				{
					xTextDocumentBodyElement = new XTextDocumentBodyElement();
					xTextDocumentBodyElement.Parent = this;
					xTextDocumentBodyElement.OwnerDocument = this;
				}
				foreach (XTextElement item in elements)
				{
					if (!(item is XTextDocumentContentElement))
					{
						xTextDocumentBodyElement.Elements.Add(item);
					}
				}
				elements.Clear();
				elements.Add(xTextDocumentHeaderElement);
				elements.Add(xTextDocumentBodyElement);
				elements.Add(xTextDocumentFooterElement);
				elements.Add(xTextDocumentHeaderForFirstPageElement);
				elements.Add(xTextDocumentFooterForFirstPageElement);
			}
		}

		/// <summary>
		///       获得指定类型的插入点所在的文档对象
		///       </summary>
		/// <param name="elementType">指定的文档元素对象</param>
		/// <returns>获得的文档元素对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public XTextElement GetCurrentElement(Type elementType)
		{
			return GetCurrentElement(elementType, includeThis: true);
		}

		/// <summary>
		///       获得指定类型的插入点所在的文档对象
		///       </summary>
		/// <param name="elementType">指定的文档元素对象</param>
		/// <param name="includeThis">是否对当前元素本身进行类型判断</param>
		/// <returns>获得的文档元素对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public XTextElement GetCurrentElement(Type elementType, bool includeThis)
		{
			int num = 6;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new ArgumentException(elementType.FullName);
			}
			if (CurrentElement == null)
			{
				return null;
			}
			if (includeThis && elementType.IsInstanceOfType(CurrentElement))
			{
				return CurrentElement;
			}
			if (RunAtWebServer)
			{
				XTextElement xTextElement = CurrentElement;
				while (true)
				{
					if (xTextElement != null)
					{
						if (elementType.IsInstanceOfType(xTextElement))
						{
							break;
						}
						xTextElement = xTextElement.Parent;
						continue;
					}
					return null;
				}
				return xTextElement;
			}
			XTextContainerElement container = null;
			if (CurrentElement is XTextFieldBorderElement)
			{
				container = CurrentElement.Parent;
			}
			else
			{
				int elementIndex = 0;
				Content.GetCurrentPositionInfo(out container, out elementIndex);
			}
			while (true)
			{
				if (container != null)
				{
					if (elementType.IsInstanceOfType(container))
					{
						break;
					}
					container = container.Parent;
					continue;
				}
				return null;
			}
			return container;
		}

		/// <summary>
		///       获得当前插入点所在的指定类型的文档元素对象。
		///       </summary>
		/// <param name="typeName">指定的文档元素类型的名称</param>
		/// <returns>获得的文档元素对象</returns>
		[DCPublishAPI]
		public XTextElement GetCurrentElementByTypeName(string typeName)
		{
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType == null)
			{
				throw new ArgumentOutOfRangeException(typeName);
			}
			return GetCurrentElement(controlType, includeThis: true);
		}

		/// <summary>
		///       获得当前元素具有相同样式的区域
		///       </summary>
		/// <returns>获得的区域</returns>
		public XTextRange GetCurrentRangeWithSameStyle()
		{
			return CreateRange(CurrentElement, delegate(object object_3, object object_4)
			{
				XTextElement xTextElement = (XTextElement)object_3;
				XTextElement xTextElement2 = (XTextElement)object_4;
				return (xTextElement.GetType() != xTextElement2.GetType() || xTextElement.StyleIndex != xTextElement2.StyleIndex) ? 1 : 0;
			});
		}

		[DCInternal]
		public XTextRange CreateRange(XTextElement element, GDelegate5 callBack)
		{
			XTextDocumentContentElement documentContentElement = element.DocumentContentElement;
			XTextContent content = documentContentElement.Content;
			int num = content.IndexOf(element);
			int num2 = num;
			int num3 = num;
			int num4 = num;
			while (num4 > 0 && callBack(element, content[num4]) == 0)
			{
				num2 = num4;
				num4--;
			}
			for (num4 = num; num4 < content.Count && callBack(element, content[num4]) == 0; num4++)
			{
				num3 = num4;
			}
			return new XTextRange(CurrentContentElement, num2, num3 - num2 + 1);
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象,对文档对象该参数无意义</param>
		/// <returns>创建的文档对象</returns>
		[DCPublishAPI]
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			return (XTextDocument)Clone(Deeply: true);
		}

		/// <summary>
		///       根据视图坐标来获得续打信息对象
		///       </summary>
		/// <param name="pos">指定的文档位置</param>
		/// <returns>获得的续打信息对象</returns>
		public JumpPrintInfo GetJumpPrintInfo(float float_10)
		{
			foreach (PrintPage page in Pages)
			{
				if (Math.Abs(page.Top - float_10) < 1f)
				{
					JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
					jumpPrintInfo.SetNativePosition(float_10);
					jumpPrintInfo.PageIndex = Pages.IndexOf(page);
					jumpPrintInfo.Position = 0f;
					jumpPrintInfo.Page = page;
					return jumpPrintInfo;
				}
			}
			if (float_10 > Body.AbsTop + Body.ContentHeight - 1f)
			{
				return null;
			}
			GClass128 gClass = new GClass128();
			gClass.float_3 = float_10;
			gClass.method_21(0f);
			gClass.method_17(bool_5: true);
			if (Options.BehaviorOptions.SpecifyDebugMode)
			{
				gClass.method_17(bool_5: false);
			}
			Body.method_42(gClass);
			if (gClass.method_23() > 0f)
			{
				JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
				jumpPrintInfo.SetNativePosition(float_10);
				foreach (PrintPage page2 in Pages)
				{
					if (gClass.method_23() >= page2.Top && gClass.method_23() < page2.Bottom)
					{
						jumpPrintInfo.PageIndex = Pages.IndexOf(page2);
						jumpPrintInfo.Position = (int)(gClass.method_23() - page2.Top);
						jumpPrintInfo.AbsPosition = gClass.method_23();
					}
				}
				jumpPrintInfo.Page = Pages.SafeGet(jumpPrintInfo.PageIndex);
				return jumpPrintInfo;
			}
			return null;
		}

		/// <summary>
		///       根据视图坐标来获得续打信息对象,不修正位置
		///       </summary>
		/// <param name="pos">指定的文档位置</param>
		/// <returns>获得的续打信息对象</returns>
		[DCInternal]
		public JumpPrintInfo GetJumpPrintInfoWithouFixPosition(float float_10)
		{
			foreach (PrintPage page in Pages)
			{
				if (Math.Abs(page.Top - float_10) < 1f)
				{
					JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
					jumpPrintInfo.SetNativePosition(float_10);
					jumpPrintInfo.PageIndex = Pages.IndexOf(page);
					jumpPrintInfo.Position = 0f;
					jumpPrintInfo.Page = page;
					return jumpPrintInfo;
				}
			}
			if (float_10 > Body.AbsTop + Body.ContentHeight - 1f)
			{
				return null;
			}
			GClass128 gClass = new GClass128();
			gClass.float_3 = float_10;
			gClass.method_21(0f);
			gClass.method_17(bool_5: true);
			if (gClass.method_23() > 0f)
			{
				JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
				jumpPrintInfo.SetNativePosition(float_10);
				foreach (PrintPage page2 in Pages)
				{
					if (gClass.method_23() >= page2.Top && gClass.method_23() < page2.Bottom)
					{
						jumpPrintInfo.PageIndex = Pages.IndexOf(page2);
						jumpPrintInfo.Position = (int)(gClass.method_23() - page2.Top);
						jumpPrintInfo.AbsPosition = gClass.method_23();
					}
				}
				jumpPrintInfo.Page = Pages.SafeGet(jumpPrintInfo.PageIndex);
				return jumpPrintInfo;
			}
			return null;
		}

		/// <summary>
		///       分配文档中使用的对象编号
		///       </summary>
		/// <returns>分配的新的编号</returns>
		[DCPublishAPI]
		public int AllocObjectID()
		{
			if (int_12 == 0)
			{
				if (documentCommentList_1 != null)
				{
					foreach (DocumentComment item in documentCommentList_1)
					{
						int_12 = Math.Max(item.Index, int_12);
					}
				}
				foreach (DocumentContentStyle style in ContentStyles.Styles)
				{
					int_12 = Math.Max(style.CommentIndex, int_12);
				}
				int_12++;
			}
			return int_12++;
		}

		internal void method_50(XTextElement xtextElement_3, string string_26)
		{
			if (EditorControl != null)
			{
				EditorControl.InnerViewControl.method_194(xtextElement_3, string_26);
			}
		}

		public override void vmethod_34(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			LastSearchStartPosition = -1;
			base.vmethod_34(contentChangedEventArgs_0);
			if (EditorControl != null)
			{
				EditorControl.vmethod_40(contentChangedEventArgs_0);
			}
		}

		public override void vmethod_33(ContentChangingEventArgs contentChangingEventArgs_0)
		{
			base.vmethod_33(contentChangingEventArgs_0);
			if (EditorControl != null)
			{
				EditorControl.vmethod_38(contentChangingEventArgs_0);
			}
		}

		internal void method_51()
		{
			if (CurrentElement != null)
			{
				DocumentEventArgs documentEventArgs_ = new DocumentEventArgs(OwnerDocument, CurrentElement, DocumentEventStyles.ControlGotFoucs);
				method_84(CurrentElement, documentEventArgs_);
			}
		}

		internal void method_52()
		{
			if (CurrentElement != null)
			{
				DocumentEventArgs documentEventArgs_ = new DocumentEventArgs(OwnerDocument, CurrentElement, DocumentEventStyles.ControlLostFoucs);
				method_84(CurrentElement, documentEventArgs_);
			}
		}

		internal void method_53()
		{
			if (CurrentElement != null)
			{
				DocumentEventArgs documentEventArgs_ = new DocumentEventArgs(OwnerDocument, CurrentElement, DocumentEventStyles.LostFocusExt);
				method_84(CurrentElement, documentEventArgs_);
			}
		}

		[DCInternal]
		public DocumentPaintEventArgs method_54()
		{
			DCGraphics dcgraphics_ = CreateDCGraphics();
			DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(dcgraphics_, Rectangle.Empty);
			documentPaintEventArgs.Document = this;
			documentPaintEventArgs.Render = Render;
			return documentPaintEventArgs;
		}

		/// <summary>
		///       创建画布对象
		///       </summary>
		/// <returns>创建的画布对象</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Obsolete("■■■■■■■不推荐使用，请使用CreateDCGraphics")]
		public Graphics CreateGraphics()
		{
			method_98();
			if (EditorControl == null || !EditorControl.IsHandleCreated)
			{
				Graphics graphics = Graphics.FromHwnd(new IntPtr(0));
				graphics.PageUnit = graphicsUnit_0;
				return graphics;
			}
			return EditorControl.CreateViewGraphics();
		}

		[DCInternal]
		public DocumentPaintEventArgs method_55(DCGraphics dcgraphics_0)
		{
			DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(dcgraphics_0, RectangleF.Empty);
			documentPaintEventArgs.Document = this;
			documentPaintEventArgs.Render = Render;
			return documentPaintEventArgs;
		}

		/// <summary>
		///       创建画布对象
		///       </summary>
		/// <returns>创建的画布对象</returns>
		public DCGraphics CreateDCGraphics()
		{
			bool bool_ = ContentStyles.bool_0;
			ContentStyles.bool_0 = true;
			ContentStyles.method_4();
			ContentStyles.bool_0 = bool_;
			DCGraphics dCGraphics = null;
			if (EditorControl == null || !EditorControl.IsHandleCreated)
			{
				Graphics graphics = Graphics.FromHwnd(new IntPtr(0));
				graphics.PageUnit = graphicsUnit_0;
				dCGraphics = new DCGraphics(graphics);
			}
			else
			{
				dCGraphics = new DCGraphics(EditorControl.CreateViewGraphics());
				dCGraphics.PageUnit = DocumentGraphicsUnit;
			}
			dCGraphics.AutoDisposeNativeGraphics = true;
			return dCGraphics;
		}

		internal void method_56()
		{
			Modified = false;
			BoundsSelection = null;
			BodyLayoutOffset = 0f;
			PageSettings = new XPageSettings();
			MeasureMode = MeasureMode.Default;
			FileName = null;
			FileFormat = null;
			ContentStyles.Clear();
			Parameters.Clear();
			LocalConfig = new LocalConfig();
			Info.CreationTime = GetNowDateTime();
			Info.LastModifiedTime = Info.CreationTime;
			Info.EditMinute = 0;
			method_57();
		}

		/// <summary>
		///       清空文档内容
		///       </summary>
		[DCPublishAPI]
		public void Clear()
		{
			Modified = false;
			if (documentCommentList_0 != null)
			{
				documentCommentList_0.ClearData();
				documentCommentList_0 = null;
			}
			method_44();
			BoundsSelection = null;
			BodyLayoutOffset = 0f;
			PageSettings = new XPageSettings();
			MeasureMode = MeasureMode.Default;
			FileName = null;
			FileFormat = null;
			ContentStyles.Clear();
			Parameters.Clear();
			LocalConfig = new LocalConfig();
			Info.CreationTime = GetNowDateTime();
			Info.LastModifiedTime = Info.CreationTime;
			Info.EditMinute = 0;
			method_57();
			if (!IsLoadingDocument)
			{
				using (DCGraphics dcgraphics_ = CreateDCGraphics())
				{
					RefreshSize(dcgraphics_);
				}
				ExecuteLayout();
				OnSelectionChanged();
				OnDocumentContentChanged();
			}
		}

		internal void method_57()
		{
			if (documentCommentList_0 != null)
			{
				documentCommentList_0.ClearData();
				documentCommentList_0 = null;
			}
			if (list_1 != null)
			{
				list_1.Clear();
				list_1 = null;
			}
			if (xtextElementList_3 != null)
			{
				xtextElementList_3.Clear();
				xtextElementList_3 = null;
			}
			if (documentControler_0 != null)
			{
				documentControler_0.method_26();
			}
			printResult_0 = null;
			xtextElementList_2 = null;
			currentContentStyleInfo_0 = null;
			method_44();
			if (Elements != null)
			{
				foreach (XTextDocumentContentElement element in Elements)
				{
					element.method_63();
				}
			}
			xtextElementList_3 = null;
			list_0 = null;
			string_17 = null;
			dictionary_0 = null;
			documentStates_0 = new DocumentStates();
			float_5 = 0f;
			class135_0 = null;
			memoryStream_0 = null;
			pageContentVersionInfoList_0 = null;
			LastSearchStartPosition = -1;
			boundsSelectionPrintInfo_0 = null;
			bool_18 = false;
			if (dictionary_1 != null)
			{
				dictionary_1.Clear();
			}
			if (adornTextManager_0 != null)
			{
				adornTextManager_0.method_0();
			}
			if (documentParameterCollection_1 != null)
			{
				documentParameterCollection_1.Clear();
			}
			if (documentParameterCollection_0 != null)
			{
				documentParameterCollection_0.Clear();
			}
			method_16();
			if (documentCommentList_1 != null)
			{
				documentCommentList_1.Clear();
			}
			xtextDocumentContentElement_0 = null;
			class136_0 = new Class136(this);
			float_8 = null;
			list_1 = null;
			ContentSourceType = DocumentContentSourceTypes.Unknown;
			MeasureMode = MeasureMode.Default;
			printPage_0 = null;
			currentContentStyleInfo_0 = null;
			Info = new DocumentInfo();
			if (xtextDocumentUndoList_0 != null)
			{
				UndoList.Clear();
			}
			if (userHistoryInfoList_0 != null)
			{
				UserHistories.Clear();
			}
			ScriptText = null;
			ScriptLanguage = ScriptLanguageType.VBNET;
			if (idocumentScriptEngine_0 != null)
			{
				ScriptEngine.Close();
				ScriptEngine = null;
			}
			ContentStyles.Clear();
			ContentStyles.Default.FontSize = DefaultFontSize;
			currentContentStyleInfo_0 = null;
			if (Elements != null)
			{
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.AddRange(Elements);
				Elements.Clear();
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(xTextElementList);
				domTreeNodeEnumerable.ExcludeParagraphFlag = true;
				domTreeNodeEnumerable.ExcludeCharElement = true;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					((IDisposable)item)?.Dispose();
				}
			}
			xtextDocumentContentElement_0 = null;
			int_12 = 0;
			if (!bool_24)
			{
				XTextDocumentContentElement body = Body;
				body.FixElements();
				body.vmethod_36(bool_22: true);
				body.SetSelection(0, 0);
				body = Header;
				body.FixElements();
				body.vmethod_36(bool_22: true);
				body.SetSelection(0, 0);
				body = Footer;
				body.FixElements();
				body.vmethod_36(bool_22: true);
				body.SetSelection(0, 0);
				FixDomState();
			}
		}

		/// <summary>
		///       开始记录撤销操作信息
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		public bool BeginLogUndo()
		{
			if (!Options.BehaviorOptions.EnableLogUndo)
			{
				return false;
			}
			if (UIIsUpdating)
			{
				return false;
			}
			if (xtextDocumentUndoList_0 != null)
			{
				return xtextDocumentUndoList_0.vmethod_1();
			}
			return false;
		}

		/// <summary>
		///       完成记录撤销操作信息
		///       </summary>
		/// <remarks>操作是否保存了新的撤销信息</remarks>
		[DCInternal]
		public bool EndLogUndo()
		{
			int num = 3;
			if (!Options.BehaviorOptions.EnableLogUndo)
			{
				return false;
			}
			if (UIIsUpdating)
			{
				return false;
			}
			if (xtextDocumentUndoList_0 != null && xtextDocumentUndoList_0.vmethod_4())
			{
				if (EditorControl != null && EditorControl.CommandControler != null)
				{
					EditorControl.CommandControler.InvalidateCommandState("Undo");
					EditorControl.CommandControler.InvalidateCommandState("Redo");
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       撤销记录的重做/撤销操作信息
		///       </summary>
		[DCInternal]
		public void CancelLogUndo()
		{
			if (xtextDocumentUndoList_0 != null)
			{
				xtextDocumentUndoList_0.vmethod_2();
			}
		}

		private ArrayList method_58(string string_26)
		{
			string[] array = WriterUtils.smethod_52(string_26);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			using (DCGraphics dcgraphics_ = CreateDCGraphics())
			{
				DocumentPaintEventArgs args = method_55(dcgraphics_);
				string[] array2 = array;
				foreach (string strText in array2)
				{
					XTextElementList xTextElementList = CreateChars(strText);
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						arrayList.Add(xTextElementList);
						foreach (XTextElement item in xTextElementList)
						{
							item.RefreshSize(args);
						}
					}
					else
					{
						arrayList.Add(new XTextElementList());
					}
				}
			}
			return arrayList;
		}

		/// <summary>
		///       创建多个文本元素
		///       </summary>
		/// <param name="strText">文本内容</param>
		/// <param name="paragraphStyle">段落样式</param>
		/// <param name="textStyle">文本样式</param>
		/// <returns>创建的字符元素对象列表</returns>
		[DCInternal]
		public XTextElementList CreateTextElements(string strText, DocumentContentStyle paragraphStyle, DocumentContentStyle textStyle)
		{
			return CreateTextElementsExt(strText, paragraphStyle, textStyle, Options.SecurityOptions.EnablePermission);
		}

		/// <summary>
		///       创建多个文本元素
		///       </summary>
		/// <param name="strText">文本内容</param>
		/// <param name="paragraphStyle">段落样式</param>
		/// <param name="textStyle">文本样式</param>
		/// <param name="enablePermission">是否启用授权标记</param>
		/// <returns>创建的字符元素对象列表</returns>
		[DCInternal]
		public XTextElementList CreateTextElementsExt(string strText, DocumentContentStyle paragraphStyle, DocumentContentStyle textStyle, bool enablePermission)
		{
			int num = 11;
			if (string.IsNullOrEmpty(strText))
			{
				return new XTextElementList();
			}
			if (paragraphStyle != null)
			{
				paragraphStyle = (DocumentContentStyle)paragraphStyle.CloneEnableDefaultValue();
			}
			if (textStyle != null)
			{
				textStyle = (DocumentContentStyle)textStyle.CloneEnableDefaultValue();
			}
			XTextElementList xTextElementList = new XTextElementList();
			if (enablePermission)
			{
				if (textStyle != null)
				{
					textStyle.CreatorIndex = UserHistories.CurrentIndex;
				}
				else
				{
					textStyle = new DocumentContentStyle();
					textStyle.CreatorIndex = UserHistories.CurrentIndex;
				}
				if (paragraphStyle != null)
				{
					paragraphStyle.CreatorIndex = UserHistories.CurrentIndex;
				}
				else
				{
					paragraphStyle = new DocumentContentStyle();
					paragraphStyle.CreatorIndex = UserHistories.CurrentIndex;
				}
			}
			else
			{
				if (textStyle != null && textStyle.CreatorIndex >= 0)
				{
					textStyle.method_29("CreatorIndex");
				}
				if (paragraphStyle != null && paragraphStyle.CreatorIndex >= 0)
				{
					paragraphStyle.method_29("CreatorIndex");
				}
			}
			if (textStyle != null)
			{
				XDependencyObject.smethod_1(textStyle, null);
				XDependencyObject.smethod_1(textStyle, ContentStyles.Default);
			}
			if (paragraphStyle != null)
			{
				XDependencyObject.smethod_1(paragraphStyle, null);
				XDependencyObject.smethod_1(paragraphStyle, ContentStyles.Default);
			}
			int styleIndex = ContentStyles.GetStyleIndex(textStyle);
			int styleIndex2 = ContentStyles.GetStyleIndex(paragraphStyle);
			if (strText.IndexOf('\n') >= 0 && strText.IndexOf('\r') < 0)
			{
				strText = strText.Replace('\n', '\r');
			}
			DCGraphics dCGraphics = null;
			if (!UIIsUpdating)
			{
				dCGraphics = CreateDCGraphics();
			}
			DocumentPaintEventArgs documentPaintEventArgs = null;
			if (dCGraphics != null)
			{
				documentPaintEventArgs = method_55(dCGraphics);
			}
			try
			{
				string text = strText;
				foreach (char c in text)
				{
					switch (c)
					{
					case '\r':
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.method_5(this);
						xTextParagraphFlagElement.SetParentRaw(this);
						xTextParagraphFlagElement.StyleIndex = styleIndex2;
						if (documentPaintEventArgs != null)
						{
							xTextParagraphFlagElement.RefreshSize(documentPaintEventArgs);
						}
						xTextElementList.AddRaw(xTextParagraphFlagElement);
						break;
					}
					default:
					{
						XTextCharElement xTextCharElement = new XTextCharElement();
						xTextCharElement.CharValue = c;
						xTextCharElement.method_5(this);
						xTextCharElement.SetParentRaw(this);
						xTextCharElement.StyleIndex = styleIndex;
						if (documentPaintEventArgs != null)
						{
							xTextCharElement.RefreshSize(documentPaintEventArgs);
						}
						xTextElementList.AddRaw(xTextCharElement);
						break;
					}
					case '\n':
						break;
					}
				}
			}
			finally
			{
				dCGraphics?.Dispose();
			}
			return xTextElementList;
		}

		internal void method_59(string string_26, int int_18, int int_19, XTextElementList xtextElementList_5)
		{
			if (string_26 == null || string_26.Length == 0)
			{
				return;
			}
			foreach (char c in string_26)
			{
				switch (c)
				{
				case '\r':
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.StyleIndex = int_19;
					xTextParagraphFlagElement.SetParentRaw(this);
					xTextParagraphFlagElement.method_5(this);
					xtextElementList_5.AddRaw(xTextParagraphFlagElement);
					break;
				}
				default:
				{
					XTextCharElement xTextCharElement = new XTextCharElement();
					xTextCharElement.StyleIndex = int_18;
					xTextCharElement.CharValue = c;
					xTextCharElement.SetParentRaw(this);
					xTextCharElement.method_5(this);
					xtextElementList_5.AddRaw(xTextCharElement);
					break;
				}
				case '\n':
					break;
				}
			}
		}

		/// <summary>
		///       导入文档元素
		///       </summary>
		/// <param name="element">要导入的文档元素</param>
		public void ImportElement(XTextElement element)
		{
			int num = 8;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			ImportElements(new XTextElementList(element));
		}

		/// <summary>
		///       导入文档元素
		///       </summary>
		/// <param name="elements">要导入的文档元素</param>
		public void ImportElements(XTextElementList elements)
		{
			int num = 6;
			if (elements == null)
			{
				throw new ArgumentNullException("elements");
			}
			ImportElementsSpceifyImportPermssion(elements, Options.SecurityOptions.EnablePermission, Options.SecurityOptions.EnablePermission);
		}

		/// <summary>
		///       导入文档元素
		///       </summary>
		/// <param name="elements">要导入的文档元素</param>
		/// <param name="preserveUserTrack">是否保留用户修改痕迹</param>
		public void ImportElementsSpceifyImportPermssion(XTextElementList elements, bool preserveUserTrack)
		{
			ImportElementsSpceifyImportPermssion(elements, preserveUserTrack, Options.SecurityOptions.EnablePermission);
		}

		/// <summary>
		///       导入文档元素
		///       </summary>
		/// <param name="elements">要导入的文档元素</param>
		/// <param name="preserveUserTrack">是否保留用户修改痕迹</param>
		/// <param name="enablePermission">是否启用授权痕迹管理</param>
		public void ImportElementsSpceifyImportPermssion(XTextElementList elements, bool preserveUserTrack, bool enablePermission)
		{
			int num = 6;
			if (elements == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (elements.Count == 0)
			{
				return;
			}
			if (elements.LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)elements.LastElement;
				if (xTextParagraphFlagElement.AutoCreate)
				{
					elements.RemoveAt(elements.Count - 1);
				}
			}
			if (elements.Count == 0)
			{
				return;
			}
			if (!preserveUserTrack && !enablePermission)
			{
				WriterUtils.RemoveLogicDeletedElements(elements);
			}
			if (elements.Count == 0)
			{
				return;
			}
			Dictionary<int, DocumentContentStyle> dictionary = new Dictionary<int, DocumentContentStyle>();
			XTextDocument xTextDocument = elements[0].OwnerDocument;
			if (xTextDocument == null)
			{
				xTextDocument = this;
			}
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(elements);
			domTreeNodeEnumerable.ExcludeCharElement = false;
			domTreeNodeEnumerable.ExcludeParagraphFlag = false;
			if (xTextDocument != this)
			{
				List<DocumentComment> list = new List<DocumentComment>();
				UserHistoryInfoList userHistoryInfoList = new UserHistoryInfoList();
				xTextDocument.UserHistories.RefreshIndex();
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					ValidateElementIDRepeat(item);
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)xTextDocument.ContentStyles.GetStyle(item.StyleIndex);
					dictionary[item.StyleIndex] = documentContentStyle;
					if (xTextDocument.Comments != null && xTextDocument.Comments.Count > 0)
					{
						DocumentComment byCommentIndex = xTextDocument.Comments.GetByCommentIndex(documentContentStyle.CommentIndex);
						if (byCommentIndex != null && !list.Contains(byCommentIndex))
						{
							list.Add(byCommentIndex);
						}
					}
					if (preserveUserTrack && xTextDocument.UserHistories != null && xTextDocument.UserHistories.Count > 0)
					{
						UserHistoryInfo info = xTextDocument.UserHistories.GetInfo(documentContentStyle.CreatorIndex);
						if (info != null)
						{
							if (!userHistoryInfoList.Contains(info))
							{
								userHistoryInfoList.Add(info);
							}
						}
						else
						{
							documentContentStyle.CreatorIndex = -1;
						}
						info = xTextDocument.UserHistories.GetInfo(documentContentStyle.DeleterIndex);
						if (info != null)
						{
							if (!userHistoryInfoList.Contains(info))
							{
								userHistoryInfoList.Add(info);
							}
						}
						else
						{
							documentContentStyle.DeleterIndex = -1;
						}
					}
				}
				userHistoryInfoList.SortByIndex();
				bool flag = false;
				int count = UserHistories.Count;
				DomTreeNodeEnumerable domTreeNodeEnumerable2 = new DomTreeNodeEnumerable(this);
				domTreeNodeEnumerable2.ExcludeCharElement = false;
				domTreeNodeEnumerable2.ExcludeParagraphFlag = false;
				foreach (XTextElement item2 in domTreeNodeEnumerable2)
				{
					int creatorIndex = item2.RuntimeStyle.CreatorIndex;
					if (creatorIndex == count - 1)
					{
						flag = true;
						break;
					}
					creatorIndex = item2.RuntimeStyle.DeleterIndex;
					if (creatorIndex == count - 1)
					{
						flag = true;
						break;
					}
				}
				int num2 = count - 1;
				if (flag)
				{
					num2 = count;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
				for (int i = 0; i < userHistoryInfoList.Count; i++)
				{
					dictionary2[userHistoryInfoList[i].Index] = i + num2;
				}
				int num3 = Comments.MaxID + 1;
				using (DCGraphics dcgraphics_ = CreateDCGraphics())
				{
					foreach (DocumentContentStyle value in dictionary.Values)
					{
						xTextDocument.ContentStyles.GetStyleIndex(value);
						DocumentContentStyle documentContentStyle2 = (DocumentContentStyle)value.Clone();
						if (preserveUserTrack)
						{
							if (documentContentStyle2.CreatorIndex != -1 && dictionary2.ContainsKey(documentContentStyle2.CreatorIndex))
							{
								documentContentStyle2.CreatorIndex = dictionary2[documentContentStyle2.CreatorIndex];
							}
							if (documentContentStyle2.DeleterIndex != -1 && dictionary2.ContainsKey(documentContentStyle2.DeleterIndex))
							{
								documentContentStyle2.DeleterIndex = dictionary2[documentContentStyle2.DeleterIndex];
							}
						}
						else if (enablePermission)
						{
							if (dictionary2.ContainsKey(documentContentStyle2.CreatorIndex))
							{
								documentContentStyle2.CreatorIndex = dictionary2[documentContentStyle2.CreatorIndex];
							}
							documentContentStyle2.DeleterIndex = -1;
						}
						else
						{
							documentContentStyle2.CreatorIndex = -1;
							documentContentStyle2.DeleterIndex = -1;
						}
						if (num3 > 0 && documentContentStyle2.CommentIndex != -1)
						{
							documentContentStyle2.CommentIndex += num3;
						}
						int styleIndex2 = value.Index = ContentStyles.GetStyleIndex(documentContentStyle2);
						DocumentContentStyle documentContentStyle3 = (DocumentContentStyle)ContentStyles.GetStyle(styleIndex2);
						documentContentStyle3.method_32(dcgraphics_);
					}
				}
				ContentStyles.method_4();
				foreach (DocumentComment item3 in list)
				{
					DocumentComment documentComment = item3.method_0();
					documentComment.Index += num3;
					Comments.Add(documentComment);
				}
				if (preserveUserTrack)
				{
					UserHistoryInfo currentInfo = UserHistories.CurrentInfo;
					if (currentInfo != null && !flag)
					{
						UserHistories.Remove(currentInfo);
					}
					foreach (UserHistoryInfo item4 in userHistoryInfoList)
					{
						UserHistories.Add(item4.Clone());
					}
					if (currentInfo != null && !flag)
					{
						UserHistories.Add(currentInfo);
					}
					UserHistories.RefreshIndex();
				}
				int_12 = 0;
				foreach (XTextElement item5 in domTreeNodeEnumerable)
				{
					if (dictionary.ContainsKey(item5.StyleIndex))
					{
						item5.StyleIndex = dictionary[item5.StyleIndex].Index;
					}
					item5.OwnerDocument = this;
				}
			}
			foreach (XTextElement element in elements)
			{
				element.OwnerDocument = this;
				element.SizeInvalid = true;
				element.FixDomState();
			}
			ValidateElementsIDRepeat(elements);
			foreach (XTextElement element2 in elements)
			{
				element2.AfterLoad(new ElementLoadEventArgs(element2, "xml"));
			}
		}

		/// <summary>
		///       在当前位置插入一个元素
		///       </summary>
		/// <param name="element">要插入的元素对象</param>
		/// <returns>操作是否成功</returns>
		public bool InsertElement(XTextElement element)
		{
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.Add(element);
			int num = InsertElements(xTextElementList, updateContent: true);
			return num > 0;
		}

		/// <summary>
		///       插入多个元素到文档中
		///       </summary>
		/// <param name="newElements">要插入的新元素</param>
		/// <param name="updateContent">是否更新文档视图</param>
		/// <returns>插入的元素个数</returns>
		public int InsertElements(XTextElementList newElements, bool updateContent)
		{
			GClass101 gClass = new GClass101();
			gClass.method_3(newElements);
			gClass.method_11(updateContent);
			return InsertElements(gClass);
		}

		public int InsertElements(GClass101 args3)
		{
			if (args3 == null)
			{
				return 0;
			}
			if (args3.method_2() == null || args3.method_2().Count == 0)
			{
				return 0;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			XTextElement xTextElement = args3.method_0();
			if (xTextElement == null)
			{
				xTextElement = CurrentElement;
			}
			bool flag = false;
			if (xTextElement.IsRightToLeft && args3.method_2() != null && args3.method_2().FirstElement is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)args3.method_2().FirstElement;
				if (!Class126.smethod_8(xTextCharElement.CharValue))
				{
					XTextElement preElement = xTextElement.OwnerLine.GetPreElement(xTextElement);
					if (!(preElement?.IsRightToLeft ?? true))
					{
						xTextElement = preElement;
						flag = true;
					}
				}
			}
			bool flag2;
			if (flag2 = (args3.method_2().Count == 1 && args3.method_2()[0] is XTextParagraphFlagElement))
			{
				if (IsCurrentPositionAtFirstCell)
				{
					XTextTableCellElement ownerCell = xTextElement.OwnerCell;
					XTextTableElement ownerTable = ownerCell.OwnerTable;
					XTextContainerElement parent = ownerTable.Parent;
					if (!parent.RuntimeContentReadonly)
					{
						GEventArgs4 gEventArgs = new GEventArgs4(ownerTable.Parent, parent.Elements.IndexOf(ownerTable), 0, args3.method_2(), bool_10: true, args3.method_10(), bool_12: true);
						gEventArgs.method_3(args3.method_6());
						if (gEventArgs.method_2())
						{
							gEventArgs.method_17(bool_10: false);
						}
						int result = method_63(gEventArgs);
						if (args3.method_2().Count > 0)
						{
							CurrentContentElement.SetSelection(args3.method_2()[0].ViewIndex, 0);
						}
						return result;
					}
				}
				else if (IsCurrentPositionAtFirstSection)
				{
					XTextSectionElement ownerSection = xTextElement.OwnerSection;
					XTextContainerElement parent = ownerSection.Parent;
					if (!parent.RuntimeContentReadonly)
					{
						GEventArgs4 gEventArgs = new GEventArgs4(ownerSection.Parent, parent.Elements.IndexOf(ownerSection), 0, args3.method_2(), bool_10: true, args3.method_10(), bool_12: true);
						gEventArgs.method_3(args3.method_6());
						if (gEventArgs.method_2())
						{
							gEventArgs.method_17(bool_10: false);
						}
						int result = method_63(gEventArgs);
						if (args3.method_2().Count > 0)
						{
							CurrentContentElement.SetSelection(args3.method_2()[0].ViewIndex, 0);
						}
						return result;
					}
				}
			}
			XTextDocumentContentElement documentContentElement = xTextElement.DocumentContentElement;
			if (documentContentElement == Body)
			{
			}
			XTextContainerElement xtextContainerElement_ = null;
			int int_ = 0;
			documentContentElement.Content.method_20(documentContentElement.Content.IndexOf(xTextElement), out xtextContainerElement_, out int_, documentContentElement.Content.LineEndFlag);
			GEventArgs4 gEventArgs2 = new GEventArgs4(xtextContainerElement_, int_, 0, args3.method_2(), bool_10: true, args3.method_10(), bool_12: true);
			gEventArgs2.method_3(args3.method_6());
			if (gEventArgs2.method_2())
			{
				gEventArgs2.method_17(bool_10: false);
			}
			if (flag2)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = xtextContainerElement_.Elements.SafeGet(int_) as XTextParagraphFlagElement;
				if (xTextParagraphFlagElement != null)
				{
					RuntimeDocumentContentStyle runtimeStyle = xTextParagraphFlagElement.RuntimeStyle;
					if (runtimeStyle.ParagraphOutlineLevel >= 0 && DocumentControler.CanModify(xTextParagraphFlagElement) && !Options.BehaviorOptions.ContinueHeaderParagrahStyle)
					{
						gEventArgs2.method_37(xTextParagraphFlagElement);
						gEventArgs2.method_35(method_60);
					}
				}
			}
			_ = xTextElement.OwnerLine;
			if (!flag && xTextElement is XTextCharElement)
			{
				ContentLayoutDirectionStyle contentLayoutDirectionStyle = (!xTextElement.IsRightToLeft) ? ContentLayoutDirectionStyle.LeftToRight : ContentLayoutDirectionStyle.RightToLeft;
				if (WriterUtils.smethod_21(((XTextCharElement)xTextElement).CharValue, contentLayoutDirectionStyle) != contentLayoutDirectionStyle)
				{
					int_++;
				}
			}
			if (xtextContainerElement_ is XTextContentElement && int_ == xtextContainerElement_.Elements.Count)
			{
				int_ = xtextContainerElement_.Elements.Count - 1;
			}
			gEventArgs2.method_11(int_);
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			tickCountFloat = CountDown.GetTickCountFloat();
			int result2 = method_63(gEventArgs2);
			if (!flag)
			{
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			return result2;
		}

		private void method_60(object sender, EventArgs e)
		{
			GEventArgs4 gEventArgs = (GEventArgs4)e;
			XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)gEventArgs.method_36();
			DocumentContentStyle documentContentStyle = xTextParagraphFlagElement.RuntimeStyle.CloneParent();
			documentContentStyle.ParagraphOutlineLevel = -1;
			documentContentStyle.ParagraphMultiLevel = false;
			documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
			documentContentStyle.Font = DefaultStyle.Font;
			documentContentStyle.LeftIndent = 0f;
			documentContentStyle.FirstLineIndent = 0f;
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
			documentContentStyle.LineSpacing = 1f;
			int styleIndex = ContentStyles.GetStyleIndex(documentContentStyle);
			if (CanLogUndo)
			{
				UndoList.AddStyleIndex(xTextParagraphFlagElement, xTextParagraphFlagElement.StyleIndex, styleIndex);
			}
			xTextParagraphFlagElement.StyleIndex = styleIndex;
			xTextParagraphFlagElement.SizeInvalid = true;
			xTextParagraphFlagElement.ViewInvalid = true;
			FixCurrentStyleInfoForEnter = false;
		}

		/// <summary>
		///       在当前插入点处插入若干个元素
		///       </summary>
		/// <param name="element">基点元素</param>
		/// <param name="newElements">要插入的元素的列表</param>
		/// <param name="UpdateContent">是否更新文档显示内容</param>
		public void InsertElementsBefore(XTextElement element, XTextElementList newElements, bool UpdateContent)
		{
			if (element == null)
			{
				element = Body.PrivateContent[0];
			}
			if (newElements == null || newElements.Count == 0)
			{
				return;
			}
			XTextContentElement contentElement = element.ContentElement;
			XTextContainerElement parent = element.Parent;
			int num = parent.Elements.IndexOf(element);
			if (num < 0)
			{
				num = parent.Elements.Count;
			}
			parent.Elements.method_12(num, newElements);
			foreach (XTextElement newElement in newElements)
			{
				newElement.Parent = parent;
				newElement.OwnerDocument = parent.OwnerDocument;
			}
			if (CanLogUndo)
			{
				UndoList.AddReplaceElements(parent, num, null, newElements);
			}
			Modified = true;
			if (!UpdateContent)
			{
				return;
			}
			foreach (XTextElement newElement2 in newElements)
			{
				if (newElement2 is XTextTableElement)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)newElement2;
					foreach (XTextTableCellElement cell in xTextTableElement.Cells)
					{
						cell.FixElements();
					}
					xTextTableElement.ExecuteLayout();
				}
			}
			contentElement.vmethod_36(bool_22: true);
			if (contentElement != parent.DocumentContentElement)
			{
				parent.DocumentContentElement.vmethod_36(bool_22: true);
			}
			XTextElement xTextElement = newElements.FirstContentElement;
			_ = newElements.LastContentElement;
			if (xTextElement == null || !contentElement.PrivateContent.Contains(xTextElement))
			{
				xTextElement = contentElement.PrivateContent[0];
			}
			num = contentElement.PrivateContent.IndexOf(xTextElement);
			if (num >= 0)
			{
				XTextElement xTextElement2 = contentElement.PrivateContent.SafeGet(num - 1);
				int num2 = 0;
				int num3 = contentElement.PrivateLines.Count - 1;
				if (xTextElement2 != null && xTextElement2.OwnerLine != null)
				{
					num2 = contentElement.PrivateLines.IndexOf(xTextElement2.OwnerLine);
					if (xTextElement2.OwnerLine.LastElement == xTextElement2)
					{
						num2++;
					}
				}
				int num4 = contentElement.PrivateContent.IndexOf(newElements.LastContentElement);
				if (num4 >= 0)
				{
					xTextElement2 = contentElement.PrivateContent.SafeGet(num4 + 1);
					if (xTextElement2 != null && xTextElement2.OwnerLine != null)
					{
						num3 = contentElement.PrivateLines.IndexOf(xTextElement2.OwnerLine);
					}
				}
				for (int i = num2; i <= num3; i++)
				{
					contentElement.PrivateLines[i].InvalidateState = true;
				}
			}
			XTextDocumentContentElement documentContentElement = element.DocumentContentElement;
			contentElement.vmethod_38(num, -1, bool_22: false);
			int num5 = documentContentElement.Content.IndexOf(newElements.LastContentElement);
			if (num5 >= 0)
			{
				documentContentElement.Content.AutoClearSelection = true;
				documentContentElement.Content.MoveToPosition(num5 + 1);
			}
		}

		internal void method_61(XTextElementList xtextElementList_5, int int_18, int int_19, bool bool_32, bool bool_33)
		{
			int num = 1;
			if (xtextElementList_5 == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (int_18 < 0 || int_18 >= xtextElementList_5.Count)
			{
				throw new ArgumentOutOfRangeException("startIndex=" + int_18);
			}
			if (int_19 < 0 || int_18 + int_19 > xtextElementList_5.Count)
			{
				throw new ArgumentOutOfRangeException("length=" + int_19);
			}
			int num2 = int_18 + int_19 - 1;
			for (int i = int_18; i <= num2; i++)
			{
				XTextElement xTextElement = xtextElementList_5[i];
				DocumentContentStyle documentContentStyle = xTextElement.RuntimeStyle.CloneParent();
				documentContentStyle.DisableDefaultValue = false;
				if (bool_32)
				{
					documentContentStyle.CreatorIndex = UserHistories.CurrentIndex;
				}
				else
				{
					if (documentContentStyle.DeleterIndex >= 0)
					{
						continue;
					}
					documentContentStyle.DeleterIndex = UserHistories.CurrentIndex;
				}
				int styleIndex = ContentStyles.GetStyleIndex(documentContentStyle);
				if (bool_33 && CanLogUndo)
				{
					UndoList.AddStyleIndex(xTextElement, xTextElement.StyleIndex, styleIndex);
				}
				xTextElement.StyleIndex = styleIndex;
			}
			if (WriterUtils.smethod_5(xtextElementList_5, int_18, num2))
			{
				PageRefreshed = false;
			}
		}

		[DCInternal]
		internal int method_62(XTextElementList xtextElementList_5)
		{
			if (!Options.BehaviorOptions.AutoFixElementIDWhenInsertElements)
			{
				return 0;
			}
			List<string> list = null;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(xtextElementList_5);
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			domTreeNodeEnumerable.ExcludeCharElement = true;
			int num = 0;
			long ticks = DateTime.Now.Ticks;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if ((item is XTextObjectElement || item is XTextContainerElement) && !string.IsNullOrEmpty(item.ID))
				{
					if (list == null)
					{
						list = new List<string>();
						DomTreeNodeEnumerable domTreeNodeEnumerable2 = new DomTreeNodeEnumerable(this, bool_2: true);
						domTreeNodeEnumerable2.ExcludeCharElement = true;
						domTreeNodeEnumerable2.ExcludeParagraphFlag = true;
						foreach (XTextElement item2 in domTreeNodeEnumerable2)
						{
							string iD = item2.ID;
							if (!string.IsNullOrEmpty(iD) && !list.Contains(iD))
							{
								list.Add(iD);
							}
						}
					}
					string iD2 = item.ID;
					if (list.Contains(iD2))
					{
						string text = AllocElementID(item.ElementIDPrefix, item.GetType());
						if (list.Contains(text))
						{
							text += Convert.ToString(ticks++);
						}
						dictionary[text] = iD2;
						item.ID = text;
						list.Add(text);
						num++;
					}
				}
			}
			if (dictionary.Count > 0)
			{
				if (ElementIDForEditableDependentExecuter != null)
				{
					ElementIDForEditableDependentExecuter.SynchronForModifyElementID(xtextElementList_5, dictionary);
				}
				if (ExpressionExecuter != null)
				{
					ExpressionExecuter.imethod_0(xtextElementList_5, dictionary);
				}
			}
			return num;
		}

		[DCInternal]
		public int method_63(GEventArgs4 geventArgs4_0)
		{
			int num = 8;
			if (geventArgs4_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (geventArgs4_0.method_8() == null)
			{
				throw new ArgumentNullException("container");
			}
			geventArgs4_0.method_39(0);
			if (geventArgs4_0.method_12() == 0 && (geventArgs4_0.method_14() == null || geventArgs4_0.method_14().Count == 0))
			{
				return 0;
			}
			if (geventArgs4_0.method_10() < 0)
			{
				return 0;
			}
			XTextElement currentElement = CurrentElement;
			XTextContentElement xTextContentElement = geventArgs4_0.method_8().ContentElement;
			if (geventArgs4_0.method_8() is XTextSectionElement)
			{
				xTextContentElement = (XTextSectionElement)geventArgs4_0.method_8();
			}
			if (xTextContentElement == null)
			{
				throw new ArgumentNullException("ContentElement");
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			XTextElementList elements = geventArgs4_0.method_8().Elements;
			XTextElementList xTextElementList = new XTextElementList();
			XTextElementList xTextElementList2 = new XTextElementList();
			if (elements.Count > 0 && geventArgs4_0.method_10() >= 0 && geventArgs4_0.method_10() + geventArgs4_0.method_12() <= elements.Count && geventArgs4_0.method_12() > 0)
			{
				for (int i = 0; i < geventArgs4_0.method_12(); i++)
				{
					XTextElement xTextElement = elements[i + geventArgs4_0.method_10()];
					if (!DocumentControler.CanDelete(xTextElement, geventArgs4_0.method_28()))
					{
						if (xTextElement is XTextParagraphFlagElement && elements.LastElement == xTextElement && geventArgs4_0.method_8() is XTextContentElement)
						{
							geventArgs4_0.method_13(geventArgs4_0.method_12() - 1);
						}
						else
						{
							ContentProtectedInfo contentProtectedInfo = DocumentControler.method_22();
							if (contentProtectedInfo != null)
							{
								if (contentProtectedInfo.Reason == ContentProtectedReason.LogicDeleteAgain)
								{
									xTextElementList2.Add(elements[i + geventArgs4_0.method_10()]);
									continue;
								}
								ContentProtectedInfos.Add(contentProtectedInfo);
								return 0;
							}
						}
					}
					xTextElementList.Add(elements[i + geventArgs4_0.method_10()]);
					xTextElementList2.Add(elements[i + geventArgs4_0.method_10()]);
				}
			}
			if (geventArgs4_0.method_14() != null && geventArgs4_0.method_14().Count > 0)
			{
				for (int i = geventArgs4_0.method_14().Count - 1; i >= 0; i--)
				{
					XTextElement newElement = geventArgs4_0.method_14()[i];
					if (!DocumentControler.CanInsert(geventArgs4_0.method_8(), geventArgs4_0.method_10(), newElement, geventArgs4_0.method_28()))
					{
						if (!geventArgs4_0.method_16())
						{
							return 0;
						}
						geventArgs4_0.method_14().RemoveAt(i);
					}
				}
			}
			if (geventArgs4_0.method_12() == 0 && (geventArgs4_0.method_14() == null || geventArgs4_0.method_14().Count == 0))
			{
				return 0;
			}
			if (geventArgs4_0.method_8().RuntimeMaxInputLength > 0)
			{
				int num2 = geventArgs4_0.method_8().Elements.Count;
				if (geventArgs4_0.method_12() > 0)
				{
					num2 -= geventArgs4_0.method_12();
				}
				if (geventArgs4_0.method_14() != null)
				{
					num2 += geventArgs4_0.method_14().Count;
				}
				if (num2 > geventArgs4_0.method_8().RuntimeMaxInputLength)
				{
					geventArgs4_0.method_39(0);
					return geventArgs4_0.method_38();
				}
			}
			if (geventArgs4_0.method_2())
			{
				geventArgs4_0.method_39(geventArgs4_0.method_12());
				if (geventArgs4_0.method_14() != null)
				{
					geventArgs4_0.method_39(geventArgs4_0.method_38() + geventArgs4_0.method_14().Count);
				}
				return geventArgs4_0.method_38();
			}
			int num3 = 0;
			XTextElement item = null;
			if (geventArgs4_0.method_20() && ReadyState == DomReadyStates.Complete)
			{
				XTextElement xTextElement2 = null;
				xTextElement2 = ((elements.Count == 0) ? geventArgs4_0.method_8().FirstContentElement : ((geventArgs4_0.method_12() > 0) ? xTextElementList2.FirstContentElement : ((geventArgs4_0.method_10() != elements.Count) ? elements[geventArgs4_0.method_10()].FirstContentElement : elements[geventArgs4_0.method_10() - 1].FirstContentElement)));
				if (xTextElement2 == null || !xTextContentElement.PrivateContent.Contains(xTextElement2))
				{
					xTextElement2 = geventArgs4_0.method_8().FirstContentElement;
				}
				if (xTextElement2 == null || !xTextContentElement.PrivateContent.Contains(xTextElement2))
				{
					xTextElement2 = xTextContentElement.PrivateContent.SafeGet(0);
				}
				XTextElement xTextElement3 = null;
				xTextElement3 = ((elements.Count == 0) ? geventArgs4_0.method_8().LastContentElement : ((geventArgs4_0.method_12() > 0) ? xTextElementList2.LastContentElement : ((geventArgs4_0.method_10() != elements.Count) ? elements[geventArgs4_0.method_10()].LastContentElement : elements[geventArgs4_0.method_10() - 1].LastContentElement)));
				if (xTextElement3 == null || !xTextContentElement.PrivateContent.Contains(xTextElement3))
				{
					xTextElement3 = geventArgs4_0.method_8().LastContentElement;
				}
				item = xTextContentElement.PrivateContent.LastElement;
				if (xTextElement3 != null)
				{
					item = xTextContentElement.PrivateContent.GetNextElement(xTextElement3);
				}
				num3 = xTextContentElement.PrivateContent.IndexOf(xTextElement2);
				if (num3 >= 0 && xTextContentElement.PrivateLines.Count > 0)
				{
					XTextElement xTextElement4 = xTextContentElement.PrivateContent.SafeGet(num3 - 1);
					int num4 = 0;
					int num5 = xTextContentElement.PrivateLines.Count - 1;
					if (xTextElement4 != null && xTextElement4.OwnerLine != null)
					{
						num4 = xTextContentElement.PrivateLines.IndexOf(xTextElement4.OwnerLine);
						if (xTextElement4.OwnerLine.LastElement == xTextElement4)
						{
							num4++;
						}
					}
					int num6 = xTextContentElement.PrivateContent.IndexOf(xTextElement3);
					if (num6 >= 0)
					{
						xTextElement4 = xTextContentElement.PrivateContent.SafeGet(num6 + 1);
						if (xTextElement4 != null && xTextElement4.OwnerLine != null)
						{
							num5 = xTextContentElement.PrivateLines.IndexOf(xTextElement4.OwnerLine);
						}
					}
					for (int i = num4; i <= num5; i++)
					{
						if (i >= 0 && i <= xTextContentElement.PrivateLines.Count)
						{
							xTextContentElement.PrivateLines[i].InvalidateState = true;
						}
					}
				}
			}
			bool flag = true;
			XTextElementList range = elements.GetRange(geventArgs4_0.method_10(), geventArgs4_0.method_12());
			foreach (XTextElement item3 in range)
			{
				if (!(item3 is XTextCharElement))
				{
					flag = false;
					break;
				}
			}
			if (flag && geventArgs4_0.method_14() != null)
			{
				foreach (XTextElement item4 in geventArgs4_0.method_14())
				{
					if (!(item4 is XTextCharElement))
					{
						flag = false;
						break;
					}
				}
			}
			bool flag2 = false;
			if (range != null && range.Count > 0)
			{
				flag2 = true;
			}
			if (geventArgs4_0.method_14() != null && geventArgs4_0.method_14().Count > 0)
			{
				flag2 = true;
			}
			if (flag2 && geventArgs4_0.method_24())
			{
				ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
				contentChangingEventArgs.Document = this;
				contentChangingEventArgs.Element = geventArgs4_0.method_8();
				contentChangingEventArgs.ElementIndex = geventArgs4_0.method_10();
				contentChangingEventArgs.DeletingElements = range;
				contentChangingEventArgs.InsertingElements = geventArgs4_0.method_14();
				geventArgs4_0.method_8().method_22(contentChangingEventArgs);
				if (contentChangingEventArgs.Cancel)
				{
					return 0;
				}
			}
			ContentStyles.Styles.SetValueLocked(vLock: false);
			bool flag3 = false;
			if (!geventArgs4_0.method_26() && geventArgs4_0.method_8().RuntimeEnablePermission && Options.SecurityOptions.EnableLogicDelete)
			{
				for (int i = 0; i < geventArgs4_0.method_12(); i++)
				{
					XTextElement newElement = elements[geventArgs4_0.method_10() + i];
					if (newElement.RuntimeStyle.CreatorIndex != UserHistories.CurrentIndex)
					{
						flag3 = true;
						break;
					}
				}
			}
			XTextDocumentContentElement documentContentElement = geventArgs4_0.method_8().DocumentContentElement;
			documentContentElement.method_55();
			XTextElement xTextElement5 = documentContentElement.Selection.FirstElement;
			XTextElement item2 = documentContentElement.Selection.LastElement;
			if (xTextElement5 == null)
			{
				xTextElement5 = documentContentElement.Content.SafeGet(documentContentElement.Selection.AbsStartIndex);
				item2 = xTextElement5;
			}
			List<int> list = ContentStyles.method_7();
			int num7 = 0;
			if (geventArgs4_0.method_12() > 0)
			{
				if (list != null && list.Count > 0)
				{
					for (int i = 0; i < geventArgs4_0.method_12(); i++)
					{
						if (list != null && list.Contains(elements[geventArgs4_0.method_10() + i].StyleIndex) && !geventArgs4_0.method_2())
						{
							bool_22 = true;
						}
					}
				}
				for (int j = 0; j < geventArgs4_0.method_12(); j++)
				{
					ContentSnapshot.method_8(elements[geventArgs4_0.method_10() + j]);
				}
				if (flag3)
				{
					method_61(elements, geventArgs4_0.method_10(), geventArgs4_0.method_12(), bool_32: false, bool_33: true);
					documentContentElement.ParagraphTreeInvalidte = true;
				}
				else if (geventArgs4_0.method_12() == elements.Count)
				{
					if (WriterUtils.smethod_5(elements, 0, elements.Count - 1))
					{
						PageRefreshed = false;
					}
					elements.Clear();
					documentContentElement.ParagraphTreeInvalidte = true;
				}
				else
				{
					if (WriterUtils.smethod_5(elements, geventArgs4_0.method_10(), geventArgs4_0.method_10() + geventArgs4_0.method_12() - 1))
					{
						PageRefreshed = false;
					}
					elements.RemoveRange(geventArgs4_0.method_10(), geventArgs4_0.method_12());
					documentContentElement.ParagraphTreeInvalidte = true;
				}
				num7 += geventArgs4_0.method_12();
			}
			bool flag4 = EditorControl != null && EditorControl.IsUpdating;
			if (geventArgs4_0.method_14() != null && geventArgs4_0.method_14().Count > 0)
			{
				if (geventArgs4_0.method_26())
				{
					foreach (XTextElement item5 in geventArgs4_0.method_14())
					{
						DocumentContentStyle documentContentStyle = item5.RuntimeStyle.CloneParent();
						if (documentContentStyle.HasTitleLevel)
						{
							bool_22 = true;
						}
						documentContentStyle.CreatorIndex = -1;
						documentContentStyle.DeleterIndex = -1;
						item5.StyleIndex = ContentStyles.GetStyleIndex(documentContentStyle);
					}
				}
				if (!flag4)
				{
					using (DCGraphics dcgraphics_ = CreateDCGraphics())
					{
						foreach (XTextElement item6 in geventArgs4_0.method_14())
						{
							item6.SetParentRaw(geventArgs4_0.method_8());
							item6.method_5(this);
							if (!(item6 is XTextCharElement) && !(item6 is XTextParagraphFlagElement))
							{
								item6.FixDomState();
								item6.AfterLoad(new ElementLoadEventArgs(item6, null));
							}
							if (item6 is XTextParagraphFlagElement)
							{
								documentContentElement.ParagraphTreeInvalidte = true;
							}
							if (item6.SizeInvalid)
							{
								DocumentPaintEventArgs documentPaintEventArgs = method_55(dcgraphics_);
								documentPaintEventArgs.Element = item6;
								item6.RefreshSize(documentPaintEventArgs);
							}
							if (item6 is XTextCharElement)
							{
								if (WriterUtils.smethod_22(((XTextCharElement)item6).CharValue))
								{
									item6.SizeInvalid = true;
								}
							}
							else
							{
								HighlightManager?.imethod_9(item6);
							}
						}
					}
				}
				ContentSnapshot.method_9(geventArgs4_0.method_14());
				elements.method_12(geventArgs4_0.method_10(), geventArgs4_0.method_14());
				if (WriterUtils.smethod_5(geventArgs4_0.method_14(), 0, geventArgs4_0.method_14().Count - 1))
				{
					PageRefreshed = false;
				}
				xtextElementList_2 = geventArgs4_0.method_14().Clone();
				if (geventArgs4_0.method_8().RuntimeEnablePermission)
				{
					method_61(geventArgs4_0.method_14(), 0, geventArgs4_0.method_14().Count, bool_32: true, bool_33: false);
				}
				num7 += geventArgs4_0.method_14().Count;
			}
			if (geventArgs4_0.method_34() != null)
			{
				geventArgs4_0.method_34()(this, geventArgs4_0);
				num7++;
			}
			if (num7 > 0)
			{
				geventArgs4_0.method_8().UpdateContentVersion();
				geventArgs4_0.method_8().vmethod_35();
			}
			if (geventArgs4_0.method_18() && CanLogUndo)
			{
				if (flag3)
				{
					UndoList.AddReplaceElements(geventArgs4_0.method_8(), geventArgs4_0.method_10(), null, geventArgs4_0.method_14());
				}
				else
				{
					UndoList.AddReplaceElements(geventArgs4_0.method_8(), geventArgs4_0.method_10(), xTextElementList, geventArgs4_0.method_14());
				}
			}
			Modified = true;
			if (geventArgs4_0.method_20() && !flag4)
			{
				if (geventArgs4_0.method_14() != null && geventArgs4_0.method_14().Count > 0)
				{
					WriterUtils.smethod_49(geventArgs4_0.method_14(), method_64);
				}
				XTextContentElement.Class11 @class = new XTextContentElement.Class11();
				@class.method_3(num3);
				@class.method_7(bool_5: true);
				@class.method_9(bool_5: true);
				@class.method_11(bool_5: true);
				if (!Options.SecurityOptions.ShowLogicDeletedContent && flag3 && geventArgs4_0.method_12() > 0)
				{
					@class.method_9(bool_5: false);
				}
				@class.method_1(flag);
				xTextContentElement.vmethod_37(@class);
				xTextContentElement.vmethod_39(num3, xTextContentElement.PrivateContent.IndexOf(item), bool_22: false, bool_23: false);
				if (geventArgs4_0.method_12() > 0 && CommentManager != null && CommentManager.imethod_6(bool_0: true) && WriterControl != null)
				{
					WriterControl.InnerViewControl.Invalidate();
				}
				if (geventArgs4_0.method_22() && CopySourceExecuter != null)
				{
					CopySourceExecuter.imethod_2(geventArgs4_0.method_8());
				}
				documentContentElement.method_70();
				try
				{
					if (geventArgs4_0.method_0() && EditorControl != null && EditorControl.InnerViewControl != null)
					{
						EditorControl.InnerViewControl.LockScrollPositionOnce = true;
					}
					if (geventArgs4_0.method_32())
					{
						geventArgs4_0.method_8().Focus();
					}
					else if (geventArgs4_0.method_30())
					{
						if (currentElement != null)
						{
							documentContentElement.Content.AutoClearSelection = true;
							documentContentElement.Content.LineEndFlag = false;
							int num8 = currentElement.ViewIndex;
							if (!documentContentElement.Content.Contains(currentElement))
							{
								num8--;
							}
							if (geventArgs4_0.method_14() != null)
							{
								XTextElement xTextElement6 = geventArgs4_0.method_14().LastContentElement;
								if (xTextElement6 is XTextTableElement)
								{
									XTextTableElement xTextTableElement = (XTextTableElement)xTextElement6;
									xTextElement6 = xTextTableElement.GetCell(0, 0, throwException: true).FirstContentElement;
									num8 = xTextElement6.ViewIndex;
								}
								else if (xTextElement6 is XTextSectionElement)
								{
									XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement6;
									xTextElement6 = xTextSectionElement.FirstContentElement;
									num8 = xTextElement6.ViewIndex;
								}
								else if (xTextElement6 != null && documentContentElement.Content.Contains(xTextElement6))
								{
									num8 = xTextElement6.ViewIndex + 1;
								}
								xTextElement6?.method_11(bool_5: true, bool_6: true);
							}
							documentContentElement.Content.MoveToPosition(num8);
						}
					}
					else if (geventArgs4_0.method_30())
					{
						XTextElement xTextElement6 = null;
						if (geventArgs4_0.method_14() != null && geventArgs4_0.method_14().Count > 0)
						{
							xTextElement6 = geventArgs4_0.method_14().LastContentElement;
						}
						xTextElement6?.method_11(bool_5: true, bool_6: true);
						int num9 = documentContentElement.Content.IndexOf(xTextElement5);
						int num10 = documentContentElement.Content.IndexOf(item2);
						if (num9 >= 0 && num10 >= 0)
						{
							documentContentElement.Content.method_47(num9, num10 - num9);
						}
						else if (num9 >= 0 && num10 < 0)
						{
							documentContentElement.Content.method_47(num9, 0);
						}
						else if (num9 < 0 && num10 >= 0)
						{
							documentContentElement.Content.method_47(num10, 0);
						}
						else
						{
							documentContentElement.Content.method_47(documentContentElement.Selection.StartIndex, documentContentElement.Selection.Length);
						}
					}
				}
				finally
				{
					if (EditorControl != null && EditorControl.InnerViewControl != null)
					{
						EditorControl.InnerViewControl.LockScrollPositionOnce = false;
					}
				}
				if (EditorControl != null && geventArgs4_0.method_14() != null && !flag4)
				{
					foreach (XTextElement item7 in geventArgs4_0.method_14())
					{
						if (item7 is XTextControlHostElement)
						{
							XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)item7;
							if (xTextControlHostElement.SpecifyHostedInstance != null)
							{
							}
						}
					}
					if (EditorControl.ControlHostManger != null)
					{
						if (flag)
						{
							EditorControl.ControlHostManger.UpdateHostWindowsControlPosition();
						}
						else
						{
							EditorControl.ControlHostManger.ReloadControls();
						}
					}
				}
			}
			if (geventArgs4_0.method_24() && !flag4)
			{
				ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
				contentChangedEventArgs.Document = this;
				contentChangedEventArgs.Element = geventArgs4_0.method_8();
				contentChangedEventArgs.ElementIndex = geventArgs4_0.method_10();
				contentChangedEventArgs.EventSource = geventArgs4_0.method_6();
				if (geventArgs4_0.method_12() > 0)
				{
					contentChangedEventArgs.DeletedElements = range;
				}
				contentChangedEventArgs.InsertedElements = geventArgs4_0.method_14();
				geventArgs4_0.method_8().method_23(contentChangedEventArgs);
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			geventArgs4_0.method_5(tickCountFloat);
			geventArgs4_0.method_39(num7);
			return num7;
		}

		private void method_64(object sender, ElementEnumerateEventArgs e)
		{
			XTextElement element = e.Element;
			if (element is XTextTableElement)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)element;
				if (xTextTableElement.OwnerLine == null)
				{
					e.Cancel = true;
				}
				foreach (XTextTableCellElement cell in xTextTableElement.Cells)
				{
					cell.Width = 0f;
					cell.Height = 0f;
				}
				xTextTableElement.ExecuteLayout();
				e.CancelChild = true;
			}
			else if (element is XTextSectionElement)
			{
				XTextSectionElement xTextSectionElement = (XTextSectionElement)element;
				if (xTextSectionElement.OwnerLine == null)
				{
					e.Cancel = true;
				}
				xTextSectionElement.ExecuteLayout();
				e.CancelChild = true;
			}
		}

		/// <summary>
		///       创建段落对象
		///       </summary>
		/// <param name="elements">元素对象列表</param>
		/// <returns>创建的段落对象列表</returns>
		[DCInternal]
		public XTextElementList CreateParagraphs(IEnumerable elements)
		{
			int num = 10;
			if (elements == null)
			{
				throw new ArgumentNullException("elements");
			}
			XTextElementList xTextElementList = new XTextElementList();
			XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
			xTextParagraphElement.OwnerDocument = this;
			xTextParagraphElement.Parent = this;
			xTextElementList.Add(xTextParagraphElement);
			XTextParagraphFlagElement xTextParagraphFlagElement = null;
			foreach (XTextElement element in elements)
			{
				if (element is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)element;
					xTextParagraphElement.StyleIndex = xTextParagraphFlagElement2.StyleIndex;
					xTextParagraphElement.Elements.AddRaw(element);
					xTextParagraphElement = new XTextParagraphElement();
					xTextParagraphElement.OwnerDocument = this;
					xTextParagraphElement.Parent = this;
					xTextElementList.AddRaw(xTextParagraphElement);
				}
				else
				{
					xTextParagraphElement.Elements.AddRaw(element);
				}
				if (xTextParagraphFlagElement == null)
				{
					xTextParagraphFlagElement = element.OwnerParagraphEOF;
				}
			}
			for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
			{
				XTextParagraphElement xTextParagraphElement2 = (XTextParagraphElement)xTextElementList[num2];
				if (xTextParagraphElement2.Elements.Count == 0)
				{
					xTextElementList.RemoveAt(num2);
				}
				else if (!(xTextParagraphElement2.Elements.LastElement is XTextParagraphFlagElement))
				{
					xTextParagraphElement2.Elements.AddRaw(xTextParagraphFlagElement);
				}
			}
			foreach (XTextParagraphElement item in xTextElementList)
			{
				XTextElementList collection = WriterUtils.smethod_60(item.Elements, bool_2: false);
				item.Elements.Clear();
				item.Elements.AddRange(collection);
			}
			return xTextElementList;
		}

		/// <summary>
		///       是否可以启用UI层的编辑内容操作
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[DCInternal]
		public bool UIStartEditContent()
		{
			if (writerControl_0 != null)
			{
				return writerControl_0.UIStartEditContent();
			}
			return false;
		}

		/// <summary>
		///       执行文档中的表格的分栏操作
		///       </summary>
		/// <param name="updateView">是否更新视图</param>
		/// <returns>
		/// </returns>
		[DCInternal]
		[ComVisible(true)]
		public bool ExecuteTableSubfield(bool updateView)
		{
			bool flag = false;
			foreach (XTextTableElement table in Tables)
			{
				if (table.Subfield(updateView: false))
				{
					flag = true;
				}
			}
			if (flag && updateView)
			{
				if (WriterControl != null)
				{
					WriterControl.RefreshDocument();
				}
				else
				{
					EditorRefreshView();
				}
			}
			return flag;
		}

		public override void EditorRefreshViewExt(bool fastMode)
		{
			if (!fastMode)
			{
				ElementLoadEventArgs elementLoadEventArgs = new ElementLoadEventArgs(this, null);
				elementLoadEventArgs.UpdateValueBinding = false;
				AfterLoad(elementLoadEventArgs);
			}
			if (EditorControl == null || !EditorControl.IsUpdating)
			{
				RefreshSizeWithoutParamter();
				ExecuteLayout();
				RefreshPages();
			}
		}

		private void method_65(XTextContainerElement xtextContainerElement_1, XTextElementList xtextElementList_5)
		{
			foreach (XTextElement element in xtextContainerElement_1.Elements)
			{
				if (element is XTextContainerElement)
				{
					if (element is XTextTableElement)
					{
						xtextElementList_5.AddRaw(element);
						XTextTableElement xTextTableElement = (XTextTableElement)element;
						foreach (XTextTableRowElement row in xTextTableElement.Rows)
						{
							foreach (XTextTableCellElement cell in row.Cells)
							{
								method_65(cell, xtextElementList_5);
							}
						}
					}
					else
					{
						method_65((XTextContainerElement)element, xtextElementList_5);
					}
				}
			}
		}

		/// <summary>
		///       获得文档中所有指定名称的复选框元素列表
		///       </summary>
		/// <param name="name">指定的名称</param>
		/// <returns>元素列表</returns>
		[DCInternal]
		public XTextElementList GetCheckBoxElementsSpecifyName(string name)
		{
			return CheckBoxGroupInfo.method_3(name, typeof(XTextCheckBoxElement));
		}

		/// <summary>
		///       获得文档中所有指定名称的单选框元素列表
		///       </summary>
		/// <param name="name">指定的名称</param>
		/// <returns>元素列表</returns>
		[DCInternal]
		public XTextElementList GetRadioBoxElementsSpecifyName(string name)
		{
			return CheckBoxGroupInfo.method_3(name, typeof(XTextRadioBoxElement));
		}

		/// <summary>
		///       获得指定表格中的指定单元格
		///       </summary>
		/// <param name="tableID">编号编号</param>
		/// <param name="rowIndex">从0开始计算的行号</param>
		/// <param name="colIndex">从0开始计算的列号</param>
		/// <returns>获得的单元格对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextTableCellElement GetTableCell(string tableID, int rowIndex, int colIndex)
		{
			XTextTableElement xTextTableElement = null;
			XTextElement firstChild = Body.FirstChild;
			return ((!(firstChild is XTextTableElement) || !(firstChild.ID == tableID)) ? (GetElementById(tableID) as XTextTableElement) : ((XTextTableElement)firstChild))?.GetCell(rowIndex, colIndex, throwException: false);
		}

		/// <summary>
		///       获得表格单元格的文本内容
		///       </summary>
		/// <param name="tableID">表格编号</param>
		/// <param name="rowIndex">从0开始计算的行号</param>
		/// <param name="colIndex">从0开始计算的列号</param>
		/// <returns>单元格文本</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetTableCellText(string tableID, int rowIndex, int colIndex)
		{
			return GetTableCell(tableID, rowIndex, colIndex)?.Text;
		}

		/// <summary>
		///       设置单元格文本值
		///       </summary>
		/// <param name="tableID">表格编号</param>
		/// <param name="rowIndex">从0开始计算的行号</param>
		/// <param name="colIndex">从0开始计算的列号</param>
		/// <param name="newText">新文本值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetTableCellText(string tableID, int rowIndex, int colIndex, string newText)
		{
			XTextTableCellElement tableCell = GetTableCell(tableID, rowIndex, colIndex);
			if (tableCell != null)
			{
				return SetElementText(tableCell, newText);
			}
			return false;
		}

		/// <summary>
		///       获得指定编号的输入域的InnerValue属性值。
		///       </summary>
		/// <param name="id">输入域编号</param>
		/// <returns>获得的属性值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetInputFieldInnerValue(string string_26)
		{
			return (GetElementById(string_26) as XTextInputFieldElement)?.InnerValue;
		}

		/// <summary>
		///       设置指定编号的输入域的InnerValue属性值。
		///       </summary>
		/// <param name="id">输入域编号</param>
		/// <param name="newValue">新的属性值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetInputFieldInnerValue(string string_26, string newValue)
		{
			XTextInputFieldElement xTextInputFieldElement = GetElementById(string_26) as XTextInputFieldElement;
			if (xTextInputFieldElement != null)
			{
				xTextInputFieldElement.InnerValue = newValue;
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得指定编号的子文档内容XML字符串
		///       </summary>
		/// <param name="id">子文档元素编号</param>
		/// <returns>获得的XML字符串</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetSubDoumentContentXmlByID(string string_26)
		{
			return (GetElementById(string_26) as XTextSubDocumentElement)?.SaveDocumentToString(null);
		}

		/// <summary>
		///       返回包含数据的XML片段,本函数返回的XML字符串可以作为编辑器控件或文档对象的函数CreateElementByXMLFragment()的参数。
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>生成的XML片段字符串</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetElementXMLFragmentByID(string string_26)
		{
			return GetElementById(string_26)?.GetXMLFragment();
		}

		/// <summary>
		///       返回元素内置内容的文档XML字符串
		///       </summary>
		/// <param name="id">文档元素对象</param>
		/// <returns>获得的XML字符串</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetElementOuterXmlByID(string string_26)
		{
			return GetElementById(string_26)?.OuterXML;
		}

		/// <summary>
		///       返回元素外置内容的文档XML字符串
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>XML字符串</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetElementInnerXmlByID(string string_26)
		{
			return GetElementById(string_26)?.InnerText;
		}

		/// <summary>
		///       获得指定编号的元素文本值
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>文本值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetElementTextByID(string string_26)
		{
			XTextElement elementById = GetElementById(string_26);
			string text = null;
			if (elementById != null)
			{
				if (elementById is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)elementById;
					text = xTextContainerElement.Text;
				}
				else if (elementById is XTextLabelElement)
				{
					XTextLabelElement xTextLabelElement = (XTextLabelElement)elementById;
					text = xTextLabelElement.Text;
				}
				else if (elementById is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)elementById;
					text = xTextCheckBoxElementBase.Caption;
				}
				else
				{
					text = elementById.Text;
				}
			}
			if (text == null)
			{
				return "";
			}
			return text;
		}

		/// <summary>
		///       获得指定编号的元素文本值
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>文本值</returns>
		[Obsolete("请使用GetElementTextByID(id)")]
		public string GetElementText(string string_26)
		{
			return GetElementTextByID(string_26);
		}

		/// <summary>
		///       设置输入域选择多个下拉项目
		///       </summary>
		/// <param name="id">输入域编号</param>
		/// <param name="indexs">从0开始的下拉项目序号，各个序号之间用逗号分开</param>
		/// <returns>操作是否修改文档内容</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetInputFieldSelectedIndexs(string string_26, string indexs)
		{
			return (GetElementById(string_26) as XTextInputFieldElement)?.EditorSetSelectedIndexs(indexs) ?? false;
		}

		/// <summary>
		///       设置文档元素文档的文本值
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetElementTextByID(string string_26, string text)
		{
			XTextElement elementById = GetElementById(string_26);
			if (elementById != null)
			{
				return SetElementText(elementById, text);
			}
			return false;
		}

		/// <summary>
		///       设置文档元素文档的文本值
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		[Obsolete("请使用SetElementTextByID(id,text)")]
		[ComVisible(false)]
		public bool SetElementText(string string_26, string text)
		{
			XTextElement elementById = GetElementById(string_26);
			if (elementById != null)
			{
				return SetElementText(elementById, text);
			}
			return false;
		}

		/// <summary>
		///       设置文档元素文本值
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		public bool SetElementText(XTextElement element, string text)
		{
			int num = 1;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (element is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)element;
				return xTextContainerElement.SetEditorTextExt(text, DomAccessFlags.None, disablePermissioin: true, updateContent: true);
			}
			if (element is XTextLabelElement)
			{
				XTextLabelElement xTextLabelElement = (XTextLabelElement)element;
				if (xTextLabelElement.Text != text)
				{
					xTextLabelElement.Text = text;
					if (xTextLabelElement.RuntimeAutoSize)
					{
						xTextLabelElement.EditorRefreshView();
					}
					else
					{
						xTextLabelElement.InvalidateView();
					}
				}
				return true;
			}
			if (element is XTextCheckBoxElementBase)
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)element;
				if (xTextCheckBoxElementBase.Caption != text)
				{
					xTextCheckBoxElementBase.Caption = text;
					xTextCheckBoxElementBase.EditorRefreshView();
				}
				return true;
			}
			element.Text = text;
			return true;
		}

		/// <summary>
		///       设置指定图片元素的图片内容
		///       </summary>
		/// <param name="id">编号</param>
		/// <param name="img">图片内容</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool SetElementImageContent(string string_26, Image image_0)
		{
			XTextImageElement xTextImageElement = GetElementById(string_26) as XTextImageElement;
			if (xTextImageElement != null)
			{
				xTextImageElement.method_20(image_0, bool_17: true, bool_18: false);
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得指定文档元素的可见性
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <returns>可见性</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool GetElementVisible(string string_26)
		{
			return GetElementById(string_26)?.RuntimeVisible ?? false;
		}

		/// <summary>
		///       设置文档元素的可见性
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="visible">文本值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetElementVisible(string string_26, bool visible)
		{
			return GetElementById(string_26)?.EditorSetVisibleExt(visible, logUndo: false, fastMode: false) ?? false;
		}

		/// <summary>
		///       获得文档中所有指定编号的元素对象列表,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <returns>找到的元素对象列表</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override XTextElementList GetElementsById(string string_26)
		{
			int num = 13;
			if (string.IsNullOrEmpty(string_26))
			{
				return null;
			}
			if (string.Compare(string_26, "Header", ignoreCase: true) == 0)
			{
				return new XTextElementList(Header);
			}
			if (string.Compare(string_26, "Body", ignoreCase: true) == 0)
			{
				return new XTextElementList(Body);
			}
			if (string.Compare(string_26, "Footer", ignoreCase: true) == 0)
			{
				return new XTextElementList(Footer);
			}
			return base.GetElementsById(string_26);
		}

		/// <summary>
		///       获得文档中指定编号的元素对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <returns>找到的元素对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override XTextElement GetElementById(string string_26)
		{
			int num = 10;
			if (string.IsNullOrEmpty(string_26))
			{
				return null;
			}
			if (string.Compare(string_26, "Header", ignoreCase: true) == 0)
			{
				return Header;
			}
			if (string.Compare(string_26, "Body", ignoreCase: true) == 0)
			{
				return Body;
			}
			if (string.Compare(string_26, "Footer", ignoreCase: true) == 0)
			{
				return Footer;
			}
			return base.GetElementById(string_26);
		}

		/// <summary>
		///       获得文档中指定类型的下一个元素
		///       </summary>
		/// <param name="startElement">开始查找的起始元素</param>
		/// <param name="nextElementTypeName">要查找的元素的类型的名称</param>
		/// <returns>找到的元素</returns>
		[ComVisible(true)]
		public XTextElement GetNextElementByTypeName(XTextElement startElement, string nextElementTypeName)
		{
			Type controlType = ControlHelper.GetControlType(nextElementTypeName, typeof(XTextElement));
			if (controlType == null)
			{
				throw new ArgumentException(nextElementTypeName);
			}
			return GetNextElement(startElement, controlType, includeHiddenElement: false);
		}

		/// <summary>
		///       获得文档中指定类型的下一个元素
		///       </summary>
		/// <param name="startElement">开始查找的起始元素</param>
		/// <param name="nextElementType">要查找的元素的类型</param>
		/// <returns>找到的元素</returns>
		public XTextElement GetNextElement(XTextElement startElement, Type nextElementType)
		{
			return GetNextElement(startElement, nextElementType, includeHiddenElement: false);
		}

		/// <summary>
		///       获得文档中指定类型的下一个元素
		///       </summary>
		/// <param name="startElement">开始查找的起始元素</param>
		/// <param name="nextElementType">要查找的元素的类型</param>
		/// <param name="includeHiddenElement">查找的时候是否查找隐藏的文档元素对象</param>
		/// <returns>找到的元素</returns>
		public XTextElement GetNextElement(XTextElement startElement, Type nextElementType, bool includeHiddenElement)
		{
			int num = 2;
			if (startElement == null)
			{
				throw new ArgumentNullException("startElement");
			}
			if (nextElementType == null)
			{
				throw new ArgumentNullException("nextElementType");
			}
			XTextElement result = null;
			bool flag = false;
			XTextDocumentContentElement documentContentElement = startElement.DocumentContentElement;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(documentContentElement);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (!includeHiddenElement && !item.RuntimeVisible)
				{
					domTreeNodeEnumerable.CancelChild();
				}
				else if (flag)
				{
					if (nextElementType.IsInstanceOfType(item))
					{
						result = item;
						break;
					}
				}
				else if (item == startElement)
				{
					flag = true;
				}
			}
			return result;
		}

		/// <summary>
		///       获得文档中所有的勾选的复选框元素的值
		///       </summary>
		/// <param name="spliter">各个项目之间的分隔字符串</param>
		/// <param name="includeCheckbox">是否包含复选框</param>
		/// <param name="includeRadio">是否包含单选框</param>
		/// <param name="includeElementID">是否包含元素ID号</param>
		/// <param name="includeElementName">是否包含元素Name属性值</param>
		/// <returns>获得的字符串</returns>
		/// <remarks>
		///       例如调用 document.GetCheckedValueList(";",true,true,true,true) 返回类似字符串
		///       “xbzw;胸部正位;gpzw;骨盆正位;fbww;腹部卧位”
		///       </remarks>
		[ComVisible(true)]
		public string GetCheckedValueList(string spliter, bool includeCheckbox, bool includeRadio, bool includeElementID, bool includeElementName)
		{
			if (!includeCheckbox && !includeRadio)
			{
				return string.Empty;
			}
			if (!includeElementID && !includeElementName)
			{
				return string.Empty;
			}
			XTextElementList elementsByType = GetElementsByType(typeof(XTextCheckBoxElementBase));
			StringBuilder stringBuilder = new StringBuilder();
			foreach (XTextCheckBoxElementBase item in elementsByType)
			{
				if (item.Checked && (includeCheckbox || !(item is XTextCheckBoxElement)) && (includeRadio || !(item is XTextRadioBoxElement)))
				{
					if (stringBuilder.Length > 0 && spliter != null)
					{
						stringBuilder.Append(spliter);
					}
					if (includeElementID)
					{
						stringBuilder.Append(item.ID);
					}
					if (spliter != null)
					{
						stringBuilder.Append(spliter);
					}
					if (includeElementName)
					{
						stringBuilder.Append(item.Name);
					}
				}
			}
			return stringBuilder.ToString();
		}

		[DCInternal]
		public XTextDocumentContentElement method_66(PageContentPartyStyle pageContentPartyStyle_0)
		{
			switch (pageContentPartyStyle_0)
			{
			case PageContentPartyStyle.Header:
				return Header;
			case PageContentPartyStyle.Footer:
				return Footer;
			case PageContentPartyStyle.Body:
				return Body;
			default:
				return Body;
			case PageContentPartyStyle.HeaderForFirstPage:
				return HeaderForFirstPage;
			case PageContentPartyStyle.FooterForFirstPage:
				return FooterForFirstPage;
			}
		}

		[DCInternal]
		public void method_67(XTextElement xtextElement_3)
		{
			int num = 7;
			if (xtextElement_3 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (!IsLoadingDocument && EditorControl != null && !EditorControl.IsUpdating && xtextElement_3 is XTextControlHostElement && EditorControl.ControlHostManger != null)
			{
				EditorControl.ControlHostManger.InvalidateLayout((XTextControlHostElement)xtextElement_3);
			}
		}

		internal RectangleF method_68(XTextElement xtextElement_3)
		{
			int num = 15;
			if (xtextElement_3 == null)
			{
				throw new ArgumentNullException("element");
			}
			RectangleF rectangleF = xtextElement_3.AbsBounds;
			rectangleF.Width = xtextElement_3.ViewWidth + xtextElement_3.WidthFix;
			if (WriterControl != null && WriterControl.InnerViewControl != null)
			{
				Class137 viewHandleManager = WriterControl.InnerViewControl.ViewHandleManager;
				GClass3 gClass = viewHandleManager.method_6(xtextElement_3);
				if (gClass != null)
				{
					rectangleF = RectangleF.Union(rectangleF, gClass.method_18());
				}
			}
			if (xtextElement_3.RuntimeZOrderStyle == ElementZOrderStyle.Normal && xtextElement_3.OwnerLine != null)
			{
				rectangleF.Y = xtextElement_3.OwnerLine.AbsTop;
				if (xtextElement_3.RuntimeStyle.LayoutAlign == ContentLayoutAlign.EmbedInText)
				{
					rectangleF.Height = Math.Max(xtextElement_3.OwnerLine.Height, xtextElement_3.Height);
					if (xtextElement_3.Height > xtextElement_3.OwnerLine.Height)
					{
						rectangleF.Y -= xtextElement_3.Height - xtextElement_3.OwnerLine.Height;
						rectangleF.Height = xtextElement_3.Height;
					}
				}
			}
			if (xtextElement_3.RuntimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings)
			{
				rectangleF.Height = Math.Max(rectangleF.Height, xtextElement_3.Top + xtextElement_3.Height);
			}
			if (!(xtextElement_3 is XTextParagraphFlagElement))
			{
			}
			if (!(xtextElement_3 is XTextCharElement))
			{
				XTextElement xTextElement = xtextElement_3;
				if (xtextElement_3 is XTextFieldBorderElement)
				{
					xTextElement = xtextElement_3.Parent;
				}
				if (!string.IsNullOrEmpty(xTextElement.RuntimeAdornText))
				{
					RectangleF b = AdornTextMan.method_4(xTextElement);
					if (!b.IsEmpty)
					{
						rectangleF = RectangleF.Union(rectangleF, b);
					}
					else if (AdornTextMan.method_1(xTextElement))
					{
						SizeF sizeF = AdornTextMan.method_5(xTextElement.RuntimeAdornText);
						rectangleF.Y -= sizeF.Height;
						rectangleF.Height += sizeF.Height;
						rectangleF.Width = Math.Max(rectangleF.Width, sizeF.Width);
					}
				}
			}
			return rectangleF;
		}

		[DCInternal]
		public void method_69(XTextElement xtextElement_3)
		{
			int num = 16;
			if (!bool_21 || IsLoadingDocument)
			{
				return;
			}
			if (xtextElement_3 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (EditorControl != null && !EditorControl.IsUpdating && !EditorControl.InnerViewControl.IsFreezeUI)
			{
				if (xtextElement_3 == this)
				{
					EditorControl.InnerViewControl.Invalidate();
				}
				else if (xtextElement_3.DocumentContentElement != null)
				{
					RectangleF rect = method_68(xtextElement_3);
					EditorControl.ViewInvalidate(rect, xtextElement_3.DocumentContentElement.ContentPartyStyle);
				}
			}
		}

		[DCInternal]
		public void method_70(RectangleF rectangleF_1)
		{
			if (bool_21 && !IsLoadingDocument && EditorControl != null && !EditorControl.IsUpdating)
			{
				EditorControl.ViewInvalidate(rectangleF_1, CurrentContentPartyStyle);
			}
		}

		[DCInternal]
		public void method_71(XTextRange xtextRange_0)
		{
			if (bool_21 && !IsLoadingDocument && xtextRange_0 != null && EditorControl != null && !EditorControl.IsUpdating && !EditorControl.InnerViewControl.IsFreezeUI)
			{
				foreach (XTextElement item in xtextRange_0)
				{
					method_69(item);
				}
			}
		}

		/// <summary>
		///       根据一个XML字符串创建一个文档元素对象
		///       </summary>
		/// <param name="xml">XML字符串</param>
		/// <returns>创建的文档元素对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElement CreateElementByXMLFragment(string string_26)
		{
			if (string.IsNullOrEmpty(string_26))
			{
				return null;
			}
			XTextElement xTextElement = XMLContentSerializer.smethod_0(string_26, bool_0: false);
			if (xTextElement != null)
			{
				xTextElement.OwnerDocument = this;
			}
			return xTextElement;
		}

		/// <summary>
		///       创建一个文档批注对象
		///       </summary>
		/// <returns>创建的对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public DocumentComment CreateComment()
		{
			method_98();
			return new DocumentComment();
		}

		/// <summary>
		///       创建一个新的文档
		///       </summary>
		/// <returns>创建的文档</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextDocument CreateDocumentFragment()
		{
			return new XTextDocument();
		}

		/// <summary>
		///       创建一个文档元素
		///       </summary>
		/// <param name="typeName">指定的文档元素类型名称</param>
		/// <returns>创建的文档元素</returns>
		/// <remarks>
		///       例如 doc.CreateElement("XTextInputFieldElement");
		///       </remarks>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElement CreateElement(string typeName)
		{
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType == null)
			{
				return null;
			}
			return CreateElementByType(controlType);
		}

		/// <summary>
		///       创建一个文档元素
		///       </summary>
		/// <param name="elementType">指定的文档元素类型</param>
		/// <returns>创建的文档元素</returns>
		[DCPublishAPI]
		public XTextElement CreateElementByType(Type elementType)
		{
			int num = 11;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new ArgumentOutOfRangeException(elementType.FullName);
			}
			if (typeof(XTextSectionElement).IsAssignableFrom(elementType) && !smethod_13(GEnum6.const_85))
			{
				return null;
			}
			XTextElement xTextElement = (XTextElement)Activator.CreateInstance(elementType);
			if (xTextElement != null && !(xTextElement is XTextDocument))
			{
				xTextElement.OwnerDocument = this;
				xTextElement.Parent = null;
				xTextElement.StyleIndex = -1;
			}
			return xTextElement;
		}

		/// <summary>
		///       创建一个图片元素对象
		///       </summary>
		/// <returns>创建的图片元素</returns>
		[DCPublishAPI]
		public XTextImageElement CreateImage()
		{
			method_98();
			return (XTextImageElement)CreateElementByType(typeof(XTextImageElement));
		}

		/// <summary>
		///       根据一个字符串创建若干个字符文本元素
		///       </summary>
		/// <param name="strText">字符串</param>
		/// <returns>创建的字符文本元素组成的列表</returns>
		[DCPublishAPI]
		public XTextElementList CreateChars(string strText)
		{
			method_98();
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			foreach (char char_ in strText)
			{
				XTextCharElement xTextCharElement = method_72(char_);
				if (xTextCharElement != null)
				{
					xTextElementList.Add(xTextCharElement);
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       创建一个字符串节点对象
		///       </summary>
		/// <param name="txt">文本内容</param>
		/// <returns>生成的字符串元素对象</returns>
		[ComVisible(true)]
		[DCInternal]
		public XTextStringElement CreateTextNode(string string_26)
		{
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.Text = string_26;
			xTextStringElement.OwnerDocument = this;
			return xTextStringElement;
		}

		/// <summary>
		///       根据一个字符串创建若干个字符文本元素
		///       </summary>
		/// <param name="strText">字符串</param>
		/// <param name="styleIndex">指定的样式编号</param>
		/// <returns>创建的字符文本元素组成的列表</returns>
		[DCPublishAPI]
		public XTextElementList CreateChars(string strText, int styleIndex)
		{
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			foreach (char char_ in strText)
			{
				XTextCharElement xTextCharElement = method_73(char_, styleIndex);
				if (xTextCharElement != null)
				{
					xTextElementList.Add(xTextCharElement);
				}
			}
			return xTextElementList;
		}

		[DCPublishAPI]
		public XTextCharElement method_72(char char_0)
		{
			return method_73(char_0, ContentStyles.GetStyleIndex(CurrentStyleInfo.Content));
		}

		[DCPublishAPI]
		public XTextCharElement method_73(char char_0, int int_18)
		{
			if (char_0 == '\n' || char_0 == '\r')
			{
				return null;
			}
			if (char_0 < ' ' && char_0 != '\t')
			{
				return null;
			}
			XTextCharElement xTextCharElement = new XTextCharElement();
			xTextCharElement.CharValue = char_0;
			xTextCharElement.StyleIndex = int_18;
			xTextCharElement.OwnerDocument = this;
			xTextCharElement.Parent = this;
			return xTextCharElement;
		}

		internal bool method_74(bool bool_32 = false)
		{
			if (documentCommentList_0 != null && documentCommentList_0.Count > 0)
			{
				return true;
			}
			if (documentCommentList_1 != null && documentCommentList_1.Count > 0)
			{
				if (bool_32)
				{
					return documentCommentList_1.HasVisibleComment;
				}
				return true;
			}
			return false;
		}

		internal void method_75()
		{
			if (bool_22)
			{
				bool_22 = false;
				if (EditorControl != null)
				{
					EditorControl.vmethod_17(new WriterEventArgs(EditorControl, this, null));
				}
			}
		}

		[DCInternal]
		private bool method_76()
		{
			if (!Options.BehaviorOptions.EnableCompressUserHistories)
			{
				return false;
			}
			ContentStyles.Styles.SetValueLocked(vLock: false);
			new List<int>();
			bool[] array = new bool[UserHistories.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = false;
			}
			if (!UserHistories._CanCompressLastItem && UserHistories.Count > 0)
			{
				array[UserHistories.Count - 1] = true;
			}
			foreach (DocumentContentStyle style in ContentStyles.Styles)
			{
				if (style.CreatorIndex >= 0 && style.CreatorIndex < array.Length)
				{
					array[style.CreatorIndex] = true;
				}
				if (style.DeleterIndex >= 0 && style.DeleterIndex < array.Length)
				{
					array[style.DeleterIndex] = true;
				}
			}
			bool result = false;
			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (!array[i])
				{
					result = true;
					UserHistories.RemoveAt(i);
					foreach (DocumentContentStyle style2 in ContentStyles.Styles)
					{
						if (style2.CreatorIndex >= i)
						{
							style2.CreatorIndex--;
						}
						if (style2.DeleterIndex >= i)
						{
							style2.DeleterIndex--;
						}
					}
				}
			}
			return result;
		}

		public XTextParagraphFlagElement method_77(XTextElement xtextElement_3)
		{
			int num = 8;
			if (xtextElement_3 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextElement_3 is XTextParagraphFlagElement)
			{
				return (XTextParagraphFlagElement)xtextElement_3;
			}
			XTextContentElement xTextContentElement = xtextElement_3.ContentElement;
			if (xtextElement_3 is XTextSectionElement)
			{
				xTextContentElement = (XTextContentElement)xtextElement_3.Parent;
			}
			if (xTextContentElement != null)
			{
				XTextElementList privateContent = xTextContentElement.PrivateContent;
				int i = privateContent.IndexOf(xtextElement_3);
				if (i < 0)
				{
					Debug.WriteLine("GetParagraphEOFElement:元素不包含在内容中。");
					return privateContent.LastElement as XTextParagraphFlagElement;
				}
				for (; i < privateContent.Count; i++)
				{
					if (privateContent[i] is XTextParagraphFlagElement)
					{
						return (XTextParagraphFlagElement)privateContent[i];
					}
				}
			}
			return null;
		}

		[DCInternal]
		public bool method_78(XTextElement xtextElement_3)
		{
			if (xtextElement_3 == null)
			{
				return false;
			}
			if (!Options.BehaviorOptions.EnableExpression)
			{
				return false;
			}
			XTextElement xTextElement = xtextElement_3;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement.RuntimeStyle.DeleterIndex < 0)
					{
						if (!xTextElement.RuntimeVisible)
						{
							break;
						}
						xTextElement = xTextElement.Parent;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		internal void method_79()
		{
			ginterface4_0 = null;
		}

		[DCInternal]
		internal string method_80(XTextElement xtextElement_3)
		{
			if (ginterface4_0 != null)
			{
				return ginterface4_0.imethod_2(xtextElement_3);
			}
			return null;
		}

		private HighlightInfoList method_81()
		{
			return null;
		}

		/// <summary>
		///       判断鼠标是否悬停在对象上面
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <returns>是否悬停</returns>
		[DCPublishAPI]
		public bool IsHover(XTextElement element)
		{
			int num = 0;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (HoverElement == null)
			{
				return false;
			}
			XTextElement xTextElement = HoverElement;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement == element)
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				return false;
			}
			return true;
		}

		private void method_82(XTextElement xtextElement_3, XTextElement xtextElement_4)
		{
			if (EditorControl != null)
			{
				EditorControl.vmethod_0(xtextElement_3, xtextElement_4);
			}
		}

		/// <summary>
		///       处理用户界面事件
		///       </summary>
		/// <param name="args">事件参数</param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.MouseDown)
			{
				if (writerControl_0 != null)
				{
					writerControl_0.InnerViewControl.UseAbsTransformPoint = true;
				}
				XTextElement elementAt = GetElementAt(args.X, args.Y, strict: true);
				if (elementAt != null)
				{
					method_84(elementAt, args);
					if (EditorControl != null && EditorControl.EnabledEventMessage)
					{
						WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForMouseEvent(WriterControlEventMessageType.MouseDown, args);
						writerControlEventMessage.SrcElement = elementAt;
						writerControlEventMessage.ToElement = elementAt;
						EditorControl.method_49(writerControlEventMessage);
					}
				}
			}
			else if (args.Style == DocumentEventStyles.MouseMove)
			{
				if (args.Button == MouseButtons.None)
				{
					gclass132_0 = null;
				}
				if (gclass132_0 != null)
				{
					gclass132_0.method_9(args.X);
					gclass132_0.method_11(args.Y);
					gclass132_0.method_1(bool_1: true);
					Content.AutoClearSelection = false;
					Content.MoveToPoint(args.X, args.Y);
					Content.AutoClearSelection = true;
					EditorControl.InnerViewControl.MoveCaretWithScroll = false;
					EditorControl.UpdateTextCaret();
					EditorControl.InnerViewControl.MoveCaretWithScroll = true;
				}
				else
				{
					if (args.Button != 0)
					{
						return;
					}
					XTextElement elementAt = args.StrictMatch ? GetElementAt(args.X, args.Y, strict: true) : null;
					if (elementAt != xtextElement_0)
					{
						XTextElementList xTextElementList = (HoverElement == null) ? new XTextElementList() : WriterUtils.smethod_58(HoverElement);
						if (HoverElement != null)
						{
							xTextElementList.method_13(0, HoverElement);
						}
						XTextElementList xTextElementList2 = (elementAt == null) ? new XTextElementList() : WriterUtils.smethod_58(elementAt);
						if (elementAt != null)
						{
							xTextElementList2.method_13(0, elementAt);
						}
						else
						{
							xTextElementList2.Add(this);
						}
						foreach (XTextElement item in xTextElementList)
						{
							if (xTextElementList2.Contains(item))
							{
								break;
							}
							DocumentEventArgs documentEventArgs = args.Clone();
							documentEventArgs.intStyle = DocumentEventStyles.MouseLeave;
							documentEventArgs.Element = item;
							item.HandleDocumentEvent(documentEventArgs);
							if (documentEventArgs.Handled)
							{
								break;
							}
							if (EditorControl != null && EditorControl.EnabledEventMessage)
							{
								WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForMouseEvent(WriterControlEventMessageType.MouseLeave, args);
								writerControlEventMessage.FromElement = item;
								writerControlEventMessage.ToElement = item;
								EditorControl.method_49(writerControlEventMessage);
							}
						}
						foreach (XTextElement item2 in xTextElementList2)
						{
							if (xTextElementList.Contains(item2))
							{
								break;
							}
							DocumentEventArgs documentEventArgs = args.Clone();
							documentEventArgs.intStyle = DocumentEventStyles.MouseEnter;
							documentEventArgs.Element = item2;
							item2.HandleDocumentEvent(documentEventArgs);
							if (documentEventArgs.Handled)
							{
								break;
							}
							if (EditorControl != null && EditorControl.EnabledEventMessage)
							{
								WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForMouseEvent(WriterControlEventMessageType.MouseEnter, args);
								writerControlEventMessage.FromElement = item2;
								writerControlEventMessage.ToElement = item2;
								EditorControl.method_49(writerControlEventMessage);
							}
						}
					}
					if (elementAt != xtextElement_0)
					{
						XTextElement xtextElement_ = xtextElement_0;
						HoverElement = elementAt;
						method_82(xtextElement_, elementAt);
					}
					if (elementAt == null)
					{
						elementAt = GetElementAt(args.X, args.Y, strict: true);
					}
					if (elementAt != null)
					{
						method_84(elementAt, args);
						if (!args.Handled && EditorControl != null && EditorControl.EnabledEventMessage)
						{
							WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForMouseEvent(WriterControlEventMessageType.MouseMove, args);
							writerControlEventMessage.FromElement = elementAt;
							writerControlEventMessage.ToElement = elementAt;
							EditorControl.method_49(writerControlEventMessage);
						}
					}
				}
			}
			else if (args.Style == DocumentEventStyles.MouseUp || args.Style == DocumentEventStyles.MouseClick || args.Style == DocumentEventStyles.MouseDblClick)
			{
				writerControl_0.InnerViewControl.UseAbsTransformPoint = false;
				if (gclass132_0 == null || !gclass132_0.method_0())
				{
					XTextElement elementAt = GetElementAt(args.X, args.Y, strict: true);
					if (elementAt != null)
					{
						method_84(elementAt, args);
					}
					if (!args.Handled && EditorControl != null && EditorControl.EnabledEventMessage)
					{
						WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForMouseEvent(WriterControlEventMessageType.MouseMove, args);
						if (args.Style == DocumentEventStyles.MouseUp)
						{
							writerControlEventMessage.TypeValue = WriterControlEventMessageType.MouseUp;
						}
						else if (args.Style == DocumentEventStyles.MouseClick)
						{
							writerControlEventMessage.TypeValue = WriterControlEventMessageType.MouseClick;
						}
						else if (args.Style == DocumentEventStyles.MouseDblClick)
						{
							writerControlEventMessage.TypeValue = WriterControlEventMessageType.MouseDblClick;
						}
						writerControlEventMessage.FromElement = elementAt;
						writerControlEventMessage.ToElement = elementAt;
						EditorControl.method_49(writerControlEventMessage);
					}
				}
				gclass132_0 = null;
			}
			else if (args.Style == DocumentEventStyles.MouseLeave)
			{
				if (HoverElement != null)
				{
					XTextElement xtextElement_ = HoverElement;
					method_84(HoverElement, args);
					if (EditorControl != null && EditorControl.EnabledEventMessage)
					{
						WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForMouseEvent(WriterControlEventMessageType.MouseLeave, args);
						writerControlEventMessage.FromElement = xtextElement_;
						writerControlEventMessage.ToElement = xtextElement_;
						EditorControl.method_49(writerControlEventMessage);
					}
					HoverElement = null;
					method_82(xtextElement_, null);
				}
			}
			else if (args.Style == DocumentEventStyles.KeyDown)
			{
				XTextElement elementAt = null;
				if (Math.Abs(Selection.Length) == 1)
				{
					elementAt = Selection.ContentElements[0];
				}
				else
				{
					XTextContainerElement container = null;
					int elementIndex = 0;
					Content.GetCurrentPositionInfo(out container, out elementIndex);
					elementAt = container;
				}
				method_84(elementAt, args);
				if (!args.Handled && EditorControl != null && EditorControl.EnabledEventMessage)
				{
					WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForKeyEvent(WriterControlEventMessageType.KeyDown, args);
					writerControlEventMessage.FromElement = elementAt;
					writerControlEventMessage.ToElement = elementAt;
					EditorControl.method_49(writerControlEventMessage);
				}
			}
			else if (args.Style == DocumentEventStyles.KeyPress)
			{
				XTextElement elementAt = null;
				if (Math.Abs(Selection.Length) == 1)
				{
					elementAt = Selection.ContentElements[0];
				}
				else
				{
					XTextContainerElement container = null;
					int elementIndex = 0;
					Content.GetCurrentPositionInfo(out container, out elementIndex);
					elementAt = container;
				}
				method_84(elementAt, args);
				if (!args.Handled && EditorControl != null && EditorControl.EnabledEventMessage)
				{
					WriterControlEventMessage writerControlEventMessage = WriterControlEventMessage.CreateForKeyEvent(WriterControlEventMessageType.KeyPress, args);
					writerControlEventMessage.FromElement = elementAt;
					writerControlEventMessage.ToElement = elementAt;
					EditorControl.method_49(writerControlEventMessage);
				}
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		private void method_83(XTextElementList xtextElementList_5, DocumentEventArgs documentEventArgs_0)
		{
			int x = documentEventArgs_0.X;
			int y = documentEventArgs_0.Y;
			documentEventArgs_0.Handled = false;
			int num = xtextElementList_5.Count - 1;
			for (int i = 0; i < xtextElementList_5.Count; i++)
			{
				if (xtextElementList_5[i].RuntimeStyle.DeleterIndex >= 0)
				{
					num = i - 1;
					break;
				}
			}
			for (int i = 0; i <= num; i++)
			{
				XTextElement xTextElement = xtextElementList_5[i];
				if (documentEventArgs_0.Style == DocumentEventStyles.MouseDown || documentEventArgs_0.Style == DocumentEventStyles.MouseMove || documentEventArgs_0.Style == DocumentEventStyles.MouseUp || documentEventArgs_0.Style == DocumentEventStyles.MouseClick || documentEventArgs_0.Style == DocumentEventStyles.MouseDblClick)
				{
					documentEventArgs_0.intX = (int)((float)x - xTextElement.AbsLeft);
					documentEventArgs_0.intY = (int)((float)y - xTextElement.AbsTop);
				}
				documentEventArgs_0.Element = xTextElement;
				xTextElement.HandleDocumentEvent(documentEventArgs_0);
				if (documentEventArgs_0.Handled || documentEventArgs_0.CancelBubble || !xTextElement.BelongToDocumentDom(this, checkLogicDelete: false))
				{
					break;
				}
			}
			documentEventArgs_0.intX = x;
			documentEventArgs_0.intY = y;
		}

		private void method_84(XTextElement xtextElement_3, DocumentEventArgs documentEventArgs_0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			XTextElement xTextElement = xtextElement_3;
			while (xTextElement != null && xTextElement != this)
			{
				xTextElementList.Add(xTextElement);
				xTextElement = xTextElement.Parent;
			}
			method_83(xTextElementList, documentEventArgs_0);
		}

		/// <summary>
		///       获得文档视图中指定位置处的文档元素对象
		///       </summary>
		/// <param name="x">指定的X坐标</param>
		/// <param name="y">指定的Y坐标</param>
		/// <param name="strict">是否严格匹配</param>
		/// <returns>获得的文档元素</returns>
		public XTextElement GetElementAt(float float_10, float float_11, bool strict)
		{
			XTextElement xTextElement = Content.GetElementAt(float_10, float_11, strict);
			if (xTextElement is XTextShadowElement)
			{
				xTextElement = ((XTextShadowElement)xTextElement).EntryElement;
			}
			if (xTextElement == null)
			{
				XTextElementList xTextElementList = TypedElements.method_5(CurrentContentElement, typeof(XTextTableElement));
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					for (int num = xTextElementList.Count - 1; num >= 0; num--)
					{
						XTextTableElement xTextTableElement = (XTextTableElement)xTextElementList[num];
						if (!xTextTableElement.IsInCollapsedSection)
						{
							XTextTableCellElement xTextTableCellElement = xTextTableElement.method_42(float_10, float_11);
							if (xTextTableCellElement != null)
							{
								return xTextTableCellElement;
							}
						}
					}
				}
			}
			if (xTextElement == null)
			{
				XTextElementList xTextElementList2 = TypedElements.method_5(CurrentContentElement, typeof(XTextSectionElement));
				if (xTextElementList2 != null && xTextElementList2.Count > 0)
				{
					foreach (XTextSectionElement item in xTextElementList2)
					{
						if (!item.IsInCollapsedSection && item.RuntimeVisible && !item.RuntimeIsCollapsed && item.AbsBounds.Contains(float_10, float_11))
						{
							return item;
						}
					}
				}
			}
			return xTextElement;
		}

		/// <summary>
		///       元素是否处于选择状态
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>是否选择</returns>
		[DCPublishAPI]
		[DCInternal]
		public bool IsSelected(XTextElement element)
		{
			XTextDocumentContentElement documentContentElement = element.DocumentContentElement;
			return documentContentElement.IsSelected(element);
		}

		/// <summary>
		///       元素是否可见
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>是否可见</returns>
		[DCInternal]
		public bool IsVisible(XTextElement element)
		{
			int styleIndex = element.StyleIndex;
			if (styleIndex < 0)
			{
				return true;
			}
			if (!ContentStyles.method_5(styleIndex, Options.SecurityOptions.ShowLogicDeletedContent))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       元素是否可见
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>是否可见</returns>
		[DCInternal]
		internal bool IsVisible(XTextElement element, bool showLogicDeletedContent)
		{
			int styleIndex = element.StyleIndex;
			if (styleIndex < 0)
			{
				return true;
			}
			if (!ContentStyles.method_5(styleIndex, showLogicDeletedContent))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       将像素长度转换为文档长度
		///       </summary>
		/// <param name="Value">像素长度</param>
		/// <returns>文档长度</returns>
		[DCPublishAPI]
		public float PixelToDocumentUnit(float Value)
		{
			return GraphicsUnitConvert.Convert(Value, GraphicsUnit.Pixel, graphicsUnit_0);
		}

		/// <summary>
		///       将像素大小转换为文档大小
		///       </summary>
		/// <param name="Value">像素大小</param>
		/// <returns>文档大小</returns>
		[DCPublishAPI]
		public Size PixelToDocumentUnit(Size Value)
		{
			return GraphicsUnitConvert.Convert(Value, GraphicsUnit.Pixel, graphicsUnit_0);
		}

		/// <summary>
		///       将文档长度转换为像素长度
		///       </summary>
		/// <param name="Value">文档长度</param>
		/// <returns>像素长度</returns>
		[DCPublishAPI]
		public int ToPixel(float Value)
		{
			return (int)GraphicsUnitConvert.Convert(Value, DocumentGraphicsUnit, GraphicsUnit.Pixel);
		}

		/// <summary>
		///       将文档长度转换为浮点数的像素长度
		///       </summary>
		/// <param name="Value">文档长度</param>
		/// <returns>像素长度</returns>
		[DCPublishAPI]
		public float ToPixelFloat(float float_10)
		{
			return GraphicsUnitConvert.Convert(float_10, DocumentGraphicsUnit, GraphicsUnit.Pixel);
		}

		/// <summary>
		///       将文档大小转换为像素大小
		///       </summary>
		/// <param name="Value">文档大小</param>
		/// <returns>像素大小</returns>
		[DCPublishAPI]
		public Size ToPixel(Size Value)
		{
			return GraphicsUnitConvert.Convert(Value, graphicsUnit_0, GraphicsUnit.Pixel);
		}

		/// <summary>
		///       创建长的文档内容位图对象,一个图片中包含了文档中所有的内容。
		///       </summary>
		/// <param name="showMarginLine">是否绘制表示页边距的虚线</param>
		/// <returns>创建的位图对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public Bitmap CreateLongBmp(bool showMarginLine)
		{
			return CreateLongBmp(showMarginLine, 1f);
		}

		/// <summary>
		///       创建长的文档内容位图对象,一个图片中包含了文档中所有的内容。
		///       </summary>
		/// <param name="showMarginLine">是否绘制表示页边距的虚线</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <returns>创建的位图对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public Bitmap CreateLongBmp(bool showMarginLine, float zoomRate)
		{
			method_98();
			CheckPageRefreshed();
			PrintPage printPage = Pages[0].Clone();
			printPage.OwnerPages = new PrintPageCollection();
			printPage.OwnerPages.Add(printPage);
			XPageSettings xPageSettings2 = printPage.PageSettings = printPage.PageSettings.Clone();
			xPageSettings2.PaperKind = PaperKind.Custom;
			if (xPageSettings2.Landscape)
			{
				int paperWidth = xPageSettings2.PaperWidth;
				xPageSettings2.PaperWidth = xPageSettings2.PaperHeight;
				xPageSettings2.PaperHeight = paperWidth;
			}
			xPageSettings2.Landscape = false;
			XTextDocumentContentElement xTextDocumentContentElement = PageSettings.RuntimeHeaderFooterDifferentFirstPage ? ((XTextDocumentContentElement)HeaderForFirstPage) : ((XTextDocumentContentElement)Header);
			XTextDocumentContentElement xTextDocumentContentElement2 = PageSettings.RuntimeHeaderFooterDifferentFirstPage ? ((XTextDocumentContentElement)FooterForFirstPage) : ((XTextDocumentContentElement)Footer);
			float num = Math.Max(xPageSettings2.ViewTopMargin, xPageSettings2.ViewHeaderDistance + xTextDocumentContentElement.Height);
			float num2 = Math.Max(xPageSettings2.ViewBottomMargin, xPageSettings2.ViewFooterDistance + xTextDocumentContentElement2.Height);
			xPageSettings2.ViewPaperHeight = Body.Height + num + num2;
			printPage.Height = Body.Height;
			Class104 @class = new Class104();
			@class.method_9(this);
			@class.method_19(bool_2: true);
			@class.method_21(bool_2: true);
			@class.method_25(Color.Transparent);
			GClass472 gClass = smethod_6(bool_32: false);
			if (!gClass.method_6())
			{
				@class.method_31(gClass);
			}
			else
			{
				@class.method_31(null);
			}
			if (EditorControl != null)
			{
				@class.method_23(EditorControl.PageBackColor);
			}
			else
			{
				@class.method_23(Color.White);
			}
			@class.method_17(Pages);
			@class.method_1(ContentRenderMode.UIPaint);
			@class.method_11(zoomRate);
			@class.method_13(zoomRate);
			@class.method_33(Options.ViewOptions.PageMarginLineLength);
			try
			{
				States.GenerateLongBmp = true;
				States.GenerateBmp = true;
				Bitmap bitmap = @class.method_36(printPage, showMarginLine);
				if (!smethod_13(GEnum6.const_13))
				{
					smethod_12(bitmap);
				}
				return bitmap;
			}
			finally
			{
				States.GenerateLongBmp = false;
				States.GenerateBmp = false;
			}
		}

		/// <summary>
		///       创建页面位图对象
		///       </summary>
		/// <param name="pageIndex">指定的页号</param>
		/// <param name="showMarginLine">是否绘制表示页边距的虚线</param>
		/// <returns>创建的位图对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public Bitmap CreatePageBmp(int pageIndex, bool showMarginLine)
		{
			return CreatePageBmp(pageIndex, showMarginLine, 1f);
		}

		/// <summary>
		///       创建页面位图对象
		///       </summary>
		/// <param name="pageIndex">指定的页号</param>
		/// <param name="showMarginLine">是否绘制表示页边距的虚线</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <returns>创建的位图对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public Bitmap CreatePageBmp(int pageIndex, bool showMarginLine, float zoomRate)
		{
			int num = 2;
			if (pageIndex < 0)
			{
				throw new ArgumentOutOfRangeException("pageIndex=" + pageIndex);
			}
			CheckPageRefreshed();
			if (pageIndex >= Pages.Count)
			{
				throw new ArgumentOutOfRangeException("pageIndex=" + pageIndex);
			}
			Class104 @class = new Class104();
			@class.method_9(this);
			@class.method_19(bool_2: true);
			@class.method_21(bool_2: true);
			@class.method_25(Color.Transparent);
			GClass472 gClass = smethod_6(bool_32: false);
			if (!gClass.method_6())
			{
				@class.method_31(gClass);
			}
			else
			{
				@class.method_31(null);
			}
			if (EditorControl != null)
			{
				@class.method_23(EditorControl.PageBackColor);
			}
			else
			{
				@class.method_23(Color.White);
			}
			@class.method_17(Pages);
			@class.method_1(ContentRenderMode.UIPaint);
			@class.method_33(Options.ViewOptions.PageMarginLineLength);
			@class.method_11(zoomRate);
			@class.method_13(zoomRate);
			States.GenerateBmp = true;
			try
			{
				Bitmap bitmap = @class.method_35(pageIndex, showMarginLine);
				if (!smethod_13(GEnum6.const_12))
				{
					smethod_12(bitmap);
				}
				return bitmap;
			}
			finally
			{
				States.GenerateBmp = false;
			}
		}

		public void method_85(XTextElement xtextElement_3)
		{
			if (xtextElementList_3 != null && !xtextElementList_3.Contains(xtextElement_3))
			{
				xtextElementList_3.Add(xtextElement_3);
			}
		}

		private void method_86()
		{
			if (Options.BehaviorOptions.GeneratePageContentVersion)
			{
				method_87();
			}
		}

		[DCInternal]
		public void method_87()
		{
			CheckPageRefreshed();
			PageContentVersions = new PageContentVersionInfoList();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			foreach (PrintPage page in Pages)
			{
				PageContentVersionInfo pageContentVersionInfo = new PageContentVersionInfo();
				pageContentVersionInfo.PageIndex = Pages.IndexOf(page);
				memoryStream_0 = new MemoryStream();
				try
				{
					using (CreatePageBmp(pageContentVersionInfo.PageIndex, showMarginLine: false))
					{
					}
					byte[] array2 = pageContentVersionInfo.NativeBytes = memoryStream_0.ToArray();
					if (array2 != null && array2.Length > 0)
					{
						byte[] inArray = mD5CryptoServiceProvider.ComputeHash(array2);
						pageContentVersionInfo.Version = Convert.ToBase64String(inArray);
					}
					PageContentVersions.Add(pageContentVersionInfo);
				}
				finally
				{
					memoryStream_0 = null;
				}
			}
		}

		internal void method_88(RectangleF rectangleF_1)
		{
			if (!rectangleF_1.IsEmpty)
			{
				if (rectangleF_0.IsEmpty)
				{
					rectangleF_0 = rectangleF_1;
				}
				else
				{
					rectangleF_0 = RectangleF.Union(rectangleF_0, rectangleF_1);
				}
			}
		}

		/// <summary>
		///       绘制文档内容
		///       </summary>
		/// <param name="args">参数</param>
		[DCInternal]
		public void DrawContent(PageDocumentPaintEventArgs args)
		{
			lock (this)
			{
				rectangleF_0 = RectangleF.Empty;
				if (LogElementRenderResult)
				{
					ElementRenderResult elementRenderResult = new ElementRenderResult();
					elementRenderResult.ClipRectangle = args.ClipRectangle;
					elementRenderResult.Printing = States.Printing;
					elementRenderResult.PrintPreviewing = States.PrintPreviewing;
					base.LastRenderResult = elementRenderResult;
				}
				if (BeforeDrawContent != null)
				{
					BeforeDrawContent(this, args);
				}
				try
				{
					if (WriterControl != null)
					{
						WriterControl.EnableCollectOuterReference = false;
					}
					if (xtextElementList_3 != null)
					{
						xtextElementList_3.Clear();
					}
					if (args.RenderMode == ContentRenderMode.UIPaint)
					{
						xtextElementList_3 = null;
					}
					else
					{
						xtextElementList_3 = new XTextElementList();
					}
					BoundsSelectionPrintInfo boundsSelectionPrintInfo = null;
					if (args.Options != null)
					{
						boundsSelectionPrintInfo = args.Options.BoundsSelection;
					}
					if (boundsSelectionPrintInfo == null)
					{
						boundsSelectionPrintInfo = BoundsSelection;
					}
					if (Options.BehaviorOptions.SpecifyDebugMode && boundsSelectionPrintInfo != null && boundsSelectionPrintInfo.Enable && boundsSelectionPrintInfo.Count > 0 && (args.ContentStyle == PageContentPartyStyle.Body || args.ContentStyle == PageContentPartyStyle.HeaderRows))
					{
						foreach (BoundsSelectionPrintInfoItem item in boundsSelectionPrintInfo)
						{
							args.Graphics.DrawRectangle(Pens.Blue, item.ViewBounds.Left, item.ViewBounds.Top, item.ViewBounds.Width, item.ViewBounds.Height);
						}
					}
					if (!States.Printing || States.PrintPreviewing)
					{
						goto IL_02d2;
					}
					if (args.Options == null || args.Options.PrintRange != PrintRange.Selection || !DrawerUtil.IsHeaderFooter(args.ContentStyle))
					{
						if (boundsSelectionPrintInfo == null || !boundsSelectionPrintInfo.Enable)
						{
							goto IL_02d2;
						}
						if (!DrawerUtil.IsHeaderFooter(args.ContentStyle))
						{
							RectangleF value = RectangleF.Intersect(args.ClipRectangle, boundsSelectionPrintInfo.ViewBounds);
							if (!value.IsEmpty)
							{
								args.ClipRectangle = Rectangle.Round(value);
								Region region = null;
								foreach (BoundsSelectionPrintInfoItem item2 in boundsSelectionPrintInfo)
								{
									if (region == null)
									{
										region = new Region(item2.ViewBounds);
									}
									else
									{
										region.Union(item2.ViewBounds);
									}
								}
								args.Graphics.SetClip(region, CombineMode.Replace);
								goto IL_02d2;
							}
						}
					}
					goto end_IL_0076;
					IL_02d2:
					CurrentPage = args.Page;
					XTextDocumentContentElement xTextDocumentContentElement = method_66(args.ContentStyle);
					if ((xTextDocumentContentElement == Body || xTextDocumentContentElement.HasContentElement || CurrentContentElement == xTextDocumentContentElement) && xTextDocumentContentElement.Visible)
					{
						DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(new DCGraphics(args.Graphics), args.ClipRectangle);
						if (memoryStream_0 != null)
						{
							documentPaintEventArgs.Graphics.LogStream = memoryStream_0;
							documentPaintEventArgs.Graphics.LogType = DCGraphicsLogType.Content;
						}
						documentPaintEventArgs.ViewMode = args.ViewMode;
						documentPaintEventArgs.Document = this;
						documentPaintEventArgs.Type = args.ContentStyle;
						documentPaintEventArgs.ActiveMode = (xTextDocumentContentElement == CurrentContentElement);
						documentPaintEventArgs.DocumentContentElement = xTextDocumentContentElement;
						documentPaintEventArgs.Render = Render;
						documentPaintEventArgs.Options = args.Options;
						if (args.RenderMode == ContentRenderMode.Print)
						{
							documentPaintEventArgs.RenderMode = DocumentRenderMode.Print;
						}
						else if (args.RenderMode == ContentRenderMode.ReadPaint)
						{
							documentPaintEventArgs.RenderMode = DocumentRenderMode.ReadPaint;
						}
						else if (PrintingViewMode)
						{
							documentPaintEventArgs.RenderMode = DocumentRenderMode.Print;
						}
						else
						{
							documentPaintEventArgs.RenderMode = DocumentRenderMode.Paint;
						}
						if (LogElementRenderResult)
						{
							base.LastRenderResult = new ElementRenderResult(documentPaintEventArgs, this);
						}
						documentPaintEventArgs.Element = xTextDocumentContentElement;
						documentPaintEventArgs.Style = xTextDocumentContentElement.RuntimeStyle;
						documentPaintEventArgs.Graphics.TextRenderingHint = Options.ViewOptions.TextRenderStyle;
						documentPaintEventArgs.Graphics.SmoothingMode = Options.ViewOptions.GraphicsSmoothingMode;
						documentPaintEventArgs.PageClipRectangle = args.PageClipRectangle;
						documentPaintEventArgs.PageIndex = args.PageIndex;
						documentPaintEventArgs.Page = args.Page;
						documentPaintEventArgs.JumpPrintMode = (args.Options != null && args.Options.JumpPrint != null && args.Options.JumpPrint.HasValidateInfo);
						WriterUtils.smethod_29(this, xTextDocumentContentElement, documentPaintEventArgs);
						xTextDocumentContentElement.DrawContent(documentPaintEventArgs);
						if (AdornTextMan != null && args.RenderMode == ContentRenderMode.UIPaint && Options.ViewOptions.AdornTextVisibility != 0 && documentPaintEventArgs.ActiveMode)
						{
							documentPaintEventArgs.Graphics.ResetClip();
							AdornTextMan.method_2(documentPaintEventArgs);
						}
						if (EditorControl != null && EditorControl.InnerViewControl != null && !States.GenerateBmp)
						{
							documentPaintEventArgs.ClipRectangle = args.ClipRectangle;
							EditorControl.InnerViewControl.ViewHandleManager.method_7(documentPaintEventArgs, xTextDocumentContentElement);
						}
						WriterUtils.smethod_28(this, xTextDocumentContentElement, documentPaintEventArgs);
						if ((xTextDocumentContentElement == Header || xTextDocumentContentElement == HeaderForFirstPage) && RuntimeShowHeaderBottomLine && xTextDocumentContentElement.Content.Count > 0)
						{
							_ = xTextDocumentContentElement.AbsBounds;
							float num = GraphicsUnitConvert.Convert(Options.ViewOptions.HeaderBottomLineWidth, GraphicsUnit.Pixel, args.Graphics.PageUnit);
							using (Pen pen = new Pen(Color.Black, num))
							{
								args.Graphics.DrawLine(pen, xTextDocumentContentElement.Left, xTextDocumentContentElement.Bottom - num, xTextDocumentContentElement.Right, xTextDocumentContentElement.Bottom - num);
							}
						}
						DocumentTerminalTextInfo runtimeTerminalText = PageSettings.RuntimeTerminalText;
						if (args.ContentStyle == PageContentPartyStyle.Body && runtimeTerminalText != null && PageViewMode == PageViewMode.Page)
						{
							bool flag = true;
							if (boundsSelectionPrintInfo != null && boundsSelectionPrintInfo.Enable)
							{
								flag = false;
							}
							if (args.Options != null && args.Options.JumpPrint != null && args.Options.JumpPrint.HasValidateInfo && args.Options.JumpPrint.Mode != JumpPrintMode.Offset)
							{
								flag = false;
							}
							if (args.Options != null && args.Options.PrintRange == PrintRange.Selection)
							{
								flag = false;
							}
							if (flag)
							{
								if (args.Page == Pages.LastPage && !LastPageIsEmpty)
								{
									RectangleF rectangleF = new RectangleF(Left, BodyLayoutOffset + xTextDocumentContentElement.Bottom, xTextDocumentContentElement.Width, args.Page.StandartPapeBodyHeight - args.Page.Height);
									args.Graphics.ResetClip();
									runtimeTerminalText.method_1(new DCGraphics(args.Graphics), rectangleF, RectangleF.Empty);
								}
								else if (args.Page != Pages.LastPage)
								{
									RectangleF rectangleF = new RectangleF(Left, args.Page.Top + args.Page.Height, xTextDocumentContentElement.Width, args.Page.StandartPapeBodyHeight - args.Page.Height);
									args.Graphics.ResetClip();
									runtimeTerminalText.method_0(new DCGraphics(args.Graphics), rectangleF, RectangleF.Empty);
								}
							}
						}
						if (!IsRegistered && args.ContentStyle == PageContentPartyStyle.Body)
						{
							GClass472 gClass = Class103.smethod_6((WriterControl == null) ? null : WriterControl.InnerViewControl);
							GraphicsState gstate = args.Graphics.Save();
							args.Graphics.ResetClip();
							if (args.RenderMode == ContentRenderMode.Print)
							{
								gClass.method_13(gClass.method_12() * 3f);
								gClass.method_32(bool_7: true);
							}
							if (!args.PageClipRectangle.IsEmpty)
							{
								gClass.method_28(args.Graphics, args.PageClipRectangle, bool_7: false);
							}
							else
							{
								gClass.method_28(args.Graphics, args.ContentBounds, bool_7: false);
							}
							args.Graphics.Restore(gstate);
						}
					}
					end_IL_0076:;
				}
				finally
				{
					if (WriterControl != null)
					{
						WriterControl.EnableCollectOuterReference = true;
					}
					if (AfterDrawContent != null)
					{
						AfterDrawContent(this, args);
					}
				}
			}
		}

		/// <summary>
		///       返回表示内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return "Document:" + Info.Title;
		}

		internal XTextDocument method_89()
		{
			XTextDocument xTextDocument = (XTextDocument)Clone(Deeply: false);
			xTextDocument.Elements = new XTextElementList();
			foreach (XTextElement element2 in Elements)
			{
				if (!(element2 is XTextDocumentBodyElement))
				{
					XTextElement element = element2.Clone(Deeply: true);
					xTextDocument.Elements.Add(element);
				}
			}
			xTextDocument.FixDomState();
			return xTextDocument;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public override XTextElement Clone(bool Deeply)
		{
			XTextDocument xTextDocument = (XTextDocument)base.Clone(Deeply);
			xTextDocument.documentCommentList_0 = null;
			xTextDocument.method_5(xTextDocument);
			xTextDocument.class136_0 = null;
			xTextDocument.gclass123_0 = null;
			xTextDocument.gclass123_0 = null;
			xTextDocument.bool_23 = false;
			xTextDocument.writerPrintEventHandler_0 = null;
			xTextDocument.writerPrintEventHandler_1 = null;
			xTextDocument.writerPrintPageEventHandler_0 = null;
			xTextDocument.writerPrintQueryPageSettingsEventHandler_0 = null;
			xTextDocument.xtextElementList_2 = null;
			xTextDocument.xtextElement_0 = null;
			xTextDocument.gclass132_0 = null;
			xTextDocument.adornTextManager_0 = null;
			xTextDocument.memoryStream_0 = null;
			xTextDocument.repeatedImageValueList_0 = null;
			xTextDocument.documentStates_0 = new DocumentStates();
			xTextDocument.class135_0 = null;
			xTextDocument.ginterface7_0 = null;
			xTextDocument.ginterface2_0 = null;
			xTextDocument.idocumentScriptEngine_0 = null;
			xTextDocument.xtextElement_1 = null;
			xTextDocument.xtextElement_2 = null;
			xTextDocument.adornTextManager_0 = null;
			xTextDocument.boundsSelectionPrintInfo_0 = null;
			xTextDocument.class135_0 = null;
			xTextDocument.dictionary_0 = null;
			xTextDocument.gclass108_0 = null;
			xTextDocument.class136_0 = null;
			xTextDocument.xtextDocumentContentElement_0 = null;
			xTextDocument.printPage_0 = null;
			xTextDocument.currentContentStyleInfo_0 = null;
			xTextDocument.documentControler_0 = null;
			xTextDocument.writerControl_0 = null;
			xTextDocument.xtextElementList_3 = null;
			xTextDocument.ginterface4_0 = null;
			xTextDocument.list_1 = null;
			xTextDocument.printPageCollection_1 = null;
			xTextDocument.ginterface6_0 = null;
			xTextDocument.xtextElement_0 = null;
			xTextDocument.systemAlertInfoList_0 = null;
			xTextDocument.appErrorInfo_0 = null;
			xTextDocument.dictionary_2 = null;
			xTextDocument.xtextElementList_4 = null;
			xTextDocument.xtextElementList_2 = null;
			xTextDocument.printResult_0 = null;
			xTextDocument.class114_0 = null;
			xTextDocument.memoryStream_0 = null;
			xTextDocument.gclass132_0 = null;
			xTextDocument.documentOutlineNodeList_0 = null;
			xTextDocument.printPageCollection_0 = null;
			xTextDocument.dictionary_1 = null;
			xTextDocument.xtextDocumentUndoList_0 = null;
			xTextDocument.float_8 = null;
			xTextDocument.method_126(this, bool_32: false);
			if (Deeply)
			{
				if (pageContentVersionInfoList_0 != null && pageContentVersionInfoList_0.Count > 0)
				{
					xTextDocument.pageContentVersionInfoList_0 = pageContentVersionInfoList_0.Clone();
				}
				else
				{
					xTextDocument.pageContentVersionInfoList_0 = null;
				}
				if (documentCommentList_1 != null)
				{
					xTextDocument.documentCommentList_1 = documentCommentList_1.Clone(Deeply);
				}
				xTextDocument.documentContentStyleContainer_0 = (DocumentContentStyleContainer)ContentStyles.method_2();
				if (userHistoryInfoList_0 != null)
				{
					xTextDocument.userHistoryInfoList_0 = userHistoryInfoList_0.Clone();
				}
				if (repeatedImageValueList_0 != null && repeatedImageValueList_0.Count > 0)
				{
					xTextDocument.repeatedImageValueList_0 = repeatedImageValueList_0.method_4();
				}
				else
				{
					xTextDocument.repeatedImageValueList_0 = null;
				}
			}
			else
			{
				xTextDocument.pageContentVersionInfoList_0 = null;
				xTextDocument.documentCommentList_1 = null;
				xTextDocument.documentContentStyleContainer_0 = null;
				xTextDocument.userHistoryInfoList_0 = null;
			}
			xTextDocument.FixDomState();
			return xTextDocument;
		}

		/// <summary>
		///       锁定文档元素的内容
		///       </summary>
		/// <param name="tableID">表格编号</param>
		/// <param name="rowIndexBase0">从0开始计算的表格行序号</param>
		/// <param name="userID">锁定操作的用户ID</param>
		/// <param name="authoriseUserIDList">授权操作的用户ID列表，各个列表之间用英文逗号分开</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool LockContentByTableRow(string tableID, int rowIndexBase0, string userID, string authoriseUserIDList, bool logUndo)
		{
			XTextTableElement xTextTableElement = GetElementById(tableID) as XTextTableElement;
			if (xTextTableElement != null && rowIndexBase0 >= 0 && rowIndexBase0 < xTextTableElement.Rows.Count)
			{
				return LockContentByElement((XTextContainerElement)xTextTableElement.Rows[rowIndexBase0], userID, authoriseUserIDList, logUndo);
			}
			return false;
		}

		/// <summary>
		///       锁定文档元素的内容
		///       </summary>
		/// <param name="elementID">元素编号，必须为一个容器类型的元素的编号</param>
		/// <param name="userID">锁定操作的用户ID</param>
		/// <param name="authoriseUserIDList">授权操作的用户ID列表，各个列表之间用英文逗号分开</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool LockContentByElementID(string elementID, string userID, string authoriseUserIDList, bool logUndo)
		{
			return LockContentByElement(GetElementById(elementID) as XTextContainerElement, userID, authoriseUserIDList, logUndo);
		}

		/// <summary>
		///       锁定文档元素的内容
		///       </summary>
		/// <param name="element">文档元素，必须为容器类文档元素</param>
		/// <param name="userID">
		/// </param>
		/// <param name="authoriseUserIDList">
		/// </param>
		/// <param name="logUndo">
		/// </param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool LockContentByElement(XTextContainerElement element, string userID, string authoriseUserIDList, bool logUndo)
		{
			if (element == null)
			{
				return false;
			}
			return element.SetContentLock(userID, authoriseUserIDList, logUndo);
		}

		internal void method_90()
		{
			gclass108_0 = null;
		}

		[DCInternal]
		public bool method_91(GClass108 gclass108_1)
		{
			GClass108 gClass = gclass108_1;
			if (gClass == null || gClass.Count == 0)
			{
				gClass = gclass108_0;
				gclass108_0 = null;
			}
			if (gClass == null || gClass.Count == 0)
			{
				return false;
			}
			for (int num = gClass.Count - 1; num >= 0; num--)
			{
				if (gClass[num].Element is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)gClass[num].Element;
					if (xTextParagraphFlagElement.IsLastElementInContentElement)
					{
						gClass.RemoveAt(num);
					}
				}
			}
			if (gClass != null && gClass.Count > 0)
			{
				for (int num = gClass.Count - 1; num >= 0; num--)
				{
					XTextElement element = gClass[num].Element;
					if (element is XTextFieldBorderElement)
					{
						XTextElement parent = element.Parent;
						if (gClass.method_1(element.Parent) == null)
						{
							gClass[num].Element = parent;
						}
						else
						{
							gClass.RemoveAt(num);
						}
					}
					else if (element.Parent is XTextFieldElementBase && element is XTextCharElement)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)element.Parent;
						if (xTextFieldElementBase.IsBackgroundTextElement(element))
						{
							XTextElement parent = element.Parent;
							if (gClass.method_1(element.Parent) == null)
							{
								gClass[num].Element = parent;
							}
							else
							{
								gClass.RemoveAt(num);
							}
						}
					}
				}
				if (Options.BehaviorOptions.PromptProtectedContent == PromptProtectedContentMode.Flash)
				{
					if (EditorControl != null)
					{
						XTextElementList xTextElementList = new XTextElementList();
						foreach (ContentProtectedInfo item in gClass)
						{
							xTextElementList.Add(item.Element);
						}
						EditorControl.FlashElements(xTextElementList, autoScroll: true);
					}
					return true;
				}
				string string_ = null;
				switch (Options.BehaviorOptions.PromptProtectedContent)
				{
				case PromptProtectedContentMode.None:
					string_ = WriterStringsCore.PromptProtectedContent + Environment.NewLine + gClass[0].Message;
					break;
				case PromptProtectedContentMode.Simple:
					string_ = WriterStringsCore.PromptProtectedContent + Environment.NewLine + gClass[0].Message;
					break;
				case PromptProtectedContentMode.Details:
					string_ = WriterStringsCore.PromptProtectedContent + Environment.NewLine + gClass.method_2();
					break;
				}
				if (EditorControl != null)
				{
					PromptProtectedContentEventArgs promptProtectedContentEventArgs = new PromptProtectedContentEventArgs(EditorControl, this, gClass[0].Element, string_, Options.BehaviorOptions.PromptProtectedContent);
					EditorControl.vmethod_37(promptProtectedContentEventArgs);
					if (promptProtectedContentEventArgs.Handled)
					{
						return true;
					}
				}
				switch (Options.BehaviorOptions.PromptProtectedContent)
				{
				case PromptProtectedContentMode.Simple:
					AppHost.UITools.ShowWarringMessageBox(EditorControl, string_);
					break;
				case PromptProtectedContentMode.Details:
					AppHost.UITools.ShowWarringMessageBox(EditorControl, string_);
					break;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       拒绝对文档所有的修订
		///       </summary>
		/// <returns>操作是否修改了文档内容</returns>
		[DCPublishAPI]
		public bool RejectUserTrace()
		{
			bool result;
			if (result = method_92(this))
			{
				Modified = true;
				if (UndoList != null)
				{
					UndoList.Clear();
				}
			}
			return result;
		}

		private bool method_92(XTextContainerElement xtextContainerElement_1)
		{
			bool result = false;
			for (int num = xtextContainerElement_1.Elements.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = xtextContainerElement_1.Elements[num];
				RuntimeDocumentContentStyle runtimeStyle = xTextElement.RuntimeStyle;
				if (runtimeStyle.CreatorIndex < 0)
				{
					if (runtimeStyle.DeleterIndex >= 0)
					{
						DocumentContentStyle documentContentStyle = xTextElement.RuntimeStyle.CloneParent();
						documentContentStyle.DeleterIndex = -1;
						xTextElement.StyleIndex = ContentStyles.GetStyleIndex(documentContentStyle);
						result = true;
					}
				}
				else if (runtimeStyle.CreatorIndex >= 0 || runtimeStyle.DeleterIndex >= 0)
				{
					xtextContainerElement_1.Elements.RemoveAt(num);
					result = true;
					continue;
				}
				if (xTextElement is XTextContainerElement && method_92((XTextContainerElement)xTextElement))
				{
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		///       提交所有用户的修改记录。删除被逻辑删除的内容，清除用户修改痕迹。
		///       </summary>
		/// <returns>操作是否修改了文档内容</returns>
		[DCPublishAPI]
		public override bool CommitUserTrace()
		{
			bool result = WriterUtils.smethod_7(this);
			for (int num = ContentStyles.Styles.Count - 1; num >= 0; num--)
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)ContentStyles.Styles[num];
				if (documentContentStyle.DeleterIndex >= 0)
				{
					documentContentStyle.DeleterIndex = -1;
					result = true;
				}
				else if (documentContentStyle.CreatorIndex >= 0)
				{
					documentContentStyle.CreatorIndex = -1;
					result = true;
				}
			}
			if (UserHistories.Count > 0)
			{
				UserHistories.Clear();
				result = true;
			}
			if (xtextDocumentUndoList_0 != null)
			{
				xtextDocumentUndoList_0.Clear();
			}
			return result;
		}

		[DCInternal]
		public override void EditorRefreshView()
		{
			if (!UIIsUpdating)
			{
				if (EditorControl != null)
				{
					EditorControl.RefreshDocumentExt(refreshSize: true, executeLayout: true);
					return;
				}
				PageRefreshed = false;
				CheckPageRefreshed();
			}
		}

		[DCInternal]
		public JumpPrintInfo GetJumpPrintInfo(XTextElement startElement, XTextElement endElement)
		{
			if (startElement != null && startElement.DocumentContentElement != Body)
			{
				return null;
			}
			if (endElement != null && endElement.DocumentContentElement != Body)
			{
				return null;
			}
			JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
			jumpPrintInfo.Enabled = false;
			if (startElement != null)
			{
				float num = 0f;
				if (startElement is XTextTableCellElement || startElement is XTextTableRowElement || startElement is XTextTableElement || startElement is XTextSectionElement)
				{
					num = startElement.AbsTop;
				}
				else
				{
					XTextElement xTextElement = startElement.FirstContentElement;
					if (startElement is XTextParagraphFlagElement)
					{
						xTextElement = startElement;
					}
					num = (xTextElement.OwnerLine?.AbsTop ?? xTextElement.AbsTop);
				}
				JumpPrintInfo jumpPrintInfo2 = GetJumpPrintInfo(num);
				if (jumpPrintInfo2 != null)
				{
					jumpPrintInfo.SetNativePosition(jumpPrintInfo2.NativePosition);
					jumpPrintInfo.PageIndex = jumpPrintInfo2.PageIndex;
					jumpPrintInfo.Position = jumpPrintInfo2.Position;
					jumpPrintInfo.Enabled = true;
				}
			}
			if (endElement != null)
			{
				float num = 0f;
				if (endElement is XTextTableCellElement || endElement is XTextTableRowElement || endElement is XTextTableElement || endElement is XTextSectionElement)
				{
					num = endElement.AbsTop + endElement.Height + 1f;
				}
				else
				{
					XTextElement xTextElement = endElement.FirstContentElement;
					if (endElement is XTextParagraphFlagElement)
					{
						xTextElement = endElement;
					}
					XTextLine ownerLine = xTextElement.OwnerLine;
					num = ((ownerLine != null) ? (ownerLine.AbsTop + ownerLine.Height + 1f) : (xTextElement.AbsTop + xTextElement.Height + 1f));
				}
				JumpPrintInfo jumpPrintInfo3 = GetJumpPrintInfo(num);
				if (jumpPrintInfo3 != null)
				{
					jumpPrintInfo.SetNativeEndPosition(jumpPrintInfo3.NativePosition);
					jumpPrintInfo.EndPageIndex = jumpPrintInfo3.PageIndex;
					jumpPrintInfo.EndPosition = jumpPrintInfo3.Position;
				}
			}
			if (jumpPrintInfo.Enabled)
			{
				return jumpPrintInfo;
			}
			return null;
		}

		/// <summary>
		///       检查文档内容排版和布局
		///       </summary>
		public void CheckPageRefreshed()
		{
			if (!PageRefreshed && !UIIsUpdating)
			{
				method_97(bool_32: false, bool_33: true);
				RefreshSizeWithoutParamter();
				ExecuteLayout();
				RefreshPages();
				method_40(DomReadyStates.Complete);
			}
		}

		/// <summary>
		///       刷新文档内部排版和分页。不更新用户界面。
		///       </summary>
		/// <param name="fastMode">
		/// </param>
		[ComVisible(true)]
		public void RefreshInnerView(bool fastMode)
		{
			method_98();
			WriterControl editorControl = EditorControl;
			EditorControl = null;
			try
			{
				if (fastMode)
				{
					method_97(bool_32: true, bool_33: false);
				}
				else
				{
					method_97(bool_32: false, bool_33: true);
				}
				using (DCGraphics dcgraphics_ = CreateDCGraphics())
				{
					method_94(dcgraphics_, fastMode);
				}
				ExecuteLayout();
				method_96(fastMode);
				method_40(DomReadyStates.Complete);
			}
			finally
			{
				EditorControl = editorControl;
			}
		}

		/// <summary>
		///       无参数的重新计算文件元素大小
		///       </summary>
		[DCPublishAPI]
		[DCInternal]
		public void RefreshSizeWithoutParamter()
		{
			if (!UIIsUpdating)
			{
				using (DCGraphics dcgraphics_ = CreateDCGraphics())
				{
					RefreshSize(dcgraphics_);
				}
			}
		}

		/// <summary>
		///       仅供兼容
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DCInternal]
		[Obsolete("!!!!仅仅用于提供COM接口兼容性支持，不要使用。")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefreshSize_2()
		{
			RefreshSizeWithoutParamter();
		}

		/// <summary>
		///       重新计算大小
		///       </summary>
		/// <param name="g">画布对象</param>
		[DCInternal]
		[Obsolete("■■■■■■■不推荐使用，请使用void RefreshSize(DCGraphics g)")]
		[ComVisible(false)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefreshSize(Graphics graphics_0)
		{
			RefreshSize(new DCGraphics(graphics_0));
		}

		private void method_93(DCGraphics dcgraphics_0)
		{
			_ = (int)Math.Ceiling(DefaultStyle.DefaultLineHeight);
			DocumentContentStyle defaultStyle = DefaultStyle;
			dcgraphics_0.MeasureString("#", defaultStyle.Font);
			sizeF_0.Height = dcgraphics_0.GetFontHeight(defaultStyle.Font);
			sizeF_0.Width = PixelToDocumentUnit(2f);
			float_7 = PixelToDocumentUnit(9f);
		}

		/// <summary>
		///       重新计算大小
		///       </summary>
		/// <param name="g">画布对象</param>
		[ComVisible(false)]
		[DCInternal]
		public void RefreshSize(DCGraphics dcgraphics_0)
		{
			method_94(dcgraphics_0, bool_32: false);
		}

		private void method_94(DCGraphics dcgraphics_0, bool bool_32)
		{
			method_98();
			if (!UIIsUpdating)
			{
				if (EditorControl != null)
				{
					GClass445.smethod_9(EditorControl.InnerViewControl, WriterStringsCore.RefreshingDocumentSize);
				}
				ContentStyles.method_4();
				method_93(dcgraphics_0);
				Width = PageSettings.ViewPaperWidth;
				dcgraphics_0.PageUnit = DocumentGraphicsUnit;
				dcgraphics_0.TextRenderingHint = TextRenderingHint.AntiAlias;
				_ = Render;
				DocumentPaintEventArgs documentPaintEventArgs = method_55(dcgraphics_0);
				documentPaintEventArgs.Graphics.PageUnit = DocumentGraphicsUnit;
				documentPaintEventArgs.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				ContentStyles.method_8(documentPaintEventArgs.Graphics);
				if (bool_32)
				{
					documentPaintEventArgs.CheckSizeInvalidateWhenRefreshSize = true;
				}
				else
				{
					Render.method_8();
				}
				if (States.Printing)
				{
					documentPaintEventArgs.RenderMode = DocumentRenderMode.Print;
				}
				RefreshSize(documentPaintEventArgs);
				PageRefreshed = false;
				if (!bool_32)
				{
					Render.method_8();
				}
				Render.gstruct20_1.method_0();
				Render.gstruct20_0.method_0();
				Render.int_0 = 0;
			}
		}

		[ComVisible(false)]
		[Browsable(false)]
		[DCInternal]
		public float method_95(XPageSettings xpageSettings_1)
		{
			float num = xpageSettings_1.ViewClientHeight;
			float height = Header.Height;
			float viewHeaderHeight = xpageSettings_1.ViewHeaderHeight;
			if (height > viewHeaderHeight)
			{
				num -= height - viewHeaderHeight;
			}
			float height2 = Footer.Height;
			float viewFooterHeight = xpageSettings_1.ViewFooterHeight;
			if (height2 > viewFooterHeight)
			{
				num -= height2 - viewFooterHeight;
			}
			return num;
		}

		/// <summary>
		///       重新进行分页
		///       </summary>
		[DCInternal]
		public void RefreshPages()
		{
			method_96(bool_32: false);
		}

		private void method_96(bool bool_32)
		{
			method_98();
			if (!bool_32 && GClass354.smethod_3())
			{
				return;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			List<XTextPageBreakElement> list = new List<XTextPageBreakElement>();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Body);
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			domTreeNodeEnumerable.ExcludeCharElement = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					xTextContainerElement.ContainsUnHandledPageBreak = false;
					if (xTextContainerElement is XTextTableRowElement)
					{
						((XTextTableRowElement)xTextContainerElement).HandledNewPage = false;
					}
				}
				else if (item is XTextPageBreakElement)
				{
					XTextPageBreakElement xTextPageBreakElement = (XTextPageBreakElement)item;
					xTextPageBreakElement.Handled = false;
					if (xTextPageBreakElement.RuntimeVisible)
					{
						list.Add(xTextPageBreakElement);
					}
				}
			}
			foreach (XTextElement element in Body.Elements)
			{
				if (element is XTextSubDocumentElement)
				{
					XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)element;
					xTextSubDocumentElement.HandledNewPage = false;
				}
			}
			foreach (XTextDocumentContentElement element2 in Elements)
			{
				element2.Top = 0f;
				_ = element2.Top;
				foreach (XTextLine line in element2.Lines)
				{
					line.OwnerPage = null;
				}
				foreach (XTextLine privateLine in element2.PrivateLines)
				{
					privateLine.OwnerPage = null;
				}
			}
			if (FixContentForPageLineElements.Count > 0)
			{
				List<XTextContentElement> list2 = new List<XTextContentElement>();
				list2.AddRange(FixContentForPageLineElements);
				FixContentForPageLineElements.Clear();
				foreach (XTextContentElement item2 in list2)
				{
					if (item2 != null)
					{
						foreach (XTextLine privateLine2 in item2.PrivateLines)
						{
							privateLine2.Top = privateLine2.NativeTop;
						}
					}
				}
			}
			XTextDocumentContentElement body = Body;
			XTextLineList allLines = body.GetAllLines();
			foreach (XTextLine item3 in allLines)
			{
				item3.AbsTopBuffered = -1f;
				item3.AbsTopBuffered = item3.AbsTop;
			}
			PrintPageCollection pages = Pages;
			XPageSettings pageSettings = PageSettings;
			pageSettings.method_0(method_112());
			if (printPage_0 != null)
			{
				pages.IndexOf(printPage_0);
			}
			else
				_ = 0;
			pageSettings.ViewUnit = DocumentGraphicsUnit;
			pages.Clear();
			printPage_0 = null;
			if (EditorControl != null && EditorControl.InnerViewControl != null)
			{
				EditorControl.InnerViewControl.method_36(null);
			}
			pages.Top = 0f;
			_ = body.Height;
			float num = printPageCollection_0.Top;
			printPage_0 = null;
			if (EditorControl != null)
			{
				PageViewMode = EditorControl.ViewMode;
			}
			if (SpecifyPageLinePosition != null && SpecifyPageLinePosition.Length > 0)
			{
				for (int i = 0; i < SpecifyPageLinePosition.Length; i++)
				{
					float num2 = SpecifyPageLinePosition[i];
					if (num2 > num)
					{
						PrintPage printPage = new PrintPage(this, pageSettings.Clone(), pages, 0f, 0f);
						printPage.Height = num2 - printPage.Top;
						printPage.DocumentHeight = Height;
						num = printPage.Bottom;
						pages.Add(printPage);
						printPage.ResetTop();
					}
				}
			}
			GClass128 gClass = new GClass128();
			gClass.method_9(pageSettings);
			gClass.method_11(pageSettings.ViewClientHeight);
			gClass.method_13(50f);
			gClass.method_1(list);
			if (gClass.method_10() < gClass.method_12() * 2f)
			{
				throw new Exception(WriterStringsCore.InvalidatePageSettings);
			}
			XTextElementList xTextElementList = null;
			int num3 = (int)(body.AbsTop + body.Height);
			bool forNewPage = false;
			if (EditorControl != null && EditorControl.InnerViewControl != null)
			{
				GClass445.smethod_9(EditorControl.InnerViewControl, WriterStringsCore.RefreshingPage);
			}
			while (pages.Height < (float)num3)
			{
				if (list.Count > 0)
				{
					foreach (XTextPageBreakElement item4 in list)
					{
						for (XTextContainerElement xTextContainerElement = item4.Parent; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.Parent)
						{
							xTextContainerElement.ContainsUnHandledPageBreak = false;
						}
					}
					foreach (XTextPageBreakElement item5 in list)
					{
						if (!item5.Handled)
						{
							for (XTextContainerElement xTextContainerElement = item5.Parent; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.Parent)
							{
								xTextContainerElement.ContainsUnHandledPageBreak = true;
							}
						}
					}
				}
				PrintPage printPage = new PrintPage(this, pageSettings, pages, 0f, 0f);
				if (pageSettings.RuntimeSwapLeftRightMargin && pages.Count % 2 == 1)
				{
					printPage.Margins = new Margins(pageSettings.Margins.Right, pageSettings.Margins.Left, pageSettings.Margins.Top, pageSettings.Margins.Bottom);
				}
				printPage.ForNewPage = forNewPage;
				if (pageSettings.EnableHeaderFooter)
				{
					if (pageSettings.RuntimeHeaderFooterDifferentFirstPage && pages.Count == 0)
					{
						printPage.HeaderContentHeight = HeaderForFirstPage.Height;
						printPage.FooterContentHeight = FooterForFirstPage.Height;
						printPage.FirstPageFlag = true;
					}
					else
					{
						printPage.HeaderContentHeight = Header.Height;
						printPage.FooterContentHeight = Footer.Height;
						printPage.FirstPageFlag = false;
					}
				}
				else
				{
					printPage.HeaderContentHeight = 0f;
					printPage.FooterContentHeight = 0f;
				}
				printPage.Height = printPage.StandartPapeBodyHeight;
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					printPage.HeaderRows = xTextElementList;
					MultiPageTransform.smethod_0(printPage);
					float num4 = 0f;
					foreach (XTextTableRowElement item6 in xTextElementList)
					{
						num4 += item6.Height;
					}
					printPage.Height -= num4;
				}
				if (printPage.Height < 50f)
				{
					break;
				}
				printPage.DocumentHeight = Height;
				gClass.method_19(pages.Count);
				gClass.method_21(printPage.Top);
				gClass.float_3 = printPage.Bottom;
				gClass.method_15(PageViewMode);
				gClass.method_3(bool_5: false);
				body.method_42(gClass);
				if (gClass.method_6().Count > 1)
				{
					List<XTextElement> list3 = new List<XTextElement>();
					for (int i = 0; i < gClass.method_6().Count - 1; i++)
					{
						XTextContentElement current2 = null;
						XTextElement xTextElement = gClass.method_6()[i];
						current2 = ((!(xTextElement is XTextContentElement)) ? xTextElement.ContentElement : ((XTextContentElement)xTextElement));
						if (current2 != null && !list3.Contains(current2))
						{
							list3.Add(current2);
							if (!(current2 is XTextDocumentContentElement) && !FixContentForPageLineElements.Contains(current2))
							{
								FixContentForPageLineElements.Add(current2);
							}
						}
					}
				}
				gClass.method_5(null);
				gClass.method_6().Clear();
				printPage.Height = gClass.method_23() - printPage.Top;
				forNewPage = gClass.method_2();
				xTextElementList = gClass.method_25();
				gClass.method_26(null);
				if (!(gClass.method_4() is XTextPageBreakElement) && printPage.Height < gClass.method_12())
				{
					printPage.Height = printPage.ViewStandardHeight;
				}
				num = printPage.Bottom;
				pages.Add(printPage);
			}
			list.Clear();
			list = null;
			if (pages.Count > 0)
			{
				body.method_69();
				pages.LastPage.Height = pages.LastPage.Height - (pages.Height - body.AbsTop - body.Height);
			}
			foreach (PrintPage item7 in pages)
			{
			}
			PageRefreshed = true;
			if (Info != null)
			{
				Info.NumOfPage = pages.Count;
			}
			if (FixContentForPageLineElements.Count > 0)
			{
				foreach (XTextContentElement fixContentForPageLineElement in FixContentForPageLineElements)
				{
					fixContentForPageLineElement?.method_34();
				}
				foreach (XTextLine item8 in allLines)
				{
					item8.AbsTopBuffered = -1f;
					item8.AbsTopBuffered = item8.AbsTop;
				}
			}
			foreach (XTextContentElement contentElement in Body.ContentElements)
			{
				contentElement.method_40();
			}
			body.method_69();
			foreach (XTextLine item9 in allLines)
			{
				item9.AbsTopBuffered = -1f;
			}
			using (DCGraphics dcgraphics_ = CreateDCGraphics())
			{
				DocumentPaintEventArgs documentPaintEventArgs = method_55(dcgraphics_);
				using (List<XTextElement>.Enumerator enumerator2 = GetElementsByType(typeof(XTextPageInfoElement)).GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)(documentPaintEventArgs.Element = (XTextPageInfoElement)enumerator2.Current);
						float width = xTextPageInfoElement.Width;
						xTextPageInfoElement.RefreshSize(documentPaintEventArgs);
						float num5 = xTextPageInfoElement.Width - width;
						if (num5 != 0f)
						{
							XTextLine current = xTextPageInfoElement.OwnerLine;
							for (int i = current.IndexOf(xTextPageInfoElement) + 1; i < current.Count; i++)
							{
								current[i].Left += num5;
							}
						}
					}
				}
			}
			if (!States.Printing && EditorControl != null && EditorControl.InnerViewControl != null && EditorControl.InnerViewControl.RuntimeHasCommentLayout && method_74() && EditorControl != null)
			{
				GClass445.smethod_9(EditorControl.InnerViewControl, WriterStringsCore.RefreshDocumentComments);
				using (DCGraphics dcgraphics_ = CreateDCGraphics())
				{
					EditorControl.CommentManager.imethod_3(dcgraphics_);
				}
			}
			RefreshLabelContactString();
			if (EditorControl != null)
			{
				EditorControl.vmethod_44();
			}
			States.Layouted = true;
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		/// <summary>
		///       刷新内容连接的标签文档元素对象的内容
		///       </summary>
		[DCPublishAPI]
		public void RefreshLabelContactString()
		{
			foreach (XTextElement element in Elements)
			{
				if (!(element is XTextDocumentBodyElement))
				{
					DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(element.Elements);
					domTreeNodeEnumerable.ExcludeCharElement = true;
					domTreeNodeEnumerable.ExcludeParagraphFlag = true;
					foreach (XTextElement item in domTreeNodeEnumerable)
					{
						if (item is XTextLabelElement)
						{
							XTextLabelElement xTextLabelElement = (XTextLabelElement)item;
							if (xTextLabelElement.UpdateContactAction())
							{
								xTextLabelElement.InvalidateView();
							}
						}
					}
				}
			}
		}

		internal void method_97(bool bool_32, bool bool_33)
		{
			method_98();
			if (!UIIsUpdating)
			{
				FixDomState();
				foreach (XTextDocumentContentElement element in Elements)
				{
					element.ParagraphTreeInvalidte = true;
					element.vmethod_31(bool_17: true);
				}
				if (bool_33)
				{
					method_79();
				}
				foreach (XTextContentElement item in GetElementsByType(typeof(XTextContentElement)))
				{
					if (!item.IsInCollapsedSection && (!(item is XTextSectionElement) || !((XTextSectionElement)item).RuntimeIsCollapsed))
					{
						XTextContentElement.Class11 @class = new XTextContentElement.Class11();
						@class.method_11(bool_5: false);
						@class.method_7(bool_5: false);
						item.vmethod_37(@class);
						if (bool_32 && item is XTextTableCellElement)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)item;
							xTextTableCellElement.Width = 0f;
							xTextTableCellElement.Height = 0f;
							XTextTableElement ownerTable = xTextTableCellElement.OwnerTable;
							if (ownerTable != null)
							{
								ownerTable.LayoutInvalidate = true;
							}
						}
					}
				}
				if (bool_32)
				{
					foreach (XTextElement element2 in Body.Elements)
					{
						if (element2 is XTextSectionElement)
						{
							((XTextSectionElement)element2).LayoutInvalidate = true;
						}
					}
				}
				if (HighlightManager != null && !UIIsUpdating)
				{
					HighlightManager.imethod_4();
				}
			}
		}

		/// <summary>
		///       对整个文档执行重新排版操作
		///       </summary>
		public override void ExecuteLayout()
		{
			method_98();
			if (UIIsUpdating)
			{
				return;
			}
			if (EditorControl != null && !EditorControl.IsUpdating)
			{
				GClass445.smethod_9(EditorControl.InnerViewControl, WriterStringsCore.RefreshingDocumentLayout);
			}
			FixDomState();
			float tickCountFloat = CountDown.GetTickCountFloat();
			using (DCGraphics dcgraphics_ = CreateDCGraphics())
			{
				foreach (DocumentContentStyle style in ContentStyles.Styles)
				{
					style.method_32(dcgraphics_);
				}
			}
			ContentStyles.method_4();
			bool_21 = false;
			try
			{
				ContentStyles.bool_0 = true;
				ContentStyles.method_4();
				ContentStyles.bool_0 = false;
				ArrayList arrayList = new ArrayList(Elements);
				foreach (XTextDocumentContentElement item in arrayList)
				{
					item.ExecuteLayout();
				}
			}
			finally
			{
				ContentStyles.bool_0 = true;
				bool_21 = true;
			}
			float num = Header.Height + Footer.Height;
			float num2 = num - PageSettings.ViewClientHeight * 0.9f;
			if (num2 > 0f)
			{
				if (Header.Height > num2)
				{
					Header.Height -= num2;
				}
				else
				{
					Footer.Height -= num2;
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_98()
		{
			int num = 10;
			if (bool_24)
			{
				throw new ObjectDisposedException("dcwriter.document");
			}
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public override void Dispose()
		{
			bool_24 = true;
			base.Dispose();
			if (xpageSettings_0 != null)
			{
				xpageSettings_0.Dispose();
			}
			if (repeatedImageValueList_0 != null)
			{
				RepeatedImageValueList repeatedImageValueList = repeatedImageValueList_0;
				repeatedImageValueList_0 = null;
				repeatedImageValueList.Dispose();
			}
			if (gclass123_0 != null)
			{
				gclass123_0.method_4();
				gclass123_0 = null;
			}
			method_57();
			if (gclass95_0 != null)
			{
				gclass95_0.Dispose();
				gclass95_0 = null;
			}
			if (idocumentScriptEngine_0 != null)
			{
				idocumentScriptEngine_0.Close();
				idocumentScriptEngine_0 = null;
			}
			documentOptions_1 = null;
			adornTextManager_0 = null;
			writerAppHost_0 = null;
			binaryContentBuffer_0 = null;
			class135_0 = null;
			dictionary_0 = null;
			documentCommentList_1 = null;
			gclass108_0 = null;
			class136_0 = null;
			documentContentStyleContainer_0 = null;
			writerControlOptions_0 = null;
			ginterface7_0 = null;
			xtextDocumentContentElement_0 = null;
			printPage_0 = null;
			currentContentStyleInfo_0 = null;
			list_2 = null;
			documentControler_0 = null;
			documentOptions_0 = null;
			writerControl_0 = null;
			idcelementIDForEditableDependentExecuter_0 = null;
			xtextElementList_1 = null;
			ginterface4_0 = null;
			string_23 = null;
			list_1 = null;
			elementEventTemplate_0 = null;
			string_17 = null;
			list_0 = null;
			printPageCollection_1 = null;
			ginterface6_0 = null;
			xtextElement_0 = null;
			documentInfo_0 = null;
			dataSourceTreeDocument_1 = null;
			documentParameterCollection_1 = null;
			systemAlertInfoList_0 = null;
			appErrorInfo_0 = null;
			dictionary_2 = null;
			xtextElementList_4 = null;
			xtextElementList_2 = null;
			printResult_0 = null;
			class114_0 = null;
			localConfig_0 = null;
			memoryStream_0 = null;
			motherTemplateInfo_0 = null;
			gclass132_0 = null;
			documentOutlineNodeList_0 = null;
			documentOptions_1 = null;
			printPageCollection_0 = null;
			xpageSettings_0 = null;
			documentParameterCollection_0 = null;
			object_1 = null;
			repeatedImageValueList_0 = null;
			dictionary_1 = null;
			idocumentScriptEngine_0 = null;
			string_18 = null;
			scriptLanguageType_0 = ScriptLanguageType.VBNET;
			contentSerializeOptions_0 = null;
			object_2 = null;
			dataSourceTreeDocument_0 = null;
			float_8 = null;
			xtextElement_1 = null;
			documentStates_0 = null;
			ginterface2_0 = null;
			xtextDocumentUndoList_0 = null;
			userHistoryInfoList_0 = null;
		}

		/// <summary>
		///       根据数据名称获得文档中所有的数据
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public Hashtable GetValuesByDataName()
		{
			int num = 8;
			Hashtable hashtable = new Hashtable();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Elements);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				string text = null;
				string key = null;
				if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					if (!string.IsNullOrEmpty(xTextContainerElement.DataName))
					{
						key = xTextContainerElement.DataName;
						text = xTextContainerElement.Text;
						if (item is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)item;
							if (!string.IsNullOrEmpty(xTextInputFieldElement.InnerValue))
							{
								text = xTextInputFieldElement.InnerValue;
							}
						}
					}
				}
				else if (item is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
					if (xTextCheckBoxElementBase.Checked && !string.IsNullOrEmpty(xTextCheckBoxElementBase.DataName))
					{
						key = xTextCheckBoxElementBase.DataName;
						text = xTextCheckBoxElementBase.CheckedValue;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					if (!hashtable.Contains(key))
					{
						hashtable[key] = text;
					}
					else
					{
						hashtable[key] = string.Concat(hashtable[key], ",", text);
					}
				}
			}
			return hashtable;
		}

		/// <summary>
		///       将指定名称的文档参数值填充到文档中
		///       </summary>
		/// <param name="parameterNames">指定的文档参数名称，各个名称之间用英文逗号分开。比如“姓名,性别,国籍”，如果为空则更新全部数据源。</param>
		/// <returns>更新的数据点个数</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public int WriteDataFromDataSourceToDocumentSpecifyParameterNames(string parameterNames)
		{
			method_98();
			UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
			updateDataBindingArgs.FastMode = true;
			if (!string.IsNullOrEmpty(parameterNames))
			{
				updateDataBindingArgs.SpecifyParameterNames = parameterNames.Split(',');
			}
			method_103();
			int num = UpdateDataBindingExt(updateDataBindingArgs);
			if (num > 0)
			{
				XTextElementList handledElements = updateDataBindingArgs.HandledElements;
				GInterface7 copySourceExecuter = CopySourceExecuter;
				if (copySourceExecuter != null && handledElements != null && handledElements.Count > 0)
				{
					foreach (XTextElement item in handledElements)
					{
						if (item is XTextContainerElement)
						{
							copySourceExecuter.imethod_2(item);
						}
					}
				}
				FixDomState();
				if (UndoList != null)
				{
					UndoList.Clear();
				}
			}
			return num;
		}

		/// <summary>
		///       检测数据源填充操作导致的修改文档元素的相关信息，但不真正填充数据源，不会修改文档内容。
		///       </summary>
		/// <returns>结果信息列表</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetDetectValueBindingModifiedMessage()
		{
			DetectResultForValueBindingModifiedList detectResultForValueBindingModifiedList = DetectValueBindingModified();
			if (detectResultForValueBindingModifiedList == null || detectResultForValueBindingModifiedList.Count == 0)
			{
				return null;
			}
			return detectResultForValueBindingModifiedList.ToString();
		}

		/// <summary>
		///       检测数据源填充操作导致的修改文档元素的个数，但不真正填充数据源，不会修改文档内容。
		///       </summary>
		/// <returns>结果信息列表</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public DetectResultForValueBindingModifiedList DetectValueBindingModified()
		{
			method_98();
			UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
			updateDataBindingArgs.FastMode = true;
			updateDataBindingArgs.DetectValueModified = true;
			method_103();
			UpdateDataBindingExt(updateDataBindingArgs);
			if (updateDataBindingArgs.DetectResults != null && updateDataBindingArgs.DetectResults.Count > 0)
			{
				return updateDataBindingArgs.DetectResults;
			}
			return null;
		}

		/// <summary>
		///       将数据源填充到文档中
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public int WriteDataFromDataSourceToDocument()
		{
			return WriteDataFromDataSourceToDocumentSpecifyParameterNames(null);
		}

		/// <summary>
		///       重置表单元素默认值
		///       </summary>
		/// <returns>是否导致文档内容发生改变</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool ResetFormValue()
		{
			method_98();
			bool flag = false;
			foreach (XTextInputFieldElement item in GetElementsByType(typeof(XTextInputFieldElement)))
			{
				if (item.ResetToDefaultValue())
				{
					item.Modified = false;
					flag = true;
				}
			}
			foreach (XTextCheckBoxElementBase item2 in GetElementsByType(typeof(XTextCheckBoxElementBase)))
			{
				if (item2.Checked)
				{
					item2.Checked = false;
					item2.Modified = false;
					flag = true;
				}
			}
			if (flag)
			{
				WriterControl.RefreshDocument();
			}
			return flag;
		}

		/// <summary>
		///       填充数据源到文档内容中
		///       </summary>
		/// <param name="fastMode">快速模式</param>
		/// <returns>操作是否导致了文档内容发生改变的处数</returns>
		[Obsolete("请使用FillDataSourceToDocument()函数")]
		[DCInternal]
		[ComVisible(true)]
		public int FillDataSource(bool fastMode)
		{
			UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
			updateDataBindingArgs.FastMode = fastMode;
			return UpdateDataBindingExt(updateDataBindingArgs);
		}

		private string method_99(string string_26)
		{
			VariableString variableString = new VariableString(string_26);
			variableString.SetVariable("pageindex", Convert.ToString(PageIndex));
			variableString.SetVariable("pagecount", printPageCollection_0.Count.ToString());
			DateTime nowDateTime = GetNowDateTime();
			variableString.SetVariable("year", nowDateTime.Year.ToString());
			variableString.SetVariable("month", nowDateTime.Month.ToString());
			variableString.SetVariable("day", nowDateTime.Day.ToString());
			variableString.SetVariable("hour", nowDateTime.Hour.ToString());
			variableString.SetVariable("minute", nowDateTime.Minute.ToString());
			variableString.SetVariable("secend", nowDateTime.Second.ToString());
			return variableString.Execute();
		}

		/// <summary>
		///       设置表单值
		///       </summary>
		/// <param name="name">表单元素名称</param>
		/// <param name="Value">表单值</param>
		/// <returns>操作是否修改了文档内容</returns>
		[DCPublishAPI]
		public bool SetFormValue(string name, string Value)
		{
			bool result = false;
			XTextElementList elementsByName = GetElementsByName(name);
			if (elementsByName != null && elementsByName.Count > 0)
			{
				foreach (XTextElement item in elementsByName)
				{
					if (item is XTextFieldElementBase)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)item;
						if (xTextFieldElementBase.EditorTextExt != Value)
						{
							xTextFieldElementBase.EditorTextExt = Value;
							result = true;
						}
					}
					else if (item is XTextCheckBoxElement)
					{
						IDList iDList = new IDList(Value, ',');
						XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)item;
						bool flag = iDList.Contains(xTextCheckBoxElement.CheckedValue);
						if (xTextCheckBoxElement.EditorChecked != flag)
						{
							xTextCheckBoxElement.EditorChecked = flag;
							result = true;
						}
					}
					else if (item is XTextRadioBoxElement)
					{
						XTextRadioBoxElement xTextRadioBoxElement = (XTextRadioBoxElement)item;
						bool flag = xTextRadioBoxElement.CheckedValue == Value;
						if (xTextRadioBoxElement.EditorChecked != flag)
						{
							xTextRadioBoxElement.EditorChecked = flag;
							result = true;
						}
					}
				}
				return result;
			}
			return result;
		}

		/// <summary>
		///       获得表单数据
		///       </summary>
		/// <param name="name">字段名称</param>
		/// <returns>获得的表单数值</returns>
		[DCPublishAPI]
		public string GetFormValue(string name)
		{
			int num = 11;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			string result = null;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item;
					if (xTextInputFieldElementBase.ID == name || xTextInputFieldElementBase.Name == name)
					{
						result = xTextInputFieldElementBase.Text;
						break;
					}
				}
				else if (item is XTextCheckBoxElement)
				{
					XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)item;
					if (xTextCheckBoxElement.Name == name)
					{
						XTextElementList elementsInSameGroup = xTextCheckBoxElement.GetElementsInSameGroup();
						StringBuilder stringBuilder = new StringBuilder();
						foreach (XTextCheckBoxElement item2 in elementsInSameGroup)
						{
							if (item2.Checked)
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append(",");
								}
								stringBuilder.Append(item2.CheckedValue);
								if (xTextCheckBoxElement.ControlStyle == CheckBoxControlStyle.RadioBox)
								{
									break;
								}
							}
						}
						result = stringBuilder.ToString();
						break;
					}
				}
			}
			return result;
		}

		/// <summary>
		///       清空数据校验结果信息
		///       </summary>
		/// <returns>清除的信息个数</returns>
		[DCPublishAPI]
		public int ClearValueValidateResult()
		{
			int num = 0;
			XTextElementList elementsByType = GetElementsByType(typeof(XTextInputFieldElementBase));
			if (elementsByType.Count > 0)
			{
				foreach (XTextInputFieldElementBase item in elementsByType)
				{
					if (item.vmethod_23(bool_20: false))
					{
						num++;
						item.InvalidateView();
						if (HighlightManager != null)
						{
							HighlightManager.imethod_9(item);
						}
					}
				}
			}
			if (num > 0 && EditorControl != null)
			{
				EditorControl.UpdateToolTip(checkVersion: false);
				EditorControl.InnerViewControl.Invalidate();
			}
			return num;
		}

		internal void method_100(XTextElement xtextElement_3)
		{
			if (documentCommentList_0 != null)
			{
				foreach (DocumentComment item in documentCommentList_0)
				{
					if (item.DataBoundItem is ValueValidateResult)
					{
						ValueValidateResult valueValidateResult = (ValueValidateResult)item.DataBoundItem;
						if (valueValidateResult.Element == xtextElement_3)
						{
							documentCommentList_0.Remove(item);
							if (CommentManager != null)
							{
								CommentManager.imethod_2();
								if (WriterControl != null)
								{
									WriterControl.Invalidate(invalidateChildren: true);
								}
							}
							break;
						}
					}
				}
			}
		}

		private int method_101(ValueValidateResultList valueValidateResultList_0, DocumentCommentList documentCommentList_2)
		{
			int num = 7;
			if (valueValidateResultList_0 == null || valueValidateResultList_0.Count == 0)
			{
				return 0;
			}
			if (documentCommentList_2 == null)
			{
				throw new ArgumentNullException("cmds");
			}
			int result = 0;
			foreach (ValueValidateResult item in valueValidateResultList_0)
			{
				if (item.Element != null)
				{
					DocumentComment documentComment = new DocumentComment();
					documentComment.bool_0 = true;
					documentComment.Text = item.Message;
					documentComment.BackColor = Color.Yellow;
					documentComment.Document = this;
					documentComment.AnchorElement = item.Element.FirstContentElementInPublicContent;
					documentComment.DataBoundItem = item;
					documentComment.Title = WriterStringsCore.ValueInvalidate;
					documentComment.ReferenceElements = item.GetReferenceElements();
					documentCommentList_2.Add(documentComment);
				}
			}
			return result;
		}

		/// <summary>
		///       检验文档，并根据校验结果自动生成文档批注。
		///       </summary>
		/// <returns>校验信息列表，如果返回空列表则校验全部通过</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public ValueValidateResultList ValueValidateWithCreateDocumentComments()
		{
			ValueValidateResultList valueValidateResultList = ValueValidate();
			if (!smethod_13(GEnum6.const_178))
			{
				return valueValidateResultList;
			}
			bool flag = documentCommentList_0 != null && documentCommentList_0.Count > 0;
			documentCommentList_0 = new DocumentCommentList();
			method_101(valueValidateResultList, documentCommentList_0);
			bool flag2 = documentCommentList_0 != null && documentCommentList_0.Count > 0;
			if ((flag || flag2) && WriterControl != null && WriterControl.CommentManager != null)
			{
				WriterControl.CommentManager.imethod_2();
				WriterControl.Invalidate(invalidateChildren: true);
				WriterControl.UpdateTextCaretWithoutScroll();
			}
			return valueValidateResultList;
		}

		/// <summary>
		///       对整个文档的输入域进行数据校验
		///       </summary>
		/// <returns>校验信息列表，如果返回空列表则校验全部通过</returns>
		[DCPublishAPI]
		public ValueValidateResultList ValueValidate()
		{
			if (Options == null || Options.EditOptions.ValueValidateMode == DocumentValueValidateMode.None)
			{
				return null;
			}
			ValueValidateResultList valueValidateResultList = new ValueValidateResultList();
			List<string> list = new List<string>();
			if (smethod_13(GEnum6.const_147))
			{
				string excludeKeywords = Options.BehaviorOptions.ExcludeKeywords;
				if (excludeKeywords != null && excludeKeywords.Length > 0)
				{
					string[] array = excludeKeywords.Split(',', '|');
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (text.Trim().Length > 0)
						{
							list.Add(text.Trim());
						}
					}
				}
				if (LocalExcludeKeywords != null && LocalExcludeKeywords.Length > 0)
				{
					string[] array = LocalExcludeKeywords.Split(',');
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (text.Trim().Length > 0)
						{
							list.Add(text.Trim());
						}
					}
				}
			}
			if (list.Count > 0)
			{
				GInterface3 gInterface = AppHost.Tools.CreateContentSearchReplacer();
				if (gInterface != null)
				{
					gInterface.imethod_5(this);
					XTextElementList contentElements = Body.ContentElements;
					SearchReplaceCommandArgs searchReplaceCommandArgs = new SearchReplaceCommandArgs();
					searchReplaceCommandArgs.Backward = true;
					searchReplaceCommandArgs.EnableReplaceString = false;
					searchReplaceCommandArgs.IgnoreCase = false;
					searchReplaceCommandArgs.SearchID = false;
					using (List<string>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							string text = searchReplaceCommandArgs.SearchString = enumerator.Current;
							foreach (XTextContentElement item in contentElements)
							{
								int int_ = 0;
								while (true)
								{
									int_ = gInterface.imethod_12(searchReplaceCommandArgs, item.PrivateContent, bool_0: false, int_);
									if (int_ < 0)
									{
										break;
									}
									ValueValidateResult valueValidateResult = new ValueValidateResult();
									valueValidateResult.Element = item.PrivateContent[int_];
									valueValidateResult.Type = ValueValidateResultTypes.ExcludeKeyword;
									valueValidateResult.ExcludeKeywordText = text;
									valueValidateResult.Level = ValueValidateLevel.Error;
									valueValidateResult.Message = string.Format(WriterStringsCore.ExcludeKeyword_Keyword, text);
									valueValidateResultList.Add(valueValidateResult);
									int_ += text.Length;
								}
							}
						}
					}
				}
			}
			XTextElementList elementsByType = GetElementsByType(typeof(XTextCheckBoxElementBase));
			if (elementsByType != null && elementsByType.Count > 0)
			{
				List<string> list2 = new List<string>();
				foreach (XTextCheckBoxElementBase item2 in elementsByType)
				{
					if (item2.RuntimeRequired && !string.IsNullOrEmpty(item2.Name) && !list2.Contains(item2.Name))
					{
						list2.Add(item2.Name);
						XTextElementList elementsInSameGroup = item2.GetElementsInSameGroup();
						bool flag = false;
						foreach (XTextCheckBoxElementBase item3 in elementsInSameGroup)
						{
							if (item3.Checked)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							ValueValidateResult valueValidateResult = new ValueValidateResult();
							valueValidateResult.Element = item2;
							valueValidateResult.Level = ValueValidateLevel.Error;
							valueValidateResult.Message = string.Format(WriterStringsCore.CheckRequired_Name, item2.Name);
							valueValidateResult.Type = ValueValidateResultTypes.ValueValidate;
							valueValidateResultList.Add(valueValidateResult);
						}
					}
				}
			}
			XTextElementList elementsByType2 = GetElementsByType(typeof(XTextContainerElement));
			if (elementsByType2.Count > 0)
			{
				foreach (XTextContainerElement item4 in elementsByType2)
				{
					if (item4.EnableValueValidate)
					{
						XTextElement xTextElement = item4;
						bool flag2 = false;
						while (xTextElement != null && !(xTextElement is XTextDocumentContentElement))
						{
							if (xTextElement.RuntimeStyle.DeleterIndex >= 0)
							{
								flag2 = true;
								break;
							}
							if (!xTextElement.Visible)
							{
								flag2 = true;
								break;
							}
							xTextElement = xTextElement.Parent;
						}
						if (!flag2)
						{
							ValueValidateResult valueValidateResult = item4.vmethod_24(bool_17: false);
							if (valueValidateResult != null)
							{
								valueValidateResultList.Add(valueValidateResult);
							}
							if (HighlightManager != null)
							{
								HighlightManager.imethod_9(item4);
							}
						}
					}
				}
			}
			if (valueValidateResultList.Count > 1)
			{
				valueValidateResultList.SoryByDOMLevel();
			}
			return valueValidateResultList;
		}

		/// <summary>
		///       获得描述数据源绑定信息的XML字符串
		///       </summary>
		/// <returns>描述数据源绑定信息的XML字符串。</returns>
		/// <example>
		///       本函数返回的是类似以下的XML字符串，注意：此处使用了方括号替换了尖括号。
		///       [DCDataSourceBindingDescriptions]
		///           [Binding DataSource="Patient" BindingPath="Name" ElementID="field1" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="Age" ElementID="field2" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="Address.Street" ElementID="field3" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="Sex" ElementID="radio1" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="Sex" ElementID="radio2" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="过敏" ElementID="" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="过敏" ElementID="" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="过敏" ElementID="" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="Patient" BindingPath="过敏" ElementID="" FormatString="" AutoUpdate="False" Readonly="False" /]
		///           [Binding DataSource="年龄" BindingPath="" ElementID="field4" FormatString="" AutoUpdate="False" Readonly="False" /]
		///       [/DCDataSourceBindingDescriptions]
		///       </example>[System.Reflection.Obfuscation(Exclude = true, ApplyToMembers = true)]
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetDataSourceBindingDescriptionsXML()
		{
			int num = 13;
			DataSourceBindingDescriptionList dataSourceBindingDescriptions = GetDataSourceBindingDescriptions();
			GClass351 gClass = new GClass351(bool_0: true);
			if (dataSourceBindingDescriptions != null)
			{
				gClass.method_1();
				gClass.method_3("DCDataSourceBindingDescriptions");
				foreach (DataSourceBindingDescription item in dataSourceBindingDescriptions)
				{
					gClass.method_3("Binding");
					gClass.method_7("DataSource", item.DataSource);
					gClass.method_7("BindingPath", item.BindingPath);
					gClass.method_7("ElementID", item.ElementID);
					gClass.method_7("FormatString", item.FormatString);
					gClass.method_7("AutoUpdate", item.AutoUpdate.ToString());
					gClass.method_7("Readonly", item.Readonly.ToString());
					gClass.method_4();
				}
				gClass.method_4();
				gClass.method_2();
			}
			return gClass.method_0();
		}

		/// <summary>
		///       获得文档中绑定的数据源名称字符串列表。各个名称之间用逗号分开。
		///       </summary>
		/// <returns>数据源名称列表</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetBindingDataSources()
		{
			DataSourceBindingDescriptionList dataSourceBindingDescriptions = GetDataSourceBindingDescriptions();
			IDList iDList = new IDList();
			iDList.IgnoreCase = true;
			if (dataSourceBindingDescriptions != null)
			{
				foreach (DataSourceBindingDescription item in dataSourceBindingDescriptions)
				{
					iDList.Add(item.DataSource);
				}
			}
			return iDList.ToString();
		}

		/// <summary>
		///       获得描述数据源绑定信息的XML字符串
		///       </summary>
		/// <returns>描述信息列表</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public DataSourceBindingDescriptionList GetDataSourceBindingDescriptions()
		{
			DataSourceBindingDescriptionList dataSourceBindingDescriptionList = new DataSourceBindingDescriptionList();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				XDataBinding xDataBinding = null;
				if (item is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
					xDataBinding = xTextCheckBoxElementBase.ValueBinding;
				}
				else if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					xDataBinding = xTextContainerElement.ValueBinding;
				}
				if (!(xDataBinding?.IsEmptyBinding ?? true))
				{
					DataSourceBindingDescription dataSourceBindingDescription = new DataSourceBindingDescription();
					dataSourceBindingDescription.DataSource = xDataBinding.DataSource;
					if (string.IsNullOrEmpty(xDataBinding.BindingPath))
					{
						dataSourceBindingDescription.BindingPath = xDataBinding.BindingPathForText;
					}
					else
					{
						dataSourceBindingDescription.BindingPath = xDataBinding.BindingPath;
					}
					dataSourceBindingDescription.ElementID = item.ID;
					dataSourceBindingDescription.Element = item;
					dataSourceBindingDescription.FormatString = xDataBinding.FormatString;
					dataSourceBindingDescription.AutoUpdate = xDataBinding.AutoUpdate;
					dataSourceBindingDescription.Readonly = xDataBinding.Readonly;
					dataSourceBindingDescriptionList.Add(dataSourceBindingDescription);
				}
			}
			return dataSourceBindingDescriptionList;
		}

		/// <summary>
		///       本接口仅供保持兼容性，请改为使用WriteDataFromDocumentToDataSource()
		///       </summary>
		/// <returns>写入的数据点个数</returns>
		[Obsolete("请使用WriteDataFromDocumentToDataSource()函数")]
		[DCInternal]
		public int WriteDataSource()
		{
			return WriteDataFromDocumentToDataSource();
		}

		private bool method_102(DataSourceTreeNode dataSourceTreeNode_1, XTextElement xtextElement_3, string string_26, bool bool_32, List<DataSourceTreeNode> list_3)
		{
			int num = 11;
			if (dataSourceTreeNode_1 == null)
			{
				throw new ArgumentNullException("node");
			}
			if (xtextElement_3 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (dataSourceTreeNode_1 == null || dataSourceTreeNode_1.IsEmpty || dataSourceTreeNode_1.Readonly)
			{
				return false;
			}
			List<Class17> list = dataSourceTreeNode_1.BindingTarget as List<Class17>;
			if (list == null)
			{
				list = (List<Class17>)(dataSourceTreeNode_1.BindingTarget = new List<Class17>());
			}
			if (bool_32 && list.Count > 0)
			{
				if (xtextElement_3.OwnerDocument != null)
				{
					xtextElement_3.OwnerDocument.LastAlertInfos.AddInfo(string.Format(WriterStringsCore.RepeatDataBinging_Element_DataSource, xtextElement_3.ToDebugString(), dataSourceTreeNode_1.FullPath));
				}
				return false;
			}
			Class17 @class = new Class17();
			@class.xtextElement_0 = xtextElement_3;
			@class.string_0 = string_26;
			list.Add(@class);
			if (!list_3.Contains(dataSourceTreeNode_1))
			{
				list_3.Add(dataSourceTreeNode_1);
			}
			return true;
		}

		/// <summary>
		///       将文档中的数据写入到数据源中,本函数会修改LastAlertInfos列表内容。
		///       </summary>
		/// <returns>写入的数据点个数</returns>
		[DCPublishAPI]
		public int WriteDataFromDocumentToDataSource()
		{
			int num = 12;
			method_98();
			LastAlertInfos.Clear();
			xtextElementList_4 = null;
			if (RuntimeDataSourceTree == null)
			{
				return 0;
			}
			int num2 = 0;
			new Class16();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			RuntimeDataSourceTree.ClearBindingTarget();
			List<DataSourceTreeNode> list = new List<DataSourceTreeNode>();
			new UpdateDataBindingArgs();
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
					if (!(xTextCheckBoxElementBase is XTextRadioBoxElement) || xTextCheckBoxElementBase.Checked)
					{
						DataSourceTreeNode dataSourceTreeNode = xTextCheckBoxElementBase.DataBoundNode;
						if (SerializeParameterValue && dataSourceTreeNode == null)
						{
							dataSourceTreeNode = xTextCheckBoxElementBase.method_17();
							if (dataSourceTreeNode != null && !dataSourceTreeNode.IsEmpty && !dataSourceTreeNode.HasProperty)
							{
							}
						}
						if ((xTextCheckBoxElementBase.DataBoundNodeValueUsed || SerializeParameterValue) && dataSourceTreeNode != null && !dataSourceTreeNode.IsEmpty && !dataSourceTreeNode.Readonly)
						{
							method_102(dataSourceTreeNode, xTextCheckBoxElementBase, xTextCheckBoxElementBase.CheckedValue, xTextCheckBoxElementBase is XTextRadioBoxElement, list);
						}
					}
				}
				else if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					DataSourceTreeNode dataSourceTreeNode = xTextContainerElement.DataBoundNode;
					if (SerializeParameterValue && dataSourceTreeNode == null)
					{
						dataSourceTreeNode = xTextContainerElement.method_15();
					}
					if ((xTextContainerElement.DataBoundNodeValueUsed || SerializeParameterValue) && dataSourceTreeNode != null && !dataSourceTreeNode.IsEmpty && !dataSourceTreeNode.Readonly)
					{
						if (item is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)item;
							string text = xTextInputFieldElement.InnerValue;
							if (string.IsNullOrEmpty(text))
							{
								text = xTextInputFieldElement.Text;
							}
							if (text == xTextInputFieldElement.DefaultValueForValueBinding)
							{
								text = null;
							}
							if (method_102(dataSourceTreeNode, xTextInputFieldElement, text, bool_32: true, list))
							{
								if (xTextInputFieldElement.DataSourceNodeForText != null)
								{
									method_102(xTextInputFieldElement.DataSourceNodeForText, xTextInputFieldElement, xTextInputFieldElement.Text, bool_32: true, list);
								}
								if (xTextInputFieldElement.DataSourceNodeForWriteText != null)
								{
									method_102(xTextInputFieldElement.DataSourceNodeForWriteText, xTextInputFieldElement, xTextInputFieldElement.Text, bool_32: true, list);
								}
							}
						}
						else
						{
							string text2 = xTextContainerElement.Text;
							if (text2 == xTextContainerElement.DefaultValueForValueBinding)
							{
								text2 = null;
							}
							method_102(dataSourceTreeNode, xTextContainerElement, text2, bool_32: true, list);
						}
					}
					else if (xTextContainerElement.RuntimeSupportValueBinding && xTextContainerElement.ValueBinding != null && !xTextContainerElement.ValueBinding.IsEmptyBinding && !xTextContainerElement.ValueBinding.Readonly)
					{
						string text3 = item.Text;
						if (item is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)item;
							text3 = xTextInputFieldElement.InnerValue;
							if (string.IsNullOrEmpty(text3))
							{
								text3 = xTextInputFieldElement.Text;
							}
							if (text3 == xTextInputFieldElement.DefaultValueForValueBinding)
							{
								text3 = null;
							}
						}
						if (XDataBindingProvider.StdWriteValue(xTextContainerElement.ValueBinding, Parameters.GetValue(xTextContainerElement.ValueBinding.DataSource), text3, throwException: false))
						{
							if (xtextElementList_4 == null)
							{
								xtextElementList_4 = new XTextElementList();
							}
							xtextElementList_4.Add(xTextContainerElement);
							num2++;
						}
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (DataSourceTreeNode item2 in list)
				{
					List<Class17> list2 = (List<Class17>)item2.BindingTarget;
					StringBuilder stringBuilder = new StringBuilder();
					if (list2.Count == 1 && list2[0].xtextElement_0 is XTextCheckBoxElementBase)
					{
						XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)list2[0].xtextElement_0;
						if (string.IsNullOrEmpty(xTextCheckBoxElementBase.CheckedValue))
						{
							stringBuilder.Append(xTextCheckBoxElementBase.Checked.ToString());
						}
					}
					if (stringBuilder.Length == 0)
					{
						foreach (Class17 item3 in list2)
						{
							if ((!(item3.xtextElement_0 is XTextCheckBoxElementBase) || ((XTextCheckBoxElementBase)item3.xtextElement_0).Checked) && !string.IsNullOrEmpty(item3.string_0))
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append(",");
								}
								stringBuilder.Append(item3.string_0);
							}
						}
					}
					if (item2.SetValue(stringBuilder.ToString()))
					{
						num2++;
						if (xtextElementList_4 == null)
						{
							xtextElementList_4 = new XTextElementList();
						}
						foreach (Class17 item4 in list2)
						{
							xtextElementList_4.Add(item4.xtextElement_0);
						}
					}
					item2.BindingTarget = null;
				}
				return num2;
			}
			return 0;
		}

		[DCInternal]
		public void method_103()
		{
			dataSourceTreeDocument_1 = null;
		}

		internal bool method_104(XDataBinding xdataBinding_1)
		{
			if (xdataBinding_1 == null)
			{
				return false;
			}
			if (!Options.BehaviorOptions.EnableDataBinding)
			{
				return false;
			}
			if (xdataBinding_1.ProcessState == DCProcessStates.Never)
			{
				return false;
			}
			if (xdataBinding_1.IsEmptyBinding)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(xdataBinding_1.DataSource) && !GetParameterEnabled(xdataBinding_1.DataSource))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       获得参数是否有效
		///       </summary>
		/// <param name="parameterName">参数名</param>
		/// <returns>是否有效</returns>
		[ComVisible(true)]
		public bool GetParameterEnabled(string parameterName)
		{
			if (string.IsNullOrEmpty(parameterName))
			{
				return true;
			}
			if (list_2 != null)
			{
				foreach (string item in list_2)
				{
					if (string.Compare(item, parameterName, ignoreCase: true) == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		///       设置参数是否有效
		///       </summary>
		/// <param name="parameterName">参数名</param>
		/// <param name="enabled">是否有效</param>
		[ComVisible(true)]
		public void SetParameterEnabled(string parameterName, bool enabled)
		{
			if (GetParameterEnabled(parameterName) == enabled)
			{
				return;
			}
			if (!enabled)
			{
				if (list_2 == null)
				{
					list_2 = new List<string>();
				}
				list_2.Add(parameterName);
			}
			else
			{
				if (list_2 == null)
				{
					return;
				}
				for (int num = list_2.Count - 1; num >= 0; num--)
				{
					string strA = list_2[num];
					if (string.Compare(strA, parameterName, ignoreCase: true) == 0)
					{
						list_2.RemoveAt(num);
					}
				}
			}
		}

		/// <summary>
		///       获得系统当前日期事件
		///       </summary>
		/// <returns>日期事件</returns>
		[DCPublishAPI]
		public DateTime GetNowDateTime()
		{
			if (WriterControl != null)
			{
				return WriterControl.vmethod_2();
			}
			if (AppHost.DateTimeService == null)
			{
				return DateTime.Now;
			}
			return AppHost.DateTimeService.GetNow();
		}

		/// <summary>
		///       获得指定名称的参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>获得的参数值</returns>
		public object GetParameterValue(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			if (InnerParameters.Contains(name))
			{
				return InnerParameters.GetValue(name);
			}
			if (Parameters != null)
			{
				return Parameters.GetValue(name);
			}
			return null;
		}

		/// <summary>
		///       设置参数值
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <param name="newValue">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("请使用XTextDocument.SetDocumentParameterValue")]
		public bool SetParameterValue(string name, object newValue)
		{
			Parameters.SetValue(name, newValue);
			return true;
		}

		/// <summary>
		///       设置参数值
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <param name="newValue">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetDocumentParameterValue(string name, object newValue)
		{
			Parameters.SetValue(name, newValue);
			return true;
		}

		/// <summary>
		///       设置XML格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="xmlText">参数值</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SetDocumentParameterValueXml(string name, string xmlText)
		{
			Parameters.SetXmlValue(name, xmlText);
		}

		/// <summary>
		///       获得文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public object GetDocumnetParameterValue(string name)
		{
			return Parameters.GetValue(name);
		}

		/// <summary>
		///       获得Xml格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetDocumentParameterValueXml(string name)
		{
			return Parameters.GetXmlValue(name);
		}

		/// <summary>
		///       请改用WriteDataFromDataSourceToDocument()
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCInternal]
		public int UpdateViewForDataSource()
		{
			UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
			updateDataBindingArgs.FastMode = true;
			return UpdateDataBindingExt(updateDataBindingArgs);
		}

		internal string method_105(string string_26, bool bool_32)
		{
			if (string.IsNullOrEmpty(string_26))
			{
				return string_26;
			}
			int maxTextLengthForPaste = Options.BehaviorOptions.MaxTextLengthForPaste;
			if (maxTextLengthForPaste > 0)
			{
				if (!smethod_13(GEnum6.const_145))
				{
					return string_26;
				}
				if (string_26.Length >= maxTextLengthForPaste)
				{
					if (bool_32)
					{
						AppHost.UITools.ShowWarringMessageBox(EditorControl, string.Format(WriterStringsCore.PromptMaxTextLengthForPaste_Length, maxTextLengthForPaste));
					}
					return string_26;
				}
			}
			else if (maxTextLengthForPaste < 0)
			{
				int num = Math.Abs(maxTextLengthForPaste);
				if (string_26.Length > num)
				{
					string_26 = string_26.Substring(0, num);
					return string_26;
				}
			}
			return string_26;
		}

		internal void method_106(XTextElementList xtextElementList_5)
		{
			if (Options.BehaviorOptions.AutoClearTextFormatWhenPasteOrInsertContent)
			{
				int styleIndex = ContentStyles.GetStyleIndex(CurrentStyleInfo.Content);
				int styleIndex2 = ContentStyles.GetStyleIndex(CurrentStyleInfo.Paragraph);
				int styleIndex3 = ContentStyles.GetStyleIndex(CurrentStyleInfo.Cell);
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(xtextElementList_5);
				domTreeNodeEnumerable.ExcludeCharElement = false;
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item is XTextParagraphFlagElement)
					{
						item.StyleIndex = styleIndex2;
					}
					else if (item is XTextTableCellElement)
					{
						item.StyleIndex = styleIndex3;
					}
					else
					{
						item.StyleIndex = styleIndex;
					}
				}
			}
		}

		internal bool method_107(XTextElementList xtextElementList_5, bool bool_32)
		{
			if (xtextElementList_5 == null || xtextElementList_5.Count == 0)
			{
				return true;
			}
			int maxTextLengthForPaste = Options.BehaviorOptions.MaxTextLengthForPaste;
			if (maxTextLengthForPaste == 0)
			{
				return true;
			}
			int num = Math.Abs(maxTextLengthForPaste);
			int num2 = 0;
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextElement item in xtextElementList_5.method_2())
			{
				if (item is XTextCharElement)
				{
					num2++;
					if (num2 > num)
					{
						if (maxTextLengthForPaste > 0)
						{
							if (bool_32)
							{
								AppHost.UITools.ShowWarringMessageBox(EditorControl, string.Format(WriterStringsCore.PromptMaxTextLengthForPaste_Length, maxTextLengthForPaste));
							}
							return false;
						}
						xTextElementList.Add(item);
					}
				}
			}
			if (xTextElementList.Count > 0)
			{
				foreach (XTextElement item2 in xTextElementList)
				{
					if (xtextElementList_5.Contains(item2))
					{
						xtextElementList_5.Remove(item2);
					}
					else if (item2.Parent != null && item2.Parent.Elements.Contains(item2))
					{
						item2.Parent.Elements.Remove(item2);
					}
				}
			}
			return true;
		}

		/// <summary>
		///       追加子文档元素
		///       </summary>
		/// <param name="newSubDoc">子文档元素对象</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AppendSubDocument(XTextSubDocumentElement newSubDoc)
		{
			int num = 0;
			if (newSubDoc == null)
			{
				throw new ArgumentNullException("newSubDoc");
			}
			bool flag = false;
			int num2 = Body.Elements.Count - 1;
			while (num2 >= 0)
			{
				if (!(Body.Elements[num2] is XTextSubDocumentElement))
				{
					num2--;
					continue;
				}
				Body.Elements.method_13(num2 + 1, newSubDoc);
				flag = true;
				break;
			}
			if (!flag)
			{
				Body.Elements.method_13(0, newSubDoc);
			}
			newSubDoc.FixDomState();
			newSubDoc.EditorRefreshView();
			newSubDoc.SelectFirstLine();
			if (EditorControl != null)
			{
				EditorControl.ScrollToCaretExt(ScrollToViewStyle.Middle);
			}
		}

		/// <summary>
		///       在当前位置处插入子文档元素
		///       </summary>
		/// <param name="newSubDoc">要插入的子文档对象</param>
		/// <param name="insertUp">true:在上面插入；false:在下面插入</param>
		[ComVisible(true)]
		public void InsertSubDocuentAtCurrentPosition(XTextSubDocumentElement newSubDoc, bool insertUp)
		{
			int num = 15;
			if (newSubDoc == null)
			{
				throw new ArgumentNullException("newSubDoc");
			}
			int num2 = 0;
			XTextSubDocumentElement currentSubDocument = CurrentSubDocument;
			if (currentSubDocument != null)
			{
				num2 = Body.Elements.IndexOf(currentSubDocument);
				if (num2 < 0)
				{
					num2 = 0;
				}
			}
			if (insertUp)
			{
				Body.Elements.method_13(num2, newSubDoc);
			}
			else
			{
				Body.Elements.method_13(num2 + 1, newSubDoc);
			}
			newSubDoc.Parent = Body;
			newSubDoc.FixDomState();
			newSubDoc.EditorRefreshView();
			newSubDoc.SelectFirstLine();
			if (EditorControl != null)
			{
				EditorControl.ScrollToCaretExt(ScrollToViewStyle.Middle);
			}
		}

		/// <summary>
		///       修正文档元素中重复的ID号
		///       </summary>
		/// <param name="elements">文档元素列表</param>
		/// <returns>修改的ID的个数</returns>
		public int ValidateElementsIDRepeat(XTextElementList elements)
		{
			if (elements == null || elements.Count == 0)
			{
				return 0;
			}
			if (Options.BehaviorOptions.ValidateIDRepeatMode == DCValidateIDRepeatMode.None)
			{
				return 0;
			}
			int num = 0;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(elements);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (!string.IsNullOrEmpty(item.ID) && ValidateElementIDRepeat(item))
				{
					num++;
				}
			}
			return num;
		}

		/// <summary>
		///       对文档元素ID值进行重复性校验
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>校验是否通过</returns>
		public bool ValidateElementIDRepeat(XTextElement element)
		{
			int num = 16;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (element is XTextCharElement)
			{
				return true;
			}
			DCValidateIDRepeatMode validateIDRepeatMode = Options.BehaviorOptions.ValidateIDRepeatMode;
			if (validateIDRepeatMode == DCValidateIDRepeatMode.None)
			{
				return true;
			}
			string iD = element.ID;
			if (string.IsNullOrEmpty(iD))
			{
				return true;
			}
			XTextElement elementByIdExt = GetElementByIdExt(iD, idAttributeOnly: true);
			if (elementByIdExt != null && elementByIdExt != element)
			{
				switch (validateIDRepeatMode)
				{
				case DCValidateIDRepeatMode.AutoFix:
					iD = iD + "_" + int_14;
					int_14++;
					element.ID = iD;
					return true;
				case DCValidateIDRepeatMode.ThrowException:
				{
					string message = string.Format(WriterStringsCore.IDRepeat_ID, iD);
					throw new InvalidOperationException(message);
				}
				case DCValidateIDRepeatMode.DetectOnly:
					return false;
				}
			}
			return true;
		}

		[DCInternal]
		private void method_108(bool bool_32)
		{
			throw new NotSupportedException("EditorDelete");
		}

		/// <summary>
		///       设置文档元素自定义属性
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetElementProperty(string string_26, string name, string Value)
		{
			return GetElementById(string_26)?.SetAttribute(name, Value) ?? false;
		}

		/// <summary>
		///       获得文档元素的自定义属性值
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetElementProperty(string string_26, string name)
		{
			return GetElementById(string_26)?.GetAttribute(name);
		}

		/// <summary>
		///       为下拉列表元素添加下拉列表项目
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="text">项目的文本值</param>
		/// <param name="Value">项目的数值</param>
		/// <param name="saveToXml">添加的项目是否保存在XML中</param>
		[DCPublishAPI]
		public bool AddDropdownListItem(string string_26, string text, string Value, bool saveToXml)
		{
			XTextInputFieldElement xTextInputFieldElement = GetElementById(string_26) as XTextInputFieldElement;
			if (xTextInputFieldElement != null)
			{
				if (xTextInputFieldElement.FieldSettings == null)
				{
					xTextInputFieldElement.FieldSettings = new InputFieldSettings();
				}
				xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				if (xTextInputFieldElement.FieldSettings.ListSource == null)
				{
					xTextInputFieldElement.FieldSettings.ListSource = new ListSourceInfo();
				}
				if (saveToXml)
				{
					if (xTextInputFieldElement.FieldSettings.ListSource.Items == null)
					{
						xTextInputFieldElement.FieldSettings.ListSource.Items = new ListItemCollection();
					}
					xTextInputFieldElement.FieldSettings.ListSource.Items.AddByTextValue(text, Value);
				}
				else
				{
					if (xTextInputFieldElement.FieldSettings.ListSource.RuntimeItems == null)
					{
						xTextInputFieldElement.FieldSettings.ListSource.RuntimeItems = new ListItemCollection();
					}
					xTextInputFieldElement.FieldSettings.ListSource.RuntimeItems.AddByTextValue(text, Value);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       设置标记了自动隐藏的元素的可见性
		///       </summary>
		/// <param name="visible">可见性</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作修改的文档元素对象列表</returns>
		[ComVisible(true)]
		public XTextElementList SetVisibleForElementMarkAutoHide(bool visible, bool logUndo)
		{
			int num = 3;
			bool flag = CanLogUndo && logUndo;
			XTextElementList xTextElementList = new XTextElementList();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					if (xTextContainerElement.AutoHideMode != 0)
					{
						xTextElementList.Add(xTextContainerElement);
						domTreeNodeEnumerable.CancelChild();
					}
				}
			}
			XTextElementList xTextElementList2 = new XTextElementList();
			if (xTextElementList.Count > 0)
			{
				foreach (XTextContainerElement item2 in xTextElementList)
				{
					bool flag2 = false;
					if (item2.AutoHideMode == ContainerAutoHideMode.HideWhenChildFieldEmpty)
					{
						XTextElementList elementsByType = item2.GetElementsByType(typeof(XTextInputFieldElementBase));
						bool flag3 = false;
						foreach (XTextInputFieldElementBase item3 in elementsByType)
						{
							if (item3.Elements != null && item3.Elements.Count > 0)
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							flag2 = true;
						}
					}
					else if (item2.AutoHideMode == ContainerAutoHideMode.HideWhenEmpty && (item2.Elements == null || item2.Elements.Count == 0))
					{
						flag2 = true;
					}
					if (flag2 && item2.Visible != visible)
					{
						if (flag)
						{
							UndoList.AddProperty("Visible", item2.Visible, visible, item2);
						}
						item2.Visible = visible;
						xTextElementList2.Add(item2);
					}
				}
			}
			if (xTextElementList2.Count > 0)
			{
				if (flag)
				{
					UndoList.AddMethod(UndoMethodTypes.RefreshDocument);
				}
				Modified = true;
				if (EditorControl != null)
				{
					EditorControl.RefreshDocument();
				}
			}
			return xTextElementList2;
		}

		/// <summary>
		///       设置文档默认样式
		///       </summary>
		/// <param name="newStyle">新默认样式</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void EditorSetDefaultStyle(DocumentContentStyle newStyle, bool logUndo)
		{
			int num = 0;
			if (newStyle == null)
			{
				throw new ArgumentNullException("newStyle");
			}
			if (logUndo && BeginLogUndo())
			{
				UndoList.method_14(new XTextUndoSetDocumentProperty(this, "DefaultStyle", DefaultStyle.Clone(), newStyle));
				EndLogUndo();
			}
			ContentStyles.Default = newStyle;
			Modified = true;
			if (EditorControl != null)
			{
				EditorControl.RefreshDocument();
			}
		}

		internal XTextElementList method_109(Dictionary<XTextElement, int> dictionary_3, bool bool_32)
		{
			int num = 14;
			if (dictionary_3 == null)
			{
				throw new ArgumentNullException("newStyleIndexs");
			}
			XTextUndoSetElementStyle xTextUndoSetElementStyle = null;
			if (bool_32)
			{
				xTextUndoSetElementStyle = new XTextUndoSetElementStyle();
				xTextUndoSetElementStyle.Document = this;
				xTextUndoSetElementStyle.ParagraphStyle = true;
			}
			ContentStyles.Styles.SetValueLocked(vLock: false);
			List<XTextLine> list = new List<XTextLine>();
			Dictionary<XTextContentElement, XTextElementList> dictionary = new Dictionary<XTextContentElement, XTextElementList>();
			XTextElementList xTextElementList = new XTextElementList();
			XTextElementList xTextElementList2 = new XTextElementList();
			foreach (XTextParagraphFlagElement key in dictionary_3.Keys)
			{
				if (DocumentControler.CanModify(key))
				{
					XTextContentElement contentElement = key.ContentElement;
					xTextUndoSetElementStyle?.method_0(key, key.StyleIndex, dictionary_3[key]);
					_ = key.RuntimeStyle;
					key.StyleIndex = dictionary_3[key];
					key.AutoCreate = false;
					key.UpdateContentVersion();
					xTextElementList.Add(key);
					_ = key.RuntimeStyle;
					bool flag = true;
					if (!xTextElementList2.Contains(key.Parent))
					{
						xTextElementList2.Add(key.Parent);
					}
					if (!dictionary.ContainsKey(contentElement))
					{
						dictionary[contentElement] = new XTextElementList();
					}
					dictionary[contentElement].Add(key.FirstContentElement);
					dictionary[contentElement].Add(key);
					if (flag)
					{
						XTextLine ownerLine = key.FirstContentElement.OwnerLine;
						XTextLine ownerLine2 = key.OwnerLine;
						if (ownerLine != null && ownerLine2 != null)
						{
							int num2 = contentElement.PrivateLines.IndexOf(ownerLine2);
							for (int i = contentElement.PrivateLines.IndexOf(ownerLine); i <= num2; i++)
							{
								list.Add(contentElement.PrivateLines[i]);
								contentElement.PrivateLines[i].InvalidateState = true;
							}
						}
					}
				}
			}
			if (dictionary.Count > 0)
			{
				if (bool_32 && BeginLogUndo())
				{
					UndoList.method_14(xTextUndoSetElementStyle);
					EndLogUndo();
				}
				foreach (XTextContainerElement item in xTextElementList2)
				{
					for (XTextContainerElement xTextContainerElement2 = item; xTextContainerElement2 != null; xTextContainerElement2 = xTextContainerElement2.Parent)
					{
						xTextContainerElement2.Modified = true;
					}
				}
				Modified = true;
				CurrentStyleInfo.method_1(this);
				bool flag2 = false;
				XTextDocumentContentElement xTextDocumentContentElement = null;
				foreach (XTextContentElement key2 in dictionary.Keys)
				{
					if (xTextDocumentContentElement == null)
					{
						xTextDocumentContentElement = key2.DocumentContentElement;
						xTextDocumentContentElement.method_57(bool_23: false, bool_24: true);
					}
					key2.method_32(dictionary[key2], bool_22: true, bool_23: false);
					if (key2.DocumentContentElement == CurrentContentElement)
					{
						flag2 = true;
					}
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = this;
					contentChangedEventArgs.Element = key2;
					key2.method_23(contentChangedEventArgs);
				}
				if (EditorControl != null)
				{
					EditorControl.UpdateTextCaret();
				}
				if (flag2)
				{
					if (EditorControl != null)
					{
						EditorControl.InnerViewControl.Invalidate();
					}
					OnSelectionChanged();
				}
			}
			ContentStyles.Styles.SetValueLocked(vLock: true);
			return xTextElementList;
		}

		/// <summary>
		///       在编辑器中设置元素样式
		///       </summary>
		/// <param name="newStyleIndexs">新元素样式编号</param>
		/// <param name="logUndo">是否记录撤销信息</param>
		/// <param name="causeUpdateLayout">操作是否会导致重新排版</param>
		/// <param name="commandName">相关的命令对象</param>
		/// <returns>操作修改的元素列表</returns>
		[DCInternal]
		public XTextElementList EditorSetElementStyle(Dictionary<XTextElement, int> newStyleIndexs, bool logUndo, bool causeUpdateLayout, string commandName)
		{
			bool flag = commandName != "ContentProtect";
			foreach (XTextElement key in newStyleIndexs.Keys)
			{
				key.method_5(this);
				key.FixDomState();
			}
			ContentStyles.method_4();
			Dictionary<XTextContentElement, XTextElementList> dictionary = new Dictionary<XTextContentElement, XTextElementList>();
			XTextUndoSetElementStyle xTextUndoSetElementStyle = null;
			if (logUndo)
			{
				xTextUndoSetElementStyle = new XTextUndoSetElementStyle();
				xTextUndoSetElementStyle.Document = this;
				xTextUndoSetElementStyle.ParagraphStyle = false;
				xTextUndoSetElementStyle.CauseUpdateLayout = causeUpdateLayout;
				xTextUndoSetElementStyle.CommandName = commandName;
			}
			ContentStyles.Styles.SetValueLocked(vLock: false);
			XTextElementList xTextElementList = new XTextElementList();
			List<XTextContainerElement> list = new List<XTextContainerElement>();
			List<XTextTableElement> list2 = new List<XTextTableElement>();
			List<XTextContentElement> list3 = new List<XTextContentElement>();
			List<int> list4 = ContentStyles.method_7();
			DomAccessFlags domAccessFlags = DomAccessFlags.Normal;
			domAccessFlags = (DomAccessFlags)(flag ? ((int)(domAccessFlags | DomAccessFlags.CheckContentProtect)) : MathCommon.smethod_25((int)domAccessFlags, 64, bool_0: false));
			using (DCGraphics dcgraphics_ = CreateDCGraphics())
			{
				foreach (XTextElement key2 in newStyleIndexs.Keys)
				{
					if ((WriterUtils.smethod_19(commandName) && Options.BehaviorOptions.PowerfulCommentCommand) || DocumentControler.CanModify(key2, domAccessFlags))
					{
						XTextContentElement contentElement = key2.ContentElement;
						xTextUndoSetElementStyle?.method_0(key2, key2.StyleIndex, newStyleIndexs[key2]);
						if (key2 is XTextParagraphFlagElement)
						{
							XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)key2;
							xTextParagraphFlagElement.AutoCreate = false;
							xTextParagraphFlagElement.UpdateContentVersion();
							if (causeUpdateLayout && contentElement != null)
							{
								XTextLine ownerLine = xTextParagraphFlagElement.FirstContentElement.OwnerLine;
								XTextLine ownerLine2 = xTextParagraphFlagElement.OwnerLine;
								if (ownerLine != null && ownerLine2 != null)
								{
									int num = contentElement.PrivateLines.IndexOf(ownerLine2);
									int i = contentElement.PrivateLines.IndexOf(ownerLine);
									if (i >= 0)
									{
										for (; i <= num; i++)
										{
											contentElement.PrivateLines[i].InvalidateState = true;
										}
									}
								}
							}
							if (contentElement != null && !list3.Contains(contentElement))
							{
								list3.Add(contentElement);
							}
						}
						if (list4 != null && (list4.Contains(key2.StyleIndex) || list4.Contains(newStyleIndexs[key2])))
						{
							bool_22 = true;
						}
						key2.StyleIndex = newStyleIndexs[key2];
						if (!list.Contains(key2.Parent))
						{
							XTextContainerElement parent = key2.Parent;
							list.Add(parent);
							parent.method_5(this);
							parent.FixDomState();
						}
						key2.vmethod_4();
						key2.UpdateContentVersion();
						if (causeUpdateLayout && contentElement != null)
						{
							if (key2 is XTextContentElement)
							{
								XTextContentElement xTextContentElement = (XTextContentElement)key2;
								xTextContentElement.vmethod_41(contentElement.ContentVertialAlign, bool_22: false, bool_23: false);
							}
							key2.SizeInvalid = true;
						}
						xTextElementList.Add(key2);
						if (contentElement != null && contentElement.PrivateContent.Contains(key2.FirstContentElement))
						{
							if (dictionary.ContainsKey(contentElement))
							{
								dictionary[contentElement].Add(key2.FirstContentElement);
							}
							else
							{
								XTextElementList xTextElementList2 = new XTextElementList();
								xTextElementList2.Add(key2.FirstContentElement);
								dictionary[contentElement] = xTextElementList2;
							}
						}
						if (causeUpdateLayout)
						{
							DocumentPaintEventArgs documentPaintEventArgs = method_55(dcgraphics_);
							documentPaintEventArgs.RenderMode = DocumentRenderMode.Paint;
							documentPaintEventArgs.Element = key2;
							key2.RefreshSize(documentPaintEventArgs);
						}
						if (key2 is XTextContentElement)
						{
							if (key2 is XTextTableCellElement)
							{
								XTextTableElement ownerTable = ((XTextTableCellElement)key2).OwnerTable;
								if (!list2.Contains(ownerTable))
								{
									list2.Add(ownerTable);
								}
							}
							else if (causeUpdateLayout)
							{
								XTextContentElement xTextContentElement = (XTextContentElement)key2;
								xTextContentElement.vmethod_42(new Class121(null, null, xTextContentElement.ContentVertialAlign));
							}
						}
						if (causeUpdateLayout)
						{
							if (key2 is XTextObjectElement)
							{
								((XTextObjectElement)key2).vmethod_23();
							}
							else if (key2 is XTextShapeInputFieldElement)
							{
								((XTextShapeInputFieldElement)key2).vmethod_47();
							}
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (XTextTableElement item in list2)
				{
					item.InvalidateView();
					if (causeUpdateLayout)
					{
						item.ExecuteLayout();
						item.InvalidateView();
					}
					XTextElementList xTextElementList3 = new XTextElementList();
					xTextElementList3.Add(item);
					dictionary[item.ContentElement] = xTextElementList3;
				}
			}
			if (list3.Count > 0)
			{
				XTextDocumentContentElement documentContentElement = list3[0].DocumentContentElement;
				documentContentElement.method_57(bool_23: false, bool_24: true);
			}
			if (dictionary.Count > 0)
			{
				if (logUndo)
				{
					if (CanLogUndo)
					{
						UndoList.method_14(xTextUndoSetElementStyle);
					}
					else if (BeginLogUndo())
					{
						UndoList.method_14(xTextUndoSetElementStyle);
						EndLogUndo();
					}
				}
				Modified = true;
				bool flag2 = false;
				if (causeUpdateLayout)
				{
					foreach (XTextContentElement key3 in dictionary.Keys)
					{
						if (key3.BelongToDocumentDom(key3.OwnerDocument, checkLogicDelete: false))
						{
							key3.method_32(dictionary[key3], bool_22: true, bool_23: true);
							if (key3.bool_19)
							{
								flag2 = true;
							}
						}
					}
				}
				if (list.Count > 0)
				{
					foreach (XTextContainerElement item2 in list)
					{
						if (item2.BelongToDocumentDom(item2.OwnerDocument, checkLogicDelete: false))
						{
							for (XTextContainerElement xTextContainerElement = item2; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.Parent)
							{
								xTextContainerElement.Modified = true;
							}
							ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
							contentChangedEventArgs.Document = this;
							contentChangedEventArgs.Element = item2;
							contentChangedEventArgs.OnlyStyleChanged = true;
							item2.method_23(contentChangedEventArgs);
						}
					}
				}
				OnDocumentContentChanged();
				if (flag2)
				{
					PageRefreshed = false;
					RefreshPages();
					if (EditorControl != null)
					{
						EditorControl.UpdatePages();
						EditorControl.UpdateTextCaret();
						EditorControl.InnerViewControl.Invalidate();
					}
				}
				else if (EditorControl != null)
				{
					EditorControl.UpdateTextCaret();
					EditorControl.InnerViewControl.Invalidate();
				}
				OnSelectionChanged();
			}
			ContentStyles.Styles.SetValueLocked(vLock: true);
			return xTextElementList;
		}

		[ComVisible(false)]
		[DCInternal]
		public void method_110()
		{
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Elements);
			domTreeNodeEnumerable.ExcludeCharElement = false;
			domTreeNodeEnumerable.ExcludeParagraphFlag = false;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				item.method_8(bool_5: false);
			}
		}

		/// <summary>
		///       创建文档样式对象
		///       </summary>
		/// <returns>创建的对象</returns>
		[DCPublishAPI]
		public DocumentContentStyle CreateDocumentContentStyle()
		{
			return new DocumentContentStyle();
		}

		[DCInternal]
		public void method_111()
		{
			int num = 6;
			bool flag = false;
			RepeatedImages.method_1(this);
			ContentStyles.Styles.SetValueLocked(vLock: false);
			List<int> list = new List<int>();
			foreach (DocumentContentStyle style in ContentStyles.Styles)
			{
				if (style.CommentIndex >= 0)
				{
					list.Add(style.CommentIndex);
				}
			}
			if (Comments != null && Comments.Count > 0)
			{
				for (int num2 = Comments.Count - 1; num2 >= 0; num2--)
				{
					if (!list.Contains(Comments[num2].Index))
					{
						Comments.RemoveAt(num2);
						flag = true;
					}
				}
			}
			foreach (DocumentContentStyle style2 in ContentStyles.Styles)
			{
				int commentIndex = style2.CommentIndex;
				if (commentIndex >= 0 && (Comments == null || Comments.GetByCommentIndex(commentIndex) == null))
				{
					style2.CommentIndex = -1;
					flag = true;
				}
			}
			ContentStyleList styles = ContentStyles.Styles;
			int count = styles.Count;
			int[] array = new int[count];
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			domTreeNodeEnumerable.ExcludeCharElement = false;
			domTreeNodeEnumerable.ExcludeParagraphFlag = false;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				int styleIndex = item.StyleIndex;
				if (styleIndex >= 0 && styleIndex < count)
				{
					array[styleIndex]++;
				}
			}
			for (int i = 0; i < count; i++)
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)styles[i];
				if (array[i] == 0)
				{
					flag = true;
				}
				else if (XDependencyObject.smethod_0(documentContentStyle) == 0)
				{
					flag = true;
					array[i] = 0;
				}
			}
			if (flag)
			{
				ContentStyles.method_1();
				DocumentContentStyle documentContentStyle2 = new DocumentContentStyle();
				documentContentStyle2.FontName = "嘿嘿，袁永福到此一游";
				int num3 = 0;
				for (int num2 = 0; num2 < count; num2++)
				{
					if (array[num2] == 0)
					{
						array[num2] = -1;
					}
				}
				for (int num2 = 0; num2 < count; num2++)
				{
					if (array[num2] == -1)
					{
						num3++;
						array[num2] = -1;
						styles[num2].Dispose();
						styles[num2] = documentContentStyle2;
						continue;
					}
					if (styles[num2] == documentContentStyle2)
					{
						num3++;
						continue;
					}
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)styles[num2];
					if (documentContentStyle == documentContentStyle2)
					{
						continue;
					}
					array[num2] = num2 - num3;
					for (int j = num2 + 1; j < count; j++)
					{
						if (styles[j] != documentContentStyle2 && documentContentStyle.method_4(styles[j]))
						{
							array[j] = array[num2];
							styles[j].Dispose();
							styles[j] = documentContentStyle2;
						}
					}
				}
				DomTreeNodeEnumerable domTreeNodeEnumerable2 = new DomTreeNodeEnumerable(this);
				domTreeNodeEnumerable2.ExcludeParagraphFlag = false;
				domTreeNodeEnumerable2.ExcludeCharElement = false;
				foreach (XTextElement item2 in domTreeNodeEnumerable2)
				{
					int styleIndex = item2.StyleIndex;
					if (styleIndex >= 0 && styleIndex < count)
					{
						item2.StyleIndex = array[styleIndex];
						if (item2 is XTextFieldElementBase)
						{
							((XTextFieldElementBase)item2).method_26();
						}
					}
					else
					{
						item2.StyleIndex = -1;
					}
				}
				for (int num2 = styles.Count - 1; num2 >= 0; num2--)
				{
					if (styles[num2] == documentContentStyle2)
					{
						styles.RemoveAt(num2);
					}
				}
				if (Comments != null && Comments.Count > 0)
				{
					for (int num2 = Comments.Count - 1; num2 >= 0; num2--)
					{
						int index = Comments[num2].Index;
						bool flag2 = false;
						foreach (DocumentContentStyle style3 in ContentStyles.Styles)
						{
							if (style3.CommentIndex == index)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							Comments.RemoveAt(num2);
							flag = true;
						}
					}
				}
				DocumentCommentList comments = Comments;
				if (comments != null && comments.Count > 0)
				{
					foreach (DocumentContentStyle style4 in ContentStyles.Styles)
					{
						int commentIndex = style4.CommentIndex;
						for (int num2 = 0; num2 < comments.Count; num2++)
						{
							if (comments[num2].Index == commentIndex)
							{
								style4.CommentIndex = num2;
							}
						}
					}
					for (int num2 = 0; num2 < comments.Count; num2++)
					{
						comments[num2].Index = num2;
					}
				}
				using (DCGraphics dcgraphics_ = CreateDCGraphics())
				{
					foreach (DocumentContentStyle item3 in styles)
					{
						item3.method_32(dcgraphics_);
					}
					((DocumentContentStyle)ContentStyles.Default).method_32(dcgraphics_);
				}
				ContentStyles.vmethod_0();
			}
			method_76();
		}

		/// <summary>
		///       获得指定元素所在段落的样式
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>段落样式对象</returns>
		public RuntimeDocumentContentStyle GetParagraphStyle(XTextElement element)
		{
			if (element == null)
			{
				return ((DocumentContentStyle)ContentStyles.Default).MyRuntimeStyle;
			}
			XTextParagraphFlagElement xTextParagraphFlagElement = method_77(element);
			if (xTextParagraphFlagElement == null)
			{
				return ((DocumentContentStyle)ContentStyles.Default).MyRuntimeStyle;
			}
			return xTextParagraphFlagElement.RuntimeStyle;
		}

		/// <summary>
		///       获得样式在列表中的编号。
		///       </summary>
		/// <param name="styleString">样式字符串，比如“FontName:宋体;FontSize:9”</param>
		/// <returns>编号</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public int GetStyleIndexByString(string styleString)
		{
			return ContentStyles.GetStyleIndexByString(styleString);
		}

		/// <summary>
		///       设置默认字体
		///       </summary>
		/// <param name="font">默认字体</param>
		/// <param name="raiseEvent">若修改了文档设置则是否触发事件</param>
		/// <returns>对视图的影响</returns>
		[DCPublishAPI]
		public ContentEffects SetDefaultFont(XFontValue font, bool raiseEvent)
		{
			return SetDefaultFont(font, ContentStyles.Default.Color, raiseEvent);
		}

		/// <summary>
		///       设置默认字体
		///       </summary>
		/// <param name="font">默认字体</param>
		/// <param name="color">默认文本颜色</param>
		/// <param name="raiseEvent">若修改了文档设置则是否触发事件</param>
		/// <returns>对视图的影响</returns>
		public ContentEffects SetDefaultFont(XFontValue font, Color color, bool raiseEvent)
		{
			bool flag = !ContentStyles.Default.Font.method_5(font);
			bool flag2 = ContentStyles.Default.Color != color;
			if (flag)
			{
				ContentStyles.Default.Font = font.Clone();
				foreach (DocumentContentStyle style in ContentStyles.Styles)
				{
					if (style.Font.method_5(font))
					{
						style.Font = font;
					}
				}
				ContentStyles.method_1();
			}
			if (flag2)
			{
				ContentStyles.Default.Color = color;
				ContentStyles.method_1();
			}
			if ((flag || flag2) && raiseEvent && Body.Elements.Count > 0)
			{
				OnDocumentContentChanged();
				OnSelectionChanged();
			}
			if (flag)
			{
				return ContentEffects.Layout;
			}
			if (flag2)
			{
				return ContentEffects.Display;
			}
			return ContentEffects.None;
		}

		private static GEnum13 smethod_0(GEnum6 genum6_0)
		{
			if (genum13_0 == null)
			{
				genum13_0 = new GEnum13[223];
				genum13_0[1] = GEnum13.const_0;
				genum13_0[2] = GEnum13.const_2;
				genum13_0[3] = GEnum13.const_1;
				genum13_0[4] = GEnum13.const_1;
				genum13_0[5] = GEnum13.const_0;
				genum13_0[6] = GEnum13.const_2;
				genum13_0[7] = GEnum13.const_1;
				genum13_0[8] = GEnum13.const_2;
				genum13_0[9] = GEnum13.const_2;
				genum13_0[10] = GEnum13.const_1;
				genum13_0[11] = GEnum13.const_1;
				genum13_0[12] = GEnum13.const_1;
				genum13_0[13] = GEnum13.const_2;
				genum13_0[14] = GEnum13.const_1;
				genum13_0[15] = GEnum13.const_1;
				genum13_0[16] = GEnum13.const_2;
				genum13_0[17] = GEnum13.const_0;
				genum13_0[18] = GEnum13.const_0;
				genum13_0[19] = GEnum13.const_0;
				genum13_0[20] = GEnum13.const_0;
				genum13_0[21] = GEnum13.const_1;
				genum13_0[22] = GEnum13.const_1;
				genum13_0[23] = GEnum13.const_2;
				genum13_0[24] = GEnum13.const_2;
				genum13_0[25] = GEnum13.const_1;
				genum13_0[26] = GEnum13.const_2;
				genum13_0[27] = GEnum13.const_2;
				genum13_0[28] = GEnum13.const_1;
				genum13_0[29] = GEnum13.const_2;
				genum13_0[30] = GEnum13.const_2;
				genum13_0[31] = GEnum13.const_1;
				genum13_0[32] = GEnum13.const_2;
				genum13_0[33] = GEnum13.const_1;
				genum13_0[34] = GEnum13.const_1;
				genum13_0[35] = GEnum13.const_1;
				genum13_0[36] = GEnum13.const_0;
				genum13_0[37] = GEnum13.const_0;
				genum13_0[38] = GEnum13.const_1;
				genum13_0[39] = GEnum13.const_1;
				genum13_0[40] = GEnum13.const_1;
				genum13_0[41] = GEnum13.const_0;
				genum13_0[42] = GEnum13.const_0;
				genum13_0[43] = GEnum13.const_2;
				genum13_0[44] = GEnum13.const_2;
				genum13_0[45] = GEnum13.const_1;
				genum13_0[46] = GEnum13.const_2;
				genum13_0[47] = GEnum13.const_0;
				genum13_0[48] = GEnum13.const_1;
				genum13_0[49] = GEnum13.const_1;
				genum13_0[50] = GEnum13.const_0;
				genum13_0[51] = GEnum13.const_0;
				genum13_0[52] = GEnum13.const_0;
				genum13_0[53] = GEnum13.const_0;
				genum13_0[54] = GEnum13.const_1;
				genum13_0[55] = GEnum13.const_0;
				genum13_0[56] = GEnum13.const_0;
				genum13_0[57] = GEnum13.const_1;
				genum13_0[58] = GEnum13.const_1;
				genum13_0[59] = GEnum13.const_0;
				genum13_0[60] = GEnum13.const_0;
				genum13_0[61] = GEnum13.const_0;
				genum13_0[62] = GEnum13.const_1;
				genum13_0[63] = GEnum13.const_1;
				genum13_0[64] = GEnum13.const_0;
				genum13_0[65] = GEnum13.const_2;
				genum13_0[66] = GEnum13.const_2;
				genum13_0[67] = GEnum13.const_2;
				genum13_0[68] = GEnum13.const_0;
				genum13_0[69] = GEnum13.const_0;
				genum13_0[70] = GEnum13.const_1;
				genum13_0[71] = GEnum13.const_1;
				genum13_0[72] = GEnum13.const_1;
				genum13_0[73] = GEnum13.const_1;
				genum13_0[74] = GEnum13.const_1;
				genum13_0[75] = GEnum13.const_1;
				genum13_0[76] = GEnum13.const_2;
				genum13_0[77] = GEnum13.const_0;
				genum13_0[78] = GEnum13.const_1;
				genum13_0[79] = GEnum13.const_1;
				genum13_0[80] = GEnum13.const_0;
				genum13_0[81] = GEnum13.const_0;
				genum13_0[82] = GEnum13.const_1;
				genum13_0[83] = GEnum13.const_1;
				genum13_0[84] = GEnum13.const_2;
				genum13_0[85] = GEnum13.const_1;
				genum13_0[86] = GEnum13.const_1;
				genum13_0[87] = GEnum13.const_2;
				genum13_0[88] = GEnum13.const_0;
				genum13_0[89] = GEnum13.const_0;
				genum13_0[90] = GEnum13.const_0;
				genum13_0[91] = GEnum13.const_0;
				genum13_0[92] = GEnum13.const_2;
				genum13_0[93] = GEnum13.const_2;
				genum13_0[94] = GEnum13.const_2;
				genum13_0[95] = GEnum13.const_2;
				genum13_0[96] = GEnum13.const_1;
				genum13_0[97] = GEnum13.const_1;
				genum13_0[98] = GEnum13.const_0;
				genum13_0[99] = GEnum13.const_1;
				genum13_0[100] = GEnum13.const_1;
				genum13_0[101] = GEnum13.const_0;
				genum13_0[102] = GEnum13.const_1;
				genum13_0[103] = GEnum13.const_1;
				genum13_0[104] = GEnum13.const_1;
				genum13_0[105] = GEnum13.const_1;
				genum13_0[106] = GEnum13.const_1;
				genum13_0[107] = GEnum13.const_2;
				genum13_0[108] = GEnum13.const_2;
				genum13_0[109] = GEnum13.const_1;
				genum13_0[110] = GEnum13.const_1;
				genum13_0[111] = GEnum13.const_2;
				genum13_0[112] = GEnum13.const_1;
				genum13_0[113] = GEnum13.const_2;
				genum13_0[114] = GEnum13.const_1;
				genum13_0[115] = GEnum13.const_0;
				genum13_0[116] = GEnum13.const_1;
				genum13_0[117] = GEnum13.const_0;
				genum13_0[118] = GEnum13.const_0;
				genum13_0[119] = GEnum13.const_1;
				genum13_0[120] = GEnum13.const_1;
				genum13_0[121] = GEnum13.const_2;
				genum13_0[122] = GEnum13.const_1;
				genum13_0[123] = GEnum13.const_1;
				genum13_0[124] = GEnum13.const_2;
				genum13_0[125] = GEnum13.const_1;
				genum13_0[126] = GEnum13.const_2;
				genum13_0[127] = GEnum13.const_0;
				genum13_0[128] = GEnum13.const_0;
				genum13_0[129] = GEnum13.const_1;
				genum13_0[130] = GEnum13.const_1;
				genum13_0[131] = GEnum13.const_1;
				genum13_0[132] = GEnum13.const_1;
				genum13_0[133] = GEnum13.const_0;
				genum13_0[134] = GEnum13.const_1;
				genum13_0[135] = GEnum13.const_2;
				genum13_0[136] = GEnum13.const_0;
				genum13_0[137] = GEnum13.const_1;
				genum13_0[138] = GEnum13.const_1;
				genum13_0[139] = GEnum13.const_0;
				genum13_0[140] = GEnum13.const_0;
				genum13_0[141] = GEnum13.const_1;
				genum13_0[142] = GEnum13.const_0;
				genum13_0[143] = GEnum13.const_1;
				genum13_0[144] = GEnum13.const_1;
				genum13_0[145] = GEnum13.const_2;
				genum13_0[146] = GEnum13.const_1;
				genum13_0[147] = GEnum13.const_1;
				genum13_0[148] = GEnum13.const_1;
				genum13_0[149] = GEnum13.const_1;
				genum13_0[150] = GEnum13.const_1;
				genum13_0[151] = GEnum13.const_2;
				genum13_0[152] = GEnum13.const_2;
				genum13_0[153] = GEnum13.const_1;
				genum13_0[154] = GEnum13.const_1;
				genum13_0[155] = GEnum13.const_2;
				genum13_0[156] = GEnum13.const_1;
				genum13_0[157] = GEnum13.const_1;
				genum13_0[158] = GEnum13.const_1;
				genum13_0[159] = GEnum13.const_1;
				genum13_0[160] = GEnum13.const_1;
				genum13_0[161] = GEnum13.const_1;
				genum13_0[162] = GEnum13.const_1;
				genum13_0[163] = GEnum13.const_0;
				genum13_0[164] = GEnum13.const_1;
				genum13_0[165] = GEnum13.const_1;
				genum13_0[166] = GEnum13.const_2;
				genum13_0[167] = GEnum13.const_2;
				genum13_0[168] = GEnum13.const_0;
				genum13_0[169] = GEnum13.const_1;
				genum13_0[170] = GEnum13.const_0;
				genum13_0[171] = GEnum13.const_0;
				genum13_0[172] = GEnum13.const_0;
				genum13_0[173] = GEnum13.const_1;
				genum13_0[174] = GEnum13.const_1;
				genum13_0[175] = GEnum13.const_1;
				genum13_0[176] = GEnum13.const_1;
				genum13_0[177] = GEnum13.const_0;
				genum13_0[178] = GEnum13.const_2;
				genum13_0[179] = GEnum13.const_1;
				genum13_0[180] = GEnum13.const_1;
				genum13_0[181] = GEnum13.const_1;
				genum13_0[182] = GEnum13.const_2;
				genum13_0[183] = GEnum13.const_1;
				genum13_0[184] = GEnum13.const_1;
				genum13_0[185] = GEnum13.const_1;
				genum13_0[186] = GEnum13.const_0;
				genum13_0[187] = GEnum13.const_1;
				genum13_0[188] = GEnum13.const_1;
				genum13_0[189] = GEnum13.const_2;
				genum13_0[190] = GEnum13.const_2;
				genum13_0[191] = GEnum13.const_2;
				genum13_0[192] = GEnum13.const_1;
				genum13_0[193] = GEnum13.const_2;
				genum13_0[194] = GEnum13.const_1;
				genum13_0[195] = GEnum13.const_1;
				genum13_0[196] = GEnum13.const_1;
				genum13_0[197] = GEnum13.const_1;
				genum13_0[198] = GEnum13.const_0;
				genum13_0[199] = GEnum13.const_1;
				genum13_0[200] = GEnum13.const_1;
				genum13_0[201] = GEnum13.const_2;
				genum13_0[202] = GEnum13.const_1;
				genum13_0[203] = GEnum13.const_1;
				genum13_0[204] = GEnum13.const_1;
				genum13_0[205] = GEnum13.const_0;
				genum13_0[206] = GEnum13.const_1;
				genum13_0[207] = GEnum13.const_1;
				genum13_0[208] = GEnum13.const_1;
				genum13_0[209] = GEnum13.const_2;
				genum13_0[210] = GEnum13.const_2;
				genum13_0[211] = GEnum13.const_2;
				genum13_0[212] = GEnum13.const_1;
				genum13_0[213] = GEnum13.const_1;
				genum13_0[214] = GEnum13.const_1;
				genum13_0[215] = GEnum13.const_1;
				genum13_0[216] = GEnum13.const_2;
				genum13_0[217] = GEnum13.const_2;
				genum13_0[218] = GEnum13.const_1;
				genum13_0[219] = GEnum13.const_1;
				genum13_0[220] = GEnum13.const_2;
				genum13_0[221] = GEnum13.const_0;
				genum13_0[222] = GEnum13.const_2;
			}
			if (genum6_0 >= GEnum6.const_0 && (int)genum6_0 < genum13_0.Length)
			{
				return genum13_0[(int)genum6_0];
			}
			return GEnum13.const_0;
		}

		private GEnum25 method_112()
		{
			int num = 268435455;
			if (!smethod_13(GEnum6.const_22))
			{
				num &= -32769;
			}
			if (!smethod_13(GEnum6.const_23))
			{
				num &= -65537;
			}
			if (!smethod_13(GEnum6.const_24))
			{
				num &= -2049;
			}
			if (!smethod_13(GEnum6.const_25))
			{
				num &= -4097;
			}
			if (!smethod_13(GEnum6.const_26))
			{
				num &= -8193;
			}
			if (!smethod_13(GEnum6.const_27))
			{
				num &= -16385;
			}
			if (!smethod_13(GEnum6.const_28))
			{
				num &= -257;
			}
			if (!smethod_13(GEnum6.const_29))
			{
				num &= -131073;
			}
			if (!smethod_13(GEnum6.const_30))
			{
				num &= -1025;
			}
			if (!smethod_13(GEnum6.const_31))
			{
				num &= -3;
			}
			if (!smethod_13(GEnum6.const_32))
			{
				num &= -33;
			}
			if (!smethod_13(GEnum6.const_33))
			{
				num &= -9;
			}
			if (!smethod_13(GEnum6.const_34))
			{
				num &= -17;
			}
			if (!smethod_13(GEnum6.const_35))
			{
				num &= -129;
			}
			return (GEnum25)num;
		}

		public static bool smethod_1(Control control_0)
		{
			return false;
		}

		[DCInternal]
		public static void smethod_2(bool bool_32)
		{
			bool_27 = bool_32;
		}

		private void method_113()
		{
			int num = 8;
			GClass138 gClass = Class103.smethod_4();
			if (gClass.method_34())
			{
				Info.LicenseText = gClass.method_33() + ":" + gClass.method_50();
			}
			else
			{
				Info.LicenseText = WriterStringsCore.UnRegisterTitle;
			}
		}

		public static string StaticGetRegisterCode()
		{
			return _RegisterCode;
		}

		[DCInternal]
		public static void CheckSpecifyLic(Control control_0, int appID)
		{
			int num = 8;
			Class18.smethod_0();
			if (control_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (control_0.IsDisposed)
			{
				throw new ObjectDisposedException("ctl");
			}
			if (Environment.UserInteractive)
			{
				if (timer_0 == null)
				{
					timer_0 = new System.Windows.Forms.Timer();
					timer_0.Interval = 30000;
					timer_0.Tick += smethod_3;
					timer_0.Tag = new ArrayList();
					timer_0.Start();
				}
				((ArrayList)timer_0.Tag).Add(control_0);
				((ArrayList)timer_0.Tag).Add(appID);
			}
		}

		private static void smethod_3(object sender, EventArgs e)
		{
			if (timer_0 == null)
			{
				return;
			}
			ArrayList arrayList = (ArrayList)timer_0.Tag;
			for (int num = arrayList.Count - 2; num >= 0; num -= 2)
			{
				Control control = (Control)arrayList[num];
				int int_ = (int)arrayList[num + 1];
				if (control.IsDisposed)
				{
					arrayList.RemoveAt(num);
					arrayList.RemoveAt(num);
				}
				else if (control.IsHandleCreated)
				{
					GClass472 gClass = smethod_5(bool_32: false, int_);
					if (!gClass.method_6() || gClass.method_4())
					{
						string s = gClass.method_8();
						IntPtr intPtr = Marshal.StringToBSTR(s);
						if (control.IsHandleCreated)
						{
							GClass251 gClass2 = new GClass251(control.Handle);
							gClass2.method_5(1134, (uint)intPtr.ToInt32(), 0u);
							break;
						}
					}
				}
			}
			if (arrayList.Count == 0 && timer_0 != null)
			{
				timer_0.Stop();
				timer_0.Dispose();
				timer_0 = null;
			}
		}

		private static void smethod_4(Control control_0, string string_26)
		{
			bool_28 = true;
			try
			{
				MessageBox.Show(control_0, string_26, WriterStringsCore.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				bool_28 = false;
			}
		}

		[DCInternal]
		public static GClass472 smethod_5(bool bool_32, int int_18)
		{
			return smethod_7(bool_32, int_18);
		}

		[DCInternal]
		public static GClass472 smethod_6(bool bool_32)
		{
			return smethod_7(bool_32, -1);
		}

		internal static GClass472 smethod_7(bool bool_32, int int_18)
		{
			int num = 0;
			GClass472 gClass = new GClass472();
			GClass138 gClass2 = Class103.smethod_4();
			if (int_18 >= 0)
			{
				gClass2 = Class103.smethod_3(null, int_18);
			}
			if (gClass2.method_34())
			{
				gClass.method_9(gClass2.method_50());
				gClass.method_23(gClass2.method_24());
				if (bool_32 && !string.IsNullOrEmpty(gClass2.method_16()))
				{
					gClass.method_9(gClass.method_8() + " " + gClass2.method_16());
				}
				gClass.method_7(bool_7: true);
				if (gClass2.method_38())
				{
					string str = "[试用版]";
					gClass.method_5(bool_7: true);
					gClass.method_9(gClass.method_8() + str);
				}
			}
			else
			{
				gClass.method_7(bool_7: false);
				string string_ = "【未注册，请联系“南京都昌信息科技有限公司”进行注册】";
				gClass.method_9(string_);
				gClass.method_13(15f);
				gClass.method_17(Color.Red);
				gClass.method_15(bool_7: true);
			}
			return gClass;
		}

		[DCInternal]
		public static bool smethod_8(Control control_0, GEnum6 genum6_0, string string_26)
		{
			int num = 6;
			if (!smethod_13(genum6_0))
			{
				string text = LimitedFunctionString + ":" + string_26;
				if (!Environment.UserInteractive)
				{
					Console.WriteLine(text);
					Thread.Sleep(2000);
					return false;
				}
				if (control_0 == null)
				{
					MessageBox.Show(null, text, WriterStringsCore.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Delegate1 method = smethod_9;
					control_0.BeginInvoke(method, control_0, text);
				}
				return false;
			}
			return true;
		}

		private static void smethod_9(Control control_0, string string_26)
		{
			MessageBox.Show(control_0, string_26, WriterStringsCore.CoreSystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		[DCInternal]
		public bool method_114(XTextElement xtextElement_3, DocumentPaintEventArgs documentPaintEventArgs_0, GEnum6 genum6_0)
		{
			return smethod_10(xtextElement_3, documentPaintEventArgs_0, genum6_0);
		}

		[DCInternal]
		public static bool smethod_10(XTextElement xtextElement_3, DocumentPaintEventArgs documentPaintEventArgs_0, GEnum6 genum6_0)
		{
			int num = 18;
			if (documentPaintEventArgs_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (!smethod_13(genum6_0))
			{
				RectangleF rectangleF_ = xtextElement_3.AbsBounds;
				if (rectangleF_.IsEmpty)
				{
					rectangleF_ = documentPaintEventArgs_0.ViewBounds;
				}
				smethod_11(documentPaintEventArgs_0.Graphics, rectangleF_);
				return true;
			}
			return false;
		}

		public static void smethod_11(DCGraphics dcgraphics_0, RectangleF rectangleF_1)
		{
			int num = 16;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			if (!(rectangleF_1.Width <= 0f) && !(rectangleF_1.Height <= 0f))
			{
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoClip;
					string limitedFunctionString = LimitedFunctionString;
					XFontValue font = new XFontValue();
					SizeF sizeF = dcgraphics_0.MeasureString(limitedFunctionString, font, (int)rectangleF_1.Width, drawStringFormatExt);
					if (sizeF.Height * 3f > rectangleF_1.Height)
					{
						dcgraphics_0.FillRectangle(rect: new RectangleF(rectangleF_1.Left + (rectangleF_1.Width - sizeF.Width) / 2f, rectangleF_1.Top + (rectangleF_1.Height - sizeF.Height) / 2f - 4f, sizeF.Width, sizeF.Height + 4f), color_0: Color.White);
						dcgraphics_0.DrawString(limitedFunctionString, font, Color.Red, rectangleF_1, drawStringFormatExt);
					}
					else
					{
						for (float num2 = rectangleF_1.Top; num2 < rectangleF_1.Bottom; num2 += sizeF.Height * 3f)
						{
							RectangleF rect2 = new RectangleF(rectangleF_1.Left + (rectangleF_1.Width - sizeF.Width) / 2f, num2 + sizeF.Height, sizeF.Width, sizeF.Height + 4f);
							dcgraphics_0.FillRectangle(Color.White, rect2);
							dcgraphics_0.DrawString(limitedFunctionString, font, Color.Red, rect2, drawStringFormatExt);
						}
					}
				}
			}
		}

		private static void smethod_12(Bitmap bitmap_0)
		{
			int num = 12;
			if (bitmap_0 == null)
			{
				throw new ArgumentNullException("bmp");
			}
			if (bitmap_0.Width >= 10 && bitmap_0.Height >= 10)
			{
				using (Graphics graphics_ = Graphics.FromImage(bitmap_0))
				{
					DCGraphics dcgraphics_ = new DCGraphics(graphics_);
					smethod_11(dcgraphics_, new RectangleF(0f, 0f, bitmap_0.Width, bitmap_0.Height));
				}
			}
		}

		[DCInternal]
		public static bool smethod_13(GEnum6 genum6_0)
		{
			GEnum13 gEnum = smethod_0(genum6_0);
			if (gEnum == GEnum13.const_0)
			{
				return true;
			}
			if (gEnum <= genum13_1)
			{
				return true;
			}
			return false;
		}

		internal static void smethod_14()
		{
		}

		/// <summary>
		///       获得XML字符串
		///       </summary>
		/// <param name="formatted">是否格式化输出</param>
		/// <returns>获得的XML字符串</returns>
		[DCPublishAPI]
		public string GetXMLText(bool formatted)
		{
			int num = 0;
			ContentSerializer contentSerializer = null;
			if (AppHost != null)
			{
				contentSerializer = AppHost.ContentSerializers.GetSerializer("xml");
			}
			if (contentSerializer == null)
			{
				contentSerializer = new XMLContentSerializer();
			}
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.EnableDocumentSetting = true;
			contentSerializeOptions.IncludeSelectionOnly = false;
			contentSerializeOptions.Formated = formatted;
			method_86();
			XTextDocument xTextDocument = this;
			if (Options.BehaviorOptions.CloneSerialize)
			{
				xTextDocument = (XTextDocument)Clone(Deeply: true);
			}
			xTextDocument.vmethod_21("xml");
			contentSerializer.Serialize(streamWriter, xTextDocument, contentSerializeOptions);
			xTextDocument.vmethod_22();
			xTextDocument.Parameters = null;
			if (Options.BehaviorOptions.CloneSerialize)
			{
				xTextDocument.Dispose();
			}
			streamWriter.Close();
			byte[] bytes = memoryStream.ToArray();
			string @string = Encoding.UTF8.GetString(bytes);
			return XMLHelper.CleanupXMLHeader(@string);
		}

		/// <summary>
		///       获得文档的RTF文本代码
		///       </summary>
		/// <param name="IncludeSelectionOnly">是否只包含选择区域</param>
		/// <returns>获得的RTF文本代码字符串</returns>
		[DCPublishAPI]
		public string GetRTFText(bool IncludeSelectionOnly)
		{
			int num = 17;
			ContentSerializer contentSerializer = null;
			if (AppHost != null)
			{
				contentSerializer = AppHost.ContentSerializers.GetSerializer("rtf");
			}
			if (contentSerializer == null)
			{
				contentSerializer = new RTFContentSerializer();
			}
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.IncludeSelectionOnly = IncludeSelectionOnly;
			StringWriter stringWriter = new StringWriter();
			XTextDocument xTextDocument = this;
			if (Options.BehaviorOptions.CloneSerialize)
			{
				xTextDocument = (XTextDocument)Clone(Deeply: true);
			}
			xTextDocument.vmethod_21("rtf");
			contentSerializer.Serialize(stringWriter, xTextDocument, contentSerializeOptions);
			xTextDocument.vmethod_22();
			if (Options.BehaviorOptions.CloneSerialize)
			{
				xTextDocument.Dispose();
			}
			return stringWriter.ToString();
		}

		/// <summary>
		///       获得文档的Html文本代码
		///       </summary>
		/// <param name="IncludeSelectionOnly">是否只包含选择区域</param>
		/// <returns>获得的RTF文本代码字符串</returns>
		[DCPublishAPI]
		public string GetHtmlText(bool IncludeSelectionOnly)
		{
			int num = 3;
			ContentSerializer contentSerializer = null;
			if (AppHost != null)
			{
				contentSerializer = AppHost.ContentSerializers.GetSerializer("html");
			}
			if (contentSerializer == null)
			{
				contentSerializer = new HTMLContentSerializer();
			}
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.IncludeSelectionOnly = IncludeSelectionOnly;
			contentSerializeOptions.Formated = Options.BehaviorOptions.OutputFormatedXMLSource;
			contentSerializeOptions.ForPrint = true;
			StringWriter stringWriter = new StringWriter();
			XTextDocument xTextDocument = this;
			if (Options.BehaviorOptions.CloneSerialize)
			{
				xTextDocument = (XTextDocument)Clone(Deeply: true);
			}
			xTextDocument.vmethod_21("html");
			contentSerializer.Serialize(stringWriter, xTextDocument, contentSerializeOptions);
			xTextDocument.vmethod_22();
			if (Options.BehaviorOptions.CloneSerialize)
			{
				xTextDocument.Dispose();
			}
			return stringWriter.ToString();
		}

		/// <summary>
		///       加载文档后的处理
		///       </summary>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			int num = 15;
			if (!EnableAfterLoad)
			{
				return;
			}
			dictionary_0 = null;
			CountDown.GetTickCountFloat();
			States.Layouted = false;
			ContentStyles.method_4();
			ContentStyles.Styles.SetValueLocked(vLock: false);
			if (MotherTemplate != null)
			{
				MotherTemplate.Apply(args.WriterControl, this);
			}
			if (documentCommentList_1 != null)
			{
				documentCommentList_1.FixDomState();
			}
			int_12 = 0;
			CountDown.GetTickCountFloat();
			if (idocumentScriptEngine_0 != null)
			{
				idocumentScriptEngine_0.Close();
				idocumentScriptEngine_0 = null;
			}
			if (string.Compare(args.Format, "rtf", ignoreCase: true) == 0)
			{
				Options.ViewOptions.RichTextBoxCompatibility = true;
			}
			else
			{
				Options.ViewOptions.RichTextBoxCompatibility = false;
			}
			if (string.IsNullOrEmpty(ContentStyles.Default.FontName))
			{
				ContentStyles.Default.FontName = Control.DefaultFont.Name;
			}
			if (ContentStyles.Default.FontSize <= 0f)
			{
				ContentStyles.Default.FontSize = 9f;
			}
			ContentStyles.HandleAfterLoad();
			ContentStyles.method_4();
			args.Element = this;
			FixDomState();
			base.AfterLoad(args);
			CurrentContentElement = Body;
			_ = Header;
			_ = Footer;
			method_111();
			foreach (DocumentComment comment in Comments)
			{
				comment.method_1(this);
			}
			method_79();
			method_29(EventArgs.Empty);
			if (Options.BehaviorOptions.EnableElementEvents)
			{
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this, bool_2: true);
				domTreeNodeEnumerable.ExcludeCharElement = true;
				domTreeNodeEnumerable.ExcludeParagraphFlag = true;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					ElementEventTemplateList events = item.Events;
					if (events != null && events.HasLoad)
					{
						args.Element = item;
						events.OnLoad(this, args);
					}
				}
				if (GlobalEvents != null && GlobalEvents.HasLoad)
				{
					args.Element = this;
					GlobalEvents.OnLoad(this, args);
				}
			}
			ContentStyles.Styles.SetValueLocked(vLock: true);
		}

		internal void method_115()
		{
			int_17++;
		}

		internal void method_116()
		{
			int_17--;
			if (int_17 < 0)
			{
				int_17 = 0;
			}
		}

		/// <summary>
		///       导入文档内容
		///       </summary>
		/// <param name="source">文档来源</param>
		/// <returns>导入的文档元素列表</returns>
		public XTextElementList ImportDocument(FileContentSource source)
		{
			if (source == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(source.FileName))
			{
				return null;
			}
			return method_119(source, bool_32: true, bool_33: true, this);
		}

		/// <summary>
		///       导入文档内容
		///       </summary>
		/// <param name="fileSystemName">文件系统名称</param>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>导入的文档元素列表</returns>
		public XTextElementList ImportDocument(string fileSystemName, string fileName, string format)
		{
			return method_118(fileSystemName, fileName, format, bool_32: false, Enum2.const_1, null);
		}

		/// <summary>
		///       从文件中导入文档内容
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>导入的文档元素列表</returns>
		public XTextElementList ImportDocument(string fileName, string format)
		{
			return method_118(null, fileName, format, bool_32: false, Enum2.const_1, null);
		}

		/// <summary>
		///       导入文档内容
		///       </summary>
		/// <param name="stream">文档流对象</param>
		/// <param name="format">文件格式</param>
		/// <returns>导入的文档元素列表</returns>
		public XTextElementList ImportDocument(Stream stream, string format)
		{
			return method_118(null, stream, format, bool_32: false, Enum2.const_1, null);
		}

		/// <summary>
		///       导入文档
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">文件格式</param>
		/// <returns>导入的文档元素列表</returns>
		public XTextElementList ImportDocument(TextReader reader, string format)
		{
			return method_118(null, reader, format, bool_32: false, Enum2.const_1, null);
		}

		/// <summary>
		///       已追加模式加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>导入的文档元素列表</returns>
		[DCPublishAPI]
		public void LoadUseAppendModeFromFileName(string fileName, string format)
		{
			method_118(null, fileName, format, bool_32: false, Enum2.const_2, null);
		}

		/// <summary>
		///       以追加模式加载文档
		///       </summary>
		/// <param name="stream">文档流对象</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		public void LoadUseAppendModeFromStream(Stream stream, string format)
		{
			try
			{
				method_115();
				method_118(null, stream, format, bool_32: false, Enum2.const_2, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以追加模式加载文档
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		public void LoadUseAppendModeFromReader(TextReader reader, string format)
		{
			try
			{
				method_115();
				method_118(null, reader, format, bool_32: false, Enum2.const_2, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以追加模式加载文档
		///       </summary>
		/// <param name="txt">文本内容</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		public void LoadUseAppendModeFromString(string string_26, string format)
		{
			if (string_26 == null)
			{
				string_26 = "";
			}
			StringReader object_ = new StringReader(string_26);
			try
			{
				method_115();
				method_118(null, object_, format, bool_32: false, Enum2.const_2, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以追加模式加载文档
		///       </summary>
		/// <param name="txt">BASE64格式文本</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		public void LoadUseAppendModeFromBase64String(string string_26, string format)
		{
			if (!string.IsNullOrEmpty(string_26))
			{
				byte[] buffer = Convert.FromBase64String(string_26);
				MemoryStream object_ = new MemoryStream(buffer);
				try
				{
					method_115();
					method_118(null, object_, format, bool_32: false, Enum2.const_2, null);
				}
				finally
				{
					method_116();
				}
			}
		}

		/// <summary>
		///       以指定的格式从指定名称的文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		/// <param name="instance">承载加载文档的对象实例</param>
		public void LoadDocumentInstance(string fileName, string format, XTextDocument instance)
		{
			try
			{
				method_115();
				method_118(null, fileName, format, bool_32: false, Enum2.const_0, instance);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从指定名称的文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		/// <param name="fastMode">快速加载模式</param>
		/// <param name="instance">指定的文档对象实例</param>
		[ComVisible(false)]
		public void Load(string fileName, string format, bool fastMode, XTextDocument instance)
		{
			try
			{
				method_115();
				method_118(null, fileName, format, fastMode, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="format">指定的格式</param>
		/// <param name="instance">指定的文档对象实例</param>
		[ComVisible(false)]
		public void Load(Stream stream, string format, XTextDocument instance)
		{
			try
			{
				method_115();
				method_118(null, stream, format, bool_32: false, Enum2.const_0, instance);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="format">指定的格式</param>
		/// <param name="fastMode">快速加载模式</param>
		/// <param name="instance">指定的文档对象实例</param>
		[ComVisible(false)]
		public void Load(Stream stream, string format, bool fastMode, XTextDocument instance)
		{
			try
			{
				method_115();
				method_118(null, stream, format, fastMode, Enum2.const_0, instance);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">指定的格式</param>
		/// <param name="instance">指定的文档对象实例</param>
		[ComVisible(false)]
		public void Load(TextReader reader, string format, XTextDocument instance)
		{
			try
			{
				method_115();
				method_118(null, reader, format, bool_32: false, Enum2.const_0, instance);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从指定名称的文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		public void Load(string fileName, string format)
		{
			try
			{
				method_115();
				method_118(null, fileName, format, bool_32: false, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从指定名称的文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void LoadFromFile(string fileName, string format)
		{
			try
			{
				method_115();
				method_118(null, fileName, format, bool_32: false, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从指定名称的文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void LoadFromFileFastMode(string fileName, string format)
		{
			try
			{
				method_115();
				method_118(null, fileName, format, bool_32: true, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从指定的文本中加载文档
		///       </summary>
		/// <param name="text">文本</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void LoadFromString(string text, string format)
		{
			StringReader object_ = new StringReader(text);
			try
			{
				method_115();
				method_118(null, object_, format, bool_32: false, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从指定的文本中加载文档
		///       </summary>
		/// <param name="text">文本</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void LoadFromStringFastMode(string text, string format)
		{
			StringReader object_ = new StringReader(text);
			try
			{
				method_115();
				method_118(null, object_, format, bool_32: true, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       从Base64的字符串中加载文档
		///       </summary>
		/// <param name="text">Base64字符串</param>
		/// <param name="format">指定的文件格式</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void LoadFromBase64String(string text, string format)
		{
			byte[] buffer = Convert.FromBase64String(text);
			MemoryStream stream = new MemoryStream(buffer);
			Load(stream, format);
		}

		/// <summary>
		///       从Base64的字符串中加载文档
		///       </summary>
		/// <param name="text">Base64字符串</param>
		/// <param name="format">指定的文件格式</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void LoadFromBase64StringFastMode(string text, string format)
		{
			byte[] buffer = Convert.FromBase64String(text);
			MemoryStream stream = new MemoryStream(buffer);
			Load(stream, format, fastMode: true);
		}

		/// <summary>
		///       以指定的格式从指定名称的文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		/// <param name="fastMode">快速加载模式</param>
		[ComVisible(false)]
		public void Load(string fileName, string format, bool fastMode)
		{
			try
			{
				method_115();
				method_118(null, fileName, format, fastMode, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="format">指定的格式</param>
		[ComVisible(false)]
		[DCPublishAPI]
		public void Load(Stream stream, string format)
		{
			Load(stream, format, fastMode: false);
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="format">指定的格式</param>
		/// <param name="fastMode">快速加载模式</param>
		[ComVisible(false)]
		[DCPublishAPI]
		public void Load(Stream stream, string format, bool fastMode)
		{
			try
			{
				method_115();
				method_118(null, stream, format, fastMode, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">指定的格式</param>
		[DCPublishAPI]
		[ComVisible(false)]
		public void Load(TextReader reader, string format)
		{
			try
			{
				method_115();
				method_118(null, reader, format, bool_32: false, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		/// <summary>
		///       以指定的格式从文件流中加载文档。
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">指定的格式</param>
		/// <param name="fastMode">快速加载模式</param>
		[ComVisible(false)]
		[DCPublishAPI]
		public void Load(TextReader reader, string format, bool fastMode)
		{
			try
			{
				method_115();
				method_118(null, reader, format, fastMode, Enum2.const_0, null);
			}
			finally
			{
				method_116();
			}
		}

		private ContentSerializer method_117(object object_3, string string_26)
		{
			ContentSerializer contentSerializer = AppHost.ContentSerializers.GetSerializer(string_26);
			if (contentSerializer != null)
			{
				if (object_3 is string || object_3 is Stream)
				{
					if ((contentSerializer.Flags & GEnum14.flag_1) != GEnum14.flag_1)
					{
						contentSerializer = null;
					}
				}
				else if (object_3 is TextReader)
				{
					if ((contentSerializer.Flags & GEnum14.flag_3) != GEnum14.flag_3)
					{
						contentSerializer = null;
					}
				}
				else
				{
					contentSerializer = null;
				}
			}
			if (contentSerializer == null)
			{
				throw new NotSupportedException(string_26.ToString());
			}
			return contentSerializer;
		}

		private XTextElementList method_118(string string_26, object object_3, string string_27, bool bool_32, Enum2 enum2_0, XTextDocument xtextDocument_1)
		{
			int num = 2;
			method_98();
			xtextElementList_2 = null;
			method_40(DomReadyStates.Loading);
			float tickCountFloat = CountDown.GetTickCountFloat();
			float num2 = tickCountFloat;
			if (xtextDocument_1 != null)
			{
				boundsSelectionPrintInfo_0 = null;
			}
			if (Options.BehaviorOptions.DebugMode)
			{
				tickCountFloat = CountDown.GetTickCountFloat();
				Debug.WriteLine(string.Format(WriterStringsCore.Loading_FileName_Format, bool_32 ? ("Fast " + object_3.ToString()) : object_3.ToString(), string_27));
			}
			ContentSerializer contentSerializer = method_117(object_3, string_27);
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.EnableDocumentSetting = true;
			contentSerializeOptions.WriterControl = EditorControl;
			contentSerializeOptions.BasePath = BaseUrl;
			contentSerializeOptions.FileName = FileName;
			contentSerializeOptions.FastMode = bool_32;
			XTextDocument xTextDocument = xtextDocument_1;
			if (xTextDocument == null)
			{
				xTextDocument = this;
			}
			xTextDocument.float_5 = 0f;
			xTextDocument.boundsSelectionPrintInfo_0 = null;
			if (enum2_0 == Enum2.const_1 || enum2_0 == Enum2.const_2)
			{
				xTextDocument = (XTextDocument)Clone(Deeply: false);
			}
			else
			{
				xtextDocument_1?.method_126(this, bool_32: false);
			}
			if (object_3 is string)
			{
				string text = (string)object_3;
				contentSerializeOptions.BasePath = GClass334.smethod_1(text);
				contentSerializeOptions.FileName = text;
				WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(EditorControl, this, xtextElement_1, text, string_26);
				writerReadFileContentEventArgs.FileFormat = string_27;
				byte[] array = WriterControl.ReadFileContent(EditorControl, writerReadFileContentEventArgs);
				if (array == null || array.Length <= 0)
				{
					return null;
				}
				contentSerializer = method_117(object_3, writerReadFileContentEventArgs.FileFormat);
				MemoryStream stream = new MemoryStream(array);
				if (contentSerializer != null)
				{
					contentSerializer.Deserialize(stream, xTextDocument, contentSerializeOptions);
					if (!string.IsNullOrEmpty(writerReadFileContentEventArgs.SpecifyTitle))
					{
						xTextDocument.Title = writerReadFileContentEventArgs.SpecifyTitle;
					}
				}
				ContentSourceType = DocumentContentSourceTypes.File;
			}
			else if (object_3 is TextReader)
			{
				contentSerializer.Deserialize((TextReader)object_3, xTextDocument, contentSerializeOptions);
				ContentSourceType = DocumentContentSourceTypes.TextReader;
			}
			else if (object_3 is Stream)
			{
				contentSerializer.Deserialize((Stream)object_3, xTextDocument, contentSerializeOptions);
				ContentSourceType = DocumentContentSourceTypes.Stream;
			}
			if (xTextDocument.documentControler_0 != null)
			{
				xTextDocument.documentControler_0.method_0();
			}
			xTextDocument.gclass108_0 = null;
			xTextDocument.class136_0 = null;
			WriterEventArgs writerEventArgs_ = new WriterEventArgs(EditorControl, xTextDocument, xTextDocument);
			method_37(writerEventArgs_);
			if (!bool_32)
			{
				if (object_3 is string)
				{
					xTextDocument.FileName = (string)object_3;
				}
				if (xTextDocument.SaveDocumentOptionsToFile && xTextDocument.DocumentOptionsToSaveFile != null)
				{
					Options = DocumentOptionsToSaveFile;
				}
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				ElementLoadEventArgs args = new ElementLoadEventArgs(xTextDocument, string_27);
				xTextDocument.AfterLoad(args);
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
				xTextDocument.Modified = false;
				if (xTextDocument.UndoList != null)
				{
					xTextDocument.UndoList.Clear();
				}
			}
			else
			{
				xTextDocument.method_18(bool_17: true);
				WriterUtils.smethod_62(Elements, bool_2: true);
			}
			if (Options.BehaviorOptions.DebugMode)
			{
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				Debug.WriteLine("Document loaded:" + xTextDocument.Info.Title);
				Debug.WriteLine("Load Tick Count:" + Convert.ToString(tickCountFloat));
				Debug.WriteLine("File name      :" + xTextDocument.FileName);
				Debug.WriteLine("Creation time  :" + FormatUtils.ToYYYY_MM_DD_HH_MM_SS(xTextDocument.Info.CreationTime));
				Debug.WriteLine("Description    :" + xTextDocument.Info.Description);
			}
			XTextElementList elements = xTextDocument.Body.Elements;
			if (enum2_0 == Enum2.const_1 || enum2_0 == Enum2.const_2)
			{
				ImportElements(elements);
				if (enum2_0 == Enum2.const_2)
				{
					Body.ContentBuilder.AppendRange(elements);
					Body.vmethod_36(bool_22: false);
					if (!bool_32)
					{
						ElementLoadEventArgs args = new ElementLoadEventArgs(xTextDocument, string_27);
						AfterLoad(args);
						Modified = false;
						if (UndoList != null)
						{
							UndoList.Clear();
						}
					}
				}
			}
			num2 = CountDown.GetTickCountFloat() - num2;
			return elements;
		}

		private XTextElementList method_119(FileContentSource fileContentSource_0, bool bool_32, bool bool_33, XTextDocument xtextDocument_1)
		{
			int num = 1;
			if (fileContentSource_0 == null)
			{
				throw new ArgumentNullException("contentSource");
			}
			if (string.IsNullOrEmpty(fileContentSource_0.FileName))
			{
				throw new ArgumentNullException("contentSource.FileName");
			}
			long num2 = 0L;
			if (Options.BehaviorOptions.DebugMode)
			{
				num2 = CountDown.GetTickCountExt();
				Debug.WriteLine(string.Format(WriterStringsCore.Loading_FileName_Format, bool_32 ? ("Fast " + fileContentSource_0.FileName) : fileContentSource_0.FileName, fileContentSource_0.Format));
			}
			ContentSerializer contentSerializer = method_117(fileContentSource_0.FileName, fileContentSource_0.Format);
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.EnableDocumentSetting = true;
			contentSerializeOptions.BasePath = GClass334.smethod_1(fileContentSource_0.FileName);
			if (string.IsNullOrEmpty(contentSerializeOptions.BasePath))
			{
				contentSerializeOptions.BasePath = BaseUrl;
			}
			fileContentSource_0.RuntimeFileName = fileContentSource_0.FileName;
			contentSerializeOptions.FileName = fileContentSource_0.FileName;
			contentSerializeOptions.FastMode = bool_32;
			XTextDocument xTextDocument = xtextDocument_1;
			if (xTextDocument == null)
			{
				xTextDocument = this;
			}
			if (bool_33)
			{
				xTextDocument = (XTextDocument)Clone(Deeply: false);
			}
			else
			{
				xtextDocument_1?.method_126(this, bool_32: false);
			}
			WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(EditorControl, xTextDocument, null, fileContentSource_0.RuntimeFileName, fileContentSource_0.FileSystemName);
			writerReadFileContentEventArgs.FileFormat = fileContentSource_0.Format;
			byte[] array = WriterControl.ReadFileContent(EditorControl, writerReadFileContentEventArgs);
			if (array != null && array.Length > 0)
			{
				contentSerializer = method_117(fileContentSource_0.FileName, writerReadFileContentEventArgs.FileFormat);
				fileContentSource_0.RuntimeFormat = writerReadFileContentEventArgs.FileFormat;
				fileContentSource_0.RuntimeFileName = writerReadFileContentEventArgs.FileName;
				MemoryStream stream = new MemoryStream(array);
				contentSerializer?.Deserialize(stream, xTextDocument, contentSerializeOptions);
				xTextDocument.FixDomState();
				if (!bool_32)
				{
					xTextDocument.FileName = fileContentSource_0.FileName;
					ElementLoadEventArgs args = new ElementLoadEventArgs(xTextDocument, fileContentSource_0.Format);
					xTextDocument.AfterLoad(args);
					xTextDocument.Modified = false;
					if (xTextDocument.UndoList != null)
					{
						xTextDocument.UndoList.Clear();
					}
				}
				else
				{
					xTextDocument.method_18(bool_17: true);
					WriterUtils.smethod_62(xTextDocument.Elements, bool_2: true);
				}
				if (Options.BehaviorOptions.DebugMode)
				{
					num2 = CountDown.GetTickCountExt() - num2;
					Debug.WriteLine("Document loaded:" + xTextDocument.Info.Title);
					Debug.WriteLine("Load Tick Count:" + Convert.ToString((double)num2 / 10000.0));
					Debug.WriteLine("File name      :" + xTextDocument.FileName);
					Debug.WriteLine("Creation time  :" + FormatUtils.ToYYYY_MM_DD_HH_MM_SS(xTextDocument.Info.CreationTime));
					Debug.WriteLine("Description    :" + xTextDocument.Info.Description);
				}
				XTextElementList xTextElementList = xTextDocument.Body.Elements;
				string text = fileContentSource_0.Range;
				if (text != null)
				{
					text = text.Trim();
				}
				if (!string.IsNullOrEmpty(text))
				{
					if (string.Compare(text, "header", ignoreCase: true) == 0)
					{
						xTextElementList = xTextDocument.Header.Elements;
					}
					else if (string.Compare(text, "footer", ignoreCase: true) == 0)
					{
						xTextElementList = xTextDocument.Footer.Elements;
					}
					else if (string.Compare(text, "body", ignoreCase: true) == 0)
					{
						xTextElementList = xTextDocument.Body.Elements;
					}
					else
					{
						XTextElement elementById = xTextDocument.GetElementById(text);
						if (elementById != null)
						{
							xTextElementList = ((!(elementById is XTextContainerElement)) ? new XTextElementList(elementById) : elementById.Elements);
						}
					}
				}
				if (bool_33)
				{
					ImportElements(xTextElementList);
				}
				return xTextElementList;
			}
			return null;
		}

		/// <summary>
		///       保存长图片文件
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SaveLongImageFile(string fileName)
		{
			method_120(0, fileName, bool_32: true, 1f);
		}

		/// <summary>
		///       保存页面图片文件
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="fileName">文件名</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SavePageImageFile(int pageIndex, string fileName)
		{
			method_120(pageIndex, fileName, bool_32: false, 1f);
		}

		/// <summary>
		///       保存长图片文件
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SaveLongImageFileZoom(string fileName, float zoomRate)
		{
			method_120(0, fileName, bool_32: true, zoomRate);
		}

		/// <summary>
		///       保存页面图片文件
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <param name="fileName">文件名</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SavePageImageFileZoom(int pageIndex, string fileName, float zoomRate)
		{
			method_120(pageIndex, fileName, bool_32: false, zoomRate);
		}

		private void method_120(int int_18, string string_26, bool bool_32, float float_10)
		{
			int num = 15;
			if (string.IsNullOrEmpty(string_26))
			{
				throw new ArgumentNullException("fileName");
			}
			ImageFormat imageFormat = GClass343.smethod_3(string_26);
			if (imageFormat == null)
			{
				imageFormat = ImageFormat.Png;
			}
			Bitmap bitmap = null;
			bitmap = ((!bool_32) ? CreatePageBmp(int_18, showMarginLine: true, float_10) : CreateLongBmp(showMarginLine: true, float_10));
			if (bitmap == null)
			{
				throw new Exception("未能生成BMP");
			}
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				bitmap.Save(memoryStream, imageFormat);
				using (FileStream stream = new FileStream(string_26, FileMode.Create, FileAccess.Write))
				{
					memoryStream.WriteTo(stream);
				}
			}
			finally
			{
				bitmap.Dispose();
				memoryStream.Dispose();
			}
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <returns>生成的BASE64字符串</returns>
		[ComVisible(true)]
		public string SavePageImageToBase64String(int pageIndex, string format)
		{
			int num = 9;
			if (string.IsNullOrEmpty(format))
			{
				format = ".png";
			}
			Bitmap bitmap = CreatePageBmp(pageIndex, showMarginLine: true);
			ImageFormat imageFormat = GClass343.smethod_3(format);
			if (imageFormat == null)
			{
				imageFormat = ImageFormat.Png;
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, imageFormat);
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <returns>生成的BASE64字符串</returns>
		[ComVisible(true)]
		public string SavePageImageToBase64StringZoom(int pageIndex, string format, float zoomRate)
		{
			int num = 3;
			if (string.IsNullOrEmpty(format))
			{
				format = ".png";
			}
			Bitmap bitmap = CreatePageBmp(pageIndex, showMarginLine: true, zoomRate);
			ImageFormat imageFormat = GClass343.smethod_3(format);
			if (imageFormat == null)
			{
				imageFormat = ImageFormat.Png;
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, imageFormat);
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <returns>生成的BASE64字符串</returns>
		[ComVisible(true)]
		public string SaveLongImageToBase64String(string format)
		{
			int num = 12;
			if (string.IsNullOrEmpty(format))
			{
				format = ".png";
			}
			Bitmap bitmap = CreateLongBmp(showMarginLine: true);
			ImageFormat imageFormat = GClass343.smethod_3(format);
			if (imageFormat == null)
			{
				imageFormat = ImageFormat.Png;
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, imageFormat);
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <returns>生成的BASE64字符串</returns>
		[ComVisible(true)]
		public string SaveLongImageToBase64StringZoom(string format, float zoomRate)
		{
			int num = 7;
			if (string.IsNullOrEmpty(format))
			{
				format = ".png";
			}
			Bitmap bitmap = CreateLongBmp(showMarginLine: true, zoomRate);
			ImageFormat imageFormat = GClass343.smethod_3(format);
			if (imageFormat == null)
			{
				imageFormat = ImageFormat.Png;
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, imageFormat);
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		/// <summary>
		///       更新用户历史记录的时间
		///       </summary>
		/// <param name="addNewHistoryInfo">添加新的历史记录</param>
		[DCInternal]
		public void UpdateUserInfoSaveTime(bool addNewHistoryInfo)
		{
			DateTime nowDateTime = GetNowDateTime();
			Info.LastModifiedTime = nowDateTime;
			if (!Options.SecurityOptions.EnablePermission)
			{
				return;
			}
			if (UserHistories.Count > 0)
			{
				UserHistoryInfo userHistoryInfo = UserHistories[UserHistories.Count - 1];
				if (userHistoryInfo.IsEmptySaveTime)
				{
					userHistoryInfo.SavedTime = nowDateTime;
				}
			}
			if (addNewHistoryInfo)
			{
				UserHistoryInfo userHistoryInfo2 = UserHistoryInfo.CreateInstance();
				if (UserHistories.Count > 0)
				{
					UserHistoryInfo userHistoryInfo3 = UserHistories[UserHistories.Count - 1];
					userHistoryInfo2.Description = userHistoryInfo3.Description;
					userHistoryInfo2.ID = userHistoryInfo3.ID;
					userHistoryInfo2.Name = userHistoryInfo3.Name;
					userHistoryInfo2.Name2 = userHistoryInfo3.Name2;
					userHistoryInfo2.PermissionLevel = userHistoryInfo3.PermissionLevel;
					userHistoryInfo2.Tag = userHistoryInfo3.Tag;
					UserHistories.Add(userHistoryInfo2);
				}
			}
		}

		/// <summary>
		///       以指定的格式将文档保存在文档文档中
		///       </summary>
		/// <param name="writer">文本书写器</param>
		/// <param name="format">文档格式</param>
		[DCPublishAPI]
		[ComVisible(false)]
		public void Save(TextWriter writer, string format)
		{
			Info.LastModifiedTime = GetNowDateTime();
			method_121(writer, format, bool_32: false, null);
		}

		/// <summary>
		///       以指定的格式将文档保存在文档文档中
		///       </summary>
		/// <param name="writer">文本书写器</param>
		/// <param name="format">文档格式</param>
		/// <param name="backgroundMode">后台模式</param>
		[ComVisible(false)]
		[DCPublishAPI]
		public void Save(TextWriter writer, string format, bool backgroundMode)
		{
			Info.LastModifiedTime = GetNowDateTime();
			method_121(writer, format, backgroundMode, null);
		}

		/// <summary>
		///       以指定的格式将文档保存在文档文档中,DCWriter内部使用。
		///       </summary>
		/// <param name="writer">文本书写器</param>
		/// <param name="format">文档格式</param>
		/// <param name="backgroundMode">后台模式</param>
		/// <param name="descFileName">文件名</param>
		[ComVisible(false)]
		[Browsable(false)]
		[DCPublishAPI]
		public void Save(TextWriter writer, string format, bool backgroundMode, string descFileName)
		{
			Info.LastModifiedTime = GetNowDateTime();
			method_121(writer, format, backgroundMode, descFileName);
		}

		/// <summary>
		///       以指定的格式将文档保存在文件中
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文档格式</param>
		[DCPublishAPI]
		public void Save(string fileName, string format)
		{
			Info.LastModifiedTime = GetNowDateTime();
			method_121(fileName, format, bool_32: false, null);
		}

		/// <summary>
		///       以指定的格式将文档保存在文件中
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文档格式</param>
		[DCPublishAPI]
		public void SaveToFile(string fileName, string format)
		{
			Info.LastModifiedTime = GetNowDateTime();
			method_121(fileName, format, bool_32: false, null);
		}

		/// <summary>
		///       以指定格式将文档保存而而生成文本
		///       </summary>
		/// <param name="format">文档格式</param>
		/// <returns>保存结果</returns>
		[DCPublishAPI]
		public string SaveToString(string format)
		{
			Info.LastModifiedTime = GetNowDateTime();
			StringWriter stringWriter = new StringWriter();
			method_121(stringWriter, format, bool_32: false, null);
			string xmlText = stringWriter.ToString();
			return XMLHelper.CleanupXMLHeader(xmlText);
		}

		/// <summary>
		///       以指定格式将文档保存为BASE64格式的字符串
		///       </summary>
		/// <param name="format">文档格式</param>
		/// <returns>保存的BASE64字符串</returns>
		[DCPublishAPI]
		public string SaveToBase64String(string format)
		{
			MemoryStream memoryStream = new MemoryStream();
			Save(memoryStream, format);
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		/// <summary>
		///       以指定的格式将文档保存而生成二进制数据
		///       </summary>
		/// <param name="format">文档格式</param>
		/// <returns>保存结果</returns>
		[DCPublishAPI]
		public byte[] SaveToBinary(string format)
		{
			Info.LastModifiedTime = GetNowDateTime();
			MemoryStream memoryStream = new MemoryStream();
			method_121(memoryStream, format, bool_32: false, null);
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			return result;
		}

		/// <summary>
		///       以指定的格式将文档保存而生成压缩的二进制数据
		///       </summary>
		/// <param name="format">文档格式</param>
		/// <returns>保存结果</returns>
		[DCPublishAPI]
		public byte[] SaveToCompressBinary(string format)
		{
			byte[] array = SaveToBinary(format);
			if (array != null && array.Length > 0)
			{
				return FileHelper.GZipCompress(array);
			}
			return null;
		}

		/// <summary>
		///       以指定的格式从压缩的二进制数据加载文档
		///       </summary>
		/// <param name="bs">压缩的二进制数据</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		public void LoadFromCompressBinary(byte[] byte_0, string format)
		{
			int num = 13;
			if (byte_0 == null || byte_0.Length == 0)
			{
				throw new ArgumentNullException("bs");
			}
			byte[] array = FileHelper.GZipDecompress(byte_0);
			if (array != null && array.Length > 0)
			{
				MemoryStream stream = new MemoryStream(array);
				Load(stream, format);
			}
		}

		/// <summary>
		///       以后台模式存储文件
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文档格式</param>
		/// <remarks>
		///       后台模式存储文件时，不更新Modified状态
		///       </remarks>
		[DCPublishAPI]
		public void BackgroundSave(string fileName, string format)
		{
			method_121(fileName, format, bool_32: true, null);
		}

		/// <summary>
		///       以后台模式存储文件
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		/// <remarks>
		///       后台模式存储文件时，不更新Modified状态
		///       </remarks>
		[DCPublishAPI]
		public void BackgroundSaveToStream(Stream stream, string format)
		{
			method_121(stream, format, bool_32: true, null);
		}

		/// <summary>
		///       以指定的格式将文档保存在文件中
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文档格式</param>
		/// <param name="backgroundMode">后台模式</param>
		[ComVisible(false)]
		public void Save(string fileName, string format, bool backgroundMode)
		{
			method_121(fileName, format, backgroundMode, null);
		}

		/// <summary>
		///       以指定的格式将文档保存在文件流中。
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		[DCPublishAPI]
		[ComVisible(false)]
		public void Save(Stream stream, string format)
		{
			method_121(stream, format, bool_32: false, null);
		}

		/// <summary>
		///       以指定的格式将文档保存在文件流中。
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		/// <param name="backgroundMode">后台模式</param>
		/// <param name="descFileName">目标文件</param>
		[DCPublishAPI]
		[ComVisible(false)]
		public void Save(Stream stream, string format, bool backgroundMode, string descFileName, Encoding contentEncoding)
		{
			method_122(stream, format, backgroundMode, descFileName, contentEncoding);
		}

		internal void method_121(object object_3, string string_26, bool bool_32, string string_27)
		{
			method_122(object_3, string_26, bool_32, string_27, null);
		}

		internal void method_122(object object_3, string string_26, bool bool_32, string string_27, Encoding encoding_0)
		{
			int num = 2;
			method_98();
			smethod_1(EditorControl);
			if (string.Compare(string_26, "xml", ignoreCase: true) == 0)
			{
				method_86();
			}
			if (!bool_32)
			{
				UpdateUserInfoSaveTime(addNewHistoryInfo: true);
			}
			if (SaveDocumentOptionsToFile && documentOptions_1 != null)
			{
				DocumentOptionsToSaveFile = documentOptions_1.Clone();
			}
			if (Options.BehaviorOptions.CloneSerialize && string.Compare(string_26, "pdf", ignoreCase: true) != 0)
			{
				using (XTextDocument xTextDocument = (XTextDocument)Clone(Deeply: true))
				{
					if (contentSerializeOptions_0 != null)
					{
						xTextDocument.contentSerializeOptions_0 = contentSerializeOptions_0.Clone();
						contentSerializeOptions_0 = null;
					}
					xTextDocument.method_123(object_3, string_26, bool_32, string_27, encoding_0);
					if (!bool_32)
					{
						Modified = false;
						method_27();
					}
				}
			}
			else
			{
				method_123(object_3, string_26, bool_32, string_27, encoding_0);
			}
		}

		/// <summary>
		///       设置只使用一次的文档序列化设置
		///       </summary>
		/// <param name="opts">
		/// </param>
		[DCInternal]
		public void SetSerializeOptionsOnce(ContentSerializeOptions opts)
		{
			contentSerializeOptions_0 = opts;
		}

		private void method_123(object object_3, string string_26, bool bool_32, string string_27, Encoding encoding_0)
		{
			int num = 6;
			method_98();
			if (object_3 == null)
			{
				throw new ArgumentNullException("output");
			}
			ContentSerializer contentSerializer = AppHost.ContentSerializers.GetSerializer(string_26);
			if (!(contentSerializer is XMLContentSerializer))
			{
			}
			if (contentSerializer != null)
			{
				if (object_3 is string || object_3 is Stream)
				{
					if ((contentSerializer.Flags & GEnum14.flag_2) != GEnum14.flag_2)
					{
						contentSerializer = null;
						throw new NotSupportedException(string.Format(WriterStringsCore.NotSupportSerialize_Format, string_26));
					}
				}
				else if (object_3 is TextWriter)
				{
					if ((contentSerializer.Flags & GEnum14.flag_4) != GEnum14.flag_4)
					{
						contentSerializer = null;
						throw new NotSupportedException(string.Format(WriterStringsCore.NotSupportSerializeText_Format, string_26));
					}
				}
				else
				{
					contentSerializer = null;
				}
			}
			if (contentSerializer == null)
			{
				throw new NotSupportedException(string.Format(WriterStringsCore.NotSupportWrite_Format, string_26));
			}
			if (string.IsNullOrEmpty(string_26))
			{
				string_26 = contentSerializer.Name;
			}
			ContentSerializeOptions contentSerializeOptions = contentSerializeOptions_0;
			contentSerializeOptions_0 = null;
			if (contentSerializeOptions == null)
			{
				contentSerializeOptions = new ContentSerializeOptions();
			}
			if (string.IsNullOrEmpty(string_27))
			{
				contentSerializeOptions.BasePath = BaseUrl;
				contentSerializeOptions.FileName = FileName;
			}
			else
			{
				contentSerializeOptions.BasePath = GClass334.smethod_1(string_27);
				contentSerializeOptions.FileName = string_27;
			}
			contentSerializeOptions.EnableDocumentSetting = true;
			contentSerializeOptions.IncludeSelectionOnly = false;
			contentSerializeOptions.SerializeAttachFiles = true;
			contentSerializeOptions.FastMode = false;
			contentSerializeOptions.Formated = Options.BehaviorOptions.OutputFormatedXMLSource;
			if (encoding_0 != null)
			{
				contentSerializeOptions.ContentEncoding = encoding_0;
			}
			string text = string_19;
			try
			{
				string_19 = null;
				vmethod_21(string_26);
				if (contentSerializer.NeedRefreshPages(this))
				{
					CheckPageRefreshed();
				}
				if (object_3 is string)
				{
					string text2 = (string)object_3;
					MemoryStream memoryStream = new MemoryStream();
					contentSerializeOptions.BasePath = GClass334.smethod_1(text2);
					contentSerializeOptions.FileName = text2;
					contentSerializer.Serialize(memoryStream, this, contentSerializeOptions);
					WriterSaveFileContentEventArgs args = new WriterSaveFileContentEventArgs(EditorControl, this, null, text2, null, memoryStream.ToArray());
					WriterControl.SaveFileContent(EditorControl, args);
				}
				else if (object_3 is Stream)
				{
					contentSerializer.Serialize((Stream)object_3, this, contentSerializeOptions);
				}
				else if (object_3 is TextWriter)
				{
					TextWriter textWriter = (TextWriter)object_3;
					if (textWriter is StreamWriter)
					{
						StreamWriter streamWriter = (StreamWriter)textWriter;
						contentSerializeOptions.ContentEncoding = streamWriter.Encoding;
					}
					contentSerializer.Serialize(textWriter, this, contentSerializeOptions);
				}
				vmethod_22();
			}
			finally
			{
				string_19 = text;
			}
			if (!bool_32)
			{
				Modified = false;
				method_27();
			}
		}

		[DCInternal]
		public override void vmethod_21(string string_26)
		{
			int num = 6;
			if (string.Compare(string_26, "pdf", ignoreCase: true) != 0)
			{
				if (SaveDocumentOptionsToFile && EditorControl != null)
				{
					DocumentOptionsToSaveFile = EditorControl.DocumentOptions;
				}
				method_113();
				if (SerializeParameterValue)
				{
					foreach (DocumentParameter parameter in Parameters)
					{
						parameter.SetSerializeValue();
					}
				}
				EditorVersion = CurrentEditorVersion;
				xtextElementList_1 = null;
				bool_31 = false;
				if (!Options.BehaviorOptions.SpecifyDebugMode)
				{
					method_111();
				}
				ContentStyles.Styles.UpdateStyleIndex();
				FixDomState();
				foreach (XTextElement element in Elements)
				{
					(element as XTextDocumentContentElement)?.method_57(bool_23: true, bool_24: true);
				}
				if (xtextDocumentUndoList_0 != null)
				{
					xtextDocumentUndoList_0.Clear();
				}
				if (string.IsNullOrEmpty(string_26) || string.Compare(string_26, "xml", ignoreCase: true) == 0)
				{
					xtextElementList_1 = new XTextElementList();
					bool headerFooterDifferentFirstPage = PageSettings.HeaderFooterDifferentFirstPage;
					foreach (XTextElement element2 in Elements)
					{
						if (headerFooterDifferentFirstPage || (!(element2 is XTextDocumentHeaderForFirstPageElement) && !(element2 is XTextDocumentFooterForFirstPageElement)))
						{
							xtextElementList_1.Add(element2);
							element2.vmethod_21(string_26);
						}
					}
					int_9 = 0;
				}
			}
		}

		public override void vmethod_22()
		{
			base.vmethod_22();
			FixDomState();
		}

		[DCPublishAPI]
		public override void vmethod_19(GClass103 gclass103_0)
		{
			States.RenderMode = DocumentRenderMode.RTF;
			gclass103_0.method_32(this);
			gclass103_0.method_6(new RectangleF(0f, 0f, Body.Width, Body.Height));
			Body.vmethod_19(gclass103_0);
			gclass103_0.method_34();
		}

		internal void method_124(XTextElement xtextElement_3)
		{
			if (!RunAtWebServer)
			{
				return;
			}
			if (xtextElement_2 != null)
			{
				if (xtextElement_2 is XTextContainerElement)
				{
					((XTextContainerElement)xtextElement_2).WebClientSelected = false;
				}
				else if (xtextElement_2 is XTextObjectElement)
				{
					((XTextObjectElement)xtextElement_2).WebClientSelected = false;
				}
			}
			xtextElement_2 = null;
			XTextElement xTextElement = xtextElement_3;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement is XTextContainerElement || xTextElement is XTextObjectElement)
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				return;
			}
			xtextElement_2 = xTextElement;
		}

		[DCInternal]
		public void method_125()
		{
			if (RunAtWebServer)
			{
				xtextElement_2 = null;
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Body, bool_2: true);
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
						if (xTextContainerElement.WebClientSelected)
						{
							xtextElement_2 = xTextContainerElement;
							xTextContainerElement.WebClientSelected = false;
						}
					}
					else if (item is XTextObjectElement)
					{
						XTextObjectElement xTextObjectElement = (XTextObjectElement)item;
						if (xTextObjectElement.WebClientSelected)
						{
							xtextElement_2 = xTextObjectElement;
							xTextObjectElement.WebClientSelected = false;
						}
					}
				}
			}
		}

		public void method_126(XTextDocument xtextDocument_1, bool bool_32, bool bool_33 = false)
		{
			if (documentCommentList_0 != null)
			{
				documentCommentList_0.ClearData();
				documentCommentList_0 = null;
			}
			xtextDocumentContentElement_0 = null;
			printPage_0 = null;
			currentContentStyleInfo_0 = null;
			xtextElement_0 = null;
			if (xtextDocument_1 == null)
			{
				return;
			}
			if (xtextDocument_1.list_0 != null)
			{
				if (bool_33)
				{
					list_0 = xtextDocument_1.list_0;
					xtextDocument_1.list_0 = null;
				}
				else
				{
					list_0 = new List<string>();
					foreach (string item in xtextDocument_1.list_0)
					{
						list_0.Add((string)item.Clone());
					}
				}
			}
			string_17 = xtextDocument_1.string_17;
			if (bool_32)
			{
				if (xtextDocument_1.Elements != null)
				{
					if (bool_33)
					{
						Elements = xtextDocument_1.Elements;
						xtextDocument_1.Elements = null;
					}
					else
					{
						Elements.Clear();
						foreach (XTextElement element in xtextDocument_1.Elements)
						{
							Elements.Add(element);
						}
					}
				}
				if (xtextDocument_1.xtextElementList_1 != null)
				{
					if (bool_33)
					{
						xtextElementList_1 = xtextDocument_1.xtextElementList_1;
						xtextDocument_1.xtextElementList_1 = null;
					}
					else
					{
						xtextElementList_1 = xtextDocument_1.xtextElementList_1.Clone();
					}
				}
				int_9 = xtextDocument_1.int_9;
				if (xtextDocument_1.documentCommentList_1 != null)
				{
					if (bool_33)
					{
						documentCommentList_1 = xtextDocument_1.documentCommentList_1;
						xtextDocument_1.documentCommentList_1 = null;
					}
					else
					{
						documentCommentList_1 = xtextDocument_1.documentCommentList_1.Clone(deeply: true);
					}
				}
				if (xtextDocument_1.documentContentStyleContainer_0 != null)
				{
					if (bool_33)
					{
						documentContentStyleContainer_0 = xtextDocument_1.documentContentStyleContainer_0;
						xtextDocument_1.documentContentStyleContainer_0 = null;
					}
					else
					{
						documentContentStyleContainer_0 = (DocumentContentStyleContainer)xtextDocument_1.documentContentStyleContainer_0.method_2();
						documentContentStyleContainer_0.Document = this;
					}
				}
				if (xtextDocument_1.userHistoryInfoList_0 != null)
				{
					if (bool_33)
					{
						userHistoryInfoList_0 = xtextDocument_1.userHistoryInfoList_0;
						xtextDocument_1.userHistoryInfoList_0 = null;
					}
					else
					{
						userHistoryInfoList_0 = xtextDocument_1.userHistoryInfoList_0.Clone();
					}
				}
				if (xtextDocument_1.repeatedImageValueList_0 != null)
				{
					if (bool_33)
					{
						repeatedImageValueList_0 = xtextDocument_1.repeatedImageValueList_0;
						xtextDocument_1.repeatedImageValueList_0 = null;
					}
					else
					{
						repeatedImageValueList_0 = xtextDocument_1.repeatedImageValueList_0.method_4();
					}
				}
			}
			else
			{
				documentCommentList_1 = null;
				userHistoryInfoList_0 = null;
			}
			if (xtextDocument_1.documentOptions_0 != null)
			{
				if (bool_33)
				{
					documentOptions_0 = xtextDocument_1.documentOptions_0;
					xtextDocument_1.documentOptions_0 = null;
				}
				else
				{
					documentOptions_0 = xtextDocument_1.documentOptions_0.Clone();
				}
			}
			if (xtextDocument_1.Attributes != null)
			{
				if (bool_33)
				{
					Attributes = xtextDocument_1.Attributes;
					xtextDocument_1.Attributes = null;
				}
				else
				{
					Attributes = xtextDocument_1.Attributes.Clone();
				}
			}
			if (xtextDocument_1.documentParameterCollection_0 != null)
			{
				if (documentParameterCollection_0 == null)
				{
					documentParameterCollection_0 = new DocumentParameterCollection();
				}
				foreach (DocumentParameter item2 in xtextDocument_1.documentParameterCollection_0)
				{
					if (!Parameters.Contains(item2.Name))
					{
						Parameters.Add(item2.Clone());
					}
				}
			}
			if (xtextDocument_1.localConfig_0 != null)
			{
				if (bool_33)
				{
					localConfig_0 = xtextDocument_1.localConfig_0;
					xtextDocument_1.localConfig_0 = null;
				}
				else
				{
					localConfig_0 = xtextDocument_1.localConfig_0.Clone();
				}
			}
			bool_25 = xtextDocument_1.bool_25;
			FileName = xtextDocument_1.FileName;
			FileFormat = xtextDocument_1.FileFormat;
			boundsSelectionPrintInfo_0 = null;
			int_12 = 0;
			currentContentStyleInfo_0 = null;
			xtextDocumentContentElement_0 = null;
			documentParameterCollection_1 = null;
			ginterface6_0 = null;
			xtextElement_0 = null;
			documentControler_0 = null;
			currentContentStyleInfo_0 = null;
			printPageCollection_1 = null;
			gclass132_0 = null;
			PageRefreshed = false;
			printPageCollection_0 = new PrintPageCollection();
			printPage_0 = null;
			if (xtextDocument_1.Info != null)
			{
				if (bool_33)
				{
					documentInfo_0 = xtextDocument_1.documentInfo_0;
					xtextDocument_1.documentInfo_0 = null;
				}
				else
				{
					Info = xtextDocument_1.Info.Clone();
				}
			}
			if (xtextDocument_1.PageSettings != null)
			{
				if (bool_33)
				{
					xpageSettings_0 = xtextDocument_1.xpageSettings_0;
					xtextDocument_1.xpageSettings_0 = null;
				}
				else
				{
					xpageSettings_0 = xtextDocument_1.xpageSettings_0.Clone();
				}
			}
			if (xtextDocument_1.documentOptions_1 != null)
			{
				if (bool_33)
				{
					documentOptions_1 = xtextDocument_1.documentOptions_1;
					xtextDocument_1.documentOptions_1 = null;
				}
				else
				{
					documentOptions_1 = xtextDocument_1.documentOptions_1.Clone();
				}
			}
			if (xtextDocument_1.ControlOptionsForDebug != null)
			{
				if (bool_33)
				{
					ControlOptionsForDebug = xtextDocument_1.ControlOptionsForDebug;
					xtextDocument_1.ControlOptionsForDebug = null;
				}
				else
				{
					ControlOptionsForDebug = xtextDocument_1.ControlOptionsForDebug.Clone();
				}
			}
			ScriptText = xtextDocument_1.ScriptText;
			ScriptLanguage = xtextDocument_1.ScriptLanguage;
		}

		[CompilerGenerated]
		private static int smethod_15(object object_3, object object_4)
		{
			XTextElement xTextElement = (XTextElement)object_3;
			XTextElement xTextElement2 = (XTextElement)object_4;
			if (xTextElement.GetType() == xTextElement2.GetType() && xTextElement.StyleIndex == xTextElement2.StyleIndex)
			{
				return 0;
			}
			return 1;
		}
	}
}

#define DEBUG
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器鼠标事件处理
	///       </summary>
	/// <summary>
	///       文档元素级事件相关代码
	///       </summary>
	/// <summary>
	///       编辑器控件的文档对象模型处理模块
	///       </summary>
	/// <summary>
	///       编辑器中文档批注相关的功能
	///       </summary>
	/// <summary>
	///        编辑器命令相关功能模块
	///        </summary>
	/// <remarks>袁永福到此一游</remarks>
	/// <summary>
	///       加载和保存文件相关的操作
	///       </summary>
	/// <summary>
	///       文本文档编辑控件
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	/// <summary>
	///       授权相关
	///       </summary>
	/// <summary>
	///       编辑器中绘制用户界面的操作
	///       </summary>
	/// <summary>
	///       编辑器打印相关代码
	///       </summary>
	/// <summary>
	///       内容安全及授权相关
	///       </summary>
	/// <summary>
	///       处理键盘事件
	///       </summary>
	[DefaultEvent("DocumentContentChanged")]
	[DCPublishAPI]
	[DocumentComment]
	[ComVisible(true)]
	[ToolboxItem(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890000")]
	[ComClass("00012345-6789-ABCD-EF01-234567890000")]
	[ToolboxBitmap(typeof(WriterControl))]
	public class WriterControl : UserControl
	{
		/// <summary>
		///       处理未知命令的命令对象
		///       </summary>
		private class UnknowWriterCommand : WriterCommand
		{
			private WriterControl writerControl_0 = null;

			/// <summary>
			///       初始化对象
			///       </summary>
			/// <param name="ctl">编辑器控件对象</param>
			public UnknowWriterCommand(WriterControl writerControl_1)
			{
				writerControl_0 = writerControl_1;
			}

			public override void Invoke(WriterCommandEventArgs args)
			{
				writerControl_0.vmethod_46(args);
			}
		}

		/// <summary>
		///       编辑器键盘事件委托类型
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="keyCode">
		/// </param>
		/// <param name="modifiers">
		/// </param>
		[ComVisible(true)]
		[Guid("B9290895-6E4C-4C97-9E1C-4F3FD80F92FE")]
		public delegate void WriterKeyEventExtHandler(object eventSender, int keyCode, int modifiers);

		/// <summary>
		///       编辑器键盘按键事件委托类型
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="keyCode">
		/// </param>
		[Guid("72E3DA9C-C679-44E7-B878-6134B532E2B2")]
		[ComVisible(true)]
		public delegate void WriterKeyPressEventExtHandler(object eventSender, int keyCode);

		[CompilerGenerated]
		private sealed class Class286
		{
			public WriterControl writerControl_0;

			public XTextElement xtextElement_0;

			public void method_0(object sender, EventArgs e)
			{
				if (writerControl_0.DeveloperToolsVisible)
				{
					((GInterface18)writerControl_0.control_0).imethod_2(bool_0: false);
				}
				WriterEventArgs writerEventArgs_ = new WriterEventArgs(writerControl_0, writerControl_0.Document, xtextElement_0);
				writerControl_0.vmethod_5(writerEventArgs_);
			}
		}

		private DocumentOutlineNodeList documentOutlineNodeList_0 = null;

		private bool bool_0 = true;

		private VoidEventHandler voidEventHandler_0 = null;

		private VoidEventHandler voidEventHandler_1 = null;

		private VoidEventHandler voidEventHandler_2 = null;

		private VoidEventHandler voidEventHandler_3 = null;

		private IContainer icontainer_0 = null;

		private WriterViewControl myViewControl;

		private DCRulerControl ctlHRule;

		private DCRulerControl ctlVRule;

		private SplitContainer mySplitContainer;

		private static string string_0;

		private static string string_1;

		private IAutoSaveManager iautoSaveManager_0 = null;

		private bool bool_1 = true;

		private Image image_0 = null;

		private bool bool_2 = false;

		private bool bool_3 = true;

		private bool bool_4 = false;

		private bool bool_5 = false;

		private int int_0 = 0;

		private int int_1 = 0;

		private GlobalDebugConfig globalDebugConfig_0 = null;

		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		private DCLicenceDisplayMode _LicenceDisplayMode = DCLicenceDisplayMode.PageHeader;

		private Control control_0 = null;

		private bool bool_6 = false;

		private int int_2 = 0;

		private static volatile int int_3;

		private DCWinMessageFilterList dcwinMessageFilterList_0 = null;

		private static string string_2;

		private ClipboardProvider clipboardProvider_0 = null;

		private bool bool_7 = false;

		private string string_3 = null;

		private static string string_4;

		private IWriterControlWebServiceProtocol iwriterControlWebServiceProtocol_0 = null;

		private bool bool_8 = true;

		private List<WriterControlEventMessage> list_0 = new List<WriterControlEventMessage>();

		private WriterControlEventMessage writerControlEventMessage_0 = null;

		private WriterControlEventTemplate writerControlEventTemplate_0 = null;

		private WriterAfterExecuteEventExpressionEventHandler writerAfterExecuteEventExpressionEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_0 = null;

		private WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler_0 = null;

		private WriterSectionElementEventHandler writerSectionElementEventHandler_0 = null;

		private WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler_1 = null;

		private WriterSectionElementEventHandler writerSectionElementEventHandler_1 = null;

		[NonSerialized]
		private WriterPrintEventHandler writerPrintEventHandler_0 = null;

		[NonSerialized]
		private WriterPrintQueryPageSettingsEventHandler writerPrintQueryPageSettingsEventHandler_0 = null;

		[NonSerialized]
		private WriterPrintPageEventHandler writerPrintPageEventHandler_0 = null;

		[NonSerialized]
		private WriterPrintEventHandler writerPrintEventHandler_1 = null;

		private WriterBeforeFieldContentEditEventHandler writerBeforeFieldContentEditEventHandler_0 = null;

		private WriterAfterFieldContentEditEventHandler writerAfterFieldContentEditEventHandler_0 = null;

		private ElementValidatingEventHandler elementValidatingEventHandler_0 = null;

		private WriterBeforePlayMediaEventHandler writerBeforePlayMediaEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_1 = null;

		private WriterElementCheckedChangedEventHandler writerElementCheckedChangedEventHandler_0 = null;

		private WriterQueryAssistInputItemsEventHandler writerQueryAssistInputItemsEventHandler_0 = null;

		private WriterBeforeUIKeyboardInputStringEventHandler writerBeforeUIKeyboardInputStringEventHandler_0 = null;

		private WriterTableRowHeightChangedEventHandler writerTableRowHeightChangedEventHandler_0 = null;

		private WriterTableRowHeightChangingEventHandler writerTableRowHeightChangingEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_2 = null;

		private StatusTextChangedEventHandler statusTextChangedEventHandler_0 = null;

		private WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler_0 = null;

		private WriterReportErrorEventHandler writerReportErrorEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_3 = null;

		private WriterExpressionFunctionEventHandler writerExpressionFunctionEventHandler_0 = null;

		private WriterGetAdornTextEventHandler writerGetAdornTextEventHandler_0 = null;

		private WriterEditElementValueEventHandler writerEditElementValueEventHandler_0 = null;

		private System.Windows.Forms.Timer timer_0 = null;

		private WriterSaveFileContentEventHandler writerSaveFileContentEventHandler_0 = null;

		private bool bool_9 = true;

		private WriterSaveFileContentEventHandler writerSaveFileContentEventHandler_1 = null;

		private WriterReadFileContentEventHandler writerReadFileContentEventHandler_0 = null;

		private ElementMouseEventHandler elementMouseEventHandler_0 = null;

		private ElementEventHandler elementEventHandler_0 = null;

		private ElementEventHandler elementEventHandler_1 = null;

		private ElementMouseEventHandler elementMouseEventHandler_1 = null;

		private ElementMouseEventHandler elementMouseEventHandler_2 = null;

		private ElementMouseEventHandler elementMouseEventHandler_3 = null;

		private ElementMouseEventHandler elementMouseEventHandler_4 = null;

		private WriterButtonClickEventHandler writerButtonClickEventHandler_0 = null;

		private WriterLinkEventHandler writerLinkEventHandler_0 = null;

		private GetLinkListItemsEventHandler getLinkListItemsEventHandler_0 = null;

		private CollectProtectedElementsEventHandler collectProtectedElementsEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_4 = null;

		private PromptProtectedContentEventHandler promptProtectedContentEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_5 = null;

		private WriterEventHandler writerEventHandler_6 = null;

		private ContentChangingEventHandler contentChangingEventHandler_0 = null;

		private ContentChangedEventHandler contentChangedEventHandler_0 = null;

		private WriterShowDialogEventHandler writerShowDialogEventHandler_0 = null;

		private CustomCommandEventHandler customCommandEventHandler_0 = null;

		private WriterStartEditEventHandler writerStartEditEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_7 = null;

		private CreateInstanceEventHandler createInstanceEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_8 = null;

		private QueryUserHistoryDisplayTextEventHandler queryUserHistoryDisplayTextEventHandler_0 = null;

		private ParseSelectedItemsEventHandler parseSelectedItemsEventHandler_0 = null;

		private FormatListItemsEventHandler formatListItemsEventHandler_0 = null;

		private WriterCommandEventHandler writerCommandEventHandler_0 = null;

		private QueryKBEntriesEventHandler queryKBEntriesEventHandler_0 = null;

		private WriterMouseEventHandler writerMouseEventHandler_0 = null;

		private WriterMouseEventHandler writerMouseEventHandler_1 = null;

		private WriterMouseEventHandler writerMouseEventHandler_2 = null;

		private WriterKeyEventExtHandler writerKeyEventExtHandler_0 = null;

		private WriterKeyEventExtHandler writerKeyEventExtHandler_1 = null;

		private WriterKeyPressEventExtHandler writerKeyPressEventExtHandler_0 = null;

		private WriterMouseEventHandler writerMouseEventHandler_3 = null;

		private WriterMouseEventHandler writerMouseEventHandler_4 = null;

		private FilterValueEventHandler filterValueEventHandler_0 = null;

		private CreateElementsByKBEntryEventHandler createElementsByKBEntryEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_9 = null;

		private WriterEventHandler writerEventHandler_10 = null;

		private ComVoidHandler comVoidHandler_0 = null;

		private WriterEventHandler writerEventHandler_11 = null;

		private InsertObjectEventHandler insertObjectEventHandler_0 = null;

		private CanInsertObjectEventHandler canInsertObjectEventHandler_0 = null;

		private SelectionChangingEventHandler selectionChangingEventHandler_0 = null;

		private bool bool_10 = true;

		private WriterEventHandler writerEventHandler_12 = null;

		private ComVoidHandler comVoidHandler_1 = null;

		private WriterEventHandler writerEventHandler_13 = null;

		private ComVoidHandler comVoidHandler_2 = null;

		private bool bool_11 = false;

		private QueryListItemsEventHandler queryListItemsEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_14 = null;

		private WriterCommandEventHandler writerCommandEventHandler_1 = null;

		private WriterCommandEventHandler writerCommandEventHandler_2 = null;

		private WriterEventHandler writerEventHandler_15 = null;

		private CommandErrorEventHandler commandErrorEventHandler_0 = null;

		private WriterDocumentPrintedEventHandler writerDocumentPrintedEventHandler_0 = null;

		private WriterEventHandler writerEventHandler_16 = null;

		private Class134 class134_0 = null;

		private List<string> list_1 = null;

		/// <summary>
		///       当前子文档节元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		[XmlIgnore]
		public XTextSubDocumentElement CurrentSubDocument => Document.CurrentSubDocument;

		/// <summary>
		///       文档中包含的子文档对象列表
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextElementList SubDocuments => Document.SubDocuments;

		[DCPublishAPI]
		[DefaultValue(false)]
		public override bool AllowDrop
		{
			get
			{
				return InnerViewControl.AllowDrop;
			}
			set
			{
				InnerViewControl.AllowDrop = value;
			}
		}

		/// <summary>
		///       能否直接拖拽文档内容
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		[Category("Behavior")]
		public bool AllowDragContent
		{
			get
			{
				return InnerViewControl.AllowDragContent;
			}
			set
			{
				InnerViewControl.AllowDragContent = value;
			}
		}

		/// <summary>
		///       编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据
		///       </summary>
		[Description("编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据")]
		[DCPublishAPI]
		[DefaultValue(WriterDataFormats.All)]
		[Category("Behavior")]
		public WriterDataFormats AcceptDataFormats
		{
			get
			{
				return InnerViewControl.AcceptDataFormats;
			}
			set
			{
				InnerViewControl.AcceptDataFormats = value;
			}
		}

		/// <summary>
		///       编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作
		///       </summary>
		[DefaultValue(WriterDataFormats.All)]
		[DCPublishAPI]
		[Description("编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作")]
		[Category("Behavior")]
		public WriterDataFormats CreationDataFormats
		{
			get
			{
				return InnerViewControl.CreationDataFormats;
			}
			set
			{
				InnerViewControl.CreationDataFormats = value;
			}
		}

		/// <summary>
		///       拖拽事件已经处理标记
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[Browsable(false)]
		public bool DragEventHandled
		{
			get
			{
				return InnerViewControl.DragEventHandled;
			}
			set
			{
				InnerViewControl.DragEventHandled = value;
			}
		}

		/// <summary>
		///       编辑器控件正在执行OLE拖拽事件
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public DragOperationState DragState => InnerViewControl.DragState;

		/// <summary>
		///       是否允许触发文档元素级事件
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool EnabledElementEvent
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.EnabledElementEvent;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.EnabledElementEvent = value;
				}
			}
		}

		/// <summary>
		///       文档元素事件模板列表
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ElementEventTemplateList EventTemplates
		{
			get
			{
				return InnerViewControl.EventTemplates;
			}
			set
			{
				InnerViewControl.EventTemplates = value;
			}
		}

		/// <summary>
		///       全局文档元素事件模板列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		public ElementEventTemlateMap GlobalEventTemplates
		{
			get
			{
				return InnerViewControl.GlobalEventTemplates;
			}
			set
			{
				InnerViewControl.GlobalEventTemplates = value;
			}
		}

		/// <summary>
		///       文本域元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_Field
		{
			get
			{
				return method_2(typeof(XTextFieldElementBase));
			}
			set
			{
				method_3(typeof(XTextFieldElementBase), value);
			}
		}

		/// <summary>
		///       复选框元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[DCPublishAPI]
		public ElementEventTemplate GlobalEventTemplate_CheckBox
		{
			get
			{
				return method_2(typeof(XTextCheckBoxElementBase));
			}
			set
			{
				method_3(typeof(XTextCheckBoxElementBase), value);
			}
		}

		/// <summary>
		///       表格元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DCPublishAPI]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Table
		{
			get
			{
				return method_2(typeof(XTextTableElement));
			}
			set
			{
				method_3(typeof(XTextTableElement), value);
			}
		}

		/// <summary>
		///       表格行元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_TableRow
		{
			get
			{
				return method_2(typeof(XTextTableRowElement));
			}
			set
			{
				method_3(typeof(XTextTableRowElement), value);
			}
		}

		/// <summary>
		///       单元格元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DCPublishAPI]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Cell
		{
			get
			{
				return method_2(typeof(XTextTableCellElement));
			}
			set
			{
				method_3(typeof(XTextTableCellElement), value);
			}
		}

		/// <summary>
		///       图片元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DCPublishAPI]
		[Category("Behavior")]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Image
		{
			get
			{
				return method_2(typeof(XTextImageElement));
			}
			set
			{
				method_3(typeof(XTextImageElement), value);
			}
		}

		/// <summary>
		///       所有类型元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DCPublishAPI]
		[Category("Behavior")]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Element
		{
			get
			{
				return method_2(typeof(XTextElement));
			}
			set
			{
				method_3(typeof(XTextElement), value);
			}
		}

		/// <summary>
		///       文档大纲层次的根节点列表
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public DocumentOutlineNodeList OutlineNodes => Document.OutlineNodes;

		/// <summary>
		///       当前文档大纲结构节点对象
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		public DocumentOutlineNode CurrentOutlineNode => Document.CurrentOutlineNode;

		/// <summary>
		///       后台运行模式
		///       </summary>
		/// <remarks>
		///       后台模式下，任何控件、文档只读和授权内容保护无效，可以任意修改文档内容。
		///       但仍然会根据需要留下历史修改痕迹。
		///       </remarks>
		[DCPublishAPI]
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public bool BackgroundMode
		{
			get
			{
				return InnerViewControl.BackgroundMode;
			}
			set
			{
				InnerViewControl.BackgroundMode = value;
			}
		}

		/// <summary>
		///       文档内容改变标记
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public bool Modified
		{
			get
			{
				return InnerViewControl.Modified;
			}
			set
			{
				InnerViewControl.Modified = value;
			}
		}

		/// <summary>
		///       文档中所有的表格对象
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextElementList Tables => Document.Tables;

		/// <summary>
		///       文档中所有的图片对象
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public XTextElementList Images => Document.Images;

		/// <summary>
		///       文档中包含的文本输入域列表对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public XTextElementList InputFields => Document.InputFields;

		/// <summary>
		///       文档中包含的内容被修改的文本输入域列表对象
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public XTextElementList ModifiedInputFields => Document.ModifiedInputFields;

		/// <summary>
		///       当前光标所在的字体名称
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public string CurrentFontName => Document.CurrentStyleInfo.Content.FontName;

		/// <summary>
		///       当前光标所在的粗体样式
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		public bool CurrentBold => Document.CurrentStyleInfo.Content.Bold;

		/// <summary>
		///       当前光标所在的斜体样式
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DCPublishAPI]
		public bool CurrentItalic => Document.CurrentStyleInfo.Content.Italic;

		/// <summary>
		///       当前光标所在的下划线样式
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public bool CurrentUnderline => Document.CurrentStyleInfo.Content.Underline;

		/// <summary>
		///       当前光标所在的上标样式
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public bool CurrentSuperscript => Document.CurrentStyleInfo.Content.Superscript;

		/// <summary>
		///       当前光标所在的下标样式
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		public bool CurrentSubscript => Document.CurrentStyleInfo.Content.Subscript;

		/// <summary>
		///       当前光标所在的字体大小
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public float CurrentFontSize => Document.CurrentStyleInfo.Content.FontSize;

		/// <summary>
		///       当前段落对齐方式
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public DocumentContentAlignment CurrentParagraphAlign => Document.CurrentStyleInfo.Paragraph.Align;

		/// <summary>
		///       当前段落对象
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextParagraphFlagElement CurrentParagraphEOF => Document.CurrentParagraphEOF;

		/// <summary>
		///       文档基础路径
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public string DocumentBaseUrl
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.BaseUrl;
			}
			set
			{
				if (Document != null)
				{
					Document.BaseUrl = value;
				}
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextDocument Document
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.Document;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.Document = value;
				}
			}
		}

		/// <summary>
		///       当前文档内容版本号，对文档内容的任何修改都会使得该版本号增加
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public int DocumentContentVersion
		{
			get
			{
				if (Document == null)
				{
					return 0;
				}
				return Document.ContentVersion;
			}
		}

		/// <summary>
		///       当前元素样式
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		public DocumentContentStyle CurrentStyle
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.CurrentStyleInfo.Content;
			}
		}

		/// <summary>
		///       当前插入点所在的元素
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public XTextElement CurrentElement
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.CurrentElement;
			}
		}

		/// <summary>
		///       当前单选的文档元素对象
		///       </summary>
		/// <remarks>
		///       当只选中一个文档元素对象，则返回给文档元素对象，如果没有选中元素
		///       或者选中多个元素，则返回空。
		///       </remarks>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextElement SingleSelectedElement
		{
			get
			{
				if (InnerViewControl != null && Selection.ContentElements != null && Selection.ContentElements.Count == 1)
				{
					return Selection.ContentElements[0];
				}
				return null;
			}
		}

		/// <summary>
		///       当前插入点所在的输入域元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextInputFieldElement CurrentInputField
		{
			get
			{
				XTextInputFieldElement xTextInputFieldElement = GetCurrentElement(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
				CollectOuterReference(xTextInputFieldElement);
				return xTextInputFieldElement;
			}
		}

		/// <summary>
		///       当前插入点所在的单元格元素
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public XTextTableCellElement CurrentTableCell
		{
			get
			{
				XTextTableCellElement xTextTableCellElement = GetCurrentElement(typeof(XTextTableCellElement)) as XTextTableCellElement;
				CollectOuterReference(xTextTableCellElement);
				return xTextTableCellElement;
			}
		}

		/// <summary>
		///       当前插入点所在的表格行元素
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public XTextTableRowElement CurrentTableRow
		{
			get
			{
				XTextTableRowElement xTextTableRowElement = GetCurrentElement(typeof(XTextTableRowElement)) as XTextTableRowElement;
				CollectOuterReference(xTextTableRowElement);
				return xTextTableRowElement;
			}
		}

		/// <summary>
		///       当前插入点所在的表格元素
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextTableElement CurrentTable
		{
			get
			{
				XTextTableElement xTextTableElement = GetCurrentElement(typeof(XTextTableElement)) as XTextTableElement;
				CollectOuterReference(xTextTableElement);
				return xTextTableElement;
			}
		}

		/// <summary>
		///       当前用户信息
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[ComVisible(true)]
		[XmlIgnore]
		[Browsable(false)]
		public UserHistoryInfo CurrentUser => Document.CurrentUser;

		/// <summary>
		///       当前插入点所在的文档节对象
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextSectionElement CurrentSection
		{
			get
			{
				XTextSectionElement xTextSectionElement = GetCurrentElement(typeof(XTextSectionElement)) as XTextSectionElement;
				CollectOuterReference(xTextSectionElement);
				return xTextSectionElement;
			}
		}

		/// <summary>
		///       当前文档部分类型
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public PageContentPartyStyle CurrentContentPartyStyle
		{
			get
			{
				if (InnerViewControl == null)
				{
					return PageContentPartyStyle.Body;
				}
				return InnerViewControl.CurrentContentPartyStyle;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.CurrentContentPartyStyle = value;
				}
			}
		}

		/// <summary>
		///       鼠标悬停的元素
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextElement HoverElement
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.HoverElement;
			}
		}

		/// <summary>
		///       当前文本行
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public XTextLine CurrentLine
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.CurrentContentElement.CurrentLine;
			}
		}

		/// <summary>
		///       允许启用CollectOuterReference功能。
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(true)]
		[Browsable(false)]
		[DCInternal]
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableCollectOuterReference
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
		///       文档中包含的所有的复选框元素列表
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		[XmlIgnore]
		public XTextElementList CheckBoxes => GetElementsByType(typeof(XTextCheckBoxElement));

		/// <summary>
		///       文档中包含的所有的单选框元素列表
		///       </summary>
		[ComVisible(true)]
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public XTextElementList RadioBoxes => GetElementsByType(typeof(XTextRadioBoxElement));

		/// <summary>
		///       获得文档中文档节列表
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextElementList Sections => Document.Sections;

		/// <summary>
		///       从0开始计算的获得输入焦点的页码
		///       </summary>
		[Browsable(false)]
		public int FocusedPageIndexBase0
		{
			get
			{
				if (InnerViewControl == null)
				{
					return 0;
				}
				return InnerViewControl.FocusedPageIndexBase0;
			}
		}

		/// <summary>
		///       当前文档批注对象
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentComment CurrentComment
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return CommentManager.imethod_9();
			}
		}

		/// <summary>
		///       获得从1开始计算的当前列号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public int CurrentColumnIndex
		{
			get
			{
				if (InnerViewControl == null)
				{
					return 0;
				}
				return InnerViewControl.CurrentColumnIndex;
			}
		}

		/// <summary>
		///       当前行号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public int CurrentLineIndex
		{
			get
			{
				if (InnerViewControl == null)
				{
					return 0;
				}
				return InnerViewControl.CurrentLineIndex;
			}
		}

		/// <summary>
		///       获得从1开始计算的当前文本行在页中的序号
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[ComVisible(true)]
		public int CurrentLineIndexInPage
		{
			get
			{
				if (Document == null || Document.Content.CurrentLine == null)
				{
					return -1;
				}
				return Document.Content.CurrentLine.IndexInPage;
			}
		}

		/// <summary>
		///       获得从1开始计算的当前文本行在页中的内置序号
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int CurrentLinePrivateIndexInPage
		{
			get
			{
				if (Document == null || Document.Content.CurrentLine == null)
				{
					return -1;
				}
				return Document.Content.CurrentLine.PrivateIndexInPage;
			}
		}

		/// <summary>
		///       获得从1开始计算的当前文本行所在的页码
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		public int CurrentLineOwnerPageIndex
		{
			get
			{
				if (InnerViewControl == null)
				{
					return 0;
				}
				return InnerViewControl.CurrentLineOwnerPageIndex;
			}
		}

		/// <summary>
		///       文档选择的部分
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextSelection Selection
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.Selection;
			}
		}

		/// <summary>
		///       文档中被选中的文字
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public string SelectedText
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.Selection.Text;
			}
		}

		/// <summary>
		///       是否显示提示文本
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool ShowTooltip
		{
			get
			{
				return InnerViewControl.ShowTooltip;
			}
			set
			{
				InnerViewControl.ShowTooltip = value;
			}
		}

		/// <summary>
		///       内置的提示信息控件
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolTip TooltipControl => InnerViewControl.TooltipControl;

		/// <summary>
		///       元素提示文本信息列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public GClass97 ToolTips
		{
			get
			{
				return InnerViewControl.ToolTips;
			}
			set
			{
				InnerViewControl.ToolTips = value;
			}
		}

		/// <summary>
		///       即使在只读状态下是否能编辑文档批注
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool CommentEditableWhenReadonly
		{
			get
			{
				return InnerViewControl.CommentEditableWhenReadonly;
			}
			set
			{
				InnerViewControl.CommentEditableWhenReadonly = value;
			}
		}

		/// <summary>
		///       是否显示文档批注
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(FunctionControlVisibility.Auto)]
		[Category("Appearance")]
		public FunctionControlVisibility CommentVisibility
		{
			get
			{
				return InnerViewControl.CommentVisibility;
			}
			set
			{
				InnerViewControl.CommentVisibility = value;
			}
		}

		/// <summary>
		///       运行时是否显示文档批注
		///       </summary>
		[Browsable(false)]
		internal bool RuntimeCommentVisible => InnerViewControl.RuntimeCommentVisible;

		/// <summary>
		///       鼠标双击来编辑文档批注
		///       </summary>
		[Category("Behavior")]
		[DCPublishAPI]
		[Description("鼠标双击来编辑文档批注")]
		[DefaultValue(true)]
		public bool DoubleClickToEditComment
		{
			get
			{
				return InnerViewControl.DoubleClickToEditComment;
			}
			set
			{
				InnerViewControl.DoubleClickToEditComment = value;
			}
		}

		/// <summary>
		///       文档批注管理器
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GInterface9 CommentManager
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.CommentManager;
			}
		}

		/// <summary>
		///       强制预处理消息，用于避免某些情况下的堆栈溢出错误。
		///       </summary>
		/// <remarks>一般情况下，AxWriterControl会自动检测是否需要强制预处理消息。不排除在某些情况下
		///       无法自动检测而导致出现堆栈溢出的错误，此时可以设置这个属性来强制预处理消息。</remarks>
		[DCInternal]
		[Browsable(false)]
		[DefaultValue(false)]
		public bool ForcePreProcessMessage
		{
			get
			{
				return InnerViewControl.ForcePreProcessMessage;
			}
			set
			{
				InnerViewControl.ForcePreProcessMessage = value;
			}
		}

		/// <summary>
		///       布局停靠样式，仅仅向COM接口提供该属性
		///       </summary>
		[DCInternal]
		[DefaultValue(0)]
		[Obsolete("仅提供兼容性")]
		[Browsable(false)]
		[ComVisible(false)]
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
		///       命令控制器对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public WriterCommandControler CommandControler
		{
			get
			{
				return InnerViewControl.CommandControler;
			}
			set
			{
				InnerViewControl.CommandControler = value;
			}
		}

		/// <summary>
		///       打开文件使用的文件名过滤字符串
		///       </summary>
		[DCInternal]
		public static string OpenFileFilter
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       保存时使用的文件名过滤条件
		///       </summary>
		[DCInternal]
		public static string SaveFileFilter
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       自动保存管理器
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(false)]
		public IAutoSaveManager AutoSaveManager
		{
			get
			{
				return iautoSaveManager_0;
			}
			set
			{
				int num = 19;
				if (value == null || !(value.GetType().FullName == "DCSoft.Writer.Controls.LocalAutoSaveManager") || XTextDocument.smethod_13(GEnum6.const_15))
				{
					iautoSaveManager_0 = value;
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用, 指定的一次性使用的加载文件时的文件名。
		///        </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public string SpecifyLoadFileNameOnce
		{
			get
			{
				return InnerViewControl.SpecifyLoadFileNameOnce;
			}
			set
			{
				InnerViewControl.SpecifyLoadFileNameOnce = value;
			}
		}

		/// <summary>
		///       控件数据
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public override string Text
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.Text;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.Text = value;
				}
			}
		}

		/// <summary>
		///       RTF文本
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string RTFText
		{
			get
			{
				return InnerViewControl.RTFText;
			}
			set
			{
				InnerViewControl.RTFText = value;
			}
		}

		/// <summary>
		///       未格式化的XML文本
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public string XMLTextUnFormatted => InnerViewControl.XMLTextUnFormatted;

		/// <summary>
		///       XML文本
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public string XMLText
		{
			get
			{
				return InnerViewControl.XMLText;
			}
			set
			{
				InnerViewControl.XMLText = value;
			}
		}

		/// <summary>
		///       获得文档XML内容
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string XMLTextWithDocumentState
		{
			get
			{
				return InnerViewControl.XMLTextWithDocumentState;
			}
			set
			{
				InnerViewControl.XMLTextWithDocumentState = value;
			}
		}

		/// <summary>
		///       生成用于保存的XML字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public string XMLTextForSave
		{
			get
			{
				return InnerViewControl.XMLTextForSave;
			}
			set
			{
				InnerViewControl.XMLTextForSave = value;
			}
		}

		/// <summary>
		///       加载文档时显示等待界面
		///       </summary>
		[DCInternal]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowWaittingUIForLoadingDocument
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		[Browsable(false)]
		[DCInternal]
		public Image CustomLogoImage
		{
			get
			{
				return image_0;
			}
			set
			{
				image_0 = value;
			}
		}

		/// <summary>
		///       命令状态需要刷新标识
		///       </summary>
		/// <remarks>
		///       当不能启用控件事件或者无法响应控件事件时，可以使用定时器来判断本属性值，如果本属性值为true，
		///       则需要刷新应用程序界面按钮的状态，然后设置本属性值为false。
		///       比如
		///       void Timer_Intervel()
		///       {
		///           if( myWriterControl.CommandStateNeedRefreshFlag == true )
		///           {
		///               myWriterControl.CommandStateNeedRefreshFlag = false ;
		///               ---- 此处编写刷新菜单按钮状态的代码 ----
		///           }
		///       }
		///       在DCWriter内部会根据实时情况来自动设置本属性值为true，以标记应用程序需要刷新按钮状态了。
		///       </remarks>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CommandStateNeedRefreshFlag
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       用户界面工具对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCUITools UITools
		{
			get
			{
				return AppHost.UITools;
			}
			set
			{
				AppHost.Services.AddService(typeof(DCUITools), value);
			}
		}

		/// <summary>
		///       编辑器正在显示某种用户界面
		///       </summary>
		[DCPublishAPI]
		[ReadOnly(true)]
		[Browsable(false)]
		public bool ShowingUI
		{
			get
			{
				return InnerViewControl.ShowingUI;
			}
			set
			{
				InnerViewControl.ShowingUI = value;
			}
		}

		/// <summary>
		///        允许执行StartEditContent事件
		///       </summary>
		[Category("Behavior")]
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool EnableUIEventStartEditContent
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.EnableUIEventStartEditContent;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.EnableUIEventStartEditContent = value;
				}
			}
		}

		/// <summary>
		///       文档内容导航者
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public DocumentNavigator Navigator => InnerViewControl.Navigator;

		/// <summary>
		///       当前光标位置所在的导航节点对象
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		public NavigateNode CurrentNavigateNode => InnerViewControl.CurrentNavigateNode;

		/// <summary>
		///       状态文本
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public string StatusText
		{
			get
			{
				return InnerViewControl.StatusText;
			}
			set
			{
				InnerViewControl.StatusText = value;
			}
		}

		/// <summary>
		///       配套的工具窗体列表
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public GClass255 ToolWindows => InnerViewControl.ToolWindows;

		/// <summary>
		///       销毁控件的时候是否自动销毁文档对象
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public bool AutoDisposeDocument
		{
			get
			{
				return InnerViewControl != null && InnerViewControl.AutoDisposeDocument;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.AutoDisposeDocument = value;
				}
			}
		}

		/// <summary>
		///       销毁控件的时候是否自动销毁快捷菜单
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoDisposeContextMenu
		{
			get
			{
				if (InnerViewControl == null)
				{
					return true;
				}
				return InnerViewControl.AutoDisposeContextMenu;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.AutoDisposeContextMenu = value;
				}
			}
		}

		/// <summary>
		///       批注使用的快键菜单
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public ContextMenuStrip CommentContextMenuStrip
		{
			get
			{
				return InnerViewControl.CommentContextMenuStrip;
			}
			set
			{
				InnerViewControl.CommentContextMenuStrip = value;
			}
		}

		/// <summary>
		///       快捷菜单管理器
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public IContextMenuStripManager ContextMenuManager
		{
			get
			{
				return InnerViewControl.ContextMenuManager;
			}
			set
			{
				InnerViewControl.ContextMenuManager = value;
			}
		}

		/// <summary>
		///       允许启用ApplyLocalDocumentOptions功能。
		///       </summary>
		[DefaultValue(false)]
		[DCInternal]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		public bool AllowApplyLocalDocumentOptions
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       选择状态版本号。任何选择区域或插入点的改变都会增加该属性值。
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCInternal]
		[ComVisible(true)]
		public int SelectionVersion
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       全局调试设置
		///       </summary>
		[DCInternal]
		public GlobalDebugConfig DebugConfig
		{
			get
			{
				if (globalDebugConfig_0 == null)
				{
					globalDebugConfig_0 = GlobalDebugConfig.CreateInstance();
				}
				return globalDebugConfig_0;
			}
		}

		/// <summary>
		///       授权信息显示模式
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(true)]
		[DefaultValue(DCLicenceDisplayMode.PageHeader)]
		public DCLicenceDisplayMode LicenceDisplayMode
		{
			get
			{
				return _LicenceDisplayMode;
			}
			set
			{
				_LicenceDisplayMode = value;
			}
		}

		/// <summary>
		///       在进度等待界面中显示注册信息
		///       </summary>
		[DefaultValue(false)]
		[DCInternal]
		[Obsolete("本属性已经废除了。")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowRegisterInfoInProgressUI
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		///       最后一次操作产生的系统警告信息列表
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		public SystemAlertInfoList LastAlertInfos => Document.LastAlertInfos;

		/// <summary>
		///       控件背景色字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public string BackColorString
		{
			get
			{
				return ColorTranslator.ToHtml(BackColor);
			}
			set
			{
				BackColor = XMLSerializeHelper.StringToColor(value, SystemColors.Control);
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				myViewControl.BackColor = value;
			}
		}

		/// <summary>
		///       时间提供者对象
		///       </summary>
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("请使用SynchroServerTime()")]
		public IDateTimeService DateTimeService
		{
			get
			{
				return (IDateTimeService)AppHost.Services.GetService(typeof(IDateTimeService));
			}
			set
			{
				AppHost.Services.AddService(typeof(IDateTimeService), value);
			}
		}

		/// <summary>
		///       开发者工具是否可见
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool DeveloperToolsVisible
		{
			get
			{
				if (base.IsDisposed || !base.IsHandleCreated)
				{
					return false;
				}
				try
				{
					return mySplitContainer != null && !mySplitContainer.Panel2Collapsed && control_0 != null;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
					return false;
				}
			}
			set
			{
				int num = 5;
				mySplitContainer.Panel2Collapsed = !value;
				if (!mySplitContainer.Panel2Collapsed)
				{
					if (control_0 == null)
					{
						control_0 = AppHost.Tools.CreateDeveloperToolsControl();
						if (control_0 != null)
						{
							((GInterface18)control_0).WriterControl = this;
							control_0.Dock = DockStyle.Fill;
						}
						if (control_0 != null)
						{
							mySplitContainer.Panel2.Controls.Add(control_0);
						}
					}
					if (control_0 != null)
					{
						control_0.BackColor = SystemColors.Control;
						((GInterface18)control_0).imethod_0();
					}
				}
				else
				{
					((GInterface18)control_0).imethod_1();
					if (CommandControler != null)
					{
						CommandControler.UpdateBindingControlStatus("DeveloperTools");
					}
				}
			}
		}

		[Obsolete("请使用DocumentOptions.BehaviorOptions.EnableEditElementValue")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool EnableEditElementValue
		{
			get
			{
				return DocumentOptions.BehaviorOptions.EnableEditElementValue;
			}
			set
			{
				DocumentOptions.BehaviorOptions.EnableEditElementValue = value;
			}
		}

		/// <summary>
		///       快键菜单
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public new ContextMenuStrip ContextMenuStrip
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.ContextMenuStrip;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.ContextMenuStrip = value;
				}
			}
		}

		/// <summary>
		///       快键菜单
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public new ContextMenu ContextMenu
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.ContextMenu;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.ContextMenu = value;
				}
			}
		}

		/// <summary>
		///       当前页面边框颜色值
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		[DCInternal]
		public string CurrentPageBorderColorString
		{
			get
			{
				return ColorTranslator.ToHtml(CurrentPageBorderColor);
			}
			set
			{
				CurrentPageBorderColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       当前页面边框线颜色
		///       </summary>
		[DCPublishAPI]
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "Black")]
		public Color CurrentPageBorderColor
		{
			get
			{
				return InnerViewControl.CurrentPageBorderColor;
			}
			set
			{
				InnerViewControl.CurrentPageBorderColor = value;
			}
		}

		/// <summary>
		///       绘图单位
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GraphicsUnit GraphicsUnit
		{
			get
			{
				return InnerViewControl.GraphicsUnit;
			}
			set
			{
				InnerViewControl.GraphicsUnit = value;
			}
		}

		/// <summary>
		///       移动光标时是否自动滚动到光标区域
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool MoveCaretWithScroll
		{
			get
			{
				return InnerViewControl.MoveCaretWithScroll;
			}
			set
			{
				InnerViewControl.MoveCaretWithScroll = value;
			}
		}

		/// <summary>
		///       获取或设置一个值，该值指示在控件中按 TAB 键时，是否在控件中键入一个 TAB 字符，而不是按选项卡的顺序将焦点移动到下一个控件。
		///       </summary>
		[Category("Behavior")]
		[DCPublishAPI]
		[DefaultValue(true)]
		public bool AcceptsTab
		{
			get
			{
				return InnerViewControl.AcceptsTab;
			}
			set
			{
				InnerViewControl.AcceptsTab = value;
			}
		}

		/// <summary>
		///       是否强制显示光标而不管控件是否获得输入焦点
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(false)]
		public bool ForceShowCaret
		{
			get
			{
				return InnerViewControl.ForceShowCaret;
			}
			set
			{
				InnerViewControl.ForceShowCaret = value;
			}
		}

		/// <summary>
		///       标尺是否可见,为了提高兼容性，默认不显示标尺。
		///       </summary>
		[Category("Appearance")]
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool RuleVisible
		{
			get
			{
				return bool_6;
			}
			set
			{
				if (bool_6 != value)
				{
					bool_6 = value;
					method_17();
				}
			}
		}

		/// <summary>
		///       标尺背景色
		///       </summary>
		[DCPublishAPI]
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "155, 187, 227")]
		public Color RuleBackColor
		{
			get
			{
				return ctlHRule.BackColor;
			}
			set
			{
				ctlHRule.BackColor = value;
				ctlVRule.BackColor = value;
			}
		}

		/// <summary>
		///       标尺是否可用
		///       </summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[DCPublishAPI]
		public bool RuleEnabled
		{
			get
			{
				return ctlHRule.Enabled;
			}
			set
			{
				ctlHRule.Enabled = value;
				ctlHRule.Enabled = value;
			}
		}

		/// <summary>
		///       调试用的标记
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DebugFlag
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		/// <summary>
		///       调试用的静态标记
		///       </summary>
		[Browsable(false)]
		public static int StaticDebugFlag
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
		///       本控件不能设置自动滚动
		///       </summary>
		[Browsable(false)]
		public override bool AutoScroll
		{
			get
			{
				return false;
			}
			set
			{
				base.AutoScroll = false;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new Size AutoScrollMinSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// <summary>
		///       DCWriter内部使用。内置的文档视图控件
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public WriterViewControl InnerViewControl => myViewControl;

		/// <summary>
		///       正在更新用户界面，用户界面被锁定了。
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool IsUpdating
		{
			get
			{
				if (myViewControl == null)
				{
					return true;
				}
				return myViewControl.IsUpdating;
			}
		}

		/// <summary>
		///       知识库文件URL
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(null)]
		public string KBLibraryUrl
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.KBLibraryUrl;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.KBLibraryUrl = value;
				}
			}
		}

		/// <summary>
		///       知识库对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		[DCPublishAPI]
		public KBLibrary KBLibrary
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				KBLibrary kBLibrary = InnerViewControl.KBLibrary;
				if (kBLibrary == null && method_46(WriterControlWebMethodTypes.GetKBLibrary))
				{
					kBLibrary = WebServiceClient.GetKBLibrary();
					InnerViewControl.KBLibrary = kBLibrary;
				}
				return kBLibrary;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.KBLibrary = value;
				}
			}
		}

		/// <summary>
		///       返回内核版本号的静态属性
		///       </summary>
		[DCPublishAPI]
		public static string StaticCoreVersion => FormatUtils.ToYYYY_MM_DD(DCPublishDateAttribute.ValueForCurrentDomain);

		/// <summary>
		///       控件是否处于等待模式
		///       </summary>
		[Obsolete("请不要使用该属性")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		public bool WaittingMode
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.WaittingMode;
			}
			set
			{
			}
		}

		/// <summary>
		///       是否作为ActiveX控件的模式运行
		///       </summary>
		[ComVisible(false)]
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual bool IsAxControl => false;

		/// <summary>
		///       自动设置文档的默认字体
		///       </summary>
		/// <remarks>若该属性值为true，则编辑器会自动将控件的字体和前景色设置
		///       到文档的默认字体和文本颜色。修改本属性值不会立即更新文档视图，
		///       此时需要调用“UpdateDefaultFont( true )”来更新文档视图。</remarks>
		[Category("Appearance")]
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool AutoSetDocumentDefaultFont
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.AutoSetDocumentDefaultFont;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.AutoSetDocumentDefaultFont = value;
				}
			}
		}

		/// <summary>
		///       承载的控件管理器
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public GInterface20 ControlHostManger
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.ControlHostManger;
			}
		}

		/// <summary>
		///       移动焦点使用的快捷键
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(MoveFocusHotKeys.None)]
		[Description("移动输入焦点使用的快捷键模式")]
		[Category("Behavior")]
		public MoveFocusHotKeys MoveFocusHotKey
		{
			get
			{
				if (InnerViewControl == null)
				{
					return MoveFocusHotKeys.None;
				}
				return InnerViewControl.MoveFocusHotKey;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.MoveFocusHotKey = value;
				}
			}
		}

		/// <summary>
		///       初始化是用的参数列表，格式为“参数名:参数值;参数名:参数值;”。
		///       </summary>
		[DefaultValue(null)]
		[DCInternal]
		[Browsable(false)]
		[Category("Data")]
		public string InitalizeParameterValues
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.InitalizeParameterValues;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.InitalizeParameterValues = value;
				}
			}
		}

		/// <summary>
		///       列表缓存对象
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCListItemCollectionBuffer ListItemsBuffer
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.ListItemsBuffer;
			}
		}

		/// <summary>
		///       最后一次用户界面事件的发生时间
		///       </summary>
		/// <remarks>这里的用户界面事件包括鼠标键盘事件、OLE拖拽事件，
		///       应用程序可以根据这个属性值来实现超时锁定用户界面的功能。</remarks>
		[Browsable(false)]
		[DCPublishAPI]
		public DateTime LastUIEventTime
		{
			get
			{
				if (InnerViewControl == null)
				{
					return DateTime.MinValue;
				}
				return InnerViewControl.LastUIEventTime;
			}
		}

		/// <summary>
		///       文档内容只读标记
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		[Category("Behavior")]
		public bool Readonly
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.Readonly;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.Readonly = value;
				}
			}
		}

		/// <summary>
		///       运行时的控件内容只读设置
		///       </summary>
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public bool RuntimeReadonly
		{
			get
			{
				if (InnerViewControl != null)
				{
					return InnerViewControl.RuntimeReadonly;
				}
				return false;
			}
		}

		/// <summary>
		///       页眉页脚是否只读
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[DCPublishAPI]
		public bool HeaderFooterReadonly
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.HeaderFooterReadonly;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.HeaderFooterReadonly = value;
				}
			}
		}

		/// <summary>
		///       控件是否处于调试模式
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool InDesignMode
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.InDesignMode;
			}
		}

		/// <summary>
		///       表单视图模式
		///       </summary>
		[Category("Behavior")]
		[DCPublishAPI]
		[DefaultValue(FormViewMode.Disable)]
		public FormViewMode FormView
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_119))
				{
					return FormViewMode.Disable;
				}
				if (InnerViewControl == null)
				{
					return FormViewMode.Disable;
				}
				return InnerViewControl.FormView;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.FormView = value;
				}
			}
		}

		/// <summary>
		///       服务器对象
		///       </summary>
		[ComVisible(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public object ServerObject
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.ServerObject;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.ServerObject = value;
				}
			}
		}

		/// <summary>
		///       文档设置
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		[DCPublishAPI]
		public DocumentOptions DocumentOptions
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentOptions;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.DocumentOptions = value;
				}
			}
		}

		/// <summary>
		///       文档视图选项
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DocumentViewOptions DocumentViewOptions
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentOptions.ViewOptions;
			}
		}

		/// <summary>
		///       文档行为选项
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public DocumentBehaviorOptions DocumentBehaviorOptions
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentOptions.BehaviorOptions;
			}
		}

		/// <summary>
		///       文档编辑选项
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		public DocumentEditOptions DocumentEditOptions
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentOptions.EditOptions;
			}
		}

		/// <summary>
		///       文档安全选项
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentSecurityOptions DocumentSecurityOptions
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentOptions.SecurityOptions;
			}
		}

		/// <summary>
		///       文档设置XML字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[Browsable(false)]
		[ComVisible(true)]
		public string DocumentOptionsXML
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentOptionsXML;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.DocumentOptionsXML = value;
				}
			}
		}

		/// <summary>
		///       违禁关键字
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		[DCPublishAPI]
		public string ExcludeKeywords
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.ExcludeKeywords;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.ExcludeKeywords = value;
				}
			}
		}

		/// <summary>
		///       文档控制器
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCInternal]
		public DocumentControler DocumentControler
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DocumentControler;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.DocumentControler = value;
				}
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public WriterAppHost AppHost
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.AppHost;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.AppHost = value;
				}
			}
		}

		/// <summary>
		///       为格式刷而准备的文档格式信息对象,DCWriter内部使用。
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		[DCInternal]
		public CurrentContentStyleInfo StyleInfoForFormatBrush
		{
			get
			{
				return InnerViewControl.StyleInfoForFormatBrush;
			}
			set
			{
				InnerViewControl.StyleInfoForFormatBrush = value;
			}
		}

		/// <summary>
		///       获得将文档单位转换为屏幕像素单位的比率
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public float RateOfDocumentUnitToPixel
		{
			get
			{
				if (InnerViewControl == null)
				{
					return 1f;
				}
				return InnerViewControl.RateOfDocumentUnitToPixel;
			}
		}

		/// <summary>
		///       文档内容视图高度
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public float ContentViewHeight
		{
			get
			{
				if (InnerViewControl == null)
				{
					return 0f;
				}
				return InnerViewControl.ContentViewHeight;
			}
		}

		/// <summary>
		///       获得各个表单数据组成的字符串，采用“名称=值&amp;名称=值&amp;名称=值”的形式，
		///       模仿HTML提交表单数据的字符串格式，遇到HTML特殊字符会进行转义处理。
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string FormValuesString
		{
			get
			{
				int num = 14;
				if (InnerViewControl == null)
				{
					return null;
				}
				Hashtable formValues = Document.FormValues;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string key in formValues.Keys)
				{
					string s = (string)formValues[key];
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append("&");
					}
					stringBuilder.Append(HttpUtility.HtmlEncode(key));
					stringBuilder.Append("=");
					stringBuilder.Append(HttpUtility.HtmlEncode(s));
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       表单数据组成在字典
		///       </summary>
		[ComVisible(false)]
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Hashtable FormValues
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.FormValues;
			}
		}

		/// <summary>
		///       XML格式的表单数据字典
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string FormValuesXml
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				return Document.FormValuesXml;
			}
		}

		/// <summary>
		///       表单数据组成的字符串数组，序号为偶数的元素为名称，序号为奇数的元素为数值。
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		public string[] FormValuesArray
		{
			get
			{
				if (Document == null)
				{
					return null;
				}
				Hashtable formValues = Document.FormValues;
				List<string> list = new List<string>();
				foreach (string key in formValues.Keys)
				{
					list.Add(key);
					list.Add((string)formValues[key]);
				}
				return list.ToArray();
			}
		}

		/// <summary>
		///       当选择了文档内容时隐藏光标
		///       </summary>
		[DefaultValue(true)]
		[DCPublishAPI]
		[Category("Appearance")]
		public bool HideCaretWhenHasSelection
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.HideCaretWhenHasSelection;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.HideCaretWhenHasSelection = value;
				}
			}
		}

		/// <summary>
		///       文档中当前元素或被选择区域的开始位置在编辑器控件客户区中的坐标
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public Point SelectionStartPosition
		{
			get
			{
				if (InnerViewControl == null)
				{
					return Point.Empty;
				}
				return InnerViewControl.SelectionStartPosition;
			}
		}

		/// <summary>
		///        表示当前插入点位置信息的字符串
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public string PositionInfoText
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.PositionInfoText;
			}
		}

		/// <summary>
		///       正在编辑文档元素数值
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public bool IsEditingElementValue
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.IsEditingElementValue;
			}
		}

		/// <summary>
		///       可以被拖拽的文档元素
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		public XTextElement DragableElement
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.DragableElement;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.DragableElement = value;
				}
			}
		}

		/// <summary>
		///       拖拽句柄边界
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		public Rectangle DragableHandleBounds
		{
			get
			{
				if (InnerViewControl == null)
				{
					return Rectangle.Empty;
				}
				return InnerViewControl.DragableHandleBounds;
			}
		}

		/// <summary>
		///       绝对的是否占有焦点
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public bool AbsoluteFocused
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.AbsoluteFocused;
			}
		}

		/// <summary>
		///       在控件的获得/失去焦点事件时是否触发文档的获得/失去焦点事件
		///       </summary>
		[DefaultValue(true)]
		[DCPublishAPI]
		public bool RaiseDocumentFoucsEventWhenControlFocusEvent
		{
			get
			{
				if (InnerViewControl == null)
				{
					return false;
				}
				return InnerViewControl.RaiseDocumentFoucsEventWhenControlFocusEvent;
			}
			set
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.RaiseDocumentFoucsEventWhenControlFocusEvent = value;
				}
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public TextWindowsFormsEditorHost EditorHost
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.EditorHost;
			}
		}

		/// <summary>
		///       处于页面视图模式时各个页面间的距离，像素为单位
		///       </summary>
		[Category("Appearance")]
		[DCPublishAPI]
		[DefaultValue(20)]
		public int PageSpacing
		{
			get
			{
				return InnerViewControl.PageSpacing;
			}
			set
			{
				InnerViewControl.PageSpacing = value;
			}
		}

		/// <summary>
		///       页面集合
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintPageCollection Pages
		{
			get
			{
				return InnerViewControl.Pages;
			}
			set
			{
				InnerViewControl.Pages = value;
			}
		}

		/// <summary>
		///       设置或返回从1开始的当前页号
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public int PageIndex
		{
			get
			{
				return InnerViewControl.PageIndex;
			}
			set
			{
				InnerViewControl.PageIndex = value;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public int PageCount => InnerViewControl.PageCount;

		/// <summary>
		///       从1开始计算的当前页号
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int CurrentPageIndex
		{
			get
			{
				return InnerViewControl.CurrentPageIndex;
			}
			set
			{
				InnerViewControl.CurrentPageIndex = value;
			}
		}

		/// <summary>
		///       当前页对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintPage CurrentPage
		{
			get
			{
				return InnerViewControl.CurrentPage;
			}
			set
			{
				InnerViewControl.CurrentPage = value;
			}
		}

		/// <summary>
		///       阅读版式视图模式
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool ReadViewMode
		{
			get
			{
				return InnerViewControl.ReadViewMode;
			}
			set
			{
				InnerViewControl.ReadViewMode = value;
			}
		}

		/// <summary>
		///       页背景色
		///       </summary>
		[DefaultValue(typeof(Color), "Window")]
		[DCPublishAPI]
		[Category("Appearance")]
		public Color PageBackColor
		{
			get
			{
				return InnerViewControl.PageBackColor;
			}
			set
			{
				InnerViewControl.PageBackColor = value;
			}
		}

		/// <summary>
		///       页面背景文字字符串
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[Browsable(false)]
		public string PageBackColorString
		{
			get
			{
				return ColorTranslator.ToHtml(PageBackColor);
			}
			set
			{
				PageBackColor = XMLSerializeHelper.StringToColor(value, SystemColors.Window);
			}
		}

		/// <summary>
		///       是否显示页眉页脚标记
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(HeaderFooterFlagVisible.None)]
		public HeaderFooterFlagVisible HeaderFooterFlagVisible
		{
			get
			{
				return InnerViewControl.HeaderFooterFlagVisible;
			}
			set
			{
				InnerViewControl.HeaderFooterFlagVisible = value;
			}
		}

		/// <summary>
		///       页面显示模式
		///       </summary>
		[DefaultValue(PageViewMode.Page)]
		[Browsable(false)]
		[DCPublishAPI]
		public PageViewMode ViewMode
		{
			get
			{
				if (InnerViewControl == null)
				{
					return PageViewMode.Page;
				}
				return InnerViewControl.ViewMode;
			}
			set
			{
				if (value == PageViewMode.AutoLine)
				{
					if (!XTextDocument.smethod_13(GEnum6.const_114))
					{
						return;
					}
				}
				else if (value == PageViewMode.Page)
				{
					if (!XTextDocument.smethod_13(GEnum6.const_115))
					{
						return;
					}
				}
				else if ((value == PageViewMode.Normal || value == PageViewMode.NormalCenter) && !XTextDocument.smethod_13(GEnum6.const_116))
				{
					return;
				}
				if (InnerViewControl.ViewMode != value)
				{
					InnerViewControl.ViewMode = value;
					method_17();
				}
			}
		}

		/// <summary>
		///       从0开始的计算的开始显示的页码号,只有处于分页视图模式下该属性才有效。小于0则不启用该设置。
		///       </summary>
		[DCPublishAPI]
		[Category("Appearance")]
		[DefaultValue(-1)]
		public int StartPageIndex
		{
			get
			{
				return InnerViewControl.StartPageIndex;
			}
			set
			{
				InnerViewControl.StartPageIndex = value;
			}
		}

		/// <summary>
		///       从0开始计算的最后显示的页码号,为0表示没有设置。只有处于分页视图模式下该属性才有效。小于0则不启用该设置。
		///       </summary>
		[DefaultValue(-1)]
		[DCPublishAPI]
		[Category("Appearance")]
		public int EndPageIndex
		{
			get
			{
				return InnerViewControl.EndPageIndex;
			}
			set
			{
				InnerViewControl.EndPageIndex = value;
			}
		}

		/// <summary>
		///       使用鼠标拖拽滚动模式标记
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal bool MouseDragScroll
		{
			get
			{
				return InnerViewControl.MouseDragScroll;
			}
			set
			{
				InnerViewControl.MouseDragScroll = value;
			}
		}

		/// <summary>
		///       当前是否处于插入模式,若处于插入模式,则光标比较细,否则处于改写模式,光标比较粗
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		public virtual bool InsertMode
		{
			get
			{
				return InnerViewControl.InsertMode;
			}
			set
			{
				InnerViewControl.InsertMode = value;
			}
		}

		/// <summary>
		///       控件正在加载标记
		///       </summary>
		[Browsable(false)]
		internal bool ControlLoading => InnerViewControl.ControlLoading;

		/// <summary>
		///       页面边框颜色值
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public string PageBorderColorString
		{
			get
			{
				return ColorTranslator.ToHtml(PageBorderColor);
			}
			set
			{
				PageBorderColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       页面边框线颜色
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "Black")]
		[DCPublishAPI]
		public Color PageBorderColor
		{
			get
			{
				return InnerViewControl.PageBorderColor;
			}
			set
			{
				InnerViewControl.PageBorderColor = value;
			}
		}

		/// <summary>
		///       X方向缩放率
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		public float XZoomRate
		{
			get
			{
				return InnerViewControl.XZoomRate;
			}
			set
			{
				InnerViewControl.XZoomRate = value;
			}
		}

		/// <summary>
		///       Y方向缩放率
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public float YZoomRate
		{
			get
			{
				return InnerViewControl.YZoomRate;
			}
			set
			{
				InnerViewControl.YZoomRate = value;
			}
		}

		/// <summary>
		///       设置自动缩放
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool AutoZoom
		{
			get
			{
				return InnerViewControl.AutoZoom;
			}
			set
			{
				InnerViewControl.AutoZoom = value;
			}
		}

		/// <summary>
		///       控件本地的Windows消息过滤器列表
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCWinMessageFilterList LocalMessageFilters
		{
			get
			{
				if (dcwinMessageFilterList_0 == null)
				{
					dcwinMessageFilterList_0 = new DCWinMessageFilterList();
				}
				return dcwinMessageFilterList_0;
			}
		}

		/// <summary>
		///       启用输入法
		///       </summary>
		protected override bool CanEnableIme => true;

		/// <summary>
		///       页面标题位置
		///       </summary>
		[DefaultValue(PageTitlePosition.TopLeft)]
		[Category("Appearance")]
		[DCPublishAPI]
		public PageTitlePosition PageTitlePosition
		{
			get
			{
				return InnerViewControl.PageTitlePosition;
			}
			set
			{
				InnerViewControl.PageTitlePosition = value;
			}
		}

		/// <summary>
		///       注册码文件URL地址
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Data")]
		[DefaultValue(null)]
		[DCPublishAPI]
		[Browsable(false)]
		public string RegisterCodeFileUrl
		{
			get
			{
				return InnerViewControl.RegisterCodeFileUrl;
			}
			set
			{
				InnerViewControl.RegisterCodeFileUrl = value;
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		[Browsable(true)]
		[Category("Data")]
		public string RegisterCode
		{
			get
			{
				return InnerViewControl.RegisterCode;
			}
			set
			{
				InnerViewControl.RegisterCode = value;
			}
		}

		/// <summary>
		///       显示在已经注册的页码标题文本后面的额外的页码标题文本。比如“授权给XX医院使用”。
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[DCPublishAPI]
		public string AdditionPageTitle
		{
			get
			{
				return InnerViewControl.AdditionPageTitle;
			}
			set
			{
				InnerViewControl.AdditionPageTitle = value;
			}
		}

		/// <summary>
		///       对话框标题前缀
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public string DialogTitlePrefix => InnerViewControl.DialogTitlePrefix;

		/// <summary>
		///       标记图片
		///       </summary>
		[DCInternal]
		public static Bitmap DCLogonImage => WriterViewControl.DCLogonImage;

		/// <summary>
		///       DOM使用的图标列表
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		public DCStdImageList DomImageList => InnerViewControl.DomImageList;

		/// <summary>
		///       高亮度显示区域
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCPublishAPI]
		public HighlightInfo HighlightRange
		{
			get
			{
				return InnerViewControl.HighlightRange;
			}
			set
			{
				InnerViewControl.HighlightRange = value;
			}
		}

		/// <summary>
		///       高亮度显示区域
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public HighlightInfoList HighlightRanges
		{
			get
			{
				return InnerViewControl.HighlightRanges;
			}
			set
			{
				InnerViewControl.HighlightRanges = value;
			}
		}

		/// <summary>
		///       页面设置
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XPageSettings PageSettings
		{
			get
			{
				return InnerViewControl.PageSettings;
			}
			set
			{
				InnerViewControl.PageSettings = value;
			}
		}

		/// <summary>
		///       区域选择打印的信息
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCInternal]
		public BoundsSelectionPrintInfo BoundsSelection
		{
			get
			{
				return InnerViewControl.BoundsSelection;
			}
			set
			{
				InnerViewControl.BoundsSelection = value;
			}
		}

		/// <summary>
		///       扩展视图模式
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(WriterControlExtViewMode.Normal)]
		[DCPublishAPI]
		public WriterControlExtViewMode ExtViewMode
		{
			get
			{
				return InnerViewControl.ExtViewMode;
			}
			set
			{
				InnerViewControl.ExtViewMode = value;
			}
		}

		/// <summary>
		///       全局的默认打印机名称
		///       </summary>
		[DCPublishAPI]
		public static string GlobalDefaultPrinterName
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
		///       默认打印机名称
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string DefaultPrinterName
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
		///       运行时用的默认打印机名称
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public string RuntimeDefaultPrinterName => string_2;

		/// <summary>
		///       最后一次打印结果
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintResult LastPrintResult
		{
			get
			{
				return InnerViewControl.LastPrintResult;
			}
			set
			{
				InnerViewControl.LastPrintResult = value;
			}
		}

		/// <summary>
		///       最后一次的打印位置
		///       </summary>
		/// <remarks>
		///       一般本属性和控件的JumpPrintPosition属性搭配使用.
		///       比如在打印后存储该属性值,下次打开文档后,再设置JumpPrintPosition属性值.
		///       能设置上次打印结束的位置为续打起始位置.
		///       </remarks>
		[DCPublishAPI]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[DefaultValue(0)]
		public int LastPrintPosition
		{
			get
			{
				return InnerViewControl.LastPrintPosition;
			}
			set
			{
				InnerViewControl.LastPrintPosition = value;
			}
		}

		/// <summary>
		///       续打信息
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public JumpPrintInfo JumpPrint
		{
			get
			{
				return InnerViewControl.JumpPrint;
			}
			set
			{
				InnerViewControl.JumpPrint = value;
			}
		}

		/// <summary>
		///       是否允许续打
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool EnableJumpPrint
		{
			get
			{
				return InnerViewControl.EnableJumpPrint;
			}
			set
			{
				InnerViewControl.EnableJumpPrint = value;
			}
		}

		/// <summary>
		///       续打位置
		///       </summary>
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public float JumpPrintPosition
		{
			get
			{
				return InnerViewControl.JumpPrintPosition;
			}
			set
			{
				InnerViewControl.JumpPrintPosition = value;
			}
		}

		/// <summary>
		///       续打结束位置
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public float JumpPrintEndPosition
		{
			get
			{
				return InnerViewControl.JumpPrintEndPosition;
			}
			set
			{
				InnerViewControl.JumpPrintEndPosition = value;
			}
		}

		/// <summary>
		///       用户修改痕迹信息列表
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[ComVisible(true)]
		public UserTrackInfoList UserTrackInfos
		{
			get
			{
				if (InnerViewControl == null)
				{
					return null;
				}
				return InnerViewControl.UserTrackInfos;
			}
		}

		/// <summary>
		///       是否以管理员模式运行
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		public bool IsAdministrator
		{
			get
			{
				return InnerViewControl.IsAdministrator;
			}
			set
			{
				InnerViewControl.IsAdministrator = value;
			}
		}

		/// <summary>
		///       每打开文档时自动进行用户登录
		///       </summary>
		[Category("Behavior")]
		[Obsolete("★★★★★本属性已过期，跪求改用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		[DefaultValue(false)]
		public bool AutoUserLogin
		{
			get
			{
				return InnerViewControl.AutoUserLogin;
			}
			set
			{
				InnerViewControl.AutoUserLogin = value;
			}
		}

		/// <summary>
		///       执行自动登录时使用的用户登录信息
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("请调用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public UserLoginInfo AutoUserLoginInfo
		{
			get
			{
				return InnerViewControl.AutoUserLoginInfo;
			}
			set
			{
				InnerViewControl.AutoUserLoginInfo = value;
			}
		}

		/// <summary>
		///       数据对象应用范围。本属性实际上引用了DocumentOptions.BehaviorOptions.DataObjectRange属性.
		///       </summary>
		/// <remarks>
		/// </remarks>
		[DCPublishAPI]
		[DefaultValue(WriterDataObjectRange.OS)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Behavior")]
		public WriterDataObjectRange DataObjectRange
		{
			get
			{
				return DocumentOptions.BehaviorOptions.DataObjectRange;
			}
			set
			{
				DocumentOptions.BehaviorOptions.DataObjectRange = value;
			}
		}

		/// <summary>
		///       剪切板
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public ClipboardProvider Clipboard
		{
			get
			{
				return clipboardProvider_0;
			}
			set
			{
				clipboardProvider_0 = value;
			}
		}

		/// <summary>
		///       取消下一次的KePress事件
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[Browsable(false)]
		public bool IgnoreNextKeyPressEvent
		{
			get
			{
				return InnerViewControl.IgnoreNextKeyPressEventOnce;
			}
			set
			{
				InnerViewControl.IgnoreNextKeyPressEventOnce = value;
			}
		}

		/// <summary>
		///       延时截屏使用的对话框,DCWriter内部使用.
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		[Browsable(false)]
		public dlgPrepareScreenSnapshot DlgSnapshotDelay
		{
			get
			{
				return InnerViewControl.DlgSnapshotDelay;
			}
			set
			{
				InnerViewControl.DlgSnapshotDelay = value;
			}
		}

		/// <summary>
		///       Web服务页面地址
		///       </summary>
		[ComVisible(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[DCPublishAPI]
		public string WebServiceUrl
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
				if (iwriterControlWebServiceProtocol_0 != null)
				{
					iwriterControlWebServiceProtocol_0.Url = string_3;
				}
			}
		}

		/// <summary>
		///       全局性的Web服务页面地址
		///       </summary>
		[DCPublishAPI]
		public static string GlobalWebServiceUrl
		{
			get
			{
				return string_4;
			}
			set
			{
				string_4 = value;
			}
		}

		/// <summary>
		///       Web服务客户端
		///       </summary>
		private IWriterControlWebServiceProtocol WebServiceClient
		{
			get
			{
				string text = WebServiceUrl;
				if (string.IsNullOrEmpty(text))
				{
					text = GlobalWebServiceUrl;
				}
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				if (iwriterControlWebServiceProtocol_0 == null)
				{
					iwriterControlWebServiceProtocol_0 = AppHost.Tools.CreateWriterControlWebServiceProtocol(this);
					iwriterControlWebServiceProtocol_0.Url = text;
				}
				iwriterControlWebServiceProtocol_0.DebugMode = (DeveloperToolsVisible || DocumentOptions.BehaviorOptions.DebugMode);
				return iwriterControlWebServiceProtocol_0;
			}
		}

		/// <summary>
		///       是否用TRY-CATCH模式触发事件
		///       </summary>
		/// <returns>
		/// </returns>
		internal bool IsTryCathForRaiseEvent
		{
			get
			{
				if (IsAxControl)
				{
					return true;
				}
				return DocumentOptions.BehaviorOptions.AppErrorHandleMode == AppErrorHandleModeConsts.ThrowException;
			}
		}

		/// <summary>
		///       是否允许控件的事件
		///       </summary>
		/// <remarks>
		///       如果本属性为false，则不触发任何编辑器的事件，不过System.Windows.Forms.Control中定义的事件仍然会触发。
		///       </remarks>
		[DCPublishAPI]
		[DefaultValue(true)]
		[Browsable(true)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool EnabledControlEvent
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		/// <summary>
		///       是否启用事件消息机制
		///       </summary>
		internal bool EnabledEventMessage => !EnabledControlEvent;

		/// <summary>
		///       最后一次获得的事件消息对象
		///       </summary>
		[ComVisible(true)]
		[DCInternal]
		public WriterControlEventMessage LastEventMessage => writerControlEventMessage_0;

		/// <summary>
		///       控件事件模板对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DCPublishAPI]
		public WriterControlEventTemplate ControlEventTemplate
		{
			get
			{
				return writerControlEventTemplate_0;
			}
			set
			{
				writerControlEventTemplate_0 = value;
			}
		}

		/// <summary>
		///       是否有加载和保存文件内容的事件
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public bool HasEventSaveFileContentForAutoSave => writerSaveFileContentEventHandler_0 != null;

		/// <summary>
		///       是否启用读取和保存文件内容的事件，默认值为true，对于COM开发默认值为false。
		///       </summary>
		[DefaultValue(true)]
		[ComVisible(false)]
		[DCInternal]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool EnabledEventReadSaveFileContent
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       是否有加载和保存文件内容的事件
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool HasEventReadSaveFileContent
		{
			get
			{
				if (!EnabledEventReadSaveFileContent)
				{
					return false;
				}
				return writerReadFileContentEventHandler_0 != null || writerSaveFileContentEventHandler_1 != null;
			}
		}

		/// <summary>
		///       全局文档元素事件处理器
		///       </summary>
		[Browsable(false)]
		internal Class134 GlobalElementEventMan
		{
			get
			{
				if (class134_0 == null)
				{
					class134_0 = new Class134(this);
				}
				return class134_0;
			}
		}

		/// <summary>
		///       针对COM而声明的文档内容选择状态发生改变事件
		///       </summary>
		[Obsolete("★★★不推荐使用本事件")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event VoidEventHandler ComEventSelectionChanged
		{
			add
			{
				VoidEventHandler voidEventHandler = voidEventHandler_0;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Combine(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_0, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
			remove
			{
				VoidEventHandler voidEventHandler = voidEventHandler_0;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Remove(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_0, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
		}

		/// <summary>
		///       针对COM声明的事件
		///       </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★不推荐使用本事件")]
		public event VoidEventHandler ComEventDocumentLoad
		{
			add
			{
				VoidEventHandler voidEventHandler = voidEventHandler_1;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Combine(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_1, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
			remove
			{
				VoidEventHandler voidEventHandler = voidEventHandler_1;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Remove(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_1, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
		}

		/// <summary>
		///       针对COM声明的事件
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★不推荐使用本事件")]
		[Browsable(false)]
		public event VoidEventHandler ComEventDocumentContentChanged
		{
			add
			{
				VoidEventHandler voidEventHandler = voidEventHandler_2;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Combine(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_2, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
			remove
			{
				VoidEventHandler voidEventHandler = voidEventHandler_2;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Remove(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_2, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
		}

		/// <summary>
		///       针对COM声明的事件
		///       </summary>
		[Obsolete("★★★不推荐使用本事件")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event VoidEventHandler ComEventStatusTextChanged
		{
			add
			{
				VoidEventHandler voidEventHandler = voidEventHandler_3;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Combine(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_3, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
			remove
			{
				VoidEventHandler voidEventHandler = voidEventHandler_3;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Remove(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_3, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
		}

		/// <summary>
		///       触发刷新执行元素事件表达式功能
		///       </summary>
		[DCPublishAPI]
		public event WriterAfterExecuteEventExpressionEventHandler EventAfterExecuteEventExpression
		{
			add
			{
				WriterAfterExecuteEventExpressionEventHandler writerAfterExecuteEventExpressionEventHandler = writerAfterExecuteEventExpressionEventHandler_0;
				WriterAfterExecuteEventExpressionEventHandler writerAfterExecuteEventExpressionEventHandler2;
				do
				{
					writerAfterExecuteEventExpressionEventHandler2 = writerAfterExecuteEventExpressionEventHandler;
					WriterAfterExecuteEventExpressionEventHandler value2 = (WriterAfterExecuteEventExpressionEventHandler)Delegate.Combine(writerAfterExecuteEventExpressionEventHandler2, value);
					writerAfterExecuteEventExpressionEventHandler = Interlocked.CompareExchange(ref writerAfterExecuteEventExpressionEventHandler_0, value2, writerAfterExecuteEventExpressionEventHandler2);
				}
				while ((object)writerAfterExecuteEventExpressionEventHandler != writerAfterExecuteEventExpressionEventHandler2);
			}
			remove
			{
				WriterAfterExecuteEventExpressionEventHandler writerAfterExecuteEventExpressionEventHandler = writerAfterExecuteEventExpressionEventHandler_0;
				WriterAfterExecuteEventExpressionEventHandler writerAfterExecuteEventExpressionEventHandler2;
				do
				{
					writerAfterExecuteEventExpressionEventHandler2 = writerAfterExecuteEventExpressionEventHandler;
					WriterAfterExecuteEventExpressionEventHandler value2 = (WriterAfterExecuteEventExpressionEventHandler)Delegate.Remove(writerAfterExecuteEventExpressionEventHandler2, value);
					writerAfterExecuteEventExpressionEventHandler = Interlocked.CompareExchange(ref writerAfterExecuteEventExpressionEventHandler_0, value2, writerAfterExecuteEventExpressionEventHandler2);
				}
				while ((object)writerAfterExecuteEventExpressionEventHandler != writerAfterExecuteEventExpressionEventHandler2);
			}
		}

		/// <summary>
		///       触发刷新DOM树事件
		///       </summary>
		[DCPublishAPI]
		public event WriterEventHandler EventRefreshDomTree
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_0;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_0, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_0;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_0, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       展开文档节前触发的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterSectionElementCancelEventHandler EventBeforeCollapseSection
		{
			add
			{
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler = writerSectionElementCancelEventHandler_0;
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler2;
				do
				{
					writerSectionElementCancelEventHandler2 = writerSectionElementCancelEventHandler;
					WriterSectionElementCancelEventHandler value2 = (WriterSectionElementCancelEventHandler)Delegate.Combine(writerSectionElementCancelEventHandler2, value);
					writerSectionElementCancelEventHandler = Interlocked.CompareExchange(ref writerSectionElementCancelEventHandler_0, value2, writerSectionElementCancelEventHandler2);
				}
				while ((object)writerSectionElementCancelEventHandler != writerSectionElementCancelEventHandler2);
			}
			remove
			{
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler = writerSectionElementCancelEventHandler_0;
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler2;
				do
				{
					writerSectionElementCancelEventHandler2 = writerSectionElementCancelEventHandler;
					WriterSectionElementCancelEventHandler value2 = (WriterSectionElementCancelEventHandler)Delegate.Remove(writerSectionElementCancelEventHandler2, value);
					writerSectionElementCancelEventHandler = Interlocked.CompareExchange(ref writerSectionElementCancelEventHandler_0, value2, writerSectionElementCancelEventHandler2);
				}
				while ((object)writerSectionElementCancelEventHandler != writerSectionElementCancelEventHandler2);
			}
		}

		/// <summary>
		///       收缩文档节后触发的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterSectionElementEventHandler EventAfterCollapseSection
		{
			add
			{
				WriterSectionElementEventHandler writerSectionElementEventHandler = writerSectionElementEventHandler_0;
				WriterSectionElementEventHandler writerSectionElementEventHandler2;
				do
				{
					writerSectionElementEventHandler2 = writerSectionElementEventHandler;
					WriterSectionElementEventHandler value2 = (WriterSectionElementEventHandler)Delegate.Combine(writerSectionElementEventHandler2, value);
					writerSectionElementEventHandler = Interlocked.CompareExchange(ref writerSectionElementEventHandler_0, value2, writerSectionElementEventHandler2);
				}
				while ((object)writerSectionElementEventHandler != writerSectionElementEventHandler2);
			}
			remove
			{
				WriterSectionElementEventHandler writerSectionElementEventHandler = writerSectionElementEventHandler_0;
				WriterSectionElementEventHandler writerSectionElementEventHandler2;
				do
				{
					writerSectionElementEventHandler2 = writerSectionElementEventHandler;
					WriterSectionElementEventHandler value2 = (WriterSectionElementEventHandler)Delegate.Remove(writerSectionElementEventHandler2, value);
					writerSectionElementEventHandler = Interlocked.CompareExchange(ref writerSectionElementEventHandler_0, value2, writerSectionElementEventHandler2);
				}
				while ((object)writerSectionElementEventHandler != writerSectionElementEventHandler2);
			}
		}

		/// <summary>
		///       展开文档节前触发的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterSectionElementCancelEventHandler EventBeforeExpandSection
		{
			add
			{
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler = writerSectionElementCancelEventHandler_1;
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler2;
				do
				{
					writerSectionElementCancelEventHandler2 = writerSectionElementCancelEventHandler;
					WriterSectionElementCancelEventHandler value2 = (WriterSectionElementCancelEventHandler)Delegate.Combine(writerSectionElementCancelEventHandler2, value);
					writerSectionElementCancelEventHandler = Interlocked.CompareExchange(ref writerSectionElementCancelEventHandler_1, value2, writerSectionElementCancelEventHandler2);
				}
				while ((object)writerSectionElementCancelEventHandler != writerSectionElementCancelEventHandler2);
			}
			remove
			{
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler = writerSectionElementCancelEventHandler_1;
				WriterSectionElementCancelEventHandler writerSectionElementCancelEventHandler2;
				do
				{
					writerSectionElementCancelEventHandler2 = writerSectionElementCancelEventHandler;
					WriterSectionElementCancelEventHandler value2 = (WriterSectionElementCancelEventHandler)Delegate.Remove(writerSectionElementCancelEventHandler2, value);
					writerSectionElementCancelEventHandler = Interlocked.CompareExchange(ref writerSectionElementCancelEventHandler_1, value2, writerSectionElementCancelEventHandler2);
				}
				while ((object)writerSectionElementCancelEventHandler != writerSectionElementCancelEventHandler2);
			}
		}

		/// <summary>
		///       展开文档节后触发的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterSectionElementEventHandler EventAfterExpandSection
		{
			add
			{
				WriterSectionElementEventHandler writerSectionElementEventHandler = writerSectionElementEventHandler_1;
				WriterSectionElementEventHandler writerSectionElementEventHandler2;
				do
				{
					writerSectionElementEventHandler2 = writerSectionElementEventHandler;
					WriterSectionElementEventHandler value2 = (WriterSectionElementEventHandler)Delegate.Combine(writerSectionElementEventHandler2, value);
					writerSectionElementEventHandler = Interlocked.CompareExchange(ref writerSectionElementEventHandler_1, value2, writerSectionElementEventHandler2);
				}
				while ((object)writerSectionElementEventHandler != writerSectionElementEventHandler2);
			}
			remove
			{
				WriterSectionElementEventHandler writerSectionElementEventHandler = writerSectionElementEventHandler_1;
				WriterSectionElementEventHandler writerSectionElementEventHandler2;
				do
				{
					writerSectionElementEventHandler2 = writerSectionElementEventHandler;
					WriterSectionElementEventHandler value2 = (WriterSectionElementEventHandler)Delegate.Remove(writerSectionElementEventHandler2, value);
					writerSectionElementEventHandler = Interlocked.CompareExchange(ref writerSectionElementEventHandler_1, value2, writerSectionElementEventHandler2);
				}
				while ((object)writerSectionElementEventHandler != writerSectionElementEventHandler2);
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

		/// <summary>
		///       通过数值编辑器修改输入域内容前触发的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterBeforeFieldContentEditEventHandler EventBeforeFieldContentEdit
		{
			add
			{
				WriterBeforeFieldContentEditEventHandler writerBeforeFieldContentEditEventHandler = writerBeforeFieldContentEditEventHandler_0;
				WriterBeforeFieldContentEditEventHandler writerBeforeFieldContentEditEventHandler2;
				do
				{
					writerBeforeFieldContentEditEventHandler2 = writerBeforeFieldContentEditEventHandler;
					WriterBeforeFieldContentEditEventHandler value2 = (WriterBeforeFieldContentEditEventHandler)Delegate.Combine(writerBeforeFieldContentEditEventHandler2, value);
					writerBeforeFieldContentEditEventHandler = Interlocked.CompareExchange(ref writerBeforeFieldContentEditEventHandler_0, value2, writerBeforeFieldContentEditEventHandler2);
				}
				while ((object)writerBeforeFieldContentEditEventHandler != writerBeforeFieldContentEditEventHandler2);
			}
			remove
			{
				WriterBeforeFieldContentEditEventHandler writerBeforeFieldContentEditEventHandler = writerBeforeFieldContentEditEventHandler_0;
				WriterBeforeFieldContentEditEventHandler writerBeforeFieldContentEditEventHandler2;
				do
				{
					writerBeforeFieldContentEditEventHandler2 = writerBeforeFieldContentEditEventHandler;
					WriterBeforeFieldContentEditEventHandler value2 = (WriterBeforeFieldContentEditEventHandler)Delegate.Remove(writerBeforeFieldContentEditEventHandler2, value);
					writerBeforeFieldContentEditEventHandler = Interlocked.CompareExchange(ref writerBeforeFieldContentEditEventHandler_0, value2, writerBeforeFieldContentEditEventHandler2);
				}
				while ((object)writerBeforeFieldContentEditEventHandler != writerBeforeFieldContentEditEventHandler2);
			}
		}

		/// <summary>
		///       通过数值编辑器修改输入域内容前触发的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterAfterFieldContentEditEventHandler EventAfterFieldContentEdit
		{
			add
			{
				WriterAfterFieldContentEditEventHandler writerAfterFieldContentEditEventHandler = writerAfterFieldContentEditEventHandler_0;
				WriterAfterFieldContentEditEventHandler writerAfterFieldContentEditEventHandler2;
				do
				{
					writerAfterFieldContentEditEventHandler2 = writerAfterFieldContentEditEventHandler;
					WriterAfterFieldContentEditEventHandler value2 = (WriterAfterFieldContentEditEventHandler)Delegate.Combine(writerAfterFieldContentEditEventHandler2, value);
					writerAfterFieldContentEditEventHandler = Interlocked.CompareExchange(ref writerAfterFieldContentEditEventHandler_0, value2, writerAfterFieldContentEditEventHandler2);
				}
				while ((object)writerAfterFieldContentEditEventHandler != writerAfterFieldContentEditEventHandler2);
			}
			remove
			{
				WriterAfterFieldContentEditEventHandler writerAfterFieldContentEditEventHandler = writerAfterFieldContentEditEventHandler_0;
				WriterAfterFieldContentEditEventHandler writerAfterFieldContentEditEventHandler2;
				do
				{
					writerAfterFieldContentEditEventHandler2 = writerAfterFieldContentEditEventHandler;
					WriterAfterFieldContentEditEventHandler value2 = (WriterAfterFieldContentEditEventHandler)Delegate.Remove(writerAfterFieldContentEditEventHandler2, value);
					writerAfterFieldContentEditEventHandler = Interlocked.CompareExchange(ref writerAfterFieldContentEditEventHandler_0, value2, writerAfterFieldContentEditEventHandler2);
				}
				while ((object)writerAfterFieldContentEditEventHandler != writerAfterFieldContentEditEventHandler2);
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
		///       准备播放媒体事件
		///       </summary>
		[DCPublishAPI]
		public event WriterBeforePlayMediaEventHandler EventBeforePlayMedia
		{
			add
			{
				WriterBeforePlayMediaEventHandler writerBeforePlayMediaEventHandler = writerBeforePlayMediaEventHandler_0;
				WriterBeforePlayMediaEventHandler writerBeforePlayMediaEventHandler2;
				do
				{
					writerBeforePlayMediaEventHandler2 = writerBeforePlayMediaEventHandler;
					WriterBeforePlayMediaEventHandler value2 = (WriterBeforePlayMediaEventHandler)Delegate.Combine(writerBeforePlayMediaEventHandler2, value);
					writerBeforePlayMediaEventHandler = Interlocked.CompareExchange(ref writerBeforePlayMediaEventHandler_0, value2, writerBeforePlayMediaEventHandler2);
				}
				while ((object)writerBeforePlayMediaEventHandler != writerBeforePlayMediaEventHandler2);
			}
			remove
			{
				WriterBeforePlayMediaEventHandler writerBeforePlayMediaEventHandler = writerBeforePlayMediaEventHandler_0;
				WriterBeforePlayMediaEventHandler writerBeforePlayMediaEventHandler2;
				do
				{
					writerBeforePlayMediaEventHandler2 = writerBeforePlayMediaEventHandler;
					WriterBeforePlayMediaEventHandler value2 = (WriterBeforePlayMediaEventHandler)Delegate.Remove(writerBeforePlayMediaEventHandler2, value);
					writerBeforePlayMediaEventHandler = Interlocked.CompareExchange(ref writerBeforePlayMediaEventHandler_0, value2, writerBeforePlayMediaEventHandler2);
				}
				while ((object)writerBeforePlayMediaEventHandler != writerBeforePlayMediaEventHandler2);
			}
		}

		/// <summary>
		///       文档大纲树状结构发生改变事件
		///       </summary>
		[DCPublishAPI]
		public event WriterEventHandler EventOutlineTreeChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_1;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_1, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_1;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_1, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       元素勾选状态发生改变事件
		///       </summary>
		[DCPublishAPI]
		public event WriterElementCheckedChangedEventHandler EventElementCheckedChanged
		{
			add
			{
				WriterElementCheckedChangedEventHandler writerElementCheckedChangedEventHandler = writerElementCheckedChangedEventHandler_0;
				WriterElementCheckedChangedEventHandler writerElementCheckedChangedEventHandler2;
				do
				{
					writerElementCheckedChangedEventHandler2 = writerElementCheckedChangedEventHandler;
					WriterElementCheckedChangedEventHandler value2 = (WriterElementCheckedChangedEventHandler)Delegate.Combine(writerElementCheckedChangedEventHandler2, value);
					writerElementCheckedChangedEventHandler = Interlocked.CompareExchange(ref writerElementCheckedChangedEventHandler_0, value2, writerElementCheckedChangedEventHandler2);
				}
				while ((object)writerElementCheckedChangedEventHandler != writerElementCheckedChangedEventHandler2);
			}
			remove
			{
				WriterElementCheckedChangedEventHandler writerElementCheckedChangedEventHandler = writerElementCheckedChangedEventHandler_0;
				WriterElementCheckedChangedEventHandler writerElementCheckedChangedEventHandler2;
				do
				{
					writerElementCheckedChangedEventHandler2 = writerElementCheckedChangedEventHandler;
					WriterElementCheckedChangedEventHandler value2 = (WriterElementCheckedChangedEventHandler)Delegate.Remove(writerElementCheckedChangedEventHandler2, value);
					writerElementCheckedChangedEventHandler = Interlocked.CompareExchange(ref writerElementCheckedChangedEventHandler_0, value2, writerElementCheckedChangedEventHandler2);
				}
				while ((object)writerElementCheckedChangedEventHandler != writerElementCheckedChangedEventHandler2);
			}
		}

		/// <summary>
		///       查询辅助录入使用的字符串列表事件,注意：这个事件不是在UI线程中触发。不能在本事件处理中直接操作用UI控件。
		///       </summary>
		[DCPublishAPI]
		public event WriterQueryAssistInputItemsEventHandler EventQueryAssistInputItems
		{
			add
			{
				WriterQueryAssistInputItemsEventHandler writerQueryAssistInputItemsEventHandler = writerQueryAssistInputItemsEventHandler_0;
				WriterQueryAssistInputItemsEventHandler writerQueryAssistInputItemsEventHandler2;
				do
				{
					writerQueryAssistInputItemsEventHandler2 = writerQueryAssistInputItemsEventHandler;
					WriterQueryAssistInputItemsEventHandler value2 = (WriterQueryAssistInputItemsEventHandler)Delegate.Combine(writerQueryAssistInputItemsEventHandler2, value);
					writerQueryAssistInputItemsEventHandler = Interlocked.CompareExchange(ref writerQueryAssistInputItemsEventHandler_0, value2, writerQueryAssistInputItemsEventHandler2);
				}
				while ((object)writerQueryAssistInputItemsEventHandler != writerQueryAssistInputItemsEventHandler2);
			}
			remove
			{
				WriterQueryAssistInputItemsEventHandler writerQueryAssistInputItemsEventHandler = writerQueryAssistInputItemsEventHandler_0;
				WriterQueryAssistInputItemsEventHandler writerQueryAssistInputItemsEventHandler2;
				do
				{
					writerQueryAssistInputItemsEventHandler2 = writerQueryAssistInputItemsEventHandler;
					WriterQueryAssistInputItemsEventHandler value2 = (WriterQueryAssistInputItemsEventHandler)Delegate.Remove(writerQueryAssistInputItemsEventHandler2, value);
					writerQueryAssistInputItemsEventHandler = Interlocked.CompareExchange(ref writerQueryAssistInputItemsEventHandler_0, value2, writerQueryAssistInputItemsEventHandler2);
				}
				while ((object)writerQueryAssistInputItemsEventHandler != writerQueryAssistInputItemsEventHandler2);
			}
		}

		/// <summary>
		///       键盘输入字符串事件
		///       </summary>
		[DCPublishAPI]
		public event WriterBeforeUIKeyboardInputStringEventHandler EventBeforeUIKeyboardInputString
		{
			add
			{
				WriterBeforeUIKeyboardInputStringEventHandler writerBeforeUIKeyboardInputStringEventHandler = writerBeforeUIKeyboardInputStringEventHandler_0;
				WriterBeforeUIKeyboardInputStringEventHandler writerBeforeUIKeyboardInputStringEventHandler2;
				do
				{
					writerBeforeUIKeyboardInputStringEventHandler2 = writerBeforeUIKeyboardInputStringEventHandler;
					WriterBeforeUIKeyboardInputStringEventHandler value2 = (WriterBeforeUIKeyboardInputStringEventHandler)Delegate.Combine(writerBeforeUIKeyboardInputStringEventHandler2, value);
					writerBeforeUIKeyboardInputStringEventHandler = Interlocked.CompareExchange(ref writerBeforeUIKeyboardInputStringEventHandler_0, value2, writerBeforeUIKeyboardInputStringEventHandler2);
				}
				while ((object)writerBeforeUIKeyboardInputStringEventHandler != writerBeforeUIKeyboardInputStringEventHandler2);
			}
			remove
			{
				WriterBeforeUIKeyboardInputStringEventHandler writerBeforeUIKeyboardInputStringEventHandler = writerBeforeUIKeyboardInputStringEventHandler_0;
				WriterBeforeUIKeyboardInputStringEventHandler writerBeforeUIKeyboardInputStringEventHandler2;
				do
				{
					writerBeforeUIKeyboardInputStringEventHandler2 = writerBeforeUIKeyboardInputStringEventHandler;
					WriterBeforeUIKeyboardInputStringEventHandler value2 = (WriterBeforeUIKeyboardInputStringEventHandler)Delegate.Remove(writerBeforeUIKeyboardInputStringEventHandler2, value);
					writerBeforeUIKeyboardInputStringEventHandler = Interlocked.CompareExchange(ref writerBeforeUIKeyboardInputStringEventHandler_0, value2, writerBeforeUIKeyboardInputStringEventHandler2);
				}
				while ((object)writerBeforeUIKeyboardInputStringEventHandler != writerBeforeUIKeyboardInputStringEventHandler2);
			}
		}

		/// <summary>
		///       表格行高度发生改变事件
		///       </summary>
		[DCPublishAPI]
		public event WriterTableRowHeightChangedEventHandler EventTableRowHeightChanged
		{
			add
			{
				WriterTableRowHeightChangedEventHandler writerTableRowHeightChangedEventHandler = writerTableRowHeightChangedEventHandler_0;
				WriterTableRowHeightChangedEventHandler writerTableRowHeightChangedEventHandler2;
				do
				{
					writerTableRowHeightChangedEventHandler2 = writerTableRowHeightChangedEventHandler;
					WriterTableRowHeightChangedEventHandler value2 = (WriterTableRowHeightChangedEventHandler)Delegate.Combine(writerTableRowHeightChangedEventHandler2, value);
					writerTableRowHeightChangedEventHandler = Interlocked.CompareExchange(ref writerTableRowHeightChangedEventHandler_0, value2, writerTableRowHeightChangedEventHandler2);
				}
				while ((object)writerTableRowHeightChangedEventHandler != writerTableRowHeightChangedEventHandler2);
			}
			remove
			{
				WriterTableRowHeightChangedEventHandler writerTableRowHeightChangedEventHandler = writerTableRowHeightChangedEventHandler_0;
				WriterTableRowHeightChangedEventHandler writerTableRowHeightChangedEventHandler2;
				do
				{
					writerTableRowHeightChangedEventHandler2 = writerTableRowHeightChangedEventHandler;
					WriterTableRowHeightChangedEventHandler value2 = (WriterTableRowHeightChangedEventHandler)Delegate.Remove(writerTableRowHeightChangedEventHandler2, value);
					writerTableRowHeightChangedEventHandler = Interlocked.CompareExchange(ref writerTableRowHeightChangedEventHandler_0, value2, writerTableRowHeightChangedEventHandler2);
				}
				while ((object)writerTableRowHeightChangedEventHandler != writerTableRowHeightChangedEventHandler2);
			}
		}

		/// <summary>
		///       表格行高度正在发生改变事件，在这个事件中可以取消表格行高度修改操作
		///       </summary>
		[DCPublishAPI]
		public event WriterTableRowHeightChangingEventHandler EventTableRowHeightChanging
		{
			add
			{
				WriterTableRowHeightChangingEventHandler writerTableRowHeightChangingEventHandler = writerTableRowHeightChangingEventHandler_0;
				WriterTableRowHeightChangingEventHandler writerTableRowHeightChangingEventHandler2;
				do
				{
					writerTableRowHeightChangingEventHandler2 = writerTableRowHeightChangingEventHandler;
					WriterTableRowHeightChangingEventHandler value2 = (WriterTableRowHeightChangingEventHandler)Delegate.Combine(writerTableRowHeightChangingEventHandler2, value);
					writerTableRowHeightChangingEventHandler = Interlocked.CompareExchange(ref writerTableRowHeightChangingEventHandler_0, value2, writerTableRowHeightChangingEventHandler2);
				}
				while ((object)writerTableRowHeightChangingEventHandler != writerTableRowHeightChangingEventHandler2);
			}
			remove
			{
				WriterTableRowHeightChangingEventHandler writerTableRowHeightChangingEventHandler = writerTableRowHeightChangingEventHandler_0;
				WriterTableRowHeightChangingEventHandler writerTableRowHeightChangingEventHandler2;
				do
				{
					writerTableRowHeightChangingEventHandler2 = writerTableRowHeightChangingEventHandler;
					WriterTableRowHeightChangingEventHandler value2 = (WriterTableRowHeightChangingEventHandler)Delegate.Remove(writerTableRowHeightChangingEventHandler2, value);
					writerTableRowHeightChangingEventHandler = Interlocked.CompareExchange(ref writerTableRowHeightChangingEventHandler_0, value2, writerTableRowHeightChangingEventHandler2);
				}
				while ((object)writerTableRowHeightChangingEventHandler != writerTableRowHeightChangingEventHandler2);
			}
		}

		/// <summary>
		///       文档内容的导航数据发生改变事件
		///       </summary>
		[DCPublishAPI]
		[Description("文档内容的导航数据发生改变事件")]
		public event WriterEventHandler DocumentNavigateContentChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_2;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_2, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_2;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_2, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       状态栏文本发生改变事件
		///       </summary>
		[DCPublishAPI]
		[Description("状态栏文本发生改变事件")]
		public event StatusTextChangedEventHandler StatusTextChanged
		{
			add
			{
				StatusTextChangedEventHandler statusTextChangedEventHandler = statusTextChangedEventHandler_0;
				StatusTextChangedEventHandler statusTextChangedEventHandler2;
				do
				{
					statusTextChangedEventHandler2 = statusTextChangedEventHandler;
					StatusTextChangedEventHandler value2 = (StatusTextChangedEventHandler)Delegate.Combine(statusTextChangedEventHandler2, value);
					statusTextChangedEventHandler = Interlocked.CompareExchange(ref statusTextChangedEventHandler_0, value2, statusTextChangedEventHandler2);
				}
				while ((object)statusTextChangedEventHandler != statusTextChangedEventHandler2);
			}
			remove
			{
				StatusTextChangedEventHandler statusTextChangedEventHandler = statusTextChangedEventHandler_0;
				StatusTextChangedEventHandler statusTextChangedEventHandler2;
				do
				{
					statusTextChangedEventHandler2 = statusTextChangedEventHandler;
					StatusTextChangedEventHandler value2 = (StatusTextChangedEventHandler)Delegate.Remove(statusTextChangedEventHandler2, value);
					statusTextChangedEventHandler = Interlocked.CompareExchange(ref statusTextChangedEventHandler_0, value2, statusTextChangedEventHandler2);
				}
				while ((object)statusTextChangedEventHandler != statusTextChangedEventHandler2);
			}
		}

		/// <summary>
		///       自定义绘制图形内容事件
		///       </summary>
		[DCPublishAPI]
		public event WriterDrawShapeContentEventHandler EventDrawShapeContent
		{
			add
			{
				WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler = writerDrawShapeContentEventHandler_0;
				WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler2;
				do
				{
					writerDrawShapeContentEventHandler2 = writerDrawShapeContentEventHandler;
					WriterDrawShapeContentEventHandler value2 = (WriterDrawShapeContentEventHandler)Delegate.Combine(writerDrawShapeContentEventHandler2, value);
					writerDrawShapeContentEventHandler = Interlocked.CompareExchange(ref writerDrawShapeContentEventHandler_0, value2, writerDrawShapeContentEventHandler2);
				}
				while ((object)writerDrawShapeContentEventHandler != writerDrawShapeContentEventHandler2);
			}
			remove
			{
				WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler = writerDrawShapeContentEventHandler_0;
				WriterDrawShapeContentEventHandler writerDrawShapeContentEventHandler2;
				do
				{
					writerDrawShapeContentEventHandler2 = writerDrawShapeContentEventHandler;
					WriterDrawShapeContentEventHandler value2 = (WriterDrawShapeContentEventHandler)Delegate.Remove(writerDrawShapeContentEventHandler2, value);
					writerDrawShapeContentEventHandler = Interlocked.CompareExchange(ref writerDrawShapeContentEventHandler_0, value2, writerDrawShapeContentEventHandler2);
				}
				while ((object)writerDrawShapeContentEventHandler != writerDrawShapeContentEventHandler2);
			}
		}

		/// <summary>
		///       报告错误内容的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterReportErrorEventHandler EventReportError
		{
			add
			{
				WriterReportErrorEventHandler writerReportErrorEventHandler = writerReportErrorEventHandler_0;
				WriterReportErrorEventHandler writerReportErrorEventHandler2;
				do
				{
					writerReportErrorEventHandler2 = writerReportErrorEventHandler;
					WriterReportErrorEventHandler value2 = (WriterReportErrorEventHandler)Delegate.Combine(writerReportErrorEventHandler2, value);
					writerReportErrorEventHandler = Interlocked.CompareExchange(ref writerReportErrorEventHandler_0, value2, writerReportErrorEventHandler2);
				}
				while ((object)writerReportErrorEventHandler != writerReportErrorEventHandler2);
			}
			remove
			{
				WriterReportErrorEventHandler writerReportErrorEventHandler = writerReportErrorEventHandler_0;
				WriterReportErrorEventHandler writerReportErrorEventHandler2;
				do
				{
					writerReportErrorEventHandler2 = writerReportErrorEventHandler;
					WriterReportErrorEventHandler value2 = (WriterReportErrorEventHandler)Delegate.Remove(writerReportErrorEventHandler2, value);
					writerReportErrorEventHandler = Interlocked.CompareExchange(ref writerReportErrorEventHandler_0, value2, writerReportErrorEventHandler2);
				}
				while ((object)writerReportErrorEventHandler != writerReportErrorEventHandler2);
			}
		}

		/// <summary>
		///       加载文档DOM结构后的事件
		///       </summary>
		[DCPublishAPI]
		public event WriterEventHandler EventAfterLoadRawDOM
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_3;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_3, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_3;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_3, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
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
		///       获得文档元素的扩展文本内容事件
		///       </summary>
		[DCPublishAPI]
		public event WriterGetAdornTextEventHandler EventGetAdornText
		{
			add
			{
				WriterGetAdornTextEventHandler writerGetAdornTextEventHandler = writerGetAdornTextEventHandler_0;
				WriterGetAdornTextEventHandler writerGetAdornTextEventHandler2;
				do
				{
					writerGetAdornTextEventHandler2 = writerGetAdornTextEventHandler;
					WriterGetAdornTextEventHandler value2 = (WriterGetAdornTextEventHandler)Delegate.Combine(writerGetAdornTextEventHandler2, value);
					writerGetAdornTextEventHandler = Interlocked.CompareExchange(ref writerGetAdornTextEventHandler_0, value2, writerGetAdornTextEventHandler2);
				}
				while ((object)writerGetAdornTextEventHandler != writerGetAdornTextEventHandler2);
			}
			remove
			{
				WriterGetAdornTextEventHandler writerGetAdornTextEventHandler = writerGetAdornTextEventHandler_0;
				WriterGetAdornTextEventHandler writerGetAdornTextEventHandler2;
				do
				{
					writerGetAdornTextEventHandler2 = writerGetAdornTextEventHandler;
					WriterGetAdornTextEventHandler value2 = (WriterGetAdornTextEventHandler)Delegate.Remove(writerGetAdornTextEventHandler2, value);
					writerGetAdornTextEventHandler = Interlocked.CompareExchange(ref writerGetAdornTextEventHandler_0, value2, writerGetAdornTextEventHandler2);
				}
				while ((object)writerGetAdornTextEventHandler != writerGetAdornTextEventHandler2);
			}
		}

		/// <summary>
		///       编辑文档元素数值事件
		///       </summary>
		[DCPublishAPI]
		public event WriterEditElementValueEventHandler EventEditElementValue
		{
			add
			{
				WriterEditElementValueEventHandler writerEditElementValueEventHandler = writerEditElementValueEventHandler_0;
				WriterEditElementValueEventHandler writerEditElementValueEventHandler2;
				do
				{
					writerEditElementValueEventHandler2 = writerEditElementValueEventHandler;
					WriterEditElementValueEventHandler value2 = (WriterEditElementValueEventHandler)Delegate.Combine(writerEditElementValueEventHandler2, value);
					writerEditElementValueEventHandler = Interlocked.CompareExchange(ref writerEditElementValueEventHandler_0, value2, writerEditElementValueEventHandler2);
				}
				while ((object)writerEditElementValueEventHandler != writerEditElementValueEventHandler2);
			}
			remove
			{
				WriterEditElementValueEventHandler writerEditElementValueEventHandler = writerEditElementValueEventHandler_0;
				WriterEditElementValueEventHandler writerEditElementValueEventHandler2;
				do
				{
					writerEditElementValueEventHandler2 = writerEditElementValueEventHandler;
					WriterEditElementValueEventHandler value2 = (WriterEditElementValueEventHandler)Delegate.Remove(writerEditElementValueEventHandler2, value);
					writerEditElementValueEventHandler = Interlocked.CompareExchange(ref writerEditElementValueEventHandler_0, value2, writerEditElementValueEventHandler2);
				}
				while ((object)writerEditElementValueEventHandler != writerEditElementValueEventHandler2);
			}
		}

		/// <summary>
		///       为自动保存功能而设置的保存文件内容事件
		///       </summary>
		[DCPublishAPI]
		public event WriterSaveFileContentEventHandler EventSaveFileContentForAutoSave
		{
			add
			{
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler = writerSaveFileContentEventHandler_0;
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler2;
				do
				{
					writerSaveFileContentEventHandler2 = writerSaveFileContentEventHandler;
					WriterSaveFileContentEventHandler value2 = (WriterSaveFileContentEventHandler)Delegate.Combine(writerSaveFileContentEventHandler2, value);
					writerSaveFileContentEventHandler = Interlocked.CompareExchange(ref writerSaveFileContentEventHandler_0, value2, writerSaveFileContentEventHandler2);
				}
				while ((object)writerSaveFileContentEventHandler != writerSaveFileContentEventHandler2);
			}
			remove
			{
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler = writerSaveFileContentEventHandler_0;
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler2;
				do
				{
					writerSaveFileContentEventHandler2 = writerSaveFileContentEventHandler;
					WriterSaveFileContentEventHandler value2 = (WriterSaveFileContentEventHandler)Delegate.Remove(writerSaveFileContentEventHandler2, value);
					writerSaveFileContentEventHandler = Interlocked.CompareExchange(ref writerSaveFileContentEventHandler_0, value2, writerSaveFileContentEventHandler2);
				}
				while ((object)writerSaveFileContentEventHandler != writerSaveFileContentEventHandler2);
			}
		}

		/// <summary>
		///       保存文件内容事件
		///       </summary>
		[DCPublishAPI]
		public event WriterSaveFileContentEventHandler EventSaveFileContent
		{
			add
			{
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler = writerSaveFileContentEventHandler_1;
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler2;
				do
				{
					writerSaveFileContentEventHandler2 = writerSaveFileContentEventHandler;
					WriterSaveFileContentEventHandler value2 = (WriterSaveFileContentEventHandler)Delegate.Combine(writerSaveFileContentEventHandler2, value);
					writerSaveFileContentEventHandler = Interlocked.CompareExchange(ref writerSaveFileContentEventHandler_1, value2, writerSaveFileContentEventHandler2);
				}
				while ((object)writerSaveFileContentEventHandler != writerSaveFileContentEventHandler2);
			}
			remove
			{
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler = writerSaveFileContentEventHandler_1;
				WriterSaveFileContentEventHandler writerSaveFileContentEventHandler2;
				do
				{
					writerSaveFileContentEventHandler2 = writerSaveFileContentEventHandler;
					WriterSaveFileContentEventHandler value2 = (WriterSaveFileContentEventHandler)Delegate.Remove(writerSaveFileContentEventHandler2, value);
					writerSaveFileContentEventHandler = Interlocked.CompareExchange(ref writerSaveFileContentEventHandler_1, value2, writerSaveFileContentEventHandler2);
				}
				while ((object)writerSaveFileContentEventHandler != writerSaveFileContentEventHandler2);
			}
		}

		/// <summary>
		///       读取文件内容事件
		///       </summary>
		[DCPublishAPI]
		public event WriterReadFileContentEventHandler EventReadFileContent
		{
			add
			{
				WriterReadFileContentEventHandler writerReadFileContentEventHandler = writerReadFileContentEventHandler_0;
				WriterReadFileContentEventHandler writerReadFileContentEventHandler2;
				do
				{
					writerReadFileContentEventHandler2 = writerReadFileContentEventHandler;
					WriterReadFileContentEventHandler value2 = (WriterReadFileContentEventHandler)Delegate.Combine(writerReadFileContentEventHandler2, value);
					writerReadFileContentEventHandler = Interlocked.CompareExchange(ref writerReadFileContentEventHandler_0, value2, writerReadFileContentEventHandler2);
				}
				while ((object)writerReadFileContentEventHandler != writerReadFileContentEventHandler2);
			}
			remove
			{
				WriterReadFileContentEventHandler writerReadFileContentEventHandler = writerReadFileContentEventHandler_0;
				WriterReadFileContentEventHandler writerReadFileContentEventHandler2;
				do
				{
					writerReadFileContentEventHandler2 = writerReadFileContentEventHandler;
					WriterReadFileContentEventHandler value2 = (WriterReadFileContentEventHandler)Delegate.Remove(writerReadFileContentEventHandler2, value);
					writerReadFileContentEventHandler = Interlocked.CompareExchange(ref writerReadFileContentEventHandler_0, value2, writerReadFileContentEventHandler2);
				}
				while ((object)writerReadFileContentEventHandler != writerReadFileContentEventHandler2);
			}
		}

		/// <summary>
		///       文档元素鼠标点击事件
		///       </summary>
		[DCPublishAPI]
		public event ElementMouseEventHandler EventElementMouseClick
		{
			add
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_0;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Combine(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_0, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
			remove
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_0;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Remove(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_0, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
		}

		/// <summary>
		///       文档元素获取焦点事件
		///       </summary>
		[DCPublishAPI]
		public event ElementEventHandler EventElementGotFocus
		{
			add
			{
				ElementEventHandler elementEventHandler = elementEventHandler_0;
				ElementEventHandler elementEventHandler2;
				do
				{
					elementEventHandler2 = elementEventHandler;
					ElementEventHandler value2 = (ElementEventHandler)Delegate.Combine(elementEventHandler2, value);
					elementEventHandler = Interlocked.CompareExchange(ref elementEventHandler_0, value2, elementEventHandler2);
				}
				while ((object)elementEventHandler != elementEventHandler2);
			}
			remove
			{
				ElementEventHandler elementEventHandler = elementEventHandler_0;
				ElementEventHandler elementEventHandler2;
				do
				{
					elementEventHandler2 = elementEventHandler;
					ElementEventHandler value2 = (ElementEventHandler)Delegate.Remove(elementEventHandler2, value);
					elementEventHandler = Interlocked.CompareExchange(ref elementEventHandler_0, value2, elementEventHandler2);
				}
				while ((object)elementEventHandler != elementEventHandler2);
			}
		}

		/// <summary>
		///       文档元素获取焦点事件
		///       </summary>
		[DCPublishAPI]
		public event ElementEventHandler EventElementLostFocus
		{
			add
			{
				ElementEventHandler elementEventHandler = elementEventHandler_1;
				ElementEventHandler elementEventHandler2;
				do
				{
					elementEventHandler2 = elementEventHandler;
					ElementEventHandler value2 = (ElementEventHandler)Delegate.Combine(elementEventHandler2, value);
					elementEventHandler = Interlocked.CompareExchange(ref elementEventHandler_1, value2, elementEventHandler2);
				}
				while ((object)elementEventHandler != elementEventHandler2);
			}
			remove
			{
				ElementEventHandler elementEventHandler = elementEventHandler_1;
				ElementEventHandler elementEventHandler2;
				do
				{
					elementEventHandler2 = elementEventHandler;
					ElementEventHandler value2 = (ElementEventHandler)Delegate.Remove(elementEventHandler2, value);
					elementEventHandler = Interlocked.CompareExchange(ref elementEventHandler_1, value2, elementEventHandler2);
				}
				while ((object)elementEventHandler != elementEventHandler2);
			}
		}

		/// <summary>
		///       文档元素鼠标双击事件
		///       </summary>
		[DCPublishAPI]
		public event ElementMouseEventHandler EventElementMouseDblClick
		{
			add
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_1;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Combine(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_1, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
			remove
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_1;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Remove(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_1, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
		}

		/// <summary>
		///       文档元素鼠标双击事件
		///       </summary>
		[DCPublishAPI]
		public event ElementMouseEventHandler EventElementMouseDown
		{
			add
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_2;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Combine(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_2, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
			remove
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_2;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Remove(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_2, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
		}

		/// <summary>
		///       文档元素鼠标移动事件
		///       </summary>
		[DCPublishAPI]
		public event ElementMouseEventHandler EventElementMouseMove
		{
			add
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_3;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Combine(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_3, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
			remove
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_3;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Remove(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_3, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
		}

		/// <summary>
		///       文档元素鼠标按键松开事件
		///       </summary>
		[DCPublishAPI]
		public event ElementMouseEventHandler EventElementMouseUp
		{
			add
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_4;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Combine(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_4, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
			remove
			{
				ElementMouseEventHandler elementMouseEventHandler = elementMouseEventHandler_4;
				ElementMouseEventHandler elementMouseEventHandler2;
				do
				{
					elementMouseEventHandler2 = elementMouseEventHandler;
					ElementMouseEventHandler value2 = (ElementMouseEventHandler)Delegate.Remove(elementMouseEventHandler2, value);
					elementMouseEventHandler = Interlocked.CompareExchange(ref elementMouseEventHandler_4, value2, elementMouseEventHandler2);
				}
				while ((object)elementMouseEventHandler != elementMouseEventHandler2);
			}
		}

		/// <summary>
		///       按钮点击事件
		///       </summary>
		[DCPublishAPI]
		public event WriterButtonClickEventHandler EventButtonClick
		{
			add
			{
				WriterButtonClickEventHandler writerButtonClickEventHandler = writerButtonClickEventHandler_0;
				WriterButtonClickEventHandler writerButtonClickEventHandler2;
				do
				{
					writerButtonClickEventHandler2 = writerButtonClickEventHandler;
					WriterButtonClickEventHandler value2 = (WriterButtonClickEventHandler)Delegate.Combine(writerButtonClickEventHandler2, value);
					writerButtonClickEventHandler = Interlocked.CompareExchange(ref writerButtonClickEventHandler_0, value2, writerButtonClickEventHandler2);
				}
				while ((object)writerButtonClickEventHandler != writerButtonClickEventHandler2);
			}
			remove
			{
				WriterButtonClickEventHandler writerButtonClickEventHandler = writerButtonClickEventHandler_0;
				WriterButtonClickEventHandler writerButtonClickEventHandler2;
				do
				{
					writerButtonClickEventHandler2 = writerButtonClickEventHandler;
					WriterButtonClickEventHandler value2 = (WriterButtonClickEventHandler)Delegate.Remove(writerButtonClickEventHandler2, value);
					writerButtonClickEventHandler = Interlocked.CompareExchange(ref writerButtonClickEventHandler_0, value2, writerButtonClickEventHandler2);
				}
				while ((object)writerButtonClickEventHandler != writerButtonClickEventHandler2);
			}
		}

		/// <summary>
		///       超链接点击事件
		///       </summary>
		[DCPublishAPI]
		public event WriterLinkEventHandler EventLinkClick
		{
			add
			{
				WriterLinkEventHandler writerLinkEventHandler = writerLinkEventHandler_0;
				WriterLinkEventHandler writerLinkEventHandler2;
				do
				{
					writerLinkEventHandler2 = writerLinkEventHandler;
					WriterLinkEventHandler value2 = (WriterLinkEventHandler)Delegate.Combine(writerLinkEventHandler2, value);
					writerLinkEventHandler = Interlocked.CompareExchange(ref writerLinkEventHandler_0, value2, writerLinkEventHandler2);
				}
				while ((object)writerLinkEventHandler != writerLinkEventHandler2);
			}
			remove
			{
				WriterLinkEventHandler writerLinkEventHandler = writerLinkEventHandler_0;
				WriterLinkEventHandler writerLinkEventHandler2;
				do
				{
					writerLinkEventHandler2 = writerLinkEventHandler;
					WriterLinkEventHandler value2 = (WriterLinkEventHandler)Delegate.Remove(writerLinkEventHandler2, value);
					writerLinkEventHandler = Interlocked.CompareExchange(ref writerLinkEventHandler_0, value2, writerLinkEventHandler2);
				}
				while ((object)writerLinkEventHandler != writerLinkEventHandler2);
			}
		}

		/// <summary>
		///       获得联动下拉列表事件
		///       </summary>
		[DCDescription(typeof(WriterControl), "EventGetLinkListItems")]
		[DCPublishAPI]
		public event GetLinkListItemsEventHandler EventGetLinkListItems
		{
			add
			{
				GetLinkListItemsEventHandler getLinkListItemsEventHandler = getLinkListItemsEventHandler_0;
				GetLinkListItemsEventHandler getLinkListItemsEventHandler2;
				do
				{
					getLinkListItemsEventHandler2 = getLinkListItemsEventHandler;
					GetLinkListItemsEventHandler value2 = (GetLinkListItemsEventHandler)Delegate.Combine(getLinkListItemsEventHandler2, value);
					getLinkListItemsEventHandler = Interlocked.CompareExchange(ref getLinkListItemsEventHandler_0, value2, getLinkListItemsEventHandler2);
				}
				while ((object)getLinkListItemsEventHandler != getLinkListItemsEventHandler2);
			}
			remove
			{
				GetLinkListItemsEventHandler getLinkListItemsEventHandler = getLinkListItemsEventHandler_0;
				GetLinkListItemsEventHandler getLinkListItemsEventHandler2;
				do
				{
					getLinkListItemsEventHandler2 = getLinkListItemsEventHandler;
					GetLinkListItemsEventHandler value2 = (GetLinkListItemsEventHandler)Delegate.Remove(getLinkListItemsEventHandler2, value);
					getLinkListItemsEventHandler = Interlocked.CompareExchange(ref getLinkListItemsEventHandler_0, value2, getLinkListItemsEventHandler2);
				}
				while ((object)getLinkListItemsEventHandler != getLinkListItemsEventHandler2);
			}
		}

		/// <summary>
		///       收集内容保护信息事件
		///       </summary>
		[DCDescription(typeof(WriterControl), "EventCollectProtectedElements")]
		[DCPublishAPI]
		public event CollectProtectedElementsEventHandler EventCollectProtectedElements
		{
			add
			{
				CollectProtectedElementsEventHandler collectProtectedElementsEventHandler = collectProtectedElementsEventHandler_0;
				CollectProtectedElementsEventHandler collectProtectedElementsEventHandler2;
				do
				{
					collectProtectedElementsEventHandler2 = collectProtectedElementsEventHandler;
					CollectProtectedElementsEventHandler value2 = (CollectProtectedElementsEventHandler)Delegate.Combine(collectProtectedElementsEventHandler2, value);
					collectProtectedElementsEventHandler = Interlocked.CompareExchange(ref collectProtectedElementsEventHandler_0, value2, collectProtectedElementsEventHandler2);
				}
				while ((object)collectProtectedElementsEventHandler != collectProtectedElementsEventHandler2);
			}
			remove
			{
				CollectProtectedElementsEventHandler collectProtectedElementsEventHandler = collectProtectedElementsEventHandler_0;
				CollectProtectedElementsEventHandler collectProtectedElementsEventHandler2;
				do
				{
					collectProtectedElementsEventHandler2 = collectProtectedElementsEventHandler;
					CollectProtectedElementsEventHandler value2 = (CollectProtectedElementsEventHandler)Delegate.Remove(collectProtectedElementsEventHandler2, value);
					collectProtectedElementsEventHandler = Interlocked.CompareExchange(ref collectProtectedElementsEventHandler_0, value2, collectProtectedElementsEventHandler2);
				}
				while ((object)collectProtectedElementsEventHandler != collectProtectedElementsEventHandler2);
			}
		}

		/// <summary>
		///       控件缩放事件
		///       </summary>
		[DCDescription(typeof(WriterControl), "EventZoomChanged")]
		[DCPublishAPI]
		public event WriterEventHandler EventZoomChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_4;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_4, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_4;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_4, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       提示内容受保护的事件
		///       </summary>
		[DCDescription(typeof(WriterControl), "EventPromptProtectedContent")]
		[DCPublishAPI]
		public event PromptProtectedContentEventHandler EventPromptProtectedContent
		{
			add
			{
				PromptProtectedContentEventHandler promptProtectedContentEventHandler = promptProtectedContentEventHandler_0;
				PromptProtectedContentEventHandler promptProtectedContentEventHandler2;
				do
				{
					promptProtectedContentEventHandler2 = promptProtectedContentEventHandler;
					PromptProtectedContentEventHandler value2 = (PromptProtectedContentEventHandler)Delegate.Combine(promptProtectedContentEventHandler2, value);
					promptProtectedContentEventHandler = Interlocked.CompareExchange(ref promptProtectedContentEventHandler_0, value2, promptProtectedContentEventHandler2);
				}
				while ((object)promptProtectedContentEventHandler != promptProtectedContentEventHandler2);
			}
			remove
			{
				PromptProtectedContentEventHandler promptProtectedContentEventHandler = promptProtectedContentEventHandler_0;
				PromptProtectedContentEventHandler promptProtectedContentEventHandler2;
				do
				{
					promptProtectedContentEventHandler2 = promptProtectedContentEventHandler;
					PromptProtectedContentEventHandler value2 = (PromptProtectedContentEventHandler)Delegate.Remove(promptProtectedContentEventHandler2, value);
					promptProtectedContentEventHandler = Interlocked.CompareExchange(ref promptProtectedContentEventHandler_0, value2, promptProtectedContentEventHandler2);
				}
				while ((object)promptProtectedContentEventHandler != promptProtectedContentEventHandler2);
			}
		}

		/// <summary>
		///       使用TAB键新增表格行触发的事件
		///       </summary>
		[DCDescription(typeof(WriterControl), "EventTableAddNewRowWhenPressTabKey")]
		[DCPublishAPI]
		public event WriterEventHandler EventTableAddNewRowWhenPressTabKey
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_5;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_5, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_5;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_5, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       结束切换输入焦点事件
		///       </summary>
		[DCDescription(typeof(WriterControl), "EventEndTabStop")]
		[DCPublishAPI]
		public event WriterEventHandler EventEndTabStop
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_6;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_6, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_6;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_6, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       内容正在改变事件
		///       </summary>
		[DCPublishAPI]
		[DCDescription(typeof(WriterControl), "EventContentChanging")]
		public event ContentChangingEventHandler EventContentChanging
		{
			add
			{
				ContentChangingEventHandler contentChangingEventHandler = contentChangingEventHandler_0;
				ContentChangingEventHandler contentChangingEventHandler2;
				do
				{
					contentChangingEventHandler2 = contentChangingEventHandler;
					ContentChangingEventHandler value2 = (ContentChangingEventHandler)Delegate.Combine(contentChangingEventHandler2, value);
					contentChangingEventHandler = Interlocked.CompareExchange(ref contentChangingEventHandler_0, value2, contentChangingEventHandler2);
				}
				while ((object)contentChangingEventHandler != contentChangingEventHandler2);
			}
			remove
			{
				ContentChangingEventHandler contentChangingEventHandler = contentChangingEventHandler_0;
				ContentChangingEventHandler contentChangingEventHandler2;
				do
				{
					contentChangingEventHandler2 = contentChangingEventHandler;
					ContentChangingEventHandler value2 = (ContentChangingEventHandler)Delegate.Remove(contentChangingEventHandler2, value);
					contentChangingEventHandler = Interlocked.CompareExchange(ref contentChangingEventHandler_0, value2, contentChangingEventHandler2);
				}
				while ((object)contentChangingEventHandler != contentChangingEventHandler2);
			}
		}

		/// <summary>
		///       内容已经改变事件
		///       </summary>
		[DCPublishAPI]
		[DCDescription(typeof(WriterControl), "EventContentChanged")]
		public event ContentChangedEventHandler EventContentChanged
		{
			add
			{
				ContentChangedEventHandler contentChangedEventHandler = contentChangedEventHandler_0;
				ContentChangedEventHandler contentChangedEventHandler2;
				do
				{
					contentChangedEventHandler2 = contentChangedEventHandler;
					ContentChangedEventHandler value2 = (ContentChangedEventHandler)Delegate.Combine(contentChangedEventHandler2, value);
					contentChangedEventHandler = Interlocked.CompareExchange(ref contentChangedEventHandler_0, value2, contentChangedEventHandler2);
				}
				while ((object)contentChangedEventHandler != contentChangedEventHandler2);
			}
			remove
			{
				ContentChangedEventHandler contentChangedEventHandler = contentChangedEventHandler_0;
				ContentChangedEventHandler contentChangedEventHandler2;
				do
				{
					contentChangedEventHandler2 = contentChangedEventHandler;
					ContentChangedEventHandler value2 = (ContentChangedEventHandler)Delegate.Remove(contentChangedEventHandler2, value);
					contentChangedEventHandler = Interlocked.CompareExchange(ref contentChangedEventHandler_0, value2, contentChangedEventHandler2);
				}
				while ((object)contentChangedEventHandler != contentChangedEventHandler2);
			}
		}

		/// <summary>
		///       在显示对话框之前触发的事件
		///       </summary>
		[Description("在显示对话框之前触发的事件")]
		[DCPublishAPI]
		public event WriterShowDialogEventHandler EventBeforeShowDialog
		{
			add
			{
				WriterShowDialogEventHandler writerShowDialogEventHandler = writerShowDialogEventHandler_0;
				WriterShowDialogEventHandler writerShowDialogEventHandler2;
				do
				{
					writerShowDialogEventHandler2 = writerShowDialogEventHandler;
					WriterShowDialogEventHandler value2 = (WriterShowDialogEventHandler)Delegate.Combine(writerShowDialogEventHandler2, value);
					writerShowDialogEventHandler = Interlocked.CompareExchange(ref writerShowDialogEventHandler_0, value2, writerShowDialogEventHandler2);
				}
				while ((object)writerShowDialogEventHandler != writerShowDialogEventHandler2);
			}
			remove
			{
				WriterShowDialogEventHandler writerShowDialogEventHandler = writerShowDialogEventHandler_0;
				WriterShowDialogEventHandler writerShowDialogEventHandler2;
				do
				{
					writerShowDialogEventHandler2 = writerShowDialogEventHandler;
					WriterShowDialogEventHandler value2 = (WriterShowDialogEventHandler)Delegate.Remove(writerShowDialogEventHandler2, value);
					writerShowDialogEventHandler = Interlocked.CompareExchange(ref writerShowDialogEventHandler_0, value2, writerShowDialogEventHandler2);
				}
				while ((object)writerShowDialogEventHandler != writerShowDialogEventHandler2);
			}
		}

		/// <summary>
		///       自定义命令事件
		///       </summary>
		[DCPublishAPI]
		[Description("自定义功能命令事件")]
		public event CustomCommandEventHandler ComCustomCommand
		{
			add
			{
				CustomCommandEventHandler customCommandEventHandler = customCommandEventHandler_0;
				CustomCommandEventHandler customCommandEventHandler2;
				do
				{
					customCommandEventHandler2 = customCommandEventHandler;
					CustomCommandEventHandler value2 = (CustomCommandEventHandler)Delegate.Combine(customCommandEventHandler2, value);
					customCommandEventHandler = Interlocked.CompareExchange(ref customCommandEventHandler_0, value2, customCommandEventHandler2);
				}
				while ((object)customCommandEventHandler != customCommandEventHandler2);
			}
			remove
			{
				CustomCommandEventHandler customCommandEventHandler = customCommandEventHandler_0;
				CustomCommandEventHandler customCommandEventHandler2;
				do
				{
					customCommandEventHandler2 = customCommandEventHandler;
					CustomCommandEventHandler value2 = (CustomCommandEventHandler)Delegate.Remove(customCommandEventHandler2, value);
					customCommandEventHandler = Interlocked.CompareExchange(ref customCommandEventHandler_0, value2, customCommandEventHandler2);
				}
				while ((object)customCommandEventHandler != customCommandEventHandler2);
			}
		}

		/// <summary>
		///       用户界面层的开始编辑文档内容事件
		///       </summary>
		[DCPublishAPI]
		[Description("开始编辑文档内容事件")]
		public event WriterStartEditEventHandler EventUIStartEditContent
		{
			add
			{
				WriterStartEditEventHandler writerStartEditEventHandler = writerStartEditEventHandler_0;
				WriterStartEditEventHandler writerStartEditEventHandler2;
				do
				{
					writerStartEditEventHandler2 = writerStartEditEventHandler;
					WriterStartEditEventHandler value2 = (WriterStartEditEventHandler)Delegate.Combine(writerStartEditEventHandler2, value);
					writerStartEditEventHandler = Interlocked.CompareExchange(ref writerStartEditEventHandler_0, value2, writerStartEditEventHandler2);
				}
				while ((object)writerStartEditEventHandler != writerStartEditEventHandler2);
			}
			remove
			{
				WriterStartEditEventHandler writerStartEditEventHandler = writerStartEditEventHandler_0;
				WriterStartEditEventHandler writerStartEditEventHandler2;
				do
				{
					writerStartEditEventHandler2 = writerStartEditEventHandler;
					WriterStartEditEventHandler value2 = (WriterStartEditEventHandler)Delegate.Remove(writerStartEditEventHandler2, value);
					writerStartEditEventHandler = Interlocked.CompareExchange(ref writerStartEditEventHandler_0, value2, writerStartEditEventHandler2);
				}
				while ((object)writerStartEditEventHandler != writerStartEditEventHandler2);
			}
		}

		/// <summary>
		///       成功加载文档DOM结构触发的事件，此时文档虽然加载了DOM结构，但没有排版和显示。
		///       </summary>
		[Description("成功加载文档DOM结构触发的事件")]
		[DCPublishAPI]
		public event WriterEventHandler AfterLoadDocumentDom
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_7;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_7, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_7;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_7, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       创建对象实例事件
		///       </summary>
		[Description("创建对象实例事件")]
		[DCPublishAPI]
		public event CreateInstanceEventHandler EventCreateInstance
		{
			add
			{
				CreateInstanceEventHandler createInstanceEventHandler = createInstanceEventHandler_0;
				CreateInstanceEventHandler createInstanceEventHandler2;
				do
				{
					createInstanceEventHandler2 = createInstanceEventHandler;
					CreateInstanceEventHandler value2 = (CreateInstanceEventHandler)Delegate.Combine(createInstanceEventHandler2, value);
					createInstanceEventHandler = Interlocked.CompareExchange(ref createInstanceEventHandler_0, value2, createInstanceEventHandler2);
				}
				while ((object)createInstanceEventHandler != createInstanceEventHandler2);
			}
			remove
			{
				CreateInstanceEventHandler createInstanceEventHandler = createInstanceEventHandler_0;
				CreateInstanceEventHandler createInstanceEventHandler2;
				do
				{
					createInstanceEventHandler2 = createInstanceEventHandler;
					CreateInstanceEventHandler value2 = (CreateInstanceEventHandler)Delegate.Remove(createInstanceEventHandler2, value);
					createInstanceEventHandler = Interlocked.CompareExchange(ref createInstanceEventHandler_0, value2, createInstanceEventHandler2);
				}
				while ((object)createInstanceEventHandler != createInstanceEventHandler2);
			}
		}

		/// <summary>
		///       刷新分页后事件
		///       </summary>
		[Description("刷新分页后事件")]
		[DCPublishAPI]
		public event WriterEventHandler AfterRefreshPages
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_8;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_8, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_8;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_8, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       查询用户历史记录显示文本事件
		///       </summary>
		[Description("查询用户历史记录显示文本事件")]
		[DCPublishAPI]
		public event QueryUserHistoryDisplayTextEventHandler QueryUserHistoryDisplayText
		{
			add
			{
				QueryUserHistoryDisplayTextEventHandler queryUserHistoryDisplayTextEventHandler = queryUserHistoryDisplayTextEventHandler_0;
				QueryUserHistoryDisplayTextEventHandler queryUserHistoryDisplayTextEventHandler2;
				do
				{
					queryUserHistoryDisplayTextEventHandler2 = queryUserHistoryDisplayTextEventHandler;
					QueryUserHistoryDisplayTextEventHandler value2 = (QueryUserHistoryDisplayTextEventHandler)Delegate.Combine(queryUserHistoryDisplayTextEventHandler2, value);
					queryUserHistoryDisplayTextEventHandler = Interlocked.CompareExchange(ref queryUserHistoryDisplayTextEventHandler_0, value2, queryUserHistoryDisplayTextEventHandler2);
				}
				while ((object)queryUserHistoryDisplayTextEventHandler != queryUserHistoryDisplayTextEventHandler2);
			}
			remove
			{
				QueryUserHistoryDisplayTextEventHandler queryUserHistoryDisplayTextEventHandler = queryUserHistoryDisplayTextEventHandler_0;
				QueryUserHistoryDisplayTextEventHandler queryUserHistoryDisplayTextEventHandler2;
				do
				{
					queryUserHistoryDisplayTextEventHandler2 = queryUserHistoryDisplayTextEventHandler;
					QueryUserHistoryDisplayTextEventHandler value2 = (QueryUserHistoryDisplayTextEventHandler)Delegate.Remove(queryUserHistoryDisplayTextEventHandler2, value);
					queryUserHistoryDisplayTextEventHandler = Interlocked.CompareExchange(ref queryUserHistoryDisplayTextEventHandler_0, value2, queryUserHistoryDisplayTextEventHandler2);
				}
				while ((object)queryUserHistoryDisplayTextEventHandler != queryUserHistoryDisplayTextEventHandler2);
			}
		}

		/// <summary>
		///       解释列表项目的事件
		///       </summary>
		[Description("解释列表项目的事件")]
		[DCPublishAPI]
		public event ParseSelectedItemsEventHandler EventParseSelectedItems
		{
			add
			{
				ParseSelectedItemsEventHandler parseSelectedItemsEventHandler = parseSelectedItemsEventHandler_0;
				ParseSelectedItemsEventHandler parseSelectedItemsEventHandler2;
				do
				{
					parseSelectedItemsEventHandler2 = parseSelectedItemsEventHandler;
					ParseSelectedItemsEventHandler value2 = (ParseSelectedItemsEventHandler)Delegate.Combine(parseSelectedItemsEventHandler2, value);
					parseSelectedItemsEventHandler = Interlocked.CompareExchange(ref parseSelectedItemsEventHandler_0, value2, parseSelectedItemsEventHandler2);
				}
				while ((object)parseSelectedItemsEventHandler != parseSelectedItemsEventHandler2);
			}
			remove
			{
				ParseSelectedItemsEventHandler parseSelectedItemsEventHandler = parseSelectedItemsEventHandler_0;
				ParseSelectedItemsEventHandler parseSelectedItemsEventHandler2;
				do
				{
					parseSelectedItemsEventHandler2 = parseSelectedItemsEventHandler;
					ParseSelectedItemsEventHandler value2 = (ParseSelectedItemsEventHandler)Delegate.Remove(parseSelectedItemsEventHandler2, value);
					parseSelectedItemsEventHandler = Interlocked.CompareExchange(ref parseSelectedItemsEventHandler_0, value2, parseSelectedItemsEventHandler2);
				}
				while ((object)parseSelectedItemsEventHandler != parseSelectedItemsEventHandler2);
			}
		}

		/// <summary>
		///       获得列表显示文本事件
		///       </summary>
		[DCPublishAPI]
		[Description("格式化输出列表显示文本事件")]
		public event FormatListItemsEventHandler EventFormatListItems
		{
			add
			{
				FormatListItemsEventHandler formatListItemsEventHandler = formatListItemsEventHandler_0;
				FormatListItemsEventHandler formatListItemsEventHandler2;
				do
				{
					formatListItemsEventHandler2 = formatListItemsEventHandler;
					FormatListItemsEventHandler value2 = (FormatListItemsEventHandler)Delegate.Combine(formatListItemsEventHandler2, value);
					formatListItemsEventHandler = Interlocked.CompareExchange(ref formatListItemsEventHandler_0, value2, formatListItemsEventHandler2);
				}
				while ((object)formatListItemsEventHandler != formatListItemsEventHandler2);
			}
			remove
			{
				FormatListItemsEventHandler formatListItemsEventHandler = formatListItemsEventHandler_0;
				FormatListItemsEventHandler formatListItemsEventHandler2;
				do
				{
					formatListItemsEventHandler2 = formatListItemsEventHandler;
					FormatListItemsEventHandler value2 = (FormatListItemsEventHandler)Delegate.Remove(formatListItemsEventHandler2, value);
					formatListItemsEventHandler = Interlocked.CompareExchange(ref formatListItemsEventHandler_0, value2, formatListItemsEventHandler2);
				}
				while ((object)formatListItemsEventHandler != formatListItemsEventHandler2);
			}
		}

		/// <summary>
		///       未知编辑器命令事件
		///       </summary>
		[DCPublishAPI]
		[Description("未知编辑器命令事件")]
		public event WriterCommandEventHandler EventUnknowCommand
		{
			add
			{
				WriterCommandEventHandler writerCommandEventHandler = writerCommandEventHandler_0;
				WriterCommandEventHandler writerCommandEventHandler2;
				do
				{
					writerCommandEventHandler2 = writerCommandEventHandler;
					WriterCommandEventHandler value2 = (WriterCommandEventHandler)Delegate.Combine(writerCommandEventHandler2, value);
					writerCommandEventHandler = Interlocked.CompareExchange(ref writerCommandEventHandler_0, value2, writerCommandEventHandler2);
				}
				while ((object)writerCommandEventHandler != writerCommandEventHandler2);
			}
			remove
			{
				WriterCommandEventHandler writerCommandEventHandler = writerCommandEventHandler_0;
				WriterCommandEventHandler writerCommandEventHandler2;
				do
				{
					writerCommandEventHandler2 = writerCommandEventHandler;
					WriterCommandEventHandler value2 = (WriterCommandEventHandler)Delegate.Remove(writerCommandEventHandler2, value);
					writerCommandEventHandler = Interlocked.CompareExchange(ref writerCommandEventHandler_0, value2, writerCommandEventHandler2);
				}
				while ((object)writerCommandEventHandler != writerCommandEventHandler2);
			}
		}

		/// <summary>
		///       查询知识库节点列表事件
		///       </summary>
		[Description("查询知识库节点列表事件")]
		[DCPublishAPI]
		public event QueryKBEntriesEventHandler QueryKBEntries
		{
			add
			{
				QueryKBEntriesEventHandler queryKBEntriesEventHandler = queryKBEntriesEventHandler_0;
				QueryKBEntriesEventHandler queryKBEntriesEventHandler2;
				do
				{
					queryKBEntriesEventHandler2 = queryKBEntriesEventHandler;
					QueryKBEntriesEventHandler value2 = (QueryKBEntriesEventHandler)Delegate.Combine(queryKBEntriesEventHandler2, value);
					queryKBEntriesEventHandler = Interlocked.CompareExchange(ref queryKBEntriesEventHandler_0, value2, queryKBEntriesEventHandler2);
				}
				while ((object)queryKBEntriesEventHandler != queryKBEntriesEventHandler2);
			}
			remove
			{
				QueryKBEntriesEventHandler queryKBEntriesEventHandler = queryKBEntriesEventHandler_0;
				QueryKBEntriesEventHandler queryKBEntriesEventHandler2;
				do
				{
					queryKBEntriesEventHandler2 = queryKBEntriesEventHandler;
					QueryKBEntriesEventHandler value2 = (QueryKBEntriesEventHandler)Delegate.Remove(queryKBEntriesEventHandler2, value);
					queryKBEntriesEventHandler = Interlocked.CompareExchange(ref queryKBEntriesEventHandler_0, value2, queryKBEntriesEventHandler2);
				}
				while ((object)queryKBEntriesEventHandler != queryKBEntriesEventHandler2);
			}
		}

		/// <summary>
		///       增强型鼠标按下事件
		///       </summary>
		[DCPublishAPI]
		[Description("增强型鼠标按下事件")]
		public event WriterMouseEventHandler EventMouseDownExt
		{
			add
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_0;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Combine(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_0, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
			remove
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_0;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Remove(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_0, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
		}

		/// <summary>
		///       增强型鼠标移动事件
		///       </summary>
		[Description("增强型鼠标移动事件")]
		[DCPublishAPI]
		public event WriterMouseEventHandler EventMouseMoveExt
		{
			add
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_1;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Combine(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_1, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
			remove
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_1;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Remove(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_1, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
		}

		/// <summary>
		///       增强型鼠标按键松开事件
		///       </summary>
		[DCPublishAPI]
		[Description("增强型鼠标按键松开事件")]
		public event WriterMouseEventHandler EventMouseUpExt
		{
			add
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_2;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Combine(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_2, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
			remove
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_2;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Remove(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_2, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
		}

		/// <summary>
		///       扩展的键盘按键按下事件
		///       </summary>
		[DCPublishAPI]
		public event WriterKeyEventExtHandler EventKeyDownExt
		{
			add
			{
				WriterKeyEventExtHandler writerKeyEventExtHandler = writerKeyEventExtHandler_0;
				WriterKeyEventExtHandler writerKeyEventExtHandler2;
				do
				{
					writerKeyEventExtHandler2 = writerKeyEventExtHandler;
					WriterKeyEventExtHandler value2 = (WriterKeyEventExtHandler)Delegate.Combine(writerKeyEventExtHandler2, value);
					writerKeyEventExtHandler = Interlocked.CompareExchange(ref writerKeyEventExtHandler_0, value2, writerKeyEventExtHandler2);
				}
				while ((object)writerKeyEventExtHandler != writerKeyEventExtHandler2);
			}
			remove
			{
				WriterKeyEventExtHandler writerKeyEventExtHandler = writerKeyEventExtHandler_0;
				WriterKeyEventExtHandler writerKeyEventExtHandler2;
				do
				{
					writerKeyEventExtHandler2 = writerKeyEventExtHandler;
					WriterKeyEventExtHandler value2 = (WriterKeyEventExtHandler)Delegate.Remove(writerKeyEventExtHandler2, value);
					writerKeyEventExtHandler = Interlocked.CompareExchange(ref writerKeyEventExtHandler_0, value2, writerKeyEventExtHandler2);
				}
				while ((object)writerKeyEventExtHandler != writerKeyEventExtHandler2);
			}
		}

		/// <summary>
		///       扩展的键盘按键松开事件
		///       </summary>
		[DCPublishAPI]
		public event WriterKeyEventExtHandler EventKeyUpExt
		{
			add
			{
				WriterKeyEventExtHandler writerKeyEventExtHandler = writerKeyEventExtHandler_1;
				WriterKeyEventExtHandler writerKeyEventExtHandler2;
				do
				{
					writerKeyEventExtHandler2 = writerKeyEventExtHandler;
					WriterKeyEventExtHandler value2 = (WriterKeyEventExtHandler)Delegate.Combine(writerKeyEventExtHandler2, value);
					writerKeyEventExtHandler = Interlocked.CompareExchange(ref writerKeyEventExtHandler_1, value2, writerKeyEventExtHandler2);
				}
				while ((object)writerKeyEventExtHandler != writerKeyEventExtHandler2);
			}
			remove
			{
				WriterKeyEventExtHandler writerKeyEventExtHandler = writerKeyEventExtHandler_1;
				WriterKeyEventExtHandler writerKeyEventExtHandler2;
				do
				{
					writerKeyEventExtHandler2 = writerKeyEventExtHandler;
					WriterKeyEventExtHandler value2 = (WriterKeyEventExtHandler)Delegate.Remove(writerKeyEventExtHandler2, value);
					writerKeyEventExtHandler = Interlocked.CompareExchange(ref writerKeyEventExtHandler_1, value2, writerKeyEventExtHandler2);
				}
				while ((object)writerKeyEventExtHandler != writerKeyEventExtHandler2);
			}
		}

		/// <summary>
		///       扩展的键盘按键按下事件
		///       </summary>
		[DCPublishAPI]
		public event WriterKeyPressEventExtHandler EventKeyPressExt
		{
			add
			{
				WriterKeyPressEventExtHandler writerKeyPressEventExtHandler = writerKeyPressEventExtHandler_0;
				WriterKeyPressEventExtHandler writerKeyPressEventExtHandler2;
				do
				{
					writerKeyPressEventExtHandler2 = writerKeyPressEventExtHandler;
					WriterKeyPressEventExtHandler value2 = (WriterKeyPressEventExtHandler)Delegate.Combine(writerKeyPressEventExtHandler2, value);
					writerKeyPressEventExtHandler = Interlocked.CompareExchange(ref writerKeyPressEventExtHandler_0, value2, writerKeyPressEventExtHandler2);
				}
				while ((object)writerKeyPressEventExtHandler != writerKeyPressEventExtHandler2);
			}
			remove
			{
				WriterKeyPressEventExtHandler writerKeyPressEventExtHandler = writerKeyPressEventExtHandler_0;
				WriterKeyPressEventExtHandler writerKeyPressEventExtHandler2;
				do
				{
					writerKeyPressEventExtHandler2 = writerKeyPressEventExtHandler;
					WriterKeyPressEventExtHandler value2 = (WriterKeyPressEventExtHandler)Delegate.Remove(writerKeyPressEventExtHandler2, value);
					writerKeyPressEventExtHandler = Interlocked.CompareExchange(ref writerKeyPressEventExtHandler_0, value2, writerKeyPressEventExtHandler2);
				}
				while ((object)writerKeyPressEventExtHandler != writerKeyPressEventExtHandler2);
			}
		}

		/// <summary>
		///       增强型鼠标按键单击事件
		///       </summary>
		[DCPublishAPI]
		[Description("增强型鼠标按键单击事件")]
		public event WriterMouseEventHandler EventMouseClickExt
		{
			add
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_3;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Combine(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_3, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
			remove
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_3;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Remove(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_3, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
		}

		/// <summary>
		///       增强型鼠标按键双击事件
		///       </summary>
		[DCPublishAPI]
		[Description("增强型鼠标按键双击事件")]
		public event WriterMouseEventHandler EventMouseDblClickExt
		{
			add
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_4;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Combine(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_4, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
			remove
			{
				WriterMouseEventHandler writerMouseEventHandler = writerMouseEventHandler_4;
				WriterMouseEventHandler writerMouseEventHandler2;
				do
				{
					writerMouseEventHandler2 = writerMouseEventHandler;
					WriterMouseEventHandler value2 = (WriterMouseEventHandler)Delegate.Remove(writerMouseEventHandler2, value);
					writerMouseEventHandler = Interlocked.CompareExchange(ref writerMouseEventHandler_4, value2, writerMouseEventHandler2);
				}
				while ((object)writerMouseEventHandler != writerMouseEventHandler2);
			}
		}

		/// <summary>
		///       数据过滤事件
		///       </summary>
		[DCPublishAPI]
		[Description("数据过滤事件")]
		public event FilterValueEventHandler FilterValue
		{
			add
			{
				FilterValueEventHandler filterValueEventHandler = filterValueEventHandler_0;
				FilterValueEventHandler filterValueEventHandler2;
				do
				{
					filterValueEventHandler2 = filterValueEventHandler;
					FilterValueEventHandler value2 = (FilterValueEventHandler)Delegate.Combine(filterValueEventHandler2, value);
					filterValueEventHandler = Interlocked.CompareExchange(ref filterValueEventHandler_0, value2, filterValueEventHandler2);
				}
				while ((object)filterValueEventHandler != filterValueEventHandler2);
			}
			remove
			{
				FilterValueEventHandler filterValueEventHandler = filterValueEventHandler_0;
				FilterValueEventHandler filterValueEventHandler2;
				do
				{
					filterValueEventHandler2 = filterValueEventHandler;
					FilterValueEventHandler value2 = (FilterValueEventHandler)Delegate.Remove(filterValueEventHandler2, value);
					filterValueEventHandler = Interlocked.CompareExchange(ref filterValueEventHandler_0, value2, filterValueEventHandler2);
				}
				while ((object)filterValueEventHandler != filterValueEventHandler2);
			}
		}

		/// <summary>
		///       根据知识库节点创建文档元素对象的事件
		///       </summary>
		[Description("根据知识库节点创建文档元素对象的事件")]
		[DCPublishAPI]
		public event CreateElementsByKBEntryEventHandler EventCreateElementsByKBEntry
		{
			add
			{
				CreateElementsByKBEntryEventHandler createElementsByKBEntryEventHandler = createElementsByKBEntryEventHandler_0;
				CreateElementsByKBEntryEventHandler createElementsByKBEntryEventHandler2;
				do
				{
					createElementsByKBEntryEventHandler2 = createElementsByKBEntryEventHandler;
					CreateElementsByKBEntryEventHandler value2 = (CreateElementsByKBEntryEventHandler)Delegate.Combine(createElementsByKBEntryEventHandler2, value);
					createElementsByKBEntryEventHandler = Interlocked.CompareExchange(ref createElementsByKBEntryEventHandler_0, value2, createElementsByKBEntryEventHandler2);
				}
				while ((object)createElementsByKBEntryEventHandler != createElementsByKBEntryEventHandler2);
			}
			remove
			{
				CreateElementsByKBEntryEventHandler createElementsByKBEntryEventHandler = createElementsByKBEntryEventHandler_0;
				CreateElementsByKBEntryEventHandler createElementsByKBEntryEventHandler2;
				do
				{
					createElementsByKBEntryEventHandler2 = createElementsByKBEntryEventHandler;
					CreateElementsByKBEntryEventHandler value2 = (CreateElementsByKBEntryEventHandler)Delegate.Remove(createElementsByKBEntryEventHandler2, value);
					createElementsByKBEntryEventHandler = Interlocked.CompareExchange(ref createElementsByKBEntryEventHandler_0, value2, createElementsByKBEntryEventHandler2);
				}
				while ((object)createElementsByKBEntryEventHandler != createElementsByKBEntryEventHandler2);
			}
		}

		/// <summary>
		///       当前鼠标悬浮的元素改变事件
		///       </summary>
		[Description("当前鼠标悬浮的元素改变事件")]
		[DCPublishAPI]
		public event WriterEventHandler HoverElementChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_9;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_9, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_9;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_9, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       控件Readonly属性值发生改变事件
		///       </summary>
		[DCPublishAPI]
		public event WriterEventHandler EventReadonlyChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_10;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_10, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_10;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_10, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       仅供COM调用的事件，一般不要使用
		///       </summary>
		public event ComVoidHandler VOIDCOMDocumentLoad
		{
			add
			{
				ComVoidHandler comVoidHandler = comVoidHandler_0;
				ComVoidHandler comVoidHandler2;
				do
				{
					comVoidHandler2 = comVoidHandler;
					ComVoidHandler value2 = (ComVoidHandler)Delegate.Combine(comVoidHandler2, value);
					comVoidHandler = Interlocked.CompareExchange(ref comVoidHandler_0, value2, comVoidHandler2);
				}
				while ((object)comVoidHandler != comVoidHandler2);
			}
			remove
			{
				ComVoidHandler comVoidHandler = comVoidHandler_0;
				ComVoidHandler comVoidHandler2;
				do
				{
					comVoidHandler2 = comVoidHandler;
					ComVoidHandler value2 = (ComVoidHandler)Delegate.Remove(comVoidHandler2, value);
					comVoidHandler = Interlocked.CompareExchange(ref comVoidHandler_0, value2, comVoidHandler2);
				}
				while ((object)comVoidHandler != comVoidHandler2);
			}
		}

		/// <summary>
		///       文档加载事件
		///       </summary>
		[Description("文档加载事件")]
		[DCPublishAPI]
		public event WriterEventHandler DocumentLoad
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_11;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_11, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_11;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_11, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       向文档插入对象事件
		///       </summary>
		[DCPublishAPI]
		[Description("向文档插入对象事件")]
		public event InsertObjectEventHandler EventInsertObject
		{
			add
			{
				InsertObjectEventHandler insertObjectEventHandler = insertObjectEventHandler_0;
				InsertObjectEventHandler insertObjectEventHandler2;
				do
				{
					insertObjectEventHandler2 = insertObjectEventHandler;
					InsertObjectEventHandler value2 = (InsertObjectEventHandler)Delegate.Combine(insertObjectEventHandler2, value);
					insertObjectEventHandler = Interlocked.CompareExchange(ref insertObjectEventHandler_0, value2, insertObjectEventHandler2);
				}
				while ((object)insertObjectEventHandler != insertObjectEventHandler2);
			}
			remove
			{
				InsertObjectEventHandler insertObjectEventHandler = insertObjectEventHandler_0;
				InsertObjectEventHandler insertObjectEventHandler2;
				do
				{
					insertObjectEventHandler2 = insertObjectEventHandler;
					InsertObjectEventHandler value2 = (InsertObjectEventHandler)Delegate.Remove(insertObjectEventHandler2, value);
					insertObjectEventHandler = Interlocked.CompareExchange(ref insertObjectEventHandler_0, value2, insertObjectEventHandler2);
				}
				while ((object)insertObjectEventHandler != insertObjectEventHandler2);
			}
		}

		/// <summary>
		///       判断能否插入对象事件
		///       </summary>
		[Description("判断能否插入对象事件")]
		[DCPublishAPI]
		public event CanInsertObjectEventHandler EventCanInsertObject
		{
			add
			{
				CanInsertObjectEventHandler canInsertObjectEventHandler = canInsertObjectEventHandler_0;
				CanInsertObjectEventHandler canInsertObjectEventHandler2;
				do
				{
					canInsertObjectEventHandler2 = canInsertObjectEventHandler;
					CanInsertObjectEventHandler value2 = (CanInsertObjectEventHandler)Delegate.Combine(canInsertObjectEventHandler2, value);
					canInsertObjectEventHandler = Interlocked.CompareExchange(ref canInsertObjectEventHandler_0, value2, canInsertObjectEventHandler2);
				}
				while ((object)canInsertObjectEventHandler != canInsertObjectEventHandler2);
			}
			remove
			{
				CanInsertObjectEventHandler canInsertObjectEventHandler = canInsertObjectEventHandler_0;
				CanInsertObjectEventHandler canInsertObjectEventHandler2;
				do
				{
					canInsertObjectEventHandler2 = canInsertObjectEventHandler;
					CanInsertObjectEventHandler value2 = (CanInsertObjectEventHandler)Delegate.Remove(canInsertObjectEventHandler2, value);
					canInsertObjectEventHandler = Interlocked.CompareExchange(ref canInsertObjectEventHandler_0, value2, canInsertObjectEventHandler2);
				}
				while ((object)canInsertObjectEventHandler != canInsertObjectEventHandler2);
			}
		}

		/// <summary>
		///       文档选择状态正在发生改变事件
		///       </summary>
		[Description("文档选择状态正在发生改变事件")]
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
		///       文档选择状态发生改变后的事件
		///       </summary>
		[DCPublishAPI]
		[Description("文档选择状态发生改变后的事件")]
		public event WriterEventHandler SelectionChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_12;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_12, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_12;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_12, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       仅供COM调用的事件，一般不要使用
		///       </summary>
		public event ComVoidHandler VOIDCOMSelectionChanged
		{
			add
			{
				ComVoidHandler comVoidHandler = comVoidHandler_1;
				ComVoidHandler comVoidHandler2;
				do
				{
					comVoidHandler2 = comVoidHandler;
					ComVoidHandler value2 = (ComVoidHandler)Delegate.Combine(comVoidHandler2, value);
					comVoidHandler = Interlocked.CompareExchange(ref comVoidHandler_1, value2, comVoidHandler2);
				}
				while ((object)comVoidHandler != comVoidHandler2);
			}
			remove
			{
				ComVoidHandler comVoidHandler = comVoidHandler_1;
				ComVoidHandler comVoidHandler2;
				do
				{
					comVoidHandler2 = comVoidHandler;
					ComVoidHandler value2 = (ComVoidHandler)Delegate.Remove(comVoidHandler2, value);
					comVoidHandler = Interlocked.CompareExchange(ref comVoidHandler_1, value2, comVoidHandler2);
				}
				while ((object)comVoidHandler != comVoidHandler2);
			}
		}

		/// <summary>
		///       文档内容发生改变事件
		///       </summary>
		[Description("文档内容发生改变事件")]
		[DCPublishAPI]
		public event WriterEventHandler DocumentContentChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_13;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_13, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_13;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_13, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       仅供COM调用的事件，一般不要使用
		///       </summary>
		public event ComVoidHandler VOIDCOMDocumentContentChanged
		{
			add
			{
				ComVoidHandler comVoidHandler = comVoidHandler_2;
				ComVoidHandler comVoidHandler2;
				do
				{
					comVoidHandler2 = comVoidHandler;
					ComVoidHandler value2 = (ComVoidHandler)Delegate.Combine(comVoidHandler2, value);
					comVoidHandler = Interlocked.CompareExchange(ref comVoidHandler_2, value2, comVoidHandler2);
				}
				while ((object)comVoidHandler != comVoidHandler2);
			}
			remove
			{
				ComVoidHandler comVoidHandler = comVoidHandler_2;
				ComVoidHandler comVoidHandler2;
				do
				{
					comVoidHandler2 = comVoidHandler;
					ComVoidHandler value2 = (ComVoidHandler)Delegate.Remove(comVoidHandler2, value);
					comVoidHandler = Interlocked.CompareExchange(ref comVoidHandler_2, value2, comVoidHandler2);
				}
				while ((object)comVoidHandler != comVoidHandler2);
			}
		}

		/// <summary>
		///       查询下拉列表项目事件
		///       </summary>
		[DCPublishAPI]
		[Description("查询下拉列表项目事件")]
		public event QueryListItemsEventHandler QueryListItems
		{
			add
			{
				QueryListItemsEventHandler queryListItemsEventHandler = queryListItemsEventHandler_0;
				QueryListItemsEventHandler queryListItemsEventHandler2;
				do
				{
					queryListItemsEventHandler2 = queryListItemsEventHandler;
					QueryListItemsEventHandler value2 = (QueryListItemsEventHandler)Delegate.Combine(queryListItemsEventHandler2, value);
					queryListItemsEventHandler = Interlocked.CompareExchange(ref queryListItemsEventHandler_0, value2, queryListItemsEventHandler2);
				}
				while ((object)queryListItemsEventHandler != queryListItemsEventHandler2);
			}
			remove
			{
				QueryListItemsEventHandler queryListItemsEventHandler = queryListItemsEventHandler_0;
				QueryListItemsEventHandler queryListItemsEventHandler2;
				do
				{
					queryListItemsEventHandler2 = queryListItemsEventHandler;
					QueryListItemsEventHandler value2 = (QueryListItemsEventHandler)Delegate.Remove(queryListItemsEventHandler2, value);
					queryListItemsEventHandler = Interlocked.CompareExchange(ref queryListItemsEventHandler_0, value2, queryListItemsEventHandler2);
				}
				while ((object)queryListItemsEventHandler != queryListItemsEventHandler2);
			}
		}

		/// <summary>
		///       文档内容中的用户修改痕迹列表信息发生改变事件
		///       </summary>
		[DCPublishAPI]
		[Description("文档内容中的用户修改痕迹列表信息发生改变事件")]
		public event WriterEventHandler UserTrackListChanged
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_14;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_14, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_14;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_14, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       结束执行编辑器命令事件
		///       </summary>
		[Description("结束执行编辑器命令事件")]
		[DCPublishAPI]
		public event WriterCommandEventHandler AfterExecuteCommand
		{
			add
			{
				WriterCommandEventHandler writerCommandEventHandler = writerCommandEventHandler_1;
				WriterCommandEventHandler writerCommandEventHandler2;
				do
				{
					writerCommandEventHandler2 = writerCommandEventHandler;
					WriterCommandEventHandler value2 = (WriterCommandEventHandler)Delegate.Combine(writerCommandEventHandler2, value);
					writerCommandEventHandler = Interlocked.CompareExchange(ref writerCommandEventHandler_1, value2, writerCommandEventHandler2);
				}
				while ((object)writerCommandEventHandler != writerCommandEventHandler2);
			}
			remove
			{
				WriterCommandEventHandler writerCommandEventHandler = writerCommandEventHandler_1;
				WriterCommandEventHandler writerCommandEventHandler2;
				do
				{
					writerCommandEventHandler2 = writerCommandEventHandler;
					WriterCommandEventHandler value2 = (WriterCommandEventHandler)Delegate.Remove(writerCommandEventHandler2, value);
					writerCommandEventHandler = Interlocked.CompareExchange(ref writerCommandEventHandler_1, value2, writerCommandEventHandler2);
				}
				while ((object)writerCommandEventHandler != writerCommandEventHandler2);
			}
		}

		/// <summary>
		///       开始执行编辑器命令事件
		///       </summary>
		[Description("开始执行编辑器命令事件")]
		[DCPublishAPI]
		public event WriterCommandEventHandler BeforeExecuteCommand
		{
			add
			{
				WriterCommandEventHandler writerCommandEventHandler = writerCommandEventHandler_2;
				WriterCommandEventHandler writerCommandEventHandler2;
				do
				{
					writerCommandEventHandler2 = writerCommandEventHandler;
					WriterCommandEventHandler value2 = (WriterCommandEventHandler)Delegate.Combine(writerCommandEventHandler2, value);
					writerCommandEventHandler = Interlocked.CompareExchange(ref writerCommandEventHandler_2, value2, writerCommandEventHandler2);
				}
				while ((object)writerCommandEventHandler != writerCommandEventHandler2);
			}
			remove
			{
				WriterCommandEventHandler writerCommandEventHandler = writerCommandEventHandler_2;
				WriterCommandEventHandler writerCommandEventHandler2;
				do
				{
					writerCommandEventHandler2 = writerCommandEventHandler;
					WriterCommandEventHandler value2 = (WriterCommandEventHandler)Delegate.Remove(writerCommandEventHandler2, value);
					writerCommandEventHandler = Interlocked.CompareExchange(ref writerCommandEventHandler_2, value2, writerCommandEventHandler2);
				}
				while ((object)writerCommandEventHandler != writerCommandEventHandler2);
			}
		}

		/// <summary>
		///       脚本发生错误事件
		///       </summary>
		[DCPublishAPI]
		[Description("脚本发生错误事件")]
		public event WriterEventHandler ScriptError
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_15;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_15, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_15;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_15, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       自定义处理命令错误的事件
		///       </summary>
		[Description("自定义处理命令错误的事件")]
		[DCPublishAPI]
		public event CommandErrorEventHandler CommandError
		{
			add
			{
				CommandErrorEventHandler commandErrorEventHandler = commandErrorEventHandler_0;
				CommandErrorEventHandler commandErrorEventHandler2;
				do
				{
					commandErrorEventHandler2 = commandErrorEventHandler;
					CommandErrorEventHandler value2 = (CommandErrorEventHandler)Delegate.Combine(commandErrorEventHandler2, value);
					commandErrorEventHandler = Interlocked.CompareExchange(ref commandErrorEventHandler_0, value2, commandErrorEventHandler2);
				}
				while ((object)commandErrorEventHandler != commandErrorEventHandler2);
			}
			remove
			{
				CommandErrorEventHandler commandErrorEventHandler = commandErrorEventHandler_0;
				CommandErrorEventHandler commandErrorEventHandler2;
				do
				{
					commandErrorEventHandler2 = commandErrorEventHandler;
					CommandErrorEventHandler value2 = (CommandErrorEventHandler)Delegate.Remove(commandErrorEventHandler2, value);
					commandErrorEventHandler = Interlocked.CompareExchange(ref commandErrorEventHandler_0, value2, commandErrorEventHandler2);
				}
				while ((object)commandErrorEventHandler != commandErrorEventHandler2);
			}
		}

		/// <summary>
		///       文档打印事件
		///       </summary>
		[DCPublishAPI]
		[Description("文档打印事件")]
		public event WriterDocumentPrintedEventHandler DocumentPrinted
		{
			add
			{
				WriterDocumentPrintedEventHandler writerDocumentPrintedEventHandler = writerDocumentPrintedEventHandler_0;
				WriterDocumentPrintedEventHandler writerDocumentPrintedEventHandler2;
				do
				{
					writerDocumentPrintedEventHandler2 = writerDocumentPrintedEventHandler;
					WriterDocumentPrintedEventHandler value2 = (WriterDocumentPrintedEventHandler)Delegate.Combine(writerDocumentPrintedEventHandler2, value);
					writerDocumentPrintedEventHandler = Interlocked.CompareExchange(ref writerDocumentPrintedEventHandler_0, value2, writerDocumentPrintedEventHandler2);
				}
				while ((object)writerDocumentPrintedEventHandler != writerDocumentPrintedEventHandler2);
			}
			remove
			{
				WriterDocumentPrintedEventHandler writerDocumentPrintedEventHandler = writerDocumentPrintedEventHandler_0;
				WriterDocumentPrintedEventHandler writerDocumentPrintedEventHandler2;
				do
				{
					writerDocumentPrintedEventHandler2 = writerDocumentPrintedEventHandler;
					WriterDocumentPrintedEventHandler value2 = (WriterDocumentPrintedEventHandler)Delegate.Remove(writerDocumentPrintedEventHandler2, value);
					writerDocumentPrintedEventHandler = Interlocked.CompareExchange(ref writerDocumentPrintedEventHandler_0, value2, writerDocumentPrintedEventHandler2);
				}
				while ((object)writerDocumentPrintedEventHandler != writerDocumentPrintedEventHandler2);
			}
		}

		/// <summary>
		///       通知应用程序更新工具条或菜单的状态。
		///       </summary>
		/// <remarks>
		///       在控件的SelectionChanged事件中更新工具条和菜单的状态性能比较差，因为SelectionChanged事件触发的过于频繁。
		///       而使用本事件能大幅降低更新频率。
		///       </remarks>
		[DCPublishAPI]
		[Description("通知更新工具条状态事件")]
		public event WriterEventHandler EventUpdateToolarState
		{
			add
			{
				WriterEventHandler writerEventHandler = writerEventHandler_16;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Combine(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_16, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
			remove
			{
				WriterEventHandler writerEventHandler = writerEventHandler_16;
				WriterEventHandler writerEventHandler2;
				do
				{
					writerEventHandler2 = writerEventHandler;
					WriterEventHandler value2 = (WriterEventHandler)Delegate.Remove(writerEventHandler2, value);
					writerEventHandler = Interlocked.CompareExchange(ref writerEventHandler_16, value2, writerEventHandler2);
				}
				while ((object)writerEventHandler != writerEventHandler2);
			}
		}

		/// <summary>
		///       获得指定编号的子文档内容XML字符串
		///       </summary>
		/// <param name="id">子文档元素编号</param>
		/// <returns>获得的XML字符串</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual string GetSubDoumentContentXmlByID(string string_5)
		{
			return Document.GetSubDoumentContentXmlByID(string_5);
		}

		/// <summary>
		///       追加新的子文档对象
		///       </summary>
		/// <param name="newSubDoc">子文档对象</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void AppendSubDocument(XTextSubDocumentElement newSubDoc)
		{
			Document.AppendSubDocument(newSubDoc);
		}

		/// <summary>
		///       在当前位置处插入子文档元素
		///       </summary>
		/// <param name="newSubDoc">要插入的子文档对象</param>
		/// <param name="insertUp">true:在上面插入；false:在下面插入</param>
		[ComVisible(true)]
		public void InsertSubDocuentAtCurrentPosition(XTextSubDocumentElement newSubDoc, bool insertUp)
		{
			Document.InsertSubDocuentAtCurrentPosition(newSubDoc, insertUp);
		}

		[DCInternal]
		public virtual void vmethod_0(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			InnerViewControl.method_151(xtextElement_0, xtextElement_1);
		}

		internal virtual bool vmethod_1(XTextElement xtextElement_0, DragEventArgs dragEventArgs_0, float float_0, float float_1)
		{
			return InnerViewControl.method_154(xtextElement_0, dragEventArgs_0, float_0, float_1);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DCInternal]
		public bool method_0(string string_5, bool bool_12)
		{
			return InnerViewControl.method_155(string_5, bool_12);
		}

		internal void method_1()
		{
			InnerViewControl.method_156();
		}

		private ElementEventTemplate method_2(Type type_0)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_159))
			{
				return null;
			}
			ElementEventTemlateMap globalEventTemplates = GlobalEventTemplates;
			if (globalEventTemplates != null && globalEventTemplates.ContainsKey(type_0))
			{
				return globalEventTemplates[type_0];
			}
			return null;
		}

		private void method_3(Type type_0, ElementEventTemplate elementEventTemplate_0)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_159))
			{
				return;
			}
			ElementEventTemlateMap globalEventTemplates = GlobalEventTemplates;
			if (globalEventTemplates == null)
			{
				return;
			}
			if (elementEventTemplate_0 == null)
			{
				if (globalEventTemplates.ContainsKey(type_0))
				{
					globalEventTemplates.Remove(type_0);
				}
			}
			else
			{
				globalEventTemplates[type_0] = elementEventTemplate_0;
			}
		}

		/// <summary>
		///       获得指定元素使用的事件模板列表,包含绑定的列表和相关的全局列表
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>事件模板列表</returns>
		[DCPublishAPI]
		public virtual ElementEventTemplateList GetElementEventTemplates(XTextElement element)
		{
			return InnerViewControl.method_229(element);
		}

		/// <summary>
		///       设置承载的原生态的控件。
		///       </summary>
		/// <param name="handle">控件句柄</param>
		[DCInternal]
		[ComVisible(true)]
		public bool SetNativeHostedControlHandle(string hostedElementID, IntPtr handle)
		{
			return (GetElementById(hostedElementID) as XTextControlHostElement)?.SetNativeHostedControlHandle(handle) ?? false;
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
			if (Document != null)
			{
				return Document.ContentStyles.GetStyleIndexByString(styleString);
			}
			return -1;
		}

		/// <summary>
		///       文档内容进行校验，返回校验结果
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public ValueValidateResultList DocumentValueValidate()
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			return InnerViewControl.Document.ValueValidate();
		}

		/// <summary>
		///       文档内容进行校验，返回校验结果
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public ValueValidateResultList DocumentValueValidateWithCreateDocumentComments()
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			return InnerViewControl.Document.ValueValidateWithCreateDocumentComments();
		}

		/// <summary>
		///       文档内容进行校验，以XML形式返回校验结果
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string DocumentValueValidateXML()
		{
			ValueValidateResultList valueValidateResultList = InnerViewControl.Document.ValueValidate();
			if (valueValidateResultList == null || valueValidateResultList.Count == 0)
			{
				return "";
			}
			return XMLHelper.SaveObjectToIndentXMLString(valueValidateResultList);
		}

		/// <summary>
		///       重新设置OutlineNodes属性值
		///       </summary>
		[DCPublishAPI]
		[DCInternal]
		public void ResetOutlineNodes()
		{
			Document.ResetOutlineNodes();
		}

		/// <summary>
		///       根据一个XML字符串创建一个文档元素对象
		///       </summary>
		/// <param name="xml">XML字符串</param>
		/// <returns>创建的文档元素对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual XTextElement CreateElementByXMLFragment(string string_5)
		{
			return Document.CreateElementByXMLFragment(string_5);
		}

		/// <summary>
		///        DCWriter内部使用。重置文档正文排版偏移量
		///       </summary>
		/// <returns>操作是否修改了数据</returns>
		[DCPublishAPI]
		[DCInternal]
		public bool ResetBodyLayoutOffset()
		{
			if (Document.BodyLayoutOffset != 0f)
			{
				Document.BodyLayoutOffset = 0f;
				RefreshDocumentExt(refreshSize: false, executeLayout: true);
				return true;
			}
			return false;
		}

		/// <summary>
		///       创建一个背景模式设置器
		///       </summary>
		/// <returns>创建的设置器</returns>
		[DCInternal]
		[ComVisible(false)]
		public IDisposable CreateBackgroundModeSetter()
		{
			return InnerViewControl.method_242();
		}

		/// <summary>
		///       获得指定编号的输入域的InnerValue属性值。
		///       </summary>
		/// <param name="id">输入域编号</param>
		/// <returns>获得的属性值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual string GetInputFieldInnerValue(string string_5)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetInputFieldInnerValue(string_5);
		}

		/// <summary>
		///       设置指定编号的输入域的InnerValue属性值。
		///       </summary>
		/// <param name="id">输入域编号</param>
		/// <param name="newValue">新的属性值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetInputFieldInnerValue(string string_5, string newValue)
		{
			return Document.SetInputFieldInnerValue(string_5, newValue);
		}

		/// <summary>
		///       设置文档元素文本内容
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetElementTextByID(string string_5, string text)
		{
			return Document.SetElementTextByID(string_5, text);
		}

		/// <summary>
		///       获得文档元素文本内容
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>获得的文本</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetElementTextByID(string string_5)
		{
			return Document.GetElementTextByID(string_5);
		}

		/// <summary>
		///       设置文档元素文本内容
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="text">文本值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[Obsolete("请使用SetElementTextByID(id,text)")]
		public bool SetElementText(string string_5, string text)
		{
			return Document.SetElementTextByID(string_5, text);
		}

		/// <summary>
		///       获得文档元素文本内容
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>获得的文本</returns>
		[Obsolete("请使用GetElementTextByID(id)")]
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetElementText(string string_5)
		{
			return Document.GetElementTextByID(string_5);
		}

		/// <summary>
		///       获得单复选框文档元素的勾选状态,如果没找到元素则返回false。
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <returns>元素的勾选状态</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool GetElementChecked(string string_5)
		{
			return (GetElementById(string_5) as XTextCheckBoxElementBase)?.Checked ?? false;
		}

		/// <summary>
		///       设置单/复选框的勾选状态
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="newChecked">新的勾选状态</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetElementChecked(string string_5, bool newChecked)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = GetElementById(string_5) as XTextCheckBoxElementBase;
			if (xTextCheckBoxElementBase == null)
			{
				return false;
			}
			xTextCheckBoxElementBase.InnerEditorChecked = newChecked;
			return true;
		}

		/// <summary>
		///       获得文档元素的可见性
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>可见性</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool GetElementVisible(string string_5)
		{
			return Document.GetElementVisible(string_5);
		}

		/// <summary>
		///       设置文档元素可见性
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="visible">可见性</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetElementVisible(string string_5, bool visible)
		{
			return Document.SetElementVisible(string_5, visible);
		}

		/// <summary>
		///       为下拉列表元素添加下拉列表项目
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="text">项目的文本值</param>
		/// <param name="Value">项目的数值</param>
		/// <param name="saveToXml">添加的项目是否保存在XML中</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool AddDropdownListItem(string string_5, string text, string Value, bool saveToXml)
		{
			return Document.AddDropdownListItem(string_5, text, Value, saveToXml);
		}

		/// <summary>
		///       设置文档元素自定义属性
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetElementProperty(string string_5, string name, string Value)
		{
			return Document.SetElementProperty(string_5, name, Value);
		}

		/// <summary>
		///       获得文档元素的自定义属性值
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetElementProperty(string string_5, string name)
		{
			return Document.GetElementProperty(string_5, name);
		}

		/// <summary>
		///       让指定文档元素获得输入焦点
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool FocusElementById(string string_5)
		{
			XTextElement elementById = GetElementById(string_5);
			if (elementById != null)
			{
				elementById.Focus();
				return true;
			}
			return false;
		}

		/// <summary>
		///       选中文档元素
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SelectElementById(string string_5)
		{
			XTextElement elementById = GetElementById(string_5);
			if (elementById != null)
			{
				elementById.Select();
				return true;
			}
			return false;
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
			return Document.Parameters.GetValue(name);
		}

		/// <summary>
		///       设置文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">新的参数值</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SetDocumentParameterValue(string name, object Value)
		{
			Document.Parameters.SetValue(name, Value);
		}

		/// <summary>
		///       设置XML格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="xmlText">参数值</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SetDocumentParameterValueXml(string name, string xmlText)
		{
			Document.Parameters.SetXmlValue(name, xmlText);
		}

		/// <summary>
		///       获得Xml格式的文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetDocumentParameterValueXml(string name)
		{
			return Document.Parameters.GetXmlValue(name);
		}

		/// <summary>
		///       设置参数是否有效
		///       </summary>
		/// <param name="parameterName">参数名</param>
		/// <param name="enabled">是否有效</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SetDocumentParameterEnabled(string parameterName, bool enabled)
		{
			Document.SetParameterEnabled(parameterName, enabled);
		}

		/// <summary>
		///       获得参数是否有效
		///       </summary>
		/// <param name="parameterName">参数名</param>
		/// <returns>是否有效</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool GetDocumentParameterEnabled(string parameterName)
		{
			return Document.GetParameterEnabled(parameterName);
		}

		/// <summary>
		///       检测数据源填充操作导致的修改文档元素的个数，但不真正填充数据源，不会修改文档内容。
		///       </summary>
		/// <returns>结果信息列表</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public DetectResultForValueBindingModifiedList DetectValueBindingModified()
		{
			if (Document == null)
			{
				return null;
			}
			return Document.DetectValueBindingModified();
		}

		/// <summary>
		///       检测数据源填充操作导致的修改文档元素的相关信息，但不真正填充数据源，不会修改文档内容。
		///       </summary>
		/// <returns>结果信息列表</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetDetectValueBindingModifiedMessage()
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetDetectValueBindingModifiedMessage();
		}

		public bool method_4(XTextDocument xtextDocument_0)
		{
			if (InnerViewControl != null)
			{
				return InnerViewControl.method_243(xtextDocument_0);
			}
			return false;
		}

		/// <summary>
		///       获得当前插入点所在的指定类型的文档元素对象。
		///       </summary>
		/// <param name="elementType">指定的文档元素类型</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public XTextElement GetCurrentElement(Type elementType)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetCurrentElement(elementType, includeThis: true);
		}

		/// <summary>
		///       获得当前插入点所在的指定类型的文档元素对象。
		///       </summary>
		/// <param name="typeName">指定的文档元素类型的名称</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElement GetCurrentElementByTypeName(string typeName)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElement currentElementByTypeName = Document.GetCurrentElementByTypeName(typeName);
			CollectOuterReference(currentElementByTypeName);
			return currentElementByTypeName;
		}

		/// <summary>
		///       返回包含数据的XML片段,本函数返回的XML字符串可以作为编辑器控件或文档对象的函数CreateElementByXMLFragment()的参数。
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>生成的XML片段字符串</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual string GetElementXMLFragmentByID(string string_5)
		{
			return Document.GetElementXMLFragmentByID(string_5);
		}

		/// <summary>
		///       返回元素内置内容的文档XML字符串
		///       </summary>
		/// <param name="id">文档元素对象</param>
		/// <returns>获得的XML字符串</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual string GetElementOuterXmlByID(string string_5)
		{
			return Document.GetElementOuterXmlByID(string_5);
		}

		/// <summary>
		///       返回元素外置内容的文档XML字符串
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <returns>XML字符串</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual string GetElementInnerXmlByID(string string_5)
		{
			return Document.GetElementInnerXmlByID(string_5);
		}

		/// <summary>
		///       在子孙文档元素中获得第一个指定类型的文档元素，但不包括本元素本身。
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public XTextElement GetFirstElementByType(Type elementType)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetFirstElementByType(elementType);
		}

		/// <summary>
		///       在子孙文档元素中获得第一个指定类型的文档元素，但不包括本元素本身。
		///       </summary>
		/// <param name="elementTypeName">文档元素类型名称</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElement GetFirstElementByTypeName(string elementTypeName)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElement firstElementByTypeName = Document.GetFirstElementByTypeName(elementTypeName);
			CollectOuterReference(firstElementByTypeName);
			return firstElementByTypeName;
		}

		/// <summary>
		///       获得表单数据
		///       </summary>
		/// <param name="name">字段名称</param>
		/// <returns>获得的表单数值</returns>
		[DCPublishAPI]
		public string GetFormValue(string name)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetFormValue(name);
		}

		/// <summary>
		///       获得文档的Html文本代码
		///       </summary>
		/// <param name="IncludeSelectionOnly">是否只包含选择区域</param>
		/// <returns>获得的RTF文本代码字符串</returns>
		[DCPublishAPI]
		public string GetHtmlText(bool IncludeSelectionOnly)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetHtmlText(IncludeSelectionOnly);
		}

		/// <summary>
		///       获得指定ID号的文档元素对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">编号</param>
		/// <returns>找到的文档元素对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public XTextElement GetElementById(string string_5)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElement elementById = Document.GetElementById(string_5);
			CollectOuterReference(elementById);
			return elementById;
		}

		[DCInternal]
		[ComVisible(false)]
		public virtual void CollectOuterReference(object instance)
		{
		}

		[DCInternal]
		[ComVisible(false)]
		public virtual void CollectOuterReferences(IList instances)
		{
		}

		/// <summary>
		///       获得文档中指定编号的元素对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <param name="idAttributeOnly">只匹配元素ID属性</param>
		/// <returns>找到的元素对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual XTextElement GetElementByIdExt(string string_5, bool idAttributeOnly)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElement elementByIdExt = Document.GetElementByIdExt(string_5, idAttributeOnly);
			CollectOuterReference(elementByIdExt);
			return elementByIdExt;
		}

		/// <summary>
		///       获得文档中指定name值的元素对象,查找时name值区分大小写的。
		///       </summary>
		/// <param name="name">指定的编号</param>
		/// <returns>找到的元素对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElementList GetElementsByName(string name)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElementList elementsByName = Document.GetElementsByName(name);
			CollectOuterReferences(elementsByName);
			return elementsByName;
		}

		/// <summary>
		///       获得本文档元素容器包含的所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementType">元素类型</param>
		/// <returns>获得的元素列表</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public XTextElementList GetElementsByType(Type elementType)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetElementsByType(elementType);
		}

		/// <summary>
		///       获得文档中所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementTypeName">元素类型名称</param>
		/// <returns>获得的元素列表</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public XTextElementList GetElementsByTypeName(string elementTypeName)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElementList elementsByTypeName = Document.GetElementsByTypeName(elementTypeName);
			CollectOuterReferences(elementsByTypeName);
			return elementsByTypeName;
		}

		/// <summary>
		///       获得文档中所有指定编号的元素对象列表,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <returns>找到的元素对象列表</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElementList GetElementsById(string string_5)
		{
			if (Document == null)
			{
				return null;
			}
			XTextElementList elementsById = Document.GetElementsById(string_5);
			CollectOuterReferences(elementsById);
			return elementsById;
		}

		/// <summary>
		///       获得指定ID号的输入域对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">ID号</param>
		/// <returns>找到的输入域元素对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public XTextInputFieldElement GetInputFieldElementById(string string_5)
		{
			return GetElementById(string_5) as XTextInputFieldElement;
		}

		/// <summary>
		///       获得指定ID号的表格对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">ID号</param>
		/// <returns>找到的表格元素对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextTableElement GetTableElementById(string string_5)
		{
			return GetElementById(string_5) as XTextTableElement;
		}

		/// <summary>
		///       获得指定文档元素的属性
		///       </summary>
		/// <param name="id">元素编号</param>
		/// <param name="attributeName">属性名称</param>
		/// <returns>属性值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetElementAttribute(string string_5, string attributeName)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetElementAttribute(string_5, attributeName);
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
		public bool SetElementAttribute(string string_5, string attributeName, string attributeValue)
		{
			if (Document == null)
			{
				return false;
			}
			return Document.SetElementAttribute(string_5, attributeName, attributeValue);
		}

		/// <summary>
		///       获得文档中指定类型的下一个元素
		///       </summary>
		/// <param name="startElement">开始查找的起始元素</param>
		/// <param name="nextElementType">要查找的元素的类型</param>
		/// <param name="includeHiddenElement">查找的时候是否查找隐藏的文档元素对象</param>
		/// <returns>找到的元素</returns>
		[DCPublishAPI]
		public XTextElement GetNextElement(XTextElement startElement, Type nextElementType, bool includeHiddenElement)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetNextElement(startElement, nextElementType, includeHiddenElement);
		}

		/// <summary>
		///       获得文档中指定类型的下一个元素
		///       </summary>
		/// <param name="startElement">开始查找的起始元素</param>
		/// <param name="nextElementType">要查找的元素的类型</param>
		/// <returns>找到的元素</returns>
		[DCPublishAPI]
		public XTextElement GetNextElement(XTextElement startElement, Type nextElementType)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetNextElement(startElement, nextElementType);
		}

		/// <summary>
		///       获得系统当前日期事件
		///       </summary>
		/// <returns>日期事件</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public DateTime GetNowDateTime()
		{
			if (Document == null)
			{
				return DateTime.Now;
			}
			return Document.GetNowDateTime();
		}

		/// <summary>
		///       获得文档中指定类型的下一个元素
		///       </summary>
		/// <param name="startElement">开始查找的起始元素</param>
		/// <param name="nextElementTypeName">要查找的元素的类型的名称</param>
		/// <returns>找到的元素</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public XTextElement GetNextElementByTypeName(XTextElement startElement, string nextElementTypeName)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetNextElementByTypeName(startElement, nextElementTypeName);
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
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetCheckedValueList(string spliter, bool includeCheckbox, bool includeRadio, bool includeElementID, bool includeElementName)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetCheckedValueList(spliter, includeCheckbox, includeRadio, includeElementID, includeElementName);
		}

		/// <summary>
		///       获得指定表格中的指定单元格
		///       </summary>
		/// <param name="tableID">编号编号</param>
		/// <param name="rowIndex">从0开始计算的行号</param>
		/// <param name="colIndex">从0开始计算的列号</param>
		/// <returns>获得的单元格对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public XTextTableCellElement GetTableCell(string tableID, int rowIndex, int colIndex)
		{
			if (Document == null)
			{
				return null;
			}
			XTextTableCellElement tableCell = Document.GetTableCell(tableID, rowIndex, colIndex);
			CollectOuterReference(tableCell);
			return tableCell;
		}

		/// <summary>
		///       获得表格单元格的文本内容
		///       </summary>
		/// <param name="tableID">表格编号</param>
		/// <param name="rowIndex">从0开始计算的行号</param>
		/// <param name="colIndex">从0开始计算的列号</param>
		/// <returns>单元格文本</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual string GetTableCellText(string tableID, int rowIndex, int colIndex)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetTableCellText(tableID, rowIndex, colIndex);
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
		public virtual bool SetTableCellText(string tableID, int rowIndex, int colIndex, string newText)
		{
			if (Document == null)
			{
				return false;
			}
			return Document.SetTableCellText(tableID, rowIndex, colIndex, newText);
		}

		/// <summary>
		///       获得控件客户区中指定位置处的文档元素对象
		///       </summary>
		/// <param name="x">X坐标</param>
		/// <param name="y">Y坐标</param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElement GetElementByPosition(int int_4, int int_5)
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			XTextElement xTextElement = InnerViewControl.method_253(int_4, int_5);
			CollectOuterReference(xTextElement);
			return xTextElement;
		}

		/// <summary>
		///       获得指定的文档元素在编辑器控件客户区中的边界
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>边界</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public Rectangle GetElementClientBounds(XTextElement element)
		{
			if (InnerViewControl == null)
			{
				return Rectangle.Empty;
			}
			return InnerViewControl.method_254(element);
		}

		/// <summary>
		///       获得文档中所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementType">元素类型</param>
		/// <returns>获得的元素列表</returns>
		[Obsolete("请使用GetElementsByType(Type elementType)")]
		[ComVisible(false)]
		public XTextElementList GetSpecifyElements(Type elementType)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetElementsByType(elementType);
		}

		/// <summary>
		///       获得文档中所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="typeName">元素类型名称</param>
		/// <returns>获得的元素列表</returns>
		[Obsolete("请使用GetElementsByTypeName(string typeName)")]
		[ComVisible(true)]
		public XTextElementList GetSpecifyElementsByTypeName(string typeName)
		{
			int num = 9;
			Type controlType = ControlHelper.GetControlType(typeName, typeof(XTextElement));
			if (controlType == null)
			{
				throw new ArgumentException("TypeName=" + typeName);
			}
			XTextElementList specifyElements = GetSpecifyElements(controlType);
			CollectOuterReferences(specifyElements);
			return specifyElements;
		}

		/// <summary>
		///       清空重做/撤销操作信息
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void ClearUndo()
		{
			int num = 9;
			if (Document != null)
			{
				Document.CancelLogUndo();
				Document.UndoList.Clear();
				if (CommandControler != null)
				{
					CommandControler.InvalidateCommandState("Undo");
					CommandControler.InvalidateCommandState("Redo");
				}
			}
		}

		/// <summary>
		///       清空文档内容
		///       </summary>
		[DCPublishAPI]
		public void ClearContent()
		{
			method_5();
			if (InnerViewControl != null)
			{
				InnerViewControl.method_255();
			}
		}

		[DCInternal]
		internal void method_5()
		{
			if (Document != null && Document.HighlightManager != null)
			{
				Document.HighlightManager.imethod_4();
			}
			ClearEventMessage();
			method_13();
			if (DocumentControler != null)
			{
				DocumentControler.method_0();
			}
			if (ctlHRule != null)
			{
				ctlHRule.method_15();
			}
			if (ctlVRule != null)
			{
				ctlVRule.method_15();
			}
		}

		/// <summary>
		///       获得指定页的剩余空白行数
		///       </summary>
		/// <param name="pageIndex">从1开始计算的页码号</param>
		/// <param name="specifyLineHeight">指定的行高</param>
		/// <returns>剩余的空白行数</returns>
		[DCPublishAPI]
		public int GetSurplusLinesOfSpeifyPage(int pageIndex, float specifyLineHeight)
		{
			if (InnerViewControl == null)
			{
				return 0;
			}
			return InnerViewControl.method_256(pageIndex, specifyLineHeight);
		}

		/// <summary>
		///       根据元素提示文本信息列表来更新用户界面
		///       </summary>
		/// <param name="checkVersion">是否检测提示信息版本号</param>
		[DCInternal]
		public void UpdateToolTip(bool checkVersion)
		{
			InnerViewControl.method_95(checkVersion);
		}

		internal void method_6()
		{
			InnerViewControl.method_96();
		}

		internal void method_7(XTextDocumentContentElement xtextDocumentContentElement_0)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_257(xtextDocumentContentElement_0);
			}
		}

		/// <summary>
		///       Invalidate方法的COM接口
		///       </summary>
		public void ComInvalidate()
		{
			InnerViewControl.method_230();
		}

		/// <summary>
		///       面向COM的设置控件属性值
		///       </summary>
		/// <remarks>有些属性值类型不是COM公开的，无法直接设置。因此采用字符串的方式来试图设置控件属性值。
		///       例如 ctl.ComSetProperty("DocumentOptions.BehaviorOptions.EnableScript","false");</remarks>
		/// <param name="propertyName">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ComSetProperty(string propertyName, string Value)
		{
			return ValueTypeHelper.SetPropertyValueMultiLayer(this, propertyName, Value, throwExecption: true);
		}

		/// <summary>
		///       面向COM的获得控件的属性值
		///       </summary>
		/// <remarks>有些属性值类型不是COM公开的，无法直接设置。因此采用指定名称来试图设置控件属性值。
		///       例如 ctl.ComGetProperty("DocumentOptions.BehaviorOptions.EnableScript") 返回true/false.</remarks>
		/// <param name="propertyName">属性名</param>
		/// <returns>获得的属性值</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		public object ComGetProperty(string propertyName)
		{
			return ValueTypeHelper.GetPropertyValueMultiLayer(this, propertyName, null, throwExecption: true);
		}

		/// <summary>
		///       面向COM的调用控件的方法
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <param name="paramters">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object ComCallMethodByName(string name, string paramters)
		{
			return WriterUtils.smethod_18(this, name, paramters, bool_2: false);
		}

		/// <summary>
		///       面向COM的调用控件的方法
		///       </summary>
		/// <param name="instance">对象实例</param>
		/// <param name="name">方法名称</param>
		/// <param name="paramters">参数</param>
		/// <returns>方法返回值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		public object ComCallInstanceMethodByName(object instance, string name, string paramters)
		{
			return WriterUtils.smethod_18(instance, name, paramters, bool_2: false);
		}

		/// <summary>
		///       创建指定名称的类型的对象实例
		///       </summary>
		/// <param name="typeName">类型名称</param>
		/// <returns>创建的对象实例</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(true)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
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
		///       检查对象属性值，如果为空则创建属性值
		///       </summary>
		/// <param name="instance">对象实例</param>
		/// <param name="propertyName">属性名，不区分大小写</param>
		/// <param name="valueTypeName">指定的属性值类型名称</param>
		/// <returns>本操作是否创建了对象实例</returns>
		[DCInternal]
		public bool CheckPropertyValue(object instance, string propertyName, string valueTypeName)
		{
			return InnerViewControl.method_236(instance, propertyName, valueTypeName);
		}

		/// <summary>
		///       将控件添加到指定句柄的窗体中
		///       </summary>
		/// <param name="containerHandle">指定的窗体句柄对象</param>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		public bool AppendToContainerControl(int containerHandle)
		{
			GClass271 gClass = new GClass271();
			gClass.method_3(new IntPtr(containerHandle));
			gClass.method_1(base.Handle);
			gClass.method_5(Dock);
			return gClass.method_6();
		}

		/// <summary>
		///       COM下获得焦点
		///       </summary>
		/// <returns>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool ComFocus()
		{
			return InnerViewControl.method_238();
		}

		/// <summary>
		///       COM下选择控件
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void ComSelect()
		{
			InnerViewControl.method_239();
		}

		/// <summary>
		///       调用Win32API函数来设置控件获得焦点
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool Win32SetFoucs()
		{
			return InnerViewControl.method_240();
		}

		/// <summary>
		///       测试
		///       </summary>
		[DCInternal]
		public void TestFireComEventSelectionChanged()
		{
			int num = 12;
			if (voidEventHandler_0 != null)
			{
				MessageBox.Show("绑定了事件");
				voidEventHandler_0();
			}
			else
			{
				MessageBox.Show("没有绑定事件");
			}
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			int num = 9;
			if (InnerViewControl != null)
			{
				InnerViewControl.bool_43 = true;
			}
			EnabledControlEvent = false;
			EnabledElementEvent = false;
			method_5();
			if (AutoDisposeContextMenu)
			{
				if (ContextMenu != null)
				{
					ContextMenu.Dispose();
					ContextMenu = null;
				}
				if (ContextMenuStrip != null)
				{
					ContextMenuStrip.Dispose();
					ContextMenuStrip = null;
				}
			}
			if (AutoDisposeDocument && InnerViewControl != null)
			{
				InnerViewControl.method_244();
			}
			method_60();
			GClass124.smethod_6(this);
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
			InnerClearMemberValues();
			if (DebugConfig.ShowMessageWhenDisposeControl)
			{
				GClass364.smethod_3(GetType(), int_1, null);
				string text = "销毁了 " + GetType().FullName + "#" + int_1 + "\r\n" + GClass354.smethod_7();
				if (text.Length > 1000)
				{
					text = text.Substring(0, 1000);
				}
				Debug.WriteLine(text);
			}
		}

		/// <summary>
		///       清除成员数值，DCWriter内部使用。
		///       </summary>
		protected virtual void InnerClearMemberValues()
		{
			method_5();
			list_0 = null;
			if (AutoDisposeDocument && InnerViewControl != null)
			{
				InnerViewControl.method_244();
			}
			if (iautoSaveManager_0 != null)
			{
				iautoSaveManager_0 = null;
			}
			if (clipboardProvider_0 != null)
			{
				clipboardProvider_0 = null;
			}
			if (iwriterControlWebServiceProtocol_0 != null)
			{
				iwriterControlWebServiceProtocol_0.Dispose();
				iwriterControlWebServiceProtocol_0 = null;
			}
			if (InnerViewControl != null)
			{
				InnerViewControl.method_129();
			}
			image_0 = null;
			control_0 = null;
			list_0 = null;
			class134_0 = null;
			writerControlEventMessage_0 = null;
			list_1 = null;
			dcwinMessageFilterList_0 = null;
			documentOutlineNodeList_0 = null;
			timer_0 = null;
			iwriterControlWebServiceProtocol_0 = null;
			mySplitContainer = null;
			myViewControl = null;
			ctlHRule = null;
			ctlVRule = null;
			writerAfterFieldContentEditEventHandler_0 = null;
			writerEventHandler_3 = null;
			writerBeforeFieldContentEditEventHandler_0 = null;
			writerBeforePlayMediaEventHandler_0 = null;
			writerShowDialogEventHandler_0 = null;
			writerBeforeUIKeyboardInputStringEventHandler_0 = null;
			writerButtonClickEventHandler_0 = null;
			canInsertObjectEventHandler_0 = null;
			collectProtectedElementsEventHandler_0 = null;
			contentChangedEventHandler_0 = null;
			contentChangingEventHandler_0 = null;
			createElementsByKBEntryEventHandler_0 = null;
			createInstanceEventHandler_0 = null;
			writerDrawShapeContentEventHandler_0 = null;
			writerEditElementValueEventHandler_0 = null;
			writerElementCheckedChangedEventHandler_0 = null;
			elementValidatingEventHandler_0 = null;
			writerEventHandler_6 = null;
			writerExpressionFunctionEventHandler_0 = null;
			formatListItemsEventHandler_0 = null;
			writerGetAdornTextEventHandler_0 = null;
			getLinkListItemsEventHandler_0 = null;
			insertObjectEventHandler_0 = null;
			writerLinkEventHandler_0 = null;
			writerMouseEventHandler_3 = null;
			writerMouseEventHandler_4 = null;
			writerMouseEventHandler_0 = null;
			writerMouseEventHandler_1 = null;
			writerMouseEventHandler_2 = null;
			writerEventHandler_1 = null;
			parseSelectedItemsEventHandler_0 = null;
			promptProtectedContentEventHandler_0 = null;
			writerQueryAssistInputItemsEventHandler_0 = null;
			writerReadFileContentEventHandler_0 = null;
			writerEventHandler_10 = null;
			writerReportErrorEventHandler_0 = null;
			writerSaveFileContentEventHandler_1 = null;
			writerSaveFileContentEventHandler_0 = null;
			writerEventHandler_5 = null;
			writerTableRowHeightChangedEventHandler_0 = null;
			writerTableRowHeightChangingEventHandler_0 = null;
			writerStartEditEventHandler_0 = null;
			writerCommandEventHandler_0 = null;
			writerEventHandler_4 = null;
			queryKBEntriesEventHandler_0 = null;
			queryListItemsEventHandler_0 = null;
			queryUserHistoryDisplayTextEventHandler_0 = null;
			filterValueEventHandler_0 = null;
			writerEventHandler_2 = null;
			writerEventHandler_13 = null;
			writerEventHandler_11 = null;
			writerDocumentPrintedEventHandler_0 = null;
			writerEventHandler_12 = null;
			selectionChangingEventHandler_0 = null;
			bool_2 = false;
			image_0 = null;
			control_0 = null;
			bool_8 = false;
			bool_10 = false;
			list_0 = null;
			class134_0 = null;
			writerControlEventMessage_0 = null;
			list_1 = null;
			dcwinMessageFilterList_0 = null;
			documentOutlineNodeList_0 = null;
			timer_0 = null;
			iwriterControlWebServiceProtocol_0 = null;
			string_3 = null;
			mySplitContainer = null;
			if (myViewControl != null)
			{
				myViewControl.Document.Dispose();
			}
			myViewControl = null;
			ctlHRule = null;
			ctlVRule = null;
			dictionary_0 = null;
			timer_0 = null;
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			myViewControl = new DCSoft.Writer.Controls.WriterViewControl();
			ctlHRule = new DCSoftDotfuscate.DCRulerControl();
			ctlVRule = new DCSoftDotfuscate.DCRulerControl();
			mySplitContainer = new System.Windows.Forms.SplitContainer();
			mySplitContainer.Panel1.SuspendLayout();
			mySplitContainer.SuspendLayout();
			SuspendLayout();
			myViewControl.AutoScroll = true;
			myViewControl.Location = new System.Drawing.Point(39, 28);
			myViewControl.Name = "myViewControl";
			myViewControl.Size = new System.Drawing.Size(319, 170);
			myViewControl.TabIndex = 0;
			ctlHRule.BackColor = System.Drawing.Color.FromArgb(155, 187, 227);
			ctlHRule.Location = new System.Drawing.Point(39, 4);
			ctlHRule.Name = "ctlHRule";
			ctlHRule.Size = new System.Drawing.Size(339, 24);
			ctlHRule.TabIndex = 1;
			ctlHRule.Text = "dcDocumentRuleControl1";
			ctlVRule.BackColor = System.Drawing.Color.FromArgb(155, 187, 227);
			ctlVRule.method_14(DCSoftDotfuscate.GEnum8.V);
			ctlVRule.Location = new System.Drawing.Point(15, 28);
			ctlVRule.Name = "ctlVRule";
			ctlVRule.Size = new System.Drawing.Size(24, 170);
			ctlVRule.TabIndex = 2;
			ctlVRule.Text = "dcDocumentRuleControl2";
			mySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			mySplitContainer.Location = new System.Drawing.Point(0, 0);
			mySplitContainer.Name = "mySplitContainer";
			mySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			mySplitContainer.Panel1.Controls.Add(myViewControl);
			mySplitContainer.Panel1.Controls.Add(ctlHRule);
			mySplitContainer.Panel1.Controls.Add(ctlVRule);
			mySplitContainer.Panel1.Resize += new System.EventHandler(method_18);
			mySplitContainer.Size = new System.Drawing.Size(623, 441);
			mySplitContainer.SplitterDistance = 280;
			mySplitContainer.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(mySplitContainer);
			base.Name = "WriterControl";
			base.Size = new System.Drawing.Size(623, 441);
			mySplitContainer.Panel1.ResumeLayout(false);
			mySplitContainer.ResumeLayout(false);
			ResumeLayout(false);
		}

		/// <summary>
		///       获得所有支持的命令名称组成的字符串，各个名称之间用逗号分开
		///       </summary>
		/// <returns>字符串列表</returns>
		[DCInternal]
		[ComVisible(true)]
		public string GetCommandNameList()
		{
			return InnerViewControl.method_65();
		}

		/// <summary>
		///       判断是否支持指定名称的功能命令
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>是否支持功能命令</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool IsCommandSupported(string commandName)
		{
			return InnerViewControl.method_66(commandName);
		}

		/// <summary>
		///       判断指定名称功能命令是否可用
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>功能命令是否可用</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool IsCommandEnabled(string commandName)
		{
			return InnerViewControl.method_67(commandName);
		}

		/// <summary>
		///       判断指定名称的功能命令是否处于勾选状态
		///       </summary>
		/// <param name="commandName">功能命令名称</param>
		/// <returns>功能命令是否处于勾选状态</returns>
		[DCPublishAPI]
		public bool IsCommandChecked(string commandName)
		{
			return InnerViewControl.method_68(commandName);
		}

		/// <summary>
		///       设置指定的命令是否有效
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="enable">是否有效</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetCommandEnabled(string commandName, bool enable)
		{
			return InnerViewControl.method_69(commandName, enable);
		}

		/// <summary>
		///       设置指定的命令是否底层有效
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="enable">底层是否有效</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetCommandEnableLowLevel(string commandName, bool enable)
		{
			return InnerViewControl.method_69(commandName, enable);
		}

		/// <summary>
		///       设置指定的命令是否启用快键键
		///       </summary>
		/// <param name="commandName">命令名称</param>
		/// <param name="enableHotKey">是否启用快键键</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetCommandEnableHotKey(string commandName, bool enableHotKey)
		{
			return InnerViewControl.method_70(commandName, enableHotKey);
		}

		/// <summary>
		///       以字符串的方式执行命令
		///       </summary>
		/// <remarks>命令字符串格式为“命令名称,是否显示UI,参数”,例如“fileopen,false,c:\a.xml”</remarks>
		/// <param name="command">命令文本</param>
		/// <returns>执行结果</returns>
		[DCInternal]
		public object ExecuteStringCommand(string command)
		{
			return InnerViewControl.method_71(command);
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <returns>执行命令后的结果</returns>
		[DCPublishAPI]
		public object ExecuteCommand(string commandName, bool showUI, object parameter)
		{
			return InnerViewControl.method_72(commandName, showUI, parameter);
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="args">参数</param>
		/// <returns>执行命令后的结果</returns>
		[DCInternal]
		public object ExecuteCommandSpecifyArgs(string commandName, WriterCommandEventArgs args)
		{
			return InnerViewControl.method_73(commandName, args);
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="commandName">命令文本</param>
		/// <param name="showUI">是否允许显示用户界面</param>
		/// <param name="parameter">用户参数</param>
		/// <param name="raiseFromUI">用户界面操作而触发的命令</param>
		/// <returns>执行命令后的结果</returns>
		[DCInternal]
		public object ExecuteCommandSpecifyRaiseFromUI(string commandName, bool showUI, object parameter, bool raiseFromUI)
		{
			return InnerViewControl.method_74(commandName, showUI, parameter, raiseFromUI);
		}

		internal Dictionary<string, object> method_8(string string_5)
		{
			return InnerViewControl.method_75(string_5);
		}

		[DCInternal]
		public static string smethod_0(IWin32Window iwin32Window_0, WriterAppHost writerAppHost_0, string string_5, ref string string_6, string string_7)
		{
			int num = 8;
			if (!string.IsNullOrEmpty(string_7))
			{
				IFileSystem fileSystem = writerAppHost_0.FileSystems.GetFileSystem(string_7, strictMatchName: true);
				if (fileSystem != null)
				{
					VFileSystemEventArgs vFileSystemEventArgs = new VFileSystemEventArgs(writerAppHost_0, iwin32Window_0, writerAppHost_0.Services, string_5);
					vFileSystemEventArgs.FileFormat = string_6;
					VFileInfo vFileInfo = fileSystem.BrowseForRead(vFileSystemEventArgs);
					if (vFileInfo == null)
					{
						return null;
					}
					string_6 = vFileInfo.Format;
					return vFileInfo.FullPath;
				}
			}
			Dictionary<int, string> dictionary = null;
			string text = OpenFileFilter;
			int filterIndex = 1;
			if (string.IsNullOrEmpty(text))
			{
				dictionary = new Dictionary<int, string>();
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = 0;
				foreach (ContentSerializer contentSerializer in writerAppHost_0.ContentSerializers)
				{
					if ((contentSerializer.Flags & GEnum14.flag_1) == GEnum14.flag_1)
					{
						dictionary[num2] = contentSerializer.Name;
						if (string_6 != null && string.Compare(string_6, contentSerializer.Name, ignoreCase: true) == 0)
						{
							filterIndex = num2 + 1;
						}
						num2++;
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(contentSerializer.FileFilter);
					}
				}
				if (dictionary.Count == 0)
				{
					return null;
				}
				text = stringBuilder.ToString();
			}
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (!string.IsNullOrEmpty(string_5))
				{
					openFileDialog.FileName = string_5;
				}
				openFileDialog.Title = WriterStringsCore.OpenLocalFile;
				if (iwin32Window_0 is WriterControl)
				{
					openFileDialog.Title = ((WriterControl)iwin32Window_0).DialogTitlePrefix + openFileDialog.Title;
				}
				openFileDialog.Filter = text;
				openFileDialog.CheckFileExists = true;
				openFileDialog.FilterIndex = filterIndex;
				if (openFileDialog.ShowDialog(iwin32Window_0) == DialogResult.OK)
				{
					if (dictionary != null && openFileDialog.FilterIndex >= 1)
					{
						string_6 = dictionary[openFileDialog.FilterIndex - 1];
					}
					if (string.IsNullOrEmpty(string_6))
					{
						string_6 = writerAppHost_0.ContentSerializers.GetFormatNameByFileExtension(openFileDialog.FileName);
					}
					return openFileDialog.FileName;
				}
			}
			return null;
		}

		[DCInternal]
		public static string smethod_1(IWin32Window iwin32Window_0, WriterAppHost writerAppHost_0, string string_5, ref string string_6, string string_7)
		{
			int num = 9;
			if (!string.IsNullOrEmpty(string_7))
			{
				IFileSystem fileSystem = writerAppHost_0.FileSystems.GetFileSystem(string_7, strictMatchName: true);
				if (fileSystem != null)
				{
					VFileSystemEventArgs vFileSystemEventArgs = new VFileSystemEventArgs(writerAppHost_0, iwin32Window_0, writerAppHost_0.Services, string_5);
					vFileSystemEventArgs.FileFormat = string_6;
					VFileInfo vFileInfo = fileSystem.BrowseForWrite(vFileSystemEventArgs);
					if (vFileInfo == null)
					{
						return null;
					}
					string_6 = vFileInfo.Format;
					return vFileInfo.FullPath;
				}
			}
			Dictionary<int, string> dictionary = null;
			string text = SaveFileFilter;
			int filterIndex = 1;
			if (string.IsNullOrEmpty(text))
			{
				dictionary = new Dictionary<int, string>();
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = 0;
				foreach (ContentSerializer contentSerializer in writerAppHost_0.ContentSerializers)
				{
					if ((contentSerializer.Flags & GEnum14.flag_2) == GEnum14.flag_2)
					{
						dictionary[num2] = contentSerializer.Name;
						if (string_6 != null && string.Compare(string_6, contentSerializer.Name, ignoreCase: true) == 0)
						{
							filterIndex = num2 + 1;
						}
						num2++;
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(contentSerializer.FileFilter);
					}
				}
				if (dictionary.Count == 0)
				{
					return null;
				}
				text = stringBuilder.ToString();
			}
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				if (!string.IsNullOrEmpty(string_5))
				{
					saveFileDialog.FileName = string_5;
				}
				saveFileDialog.Title = WriterStringsCore.SaveLocalFile;
				if (iwin32Window_0 is WriterControl)
				{
					saveFileDialog.Title = ((WriterControl)iwin32Window_0).DialogTitlePrefix + saveFileDialog.Title;
				}
				saveFileDialog.Filter = text;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.FilterIndex = filterIndex;
				saveFileDialog.CheckPathExists = true;
				if (saveFileDialog.ShowDialog(iwin32Window_0) == DialogResult.OK)
				{
					if (dictionary != null && saveFileDialog.FilterIndex >= 1)
					{
						string_6 = dictionary[saveFileDialog.FilterIndex - 1];
					}
					if (string.IsNullOrEmpty(string_6))
					{
						string_6 = writerAppHost_0.ContentSerializers.GetFormatNameByFileExtension(saveFileDialog.FileName);
					}
					return saveFileDialog.FileName;
				}
			}
			return null;
		}

		/// <summary>
		///       DCWriter内部使用。保存文件内容
		///       </summary>
		/// <param name="ctl">控件</param>
		/// <param name="args">事件参数</param>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		public static bool SaveFileContent(WriterControl writerControl_0, WriterSaveFileContentEventArgs args)
		{
			int num = 1;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			args.Result = false;
			byte[] binaryContentToSave = args.BinaryContentToSave;
			bool flag = false;
			flag = (writerControl_0?.DocumentOptions.BehaviorOptions.DebugMode ?? args.AppHost.DebugMode);
			if (flag && args.AppHost.Debuger != null)
			{
				args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.BeginWriteFile_Name_Bytes, args.FileName, FileHelper.FormatByteSize(binaryContentToSave.Length)));
			}
			if (writerControl_0 != null)
			{
				writerControl_0.vmethod_23(args);
				if (args.Handled || args.Result)
				{
					if (flag && args.AppHost.Debuger != null)
					{
						args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.UserHandleWriteFileEvent_Result, args.Result));
					}
					return args.Result;
				}
			}
			IFileSystem fileSystem = args.FileSystem;
			if (fileSystem == null)
			{
				fileSystem = args.AppHost.FileSystems.GetFileSystem(args.FileSystemName);
			}
			if (fileSystem == null)
			{
				UrlStream urlStream = UrlStream.smethod_1(args.FileName);
				if (urlStream != null)
				{
					using (urlStream)
					{
						if (binaryContentToSave != null && binaryContentToSave.Length > 0)
						{
							urlStream.Write(binaryContentToSave, 0, binaryContentToSave.Length);
						}
						args.Result = true;
					}
					if (flag && args.AppHost.Debuger != null)
					{
						args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.WriteFileByURL_URL_Result, args.FileName, args.Result));
					}
				}
			}
			else
			{
				VFileSystemEventArgs vFileSystemEventArgs = new VFileSystemEventArgs(args.AppHost, null, args.AppHost.Services, args.FileName);
				vFileSystemEventArgs.FileFormat = args.FileFormat;
				bool result = false;
				if (binaryContentToSave != null)
				{
					result = fileSystem.Write(vFileSystemEventArgs, binaryContentToSave);
				}
				args.FileFormat = vFileSystemEventArgs.FileFormat;
				args.Result = result;
				if (flag && args.AppHost.Debuger != null)
				{
					args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.WriteFileByFileSystem_SystemName_FileName_Result, args.FileSystemName, args.FileName, args.Result));
				}
			}
			return args.Result;
		}

		/// <summary>
		///       DCWriter内部使用。读取文件内容
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="args">参数</param>
		/// <returns>读取的二进制内容</returns>
		[DCInternal]
		public static byte[] ReadFileContent(WriterControl writerControl_0, WriterReadFileContentEventArgs args)
		{
			int num = 13;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			bool flag = false;
			flag = (writerControl_0?.DocumentOptions.BehaviorOptions.DebugMode ?? args.AppHost.DebugMode);
			if (flag && args.AppHost.Debuger != null)
			{
				args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.BeginReadFile_Name, args.FileName));
			}
			args.Handled = false;
			args.ResultBinary = null;
			if (writerControl_0 != null)
			{
				writerControl_0.vmethod_24(args);
				byte[] resultBinary = args.GetResultBinary();
				if (args.Handled || resultBinary != null)
				{
					if (flag && args.AppHost.Debuger != null)
					{
						args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.UserHandleReadFileEvent_FileName_Result, args.FileName, (resultBinary == null) ? "0" : FileHelper.FormatByteSize(resultBinary.Length)));
					}
					args.ResultBinary = resultBinary;
					return resultBinary;
				}
			}
			IFileSystem fileSystem = args.FileSystem;
			if (fileSystem == null)
			{
				fileSystem = args.AppHost.FileSystems.GetFileSystem(args.FileSystemName);
			}
			if (fileSystem == null)
			{
				UrlStream urlStream = UrlStream.smethod_0(args.FileName);
				if (urlStream != null)
				{
					using (urlStream)
					{
						byte[] array = urlStream.method_0();
						if (flag && args.AppHost.Debuger != null)
						{
							args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.ReadFileByURL_URL_Result, args.FileName, (array == null) ? "0" : FileHelper.FormatByteSize(array.Length)));
						}
						args.ResultBinary = array;
						return array;
					}
				}
				return null;
			}
			VFileSystemEventArgs vFileSystemEventArgs = new VFileSystemEventArgs(args.AppHost, null, args.AppHost.Services, args.FileName);
			vFileSystemEventArgs.FileFormat = args.FileFormat;
			byte[] array2 = fileSystem.Read(vFileSystemEventArgs);
			args.FileFormat = vFileSystemEventArgs.FileFormat;
			if (flag && args.AppHost.Debuger != null)
			{
				args.AppHost.Debuger.WriteLine(string.Format(WriterStringsCore.ReadFileByFileSystem_SystemName_FileName_Result, args.FileSystemName, args.FileName, (array2 == null) ? "0" : FileHelper.FormatByteSize(array2.Length)));
			}
			args.ResultBinary = array2;
			return array2;
		}

		/// <summary>
		///       启用基于本地文件系统的自动保存功能
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool StartLocalAutoSave()
		{
			ResetAutoSaveTask();
			AutoSaveManager = AppHost.Tools.CreateLocalAutoSaveManager(this);
			return AutoSaveManager != null;
		}

		/// <summary>
		///       是否存在自动保存的文件
		///       </summary>
		/// <param name="fileID">文件编号</param>
		/// <param name="confirm">是否提示用户</param>
		/// <returns>是否存在自动保存的文件</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool AutoSaveExists(string fileID, bool confirm)
		{
			if (AutoSaveManager != null)
			{
				return AutoSaveManager.Exists(fileID, confirm);
			}
			return false;
		}

		/// <summary>
		///       删除自动保存的临时文件
		///       </summary>
		/// <param name="fileID">文件编号</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AutoSaveDelete(string fileID)
		{
			if (AutoSaveManager != null)
			{
				AutoSaveManager.Delete(fileID);
			}
		}

		/// <summary>
		///       从自动保存中恢复文件内容
		///       </summary>
		/// <param name="fileID">文件编号</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool AutoSaveLoadDocument(string fileID)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_14))
			{
				return false;
			}
			if (AutoSaveManager != null)
			{
				using (CreateWaittingUI(string.Format(WriterStringsCore.LoadingAutoSave_FileID, fileID)))
				{
					byte[] array = AutoSaveManager.ReadContent(fileID);
					if (array != null && array.Length > 0)
					{
						bool flag = LoadDocumentFromBinary(array, null);
						Document.FileName = fileID;
						if (flag)
						{
							AutoSaveManager.Delete(fileID);
						}
						return flag;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       获得文档Html文本
		///       </summary>
		[DCPublishAPI]
		public string GetHtmlText()
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			return InnerViewControl.method_109();
		}

		/// <summary>
		///       设置文档HTML内容
		///       </summary>
		/// <param name="html">
		/// </param>
		[DCPublishAPI]
		public void SetHtmlText(string html)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_110(html);
			}
		}

		/// <summary>
		///       以指定的格式加载文本文档内容
		///       </summary>
		/// <param name="text">文本</param>
		/// <param name="format">格式</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool LoadDocumentFromString(string text, string format)
		{
			return InnerViewControl.method_112(text, format);
		}

		/// <summary>
		///       以指定的格式从指定的文件流中加载文本文档内容
		///       </summary>
		/// <param name="stream">流对象</param>
		/// <param name="format">格式</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public bool LoadDocumentFromStream(Stream stream, string format)
		{
			return InnerViewControl.method_121(stream, format);
		}

		/// <summary>
		///       以指定的格式从BASE64字符串加载文档内容
		///       </summary>
		/// <param name="text">BASE64字符串</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool LoadDocumentFromBase64String(string text, string format)
		{
			return InnerViewControl.method_113(text, format);
		}

		/// <summary>
		///       从指定的文件地址中加载文档
		///       </summary>
		/// <param name="url">文件地址</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		[DCPublishAPI]
		public bool LoadDocumentFromFile(string string_5, string format)
		{
			return InnerViewControl.method_114(string_5, format);
		}

		/// <summary>
		///       从指定的字节数组中加载文档
		///       </summary>
		/// <param name="bs">字节数组</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool LoadDocumentFromBinary(byte[] byte_0, string format)
		{
			return InnerViewControl.method_115(byte_0, format);
		}

		/// <summary>
		///       从指定的文件地址中加载文档
		///       </summary>
		/// <param name="strUrl">文件地址</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		[Obsolete("请使用LoadDocumentFromFile()方法。")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool LoadDocument(string strUrl, string format)
		{
			return InnerViewControl.method_118(strUrl, format);
		}

		/// <summary>
		///       从指定的文件流中加载文档
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		[ComVisible(false)]
		[Obsolete("请使用 LoadDocumentFromStream()")]
		public bool LoadDocument(Stream stream, string format)
		{
			return InnerViewControl.method_121(stream, format);
		}

		/// <summary>
		///       从指定的文件地址中加载文档
		///       </summary>
		/// <param name="reader">文件地址</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public bool LoadDocument(TextReader reader, string format)
		{
			return InnerViewControl.method_122(reader, format);
		}

		[DCInternal]
		[ComVisible(false)]
		public string GetFormatFormFileExtentsion(string fileName)
		{
			int num = 2;
			if (string.IsNullOrEmpty(fileName))
			{
				return null;
			}
			string text = fileName.ToLower().Trim();
			if (text.EndsWith(".xml"))
			{
				return "xml";
			}
			if (text.EndsWith(".rtf"))
			{
				return "rtf";
			}
			if (text.EndsWith(".htm") || text.EndsWith(".html"))
			{
				return "html";
			}
			if (text.EndsWith(".txt"))
			{
				return "txt";
			}
			return null;
		}

		/// <summary>
		///       保存文档到指定名称的文件中
		///       </summary>
		/// <param name="strUrl">文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool SaveDocument(string strUrl, string format)
		{
			bool result;
			if (result = InnerViewControl.method_123(strUrl, format))
			{
				method_60();
			}
			return result;
		}

		/// <summary>
		///       保存文档到指定名称的文件中
		///       </summary>
		/// <param name="url">文件名</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool SaveDocumentToFile(string string_5, string format)
		{
			bool result;
			if (result = InnerViewControl.method_124(string_5, format))
			{
				method_60();
			}
			return result;
		}

		/// <summary>
		///       保存文档到指定文件流中
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public bool SaveDocumentToStream(Stream stream, string format)
		{
			bool result;
			if (result = InnerViewControl.method_127(stream, format))
			{
				method_60();
			}
			return result;
		}

		/// <summary>
		///       保存文档为字符串
		///       </summary>
		/// <param name="format">文件格式</param>
		/// <returns>输出的字符串</returns>
		[DCPublishAPI]
		public string SaveDocumentToString(string format)
		{
			string text = InnerViewControl.method_125(format);
			if (text != null)
			{
				method_60();
			}
			return text;
		}

		/// <summary>
		///       保存文档为BASE64字符串
		///       </summary>
		/// <param name="format">文件格式</param>
		/// <returns>输出的BASE64字符串</returns>
		[DCPublishAPI]
		public string SaveDocumentToBase64String(string format)
		{
			string text = InnerViewControl.method_126(format);
			if (text != null)
			{
				method_60();
			}
			return text;
		}

		/// <summary>
		///       保存文档到指定的流中
		///       </summary>
		/// <param name="stream">文档流</param>
		/// <param name="format">文件格式</param>
		/// <returns>操作是否成功</returns>
		[Obsolete("请转为使用SaveDocumentToStream()")]
		[ComVisible(false)]
		public bool SaveDocument(Stream stream, string format)
		{
			bool result;
			if (result = InnerViewControl.method_127(stream, format))
			{
				method_60();
			}
			return result;
		}

		/// <summary>
		///       获得指定页的图片对象
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <param name="showMarginLine">是否绘制表示页边距的灰线</param>
		/// <returns>获得的图片对象</returns>
		[DCPublishAPI]
		public Bitmap CreatePageBmp(int pageIndex, bool showMarginLine)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.CreatePageBmp(pageIndex, showMarginLine);
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
			if (Document == null)
			{
				return null;
			}
			return Document.CreateLongBmp(showMarginLine);
		}

		/// <summary>
		///       保存长图片文件
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SaveLongImageFile(string fileName)
		{
			if (Document != null)
			{
				Document.SaveLongImageFile(fileName);
			}
		}

		/// <summary>
		///       保存长图片文件
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="zoomRate">缩放比率</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SaveLongImageFileZoom(string fileName, float zoomRate)
		{
			if (Document != null)
			{
				Document.SaveLongImageFileZoom(fileName, zoomRate);
			}
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <returns>生成的BASE64字符串</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string SaveLongImageToBase64String(string format)
		{
			if (Document != null)
			{
				return Document.SaveLongImageToBase64String(format);
			}
			return null;
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <returns>生成的BASE64字符串</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string SaveLongImageToBase64StringZoom(string format, float zoomRate)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.SaveLongImageToBase64StringZoom(format, zoomRate);
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
			if (Document != null)
			{
				Document.SavePageImageFile(pageIndex, fileName);
			}
		}

		/// <summary>
		///       保存页面图片文件
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SavePageImageFileZoom(int pageIndex, string fileName, float zoomRate)
		{
			if (Document != null)
			{
				Document.SavePageImageFileZoom(pageIndex, fileName, zoomRate);
			}
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <returns>生成的BASE64字符串</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string SavePageImageToBase64String(int pageIndex, string format)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.SavePageImageToBase64String(pageIndex, format);
		}

		/// <summary>
		///       保存页面图片到BASE64字符串中
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页面序号</param>
		/// <param name="format">图片格式，可以为bmp,png,jpg</param>
		/// <param name="zoomRate">缩放比率</param>
		/// <returns>生成的BASE64字符串</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string SavePageImageToBase64StringZoom(int pageIndex, string format, float zoomRate)
		{
			if (Document == null)
			{
				return null;
			}
			return Document.SavePageImageToBase64StringZoom(pageIndex, format, zoomRate);
		}

		/// <summary>
		///        创建等待操作界面
		///        </summary>
		/// <param name="msg">消息内容</param>
		/// <param name="delayMilliseconds">延时显示的毫秒数</param>
		/// <example>
		///        例如以下代码将显示一个等待操作界面，如果操作过程少于100毫秒则用户界面无任何变化。
		///        如果超过100毫秒，则在第100毫秒的时候显示等待操作的信息。
		///       <br />using (IDisposable man = ctl.CreateWaittingUI("正在操作中，请稍候...",100))
		///       <br />{
		///       <br />    进行一些和编辑器相关的很耗时的操作。
		///       <br />}
		///        </example>
		/// <returns>获得的操作信息对象</returns>
		[DCInternal]
		public IDisposable CreateWaittingUI(string string_5, int delayMilliseconds = 300)
		{
			GClass445 gClass = InnerViewControl.method_116(bool_47: false, null, delayMilliseconds);
			gClass.method_4(bool_3: true);
			gClass.method_8(string_5);
			gClass.Paint();
			return gClass;
		}

		/// <summary>
		///       将控件设置成MS Word的显示样式。
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SetToMSWordVisualStyle()
		{
			RuleBackColor = DCRulerControl.color_0;
			RuleVisible = true;
			BackColor = Color.FromArgb(177, 202, 235);
			RuleEnabled = true;
		}

		/// <summary>
		///       获得所有的字符串资源
		///       </summary>
		/// <returns>字符串资源列表</returns>
		[DCInternal]
		[ComVisible(false)]
		public Dictionary<string, string> GetAllResourceStringValue()
		{
			List<string> list = GClass380.smethod_2();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < list.Count; i += 2)
			{
				dictionary[list[i]] = list[i + 1];
			}
			return dictionary;
		}

		/// <summary>
		///       设置字符串资源内容,改操作的影响是全局性的。
		///       </summary>
		/// <param name="name">字符串资源名称</param>
		/// <param name="Value">字符串资源值</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SetResourceStringValue(string name, string Value)
		{
			if (XTextDocument.smethod_13(GEnum6.const_151))
			{
				GClass380.smethod_3(name, Value);
			}
		}

		/// <summary>
		///       设置字符串资源内容,改操作的影响是全局性的。
		///       </summary>
		/// <param name="name">字符串资源名称</param>
		/// <param name="Value">字符串资源值</param>
		[DCPublishAPI]
		public static void StaticSetResourceStringValue(string name, string Value)
		{
			if (XTextDocument.smethod_13(GEnum6.const_151))
			{
				GClass380.smethod_3(name, Value);
			}
		}

		/// <summary>
		///       编辑器控件获得输入焦点
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public new bool Focus()
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.Focus();
		}

		/// <summary>
		///       重置检测文档内容编辑状态标记，使得可以再次进行判断。
		///       </summary>
		[DCInternal]
		public void ResetUIStartEditContentState()
		{
			InnerViewControl.method_131();
		}

		/// <summary>
		///       用户界面层的开始编辑文档内容
		///       </summary>
		/// <returns>如果返回true，则可以编辑文档内容；如果返回false则不能编辑文档内容。</returns>
		/// <remarks>
		///       此处的能否编辑文档内容和控件当的Readonly属性不一样。在该方法中，一开始是假定控件内容
		///       可以编辑，此时是按照内容可以编辑的状态来设置的编辑器命令状态。比如Bold,Italic,Paste等命令。
		///       不过用户真的动手修改文档内容时，会调用这个方法，如果返回false则该编辑操作取消掉。
		///       不过编辑器命令状态还是假定内容可编辑的。
		///
		///       举个例子，如果系统实现了文档锁定机制，当编辑器打开一个文档，还没确定文档是否被锁定了。
		///       此时可以响应EventStartEditContent事件来确定文档是否真的被锁定了。如果被其他用户锁定了，
		///       则该方法返回false，如果没被锁定，则当前用户可以锁定文档，然后返回true。
		///       这种锁定仅影响用户界面层的操作，比如鼠标键盘事件、执行编辑器命令。但对程序直接调用
		///       控件和文档对象的各种属性方法来修改文档内容是没有影响的。
		///       本函数内部触发控件的EventUIStartEditContent事件，应用系统需要相应这个事件来判断文档
		///       是否处于锁定状态，以及锁定文档的操作。
		///       </remarks>
		[DCPublishAPI]
		public virtual bool UIStartEditContent()
		{
			if (InnerViewControl == null || !base.IsHandleCreated)
			{
				return false;
			}
			bool result;
			if (result = InnerViewControl.method_132())
			{
				method_59();
			}
			return result;
		}

		/// <summary>
		///       用户界面层的开始编辑文档内容
		///       </summary>
		/// <returns>如果返回true，则可以编辑文档内容；如果返回false则不能编辑文档内容。</returns>
		/// <remarks>
		///       此处的能否编辑文档内容和控件当的Readonly属性不一样。在该方法中，一开始是假定控件内容
		///       可以编辑，此时是按照内容可以编辑的状态来设置的编辑器命令状态。比如Bold,Italic,Paste等命令。
		///       不过用户真的动手修改文档内容时，会调用这个方法，如果返回false则该编辑操作取消掉。
		///       不过编辑器命令状态还是假定内容可编辑的。
		///
		///       举个例子，如果系统实现了文档锁定机制，当编辑器打开一个文档，还没确定文档是否被锁定了。
		///       此时可以响应EventStartEditContent事件来确定文档是否真的被锁定了。如果被其他用户锁定了，
		///       则该方法返回false，如果没被锁定，则当前用户可以锁定文档，然后返回true。
		///       这种锁定仅影响用户界面层的操作，比如鼠标键盘事件、执行编辑器命令。但对程序直接调用
		///       控件和文档对象的各种属性方法来修改文档内容是没有影响的。
		///       本函数内部触发控件的EventUIStartEditContent事件，应用系统需要相应这个事件来判断文档
		///       是否处于锁定状态，以及锁定文档的操作。
		///       </remarks>
		[DCPublishAPI]
		public virtual bool UIStartEditContentSpecifyElement(XTextElement sourceElement)
		{
			if (InnerViewControl == null || !base.IsHandleCreated)
			{
				return false;
			}
			bool result;
			if (result = InnerViewControl.method_133(sourceElement))
			{
				method_59();
			}
			return result;
		}

		internal Rectangle method_9(float float_0, float float_1, float float_2)
		{
			return InnerViewControl.method_134(float_0, float_1, float_2);
		}

		/// <summary>
		///       显示关于对话框
		///       </summary>
		[DCPublishAPI]
		public void ShowAboutDialog()
		{
			InnerViewControl.method_135();
		}

		/// <summary>
		///       获得导航节点字符串
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetNavigateNodesString()
		{
			return Navigator.GetNodeString();
		}

		/// <summary>
		///       获得导航节点XML字符串
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetNavigateNodesXMLString()
		{
			return Navigator.method_0();
		}

		/// <summary>
		///       导航到指定编号的节点的位置
		///       </summary>
		/// <param name="id">节点编号</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool NavigateByNodeID(string string_5)
		{
			return InnerViewControl.method_137(string_5);
		}

		/// <summary>
		///       导航到节点指定的位置
		///       </summary>
		/// <param name="node">节点</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool Navigate(NavigateNode node)
		{
			return InnerViewControl.method_138(node);
		}

		/// <summary>
		///       设置状态栏文本，并触发事件
		///       </summary>
		/// <param name="text">新状态栏文本</param>
		[DCPublishAPI]
		public virtual void SetStatusText(string text)
		{
			InnerViewControl.method_139(text);
		}

		[DCInternal]
		public static void UIShowForm(WriterControl writerControl_0, Form form_0)
		{
			try
			{
				form_0.Show(writerControl_0);
			}
			catch (Exception)
			{
				form_0.Show();
			}
		}

		/// <summary>
		///       显示对话框
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="dlg">对话框对象</param>
		/// <param name="sourceElement">相关文档元素对象</param>
		/// <returns>对话框返回结果</returns>
		[DCInternal]
		public static DialogResult UIShowDialog(WriterControl writerControl_0, Form form_0, XTextElement sourceElement)
		{
			if (!(writerControl_0?.IsHandleCreated ?? false))
			{
				return form_0.ShowDialog();
			}
			return writerControl_0.UIShowDialog(form_0, sourceElement);
		}

		/// <summary>
		///       显示对话框，返回对话框结果
		///       </summary>
		/// <param name="dlg">对话框对象</param>
		/// <param name="sourceElement">相关文档元素对象</param>
		/// <returns>返回的结果</returns>
		[DCInternal]
		public virtual DialogResult UIShowDialog(Form form_0, XTextElement sourceElement)
		{
			int num = 7;
			if (form_0 == null)
			{
				throw new ArgumentNullException("dlg");
			}
			if (writerShowDialogEventHandler_0 != null)
			{
				WriterShowDialogEventArgs writerShowDialogEventArgs = new WriterShowDialogEventArgs(this, form_0, Document, sourceElement);
				writerShowDialogEventArgs.Handled = false;
				if (DocumentOptions.BehaviorOptions.WeakMode)
				{
					writerShowDialogEventHandler_0(this, writerShowDialogEventArgs);
				}
				else
				{
					try
					{
						writerShowDialogEventHandler_0(this, writerShowDialogEventArgs);
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
					}
				}
				if (writerShowDialogEventArgs.Handled)
				{
					return writerShowDialogEventArgs.DialogResult;
				}
			}
			if (DocumentOptions.BehaviorOptions.AutoActiveSystemTaskbarBeforeShowDialog)
			{
				GClass244.smethod_5();
			}
			return form_0.ShowDialog(this);
		}

		/// <summary>
		///       添加快捷菜单项目
		///       </summary>
		/// <param name="text">菜单文本</param>
		/// <param name="commandName">菜单命令名称</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AddContextMenuItem(string text, string commandName)
		{
			InnerViewControl.method_140(text, commandName);
		}

		/// <summary>
		///       清空快捷菜单项目
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public void ClearContextMenuItem()
		{
			InnerViewControl.method_141();
		}

		/// <summary>
		///       主动的触发文档元素的内容发生改变事件
		///       </summary>
		/// <param name="element">文档元素对象</param>
		[DCInternal]
		[ComVisible(true)]
		public void RaiseElementContentChangedEvent(XTextElement element)
		{
			InnerViewControl.method_143(element);
		}

		/// <summary>
		///       向文档元素快键菜单添加一个分隔条
		///       </summary>
		/// <param name="elementTypeName">文档元素类型名称</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AddContextMenuSeparatorByTypeName(string elementTypeName)
		{
			InnerViewControl.method_144(elementTypeName);
		}

		/// <summary>
		///       向文档元素快键菜单添加一个分隔条
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>分隔条对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public ToolStripSeparator AddContextMenuSeparator(Type elementType)
		{
			return InnerViewControl.method_145(elementType);
		}

		/// <summary>
		///       删除指定文档元素类型的快键菜单项目
		///       </summary>
		/// <param name="elementTypeName">类型名称</param>
		/// <param name="name">菜单名称</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void RemoveContextMenuItemByTypeName(string elementTypeName, string name)
		{
			InnerViewControl.method_146(elementTypeName, name);
		}

		/// <summary>
		///       删除指定文档元素类型的快键菜单项目
		///       </summary>
		/// <param name="elementType">类型</param>
		/// <param name="name">菜单名称</param>
		[DCPublishAPI]
		[ComVisible(false)]
		public void RemoveContextMenuItem(Type elementType, string name)
		{
			InnerViewControl.method_147(elementType, name);
		}

		/// <summary>
		///       添加文档元素的快键菜单
		///       </summary>
		/// <param name="elementTypeName">文档元素类型名称</param>
		/// <param name="name">菜单项目名称</param>
		/// <param name="commandName">绑定的编辑器命令</param>
		/// <param name="text">菜单项目文本</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AddContextMenuItemByTypeName(string elementTypeName, string name, string commandName, string text)
		{
			InnerViewControl.method_148(elementTypeName, name, commandName, text);
		}

		/// <summary>
		///       添加自定义快键菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="text">文本</param>
		/// <param name="clickHandler">自定义的功能函数委托</param>
		/// <returns>生成的菜单项目对象</returns>
		[DCPublishAPI]
		[ComVisible(false)]
		public ToolStripMenuItem AddContextCustomMenuItem(Type elementType, string text, EventHandler clickHandler)
		{
			return InnerViewControl.method_149(elementType, text, clickHandler);
		}

		/// <summary>
		///       添加快键菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="name">菜单项目名称</param>
		/// <param name="commandName">编辑器命令名</param>
		/// <param name="text">文本</param>
		/// <param name="iconBase64String">图标</param>
		/// <param name="clickHandler">菜单点击事件处理委托</param>
		/// <returns>生成的菜单项目对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public ToolStripMenuItem AddContextMenuItem(Type elementType, string name, string commandName, string text, string iconBase64String, EventHandler clickHandler)
		{
			return InnerViewControl.method_150(elementType, name, commandName, text, iconBase64String, clickHandler);
		}

		/// <summary>
		///       添加快键菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="text">文本</param>
		/// <param name="commandName">编辑器命令名</param>
		/// <returns>生成的菜单项目对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public ToolStripMenuItem AddContextMenuItemByTypeTextCommandName(Type elementType, string text, string commandName)
		{
			return InnerViewControl.method_150(elementType, null, commandName, text, null, null);
		}

		/// <summary>
		///       添加快键菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="text">文本</param>
		/// <param name="clickHandler">菜单点击事件处理委托</param>
		/// <returns>生成的菜单项目对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public ToolStripMenuItem AddContextMenuItemByTypeTextHandler(Type elementType, string text, EventHandler clickHandler)
		{
			return InnerViewControl.method_150(elementType, null, null, text, null, clickHandler);
		}

		protected override void WndProc(ref Message message_0)
		{
			if ((message_0.Msg != 256 && message_0.Msg != 257 && message_0.Msg != 258 && message_0.Msg != 646) || LocalMessageFilters == null || !LocalMessageFilters.PreFilterMessage(ref message_0))
			{
				base.WndProc(ref message_0);
			}
		}

		/// <summary>
		///       编辑文本标签元素在当前页面中显示的文本
		///       </summary>
		/// <param name="lbl">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCInternal]
		public bool EditLabelPageText(XTextLabelElement xtextLabelElement_0)
		{
			int num = 0;
			if (xtextLabelElement_0 == null)
			{
				throw new ArgumentNullException("lbl");
			}
			if (ViewMode != PageViewMode.Page)
			{
				return false;
			}
			if (DocumentControler.CanModify(xtextLabelElement_0) && UIStartEditContentSpecifyElement(xtextLabelElement_0))
			{
				int focusedPageIndexBase = FocusedPageIndexBase0;
				string textValue = xtextLabelElement_0.method_16(focusedPageIndexBase);
				using (dlgInputBox dlgInputBox = new dlgInputBox())
				{
					dlgInputBox.InputTitle = WriterStringsCore.PromptInputText;
					dlgInputBox.TextValue = textValue;
					if (UIShowDialog(this, dlgInputBox, xtextLabelElement_0) == DialogResult.OK)
					{
						xtextLabelElement_0.PageTexts.SetPageText(focusedPageIndexBase, dlgInputBox.TextValue);
						xtextLabelElement_0.InvalidateView();
						Document.OnDocumentContentChanged();
						xtextLabelElement_0.Modified = true;
						Modified = true;
						return true;
					}
				}
			}
			return false;
		}

		static WriterControl()
		{
			string_0 = null;
			string_1 = null;
			int_3 = 0;
			string_2 = null;
			string_4 = null;
			WriterUtils.CheckNET20SP2(throwException: true);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterControl()
		{
			SetStyle(ControlStyles.Selectable, value: true);
			SetStyle(ControlStyles.ContainerControl, value: false);
			InitializeComponent();
			List<Control> list = WinFormUtils.smethod_3(this);
			foreach (Control item in list)
			{
				if (item != myViewControl)
				{
					WinFormUtils.smethod_2(item, ControlStyles.Selectable, bool_0: false);
				}
			}
			InnerViewControl.BorderStyle = BorderStyle.None;
			InnerViewControl.OwnerWriterControl = this;
			WriterUtils.smethod_6();
			ctlHRule.method_3(this);
			ctlVRule.method_3(this);
			RuleVisible = true;
			Font font = new Font(Control.DefaultFont.Name, 9f);
			ctlHRule.Font = font;
			ctlVRule.Font = font;
			RuleVisible = false;
			mySplitContainer.BackColor = Color.FromArgb(SystemColors.Control.ToArgb());
			mySplitContainer.Panel2Collapsed = true;
			mySplitContainer.Panel2.Font = Control.DefaultFont;
			mySplitContainer.Panel1.Paint += method_11;
			myViewControl.BackColor = BackColor;
			if (DebugConfig.ShowMessageWhenCreateControl)
			{
				int_1 = GClass364.smethod_2(this, null);
				string text = GClass364.smethod_4(GetType(), int_1);
				if (text.Length > 1000)
				{
					text = text.Substring(0, 1000);
				}
				Debug.WriteLine(text);
			}
		}

		[DCPublishAPI]
		[ComVisible(true)]
		public void PreloadSystem()
		{
			WriterAppHost.PreloadSystem();
		}

		internal void method_10()
		{
			int_0++;
		}

		[DCInternal]
		protected override bool IsInputKey(Keys keyData)
		{
			if (InnerViewControl == null)
			{
				return base.IsInputKey(keyData);
			}
			return InnerViewControl.method_174(keyData);
		}

		[DCInternal]
		protected override void OnHandleDestroyed(EventArgs eventArgs_0)
		{
			base.OnHandleDestroyed(eventArgs_0);
		}

		/// <summary>
		///       设置自定义属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SetCustomAttribute(string name, string Value)
		{
			if (!string.IsNullOrEmpty(name))
			{
				dictionary_0[name] = Value;
			}
		}

		/// <summary>
		///       获得自定义属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public string GetCustomAttribute(string name)
		{
			if (dictionary_0.ContainsKey(name))
			{
				return dictionary_0[name];
			}
			return null;
		}

		private void method_11(object sender, PaintEventArgs e)
		{
			if (base.IsHandleCreated && ctlHRule != null && ctlHRule.IsHandleCreated && ctlHRule.Visible)
			{
				Rectangle rect = new Rectangle(Math.Min(ctlVRule.Left, ctlHRule.Left), 0, ctlVRule.Width, ctlHRule.Height);
				if (e.ClipRectangle.IntersectsWith(rect))
				{
					using (SolidBrush brush = new SolidBrush(ctlVRule.BackColor))
					{
						e.Graphics.FillRectangle(brush, rect);
					}
				}
			}
		}

		/// <summary>
		///       重置表单元素默认值
		///       </summary>
		/// <returns>是否导致文档内容发生改变</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool ResetFormValue()
		{
			return Document.ResetFormValue();
		}

		/// <summary>
		///       设置选项值,选项名称为“选项组名.选项名称”的格式，比如“ViewOptions.ShowParagraphFlag”。
		///       </summary>
		/// <remarks>
		///       比如
		///       obj.SetOptionValue("ViewOptions.ShowParagraphFlag","true");
		///       <br />obj.SetOptionValue("ViewOptions.TagColorForNormalField","#AAAAAA");
		///       </remarks>
		/// <param name="name">选项名称</param>
		/// <param name="Value">新的选项值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SetOptionValue(string name, string Value)
		{
			return DocumentOptions.SetOptionValue(name, Value);
		}

		/// <summary>
		///       获得指定名称的选项数值,选项名称为“选项组名.选项名称”的格式，比如“ViewOptions.ShowParagraphFlag”。
		///       </summary>
		/// <remarks>
		///       比如
		///       string v = obj.GetOptionValue("ViewOptions.ShowParagraphFlag" ); // 返回 "true"或"false"。
		///       <br />string v2 = obj.GetOptionValue("ViewOptions.TagColorForNormalField");// 返回类似"#AAAAAA"等表示颜色值的字符串。
		///       </remarks>
		/// <param name="name">选项名称</param>
		/// <returns>选项数值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetOptionValue(string name)
		{
			return DocumentOptions.GetOptionValue(name);
		}

		/// <summary>
		///       添加XML级联提供者对象
		///       </summary>
		/// <param name="providerName">级联提供者名称</param>
		/// <param name="xmlFileName">相关的XML文件名</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AddXMLLinkListProvider(string providerName, string xmlFileName)
		{
			int num = 15;
			if (string.IsNullOrEmpty(providerName))
			{
				throw new ArgumentNullException("providerName");
			}
			if (string.IsNullOrEmpty(xmlFileName))
			{
				throw new ArgumentNullException("xmlFileName");
			}
			XMLLinkListProvider xMLLinkListProvider = new XMLLinkListProvider();
			xMLLinkListProvider.LoadXMLDocument(xmlFileName);
			xMLLinkListProvider.Name = providerName;
			AppHost.LinkListProviders.RemoveByName(providerName);
			AppHost.LinkListProviders.Add(xMLLinkListProvider);
		}

		internal virtual DateTime vmethod_2()
		{
			DateTime now = DateTime.Now;
			if (DateTimeService != null)
			{
				return DateTimeService.GetNow();
			}
			return GClass377.smethod_3();
		}

		/// <summary>
		///       同步服务器时间
		///       </summary>
		/// <param name="serverTime">当前服务器时间</param>
		/// <remarks>
		///       本函数不会修改本地计算机时钟，而是修改本软件内部维护的一个虚拟时钟。
		///       虚拟时钟会依赖本地计算机时钟。
		///       不过同步服务器时间后，如果本机时钟修改了，
		///       则需要重新调用本函数来同步服务器时间。如果不重新同步则会采用本机时刻。
		///       因此建议定期（比如一分钟）来调用本函数同步服务器时间。
		///       </remarks>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SynchroServerTime(DateTime serverTime)
		{
			if (XTextDocument.smethod_13(GEnum6.const_158))
			{
				GClass377.smethod_2(serverTime);
			}
		}

		/// <summary>
		///       同步服务器时间
		///       </summary>
		/// <param name="year">当前年份</param>
		/// <param name="month">当前月份</param>
		/// <param name="day">当前天数</param>
		/// <param name="hour">当前小时数</param>
		/// <param name="minute">当前分钟数</param>
		/// <param name="second">当前秒数</param>
		/// <remarks>
		///       本函数是SynchroServerTime(DateTime serverTime)的另外一个版本。用于对不支持DateTime类型的编程语言的支持。
		///       本函数不会修改本地计算机时钟，而是修改本软件内部维护的一个虚拟时钟。
		///       虚拟时钟会依赖本地计算机时钟。
		///       不过同步服务器时间后，如果本机时钟修改了，
		///       则需要重新调用本函数来同步服务器时间。如果不重新同步则会采用本机时刻。
		///       因此建议定期（比如一分钟）来调用本函数同步服务器时间。
		///       </remarks>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SynchroServerTimeByParameters(int year, int month, int int_4, int hour, int minute, int second)
		{
			if (XTextDocument.smethod_13(GEnum6.const_158))
			{
				DateTime dateTime_ = new DateTime(year, month, int_4, hour, minute, second);
				GClass377.smethod_2(dateTime_);
			}
		}

		private void method_12()
		{
			(control_0 as GInterface18)?.imethod_2(bool_0: false);
		}

		[DCInternal]
		[ComVisible(false)]
		public void method_13()
		{
			if (mySplitContainer != null && mySplitContainer.Panel2Collapsed && control_0 != null)
			{
				mySplitContainer.Panel2.Controls.Remove(control_0);
				control_0.Dispose();
				control_0 = null;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DCInternal]
		[ComVisible(false)]
		public bool method_14(XTextElement xtextElement_0)
		{
			if (DocumentOptions.BehaviorOptions.FastInputMode && xtextElement_0 is XTextInputFieldElementBase)
			{
				BeginInvoke(new EventHandler(method_15), xtextElement_0, null);
				return true;
			}
			return false;
		}

		private void method_15(object sender, EventArgs e)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)sender;
			if (xTextInputFieldElementBase == null)
			{
				return;
			}
			XTextContent content = xTextInputFieldElementBase.DocumentContentElement.Content;
			switch (xTextInputFieldElementBase.FastInputMode)
			{
			case DCFastInputMode.None:
				break;
			case DCFastInputMode.NextField:
				xTextInputFieldElementBase.GetNextFocusFieldElement()?.Focus();
				break;
			case DCFastInputMode.BeforeFieldBegin:
			{
				int num = content.IndexOf(xTextInputFieldElementBase.StartElement);
				if (num >= 0)
				{
					content.MoveToPosition(num);
				}
				break;
			}
			case DCFastInputMode.AfterFieldBegin:
			{
				int num = content.IndexOf(xTextInputFieldElementBase.StartElement);
				if (num >= 0)
				{
					content.MoveToPosition(num + 1);
				}
				break;
			}
			case DCFastInputMode.BeforeFieldEnd:
			{
				int num = content.IndexOf(xTextInputFieldElementBase.EndElement);
				if (num >= 0)
				{
					content.MoveToPosition(num);
				}
				break;
			}
			case DCFastInputMode.AfterFieldEnd:
			{
				int num = content.IndexOf(xTextInputFieldElementBase.EndElement);
				if (num >= 0)
				{
					content.MoveToPosition(num + 1);
				}
				break;
			}
			}
		}

		[DCInternal]
		public void method_16()
		{
			if (ctlHRule.Visible)
			{
				ctlHRule.method_16(bool_1: true);
				ctlHRule.Invalidate();
				ctlVRule.method_16(bool_1: true);
				ctlVRule.Invalidate();
			}
		}

		protected void method_17()
		{
			bool flag = ViewMode == PageViewMode.Page && RuleVisible;
			if (ctlHRule.Visible != flag)
			{
				ctlHRule.Visible = flag;
				ctlVRule.Visible = flag;
				if (base.IsHandleCreated)
				{
					OnResize(null);
				}
			}
		}

		/// <summary>
		///       处理RightToLeftChanged事件，更新标尺位置
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (ctlHRule.Visible)
			{
				OnResize(null);
			}
		}

		/// <summary>
		///       控件大小发生改变时处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnResize(EventArgs eventArgs_0)
		{
			if (base.IsHandleCreated)
			{
				base.OnResize(eventArgs_0);
				method_19(this, eventArgs_0);
			}
		}

		private void method_18(object sender, EventArgs e)
		{
			method_19(null, null);
		}

		protected override void OnVisibleChanged(EventArgs eventArgs_0)
		{
			base.OnVisibleChanged(eventArgs_0);
			method_19(null, null);
		}

		private void method_19(object sender, EventArgs e)
		{
			if (ctlHRule == null || ctlVRule == null)
			{
				return;
			}
			Control parent = ctlHRule.Parent;
			if (parent == null)
			{
				return;
			}
			if (ctlHRule.Visible)
			{
				if (parent.Width > 70 && parent.Height > 70)
				{
					RightToLeft rightToLeft = RightToLeft;
					if (rightToLeft == RightToLeft.Inherit)
					{
						try
						{
							for (Control parent2 = base.Parent; parent2 != null; parent2 = parent2.Parent)
							{
								if (parent2.RightToLeft != RightToLeft.Inherit)
								{
									rightToLeft = parent2.RightToLeft;
									break;
								}
							}
						}
						catch
						{
							rightToLeft = RightToLeft.No;
						}
					}
					if (rightToLeft == RightToLeft.Inherit)
					{
						rightToLeft = RightToLeft.No;
					}
					if (ctlHRule.RightToLeft != rightToLeft)
					{
						ctlHRule.RightToLeft = rightToLeft;
					}
					if (ctlVRule.RightToLeft != rightToLeft)
					{
						ctlVRule.RightToLeft = rightToLeft;
					}
					int num = 24;
					Rectangle bounds;
					if (rightToLeft == RightToLeft.No)
					{
						bounds = new Rectangle(num, num, parent.ClientSize.Width - num, parent.ClientSize.Height - num);
						myViewControl.Bounds = bounds;
						bounds = new Rectangle(num, 0, parent.ClientSize.Width - num, num);
						ctlHRule.Bounds = bounds;
						bounds = new Rectangle(0, num, num, parent.ClientSize.Height - num);
						ctlVRule.Bounds = bounds;
					}
					else
					{
						bounds = new Rectangle(0, num, parent.ClientSize.Width - num, parent.ClientSize.Height - num);
						myViewControl.Bounds = bounds;
						bounds = new Rectangle(0, 0, parent.ClientSize.Width - num, num);
						ctlHRule.Bounds = bounds;
						bounds = new Rectangle(parent.ClientSize.Width - num, num, num, parent.ClientSize.Height - num);
						ctlVRule.Bounds = bounds;
					}
				}
			}
			else
			{
				myViewControl.Bounds = parent.ClientRectangle;
			}
		}

		protected override void Select(bool directed, bool forward)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.Select();
				InnerViewControl.Focus();
				InnerViewControl.method_196();
			}
		}

		protected override void OnGotFocus(EventArgs eventArgs_0)
		{
			base.OnGotFocus(eventArgs_0);
			if (InnerViewControl != null)
			{
				InnerViewControl.Focus();
			}
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
			WinFormUtils.RunOnceDelay(delegate
			{
				OnResize(null);
			}, 300);
			vmethod_3();
		}

		protected void method_20(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
		}

		[DCInternal]
		protected virtual void vmethod_3()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_128();
			}
		}

		/// <summary>
		///       添加服务对象
		///       </summary>
		/// <param name="instance">服务对象</param>
		[DCInternal]
		[ComVisible(false)]
		public void AddServiceInstance(object instance)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_176(instance);
			}
		}

		/// <summary>
		///       更新文档的默认字体
		///       </summary>
		/// <param name="updateUI">是否更新用户界面</param>
		[DCPublishAPI]
		public void UpdateDefaultFont(bool updateUI)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_177(updateUI);
			}
		}

		/// <summary>
		///       设置输入域选择多个下拉项目
		///       </summary>
		/// <param name="id">输入域编号</param>
		/// <param name="indexs">从0开始的下拉项目序号，各个序号之间用逗号分开</param>
		/// <returns>操作是否修改文档内容</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual bool SetInputFieldSelectedIndexs(string string_5, string indexs)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return Document.SetInputFieldSelectedIndexs(string_5, indexs);
		}

		/// <summary>
		///       编辑器调用的设置文档的默认字体和颜色
		///       </summary>
		/// <param name="font">默认字体</param>
		/// <param name="color">默认文本颜色</param>
		/// <param name="updateUI">是否更新用户界面</param>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DCInternal]
		public void EditorSetDefaultFont(XFontValue font, Color color, bool updateUI)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_178(font, color, updateUI);
			}
		}

		/// <summary>
		///       添加缓存的项目列表
		///       </summary>
		/// <remarks>
		///       在这里添加好项目列表后，只需要设置输入域对象的field.FieldSettings.ListSource.SourceName
		///       等于这里的name参数值就能使用缓存的列表对象。
		///       </remarks>
		/// <param name="name">名称</param>
		/// <param name="items">缓存的项目列表</param>
		/// <param name="globalItems">是否为全局缓存</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void AddBufferedListItems(string name, ListItemCollection items, bool globalItems)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_179(name, items, globalItems);
			}
		}

		/// <summary>
		///       本接口仅供保持兼容性，请改为使用WriteDataFromDocumentToDataSource()
		///       </summary>
		/// <returns>写入的数据条数</returns>
		[DCInternal]
		[Obsolete("请使用WriteDataFromDocumentToDataSource()函数")]
		public int WriteDataSource()
		{
			return WriteDataFromDocumentToDataSource();
		}

		/// <summary>
		///       移动当前光标位置到指定客户区坐标位置处
		///       </summary>
		/// <param name="clientX">控件客户区X坐标，像素单位</param>
		/// <param name="clientY">控件客户区Y坐标，像素单位</param>
		/// <returns>操作是否修改了插入点</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool MoveToClientPosition(int clientX, int clientY)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_159(clientX, clientY);
		}

		/// <summary>
		///       将插入点移动到指定位置
		///       </summary>
		/// <param name="target">移动的目标</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void MoveTo(MoveTarget target)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_180(target);
			}
		}

		/// <summary>
		///       移动光标到指定位置处
		///       </summary>
		/// <param name="index">位置序号</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void MoveToPosition(int index)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_181(index);
			}
		}

		/// <summary>
		///       向左移动光标
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public void MoveLeft()
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveLeft();
			}
		}

		/// <summary>
		///       向左移动光标
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public void MoveRight()
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveRight();
			}
		}

		/// <summary>
		///       移动光标到行首
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void MoveHome()
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveHome();
			}
		}

		/// <summary>
		///       移动光标到行尾
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public void MoveEnd()
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveEnd();
			}
		}

		/// <summary>
		///       移动光标到上一行
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void MoveUpOneLine()
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveUpOneLine();
			}
		}

		/// <summary>
		///       移动光标到下一行
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void MoveDownOneLine()
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveDownOneLine();
			}
		}

		/// <summary>
		///       取消格式刷操作,DCWriter内部使用。
		///       </summary>
		[DCInternal]
		[ComVisible(false)]
		[Browsable(false)]
		public void CancelFormatBrush()
		{
			InnerViewControl.method_182();
		}

		/// <summary>
		///       获得指定元素承载的对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>承载的对象</returns>
		[DCPublishAPI]
		public object GetHostedInstance(XTextControlHostElement element)
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			return InnerViewControl.method_184(element);
		}

		/// <summary>
		///       启用可视化样式
		///       </summary>
		public static void EnableVisualStyles()
		{
			WriterViewControl.smethod_3();
		}

		/// <summary>
		///       创建视图用的画布对象
		///       </summary>
		/// <returns>创建的画布对象</returns>
		[DCInternal]
		public DCGraphics CreateDCViewGraphics()
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			return InnerViewControl.method_186();
		}

		/// <summary>
		///       刷新文档
		///       </summary>
		[DCPublishAPI]
		public void RefreshDocument()
		{
			try
			{
				if (InnerViewControl != null)
				{
					InnerViewControl.method_187();
					method_50(Document);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		/// <summary>
		///       刷新文档排版
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void RefreshDocumentLayout()
		{
			RefreshDocumentExt(refreshSize: false, executeLayout: true);
		}

		/// <summary>
		///       刷新文档
		///       </summary>
		/// <param name="refreshSize">是否重新计算元素大小</param>
		/// <param name="executeLayout">是否进行文档内容重新排版</param>
		[DCPublishAPI]
		public void RefreshDocumentExt(bool refreshSize, bool executeLayout)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_188(refreshSize, executeLayout);
				method_50(Document);
			}
		}

		/// <summary>
		///       刷新文档内部排版和分页。不更新用户界面。
		///       </summary>
		/// <param name="fastMode">
		/// </param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void RefreshInnerView(bool fastMode)
		{
			if (Document != null)
			{
				Document.RefreshInnerView(fastMode);
			}
		}

		/// <summary>
		///       更新文档页状态
		///       </summary>
		[DCInternal]
		public void UpdatePages()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.UpdatePages();
				method_16();
			}
		}

		/// <summary>
		///       单独执行一段外界注入的VB脚本代码
		///       </summary>
		/// <param name="scriptText">脚本代码</param>
		/// <returns>执行结果</returns>
		[DCInternal]
		public object ExecuteVBScript(string scriptText)
		{
			if (InnerViewControl == null)
			{
				return null;
			}
			return InnerViewControl.method_193(scriptText);
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
			if (Document == null)
			{
				return null;
			}
			return Document.GetDataSourceBindingDescriptionsXML();
		}

		/// <summary>
		///       获得文档中绑定的数据源名称字符串列表。各个名称之间用逗号分开。
		///       </summary>
		/// <returns>数据源名称列表</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public string GetBindingDataSources()
		{
			if (Document == null)
			{
				return null;
			}
			return Document.GetBindingDataSources();
		}

		/// <summary>
		///       获得描述数据源绑定信息的XML字符串
		///       </summary>
		/// <returns>描述信息列表</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public DataSourceBindingDescriptionList GetDataSourceBindingDescriptions()
		{
			if (Document == null)
			{
				return null;
			}
			DataSourceBindingDescriptionList dataSourceBindingDescriptions = Document.GetDataSourceBindingDescriptions();
			CollectOuterReferences(dataSourceBindingDescriptions);
			return dataSourceBindingDescriptions;
		}

		/// <summary>
		///       视图坐标转换为控件客户区中的坐标
		///       </summary>
		/// <param name="x">X值</param>
		/// <param name="y">Y值</param>
		/// <returns>新坐标</returns>
		[DCInternal]
		public Point ViewPointToClient(int int_4, int int_5)
		{
			if (InnerViewControl == null)
			{
				return Point.Empty;
			}
			return InnerViewControl.ViewPointToClient(int_4, int_5);
		}

		/// <summary>
		///       将控件客户区中的坐标转换为视图坐标
		///       </summary>
		/// <param name="x">X值</param>
		/// <param name="y">Y值</param>
		/// <returns>新坐标</returns>
		[DCPublishAPI]
		public Point ClientPointToView(int int_4, int int_5)
		{
			if (InnerViewControl == null)
			{
				return Point.Empty;
			}
			return InnerViewControl.ClientPointToView(int_4, int_5);
		}

		/// <summary>
		///       滚动视图到指定的视图坐标位置处
		///       </summary>
		/// <param name="viewPosition">视图Y坐标</param>
		[DCInternal]
		[ComVisible(true)]
		public void ScrollToViewPosition(float viewPosition)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_195(viewPosition);
			}
		}

		/// <summary>
		///       滚动视图到光标位置
		///       </summary>
		[DCPublishAPI]
		public void ScrollToCaret()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_196();
			}
		}

		/// <summary>
		///       滚动视图到光标位置
		///       </summary>
		/// <param name="style">滚动方式</param>
		[DCPublishAPI]
		public void ScrollToCaretExt(ScrollToViewStyle style)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_197(style);
			}
		}

		/// <summary>
		///       根据指定的文档元素对象更新光标
		///       </summary>
		/// <param name="element">指定的文档元素对象</param>
		[DCPublishAPI]
		public void UpdateTextCaretByElement(XTextElement element)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.UpdateTextCaret(element);
			}
		}

		/// <summary>
		///       根据当前元素更新光标
		///       </summary>
		[DCPublishAPI]
		public void UpdateTextCaret()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.UpdateTextCaret();
			}
		}

		/// <summary>
		///       根据当前元素更新光标，而且不会造成用户视图区域的滚动
		///       </summary>
		[DCPublishAPI]
		public void UpdateTextCaretWithoutScroll()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_201();
			}
		}

		/// <summary>
		///       选中文档所有内容
		///       </summary>
		[DCPublishAPI]
		public void SelectAll()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_202();
			}
		}

		/// <summary>
		///       剪切
		///       </summary>
		[DCPublishAPI]
		public bool Cut(bool showUI)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_203(showUI);
		}

		/// <summary>
		///       复制
		///       </summary>
		[DCPublishAPI]
		public bool Copy()
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_204();
		}

		/// <summary>
		///       粘贴
		///       </summary>
		[DCPublishAPI]
		public void Paste()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_205();
			}
		}

		/// <summary>
		///       撤销操作
		///       </summary>
		[DCPublishAPI]
		public void Undo()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_206();
			}
		}

		/// <summary>
		///       重复操作
		///       </summary>
		[DCPublishAPI]
		public void Redo()
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_207();
			}
		}

		/// <summary>
		///       删除选择区域
		///       </summary>
		[DCPublishAPI]
		public void DeleteSelection(bool showUI)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_208(showUI);
			}
		}

		/// <summary>
		///       执行文档元素默认方法
		///       </summary>
		/// <param name="element">文档元素对象</param>
		[DCPublishAPI]
		public void ExecuteElementDefaultMethod(XTextElement element)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_209(element);
			}
		}

		/// <summary>
		///       取消当前的编辑元素内容的操作
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool CancelEditElementValue()
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_210();
		}

		/// <summary>
		///       开始执行编辑元素内容值的操作
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool BeginEditElementValueById(string string_5)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_211(string_5);
		}

		/// <summary>
		///       开始执行编辑元素内容值的操作
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool BeginEditElementValue(XTextElement element)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_212(element);
		}

		internal bool method_21(XTextElement xtextElement_0, bool bool_12, ValueEditorActiveMode valueEditorActiveMode_0, bool bool_13, bool bool_14)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_213(xtextElement_0, bool_12, valueEditorActiveMode_0, bool_13, bool_14);
		}

		/// <summary>
		///       显示插入知识库的弹出式列表
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool BeginInsertKB()
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_214();
		}

		/// <summary>
		///       显示插入知识库的弹出式列表
		///       </summary>
		/// <param name="specifyText">指定的文本</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool BeginInsertKBSpecifyText(string specifyText)
		{
			if (InnerViewControl == null)
			{
				return false;
			}
			return InnerViewControl.method_215(specifyText);
		}

		internal SimpleRectangleTransform method_22(float float_0, float float_1)
		{
			return InnerViewControl.method_216(float_0, float_1);
		}

		/// <summary>
		///       设置缩放比率
		///       </summary>
		/// <param name="rate">缩放比率</param>
		[DCInternal]
		public void SetZoomRate(float rate)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.Zoom(rate);
			}
		}

		/// <summary>
		///       为自动缩放而更新控件状态
		///       </summary>
		[DCInternal]
		public void UpdateForAutoZoom(bool forceLayout)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_217(forceLayout);
			}
		}

		/// <summary>
		///       检查系统运行环境，若成功则返回空引用，若不成功则返回提示信息
		///       </summary>
		/// <param name="throwException">是否抛出异常</param>
		/// <returns>返回的提示信息，若通过则返回空引用</returns>
		[Obsolete("请使用WriterUtils.CheckNET20SP2(bool)")]
		public static string CheckSystemEnvironment(bool throwException)
		{
			return WriterUtils.CheckNET20SP2(throwException);
		}

		internal SimpleRectangleTransform method_23(XTextElement xtextElement_0)
		{
			return InnerViewControl.method_223(xtextElement_0);
		}

		/// <summary>
		///       延时获得焦点
		///       </summary>
		/// <param name="interval">延时的毫秒数</param>
		[ComVisible(true)]
		[DCInternal]
		public void DelayFocus(int interval)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_224(interval);
			}
		}

		/// <summary>
		///       跳到指定页,页号从0开始计算。
		///       </summary>
		/// <param name="targetPageIndex">从0开始的页号</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool MoveToPage(int index)
		{
			return InnerViewControl.MoveToPage(index);
		}

		[DCInternal]
		public Graphics CreateViewGraphics()
		{
			return InnerViewControl.vmethod_15();
		}

		/// <summary>
		///       开始更新内容，锁定用户界面
		///       </summary>
		[DCPublishAPI]
		public void BeginUpdate()
		{
			InnerViewControl.BeginUpdate();
		}

		/// <summary>
		///       结束更新内容，解锁用户界面
		///       </summary>
		[DCPublishAPI]
		public void EndUpdate()
		{
			InnerViewControl.EndUpdate();
		}

		/// <summary>
		///       将文档中的数据写入到数据源中
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public int WriteDataFromDocumentToDataSource()
		{
			if (Document == null)
			{
				return 0;
			}
			return Document.WriteDataFromDocumentToDataSource();
		}

		/// <summary>
		///       请改用WriteDataFromDocumentToDataSource().
		///       </summary>
		[ComVisible(true)]
		[DCInternal]
		public int UpdateDataSourceForView()
		{
			if (Document == null)
			{
				return 0;
			}
			return Document.WriteDataFromDocumentToDataSource();
		}

		/// <summary>
		///       将指定名称的文档参数值填充到文档中
		///       </summary>
		/// <param name="parameterNames">指定的文档参数名称，各个名称之间用英文逗号分开。比如“姓名,性别,国籍”，如果为空则更新全部数据源。</param>
		/// <returns>更新的数据点个数</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public int WriteDataFromDataSourceToDocumentSpecifyParameterNames(string parameterNames)
		{
			if (Document == null)
			{
				return 0;
			}
			if (InnerViewControl == null)
			{
				return 0;
			}
			int num = 0;
			BeginUpdate();
			try
			{
				num = Document.WriteDataFromDataSourceToDocumentSpecifyParameterNames(parameterNames);
				if (num > 0 && Document.UndoList != null)
				{
					Document.UndoList.Clear();
				}
			}
			finally
			{
				EndUpdate();
			}
			if (num > 0 && Document.States.Layouted)
			{
				RefreshDocument();
				Document.OnSelectionChanged();
			}
			return num;
		}

		/// <summary>
		///       将数据源中的数据写入到文档中。
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public int WriteDataFromDataSourceToDocument()
		{
			return WriteDataFromDataSourceToDocumentSpecifyParameterNames(null);
		}

		/// <summary>
		///       请改用WriteDataFromDataSourceToDocument().
		///       </summary>
		[ComVisible(true)]
		[DCInternal]
		public int UpdateViewForDataSource()
		{
			return WriteDataFromDataSourceToDocumentSpecifyParameterNames(null);
		}

		/// <summary>
		///       系统清理内存。这个过程是耗时间的。
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public void GCCollect()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.WaitForFullGCComplete();
		}

		[DCInternal]
		public static void smethod_2(Form form_0, Control control_1)
		{
			WriterViewControl.CheckRegisteredWithDialog(64, form_0, control_1);
		}

		/// <summary>
		///       设置注册码的静态方法
		///       </summary>
		/// <param name="regCode">注册码</param>
		[DCPublishAPI]
		public static void StaticSetRegisterCode(string regCode)
		{
			XTextDocument.StaticRegisterCode = regCode;
		}

		/// <summary>
		///       设置注册码
		///       </summary>
		/// <param name="regCode">注册码文本</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SetRegisterCode(string regCode)
		{
			InnerViewControl.RegisterCode = regCode;
		}

		/// <summary>
		///       重新绘制文档
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public void RedrawDocument()
		{
			Invalidate(invalidateChildren: true);
		}

		[DCInternal]
		public float method_24(float float_0)
		{
			if (float_0 > DocumentOptions.BehaviorOptions.MaxZoomRate)
			{
				float_0 = DocumentOptions.BehaviorOptions.MaxZoomRate;
			}
			if (float_0 < DocumentOptions.BehaviorOptions.MinZoomRate)
			{
				float_0 = DocumentOptions.BehaviorOptions.MinZoomRate;
			}
			return float_0;
		}

		/// <summary>
		///       设置DOM使用的图标
		///       </summary>
		/// <param name="key">图标标号</param>
		/// <param name="bmp">图片对象</param>
		[DCPublishAPI]
		public void SetDomImage(DCStdImageKey dcstdImageKey_0, Bitmap bitmap_0)
		{
			DomImageList.SetBitmape(dcstdImageKey_0, bitmap_0);
			InnerViewControl.ViewHandleManager.method_0();
			InnerViewControl.Invalidate();
		}

		/// <summary>
		///       设置DOM使用的图标
		///       </summary>
		/// <param name="key">图标标号</param>
		/// <param name="fileName">图片文件名</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void SetDomImageByFileName(DCStdImageKey dcstdImageKey_0, string fileName)
		{
			DomImageList.SetBitmapByFileName(dcstdImageKey_0, fileName);
			InnerViewControl.ViewHandleManager.method_0();
			InnerViewControl.Invalidate();
		}

		/// <summary>
		///       设置DOM使用的图标
		///       </summary>
		/// <param name="key">图标标号</param>
		/// <param name="fileName">图片文件名</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void SetDomImageByBase64String(DCStdImageKey dcstdImageKey_0, string base64String)
		{
			DomImageList.SetBitmapByBase64String(dcstdImageKey_0, base64String);
			InnerViewControl.ViewHandleManager.method_0();
			InnerViewControl.Invalidate();
		}

		/// <summary>
		///       高亮度提示文档元素
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="autoScroll">是否自动滚动</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual void FlashElement(XTextElement element, bool autoScroll)
		{
			int num = 14;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			InnerViewControl.method_97(new XTextElementList(element), autoScroll);
		}

		/// <summary>
		///       高亮度提示文档元素
		///       </summary>
		/// <param name="elements">文档元素对象</param>
		/// <param name="autoScroll">是否自动滚动</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual void FlashElements(XTextElementList elements, bool autoScroll)
		{
			int num = 2;
			if (elements == null)
			{
				throw new ArgumentNullException("elements");
			}
			InnerViewControl.method_97(elements, autoScroll);
		}

		/// <summary>
		///       添加被选择区域矩形
		///       </summary>
		/// <param name="rect">矩形</param>
		[DCInternal]
		public void AddSelectionAreaRectangle(Rectangle rect)
		{
			InnerViewControl.method_98(rect);
		}

		/// <summary>
		///       声明指定文档行区域无效，需要重新绘制。
		///       </summary>
		/// <param name="line">
		/// </param>
		/// <param name="party">
		/// </param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DCInternal]
		public void ViewInvalidate(XTextLine line, PageContentPartyStyle party)
		{
			InnerViewControl.method_99(line, party);
		}

		/// <summary>
		///       声明指定区域无效，需要重新绘制。无效矩形采用视图坐标。
		///       </summary>
		/// <param name="rect">无效矩形</param>
		/// <param name="party">文档区域</param>
		[DCInternal]
		public void ViewInvalidate(RectangleF rect, PageContentPartyStyle party)
		{
			InnerViewControl.ViewInvalidate(rect, party);
		}

		/// <summary>
		///       设置指定的区域视图无效
		///       </summary>
		/// <param name="range">文档区域</param>
		[DCPublishAPI]
		public virtual void Invalidate(XTextRange range)
		{
			InnerViewControl.method_101(range);
		}

		/// <summary>
		///       指定页码打印文档，页码是从0开始计算的。
		///       </summary>
		/// <param name="showDialog">是否显示打印机选择对话框</param>
		/// <param name="specifyPageIndexs">
		///       指定的页码，各个页码之间用逗号分开，页码是从0开始计算的，如果为空则打印整个文档</param>
		/// <remarks>
		///       比如
		///       ctl.PrintDocumentExt( true , "1,3,5,7,9");
		///       </remarks>
		[ComVisible(true)]
		[DCPublishAPI]
		public void PrintDocumentExt(bool showDialog, string specifyPageIndexs)
		{
			InnerViewControl.method_59(showDialog, specifyPageIndexs);
		}

		/// <summary>
		///       打印整个文档
		///       </summary>
		[DCPublishAPI]
		public void PrintDocument()
		{
			InnerViewControl.method_60();
		}

		/// <summary>
		///       打印当前页
		///       </summary>
		[DCPublishAPI]
		public void PrintCurrentPage()
		{
			InnerViewControl.method_61();
		}

		/// <summary>
		///       将续打位置移动到指定文档元素的上边缘
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="autoSetStartPageIndex">自动设置开始显示页码</param>
		/// <param name="useTopPosition">true:设置到文档元素的上边缘，false:设置到文档元素的下边缘</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool SetJumpPrintPositionTo(XTextElement element, bool autoSetStartPageIndex, bool useTopPosition)
		{
			return InnerViewControl.method_63(element, autoSetStartPageIndex, useTopPosition);
		}

		/// <summary>
		///       将下端续打位置移动到指定文档元素的边缘
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="autoSetEndPageIndex">自动设置开始显示页码</param>
		/// <param name="useTopPosition">true:设置到文档元素的上边缘，false:设置到文档元素的下边缘</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool SetJumpPrintEndPositionTo(XTextElement element, bool autoSetEndPageIndex, bool useTopPosition)
		{
			return InnerViewControl.method_64(element, autoSetEndPageIndex, useTopPosition);
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
		[ComVisible(true)]
		[DCPublishAPI]
		public bool LockContentByTableRow(string tableID, int rowIndexBase0, string userID, string authoriseUserIDList, bool logUndo)
		{
			return Document.LockContentByTableRow(tableID, rowIndexBase0, userID, authoriseUserIDList, logUndo);
		}

		/// <summary>
		///       锁定文档元素的内容
		///       </summary>
		/// <param name="elementID">元素编号，必须为一个容器类型的元素的编号</param>
		/// <param name="userID">锁定操作的用户ID</param>
		/// <param name="authoriseUserIDList">授权操作的用户ID列表，各个列表之间用英文逗号分开</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool LockContentByElementID(string elementID, string userID, string authoriseUserIDList, bool logUndo)
		{
			return Document.LockContentByElementID(elementID, userID, authoriseUserIDList, logUndo);
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
		[ComVisible(true)]
		[DCPublishAPI]
		public bool LockContentByElement(XTextContainerElement element, string userID, string authoriseUserIDList, bool logUndo)
		{
			return Document.LockContentByElement(element, userID, authoriseUserIDList, logUndo);
		}

		/// <summary>
		///       提交指定容器元素中的用户痕迹信息
		///       </summary>
		/// <param name="id">文档元素编号</param>
		/// <returns>操作是否修改了文档内容</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool CommitContentUserTraceById(string string_5)
		{
			return InnerViewControl.method_76(string_5);
		}

		/// <summary>
		///       提交指定容器元素中的用户痕迹信息
		///       </summary>
		/// <param name="element">容器文档元素对象</param>
		/// <returns>操作是否修改了文档内容</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool CommitContentUserTrace(XTextContainerElement element)
		{
			return InnerViewControl.method_77(element);
		}

		/// <summary>
		///       提交文档中所有的用户痕迹信息
		///       </summary>
		/// <returns>操作是否修改了文档内容</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool CommitDocumentUserTrace()
		{
			return InnerViewControl.method_78();
		}

		/// <summary>
		///       拒绝对文档的修订
		///       </summary>
		/// <returns>操作是否修改了文档内容</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool RejectUserTrace()
		{
			bool result;
			if (result = Document.RejectUserTrace())
			{
				RefreshDocumentExt(refreshSize: false, executeLayout: true);
				OnDocumentContentChanged(null);
				OnSelectionChanged(null);
			}
			return result;
		}

		/// <summary>
		///       导航到指定的用户痕迹信息
		///       </summary>
		/// <param name="info">用户痕迹信息对象</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool NavigateByUserTrackInfo(UserTrackInfo info)
		{
			return InnerViewControl.method_79(info);
		}

		/// <summary>
		///       根据当前操作员信息进行用户登录
		///       </summary>
		/// <returns>操作是否成功</returns>
		[Obsolete("请调用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		public bool UserLogin()
		{
			return InnerViewControl.method_80();
		}

		/// <summary>
		///       用户登录
		///       </summary>
		/// <param name="userID">用户编号</param>
		/// <param name="userName">用户名</param>
		/// <param name="permissionLevel">用户等级</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool UserLogin(string userID, string userName, int permissionLevel)
		{
			return InnerViewControl.method_81(userID, userName, permissionLevel);
		}

		/// <summary>
		///       执行用户登录操作
		///       </summary>
		/// <param name="loginInfo">登录信息</param>
		/// <param name="updateUI">是否更新用户界面</param>
		/// <returns>操作是否成功</returns>
		/// <remarks>
		///       本方法会自动启用授权控制，并以留痕模式显示文档内容。
		///       </remarks>
		[DCPublishAPI]
		public bool UserLogin(UserLoginInfo loginInfo, bool updateUI)
		{
			return InnerViewControl.method_82(loginInfo, updateUI);
		}

		/// <summary>
		///       根据当前操作员信息进行用户登录
		///       </summary>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		[Obsolete("请调用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		public bool UserLoginByCurrentUserInfo()
		{
			return InnerViewControl.method_83();
		}

		/// <summary>
		///       根据用户登录信息执行用户登录操作
		///       </summary>
		/// <param name="loginInfo">登录信息</param>
		/// <param name="updateUI">是否更新用户界面</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool UserLoginByUserLoginInfo(UserLoginInfo loginInfo, bool updateUI)
		{
			return InnerViewControl.method_84(loginInfo, updateUI);
		}

		/// <summary>
		///       根据参数进行用户登录
		///       </summary>
		/// <param name="userID">用户编号</param>
		/// <param name="userName">用户名</param>
		/// <param name="permissionLevel">用户等级</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool UserLoginByParameter(string userID, string userName, int permissionLevel)
		{
			return InnerViewControl.method_85(userID, userName, permissionLevel);
		}

		internal void method_25()
		{
			InnerViewControl.method_86();
		}

		/// <summary>
		///       更新用户历史记录的时间
		///       </summary>
		[DCPublishAPI]
		public void UpdateUserInfoSaveTime()
		{
			InnerViewControl.method_87();
		}

		/// <summary>
		///       更新用户历史记录的时间
		///       </summary>
		/// <remarks>是否追加新的操作记录</remarks>
		[DCPublishAPI]
		public void UpdateUserInfoSaveTimeExt(bool addNewHistoryInfo)
		{
			InnerViewControl.method_88(addNewHistoryInfo);
		}

		/// <summary>
		///       从系统剪切板创建文档对象
		///       </summary>
		/// <returns>创建的文档对象</returns>
		[ComVisible(true)]
		public XTextDocument CreateDocumentFromClipboard()
		{
			return InnerViewControl.method_89();
		}

		/// <summary>
		///       为粘贴操作获得数据源对象
		///       </summary>
		/// <returns>数据对象</returns>
		/// <remarks>DCWriter内部使用</remarks>
		public IDataObject GetSourceDataObjectForPaste(bool prompt)
		{
			return InnerViewControl.method_91(prompt);
		}

		/// <summary>
		///       清空内部的数据对象
		///       </summary>
		[DCInternal]
		public void ClearInnerDataObject()
		{
			InnerViewControl.method_92();
		}

		internal void method_26(IDataObject idataObject_0)
		{
			InnerViewControl.method_93(idataObject_0);
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
		[DCPublishAPI]
		public bool HandleBackspace()
		{
			return InnerViewControl.method_168();
		}

		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public void method_27(Keys keys_0)
		{
			InnerViewControl.method_169(keys_0);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DCInternal]
		public void method_28(char char_0)
		{
			InnerViewControl.method_170(char_0);
		}

		[DCInternal]
		public new Point PointToClient(Point point_0)
		{
			return InnerViewControl.PointToClient(point_0);
		}

		[DCInternal]
		public new Point PointToScreen(Point point_0)
		{
			return InnerViewControl.PointToScreen(point_0);
		}

		[DCInternal]
		public new Rectangle RectangleToClient(Rectangle rectangle_0)
		{
			return InnerViewControl.RectangleToClient(rectangle_0);
		}

		[DCInternal]
		public new Rectangle RectangleToScreen(Rectangle rectangle_0)
		{
			return InnerViewControl.RectangleToScreen(rectangle_0);
		}

		internal void method_29(MouseEventArgs mouseEventArgs_0)
		{
			bool_7 = true;
			try
			{
				OnMouseDown(mouseEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_30(MouseEventArgs mouseEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnMouseMove(mouseEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_31(MouseEventArgs mouseEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnMouseUp(mouseEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_32(MouseEventArgs mouseEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnMouseClick(mouseEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_33(MouseEventArgs mouseEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnMouseDoubleClick(mouseEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_34(MouseEventArgs mouseEventArgs_0)
		{
			bool_7 = true;
			try
			{
				OnMouseWheel(mouseEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_35(EventArgs eventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnMouseEnter(eventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_36(EventArgs eventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnMouseLeave(eventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_37(EventArgs eventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnClick(eventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_38(EventArgs eventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnDoubleClick(eventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_39(KeyEventArgs keyEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnKeyDown(keyEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_171(kevent);
			}
		}

		internal void method_40(KeyPressEventArgs keyPressEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnKeyPress(keyPressEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_172(keyPressEventArgs_0);
			}
		}

		internal void method_41(KeyEventArgs keyEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnKeyUp(keyEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		protected override void OnKeyUp(KeyEventArgs kevent)
		{
			if (InnerViewControl != null)
			{
				InnerViewControl.method_173(kevent);
			}
		}

		internal void method_42(DragEventArgs dragEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnDragDrop(dragEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_43(DragEventArgs dragEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnDragEnter(dragEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_44(EventArgs eventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnDragLeave(eventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		internal void method_45(DragEventArgs dragEventArgs_0)
		{
			bool_7 = true;
			try
			{
				base.OnDragOver(dragEventArgs_0);
			}
			finally
			{
				bool_7 = false;
			}
		}

		private bool method_46(WriterControlWebMethodTypes writerControlWebMethodTypes_0)
		{
			if (WebServiceClient != null)
			{
				WriterControlWebMethodTypes supportedMethods = WebServiceClient.GetSupportedMethods();
				return (supportedMethods & writerControlWebMethodTypes_0) == writerControlWebMethodTypes_0;
			}
			return false;
		}

		internal void method_47()
		{
			if (writerControlEventMessage_0 != null && writerControlEventMessage_0.CheckTimeout())
			{
				writerControlEventMessage_0 = null;
			}
			if (list_0 == null)
			{
				return;
			}
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				if (list_0[num].CheckTimeout())
				{
					list_0.RemoveAt(num);
				}
			}
		}

		/// <summary>
		///       清空内部的编辑器控件事件消息队列
		///       </summary>
		[ComVisible(true)]
		[DCInternal]
		public void ClearEventMessage()
		{
			writerControlEventMessage_0 = null;
			if (list_0 != null)
			{
				list_0.Clear();
			}
		}

		/// <summary>
		///       获得一个编辑器控件事件消息.只有当控件的EnabledControlEvent=false时，本函数才有效。
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public WriterControlEventMessage GetEventMessage()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_157))
			{
				return null;
			}
			writerControlEventMessage_0 = null;
			if (EnabledControlEvent)
			{
				return null;
			}
			if (base.IsHandleCreated)
			{
				lock (this)
				{
					method_47();
					if (list_0 != null && list_0.Count > 0)
					{
						WriterControlEventMessage writerControlEventMessage = list_0[0];
						list_0.RemoveAt(0);
						writerControlEventMessage_0 = writerControlEventMessage;
						CollectOuterReference(writerControlEventMessage);
						return writerControlEventMessage;
					}
				}
			}
			return null;
		}

		internal void method_48(WriterControlEventMessage writerControlEventMessage_1)
		{
			method_49(writerControlEventMessage_1);
		}

		internal void method_49(WriterControlEventMessage writerControlEventMessage_1)
		{
			if (base.IsHandleCreated)
			{
				lock (this)
				{
					if (list_0 != null)
					{
						list_0.Add(writerControlEventMessage_1);
						method_47();
					}
				}
			}
		}

		public virtual void vmethod_4(WriterAfterExecuteEventExpressionEventArgs writerAfterExecuteEventExpressionEventArgs_0)
		{
			int num = 5;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_0(this, writerAfterExecuteEventExpressionEventArgs_0);
			}
			if (writerAfterExecuteEventExpressionEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerAfterExecuteEventExpressionEventHandler_0(this, writerAfterExecuteEventExpressionEventArgs_0);
				}
				else
				{
					try
					{
						writerAfterExecuteEventExpressionEventHandler_0(this, writerAfterExecuteEventExpressionEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventAfterExecuteEventExpression");
					}
				}
			}
		}

		private void method_50(XTextElement xtextElement_0)
		{
			if (base.IsHandleCreated)
			{
				EventHandler method = delegate
				{
					if (DeveloperToolsVisible)
					{
						((GInterface18)control_0).imethod_2(bool_0: false);
					}
					WriterEventArgs writerEventArgs_2 = new WriterEventArgs(this, Document, xtextElement_0);
					vmethod_5(writerEventArgs_2);
				};
				object[] args = new object[2];
				BeginInvoke(method, args);
			}
			else
			{
				WriterEventArgs writerEventArgs_ = new WriterEventArgs(this, Document, xtextElement_0);
				vmethod_5(writerEventArgs_);
			}
		}

		internal virtual void vmethod_5(WriterEventArgs writerEventArgs_0)
		{
			int num = 14;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventRefreshDomTree);
				writerControlEventMessage.SrcElement = writerEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerEventArgs_0.Element;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_1(this, writerEventArgs_0);
			}
			if (writerEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_0(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_0(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventRefreshDomTree");
					}
				}
			}
		}

		internal virtual void vmethod_6(WriterSectionElementCancelEventArgs writerSectionElementCancelEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventBeforeCollapseSection);
				writerControlEventMessage.SrcElement = writerSectionElementCancelEventArgs_0.SectionElement;
				writerControlEventMessage.ToElement = writerSectionElementCancelEventArgs_0.SectionElement;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_2(this, writerSectionElementCancelEventArgs_0);
			}
			if (writerSectionElementCancelEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerSectionElementCancelEventHandler_0(this, writerSectionElementCancelEventArgs_0);
				}
				else
				{
					try
					{
						writerSectionElementCancelEventHandler_0(this, writerSectionElementCancelEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventBeforeCollapseSection");
					}
				}
			}
		}

		internal virtual void vmethod_7(WriterSectionElementEventArgs writerSectionElementEventArgs_0)
		{
			int num = 19;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventAfterCollapseSection);
				writerControlEventMessage.SrcElement = writerSectionElementEventArgs_0.SectionElement;
				writerControlEventMessage.ToElement = writerSectionElementEventArgs_0.SectionElement;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_3(this, writerSectionElementEventArgs_0);
			}
			if (writerSectionElementEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerSectionElementEventHandler_0(this, writerSectionElementEventArgs_0);
				}
				else
				{
					try
					{
						writerSectionElementEventHandler_0(this, writerSectionElementEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventAfterCollapseSection");
					}
				}
			}
		}

		internal virtual void vmethod_8(WriterSectionElementCancelEventArgs writerSectionElementCancelEventArgs_0)
		{
			int num = 12;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventBeforeExpandSection);
				writerControlEventMessage.SrcElement = writerSectionElementCancelEventArgs_0.SectionElement;
				writerControlEventMessage.ToElement = writerSectionElementCancelEventArgs_0.SectionElement;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_4(this, writerSectionElementCancelEventArgs_0);
			}
			if (writerSectionElementCancelEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerSectionElementCancelEventHandler_1(this, writerSectionElementCancelEventArgs_0);
				}
				else
				{
					try
					{
						writerSectionElementCancelEventHandler_1(this, writerSectionElementCancelEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventBeforeExpandSection");
					}
				}
			}
		}

		internal virtual void vmethod_9(WriterSectionElementEventArgs writerSectionElementEventArgs_0)
		{
			int num = 15;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventAfterExpandSection);
				writerControlEventMessage.SrcElement = writerSectionElementEventArgs_0.SectionElement;
				writerControlEventMessage.ToElement = writerSectionElementEventArgs_0.SectionElement;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_5(this, writerSectionElementEventArgs_0);
			}
			if (writerSectionElementEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerSectionElementEventHandler_1(this, writerSectionElementEventArgs_0);
				}
				else
				{
					try
					{
						writerSectionElementEventHandler_1(this, writerSectionElementEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventAfterExpandSection");
					}
				}
			}
		}

		internal void method_51(WriterPrintEventEventArgs writerPrintEventEventArgs_0)
		{
			int num = 12;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventBeginPrint);
				writerControlEventMessage.SrcElement = writerPrintEventEventArgs_0.Document;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.OnEventBeginPrint(this, writerPrintEventEventArgs_0);
			}
			if (writerPrintEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerPrintEventHandler_0(this, writerPrintEventEventArgs_0);
				}
				else
				{
					try
					{
						writerPrintEventHandler_0(this, writerPrintEventEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventBeginPrint");
					}
				}
			}
		}

		internal void method_52(WriterPrintQueryPageSettingsEventArgs writerPrintQueryPageSettingsEventArgs_0)
		{
			int num = 14;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventPrintQueryPageSettings);
				writerControlEventMessage.SrcElement = writerPrintQueryPageSettingsEventArgs_0.Document;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.OnEventPrintQueryPageSettings(this, writerPrintQueryPageSettingsEventArgs_0);
			}
			if (writerPrintQueryPageSettingsEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerPrintQueryPageSettingsEventHandler_0(this, writerPrintQueryPageSettingsEventArgs_0);
				}
				else
				{
					try
					{
						writerPrintQueryPageSettingsEventHandler_0(this, writerPrintQueryPageSettingsEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventPrintQueryPageSettings");
					}
				}
			}
		}

		internal void method_53(WriterPrintPageEventEventArgs writerPrintPageEventEventArgs_0)
		{
			int num = 12;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventPrintPage);
				writerControlEventMessage.SrcElement = writerPrintPageEventEventArgs_0.Document;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.OnEventPrintPage(this, writerPrintPageEventEventArgs_0);
			}
			if (writerPrintPageEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerPrintPageEventHandler_0(this, writerPrintPageEventEventArgs_0);
				}
				else
				{
					try
					{
						writerPrintPageEventHandler_0(this, writerPrintPageEventEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventPrintPage");
					}
				}
			}
		}

		internal void method_54(WriterPrintEventEventArgs writerPrintEventEventArgs_0)
		{
			int num = 16;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventEndPrint);
				writerControlEventMessage.SrcElement = writerPrintEventEventArgs_0.Document;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.OnEventEndPrint(this, writerPrintEventEventArgs_0);
			}
			if (writerPrintEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerPrintEventHandler_1(this, writerPrintEventEventArgs_0);
				}
				else
				{
					try
					{
						writerPrintEventHandler_1(this, writerPrintEventEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventEndPrint");
					}
				}
			}
		}

		[DCInternal]
		public void method_55(WriterBeforeFieldContentEditEventArgs writerBeforeFieldContentEditEventArgs_0)
		{
			int num = 11;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventBeforeFieldContentEdit);
				writerControlEventMessage.SrcElement = writerBeforeFieldContentEditEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerBeforeFieldContentEditEventArgs_0.Element;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.method_0(this, writerBeforeFieldContentEditEventArgs_0);
			}
			if (writerBeforeFieldContentEditEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerBeforeFieldContentEditEventHandler_0(this, writerBeforeFieldContentEditEventArgs_0);
				}
				else
				{
					try
					{
						writerBeforeFieldContentEditEventHandler_0(this, writerBeforeFieldContentEditEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventBeforeFieldContentEdit");
					}
				}
			}
		}

		[DCInternal]
		public void method_56(WriterAfterFieldContentEditEventArgs writerAfterFieldContentEditEventArgs_0)
		{
			int num = 4;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventAfterFieldContentEdit);
				writerControlEventMessage.SrcElement = writerAfterFieldContentEditEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerAfterFieldContentEditEventArgs_0.Element;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.method_1(this, writerAfterFieldContentEditEventArgs_0);
			}
			if (writerAfterFieldContentEditEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerAfterFieldContentEditEventHandler_0(this, writerAfterFieldContentEditEventArgs_0);
				}
				else
				{
					try
					{
						writerAfterFieldContentEditEventHandler_0(this, writerAfterFieldContentEditEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventAfterFieldContentEdit");
					}
				}
			}
		}

		internal virtual void vmethod_10(ElementValidatingEventArgs elementValidatingEventArgs_0)
		{
			int num = 11;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ElementValidating);
				writerControlEventMessage.SrcElement = elementValidatingEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementValidatingEventArgs_0.Element;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_6(this, elementValidatingEventArgs_0);
			}
			if (elementValidatingEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementValidatingEventHandler_0(this, elementValidatingEventArgs_0);
				}
				else
				{
					try
					{
						elementValidatingEventHandler_0(this, elementValidatingEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventElementValidating");
					}
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_11(WriterBeforePlayMediaEventArgs writerBeforePlayMediaEventArgs_0)
		{
			int num = 2;
			if (writerBeforePlayMediaEventArgs_0.MediaElement == null)
			{
				return;
			}
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.BeforePlayMedia);
				writerControlEventMessage.SrcElement = writerBeforePlayMediaEventArgs_0.MediaElement;
				writerControlEventMessage.ToElement = writerBeforePlayMediaEventArgs_0.MediaElement;
				writerControlEventMessage.ReturnValue = writerBeforePlayMediaEventArgs_0.FileName;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_7(this, writerBeforePlayMediaEventArgs_0);
			}
			if (method_46(WriterControlWebMethodTypes.BeforePlayMedia))
			{
				string text2 = writerBeforePlayMediaEventArgs_0.TargetFileName = WebServiceClient.BeforePlayMedia(writerBeforePlayMediaEventArgs_0.Document.ID, writerBeforePlayMediaEventArgs_0.MediaElement.ID, writerBeforePlayMediaEventArgs_0.FileName);
			}
			else if (writerBeforePlayMediaEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerBeforePlayMediaEventHandler_0(this, writerBeforePlayMediaEventArgs_0);
				}
				else
				{
					try
					{
						writerBeforePlayMediaEventHandler_0(this, writerBeforePlayMediaEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventBeforePlayMedia");
					}
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_12()
		{
			int num = 10;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.OutlineTreeChanged);
				method_49(writerControlEventMessage_);
				return;
			}
			WriterEventArgs e = new WriterEventArgs(this, Document, null);
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_8(this, e);
			}
			if (writerEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_1(this, e);
				}
				else
				{
					try
					{
						writerEventHandler_1(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(Document, exception_, "EventOutlineTreeChanged");
					}
				}
			}
		}

		internal virtual void vmethod_13(string string_5, string string_6, string string_7, XTextElement xtextElement_0)
		{
			int num = 15;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ElementCheckedChanged);
				writerControlEventMessage.SrcElement = xtextElement_0;
				writerControlEventMessage.ToElement = xtextElement_0;
				writerControlEventMessage.SrcElementValue = string_7;
				method_49(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_9(string_5, string_6, string_7, xtextElement_0);
			}
			if (writerElementCheckedChangedEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerElementCheckedChangedEventHandler_0(string_5, string_6, string_7, xtextElement_0);
				}
				else
				{
					try
					{
						writerElementCheckedChangedEventHandler_0(string_5, string_6, string_7, xtextElement_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(xtextElement_0, exception_, "EventElementCheckedChanged");
					}
				}
			}
		}

		[DCInternal]
		public void method_57(WriterQueryAssistInputItemsEventArgs writerQueryAssistInputItemsEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.QueryAssistInputItems);
				writerControlEventMessage.SrcElement = writerQueryAssistInputItemsEventArgs_0.ContainerElement;
				writerControlEventMessage.ContextText = writerQueryAssistInputItemsEventArgs_0.PreWord;
				writerControlEventMessage.ReturnValue = writerQueryAssistInputItemsEventArgs_0.Items;
				method_48(writerControlEventMessage);
				return;
			}
			if (method_46(WriterControlWebMethodTypes.QueryAssistInputItems))
			{
				string[] array = WebServiceClient.QueryAssistInputItems(writerQueryAssistInputItemsEventArgs_0.PreWord);
				if (array != null && array.Length > 0)
				{
					writerQueryAssistInputItemsEventArgs_0.Items.AddRange(array);
				}
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.method_2(this, writerQueryAssistInputItemsEventArgs_0);
			}
			if (writerQueryAssistInputItemsEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerQueryAssistInputItemsEventHandler_0(this, writerQueryAssistInputItemsEventArgs_0);
				}
				else
				{
					try
					{
						writerQueryAssistInputItemsEventHandler_0(this, writerQueryAssistInputItemsEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerQueryAssistInputItemsEventArgs_0.Element, exception_, "EventQueryAssistInputItems");
					}
				}
			}
		}

		internal virtual void vmethod_14(WriterBeforeUIKeyboardInputStringEventArgs writerBeforeUIKeyboardInputStringEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_10(this, writerBeforeUIKeyboardInputStringEventArgs_0);
			}
			if (writerBeforeUIKeyboardInputStringEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerBeforeUIKeyboardInputStringEventHandler_0(this, writerBeforeUIKeyboardInputStringEventArgs_0);
				}
				else
				{
					try
					{
						writerBeforeUIKeyboardInputStringEventHandler_0(this, writerBeforeUIKeyboardInputStringEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerBeforeUIKeyboardInputStringEventArgs_0.Element, exception_, "EventBeforeUIKeyboardInputString");
					}
				}
			}
		}

		internal virtual void vmethod_15(WriterTableRowHeightChangedEventArgs writerTableRowHeightChangedEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.TableRowHeightChanged);
				writerControlEventMessage.SrcElement = writerTableRowHeightChangedEventArgs_0.RowElement;
				writerControlEventMessage.ToElement = writerTableRowHeightChangedEventArgs_0.RowElement;
				method_49(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_11(this, writerTableRowHeightChangedEventArgs_0);
			}
			if (writerTableRowHeightChangedEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerTableRowHeightChangedEventHandler_0(this, writerTableRowHeightChangedEventArgs_0);
				}
				else
				{
					try
					{
						writerTableRowHeightChangedEventHandler_0(this, writerTableRowHeightChangedEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerTableRowHeightChangedEventArgs_0.Element, exception_, "EventTableRowHeightChanged");
					}
				}
			}
		}

		internal virtual void vmethod_16(WriterTableRowHeightChangingEventArgs writerTableRowHeightChangingEventArgs_0)
		{
			int num = 8;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_12(this, writerTableRowHeightChangingEventArgs_0);
			}
			if (writerTableRowHeightChangingEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerTableRowHeightChangingEventHandler_0(this, writerTableRowHeightChangingEventArgs_0);
				}
				else
				{
					try
					{
						writerTableRowHeightChangingEventHandler_0(this, writerTableRowHeightChangingEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerTableRowHeightChangingEventArgs_0.Element, exception_, "EventTableRowHeightChanging");
					}
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_17(WriterEventArgs writerEventArgs_0)
		{
			int num = 18;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.DocumentNavigateContentChanged);
				writerControlEventMessage.SrcElement = writerEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerEventArgs_0.Element;
				method_49(writerControlEventMessage);
			}
			else
			{
				if (!base.IsHandleCreated || ControlLoading)
				{
					return;
				}
				InnerViewControl.method_136();
				method_79("DocumentNavigateContentChanged");
				if (ControlEventTemplate != null)
				{
					ControlEventTemplate.OnDocumentNavigateContentChanged(this, writerEventArgs_0);
				}
				if (writerEventHandler_2 != null)
				{
					if (!IsTryCathForRaiseEvent)
					{
						writerEventHandler_2(this, writerEventArgs_0);
					}
					else
					{
						try
						{
							writerEventHandler_2(this, writerEventArgs_0);
						}
						catch (Exception exception_)
						{
							Document.method_39(writerEventArgs_0.Element, exception_, "DocumentNavigateContentChanged");
						}
					}
				}
			}
		}

		internal virtual void vmethod_18(StatusTextChangedEventArgs statusTextChangedEventArgs_0)
		{
			int num = 4;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.StatusTextChanged);
				writerControlEventMessage.ContextText = statusTextChangedEventArgs_0.StatusText;
				method_49(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_13(this, statusTextChangedEventArgs_0);
			}
			if (statusTextChangedEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					statusTextChangedEventHandler_0(this, statusTextChangedEventArgs_0);
				}
				else
				{
					try
					{
						statusTextChangedEventHandler_0(this, statusTextChangedEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "StatusTextChanged");
					}
				}
			}
		}

		internal virtual void vmethod_19(WriterDrawShapeContentEventArgs writerDrawShapeContentEventArgs_0)
		{
			int num = 13;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_14(this, writerDrawShapeContentEventArgs_0);
			}
			if (writerDrawShapeContentEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerDrawShapeContentEventHandler_0(this, writerDrawShapeContentEventArgs_0);
				}
				else
				{
					try
					{
						writerDrawShapeContentEventHandler_0(this, writerDrawShapeContentEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerDrawShapeContentEventArgs_0.Element, exception_, "EventDrawShapeContent");
					}
				}
			}
		}

		internal virtual void vmethod_20(WriterReportErrorEventArgs writerReportErrorEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ReportError);
				writerControlEventMessage.SrcElement = writerReportErrorEventArgs_0.Element;
				writerControlEventMessage.ContextText = writerReportErrorEventArgs_0.Message;
				method_49(writerControlEventMessage);
				return;
			}
			if (method_46(WriterControlWebMethodTypes.ReportError))
			{
				WebServiceClient.ReportError(0, writerReportErrorEventArgs_0.Message, writerReportErrorEventArgs_0.Details);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_15(this, writerReportErrorEventArgs_0);
			}
			if (writerReportErrorEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerReportErrorEventHandler_0(this, writerReportErrorEventArgs_0);
				}
				else
				{
					try
					{
						writerReportErrorEventHandler_0(this, writerReportErrorEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerReportErrorEventArgs_0.Element, exception_, "EventReportError");
					}
				}
			}
		}

		/// <summary>
		///       触发EventAfterLoadRawDOM事件
		///       </summary>
		/// <remarks>
		///       这是一个比较底层的事件，在加载文档的DOM模型后触发，而且在AfterLoad之前触发。
		///       </remarks>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public virtual void OnEventAfterLoadRawDOM(WriterEventArgs args)
		{
			int num = 19;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_16(this, args);
			}
			if (writerEventHandler_3 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_3(this, args);
				}
				else
				{
					try
					{
						writerEventHandler_3(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(args.Element, exception_, "EventAfterLoadRawDOM");
					}
				}
			}
		}

		[DCInternal]
		public void method_58(WriterExpressionFunctionEventArgs writerExpressionFunctionEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.method_3(this, writerExpressionFunctionEventArgs_0);
			}
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
					catch (Exception exception_)
					{
						Document.method_39(writerExpressionFunctionEventArgs_0.Element, exception_, "EventExpressionFunction");
					}
				}
			}
		}

		internal virtual void vmethod_21(WriterGetAdornTextEventArgs writerGetAdornTextEventArgs_0)
		{
			int num = 7;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_17(this, writerGetAdornTextEventArgs_0);
			}
			if (writerGetAdornTextEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerGetAdornTextEventHandler_0(this, writerGetAdornTextEventArgs_0);
				}
				else
				{
					try
					{
						writerGetAdornTextEventHandler_0(this, writerGetAdornTextEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerGetAdornTextEventArgs_0.Element, exception_, "EventGetAdornText");
					}
				}
			}
		}

		internal virtual void vmethod_22(WriterEditElementValueEventArgs writerEditElementValueEventArgs_0)
		{
			int num = 0;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_18(this, writerEditElementValueEventArgs_0);
			}
			if (writerEditElementValueEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEditElementValueEventHandler_0(this, writerEditElementValueEventArgs_0);
				}
				else
				{
					try
					{
						writerEditElementValueEventHandler_0(this, writerEditElementValueEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEditElementValueEventArgs_0.Element, exception_, "EventEditElementValue");
					}
				}
			}
		}

		/// <summary>
		///       重置自动保存任务
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public void ResetAutoSaveTask()
		{
			if (DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond > 0 && Modified)
			{
				method_59();
			}
		}

		internal void method_59()
		{
			method_60();
			if (XTextDocument.smethod_13(GEnum6.const_14) && DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond > 0)
			{
				timer_0 = new System.Windows.Forms.Timer();
				timer_0.Interval = DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond * 1000;
				timer_0.Tick += timer_0_Tick;
				timer_0.Start();
			}
		}

		internal void method_60()
		{
			if (timer_0 != null)
			{
				timer_0.Stop();
				timer_0.Dispose();
				timer_0 = null;
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			method_60();
			if (DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond > 0 && Document.Modified)
			{
				MemoryStream memoryStream = new MemoryStream();
				Document.BackgroundSaveToStream(memoryStream, null);
				WriterSaveFileContentEventArgs writerSaveFileContentEventArgs = new WriterSaveFileContentEventArgs(this, Document, Document, Document.FileName, Document.FileFormat, memoryStream.ToArray());
				OnEventSaveFileContentForAutoSave(writerSaveFileContentEventArgs);
				if (!writerSaveFileContentEventArgs.Handled)
				{
					method_59();
				}
			}
		}

		/// <summary>
		///       触发EventSaveFileContentForAutoSave事件
		///       </summary>
		/// <param name="args">事件参数</param>
		protected virtual void OnEventSaveFileContentForAutoSave(WriterSaveFileContentEventArgs args)
		{
			int num = 2;
			if (AutoSaveManager != null)
			{
				AutoSaveManager.SaveContent(args.FileName, args.BinaryContentToSave);
				if (args.Handled)
				{
					return;
				}
			}
			if (!EnabledEventReadSaveFileContent || !EnabledControlEvent)
			{
				return;
			}
			if (method_46(WriterControlWebMethodTypes.SaveFileContentForAutoSave))
			{
				bool flag2 = args.Result = WebServiceClient.SaveFileContentForAutoSave(args.FileName, args.FileSystemName, args.FileFormat, args.BinaryContentToSave);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.OnEventSaveFileContentForAutoSave(this, args);
			}
			if (writerSaveFileContentEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerSaveFileContentEventHandler_0(this, args);
				}
				else
				{
					try
					{
						writerSaveFileContentEventHandler_0(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(args.Element, exception_, "EventSaveFileContentForAutoSave");
					}
				}
			}
		}

		internal virtual void vmethod_23(WriterSaveFileContentEventArgs writerSaveFileContentEventArgs_0)
		{
			int num = 17;
			if (!EnabledEventReadSaveFileContent || !EnabledControlEvent)
			{
				return;
			}
			if (method_46(WriterControlWebMethodTypes.SaveFileContent))
			{
				bool flag2 = writerSaveFileContentEventArgs_0.Result = WebServiceClient.SaveFileContent(writerSaveFileContentEventArgs_0.FileName, writerSaveFileContentEventArgs_0.FileSystemName, writerSaveFileContentEventArgs_0.FileFormat, writerSaveFileContentEventArgs_0.BinaryContentToSave);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_19(this, writerSaveFileContentEventArgs_0);
			}
			if (writerSaveFileContentEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerSaveFileContentEventHandler_1(this, writerSaveFileContentEventArgs_0);
				}
				else
				{
					try
					{
						writerSaveFileContentEventHandler_1(this, writerSaveFileContentEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerSaveFileContentEventArgs_0.Element, exception_, "EventSaveFileContent");
					}
				}
			}
		}

		internal virtual void vmethod_24(WriterReadFileContentEventArgs writerReadFileContentEventArgs_0)
		{
			int num = 11;
			if (!EnabledEventReadSaveFileContent || !EnabledControlEvent)
			{
				return;
			}
			if (method_46(WriterControlWebMethodTypes.ReadFileContent))
			{
				byte[] array2 = writerReadFileContentEventArgs_0.ResultBinary = WebServiceClient.ReadFileContent(writerReadFileContentEventArgs_0.FileName, writerReadFileContentEventArgs_0.FileSystemName);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_20(this, writerReadFileContentEventArgs_0);
			}
			if (writerReadFileContentEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerReadFileContentEventHandler_0(this, writerReadFileContentEventArgs_0);
				}
				else
				{
					try
					{
						writerReadFileContentEventHandler_0(this, writerReadFileContentEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerReadFileContentEventArgs_0.Element, exception_, "EventReadFileContent");
					}
				}
			}
		}

		internal virtual void vmethod_25(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 13;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementMouseClick);
				writerControlEventMessage.FromElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ContextText = elementMouseEventArgs_0.ElementClientX + "," + elementMouseEventArgs_0.ElementClientY;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_21(this, elementMouseEventArgs_0);
			}
			if (elementMouseEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementMouseEventHandler_0(this, elementMouseEventArgs_0);
				}
				else
				{
					try
					{
						elementMouseEventHandler_0(this, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementMouseEventArgs_0.Element, exception_, "EventElementMouseClick");
					}
				}
			}
		}

		internal virtual void vmethod_26(ElementEventArgs elementEventArgs_0)
		{
			int num = 13;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementGotFocus);
				writerControlEventMessage.FromElement = elementEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementEventArgs_0.Element;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_22(this, elementEventArgs_0);
			}
			if (elementEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementEventHandler_0(this, elementEventArgs_0);
				}
				else
				{
					try
					{
						elementEventHandler_0(this, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementEventArgs_0.Element, exception_, "EventElementGotFocus");
					}
				}
			}
		}

		internal virtual void vmethod_27(ElementEventArgs elementEventArgs_0)
		{
			int num = 13;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementLostFocus);
				writerControlEventMessage.FromElement = elementEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementEventArgs_0.Element;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_23(this, elementEventArgs_0);
			}
			if (elementEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementEventHandler_1(this, elementEventArgs_0);
				}
				else
				{
					try
					{
						elementEventHandler_1(this, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementEventArgs_0.Element, exception_, "EventElementLostFocus");
					}
				}
			}
		}

		internal virtual void vmethod_28(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 18;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementMouseDblClick);
				writerControlEventMessage.FromElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ContextText = elementMouseEventArgs_0.ElementClientX + "," + elementMouseEventArgs_0.ElementClientY;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_24(this, elementMouseEventArgs_0);
			}
			if (elementMouseEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementMouseEventHandler_1(this, elementMouseEventArgs_0);
				}
				else
				{
					try
					{
						elementMouseEventHandler_1(this, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementMouseEventArgs_0.Element, exception_, "EventElementMouseDblClick");
					}
				}
			}
		}

		internal virtual void vmethod_29(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementMouseDown);
				writerControlEventMessage.FromElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ContextText = elementMouseEventArgs_0.ElementClientX + "," + elementMouseEventArgs_0.ElementClientY;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_25(this, elementMouseEventArgs_0);
			}
			if (elementMouseEventHandler_2 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementMouseEventHandler_2(this, elementMouseEventArgs_0);
				}
				else
				{
					try
					{
						elementMouseEventHandler_2(this, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementMouseEventArgs_0.Element, exception_, "EventElementMouseDown");
					}
				}
			}
		}

		internal virtual void vmethod_30(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 1;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementMouseMove);
				writerControlEventMessage.FromElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ContextText = elementMouseEventArgs_0.ElementClientX + "," + elementMouseEventArgs_0.ElementClientY;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_26(this, elementMouseEventArgs_0);
			}
			if (elementMouseEventHandler_3 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementMouseEventHandler_3(this, elementMouseEventArgs_0);
				}
				else
				{
					try
					{
						elementMouseEventHandler_3(this, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementMouseEventArgs_0.Element, exception_, "EventElementMouseMove");
					}
				}
			}
		}

		internal virtual void vmethod_31(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 2;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EventElementMouseUp);
				writerControlEventMessage.FromElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ToElement = elementMouseEventArgs_0.Element;
				writerControlEventMessage.ContextText = elementMouseEventArgs_0.ElementClientX + "," + elementMouseEventArgs_0.ElementClientY;
				method_48(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_27(this, elementMouseEventArgs_0);
			}
			if (elementMouseEventHandler_4 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					elementMouseEventHandler_4(this, elementMouseEventArgs_0);
				}
				else
				{
					try
					{
						elementMouseEventHandler_4(this, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(elementMouseEventArgs_0.Element, exception_, "EventElementMouseUp");
					}
				}
			}
		}

		internal virtual void vmethod_32(WriterButtonClickEventArgs writerButtonClickEventArgs_0)
		{
			int num = 9;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ButtonClick);
				writerControlEventMessage.FromElement = writerButtonClickEventArgs_0.ButtonElement;
				writerControlEventMessage.ToElement = writerButtonClickEventArgs_0.ButtonElement;
				writerControlEventMessage.ContextText = writerButtonClickEventArgs_0.CommandName;
				method_48(writerControlEventMessage);
				return;
			}
			if (method_46(WriterControlWebMethodTypes.ButtonClick))
			{
				WebServiceClient.ButtonClick(writerButtonClickEventArgs_0.ButtonElement.ID, writerButtonClickEventArgs_0.CommandName);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_28(this, writerButtonClickEventArgs_0);
			}
			if (writerButtonClickEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerButtonClickEventHandler_0(this, writerButtonClickEventArgs_0);
				}
				else
				{
					try
					{
						writerButtonClickEventHandler_0(this, writerButtonClickEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerButtonClickEventArgs_0.Element, exception_, "EventButtonClick");
					}
				}
			}
		}

		internal virtual void vmethod_33(WriterLinkEventArgs writerLinkEventArgs_0)
		{
			int num = 1;
			if (writerLinkEventArgs_0.Reference != null && writerLinkEventArgs_0.Reference.StartsWith("#"))
			{
				string text = writerLinkEventArgs_0.Reference.Substring(1);
				if (text.StartsWith("DCTopic_"))
				{
					int result = -1;
					if (int.TryParse(text.Substring("DCTopic_".Length), out result))
					{
						XTextElementList elementsByType = Document.Body.GetElementsByType(typeof(XTextParagraphFlagElement));
						foreach (XTextParagraphFlagElement item in elementsByType)
						{
							if (item.TopicID == result)
							{
								if (item.ParagraphFirstContentElement == null)
								{
									item.Focus();
								}
								else
								{
									item.ParagraphFirstContentElement.Focus();
								}
								InnerViewControl.method_197(ScrollToViewStyle.Middle);
								break;
							}
						}
					}
					return;
				}
			}
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.LinkClick);
				writerControlEventMessage.SrcElement = writerLinkEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerLinkEventArgs_0.Element;
				writerControlEventMessage.ContextText = writerLinkEventArgs_0.Reference;
				method_49(writerControlEventMessage);
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_29(this, writerLinkEventArgs_0);
			}
			if (writerLinkEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerLinkEventHandler_0(this, writerLinkEventArgs_0);
				}
				else
				{
					try
					{
						writerLinkEventHandler_0(this, writerLinkEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerLinkEventArgs_0.Element, exception_, "EventLinkClick");
					}
				}
			}
		}

		internal virtual void vmethod_34(GetLinkListItemsEventArgs getLinkListItemsEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (ControlEventTemplate != null)
			{
				ControlEventTemplate.vmethod_30(this, getLinkListItemsEventArgs_0);
			}
			if (getLinkListItemsEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					getLinkListItemsEventHandler_0(this, getLinkListItemsEventArgs_0);
				}
				else
				{
					try
					{
						getLinkListItemsEventHandler_0(this, getLinkListItemsEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventCollectProtectedElements");
					}
				}
			}
		}

		internal void method_61(XTextContainerElement xtextContainerElement_0, GClass108 gclass108_0, int int_4)
		{
			if (EnabledControlEvent && collectProtectedElementsEventHandler_0 != null)
			{
				CollectProtectedElementsEventArgs collectProtectedElementsEventArgs = new CollectProtectedElementsEventArgs(this, xtextContainerElement_0.OwnerDocument, new XTextElementList(xtextContainerElement_0), gclass108_0);
				collectProtectedElementsEventArgs.LimitedCount = int_4;
				vmethod_35(collectProtectedElementsEventArgs);
			}
		}

		[ComVisible(false)]
		[DCInternal]
		public virtual void vmethod_35(CollectProtectedElementsEventArgs collectProtectedElementsEventArgs_0)
		{
			if (EnabledControlEvent && collectProtectedElementsEventHandler_0 != null)
			{
				if (IsAxControl)
				{
					try
					{
						collectProtectedElementsEventHandler_0(this, collectProtectedElementsEventArgs_0);
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
					collectProtectedElementsEventHandler_0(this, collectProtectedElementsEventArgs_0);
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_36(WriterEventArgs writerEventArgs_0)
		{
			int num = 10;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.ZoomChanged);
				method_49(writerControlEventMessage_);
			}
			else if (writerEventHandler_4 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_4(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_4(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEventArgs_0.Element, exception_, "EventZoomChanged");
					}
				}
			}
		}

		internal virtual void vmethod_37(PromptProtectedContentEventArgs promptProtectedContentEventArgs_0)
		{
			int num = 7;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.PromptProtectedContent);
				writerControlEventMessage.ContextText = promptProtectedContentEventArgs_0.Message;
				writerControlEventMessage.SrcElement = promptProtectedContentEventArgs_0.Element;
				writerControlEventMessage.ToElement = promptProtectedContentEventArgs_0.Element;
				method_49(writerControlEventMessage);
			}
			else if (promptProtectedContentEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					promptProtectedContentEventHandler_0(this, promptProtectedContentEventArgs_0);
				}
				else
				{
					try
					{
						promptProtectedContentEventHandler_0(this, promptProtectedContentEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(promptProtectedContentEventArgs_0.Element, exception_, "EventPromptProtectedContent");
					}
				}
			}
		}

		[DCInternal]
		public void method_62(WriterEventArgs writerEventArgs_0)
		{
			int num = 5;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.TableAddNewRowWhenPressTabKey);
				writerControlEventMessage.SrcElement = writerEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerEventArgs_0.Element;
				method_49(writerControlEventMessage);
			}
			else if (writerEventHandler_5 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_5(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_5(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEventArgs_0.Element, exception_, "EventTableAddNewRowWhenPressTabKey");
					}
				}
			}
		}

		internal virtual void vmethod_38(ContentChangingEventArgs contentChangingEventArgs_0)
		{
			int num = 1;
			if (Document.EnableContentChangedEvent && EnabledControlEvent && contentChangingEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					contentChangingEventHandler_0(this, contentChangingEventArgs_0);
				}
				else
				{
					try
					{
						contentChangingEventHandler_0(this, contentChangingEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(contentChangingEventArgs_0.Element, exception_, "EventContentChanging");
					}
				}
			}
		}

		internal virtual void vmethod_39(WriterEventArgs writerEventArgs_0)
		{
			int num = 14;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.EndTabStop);
				writerControlEventMessage.SrcElement = writerEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerEventArgs_0.Element;
				method_49(writerControlEventMessage);
			}
			else if (writerEventHandler_6 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_6(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_6(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEventArgs_0.Element, exception_, "EventEndTabStop");
					}
				}
			}
		}

		internal virtual void vmethod_40(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			int num = 15;
			if (!Document.EnableContentChangedEvent)
			{
				return;
			}
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ContentChanged);
				writerControlEventMessage.SrcElement = contentChangedEventArgs_0.Element;
				writerControlEventMessage.ToElement = contentChangedEventArgs_0.Element;
				method_49(writerControlEventMessage);
			}
			else if (contentChangedEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					contentChangedEventHandler_0(this, contentChangedEventArgs_0);
				}
				else
				{
					try
					{
						contentChangedEventHandler_0(this, contentChangedEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(contentChangedEventArgs_0.Element, exception_, "EventContentChanged");
					}
				}
			}
		}

		internal virtual void vmethod_41(CustomCommandEventArgs customCommandEventArgs_0)
		{
			int num = 15;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.CustomCommand);
				writerControlEventMessage.ContextText = customCommandEventArgs_0.CommandName;
				method_49(writerControlEventMessage);
			}
			else if (customCommandEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					customCommandEventHandler_0(this, customCommandEventArgs_0);
				}
				else
				{
					try
					{
						customCommandEventHandler_0(this, customCommandEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "ComCustomCommand");
					}
				}
			}
		}

		/// <summary>
		///       触发EventUIStartEditContent事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public virtual void OnEventUIStartEditContent(WriterStartEditEventArgs args)
		{
			int num = 10;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (method_46(WriterControlWebMethodTypes.UIStartEditContent))
			{
				bool flag2 = args.Readonly = WebServiceClient.UIStartEditContent(args.DocumentID);
				args.CanDetectAgain = true;
			}
			else if (writerStartEditEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerStartEditEventHandler_0(this, args);
				}
				else
				{
					try
					{
						writerStartEditEventHandler_0(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(args.Element, exception_, "EventUIStartEditContent");
					}
				}
			}
		}

		internal virtual void vmethod_42(WriterEventArgs writerEventArgs_0)
		{
			int num = 1;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.AfterLoadDocumentDom);
				method_49(writerControlEventMessage_);
			}
			else if (writerEventHandler_7 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_7(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_7(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEventArgs_0.Element, exception_, "AfterLoadDocumentDom");
					}
				}
			}
		}

		[DCInternal]
		public virtual object vmethod_43(Type type_0, object object_0, string string_5)
		{
			if (!EnabledControlEvent)
			{
				return object_0;
			}
			if (createInstanceEventHandler_0 != null)
			{
				CreateInstanceEventArgs createInstanceEventArgs = new CreateInstanceEventArgs(this, Document, type_0, string_5);
				createInstanceEventArgs.CreatedInstance = object_0;
				createInstanceEventHandler_0(this, createInstanceEventArgs);
				if (createInstanceEventArgs.Cancel)
				{
					return null;
				}
				return createInstanceEventArgs.CreatedInstance;
			}
			return object_0;
		}

		internal virtual void vmethod_44()
		{
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.AfterRefreshPages);
				method_49(writerControlEventMessage_);
			}
			else if (writerEventHandler_8 != null)
			{
				WriterEventArgs e;
				if (IsAxControl)
				{
					try
					{
						e = new WriterEventArgs(this, Document, null);
						writerEventHandler_8(this, e);
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.ToString());
					}
					return;
				}
				e = new WriterEventArgs(this, Document, null);
				writerEventHandler_8(this, e);
			}
		}

		internal virtual void vmethod_45(QueryUserHistoryDisplayTextEventArgs queryUserHistoryDisplayTextEventArgs_0)
		{
			int num = 4;
			if (EnabledControlEvent && queryUserHistoryDisplayTextEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					queryUserHistoryDisplayTextEventHandler_0(this, queryUserHistoryDisplayTextEventArgs_0);
				}
				else
				{
					try
					{
						queryUserHistoryDisplayTextEventHandler_0(this, queryUserHistoryDisplayTextEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(queryUserHistoryDisplayTextEventArgs_0.Element, exception_, "QueryUserHistoryDisplayText");
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DCInternal]
		public void method_63(ParseSelectedItemsEventArgs parseSelectedItemsEventArgs_0)
		{
			if (EnabledControlEvent && parseSelectedItemsEventHandler_0 != null)
			{
				if (IsTryCathForRaiseEvent)
				{
					try
					{
						parseSelectedItemsEventHandler_0(this, parseSelectedItemsEventArgs_0);
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
					parseSelectedItemsEventHandler_0(this, parseSelectedItemsEventArgs_0);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DCInternal]
		public void method_64(FormatListItemsEventArgs formatListItemsEventArgs_0)
		{
			if (EnabledControlEvent && formatListItemsEventHandler_0 != null)
			{
				if (IsTryCathForRaiseEvent)
				{
					try
					{
						formatListItemsEventHandler_0(this, formatListItemsEventArgs_0);
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
					formatListItemsEventHandler_0(this, formatListItemsEventArgs_0);
				}
			}
		}

		internal virtual void vmethod_46(WriterCommandEventArgs writerCommandEventArgs_0)
		{
			int num = 17;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.UnknowCommand);
				method_49(writerControlEventMessage_);
			}
			else if (writerCommandEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerCommandEventHandler_0(this, writerCommandEventArgs_0);
				}
				else
				{
					try
					{
						writerCommandEventHandler_0(this, writerCommandEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventUnknowCommand");
					}
				}
			}
		}

		[DCInternal]
		public WriterCommand method_65()
		{
			if (writerCommandEventHandler_0 != null)
			{
				return new UnknowWriterCommand(this);
			}
			return null;
		}

		[DCInternal]
		public void method_66(QueryKBEntriesEventArgs queryKBEntriesEventArgs_0)
		{
			int num = 0;
			if (EnabledControlEvent && queryKBEntriesEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					queryKBEntriesEventHandler_0(this, queryKBEntriesEventArgs_0);
				}
				else
				{
					try
					{
						queryKBEntriesEventHandler_0(this, queryKBEntriesEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "QueryKBEntries");
					}
				}
			}
		}

		internal void method_67(MouseEventArgs mouseEventArgs_0)
		{
			int num = 15;
			if (EnabledControlEvent && writerMouseEventHandler_0 != null)
			{
				WriterMouseEventArgs e = new WriterMouseEventArgs(this, mouseEventArgs_0);
				if (!IsTryCathForRaiseEvent)
				{
					writerMouseEventHandler_0(this, e);
				}
				else
				{
					try
					{
						writerMouseEventHandler_0(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventMouseDownExt");
					}
				}
			}
		}

		internal void method_68(MouseEventArgs mouseEventArgs_0)
		{
			int num = 18;
			if (EnabledControlEvent && writerMouseEventHandler_1 != null)
			{
				WriterMouseEventArgs e = new WriterMouseEventArgs(this, mouseEventArgs_0);
				if (!IsTryCathForRaiseEvent)
				{
					writerMouseEventHandler_1(this, e);
				}
				else
				{
					try
					{
						writerMouseEventHandler_1(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventMouseMoveExt");
					}
				}
			}
		}

		internal void method_69(MouseEventArgs mouseEventArgs_0)
		{
			int num = 18;
			if (EnabledControlEvent && writerMouseEventHandler_2 != null)
			{
				WriterMouseEventArgs e = new WriterMouseEventArgs(this, mouseEventArgs_0);
				if (!IsTryCathForRaiseEvent)
				{
					writerMouseEventHandler_2(this, e);
				}
				else
				{
					try
					{
						writerMouseEventHandler_2(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventMouseUpExt");
					}
				}
			}
		}

		internal void method_70(KeyEventArgs keyEventArgs_0)
		{
			int num = 16;
			if (EnabledControlEvent && writerKeyEventExtHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerKeyEventExtHandler_0(this, (int)keyEventArgs_0.KeyCode, (int)keyEventArgs_0.Modifiers);
				}
				else
				{
					try
					{
						writerKeyEventExtHandler_0(this, (int)keyEventArgs_0.KeyCode, (int)keyEventArgs_0.Modifiers);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "OnEventKeyDownExt");
					}
				}
			}
		}

		internal void method_71(KeyEventArgs keyEventArgs_0)
		{
			int num = 3;
			if (EnabledControlEvent && writerKeyEventExtHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerKeyEventExtHandler_1(this, (int)keyEventArgs_0.KeyCode, (int)keyEventArgs_0.Modifiers);
				}
				else
				{
					try
					{
						writerKeyEventExtHandler_1(this, (int)keyEventArgs_0.KeyCode, (int)keyEventArgs_0.Modifiers);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "OnEventKeyUpExt");
					}
				}
			}
		}

		internal void method_72(KeyPressEventArgs keyPressEventArgs_0)
		{
			int num = 14;
			if (EnabledControlEvent && writerKeyPressEventExtHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerKeyPressEventExtHandler_0(this, keyPressEventArgs_0.KeyChar);
				}
				else
				{
					try
					{
						writerKeyPressEventExtHandler_0(this, keyPressEventArgs_0.KeyChar);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "OnEventKeyPressExt");
					}
				}
			}
		}

		internal void method_73(MouseEventArgs mouseEventArgs_0)
		{
			int num = 1;
			if (EnabledControlEvent && writerMouseEventHandler_3 != null)
			{
				WriterMouseEventArgs e = new WriterMouseEventArgs(this, mouseEventArgs_0);
				if (!IsTryCathForRaiseEvent)
				{
					writerMouseEventHandler_3(this, e);
				}
				else
				{
					try
					{
						writerMouseEventHandler_3(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventMouseClickExt");
					}
				}
			}
		}

		internal void method_74(MouseEventArgs mouseEventArgs_0)
		{
			int num = 12;
			if (EnabledControlEvent && writerMouseEventHandler_3 != null)
			{
				WriterMouseEventArgs e = new WriterMouseEventArgs(this, mouseEventArgs_0);
				if (!IsTryCathForRaiseEvent)
				{
					writerMouseEventHandler_4(this, e);
				}
				else
				{
					try
					{
						writerMouseEventHandler_4(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventMouseDblClickExt");
					}
				}
			}
		}

		internal virtual void vmethod_47(FilterValueEventArgs filterValueEventArgs_0)
		{
			int num = 14;
			if (!XTextDocument.smethod_13(GEnum6.const_153) || !EnabledControlEvent)
			{
				return;
			}
			if (filterValueEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					filterValueEventHandler_0(this, filterValueEventArgs_0);
				}
				else
				{
					try
					{
						filterValueEventHandler_0(this, filterValueEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "FilterValue");
					}
				}
			}
			if (filterValueEventArgs_0.Cancel)
			{
				return;
			}
			FilterValueEventHandler filterValueEventHandler = (FilterValueEventHandler)AppHost.Services.GetService(typeof(FilterValueEventHandler));
			if (filterValueEventHandler != null)
			{
				filterValueEventHandler(this, filterValueEventArgs_0);
				if (filterValueEventArgs_0.Cancel)
				{
				}
			}
		}

		/// <summary>
		///       根据知识库节点创建文档元素
		///       </summary>
		/// <param name="args">参数</param>
		[DCPublishAPI]
		public virtual void CreateElementsByKBEntry(CreateElementsByKBEntryEventArgs args)
		{
			int num = 13;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (createElementsByKBEntryEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					createElementsByKBEntryEventHandler_0(this, args);
				}
				else
				{
					try
					{
						createElementsByKBEntryEventHandler_0(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(args.Element, exception_, "EventCreateElementsByKBEntry");
					}
				}
				if (args.Handled)
				{
					return;
				}
			}
			IKBProvider iKBProvider = (IKBProvider)AppHost.Services.GetService(typeof(IKBProvider));
			iKBProvider.CreateElements(args);
		}

		internal void method_75(WriterEventArgs writerEventArgs_0)
		{
			int num = 17;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.HoverElementChanged);
				writerControlEventMessage.SrcElement = writerEventArgs_0.Element;
				writerControlEventMessage.ToElement = writerEventArgs_0.Element;
				method_49(writerControlEventMessage);
			}
			else if (writerEventHandler_9 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_9(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_9(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEventArgs_0.Element, exception_, "HoverElementChanged");
					}
				}
			}
		}

		internal virtual void vmethod_48(WriterEventArgs writerEventArgs_0)
		{
			int num = 16;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.ReadonlyChanged);
				method_49(writerControlEventMessage_);
			}
			else if (writerEventHandler_10 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_10(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_10(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(writerEventArgs_0.Element, exception_, "EventReadonlyChanged");
					}
				}
			}
		}

		[DCInternal]
		public virtual void OnDocumentLoad(WriterEventArgs writerEventArgs_0)
		{
			int num = 17;
			method_12();
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.DocumentLoad);
				method_49(writerControlEventMessage_);
			}
			else
			{
				if (!base.IsHandleCreated || InnerViewControl.ControlLoading)
				{
					return;
				}
				method_79("DocumentLoad");
				method_25();
				if (writerEventHandler_11 != null)
				{
					if (!IsTryCathForRaiseEvent)
					{
						writerEventHandler_11(this, writerEventArgs_0);
					}
					else
					{
						try
						{
							writerEventHandler_11(this, writerEventArgs_0);
						}
						catch (Exception exception_)
						{
							Document.method_39(writerEventArgs_0.Element, exception_, "DocumentLoad");
						}
					}
				}
				if (comVoidHandler_0 != null)
				{
					if (!IsTryCathForRaiseEvent)
					{
						comVoidHandler_0();
					}
					else
					{
						try
						{
							comVoidHandler_0();
						}
						catch (Exception exception_)
						{
							Document.method_39(writerEventArgs_0.Element, exception_, "VOIDCOMDocumentLoad");
						}
					}
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。向文档插入对象数据
		///       </summary>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnEventInsertObject(InsertObjectEventArgs args)
		{
			int num = 8;
			if (!EnabledControlEvent)
			{
				DocumentControler.vmethod_4(args);
				return;
			}
			if (insertObjectEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					insertObjectEventHandler_0(this, args);
				}
				else
				{
					try
					{
						insertObjectEventHandler_0(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventInsertObject");
					}
				}
			}
			if (!args.Handled)
			{
				DocumentControler.vmethod_4(args);
			}
		}

		/// <summary>
		///       DCWriter内部使用。判断能否插入对象
		///       </summary>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnEventCanInsertObject(CanInsertObjectEventArgs args)
		{
			int num = 4;
			if (!EnabledControlEvent)
			{
				return;
			}
			if (canInsertObjectEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					canInsertObjectEventHandler_0(this, args);
				}
				else
				{
					try
					{
						canInsertObjectEventHandler_0(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventCanInsertObject");
					}
				}
				if (args.Result || args.Handled)
				{
					return;
				}
			}
			DocumentControler.vmethod_2(args);
		}

		internal virtual void vmethod_50(SelectionChangingEventArgs selectionChangingEventArgs_0)
		{
			int num = 6;
			if (!EnabledControlEvent || !bool_10 || !base.IsHandleCreated || ControlLoading)
			{
				return;
			}
			method_79("SelectionChanging");
			if (selectionChangingEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					selectionChangingEventHandler_0(this, selectionChangingEventArgs_0);
				}
				else
				{
					try
					{
						selectionChangingEventHandler_0(this, selectionChangingEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "SelectionChanging");
					}
				}
			}
		}

		private void method_76()
		{
			int num = 19;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.SelectionChanged);
				method_49(writerControlEventMessage_);
			}
			else if (comVoidHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					comVoidHandler_1();
				}
				else
				{
					try
					{
						comVoidHandler_1();
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "VOIDCOMSelectionChanged");
					}
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。触发文档选择状态发生改变后的事件
		///       </summary>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public virtual void OnSelectionChanged(EventArgs args)
		{
			int num = 17;
			if (!base.IsHandleCreated || ControlLoading)
			{
				return;
			}
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.SelectionChanged);
				method_49(writerControlEventMessage_);
				return;
			}
			method_79("SelectionChanged");
			ctlHRule.method_1(Document.CurrentParagraphEOF);
			method_76();
			if (writerEventHandler_12 != null)
			{
				WriterEventArgs e = new WriterEventArgs(this, Document, null);
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_12(this, e);
				}
				else
				{
					try
					{
						writerEventHandler_12(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "SelectionChanged");
					}
				}
			}
			if (CommandControler != null)
			{
				CommandControler.EditControl = this;
				XTextElement currentElement = CurrentElement;
				if (currentElement == null)
				{
				}
				CommandControler.InvalidateCommandState();
			}
		}

		[ComVisible(false)]
		[DCInternal]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void method_77(bool bool_12)
		{
			bool_11 = bool_12;
		}

		/// <summary>
		///       触发文档内容发生改变事件
		///       </summary>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public virtual void OnDocumentContentChanged(EventArgs args)
		{
			int num = 13;
			if (!base.IsHandleCreated || ControlLoading || base.IsDisposed)
			{
				return;
			}
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.DocumentContentChanged);
				method_49(writerControlEventMessage_);
				return;
			}
			if (!bool_11 && InnerViewControl.RuntimeHasCommentLayout)
			{
				GClass445.smethod_9(InnerViewControl, WriterStringsCore.RefreshDocumentComments);
				using (DCGraphics dcgraphics_ = Document.CreateDCGraphics())
				{
					if (CommentManager.imethod_3(dcgraphics_))
					{
						InnerViewControl.method_201();
					}
				}
			}
			if (DocumentOptions.BehaviorOptions.AutoRefreshUserTrackInfos && UserTrackInfos != null)
			{
				UserTrackInfos.Document = Document;
				UserTrackInfos.ContentVersion = Document.ContentVersion - 1;
			}
			method_79("DocumentContentChanged");
			if (writerEventHandler_13 != null)
			{
				WriterEventArgs e = new WriterEventArgs(this, Document, null);
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_13(this, e);
				}
				else
				{
					try
					{
						writerEventHandler_13(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "DocumentContentChanged");
					}
				}
			}
			if (comVoidHandler_2 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					comVoidHandler_2();
				}
				else
				{
					try
					{
						comVoidHandler_2();
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "VOIDCOMDocumentContentChanged");
					}
				}
			}
		}

		/// <summary>
		///       查询下拉列表项目
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>查询的内容</returns>
		[DCInternal]
		public virtual void OnQueryListItems(QueryListItemsEventArgs args)
		{
			int num = 5;
			bool flag = false;
			if (args.Element is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)args.Element;
				if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.DynamicListItems)
				{
					flag = true;
				}
			}
			ListItemCollection listItemCollection = null;
			if (!flag)
			{
				listItemCollection = ListItemsBuffer.GetItems(args.ListSourceName);
				if (listItemCollection != null)
				{
					args.Result = listItemCollection;
					args.Handled = true;
					return;
				}
			}
			if (!args.RaiseEvent)
			{
				return;
			}
			if (method_46(WriterControlWebMethodTypes.QueryListItemsWithDocumentParameter))
			{
				if (args.Result == null || args.Result.Count == 0)
				{
					string documentParameters = Document.Parameters.ToValueString();
					ListItem[] array = WebServiceClient.QueryListItemsWithDocumentParameter(args.ListSourceName, args.SpellCode, args.PreText, args.SpecifyValue, documentParameters);
					if (array != null)
					{
						args.Result.AddRange(array);
					}
				}
				args.Handled = true;
			}
			else if (method_46(WriterControlWebMethodTypes.QueryListItems))
			{
				if (args.Result == null || args.Result.Count == 0)
				{
					ListItem[] array = WebServiceClient.QueryListItems(args.ListSourceName, args.SpellCode, args.PreText, args.SpecifyValue);
					if (array != null)
					{
						args.Result.AddRange(array);
					}
				}
				args.Handled = true;
			}
			else if (queryListItemsEventHandler_0 != null && EnabledControlEvent)
			{
				if (!IsTryCathForRaiseEvent)
				{
					queryListItemsEventHandler_0(this, args);
				}
				else
				{
					try
					{
						queryListItemsEventHandler_0(this, args);
					}
					catch (Exception exception_)
					{
						Document.method_39(args.Element, exception_, "QueryListItems");
					}
				}
			}
			if (!args.Handled)
			{
				if (args.Result == null || args.Result.Count == 0)
				{
					IListItemsProvider listItemsProvider = (IListItemsProvider)AppHost.Services.GetService(typeof(IListItemsProvider));
					if (listItemsProvider != null)
					{
						ListItemsEventArgs listItemsEventArgs = new ListItemsEventArgs(this, args.Document, args.Element, AppHost, args.ListSourceName);
						listItemsEventArgs.KBEntry = args.KBEntry;
						if (args.Element is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)args.Element;
							if (xTextInputFieldElement.FieldSettings != null)
							{
								listItemsEventArgs.Info = xTextInputFieldElement.FieldSettings.ListSource;
							}
						}
						args.Result = listItemsProvider.GetListItems(listItemsEventArgs);
					}
				}
				if (args.Result == null || args.Result.Count == 0)
				{
					KBLibrary kBLibrary = AppHost.KBLibrary;
					if (kBLibrary != null && args.KBEntry != null)
					{
						args.Result = kBLibrary.GetListItemsByListItemsSource(AppHost, this, args.KBEntry);
					}
				}
			}
			if (args.BufferItems && args.Result != null && args.Result.Count > 0)
			{
				ListItemsBuffer.AddItems(args.ListSourceName, args.Result, globalItems: true);
			}
		}

		internal virtual void vmethod_51(EventArgs eventArgs_0)
		{
			int num = 12;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.UserTrackListChanged);
				method_49(writerControlEventMessage_);
			}
			else
			{
				if (!base.IsHandleCreated || ControlLoading)
				{
					return;
				}
				method_79("UserTrackListChanged");
				if (writerEventHandler_14 != null)
				{
					WriterEventArgs e = new WriterEventArgs(this, Document, null);
					if (!IsTryCathForRaiseEvent)
					{
						writerEventHandler_14(this, e);
					}
					else
					{
						try
						{
							writerEventHandler_14(this, e);
						}
						catch (Exception exception_)
						{
							Document.method_39(null, exception_, "UserTrackListChanged");
						}
					}
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_52(WriterCommandEventArgs writerCommandEventArgs_0)
		{
			int num = 16;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.AfterExecuteCommand);
				writerControlEventMessage.ContextText = writerCommandEventArgs_0.Name;
				method_49(writerControlEventMessage);
			}
			else if (writerCommandEventHandler_1 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerCommandEventHandler_1(this, writerCommandEventArgs_0);
				}
				else
				{
					try
					{
						writerCommandEventHandler_1(this, writerCommandEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "AfterExecuteCommand");
					}
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_53(WriterCommandEventArgs writerCommandEventArgs_0)
		{
			int num = 9;
			if (EnabledControlEvent && writerCommandEventHandler_2 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerCommandEventHandler_2(this, writerCommandEventArgs_0);
				}
				else
				{
					try
					{
						writerCommandEventHandler_2(this, writerCommandEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "BeforeExecuteCommand");
					}
				}
			}
		}

		[DCInternal]
		public void method_78()
		{
			int num = 10;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.ScriptError);
				method_49(writerControlEventMessage_);
			}
			else if (writerEventHandler_15 != null)
			{
				WriterEventArgs e = new WriterEventArgs(this, Document, null);
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_15(this, e);
				}
				else
				{
					try
					{
						writerEventHandler_15(this, e);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "ScriptError");
					}
				}
			}
		}

		[DCInternal]
		public virtual void vmethod_54(WriterCommand writerCommand_0, WriterCommandEventArgs writerCommandEventArgs_0, Exception exception_0)
		{
			int num = 15;
			if (!XTextDocument.smethod_13(GEnum6.const_154))
			{
				return;
			}
			InnerViewControl.ReleaseFreezeUI();
			if (commandErrorEventHandler_0 != null && EnabledControlEvent)
			{
				CommandErrorEventArgs commandErrorEventArgs = new CommandErrorEventArgs();
				commandErrorEventArgs.WriterControl = this;
				commandErrorEventArgs.CommandName = writerCommand_0.Name;
				commandErrorEventArgs.CommmandParameter = writerCommandEventArgs_0.Parameter;
				commandErrorEventArgs.Document = commandErrorEventArgs.Document;
				commandErrorEventArgs.Exception = exception_0;
				if (exception_0 != null)
				{
					commandErrorEventArgs.Message = exception_0.Message;
				}
				if (!IsTryCathForRaiseEvent)
				{
					commandErrorEventHandler_0(this, commandErrorEventArgs);
				}
				else
				{
					try
					{
						commandErrorEventHandler_0(this, commandErrorEventArgs);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "CommandError");
					}
				}
			}
			else
			{
				string text = writerCommand_0.Name;
				if (exception_0 != null)
				{
					text = text + ":" + exception_0.Message;
				}
				AppHost.ErrorReporter.ReportError(this, text, exception_0.ToString());
				if (!EnabledControlEvent)
				{
					WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.CommandError);
					writerControlEventMessage.ContextText = text;
					method_49(writerControlEventMessage);
				}
			}
		}

		internal virtual void vmethod_55(WriterDocumentPrintedEventArgs writerDocumentPrintedEventArgs_0)
		{
			int num = 3;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.DocumentPrinted);
				method_49(writerControlEventMessage_);
				return;
			}
			if (method_46(WriterControlWebMethodTypes.DocumentPrinted))
			{
				WebServiceClient.DocumentPrinted(writerDocumentPrintedEventArgs_0.Document.ID, writerDocumentPrintedEventArgs_0.PrintResult.State, writerDocumentPrintedEventArgs_0.PrintResult.NumOfPages, writerDocumentPrintedEventArgs_0.PrintResult.Message);
			}
			if (writerDocumentPrintedEventHandler_0 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerDocumentPrintedEventHandler_0(this, writerDocumentPrintedEventArgs_0);
				}
				else
				{
					try
					{
						writerDocumentPrintedEventHandler_0(this, writerDocumentPrintedEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "DocumentPrinted");
					}
				}
			}
		}

		internal virtual void vmethod_56(WriterEventArgs writerEventArgs_0)
		{
			int num = 4;
			if (!EnabledControlEvent)
			{
				WriterControlEventMessage writerControlEventMessage_ = new WriterControlEventMessage(WriterControlEventMessageType.EventUpdateToolarState);
				method_49(writerControlEventMessage_);
			}
			else if (writerEventHandler_16 != null)
			{
				if (!IsTryCathForRaiseEvent)
				{
					writerEventHandler_16(this, writerEventArgs_0);
				}
				else
				{
					try
					{
						writerEventHandler_16(this, writerEventArgs_0);
					}
					catch (Exception exception_)
					{
						Document.method_39(null, exception_, "EventUpdateToolarState");
					}
				}
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
		[DCPublishAPI]
		public string GetLastEventNames()
		{
			int num = 12;
			if (!XTextDocument.smethod_13(GEnum6.const_157))
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (list_1.Count > 0)
			{
				foreach (string item in list_1)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(item);
				}
				list_1.Clear();
			}
			return stringBuilder.ToString();
		}

		internal void method_79(string string_5)
		{
			if (list_1 == null)
			{
				list_1 = new List<string>();
			}
			if (!list_1.Contains(string_5))
			{
				list_1.Add(string_5);
			}
		}

		/// <summary>
		///       附加文档元素的Load事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementLoadEvent(string idList, ElementLoadEventHandler handler)
		{
			GlobalElementEventMan.method_0(idList, handler);
		}

		/// <summary>
		///       附加文档元素的BeforeDropDown事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementBeforeDropDownEvent(string idList, ElementCancelEventHandler handler)
		{
			GlobalElementEventMan.method_30(idList, handler);
		}

		/// <summary>
		///       附加文档元素的ContentChanged事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementContentChangedEvent(string idList, ContentChangedEventHandler handler)
		{
			GlobalElementEventMan.method_18(idList, handler);
		}

		/// <summary>
		///       附加文档元素的ContentChanging事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementContentChangingEvent(string idList, ContentChangingEventHandler handler)
		{
			GlobalElementEventMan.method_20(idList, handler);
		}

		/// <summary>
		///       附加文档元素的Expression事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementExpressionEvent(string idList, ElementExpressionEventHandler handler)
		{
			GlobalElementEventMan.method_36(idList, handler);
		}

		/// <summary>
		///       附加文档元素的GotFocus事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementGotFocusEvent(string idList, ElementEventHandler handler)
		{
			GlobalElementEventMan.method_22(idList, handler);
		}

		/// <summary>
		///       附加文档元素的KeyDown事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementKeyDownEvent(string idList, ElementKeyEventHandler handler)
		{
			GlobalElementEventMan.method_12(idList, handler);
		}

		/// <summary>
		///       附加文档元素的KeyPress事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementKeyPressEvent(string idList, ElementKeyEventHandler handler)
		{
			GlobalElementEventMan.method_14(idList, handler);
		}

		/// <summary>
		///       附加文档元素的KeyUp事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementKeyUpEvent(string idList, ElementKeyEventHandler handler)
		{
			GlobalElementEventMan.method_16(idList, handler);
		}

		/// <summary>
		///       附加文档元素的LostFocus事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementLostFocusEvent(string idList, ElementEventHandler handler)
		{
			GlobalElementEventMan.method_24(idList, handler);
		}

		/// <summary>
		///       附加文档元素的MouseClick事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementMouseClickEvent(string idList, ElementMouseEventHandler handler)
		{
			GlobalElementEventMan.method_2(idList, handler);
		}

		/// <summary>
		///       附加文档元素的MouseDblClick事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementMouseDblClickEvent(string idList, ElementMouseEventHandler handler)
		{
			GlobalElementEventMan.method_4(idList, handler);
		}

		/// <summary>
		///       附加文档元素的MouseDown事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementMouseDownEvent(string idList, ElementMouseEventHandler handler)
		{
			GlobalElementEventMan.method_6(idList, handler);
		}

		/// <summary>
		///       附加文档元素的MouseEnter事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementMouseEnterEvent(string idList, ElementEventHandler handler)
		{
			GlobalElementEventMan.method_32(idList, handler);
		}

		/// <summary>
		///       附加文档元素的MouseLeave事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementMouseLeaveEvent(string idList, ElementEventHandler handler)
		{
			GlobalElementEventMan.method_34(idList, handler);
		}

		/// <summary>
		///       附加文档元素的MouseMove事件
		///       </summary>
		/// <param name="idList">元素编号列表</param>
		/// <param name="handler">事件委托对象</param>
		[ComVisible(false)]
		public void AttachElementMouseMoveEvent(string idList, ElementMouseEventHandler handler)
		{
			GlobalElementEventMan.method_8(idList, handler);
		}

		[CompilerGenerated]
		private void method_80(object sender, EventArgs e)
		{
			OnResize(null);
		}
	}
}

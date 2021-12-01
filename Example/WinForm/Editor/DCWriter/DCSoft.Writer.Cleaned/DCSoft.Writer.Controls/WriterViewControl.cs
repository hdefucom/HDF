#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.WinForms.Native;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using DCSoft.Writer.Script;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using New.Editor.Controls.Transform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SimpleRectangleTransform = DCSoftDotfuscate.SimpleRectangleTransform;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器打印相关代码
	///       </summary>
	/// <summary>
	///        编辑器命令相关功能模块
	///        </summary>
	/// <remarks>袁永福到此一游</remarks>
	/// <summary>
	///       内容安全及授权相关
	///       </summary>
	/// <summary>
	///       编辑器中绘制用户界面的操作
	///       </summary>
	/// <summary>
	///       授权相关
	///       </summary>
	/// <summary>
	///       加载和保存文件相关的操作
	///       </summary>
	/// <summary>
	///       编辑器鼠标事件处理
	///       </summary>
	/// <summary>
	///       处理键盘事件
	///       </summary>
	/// <summary>
	///       文本文档编辑控件
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	/// <summary>
	///       文档元素级事件相关代码
	///       </summary>
	/// <summary>
	///       编辑器控件的文档对象模型处理模块
	///       </summary>
	/// <summary>
	///       编辑器中文档批注相关的功能
	///       </summary>
	[ToolboxItem(false)]
	[DCInternal]
	[ComVisible(false)]
	public sealed class WriterViewControl : TextPageViewControl
	{
		private delegate void Delegate9(Form form_0, IWin32Window iwin32Window_0);

		private class Class287 : IDisposable
		{
			private bool bool_0;

			private WriterViewControl writerViewControl_0;

			public Class287(WriterViewControl writerViewControl_1)
			{
				int num = 11;
				bool_0 = false;
				writerViewControl_0 = null;
				
				if (writerViewControl_1 == null)
				{
					throw new ArgumentNullException("ctl");
				}
				writerViewControl_0 = writerViewControl_1;
				bool_0 = writerViewControl_0.BackgroundMode;
				writerViewControl_0.BackgroundMode = true;
			}

			public void Dispose()
			{
				writerViewControl_0.BackgroundMode = bool_0;
			}
		}

		public const string string_0 = "2015-11-13";

		private PrintResult printResult_0 = null;

		private JumpPrintInfo jumpPrintInfo_0 = new JumpPrintInfo();

		private WriterCommandControler writerCommandControler_0 = null;

		private Dictionary<string, Dictionary<string, object>> dictionary_0 = new Dictionary<string, Dictionary<string, object>>();

		private UserTrackInfoList userTrackInfoList_0 = null;

		private bool bool_21 = false;

		private bool bool_22 = false;

		private UserLoginInfo userLoginInfo_0 = null;

		private static readonly string string_1 = Guid.NewGuid().ToString();

		private static IDataObject idataObject_0 = null;

		private readonly string string_2 = Guid.NewGuid().ToString();

		private IDataObject idataObject_1 = null;

		private ToolTip toolTip_0 = null;

		private GClass96 gclass96_0 = null;

		private GClass97 gclass97_0 = new GClass97();

		private int int_8 = 0;

		private bool bool_23 = false;

		private List<Rectangle> list_0 = null;

		private PageTitlePosition pageTitlePosition_0 = PageTitlePosition.TopLeft;

		private string _AdditionPageTitle = null;

		private string string_3 = null;

		private static Bitmap bitmap_2 = null;

		private static int int_9 = 0;

		private static XFontValue xfontValue_0 = new XFontValue(Control.DefaultFont.Name, Control.DefaultFont.Size * 1.5f, FontStyle.Bold);

		internal bool bool_24 = true;

		private string string_4 = null;

		private ICaretProvider icaretProvider_0 = null;

		private bool bool_25 = false;

		private static List<WeakReference> list_1 = null;

		private bool bool_26 = false;

		private Enum10 enum10_0 = Enum10.const_0;

		private DocumentNavigator documentNavigator_0 = null;

		private string string_5 = null;

		private GClass255 gclass255_0 = new GClass255();

		private bool bool_27 = true;

		private ContextMenuStrip contextMenuStrip_0 = null;

		private IContextMenuStripManager icontextMenuStripManager_0 = null;

		private bool bool_28 = false;

		internal SimpleRectangleTransform gclass435_1 = null;

		private bool bool_29 = false;

		private DragOperationState dragOperationState_0 = DragOperationState.None;

		private GClass368 gclass368_0 = null;

		internal bool bool_30 = false;

		private GInterface19 ginterface19_0 = null;

		private System.Windows.Forms.Timer timer_1 = null;

		private bool bool_31 = false;

		private dlgPrepareScreenSnapshot dlgPrepareScreenSnapshot_0 = null;

		private Class128 class128_0 = null;

		private int int_10 = 0;

		private WriterControl writerControl_0 = null;

		private bool bool_32 = false;

		private string string_6 = null;

		private bool bool_33 = false;

		private GInterface20 ginterface20_0 = null;

		private string string_7 = null;

		private DCListItemCollectionBuffer dclistItemCollectionBuffer_0 = null;

		private DateTime dateTime_0 = DateTime.Now;

		private bool bool_34 = false;

		private bool bool_35 = false;

		private object object_0 = null;

		private DocumentOptions documentOptions_0 = new DocumentOptions();

		private DocumentControler documentControler_0 = new DocumentControler();

		private WriterAppHost writerAppHost_0 = null;

		private CurrentContentStyleInfo currentContentStyleInfo_0 = null;

		private bool bool_36 = true;

		private static bool bool_37 = false;

		private bool bool_38 = false;

		internal bool bool_39 = false;

		private int int_11 = 0;

		private bool bool_40 = false;

		private bool bool_41 = true;

		[NonSerialized]
		private XTextElement xtextElement_0 = null;

		private bool bool_42 = true;

		private int int_12 = 0;

		private StringBuilder stringBuilder_0 = null;

		internal bool bool_43 = false;

		private TextWindowsFormsEditorHost textWindowsFormsEditorHost_0 = new TextWindowsFormsEditorHost();

		private System.Windows.Forms.Timer timer_2 = null;

		private ElementEventTemplateList elementEventTemplateList_0 = new ElementEventTemplateList();

		private ElementEventTemlateMap elementEventTemlateMap_0 = new ElementEventTemlateMap();

		private bool bool_44 = false;

		private int int_13 = -15;

		private int int_14 = 0;

		private VoidEventHandler voidEventHandler_0 = null;

		private VoidEventHandler voidEventHandler_1 = null;

		private VoidEventHandler voidEventHandler_2 = null;

		private VoidEventHandler voidEventHandler_3 = null;

		private bool bool_45 = false;

		private bool bool_46 = false;

		private XTextDocument xtextDocument_0 = null;

		private Class137 class137_0 = null;

		private GInterface9 ginterface9_0 = null;

		/// <summary>
		///       从0开始计算的获得焦点的当前页码号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int FocusedPageIndexBase0
		{
			get
			{
				if (base.CurrentTransformItem == null)
				{
					return CurrentLineOwnerPageIndex - 1;
				}
				return base.CurrentTransformItem.method_12();
			}
		}

		/// <summary>
		///       页面设置
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public XPageSettings PageSettings
		{
			get
			{
				if (xtextDocument_0 == null)
				{
					return null;
				}
				return xtextDocument_0.PageSettings;
			}
			set
			{
				if (xtextDocument_0 != null)
				{
					xtextDocument_0.PageSettings = value;
				}
			}
		}

		/// <summary>
		///       区域选择打印的信息
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BoundsSelectionPrintInfo BoundsSelection
		{
			get
			{
				if (xtextDocument_0 == null)
				{
					return null;
				}
				return xtextDocument_0.BoundsSelection;
			}
			set
			{
				if (xtextDocument_0 != null)
				{
					xtextDocument_0.BoundsSelection = value;
				}
			}
		}

		/// <summary>
		///       扩展视图模式
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(WriterControlExtViewMode.Normal)]
		public WriterControlExtViewMode ExtViewMode
		{
			get
			{
				if (BoundsSelection != null && BoundsSelection.Enable)
				{
					return WriterControlExtViewMode.BoundsSelection;
				}
				if (jumpPrintInfo_0 != null && jumpPrintInfo_0.Enabled)
				{
					if (JumpPrint.Mode == JumpPrintMode.Offset)
					{
						return WriterControlExtViewMode.OffsetJumpPrint;
					}
					return WriterControlExtViewMode.JumpPrint;
				}
				return WriterControlExtViewMode.Normal;
			}
			set
			{
				if (value == ExtViewMode)
				{
					return;
				}
				method_210();
				switch (value)
				{
				case WriterControlExtViewMode.Normal:
					jumpPrintInfo_0 = null;
					BoundsSelection = null;
					break;
				case WriterControlExtViewMode.JumpPrint:
					jumpPrintInfo_0 = new JumpPrintInfo();
					jumpPrintInfo_0.Enabled = true;
					JumpPrint.Mode = JumpPrintMode.Normal;
					BoundsSelection = null;
					Cursor = Cursors.Arrow;
					break;
				case WriterControlExtViewMode.OffsetJumpPrint:
					jumpPrintInfo_0 = new JumpPrintInfo();
					jumpPrintInfo_0.Enabled = true;
					JumpPrint.Mode = JumpPrintMode.Offset;
					BoundsSelection = null;
					Cursor = Cursors.Arrow;
					break;
				case WriterControlExtViewMode.BoundsSelection:
					jumpPrintInfo_0 = null;
					BoundsSelection = new BoundsSelectionPrintInfo();
					BoundsSelection.Enable = true;
					Cursor = Cursors.Cross;
					if (base.PagesTransform != null)
					{
						foreach (SimpleRectangleTransform item in base.PagesTransform)
						{
							item.setEnable(bool_3: false);
						}
					}
					break;
				}
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}

		/// <summary>
		///       最后一次打印结果
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		///       最后一次的打印位置
		///       </summary>
		/// <remarks>
		///       一般本属性和控件的JumpPrintPosition属性搭配使用.
		///       比如在打印后存储该属性值,下次打开文档后,再设置JumpPrintPosition属性值.
		///       能设置上次打印结束的位置为续打起始位置.
		///       </remarks>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		public int LastPrintPosition
		{
			get
			{
				if (LastPrintResult == null || LastPrintResult.UserCancel)
				{
					return 0;
				}
				return LastPrintResult.Position;
			}
			set
			{
				if (printResult_0 != null)
				{
					printResult_0.Position = value;
				}
			}
		}

		/// <summary>
		///       续打信息
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public JumpPrintInfo JumpPrint
		{
			get
			{
				if (jumpPrintInfo_0 == null && !bool_43)
				{
					jumpPrintInfo_0 = new JumpPrintInfo();
				}
				return jumpPrintInfo_0;
			}
			set
			{
				jumpPrintInfo_0 = value;
			}
		}

		/// <summary>
		///       是否处于常规续打模式
		///       </summary>
		private bool NormalJumpPrint => jumpPrintInfo_0 != null && jumpPrintInfo_0.Mode == JumpPrintMode.Normal;

		/// <summary>
		///       是否允许续打
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool EnableJumpPrint
		{
			get
			{
				return ExtViewMode == WriterControlExtViewMode.JumpPrint;
			}
			set
			{
				if (value)
				{
					ExtViewMode = WriterControlExtViewMode.JumpPrint;
				}
				else
				{
					ExtViewMode = WriterControlExtViewMode.Normal;
				}
			}
		}

		/// <summary>
		///       续打位置
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public float JumpPrintPosition
		{
			get
			{
				return jumpPrintInfo_0.NativePosition;
			}
			set
			{
				JumpPrint.SetNativePosition(value);
				JumpPrintInfo jumpPrintInfoWithouFixPosition;
				if (ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint)
				{
					jumpPrintInfoWithouFixPosition = Document.GetJumpPrintInfoWithouFixPosition(value);
					if (jumpPrintInfoWithouFixPosition != null && jumpPrintInfoWithouFixPosition.PageIndex == 0)
					{
						Document.BodyLayoutOffset = jumpPrintInfoWithouFixPosition.AbsPosition;
						JumpPrint.PageIndex = 0;
						JumpPrint.Position = jumpPrintInfoWithouFixPosition.Position;
						JumpPrint.EndPageIndex = -1;
						JumpPrint.EndPosition = -1f;
					}
					else
					{
						Document.BodyLayoutOffset = 0f;
						JumpPrint.PageIndex = 0;
						JumpPrint.Position = 0f;
					}
					if (base.IsHandleCreated)
					{
						method_188(bool_47: false, bool_48: true);
						method_201();
					}
					return;
				}
				if (Document.BodyLayoutOffset != 0f)
				{
					Document.BodyLayoutOffset = 0f;
					if (base.IsHandleCreated)
					{
						method_188(bool_47: false, bool_48: true);
						method_201();
					}
				}
				jumpPrintInfoWithouFixPosition = Document.GetJumpPrintInfo(value);
				if (jumpPrintInfoWithouFixPosition != null)
				{
					JumpPrint.PageIndex = jumpPrintInfoWithouFixPosition.PageIndex;
					JumpPrint.Position = jumpPrintInfoWithouFixPosition.Position;
				}
				else
				{
					JumpPrint.PageIndex = 0;
					JumpPrint.Position = 0f;
				}
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
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
				return jumpPrintInfo_0.NativeEndPosition;
			}
			set
			{
				JumpPrintInfo jumpPrintInfo = Document.GetJumpPrintInfo(value);
				JumpPrint.SetNativeEndPosition(value);
				if (jumpPrintInfo != null)
				{
					JumpPrint.EndPageIndex = jumpPrintInfo.PageIndex;
					JumpPrint.EndPosition = jumpPrintInfo.Position;
				}
				else
				{
					JumpPrint.EndPageIndex = -1;
					JumpPrint.EndPosition = 0f;
				}
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}

		/// <summary>
		///       命令控制器对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public WriterCommandControler CommandControler
		{
			get
			{
				if (writerCommandControler_0 == null)
				{
					writerCommandControler_0 = new WriterCommandControler();
				}
				writerCommandControler_0.CommandContainer = AppHost.CommandContainer;
				writerCommandControler_0.EditControl = OwnerWriterControl;
				return writerCommandControler_0;
			}
			set
			{
				writerCommandControler_0 = value;
				if (writerCommandControler_0 != null)
				{
					if (writerCommandControler_0.EditControl != null && writerCommandControler_0.EditControl.InnerViewControl != null)
					{
						writerCommandControler_0.EditControl.InnerViewControl.writerCommandControler_0 = null;
					}
					writerCommandControler_0 = value;
					writerCommandControler_0.CommandContainer = AppHost.CommandContainer;
					writerCommandControler_0.EditControl = OwnerWriterControl;
				}
			}
		}

		/// <summary>
		///       用户修改痕迹信息列表
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		public UserTrackInfoList UserTrackInfos
		{
			get
			{
				if (base.IsDisposed)
				{
					return null;
				}
				if (userTrackInfoList_0 == null)
				{
					userTrackInfoList_0 = new UserTrackInfoList(Document);
				}
				userTrackInfoList_0.Document = Document;
				if (DocumentOptions.BehaviorOptions.AutoRefreshUserTrackInfos && userTrackInfoList_0.ContentVersion != Document.ContentVersion)
				{
					userTrackInfoList_0.Document = Document;
					userTrackInfoList_0.Refresh();
				}
				return userTrackInfoList_0;
			}
		}

		/// <summary>
		///       是否以管理员模式运行
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		[Browsable(true)]
		public bool IsAdministrator
		{
			get
			{
				if (documentControler_0 == null)
				{
					return bool_21;
				}
				return DocumentControler.IsAdministrator;
			}
			set
			{
				bool_21 = value;
				if (documentControler_0 != null)
				{
					DocumentControler.IsAdministrator = value;
				}
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
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		/// <summary>
		///       执行自动登录时使用的用户登录信息
		///       </summary>
		[Obsolete("请调用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public UserLoginInfo AutoUserLoginInfo
		{
			get
			{
				return userLoginInfo_0;
			}
			set
			{
				userLoginInfo_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的剪切板对象
		///       </summary>
		internal ClipboardProvider RuntimeClipboard
		{
			get
			{
				if (OwnerWriterControl != null && OwnerWriterControl.Clipboard != null)
				{
					return OwnerWriterControl.Clipboard;
				}
				return AppHost.Clipboard;
			}
		}

		/// <summary>
		///       是否显示提示文本
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool ShowTooltip
		{
			get
			{
				return DocumentOptions.BehaviorOptions.ShowTooltip;
			}
			set
			{
				DocumentOptions.BehaviorOptions.ShowTooltip = value;
				if (!value && base.IsHandleCreated)
				{
					TooltipControl.SetToolTip(this, null);
				}
			}
		}

		/// <summary>
		///       内置的提示信息控件
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ToolTip TooltipControl
		{
			get
			{
				if (toolTip_0 == null && !base.IsDisposed)
				{
					toolTip_0 = new ToolTip();
				}
				return toolTip_0;
			}
		}

		/// <summary>
		///       元素提示文本信息列表
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GClass97 ToolTips
		{
			get
			{
				return gclass97_0;
			}
			set
			{
				gclass97_0 = value;
			}
		}

		protected override bool RuntimeDesignMode => DocumentOptions.BehaviorOptions.DesignMode;

		/// <summary>
		///       DOM使用的图标列表
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCStdImageList DomImageList => Document.DomImageList;

		/// <summary>
		///       高亮度显示区域
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public HighlightInfo HighlightRange
		{
			get
			{
				if (Document.HighlightManager == null)
				{
					return null;
				}
				return Document.HighlightManager.imethod_5();
			}
			set
			{
				XTextDocument document = Document;
				if (document.HighlightManager != null && !HighlightInfo.smethod_0(document.HighlightManager.imethod_5(), value))
				{
					if (document.HighlightManager.imethod_2() != null)
					{
						foreach (HighlightInfo item in document.HighlightManager.imethod_2())
						{
							Document.method_71(item.Range);
						}
					}
					document.HighlightManager.imethod_6(value);
					if (document.HighlightManager.imethod_5() != null)
					{
						foreach (HighlightInfo item2 in document.HighlightManager.imethod_2())
						{
							Document.method_71(item2.Range);
						}
					}
				}
			}
		}

		/// <summary>
		///       高亮度显示区域
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public HighlightInfoList HighlightRanges
		{
			get
			{
				if (Document.HighlightManager == null)
				{
					return null;
				}
				return Document.HighlightManager.imethod_2();
			}
			set
			{
				XTextDocument document = Document;
				if (document.HighlightManager != null && document.HighlightManager.imethod_2() != value)
				{
					if (document.HighlightManager.imethod_2() != null)
					{
						foreach (HighlightInfo item in document.HighlightManager.imethod_2())
						{
							Document.method_71(item.Range);
						}
					}
					document.HighlightManager.imethod_3(value);
					foreach (HighlightInfo item2 in document.HighlightManager.imethod_2())
					{
						Document.method_71(item2.Range);
					}
				}
			}
		}

		/// <summary>
		///       页面标题位置
		///       </summary>
		[DefaultValue(PageTitlePosition.TopLeft)]
		[Category("Appearance")]
		internal PageTitlePosition PageTitlePosition
		{
			get
			{
				return pageTitlePosition_0;
			}
			set
			{
				pageTitlePosition_0 = value;
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}

		/// <summary>
		///       注册码文件URL地址
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(null)]
		[Category("Data")]
		internal string RegisterCodeFileUrl
		{
			get
			{
				return XTextDocument.StaticRegisterCodeFileUrl;
			}
			set
			{
				XTextDocument.StaticRegisterCodeFileUrl = value;
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal string RegisterCode
		{
			get
			{
				return null;
			}
			set
			{
				XTextDocument.StaticRegisterCode = value;
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}

		/// <summary>
		///       显示在已经注册的页码标题文本后面的额外的页码标题文本
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		internal string AdditionPageTitle
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

		protected override int PreserveSpacingInPageView
		{
			get
			{
				if (method_106() == 1)
				{
					return 20;
				}
				return 0;
			}
		}

		/// <summary>
		///       对话框标题前缀
		///       </summary>
		[Browsable(false)]
		public string DialogTitlePrefix => string_3;

		/// <summary>
		///       标记图片
		///       </summary>
		public static Bitmap DCLogonImage
		{
			get
			{
				if (bitmap_2 == null)
				{
					bitmap_2 = WriterResourcesCore.DCLogon96;
					bitmap_2.MakeTransparent(Color.Red);
				}
				return bitmap_2;
			}
		}

		/// <summary>
		///       控件数据
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				if (Document != null)
				{
					return Document.Text;
				}
				return "";
			}
			set
			{
				method_192();
				if (Document != null)
				{
					Document.Text = value;
				}
				method_187();
				method_131();
				Invalidate();
			}
		}

		/// <summary>
		///       RTF文本
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string RTFText
		{
			get
			{
				if (Document == null)
				{
					return "";
				}
				return Document.RTFText;
			}
			set
			{
				method_192();
				if (Document != null)
				{
					Document.RTFText = value;
				}
				method_187();
				method_131();
				Invalidate();
			}
		}

		/// <summary>
		///       未格式化的XML文本
		///       </summary>
		[Browsable(false)]
		internal string XMLTextUnFormatted => Document.XMLTextUnFormatted;

		/// <summary>
		///       XML文本
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal string XMLText
		{
			get
			{
				int num = 9;
				if (Document == null)
				{
					return null;
				}
				string xMLText = Document.XMLText;
				if (xMLText.Length < 30)
				{
					throw new Exception("内容过短，可能存在问题");
				}
				return xMLText;
			}
			set
			{
				method_192();
				using (method_116(bool_47: true, null))
				{
					Document.XMLText = value;
					Document.GetDebugText();
					method_187();
					method_131();
					Invalidate();
				}
			}
		}

		/// <summary>
		///       获得文档XML内容
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal string XMLTextWithDocumentState
		{
			get
			{
				method_88(bool_47: false);
				return XMLText;
			}
			set
			{
				XMLText = value;
			}
		}

		/// <summary>
		///       生成用于保存的XML字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal string XMLTextForSave
		{
			get
			{
				method_88(bool_47: true);
				return XMLText;
			}
			set
			{
				XMLText = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用, 指定的一次性使用的加载文件时的文件名。
		///        </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SpecifyLoadFileNameOnce
		{
			get
			{
				string result = string_4;
				string_4 = null;
				return result;
			}
			set
			{
				string_4 = value;
			}
		}

		/// <summary>
		///       光标控制对象
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public override ICaretProvider Caret
		{
			get
			{
				if (icaretProvider_0 == null)
				{
					icaretProvider_0 = writerAppHost_0.Tools.CreateCaretProvider(OwnerWriterControl);
				}
				return icaretProvider_0;
			}
		}

		/// <summary>
		///       编辑器正在显示某种用户界面
		///       </summary>
		[ReadOnly(true)]
		[Browsable(false)]
		public bool ShowingUI
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
		///        允许执行StartEditContent事件
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool EnableUIEventStartEditContent
		{
			get
			{
				return bool_26;
			}
			set
			{
				bool_26 = value;
			}
		}

		/// <summary>
		///       文档内容导航者
		///       </summary>
		[Browsable(false)]
		public DocumentNavigator Navigator
		{
			get
			{
				if (documentNavigator_0 == null && !bool_43)
				{
					documentNavigator_0 = new DocumentNavigator();
					documentNavigator_0.WriterControl = OwnerWriterControl;
					documentNavigator_0.Refresh();
				}
				return documentNavigator_0;
			}
		}

		/// <summary>
		///       当前光标位置所在的导航节点对象
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		public NavigateNode CurrentNavigateNode => Navigator.CurrentNode;

		/// <summary>
		///       状态文本
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string StatusText
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		/// <summary>
		///       配套的工具窗体列表
		///       </summary>
		[Browsable(false)]
		public GClass255 ToolWindows
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return gclass255_0;
			}
		}

		/// <summary>
		///       销毁控件的时候是否自动销毁快捷菜单
		///       </summary>
		[DefaultValue(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoDisposeContextMenu
		{
			get
			{
				return bool_27;
			}
			set
			{
				bool_27 = value;
			}
		}

		/// <summary>
		///       批注使用的快键菜单
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ContextMenuStrip CommentContextMenuStrip
		{
			get
			{
				return contextMenuStrip_0;
			}
			set
			{
				contextMenuStrip_0 = value;
			}
		}

		/// <summary>
		///       快捷菜单管理器
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public IContextMenuStripManager ContextMenuManager
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_156))
				{
					return null;
				}
				if (bool_43)
				{
					return icontextMenuStripManager_0;
				}
				if (icontextMenuStripManager_0 == null)
				{
					icontextMenuStripManager_0 = AppHost.Tools.CreateContextMenuStripManager(OwnerWriterControl);
				}
				return icontextMenuStripManager_0;
			}
			set
			{
				icontextMenuStripManager_0 = value;
			}
		}

		/// <summary>
		///       能否直接拖拽文档内容
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AllowDragContent
		{
			get
			{
				return DocumentOptions.BehaviorOptions.AllowDragContent;
			}
			set
			{
				DocumentOptions.BehaviorOptions.AllowDragContent = value;
			}
		}

		/// <summary>
		///       编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据
		///       </summary>
		[Description("编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据")]
		[Category("Behavior")]
		[DefaultValue(WriterDataFormats.All)]
		public WriterDataFormats AcceptDataFormats
		{
			get
			{
				return DocumentOptions.BehaviorOptions.AcceptDataFormats;
			}
			set
			{
				DocumentOptions.BehaviorOptions.AcceptDataFormats = value;
			}
		}

		/// <summary>
		///       编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作
		///       </summary>
		[Description("编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作")]
		[DefaultValue(WriterDataFormats.All)]
		[Category("Behavior")]
		public WriterDataFormats CreationDataFormats
		{
			get
			{
				return DocumentOptions.BehaviorOptions.CreationDataFormats;
			}
			set
			{
				DocumentOptions.BehaviorOptions.CreationDataFormats = value;
			}
		}

		/// <summary>
		///       拖拽事件已经处理标记
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool DragEventHandled
		{
			get
			{
				return bool_28;
			}
			set
			{
				bool_28 = value;
			}
		}

		/// <summary>
		///       鼠标拖拽使用的转换对象
		///       </summary>
		protected override TransformBase MouseCaptureTransform
		{
			get
			{
				if (gclass435_1 == null)
				{
					return base.Transform;
				}
				return gclass435_1;
			}
		}

		/// <summary>
		///       编辑器控件正在执行OLE拖拽事件
		///       </summary>
		[Browsable(false)]
		public DragOperationState DragState => dragOperationState_0;

		/// <summary>
		///       快捷辅助录入窗口对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GInterface19 AssistStringListForm
		{
			get
			{
				if (base.IsDisposed || !base.IsHandleCreated)
				{
					method_163();
					return null;
				}
				if (!XTextDocument.smethod_13(GEnum6.const_152))
				{
					return null;
				}
				if (ginterface19_0 == null && !bool_43)
				{
					ginterface19_0 = AppHost.Tools.CreateAssistStringList(OwnerWriterControl);
				}
				return ginterface19_0;
			}
		}

		/// <summary>
		///       取消下一次的KePress事件
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool IgnoreNextKeyPressEventOnce
		{
			get
			{
				return bool_31;
			}
			set
			{
				bool_31 = value;
			}
		}

		/// <summary>
		///       延时截屏使用的对话框,DCWriter内部使用.
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(false)]
		public dlgPrepareScreenSnapshot DlgSnapshotDelay
		{
			get
			{
				return dlgPrepareScreenSnapshot_0;
			}
			set
			{
				dlgPrepareScreenSnapshot_0 = value;
			}
		}

		/// <summary>
		///       输入的字符的缓冲区
		///       </summary>
		internal Class128 InputCharBuffer
		{
			get
			{
				if (class128_0 == null && !bool_43)
				{
					class128_0 = new Class128(this);
				}
				return class128_0;
			}
		}

		/// <summary>
		///       启用输入法
		///       </summary>
		protected override bool CanEnableIme => true;

		/// <summary>
		///       控件所在的编辑器控件对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[Browsable(false)]
		[ComVisible(false)]
		internal WriterControl OwnerWriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
				if (xtextDocument_0 != null)
				{
					xtextDocument_0.EditorControl = value;
				}
			}
		}

		/// <summary>
		///       知识库文件URL
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		public string KBLibraryUrl
		{
			get
			{
				return string_6;
			}
			set
			{
				if (string_6 != value)
				{
					string_6 = value;
					bool_32 = true;
				}
			}
		}

		/// <summary>
		///       知识库对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(null)]
		public KBLibrary KBLibrary
		{
			get
			{
				if (bool_32)
				{
					bool_32 = false;
					if (!string.IsNullOrEmpty(KBLibraryUrl))
					{
						WriterReadFileContentEventArgs args = new WriterReadFileContentEventArgs(OwnerWriterControl, Document, null, KBLibraryUrl, null);
						byte[] buffer = WriterControl.ReadFileContent(OwnerWriterControl, args);
						MemoryStream stream = new MemoryStream(buffer);
						KBLibrary kBLibrary = new KBLibrary();
						kBLibrary.Load(stream);
						if (string.IsNullOrEmpty(kBLibrary.BaseURL))
						{
							kBLibrary.BaseURL = GClass334.smethod_1(KBLibraryUrl);
						}
						AppHost.Services.AddService(typeof(KBLibrary), kBLibrary);
					}
				}
				return (KBLibrary)AppHost.Services.GetService(typeof(KBLibrary));
			}
			set
			{
				AppHost.Services.AddService(typeof(KBLibrary), value);
				bool_32 = false;
			}
		}

		/// <summary>
		///       编辑器内核版本号
		///       </summary>
		public string CoreVersion => "2015-11-13";

		/// <summary>
		///       返回内核版本号的静态属性
		///       </summary>
		public static string StaticCoreVersion => "2015-11-13";

		/// <summary>
		///       控件是否处于等待模式
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool WaittingMode => GClass445.smethod_8(this);

		/// <summary>
		///       自动设置文档的默认字体
		///       </summary>
		/// <remarks>若该属性值为true，则编辑器会自动将控件的字体和前景色设置
		///       到文档的默认字体和文本颜色。修改本属性值不会立即更新文档视图，
		///       此时需要调用“UpdateDefaultFont( true )”来更新文档视图。</remarks>
		[DefaultValue(false)]
		[Category("Appearance")]
		public bool AutoSetDocumentDefaultFont
		{
			get
			{
				return bool_33;
			}
			set
			{
				if (bool_33 != value)
				{
					bool_33 = value;
				}
			}
		}

		/// <summary>
		///       承载的控件管理器
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public GInterface20 ControlHostManger
		{
			get
			{
				if (bool_43)
				{
					return ginterface20_0;
				}
				if (ginterface20_0 == null)
				{
					ginterface20_0 = AppHost.Tools.CreateControlHostManager();
					if (ginterface20_0 != null)
					{
						ginterface20_0.ViewControl = this;
					}
				}
				return ginterface20_0;
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
				return DocumentOptions.BehaviorOptions.MoveFocusHotKey;
			}
			set
			{
				DocumentOptions.BehaviorOptions.MoveFocusHotKey = value;
			}
		}

		/// <summary>
		///       初始化是用的参数列表，格式为“参数名:参数值;参数名:参数值;”。
		///       </summary>
		[Category("Data")]
		[Browsable(false)]
		[DefaultValue(null)]
		public string InitalizeParameterValues
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
			}
		}

		/// <summary>
		///       列表缓存对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DCListItemCollectionBuffer ListItemsBuffer
		{
			get
			{
				if (dclistItemCollectionBuffer_0 == null && !bool_43)
				{
					dclistItemCollectionBuffer_0 = new DCListItemCollectionBuffer();
				}
				return dclistItemCollectionBuffer_0;
			}
		}

		/// <summary>
		///       最后一次用户界面事件的发生时间
		///       </summary>
		/// <remarks>这里的用户界面事件包括鼠标键盘事件、OLE拖拽事件，
		///       应用程序可以根据这个属性值来实现超时锁定用户界面的功能。</remarks>
		[Browsable(false)]
		public DateTime LastUIEventTime => dateTime_0;

		/// <summary>
		///       文档内容只读标记
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool Readonly
		{
			get
			{
				return bool_34;
			}
			set
			{
				if (bool_34 != value)
				{
					bool_34 = value;
					WriterEventArgs writerEventArgs_ = new WriterEventArgs(OwnerWriterControl, Document, null);
					OwnerWriterControl.vmethod_48(writerEventArgs_);
				}
			}
		}

		/// <summary>
		///       运行时的控件内容只读设置
		///       </summary>
		[Browsable(false)]
		internal bool RuntimeReadonly
		{
			get
			{
				if (XTextDocument.InnerLicenseViewerOnly)
				{
					return true;
				}
				return bool_34;
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
				return bool_35;
			}
			set
			{
				bool_35 = value;
			}
		}

		/// <summary>
		///       控件是否处于调试模式
		///       </summary>
		[Browsable(false)]
		public bool InDesignMode
		{
			get
			{
				if (base.DesignMode)
				{
					return true;
				}
				try
				{
					Control parent = base.Parent;
					while (true)
					{
						if (parent == null)
						{
							return false;
						}
						if (parent.Site != null && parent.Site.DesignMode)
						{
							break;
						}
						parent = parent.Parent;
					}
					return true;
				}
				catch
				{
					return false;
				}
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
				return DocumentOptions.BehaviorOptions.FormView;
			}
			set
			{
				DocumentOptions.BehaviorOptions.FormView = value;
			}
		}

		/// <summary>
		///       服务器对象
		///       </summary>
		[ComVisible(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public object ServerObject
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
				if (xtextDocument_0 != null)
				{
					xtextDocument_0.ServerObject = object_0;
				}
			}
		}

		/// <summary>
		///       文档设置
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DocumentOptions DocumentOptions
		{
			get
			{
				if (bool_43)
				{
					return documentOptions_0;
				}
				if (documentOptions_0 == null)
				{
					documentOptions_0 = new DocumentOptions();
					documentOptions_0.SetWriterControl(this);
				}
				return documentOptions_0;
			}
			set
			{
				documentOptions_0 = value;
				if (xtextDocument_0 != null)
				{
					xtextDocument_0.Options = documentOptions_0;
					documentOptions_0.SetWriterControl(this);
				}
			}
		}

		/// <summary>
		///       文档设置XML字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public string DocumentOptionsXML
		{
			get
			{
				return XMLHelper.SaveObjectToIndentXMLString(DocumentOptions);
			}
			set
			{
				((DocumentOptions)XMLHelper.LoadObjectFromXMLString(typeof(DocumentOptions), value))?.CopyValuesTo(DocumentOptions);
			}
		}

		/// <summary>
		///       违禁关键字
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ExcludeKeywords
		{
			get
			{
				return DocumentOptions.BehaviorOptions.ExcludeKeywords;
			}
			set
			{
				DocumentOptions.BehaviorOptions.ExcludeKeywords = value;
			}
		}

		/// <summary>
		///       文档控制器
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DocumentControler DocumentControler
		{
			get
			{
				if (bool_43)
				{
					return documentControler_0;
				}
				if (documentControler_0 == null)
				{
					documentControler_0 = new DocumentControler();
				}
				if (documentControler_0.EditorControl != OwnerWriterControl)
				{
					documentControler_0.EditorControl = OwnerWriterControl;
				}
				if (documentControler_0.Document != xtextDocument_0)
				{
					documentControler_0.Document = xtextDocument_0;
				}
				return documentControler_0;
			}
			set
			{
				documentControler_0 = value;
				if (documentControler_0 != null)
				{
					documentControler_0.Document = xtextDocument_0;
					documentControler_0.EditorControl = OwnerWriterControl;
					documentControler_0.IsAdministrator = bool_21;
				}
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public WriterAppHost AppHost
		{
			get
			{
				if (writerAppHost_0 == null)
				{
					writerAppHost_0 = WriterAppHost.Default;
				}
				return writerAppHost_0;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       为格式刷而准备的文档格式信息对象,DCWriter内部使用。
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public CurrentContentStyleInfo StyleInfoForFormatBrush
		{
			get
			{
				return currentContentStyleInfo_0;
			}
			set
			{
				currentContentStyleInfo_0 = value;
			}
		}

		/// <summary>
		///       获得将文档单位转换为屏幕像素单位的比率
		///       </summary>
		[Browsable(false)]
		public float RateOfDocumentUnitToPixel
		{
			get
			{
				float num = 1f;
				num = ((Document != null) ? ((float)GraphicsUnitConvert.GetRate(GraphicsUnit.Pixel, Document.DocumentGraphicsUnit)) : ((float)GraphicsUnitConvert.GetRate(GraphicsUnit.Pixel, GraphicsUnit.Document)));
				return num * base.XZoomRate;
			}
		}

		/// <summary>
		///       控件正在加载标记
		///       </summary>
		[Browsable(false)]
		internal bool ControlLoading => bool_36;

		/// <summary>
		///       文档内容视图高度
		///       </summary>
		[Browsable(false)]
		public override float ContentViewHeight => Document.Body.Height;

		public override float ContentViewWidth
		{
			get
			{
				float result = base.ContentViewWidth;
				if (RuntimeViewMode == PageViewMode.Normal || RuntimeViewMode == PageViewMode.NormalCenter)
				{
					result = Document.Body.ViewWidth + 1f;
				}
				return result;
			}
		}

		/// <summary>
		///       是否启用平滑滚动效果
		///       </summary>
		protected override bool SmoothScrollView
		{
			get
			{
				if (bool_40)
				{
					return false;
				}
				return DocumentOptions.BehaviorOptions.SmoothScrollView;
			}
		}

		/// <summary>
		///       当选择了文档内容时隐藏光标
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool HideCaretWhenHasSelection
		{
			get
			{
				return bool_41;
			}
			set
			{
				bool_41 = value;
			}
		}

		/// <summary>
		///       文档中当前元素或被选择区域的开始位置在编辑器控件客户区中的坐标
		///       </summary>
		[Browsable(false)]
		public Point SelectionStartPosition
		{
			get
			{
				XTextElement currentElement = CurrentElement;
				if (currentElement != null)
				{
					return method_254(currentElement).Location;
				}
				return Point.Empty;
			}
		}

		/// <summary>
		///        表示当前插入点位置信息的字符串
		///       </summary>
		[Browsable(false)]
		public string PositionInfoText
		{
			get
			{
				XTextLine currentLine = Document.CurrentContentElement.CurrentLine;
				if (currentLine != null && currentLine.OwnerPage != null)
				{
					return string.Format(WriterStringsCore.LineInfo_PageIndex_LineIndex_ColumnIndex, Convert.ToString(currentLine.OwnerPage.PageIndex + 1), Convert.ToString(CurrentLineIndexInPage), Convert.ToString(CurrentColumnIndex));
				}
				return null;
			}
		}

		/// <summary>
		///       正在编辑文档元素数值
		///       </summary>
		[Browsable(false)]
		public bool IsEditingElementValue
		{
			get
			{
				if (base.IsDisposed || !base.IsHandleCreated)
				{
					return false;
				}
				return EditorHost != null && EditorHost.CurrentEditContext != null;
			}
		}

		/// <summary>
		///       可以被拖拽的文档元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextElement DragableElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				if (xtextElement_0 == value)
				{
					return;
				}
				if (xtextElement_0 != null && base.IsHandleCreated)
				{
					Rectangle dragableHandleBounds = DragableHandleBounds;
					if (!dragableHandleBounds.IsEmpty)
					{
						Invalidate(dragableHandleBounds);
					}
				}
				xtextElement_0 = value;
				if (xtextElement_0 != null && base.IsHandleCreated)
				{
					Rectangle dragableHandleBounds = DragableHandleBounds;
					if (!dragableHandleBounds.IsEmpty)
					{
						Invalidate(dragableHandleBounds);
					}
				}
			}
		}

		/// <summary>
		///       拖拽句柄边界
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle DragableHandleBounds => Rectangle.Empty;

		/// <summary>
		///       绝对的是否占有焦点
		///       </summary>
		[Browsable(false)]
		public bool AbsoluteFocused
		{
			get
			{
				if (Focused)
				{
					return true;
				}
				if (ShowingUI)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       在控件的获得/失去焦点事件时是否触发文档的获得/失去焦点事件
		///       </summary>
		[DefaultValue(true)]
		public bool RaiseDocumentFoucsEventWhenControlFocusEvent
		{
			get
			{
				return bool_42;
			}
			set
			{
				bool_42 = value;
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[Browsable(false)]
		public TextWindowsFormsEditorHost EditorHost
		{
			get
			{
				if (bool_43)
				{
					return textWindowsFormsEditorHost_0;
				}
				if (base.IsDisposed)
				{
					return null;
				}
				if (textWindowsFormsEditorHost_0 == null)
				{
					textWindowsFormsEditorHost_0 = new TextWindowsFormsEditorHost();
				}
				textWindowsFormsEditorHost_0.EditControl = OwnerWriterControl;
				textWindowsFormsEditorHost_0.Document = Document;
				return textWindowsFormsEditorHost_0;
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
				if (DocumentOptions == null)
				{
					return false;
				}
				return DocumentOptions.BehaviorOptions.EnabledElementEvent;
			}
			set
			{
				if (DocumentOptions != null)
				{
					DocumentOptions.BehaviorOptions.EnabledElementEvent = value;
				}
			}
		}

		/// <summary>
		///       文档元素事件模板列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public ElementEventTemplateList EventTemplates
		{
			get
			{
				if (bool_43)
				{
					return elementEventTemplateList_0;
				}
				if (elementEventTemplateList_0 == null)
				{
					elementEventTemplateList_0 = new ElementEventTemplateList();
				}
				return elementEventTemplateList_0;
			}
			set
			{
				elementEventTemplateList_0 = value;
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
				return elementEventTemlateMap_0;
			}
			set
			{
				elementEventTemlateMap_0 = value;
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
				return method_227(typeof(XTextFieldElementBase));
			}
			set
			{
				method_228(typeof(XTextFieldElementBase), value);
			}
		}

		/// <summary>
		///       复选框元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_CheckBox
		{
			get
			{
				return method_227(typeof(XTextCheckBoxElementBase));
			}
			set
			{
				method_228(typeof(XTextCheckBoxElementBase), value);
			}
		}

		/// <summary>
		///       表格元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Table
		{
			get
			{
				return method_227(typeof(XTextTableElement));
			}
			set
			{
				method_228(typeof(XTextTableElement), value);
			}
		}

		/// <summary>
		///       表格行元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		public ElementEventTemplate GlobalEventTemplate_TableRow
		{
			get
			{
				return method_227(typeof(XTextTableRowElement));
			}
			set
			{
				method_228(typeof(XTextTableRowElement), value);
			}
		}

		/// <summary>
		///       单元格元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Cell
		{
			get
			{
				return method_227(typeof(XTextTableCellElement));
			}
			set
			{
				method_228(typeof(XTextTableCellElement), value);
			}
		}

		/// <summary>
		///       图片元素全局事件模板对象,是GlobalEventTemplates属性的封装。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public ElementEventTemplate GlobalEventTemplate_Image
		{
			get
			{
				return method_227(typeof(XTextImageElement));
			}
			set
			{
				method_228(typeof(XTextImageElement), value);
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
				return method_227(typeof(XTextElement));
			}
			set
			{
				method_228(typeof(XTextElement), value);
			}
		}

		/// <summary>
		///       强制预处理消息，用于避免某些情况下的堆栈溢出错误。
		///       </summary>
		/// <remarks>一般情况下，AxWriterControl会自动检测是否需要强制预处理消息。不排除在某些情况下
		///       无法自动检测而导致出现堆栈溢出的错误，此时可以设置这个属性来强制预处理消息。</remarks>
		[Browsable(false)]
		[DefaultValue(false)]
		public bool ForcePreProcessMessage
		{
			get
			{
				return bool_44;
			}
			set
			{
				bool_44 = value;
			}
		}

		/// <summary>
		///       布局停靠样式，仅仅向COM接口提供该属性
		///       </summary>
		[ComVisible(false)]
		[Browsable(false)]
		[Obsolete("仅提供兼容性")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(0)]
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

		internal bool AutoDisposeDocument
		{
			get
			{
				return bool_45;
			}
			set
			{
				bool_45 = value;
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
		[ComVisible(true)]
		public bool BackgroundMode
		{
			get
			{
				return bool_46;
			}
			set
			{
				if (XTextDocument.smethod_13(GEnum6.const_123))
				{
					bool_46 = value;
				}
				else
				{
					bool_46 = false;
				}
			}
		}

		/// <summary>
		///       文档内容改变标记
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public bool Modified
		{
			get
			{
				return Document.Modified;
			}
			set
			{
				if (Document.Modified != value)
				{
					Document.Modified = value;
				}
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextDocument Document
		{
			get
			{
				if (base.IsDisposed)
				{
					return null;
				}
				if (bool_43)
				{
					return xtextDocument_0;
				}
				if (xtextDocument_0 == null)
				{
					xtextDocument_0 = new XTextDocument();
					xtextDocument_0.Options = DocumentOptions;
					xtextDocument_0.EditorControl = OwnerWriterControl;
					xtextDocument_0.DocumentControler = DocumentControler;
					if (AutoSetDocumentDefaultFont)
					{
						method_177(bool_47: false);
					}
					xtextDocument_0.Clear();
				}
				else if (!xtextDocument_0.States.Printing && !xtextDocument_0.States.PrintPreviewing)
				{
					xtextDocument_0.Options = DocumentOptions;
					xtextDocument_0.EditorControl = OwnerWriterControl;
					xtextDocument_0.DocumentControler = documentControler_0;
				}
				if (documentControler_0 != null)
				{
					documentControler_0.Document = xtextDocument_0;
				}
				xtextDocument_0.ServerObject = ServerObject;
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
				if (xtextDocument_0 != null)
				{
					if (DocumentOptions != null)
					{
						xtextDocument_0.Options = DocumentOptions;
					}
					xtextDocument_0.EditorControl = OwnerWriterControl;
					xtextDocument_0.DocumentControler = documentControler_0;
					documentControler_0.Document = xtextDocument_0;
					xtextDocument_0.ServerObject = ServerObject;
					xtextDocument_0.Options = DocumentOptions;
					xtextDocument_0.Body.FixElements();
				}
			}
		}

		internal bool HasDocument => xtextDocument_0 != null;

		/// <summary>
		///       当前文档内容版本号，对文档内容的任何修改都会使得该版本号增加
		///       </summary>
		[Browsable(false)]
		public int DocumentContentVersion => Document.ContentVersion;

		/// <summary>
		///       绘图单位
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override GraphicsUnit GraphicsUnit
		{
			get
			{
				if (xtextDocument_0 == null)
				{
					return GraphicsUnit.Document;
				}
				return xtextDocument_0.DocumentGraphicsUnit;
			}
			set
			{
			}
		}

		/// <summary>
		///       当前元素样式
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public DocumentContentStyle CurrentStyle => Document.CurrentStyleInfo.Content;

		/// <summary>
		///       当前插入点所在的元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextElement CurrentElement => Document.CurrentElement;

		/// <summary>
		///       当前单选的文档元素对象
		///       </summary>
		/// <remarks>
		///       当只选中一个文档元素对象，则返回给文档元素对象，如果没有选中元素
		///       或者选中多个元素，则返回空。
		///       </remarks>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		public XTextElement SingleSelectedElement
		{
			get
			{
				if (Selection.ContentElements != null && Selection.ContentElements.Count == 1)
				{
					return Selection.ContentElements[0];
				}
				return null;
			}
		}

		/// <summary>
		///       当前插入点所在的输入域元素
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextInputFieldElement CurrentInputField => method_245(typeof(XTextInputFieldElement)) as XTextInputFieldElement;

		/// <summary>
		///       当前插入点所在的单元格元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextTableCellElement CurrentTableCell => method_245(typeof(XTextTableCellElement)) as XTextTableCellElement;

		/// <summary>
		///       当前插入点所在的表格行元素
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public XTextTableRowElement CurrentTableRow => method_245(typeof(XTextTableRowElement)) as XTextTableRowElement;

		/// <summary>
		///       当前插入点所在的表格元素
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public XTextTableElement CurrentTable => method_245(typeof(XTextTableElement)) as XTextTableElement;

		/// <summary>
		///       当前插入点所在的文档节对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		public XTextSectionElement CurrentSection => method_245(typeof(XTextSectionElement)) as XTextSectionElement;

		/// <summary>
		///       当前文档部分类型
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public PageContentPartyStyle CurrentContentPartyStyle
		{
			get
			{
				return Document.CurrentContentPartyStyle;
			}
			set
			{
				if (Document.CurrentContentPartyStyle != value)
				{
					foreach (XTextDocumentContentElement element in Document.Elements)
					{
						if (element.ContentPartyStyle == value)
						{
							XTextDocumentContentElement currentContentElement = Document.CurrentContentElement;
							Document.CurrentContentElement = element;
							Document.CurrentContentElement.method_67(currentContentElement.CurrentElement, element.CurrentElement);
							Document.CurrentContentElement.FixElements();
							UpdatePages();
							Invalidate();
							if (DrawerUtil.IsHeaderFooter(element.ContentPartyStyle) && HeaderFooterReadonly)
							{
								UpdateTextCaret();
							}
						}
					}
				}
			}
		}

		/// <summary>
		///       鼠标悬停的元素
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public XTextElement HoverElement => Document.HoverElement;

		/// <summary>
		///       当前文本行
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextLine CurrentLine => Document.CurrentContentElement.CurrentLine;

		/// <summary>
		///       获得从1开始计算的当前列号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int CurrentColumnIndex
		{
			get
			{
				if (Document.Content.CurrentElement != null)
				{
					return Document.Content.CurrentElement.ColumnIndex;
				}
				return -1;
			}
		}

		/// <summary>
		///       当前行号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int CurrentLineIndex
		{
			get
			{
				if (Document.Content.CurrentLine == null)
				{
					return -1;
				}
				return Document.Content.CurrentLine.GlobalIndex;
			}
		}

		/// <summary>
		///       获得从1开始计算的当前文本行在页中的序号
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int CurrentLineIndexInPage
		{
			get
			{
				if (Document.Content.CurrentLine == null)
				{
					return -1;
				}
				return Document.Content.CurrentLine.IndexInPage;
			}
		}

		/// <summary>
		///       获得从1开始计算的当前文本行所在的页码
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int CurrentLineOwnerPageIndex
		{
			get
			{
				if (xtextDocument_0 != null && xtextDocument_0.Content.CurrentLine != null && xtextDocument_0.Content.CurrentLine.OwnerPage != null)
				{
					return base.Pages.IndexOf(xtextDocument_0.Content.CurrentLine.OwnerPage) + 1;
				}
				return 0;
			}
		}

		/// <summary>
		///       文档选择的部分
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextSelection Selection => Document.Selection;

		/// <summary>
		///       即使在只读状态下是否能编辑文档批注
		///       </summary>
		[DefaultValue(false)]
		public bool CommentEditableWhenReadonly
		{
			get
			{
				return DocumentOptions.BehaviorOptions.CommentEditableWhenReadonly;
			}
			set
			{
				DocumentOptions.BehaviorOptions.CommentEditableWhenReadonly = value;
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
				return DocumentOptions.BehaviorOptions.CommentVisibility;
			}
			set
			{
				DocumentOptions.BehaviorOptions.CommentVisibility = value;
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
				if (!XTextDocument.smethod_13(GEnum6.const_148))
				{
					return false;
				}
				XTextDocument document = Document;
				if (document != null)
				{
					switch (CommentVisibility)
					{
					case FunctionControlVisibility.Auto:
						if (document != null)
						{
							if (document.Comments.HasVisibleComment)
							{
								return true;
							}
							if (document.InnerComments != null && document.InnerComments.Count > 0)
							{
								return true;
							}
						}
						return false;
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
		///       运行时是否显示文档批注
		///       </summary>
		[Browsable(false)]
		internal bool RuntimeHasCommentLayout
		{
			get
			{
				XTextDocument document = Document;
				if (document != null)
				{
					switch (CommentVisibility)
					{
					case FunctionControlVisibility.Auto:
						if (document != null)
						{
							DocumentCommentList runtimeComments = document.RuntimeComments;
							return runtimeComments != null && runtimeComments.Count > 0;
						}
						return false;
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
		///       文档批注配置信息
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override GClass543 CommentSettings
		{
			get
			{
				if (RuntimeHasCommentLayout)
				{
					GClass543 gClass = new GClass543();
					gClass.method_1(RuntimeCommentVisible);
					gClass.method_11(Document.ToPixel((int)gClass.method_8()));
					return gClass;
				}
				return null;
			}
			set
			{
				base.CommentSettings = value;
			}
		}

		/// <summary>
		///       鼠标双击来编辑文档批注
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("鼠标双击来编辑文档批注")]
		public bool DoubleClickToEditComment
		{
			get
			{
				return DocumentOptions.BehaviorOptions.DoubleClickToEditComment;
			}
			set
			{
				DocumentOptions.BehaviorOptions.DoubleClickToEditComment = value;
			}
		}

		/// <summary>
		///       文档元素视图中的小把柄管理器
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal Class137 ViewHandleManager
		{
			get
			{
				if (class137_0 == null)
				{
					class137_0 = new Class137(this);
				}
				return class137_0;
			}
		}

		/// <summary>
		///       文档批注管理器
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GInterface9 CommentManager
		{
			get
			{
				if (ginterface9_0 == null && !bool_43)
				{
					ginterface9_0 = AppHost.Tools.CreateDocumentCommentManager(OwnerWriterControl);
				}
				if (ginterface9_0 != null)
				{
					ginterface9_0.imethod_1(CommentSettings);
				}
				return ginterface9_0;
			}
		}

		/// <summary>
		///       针对COM而声明的文档内容选择状态发生改变事件
		///       </summary>
		[Obsolete("★★★不推荐使用本事件")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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
		[Obsolete("★★★不推荐使用本事件")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		[Browsable(false)]
		[Obsolete("★★★不推荐使用本事件")]
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
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★不推荐使用本事件")]
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

		[ComVisible(true)]
		public void method_59(bool bool_47, string string_8)
		{
			method_192();
			if (string.IsNullOrEmpty(string_8) || XTextDocument.smethod_8(this, GEnum6.const_46, string_8))
			{
				DocumentPrinter documentPrinter = new DocumentPrinter(Document);
				documentPrinter.Options.JumpPrint = JumpPrint;
				documentPrinter.Options.PrintRange = PrintRange.AllPages;
				documentPrinter.Options.BoundsSelection = BoundsSelection;
				documentPrinter.CurrentPage = CurrentPage;
				if (!string.IsNullOrEmpty(string_8))
				{
					documentPrinter.Options.SetSpecifyPageIndexsByString(string_8);
				}
				if (JumpPrint != null && JumpPrint.HasValidateInfo)
				{
					documentPrinter.Options.DisableRefreshDocumentLayout = true;
				}
				if (BoundsSelection != null && BoundsSelection.HasValidateInfo)
				{
					documentPrinter.Options.DisableRefreshDocumentLayout = true;
				}
				LastPrintResult = documentPrinter.PrintDocument(bool_47);
				method_187();
			}
		}

		public void method_60()
		{
			method_59(bool_47: true, null);
		}

		public void method_61()
		{
			method_192();
			DocumentPrinter documentPrinter = new DocumentPrinter(Document);
			documentPrinter.Options.JumpPrint = jumpPrintInfo_0;
			documentPrinter.Options.BoundsSelection = BoundsSelection;
			documentPrinter.CurrentPage = CurrentPage;
			documentPrinter.Options.PrintRange = PrintRange.CurrentPage;
			LastPrintResult = documentPrinter.PrintDocument(Prompt: true);
			method_187();
		}

		internal void method_62(float float_2, bool bool_47, bool bool_48, bool bool_49)
		{
			if (bool_47)
			{
				ExtViewMode = WriterControlExtViewMode.OffsetJumpPrint;
			}
			else
			{
				ExtViewMode = WriterControlExtViewMode.JumpPrint;
			}
			if (bool_48)
			{
				JumpPrintEndPosition = float_2;
			}
			else
			{
				JumpPrintPosition = float_2;
			}
			if (bool_49)
			{
				int int_ = 0;
				if (!bool_47)
				{
					int_ = ((!bool_48) ? JumpPrint.PageIndex : JumpPrint.EndPageIndex);
				}
				MoveToPage(int_);
			}
		}

		public bool method_63(XTextElement xtextElement_1, bool bool_47, bool bool_48)
		{
			if (xtextElement_1.DocumentContentElement != Document.Body)
			{
				return false;
			}
			float num = 0f;
			if (xtextElement_1 is XTextTableCellElement || xtextElement_1 is XTextTableRowElement || xtextElement_1 is XTextTableElement || xtextElement_1 is XTextSectionElement)
			{
				num = ((!bool_48) ? (xtextElement_1.AbsTop + xtextElement_1.Height + 1f) : xtextElement_1.AbsTop);
			}
			else
			{
				XTextElement xTextElement = xtextElement_1.FirstContentElement;
				if (xtextElement_1 is XTextParagraphFlagElement)
				{
					xTextElement = xtextElement_1;
				}
				XTextLine ownerLine = xTextElement.OwnerLine;
				num = ((ownerLine == null) ? ((!bool_48) ? (xTextElement.AbsTop + xTextElement.Height + 1f) : xTextElement.AbsTop) : ((!bool_48) ? (ownerLine.AbsTop + ownerLine.Height + 1f) : ownerLine.AbsTop));
			}
			EnableJumpPrint = true;
			JumpPrintPosition = num;
			if (bool_47)
			{
				int num2 = JumpPrint.PageIndex;
				if (JumpPrint.Position < 300f && num2 > 0)
				{
					num2--;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (base.StartPageIndex != num2)
				{
					base.StartPageIndex = num2;
					UpdatePages();
				}
				else
				{
					Invalidate();
				}
			}
			else
			{
				Invalidate();
			}
			return true;
		}

		public bool method_64(XTextElement xtextElement_1, bool bool_47, bool bool_48)
		{
			int num = 1;
			if (xtextElement_1 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextElement_1.DocumentContentElement != Document.Body)
			{
				return false;
			}
			float num2 = 0f;
			if (xtextElement_1 is XTextTableCellElement || xtextElement_1 is XTextTableRowElement || xtextElement_1 is XTextTableElement || xtextElement_1 is XTextSectionElement)
			{
				num2 = ((!bool_48) ? (xtextElement_1.AbsTop + xtextElement_1.Height + 1f) : xtextElement_1.AbsTop);
			}
			else
			{
				XTextElement xTextElement = xtextElement_1.FirstContentElement;
				if (xtextElement_1 is XTextParagraphFlagElement)
				{
					xTextElement = xtextElement_1;
				}
				XTextLine ownerLine = xTextElement.OwnerLine;
				num2 = ((ownerLine == null) ? ((!bool_48) ? (xTextElement.AbsTop + xTextElement.Height + 1f) : xTextElement.AbsTop) : ((!bool_48) ? (ownerLine.AbsTop + ownerLine.Height + 1f) : ownerLine.AbsTop));
			}
			EnableJumpPrint = true;
			JumpPrintEndPosition = num2;
			if (bool_47)
			{
				int num3 = JumpPrint.PageIndex;
				if (JumpPrint.Position < 300f)
				{
					num3--;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (base.EndPageIndex != num3)
				{
					base.EndPageIndex = num3;
					UpdatePages();
				}
				else
				{
					Invalidate();
				}
			}
			else
			{
				Invalidate();
			}
			return true;
		}

		[ComVisible(true)]
		public string method_65()
		{
			int num = 10;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (WriterCommand allCommand in CommandControler.CommandContainer.AllCommands)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(allCommand.Name);
			}
			return stringBuilder.ToString();
		}

		[ComVisible(true)]
		public bool method_66(string string_8)
		{
			return CommandControler.IsCommandSupported(string_8);
		}

		[ComVisible(true)]
		public bool method_67(string string_8)
		{
			if (base.IsHandleCreated)
			{
				return CommandControler.IsCommandEnabled(string_8);
			}
			return false;
		}

		public bool method_68(string string_8)
		{
			if (base.IsHandleCreated)
			{
				return CommandControler.IsCommandChecked(string_8);
			}
			return false;
		}

		[ComVisible(true)]
		public bool method_69(string string_8, bool bool_47)
		{
			WriterCommand command = CommandControler.GetCommand(string_8);
			if (command != null)
			{
				command.Enable = bool_47;
				return true;
			}
			return false;
		}

		[ComVisible(true)]
		public bool method_70(string string_8, bool bool_47)
		{
			WriterCommand command = CommandControler.GetCommand(string_8);
			if (command != null)
			{
				command.EnableHotKey = bool_47;
				return true;
			}
			return false;
		}

		public object method_71(string string_8)
		{
			int num = 3;
			if (!base.IsHandleCreated)
			{
				return null;
			}
			if (string.IsNullOrEmpty(string_8))
			{
				return null;
			}
			method_185();
			string_8 = string_8.Trim();
			GClass361 gClass = new GClass361(string_8);
			string text = gClass.method_3(',');
			if (text != null)
			{
				text = text.Trim();
			}
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			gClass.method_1();
			string text2 = gClass.method_3(',');
			bool bool_ = true;
			if (text2 != null)
			{
				text2 = text2.Trim();
				if (text2 == "0" || string.Compare(text2, "false", ignoreCase: true) == 0)
				{
					bool_ = false;
				}
			}
			gClass.method_1();
			string text3 = gClass.method_2();
			if (text3 != null)
			{
				text3 = text3.Trim();
				if (text3.Length > 1)
				{
					if (text3[0] == '\'' && text3[text3.Length - 1] == '\'')
					{
						text3 = text3.Substring(1, text3.Length - 1);
					}
					else if (text3[0] == '"' && text3[text3.Length - 1] == '"')
					{
						text3 = text3.Substring(1, text3.Length - 1);
					}
				}
			}
			return method_72(text, bool_, text3);
		}

		public object method_72(string string_8, bool bool_47, object object_1)
		{
			method_192();
			method_185();
			if (string_8 == "InnerTest33")
			{
				bool_23 = true;
				Invalidate();
				return null;
			}
			object result = CommandControler.InnerExecuteCommand(string_8, bool_47, object_1);
			DocumentControler.method_25();
			return result;
		}

		public object method_73(string string_8, WriterCommandEventArgs writerCommandEventArgs_0)
		{
			method_192();
			method_185();
			object result = CommandControler.method_2(string_8, writerCommandEventArgs_0.ShowUI, writerCommandEventArgs_0.Parameter, writerCommandEventArgs_0.RaiseFromUI);
			DocumentControler.method_25();
			return result;
		}

		public object method_74(string string_8, bool bool_47, object object_1, bool bool_48)
		{
			method_192();
			method_185();
			object result = CommandControler.method_2(string_8, bool_47, object_1, bool_48);
			DocumentControler.method_25();
			return result;
		}

		internal Dictionary<string, object> method_75(string string_8)
		{
			int num = 18;
			if (base.IsDisposed)
			{
				throw new InvalidOperationException("control disposed");
			}
			if (string.IsNullOrEmpty(string_8))
			{
				return null;
			}
			string_8 = string_8.Trim().ToLower();
			if (dictionary_0.ContainsKey(string_8))
			{
				return dictionary_0[string_8];
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary_0[string_8] = dictionary;
			return dictionary;
		}

		[ComVisible(true)]
		public bool method_76(string string_8)
		{
			int num = 16;
			if (string.IsNullOrEmpty(string_8))
			{
				throw new ArgumentNullException("id");
			}
			XTextContainerElement xTextContainerElement = method_247(string_8) as XTextContainerElement;
			if (xTextContainerElement != null)
			{
				return method_77(xTextContainerElement);
			}
			return false;
		}

		[ComVisible(true)]
		public bool method_77(XTextContainerElement xtextContainerElement_0)
		{
			int num = 12;
			if (xtextContainerElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextContainerElement_0.CommitUserTrace())
			{
				xtextContainerElement_0.EditorRefreshView();
				Document.Modified = true;
				OwnerWriterControl.OnDocumentContentChanged(null);
				OwnerWriterControl.OnSelectionChanged(null);
				return true;
			}
			return false;
		}

		[ComVisible(true)]
		public bool method_78()
		{
			if (Document.CommitUserTrace())
			{
				Document.Modified = true;
				method_188(bool_47: false, bool_48: true);
				OwnerWriterControl.OnDocumentContentChanged(null);
				OwnerWriterControl.OnSelectionChanged(null);
			}
			return true;
		}

		[ComVisible(true)]
		public bool method_79(UserTrackInfo userTrackInfo_0)
		{
			if (userTrackInfo_0 == null || userTrackInfo_0.Elements == null || userTrackInfo_0.Elements.Count == 0)
			{
				return false;
			}
			XTextElement firstContentElement = userTrackInfo_0.Elements[0].FirstContentElement;
			if (Document.CurrentContentElement != firstContentElement.DocumentContentElement)
			{
				Document.CurrentContentElement = firstContentElement.DocumentContentElement;
				Invalidate();
			}
			if (firstContentElement.ViewIndex >= 0)
			{
				Document.Content.MoveToPosition(firstContentElement.ViewIndex);
				method_196();
			}
			Focus();
			UpdateTextCaret();
			return true;
		}

		[Obsolete("请调用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		public bool method_80()
		{
			CurrentUserInfo currentUserInfo = (CurrentUserInfo)AppHost.Services.GetService(typeof(CurrentUserInfo));
			if (currentUserInfo != null)
			{
				UserLoginInfo userLoginInfo = new UserLoginInfo();
				userLoginInfo.ID = currentUserInfo.ID;
				userLoginInfo.Name = currentUserInfo.Name;
				userLoginInfo.PermissionLevel = currentUserInfo.PermissionLevel;
				userLoginInfo.ClientName = currentUserInfo.ClientName;
				return method_82(userLoginInfo, bool_47: true);
			}
			return false;
		}

		public bool method_81(string string_8, string string_9, int int_15)
		{
			UserLoginInfo userLoginInfo = new UserLoginInfo();
			userLoginInfo.ID = string_8;
			userLoginInfo.Name = string_9;
			userLoginInfo.PermissionLevel = int_15;
			return method_82(userLoginInfo, bool_47: true);
		}

		public bool method_82(UserLoginInfo userLoginInfo_1, bool bool_47)
		{
			int num = 0;
			if (userLoginInfo_1 == null)
			{
				throw new ArgumentNullException("loginInfo");
			}
			if (Document.UserHistories.CurrentInfo != null && Document.UserHistories.CurrentInfo.IsEmptySaveTime)
			{
				Document.UserHistories.CurrentInfo.SavedTime = Document.GetNowDateTime();
			}
			if (DocumentOptions.SecurityOptions.AutoEnablePermissionWhenUserLogin)
			{
				DocumentOptions.SecurityOptions.EnablePermission = true;
				DocumentOptions.SecurityOptions.EnableLogicDelete = true;
				DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
				DocumentOptions.SecurityOptions.ShowPermissionMark = true;
				DocumentOptions.SecurityOptions.ShowPermissionTip = true;
			}
			UserHistoryInfo item = new UserHistoryInfo(userLoginInfo_1);
			Document.UserHistories.Add(item);
			Document.UserHistories._CanCompressLastItem = false;
			if (Document.UndoList != null)
			{
				Document.UndoList.vmethod_4();
				Document.UndoList.Clear();
			}
			if (bool_47)
			{
				method_187();
			}
			else
			{
				Document.OnSelectionChanged();
			}
			return true;
		}

		[ComVisible(true)]
		[Obsolete("请调用控件的UserLogin()/UserLoginByUserLoginInfo()/UserLoginByParameter()")]
		public bool method_83()
		{
			return method_80();
		}

		[ComVisible(true)]
		public bool method_84(UserLoginInfo userLoginInfo_1, bool bool_47)
		{
			return method_82(userLoginInfo_1, bool_47);
		}

		[ComVisible(true)]
		public bool method_85(string string_8, string string_9, int int_15)
		{
			return method_81(string_8, string_9, int_15);
		}

		internal void method_86()
		{
			if (!AutoUserLogin)
			{
				return;
			}
			UserLoginInfo autoUserLoginInfo = AutoUserLoginInfo;
			if (autoUserLoginInfo != null && !string.IsNullOrEmpty(autoUserLoginInfo.Name))
			{
				method_82(autoUserLoginInfo, bool_47: true);
				return;
			}
			CurrentUserInfo currentUserInfo = (CurrentUserInfo)AppHost.Services.GetService(typeof(CurrentUserInfo));
			if (currentUserInfo != null)
			{
				UserLoginInfo userLoginInfo = new UserLoginInfo();
				userLoginInfo.ID = currentUserInfo.ID;
				userLoginInfo.Name = currentUserInfo.Name;
				userLoginInfo.PermissionLevel = currentUserInfo.PermissionLevel;
				userLoginInfo.ClientName = currentUserInfo.ClientName;
				method_82(userLoginInfo, bool_47: true);
			}
		}

		public void method_87()
		{
			Document.UpdateUserInfoSaveTime(addNewHistoryInfo: true);
		}

		public void method_88(bool bool_47)
		{
			Document.UpdateUserInfoSaveTime(bool_47);
		}

		[ComVisible(true)]
		public XTextDocument method_89()
		{
			IDataObject dataObject = method_91(bool_47: false);
			if (dataObject == null)
			{
				return null;
			}
			return DocumentControler.vmethod_3(dataObject);
		}

		private bool method_90()
		{
			IDataObject dataObject = RuntimeClipboard.GetDataObject(OwnerWriterControl);
			if (dataObject != null)
			{
				CanInsertObjectEventArgs canInsertObjectEventArgs = new CanInsertObjectEventArgs(Document);
				canInsertObjectEventArgs.DataObject = dataObject;
				OwnerWriterControl.OnEventCanInsertObject(canInsertObjectEventArgs);
				return canInsertObjectEventArgs.Result;
			}
			return false;
		}

		public IDataObject method_91(bool bool_47)
		{
			IDataObject dataObject = RuntimeClipboard.GetDataObject(OwnerWriterControl);
			if (dataObject != null && dataObject.GetFormats().Length > 0)
			{
				method_92();
			}
			WriterDataObjectRange writerDataObjectRange = DocumentOptions.BehaviorOptions.DataObjectRange;
			switch (writerDataObjectRange)
			{
			case WriterDataObjectRange.OS:
				if (!XTextDocument.smethod_13(GEnum6.const_142))
				{
					writerDataObjectRange = WriterDataObjectRange.Application;
				}
				break;
			case WriterDataObjectRange.Application:
				if (!XTextDocument.smethod_13(GEnum6.const_143))
				{
					writerDataObjectRange = WriterDataObjectRange.OS;
				}
				break;
			case WriterDataObjectRange.SingleWriterControl:
				if (!XTextDocument.smethod_13(GEnum6.const_144))
				{
					writerDataObjectRange = WriterDataObjectRange.OS;
				}
				break;
			}
			switch (writerDataObjectRange)
			{
			case WriterDataObjectRange.Application:
				if (idataObject_1 != null)
				{
					return idataObject_1;
				}
				if (idataObject_0 != null)
				{
					return idataObject_0;
				}
				if (bool_47 && method_90())
				{
					AppHost.UITools.ShowWarringMessageBox(this, WriterStringsCore.PromptDisableOSClipboardData);
				}
				return null;
			case WriterDataObjectRange.SingleWriterControl:
				if (idataObject_1 != null)
				{
					return idataObject_1;
				}
				if (bool_47 && method_90())
				{
					AppHost.UITools.ShowWarringMessageBox(this, WriterStringsCore.PromptDisableOSClipboardData);
				}
				return null;
			default:
				if (idataObject_1 != null)
				{
					return idataObject_1;
				}
				if (idataObject_0 != null)
				{
					return idataObject_0;
				}
				return RuntimeClipboard.GetDataObject(OwnerWriterControl);
			}
		}

		public void method_92()
		{
			idataObject_1 = null;
			idataObject_0 = null;
		}

		internal void method_93(IDataObject idataObject_2)
		{
			switch (DocumentOptions.BehaviorOptions.DataObjectRange)
			{
			case WriterDataObjectRange.Application:
				idataObject_1 = null;
				idataObject_0 = idataObject_2;
				Clipboard.Clear();
				break;
			case WriterDataObjectRange.SingleWriterControl:
				idataObject_1 = idataObject_2;
				Clipboard.Clear();
				break;
			default:
				idataObject_0 = null;
				idataObject_1 = null;
				RuntimeClipboard.Clear();
				RuntimeClipboard.SaveData(idataObject_2, DocumentOptions.BehaviorOptions.PreserveClipbardDataWhenExit);
				break;
			}
		}

		public void method_94(string string_8)
		{
			if (string.IsNullOrEmpty(string_8))
			{
				gclass96_0 = null;
				return;
			}
			gclass96_0 = new GClass96();
			gclass96_0.method_6(string_8);
		}

		public void method_95(bool bool_47)
		{
			if (!ShowTooltip)
			{
				return;
			}
			int_8++;
			ToolTips.method_5(int_8);
			GClass96 gClass = null;
			for (XTextElement xTextElement = HoverElement; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				gClass = ToolTips.method_0(xTextElement);
				if (gClass != null)
				{
					break;
				}
			}
			if (gClass == null)
			{
				for (XTextElement xTextElement = HoverElement; xTextElement != null; xTextElement = xTextElement.Parent)
				{
					gClass = xTextElement.GetToolTipInfo();
					if (gClass != null)
					{
						break;
					}
				}
			}
			if (gclass96_0 != null)
			{
				gClass = gclass96_0;
			}
			GClass96 gClass2 = TooltipControl.Tag as GClass96;
			if (gClass == null)
			{
				TooltipControl.SetToolTip(this, null);
				TooltipControl.Tag = null;
				return;
			}
			if (gClass.method_0(gClass2))
			{
				if (bool_47)
				{
					return;
				}
			}
			else
			{
				TooltipControl.RemoveAll();
				TooltipControl.Tag = null;
			}
			if (gClass.method_7() == GEnum4.const_0)
			{
				if (gClass.method_9() == GEnum5.const_0)
				{
					TooltipControl.ToolTipIcon = ToolTipIcon.Info;
				}
				else if (gClass.method_9() == GEnum5.const_1)
				{
					TooltipControl.ToolTipIcon = ToolTipIcon.Warning;
				}
				else if (gClass.method_9() == GEnum5.const_2)
				{
					TooltipControl.ToolTipIcon = ToolTipIcon.Error;
				}
				if (!gClass.method_13())
				{
				}
				if (string.IsNullOrEmpty(gClass.method_3()))
				{
					if (string.IsNullOrEmpty(DocumentOptions.BehaviorOptions.TitleForToolTip))
					{
						TooltipControl.ToolTipTitle = WriterStringsCore.TipTitle;
					}
					else
					{
						TooltipControl.ToolTipTitle = DocumentOptions.BehaviorOptions.TitleForToolTip;
					}
				}
				else
				{
					TooltipControl.ToolTipTitle = gClass.method_3();
				}
				if (EditorHost != null && EditorHost.ShowingDropDown)
				{
					TooltipControl.Tag = null;
					TooltipControl.SetToolTip(this, null);
				}
				else
				{
					TooltipControl.Tag = gClass;
					if (TooltipControl.GetToolTip(this) != gClass.method_5())
					{
						TooltipControl.SetToolTip(this, gClass.method_5());
					}
				}
			}
			ToolTips.method_5(int_8);
		}

		internal void method_96()
		{
			TooltipControl.Tag = null;
			TooltipControl.SetToolTip(this, null);
		}

		[ComVisible(true)]
		internal void method_97(XTextElementList xtextElementList_0, bool bool_47)
		{
			List<RectangleF> list = new List<RectangleF>();
			foreach (XTextElement item in xtextElementList_0)
			{
				if (item.RuntimeVisible)
				{
					RectangleF absBounds = item.AbsBounds;
					if (absBounds.Width > 0f && absBounds.Height > 0f)
					{
						list.Add(item.AbsBounds);
					}
				}
			}
			RectangleF[] array = RectangleCommon.CompressRectangles(list.ToArray());
			if (array.Length == 0)
			{
				return;
			}
			RectangleF a = RectangleF.Empty;
			RectangleF[] array2 = array;
			foreach (RectangleF absBounds in array2)
			{
				a = ((!a.IsEmpty) ? RectangleF.Union(a, absBounds) : absBounds);
			}
			if (bool_47)
			{
				method_29(new Rectangle((int)a.Left, (int)a.Top, (int)a.Width, (int)a.Height), ScrollToViewStyle.Normal);
			}
			for (int j = 0; j < 4; j++)
			{
				array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RectangleF absBounds = array2[i];
					method_23((int)absBounds.Left, (int)absBounds.Top, (int)absBounds.Width, (int)absBounds.Height);
				}
				Thread.Sleep(100);
			}
		}

		/// <summary>
		///       处理绘制用户界面事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnPaint(PaintEventArgs pevent)
		{
			int num = 7;
			if (base.IsHandleCreated && !GClass354.smethod_0(GetType()))
			{
				try
				{
					float tickCountFloat = CountDown.GetTickCountFloat();
					RectangleF layoutRectangle;
					if (InDesignMode)
					{
						layoutRectangle = new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height);
						using (StringFormat stringFormat = new StringFormat())
						{
							stringFormat.Alignment = StringAlignment.Center;
							stringFormat.LineAlignment = StringAlignment.Center;
							string text = null;
							try
							{
								text = base.ProductVersion;
							}
							catch (Exception ex)
							{
								Debug.WriteLine(ex.ToString());
							}
							Control control = OwnerWriterControl;
							if (control == null)
							{
								control = this;
							}
							string text2 = control.Name + Environment.NewLine + control.GetType().FullName + Environment.NewLine + WriterStringsCore.CoreVersion + ":" + CoreVersion + Environment.NewLine + WriterStringsCore.Version + ":" + text;
							try
							{
								text2 = text2 + Environment.NewLine + method_103();
							}
							catch (Exception ex)
							{
								text2 = text2 + Environment.NewLine + ex.Message;
							}
							try
							{
								text2 = text2 + Environment.NewLine + WriterStringsCore.FileName + ":" + GetType().Assembly.CodeBase;
							}
							catch (Exception ex)
							{
								text2 = text2 + Environment.NewLine + ex.Message;
							}
							pevent.Graphics.DrawString(text2, Font, Brushes.Red, layoutRectangle, stringFormat);
						}
						goto IL_077a;
					}
					if (base.IsFreezeUI)
					{
						method_0(pevent);
					}
					else if (!base.IsUpdating && !GClass445.smethod_10(this, pevent))
					{
						method_107(pevent);
						base.PageMarginLineLength = DocumentOptions.ViewOptions.PageMarginLineLength;
						if (xtextDocument_0 == null)
						{
							layoutRectangle = new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height);
							using (StringFormat stringFormat = new StringFormat())
							{
								stringFormat.Alignment = StringAlignment.Center;
								stringFormat.LineAlignment = StringAlignment.Center;
								pevent.Graphics.DrawString(WriterStringsCore.NoDocument, Font, Brushes.Red, layoutRectangle, stringFormat);
							}
						}
						else
						{
							Document.States.RenderMode = DocumentRenderMode.Paint;
							if (base.ReadViewMode)
							{
								Document.States.RenderMode = DocumentRenderMode.ReadPaint;
							}
							base.PageContentBorderStyle = Document.PageSettings.RuntimePageBorderBackground;
							HeaderFooterFlagVisible = HeaderFooterFlagVisible.None;
							if (DrawerUtil.IsHeaderFooter(Document.CurrentContentPartyStyle))
							{
								HeaderFooterFlagVisible = HeaderFooterFlagVisible.HeaderFooter;
							}
							list_0 = new List<Rectangle>();
							float tickCountFloat2 = CountDown.GetTickCountFloat();
							bool bool_;
							if (!(bool_ = (Document.Body.method_75(DocumentRenderMode.Paint) && RuntimeViewMode == PageViewMode.Page)))
							{
								DocumentTerminalTextInfo runtimeTerminalText = PageSettings.RuntimeTerminalText;
								if (runtimeTerminalText != null && (!string.IsNullOrEmpty(runtimeTerminalText.Text) || !string.IsNullOrEmpty(runtimeTerminalText.TextInMiddlePage)))
								{
									bool_ = true;
								}
							}
							method_52(pevent, bool_);
							tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
							if (list_0 != null && list_0.Count > 0)
							{
								DocumentViewOptions viewOptions = Document.Options.ViewOptions;
								if (viewOptions.SelectionHighlight == SelectionHighlightStyle.Invert)
								{
									IntPtr hdc = pevent.Graphics.GetHdc();
									using (GClass249 gClass2 = GClass249.smethod_1(hdc))
									{
										foreach (SimpleRectangleTransform item in base.PagesTransform)
										{
											if (item.method_2() && item.method_0() == Document.CurrentContentPartyStyle)
											{
												foreach (Rectangle item2 in list_0)
												{
													Rectangle rectangle_ = Rectangle.Intersect(item2, item.method_27());
													if (!rectangle_.IsEmpty)
													{
														rectangle_ = item.vmethod_21(rectangle_);
														Rectangle rectangle_2 = Rectangle.Intersect(rectangle_, pevent.ClipRectangle);
														if (!rectangle_2.IsEmpty)
														{
															gClass2.method_19(rectangle_2);
														}
													}
												}
											}
										}
									}
									pevent.Graphics.ReleaseHdc(hdc);
								}
								else if (viewOptions.SelectionHighlight == SelectionHighlightStyle.MaskColor)
								{
									using (SolidBrush brush = new SolidBrush(viewOptions.SelectionHightlightMaskColor))
									{
										foreach (SimpleRectangleTransform item3 in base.PagesTransform)
										{
											if (item3.method_2() && item3.method_0() == Document.CurrentContentPartyStyle)
											{
												foreach (Rectangle item4 in list_0)
												{
													Rectangle rectangle_ = Rectangle.Intersect(item4, item3.method_27());
													if (!rectangle_.IsEmpty)
													{
														rectangle_ = item3.vmethod_21(rectangle_);
														Rectangle rectangle_2 = Rectangle.Intersect(rectangle_, pevent.ClipRectangle);
														if (!rectangle_2.IsEmpty)
														{
															pevent.Graphics.FillRectangle(brush, rectangle_2);
														}
													}
												}
											}
										}
									}
								}
							}
							list_0 = null;
							if (DragableElement != null && DragableElement.DocumentContentElement == Document.CurrentContentElement)
							{
								Rectangle dragableHandleBounds = DragableHandleBounds;
								if (!dragableHandleBounds.IsEmpty)
								{
									pevent.Graphics.DrawImage(DomImageList.GetBitmap(DCStdImageKey.DragHandle), dragableHandleBounds.Left, dragableHandleBounds.Top);
								}
							}
							method_258(pevent.Graphics, pevent.ClipRectangle);
							method_108(pevent);
							if (Document.Options.ViewOptions.ShowPageLine && Document.Pages.Count > 1)
							{
								method_51(pevent);
							}
							if (ExtViewMode != WriterControlExtViewMode.BoundsSelection && (ExtViewMode == WriterControlExtViewMode.JumpPrint || ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint))
							{
								method_50(pevent.Graphics, pevent.ClipRectangle, jumpPrintInfo_0, DocumentOptions.ViewOptions.MaskColorForJumpPrint);
							}
						}
						goto IL_077a;
					}
					goto end_IL_0024;
					IL_077a:
					try
					{
						method_102(pevent);
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
					}
					tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
					end_IL_0024:;
				}
				catch (Exception ex)
				{
					pevent.Graphics.ResetClip();
					pevent.Graphics.ResetTransform();
					pevent.Graphics.PageUnit = GraphicsUnit.Pixel;
					using (StringFormat stringFormat2 = new StringFormat())
					{
						stringFormat2.Alignment = StringAlignment.Near;
						stringFormat2.LineAlignment = StringAlignment.Near;
						pevent.Graphics.DrawString(ex.ToString(), Font, Brushes.Red, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat2);
					}
				}
			}
		}

		protected override void DrawPageFrame(PrintPage printPage_1, Graphics graphics_0, Rectangle rectangle_3, bool bool_47)
		{
			base.DrawPageFrame(printPage_1, graphics_0, rectangle_3, bool_47);
			GClass472 gClass = method_104();
			if (gClass == null)
			{
				return;
			}
			WatermarkInfo watermarkInfo = gClass.method_30();
			if (watermarkInfo != null)
			{
				GraphicsState gstate = graphics_0.Save();
				graphics_0.PageUnit = GraphicsUnit.Pixel;
				graphics_0.ResetTransform();
				Rectangle clientBounds = printPage_1.ClientBounds;
				clientBounds.Y += base.AutoScrollPosition.Y;
				if (clientBounds.IntersectsWith(rectangle_3))
				{
					watermarkInfo.method_4(clientBounds, new DCGraphics(graphics_0), rectangle_3);
				}
				graphics_0.Restore(gstate);
			}
		}

		protected override void vmethod_31(IPageDocument ipageDocument_0, PageDocumentPaintEventArgs pageDocumentPaintEventArgs_0, PaintEventArgs paintEventArgs_0)
		{
			if (ipageDocument_0 == null)
			{
				return;
			}
			if (pageDocumentPaintEventArgs_0.ViewMode == PageViewMode.Normal || pageDocumentPaintEventArgs_0.ViewMode == PageViewMode.NormalCenter)
			{
				GClass472 gClass = method_104();
				if (gClass != null)
				{
					WatermarkInfo watermarkInfo = gClass.method_30();
					if (watermarkInfo != null && base.Pages != null && base.Pages.Count > 0)
					{
						GraphicsState gstate = pageDocumentPaintEventArgs_0.Graphics.Save();
						pageDocumentPaintEventArgs_0.Graphics.PageUnit = GraphicsUnit.Pixel;
						pageDocumentPaintEventArgs_0.Graphics.ResetTransform();
						foreach (PrintPage page in base.Pages)
						{
							Rectangle clientBounds = page.ClientBounds;
							clientBounds.Y += base.AutoScrollPosition.Y;
							if (clientBounds.IntersectsWith(paintEventArgs_0.ClipRectangle))
							{
								watermarkInfo.method_4(clientBounds, new DCGraphics(pageDocumentPaintEventArgs_0.Graphics), paintEventArgs_0.ClipRectangle);
							}
						}
						pageDocumentPaintEventArgs_0.Graphics.Restore(gstate);
					}
				}
			}
			base.vmethod_31(ipageDocument_0, pageDocumentPaintEventArgs_0, paintEventArgs_0);
		}

		protected override void vmethod_30(PaintEventArgs paintEventArgs_0, SimpleRectangleTransform gclass435_2)
		{
			if (ExtViewMode == WriterControlExtViewMode.BoundsSelection && (gclass435_2.method_0() == PageContentPartyStyle.Body || gclass435_2.method_0() == PageContentPartyStyle.HeaderRows))
			{
				Rectangle rect = Rectangle.Intersect(paintEventArgs_0.ClipRectangle, gclass435_2.method_21());
				if (!rect.IsEmpty)
				{
					using (Region region = new Region(rect))
					{
						List<Rectangle> list = new List<Rectangle>();
						foreach (BoundsSelectionPrintInfoItem item in BoundsSelection)
						{
							if (item.PageIndex == gclass435_2.method_12())
							{
								RectangleF rectangleF_ = RectangleF.Intersect(item.ViewBounds, gclass435_2.method_25());
								if (!rectangleF_.IsEmpty)
								{
									RectangleF rectangleF = gclass435_2.vmethod_23(rectangleF_);
									Rectangle rectangle = new Rectangle((int)rectangleF.Left, (int)rectangleF.Top, (int)rectangleF.Width, (int)rectangleF.Height);
									list.Add(rectangle);
									rectangle = Rectangle.Intersect(rectangle, paintEventArgs_0.ClipRectangle);
									region.Exclude(rectangle);
								}
							}
						}
						using (SolidBrush brush = new SolidBrush(Color.FromArgb(140, base.PageBackColor)))
						{
							paintEventArgs_0.Graphics.FillRegion(brush, region);
						}
						if (list.Count > 0)
						{
							foreach (Rectangle item2 in list)
							{
								paintEventArgs_0.Graphics.DrawRectangle(Pens.Red, item2.Left, item2.Top, item2.Width - 1, item2.Height - 1);
							}
						}
					}
				}
			}
			else if (!gclass435_2.method_2() && gclass435_2.method_4() && DocumentOptions.ViewOptions.ShowGrayMaskOverDisableContentParty)
			{
				XTextDocumentContentElement xTextDocumentContentElement = null;
				if (gclass435_2.method_0() == PageContentPartyStyle.Header)
				{
					xTextDocumentContentElement = ((XTextDocument)gclass435_2.method_10()).Header;
				}
				else if (gclass435_2.method_0() == PageContentPartyStyle.Footer)
				{
					xTextDocumentContentElement = ((XTextDocument)gclass435_2.method_10()).Footer;
				}
				if (gclass435_2.method_0() == PageContentPartyStyle.HeaderForFirstPage)
				{
					xTextDocumentContentElement = ((XTextDocument)gclass435_2.method_10()).HeaderForFirstPage;
				}
				else if (gclass435_2.method_0() == PageContentPartyStyle.FooterForFirstPage)
				{
					xTextDocumentContentElement = ((XTextDocument)gclass435_2.method_10()).FooterForFirstPage;
				}
				if (xTextDocumentContentElement?.HasContentElement ?? true)
				{
					using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(140, base.PageBackColor)))
					{
						Rectangle current2 = gclass435_2.method_21();
						paintEventArgs_0.Graphics.FillRectangle(brush2, current2.Left, current2.Top, current2.Width + 2, current2.Height + 2);
					}
				}
			}
		}

		public void method_98(Rectangle rectangle_3)
		{
			if (list_0 == null)
			{
				return;
			}
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				Rectangle rectangle = list_0[num];
				if (rectangle.Contains(rectangle_3))
				{
					return;
				}
				Rectangle rectangle2 = Rectangle.Intersect(rectangle, rectangle_3);
				if (!rectangle2.IsEmpty)
				{
					if (rectangle2.Equals(rectangle))
					{
						list_0.RemoveAt(num);
					}
					else
					{
						if (rectangle2.Equals(rectangle_3))
						{
							return;
						}
						if (rectangle2.Top == rectangle.Top && rectangle2.Height == rectangle.Height)
						{
							if (rectangle2.Left == rectangle.Left)
							{
								rectangle.Width = rectangle.Right - rectangle2.Right;
								rectangle.X = rectangle2.Right;
								list_0[num] = rectangle;
							}
							else if (rectangle2.Right == rectangle.Right)
							{
								rectangle.Width = rectangle2.Left - rectangle.Left;
								list_0[num] = rectangle;
							}
						}
						else if (rectangle2.Left == rectangle.Left && rectangle2.Width == rectangle.Width)
						{
							if (rectangle2.Top == rectangle.Top)
							{
								rectangle.Height = rectangle.Bottom - rectangle2.Bottom;
								rectangle.Y = rectangle2.Bottom;
								list_0[num] = rectangle;
							}
							else if (rectangle2.Bottom == rectangle.Bottom)
							{
								rectangle.Height = rectangle2.Top - rectangle.Top;
								list_0[num] = rectangle;
							}
						}
						else if (rectangle2.Top == rectangle_3.Top && rectangle2.Height == rectangle_3.Height)
						{
							if (rectangle2.Left == rectangle_3.Left)
							{
								rectangle_3.Width = rectangle_3.Right - rectangle2.Right;
								rectangle_3.X = rectangle2.Right;
							}
							else if (rectangle2.Right == rectangle_3.Right)
							{
								rectangle_3.Width = rectangle2.Left - rectangle_3.Left;
							}
						}
						else if (rectangle2.Left == rectangle_3.Left && rectangle2.Width == rectangle_3.Width)
						{
							if (rectangle2.Top == rectangle_3.Top)
							{
								rectangle_3.Height = rectangle_3.Bottom - rectangle2.Bottom;
								rectangle_3.Y = rectangle2.Bottom;
							}
							else if (rectangle2.Bottom == rectangle_3.Bottom)
							{
								rectangle_3.Height = rectangle2.Top - rectangle_3.Top;
							}
						}
					}
				}
			}
			if (!rectangle_3.IsEmpty)
			{
				list_0.Add(rectangle_3);
			}
		}

		public void method_99(XTextLine xtextLine_0, PageContentPartyStyle pageContentPartyStyle_0)
		{
			int num = 18;
			if (xtextLine_0 == null)
			{
				throw new ArgumentNullException("line");
			}
			RectangleF rectangleF = xtextLine_0.AbsBounds;
			rectangleF.Width = xtextLine_0.ViewWidth;
			AdornTextManager adornTextMan = Document.AdornTextMan;
			foreach (XTextElement item in xtextLine_0)
			{
				if (item is XTextObjectElement && (item.RuntimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings || item.RuntimeZOrderStyle != 0))
				{
					rectangleF = RectangleF.Union(rectangleF, item.AbsBounds);
				}
				if (adornTextMan != null)
				{
					RectangleF b = adornTextMan.method_4(item);
					if (!b.IsEmpty)
					{
						rectangleF = RectangleF.Union(rectangleF, b);
					}
				}
			}
			ViewInvalidate(rectangleF, pageContentPartyStyle_0);
		}

		public void ViewInvalidate(RectangleF rectangleF_0, PageContentPartyStyle pageContentPartyStyle_0)
		{
			if (!base.IsUpdating && !base.IsFreezeUI)
			{
				XTextDocument document = Document;
				if (document != null)
				{
					foreach (SimpleRectangleTransform item in base.PagesTransform)
					{
						if (item.method_0() == pageContentPartyStyle_0)
						{
							if ((pageContentPartyStyle_0 == PageContentPartyStyle.Body || pageContentPartyStyle_0 == PageContentPartyStyle.HeaderRows) && rectangleF_0.Top == item.method_25().Top)
							{
								_ = rectangleF_0.Bottom;
								rectangleF_0.Y += 1f;
								rectangleF_0.Height -= 1f;
							}
							RectangleF rectangleF = RectangleF.Intersect(rectangleF_0, item.method_25());
							if (rectangleF.Width > 2f && rectangleF.Height > 2f)
							{
								PointF pointF = item.vmethod_15(rectangleF.Location);
								RectangleF rectangleF2 = item.getSourceRectF();
								rectangleF2.Inflate(3f, 3f);
								if (rectangleF2.Contains(pointF))
								{
									RectangleF value = new RectangleF(pointF, item.vmethod_19(rectangleF_0.Size));
									if (value.Width > 0f && value.Height > 0f)
									{
										value.Offset(-2f, -2f);
										value.Width += 4f;
										value.Height += 4f;
										Rectangle rc = Rectangle.Ceiling(value);
										Invalidate(rc);
									}
								}
							}
						}
					}
				}
			}
		}

		public void method_101(XTextRange xtextRange_0)
		{
			if (xtextRange_0 != null)
			{
				foreach (XTextElement item in xtextRange_0)
				{
					Document.method_69(item);
				}
			}
		}

		private void method_102(PaintEventArgs paintEventArgs_0)
		{
			if (InDesignMode || Debugger.IsAttached)
			{
				Class103.smethod_4();
				if (!GClass143.smethod_13(4))
				{
					GClass138 gClass = GClass143.smethod_24(4);
					string s = string.Format(WriterStringsCore.PromptDevelopmentDog_Name, gClass.method_33());
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Center;
						stringFormat.LineAlignment = StringAlignment.Center;
						using (Font font = new Font(Font.Name, 25f))
						{
							using (SolidBrush brush = new SolidBrush(Color.FromArgb(90, 255, 0, 0)))
							{
								paintEventArgs_0.Graphics.DrawString(s, font, brush, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
							}
						}
					}
				}
			}
		}

		private string method_103()
		{
			int num = 8;
			string text = "";
			try
			{
				GClass138 gClass = Class103.smethod_4();
				if (gClass.method_34())
				{
					string str = string.Format(WriterStringsCore.RegisterTitle_UserName, gClass.method_33());
					text = text + Environment.NewLine + str;
				}
				else
				{
					text = text + Environment.NewLine + WriterStringsCore.PromptRegister;
				}
				GClass138 gClass2 = GClass143.smethod_24(4);
				text = text + Environment.NewLine + WriterStringsCore.Header + ":" + gClass2.method_50();
				text = text.Replace("[%pageindex%]", "0");
				text = text.Replace("[%pagecount%]", "0");
			}
			catch (Exception ex)
			{
				text = text + Environment.NewLine + ex.Message;
			}
			return text;
		}

		private GClass472 method_104()
		{
			return Class103.smethod_6(this);
		}

		/// <summary>
		///       检查授权状态，若为授权则显示对话框
		///       </summary>
		/// <param name="applicationID">应用编号</param>
		/// <param name="dlg">对话框</param>
		/// <param name="ctl">显示对话框的父控件</param>
		[DCInternal]
		internal static void CheckRegisteredWithDialog(int applicationID, Form form_0, Control control_0)
		{
			int num = 10;
			if (form_0 == null)
			{
				throw new ArgumentNullException("dlg");
			}
			if (!(XTextDocument.smethod_5(bool_32: false, applicationID)?.method_6() ?? false))
			{
				control_0.BeginInvoke(new Delegate9(smethod_0), form_0, control_0);
			}
		}

		private static void smethod_0(Form form_0, IWin32Window iwin32Window_0)
		{
			form_0.ShowDialog(iwin32Window_0);
		}

		private void method_105(GClass472 gclass472_0, PrintPage printPage_1)
		{
			string text = gclass472_0.method_8();
			string text2 = "[%pageindex%]";
			string text3 = "[%pagecount%]";
			if (text.IndexOf(text2) >= 0)
			{
				text = ((printPage_1 != null) ? text.Replace(text2, Convert.ToString(printPage_1.PageIndex + 1)) : text.Replace(text2, ""));
			}
			if (text.IndexOf(text3) >= 0)
			{
				text = ((printPage_1 != null) ? text.Replace(text3, base.Pages.Count.ToString()) : text.Replace(text3, ""));
			}
			gclass472_0.method_9(text);
			if (gclass472_0.method_6() && bool_23)
			{
				gclass472_0.method_17(Color.FromArgb(160, 160, 150));
			}
			gclass472_0.method_19(Color.White);
		}

		private int method_106()
		{
			if (OwnerWriterControl == null)
			{
				return 0;
			}
			string name = "_LicenceDisplayMode";
			FieldInfo field = OwnerWriterControl.GetType().GetField(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				return (int)field.GetValue(OwnerWriterControl);
			}
			return 0;
		}

		private bool method_107(PaintEventArgs paintEventArgs_0)
		{
			GClass472 gClass = method_104();
			if (gClass.method_6() && method_106() != 1)
			{
				return false;
			}
			if (RuntimeViewMode != PageViewMode.Page)
			{
				return false;
			}
			Rectangle rect = new Rectangle(base.AutoScrollPosition.X, base.AutoScrollPosition.Y, Math.Max(base.ClientSize.Width, base.AutoScrollMinSize.Width), PreserveSpacingInPageView - 1);
			if (paintEventArgs_0.ClipRectangle.IntersectsWith(rect))
			{
				paintEventArgs_0.Graphics.FillRectangle(SystemBrushes.Info, rect);
				paintEventArgs_0.Graphics.DrawRectangle(SystemPens.ControlDark, rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					string s = gClass.method_8();
					paintEventArgs_0.Graphics.DrawString(s, Control.DefaultFont, SystemBrushes.InfoText, new RectangleF(rect.Left + 10, rect.Top, rect.Width - 20, rect.Height), stringFormat);
				}
			}
			return true;
		}

		private void method_108(PaintEventArgs paintEventArgs_0)
		{
			GClass472 gClass = method_104();
			if (gClass.method_6())
			{
				try
				{
					if (!gClass.method_6() || method_106() == 0)
					{
						if ((RuntimeViewMode == PageViewMode.Normal || RuntimeViewMode == PageViewMode.NormalCenter || RuntimeViewMode == PageViewMode.AutoLine) && gClass.method_6())
						{
							method_105(gClass, null);
							if (gClass.method_20() == GEnum88.flag_1 || gClass.method_20() == GEnum88.flag_0 || gClass.method_20() == GEnum88.flag_2)
							{
							}
						}
						else
						{
							paintEventArgs_0.Graphics.PageUnit = GraphicsUnit.Pixel;
							paintEventArgs_0.Graphics.ResetTransform();
							paintEventArgs_0.Graphics.ResetClip();
							if (base.Pages != null && base.Pages.Count > 0)
							{
								Point autoScrollPosition = base.AutoScrollPosition;
								string text = gClass.method_8();
								foreach (PrintPage page in base.Pages)
								{
									Rectangle clientBounds = page.ClientBounds;
									clientBounds.Offset(autoScrollPosition.X, autoScrollPosition.Y);
									if (clientBounds.IntersectsWith(paintEventArgs_0.ClipRectangle))
									{
										gClass.method_9(text);
										method_105(gClass, page);
										if (gClass.method_22())
										{
											gClass.method_21(GEnum88.flag_0);
											gClass.method_28(paintEventArgs_0.Graphics, new RectangleF(clientBounds.Left, clientBounds.Top, clientBounds.Width, clientBounds.Height), bool_7: true);
											gClass.method_21(GEnum88.flag_3);
											gClass.method_28(paintEventArgs_0.Graphics, new RectangleF(clientBounds.Left, clientBounds.Top, clientBounds.Width, clientBounds.Height), bool_7: true);
										}
										else
										{
											gClass.method_28(paintEventArgs_0.Graphics, new RectangleF(clientBounds.Left, clientBounds.Top, clientBounds.Width, clientBounds.Height), bool_7: true);
										}
									}
								}
							}
						}
					}
				}
				finally
				{
					if (gClass.method_24())
					{
						XFontValue xFontValue = new XFontValue(XFontValue.DefaultFontName, 30f);
						int alpha = 120;
						string value = "南京都昌信息科技有限公司";
						int num = 1;
						if (gClass.method_8() == null || gClass.method_8().IndexOf(value) < 0)
						{
							alpha = 255;
							xFontValue.Size = 60f;
							num = 3;
						}
						using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, Color.Red)))
						{
							GraphicsState gstate = paintEventArgs_0.Graphics.Save();
							paintEventArgs_0.Graphics.Transform = new Matrix();
							Point autoScrollPosition = base.AutoScrollPosition;
							autoScrollPosition = GraphicsUnitConvert.Convert(autoScrollPosition, GraphicsUnit.Pixel, paintEventArgs_0.Graphics.PageUnit);
							float height = xFontValue.GetHeight(paintEventArgs_0.Graphics);
							for (int i = 0; i < num; i++)
							{
								paintEventArgs_0.Graphics.DrawString(WriterStringsCore.DCSoftTestVersion, xFontValue.Value, brush, 10 + autoScrollPosition.X, (float)(50 + autoScrollPosition.Y) + (float)i * height);
							}
							paintEventArgs_0.Graphics.Restore(gstate);
						}
					}
				}
			}
		}

		internal string method_109()
		{
			if (Document == null)
			{
				return "";
			}
			return Document.HtmlText;
		}

		internal void method_110(string string_8)
		{
			method_192();
			if (Document != null)
			{
				Document.HtmlText = string_8;
			}
			method_187();
			method_131();
			Invalidate();
		}

		[DCInternal]
		public void method_111()
		{
			method_163();
			ReleaseFreezeUI();
			method_11();
			printResult_0 = null;
			jumpPrintInfo_0 = null;
			BoundsSelection = null;
			dateTime_0 = DateTime.Now;
			gclass435_1 = null;
			documentNavigator_0 = null;
			list_0 = null;
			currentContentStyleInfo_0 = null;
			if (gclass97_0 != null)
			{
				gclass97_0.method_3();
			}
			enum10_0 = Enum10.const_0;
			userTrackInfoList_0 = null;
			base.CurrentTransformItem = null;
			if (class137_0 != null)
			{
				class137_0.method_3();
			}
			base.MouseDragScroll = false;
		}

		public bool method_112(string string_8, string string_9)
		{
			int num = 14;
			method_192();
			if (string.IsNullOrEmpty(string_8))
			{
				throw new ArgumentNullException("text");
			}
			string_8 = string_8.Trim();
			if (string_8.Length == 0)
			{
				return false;
			}
			StringReader textReader_ = new StringReader(string_8);
			return method_122(textReader_, string_9);
		}

		internal bool method_113(string string_8, string string_9)
		{
			byte[] byte_ = Convert.FromBase64String(string_8);
			return method_115(byte_, string_9);
		}

		internal bool method_114(string string_8, string string_9)
		{
			return method_118(string_8, string_9);
		}

		internal bool method_115(byte[] byte_0, string string_8)
		{
			MemoryStream stream_ = new MemoryStream(byte_0);
			return method_121(stream_, string_8);
		}

		internal GClass445 method_116(bool bool_47, string string_8, int int_15 = 400)
		{
			GClass445 gClass = GClass445.smethod_0(this, int_15);
			gClass.method_4(OwnerWriterControl.ShowWaittingUIForLoadingDocument);
			gClass.method_10(OwnerWriterControl.CustomLogoImage);
			if (OwnerWriterControl.CustomLogoImage != null && !XTextDocument.IsEnableCustomLogoImage)
			{
				gClass.method_10(null);
			}
			if (method_106() == 2)
			{
				int_9++;
				if (int_9 <= 3)
				{
					gClass.method_14(3500);
				}
			}
			gClass.Paint();
			if (bool_47)
			{
				method_117(gClass, string_8);
			}
			return gClass;
		}

		private void method_117(GClass445 gclass445_0, string string_8)
		{
			int num = 1;
			if (method_106() == 2 && gclass445_0.method_3())
			{
				GClass472 gClass = method_104();
				gclass445_0.method_6(bool_3: false);
				gclass445_0.method_12(xfontValue_0);
				gclass445_0.method_8(string.Format(WriterStringsCore.DCLicenseTo_Name, gClass.method_8()));
				gclass445_0.method_6(bool_3: true);
			}
			else
			{
				string specifyLoadFileNameOnce = SpecifyLoadFileNameOnce;
				if (string.IsNullOrEmpty(specifyLoadFileNameOnce))
				{
					if (string.IsNullOrEmpty(string_8))
					{
						gclass445_0.method_8(string.Format(WriterStringsCore.Loading_FileName, " "));
					}
					else
					{
						gclass445_0.method_8(string.Format(WriterStringsCore.Loading_FileName, string_8));
					}
				}
				else
				{
					gclass445_0.method_8(string.Format(WriterStringsCore.Loading_FileName, specifyLoadFileNameOnce));
				}
			}
			gclass445_0.Paint();
		}

		public bool method_118(string string_8, string string_9)
		{
			int num = 9;
			method_192();
			if (string.IsNullOrEmpty(string_8))
			{
				throw new ArgumentNullException("strUrl");
			}
			base.AutoScrollMinSize = new Size(0, 0);
			base.AutoScrollPosition = new Point(0, 0);
			OwnerWriterControl.method_5();
			using (method_116(bool_47: true, string_8))
			{
				try
				{
					Document.method_115();
					method_111();
					try
					{
						Document.EnableAfterLoad = false;
						Document.Load(string_8, string_9);
					}
					finally
					{
						Document.EnableAfterLoad = true;
					}
					method_119();
					OwnerWriterControl.vmethod_42(new WriterEventArgs(OwnerWriterControl, Document, null));
					method_187();
					if (DocumentOptions.BehaviorOptions.AutoDocumentValueValidate)
					{
						Document.ValueValidate();
					}
					Invalidate();
					OwnerWriterControl.OnDocumentLoad(new WriterEventArgs(OwnerWriterControl, Document, null));
					method_131();
				}
				finally
				{
					Document.method_116();
				}
				return true;
			}
		}

		private void method_119()
		{
			if (OwnerWriterControl.AllowApplyLocalDocumentOptions)
			{
				if (Document.SaveDocumentOptionsToFile && Document.DocumentOptionsToSaveFile != null)
				{
					DocumentOptions = Document.DocumentOptionsToSaveFile;
					Document.Options = Document.DocumentOptionsToSaveFile;
				}
			}
			else
			{
				Document.SaveDocumentOptionsToFile = false;
				Document.DocumentOptionsToSaveFile = null;
			}
		}

		public void method_120(string string_8)
		{
			if (string.IsNullOrEmpty(string_4))
			{
				string_4 = string_8;
			}
		}

		[ComVisible(false)]
		public bool method_121(Stream stream_0, string string_8)
		{
			int num = 14;
			method_192();
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			base.AutoScrollMinSize = new Size(0, 0);
			base.AutoScrollPosition = new Point(0, 0);
			OwnerWriterControl.method_5();
			using (method_116(bool_47: true, null))
			{
				try
				{
					Document.method_115();
					method_111();
					string fileName = Document.FileName;
					try
					{
						Document.EnableAfterLoad = false;
						Document.Load(stream_0, string_8);
					}
					finally
					{
						Document.EnableAfterLoad = true;
					}
					OwnerWriterControl.method_5();
					Document.FileName = fileName;
					method_119();
					if (!base.IsHandleCreated)
					{
						Document.FixDomState();
					}
					OwnerWriterControl.vmethod_42(new WriterEventArgs(OwnerWriterControl, Document, null));
					_ = CountDown.GetTickCountFloat() - tickCountFloat;
					tickCountFloat = CountDown.GetTickCountFloat();
					method_187();
					if (DocumentOptions.BehaviorOptions.AutoDocumentValueValidate)
					{
						Document.ValueValidate();
					}
					Document.Modified = false;
					Invalidate();
					OwnerWriterControl.OnDocumentLoad(new WriterEventArgs(OwnerWriterControl, Document, null));
					_ = CountDown.GetTickCountFloat() - tickCountFloat;
					method_131();
				}
				finally
				{
					Document.method_116();
				}
			}
			if (DocumentOptions.BehaviorOptions.AutoFocusWhenOpenDocument)
			{
				method_238();
			}
			return true;
		}

		[ComVisible(false)]
		public bool method_122(TextReader textReader_0, string string_8)
		{
			int num = 5;
			method_192();
			if (textReader_0 == null)
			{
				throw new ArgumentNullException("reader");
			}
			long tickCountExt = CountDown.GetTickCountExt();
			base.AutoScrollMinSize = new Size(0, 0);
			base.AutoScrollPosition = new Point(0, 0);
			OwnerWriterControl.method_5();
			using (method_116(bool_47: true, null))
			{
				try
				{
					Document.method_115();
					method_111();
					try
					{
						Document.EnableAfterLoad = false;
						Document.Load(textReader_0, string_8);
					}
					finally
					{
						Document.EnableAfterLoad = true;
					}
					OwnerWriterControl.method_5();
					method_119();
					if (!base.IsHandleCreated)
					{
						Document.FixDomState();
					}
					OwnerWriterControl.vmethod_42(new WriterEventArgs(OwnerWriterControl, Document, null));
					_ = CountDown.GetTickCountExt() - tickCountExt;
					method_187();
					if (DocumentOptions.BehaviorOptions.AutoDocumentValueValidate)
					{
						Document.ValueValidate();
					}
					Document.Modified = false;
					Invalidate();
					OwnerWriterControl.OnDocumentLoad(new WriterEventArgs(OwnerWriterControl, Document, null));
					_ = CountDown.GetTickCountExt() - tickCountExt;
					method_131();
				}
				finally
				{
					Document.method_116();
				}
			}
			if (DocumentOptions.BehaviorOptions.AutoFocusWhenOpenDocument)
			{
				method_238();
			}
			return true;
		}

		public bool method_123(string string_8, string string_9)
		{
			using (method_116(bool_47: false, null))
			{
				Document.Save(string_8, string_9);
				return true;
			}
		}

		public bool method_124(string string_8, string string_9)
		{
			return method_123(string_8, string_9);
		}

		public string method_125(string string_8)
		{
			using (method_116(bool_47: false, null))
			{
				return Document.SaveToString(string_8);
			}
		}

		public string method_126(string string_8)
		{
			using (method_116(bool_47: false, null))
			{
				return Document.SaveToBase64String(string_8);
			}
		}

		[ComVisible(false)]
		public bool method_127(Stream stream_0, string string_8)
		{
			using (method_116(bool_47: false, null))
			{
				Document.Save(stream_0, string_8);
				return true;
			}
		}

		public override IImmProvider vmethod_33()
		{
			return AppHost.Tools.CreateImmProvider(OwnerWriterControl);
		}

		internal void method_128()
		{
			if (WinFormUtils.GetApplicationStyle(this) != GEnum65.const_1)
			{
				if (list_1 == null)
				{
					list_1 = new List<WeakReference>();
					Application.Idle += smethod_1;
				}
				list_1.Add(new WeakReference(this));
				InputCharBuffer.method_2(bool_1: true);
			}
		}

		private static void smethod_1(object sender, EventArgs e)
		{
			smethod_2(null);
		}

		private static void smethod_2(WriterViewControl writerViewControl_0)
		{
			if (list_1 != null)
			{
				for (int num = list_1.Count - 1; num >= 0; num--)
				{
					WeakReference weakReference = list_1[num];
					try
					{
						if (weakReference.IsAlive)
						{
							WriterViewControl writerViewControl = (WriterViewControl)weakReference.Target;
							if (writerViewControl == writerViewControl_0)
							{
								list_1.RemoveAt(num);
							}
							else if (writerViewControl.IsDisposed)
							{
								list_1.RemoveAt(num);
							}
							else if (writerViewControl.IsHandleCreated)
							{
								writerViewControl.method_130(null, null);
							}
						}
					}
					catch (InvalidOperationException)
					{
						list_1.RemoveAt(num);
					}
				}
			}
		}

		internal void method_129()
		{
			smethod_2(this);
		}

		private void method_130(object sender, EventArgs e)
		{
			try
			{
				if (base.IsHandleCreated && !base.IsDisposed)
				{
					if (OwnerWriterControl != null)
					{
						OwnerWriterControl.method_47();
					}
					InputCharBuffer.method_4();
					if (writerCommandControler_0 != null)
					{
						writerCommandControler_0.UpdateInvalidatedCommandState();
					}
					if (class137_0 != null)
					{
						class137_0.method_4();
					}
					if (OwnerWriterControl != null)
					{
						OwnerWriterControl.vmethod_56(new WriterEventArgs(OwnerWriterControl, Document, Document));
					}
				}
			}
			catch (Exception ex)
			{
				if (DocumentOptions.BehaviorOptions.WeakMode)
				{
					MessageBox.Show(ex.ToString());
				}
				else if (DocumentOptions.BehaviorOptions.DebugMode)
				{
					Debug.WriteLine(ex.ToString());
				}
				else
				{
					Debug.WriteLine(ex.Message);
				}
			}
		}

		public void method_131()
		{
			OwnerWriterControl.method_60();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Document, bool_2: true);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement)
				{
					((XTextContainerElement)item).enum10_0 = Enum10.const_0;
				}
			}
		}

		internal bool method_132()
		{
			return method_133(CurrentElement);
		}

		internal bool method_133(XTextElement xtextElement_1)
		{
			if (BackgroundMode)
			{
				return true;
			}
			if (!EnableUIEventStartEditContent)
			{
				return true;
			}
			if (xtextElement_1 == null)
			{
				xtextElement_1 = Document.CurrentElement;
				if (xtextElement_1 == null)
				{
					xtextElement_1 = Document;
				}
			}
			XTextContainerElement xTextContainerElement = xtextElement_1 as XTextContainerElement;
			if (xTextContainerElement == null)
			{
				xTextContainerElement = xtextElement_1.Parent;
			}
			WriterStartEditEventArgs writerStartEditEventArgs;
			while (true)
			{
				if (xTextContainerElement != null)
				{
					if (xTextContainerElement.enum10_0 == Enum10.const_3)
					{
						xTextContainerElement = xTextContainerElement.Parent;
						continue;
					}
					if (xTextContainerElement.enum10_0 != Enum10.const_1)
					{
						if (xTextContainerElement.enum10_0 == Enum10.const_2 || xTextContainerElement.enum10_0 == Enum10.const_0)
						{
							writerStartEditEventArgs = new WriterStartEditEventArgs(OwnerWriterControl, Document);
							writerStartEditEventArgs.ContainerElement = xTextContainerElement;
							OwnerWriterControl.OnEventUIStartEditContent(writerStartEditEventArgs);
							if (writerStartEditEventArgs.Readonly)
							{
								break;
							}
							xTextContainerElement.enum10_0 = Enum10.const_3;
							if (writerStartEditEventArgs.ReloadDocument)
							{
							}
						}
						xTextContainerElement = xTextContainerElement.Parent;
						continue;
					}
					return false;
				}
				return true;
			}
			if (writerStartEditEventArgs.CanDetectAgain)
			{
				xTextContainerElement.enum10_0 = Enum10.const_2;
			}
			else
			{
				xTextContainerElement.enum10_0 = Enum10.const_1;
			}
			return false;
		}

		internal Rectangle method_134(float float_2, float float_3, float float_4)
		{
			float_4 = GraphicsUnitConvert.Convert(float_4, GraphicsUnit, GraphicsUnit.Pixel);
			base.UseAbsTransformPoint = true;
			Point point = ViewPointToClient((int)float_2, (int)float_3);
			base.UseAbsTransformPoint = false;
			return new Rectangle(point.X, point.Y, (int)(10f * base.XZoomRate), (int)(float_4 * base.YZoomRate));
		}

		public void method_135()
		{
			using (dlgAbout dlgAbout = new dlgAbout())
			{
				dlgAbout.ShowDialog(this);
			}
		}

		internal void method_136()
		{
			documentNavigator_0 = null;
		}

		[ComVisible(true)]
		public bool method_137(string string_8)
		{
			NavigateNode nodeByID = Navigator.GetNodeByID(string_8);
			return method_138(nodeByID);
		}

		[ComVisible(true)]
		public bool method_138(NavigateNode navigateNode_0)
		{
			if (navigateNode_0 == null)
			{
				return false;
			}
			if (GClass354.smethod_3())
			{
				return false;
			}
			Document.Content.AutoClearSelection = true;
			int position = navigateNode_0.Position;
			if (position >= 0)
			{
				base.MoveCaretWithScroll = false;
				bool_40 = true;
				try
				{
					Document.Content.MoveToPosition(navigateNode_0.Position);
					method_197(ScrollToViewStyle.Top);
				}
				finally
				{
					bool_40 = false;
					base.MoveCaretWithScroll = true;
				}
				return true;
			}
			return false;
		}

		public void method_139(string string_8)
		{
			int num = 11;
			if (string_5 != string_8)
			{
				string_5 = string_8;
				OwnerWriterControl.method_79("StatusTextChanged");
				StatusTextChangedEventArgs statusTextChangedEventArgs_ = new StatusTextChangedEventArgs(OwnerWriterControl, string_5);
				OwnerWriterControl.vmethod_18(statusTextChangedEventArgs_);
			}
		}

		[ComVisible(true)]
		public void method_140(string string_8, string string_9)
		{
			int num = 0;
			if (XTextDocument.smethod_13(GEnum6.const_156))
			{
				if (ContextMenuStrip == null)
				{
					ContextMenuStrip = new ContextMenuStrip();
				}
				if (string_8 == "-" || string.IsNullOrEmpty(string_8))
				{
					ContextMenuStrip.Items.Add(new ToolStripSeparator());
					return;
				}
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = string_8;
				toolStripMenuItem.Name = string_9;
				toolStripMenuItem.Click += method_142;
				ContextMenuStrip.Items.Add(toolStripMenuItem);
			}
		}

		[ComVisible(true)]
		public void method_141()
		{
			if (ContextMenuStrip != null)
			{
				ContextMenuStrip.Items.Clear();
			}
		}

		private void method_142(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			CustomCommandEventArgs customCommandEventArgs_ = new CustomCommandEventArgs(toolStripMenuItem.Name);
			OwnerWriterControl.vmethod_41(customCommandEventArgs_);
		}

		[ComVisible(true)]
		public void method_143(XTextElement xtextElement_1)
		{
			int num = 0;
			if (xtextElement_1 == null)
			{
				throw new ArgumentNullException("element");
			}
			ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
			contentChangedEventArgs.Document = Document;
			contentChangedEventArgs.Element = xtextElement_1;
			if (xtextElement_1 is XTextCheckBoxElementBase)
			{
				((XTextCheckBoxElementBase)xtextElement_1).vmethod_29(this, contentChangedEventArgs);
			}
			XTextContainerElement xTextContainerElement = xtextElement_1 as XTextContainerElement;
			if (xTextContainerElement == null)
			{
				xTextContainerElement = xtextElement_1.Parent;
			}
			xTextContainerElement?.method_23(contentChangedEventArgs);
		}

		[ComVisible(true)]
		public void method_144(string string_8)
		{
			if (ContextMenuManager != null)
			{
				Type controlType = ControlHelper.GetControlType(string_8, typeof(XTextElement));
				ContextMenuManager.AddContextMenuSeparator(controlType);
			}
		}

		[ComVisible(false)]
		public ToolStripSeparator method_145(Type type_0)
		{
			if (ContextMenuManager != null)
			{
				return ContextMenuManager.AddContextMenuSeparator(type_0);
			}
			return null;
		}

		[ComVisible(true)]
		public void method_146(string string_8, string string_9)
		{
			if (ContextMenuManager != null)
			{
				Type controlType = ControlHelper.GetControlType(string_8, typeof(XTextElement));
				ContextMenuManager.RemoveContextMenuItem(controlType, string_9);
			}
		}

		[ComVisible(false)]
		public void method_147(Type type_0, string string_8)
		{
			if (ContextMenuManager != null)
			{
				ContextMenuManager.RemoveContextMenuItem(type_0, string_8);
			}
		}

		[ComVisible(true)]
		public void method_148(string string_8, string string_9, string string_10, string string_11)
		{
			int num = 19;
			if (ContextMenuManager != null)
			{
				if (string.IsNullOrEmpty(string_8))
				{
					throw new ArgumentNullException("elementTypeName");
				}
				Type controlType = ControlHelper.GetControlType(string_8, typeof(XTextElement));
				if (controlType == null)
				{
					throw new NotSupportedException(string_8);
				}
				ContextMenuManager.AddContextMenuItem(controlType, string_9, string_10, string_11, null, null);
			}
		}

		[ComVisible(false)]
		public ToolStripMenuItem method_149(Type type_0, string string_8, EventHandler eventHandler_2)
		{
			return method_150(type_0, null, null, string_8, null, eventHandler_2);
		}

		[ComVisible(false)]
		public ToolStripMenuItem method_150(Type type_0, string string_8, string string_9, string string_10, string string_11, EventHandler eventHandler_2)
		{
			if (ContextMenuManager != null)
			{
				return ContextMenuManager.AddContextMenuItem(type_0, string_8, string_9, string_10, string_11, eventHandler_2);
			}
			return null;
		}

		public void method_151(XTextElement xtextElement_1, XTextElement xtextElement_2)
		{
			if (Document.HighlightManager != null)
			{
				HighlightInfo highlightInfo = Document.HighlightManager.imethod_10(xtextElement_1);
				if (highlightInfo != null && highlightInfo.ActiveStyle == HighlightActiveStyle.Hover)
				{
					method_101(highlightInfo.Range);
				}
				highlightInfo = Document.HighlightManager.imethod_10(xtextElement_2);
				if (highlightInfo != null && highlightInfo.ActiveStyle == HighlightActiveStyle.Hover)
				{
					method_101(highlightInfo.Range);
				}
			}
			OwnerWriterControl.method_75(new WriterEventArgs(OwnerWriterControl, Document, null));
		}

		private Point method_152(Point point_1)
		{
			MultiPageTransform gClass = (MultiPageTransform)base.Transform;
			PointF pointF = gClass.AbsTransformPoint(point_1.X, point_1.Y);
			return new Point((int)pointF.X, (int)pointF.Y);
		}

		/// <summary>
		///       处理OLE拖拽进入事件
		///       </summary>
		/// <param name="drgevent">事件参数</param>
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_149))
			{
				base.OnDragEnter(drgevent);
				return;
			}
			drgevent.Effect = DragDropEffects.None;
			dateTime_0 = DateTime.Now;
			DragEventHandled = false;
			base.OnDragEnter(drgevent);
			OwnerWriterControl.method_43(drgevent);
			if (!DragEventHandled && xtextDocument_0 != null)
			{
				drgevent.Effect = DragDropEffects.None;
				method_153(drgevent, 0);
			}
		}

		protected override void OnDragLeave(EventArgs eventArgs_0)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_149))
			{
				base.OnDragLeave(eventArgs_0);
			}
			else
			{
				OwnerWriterControl.method_44(eventArgs_0);
			}
		}

		/// <summary>
		///       处理OLE拖拽经过事件
		///       </summary>
		/// <param name="drgevent">事件参数</param>
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_149))
			{
				base.OnDragOver(drgevent);
				return;
			}
			dateTime_0 = DateTime.Now;
			if (dragOperationState_0 == DragOperationState.None)
			{
				dragOperationState_0 = DragOperationState.Drag;
			}
			DragEventHandled = false;
			base.OnDragOver(drgevent);
			OwnerWriterControl.method_45(drgevent);
			if (!DragEventHandled && xtextDocument_0 != null)
			{
				drgevent.Effect = DragDropEffects.None;
				method_153(drgevent, 0);
			}
		}

		/// <summary>
		///       处理OLE拖拽反馈事件
		///       </summary>
		/// <param name="gfbevent">事件参数</param>
		protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
		{
			if (dragOperationState_0 == DragOperationState.None)
			{
				dragOperationState_0 = DragOperationState.Drag;
			}
			dateTime_0 = DateTime.Now;
			gfbevent.UseDefaultCursors = true;
			base.OnGiveFeedback(gfbevent);
		}

		/// <summary>
		///       处理OLE拖拽完成事件
		///       </summary>
		/// <param name="drgevent">事件参数</param>
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_149))
			{
				base.OnDragDrop(drgevent);
				return;
			}
			dateTime_0 = DateTime.Now;
			if (dragOperationState_0 == DragOperationState.None)
			{
				dragOperationState_0 = DragOperationState.Drag;
			}
			DragEventHandled = false;
			base.OnDragDrop(drgevent);
			OwnerWriterControl.method_42(drgevent);
			if (DragEventHandled)
			{
				return;
			}
			if (!OwnerWriterControl.UIStartEditContent())
			{
				drgevent.Effect = DragDropEffects.None;
			}
			else if (xtextDocument_0 != null)
			{
				base.ForceShowCaret = false;
				method_153(drgevent, 1);
				if (dragOperationState_0 != DragOperationState.DragDropInOwnerWriterControl)
				{
					dragOperationState_0 = DragOperationState.None;
				}
			}
		}

		private void method_153(DragEventArgs dragEventArgs_0, int int_15)
		{
			int num = 8;
			dateTime_0 = DateTime.Now;
			WriterDataObjectRange dataObjectRange = DocumentOptions.BehaviorOptions.DataObjectRange;
			if ((dataObjectRange == WriterDataObjectRange.Application || dataObjectRange == WriterDataObjectRange.SingleWriterControl) && dragEventArgs_0.Data.GetDataPresent("DataObjectID"))
			{
				string a = Convert.ToString(dragEventArgs_0.Data.GetDataPresent("DataObjectID"));
				if ((dataObjectRange == WriterDataObjectRange.Application && a != string_1) || (dataObjectRange == WriterDataObjectRange.SingleWriterControl && a != string_2))
				{
					return;
				}
			}
			if (base.PagesTransform == null)
			{
				return;
			}
			SimpleRectangleTransform gClass = base.PagesTransform.method_15(dragEventArgs_0.X, dragEventArgs_0.Y, bool_0: true, bool_1: true, bool_2: true);
			if (gClass == null)
			{
				return;
			}
			Point p = new Point(dragEventArgs_0.X, dragEventArgs_0.Y);
			p = PointToClient(p);
			PointF pointF_ = new PointF(p.X, p.Y);
			pointF_ = RectangleCommon.MoveInto(pointF_, gClass.getSourceRectF());
			pointF_ = gClass.TransformPointF(pointF_.X, pointF_.Y);
			XTextDocument xTextDocument = (XTextDocument)gClass.method_10();
			XTextElement xTextElement = xTextDocument.Content.GetElementAt(pointF_.X, pointF_.Y, bool_4: false);
			if (xTextElement == null)
			{
				return;
			}
			int num2 = xTextDocument.Content.FixIndexForStrictFormViewMode(xTextDocument.Content.IndexOf(xTextElement), FixIndexDirection.Both, enableSetAutoClearSelectionFlag: false);
			if (num2 >= 0)
			{
				xTextElement = xTextDocument.Content[num2];
				base.ForceShowCaret = true;
				base.UseAbsTransformPoint = true;
				if (dragOperationState_0 == DragOperationState.DragingSelection)
				{
					bool hideCaretWhenHasSelection = HideCaretWhenHasSelection;
					HideCaretWhenHasSelection = false;
					UpdateTextCaret(xTextElement);
					HideCaretWhenHasSelection = hideCaretWhenHasSelection;
					if (xTextDocument.Selection.Contains(xTextElement))
					{
						dragEventArgs_0.Effect = DragDropEffects.None;
						method_139(null);
						return;
					}
				}
				else
				{
					dragOperationState_0 = DragOperationState.Drag;
					xTextDocument.Content.AutoClearSelection = true;
					xTextDocument.Content.MoveToPoint(pointF_.X, pointF_.Y);
					xTextElement = xTextDocument.CurrentElement;
				}
				base.UseAbsTransformPoint = false;
				if (method_154(xTextElement, dragEventArgs_0, pointF_.X, pointF_.Y))
				{
					if ((dragEventArgs_0.KeyState & 4) == 4 && (dragEventArgs_0.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
					{
						method_139(WriterStringsCore.WhereToMove);
						dragEventArgs_0.Effect = DragDropEffects.Move;
					}
					else if ((dragEventArgs_0.KeyState & 8) == 8 && (dragEventArgs_0.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
					{
						method_139(WriterStringsCore.WhereToCopy);
						dragEventArgs_0.Effect = DragDropEffects.Copy;
					}
					else if ((dragEventArgs_0.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
					{
						method_139(WriterStringsCore.WhereToMove);
						dragEventArgs_0.Effect = DragDropEffects.Move;
					}
					else if ((dragEventArgs_0.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
					{
						method_139(WriterStringsCore.WhereToCopy);
						dragEventArgs_0.Effect = DragDropEffects.Copy;
					}
					else
					{
						method_139(null);
						dragEventArgs_0.Effect = DragDropEffects.None;
					}
					if (int_15 != 1)
					{
						return;
					}
					InsertObjectEventArgs insertObjectEventArgs = new InsertObjectEventArgs(Document);
					insertObjectEventArgs.AllowedEffect = dragEventArgs_0.AllowedEffect;
					insertObjectEventArgs.DragEffect = dragEventArgs_0.Effect;
					insertObjectEventArgs.DataObject = dragEventArgs_0.Data;
					insertObjectEventArgs.ShowUI = true;
					insertObjectEventArgs.AutoSelectContent = true;
					insertObjectEventArgs.InputSource = InputValueSource.DragDrop;
					insertObjectEventArgs.Result = false;
					insertObjectEventArgs.CurrentElement = xTextElement;
					if (dragOperationState_0 == DragOperationState.DragingSelection && dragEventArgs_0.Effect == DragDropEffects.Move)
					{
						dragOperationState_0 = DragOperationState.DragDropInOwnerWriterControl;
						insertObjectEventArgs.DetectForDragContent = true;
						DocumentControler.vmethod_4(insertObjectEventArgs);
						if (!insertObjectEventArgs.Result)
						{
							dragEventArgs_0.Effect = DragDropEffects.None;
							return;
						}
						insertObjectEventArgs.CurrentElement = null;
						insertObjectEventArgs.DetectForDragContent = false;
						method_208(bool_47: true);
						dragEventArgs_0.Effect = DragDropEffects.Copy;
					}
					xTextDocument.Content.AutoClearSelection = true;
					base.ForceShowCaret = false;
					base.UseAbsTransformPoint = true;
					xTextDocument.Content.method_47(xTextElement.ViewIndex, 0);
					base.UseAbsTransformPoint = false;
					OwnerWriterControl.OnEventInsertObject(insertObjectEventArgs);
					dragEventArgs_0.Effect = insertObjectEventArgs.DragEffect;
					if (!insertObjectEventArgs.Result)
					{
						dragEventArgs_0.Effect = DragDropEffects.None;
					}
					method_139(null);
					Update();
					Focus();
				}
				else
				{
					method_139(null);
					dragEventArgs_0.Effect = DragDropEffects.None;
				}
			}
			else
			{
				dragEventArgs_0.Effect = DragDropEffects.None;
			}
		}

		public bool method_154(XTextElement xtextElement_1, DragEventArgs dragEventArgs_0, float float_2, float float_3)
		{
			CanInsertObjectEventArgs canInsertObjectEventArgs = new CanInsertObjectEventArgs(Document);
			canInsertObjectEventArgs.SpecifyPosition = Document.Content.IndexOf(xtextElement_1);
			canInsertObjectEventArgs.DataObject = dragEventArgs_0.Data;
			canInsertObjectEventArgs.SpecifyFormat = null;
			canInsertObjectEventArgs.AccessFlags = DomAccessFlags.Normal;
			OwnerWriterControl.OnEventCanInsertObject(canInsertObjectEventArgs);
			return canInsertObjectEventArgs.Result;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool method_155(string string_8, bool bool_47)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_53))
			{
				return false;
			}
			if (!string.IsNullOrEmpty(string_8) && !XTextDocument.smethod_13(GEnum6.const_54))
			{
				return false;
			}
			InsertObjectEventArgs insertObjectEventArgs = new InsertObjectEventArgs(Document);
			insertObjectEventArgs.DataObject = method_91(bool_47);
			if (insertObjectEventArgs.DataObject == null)
			{
				return false;
			}
			insertObjectEventArgs.SpecifyFormat = string_8;
			insertObjectEventArgs.ShowUI = bool_47;
			WriterDataFormats allowDataFormats = AcceptDataFormats;
			if (!XTextDocument.smethod_13(GEnum6.const_146))
			{
				allowDataFormats = WriterDataFormats.All;
			}
			insertObjectEventArgs.AllowDataFormats = allowDataFormats;
			insertObjectEventArgs.WriterControl = OwnerWriterControl;
			insertObjectEventArgs.InputSource = InputValueSource.Clipboard;
			insertObjectEventArgs.CheckMaxTextLengthForCopyPaste = true;
			OwnerWriterControl.OnEventInsertObject(insertObjectEventArgs);
			if (!insertObjectEventArgs.Result && insertObjectEventArgs.RejectFormats.Count > 0 && bool_47 && DocumentOptions.BehaviorOptions.PromptForRejectFormat)
			{
				string text = string.Format(WriterStringsCore.PromptRejectFormat_Format, WriterUtils.smethod_12(insertObjectEventArgs.RejectFormats, ','));
				AppHost.UITools.ShowMessageBox(this, text);
			}
			return insertObjectEventArgs.Result;
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			base.OnClick(eventArgs_0);
			OwnerWriterControl.method_37(eventArgs_0);
		}

		protected override void OnDoubleClick(EventArgs eventArgs_0)
		{
			base.OnDoubleClick(eventArgs_0);
			OwnerWriterControl.method_38(eventArgs_0);
		}

		/// <summary>
		///       处理鼠标滚轮事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			int num = 0;
			dateTime_0 = DateTime.Now;
			if (bool_29 || !base.IsHandleCreated)
			{
				return;
			}
			base.OnMouseWheel(mouseEventArgs_0);
			OwnerWriterControl.method_34(mouseEventArgs_0);
			if (xtextDocument_0 == null)
			{
				return;
			}
			if (IsEditingElementValue)
			{
				EditorHost.CancelEditValue();
			}
			if (Control.ModifierKeys == Keys.Control)
			{
				bool flag = false;
				if ((mouseEventArgs_0.Delta <= 0) ? ((bool)method_72("ZoomOut", bool_47: false, null)) : ((bool)method_72("ZoomIn", bool_47: false, null)))
				{
					method_158();
					return;
				}
			}
			else
			{
				OnScroll(null);
			}
			method_158();
		}

		internal void method_156()
		{
			bool_29 = true;
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 500;
			timer.Tick += method_157;
			timer.Start();
		}

		private void method_157(object sender, EventArgs e)
		{
			System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
			timer.Stop();
			timer.Dispose();
			bool_29 = false;
		}

		/// <summary>
		///       处理鼠标单击事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			dateTime_0 = DateTime.Now;
			if (bool_29)
			{
				return;
			}
			base.OnMouseClick(mouseEventArgs_0);
			OwnerWriterControl.method_32(mouseEventArgs_0);
			if (xtextDocument_0 != null && ExtViewMode != WriterControlExtViewMode.BoundsSelection && ExtViewMode != WriterControlExtViewMode.JumpPrint && ExtViewMode != WriterControlExtViewMode.OffsetJumpPrint)
			{
				if (Document != null)
				{
					Document.MouseCapture = null;
				}
				OwnerWriterControl.method_73(mouseEventArgs_0);
				method_160(mouseEventArgs_0, DocumentEventStyles.MouseClick);
			}
		}

		/// <summary>
		///       处理鼠标双击事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnMouseDoubleClick(MouseEventArgs mouseEventArgs_0)
		{
			dateTime_0 = DateTime.Now;
			if (bool_29)
			{
				return;
			}
			base.OnMouseDoubleClick(mouseEventArgs_0);
			OwnerWriterControl.method_33(mouseEventArgs_0);
			if (ExtViewMode == WriterControlExtViewMode.BoundsSelection || ExtViewMode == WriterControlExtViewMode.JumpPrint || ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint)
			{
				return;
			}
			OwnerWriterControl.method_74(mouseEventArgs_0);
			if (base.IsHandleCreated && xtextDocument_0 != null)
			{
				bool flag = false;
				int x = mouseEventArgs_0.X;
				int y = mouseEventArgs_0.Y;
				base.CurrentTransformItem = null;
				foreach (SimpleRectangleTransform item in base.PagesTransform)
				{
					XTextDocument xTextDocument = (XTextDocument)item.method_10();
					if (item.method_23().Contains(x, y) && (!HeaderFooterReadonly || !DrawerUtil.IsHeaderFooter(item.method_0())) && item.method_0() != PageContentPartyStyle.HeaderRows)
					{
						XTextDocumentContentElement xTextDocumentContentElement = null;
						switch (item.method_0())
						{
						case PageContentPartyStyle.Header:
							xTextDocumentContentElement = xTextDocument.Header;
							base.CurrentTransformItem = item;
							break;
						case PageContentPartyStyle.Footer:
							xTextDocumentContentElement = xTextDocument.Footer;
							base.CurrentTransformItem = item;
							break;
						case PageContentPartyStyle.Body:
							xTextDocumentContentElement = xTextDocument.Body;
							break;
						case PageContentPartyStyle.HeaderForFirstPage:
							xTextDocumentContentElement = xTextDocument.HeaderForFirstPage;
							base.CurrentTransformItem = item;
							break;
						case PageContentPartyStyle.FooterForFirstPage:
							xTextDocumentContentElement = xTextDocument.FooterForFirstPage;
							base.CurrentTransformItem = item;
							break;
						}
						if (xTextDocumentContentElement?.Visible ?? true)
						{
							bool flag2 = false;
							XTextDocumentContentElement currentContentElement = xTextDocument.CurrentContentElement;
							if (xTextDocument.CurrentContentElement != xTextDocumentContentElement)
							{
								if (CommentManager != null && CommentManager.imethod_9() != null)
								{
									CommentManager.imethod_10(null);
								}
								xTextDocument.CurrentContentElement = xTextDocumentContentElement;
								flag2 = true;
							}
							if (!item.getEnable())
							{
								xTextDocument.CurrentContentElement.FixElements();
								UpdatePages();
								Invalidate();
								UpdateTextCaret();
								flag = true;
							}
							if (flag2)
							{
								xTextDocument.CurrentContentElement.method_67(currentContentElement.CurrentElement, xTextDocumentContentElement.CurrentElement);
							}
							break;
						}
						return;
					}
				}
				if (!flag)
				{
					method_160(mouseEventArgs_0, DocumentEventStyles.MouseDblClick);
				}
			}
		}

		private void method_158()
		{
			Point mousePosition = Control.MousePosition;
			mousePosition = PointToClient(mousePosition);
			MouseEventArgs e = new MouseEventArgs(MouseButtons.None, 0, mousePosition.X, mousePosition.Y, 0);
			OnMouseMove(e);
		}

		/// <summary>
		///       处理鼠标移动事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			dateTime_0 = DateTime.Now;
			if (bool_29 || !base.IsHandleCreated)
			{
				return;
			}
			base.OnMouseMove(mevent);
			OwnerWriterControl.method_30(mevent);
			OwnerWriterControl.method_68(mevent);
			if (xtextDocument_0 == null)
			{
				return;
			}
			if (ExtViewMode == WriterControlExtViewMode.BoundsSelection)
			{
				Cursor = Cursors.Cross;
				return;
			}
			if (ExtViewMode == WriterControlExtViewMode.JumpPrint || ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint)
			{
				Cursor = Cursors.Default;
				return;
			}
			if (mevent.Button != 0 && base.MouseDragScroll)
			{
				base.UseAbsTransformPoint = true;
				base.OnMouseMove(mevent);
				base.UseAbsTransformPoint = false;
				return;
			}
			Rectangle dragableHandleBounds = DragableHandleBounds;
			if (!dragableHandleBounds.IsEmpty && dragableHandleBounds.Contains(mevent.X, mevent.Y))
			{
				Cursor = Cursors.Arrow;
			}
			else
			{
				method_160(mevent, DocumentEventStyles.MouseMove);
			}
		}

		/// <summary>
		///       处理鼠标按键按下事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			dateTime_0 = DateTime.Now;
			if (bool_29 || !base.IsHandleCreated)
			{
				return;
			}
			base.OnMouseDown(mevent);
			OwnerWriterControl.method_29(mevent);
			if (!IsEditingElementValue)
			{
			}
			method_166();
			if (xtextDocument_0 != null)
			{
				if (ExtViewMode == WriterControlExtViewMode.BoundsSelection)
				{
					if (!XTextDocument.smethod_8(this, GEnum6.const_45, ExtViewMode.ToString()))
					{
						return;
					}
					if (Cursor != Cursors.Cross)
					{
						Cursor = Cursors.Cross;
					}
					Rectangle rectangle = MouseCapturer.smethod_0(this, mevent.X, mevent.Y);
					if (!rectangle.IsEmpty)
					{
						foreach (SimpleRectangleTransform item in base.PagesTransform)
						{
							if (!DrawerUtil.IsHeaderFooter(item.method_0()))
							{
								Rectangle rectangle2 = Rectangle.Intersect(item.method_21(), rectangle);
								if (!rectangle2.IsEmpty)
								{
									RectangleF bounds = item.vmethod_11(new RectangleF(rectangle2.Left, rectangle2.Top, rectangle2.Width, rectangle2.Height));
									if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
									{
										BoundsSelection.AddItem(item.method_12(), bounds);
										Invalidate(rectangle);
									}
									else
									{
										BoundsSelection.Clear();
										BoundsSelection.AddItem(item.method_12(), bounds);
										Invalidate();
									}
								}
							}
						}
					}
				}
				else if (ExtViewMode == WriterControlExtViewMode.JumpPrint || ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint)
				{
					if (ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint && !XTextDocument.smethod_8(this, GEnum6.const_43, ExtViewMode.ToString()))
					{
						return;
					}
					JumpPrintInfo jumpPrintInfo = JumpPrint.Clone();
					JumpPrint.PageIndex = -1;
					JumpPrint.Position = 0f;
					foreach (SimpleRectangleTransform item2 in base.PagesTransform)
					{
						if (item2.method_0() == PageContentPartyStyle.Body && item2.getSourceRectF().Bottom >= (float)mevent.Y)
						{
							PrintPage printPage = (PrintPage)item2.method_8();
							XTextDocument xTextDocument = (XTextDocument)printPage.Document;
							float num = item2.TransformPoint(mevent.X, mevent.Y).Y;
							if (mevent.Y < item2.method_21().Top)
							{
								num = (int)item2.method_25().Top;
							}
							if (num >= 0f)
							{
								if (JumpPrint.Mode == JumpPrintMode.Normal && Control.ModifierKeys == Keys.Control)
								{
									JumpPrint.PageIndex = jumpPrintInfo.PageIndex;
									JumpPrint.Position = jumpPrintInfo.Position;
									JumpPrint.EndPageIndex = -1;
									JumpPrint.SetNativeEndPosition(0f);
									JumpPrintInfo jumpPrintInfo2 = xTextDocument.GetJumpPrintInfo(num);
									if (jumpPrintInfo2 != null && jumpPrintInfo2.NativePosition > JumpPrint.NativePosition)
									{
										JumpPrint.EndPageIndex = jumpPrintInfo2.PageIndex;
										JumpPrint.SetNativeEndPosition(num);
										JumpPrint.EndPosition = jumpPrintInfo2.Position;
									}
								}
								else
								{
									JumpPrint.PageIndex = base.Pages.IndexOf(printPage);
									JumpPrint.SetNativePosition(num);
									JumpPrint.EndPageIndex = -1;
									JumpPrint.SetNativeEndPosition(0f);
									JumpPrintInfo jumpPrintInfo2 = null;
									if (JumpPrint.Mode == JumpPrintMode.Offset)
									{
										jumpPrintInfo2 = xTextDocument.GetJumpPrintInfoWithouFixPosition(num);
										if (jumpPrintInfo2 != null && jumpPrintInfo2.PageIndex != 0)
										{
											jumpPrintInfo2 = null;
										}
									}
									else
									{
										jumpPrintInfo2 = xTextDocument.GetJumpPrintInfo(num);
									}
									if (jumpPrintInfo2 != null)
									{
										JumpPrint.PageIndex = jumpPrintInfo2.PageIndex;
										JumpPrint.Position = jumpPrintInfo2.Position;
									}
									else
									{
										JumpPrint.PageIndex = base.Pages.IndexOf(printPage);
										JumpPrint.Position = num;
									}
									if (JumpPrint.Mode == JumpPrintMode.Offset)
									{
										if (jumpPrintInfo2 != null && jumpPrintInfo2.PageIndex == 0)
										{
											Document.BodyLayoutOffset = jumpPrintInfo2.AbsPosition;
										}
										else
										{
											Document.BodyLayoutOffset = 0f;
											JumpPrint.PageIndex = 0;
											JumpPrint.Position = 0f;
										}
										method_188(bool_47: false, bool_48: true);
										method_201();
									}
								}
							}
							break;
						}
					}
					if (JumpPrint.PageIndex != jumpPrintInfo.PageIndex || JumpPrint.Position != jumpPrintInfo.Position || JumpPrint.EndPageIndex != jumpPrintInfo.EndPageIndex || JumpPrint.EndPosition != jumpPrintInfo.EndPosition)
					{
						Invalidate();
					}
				}
				else
				{
					Rectangle dragableHandleBounds = DragableHandleBounds;
					if (!dragableHandleBounds.IsEmpty && dragableHandleBounds.Contains(mevent.X, mevent.Y))
					{
						XTextElement dragableElement = DragableElement;
						dragableElement.Select();
						Document.method_69(dragableElement);
						Update();
						if (MouseCapturer.DragDetect(base.Handle))
						{
							method_161();
						}
					}
					else
					{
						method_160(mevent, DocumentEventStyles.MouseDown);
					}
					if (mevent.Button == MouseButtons.Right && (ContextMenu != null || ContextMenuStrip != null))
					{
					}
				}
			}
			if (base.Controls.Count > 0)
			{
				Focus();
			}
			OwnerWriterControl.method_67(mevent);
			if (!Focused)
			{
				Focus();
			}
		}

		internal bool method_159(int int_15, int int_16)
		{
			SimpleRectangleTransform gClass = null;
			gClass = base.PagesTransform.method_15(int_15, int_16, bool_0: true, bool_1: true, bool_2: true);
			if (gClass != null)
			{
				_ = (XTextDocument)gClass.method_10();
				Point point_ = new Point(int_15, int_16);
				point_ = RectangleCommon.MoveInto(point_, gClass.method_21());
				if (point_.Y == gClass.method_21().Bottom)
				{
					point_.Y = gClass.method_21().Bottom - 2;
				}
				point_ = gClass.TransformPoint(point_.X, point_.Y);
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveToPoint(point_.X, point_.Y);
				UpdateTextCaret();
				return true;
			}
			return false;
		}

		private void method_160(MouseEventArgs mouseEventArgs_0, DocumentEventStyles documentEventStyles_0)
		{
			int num = 13;
			if (!base.IsHandleCreated || xtextDocument_0 == null || ExtViewMode == WriterControlExtViewMode.JumpPrint)
			{
				return;
			}
			if (documentEventStyles_0 == DocumentEventStyles.MouseMove)
			{
				if (mouseEventArgs_0.Button != MouseButtons.Left)
				{
				}
				method_94(null);
			}
			int_12 = 0;
			RefreshScaleTransform();
			if (!HeaderFooterReadonly)
			{
				foreach (SimpleRectangleTransform item in base.PagesTransform)
				{
					if (item.method_23().Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y) && !item.getEnable() && DrawerUtil.IsHeaderFooter(item.method_0()))
					{
						if (documentEventStyles_0 == DocumentEventStyles.MouseMove)
						{
							method_96();
						}
						if (mouseEventArgs_0.Clicks > 0)
						{
							return;
						}
					}
				}
			}
			SimpleRectangleTransform gClass2 = null;
			if (mouseEventArgs_0.Button == MouseButtons.None)
			{
				gClass2 = base.PagesTransform.method_15(mouseEventArgs_0.X, mouseEventArgs_0.Y, bool_0: true, bool_1: false, bool_2: true);
				if (gClass2 == null)
				{
					Cursor = Cursors.Default;
					if (documentEventStyles_0 == DocumentEventStyles.MouseMove)
					{
						method_96();
					}
					return;
				}
			}
			gClass2 = base.PagesTransform.method_15(mouseEventArgs_0.X, mouseEventArgs_0.Y, bool_0: true, bool_1: true, bool_2: true);
			if (documentEventStyles_0 == DocumentEventStyles.MouseMove && mouseEventArgs_0.Button == MouseButtons.Left && !base.ClientRectangle.Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y) && Selection.Length != 0)
			{
				if (mouseEventArgs_0.Y < base.ClientRectangle.Top)
				{
					gClass2 = base.PagesTransform.method_16(mouseEventArgs_0.X, mouseEventArgs_0.Y, bool_0: true, GEnum92.const_2, bool_1: true);
				}
				else if (mouseEventArgs_0.Y > base.ClientRectangle.Bottom)
				{
					gClass2 = base.PagesTransform.method_16(mouseEventArgs_0.X, mouseEventArgs_0.Y, bool_0: true, GEnum92.const_3, bool_1: true);
				}
				else if (Selection.Length < 0)
				{
					gClass2 = base.PagesTransform.method_16(mouseEventArgs_0.X, mouseEventArgs_0.Y, bool_0: true, GEnum92.const_2, bool_1: true);
				}
				else if (Selection.Length > 0)
				{
					gClass2 = base.PagesTransform.method_16(mouseEventArgs_0.X, mouseEventArgs_0.Y, bool_0: true, GEnum92.const_3, bool_1: true);
				}
			}
			if (gClass2 == null)
			{
				return;
			}
			XTextDocument xTextDocument = (XTextDocument)gClass2.method_10();
			Point point_ = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			point_ = RectangleCommon.MoveInto(point_, gClass2.method_21());
			if (point_.Y > mouseEventArgs_0.Y && documentEventStyles_0 == DocumentEventStyles.MouseMove && mouseEventArgs_0.Button == MouseButtons.Left)
			{
				point_.Y++;
			}
			if (point_.Y == gClass2.method_21().Bottom)
			{
				point_.Y = gClass2.method_21().Bottom - 2;
			}
			point_ = gClass2.TransformPoint(point_.X, point_.Y);
			if (gClass2.method_0() == PageContentPartyStyle.Body)
			{
				GClass543 commentSettings = CommentSettings;
				DocumentCommentList runtimeComments = xTextDocument.RuntimeComments;
				if ((runtimeComments == null || runtimeComments.Count == 0) && CommentManager != null && CommentManager.imethod_9() != null)
				{
					CommentManager.imethod_10(null);
					OwnerWriterControl.OnSelectionChanged(EventArgs.Empty);
					Invalidate();
				}
				if (commentSettings != null && commentSettings.method_0() && runtimeComments != null && runtimeComments.Count > 0 && (documentEventStyles_0 == DocumentEventStyles.MouseDown || documentEventStyles_0 == DocumentEventStyles.MouseDblClick || documentEventStyles_0 == DocumentEventStyles.MouseClick))
				{
					Point point = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					point = gClass2.TransformPoint(point.X, point.Y);
					foreach (DocumentComment item2 in runtimeComments)
					{
						if (item2.RuntimeVisible && item2.OwnerPage == gClass2.method_8() && new RectangleF(item2.Left, item2.Top, item2.Width, item2.Height).Contains(point.X, point.Y))
						{
							ContextMenuStrip = null;
							int num2;
							switch (documentEventStyles_0)
							{
							case DocumentEventStyles.MouseDown:
								if (CommentManager.imethod_9() != item2)
								{
									CommentManager.imethod_10(item2);
									OwnerWriterControl.OnSelectionChanged(EventArgs.Empty);
									Invalidate();
									if (!OwnerWriterControl.EnabledControlEvent)
									{
										WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.DocumentCommentClick);
										writerControlEventMessage.ContextText = item2.Text;
										OwnerWriterControl.method_49(writerControlEventMessage);
									}
								}
								return;
							case DocumentEventStyles.MouseDblClick:
								if (DoubleClickToEditComment && !item2.IsInternal && DocumentControler.CanModify(item2.AnchorElement))
								{
									method_72("EditComment", bool_47: true, null);
								}
								if (!OwnerWriterControl.EnabledControlEvent)
								{
									WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.DocumentCommentDblClick);
									writerControlEventMessage.ContextText = item2.Text;
									OwnerWriterControl.method_49(writerControlEventMessage);
								}
								return;
							case DocumentEventStyles.MouseClick:
								num2 = ((mouseEventArgs_0.Button != MouseButtons.Right) ? 1 : 0);
								break;
							default:
								num2 = 1;
								break;
							}
							if (num2 == 0)
							{
								if (!item2.IsInternal)
								{
									ContextMenuStrip commentContextMenuStrip = CommentContextMenuStrip;
									if (commentContextMenuStrip != null)
									{
										ContextMenuStrip = null;
										commentContextMenuStrip.Show(this, new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
									}
								}
							}
							else if (documentEventStyles_0 == DocumentEventStyles.MouseClick && mouseEventArgs_0.Button == MouseButtons.Left && item2.IsInternal && item2.DataBoundItem is ValueValidateResult)
							{
								((ValueValidateResult)item2.DataBoundItem).Selet();
							}
							return;
						}
					}
					if (documentEventStyles_0 == DocumentEventStyles.MouseDown && CommentManager.imethod_9() != null)
					{
						CommentManager.imethod_10(null);
						Invalidate();
					}
				}
			}
			DocumentEventArgs documentEventArgs = DocumentEventArgs.CreateMouseDown(xTextDocument, new MouseEventArgs(mouseEventArgs_0.Button, mouseEventArgs_0.Clicks, point_.X, point_.Y, mouseEventArgs_0.Delta));
			if (StyleInfoForFormatBrush != null)
			{
				documentEventArgs.Cursor = GClass291.smethod_2();
			}
			documentEventArgs._StrictMatch = gClass2.method_21().Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			documentEventArgs.intStyle = documentEventStyles_0;
			if (documentEventStyles_0 != DocumentEventStyles.MouseClick)
			{
			}
			xTextDocument.HandleDocumentEvent(documentEventArgs);
			method_95(bool_47: true);
			if (!documentEventArgs.Handled)
			{
				if (ViewHandleManager != null)
				{
					ViewHandleManager.method_8(documentEventArgs);
				}
				if (documentEventArgs.Handled)
				{
					Cursor = documentEventArgs.Cursor;
				}
			}
			Cursor = documentEventArgs.Cursor;
			if (!documentEventArgs.Handled)
			{
				if (documentEventStyles_0 == DocumentEventStyles.MouseDown && mouseEventArgs_0.Button == MouseButtons.Left)
				{
					if (mouseEventArgs_0.Clicks == 1)
					{
						int stateVersion = xTextDocument.Selection.StateVersion;
						bool flag = false;
						if (AllowDragContent && Selection.Length != 0 && !RuntimeReadonly)
						{
							bool flag2 = true;
							foreach (XTextElement item3 in Selection)
							{
								if (item3 is XTextFieldBorderElement && !((XTextFieldElementBase)item3.Parent).IsFullSelect)
								{
									flag2 = false;
									break;
								}
								if (item3.Parent is XTextFieldElementBase)
								{
									XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)item3.Parent;
									if (xTextFieldElementBase.IsBackgroundTextElement(item3) && !xTextFieldElementBase.IsFullSelect)
									{
										flag2 = false;
										break;
									}
								}
							}
							if (flag2)
							{
								foreach (XTextElement item4 in Selection)
								{
									RectangleF absBounds = item4.AbsBounds;
									absBounds.Width += item4.WidthFix;
									if (absBounds.Contains(point_.X, point_.Y))
									{
										if (MouseCapturer.DragDetect(base.Handle))
										{
											method_161();
											flag = true;
										}
										else if (Control.MouseButtons == MouseButtons.None)
										{
											Point point = Control.MousePosition;
											point = PointToClient(point);
											OnMouseUp(new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
											OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
										}
										break;
									}
								}
							}
						}
						if (!flag && !documentEventArgs.AlreadSetSelection)
						{
							if (xTextDocument.Selection.StateVersion == stateVersion)
							{
								xTextDocument.MouseCapture = new GClass132(documentEventArgs);
								xTextDocument.Content.AutoClearSelection = !documentEventArgs.ShiftKey;
								float tickCountFloat = CountDown.GetTickCountFloat();
								xTextDocument.Content.MoveToPoint(documentEventArgs.X, documentEventArgs.Y);
								tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
								tickCountFloat = CountDown.GetTickCountFloat();
								UpdateTextCaret();
								tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
							}
							base.UseAbsTransformPoint = true;
						}
					}
				}
				else
				{
					switch (documentEventStyles_0)
					{
					case DocumentEventStyles.MouseDblClick:
					{
						XTextElement xTextElement = xTextDocument.Content.GetElementAt(point_.X, point_.Y, bool_4: true);
						if (xTextElement != null && gClass2.method_21().Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
						{
							if (base.Capture)
							{
								base.Capture = false;
							}
							if (int_12 <= 0 && !method_213(xTextElement, bool_47: false, ValueEditorActiveMode.MouseDblClick, bool_48: true, bool_49: true))
							{
							}
						}
						break;
					}
					case DocumentEventStyles.MouseClick:
					{
						XTextElement xTextElement = xTextDocument.Content.GetElementAt(point_.X, point_.Y, bool_4: true);
						if (xTextElement != null && gClass2.method_21().Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
						{
							if (base.Capture)
							{
								base.Capture = false;
							}
							ValueEditorActiveMode valueEditorActiveMode = ValueEditorActiveMode.None;
							valueEditorActiveMode = ((mouseEventArgs_0.Button == MouseButtons.Left) ? ValueEditorActiveMode.MouseClick : ((mouseEventArgs_0.Button != MouseButtons.Right) ? ValueEditorActiveMode.MouseClick : ValueEditorActiveMode.MouseRightClick));
							if (int_12 <= 0 && !method_213(xTextElement, bool_47: false, valueEditorActiveMode, bool_48: true, bool_49: true))
							{
							}
						}
						break;
					}
					case DocumentEventStyles.MouseMove:
						Cursor = documentEventArgs.Cursor;
						break;
					}
				}
			}
			if (mouseEventArgs_0.Button == MouseButtons.Right && documentEventStyles_0 == DocumentEventStyles.MouseClick)
			{
				ContextMenuManager.GetCurrentContextMenu()?.Show(this, new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
			}
		}

		internal void method_161()
		{
			int num = 15;
			Cursor = Cursors.Default;
			if (DocumentOptions.BehaviorOptions.MoveFieldWhenDragWholeContent)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)method_245(typeof(XTextInputFieldElementBase));
				if (xTextInputFieldElementBase != null)
				{
					XTextDocumentContentElement documentContentElement = xTextInputFieldElementBase.DocumentContentElement;
					int num2 = documentContentElement.Content.IndexOf(xTextInputFieldElementBase.StartElement);
					int num3 = documentContentElement.Content.IndexOf(xTextInputFieldElementBase.EndElement);
					int absStartIndex = documentContentElement.Selection.AbsStartIndex;
					int absEndIndex = documentContentElement.Selection.AbsEndIndex;
					if ((num2 == absStartIndex || num2 == absStartIndex - 1) && (num3 == absEndIndex || absEndIndex == num3 + 1))
					{
						documentContentElement.SetSelection(num2, num3 - num2 + 1);
					}
				}
			}
			IDataObject dataObject = DocumentControler.method_12(CreationDataFormats, bool_2: false, DocumentOptions.EditOptions.ClearFieldValueWhenCopy, DocumentOptions.EditOptions.CopyWithoutInputFieldStructure, bool_5: false);
			if (dataObject != null)
			{
				dataObject.SetData("DragContentFlag", "1");
				switch (DocumentOptions.BehaviorOptions.DataObjectRange)
				{
				case WriterDataObjectRange.SingleWriterControl:
					dataObject.SetData("DataObjectID", string_2);
					break;
				case WriterDataObjectRange.Application:
					dataObject.SetData("DataObjectID", string_1);
					break;
				}
				DragDropEffects dragDropEffects = DragDropEffects.Copy;
				if (!RuntimeReadonly && DocumentControler.CanDeleteSelection)
				{
					dragDropEffects |= DragDropEffects.Move;
				}
				DragDropEffects dragDropEffects2 = DragDropEffects.None;
				try
				{
					dragOperationState_0 = DragOperationState.DragingSelection;
					dragDropEffects2 = DoDragDrop(dataObject, dragDropEffects);
					if (dragDropEffects2 == DragDropEffects.None)
					{
						UpdateTextCaret();
					}
					else if ((dragDropEffects2 & DragDropEffects.Move) == DragDropEffects.Move && !RuntimeReadonly && dragOperationState_0 != DragOperationState.DragDropInOwnerWriterControl)
					{
						method_208(bool_47: true);
					}
				}
				finally
				{
					dragOperationState_0 = DragOperationState.None;
				}
			}
		}

		[DCInternal]
		public void method_162(XTextElement xtextElement_1)
		{
			if (xtextElement_1 == null)
			{
				gclass368_0 = null;
			}
			else
			{
				gclass368_0 = new GClass368(xtextElement_1, 100);
			}
		}

		/// <summary>
		///       处理鼠标按键松开事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			dateTime_0 = DateTime.Now;
			if (bool_29 || !base.IsHandleCreated)
			{
				return;
			}
			base.OnMouseUp(mevent);
			OwnerWriterControl.method_31(mevent);
			if (Document != null)
			{
				Document.MouseCapture = null;
			}
			if (base.Capture)
			{
				base.Capture = false;
			}
			method_166();
			OwnerWriterControl.method_69(mevent);
			if (xtextDocument_0 == null || ExtViewMode == WriterControlExtViewMode.BoundsSelection || InDesignMode || ExtViewMode != 0 || Document == null || IsEditingElementValue || mevent.Button != MouseButtons.Left)
			{
				return;
			}
			int num = GClass302.smethod_0().method_2(mevent.X, mevent.Y);
			if (num == 1 && StyleInfoForFormatBrush != null)
			{
				method_183();
				return;
			}
			switch (num)
			{
			case 2:
			{
				XTextElement xTextElement = method_253(mevent.X, mevent.Y);
				if (!(xTextElement?.RuntimeSelectable ?? true))
				{
					break;
				}
				if (xTextElement != null && xTextElement.Parent is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement.Parent;
					if (xTextInputFieldElementBase.IsBackgroundTextElement(xTextElement))
					{
						if (gclass368_0 == null || gclass368_0.method_0() != xTextInputFieldElementBase)
						{
							xTextInputFieldElementBase.Select();
						}
						break;
					}
				}
				if (DocumentOptions.BehaviorOptions.DoubleClickToSelectWord)
				{
					Document.Content.SelectWord();
				}
				break;
			}
			case 3:
			{
				XTextElement xTextElement = method_253(mevent.X, mevent.Y);
				if (!(xTextElement is XTextButtonElement) && (xTextElement?.RuntimeSelectable ?? true) && DocumentOptions.BehaviorOptions.ThreeClickToSelectParagraph)
				{
					Document.Content.SelectParagraph();
				}
				break;
			}
			}
		}

		protected override void OnMouseEnter(EventArgs eventArgs_0)
		{
			base.OnMouseEnter(eventArgs_0);
			OwnerWriterControl.method_35(eventArgs_0);
		}

		/// <summary>
		///       处理鼠标光标离开事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			dateTime_0 = DateTime.Now;
			if (bool_29 || !base.IsHandleCreated)
			{
				return;
			}
			base.OnMouseLeave(eventArgs_0);
			OwnerWriterControl.method_36(eventArgs_0);
			if (!InDesignMode)
			{
				if (!NormalJumpPrint && xtextDocument_0 != null)
				{
					DocumentEventArgs args = new DocumentEventArgs(Document, Document, DocumentEventStyles.MouseLeave);
					Document.HandleDocumentEvent(args);
				}
				Cursor = Cursors.Default;
			}
			method_96();
		}

		public void method_163()
		{
			if (timer_1 != null)
			{
				timer_1.Stop();
				timer_1.Dispose();
				timer_1 = null;
			}
			if (ginterface19_0 != null)
			{
				ginterface19_0.Dispose();
				ginterface19_0 = null;
			}
		}

		internal void method_164()
		{
			if (base.IsHandleCreated && !base.IsDisposed && DocumentOptions.BehaviorOptions.AutoAssistInsertString)
			{
				if (timer_1 == null)
				{
					timer_1 = new System.Windows.Forms.Timer();
					timer_1.Tick += timer_1_Tick;
				}
				timer_1.Interval = 200;
				timer_1.Stop();
				timer_1.Start();
			}
		}

		private void timer_1_Tick(object sender, EventArgs e)
		{
			if (timer_1 != null)
			{
				timer_1.Stop();
			}
			method_165();
		}

		public void method_165()
		{
			if (base.IsDisposed || !base.IsHandleCreated)
			{
				method_163();
			}
			else
			{
				try
				{
					method_210();
					method_182();
					if (AssistStringListForm != null)
					{
						AssistStringListForm.imethod_7();
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
				}
			}
		}

		internal bool method_166()
		{
			if (ginterface19_0 != null && ginterface19_0.Visible)
			{
				ginterface19_0.imethod_6();
				return true;
			}
			return false;
		}

		private string method_167(string string_8)
		{
			int num = 3;
			if (!XTextDocument.smethod_13(GEnum6.const_150))
			{
				return string_8;
			}
			if (string.IsNullOrEmpty(string_8))
			{
				return string_8;
			}
			if (string_8 == "九华山" && Environment.TickCount % 30 == 0)
			{
				return "九华山(袁永福2015年年三十到此一游)";
			}
			string text = string_8;
			string autoTranslateSourceString = DocumentOptions.BehaviorOptions.AutoTranslateSourceString;
			string autoTranslateDescString = DocumentOptions.BehaviorOptions.AutoTranslateDescString;
			if (!string.IsNullOrEmpty(autoTranslateSourceString) && !string.IsNullOrEmpty(autoTranslateDescString) && autoTranslateSourceString.Length == autoTranslateDescString.Length)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (char value in string_8)
				{
					int num2 = autoTranslateSourceString.IndexOf(value);
					if (num2 >= 0)
					{
						stringBuilder.Append(autoTranslateDescString[num2]);
					}
					else
					{
						stringBuilder.Append(value);
					}
				}
				text = stringBuilder.ToString();
			}
			if (OwnerWriterControl != null)
			{
				WriterBeforeUIKeyboardInputStringEventArgs writerBeforeUIKeyboardInputStringEventArgs = new WriterBeforeUIKeyboardInputStringEventArgs(OwnerWriterControl, Document, null, string_8, text);
				OwnerWriterControl.vmethod_14(writerBeforeUIKeyboardInputStringEventArgs);
				if (writerBeforeUIKeyboardInputStringEventArgs.Cancel)
				{
					return null;
				}
				text = writerBeforeUIKeyboardInputStringEventArgs.OutputString;
			}
			return text;
		}

		public bool method_168()
		{
			if (Focused)
			{
				KeyEventArgs e = new KeyEventArgs(Keys.Back);
				OnKeyDown(e);
				return true;
			}
			return false;
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (!base.AcceptsTab && (keyData == Keys.Tab || keyData == (Keys.LButton | Keys.Back | Keys.Shift)))
			{
				return false;
			}
			if (keyData == (Keys.LButton | Keys.MButton | Keys.Back | Keys.Space | Keys.Shift))
			{
				return false;
			}
			return base.IsInputKey(keyData);
		}

		/// <summary>
		///       处理对话框按键事件
		///       </summary>
		/// <param name="keyData">
		/// </param>
		/// <returns>
		/// </returns>
		protected override bool ProcessDialogKey(Keys keyData)
		{
			int num;
			switch (keyData)
			{
			case Keys.LButton | Keys.MButton | Keys.Back | Keys.Space | Keys.Shift:
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				string text = (string)dataObject.GetData(DataFormats.UnicodeText);
				if (!string.IsNullOrEmpty(text))
				{
					method_222(text);
				}
				return false;
			}
			default:
				num = ((keyData != Keys.Down) ? 1 : 0);
				break;
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
				num = 0;
				break;
			}
			if (num == 0)
			{
				return false;
			}
			if (base.AcceptsTab && (keyData == Keys.Tab || keyData == (Keys.LButton | Keys.Back | Keys.Shift)))
			{
				return false;
			}
			return base.ProcessDialogKey(keyData);
		}

		/// <summary>
		///       处理标准Tab键的行为
		///       </summary>
		/// <param name="forward">
		/// </param>
		/// <returns>
		/// </returns>
		protected override bool ProcessTabKey(bool forward)
		{
			return OwnerWriterControl.Parent?.SelectNextControl(OwnerWriterControl, forward, tabStopOnly: true, nested: true, wrap: true) ?? base.ProcessTabKey(forward);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public void method_169(Keys keys_1)
		{
			KeyEventArgs e = new KeyEventArgs(keys_1);
			OnKeyDown(e);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void method_170(char char_0)
		{
			KeyPressEventArgs e = new KeyPressEventArgs(char_0);
			OnKeyPress(e);
		}

		internal void method_171(KeyEventArgs keyEventArgs_0)
		{
			OnKeyDown(keyEventArgs_0);
		}

		internal void method_172(KeyPressEventArgs keyPressEventArgs_0)
		{
			OnKeyPress(keyPressEventArgs_0);
		}

		internal void method_173(KeyEventArgs keyEventArgs_0)
		{
			OnKeyUp(keyEventArgs_0);
		}

		internal bool method_174(Keys keys_1)
		{
			return IsInputKey(keys_1);
		}

		/// <summary>
		///       处理键盘按键按下事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			dateTime_0 = DateTime.Now;
			if (!base.IsHandleCreated)
			{
				return;
			}
			base.OnKeyDown(kevent);
			if (!kevent.Handled)
			{
				OwnerWriterControl.method_39(kevent);
				OwnerWriterControl.method_70(kevent);
			}
			if (kevent.Handled)
			{
				return;
			}
			if (kevent.Modifiers != 0)
			{
			}
			if (xtextDocument_0 == null)
			{
				return;
			}
			if (kevent.KeyCode == Keys.Escape)
			{
				method_166();
				if (DlgSnapshotDelay != null)
				{
					Form dlgSnapshotDelay = DlgSnapshotDelay;
					DlgSnapshotDelay = null;
					dlgSnapshotDelay.Close();
					dlgSnapshotDelay.Dispose();
					kevent.Handled = true;
					return;
				}
				if (IsEditingElementValue)
				{
					method_210();
					kevent.Handled = true;
					return;
				}
				if (currentContentStyleInfo_0 != null)
				{
					method_182();
					return;
				}
				if (ExtViewMode == WriterControlExtViewMode.BoundsSelection)
				{
					ExtViewMode = WriterControlExtViewMode.Normal;
					UpdatePages();
					CommandControler.UpdateBindingControlStatus();
					return;
				}
			}
			DocumentEventArgs documentEventArgs = DocumentEventArgs.CreateKeyDown(Document, kevent);
			Document.HandleDocumentEvent(documentEventArgs);
			if (documentEventArgs.Handled)
			{
				return;
			}
			if (Document.TabIndexManager != null)
			{
				XTextElement xTextElement = Document.TabIndexManager.imethod_1(Document.CurrentElement, kevent.KeyCode, kevent.Shift, kevent);
				if (xTextElement != null)
				{
					IgnoreNextKeyPressEventOnce = true;
					xTextElement.Focus();
					return;
				}
			}
			if (kevent.Handled)
			{
				IgnoreNextKeyPressEventOnce = true;
				return;
			}
			WriterCommand writerCommand = AppHost.CommandContainer.Active(OwnerWriterControl, Document, kevent);
			if (writerCommand != null)
			{
				method_72(writerCommand.Name, bool_47: true, null);
				kevent.Handled = true;
				if (kevent.Control && kevent.KeyCode == Keys.I)
				{
					IgnoreNextKeyPressEventOnce = true;
				}
			}
		}

		[DCInternal]
		public void method_175(int int_15)
		{
			int_10 = Environment.TickCount + int_15;
		}

		/// <summary>
		///       处理键盘字符事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
		{
			int num = 9;
			dateTime_0 = DateTime.Now;
			if (int_10 > 0 && Environment.TickCount < int_10)
			{
				return;
			}
			if (IgnoreNextKeyPressEventOnce)
			{
				IgnoreNextKeyPressEventOnce = false;
			}
			else
			{
				if (!base.IsHandleCreated || base.IsDisposed)
				{
					return;
				}
				base.OnKeyPress(keyPressEventArgs_0);
				if (!keyPressEventArgs_0.Handled)
				{
					OwnerWriterControl.method_40(keyPressEventArgs_0);
					OwnerWriterControl.method_72(keyPressEventArgs_0);
				}
				if (keyPressEventArgs_0.Handled || (keyPressEventArgs_0.KeyChar == '\r' && Control.ModifierKeys == Keys.Shift) || keyPressEventArgs_0.KeyChar == '\b' || keyPressEventArgs_0.KeyChar == '\n' || (keyPressEventArgs_0.KeyChar < ' ' && keyPressEventArgs_0.KeyChar != '\t' && keyPressEventArgs_0.KeyChar != '\r'))
				{
					return;
				}
				if (xtextDocument_0 != null)
				{
					DocumentEventArgs documentEventArgs = DocumentEventArgs.CreateKeyPress(Document, keyPressEventArgs_0);
					Document.HandleDocumentEvent(documentEventArgs);
					if (documentEventArgs.Handled || keyPressEventArgs_0.Handled)
					{
						return;
					}
					if (keyPressEventArgs_0.KeyChar == '\t' && Control.ModifierKeys != Keys.Control && Document.Options.EditOptions.TabKeyToFirstLineIndent && Selection.Length == 0 && DocumentControler.method_17(bool_2: true))
					{
						keyPressEventArgs_0.Handled = true;
						return;
					}
					if (!RuntimeReadonly && DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement), DomAccessFlags.Normal))
					{
						if (!OwnerWriterControl.UIStartEditContent())
						{
							return;
						}
						DocumentContentStyle documentContentStyle = (DocumentContentStyle)Document.CurrentStyleInfo.Content.Clone();
						DocumentControler.AutoUppercaseFirstCharInFirstLineOnce = DocumentOptions.BehaviorOptions.AutoUppercaseFirstCharInFirstLine;
						string text = method_167(keyPressEventArgs_0.KeyChar.ToString());
						XTextElementList xTextElementList = null;
						try
						{
							bool_30 = true;
							Document.FixCurrentStyleInfoForEnter = true;
							if (text != null && (text.IndexOf('\r') >= 0 || text.IndexOf('\n') >= 0 || text.IndexOf('\t') >= 0 || text.IndexOf(' ') >= 0))
							{
								bool_30 = false;
							}
							xTextElementList = DocumentControler.InsertString(text, logUndo: true, InputValueSource.UI, null, null);
						}
						finally
						{
							bool_30 = false;
						}
						if (xTextElementList != null && xTextElementList.Count > 0)
						{
							if (text == "\r" && Document.FixCurrentStyleInfoForEnter)
							{
								Document.CurrentStyleInfo.Content.Font = documentContentStyle.Font;
								Document.CurrentStyleInfo.ContentStyleForNewString.Font = documentContentStyle.Font;
							}
							if (text.Trim().Length == text.Length)
							{
								method_164();
							}
						}
						DocumentControler.AutoUppercaseFirstCharInFirstLineOnce = false;
					}
				}
				keyPressEventArgs_0.Handled = true;
			}
		}

		/// <summary>
		///       处理键盘按钮松开事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnKeyUp(KeyEventArgs kevent)
		{
			dateTime_0 = DateTime.Now;
			if (base.IsHandleCreated)
			{
				IgnoreNextKeyPressEventOnce = false;
				base.OnKeyUp(kevent);
				if (!kevent.Handled)
				{
					OwnerWriterControl.method_41(kevent);
					OwnerWriterControl.method_71(kevent);
				}
				if (!kevent.Handled && xtextDocument_0 != null)
				{
					Document.HandleDocumentEvent(DocumentEventArgs.CreateKeyUp(Document, kevent));
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterViewControl()
		{
			if (documentOptions_0 != null)
			{
				documentOptions_0.SetWriterControl(this);
			}
			SetStyle(ControlStyles.Selectable, value: true);
			SetStyle(ControlStyles.ContainerControl, value: false);
			WriterUtils.smethod_6();
		}

		[ComVisible(false)]
		public void method_176(object object_1)
		{
			if (object_1 != null)
			{
				if (object_1 is IDateTimeService)
				{
					AppHost.Services.AddService(typeof(IDateTimeService), object_1);
				}
				else if (object_1 is IKBProvider)
				{
					AppHost.Services.AddService(typeof(IKBProvider), object_1);
				}
				else if (object_1 is IErrorReporter)
				{
					AppHost.Services.AddService(typeof(IErrorReporter), object_1);
				}
				else if (object_1 is DCUITools)
				{
					AppHost.Services.AddService(typeof(DCUITools), object_1);
				}
				else if (object_1 is IListItemsProvider)
				{
					AppHost.Services.AddService(typeof(IListItemsProvider), object_1);
				}
				else if (object_1 is IListSourceProvider)
				{
					AppHost.Services.AddService(typeof(IListSourceProvider), object_1);
				}
				else if (object_1 is CurrentUserInfo)
				{
					AppHost.Services.AddService(typeof(CurrentUserInfo), object_1);
				}
				else if (object_1 is CurrentDepartmentInfo)
				{
					AppHost.Services.AddService(typeof(CurrentDepartmentInfo), object_1);
				}
				else
				{
					AppHost.Services.AddService(object_1.GetType(), object_1);
				}
			}
		}

		public void method_177(bool bool_47)
		{
			if (AutoSetDocumentDefaultFont)
			{
				method_178(new XFontValue(Font), ForeColor, bool_47);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void method_178(XFontValue xfontValue_1, Color color_3, bool bool_47)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_21) || xtextDocument_0 == null)
			{
				return;
			}
			ContentEffects contentEffects = xtextDocument_0.SetDefaultFont(xfontValue_1, color_3, !ControlLoading);
			if (bool_47 && base.IsHandleCreated)
			{
				switch (contentEffects)
				{
				case ContentEffects.Display:
					Invalidate();
					break;
				case ContentEffects.Layout:
					method_187();
					break;
				}
			}
		}

		[ComVisible(true)]
		public void method_179(string string_8, ListItemCollection listItemCollection_0, bool bool_47)
		{
			ListItemsBuffer.AddItems(string_8, listItemCollection_0, bool_47);
		}

		/// <summary>
		///       控件字体发生改变事件，更新文档的默认字体
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			base.OnFontChanged(eventArgs_0);
			if (!InDesignMode && xtextDocument_0 != null && documentControler_0 != null)
			{
				if (AutoSetDocumentDefaultFont)
				{
					method_177(bool_47: true);
				}
				UpdateTextCaret();
			}
		}

		[ComVisible(true)]
		public void method_180(MoveTarget moveTarget_0)
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveToTarget(moveTarget_0);
			}
		}

		[ComVisible(true)]
		public void method_181(int int_15)
		{
			if (Document != null)
			{
				Document.Content.AutoClearSelection = true;
				Document.Content.MoveToPosition(int_15);
			}
		}

		[Browsable(false)]
		[ComVisible(false)]
		public void method_182()
		{
			currentContentStyleInfo_0 = null;
			Cursor = Cursors.IBeam;
			CommandControler.InvalidateCommandState("FormatBrush");
		}

		internal void method_183()
		{
			int num = 1;
			CurrentContentStyleInfo styleInfoForFormatBrush = StyleInfoForFormatBrush;
			StyleInfoForFormatBrush = null;
			XTextElementList xTextElementList = Class125.smethod_0(Document, bool_0: true, bool_1: true, bool_2: true, Document.DocumentControler);
			if (xTextElementList != null && xTextElementList.Count != 0)
			{
				Document.BeginLogUndo();
				bool flag = XTextSelection.smethod_0(styleInfoForFormatBrush.Content, styleInfoForFormatBrush.Paragraph, styleInfoForFormatBrush.Cell, Document, xTextElementList, bool_1: true, "FormatBrush", bool_2: true);
				Document.EndLogUndo();
				if (flag)
				{
					Document.OnSelectionChanged();
					Document.OnDocumentContentChanged();
					CommandControler.InvalidateCommandState();
				}
			}
		}

		public object method_184(XTextControlHostElement xtextControlHostElement_0)
		{
			int num = 0;
			if (xtextControlHostElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			return xtextControlHostElement_0.vmethod_28();
		}

		public static void smethod_3()
		{
			int num = 18;
			if (!bool_37)
			{
				bool_37 = true;
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				}
				catch (Exception ex)
				{
					Debug.WriteLine("EnableVisualStyles:" + ex.Message);
				}
			}
		}

		/// <summary>
		///       控件加载时的处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			int num = 19;
			bool_36 = true;
			try
			{
				if (!InDesignMode)
				{
					if (!bool_39 && WinFormUtils.GetApplicationStyle(this) != 0)
					{
						smethod_3();
					}
					DocumentOptions.LoadAppConfig();
					documentControler_0 = new DocumentControler();
					myTransform = new Class205();
					base.Pages = Document.Pages;
					base.MouseDragScroll = false;
					if (!string.IsNullOrEmpty(InitalizeParameterValues))
					{
						GClass340 gClass = new GClass340(InitalizeParameterValues);
						foreach (GClass341 item in gClass)
						{
							Document.Parameters.SetValue(item.Name, item.method_0());
						}
					}
					EnableJumpPrint = false;
					JumpPrintPosition = 0f;
					base.MouseDragScroll = false;
					if (AutoSetDocumentDefaultFont)
					{
						method_177(bool_47: false);
					}
					method_187();
					Invalidate();
				}
				base.OnLoad(eventArgs_0);
			}
			finally
			{
				bool_36 = false;
				bool_38 = true;
			}
			Debug.WriteLine("WriterControlLoaded");
		}

		private bool method_185()
		{
			if (!DocumentOptions.BehaviorOptions.EnableCheckControlLoaded)
			{
				return true;
			}
			if (!bool_38)
			{
				MessageBox.Show(this, WriterStringsCore.AlertControlNotLoaded, WriterStringsCore.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return bool_38;
		}

		public DCGraphics method_186()
		{
			Graphics graphics_ = base.vmethod_15();
			DCGraphics dCGraphics = new DCGraphics(graphics_);
			dCGraphics.AutoDisposeNativeGraphics = true;
			return dCGraphics;
		}

		public void method_187()
		{
			method_188(bool_47: true, bool_48: true);
		}

		public void method_188(bool bool_47, bool bool_48)
		{
			int num = 18;
			if (class137_0 != null)
			{
				class137_0.method_3();
			}
			if (ginterface20_0 != null)
			{
				ginterface20_0.imethod_0();
			}
			if (textWindowsFormsEditorHost_0 != null)
			{
				textWindowsFormsEditorHost_0.method_0();
			}
			base.DelaySetAutoScrollMinSize = false;
			xtextElement_0 = null;
			currentContentStyleInfo_0 = null;
			gclass368_0 = null;
			if (!base.IsHandleCreated)
			{
				return;
			}
			ReleaseFreezeUI();
			method_11();
			Document.CheckBoxGroupInfo.method_2();
			Document.ContentStyles.Styles.SetValueLocked(vLock: false);
			if (!GClass354.smethod_3())
			{
				if (DocumentOptions.BehaviorOptions.DebugMode && AppHost.Debuger != null)
				{
					AppHost.Debuger.WriteLine("RefreshDocument RefreshSize=" + bool_47 + " ExecuteLayout=" + bool_48);
				}
				object obj = Document.Selection.method_12();
				try
				{
					Document.bool_19 = true;
					Document.FixDomState();
					XTextElementList tables = Document.Tables;
					foreach (XTextTableElement item in tables)
					{
						if (item.method_40() > 0)
						{
							item.FixDomState();
						}
					}
					tables.Clear();
					tables = null;
					Document.bool_19 = false;
					OwnerWriterControl.EnableCollectOuterReference = false;
					int tickCount = Environment.TickCount;
					float tickCountFloat = CountDown.GetTickCountFloat();
					method_218();
					XTextElement xTextElement = null;
					XTextElement xtextElement_ = null;
					Document.CurrentContentElement.method_59(ref xTextElement, ref xtextElement_);
					Document.method_97(bool_48, bool_33: true);
					GraphicsUnit = Document.DocumentGraphicsUnit;
					if (AutoSetDocumentDefaultFont)
					{
						bool modified = Document.Modified;
						method_177(bool_47: false);
						Document.Modified = modified;
					}
					tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
					using (DCGraphics dcgraphics_ = method_186())
					{
						base.Pages = Document.Pages;
						tickCountFloat = CountDown.GetTickCountFloat();
						if (bool_47)
						{
							ElementLoadEventArgs elementLoadEventArgs = new ElementLoadEventArgs(Document, null);
							elementLoadEventArgs.UpdateValueBinding = false;
							Document.AfterLoad(elementLoadEventArgs);
							Document.RefreshSize(dcgraphics_);
						}
						tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
						tickCountFloat = CountDown.GetTickCountFloat();
						if (bool_48)
						{
							if (RuntimeViewMode == PageViewMode.AutoLine)
							{
								Document.Body.Width = (float)((double)base.ClientSize.Width * base.ClientToViewXRate - 1.0);
								Document.Width = (float)((double)base.ClientSize.Width * base.ClientToViewXRate - 1.0);
								Document.PageViewMode = RuntimeViewMode;
							}
							Document.Pages.Clear();
							Document.ExecuteLayout();
							if (RuntimeViewMode == PageViewMode.AutoLine)
							{
							}
						}
						tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
						DocumentCommentList runtimeComments = Document.RuntimeComments;
						if (runtimeComments != null)
						{
							foreach (DocumentComment item2 in runtimeComments)
							{
								item2.Height = 0f;
								item2.ContentHeight = 0f;
							}
						}
						Document.RefreshPages();
						if (base.AutoZoom)
						{
							method_217(bool_48);
						}
						else
						{
							UpdatePages();
						}
						Document.Selection.method_13(obj);
						Document.Content.method_46();
						if (ControlHostManger != null)
						{
							ControlHostManger.ReloadControls();
						}
						Document.method_40(DomReadyStates.Complete);
						Document.OnSelectionChanged();
						OwnerWriterControl.vmethod_17(new WriterEventArgs(OwnerWriterControl, Document, Document));
						OwnerWriterControl.vmethod_12();
					}
					Invalidate();
					if (ExtViewMode != WriterControlExtViewMode.JumpPrint && ExtViewMode != WriterControlExtViewMode.OffsetJumpPrint)
					{
						bool smoothScrollView = DocumentOptions.BehaviorOptions.SmoothScrollView;
						DocumentOptions.BehaviorOptions.SmoothScrollView = false;
						try
						{
							Document.CurrentContentElement.method_60(xTextElement, xtextElement_);
							UpdateTextCaret();
							method_196();
						}
						finally
						{
							DocumentOptions.BehaviorOptions.SmoothScrollView = smoothScrollView;
						}
					}
					tickCount = Math.Abs(Environment.TickCount - tickCount);
					if (DocumentOptions.BehaviorOptions.DebugMode && AppHost.Debuger != null)
					{
						AppHost.Debuger.WriteLine("RefrehDocument TimeSpan:" + tickCount);
					}
					if (XTextDocument._MULSP > 0)
					{
						Thread.Sleep(Math.Abs(tickCount * XTextDocument._MULSP));
					}
				}
				finally
				{
					Document.bool_19 = true;
					OwnerWriterControl.EnableCollectOuterReference = true;
					if (int_11 > 8)
					{
						method_189(null, null);
					}
					else
					{
						if (int_11 == 0)
						{
							EventHandler method = method_189;
							object[] args = new object[2];
							BeginInvoke(method, args);
						}
						int_11++;
					}
				}
			}
		}

		private void method_189(object sender, EventArgs e)
		{
			int_11 = 0;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.WaitForFullGCComplete();
		}

		internal void method_190()
		{
			int num = 10;
			base.DelaySetAutoScrollMinSize = false;
			if (!base.IsHandleCreated)
			{
				return;
			}
			ReleaseFreezeUI();
			method_11();
			if (!GClass354.smethod_3())
			{
				if (DocumentOptions.BehaviorOptions.DebugMode && AppHost.Debuger != null)
				{
					AppHost.Debuger.WriteLine("UpdateDocumentView");
				}
				float tickCountFloat = CountDown.GetTickCountFloat();
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				method_218();
				GraphicsUnit = Document.DocumentGraphicsUnit;
				if (AutoSetDocumentDefaultFont)
				{
					bool modified = Document.Modified;
					method_177(bool_47: false);
					Document.Modified = modified;
				}
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
				if (RuntimeViewMode == PageViewMode.AutoLine)
				{
					Document.Body.Width = (float)((double)base.ClientSize.Width * base.ClientToViewXRate - 1.0);
					Document.Width = (float)((double)base.ClientSize.Width * base.ClientToViewXRate - 1.0);
					Document.PageViewMode = RuntimeViewMode;
				}
				Document.ExecuteLayout();
				if (RuntimeViewMode != PageViewMode.AutoLine)
				{
				}
				Document.RefreshPages();
				if (base.AutoZoom)
				{
					method_217(bool_47: true);
				}
				else
				{
					UpdatePages();
				}
				Document.Content.method_46();
				ControlHostManger.ReloadControls();
				Document.method_40(DomReadyStates.Complete);
				Document.OnSelectionChanged();
				OwnerWriterControl.vmethod_17(new WriterEventArgs(OwnerWriterControl, Document, Document));
				OwnerWriterControl.vmethod_12();
				Invalidate();
				if (ExtViewMode != WriterControlExtViewMode.JumpPrint && ExtViewMode != WriterControlExtViewMode.OffsetJumpPrint)
				{
					bool smoothScrollView = DocumentOptions.BehaviorOptions.SmoothScrollView;
					DocumentOptions.BehaviorOptions.SmoothScrollView = false;
					try
					{
						UpdateTextCaret();
						method_196();
					}
					finally
					{
						DocumentOptions.BehaviorOptions.SmoothScrollView = smoothScrollView;
					}
				}
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				if (DocumentOptions.BehaviorOptions.DebugMode && AppHost.Debuger != null)
				{
					AppHost.Debuger.WriteLine("UpdateDocumentView TimeSpan:" + tickCountFloat);
				}
			}
		}

		private void method_191()
		{
			if (RuntimeViewMode == PageViewMode.AutoLine)
			{
				Document.Body.Width = (float)((double)base.ClientSize.Width * base.ClientToViewXRate);
				Document.Width = (float)((double)base.ClientSize.Width * base.ClientToViewXRate);
				Document.PageViewMode = RuntimeViewMode;
			}
			else
			{
				Document.Body.Width = Document.PageSettings.ViewClientWidth;
				Document.Width = Document.PageSettings.ViewClientWidth;
			}
			Document.ExecuteLayout();
			if (RuntimeViewMode != PageViewMode.AutoLine)
			{
				Document.RefreshPages();
			}
		}

		public override void UpdatePages()
		{
			if (InDesignMode || !base.IsHandleCreated || Document == null)
			{
				return;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			base.Pages = Document.Pages;
			base.UpdatePages();
			PageContentPartyStyle pageContentPartyStyle = PageContentPartyStyle.Body;
			if (Document.CurrentContentElement != null)
			{
				pageContentPartyStyle = Document.CurrentContentElement.PagePartyStyle;
			}
			foreach (SimpleRectangleTransform item in base.PagesTransform)
			{
				if (ExtViewMode == WriterControlExtViewMode.BoundsSelection)
				{
					item.setEnable(bool_3: false);
				}
				else
				{
					item.setEnable(item.method_0() == pageContentPartyStyle);
				}
			}
			if (base.CurrentTransformItem != null)
			{
				bool flag = false;
				foreach (SimpleRectangleTransform item2 in base.PagesTransform)
				{
					if (item2.method_10() == base.CurrentTransformItem.method_10() && item2.method_12() == base.CurrentTransformItem.method_12() && item2.method_0() == item2.method_0())
					{
						base.CurrentTransformItem = item2;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					base.CurrentTransformItem = null;
				}
			}
			foreach (SimpleRectangleTransform item3 in base.PagesTransform)
			{
				if (DrawerUtil.IsHeaderFooter(item3.method_0()))
				{
					item3.setEnable(item3 == base.CurrentTransformItem);
				}
			}
			if (ControlHostManger != null)
			{
				ControlHostManger.UpdateHostWindowsControlPositionAsynic();
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_192()
		{
			int num = 5;
			if (base.IsDisposed)
			{
				throw new ObjectDisposedException("WriterViewControl");
			}
			if (!base.IsHandleCreated)
			{
				CreateControl();
			}
		}

		public object method_193(string string_8)
		{
			int num = 6;
			method_192();
			object result = null;
			if (Document.Options.BehaviorOptions.EnableScript)
			{
				IDocumentScriptEngine documentScriptEngine = Document.method_45();
				string text = "F" + Environment.TickCount;
				string text3 = documentScriptEngine.ScriptText = "Function " + text + "\r\n" + string_8 + "\r\n End Function";
				result = documentScriptEngine.Execute(text, null, ThrowException: false);
				documentScriptEngine.Dispose();
			}
			return result;
		}

		public void method_194(XTextElement xtextElement_1, string string_8)
		{
		}

		public override Point ViewPointToClient(int int_15, int int_16)
		{
			if (base.CurrentTransformItem == null)
			{
				return base.ViewPointToClient(int_15, int_16);
			}
			return base.CurrentTransformItem.UnTransformPoint(int_15, int_16);
		}

		public override Point ClientPointToView(int int_15, int int_16)
		{
			if (base.CurrentTransformItem == null)
			{
				return base.ClientPointToView(int_15, int_16);
			}
			return base.CurrentTransformItem.TransformPoint(int_15, int_16);
		}

		[ComVisible(true)]
		public void method_195(float float_2)
		{
			if (float_2 <= 0f)
			{
				float_2 = 0f;
			}
			if (float_2 > Document.Body.Height)
			{
				float_2 = Document.Body.Height - 1f;
			}
			method_31(0, (int)float_2, 10, 10, ScrollToViewStyle.Middle);
		}

		public void method_196()
		{
			method_197(ScrollToViewStyle.Normal);
		}

		public void method_197(ScrollToViewStyle scrollToViewStyle_0)
		{
			if (xtextDocument_0 == null || base.IsUpdating)
			{
				return;
			}
			method_192();
			XTextDocumentContentElement currentContentElement = Document.CurrentContentElement;
			XTextElement currentElement = currentContentElement.Content.CurrentElement;
			if (currentElement == null)
			{
				return;
			}
			if (currentContentElement.Content.LineEndFlag)
			{
				XTextElement xTextElement = currentContentElement.Content.GetPreElement(currentElement);
				if (xTextElement == null)
				{
					xTextElement = currentElement;
				}
				if (xTextElement != null)
				{
					method_31((int)(xTextElement.AbsLeft + xTextElement.Width - 1f), (int)xTextElement.AbsTop, InsertMode ? TextPageViewControl.int_6 : TextPageViewControl.int_7, (int)xTextElement.Height, scrollToViewStyle_0);
				}
			}
			else
			{
				method_31((int)currentElement.AbsLeft, (int)currentElement.AbsTop, InsertMode ? TextPageViewControl.int_6 : TextPageViewControl.int_7, (int)currentElement.Height, scrollToViewStyle_0);
			}
		}

		private void method_198()
		{
			if (base.InvokeRequired)
			{
				throw new Exception(WriterStringsCore.InvokeRequired);
			}
		}

		public void UpdateTextCaret(XTextElement xtextElement_1)
		{
			if (base.IsUpdating || Document == null || base.InvokeRequired || xtextElement_1 == null || xtextElement_1.OwnerLine == null)
			{
				return;
			}
			float num = 3.125f;
			float num2 = xtextElement_1.OwnerLine.AbsTop;
			if (xtextElement_1.Height > xtextElement_1.OwnerLine.Height)
			{
				num2 += xtextElement_1.OwnerLine.Height;
			}
			XTextDocumentContentElement currentContentElement = Document.CurrentContentElement;
			XTextElement xTextElement;
			float num3;
			float num4;
			if (currentContentElement.Content.LineEndFlag)
			{
				switch (xtextElement_1.OwnerLine.method_21(xtextElement_1))
				{
				case ContentLayoutDirectionStyle.RightToLeft:
					xTextElement = currentContentElement.Content.GetPreElement(xtextElement_1);
					if (xTextElement == null)
					{
						xTextElement = xtextElement_1;
					}
					if (xTextElement == null)
					{
						break;
					}
					num3 = xTextElement.Height;
					num4 = xTextElement.AbsTop;
					if (xTextElement.OwnerLine != null)
					{
						num4 = Math.Max(num4, xTextElement.OwnerLine.AbsTop);
						num3 = Math.Min(num3, xTextElement.OwnerLine.Height);
					}
					if (HideCaretWhenHasSelection && Selection.Length != 0)
					{
						method_58();
						method_28((int)xTextElement.AbsLeft, (int)Math.Max(num2, num4 + num3 + num), (int)xTextElement.Width, (int)num3);
						break;
					}
					if (Focused || base.ForceShowCaret)
					{
						ShowCaret();
					}
					MoveTextCaretTo((int)xTextElement.AbsLeft, (int)Math.Max(num2, num4 + num3 + num), (int)num3, 0);
					break;
				case ContentLayoutDirectionStyle.LeftToRight:
					xTextElement = currentContentElement.Content.GetPreElement(xtextElement_1);
					if (xTextElement == null)
					{
						xTextElement = xtextElement_1;
					}
					if (xTextElement == null)
					{
						break;
					}
					num3 = xTextElement.Height;
					num4 = xTextElement.AbsTop;
					if (xTextElement.OwnerLine != null)
					{
						num4 = Math.Max(num4, xTextElement.OwnerLine.AbsTop);
						num3 = Math.Min(num3, xTextElement.OwnerLine.Height);
					}
					if (HideCaretWhenHasSelection && Selection.Length != 0)
					{
						method_58();
						method_28((int)xTextElement.AbsLeft, (int)Math.Max(num2, xTextElement.AbsTop + num3), (int)xTextElement.Width, (int)num3);
						break;
					}
					if (Focused || base.ForceShowCaret)
					{
						ShowCaret();
					}
					MoveTextCaretTo((int)(xTextElement.AbsLeft + xTextElement.Width - 1f), (int)Math.Max(num2, num4 + num3 + num), (int)num3, (int)xTextElement.Width);
					break;
				}
				return;
			}
			int num5 = 0;
			xTextElement = xtextElement_1;
			XTextLine ownerLine = xtextElement_1.OwnerLine;
			if (ownerLine != null)
			{
				xTextElement = ownerLine.GetPreElement(xtextElement_1);
				if (xTextElement == null)
				{
					xTextElement = xtextElement_1;
				}
				else if (xTextElement is XTextShadowElement || xTextElement is XTextTableElement || xTextElement is XTextSectionElement)
				{
					xTextElement = xtextElement_1;
					num5 = 10;
				}
			}
			if (HideCaretWhenHasSelection && Selection.Length != 0)
			{
				method_58();
				if (base.MoveCaretWithScroll)
				{
					method_28((int)xtextElement_1.AbsLeft, (int)xtextElement_1.AbsTop, (int)xtextElement_1.Width, (int)xtextElement_1.Height);
				}
				return;
			}
			if (Focused || base.ForceShowCaret)
			{
				ShowCaret();
			}
			num3 = xTextElement.Height;
			num4 = xTextElement.AbsTop;
			if (xTextElement.OwnerLine != null)
			{
				num4 = Math.Max(num4, xTextElement.OwnerLine.AbsTop);
				num3 = Math.Min(num3, xTextElement.OwnerLine.Height);
			}
			float absLeft = xtextElement_1.AbsLeft;
			if (xTextElement.OwnerLine != null)
			{
			}
			_ = xTextElement.OwnerLine.RuntimeLayoutDirection;
			if (xtextElement_1.IsRightToLeft)
			{
				MoveTextCaretTo((int)(absLeft + xtextElement_1.Width - (float)num5), (int)Math.Max(num2, num4 + num3 + num), (int)num3, 0);
			}
			else
			{
				MoveTextCaretTo((int)absLeft + num5, (int)Math.Max(num2, num4 + num3 + num), (int)num3, (int)xtextElement_1.Width);
			}
		}

		public void UpdateTextCaret()
		{
			if (xtextDocument_0 != null && documentControler_0 != null && xtextDocument_0.DocumentControler != null && !base.IsFreezeUI && Document.States.Layouted)
			{
				Document.Content.method_46();
				float tickCountFloat = CountDown.GetTickCountFloat();
				UpdateTextCaret(Document.CurrentElement);
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			}
		}

		public void method_201()
		{
			if (!base.IsUpdating && Document != null)
			{
				bool moveCaretWithScroll = base.MoveCaretWithScroll;
				base.MoveCaretWithScroll = false;
				UpdateTextCaret(Document.CurrentElement);
				base.MoveCaretWithScroll = moveCaretWithScroll;
			}
		}

		public void method_202()
		{
			Document.Content.SelectAll();
			UpdateTextCaret();
		}

		public bool method_203(bool bool_47)
		{
			return DocumentControler.method_7(bool_47);
		}

		public bool method_204()
		{
			return DocumentControler.method_9();
		}

		public void method_205()
		{
			method_155(null, bool_47: true);
		}

		public void method_206()
		{
			if (XTextDocument.smethod_13(GEnum6.const_55) && Document.UndoList != null)
			{
				GEventArgs3 geventArgs3_ = new GEventArgs3();
				Document.UndoList.method_7(geventArgs3_);
			}
		}

		public void method_207()
		{
			if (XTextDocument.smethod_13(GEnum6.const_56) && Document.UndoList != null)
			{
				GEventArgs3 geventArgs3_ = new GEventArgs3();
				Document.UndoList.method_8(geventArgs3_);
			}
		}

		public void method_208(bool bool_47)
		{
			DocumentControler.Delete(bool_47);
		}

		public override bool UpdateCurrentPage()
		{
			XTextLine currentLine = Document.CurrentContentElement.CurrentLine;
			if (currentLine != null)
			{
				PrintPage ownerPage = currentLine.OwnerPage;
				return method_36(ownerPage);
			}
			return base.UpdateCurrentPage();
		}

		public void method_209(XTextElement xtextElement_1)
		{
			if (xtextElement_1 == null)
			{
				xtextElement_1 = CurrentElement;
			}
			DocumentEventArgs documentEventArgs = new DocumentEventArgs(Document, xtextElement_1, DocumentEventStyles.DefaultEditMethod);
			while (xtextElement_1 != null)
			{
				documentEventArgs.Element = xtextElement_1;
				xtextElement_1.HandleDocumentEvent(documentEventArgs);
				if (documentEventArgs.Handled)
				{
					break;
				}
				xtextElement_1 = xtextElement_1.Parent;
			}
			if (!documentEventArgs.Handled)
			{
				method_214();
			}
		}

		public bool method_210()
		{
			if (EditorHost != null && EditorHost.CurrentEditContext != null)
			{
				EditorHost.CancelEditValue();
				return true;
			}
			return false;
		}

		[ComVisible(true)]
		public bool method_211(string string_8)
		{
			XTextElement xTextElement = method_247(string_8);
			if (xTextElement != null)
			{
				return method_212(xTextElement);
			}
			return false;
		}

		[ComVisible(true)]
		public bool method_212(XTextElement xtextElement_1)
		{
			return method_213(xtextElement_1, bool_47: false, ValueEditorActiveMode.Program, bool_48: false, bool_49: true);
		}

		internal bool method_213(XTextElement xtextElement_1, bool bool_47, ValueEditorActiveMode valueEditorActiveMode_0, bool bool_48, bool bool_49)
		{
			int num = 18;
			if (RuntimeReadonly)
			{
				return false;
			}
			if (DocumentOptions.BehaviorOptions.DesignMode)
			{
				return false;
			}
			if (!DocumentOptions.BehaviorOptions.EnableEditElementValue)
			{
				if (DocumentOptions.BehaviorOptions.SpecifyDebugMode)
				{
					MessageBox.Show(this, "EnableEditElementValue=false");
				}
				return false;
			}
			if (EditorHost.EditingValue)
			{
				if (DocumentOptions.BehaviorOptions.SpecifyDebugMode)
				{
					MessageBox.Show(this, "EditorHost.EditingValue=true");
				}
				return false;
			}
			if (!GClass354.smethod_3())
			{
			}
			method_192();
			if (xtextElement_1 == null)
			{
				return false;
			}
			if (base.Capture)
			{
				base.Capture = false;
			}
			Document.MouseCapture = null;
			ElementValueEditor elementValueEditor = null;
			while (xtextElement_1 != null)
			{
				if (!xtextElement_1.IsLogicDeleted)
				{
					elementValueEditor = AppHost.Tools.CreateElementValueEditor(xtextElement_1);
					if (elementValueEditor != null && elementValueEditor.GetType().Name == "XTextInputFieldElementNumericValueEditor" && !DocumentOptions.BehaviorOptions.EnableCalculateControl)
					{
						elementValueEditor = null;
					}
					if (elementValueEditor != null)
					{
						if (!(xtextElement_1 is XTextInputFieldElement))
						{
							break;
						}
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xtextElement_1;
						if (!bool_48 || (valueEditorActiveMode_0 & xTextInputFieldElement.RuntimeEditorActiveMode) == valueEditorActiveMode_0)
						{
							break;
						}
					}
				}
				xtextElement_1 = xtextElement_1.Parent;
			}
			if (xtextElement_1 == null)
			{
				return false;
			}
			if (!DocumentControler.CanModifyContent(xtextElement_1, DomAccessFlags.CheckControlReadonly | DomAccessFlags.CheckReadonly | DomAccessFlags.CheckPermission | DomAccessFlags.CheckFormView | DomAccessFlags.CheckLock | DomAccessFlags.CheckContentProtect))
			{
				return false;
			}
			if (bool_47)
			{
				return elementValueEditor != null && DocumentControler.CanModify(xtextElement_1, DomAccessFlags.None);
			}
			if (elementValueEditor != null)
			{
				if (!DocumentControler.CanModify(xtextElement_1, DomAccessFlags.None))
				{
					return false;
				}
				bool flag = true;
				if (CurrentElement != null)
				{
					XTextElementList xTextElementList = WriterUtils.smethod_58(CurrentElement);
					if (xTextElementList.Contains(xtextElement_1))
					{
						flag = false;
					}
				}
				if (flag)
				{
					Document.Content.AutoClearSelection = true;
					Document.Content.method_47(xtextElement_1.FirstContentElementInPublicContent.ViewIndex, 0);
				}
				if (EditorHost.CurrentEditContext != null)
				{
					EditorHost.CancelEditValue();
				}
				EditorHost.KeepWriterControlFocused = false;
				ElementValueEditResult elementValueEditResult = EditorHost.EditValue(xtextElement_1, elementValueEditor);
				if (elementValueEditResult == ElementValueEditResult.UserAccept)
				{
					OwnerWriterControl.method_14(xtextElement_1);
				}
				if (elementValueEditResult != 0)
				{
				}
				return true;
			}
			return false;
		}

		public bool method_214()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_219))
			{
				return false;
			}
			method_192();
			if (RuntimeReadonly)
			{
				return false;
			}
			return AppHost.Tools.CreateKBInserter(OwnerWriterControl)?.imethod_1() ?? false;
		}

		public bool method_215(string string_8)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_219))
			{
				return false;
			}
			method_192();
			if (RuntimeReadonly)
			{
				return false;
			}
			GInterface8 gInterface = AppHost.Tools.CreateKBInserter(OwnerWriterControl);
			if (gInterface == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(string_8))
			{
				return gInterface.imethod_1();
			}
			return gInterface.imethod_0(string_8);
		}

		/// <summary>
		///       处理控件视图滚动事件
		///       </summary>
		/// <param name="se">事件参数</param>
		protected override void OnScroll(ScrollEventArgs scrollEventArgs_0)
		{
			base.OnScroll(scrollEventArgs_0);
			if (xtextDocument_0 != null)
			{
				method_166();
				if (IsEditingElementValue)
				{
					EditorHost.CancelEditValue();
				}
			}
		}

		internal SimpleRectangleTransform method_216(float float_2, float float_3)
		{
			if (base.CurrentTransformItem != null && base.CurrentTransformItem.method_25().Contains(float_2, float_3))
			{
				return base.CurrentTransformItem;
			}
			return base.PagesTransform.method_11(float_2, float_3);
		}

		/// <summary>
		///       控件大小改变事件处理
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnResize(EventArgs eventArgs_0)
		{
			if (!base.DisableResizeEvent)
			{
				method_55(eventArgs_0);
				if (base.IsHandleCreated && !InDesignMode && !InDesignMode && base.IsHandleCreated && xtextDocument_0 != null)
				{
					bool smoothScrollView = DocumentOptions.BehaviorOptions.SmoothScrollView;
					DocumentOptions.BehaviorOptions.SmoothScrollView = false;
					try
					{
						base.DelaySetAutoScrollMinSize = true;
						if (base.AutoZoom)
						{
							base.HorizontalScroll.Visible = false;
							method_217(bool_47: false);
						}
						else
						{
							if (RuntimeViewMode == PageViewMode.AutoLine)
							{
								base.HorizontalScroll.Visible = false;
								method_191();
								UpdateViewBounds();
							}
							base.HorizontalScroll.Visible = true;
							UpdatePages();
							RefreshScaleTransform();
							if (ExtViewMode != WriterControlExtViewMode.JumpPrint && ExtViewMode != WriterControlExtViewMode.OffsetJumpPrint)
							{
								UpdateTextCaret();
							}
							if (ControlHostManger != null)
							{
								ControlHostManger.UpdateHostWindowsControlPosition();
							}
						}
					}
					finally
					{
						DocumentOptions.BehaviorOptions.SmoothScrollView = smoothScrollView;
						base.DelaySetAutoScrollMinSize = false;
					}
				}
			}
		}

		public override void Zoom(float float_2)
		{
			if (XTextDocument.smethod_13(GEnum6.const_120))
			{
				if (float_2 <= 0f)
				{
					float_2 = 1f;
				}
				float_2 = OwnerWriterControl.method_24(float_2);
				_XZoomRate = float_2;
				_YZoomRate = float_2;
				if (RuntimeViewMode == PageViewMode.AutoLine)
				{
					method_191();
				}
				UpdateViewBounds();
				Invalidate();
			}
		}

		public void method_217(bool bool_47)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_121) || GClass354.smethod_3())
			{
				return;
			}
			float num = GraphicsUnitConvert.Convert(ContentViewWidth, Document.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			int num2 = base.ClientSize.Width;
			if (base.BorderStyle == BorderStyle.None)
			{
				num2 = base.Width;
			}
			else if (base.BorderStyle == BorderStyle.FixedSingle)
			{
				num2 = base.Width - 2;
			}
			else if (base.BorderStyle == BorderStyle.Fixed3D)
			{
				num2 = base.Width - SystemInformation.Border3DSize.Width;
			}
			num2 -= SystemInformation.VerticalScrollBarWidth;
			float float_ = (float)num2 / num;
			float_ = OwnerWriterControl.method_24(float_);
			if (float_ != base.XZoomRate || bool_47)
			{
				Zoom(float_);
				if (RuntimeViewMode == PageViewMode.AutoLine)
				{
					method_191();
				}
				else
				{
					UpdatePages();
				}
				UpdateTextCaret();
				ControlHostManger.UpdateHostWindowsControlPosition();
				OwnerWriterControl.vmethod_36(new WriterEventArgs(OwnerWriterControl, Document, null));
			}
		}

		private void method_218()
		{
			if (RightToLeft == RightToLeft.Yes)
			{
				DocumentOptions.ViewOptions.LayoutDirection = ContentLayoutDirectionStyle.RightToLeft;
			}
			else
			{
				DocumentOptions.ViewOptions.LayoutDirection = ContentLayoutDirectionStyle.LeftToRight;
			}
		}

		/// <summary>
		///       处理排版方向发生改变事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (xtextDocument_0 != null)
			{
				method_218();
				Document.ExecuteLayout();
				Document.RefreshPages();
				UpdatePages();
				Document.Content.method_46();
				UpdateTextCaret();
				ControlHostManger.ReloadControls();
				Document.OnSelectionChanged();
			}
		}

		/// <summary>
		///       处理控件获得焦点事件,刷新光标
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnGotFocus(EventArgs eventArgs_0)
		{
			base.OnGotFocus(eventArgs_0);
			if (!base.IsHandleCreated || xtextDocument_0 == null || base.IsFreezeUI)
			{
				return;
			}
			if (int_12 > 0)
			{
				int_12 = 0;
			}
			if (ExtViewMode == WriterControlExtViewMode.JumpPrint || ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint || ExtViewMode == WriterControlExtViewMode.BoundsSelection)
			{
				return;
			}
			if (!JumpPrint.Enabled || JumpPrint.PageIndex < 0)
			{
				if (DocumentOptions.BehaviorOptions.AutoScrollToCaretWhenGotFocus)
				{
					bool flag = bool_40;
					bool_40 = true;
					try
					{
						UpdateTextCaret();
					}
					finally
					{
						bool_40 = flag;
					}
				}
				else
				{
					method_201();
				}
			}
			if (!IsEditingElementValue && Document != null && RaiseDocumentFoucsEventWhenControlFocusEvent)
			{
				Document.method_51();
			}
		}

		/// <summary>
		///       处理控件失去焦点事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			int num = 12;
			new GClass244(this);
			base.OnLostFocus(eventArgs_0);
			if (base.IsDisposed || !base.IsHandleCreated)
			{
				return;
			}
			if (ginterface19_0 != null && !AssistStringListForm.LoadingList && !AssistStringListForm.Focused)
			{
				AssistStringListForm.imethod_6();
			}
			if (!base.IsFreezeUI && xtextDocument_0 != null && !IsEditingElementValue)
			{
				if (RaiseDocumentFoucsEventWhenControlFocusEvent)
				{
					Document.method_52();
				}
				Document.method_53();
			}
			try
			{
				if (int_12 == 0)
				{
					StackTrace stackTrace = new StackTrace();
					int frameCount = stackTrace.FrameCount;
					int num2 = 0;
					while (true)
					{
						if (num2 >= frameCount)
						{
							return;
						}
						StackFrame frame = stackTrace.GetFrame(num2);
						MethodBase method = frame.GetMethod();
						Type declaringType = method.DeclaringType;
						if (declaringType != null)
						{
							if (method.Name == "Show" && declaringType.Equals(typeof(MessageBox)))
							{
								int_12 = Environment.TickCount;
								return;
							}
							if (method.Name == "ShowDialog")
							{
								break;
							}
						}
						num2++;
					}
					int_12 = Environment.TickCount;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Get ShowDialogTick:" + ex.Message);
				int_12 = -1;
			}
		}

		/// <summary>
		///       选择控件
		///       </summary>
		/// <param name="directed">
		/// </param>
		/// <param name="forward">
		/// </param>
		protected override void Select(bool directed, bool forward)
		{
		}

		internal void method_219(ref Message message_0)
		{
			WndProc(ref message_0);
		}

		/// <summary>
		///       处理底层消息
		///       </summary>
		/// <param name="m">
		/// </param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message message_0)
		{
			try
			{
				method_220(ref message_0);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		private void method_220(ref Message message_0)
		{
			if (!base.IsHandleCreated)
			{
				base.WndProc(ref message_0);
			}
			else if (message_0.Msg == 135)
			{
				message_0.Result = new IntPtr(65535);
			}
			else
			{
				if (OwnerWriterControl == null || (OwnerWriterControl != null && OwnerWriterControl.LocalMessageFilters != null && OwnerWriterControl.LocalMessageFilters.PreFilterMessage(ref message_0)))
				{
					return;
				}
				Msgs msg = (Msgs)message_0.Msg;
				if (msg != Msgs.WM_CTLCOLORSCROLLBAR)
				{
				}
				if (msg != Msgs.WM_NCPAINT)
				{
				}
				if (OwnerWriterControl.IsAxControl)
				{
					if (message_0.Msg == 7)
					{
						OnEnter(EventArgs.Empty);
					}
					else if (message_0.Msg == 528 && (message_0.WParam.ToInt32() == 513 || message_0.WParam.ToInt32() == 516))
					{
						if (!base.ContainsFocus)
						{
							OnEnter(EventArgs.Empty);
						}
					}
					else if (message_0.Msg == 2 && !base.IsDisposed && !base.Disposing)
					{
						Dispose();
					}
				}
				if (message_0.Msg != 256)
				{
				}
				if (message_0.Msg == 135)
				{
					message_0.Result = new IntPtr(65535);
					return;
				}
				if (message_0.Msg == 74)
				{
					GClass246 gClass = new GClass246();
					gClass.method_1(base.Handle);
					if (gClass.method_6())
					{
						Class111.Invoke(OwnerWriterControl, (GEnum15)gClass.method_2(), gClass.method_4());
						return;
					}
				}
				if (message_0.Msg == 7 || message_0.Msg == 6 || message_0.Msg == 28)
				{
					base.ActiveControl = null;
					Focus();
					if (base.Controls.Count > 0)
					{
						OnGotFocus(EventArgs.Empty);
					}
					else
					{
						base.WndProc(ref message_0);
					}
					return;
				}
				Msgs msg2 = (Msgs)message_0.Msg;
				switch (msg2)
				{
				case Msgs.WM_IME_CHAR:
					if (stringBuilder_0 == null)
					{
						stringBuilder_0 = new StringBuilder();
					}
					stringBuilder_0.Append((char)(int)message_0.WParam);
					return;
				case Msgs.WM_PASTE:
				{
					string text = Clipboard.GetText();
					if (!string.IsNullOrEmpty(text))
					{
						DocumentControler.InsertString(text, logUndo: true, InputValueSource.UI, null, null);
					}
					return;
				}
				}
				if (stringBuilder_0 != null && stringBuilder_0.Length > 0)
				{
					string string_ = stringBuilder_0.ToString();
					stringBuilder_0 = null;
					method_222(string_);
				}
				if (msg2 == Msgs.WM_LBUTTONDOWN && Class103.smethod_5())
				{
					EventHandler method = method_221;
					object[] args = new object[2];
					BeginInvoke(method, args);
				}
				if (JumpPrint == null || !JumpPrint.Enabled || JumpPrint.PageIndex < 0)
				{
					IImmProvider immProvider = AppHost.Tools.CreateImmProvider(OwnerWriterControl);
					if (immProvider != null && immProvider.IsWM_IME_NOTIFY_IMN_SETOPENSTATUS(message_0) && (!JumpPrint.Enabled || JumpPrint.PageIndex < 0))
					{
						BeginInvoke(new VoidEventHandler(method_201));
					}
				}
				base.WndProc(ref message_0);
			}
		}

		private void method_221(object sender, EventArgs e)
		{
			try
			{
				if (xtextDocument_0 != null)
				{
					xtextDocument_0.Modified = false;
				}
				GClass244 gClass = new GClass244(base.Handle);
				List<GClass244> list = new List<GClass244>();
				while (gClass != null && list.Count < 20)
				{
					list.Add(gClass);
					gClass = gClass.method_23();
				}
				list.Reverse();
				foreach (GClass244 item in list)
				{
					item.method_33();
				}
			}
			catch (Exception)
			{
			}
		}

		internal void method_222(string string_8)
		{
			if (string.IsNullOrEmpty(string_8))
			{
				return;
			}
			string_8 = method_167(string_8);
			if (string.IsNullOrEmpty(string_8) || !OwnerWriterControl.UIStartEditContent() || RuntimeReadonly || !DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextCharElement), DomAccessFlags.Normal))
			{
				return;
			}
			DocumentEventArgs documentEventArgs = DocumentEventArgs.CreateKeyPress(Document, string_8[0]);
			Document.HandleDocumentEvent(documentEventArgs);
			if (!documentEventArgs.Handled)
			{
				DocumentControler.AutoUppercaseFirstCharInFirstLineOnce = DocumentOptions.BehaviorOptions.AutoUppercaseFirstCharInFirstLine;
				XTextElementList xTextElementList = null;
				try
				{
					bool_30 = true;
					xTextElementList = DocumentControler.InsertString(string_8, logUndo: true, InputValueSource.UI, null, null);
				}
				finally
				{
					bool_30 = false;
				}
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					method_164();
				}
			}
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		/// <param name="disposing">
		/// </param>
		protected override void Dispose(bool disposing)
		{
			method_163();
			method_129();
			if (class128_0 != null)
			{
				class128_0.method_0();
				class128_0 = null;
			}
			bool_43 = true;
			if (documentOptions_0 != null)
			{
				documentOptions_0.InnerDispose();
				documentOptions_0 = null;
			}
			gclass368_0 = null;
			if (class137_0 != null)
			{
				class137_0.method_2();
				class137_0 = null;
			}
			OwnerWriterControl = null;
			method_129();
			if (writerCommandControler_0 != null)
			{
				if (writerCommandControler_0.EditControl == OwnerWriterControl)
				{
					writerCommandControler_0.EditControl = null;
				}
				writerCommandControler_0 = null;
			}
			if (xtextDocument_0 != null && xtextDocument_0.EditorControl == OwnerWriterControl)
			{
				xtextDocument_0.EditorControl = null;
			}
			if (AutoDisposeDocument && xtextDocument_0 != null)
			{
				xtextDocument_0.Dispose();
				xtextDocument_0 = null;
			}
			documentControler_0 = null;
			documentOptions_0 = null;
			xtextElement_0 = null;
			if (icontextMenuStripManager_0 != null)
			{
				if (AutoDisposeContextMenu)
				{
					icontextMenuStripManager_0.Dispose();
				}
				icontextMenuStripManager_0 = null;
			}
			if (contextMenuStrip_0 != null)
			{
				if (AutoDisposeContextMenu)
				{
					contextMenuStrip_0.Dispose();
				}
				contextMenuStrip_0 = null;
			}
			if (dclistItemCollectionBuffer_0 != null)
			{
				dclistItemCollectionBuffer_0 = null;
			}
			object_0 = null;
			dclistItemCollectionBuffer_0 = null;
			if (toolTip_0 != null)
			{
				toolTip_0.Dispose();
			}
			if (dictionary_0 != null)
			{
				dictionary_0.Clear();
				dictionary_0 = null;
			}
			if (gclass255_0 != null)
			{
				gclass255_0.method_1();
				gclass255_0 = null;
			}
			if (textWindowsFormsEditorHost_0 != null)
			{
				textWindowsFormsEditorHost_0.Dispose();
				textWindowsFormsEditorHost_0 = null;
			}
			if (elementEventTemplateList_0 != null)
			{
				foreach (ElementEventTemplate item in elementEventTemplateList_0)
				{
					item.Dispose();
				}
				elementEventTemplateList_0 = null;
			}
			if (elementEventTemlateMap_0 != null)
			{
				foreach (ElementEventTemplate value in elementEventTemlateMap_0.Values)
				{
					value.Dispose();
				}
				elementEventTemlateMap_0 = null;
			}
			base.Dispose(disposing);
			writerControl_0 = null;
			documentNavigator_0 = null;
			idataObject_1 = null;
			writerAppHost_0 = null;
			userLoginInfo_0 = null;
			writerCommandControler_0 = null;
			dictionary_0 = null;
			ginterface9_0 = null;
			icontextMenuStripManager_0 = null;
			ginterface20_0 = null;
			timer_2 = null;
			dlgPrepareScreenSnapshot_0 = null;
			documentControler_0 = null;
			documentOptions_0 = null;
			xtextElement_0 = null;
			textWindowsFormsEditorHost_0 = null;
			elementEventTemplateList_0 = null;
			elementEventTemlateMap_0 = null;
			stringBuilder_0 = null;
			class128_0 = null;
			jumpPrintInfo_0 = null;
			printResult_0 = null;
			dclistItemCollectionBuffer_0 = null;
			idataObject_1 = null;
			gclass435_1 = null;
			documentNavigator_0 = null;
			writerControl_0 = null;
			list_0 = null;
			object_0 = null;
			currentContentStyleInfo_0 = null;
			timer_1 = null;
			toolTip_0 = null;
			gclass97_0 = null;
			gclass255_0 = null;
			userTrackInfoList_0 = null;
		}

		/// <summary>
		///       准备验证数据
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnValidating(CancelEventArgs cancelEventArgs_0)
		{
			base.OnValidating(cancelEventArgs_0);
			if (!base.IsDisposed && xtextDocument_0 != null && OwnerWriterControl != null && DocumentOptions.EditOptions.ValueValidateMode != 0 && DocumentOptions.EditOptions.ValueValidateMode != DocumentValueValidateMode.Program)
			{
				ValueValidateResultList valueValidateResultList = Document.ValueValidate();
				if (valueValidateResultList == null || valueValidateResultList.Count == 0)
				{
					cancelEventArgs_0.Cancel = false;
				}
			}
		}

		/// <summary>
		///       完成验证数据
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnValidated(EventArgs eventArgs_0)
		{
			base.OnValidated(eventArgs_0);
		}

		internal SimpleRectangleTransform method_223(XTextElement xtextElement_1)
		{
			float absLeft = xtextElement_1.AbsLeft;
			float absTop = xtextElement_1.AbsTop;
			foreach (SimpleRectangleTransform item in base.PagesTransform)
			{
				if (item.method_25().Contains(absLeft, absTop))
				{
					return item;
				}
			}
			return null;
		}

		[ComVisible(true)]
		public void method_224(int int_15)
		{
			if (base.IsHandleCreated && !base.IsDisposed && !bool_43 && timer_2 == null)
			{
				timer_2 = new System.Windows.Forms.Timer();
				timer_2.Tick += timer_2_Tick;
				timer_2.Interval = int_15;
				timer_2.Start();
			}
		}

		private void timer_2_Tick(object sender, EventArgs e)
		{
			Focus();
			if (timer_2 != null)
			{
				timer_2.Dispose();
				timer_2 = null;
			}
		}

		private float method_225(string string_8, XFontValue xfontValue_1, Graphics graphics_0)
		{
			return Document.Render.method_9().method_11(xfontValue_1, string_8, graphics_0, GraphicsUnit.Pixel).Width;
		}

		[DCInternal]
		public void method_226(GControl5 gcontrol5_0, bool bool_47)
		{
			int num = 13;
			if (gcontrol5_0 == null)
			{
				throw new ArgumentNullException("lst");
			}
			gcontrol5_0.gdelegate14_0 = method_225;
			if (bool_47 && DocumentOptions.BehaviorOptions.MinCountForDropdownListSpellCodeArea > 0 && gcontrol5_0.method_8().Count <= DocumentOptions.BehaviorOptions.MinCountForDropdownListSpellCodeArea)
			{
				gcontrol5_0.method_125(bool_14: false);
			}
			bool flag = false;
			string familyName = Control.DefaultFont.Name;
			float num2 = Control.DefaultFont.Size;
			if (!string.IsNullOrEmpty(DocumentOptions.ViewOptions.DropdownListFontName))
			{
				familyName = DocumentOptions.ViewOptions.DropdownListFontName;
				flag = true;
			}
			if (DocumentOptions.ViewOptions.DropdownListFontSize > 0f)
			{
				num2 = DocumentOptions.ViewOptions.DropdownListFontSize;
				flag = true;
			}
			else if (DocumentOptions.ViewOptions.AutoZoomDropdownListFontSize && base.XZoomRate != 1f)
			{
				num2 *= base.XZoomRate;
				if (num2 < 6f)
				{
					num2 = 6f;
				}
				flag = true;
			}
			if (flag)
			{
				if (DocumentOptions.BehaviorOptions.DebugMode)
				{
					gcontrol5_0.Font = new Font(familyName, num2);
				}
				else
				{
					try
					{
						Font font2 = gcontrol5_0.Font = new Font(familyName, num2);
					}
					catch
					{
					}
				}
			}
		}

		private ElementEventTemplate method_227(Type type_0)
		{
			if (elementEventTemlateMap_0 != null && elementEventTemlateMap_0.ContainsKey(type_0))
			{
				return elementEventTemlateMap_0[type_0];
			}
			return null;
		}

		private void method_228(Type type_0, ElementEventTemplate elementEventTemplate_0)
		{
			if (elementEventTemlateMap_0 == null)
			{
				return;
			}
			if (elementEventTemplate_0 == null)
			{
				if (elementEventTemlateMap_0.ContainsKey(type_0))
				{
					elementEventTemlateMap_0.Remove(type_0);
				}
			}
			else
			{
				elementEventTemlateMap_0[type_0] = elementEventTemplate_0;
			}
		}

		public ElementEventTemplateList method_229(XTextElement xtextElement_1)
		{
			if (!EnabledElementEvent)
			{
				return null;
			}
			if (!XTextDocument.smethod_13(GEnum6.const_160))
			{
				return null;
			}
			ElementEventTemplateList elementEventTemplateList = new ElementEventTemplateList();
			if (xtextElement_1 is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xtextElement_1;
				if (!string.IsNullOrEmpty(xTextContainerElement.EventTemplateName))
				{
					ElementEventTemplate elementEventTemplate = EventTemplates[xTextContainerElement.EventTemplateName];
					if (elementEventTemplate != null && elementEventTemplate.Enabled)
					{
						elementEventTemplateList.Add(elementEventTemplate);
					}
				}
			}
			if (xtextElement_1 is XTextObjectElement)
			{
				XTextObjectElement xTextObjectElement = (XTextObjectElement)xtextElement_1;
				if (!string.IsNullOrEmpty(xTextObjectElement.EventTemplateName))
				{
					ElementEventTemplate elementEventTemplate = EventTemplates[xTextObjectElement.EventTemplateName];
					if (elementEventTemplate != null && elementEventTemplate.Enabled)
					{
						elementEventTemplateList.Add(elementEventTemplate);
					}
				}
			}
			if (GlobalEventTemplates != null && GlobalEventTemplates.Count > 0)
			{
				foreach (Type key in GlobalEventTemplates.Keys)
				{
					if (key.IsAssignableFrom(xtextElement_1.GetType()))
					{
						ElementEventTemplate elementEventTemplate2 = GlobalEventTemplates[key];
						if (elementEventTemplate2 != null && elementEventTemplate2.Enabled)
						{
							elementEventTemplateList.Add(elementEventTemplate2);
						}
					}
				}
			}
			ElementVBScriptEventTemplate elementVBScriptEventTemplate = ElementVBScriptEventTemplate.smethod_0(xtextElement_1);
			if (elementVBScriptEventTemplate != null)
			{
				elementEventTemplateList.Add(elementVBScriptEventTemplate);
			}
			if (elementEventTemplateList.Count > 0)
			{
				return elementEventTemplateList;
			}
			return null;
		}

		public void method_230()
		{
			Invalidate();
		}

		/// <summary>
		///       处理在DELPHI中某些情况下用户按下键盘导致无限递归而堆栈溢出的错误。
		///       为此重写了PreProcessMessage来自己处理消息
		///       </summary>
		/// <param name="msg">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool PreProcessMessage(ref Message message_0)
		{
			int num = 9;
			if (OwnerWriterControl == null)
			{
				return base.PreProcessMessage(ref message_0);
			}
			if (!OwnerWriterControl.IsAxControl)
			{
				return base.PreProcessMessage(ref message_0);
			}
			if (ForcePreProcessMessage)
			{
				WndProc(ref message_0);
				return true;
			}
			if (int_13 == 100)
			{
				if (int_14 > 0)
				{
					int_14--;
				}
				else
				{
					WndProc(ref message_0);
				}
				return true;
			}
			if (int_13 < 0)
			{
				int_13++;
				StackTrace stackTrace = new StackTrace();
				int num2 = 0;
				MethodBase methodBase = null;
				for (int i = 0; i < stackTrace.FrameCount; i++)
				{
					StackFrame frame = stackTrace.GetFrame(i);
					MethodBase method = frame.GetMethod();
					if (methodBase == null)
					{
						if (method.Name == "TranslateAccelerator")
						{
							methodBase = method;
							num2++;
						}
					}
					else if (methodBase == method)
					{
						num2++;
					}
				}
				if (num2 >= 2)
				{
					int_13 = 100;
					int_14 = num2 - 1;
					return true;
				}
				return false;
			}
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		public bool method_231(string string_8, string string_9)
		{
			return ControlHelper.SetControlValue(this, string_8, string_9);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		public object method_232(string string_8)
		{
			return ControlHelper.GetControlValue(this, string_8);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		[ComVisible(true)]
		public object method_233(string string_8, string string_9)
		{
			return WriterUtils.smethod_18(this, string_8, string_9, bool_2: false);
		}

		[ComVisible(true)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object method_234(object object_1, string string_8, string string_9)
		{
			return WriterUtils.smethod_18(object_1, string_8, string_9, bool_2: false);
		}

		[ComVisible(true)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object method_235(string string_8)
		{
			Type controlType = ControlHelper.GetControlType(string_8, null);
			if (controlType != null)
			{
				return Activator.CreateInstance(controlType);
			}
			return null;
		}

		public bool method_236(object object_1, string string_8, string string_9)
		{
			int num = 19;
			if (object_1 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(string_8))
			{
				throw new ArgumentNullException("propertyName");
			}
			Type type = null;
			if (!string.IsNullOrEmpty(string_9))
			{
				type = ControlHelper.GetControlType(string_9, null);
				if (type == null)
				{
					throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.InvalidateType_Name, string_9));
				}
			}
			PropertyInfo property = object_1.GetType().GetProperty(string_8, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.PromptNotFontProperty_TypeName_PropertyName, object_1.GetType().FullName, string_8));
			}
			if (property.CanRead && property.GetValue(object_1, Type.EmptyTypes) == null)
			{
				if (!property.CanWrite)
				{
					throw new Exception(object_1.GetType().FullName + "." + string_8 + " readonly");
				}
				object value = Activator.CreateInstance(type);
				property.SetValue(object_1, value, Type.EmptyTypes);
				return true;
			}
			return false;
		}

		public bool method_237(int int_15)
		{
			GClass271 gClass = new GClass271();
			gClass.method_3(new IntPtr(int_15));
			gClass.method_1(base.Handle);
			gClass.method_5(Dock);
			return gClass.method_6();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool method_238()
		{
			bool result = Focus();
			method_201();
			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void method_239()
		{
			Select();
			method_201();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool method_240()
		{
			int num = GClass262.SetFocus(base.Handle);
			UpdateTextCaret();
			return num != 0;
		}

		public void method_241()
		{
			int num = 13;
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

		[ComVisible(false)]
		public IDisposable method_242()
		{
			return new Class287(this);
		}

		internal bool method_243(XTextDocument xtextDocument_1)
		{
			return xtextDocument_0 == xtextDocument_1;
		}

		internal void method_244()
		{
			if (xtextDocument_0 != null)
			{
				xtextDocument_0.Dispose();
				xtextDocument_0 = null;
			}
		}

		[ComVisible(false)]
		public XTextElement method_245(Type type_0)
		{
			return Document.GetCurrentElement(type_0, includeThis: true);
		}

		[ComVisible(true)]
		public XTextElement method_246(string string_8)
		{
			if (xtextDocument_0 == null)
			{
				return null;
			}
			return xtextDocument_0.GetCurrentElementByTypeName(string_8);
		}

		[ComVisible(true)]
		public XTextElement method_247(string string_8)
		{
			return Document.GetElementById(string_8);
		}

		[ComVisible(true)]
		public XTextInputFieldElement method_248(string string_8)
		{
			return Document.GetElementById(string_8) as XTextInputFieldElement;
		}

		[ComVisible(true)]
		public XTextTableElement method_249(string string_8)
		{
			return Document.GetElementById(string_8) as XTextTableElement;
		}

		[ComVisible(true)]
		public XTextTableCellElement method_250(string string_8, int int_15, int int_16)
		{
			return Document.GetTableCell(string_8, int_15, int_16);
		}

		[ComVisible(true)]
		public string method_251(string string_8, int int_15, int int_16)
		{
			return Document.GetTableCellText(string_8, int_15, int_16);
		}

		[ComVisible(true)]
		public bool method_252(string string_8, int int_15, int int_16, string string_9)
		{
			return Document.SetTableCellText(string_8, int_15, int_16, string_9);
		}

		[ComVisible(true)]
		public XTextElement method_253(int int_15, int int_16)
		{
			SimpleRectangleTransform gClass = base.PagesTransform.method_15(int_15, int_16, bool_0: true, bool_1: false, bool_2: true);
			if (gClass != null)
			{
				XTextDocument xTextDocument = (XTextDocument)gClass.method_10();
				PointF pointF_ = new PointF(int_15, int_16);
				pointF_ = RectangleCommon.MoveInto(pointF_, gClass.getSourceRectF());
				if (pointF_.Y == (float)gClass.method_21().Bottom)
				{
					pointF_.Y = gClass.method_21().Bottom - 2;
				}
				pointF_ = gClass.TransformPointF(pointF_.X, pointF_.Y);
				return xTextDocument.GetElementAt(pointF_.X, pointF_.Y, strict: true);
			}
			return null;
		}

		[ComVisible(true)]
		public Rectangle method_254(XTextElement xtextElement_1)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (!(xtextElement_1 is XTextInputFieldElement))
			{
				if (xtextElement_1 is XTextShapeInputFieldElement)
				{
					XTextShapeInputFieldElement xTextShapeInputFieldElement = (XTextShapeInputFieldElement)xtextElement_1;
					if (!xTextShapeInputFieldElement.EditMode)
					{
						xTextElementList.Add(xtextElement_1);
					}
				}
				else
				{
					xTextElementList.Add(xtextElement_1);
				}
			}
			if (xTextElementList.Count == 0)
			{
				XTextDocumentContentElement documentContentElement = xtextElement_1.DocumentContentElement;
				if (xtextElement_1 is XTextInputFieldElementBase && xtextElement_1 is XTextContainerElement)
				{
					XTextElementList xTextElementList2 = new XTextElementList();
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xtextElement_1;
					xTextContainerElement.vmethod_32(xTextElementList2, bool_17: true);
					if (xTextElementList2.Count > 0)
					{
						foreach (XTextElement item in xTextElementList2)
						{
							if (item.OwnerLine != null && documentContentElement.Content.Contains(item))
							{
								xTextElementList.Add(item);
							}
						}
					}
				}
			}
			Rectangle rectangle = Rectangle.Empty;
			foreach (XTextElement item2 in xTextElementList)
			{
				RectangleF absBounds = item2.AbsBounds;
				foreach (SimpleRectangleTransform item3 in base.PagesTransform)
				{
					if (item3.method_25().IntersectsWith(absBounds))
					{
						RectangleF rectangleF = item3.vmethod_23(absBounds);
						Rectangle rectangle2 = new Rectangle((int)Math.Ceiling(rectangleF.Left), (int)Math.Ceiling(rectangleF.Top), 0, 0);
						rectangle2.Width = (int)Math.Ceiling(rectangleF.Right - (float)rectangle2.Left);
						rectangle2.Height = (int)Math.Ceiling(rectangleF.Bottom - (float)rectangle2.Top);
						if (rectangle2.Width < 0)
						{
							rectangle2.Width = 0;
						}
						if (rectangle2.Height < 0)
						{
							rectangle2.Height = 0;
						}
						if (rectangle2.Width > 0 && rectangle2.Height > 0)
						{
							rectangle = ((!rectangle.IsEmpty) ? Rectangle.Union(rectangle2, rectangle) : rectangle2);
						}
						break;
					}
				}
			}
			return rectangle;
		}

		public void method_255()
		{
			method_111();
			base.MouseDragScroll = false;
			if (AutoSetDocumentDefaultFont)
			{
				method_177(bool_47: false);
			}
			if (xtextDocument_0 != null)
			{
				xtextDocument_0.Clear();
				method_187();
				Invalidate();
			}
		}

		public int method_256(int int_15, float float_2)
		{
			if (int_15 <= 0 && int_15 > Document.Pages.Count)
			{
				return 0;
			}
			XTextLineList privateLines = Document.Body.PrivateLines;
			PrintPage printPage = Document.Pages[int_15 - 1];
			int num = privateLines.Count - 1;
			XTextLine xTextLine;
			while (true)
			{
				if (num >= 0)
				{
					xTextLine = privateLines[num];
					if (xTextLine.AbsTop < printPage.Bottom)
					{
						break;
					}
					num--;
					continue;
				}
				return 0;
			}
			float num2 = printPage.Top + printPage.StandartPapeBodyHeight;
			num2 = num2 - printPage.HeaderRowsBounds.Height - xTextLine.AbsTop - xTextLine.Height;
			float num3 = xTextLine.Height;
			if (float_2 > 0f)
			{
				num3 = float_2;
			}
			return (int)Math.Floor(num2 / num3);
		}

		internal void method_257(XTextDocumentContentElement xtextDocumentContentElement_0)
		{
			base.CurrentTransformItem = null;
			_ = base.CurrentPageIndex;
			PrintPage printPage = CurrentPage;
			if (printPage == null)
			{
				printPage = Document.Pages.FirstPage;
			}
			if (printPage != null)
			{
				foreach (SimpleRectangleTransform item in base.PagesTransform)
				{
					XTextDocument xTextDocument = (XTextDocument)item.method_10();
					if (item.method_8() == printPage && item.method_0() != PageContentPartyStyle.HeaderRows && item.method_0() == xtextDocumentContentElement_0.PagePartyStyle && (!HeaderFooterReadonly || !DrawerUtil.IsHeaderFooter(item.method_0())))
					{
						if (xTextDocument.CurrentContentElement != xtextDocumentContentElement_0)
						{
							if (CommentManager != null && CommentManager.imethod_9() != null)
							{
								CommentManager.imethod_10(null);
							}
							if (xtextDocumentContentElement_0 != xTextDocument.Body)
							{
								base.CurrentTransformItem = item;
							}
							XTextDocumentContentElement currentContentElement = xTextDocument.CurrentContentElement;
							xTextDocument.CurrentContentElement = xtextDocumentContentElement_0;
							xTextDocument.CurrentContentElement.method_67(currentContentElement.CurrentElement, xtextDocumentContentElement_0.CurrentElement);
							xTextDocument.CurrentContentElement.FixElements();
							UpdatePages();
							Invalidate();
							UpdateTextCaret();
						}
						break;
					}
				}
			}
		}

		private void method_258(Graphics graphics_0, RectangleF rectangleF_0)
		{
			if (Document.method_74(bool_32: true) && RuntimeViewMode == PageViewMode.Page && RuntimeCommentVisible)
			{
				foreach (SimpleRectangleTransform item in base.PagesTransform)
				{
					if (item.method_0() == PageContentPartyStyle.Body && item.method_8() != null)
					{
						PaintEventArgs paintEventArgs = base.TransformPaint(new PaintEventArgs(graphics_0, new Rectangle((int)rectangleF_0.Left, (int)rectangleF_0.Top, (int)rectangleF_0.Width, (int)rectangleF_0.Height)), item, bool_13: false);
						if (paintEventArgs != null)
						{
							paintEventArgs.Graphics.ResetClip();
							CommentManager.imethod_7(new DCGraphics(paintEventArgs.Graphics), paintEventArgs.ClipRectangle, (PrintPage)item.method_8(), bool_0: true);
						}
					}
				}
			}
		}
	}
}

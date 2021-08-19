using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       体温单/时间轴控件
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DCPublishAPI]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(TemperatureControl))]
	[DocumentComment]
	public class TemperatureControl : UserControl
	{
		/// <summary>
		///       委托
		///       </summary>
		/// <param name="sender">对象</param>
		/// <param name="e">参数</param>
		public delegate void SelectPageIndexEventHander(object sender, SelectPageIndexChangeArgs selectPageIndexChangeArgs_0);

		/// <summary>
		///       页码改变事件
		///       </summary>
		public class SelectPageIndexChangeArgs : EventArgs
		{
			private int _PageIndex;

			/// <summary>
			///       页码
			///       </summary>
			public int PageIndex => _PageIndex;

			/// <summary>
			///       页码改变数据
			///       </summary>
			/// <param name="pageIndex">
			/// </param>
			public SelectPageIndexChangeArgs(int pageIndex)
			{
				_PageIndex = pageIndex;
			}
		}

		/// <summary>
		///       自定义名称初始化
		///       </summary>
		public static List<string> _StanderNameList = new List<string>();

		/// <summary>
		///       自定义标题初始化
		///       </summary>
		public static List<string> _StanderTitleList = new List<string>();

		private EditValuePointEventHandler editValuePointEventHandler_0 = null;

		private DocumentLinkClickEventHandler documentLinkClickEventHandler_0 = null;

		/// <summary>
		///       时间区域收缩事件
		///       </summary>
		public TimeLineZoneEventHandler EventZoneAfterCollapse = null;

		/// <summary>
		///       时间区域展开事件
		///       </summary>
		public TimeLineZoneEventHandler EventZoneAfterExpand = null;

		private bool bool_0 = true;

		private AfterRunDesignerEventHandler afterRunDesignerEventHandler_0 = null;

		private DocumentDblClickEventHandler documentDblClickEventHandler_0 = null;

		private ValuePointClickEventHandler valuePointClickEventHandler_0 = null;

		private SelectPageIndexEventHander selectPageIndexEventHander_0;

		private ToolStripMenuItem toolStripMenuItem_0 = null;

		private ToolStripMenuItem toolStripMenuItem_1 = null;

		private EventHandler eventHandler_0 = null;

		private IContainer icontainer_0 = null;

		private ToolStrip myToolStrip;

		private ToolStripLabel toolStripLabel1;

		private ToolStripComboBox cboPageIndex;

		private ToolStripButton btnPrintCurrentPage;

		private ToolStripButton btnPrintAll;

		private ToolStripDropDownButton btnViewMode;

		private ToolStripMenuItem btnNormalViewMode;

		private ToolStripMenuItem btnPageViewMode;

		private ToolStripMenuItem btnWidelyViewMode;

		private ToolStripButton btnCrossLine;

		private PictureBox picLeftHeader;

		private ToolStripButton btnEditValue;

		private ToolStripDropDownButton btnEditData;

		private ToolStripButton tsbImportImg;

		private GControl1 pnlView;

		private ToolStripButton btnDesigner;

		/// <summary>
		///       是否显示设计器按钮
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool DesignerButtonVisible
		{
			get
			{
				return btnDesigner.Visible;
			}
			set
			{
				btnDesigner.Visible = value;
			}
		}

		/// <summary>
		///       自定义名称
		///       </summary>
		public List<string> StanderNameList => _StanderNameList;

		/// <summary>
		///       自定义标题
		///       </summary>
		public List<string> StanderTitleList => _StanderTitleList;

		/// <summary>
		///       光标所在的时间值
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DateTime CaretDateTime
		{
			get
			{
				return pnlView.method_14().CaretDateTime;
			}
			set
			{
				pnlView.method_14().CaretDateTime = value;
			}
		}

		/// <summary>
		///       内置的时间轴视图控件
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GControl1 InnerViewControl => pnlView;

		/// <summary>
		///       文档行为模式
		///       </summary>
		internal Enum16 BehaviorMode
		{
			get
			{
				return DocumentViewControl.method_4();
			}
			set
			{
				DocumentViewControl.method_5(value);
			}
		}

		/// <summary>
		///       内部的时间轴视图控件
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public GControl1 DocumentViewControl => pnlView;

		/// <summary>
		///       总页数
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		public int NumOfPages => pnlView.method_14().NumOfPages;

		/// <summary>
		///       获取或者设置当前页码
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int PageIndex
		{
			get
			{
				return pnlView.method_14().PageIndex;
			}
			set
			{
				if (value >= 0 && value < cboPageIndex.Items.Count)
				{
					cboPageIndex.SelectedIndex = value;
				}
				pnlView.method_14().PageIndex = value;
			}
		}

		/// <summary>
		///       固定时间轴的左侧标题列
		///       </summary>
		[DefaultValue(true)]
		public bool FixedTimelineLeftHeader
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
				method_18(bool_1: true);
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[Obsolete("本方法已经作废，请使用SetRegisterCode().")]
		[DefaultValue(null)]
		[Browsable(false)]
		public string RegisterCode
		{
			get
			{
				return null;
			}
			set
			{
				TemperatureDocument.StaticRegisterCode = value;
			}
		}

		/// <summary>
		///       表示为空的数值
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		public float NullValue => -10000f;

		/// <summary>
		///       文档配置信息XML字符串
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string DocumentConfigXml
		{
			get
			{
				return Document.ConfigXml;
			}
			set
			{
				Document.ConfigXml = value;
			}
		}

		/// <summary>
		///       文档配置对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		[Browsable(false)]
		public TemperatureDocumentConfig DocumentConfig
		{
			get
			{
				return Document.Config;
			}
			set
			{
				Document.Config = value;
			}
		}

		/// <summary>
		///       编辑数据模式
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("本属性已废除，无任何效果。")]
		[DefaultValue(false)]
		[Browsable(false)]
		public bool EditValueMode
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
		///       设置、获得包含文档数据的XML字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public string XMLText
		{
			get
			{
				return Document.XMLText;
			}
			set
			{
				Document.XMLText = value;
				RefreshViewWithoutRefreshDataSource();
			}
		}

		/// <summary>
		///       设置、获得包含文档数据的带缩进的XML字符串
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public string XMLTextIndented
		{
			get
			{
				return Document.XMLTextIndented;
			}
			set
			{
				Document.XMLTextIndented = value;
				RefreshViewWithoutRefreshDataSource();
			}
		}

		/// <summary>
		///       是否显示提示文本 
		///       </summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[ComVisible(true)]
		public bool ShowTooltip
		{
			get
			{
				return pnlView.method_14().Config.ShowTooltip;
			}
			set
			{
				pnlView.method_14().Config.ShowTooltip = value;
			}
		}

		/// <summary>
		///       是否显示工具条
		///       </summary>
		[ComVisible(true)]
		[Category("Layout")]
		[DefaultValue(true)]
		public bool ToolbarVisible
		{
			get
			{
				return myToolStrip.Visible;
			}
			set
			{
				myToolStrip.Visible = value;
			}
		}

		/// <summary>
		///       文档视图模式
		///       </summary>
		[ComVisible(true)]
		[Category("Layout")]
		[DefaultValue(DocumentViewMode.Page)]
		public DocumentViewMode ViewMode
		{
			get
			{
				return pnlView.method_10();
			}
			set
			{
				pnlView.method_11(value);
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TemperatureDocument Document
		{
			get
			{
				return pnlView.method_14();
			}
			set
			{
				pnlView.method_15(value);
			}
		}

		/// <summary>
		///       页面设置
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public DocumentPageSettings PageSettings
		{
			get
			{
				return pnlView.method_14().Config.PageSettings;
			}
			set
			{
				pnlView.method_14().Config.PageSettings = value;
			}
		}

		/// <summary>
		///       页面背景色
		///       </summary>
		[Category("Appearance")]
		[ComVisible(true)]
		[DefaultValue(typeof(Color), "White")]
		public Color PageBackColor
		{
			get
			{
				return pnlView.method_14().Config.PageBackColor;
			}
			set
			{
				pnlView.method_14().Config.PageBackColor = value;
				picLeftHeader.BackColor = value;
			}
		}

		protected virtual bool IsAxControl => false;

		/// <summary>
		///       编辑数据按钮是否可见
		///       </summary>
		[DefaultValue(false)]
		public bool EditValueButtonVisible
		{
			get
			{
				return btnEditValue.Visible;
			}
			set
			{
				btnEditValue.Visible = value;
			}
		}

		/// <summary>
		///       编辑数据点事件
		///       </summary>
		public event EditValuePointEventHandler EventEditValuePoint
		{
			add
			{
				EditValuePointEventHandler editValuePointEventHandler = editValuePointEventHandler_0;
				EditValuePointEventHandler editValuePointEventHandler2;
				do
				{
					editValuePointEventHandler2 = editValuePointEventHandler;
					EditValuePointEventHandler value2 = (EditValuePointEventHandler)Delegate.Combine(editValuePointEventHandler2, value);
					editValuePointEventHandler = Interlocked.CompareExchange(ref editValuePointEventHandler_0, value2, editValuePointEventHandler2);
				}
				while ((object)editValuePointEventHandler != editValuePointEventHandler2);
			}
			remove
			{
				EditValuePointEventHandler editValuePointEventHandler = editValuePointEventHandler_0;
				EditValuePointEventHandler editValuePointEventHandler2;
				do
				{
					editValuePointEventHandler2 = editValuePointEventHandler;
					EditValuePointEventHandler value2 = (EditValuePointEventHandler)Delegate.Remove(editValuePointEventHandler2, value);
					editValuePointEventHandler = Interlocked.CompareExchange(ref editValuePointEventHandler_0, value2, editValuePointEventHandler2);
				}
				while ((object)editValuePointEventHandler != editValuePointEventHandler2);
			}
		}

		/// <summary>
		///       超链接点击事件
		///       </summary>
		public event DocumentLinkClickEventHandler EventLinkClick
		{
			add
			{
				DocumentLinkClickEventHandler documentLinkClickEventHandler = documentLinkClickEventHandler_0;
				DocumentLinkClickEventHandler documentLinkClickEventHandler2;
				do
				{
					documentLinkClickEventHandler2 = documentLinkClickEventHandler;
					DocumentLinkClickEventHandler value2 = (DocumentLinkClickEventHandler)Delegate.Combine(documentLinkClickEventHandler2, value);
					documentLinkClickEventHandler = Interlocked.CompareExchange(ref documentLinkClickEventHandler_0, value2, documentLinkClickEventHandler2);
				}
				while ((object)documentLinkClickEventHandler != documentLinkClickEventHandler2);
			}
			remove
			{
				DocumentLinkClickEventHandler documentLinkClickEventHandler = documentLinkClickEventHandler_0;
				DocumentLinkClickEventHandler documentLinkClickEventHandler2;
				do
				{
					documentLinkClickEventHandler2 = documentLinkClickEventHandler;
					DocumentLinkClickEventHandler value2 = (DocumentLinkClickEventHandler)Delegate.Remove(documentLinkClickEventHandler2, value);
					documentLinkClickEventHandler = Interlocked.CompareExchange(ref documentLinkClickEventHandler_0, value2, documentLinkClickEventHandler2);
				}
				while ((object)documentLinkClickEventHandler != documentLinkClickEventHandler2);
			}
		}

		/// <summary>
		///       运行设计器之后触发的事件
		///       </summary>
		public event AfterRunDesignerEventHandler EventAfterRunDesigner
		{
			add
			{
				AfterRunDesignerEventHandler afterRunDesignerEventHandler = afterRunDesignerEventHandler_0;
				AfterRunDesignerEventHandler afterRunDesignerEventHandler2;
				do
				{
					afterRunDesignerEventHandler2 = afterRunDesignerEventHandler;
					AfterRunDesignerEventHandler value2 = (AfterRunDesignerEventHandler)Delegate.Combine(afterRunDesignerEventHandler2, value);
					afterRunDesignerEventHandler = Interlocked.CompareExchange(ref afterRunDesignerEventHandler_0, value2, afterRunDesignerEventHandler2);
				}
				while ((object)afterRunDesignerEventHandler != afterRunDesignerEventHandler2);
			}
			remove
			{
				AfterRunDesignerEventHandler afterRunDesignerEventHandler = afterRunDesignerEventHandler_0;
				AfterRunDesignerEventHandler afterRunDesignerEventHandler2;
				do
				{
					afterRunDesignerEventHandler2 = afterRunDesignerEventHandler;
					AfterRunDesignerEventHandler value2 = (AfterRunDesignerEventHandler)Delegate.Remove(afterRunDesignerEventHandler2, value);
					afterRunDesignerEventHandler = Interlocked.CompareExchange(ref afterRunDesignerEventHandler_0, value2, afterRunDesignerEventHandler2);
				}
				while ((object)afterRunDesignerEventHandler != afterRunDesignerEventHandler2);
			}
		}

		/// <summary>
		///       文档双击事件
		///       </summary>
		public event DocumentDblClickEventHandler EventDocumentDblClick
		{
			add
			{
				DocumentDblClickEventHandler documentDblClickEventHandler = documentDblClickEventHandler_0;
				DocumentDblClickEventHandler documentDblClickEventHandler2;
				do
				{
					documentDblClickEventHandler2 = documentDblClickEventHandler;
					DocumentDblClickEventHandler value2 = (DocumentDblClickEventHandler)Delegate.Combine(documentDblClickEventHandler2, value);
					documentDblClickEventHandler = Interlocked.CompareExchange(ref documentDblClickEventHandler_0, value2, documentDblClickEventHandler2);
				}
				while ((object)documentDblClickEventHandler != documentDblClickEventHandler2);
			}
			remove
			{
				DocumentDblClickEventHandler documentDblClickEventHandler = documentDblClickEventHandler_0;
				DocumentDblClickEventHandler documentDblClickEventHandler2;
				do
				{
					documentDblClickEventHandler2 = documentDblClickEventHandler;
					DocumentDblClickEventHandler value2 = (DocumentDblClickEventHandler)Delegate.Remove(documentDblClickEventHandler2, value);
					documentDblClickEventHandler = Interlocked.CompareExchange(ref documentDblClickEventHandler_0, value2, documentDblClickEventHandler2);
				}
				while ((object)documentDblClickEventHandler != documentDblClickEventHandler2);
			}
		}

		/// <summary>
		///       鼠标点击数据点事件
		///       </summary>
		public event ValuePointClickEventHandler EventValuePointClick
		{
			add
			{
				ValuePointClickEventHandler valuePointClickEventHandler = valuePointClickEventHandler_0;
				ValuePointClickEventHandler valuePointClickEventHandler2;
				do
				{
					valuePointClickEventHandler2 = valuePointClickEventHandler;
					ValuePointClickEventHandler value2 = (ValuePointClickEventHandler)Delegate.Combine(valuePointClickEventHandler2, value);
					valuePointClickEventHandler = Interlocked.CompareExchange(ref valuePointClickEventHandler_0, value2, valuePointClickEventHandler2);
				}
				while ((object)valuePointClickEventHandler != valuePointClickEventHandler2);
			}
			remove
			{
				ValuePointClickEventHandler valuePointClickEventHandler = valuePointClickEventHandler_0;
				ValuePointClickEventHandler valuePointClickEventHandler2;
				do
				{
					valuePointClickEventHandler2 = valuePointClickEventHandler;
					ValuePointClickEventHandler value2 = (ValuePointClickEventHandler)Delegate.Remove(valuePointClickEventHandler2, value);
					valuePointClickEventHandler = Interlocked.CompareExchange(ref valuePointClickEventHandler_0, value2, valuePointClickEventHandler2);
				}
				while ((object)valuePointClickEventHandler != valuePointClickEventHandler2);
			}
		}

		/// <summary>
		///       事件
		///       </summary>
		public event SelectPageIndexEventHander SelectPageIndexChanged
		{
			add
			{
				SelectPageIndexEventHander selectPageIndexEventHander = selectPageIndexEventHander_0;
				SelectPageIndexEventHander selectPageIndexEventHander2;
				do
				{
					selectPageIndexEventHander2 = selectPageIndexEventHander;
					SelectPageIndexEventHander value2 = (SelectPageIndexEventHander)Delegate.Combine(selectPageIndexEventHander2, value);
					selectPageIndexEventHander = Interlocked.CompareExchange(ref selectPageIndexEventHander_0, value2, selectPageIndexEventHander2);
				}
				while ((object)selectPageIndexEventHander != selectPageIndexEventHander2);
			}
			remove
			{
				SelectPageIndexEventHander selectPageIndexEventHander = selectPageIndexEventHander_0;
				SelectPageIndexEventHander selectPageIndexEventHander2;
				do
				{
					selectPageIndexEventHander2 = selectPageIndexEventHander;
					SelectPageIndexEventHander value2 = (SelectPageIndexEventHander)Delegate.Remove(selectPageIndexEventHander2, value);
					selectPageIndexEventHander = Interlocked.CompareExchange(ref selectPageIndexEventHander_0, value2, selectPageIndexEventHander2);
				}
				while ((object)selectPageIndexEventHander != selectPageIndexEventHander2);
			}
		}

		/// <summary>
		///       刷新文档内容后的事件
		///       </summary>
		public event EventHandler EventAfterRefreshView
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
		///       初始化对象
		///       </summary>
		public TemperatureControl()
		{
			InitializeComponent();
			pnlView.method_20(method_7);
			pnlView.method_66(method_6);
			pnlView.MouseDoubleClick += pnlView_MouseDoubleClick;
			pnlView.method_49(method_3);
			pnlView.method_51(method_2);
			pnlView.method_53(method_1);
			pnlView.method_45(method_0);
			btnEditData.DropDownOpening += btnEditData_DropDownOpening;
			btnDesigner.Visible = false;
		}

		private void method_0(object sender, EditValuePointEventArgs e)
		{
			method_4(e);
		}

		private void method_1(object sender, EventArgs e)
		{
			picLeftHeader.Invalidate();
		}

		private void method_2(object sender, TimeLineZoneEventArgs e)
		{
			method_18(bool_1: false);
			method_19();
			if (EventZoneAfterExpand != null)
			{
				EventZoneAfterExpand(this, e);
			}
		}

		private void method_3(object sender, TimeLineZoneEventArgs e)
		{
			method_18(bool_1: false);
			method_19();
			if (EventZoneAfterCollapse != null)
			{
				EventZoneAfterCollapse(this, e);
			}
		}

		/// <summary>
		///       自定义名称方法
		///       </summary>
		public void AddStanderNameList(string string_0)
		{
			if (string_0.IndexOf(",") > 0)
			{
				string[] array = string_0.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					StanderNameList.Add(array[i]);
				}
			}
			else
			{
				StanderNameList.Add(string_0);
			}
		}

		/// <summary>
		///       自定义标题方法
		///       </summary>
		public void AddStanderTitleList(string string_0)
		{
			if (string_0.IndexOf(",") > 0)
			{
				string[] array = string_0.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					StanderTitleList.Add(array[i]);
				}
			}
			else
			{
				StanderTitleList.Add(string_0);
			}
		}

		/// <summary>
		///       声明整个控件，准备重新绘制整个界面
		///       </summary>
		[ComVisible(true)]
		public void InvalidateAll()
		{
			Invalidate(invalidateChildren: true);
		}

		internal void method_4(EditValuePointEventArgs editValuePointEventArgs_0)
		{
			if (editValuePointEventHandler_0 != null)
			{
				editValuePointEventHandler_0(this, editValuePointEventArgs_0);
			}
		}

		internal void method_5(DocumentLinkClickEventArgs documentLinkClickEventArgs_0)
		{
			if (documentLinkClickEventHandler_0 != null)
			{
				documentLinkClickEventHandler_0(this, documentLinkClickEventArgs_0);
			}
		}

		private void pnlView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if ((pnlView.method_43() == 0 || Environment.TickCount > pnlView.method_43()) && pnlView.method_44().method_18() == Enum17.const_0)
			{
				DocumentDblClickEventArgs documentDblClickEventArgs_ = new DocumentDblClickEventArgs(Document);
				method_8(documentDblClickEventArgs_);
			}
		}

		/// <summary>
		///       滚动视图到最后面的数据点
		///       </summary>
		public void ScrollViewToLast()
		{
			Point autoScrollPosition = new Point(y: -pnlView.AutoScrollPosition.Y, x: pnlView.AutoScrollMinSize.Width - pnlView.ClientSize.Width);
			pnlView.AutoScrollPosition = autoScrollPosition;
		}

		private void method_6(object sender, EventArgs e)
		{
		}

		private void method_7(object sender, ValuePointClickEventArgs e)
		{
			if (BehaviorMode == Enum16.const_0)
			{
				method_9(e);
			}
		}

		/// <summary>
		///       设置注册码
		///       </summary>
		/// <param name="registerCode">
		/// </param>
		[ComVisible(true)]
		[DocumentComment]
		public void SetRegisterCode(string registerCode)
		{
			TemperatureDocument.StaticRegisterCode = registerCode;
			if (base.IsHandleCreated && base.Visible)
			{
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary>
		///       设置注册码的静态方法
		///       </summary>
		/// <param name="registerCode">
		/// </param>
		[DocumentComment]
		public static void StaticSetRegisterCode(string registerCode)
		{
			TemperatureDocument.StaticRegisterCode = registerCode;
		}

		[ComVisible(true)]
		protected virtual void OnEventAfterRunDesigner(AfterRunDesignerEventArgs args)
		{
			if (afterRunDesignerEventHandler_0 != null)
			{
				if (IsAxControl)
				{
					try
					{
						afterRunDesignerEventHandler_0(this, args);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					afterRunDesignerEventHandler_0(this, args);
				}
			}
		}

		/// <summary>
		///       运行设计器
		///       </summary>
		/// <returns>操作是否修改了文档内容</returns>
		[ComVisible(true)]
		public bool RunDesigner()
		{
			using (frmTimeLineDesigner frmTimeLineDesigner = new frmTimeLineDesigner())
			{
				frmTimeLineDesigner.SourceDocument = Document;
				frmTimeLineDesigner.SourceControl = this;
				if (frmTimeLineDesigner.ShowDialog(this) == DialogResult.OK)
				{
					AfterRunDesignerEventArgs args = new AfterRunDesignerEventArgs(this, Document);
					OnEventAfterRunDesigner(args);
					RefreshView();
					return true;
				}
				pnlView.method_23();
			}
			return false;
		}

		/// <summary>
		///       最大化运行设计器
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public bool RunDesignerMax()
		{
			using (frmTimeLineDesigner frmTimeLineDesigner = new frmTimeLineDesigner())
			{
				frmTimeLineDesigner.SourceDocument = Document;
				frmTimeLineDesigner.SourceControl = this;
				frmTimeLineDesigner.WindowState = FormWindowState.Maximized;
				if (frmTimeLineDesigner.ShowDialog(this) == DialogResult.OK)
				{
					AfterRunDesignerEventArgs args = new AfterRunDesignerEventArgs(this, Document);
					OnEventAfterRunDesigner(args);
					RefreshView();
					return true;
				}
				pnlView.method_23();
			}
			return false;
		}

		private void method_8(DocumentDblClickEventArgs documentDblClickEventArgs_0)
		{
			if (documentDblClickEventHandler_0 != null)
			{
				if (IsAxControl)
				{
					try
					{
						documentDblClickEventHandler_0(this, documentDblClickEventArgs_0);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					documentDblClickEventHandler_0(this, documentDblClickEventArgs_0);
				}
			}
		}

		private void method_9(ValuePointClickEventArgs valuePointClickEventArgs_0)
		{
			if (valuePointClickEventHandler_0 != null)
			{
				if (IsAxControl)
				{
					try
					{
						valuePointClickEventHandler_0(this, valuePointClickEventArgs_0);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					valuePointClickEventHandler_0(this, valuePointClickEventArgs_0);
				}
			}
		}

		private void method_10(SelectPageIndexChangeArgs selectPageIndexChangeArgs_0)
		{
			if (selectPageIndexEventHander_0 != null)
			{
				selectPageIndexEventHander_0(this, selectPageIndexChangeArgs_0);
			}
		}

		/// <summary>
		///       控件加载时的处理
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				pnlView.method_9(btnCrossLine.Checked);
				if (picLeftHeader.Visible)
				{
					OnResize(null);
				}
			}
		}

		/// <summary>
		///       清除数据
		///       </summary>
		[ComVisible(true)]
		public void ClearData()
		{
			Document.ClearData();
			Document.Parameters.Clear();
		}

		/// <summary>
		///       修改指定时间区域的范围
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="startTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>操作是否修改了数据</returns>
		[ComVisible(true)]
		public bool SetTimeLineZoneRange(string zoneName, DateTime startTime, DateTime endTime)
		{
			return Document.SetTimeLineZoneRange(zoneName, startTime, endTime);
		}

		/// <summary>
		///       设置指定时间区域中的数据点颜色
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="valueName">数据序列名称</param>
		/// <param name="colorValue">颜色值，比如"#ff00ff"</param>
		/// <returns>操作修改的数据点个数</returns>
		[ComVisible(true)]
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, string colorValue)
		{
			return Document.SetSymbolStyleByTimeZone(zoneName, valueName, colorValue);
		}

		/// <summary>
		///       设置指定时间区域中的数据点样式
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="valueName">数据序列名称</param>
		/// <param name="style">新的数据点图标样式</param>
		/// <returns>操作修改的数据点个数</returns>
		[ComVisible(true)]
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, ValuePointSymbolStyle style)
		{
			return Document.SetSymbolStyleByTimeZone(zoneName, valueName, style);
		}

		/// <summary>
		///       设置页眉标题文本
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="text">文本</param>
		[ComVisible(true)]
		public void SetHeaderLableValue(string title, string text)
		{
			Document.SetHeaderLableValue(title, text);
		}

		/// <summary>
		///       设置文档参数值
		///       </summary>
		/// <param name="pName">参数名</param>
		/// <param name="pValue">参数值</param>
		[ComVisible(true)]
		public void SetParameterValue(string pName, string pValue)
		{
			Document.SetParameterValue(pName, pValue);
		}

		/// <summary>
		///       根据序号设置页眉标题文本
		///       </summary>
		/// <param name="index">从0开始计算的序号</param>
		/// <param name="text">文本</param>
		[ComVisible(true)]
		public void SetHeaderLableValueByIndex(int index, string text)
		{
			Document.SetHeaderLableValueByIndex(index, text);
		}

		/// <summary>
		///       创建一个数据点对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		[ComVisible(true)]
		public ValuePoint CreateValuePoint()
		{
			return new ValuePoint();
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列的名称</param>
		/// <param name="point">数据点</param>
		[ComVisible(true)]
		public void AddPoint(string name, ValuePoint point)
		{
			Document.AddPoint(name, point);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="Value">数值</param>
		[ComVisible(true)]
		public void AddPointByTimeValue(string name, DateTime dateTime_0, float Value)
		{
			Document.AddPointByTimeValue(name, dateTime_0, Value);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">数值</param>
		[ComVisible(true)]
		public void AddPointByTimeText(string name, DateTime dateTime_0, string text)
		{
			Document.AddPointByTimeText(name, dateTime_0, text);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">文本</param>
		/// <param name="Value">数值</param>
		[ComVisible(true)]
		public void AddPointByTimeTextValue(string name, DateTime dateTime_0, string text, float Value)
		{
			Document.AddPointByTimeTextValue(name, dateTime_0, text, Value);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">文本</param>
		/// <param name="htmlColorValue">HTML格式的颜色值</param>
		[ComVisible(true)]
		public void AddPointByTimeTextColor(string name, DateTime dateTime_0, string text, string htmlColorValue)
		{
			Document.AddPointByTimeTextColor(name, dateTime_0, text, htmlColorValue);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="Value">数值</param>
		/// <param name="landernValue">灯笼数值</param>
		[ComVisible(true)]
		public void AddPointByTimeValueLandernValue(string name, DateTime dateTime_0, float Value, float landernValue)
		{
			Document.AddPointByTimeValueLandernValue(name, dateTime_0, Value, landernValue);
		}

		/// <summary>
		///       更新文档视图
		///       </summary>
		[ComVisible(true)]
		public void RefreshView()
		{
			bool visible = picLeftHeader.Visible;
			picLeftHeader.Visible = false;
			pnlView.method_22();
			picLeftHeader.Visible = visible;
			method_18(bool_1: true);
			if (Document.Config.Zones != null && Document.Config.Zones.Count > 0)
			{
				btnWidelyViewMode_Click(null, null);
			}
			method_15();
			method_17();
			method_11();
			pnlView.method_44().method_5();
			vmethod_0();
		}

		/// <summary>
		///       不刷新数据源的更新文档视图
		///        </summary>
		[ComVisible(true)]
		public void RefreshViewWithoutRefreshDataSource()
		{
			pnlView.method_23();
			method_18(bool_1: true);
			if (Document.Config.Zones != null && Document.Config.Zones.Count > 0 && Document.ViewMode != DocumentViewMode.Timeline)
			{
				btnWidelyViewMode_Click(null, null);
			}
			method_15();
			method_11();
			pnlView.method_44().method_5();
			vmethod_0();
		}

		private void method_11()
		{
			btnEditData.Visible = (Document.Config.EditValuePointMode != EditValuePointEventHandleMode.None);
			btnEditData.DropDownItems.Clear();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = DCTimeLineStrings.CancelEditValuePoint;
			toolStripMenuItem.Click += method_12;
			btnEditData.DropDownItems.Add(toolStripMenuItem);
			btnEditData.DropDownItems.Add(new ToolStripSeparator());
			foreach (YAxisInfo visibleYAxisInfo in Document.VisibleYAxisInfos)
			{
				if (visibleYAxisInfo.Style == YAxisInfoStyle.Value)
				{
					ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
					toolStripMenuItem2.Text = string.Format(DCTimeLineStrings.NewValuePoint_Name, visibleYAxisInfo.Title);
					toolStripMenuItem2.Click += method_13;
					toolStripMenuItem2.Tag = visibleYAxisInfo;
					toolStripMenuItem2.Image = Document.method_53(visibleYAxisInfo);
					btnEditData.DropDownItems.Add(toolStripMenuItem2);
				}
			}
			btnEditData.DropDownItems.Add(new ToolStripSeparator());
			toolStripMenuItem_1 = new ToolStripMenuItem();
			toolStripMenuItem_1.Text = DCTimeLineStrings.DeleteValuePoint;
			toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
			btnEditData.DropDownItems.Add(toolStripMenuItem_1);
			toolStripMenuItem_0 = new ToolStripMenuItem();
			toolStripMenuItem_0.Text = DCTimeLineStrings.DragValuePointFixedTime;
			toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
			btnEditData.DropDownItems.Add(toolStripMenuItem_0);
		}

		/// <summary>
		///       拖拽数据点方法
		///       </summary>
		[ComVisible(true)]
		public void BeginDragValuePointFixDate()
		{
			InnerViewControl.method_44().method_8();
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			BeginDragValuePointFixDate();
		}

		private void method_12(object sender, EventArgs e)
		{
			CancelEditValuePoint();
		}

		/// <summary>
		///       结束编辑数据点
		///       </summary>
		[ComVisible(true)]
		public void CancelEditValuePoint()
		{
			InnerViewControl.method_44().method_5();
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			BeginDeleteValuePoint();
		}

		/// <summary>
		///       删除数据点
		///       </summary>
		[ComVisible(true)]
		public void BeginDeleteValuePoint()
		{
			InnerViewControl.method_44().method_6();
		}

		private void method_13(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			InnerViewControl.method_44().method_9(toolStripMenuItem.Tag as YAxisInfo);
		}

		/// <summary>
		///       开始为指定的数据序列插入数据点
		///       </summary>
		/// <param name="yaxisInfoName">数据序列名称</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public bool BeginInsertValuePointFor(string yaxisInfoName)
		{
			YAxisInfo itemByName = Document.Config.YAxisInfos.GetItemByName(yaxisInfoName);
			if (itemByName != null)
			{
				InnerViewControl.method_44().method_9(itemByName);
				return true;
			}
			return false;
		}

		private void btnEditData_DropDownOpening(object sender, EventArgs e)
		{
			foreach (object dropDownItem in btnEditData.DropDownItems)
			{
				if (dropDownItem is ToolStripMenuItem)
				{
					ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)dropDownItem;
					if (toolStripMenuItem.Tag is YAxisInfo)
					{
						YAxisInfo yaxisInfo_ = (YAxisInfo)toolStripMenuItem.Tag;
						toolStripMenuItem.Checked = InnerViewControl.method_44().method_11(yaxisInfo_);
					}
				}
			}
			if (toolStripMenuItem_1 != null && !toolStripMenuItem_1.IsDisposed)
			{
				toolStripMenuItem_1.Checked = (InnerViewControl.method_44().method_18() == Enum17.const_2);
			}
			if (toolStripMenuItem_0 != null && !toolStripMenuItem_0.IsDisposed)
			{
				toolStripMenuItem_0.Checked = (InnerViewControl.method_44().method_18() == Enum17.const_5);
			}
		}

		protected virtual void vmethod_0()
		{
			if (eventHandler_0 != null)
			{
				if (IsAxControl)
				{
					try
					{
						eventHandler_0(this, null);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					eventHandler_0(this, null);
				}
			}
		}

		/// <summary>
		///       更新控件状态
		///       </summary>
		public void UpdateState()
		{
			pnlView.method_24();
		}

		private void cboPageIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
			method_10(new SelectPageIndexChangeArgs(cboPageIndex.SelectedIndex));
			pnlView.method_13(cboPageIndex.SelectedIndex);
			pnlView.Invalidate();
		}

		private void btnPrintCurrentPage_Click(object sender, EventArgs e)
		{
			pnlView.method_39(pnlView.method_12());
		}

		private void btnPrintAll_Click(object sender, EventArgs e)
		{
			pnlView.method_39(-1);
		}

		/// <summary>
		///       打印当前页
		///       </summary>
		[ComVisible(true)]
		public void PrintCurrentPage()
		{
			if (pnlView.method_10() == DocumentViewMode.Normal || pnlView.method_10() == DocumentViewMode.Page)
			{
				pnlView.method_39(pnlView.method_12());
			}
		}

		/// <summary>
		///       打印指定页
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		[ComVisible(true)]
		public void PrintDocumentSpecifyPageIndex(int pageIndex)
		{
			pnlView.method_39(pageIndex);
		}

		/// <summary>
		///       批量打印指定页
		///       </summary>
		/// <param name="pageIndex">
		/// </param>
		[ComVisible(true)]
		public void PrintDocumentPageIndex(string pageIndex)
		{
			if (pageIndex.IndexOf(",") > 0)
			{
				string[] array = pageIndex.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					try
					{
						pnlView.method_39(int.Parse(array[i]));
					}
					catch (Exception ex)
					{
						throw new ArgumentException(ex.Message);
					}
				}
			}
		}

		/// <summary>
		///       打印所有内容
		///       </summary>
		[ComVisible(true)]
		public void PrintDocument()
		{
			pnlView.method_39(-1);
		}

		/// <summary>
		///       从文本读取器中加载文档
		///       </summary>
		/// <param name="reader">文本读取器</param>
		[ComVisible(false)]
		public void LoadDocument(TextReader reader)
		{
			int num = 3;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			TemperatureDocument temperatureDocument = new TemperatureDocument();
			temperatureDocument.Load(reader);
			method_14(temperatureDocument);
		}

		/// <summary>
		///       从文件流中加载文档
		///       </summary>
		/// <param name="stream">文件流对象</param>
		[ComVisible(false)]
		public void LoadDocument(Stream stream)
		{
			int num = 14;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			TemperatureDocument temperatureDocument = new TemperatureDocument();
			temperatureDocument.Load(stream);
			method_14(temperatureDocument);
		}

		private void method_14(TemperatureDocument temperatureDocument_0)
		{
			pnlView.method_41(temperatureDocument_0);
			method_17();
			method_11();
			Invalidate(invalidateChildren: true);
		}

		/// <summary>
		///       从文件中加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		public void LoadDocumentFromFile(string fileName)
		{
			int num = 19;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			TemperatureDocument temperatureDocument = new TemperatureDocument();
			temperatureDocument.LoadFromFile(fileName);
			method_14(temperatureDocument);
		}

		/// <summary>
		///       从字符串中加载文档
		///       </summary>
		/// <param name="xml">字符串</param>
		[ComVisible(true)]
		public void LoadDocumentFormString(string string_0)
		{
			int num = 9;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("xml");
			}
			TemperatureDocument temperatureDocument = new TemperatureDocument();
			temperatureDocument.LoadFromString(string_0);
			method_14(temperatureDocument);
		}

		/// <summary>
		///       保存文件到流中
		///       </summary>
		/// <param name="stream">文件流对象</param>
		[ComVisible(false)]
		public void SaveDocument(Stream stream)
		{
			Document.Save(stream);
		}

		/// <summary>
		///       保存文件到文本书写器中
		///       </summary>
		/// <param name="writer">文本书写器</param>
		[ComVisible(false)]
		public void SaveDocument(TextWriter writer)
		{
			Document.Save(writer);
		}

		/// <summary>
		///       保存文档到字符串中
		///       </summary>
		/// <returns>生成的字符串</returns>
		[ComVisible(true)]
		public string SaveDocumentToString()
		{
			return Document.SaveToString();
		}

		/// <summary>
		///       保存文档到文件中
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		public void SaveDocumentToFile(string fileName)
		{
			Document.SaveToFile(fileName);
		}

		/// <summary>
		///       保存数据HTML文件
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		public void SaveDataHtmlToFile(string fileName)
		{
			int num = 0;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				SaveDataHtmlToStream(stream);
			}
		}

		/// <summary>
		///       保存数据到HTML文档流中
		///       </summary>
		/// <param name="stream">文件流</param>
		[ComVisible(true)]
		public void SaveDataHtmlToStream(Stream stream)
		{
			int num = 2;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			Document.SaveDataHtml(stream);
		}

		private void method_15()
		{
			if (cboPageIndex.Items.Count != pnlView.method_14().NumOfPages)
			{
				cboPageIndex.Items.Clear();
				for (int i = 0; i < pnlView.method_14().NumOfPages; i++)
				{
					cboPageIndex.Items.Add(Convert.ToString(i + 1));
				}
			}
		}

		private void btnViewMode_DropDownOpening(object sender, EventArgs e)
		{
			btnPageViewMode.Checked = (pnlView.method_10() == DocumentViewMode.Page);
			btnNormalViewMode.Checked = (pnlView.method_10() == DocumentViewMode.Normal);
			btnWidelyViewMode.Checked = (pnlView.method_10() == DocumentViewMode.Timeline);
		}

		private bool method_16()
		{
			if (Document != null && Document.Config.HasTimeLineZones)
			{
				MessageBox.Show(this, DCTimeLineStrings.PromptExistTimeZone, DCTimeLineStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return false;
			}
			return true;
		}

		private void btnNormalViewMode_Click(object sender, EventArgs e)
		{
			if (method_16())
			{
				ViewMode = DocumentViewMode.Normal;
				RefreshViewWithoutRefreshDataSource();
				method_17();
			}
		}

		private void btnPageViewMode_Click(object sender, EventArgs e)
		{
			if (method_16())
			{
				ViewMode = DocumentViewMode.Page;
				RefreshViewWithoutRefreshDataSource();
				method_17();
			}
		}

		private void btnWidelyViewMode_Click(object sender, EventArgs e)
		{
			ViewMode = DocumentViewMode.Timeline;
			RefreshViewWithoutRefreshDataSource();
			method_17();
		}

		private void method_17()
		{
			cboPageIndex.Enabled = (pnlView.method_10() == DocumentViewMode.Page || pnlView.method_10() == DocumentViewMode.Normal);
			btnPrintCurrentPage.Enabled = (pnlView.method_10() == DocumentViewMode.Page || pnlView.method_10() == DocumentViewMode.Normal);
			btnPrintAll.Enabled = btnPrintCurrentPage.Enabled;
			method_15();
			method_18(bool_1: true);
		}

		private void method_18(bool bool_1)
		{
			bool flag = pnlView.method_10() == DocumentViewMode.Timeline;
			if (!FixedTimelineLeftHeader)
			{
				flag = false;
			}
			if (flag)
			{
				pnlView.method_14().method_7();
				if (pnlView.method_14().LeftHeaderPixelWidth <= 0f)
				{
					flag = false;
				}
			}
			if (picLeftHeader.Visible != flag)
			{
				picLeftHeader.Visible = flag;
			}
			if (flag)
			{
				picLeftHeader.BorderStyle = BorderStyle.None;
				pnlView.Refresh();
				picLeftHeader.Width = (int)Math.Ceiling(pnlView.method_14().LeftHeaderPixelWidth) + 1;
				picLeftHeader.Height = pnlView.ClientSize.Height - SystemInformation.HorizontalScrollBarHeight;
				picLeftHeader.Invalidate();
				if (bool_1)
				{
					OnResize(EventArgs.Empty);
				}
			}
		}

		/// <summary>
		///       处理控件大小改变事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			if (picLeftHeader.Visible && base.Width > 10 && base.Height > 10)
			{
				method_19();
				System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
				timer.Interval = 100;
				timer.Tick += method_20;
				timer.Start();
			}
			if (pnlView.method_10() == DocumentViewMode.Timeline || pnlView.method_10() == DocumentViewMode.Normal)
			{
			}
		}

		private void method_19()
		{
			picLeftHeader.BackColor = pnlView.BackColor;
			Rectangle rectangle = new Rectangle(pnlView.Left + SystemInformation.Border3DSize.Width, pnlView.Top + SystemInformation.Border3DSize.Height, picLeftHeader.Width, pnlView.Height - SystemInformation.Border3DSize.Height * 2 - SystemInformation.HorizontalScrollBarHeight);
			if (picLeftHeader.Bounds != rectangle)
			{
				picLeftHeader.Bounds = rectangle;
				picLeftHeader.Invalidate();
			}
		}

		private void method_20(object sender, EventArgs e)
		{
			System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
			timer.Dispose();
			method_19();
		}

		/// <summary>
		///       处理键盘按下事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			base.OnKeyDown(kevent);
			InnerViewControl.method_44().method_15(kevent);
		}

		/// <summary>
		///       显示关于对话框
		///       </summary>
		[ComVisible(true)]
		public void AboutControl()
		{
			pnlView.method_68();
		}

		private void btnCrossLine_Click(object sender, EventArgs e)
		{
			pnlView.method_9(btnCrossLine.Checked);
		}

		private void picLeftHeader_Paint(object sender, PaintEventArgs e)
		{
			if (pnlView.method_14() != null)
			{
				pnlView.method_14().PrintingMode = false;
				e.Graphics.FillRectangle(GClass438.smethod_0(pnlView.method_19()), e.ClipRectangle);
				RectangleF rectangleF_ = GraphicsUnitConvert.Convert(e.ClipRectangle, GraphicsUnit.Pixel, Document.GraphicsUnit);
				e.Graphics.PageUnit = pnlView.method_14().GraphicsUnit;
				e.Graphics.ResetClip();
				pnlView.method_14().method_29(new DCGraphics(e.Graphics), rectangleF_, GEnum22.const_0);
			}
		}

		private void picLeftHeader_MouseClick(object sender, MouseEventArgs e)
		{
			if (pnlView.method_65(e.X + pnlView.AutoScrollPosition.X, e.Y + pnlView.AutoScrollPosition.Y))
			{
				picLeftHeader.Invalidate();
				WinFormUtils.RunOnceDelay(delegate
				{
					picLeftHeader.Invalidate();
				}, 100);
			}
		}

		private void btnEditValue_Click(object sender, EventArgs e)
		{
		}

		private void tsbImportImg_Click(object sender, EventArgs e)
		{
			ExportImage(null);
		}

		/// <summary>
		///       导出图片
		///       </summary>
		public void ExportImg()
		{
			ExportImage(null);
		}

		/// <summary>
		///       导出图片制定地址
		///       </summary>
		/// <param name="SavePath">
		/// </param>
		public bool ExportImg(string SavePath)
		{
			if (!string.IsNullOrEmpty(SavePath))
			{
				ExportImage(SavePath);
				return true;
			}
			return false;
		}

		private bool ExportImage(string path)
		{
			int num = 18;
			if (ViewMode == DocumentViewMode.Page)
			{
				using (Bitmap image = pnlView.method_14().CreateFullContentBmp())
				{
					int width = (int)((double)pnlView.method_14().Width * 0.365);
					int height = (int)((double)pnlView.method_14().Height * 0.345);
					Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.DrawImage(image, 0, 0, new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
					graphics.Dispose();
					if (!string.IsNullOrEmpty(path))
					{
						bitmap.Save(path, ImageFormat.Jpeg);
						return true;
					}
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = Application.StartupPath;
					saveFileDialog.Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";
					if (saveFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
					{
						bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
						MessageBox.Show("保存成功");
						return true;
					}
				}
				return false;
			}
			MessageBox.Show("此功能仅限分页模式下使用");
			return false;
		}

		private void btnDesigner_Click(object sender, EventArgs e)
		{
			RunDesigner();
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.TemperatureChart.TemperatureControl));
			myToolStrip = new System.Windows.Forms.ToolStrip();
			btnViewMode = new System.Windows.Forms.ToolStripDropDownButton();
			btnNormalViewMode = new System.Windows.Forms.ToolStripMenuItem();
			btnPageViewMode = new System.Windows.Forms.ToolStripMenuItem();
			btnWidelyViewMode = new System.Windows.Forms.ToolStripMenuItem();
			btnCrossLine = new System.Windows.Forms.ToolStripButton();
			btnEditValue = new System.Windows.Forms.ToolStripButton();
			toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			cboPageIndex = new System.Windows.Forms.ToolStripComboBox();
			btnPrintCurrentPage = new System.Windows.Forms.ToolStripButton();
			btnPrintAll = new System.Windows.Forms.ToolStripButton();
			btnEditData = new System.Windows.Forms.ToolStripDropDownButton();
			tsbImportImg = new System.Windows.Forms.ToolStripButton();
			picLeftHeader = new System.Windows.Forms.PictureBox();
			pnlView = new DCSoftDotfuscate.GControl1();
			btnDesigner = new System.Windows.Forms.ToolStripButton();
			myToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picLeftHeader).BeginInit();
			SuspendLayout();
			myToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[10]
			{
				btnViewMode,
				btnCrossLine,
				btnEditValue,
				toolStripLabel1,
				cboPageIndex,
				btnPrintCurrentPage,
				btnPrintAll,
				btnEditData,
				tsbImportImg,
				btnDesigner
			});
			resources.ApplyResources(myToolStrip, "myToolStrip");
			myToolStrip.Name = "myToolStrip";
			myToolStrip.ShowItemToolTips = false;
			btnViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				btnNormalViewMode,
				btnPageViewMode,
				btnWidelyViewMode
			});
			resources.ApplyResources(btnViewMode, "btnViewMode");
			btnViewMode.Name = "btnViewMode";
			btnViewMode.DropDownOpening += new System.EventHandler(btnViewMode_DropDownOpening);
			btnNormalViewMode.Name = "btnNormalViewMode";
			resources.ApplyResources(btnNormalViewMode, "btnNormalViewMode");
			btnNormalViewMode.Click += new System.EventHandler(btnNormalViewMode_Click);
			btnPageViewMode.Checked = true;
			btnPageViewMode.CheckState = System.Windows.Forms.CheckState.Checked;
			btnPageViewMode.Name = "btnPageViewMode";
			resources.ApplyResources(btnPageViewMode, "btnPageViewMode");
			btnPageViewMode.Click += new System.EventHandler(btnPageViewMode_Click);
			btnWidelyViewMode.Name = "btnWidelyViewMode";
			resources.ApplyResources(btnWidelyViewMode, "btnWidelyViewMode");
			btnWidelyViewMode.Click += new System.EventHandler(btnWidelyViewMode_Click);
			btnCrossLine.CheckOnClick = true;
			btnCrossLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnCrossLine, "btnCrossLine");
			btnCrossLine.Name = "btnCrossLine";
			btnCrossLine.Click += new System.EventHandler(btnCrossLine_Click);
			btnEditValue.CheckOnClick = true;
			btnEditValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnEditValue, "btnEditValue");
			btnEditValue.Name = "btnEditValue";
			btnEditValue.Click += new System.EventHandler(btnEditValue_Click);
			toolStripLabel1.Name = "toolStripLabel1";
			resources.ApplyResources(toolStripLabel1, "toolStripLabel1");
			cboPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPageIndex.Name = "cboPageIndex";
			resources.ApplyResources(cboPageIndex, "cboPageIndex");
			cboPageIndex.SelectedIndexChanged += new System.EventHandler(cboPageIndex_SelectedIndexChanged);
			btnPrintCurrentPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnPrintCurrentPage, "btnPrintCurrentPage");
			btnPrintCurrentPage.Name = "btnPrintCurrentPage";
			btnPrintCurrentPage.Click += new System.EventHandler(btnPrintCurrentPage_Click);
			btnPrintAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnPrintAll, "btnPrintAll");
			btnPrintAll.Name = "btnPrintAll";
			btnPrintAll.Click += new System.EventHandler(btnPrintAll_Click);
			btnEditData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnEditData, "btnEditData");
			btnEditData.Name = "btnEditData";
			tsbImportImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(tsbImportImg, "tsbImportImg");
			tsbImportImg.Name = "tsbImportImg";
			tsbImportImg.Click += new System.EventHandler(tsbImportImg_Click);
			resources.ApplyResources(picLeftHeader, "picLeftHeader");
			picLeftHeader.Name = "picLeftHeader";
			picLeftHeader.TabStop = false;
			picLeftHeader.Paint += new System.Windows.Forms.PaintEventHandler(picLeftHeader_Paint);
			picLeftHeader.MouseClick += new System.Windows.Forms.MouseEventHandler(picLeftHeader_MouseClick);
			resources.ApplyResources(pnlView, "pnlView");
			pnlView.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			pnlView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			pnlView.Name = "pnlView";
			btnDesigner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnDesigner, "btnDesigner");
			btnDesigner.Name = "btnDesigner";
			btnDesigner.Click += new System.EventHandler(btnDesigner_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(picLeftHeader);
			base.Controls.Add(pnlView);
			base.Controls.Add(myToolStrip);
			base.Name = "TemperatureControl";
			myToolStrip.ResumeLayout(false);
			myToolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picLeftHeader).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		[CompilerGenerated]
		private void method_21(object sender, EventArgs e)
		{
			picLeftHeader.Invalidate();
		}
	}
}

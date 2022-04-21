#define DEBUG
using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印预览控件对象
	///       </summary>
	/// <remarks> 编制 袁永福
	///       本代码部分来自开源代码
	///       <seealso cref="!:http://www.codeproject.com/Articles/35838/An-Enhanced-PrintPreviewDialog" /></remarks>
	[Guid("00012345-6789-ABCD-EF01-234567890082")]
	[ToolboxItem(false)]
	
	
	[ComVisible(true)]
	public class DCPrintPreviewControl : UserControl
	{
		private class Control0 : StandardPrintController
		{
			private DCPrintPreviewControl dcprintPreviewControl_0 = null;

			private int int_0 = 0;

			public Control0(DCPrintPreviewControl dcprintPreviewControl_1)
			{
				dcprintPreviewControl_0 = dcprintPreviewControl_1;
			}

			public override void OnStartPrint(PrintDocument document, PrintEventArgs printEventArgs_0)
			{
				int_0 = 0;
				base.OnStartPrint(document, printEventArgs_0);
				dcprintPreviewControl_0.bool_4 = false;
				dcprintPreviewControl_0.TotalPages = 0;
				dcprintPreviewControl_0.pnlStatus.Visible = true;
				dcprintPreviewControl_0.pnlStatus.Left = (dcprintPreviewControl_0.Width - dcprintPreviewControl_0.pnlStatus.Width) / 2;
				dcprintPreviewControl_0.pnlStatus.Top = (dcprintPreviewControl_0.Height - dcprintPreviewControl_0.pnlStatus.Height) / 2;
				dcprintPreviewControl_0.lblStatus.Text = string.Format(PrintingResources.StartPrint_Name, dcprintPreviewControl_0.PrintPreviewControl.Document.DocumentName);
				dcprintPreviewControl_0.Update();
			}

			public override void OnEndPrint(PrintDocument document, PrintEventArgs printEventArgs_0)
			{
				base.OnEndPrint(document, printEventArgs_0);
				dcprintPreviewControl_0.btnPageIndex.Text = "1/" + dcprintPreviewControl_0.TotalPages;
				dcprintPreviewControl_0.pnlStatus.Visible = false;
			}

			public override Graphics OnStartPage(PrintDocument document, PrintPageEventArgs printPageEventArgs_0)
			{
				int_0++;
				dcprintPreviewControl_0.TotalPages++;
				dcprintPreviewControl_0.lblStatus.Text = string.Format(PrintingResources.PrintintPage_Name_Index, dcprintPreviewControl_0.PrintPreviewControl.Document.DocumentName, Convert.ToString(int_0 + 1));
				Application.DoEvents();
				if (dcprintPreviewControl_0.bool_4)
				{
					printPageEventArgs_0.HasMorePages = false;
					return null;
				}
				return base.OnStartPage(document, printPageEventArgs_0);
			}

			public override void OnEndPage(PrintDocument document, PrintPageEventArgs printPageEventArgs_0)
			{
				base.OnEndPage(document, printPageEventArgs_0);
				Application.DoEvents();
				if (dcprintPreviewControl_0.bool_4)
				{
					printPageEventArgs_0.HasMorePages = false;
				}
			}
		}

		protected const string string_0 = "DoubleColumns";

		protected const string string_1 = "BoundsSelection";

		protected const string string_2 = "Zoom";

		protected const string string_3 = "PrintDocumentExt";

		private IContainer icontainer_0 = null;

		private DCSimplePrintPreviewControl myPrintPreviewControl;

		private ToolStrip mainToolStrip;

		private ToolStripButton tsBtnPrint;

		private ToolStripSeparator toolStripSeparator;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton tsBtnNext;

		private ToolStripButton tsBtnPrev;

		private ToolStripComboBox tsComboZoom;

		private ToolStripButton tsBtnPageSettings;

		private ToolStripButton tsBtnPrinterSettings;

		private ToolStripButton tsBtnZoom;

		private Panel pnlStatus;

		private Button btnCancel;

		private Label lblStatus;

		protected ToolStripButton btnJumpPrint;

		private ToolStripComboBox cboStartPageIndex;

		private ToolStripLabel lblStartPageIndex;

		private ToolStripButton btnPageIndex;

		private ToolStripButton btnSingleColumn;

		private ToolStripButton btnDoubleColumns;

		private ToolStripButton btnBoundsSelection;

		protected ToolStripButton btnPrintManualDuplex;

		private bool bool_0 = true;

		private PageSetupDialog pageSetupDialog_0;

		private PrintDialog printDialog_0;

		private int int_0 = 1;

		private int int_1 = 0;

		private EventHandler eventHandler_0 = null;

		private bool bool_1 = true;

		private bool bool_2 = false;

		private CancelEventHandler cancelEventHandler_0 = null;

		private EventHandler eventHandler_1 = null;

		private bool bool_3 = false;

		private volatile bool bool_4 = false;

		/// <summary>
		///       是否允许控件的事件
		///       </summary>
		/// <remarks>
		///       如果本属性为false，则不触发任何编辑器的事件，不过System.Windows.Forms.Control中定义的事件仍然会触发。
		///       </remarks>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		
		[ComVisible(true)]
		[Browsable(true)]
		[DefaultValue(true)]
		public bool EnabledControlEvent
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
		///       是否允许用户修改打印输出区域
		///       </summary>
		[DefaultValue(true)]
		[ComVisible(true)]
		public bool AllowUserChangePrintArea
		{
			get
			{
				return myPrintPreviewControl.AllowUserChangePrintArea;
			}
			set
			{
				myPrintPreviewControl.AllowUserChangePrintArea = value;
			}
		}

		/// <summary>
		///       主工具条
		///       </summary>
		[Browsable(false)]
		
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStrip MainToolStrip => mainToolStrip;

		/// <summary>
		///       是否显示起始页号
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(true)]
		[ComVisible(true)]
		public bool ShowStartPageIndex
		{
			get
			{
				return cboStartPageIndex.Visible;
			}
			set
			{
				cboStartPageIndex.Visible = value;
				lblStartPageIndex.Visible = value;
			}
		}

		
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int TotalPages
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		/// <summary>
		///       是否显示续打按钮
		///       </summary>
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool JumpPrintButtonVisible
		{
			get
			{
				return btnJumpPrint.Visible;
			}
			set
			{
				btnJumpPrint.Visible = value;
			}
		}

		/// <summary>
		///       是否显示工具条
		///       </summary>
		[DefaultValue(true)]
		
		[Category("Appearance")]
		[ComVisible(true)]
		public bool ToolbarVisible
		{
			get
			{
				return mainToolStrip.Visible;
			}
			set
			{
				mainToolStrip.Visible = value;
			}
		}

		/// <summary>
		///       内置的页面设置对话框
		///       </summary>
		[Browsable(false)]
		private PageSetupDialog PageSetupDialog
		{
			get
			{
				if (pageSetupDialog_0 == null)
				{
					pageSetupDialog_0 = new PageSetupDialog();
				}
				return pageSetupDialog_0;
			}
			set
			{
				pageSetupDialog_0 = value;
			}
		}

		[Browsable(false)]
		private PrintDialog PrintDialog
		{
			get
			{
				if (printDialog_0 == null)
				{
					printDialog_0 = new PrintDialog();
				}
				return printDialog_0;
			}
			set
			{
				printDialog_0 = value;
			}
		}

		/// <summary>
		///       是否显示打印机设置对话框按钮
		///       </summary>
		[DefaultValue(false)]
		
		[Category("Appearance")]
		[ComVisible(true)]
		public bool ShowPrinterSettingsButton
		{
			get
			{
				return tsBtnPrinterSettings.Visible;
			}
			set
			{
				tsBtnPrinterSettings.Visible = value;
				mainToolStrip.Refresh();
			}
		}

		/// <summary>
		///       是否显示页面设置对话框按钮
		///       </summary>
		[DefaultValue(true)]
		[ComVisible(true)]
		
		[Category("Appearance")]
		public bool ShowPageSettingsButton
		{
			get
			{
				return tsBtnPageSettings.Visible;
			}
			set
			{
				tsBtnPageSettings.Visible = value;
			}
		}

		/// <summary>
		///       内置的打印预览控件
		///       </summary>
		[Browsable(false)]
		public DCSimplePrintPreviewControl PrintPreviewControl => myPrintPreviewControl;

		/// <summary>
		///       文档选项
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DCPrintDocumentOptions Options
		{
			get
			{
				return myPrintPreviewControl.Options;
			}
			set
			{
				myPrintPreviewControl.Options = value;
			}
		}

		/// <summary>
		///       内置的打印文档对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual PrintDocument Document
		{
			get
			{
				return myPrintPreviewControl.Document;
			}
			set
			{
				method_3(myPrintPreviewControl.Document, bool_5: false);
				myPrintPreviewControl.Document = value;
				method_3(value, bool_5: true);
			}
		}

		/// <summary>
		///       打印结果
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintResult CurrentPrintResult
		{
			get
			{
				return myPrintPreviewControl.CurrentPrintResult;
			}
			set
			{
				myPrintPreviewControl.CurrentPrintResult = value;
			}
		}

		/// <summary>
		///       页面背景色
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		
		public Color PageBackColor
		{
			get
			{
				return myPrintPreviewControl.PageBackColor;
			}
			set
			{
				myPrintPreviewControl.PageBackColor = value;
			}
		}

		/// <summary>
		///       打印预览区域的背景色
		///       </summary>
		[ComVisible(true)]
		
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color PreviewBackColor
		{
			get
			{
				return myPrintPreviewControl.BackColor;
			}
			set
			{
				myPrintPreviewControl.BackColor = value;
			}
		}

		/// <summary>
		///       缩放比率
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Zoom
		{
			get
			{
				return myPrintPreviewControl.Zoom;
			}
			set
			{
				myPrintPreviewControl.Zoom = value;
			}
		}

		/// <summary>
		///       显示预览时是否启用抗锯齿效果
		///       </summary>
		
		[DefaultValue(false)]
		[ComVisible(true)]
		public bool UseAntiAlias
		{
			get
			{
				return myPrintPreviewControl.UseAntiAlias;
			}
			set
			{
				myPrintPreviewControl.UseAntiAlias = value;
			}
		}

		/// <summary>
		///       打印预览显示的当前页码
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(-1)]
		
		[ComVisible(true)]
		public int StartPage
		{
			get
			{
				return myPrintPreviewControl.StartPage;
			}
			set
			{
				myPrintPreviewControl.StartPage = value;
			}
		}

		/// <summary>
		///       打印前是否显示打印机设置对话框
		///       </summary>
		
		[DefaultValue(true)]
		[ComVisible(true)]
		[Category("Behavior")]
		public bool ShowPrinterSettingsBeforePrint
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

		private int PageIndexFix
		{
			get
			{
				if (myPrintPreviewControl.Document is XPrintDocument)
				{
					return ((XPrintDocument)myPrintPreviewControl.Document).Options.GlobalPageIndexFix;
				}
				return 0;
			}
		}

		/// <summary>
		///       成功的打印文档标记
		///       </summary>
		
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPrintCompleted
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
		///       在触发事件时是否捕获异常
		///       </summary>
		protected virtual bool IsTryCathForRaiseEvent => false;

		/// <summary>
		///       允许在打印预览的时候是否允许设置续打位置
		///       </summary>
		/// <remarks>
		///       如果允许设置，则在生成打印预览内容的时候绘制全部预览内容
		///       </remarks>
		[Category("Behavior")]
		[ComVisible(true)]
		[DefaultValue(false)]
		
		public bool EnableSetJumpPrintPosition
		{
			get
			{
				return PrintPreviewControl.EnableSetJumpPrintPosition;
			}
			set
			{
				PrintPreviewControl.EnableSetJumpPrintPosition = value;
				btnJumpPrint.Visible = value;
			}
		}

		/// <summary>
		///       缩放比率发生改变事件
		///       </summary>
		[Category("Behavior")]
		public event EventHandler ZoomChanged
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
		///       文档打印前事件
		///       </summary>
		public event CancelEventHandler BeforePrint
		{
			add
			{
				CancelEventHandler cancelEventHandler = cancelEventHandler_0;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
				}
				while ((object)cancelEventHandler != cancelEventHandler2);
			}
			remove
			{
				CancelEventHandler cancelEventHandler = cancelEventHandler_0;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
				}
				while ((object)cancelEventHandler != cancelEventHandler2);
			}
		}

		/// <summary>
		///       文档打印完毕事件
		///       </summary>
		public event EventHandler PrintCompleted
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
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.DCPrintPreviewControl));
			mainToolStrip = new System.Windows.Forms.ToolStrip();
			tsBtnPrint = new System.Windows.Forms.ToolStripButton();
			btnPrintManualDuplex = new System.Windows.Forms.ToolStripButton();
			tsBtnPrinterSettings = new System.Windows.Forms.ToolStripButton();
			tsBtnPageSettings = new System.Windows.Forms.ToolStripButton();
			btnJumpPrint = new System.Windows.Forms.ToolStripButton();
			btnBoundsSelection = new System.Windows.Forms.ToolStripButton();
			btnSingleColumn = new System.Windows.Forms.ToolStripButton();
			btnDoubleColumns = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			tsBtnZoom = new System.Windows.Forms.ToolStripButton();
			tsComboZoom = new System.Windows.Forms.ToolStripComboBox();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			tsBtnNext = new System.Windows.Forms.ToolStripButton();
			tsBtnPrev = new System.Windows.Forms.ToolStripButton();
			lblStartPageIndex = new System.Windows.Forms.ToolStripLabel();
			cboStartPageIndex = new System.Windows.Forms.ToolStripComboBox();
			btnPageIndex = new System.Windows.Forms.ToolStripButton();
			pnlStatus = new System.Windows.Forms.Panel();
			btnCancel = new System.Windows.Forms.Button();
			lblStatus = new System.Windows.Forms.Label();
			myPrintPreviewControl = new DCSoft.Printing.DCSimplePrintPreviewControl();
			mainToolStrip.SuspendLayout();
			pnlStatus.SuspendLayout();
			SuspendLayout();
			mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[17]
			{
				tsBtnPrint,
				btnPrintManualDuplex,
				tsBtnPrinterSettings,
				tsBtnPageSettings,
				btnJumpPrint,
				btnBoundsSelection,
				btnSingleColumn,
				btnDoubleColumns,
				toolStripSeparator,
				tsBtnZoom,
				tsComboZoom,
				toolStripSeparator2,
				tsBtnNext,
				tsBtnPrev,
				lblStartPageIndex,
				cboStartPageIndex,
				btnPageIndex
			});
			resources.ApplyResources(mainToolStrip, "mainToolStrip");
			mainToolStrip.Name = "mainToolStrip";
			tsBtnPrint.AutoToolTip = false;
			resources.ApplyResources(tsBtnPrint, "tsBtnPrint");
			tsBtnPrint.Name = "tsBtnPrint";
			tsBtnPrint.Click += new System.EventHandler(tsBtnPrint_Click);
			btnPrintManualDuplex.AutoToolTip = false;
			resources.ApplyResources(btnPrintManualDuplex, "btnPrintManualDuplex");
			btnPrintManualDuplex.Name = "btnPrintManualDuplex";
			btnPrintManualDuplex.Click += new System.EventHandler(btnPrintManualDuplex_Click);
			tsBtnPrinterSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(tsBtnPrinterSettings, "tsBtnPrinterSettings");
			tsBtnPrinterSettings.Name = "tsBtnPrinterSettings";
			tsBtnPrinterSettings.Click += new System.EventHandler(tsBtnPrinterSettings_Click);
			tsBtnPageSettings.AutoToolTip = false;
			resources.ApplyResources(tsBtnPageSettings, "tsBtnPageSettings");
			tsBtnPageSettings.Name = "tsBtnPageSettings";
			tsBtnPageSettings.Click += new System.EventHandler(tsBtnPageSettings_Click);
			btnJumpPrint.AutoToolTip = false;
			btnJumpPrint.CheckOnClick = true;
			resources.ApplyResources(btnJumpPrint, "btnJumpPrint");
			btnJumpPrint.Name = "btnJumpPrint";
			btnJumpPrint.Click += new System.EventHandler(btnJumpPrint_Click);
			btnBoundsSelection.AutoToolTip = false;
			btnBoundsSelection.CheckOnClick = true;
			resources.ApplyResources(btnBoundsSelection, "btnBoundsSelection");
			btnBoundsSelection.Name = "btnBoundsSelection";
			btnBoundsSelection.Click += new System.EventHandler(btnBoundsSelection_Click);
			btnSingleColumn.Checked = true;
			btnSingleColumn.CheckState = System.Windows.Forms.CheckState.Checked;
			btnSingleColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnSingleColumn, "btnSingleColumn");
			btnSingleColumn.Name = "btnSingleColumn";
			btnSingleColumn.Click += new System.EventHandler(btnSingleColumn_Click);
			btnDoubleColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnDoubleColumns, "btnDoubleColumns");
			btnDoubleColumns.Name = "btnDoubleColumns";
			btnDoubleColumns.Click += new System.EventHandler(btnDoubleColumns_Click);
			toolStripSeparator.Name = "toolStripSeparator";
			resources.ApplyResources(toolStripSeparator, "toolStripSeparator");
			resources.ApplyResources(tsBtnZoom, "tsBtnZoom");
			tsBtnZoom.Margin = new System.Windows.Forms.Padding(40, 1, 0, 2);
			tsBtnZoom.Name = "tsBtnZoom";
			tsBtnZoom.Click += new System.EventHandler(tsBtnZoom_Click);
			tsComboZoom.Items.AddRange(new object[10]
			{
				resources.GetString("tsComboZoom.Items"),
				resources.GetString("tsComboZoom.Items1"),
				resources.GetString("tsComboZoom.Items2"),
				resources.GetString("tsComboZoom.Items3"),
				resources.GetString("tsComboZoom.Items4"),
				resources.GetString("tsComboZoom.Items5"),
				resources.GetString("tsComboZoom.Items6"),
				resources.GetString("tsComboZoom.Items7"),
				resources.GetString("tsComboZoom.Items8"),
				resources.GetString("tsComboZoom.Items9")
			});
			tsComboZoom.Name = "tsComboZoom";
			resources.ApplyResources(tsComboZoom, "tsComboZoom");
			tsComboZoom.SelectedIndexChanged += new System.EventHandler(tsComboZoom_Leave);
			tsComboZoom.Leave += new System.EventHandler(tsComboZoom_Leave);
			tsComboZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tsComboZoom_KeyPress);
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			tsBtnNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			tsBtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(tsBtnNext, "tsBtnNext");
			tsBtnNext.Name = "tsBtnNext";
			tsBtnNext.Tag = "next";
			tsBtnNext.Click += new System.EventHandler(tsBtnPrev_Click);
			tsBtnPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			tsBtnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(tsBtnPrev, "tsBtnPrev");
			tsBtnPrev.Name = "tsBtnPrev";
			tsBtnPrev.Tag = "prev";
			tsBtnPrev.Click += new System.EventHandler(tsBtnPrev_Click);
			lblStartPageIndex.Name = "lblStartPageIndex";
			resources.ApplyResources(lblStartPageIndex, "lblStartPageIndex");
			resources.ApplyResources(cboStartPageIndex, "cboStartPageIndex");
			cboStartPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboStartPageIndex.Name = "cboStartPageIndex";
			cboStartPageIndex.SelectedIndexChanged += new System.EventHandler(cboStartPageIndex_SelectedIndexChanged);
			btnPageIndex.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnPageIndex.AutoToolTip = false;
			btnPageIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnPageIndex, "btnPageIndex");
			btnPageIndex.Name = "btnPageIndex";
			btnPageIndex.Click += new System.EventHandler(btnPageIndex_Click);
			pnlStatus.BackColor = System.Drawing.SystemColors.Control;
			pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlStatus.Controls.Add(btnCancel);
			pnlStatus.Controls.Add(lblStatus);
			resources.ApplyResources(pnlStatus, "pnlStatus");
			pnlStatus.Name = "pnlStatus";
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(lblStatus, "lblStatus");
			lblStatus.Name = "lblStatus";
			resources.ApplyResources(myPrintPreviewControl, "myPrintPreviewControl");
			myPrintPreviewControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			myPrintPreviewControl.Name = "myPrintPreviewControl";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.AppWorkspace;
			base.Controls.Add(pnlStatus);
			base.Controls.Add(myPrintPreviewControl);
			base.Controls.Add(mainToolStrip);
			MinimumSize = new System.Drawing.Size(396, 300);
			base.Name = "DCPrintPreviewControl";
			mainToolStrip.ResumeLayout(false);
			mainToolStrip.PerformLayout();
			pnlStatus.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       清除成员数值，DCWriter内部使用。
		///       </summary>
		protected virtual void InnerClearMemberValues()
		{
			bool_3 = false;
			bool_2 = false;
			bool_1 = false;
			myPrintPreviewControl = null;
			btnBoundsSelection = null;
			btnCancel = null;
			btnPageIndex = null;
			btnPrintManualDuplex = null;
			btnSingleColumn = null;
			btnJumpPrint = null;
			lblStartPageIndex = null;
			lblStatus = null;
			mainToolStrip = null;
			pageSetupDialog_0 = null;
			printDialog_0 = null;
			myPrintPreviewControl = null;
			pnlStatus = null;
			toolStripSeparator = null;
			toolStripSeparator2 = null;
			tsBtnNext = null;
			tsBtnPageSettings = null;
			tsBtnPrev = null;
			tsBtnPrint = null;
			tsBtnPrinterSettings = null;
			tsBtnZoom = null;
			tsComboZoom = null;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCPrintPreviewControl()
		{
			InitializeComponent();
			myPrintPreviewControl.StartPageChanged += method_2;
			ShowPrinterSettingsButton = false;
			myPrintPreviewControl.ZoomChanged += method_0;
		}

		private void method_0(object sender, EventArgs e)
		{
			if (EnabledControlEvent && eventHandler_0 != null)
			{
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void method_1(object sender, EventArgs e)
		{
		}

		private void tsBtnPrev_Click(object sender, EventArgs e)
		{
			ToolStripButton toolStripButton = (ToolStripButton)sender;
			int startPage = myPrintPreviewControl.StartPage;
			try
			{
				startPage = ((toolStripButton != tsBtnNext) ? (startPage - int_0) : (startPage + int_0));
				if (startPage < 0)
				{
					startPage = 0;
				}
				if (startPage > int_1 - 1)
				{
					startPage = int_1 - int_0;
				}
				myPrintPreviewControl.StartPage = startPage;
			}
			catch
			{
			}
		}

		private void method_2(object sender, EventArgs e)
		{
			int num = myPrintPreviewControl.StartPage + 1;
			btnPageIndex.Text = num + " / " + myPrintPreviewControl.PageCount;
		}

		private void tsComboZoom_Leave(object sender, EventArgs e)
		{
			int num = 17;
			if (vmethod_0("Zoom"))
			{
				string s = tsComboZoom.Text.Replace("%", "");
				if (double.TryParse(s, out double result))
				{
					try
					{
						myPrintPreviewControl.Zoom = result / 100.0;
					}
					catch
					{
					}
					result = myPrintPreviewControl.Zoom * 100.0;
					tsComboZoom.Text = result + "%";
				}
			}
		}

		private void tsBtnZoom_Click(object sender, EventArgs e)
		{
			tsComboZoom.SelectedIndex = 0;
			tsComboZoom_Leave(null, null);
		}

		private void tsComboZoom_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				tsComboZoom_Leave(null, null);
			}
		}

		private void tsBtnPrint_Click(object sender, EventArgs e)
		{
			PrintDocument(showUI: true);
		}

		
		protected virtual bool vmethod_0(string string_4)
		{
			return true;
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
		public void PrintDocumentExt(bool showUI, string specifyPageIndes)
		{
			if (vmethod_0("PrintDocumentExt"))
			{
				try
				{
					if (string.IsNullOrEmpty(specifyPageIndes))
					{
						PrintDocument(showUI);
					}
					else
					{
						CheckInvalidatePreview();
						PrintDialog.Document = myPrintPreviewControl.Document;
						if (ShowPrinterSettingsBeforePrint && showUI)
						{
							if (myPrintPreviewControl.Document is XPrintDocument)
							{
								XPrintDocument xPrintDocument = (XPrintDocument)myPrintPreviewControl.Document;
								xPrintDocument.Options = myPrintPreviewControl.Options;
								if (xPrintDocument.ShowPrintDialog(this) && vmethod_1())
								{
									xPrintDocument.Options.SetSpecifyPageIndexsByString(specifyPageIndes);
									xPrintDocument.DCPrint(this);
									bool_2 = true;
									vmethod_2();
								}
							}
							else
							{
								PrintDialog.AllowSomePages = true;
								PrintDialog.PrinterSettings.FromPage = 1;
								PrintDialog.PrinterSettings.ToPage = myPrintPreviewControl.PageCount;
								PrintDialog.PrinterSettings.FromPage += PageIndexFix;
								PrintDialog.PrinterSettings.ToPage += PageIndexFix;
								PrintDialog.AllowSomePages = true;
								PrintDialog.AllowSelection = true;
								PrintDialog.AllowCurrentPage = true;
								if (PrintDialog.ShowDialog(this) == DialogResult.OK)
								{
									PrintDialog.PrinterSettings.FromPage -= PageIndexFix;
									PrintDialog.PrinterSettings.ToPage -= PageIndexFix;
									try
									{
										if (vmethod_1())
										{
											myPrintPreviewControl.Document.Print();
											bool_2 = true;
											vmethod_2();
										}
									}
									catch
									{
									}
								}
								else
								{
									PrintDialog.PrinterSettings.FromPage -= PageIndexFix;
									PrintDialog.PrinterSettings.ToPage -= PageIndexFix;
								}
							}
						}
						else if (vmethod_1())
						{
							myPrintPreviewControl.Options.SetSpecifyPageIndexsByString(specifyPageIndes);
							XPrintDocument xPrintDocument = myPrintPreviewControl.Document as XPrintDocument;
							if (xPrintDocument != null)
							{
								xPrintDocument.Options = myPrintPreviewControl.Options;
							}
							myPrintPreviewControl.Document.Print();
							bool_2 = true;
							vmethod_2();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, PrintingResources.PrintError + Environment.NewLine + ex.Message, PrintingResources.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				finally
				{
					myPrintPreviewControl.Options.SpecifyPageIndexs = null;
				}
			}
		}

		/// <summary>
		///       打印文档
		///       </summary>
		/// <param name="showUI">是否显示用户界面</param>
		public void PrintDocument(bool showUI)
		{
			try
			{
				CheckInvalidatePreview();
				PrintDialog.Document = myPrintPreviewControl.Document;
				if (ShowPrinterSettingsBeforePrint && showUI)
				{
					if (myPrintPreviewControl.Document is XPrintDocument)
					{
						XPrintDocument xPrintDocument = (XPrintDocument)myPrintPreviewControl.Document;
						xPrintDocument.Options = myPrintPreviewControl.Options;
						if (xPrintDocument.ShowPrintDialog(this) && vmethod_1())
						{
							xPrintDocument.DCPrint(this);
							bool_2 = true;
							vmethod_2();
						}
					}
					else
					{
						PrintDialog.AllowSomePages = true;
						PrintDialog.PrinterSettings.FromPage = 1;
						PrintDialog.PrinterSettings.ToPage = myPrintPreviewControl.PageCount;
						PrintDialog.PrinterSettings.FromPage += PageIndexFix;
						PrintDialog.PrinterSettings.ToPage += PageIndexFix;
						PrintDialog.AllowSomePages = true;
						PrintDialog.AllowSelection = true;
						PrintDialog.AllowCurrentPage = true;
						if (PrintDialog.ShowDialog(this) == DialogResult.OK)
						{
							PrintDialog.PrinterSettings.FromPage -= PageIndexFix;
							PrintDialog.PrinterSettings.ToPage -= PageIndexFix;
							try
							{
								if (vmethod_1())
								{
									myPrintPreviewControl.Document.Print();
									bool_2 = true;
									vmethod_2();
								}
							}
							catch
							{
							}
						}
						else
						{
							PrintDialog.PrinterSettings.FromPage -= PageIndexFix;
							PrintDialog.PrinterSettings.ToPage -= PageIndexFix;
						}
					}
				}
				else if (vmethod_1())
				{
					myPrintPreviewControl.Document.Print();
					bool_2 = true;
					vmethod_2();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, PrintingResources.PrintError + Environment.NewLine + ex.Message, PrintingResources.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnPrintManualDuplex_Click(object sender, EventArgs e)
		{
			PrintDialog.Document = myPrintPreviewControl.Document;
			if (ShowPrinterSettingsBeforePrint)
			{
				PrintDialog.PrinterSettings.FromPage += PageIndexFix;
				PrintDialog.PrinterSettings.ToPage += PageIndexFix;
				PrintDialog.AllowCurrentPage = false;
				PrintDialog.AllowSelection = false;
				PrintDialog.AllowSomePages = false;
				if (PrintDialog.ShowDialog(this) == DialogResult.OK)
				{
					PrintDialog.PrinterSettings.FromPage -= PageIndexFix;
					PrintDialog.PrinterSettings.ToPage -= PageIndexFix;
					try
					{
						if (vmethod_1() && myPrintPreviewControl.Document is XPrintDocument)
						{
							XPrintDocument xPrintDocument = (XPrintDocument)myPrintPreviewControl.Document;
							xPrintDocument.PrintWithManualDuplex(this);
							bool_2 = true;
							vmethod_2();
						}
					}
					catch
					{
					}
				}
				else
				{
					PrintDialog.PrinterSettings.FromPage -= PageIndexFix;
					PrintDialog.PrinterSettings.ToPage -= PageIndexFix;
				}
			}
			else
			{
				try
				{
					if (vmethod_1() && myPrintPreviewControl.Document is XPrintDocument)
					{
						XPrintDocument xPrintDocument = (XPrintDocument)myPrintPreviewControl.Document;
						xPrintDocument.PrintWithManualDuplex(this);
						bool_2 = true;
						vmethod_2();
					}
				}
				catch
				{
				}
			}
		}

		protected virtual bool vmethod_1()
		{
			int num = 8;
			if (EnabledControlEvent && cancelEventHandler_0 != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				cancelEventArgs.Cancel = false;
				if (IsTryCathForRaiseEvent)
				{
					try
					{
						cancelEventHandler_0(this, cancelEventArgs);
					}
					catch (Exception ex)
					{
						Debug.WriteLine("PrintCompleted:" + ex.Message);
						return true;
					}
				}
				else
				{
					cancelEventHandler_0(this, cancelEventArgs);
				}
				return !cancelEventArgs.Cancel;
			}
			return true;
		}

		protected virtual void vmethod_2()
		{
			int num = 3;
			if (EnabledControlEvent && eventHandler_1 != null)
			{
				if (IsTryCathForRaiseEvent)
				{
					try
					{
						eventHandler_1(this, EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Debug.WriteLine("PrintCompleted:" + ex.Message);
					}
				}
				else
				{
					eventHandler_1(this, EventArgs.Empty);
				}
			}
		}

		private void tsBtnPageSettings_Click(object sender, EventArgs e)
		{
			if (myPrintPreviewControl.Document != null)
			{
				PageSetupDialog.Document = myPrintPreviewControl.Document;
				PageSetupDialog.PageSettings = Document.DefaultPageSettings;
				if (PageSetupDialog.ShowDialog() == DialogResult.OK)
				{
					myPrintPreviewControl.InvalidatePreview();
				}
			}
		}

		private void tsBtnPrinterSettings_Click(object sender, EventArgs e)
		{
			PrintDialog.Document = myPrintPreviewControl.Document;
			PrintDialog.ShowDialog();
		}

		public void CheckInvalidatePreview()
		{
			if (!bool_3)
			{
				InvalidatePreview();
			}
		}

		/// <summary>
		///       刷新文档视图
		///       </summary>
		public virtual void InvalidatePreview()
		{
			if (!base.IsDisposed)
			{
				if (PrintPreviewControl.Document == null)
				{
				}
				using (GClass445.smethod_0(PrintPreviewControl))
				{
					bool flag = false;
					if (PrintPreviewControl.Document is XPrintDocument)
					{
						XPrintDocument xPrintDocument = (XPrintDocument)PrintPreviewControl.Document;
						flag = xPrintDocument.ForPOSPrinter;
					}
					PrintPreviewControl.InvalidatePreview();
					btnJumpPrint.Enabled = !flag;
					btnPrintManualDuplex.Enabled = !flag;
					btnBoundsSelection.Enabled = !flag;
					cboStartPageIndex.Enabled = !flag;
					btnSingleColumn.Enabled = !flag;
					btnDoubleColumns.Enabled = !flag;
					tsBtnNext.Enabled = !flag;
					tsBtnPrev.Enabled = !flag;
					tsBtnZoom.Enabled = !flag;
					tsComboZoom.Enabled = !flag;
					btnPageIndex.Enabled = !flag;
					cboStartPageIndex.Enabled = !flag;
					tsBtnPageSettings.Enabled = !flag;
					DCPrintDocumentOptions options = PrintPreviewControl.Options;
					if (options != null)
					{
						btnJumpPrint.Checked = (options.JumpPrint != null && options.JumpPrint.Enabled);
						btnBoundsSelection.Checked = (options.BoundsSelection != null && options.BoundsSelection.Enable);
					}
					if (PrintPreviewControl.Options != null)
					{
						btnJumpPrint.Checked = PrintPreviewControl.Options.JumpPrint.Enabled;
					}
					btnJumpPrint.Visible = PrintPreviewControl.EnableSetJumpPrintPosition;
					if (btnBoundsSelection.Checked)
					{
						myPrintPreviewControl.Cursor = Cursors.Cross;
					}
					else
					{
						myPrintPreviewControl.Cursor = Cursors.Arrow;
					}
				}
				Update();
				bool_3 = true;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			bool_4 = true;
		}

		private void method_3(PrintDocument printDocument_0, bool bool_5)
		{
			if (printDocument_0 != null)
			{
				if (bool_5)
				{
					printDocument_0.BeginPrint += method_4;
					printDocument_0.PrintPage += method_6;
					printDocument_0.EndPrint += method_5;
				}
				else
				{
					printDocument_0.BeginPrint -= method_4;
					printDocument_0.PrintPage -= method_6;
					printDocument_0.EndPrint -= method_5;
				}
			}
		}

		private void method_4(object sender, PrintEventArgs e)
		{
			if (myPrintPreviewControl.ExecutingInvalidatePreview)
			{
				int_1 = 0;
			}
		}

		private void method_5(object sender, PrintEventArgs e)
		{
			int num = 17;
			if (myPrintPreviewControl.ExecutingInvalidatePreview)
			{
				btnPageIndex.Text = "1 / " + int_1;
			}
		}

		private void method_6(object sender, PrintPageEventArgs e)
		{
			if (myPrintPreviewControl.ExecutingInvalidatePreview)
			{
				int_1++;
			}
		}

		private void btnJumpPrint_Click(object sender, EventArgs e)
		{
			if (myPrintPreviewControl.EnableSetJumpPrintPosition)
			{
				if (myPrintPreviewControl.Options.JumpPrint == null)
				{
					myPrintPreviewControl.Options.JumpPrint = new JumpPrintInfo();
				}
				myPrintPreviewControl.Options.JumpPrint.Enabled = btnJumpPrint.Checked;
				myPrintPreviewControl.Options.BoundsSelection = null;
				myPrintPreviewControl.Options.SpecifyPageIndexs = null;
				btnBoundsSelection.Checked = false;
				myPrintPreviewControl.Invalidate();
				myPrintPreviewControl.Cursor = Cursors.Arrow;
			}
		}

		private void btnBoundsSelection_Click(object sender, EventArgs e)
		{
			if (vmethod_0("BoundsSelection"))
			{
				btnJumpPrint.Checked = false;
				if (myPrintPreviewControl.Options.BoundsSelection == null)
				{
					myPrintPreviewControl.Options.BoundsSelection = new BoundsSelectionPrintInfo();
				}
				myPrintPreviewControl.Options.BoundsSelection.Enable = btnBoundsSelection.Checked;
				myPrintPreviewControl.Options.JumpPrint.Enabled = false;
				btnJumpPrint.Checked = false;
				myPrintPreviewControl.Invalidate();
				if (btnBoundsSelection.Checked)
				{
					myPrintPreviewControl.Cursor = Cursors.Cross;
				}
				else
				{
					myPrintPreviewControl.Cursor = Cursors.Arrow;
				}
			}
		}

		private void cboStartPageIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void btnPageIndex_Click(object sender, EventArgs e)
		{
			using (dlgPageIndex dlgPageIndex = new dlgPageIndex())
			{
				dlgPageIndex.InputMaxPageIndex = myPrintPreviewControl.PageCount;
				dlgPageIndex.InputMinPageIndex = 1;
				int num = myPrintPreviewControl.StartPage + 1;
				if (num < 1)
				{
					dlgPageIndex.InputPageIndex = 1;
				}
				else
				{
					dlgPageIndex.InputPageIndex = num;
				}
				if (dlgPageIndex.ShowDialog(this) == DialogResult.OK)
				{
					int num2 = dlgPageIndex.InputPageIndex - 1;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if (num2 > int_1 - 1)
					{
						num2 = int_1 - int_0;
					}
					myPrintPreviewControl.StartPage = num2;
				}
			}
		}

		private void btnSingleColumn_Click(object sender, EventArgs e)
		{
			myPrintPreviewControl.PageColumns = 1;
			myPrintPreviewControl.InvalidateLayout();
			btnSingleColumn.Checked = true;
			btnDoubleColumns.Checked = false;
		}

		private void btnDoubleColumns_Click(object sender, EventArgs e)
		{
			if (vmethod_0("DoubleColumns"))
			{
				myPrintPreviewControl.PageColumns = 2;
				myPrintPreviewControl.InvalidateLayout();
				btnSingleColumn.Checked = false;
				btnDoubleColumns.Checked = true;
			}
		}
	}
}

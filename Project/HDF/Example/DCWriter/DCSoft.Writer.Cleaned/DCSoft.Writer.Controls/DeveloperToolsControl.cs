using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       DCWriter开发者工具控件对象
	///       </summary>
	[ToolboxItem(false)]
	[ComVisible(false)]
	[DCInternal]
	internal class DeveloperToolsControl : UserControl, IMessageFilter, GInterface18
	{
		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private ToolStripButton btnRefreshDocument;

		private ToolStripButton btnRedraw;

		private SplitContainer splitContainer1;

		private TreeView tvwDOM;

		private PropertyGrid myPropertyGrid;

		private ToolStripButton btnSelectElement;

		private TabControl myTabControl;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TextBox txtLog;

		private ToolStrip tbrLogMessage;

		private ToolStripButton btnClearLog;

		private ToolStripButton btnSelectNode;

		private ToolStripButton btnDebugMode;

		private ToolStripSeparator toolStripSeparator1;

		private TabControl tabControl2;

		private TabPage tabPage3;

		private TabPage tabPage4;

		private PropertyGrid pgStyle;

		private ToolStripButton btnRefreshCurrentLine;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton btnRfreshDOMExt;

		private TabPage tabPage5;

		private ToolStrip toolStrip3;

		private ListView lvwCommand;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private ColumnHeader columnHeader_3;

		private ToolStripButton btnExecuteCommand2;

		private ToolStripButton btnRefreshCommandList;

		private ToolStripButton btnClose;

		private ToolStripButton btnClose2;

		private ToolStripButton btnClose3;

		private ToolStripButton btnRefreshDOM;

		private ToolStripSeparator toolStripSeparator3;

		private TabPage tabPage6;

		private TextBox txtVBScript;

		private ToolStrip toolStrip4;

		private ToolStripButton btnSaveVBScript;

		private ToolStripButton btnClose4;

		private ImageList imageList_0;

		private ToolStripButton btnSaveLog;

		private ToolStripButton btnGlobalDebugConfig;

		private ToolStripDropDownButton toolStripDropDownButton1;

		private ToolStripMenuItem btnLogNoMessage;

		private ToolStripMenuItem btnLogControlMessage;

		private ToolStripMenuItem btnLogAppMessage;

		private TabPage tabPage7;

		private GroupBox groupBox1;

		private TextBox txtDescValue;

		private Label label1;

		private ComboBox cboDescValue;

		private ComboBox cboSourceUnit;

		private TextBox txtSourceValue;

		private TabPage tabPage8;

		private Panel panel1;

		private Panel panel2;

		private Panel panel3;

		private Panel panel4;

		private Label label6;

		private TextBox txtClientWidth;

		private TextBox txtClientHeight;

		private Label label5;

		private TextBox txtPaddingRight;

		private TextBox txtPaddingLeft;

		private TextBox txtPaddingBottom;

		private TextBox txtPaddingTop;

		private Label label4;

		private TextBox txtLeft;

		private TextBox txtTop;

		private Label label3;

		private TextBox txtAbsLeft;

		private TextBox txtAbsTop;

		private Label label2;

		private ComboBox cboMeasureUnit;

		private Label label7;

		private TextBox txtSize;

		private Label label8;

		private Label lblCurrentObject;

		private ToolStripButton btnDeleteNode;

		private DOMTreeManager domtreeManager_0 = null;

		private WriterControl writerControl_0 = null;

		private WriterEventHandler writerEventHandler_0 = null;

		private GClass358 gclass358_0 = null;

		private TreeNode treeNode_0 = null;

		private TreeNode treeNode_1 = null;

		private DOMTreeManager TreeMan
		{
			get
			{
				if (domtreeManager_0 == null)
				{
					domtreeManager_0 = new DOMTreeManager(tvwDOM);
					domtreeManager_0.DynamicLoadChildNodes = true;
					domtreeManager_0.BindingTreeViewEvent();
				}
				domtreeManager_0.WriterControl = WriterControl;
				domtreeManager_0.Document = WriterControl.Document;
				return domtreeManager_0;
			}
		}

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (tvwDOM == null || tvwDOM.IsDisposed)
			{
			}
			if (myPropertyGrid != null && !myPropertyGrid.IsDisposed)
			{
				myPropertyGrid.SelectedObject = null;
			}
			if (domtreeManager_0 != null)
			{
				domtreeManager_0.Dispose();
				domtreeManager_0 = null;
			}
			if (writerControl_0 != null)
			{
				writerControl_0 = null;
			}
			if (treeNode_0 != null)
			{
				treeNode_0 = null;
			}
			if (treeNode_1 != null)
			{
				treeNode_1 = null;
			}
			if (gclass358_0 != null)
			{
				gclass358_0 = null;
			}
			if (pgStyle != null && !pgStyle.IsDisposed)
			{
				pgStyle.SelectedObject = null;
			}
			if (lvwCommand != null && !lvwCommand.IsDisposed)
			{
				lvwCommand.Clear();
			}
			if (txtVBScript != null && !txtVBScript.IsDisposed)
			{
				txtVBScript.Clear();
			}
			if (txtLog != null && !txtLog.IsDisposed)
			{
				txtLog.Clear();
			}
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
			if (WriterControl != null)
			{
				WriterControl.DocumentLoad -= writerEventHandler_0;
				WriterControl = null;
			}
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.DeveloperToolsControl));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnRefreshDOM = new System.Windows.Forms.ToolStripButton();
			btnRfreshDOMExt = new System.Windows.Forms.ToolStripButton();
			btnRefreshCurrentLine = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			btnRefreshDocument = new System.Windows.Forms.ToolStripButton();
			btnRedraw = new System.Windows.Forms.ToolStripButton();
			btnSelectElement = new System.Windows.Forms.ToolStripButton();
			btnSelectNode = new System.Windows.Forms.ToolStripButton();
			btnDeleteNode = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnDebugMode = new System.Windows.Forms.ToolStripButton();
			btnClose = new System.Windows.Forms.ToolStripButton();
			btnGlobalDebugConfig = new System.Windows.Forms.ToolStripButton();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			tvwDOM = new System.Windows.Forms.TreeView();
			tabControl2 = new System.Windows.Forms.TabControl();
			tabPage3 = new System.Windows.Forms.TabPage();
			myPropertyGrid = new System.Windows.Forms.PropertyGrid();
			tabPage4 = new System.Windows.Forms.TabPage();
			pgStyle = new System.Windows.Forms.PropertyGrid();
			tabPage8 = new System.Windows.Forms.TabPage();
			lblCurrentObject = new System.Windows.Forms.Label();
			cboMeasureUnit = new System.Windows.Forms.ComboBox();
			label7 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			txtSize = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			txtClientWidth = new System.Windows.Forms.TextBox();
			txtClientHeight = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtPaddingRight = new System.Windows.Forms.TextBox();
			txtPaddingLeft = new System.Windows.Forms.TextBox();
			txtPaddingBottom = new System.Windows.Forms.TextBox();
			txtPaddingTop = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtLeft = new System.Windows.Forms.TextBox();
			txtTop = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtAbsLeft = new System.Windows.Forms.TextBox();
			txtAbsTop = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			myTabControl = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			txtLog = new System.Windows.Forms.TextBox();
			tbrLogMessage = new System.Windows.Forms.ToolStrip();
			btnClearLog = new System.Windows.Forms.ToolStripButton();
			btnClose2 = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			btnLogNoMessage = new System.Windows.Forms.ToolStripMenuItem();
			btnLogControlMessage = new System.Windows.Forms.ToolStripMenuItem();
			btnLogAppMessage = new System.Windows.Forms.ToolStripMenuItem();
			btnSaveLog = new System.Windows.Forms.ToolStripButton();
			tabPage5 = new System.Windows.Forms.TabPage();
			lvwCommand = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			columnHeader_3 = new System.Windows.Forms.ColumnHeader();
			toolStrip3 = new System.Windows.Forms.ToolStrip();
			btnRefreshCommandList = new System.Windows.Forms.ToolStripButton();
			btnExecuteCommand2 = new System.Windows.Forms.ToolStripButton();
			btnClose3 = new System.Windows.Forms.ToolStripButton();
			tabPage6 = new System.Windows.Forms.TabPage();
			txtVBScript = new System.Windows.Forms.TextBox();
			toolStrip4 = new System.Windows.Forms.ToolStrip();
			btnSaveVBScript = new System.Windows.Forms.ToolStripButton();
			btnClose4 = new System.Windows.Forms.ToolStripButton();
			tabPage7 = new System.Windows.Forms.TabPage();
			groupBox1 = new System.Windows.Forms.GroupBox();
			txtSourceValue = new System.Windows.Forms.TextBox();
			txtDescValue = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			cboDescValue = new System.Windows.Forms.ComboBox();
			cboSourceUnit = new System.Windows.Forms.ComboBox();
			imageList_0 = new System.Windows.Forms.ImageList(icontainer_0);
			toolStrip1.SuspendLayout();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tabControl2.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage4.SuspendLayout();
			tabPage8.SuspendLayout();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			myTabControl.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tbrLogMessage.SuspendLayout();
			tabPage5.SuspendLayout();
			toolStrip3.SuspendLayout();
			tabPage6.SuspendLayout();
			toolStrip4.SuspendLayout();
			tabPage7.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[13]
			{
				btnRefreshDOM,
				btnRfreshDOMExt,
				btnRefreshCurrentLine,
				toolStripSeparator2,
				btnRefreshDocument,
				btnRedraw,
				btnSelectElement,
				btnSelectNode,
				btnDeleteNode,
				toolStripSeparator1,
				btnDebugMode,
				btnClose,
				btnGlobalDebugConfig
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			resources.ApplyResources(btnRefreshDOM, "btnRefreshDOM");
			btnRefreshDOM.Name = "btnRefreshDOM";
			btnRefreshDOM.Click += new System.EventHandler(btnRefreshDOM_Click);
			btnRfreshDOMExt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnRfreshDOMExt, "btnRfreshDOMExt");
			btnRfreshDOMExt.Name = "btnRfreshDOMExt";
			btnRfreshDOMExt.Click += new System.EventHandler(btnRfreshDOMExt_Click);
			btnRefreshCurrentLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnRefreshCurrentLine, "btnRefreshCurrentLine");
			btnRefreshCurrentLine.Name = "btnRefreshCurrentLine";
			btnRefreshCurrentLine.Click += new System.EventHandler(btnRefreshCurrentLine_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			btnRefreshDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnRefreshDocument, "btnRefreshDocument");
			btnRefreshDocument.Name = "btnRefreshDocument";
			btnRefreshDocument.Click += new System.EventHandler(btnRefreshDocument_Click);
			btnRedraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnRedraw, "btnRedraw");
			btnRedraw.Name = "btnRedraw";
			btnRedraw.Click += new System.EventHandler(btnRedraw_Click);
			btnSelectElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnSelectElement, "btnSelectElement");
			btnSelectElement.Name = "btnSelectElement";
			btnSelectElement.Click += new System.EventHandler(btnSelectElement_Click);
			btnSelectNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnSelectNode, "btnSelectNode");
			btnSelectNode.Name = "btnSelectNode";
			btnSelectNode.Click += new System.EventHandler(btnSelectNode_Click);
			btnDeleteNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnDeleteNode, "btnDeleteNode");
			btnDeleteNode.Name = "btnDeleteNode";
			btnDeleteNode.Click += new System.EventHandler(btnDeleteNode_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			btnDebugMode.CheckOnClick = true;
			btnDebugMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnDebugMode, "btnDebugMode");
			btnDebugMode.Name = "btnDebugMode";
			btnDebugMode.Click += new System.EventHandler(btnDebugMode_Click);
			btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.Name = "btnClose";
			btnClose.Click += new System.EventHandler(btnClose3_Click);
			btnGlobalDebugConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnGlobalDebugConfig, "btnGlobalDebugConfig");
			btnGlobalDebugConfig.Name = "btnGlobalDebugConfig";
			btnGlobalDebugConfig.Click += new System.EventHandler(btnGlobalDebugConfig_Click);
			resources.ApplyResources(splitContainer1, "splitContainer1");
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(tvwDOM);
			splitContainer1.Panel2.Controls.Add(tabControl2);
			resources.ApplyResources(tvwDOM, "tvwDOM");
			tvwDOM.HideSelection = false;
			tvwDOM.Name = "tvwDOM";
			tvwDOM.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(tvwDOM_AfterSelect);
			tvwDOM.DoubleClick += new System.EventHandler(tvwDOM_DoubleClick);
			tabControl2.Controls.Add(tabPage3);
			tabControl2.Controls.Add(tabPage4);
			tabControl2.Controls.Add(tabPage8);
			resources.ApplyResources(tabControl2, "tabControl2");
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabPage3.Controls.Add(myPropertyGrid);
			resources.ApplyResources(tabPage3, "tabPage3");
			tabPage3.Name = "tabPage3";
			tabPage3.UseVisualStyleBackColor = true;
			resources.ApplyResources(myPropertyGrid, "myPropertyGrid");
			myPropertyGrid.Name = "myPropertyGrid";
			myPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			myPropertyGrid.ToolbarVisible = false;
			myPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(myPropertyGrid_PropertyValueChanged);
			tabPage4.Controls.Add(pgStyle);
			resources.ApplyResources(tabPage4, "tabPage4");
			tabPage4.Name = "tabPage4";
			tabPage4.UseVisualStyleBackColor = true;
			resources.ApplyResources(pgStyle, "pgStyle");
			pgStyle.Name = "pgStyle";
			pgStyle.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			pgStyle.ToolbarVisible = false;
			tabPage8.Controls.Add(lblCurrentObject);
			tabPage8.Controls.Add(cboMeasureUnit);
			tabPage8.Controls.Add(label7);
			tabPage8.Controls.Add(panel1);
			resources.ApplyResources(tabPage8, "tabPage8");
			tabPage8.Name = "tabPage8";
			tabPage8.UseVisualStyleBackColor = true;
			resources.ApplyResources(lblCurrentObject, "lblCurrentObject");
			lblCurrentObject.Name = "lblCurrentObject";
			lblCurrentObject.Tag = "对象：";
			cboMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboMeasureUnit.FormattingEnabled = true;
			resources.ApplyResources(cboMeasureUnit, "cboMeasureUnit");
			cboMeasureUnit.Name = "cboMeasureUnit";
			cboMeasureUnit.SelectedIndexChanged += new System.EventHandler(cboMeasureUnit_SelectedIndexChanged);
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(txtAbsLeft);
			panel1.Controls.Add(txtAbsTop);
			panel1.Controls.Add(label2);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			panel2.BackColor = System.Drawing.Color.FromArgb(211, 231, 188);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(txtSize);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(txtLeft);
			panel2.Controls.Add(txtTop);
			panel2.Controls.Add(label3);
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtSize, "txtSize");
			txtSize.Name = "txtSize";
			txtSize.ReadOnly = true;
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			panel3.BackColor = System.Drawing.Color.FromArgb(251, 212, 199);
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(panel4);
			panel3.Controls.Add(txtPaddingRight);
			panel3.Controls.Add(txtPaddingLeft);
			panel3.Controls.Add(txtPaddingBottom);
			panel3.Controls.Add(txtPaddingTop);
			panel3.Controls.Add(label4);
			resources.ApplyResources(panel3, "panel3");
			panel3.Name = "panel3";
			panel4.BackColor = System.Drawing.Color.FromArgb(226, 243, 251);
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(label6);
			panel4.Controls.Add(txtClientWidth);
			panel4.Controls.Add(txtClientHeight);
			panel4.Controls.Add(label5);
			resources.ApplyResources(panel4, "panel4");
			panel4.Name = "panel4";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			label6.Click += new System.EventHandler(label6_Click);
			txtClientWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtClientWidth, "txtClientWidth");
			txtClientWidth.Name = "txtClientWidth";
			txtClientWidth.ReadOnly = true;
			txtClientHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtClientHeight, "txtClientHeight");
			txtClientHeight.Name = "txtClientHeight";
			txtClientHeight.ReadOnly = true;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			txtPaddingRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtPaddingRight, "txtPaddingRight");
			txtPaddingRight.Name = "txtPaddingRight";
			txtPaddingRight.ReadOnly = true;
			txtPaddingLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtPaddingLeft, "txtPaddingLeft");
			txtPaddingLeft.Name = "txtPaddingLeft";
			txtPaddingLeft.ReadOnly = true;
			txtPaddingBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtPaddingBottom, "txtPaddingBottom");
			txtPaddingBottom.Name = "txtPaddingBottom";
			txtPaddingBottom.ReadOnly = true;
			txtPaddingTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtPaddingTop, "txtPaddingTop");
			txtPaddingTop.Name = "txtPaddingTop";
			txtPaddingTop.ReadOnly = true;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			txtLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtLeft, "txtLeft");
			txtLeft.Name = "txtLeft";
			txtLeft.ReadOnly = true;
			txtTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtTop, "txtTop");
			txtTop.Name = "txtTop";
			txtTop.ReadOnly = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			txtAbsLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtAbsLeft, "txtAbsLeft");
			txtAbsLeft.Name = "txtAbsLeft";
			txtAbsLeft.ReadOnly = true;
			txtAbsTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(txtAbsTop, "txtAbsTop");
			txtAbsTop.Name = "txtAbsTop";
			txtAbsTop.ReadOnly = true;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			myTabControl.Controls.Add(tabPage1);
			myTabControl.Controls.Add(tabPage2);
			myTabControl.Controls.Add(tabPage5);
			myTabControl.Controls.Add(tabPage6);
			myTabControl.Controls.Add(tabPage7);
			resources.ApplyResources(myTabControl, "myTabControl");
			myTabControl.ImageList = imageList_0;
			myTabControl.Name = "myTabControl";
			myTabControl.SelectedIndex = 0;
			tabPage1.Controls.Add(splitContainer1);
			tabPage1.Controls.Add(toolStrip1);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			tabPage2.Controls.Add(txtLog);
			tabPage2.Controls.Add(tbrLogMessage);
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtLog, "txtLog");
			txtLog.Name = "txtLog";
			tbrLogMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[5]
			{
				btnClearLog,
				btnClose2,
				toolStripSeparator3,
				toolStripDropDownButton1,
				btnSaveLog
			});
			resources.ApplyResources(tbrLogMessage, "tbrLogMessage");
			tbrLogMessage.Name = "tbrLogMessage";
			tbrLogMessage.ShowItemToolTips = false;
			btnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnClearLog, "btnClearLog");
			btnClearLog.Name = "btnClearLog";
			btnClearLog.Click += new System.EventHandler(btnClearLog_Click);
			btnClose2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			resources.ApplyResources(btnClose2, "btnClose2");
			btnClose2.Name = "btnClose2";
			btnClose2.Click += new System.EventHandler(btnClose3_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
			toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				btnLogNoMessage,
				btnLogControlMessage,
				btnLogAppMessage
			});
			resources.ApplyResources(toolStripDropDownButton1, "toolStripDropDownButton1");
			toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			btnLogNoMessage.Checked = true;
			btnLogNoMessage.CheckState = System.Windows.Forms.CheckState.Checked;
			btnLogNoMessage.Name = "btnLogNoMessage";
			resources.ApplyResources(btnLogNoMessage, "btnLogNoMessage");
			btnLogNoMessage.Click += new System.EventHandler(btnLogNoMessage_Click);
			btnLogControlMessage.Name = "btnLogControlMessage";
			resources.ApplyResources(btnLogControlMessage, "btnLogControlMessage");
			btnLogControlMessage.Click += new System.EventHandler(btnLogControlMessage_Click);
			btnLogAppMessage.Name = "btnLogAppMessage";
			resources.ApplyResources(btnLogAppMessage, "btnLogAppMessage");
			btnLogAppMessage.Click += new System.EventHandler(btnLogAppMessage_Click);
			resources.ApplyResources(btnSaveLog, "btnSaveLog");
			btnSaveLog.Name = "btnSaveLog";
			btnSaveLog.Click += new System.EventHandler(btnSaveLog_Click);
			tabPage5.Controls.Add(lvwCommand);
			tabPage5.Controls.Add(toolStrip3);
			resources.ApplyResources(tabPage5, "tabPage5");
			tabPage5.Name = "tabPage5";
			tabPage5.UseVisualStyleBackColor = true;
			lvwCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2,
				columnHeader_3
			});
			resources.ApplyResources(lvwCommand, "lvwCommand");
			lvwCommand.FullRowSelect = true;
			lvwCommand.GridLines = true;
			lvwCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwCommand.HideSelection = false;
			lvwCommand.Name = "lvwCommand";
			lvwCommand.UseCompatibleStateImageBehavior = false;
			lvwCommand.View = System.Windows.Forms.View.Details;
			resources.ApplyResources(columnHeader_0, "columnHeader1");
			resources.ApplyResources(columnHeader_1, "columnHeader2");
			resources.ApplyResources(columnHeader_2, "columnHeader3");
			resources.ApplyResources(columnHeader_3, "columnHeader4");
			toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				btnRefreshCommandList,
				btnExecuteCommand2,
				btnClose3
			});
			resources.ApplyResources(toolStrip3, "toolStrip3");
			toolStrip3.Name = "toolStrip3";
			toolStrip3.ShowItemToolTips = false;
			resources.ApplyResources(btnRefreshCommandList, "btnRefreshCommandList");
			btnRefreshCommandList.Name = "btnRefreshCommandList";
			btnRefreshCommandList.Click += new System.EventHandler(btnRefreshCommandList_Click);
			resources.ApplyResources(btnExecuteCommand2, "btnExecuteCommand2");
			btnExecuteCommand2.Name = "btnExecuteCommand2";
			btnExecuteCommand2.Click += new System.EventHandler(btnExecuteCommand2_Click);
			btnClose3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			resources.ApplyResources(btnClose3, "btnClose3");
			btnClose3.Name = "btnClose3";
			btnClose3.Click += new System.EventHandler(btnClose3_Click);
			tabPage6.Controls.Add(txtVBScript);
			tabPage6.Controls.Add(toolStrip4);
			resources.ApplyResources(tabPage6, "tabPage6");
			tabPage6.Name = "tabPage6";
			tabPage6.UseVisualStyleBackColor = true;
			txtVBScript.AcceptsTab = true;
			resources.ApplyResources(txtVBScript, "txtVBScript");
			txtVBScript.Name = "txtVBScript";
			toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				btnSaveVBScript,
				btnClose4
			});
			resources.ApplyResources(toolStrip4, "toolStrip4");
			toolStrip4.Name = "toolStrip4";
			toolStrip4.ShowItemToolTips = false;
			resources.ApplyResources(btnSaveVBScript, "btnSaveVBScript");
			btnSaveVBScript.Name = "btnSaveVBScript";
			btnSaveVBScript.Click += new System.EventHandler(btnSaveVBScript_Click);
			btnClose4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnClose4.AutoToolTip = false;
			resources.ApplyResources(btnClose4, "btnClose4");
			btnClose4.Name = "btnClose4";
			btnClose4.Click += new System.EventHandler(btnClose4_Click);
			tabPage7.Controls.Add(groupBox1);
			resources.ApplyResources(tabPage7, "tabPage7");
			tabPage7.Name = "tabPage7";
			tabPage7.UseVisualStyleBackColor = true;
			groupBox1.Controls.Add(txtSourceValue);
			groupBox1.Controls.Add(txtDescValue);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(cboDescValue);
			groupBox1.Controls.Add(cboSourceUnit);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(txtSourceValue, "txtSourceValue");
			txtSourceValue.Name = "txtSourceValue";
			txtSourceValue.TextChanged += new System.EventHandler(cboSourceUnit_SelectedIndexChanged);
			resources.ApplyResources(txtDescValue, "txtDescValue");
			txtDescValue.Name = "txtDescValue";
			txtDescValue.ReadOnly = true;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cboDescValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDescValue.FormattingEnabled = true;
			resources.ApplyResources(cboDescValue, "cboDescValue");
			cboDescValue.Name = "cboDescValue";
			cboDescValue.SelectedIndexChanged += new System.EventHandler(cboSourceUnit_SelectedIndexChanged);
			cboSourceUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboSourceUnit.FormattingEnabled = true;
			resources.ApplyResources(cboSourceUnit, "cboSourceUnit");
			cboSourceUnit.Name = "cboSourceUnit";
			cboSourceUnit.SelectedIndexChanged += new System.EventHandler(cboSourceUnit_SelectedIndexChanged);
			imageList_0.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList_0.TransparentColor = System.Drawing.Color.Red;
			imageList_0.Images.SetKeyName(0, "CodeVB.png");
			imageList_0.Images.SetKeyName(1, "list.png");
			imageList_0.Images.SetKeyName(2, "CommandDefault.bmp");
			imageList_0.Images.SetKeyName(3, "TreeView.bmp");
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(myTabControl);
			base.Name = "DeveloperToolsControl";
			base.Load += new System.EventHandler(DeveloperToolsControl_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			tabControl2.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			tabPage4.ResumeLayout(false);
			tabPage8.ResumeLayout(false);
			tabPage8.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			myTabControl.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tbrLogMessage.ResumeLayout(false);
			tbrLogMessage.PerformLayout();
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			toolStrip3.ResumeLayout(false);
			toolStrip3.PerformLayout();
			tabPage6.ResumeLayout(false);
			tabPage6.PerformLayout();
			toolStrip4.ResumeLayout(false);
			toolStrip4.PerformLayout();
			tabPage7.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DeveloperToolsControl()
		{
			InitializeComponent();
		}

		private void DeveloperToolsControl_Load(object sender, EventArgs e)
		{
			int num = 5;
			foreach (object value in Enum.GetValues(typeof(LengthUnit)))
			{
				cboSourceUnit.Items.Add(value);
				cboDescValue.Items.Add(value);
				cboMeasureUnit.Items.Add(value);
			}
			cboSourceUnit.SelectedIndex = 0;
			cboDescValue.SelectedIndex = 0;
			cboMeasureUnit.SelectedIndex = 0;
			WriterCommandControler commandControler = WriterControl.CommandControler;
			WriterCommandList allCommands = commandControler.CommandContainer.AllCommands;
			ImageList imageList = new ImageList();
			lvwCommand.SmallImageList = imageList;
			foreach (WriterCommand item in allCommands)
			{
				ListViewItem listViewItem = new ListViewItem(item.Name);
				listViewItem.SubItems.Add((item.Module == null) ? "" : item.Module.Name);
				listViewItem.SubItems.Add(item.Description);
				if (commandControler.IsCommandEnabled(item.Name))
				{
					listViewItem.SubItems.Add(WriterStrings.Enabled);
				}
				else
				{
					listViewItem.SubItems.Add(WriterStrings.Disable);
				}
				if (item.ToolbarImage != null)
				{
					imageList.Images.Add(item.Name, item.ToolbarImage);
					listViewItem.ImageKey = item.Name;
				}
				lvwCommand.Items.Add(listViewItem);
			}
			writerEventHandler_0 = method_0;
			WriterControl.DocumentLoad += writerEventHandler_0;
			imethod_2(bool_0: false);
			gclass358_0 = new GClass358(txtLog);
			gclass358_0.method_1(bool_3: true);
			gclass358_0.method_5(bool_3: true);
			btnDebugMode.Checked = WriterControl.DocumentOptions.BehaviorOptions.DebugMode;
			Text = Text + " Version:" + WriterControl.ProductVersion;
		}

		public void imethod_0()
		{
			if (gclass358_0 != null)
			{
				gclass358_0.method_1(bool_3: true);
			}
		}

		public void imethod_1()
		{
			if (gclass358_0 != null)
			{
				gclass358_0.method_1(bool_3: false);
			}
		}

		private void method_0(object sender, WriterEventArgs e)
		{
			imethod_2(bool_0: false);
		}

		private void btnRefreshDOM_Click(object sender, EventArgs e)
		{
			imethod_2(bool_0: false);
		}

		private void btnRfreshDOMExt_Click(object sender, EventArgs e)
		{
			imethod_2(bool_0: true);
		}

		public void imethod_2(bool bool_0)
		{
			if (base.IsHandleCreated && !base.IsDisposed)
			{
				treeNode_0 = null;
				myPropertyGrid.SelectedObject = null;
				pgStyle.SelectedObject = null;
				if (WriterControl != null && WriterControl.InnerViewControl != null && tvwDOM.IsHandleCreated && !tvwDOM.IsDisposed)
				{
					Cursor = Cursors.WaitCursor;
					txtVBScript.Text = WriterControl.Document.ScriptText;
					try
					{
						TreeMan.ExactMode = bool_0;
						TreeMan.RefreshViewWriterControlAsRoot();
						myPropertyGrid.Refresh();
						pgStyle.Refresh();
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void method_1()
		{
			TreeMan.RefreshCurrentLine();
		}

		private void tvwDOM_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (tvwDOM.SelectedNode == null)
			{
				myPropertyGrid.SelectedObject = null;
				pgStyle.SelectedObject = null;
			}
			else
			{
				myPropertyGrid.SelectedObject = tvwDOM.SelectedNode.Tag;
				if (tvwDOM.SelectedNode.Tag is XTextElement)
				{
					pgStyle.SelectedObject = ((XTextElement)tvwDOM.SelectedNode.Tag).Style;
				}
				else
				{
					pgStyle.SelectedObject = null;
				}
			}
			method_3();
		}

		private void btnRefreshDocument_Click(object sender, EventArgs e)
		{
			if (WriterControl != null)
			{
				WriterControl.RefreshDocument();
				myPropertyGrid.Refresh();
				pgStyle.Refresh();
			}
		}

		private void btnRedraw_Click(object sender, EventArgs e)
		{
			if (WriterControl != null)
			{
				WriterControl.Refresh();
			}
		}

		private void btnSelectElement_Click(object sender, EventArgs e)
		{
			TreeMan.SelectElementBySelectedNode();
		}

		private void btnClearLog_Click(object sender, EventArgs e)
		{
			txtLog.Text = "";
		}

		private void method_2(object sender, EventArgs e)
		{
			int num = 8;
			if (WriterControl != null && WriterControl.InnerViewControl != null)
			{
				WriterControl.InnerViewControl.Focus();
				WriterControl.ExecuteCommand("ExecuteCommand", showUI: true, null);
			}
		}

		private void tvwDOM_DoubleClick(object sender, EventArgs e)
		{
			TreeMan.SelectElementBySelectedNode();
		}

		private void btnSelectNode_Click(object sender, EventArgs e)
		{
			TreeMan.SelectTreeNodeByCurrentElement();
		}

		private void btnDebugMode_Click(object sender, EventArgs e)
		{
			WriterControl.DocumentOptions.BehaviorOptions.DebugMode = btnDebugMode.Checked;
		}

		private void btnRefreshCurrentLine_Click(object sender, EventArgs e)
		{
			method_1();
		}

		private void btnExecuteCommand2_Click(object sender, EventArgs e)
		{
			if (lvwCommand.FocusedItem != null)
			{
				WriterControl.ExecuteCommand(lvwCommand.FocusedItem.Text, showUI: true, null);
			}
		}

		private void btnRefreshCommandList_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lvwCommand.Items)
			{
				bool flag = WriterControl.IsCommandEnabled(item.Text);
				item.SubItems[3].Text = (flag ? WriterStrings.Enabled : WriterStrings.Disable);
			}
		}

		private void btnClose3_Click(object sender, EventArgs e)
		{
			WriterControl.DeveloperToolsVisible = false;
		}

		bool IMessageFilter.PreFilterMessage(ref Message message_0)
		{
			if (message_0.HWnd != base.Handle && message_0.HWnd != txtLog.Handle && message_0.HWnd != tbrLogMessage.Handle && message_0.HWnd != myTabControl.Handle)
			{
				string text = Environment.NewLine + WinFormUtils.smethod_16(message_0);
				txtLog.AppendText(text);
			}
			return false;
		}

		private void btnSaveVBScript_Click(object sender, EventArgs e)
		{
			WriterControl.Document.ScriptText = txtVBScript.Text;
			WriterControl.Modified = true;
			WriterControl.Document.ResetScriptEngine();
			WriterControl.Document.StartScriptEngine();
			if (WriterControl.Document.ScriptEngine != null)
			{
				CompilerErrorCollection compilerErrors = WriterControl.Document.ScriptEngine.CompilerErrors;
				if (compilerErrors != null && compilerErrors.Count > 0)
				{
					string string_ = string.Format(WriterStrings.HasCompilerErrors_Num, compilerErrors.Count) + Environment.NewLine + WriterControl.Document.ScriptEngine.CompilerErrorMessage;
					WriterControl.UITools.ShowWarringMessageBox(this, string_);
				}
			}
			WriterControl.Invalidate(invalidateChildren: true);
		}

		private void btnClose4_Click(object sender, EventArgs e)
		{
			WriterControl.DeveloperToolsVisible = false;
		}

		private void btnSaveLog_Click(object sender, EventArgs e)
		{
			int num = 1;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "*.txt|*.txt";
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					File.WriteAllText(saveFileDialog.FileName, txtLog.Text);
				}
			}
		}

		private void btnGlobalDebugConfig_Click(object sender, EventArgs e)
		{
			int num = 5;
			if (WriterControl != null)
			{
				WriterControl.ExecuteCommand("GlobalDebugInfo", showUI: true, null);
			}
		}

		private void btnLogNoMessage_Click(object sender, EventArgs e)
		{
			btnLogNoMessage.Checked = true;
			btnLogControlMessage.Checked = false;
			btnLogAppMessage.Checked = false;
			WriterControl.LocalMessageFilters.Remove(this);
			Application.RemoveMessageFilter(this);
		}

		private void btnLogControlMessage_Click(object sender, EventArgs e)
		{
			btnLogNoMessage.Checked = false;
			btnLogControlMessage.Checked = true;
			btnLogAppMessage.Checked = false;
			WriterControl.LocalMessageFilters.Remove(this);
			Application.RemoveMessageFilter(this);
			WriterControl.LocalMessageFilters.Attach(this);
		}

		private void btnLogAppMessage_Click(object sender, EventArgs e)
		{
			btnLogNoMessage.Checked = false;
			btnLogControlMessage.Checked = false;
			btnLogAppMessage.Checked = true;
			WriterControl.LocalMessageFilters.Remove(this);
			Application.RemoveMessageFilter(this);
			Application.AddMessageFilter(this);
		}

		private void myPropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
		{
			int num = 11;
			if (e.ChangedItem.PropertyDescriptor != null && (e.ChangedItem.PropertyDescriptor.Name == "ID" || e.ChangedItem.PropertyDescriptor.Name == "Name" || e.ChangedItem.PropertyDescriptor.Name == "Text") && tvwDOM.SelectedNode != null && tvwDOM.SelectedNode.Tag is XTextElement)
			{
				tvwDOM.SelectedNode.Text = ((XTextElement)tvwDOM.SelectedNode.Tag).DomDisplayName;
			}
			if (myPropertyGrid.SelectedObject is DocumentOptions)
			{
				WriterControl.Invalidate(invalidateChildren: true);
			}
		}

		private void cboSourceUnit_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cboSourceUnit.SelectedIndex >= 0 && cboDescValue.SelectedIndex >= 0)
				{
					txtDescValue.Text = GraphicsUnitConvert.Convert(Convert.ToDouble(txtSourceValue.Text), (LengthUnit)cboSourceUnit.SelectedItem, (LengthUnit)cboDescValue.SelectedItem).ToString();
				}
			}
			catch (Exception ex)
			{
				txtDescValue.Text = ex.Message;
			}
		}

		private void label6_Click(object sender, EventArgs e)
		{
		}

		private void method_3()
		{
			int num = 11;
			LengthUnit newUnit = (LengthUnit)Enum.Parse(typeof(LengthUnit), cboMeasureUnit.Text);
			double num2 = GraphicsUnitConvert.Convert(1.0, LengthUnit.Document, newUnit);
			if (myPropertyGrid.SelectedObject == null)
			{
				lblCurrentObject.Text = Convert.ToString(lblCurrentObject.Tag);
			}
			else
			{
				lblCurrentObject.Text = Convert.ToString(lblCurrentObject.Tag) + myPropertyGrid.SelectedObject.GetType().Name;
			}
			if (myPropertyGrid.SelectedObject is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)myPropertyGrid.SelectedObject;
				txtAbsLeft.Text = method_4((double)xTextElement.AbsLeft * num2);
				txtAbsTop.Text = method_4((double)xTextElement.AbsTop * num2);
				txtLeft.Text = method_4((double)xTextElement.Left * num2);
				txtTop.Text = method_4((double)xTextElement.Top * num2);
				txtSize.Text = "W:" + method_4((double)xTextElement.Width * num2) + " H:" + method_4((double)xTextElement.Height * num2);
				if (xTextElement is XTextContainerElement)
				{
					txtPaddingLeft.Text = method_4((double)xTextElement.Style.PaddingLeft * num2);
					txtPaddingTop.Text = method_4((double)xTextElement.Style.PaddingTop * num2);
					txtPaddingRight.Text = method_4((double)xTextElement.Style.PaddingRight * num2);
					txtPaddingBottom.Text = method_4((double)xTextElement.Style.PaddingBottom * num2);
				}
				else
				{
					txtPaddingLeft.Text = "";
					txtPaddingTop.Text = "";
					txtPaddingRight.Text = "";
					txtPaddingBottom.Text = "";
				}
				txtClientWidth.Text = method_4((double)xTextElement.ClientWidth * num2);
				txtClientHeight.Text = method_4((double)xTextElement.ClientHeight * num2);
			}
			else if (myPropertyGrid.SelectedObject is XTextLine)
			{
				XTextLine xTextLine = (XTextLine)myPropertyGrid.SelectedObject;
				txtAbsLeft.Text = method_4((double)xTextLine.AbsLeft * num2);
				txtAbsTop.Text = method_4((double)xTextLine.AbsTop * num2);
				txtLeft.Text = method_4((double)xTextLine.Left * num2);
				txtTop.Text = method_4((double)xTextLine.Top * num2);
				txtPaddingLeft.Text = method_4((double)xTextLine.PaddingLeft * num2);
				txtPaddingTop.Text = method_4((double)xTextLine.ContentTopFix * num2);
				txtPaddingRight.Text = method_4((double)xTextLine.PaddingRight * num2);
				txtPaddingBottom.Text = "";
				txtClientWidth.Text = method_4((double)xTextLine.ContentWidth * num2);
				txtClientHeight.Text = method_4((double)xTextLine.ContentHeight * num2);
				txtSize.Text = "W:" + method_4((double)xTextLine.Width * num2) + " H:" + method_4((double)xTextLine.Height * num2);
			}
			else
			{
				txtAbsLeft.Text = "";
				txtAbsTop.Text = "";
				txtLeft.Text = "";
				txtTop.Text = "";
				txtSize.Text = "";
				txtClientHeight.Text = "";
				txtClientWidth.Text = "";
				txtPaddingBottom.Text = "";
				txtPaddingLeft.Text = "";
				txtPaddingRight.Text = "";
				txtPaddingTop.Text = "";
			}
		}

		private string method_4(double double_0)
		{
			return double_0.ToString("0.##");
		}

		private void cboMeasureUnit_SelectedIndexChanged(object sender, EventArgs e)
		{
			method_3();
		}

		private void btnDeleteNode_Click(object sender, EventArgs e)
		{
			if (TreeMan.DeleteSelectedNode())
			{
				myPropertyGrid.Refresh();
				pgStyle.Refresh();
			}
		}
	}
}

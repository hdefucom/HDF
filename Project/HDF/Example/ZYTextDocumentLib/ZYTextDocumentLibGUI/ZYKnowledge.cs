using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using XDesignerPrinting;
using ZYCommon;
using ZYTextDocumentLib;

namespace ZYTextDocumentLibGUI
{
	[Guid("86624735-E99A-4374-8029-CEAB6E22E48C")]
	public class ZYKnowledge : UserControl
	{
		public class TreeViewMenuItem : MenuItem
		{
			public int CommandID = 0;

			public ZYKnowledge OwnerForm;

			protected override void OnClick(EventArgs e)
			{
				if (OwnerForm != null)
				{
					OwnerForm.HandleTreeViewCommand(CommandID);
				}
			}

			public TreeViewMenuItem(string vText, int vCommandID)
			{
				base.Text = vText;
				CommandID = vCommandID;
			}

			public TreeViewMenuItem(string vText)
			{
				base.Text = vText;
				CommandID = -1;
			}
		}

		private Thread myInitThread = null;

		private string strIECookie = null;

		private string strServerPage = null;

		private string strDocumentID = null;

		private string strUserName = null;

		private ZYTextDocument myDoc;

		private ZYToolBarGroup tbrCommand;

		private Splitter splitter1;

		private ZYKBListView lvwKBItem;

		private Panel panel2;

		private Button cmdNewKBItem;

		private Button cmdDeleteKBItem;

		private Button cmdItemUP;

		private Button cmdItemDown;

		private Button cmdEditItem;

		private StatusBar myStatuBar;

		private StatusBarPanel stuText;

		private StatusBarPanel stuProgress;

		private ProgressBar myProgress;

		private ToolTip toolTip1;

		private ContextMenu myMenu;

		private Panel panel1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private EMRTabControl myTab;

		private EMRTabPage tabKBItem;

		private EMRTabPage tabText;

		private ZYEditorControl txtEMR;

		private IContainer components;

		private int iAuthrity = 0;

		private EMRTabPage emrTabPage1;

		private EMRTabPage emrTabPage2;

		private ZYToolBarGroup tbrKB;

		private ZYKBTreeView tvwKB;

		private ZYKBTreeView tvwYS;

		private EMRTabControl mytreetab;

		private int designerMode = 0;

		private SimpleXMLConfig myConfig = new SimpleXMLConfig();

		private IDbConnection myConnection = null;

		private TreeNode myTemplateNode = null;

		private ComboBox cboSection = null;

		private SectionList mySectionList = new SectionList();

		private ComboBox mySaveList;

		private ComboBox myMarkList;

		public int DesignerMode
		{
			get
			{
				return designerMode;
			}
			set
			{
				designerMode = value;
			}
		}

		public ZYTextDocument Document => txtEMR.EMRDoc;

		public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
		{
			pdwSupportedOptions = 1;
			pdwEnabledOptions = 2;
		}

		public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
		{
		}

		public ZYKnowledge()
		{
			ZYErrorReport.Instance.Clear();
			ZYErrorReport.Instance.ClearDebugPrint();
			ZYErrorReport.Instance.GetDebugPrint = true;
			ZYErrorReport.Instance.SystemName = "报告编辑器网页版";
			ZYErrorReport.Instance.OperatorName = "默认用户";
			ZYErrorReport.Instance.ReportURL = "http://192.168.0.26/fileview/reporterr.aspx";
			ZYErrorReport.Instance.DebugPrint("程序开始运行");
			try
			{
				InitializeComponent();
				txtEMR.EMRDoc.Info.SavePreViewText = true;
				txtEMR.EMRDoc.Info.ShowAll = false;
				txtEMR.EMRDoc.Info.ShowMark = false;
				txtEMR.EMRDoc.Info.ShowPageLine = false;
				txtEMR.EMRDoc.KBBuffer = ZYKBBuffer.Instance;
				txtEMR.BorderStyle = BorderStyle.None;
				InitPopupMenu();
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = txtEMR;
				ZYErrorReport.Instance.UserMessage = "加载报告编辑控件错误";
				ZYErrorReport.Instance.ShowErrorDialog();
			}
			tvwKB.KBListClick += tvwKB_KBListClick;
			tvwKB.KBItemClick += tvwKB_KBItemClick;
			tvwKB.DragDrop += tvwKB_DragDrop;
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(ZYTextDocumentLibGUI.ZYKnowledge));
			tbrCommand = new ZYCommon.ZYToolBarGroup();
			txtEMR = new ZYTextDocumentLib.ZYEditorControl();
			myMenu = new System.Windows.Forms.ContextMenu();
			splitter1 = new System.Windows.Forms.Splitter();
			lvwKBItem = new ZYTextDocumentLib.ZYKBListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			panel2 = new System.Windows.Forms.Panel();
			cmdEditItem = new System.Windows.Forms.Button();
			cmdItemDown = new System.Windows.Forms.Button();
			cmdItemUP = new System.Windows.Forms.Button();
			cmdDeleteKBItem = new System.Windows.Forms.Button();
			cmdNewKBItem = new System.Windows.Forms.Button();
			myStatuBar = new System.Windows.Forms.StatusBar();
			stuText = new System.Windows.Forms.StatusBarPanel();
			stuProgress = new System.Windows.Forms.StatusBarPanel();
			myProgress = new System.Windows.Forms.ProgressBar();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			panel1 = new System.Windows.Forms.Panel();
			mytreetab = new ZYCommon.EMRTabControl();
			emrTabPage1 = new ZYCommon.EMRTabPage();
			tvwKB = new ZYTextDocumentLib.ZYKBTreeView();
			tbrKB = new ZYCommon.ZYToolBarGroup();
			emrTabPage2 = new ZYCommon.EMRTabPage();
			tvwYS = new ZYTextDocumentLib.ZYKBTreeView();
			myTab = new ZYCommon.EMRTabControl();
			tabKBItem = new ZYCommon.EMRTabPage();
			tabText = new ZYCommon.EMRTabPage();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)stuText).BeginInit();
			((System.ComponentModel.ISupportInitialize)stuProgress).BeginInit();
			panel1.SuspendLayout();
			mytreetab.SuspendLayout();
			emrTabPage1.SuspendLayout();
			emrTabPage2.SuspendLayout();
			myTab.SuspendLayout();
			tabKBItem.SuspendLayout();
			tabText.SuspendLayout();
			SuspendLayout();
			tbrCommand.BarBorder = true;
			tbrCommand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			tbrCommand.Dock = System.Windows.Forms.DockStyle.Top;
			tbrCommand.FloatStyle = true;
			tbrCommand.LeftMargin = 5;
			tbrCommand.Location = new System.Drawing.Point(0, 0);
			tbrCommand.Name = "tbrCommand";
			tbrCommand.ShowIcon = true;
			tbrCommand.ShowText = true;
			tbrCommand.Size = new System.Drawing.Size(543, 64);
			tbrCommand.TabIndex = 1;
			txtEMR.AcceptsTab = true;
			txtEMR.AllowDrop = true;
			txtEMR.AutoScroll = true;
			txtEMR.AutoScrollMinSize = new System.Drawing.Size(753, 1034);
			txtEMR.BackColor = System.Drawing.SystemColors.AppWorkspace;
			txtEMR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtEMR.CaptureMouse = false;
			txtEMR.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEMR.DefaultCursor = System.Windows.Forms.Cursors.Default;
			txtEMR.Dock = System.Windows.Forms.DockStyle.Fill;
			txtEMR.EnableInsertMode = true;
			txtEMR.ForceShowCaret = false;
			txtEMR.GraphicsUnit = System.Drawing.GraphicsUnit.Document;
			txtEMR.InnerToolTipVisible = false;
			txtEMR.InsertMode = true;
			txtEMR.Location = new System.Drawing.Point(0, 64);
			txtEMR.MouseDragScroll = false;
			txtEMR.MoveCaretWithScroll = true;
			txtEMR.Name = "txtEMR";
			txtEMR.PageBackColor = System.Drawing.Color.White;
			txtEMR.PageIndex = 0;
			txtEMR.PageSpacing = 10;
			txtEMR.RunInIE = false;
			txtEMR.ScrollFlag = false;
			txtEMR.Size = new System.Drawing.Size(543, 416);
			txtEMR.TabIndex = 2;
			txtEMR.UseAbsTransformPoint = false;
			txtEMR.UserLevel = 0;
			txtEMR.ViewAutoScrollMinSize = new System.Drawing.Size(2353, 3231);
			txtEMR.ViewAutoScrollPosition = new System.Drawing.Point(0, 0);
			txtEMR.ViewBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
			txtEMR.ViewMode = XDesignerPrinting.PageViewMode.Page;
			txtEMR.WordWrap = false;
			txtEMR.XZoomRate = 1f;
			txtEMR.YZoomRate = 1f;
			splitter1.BackColor = System.Drawing.SystemColors.Control;
			splitter1.Location = new System.Drawing.Point(175, 0);
			splitter1.Name = "splitter1";
			splitter1.Size = new System.Drawing.Size(5, 503);
			splitter1.TabIndex = 4;
			splitter1.TabStop = false;
			lvwKBItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4]
			{
				columnHeader1,
				columnHeader2,
				columnHeader3,
				columnHeader4
			});
			lvwKBItem.Dock = System.Windows.Forms.DockStyle.Fill;
			lvwKBItem.FullRowSelect = true;
			lvwKBItem.GridLines = true;
			lvwKBItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwKBItem.HideSelection = false;
			lvwKBItem.KBBuffer = null;
			lvwKBItem.LabelEdit = true;
			lvwKBItem.Location = new System.Drawing.Point(0, 32);
			lvwKBItem.Name = "lvwKBItem";
			lvwKBItem.OwnerKBList = null;
			lvwKBItem.ShowChildKBList = false;
			lvwKBItem.Size = new System.Drawing.Size(543, 448);
			lvwKBItem.TabIndex = 0;
			lvwKBItem.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "项目文本";
			columnHeader1.Width = 150;
			columnHeader2.Text = "项目值";
			columnHeader2.Width = 150;
			columnHeader3.Text = "类型";
			columnHeader3.Width = 90;
			columnHeader4.Text = "编号";
			columnHeader4.Width = 80;
			panel2.BackColor = System.Drawing.SystemColors.Control;
			panel2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("panel2.BackgroundImage");
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel2.Controls.Add(cmdEditItem);
			panel2.Controls.Add(cmdItemDown);
			panel2.Controls.Add(cmdItemUP);
			panel2.Controls.Add(cmdDeleteKBItem);
			panel2.Controls.Add(cmdNewKBItem);
			panel2.Dock = System.Windows.Forms.DockStyle.Top;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(543, 32);
			panel2.TabIndex = 1;
			cmdEditItem.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdEditItem.BackgroundImage");
			cmdEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			cmdEditItem.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEditItem.Image = (System.Drawing.Image)resourceManager.GetObject("cmdEditItem.Image");
			cmdEditItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdEditItem.Location = new System.Drawing.Point(160, 3);
			cmdEditItem.Name = "cmdEditItem";
			cmdEditItem.Size = new System.Drawing.Size(104, 23);
			cmdEditItem.TabIndex = 7;
			cmdEditItem.Text = "编辑列表项目";
			cmdEditItem.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			cmdEditItem.Click += new System.EventHandler(cmdEditItem_Click);
			cmdItemDown.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdItemDown.BackgroundImage");
			cmdItemDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			cmdItemDown.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdItemDown.Image = (System.Drawing.Image)resourceManager.GetObject("cmdItemDown.Image");
			cmdItemDown.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdItemDown.Location = new System.Drawing.Point(448, 3);
			cmdItemDown.Name = "cmdItemDown";
			cmdItemDown.Size = new System.Drawing.Size(56, 23);
			cmdItemDown.TabIndex = 3;
			cmdItemDown.Text = "下移";
			cmdItemDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cmdItemDown.Click += new System.EventHandler(cmdItemDown_Click);
			cmdItemUP.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdItemUP.BackgroundImage");
			cmdItemUP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			cmdItemUP.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdItemUP.Image = (System.Drawing.Image)resourceManager.GetObject("cmdItemUP.Image");
			cmdItemUP.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdItemUP.Location = new System.Drawing.Point(384, 3);
			cmdItemUP.Name = "cmdItemUP";
			cmdItemUP.Size = new System.Drawing.Size(56, 23);
			cmdItemUP.TabIndex = 2;
			cmdItemUP.Text = "上移";
			cmdItemUP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cmdItemUP.Click += new System.EventHandler(cmdItemUP_Click);
			cmdDeleteKBItem.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdDeleteKBItem.BackgroundImage");
			cmdDeleteKBItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			cmdDeleteKBItem.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDeleteKBItem.Image = (System.Drawing.Image)resourceManager.GetObject("cmdDeleteKBItem.Image");
			cmdDeleteKBItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdDeleteKBItem.Location = new System.Drawing.Point(320, 3);
			cmdDeleteKBItem.Name = "cmdDeleteKBItem";
			cmdDeleteKBItem.Size = new System.Drawing.Size(56, 23);
			cmdDeleteKBItem.TabIndex = 1;
			cmdDeleteKBItem.Text = "删除";
			cmdDeleteKBItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cmdDeleteKBItem.Click += new System.EventHandler(cmdDeleteKBItem_Click);
			cmdNewKBItem.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdNewKBItem.BackgroundImage");
			cmdNewKBItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			cmdNewKBItem.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdNewKBItem.Image = (System.Drawing.Image)resourceManager.GetObject("cmdNewKBItem.Image");
			cmdNewKBItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdNewKBItem.Location = new System.Drawing.Point(40, 3);
			cmdNewKBItem.Name = "cmdNewKBItem";
			cmdNewKBItem.Size = new System.Drawing.Size(110, 23);
			cmdNewKBItem.TabIndex = 0;
			cmdNewKBItem.Text = "新增列表项目";
			cmdNewKBItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cmdNewKBItem.Click += new System.EventHandler(cmdNewKBItem_Click);
			myStatuBar.Location = new System.Drawing.Point(0, 503);
			myStatuBar.Name = "myStatuBar";
			myStatuBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[2]
			{
				stuText,
				stuProgress
			});
			myStatuBar.ShowPanels = true;
			myStatuBar.Size = new System.Drawing.Size(727, 22);
			myStatuBar.TabIndex = 6;
			myStatuBar.Text = "statusBar1";
			myStatuBar.DoubleClick += new System.EventHandler(myStatuBar_DoubleClick);
			stuText.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			stuText.Text = "状态";
			stuText.Width = 511;
			stuProgress.Width = 200;
			myProgress.Location = new System.Drawing.Point(325, 508);
			myProgress.Name = "myProgress";
			myProgress.Size = new System.Drawing.Size(186, 16);
			myProgress.TabIndex = 7;
			myProgress.Value = 11;
			myProgress.Visible = false;
			panel1.Controls.Add(mytreetab);
			panel1.Dock = System.Windows.Forms.DockStyle.Left;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(175, 503);
			panel1.TabIndex = 13;
			mytreetab.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("mytreetab.BackgroundImage");
			mytreetab.ButtonImage = (System.Drawing.Image)resourceManager.GetObject("mytreetab.ButtonImage");
			mytreetab.ClientBackColor = System.Drawing.SystemColors.Control;
			mytreetab.ClientBorderColor = System.Drawing.Color.Black;
			mytreetab.Controls.Add(emrTabPage1);
			mytreetab.Controls.Add(emrTabPage2);
			mytreetab.Dock = System.Windows.Forms.DockStyle.Fill;
			mytreetab.Location = new System.Drawing.Point(0, 0);
			mytreetab.Name = "mytreetab";
			mytreetab.PageTagSize = 25;
			mytreetab.SelectedIndex = -1;
			mytreetab.SelectedTab = emrTabPage1;
			mytreetab.Size = new System.Drawing.Size(175, 503);
			mytreetab.TabIndex = 1;
			emrTabPage1.Caption = null;
			emrTabPage1.Controls.Add(tvwKB);
			emrTabPage1.Controls.Add(tbrKB);
			emrTabPage1.Location = new System.Drawing.Point(2, 26);
			emrTabPage1.Name = "emrTabPage1";
			emrTabPage1.Size = new System.Drawing.Size(171, 475);
			emrTabPage1.TabIndex = 0;
			tvwKB.BindControl = null;
			tvwKB.ContextMenu = myMenu;
			tvwKB.DesignKBMode = true;
			tvwKB.Dock = System.Windows.Forms.DockStyle.Fill;
			tvwKB.DoubleClickMode = false;
			tvwKB.HideSelection = false;
			tvwKB.Indent = 14;
			tvwKB.ItemHeight = 18;
			tvwKB.KBBuffer = null;
			tvwKB.LabelEdit = true;
			tvwKB.Location = new System.Drawing.Point(0, 56);
			tvwKB.Name = "tvwKB";
			tvwKB.RootKBList = null;
			tvwKB.SelectedKBList = null;
			tvwKB.ShowKBItem = false;
			tvwKB.ShowNormalKBItem = false;
			tvwKB.ShowSystemKBItem = false;
			tvwKB.ShowTemplateKBItem = false;
			tvwKB.Size = new System.Drawing.Size(171, 419);
			tvwKB.TabIndex = 15;
			tbrKB.BackColor = System.Drawing.SystemColors.Control;
			tbrKB.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tbrKB.BackgroundImage");
			tbrKB.BarBorder = true;
			tbrKB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			tbrKB.Dock = System.Windows.Forms.DockStyle.Top;
			tbrKB.FloatStyle = true;
			tbrKB.LeftMargin = 5;
			tbrKB.Location = new System.Drawing.Point(0, 0);
			tbrKB.Name = "tbrKB";
			tbrKB.ShowIcon = true;
			tbrKB.ShowText = true;
			tbrKB.Size = new System.Drawing.Size(171, 56);
			tbrKB.TabIndex = 14;
			emrTabPage2.Caption = null;
			emrTabPage2.Controls.Add(tvwYS);
			emrTabPage2.Location = new System.Drawing.Point(2, 26);
			emrTabPage2.Name = "emrTabPage2";
			emrTabPage2.Size = new System.Drawing.Size(171, 475);
			emrTabPage2.TabIndex = 0;
			tvwYS.BindControl = null;
			tvwYS.DesignKBMode = true;
			tvwYS.Dock = System.Windows.Forms.DockStyle.Fill;
			tvwYS.DoubleClickMode = false;
			tvwYS.HideSelection = false;
			tvwYS.Indent = 14;
			tvwYS.ItemHeight = 18;
			tvwYS.KBBuffer = null;
			tvwYS.LabelEdit = true;
			tvwYS.Location = new System.Drawing.Point(0, 0);
			tvwYS.Name = "tvwYS";
			tvwYS.RootKBList = null;
			tvwYS.SelectedKBList = null;
			tvwYS.ShowKBItem = false;
			tvwYS.ShowNormalKBItem = false;
			tvwYS.ShowSystemKBItem = false;
			tvwYS.ShowTemplateKBItem = false;
			tvwYS.Size = new System.Drawing.Size(171, 475);
			tvwYS.TabIndex = 15;
			myTab.BackColor = System.Drawing.Color.White;
			myTab.ButtonImage = (System.Drawing.Image)resourceManager.GetObject("myTab.ButtonImage");
			myTab.ClientBackColor = System.Drawing.Color.FromArgb(235, 238, 243);
			myTab.ClientBorderColor = System.Drawing.Color.FromArgb(123, 148, 176);
			myTab.Controls.Add(tabKBItem);
			myTab.Controls.Add(tabText);
			myTab.Dock = System.Windows.Forms.DockStyle.Fill;
			myTab.Location = new System.Drawing.Point(180, 0);
			myTab.Name = "myTab";
			myTab.PageTagSize = 20;
			myTab.SelectedIndex = -1;
			myTab.SelectedTab = tabKBItem;
			myTab.Size = new System.Drawing.Size(547, 503);
			myTab.TabIndex = 5;
			myTab.EnableClickChange = false;
			myTab.SelectedIndexChanged += new System.EventHandler(myTab_SelectedIndexChanged);
			tabKBItem.Caption = "知识库列表";
			tabKBItem.Controls.Add(lvwKBItem);
			tabKBItem.Controls.Add(panel2);
			tabKBItem.Location = new System.Drawing.Point(2, 21);
			tabKBItem.Name = "tabKBItem";
			tabKBItem.Size = new System.Drawing.Size(543, 480);
			tabKBItem.TabIndex = 1;
			tabText.Caption = "报告模板";
			tabText.Controls.Add(txtEMR);
			tabText.Controls.Add(tbrCommand);
			tabText.Location = new System.Drawing.Point(2, 21);
			tabText.Name = "tabText";
			tabText.Size = new System.Drawing.Size(543, 480);
			tabText.TabIndex = 0;
			base.Controls.Add(myProgress);
			base.Controls.Add(myTab);
			base.Controls.Add(splitter1);
			base.Controls.Add(panel1);
			base.Controls.Add(myStatuBar);
			base.Name = "ZYKnowledge";
			base.Size = new System.Drawing.Size(727, 525);
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)stuText).EndInit();
			((System.ComponentModel.ISupportInitialize)stuProgress).EndInit();
			panel1.ResumeLayout(false);
			mytreetab.ResumeLayout(false);
			emrTabPage1.ResumeLayout(false);
			emrTabPage2.ResumeLayout(false);
			myTab.ResumeLayout(false);
			tabKBItem.ResumeLayout(false);
			tabText.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void InitToolbar()
		{
			myTab.SelectedTab = tabKBItem;
			SetWindowTitle(null);
			SetStatusText("正在初始化程序..");
			txtEMR.KBTreeView = tvwKB;
			myConfig.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("ZYTextDocumentLib.Config.config.xml"));
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("ZYTextDocumentLib.Config.toolbardef.xml"));
				tbrCommand.ShowText = false;
				tbrCommand.BorderStyle = BorderStyle.None;
				tbrCommand.FromXML((XmlElement)xmlDocument.SelectSingleNode("*/emrtoolbars[@name='main']"), Path.Combine(ZYPublic.WebServerUrl, "ButtonImage"));
				tbrKB.ShowText = false;
				tbrKB.BorderStyle = BorderStyle.None;
				tbrKB.FromXML((XmlElement)xmlDocument.SelectSingleNode("*/emrtoolbars[@name='kb']"), Path.Combine(ZYPublic.WebServerUrl, "ButtonImage"));
				tbrKB.OnButtonClick += tbrKB_OnButtonClick;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			myDoc = txtEMR.EMRDoc;
			myDoc.Info.LogicDelete = false;
			myDoc.Info.AutoLogicDelete = false;
			myDoc.Info.EnableSaveLog = false;
			myDoc.Info.DesignMode = true;
			foreach (ZYToolBarGroup.ZYToolBarButton button in tbrCommand.Buttons)
			{
				button.Action = myDoc.GetActionByName(button.Command);
			}
			myDoc.OnSelectionChanged += DocumentSelectionChanged;
		}

		private void InitForm()
		{
			lvwKBItem.KBBuffer = ZYKBBuffer.Instance;
			lvwKBItem.SmallImageList = tvwKB.ImageList;
			lvwKBItem.ShowChildKBList = true;
			lvwKBItem.AfterLabelEdit += lvwKBItem_AfterLabelEdit;
			lvwKBItem.DoubleClick += lvwKBItem_DoubleClick;
			lvwKBItem.StatusTextChange += lvwKBItem_StatusTextChange;
			SetWindowTitle(null);
			A_SaveDBFile a_SaveDBFile = myDoc.GetActionByName("savedbfile") as A_SaveDBFile;
			if (a_SaveDBFile != null)
			{
				a_SaveDBFile.OnSave = OnEMRDocSaved;
			}
			if (tvwKB.Nodes.Count > 0)
			{
				tvwKB.SelectedNode = tvwKB.Nodes[0];
			}
			Cursor = Cursors.Default;
			SetStatusText("就绪");
			txtEMR.EMRDoc.Info.ShowAll = true;
			txtEMR.EMRDoc.Info.ShowMark = true;
			txtEMR.EMRDoc.Info.DesignMode = true;
			txtEMR.RunInDesigner = true;
			txtEMR.BorderStyle = BorderStyle.Fixed3D;
			ZYToolBarGroup.ZYToolBarButton button = tbrCommand.GetButton("marklevel");
			if (button != null)
			{
				myMarkList = (button.InnerControl as ComboBox);
				myMarkList.SelectedIndexChanged += myMarkList_SelectedIndexChanged;
			}
			button = tbrCommand.GetButton("savelevel");
			if (button != null)
			{
				mySaveList = (button.InnerControl as ComboBox);
				mySaveList.SelectedIndexChanged += mySaveList_SelectedIndexChanged;
			}
			if (DesignerMode == 0)
			{
				myTab.TabPages.AddRange(new EMRTabPage[1]
				{
					tabText
				});
				emrTabPage1.Caption = "报告模板库";
				emrTabPage2.Caption = "报告元素库";
				mytreetab.TabPages.AddRange(new EMRTabPage[2]
				{
					emrTabPage1,
					emrTabPage2
				});
			}
			else
			{
				myTab.TabPages.AddRange(new EMRTabPage[2]
				{
					tabKBItem,
					tabText
				});
				emrTabPage1.Caption = "报告元素库";
				ZYKBBuffer.Instance.Mod = 1;
				mytreetab.TabPages.AddRange(new EMRTabPage[1]
				{
					emrTabPage1
				});
			}
		}

		public bool InitForIE(string strCookie, string strPage, string strID, string vUserName, string strKBListSql, string strKBItemSql, int iAuth, int Dmod, string YSID, string YSkbsql, string YSitemsql, string info, string webUrl)
		{
			myTab.TabPages.Clear();
			mytreetab.TabPages.Clear();
			DesignerMode = Dmod;
			if (DesignerMode == 1)
			{
				lvwKBItem.Items.Clear();
				cmdNewKBItem.Enabled = false;
			}
			else
			{
				txtEMR.Document.ClearContent();
				txtEMR.Document.OwnerKBItem = null;
			}
			ZYKBBuffer.Instance.Mod = Dmod;
			iAuthrity = iAuth;
			ZYKBBuffer.Instance.KeyPreFix = strID;
			ZYKBBuffer.Instance.Custom_KBLIST_SQL = strKBListSql;
			ZYKBBuffer.Instance.Custom_KBITEM_SQL = strKBItemSql;
			ZYKBBuffer.Instance.OwnerSection = strID;
			ZYPublic.WebServerUrl = webUrl;
			ZYKBBufferYS.Instance.KeyPreFix = YSID;
			ZYKBBufferYS.Instance.Custom_KBLIST_SQL = YSkbsql;
			ZYKBBufferYS.Instance.Custom_KBITEM_SQL = YSitemsql;
			ZYKBBufferYS.Instance.OwnerSection = YSID;
			string[] array = info.Split('|');
			if (array[0] == "1")
			{
				ZYPublic.StandardMode = true;
			}
			else
			{
				ZYPublic.StandardMode = false;
			}
			if (array.Length > 1)
			{
				ZYPublic.ModalityName = array[1];
			}
			KB_List.strDeptment = strID;
			KB_Item.strDeptment = strID;
			ET_Document.strDeptment = strID;
			try
			{
				if (myInitThread != null)
				{
					myInitThread.Abort();
				}
				tvwKB.Nodes.Clear();
				tvwKB.Nodes.Add("正在加载数据,请稍候...");
				tvwYS.Nodes.Clear();
				tvwYS.Nodes.Add("正在加载数据,请稍候...");
				strIECookie = strCookie;
				strServerPage = strPage;
				strDocumentID = strID;
				strUserName = vUserName;
				if (txtEMR.InitForIE(strCookie, strPage, strID, vUserName))
				{
					myInitThread = new Thread(EMRInit);
					myInitThread.IsBackground = true;
					myInitThread.Start();
				}
				if (myDoc == null)
				{
					InitToolbar();
				}
				InitForm();
				LoadXML(ZYConfig.NewFileXml);
				myTab.CallResize();
				txtEMR.CallOnResize();
				mytreetab.RefreshTagHead();
				return true;
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = this;
				ZYErrorReport.Instance.MemberName = "EMREditPanle.InitForIE";
				ZYErrorReport.Instance.UserMessage = "初始化网页控件错误";
				ZYErrorReport.Instance.ReportError();
			}
			return false;
		}

		private void EMRInit()
		{
			try
			{
				if (!ZYKBBuffer.Instance.Loading && base.IsHandleCreated)
				{
					object[] array = new object[2];
					object[] args = array;
					BeginInvoke(new EventHandler(RefreshKBTreeView), args);
				}
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.UserMessage = "加载报告知识库错误";
				ZYErrorReport.Instance.MemberName = "ZYEditPanel.EMRInit";
				ZYErrorReport.Instance.ShowErrorDialog();
			}
		}

		private void OpenDB()
		{
			txtEMR.EMRDoc.DataSource.DBConn.Open();
		}

		public void RefreshKBTreeView(object obj, EventArgs e)
		{
			if (myInitThread != null)
			{
				myInitThread = null;
			}
			ZYKBTreeView.RunInDesigner = true;
			txtEMR.RunInDesigner = true;
			tvwKB.Nodes.Clear();
			tvwKB.Nodes.Add("正在加载列表，请稍候...");
			tvwKB.Refresh();
			ZYKBBuffer.Instance.Connection = txtEMR.EMRDoc.DataSource.DBConn;
			ZYKBBuffer.Instance.DesignMode = true;
			LoadAllData();
			tvwKB.RootKBList = ZYKBBuffer.Instance.RootList;
			tvwKB.KBBuffer = ZYKBBuffer.Instance;
			tvwKB.ShowKBItem = true;
			tvwKB.ShowTemplateKBItem = true;
			tvwKB.DesignKBMode = true;
			tvwKB.AllowDrop = true;
			tvwKB.ResetContent();
			tvwKB.EnableClickEvent = true;
			tvwYS.Nodes.Clear();
			tvwYS.Nodes.Add("正在加载列表，请稍候...");
			tvwYS.Refresh();
			ZYKBBufferYS.Instance.Connection = ZYDBConnection.Instance;
			ZYKBBufferYS.Instance.DesignMode = true;
			LoadALLdataYS();
			tvwYS.ShowNormalKBItem = true;
			tvwYS.RootKBList = ZYKBBufferYS.Instance.RootList;
			tvwYS.KBBuffer = ZYKBBufferYS.Instance;
			tvwYS.ShowKBItem = true;
			tvwYS.ShowTemplateKBItem = true;
			tvwYS.DesignKBMode = true;
			tvwYS.ResetContent();
			tvwYS.EnableClickEvent = true;
			SetStatusText("就绪");
			myTab.RefreshTagHead();
		}

		public bool LoadXMLFile(string strURL)
		{
			return txtEMR.LoadXMLFile(strURL);
		}

		public bool LoadBase64XML(string strXML)
		{
			return txtEMR.LoadBase64XML(strXML);
		}

		public bool LoadXML(string strXML)
		{
			return txtEMR.LoadXML(strXML);
		}

		public string ToBase64XML()
		{
			return txtEMR.ToBase64XML();
		}

		public string ToBase64XML2()
		{
			return txtEMR.ToBase64XML2();
		}

		public string ToBase64EMRXML()
		{
			return txtEMR.ToBase64EMRXML();
		}

		public string ToXMLString()
		{
			XmlDocument xmlDocument = new XmlDocument();
			txtEMR.EMRDoc.ToXMLDocument(xmlDocument);
			return xmlDocument.DocumentElement.OuterXml;
		}

		public string GetFinalText()
		{
			return txtEMR.GetFinalText();
		}

		public object GetNameValueArray()
		{
			ZYErrorReport.Instance.DebugPrint("试图获得结构化数据");
			string[] elementKeyValueList = txtEMR.EMRDoc.GetElementKeyValueList();
			Collection collection = new Collection();
			if (elementKeyValueList != null && elementKeyValueList.Length > 0)
			{
				ZYErrorReport.Instance.DebugPrint("共获得 " + elementKeyValueList.Length + " 组结构化数据");
				string[] array = elementKeyValueList;
				foreach (string item in array)
				{
					collection.Add(item);
				}
			}
			else
			{
				ZYErrorReport.Instance.DebugPrint("未获得任何结构化数据");
			}
			return collection;
		}

		public bool HandleCommand(string CommandName, string Param1, string Param2, string Param3)
		{
			if (CommandName == "kblist")
			{
				if (tvwKB.Visible)
				{
					tvwKB.Visible = false;
				}
				else
				{
					tvwKB.Visible = true;
				}
				OnResize(null);
				return true;
			}
			return txtEMR.HandleCommand(CommandName, Param1, Param2, Param3);
		}

		public bool HandleCommandNoUI(string CommandName, string Param1, string Param2, string Param3)
		{
			return txtEMR.HandleCommandNoUI(CommandName, Param1, Param2, Param3);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		protected override bool IsInputChar(char charCode)
		{
			return true;
		}

		private void EMREditPanel_GotFocus(object sender, EventArgs e)
		{
			txtEMR.Select();
		}

		protected override void Dispose(bool disposing)
		{
			if (ZYDBConnection.Instance.Connection is XMLHttpConnection)
			{
				(ZYDBConnection.Instance.Connection as XMLHttpConnection).CancelPostData();
			}
			ZYKBBuffer.Instance.Close();
			ZYKBBufferYS.Instance.Close();
			ZYErrorReport.Instance.ClearDebugPrint();
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
			if (myDoc != null)
			{
				myDoc.Dispose();
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			myProgress.Bounds = new Rectangle(stuText.Width + 2, myStatuBar.Top + 2, stuProgress.Width - 2, myStatuBar.Height - 2);
		}

		private void SetWindowTitle(string strTitle)
		{
			Text = "报告知识库维护程序 [" + ZYKBBuffer.Instance.ProjectName + "] " + (StringCommon.isBlankString(strTitle) ? "" : (" - " + strTitle));
		}

		private void tvwKB_KBListClick(TreeNode TreeNode, KB_List SelectedList)
		{
			TreeNode.Expand();
			myTab.Tag = "setting";
			myTab.SelectedTab = tabKBItem;
			myTab.Tag = null;
			Cursor = Cursors.WaitCursor;
			tabKBItem.Caption = "列表 - " + SelectedList.Name;
			lvwKBItem.ShowChildKBList = SelectedList.HasChildren();
			lvwKBItem.OwnerKBList = SelectedList;
			cmdNewKBItem.Enabled = SelectedList.EnableAddItem();
			Cursor = Cursors.Default;
			SetWindowTitle(SelectedList.GetRealFullPath());
		}

		private void tvwKB_KBItemClick(TreeNode TreeNode, KB_Item SelectedItem)
		{
			if (!SelectedItem.isTemplate())
			{
				return;
			}
			myTab.Tag = "setting";
			myTab.Tag = null;
			myTemplateNode = tvwKB.SelectedNode;
			tabText.Caption = "模板 - " + myTemplateNode.Text;
			string itemValue = SelectedItem.ItemValue;
			myTab.SelectedTab = tabText;
			myTab.RefreshTagHead();
			ZYEditorAction actionByName = myDoc.GetActionByName("opendbfile");
			SetWindowTitle("模板:" + SelectedItem.ItemText);
			if (actionByName.isEnable())
			{
				actionByName.Param1 = itemValue;
				actionByName.Execute();
				myDoc.OwnerKBItem = SelectedItem;
				string realFullPath = SelectedItem.OwnerList.GetRealFullPath();
				realFullPath = ((!StringCommon.isBlankString(realFullPath)) ? (realFullPath + "." + SelectedItem.ItemText) : SelectedItem.ItemText);
				if (myDoc.Info.Title != realFullPath)
				{
					myDoc.Info.Title = realFullPath;
				}
			}
		}

		private void OnEMRDocSaved()
		{
			KB_Item ownerKBItem = myDoc.OwnerKBItem;
			if (ownerKBItem != null && ownerKBItem.ItemValue != myDoc.Info.ID)
			{
				ownerKBItem.ItemValue = myDoc.Info.ID;
				tvwKB.RefreshNode(tvwKB.SelectedNode);
				cmdSaveKB_Click(null, null);
			}
		}

		private void DocumentSelectionChanged(object sender, EventArgs e)
		{
			ZYToolBarGroup.ZYToolBarButton button = tbrCommand.GetButton("title_fieldname");
			ZYToolBarGroup.ZYToolBarButton button2 = tbrCommand.GetButton("fieldname");
			if (button2 != null)
			{
				ZYTextElement currentElement = myDoc.Content.CurrentElement;
				if (currentElement == null)
				{
					return;
				}
				if (currentElement is ZYTextSelect)
				{
					button.Text = "下列列表";
					button2.Text = currentElement.Attributes.GetString("id");
				}
				else if (currentElement is ZYTextInput)
				{
					button.Text = "文本域";
					button2.Text = currentElement.Attributes.GetString("id");
				}
				else if (currentElement.Parent is ZYTextInput)
				{
					button.Text = "文本域";
					button2.Text = currentElement.Parent.Attributes.GetString("id");
				}
				else
				{
					button.Text = "层";
					button2.Text = currentElement.Parent.Attributes.GetString("id");
				}
			}
			tbrCommand.CheckButtonsStatus();
		}

		private void myTab_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (myDoc == null && myTab.Tag != null)
			{
				return;
			}
			tvwKB.EnableClickEvent = false;
			if (myTab.SelectedTab == tabText && myDoc.OwnerKBItem != null)
			{
				if (myTemplateNode != null)
				{
					tvwKB.SelectedNode = myTemplateNode;
					tvwKB.SelectedNode.EnsureVisible();
					txtEMR.Focus();
				}
				myTemplateNode = tvwKB.SelectedNode;
			}
			if (myTab.SelectedTab == tabKBItem)
			{
				tvwKB.SelectedKBList = lvwKBItem.OwnerKBList;
				lvwKBItem.Focus();
			}
			tvwKB.EnableClickEvent = true;
		}

		private void cmdDeleteKBItem_Click(object sender, EventArgs e)
		{
			lvwKBItem.DeleteSelectedItems();
			tvwKB.RefreshChildNode(bolMoveNode: false);
		}

		private void cmdItemUP_Click(object sender, EventArgs e)
		{
			if (lvwKBItem.ItemMoveUp())
			{
				tvwKB.RefreshChildNode(bolMoveNode: true);
			}
		}

		private void cmdItemDown_Click(object sender, EventArgs e)
		{
			if (lvwKBItem.ItemMoveDown())
			{
				tvwKB.RefreshChildNode(bolMoveNode: true);
			}
		}

		private void lvwKBItem_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			tvwKB.RefreshChildNode(bolMoveNode: false);
		}

		private void LoadAllData()
		{
			SetStatusText("正在加载数据...");
			string ownerSection = ZYKBBuffer.Instance.OwnerSection;
			ZYKBBuffer.Instance.OwnerSection = null;
			ZYKBBuffer.Instance.LoadAllKBList(FixListIndex: true);
			ZYKBBuffer.Instance.OwnerSection = ownerSection;
			ZYKBBuffer.Instance.LoadKBSection();
			GC.Collect();
		}

		private void LoadALLdataYS()
		{
			SetStatusText("正在加载数据...");
			string ownerSection = ZYKBBufferYS.Instance.OwnerSection;
			ZYKBBufferYS.Instance.OwnerSection = null;
			ZYKBBufferYS.Instance.LoadAllKBList(FixListIndex: true);
			ZYKBBufferYS.Instance.OwnerSection = ownerSection;
			ZYKBBufferYS.Instance.LoadKBSection();
			GC.Collect();
		}

		private void cmdRefreshKB_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			ZYKBBuffer.Instance.GetAllChangedRecord(arrayList);
			if (arrayList.Count <= 0 || MessageBox.Show(this, "本知识库已经修改了 " + arrayList.Count + "处，刷新操作将不保存任何修改，是否继续操作?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					myTemplateNode = null;
					myDoc.ClearContent();
					LoadXML(ZYConfig.NewFileXml);
					lvwKBItem.Items.Clear();
					string vSEQ = null;
					if (lvwKBItem.OwnerKBList != null)
					{
						vSEQ = lvwKBItem.OwnerKBList.SEQ;
					}
					RefreshKBTreeView(null, null);
					lvwKBItem.OwnerKBList = null;
					tvwKB.SelectedKBList = ZYKBBuffer.Instance.GetKBList(vSEQ);
				}
				catch (Exception sourceException)
				{
					ZYErrorReport.Instance.Clear();
					ZYErrorReport.Instance.SourceException = sourceException;
					ZYErrorReport.Instance.SourceObject = myDoc.DataSource.DBConn;
					ZYErrorReport.Instance.UserMessage = "读取数据错误，请稍候再试!";
					ZYErrorReport.Instance.MemberName = "ZYKnowledge.cmdRefreshKB_Click";
					ZYErrorReport.Instance.ShowErrorDialog();
				}
				Cursor = Cursors.Default;
			}
		}

		private void cmdSaveKB_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				ArrayList arrayList = new ArrayList();
				ZYKBBuffer.Instance.GetAllChangedRecord(arrayList);
				if (arrayList.Count > 0)
				{
					int deletedRecordCount = ZYDBRecordBase.GetDeletedRecordCount(arrayList);
					if (deletedRecordCount > 0 && MessageBox.Show(null, "本操作将要至少删除 " + deletedRecordCount + " 个记录，是否继续操作?", "系统警报", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
					{
						Cursor = Cursors.Default;
						return;
					}
					myProgress.Value = 0;
					myProgress.Visible = true;
					SetStatusText("正在保存数据...");
					if (ZYKBBuffer.Instance.UpdateDataBase(arrayList, SetProgress2) >= 0)
					{
						ZYKBBuffer.Instance.RefreshAllKBList();
						tvwKB.RefreshAllNode();
						if (DesignerMode == 1)
						{
							ZYKBBufferYS.Instance.LoadAllKBList(FixListIndex: true);
							tvwYS.RefreshAllNode();
						}
						lvwKBItem.OwnerKBList = tvwKB.SelectedKBList;
					}
					SetStatusText("保存完毕");
					myProgress.Visible = false;
				}
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.Clear();
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = myDoc.DataSource.DBConn;
				ZYErrorReport.Instance.UserMessage = "保存数据错误，请稍候再试!";
				ZYErrorReport.Instance.MemberName = "ZYKnowledge.cmdSaveKB_Click";
				ZYErrorReport.Instance.ShowErrorDialog();
			}
			Cursor = Cursors.Default;
		}

		private void cmdNewKBList_Click(object sender, EventArgs e)
		{
			if (lvwKBItem.NewKBList())
			{
				tvwKB.RefreshChildNode(bolMoveNode: true);
				cmdNewKBItem.Enabled = !lvwKBItem.OwnerKBList.HasChildren();
			}
		}

		private void cmdNewKBItem_Click(object sender, EventArgs e)
		{
			if (lvwKBItem.NewKBItem())
			{
				tvwKB.RefreshChildNode(bolMoveNode: true);
				cmdNewKBItem.Enabled = !lvwKBItem.OwnerKBList.HasChildren();
			}
		}

		private void cmdEditItem_Click(object sender, EventArgs e)
		{
			if (lvwKBItem.FocusedItem != null && lvwKBItem.FocusedItem.Tag is KB_Item)
			{
				lvwKBItem.EditFocusedItem();
			}
			else if (lvwKBItem.FocusedItem != null && lvwKBItem.FocusedItem.Tag is KB_List && (lvwKBItem.FocusedItem.Tag as KB_List).InputBoxAttribute)
			{
				using (dlgKB_List dlgKB_List = new dlgKB_List())
				{
					dlgKB_List.OwnerList = (lvwKBItem.FocusedItem.Tag as KB_List);
					string ownerSection = dlgKB_List.OwnerList.OwnerSection;
					if (dlgKB_List.ShowDialog(tvwKB) == DialogResult.OK)
					{
						tvwKB.RefreshNode(tvwKB.SelectedNode);
						lvwKBItem.RefreshListItem(lvwKBItem.FocusedItem);
						if (dlgKB_List.OwnerList.OwnerSection != ownerSection)
						{
							tvwKB.SetSectionFlag(tvwKB.SelectedNode, dlgKB_List.OwnerList.OwnerSection);
						}
					}
				}
			}
		}

		private void lvwKBItem_DoubleClick(object sender, EventArgs e)
		{
		}

		private void lvwKBItem_StatusTextChange(object sender, string Text)
		{
			stuText.Text = Text;
		}

		public void SetStatusText(string Text)
		{
			stuText.Text = Text;
		}

		public void SetProgress(int Rate)
		{
			if (!myProgress.Visible)
			{
				myProgress.Visible = true;
			}
			if (Rate < 0)
			{
				Rate = 0;
			}
			if (Rate > 100)
			{
				Rate = 100;
			}
			myProgress.Value = Rate;
		}

		public void SetProgress2(int vCompleted, int vTotal)
		{
			if (myProgress.Maximum != vTotal)
			{
				myProgress.Maximum = vTotal;
			}
			myProgress.Value = vCompleted;
		}

		private void SetProgressObj(object objData, int Completed, int Total)
		{
			SetProgress(Completed * 100 / Total);
			SetStatusText("正在更新 " + ((KB_List)objData).GetRealFullPath());
		}

		public void HideProgress()
		{
			myProgress.Visible = false;
		}

		private void tvwKB_DragDrop(object sender, DragEventArgs e)
		{
			lvwKBItem.RefreshContent();
		}

		private void myMarkList_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void mySaveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ZYEditorAction actionByName = myDoc.GetActionByName("setuserlevel");
			if (actionByName != null)
			{
				if (mySaveList.SelectedIndex == mySaveList.Items.Count - 1)
				{
					actionByName.Param1 = "-1";
				}
				else
				{
					actionByName.Param1 = mySaveList.SelectedIndex.ToString();
				}
				actionByName.Execute();
			}
		}

		private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			tbrKB.Refresh();
			if (cboSection.SelectedIndex < 0)
			{
				ZYKBBuffer.Instance.OwnerSection = null;
			}
			else
			{
				ZYKBBuffer.Instance.OwnerSection = mySectionList.GetSectionCode(cboSection.SelectedIndex);
			}
			myConfig.SetSetting("ownersection", ZYKBBuffer.Instance.OwnerSection);
			tvwKB.BeginUpdate();
			tvwKB.RefreshNodeColor(tvwKB.Nodes[0]);
			tvwKB.EndUpdate();
			Cursor = Cursors.Default;
		}

		private void DBConn_OnOpen(object sender, EventArgs e)
		{
			(sender as ZYDBConnection).Connection = myConnection;
			ZYErrorReport.Instance.DebugPrint("打开数据库连接" + myConnection.ConnectionString);
		}

		private void DBConn_OnClose(object sender, EventArgs e)
		{
			(sender as ZYDBConnection).Connection = null;
			ZYErrorReport.Instance.DebugPrint("关闭数据库连接");
		}

		private void myStatuBar_DoubleClick(object sender, EventArgs e)
		{
		}

		private void myDoc_OnJumpDiv(ZYTextDiv DivFrom, ZYTextDiv DivTo)
		{
			SetStatusText("从文本块 " + DivFrom.Title + " 跳到文本块" + DivTo.Title);
		}

		private void InitPopupMenu()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new TreeViewMenuItem("新增子节点(&N)", 1));
			arrayList.Add(new TreeViewMenuItem("新增文本框", 11));
			arrayList.Add(new TreeViewMenuItem("新增列表项目", 2));
			arrayList.Add(new TreeViewMenuItem("新增模板(&T)", 3));
			arrayList.Add(new TreeViewMenuItem("删除(&D)", 4));
			arrayList.Add(new TreeViewMenuItem("-"));
			arrayList.Add(new TreeViewMenuItem("节点上移(&U)", 5));
			arrayList.Add(new TreeViewMenuItem("节点下移(&D)", 6));
			arrayList.Add(new TreeViewMenuItem("属性(&R)", 7));
			arrayList.Add(new TreeViewMenuItem("-"));
			arrayList.Add(new TreeViewMenuItem("图例...", 10));
			arrayList.Add(new TreeViewMenuItem("设置ICD编码", 111));
			foreach (TreeViewMenuItem item in arrayList)
			{
				item.OwnerForm = this;
			}
			myMenu.MenuItems.AddRange((MenuItem[])arrayList.ToArray(typeof(MenuItem)));
			myMenu.Popup += myMenu_Popup;
		}

		public void HandleTreeViewCommand(int CommandID)
		{
			string text = null;
			KB_List selectedKBList = tvwKB.SelectedKBList;
			ZYKBObjectList zYKBObjectList = null;
			switch (CommandID)
			{
			case 0:
				tvwKB.InsertKBList();
				break;
			case 1:
				tvwKB.NewKBList(0);
				break;
			case 2:
				tvwKB.NewKBItem();
				break;
			case 3:
				tvwKB.NewFormItem();
				break;
			case 4:
				if (tvwKB.SelectedNode != null && tvwKB.SelectedNode != tvwKB.Nodes[0])
				{
					tvwKB.SetDeleteFlag(tvwKB.SelectedNode);
				}
				break;
			case 5:
				tvwKB.MoveNodeUp();
				break;
			case 6:
				tvwKB.MoveNodeDown();
				break;
			case 7:
				if (tvwKB.SelectedNode != null && tvwKB.SelectedNode != tvwKB.Nodes[0])
				{
					if (tvwKB.SelectedNode.Tag is KB_List)
					{
						using (dlgKB_List dlgKB_List = new dlgKB_List())
						{
							dlgKB_List.OwnerList = (tvwKB.SelectedNode.Tag as KB_List);
							string ownerSection = dlgKB_List.OwnerList.OwnerSection;
							if (dlgKB_List.ShowDialog(tvwKB) == DialogResult.OK)
							{
								tvwKB.RefreshNode(tvwKB.SelectedNode);
								if (dlgKB_List.OwnerList.OwnerSection != ownerSection)
								{
									tvwKB.SetSectionFlag(tvwKB.SelectedNode, dlgKB_List.OwnerList.OwnerSection);
								}
							}
						}
					}
					else if (tvwKB.SelectedNode.Tag is KB_Item)
					{
						using (dlgKB_Item dlgKB_Item = new dlgKB_Item())
						{
							dlgKB_Item.OwnerItem = (tvwKB.SelectedNode.Tag as KB_Item);
							if (dlgKB_Item.ShowDialog(tvwKB) == DialogResult.OK)
							{
								tvwKB.RefreshNode(tvwKB.SelectedNode);
							}
						}
					}
				}
				break;
			case 8:
				if (selectedKBList != null && ZYKBBuffer.Instance != null && ZYKBBuffer.Instance.BindKBToSection(selectedKBList, bolSet: true, ShowInTree: true))
				{
					tvwKB.RefreshNodeColor(tvwKB.Nodes[0]);
				}
				break;
			case 9:
				if (selectedKBList != null && ZYKBBuffer.Instance != null && ZYKBBuffer.Instance.BindKBToSection(selectedKBList, bolSet: false, ShowInTree: false))
				{
					tvwKB.RefreshNodeColor(tvwKB.Nodes[0]);
				}
				break;
			case 10:
			{
				using (dlgIconInfo dlgIconInfo = new dlgIconInfo())
				{
					dlgIconInfo.ShowDialog(tvwKB);
				}
				break;
			}
			case 111:
			{
				using (ICD iCD = new ICD())
				{
					iCD.kblist = tvwKB.SelectedKBList.SEQ;
					iCD.ShowDialog(tvwKB);
				}
				break;
			}
			case 11:
				tvwKB.NewKBList(1);
				break;
			case 12:
				if (selectedKBList != null && selectedKBList.ChildNodes != null && selectedKBList.ChildNodes.Count > 0)
				{
					using (OpenFileDialog openFileDialog = new OpenFileDialog())
					{
						openFileDialog.CheckFileExists = true;
						openFileDialog.Title = "打开知识库定义文件";
						openFileDialog.Filter = "数据文件|*.dat|所有文件|*.*";
						if (openFileDialog.ShowDialog(tvwKB) == DialogResult.OK)
						{
							tvwKB.Cursor = Cursors.WaitCursor;
							SetStatusText("正在从 " + openFileDialog.FileName + " 导入知识库定义文件...");
							zYKBObjectList = new ZYKBObjectList();
							zYKBObjectList.RootKBList = selectedKBList;
							zYKBObjectList.Load(openFileDialog.FileName);
							tvwKB.SelectedNode.Nodes.Clear();
							tvwKB.ResetNode(tvwKB.SelectedNode);
							tvwKB.SelectedNode.Expand();
							SetStatusText("已导入 " + zYKBObjectList.Count + " 个对象");
							tvwKB.Cursor = Cursors.Default;
						}
					}
				}
				break;
			case 13:
				if (selectedKBList != null && selectedKBList.ChildNodes != null && selectedKBList.ChildNodes.Count > 0)
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.CheckPathExists = true;
						saveFileDialog.OverwritePrompt = true;
						saveFileDialog.Title = "保存知识库定义文件";
						saveFileDialog.Filter = "数据文件|*.dat|所有文件|*.*";
						if (saveFileDialog.ShowDialog(tvwKB) == DialogResult.OK)
						{
							tvwKB.Cursor = Cursors.WaitCursor;
							SetStatusText("正在向 " + saveFileDialog.FileName + " 导出知识库定义...");
							zYKBObjectList = new ZYKBObjectList();
							using (IDbCommand myCmd = ZYDBConnection.Instance.CreateCommand())
							{
								ZYKBBuffer.Instance.KBListToObjList(zYKBObjectList, selectedKBList, IncludeTemplate: true, myCmd);
							}
							zYKBObjectList.Save(saveFileDialog.FileName);
							tvwKB.Cursor = Cursors.Default;
							SetStatusText("共保存了 " + zYKBObjectList.Count + " 个对象");
							MessageBox.Show(tvwKB, "共保存了 " + zYKBObjectList.Count + " 个对象", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
				}
				break;
			case 14:
				if (ZYKBBuffer.Instance.AllKBList != null && ZYKBBuffer.Instance.AllKBList.Count > 0)
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.CheckPathExists = true;
						saveFileDialog.OverwritePrompt = true;
						saveFileDialog.Title = "保存知识库定义文件";
						saveFileDialog.Filter = "数据文件|*.dat|所有文件|*.*";
						if (saveFileDialog.ShowDialog(tvwKB) != DialogResult.OK)
						{
							return;
						}
						text = saveFileDialog.FileName;
					}
					Cursor = Cursors.WaitCursor;
					Refresh();
					SetStatusText("正在向 " + text + " 导出知识库定义...");
					zYKBObjectList = new ZYKBObjectList();
					zYKBObjectList.EncryptString = true;
					using (IDbCommand myCmd = ZYDBConnection.Instance.CreateCommand())
					{
						SetStatusText("正在读取知识点数据...");
						ZYKBBuffer.Instance.LoadRecords(zYKBObjectList, 0, myCmd);
						SetStatusText("正在读取知识点列表项目数据...");
						ZYKBBuffer.Instance.LoadRecords(zYKBObjectList, 1, myCmd);
						SetStatusText("正在读取知识点科室绑定信息数据...");
						ZYKBBuffer.Instance.LoadRecords(zYKBObjectList, 2, myCmd);
						SetStatusText("正在读取所有的文本型报告模板...");
						ZYKBBuffer.Instance.LoadRecords(zYKBObjectList, 3, myCmd);
					}
					ZYDBConnection.Instance.ExecuteCompleted();
					zYKBObjectList.Save(text);
					Cursor = Cursors.Default;
					SetStatusText("共保存了 " + zYKBObjectList.Count + " 个对象");
					MessageBox.Show(this, "共保存了 " + zYKBObjectList.Count + " 个对象", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				break;
			case 15:
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.CheckFileExists = true;
					openFileDialog.ReadOnlyChecked = false;
					openFileDialog.Title = "加载知识库定义文件";
					openFileDialog.Filter = "数据文件|*.dat|所有文件|*.*";
					if (openFileDialog.ShowDialog(tvwKB) != DialogResult.OK)
					{
						return;
					}
					text = openFileDialog.FileName;
				}
				Cursor = Cursors.WaitCursor;
				Refresh();
				SetStatusText("正在加载知识库文件 " + text);
				zYKBObjectList = new ZYKBObjectList();
				zYKBObjectList.Load(text);
				if (MessageBox.Show(this, "共加载 " + zYKBObjectList.Count + " 个对象,本操作将替换当前工程的全部知识库,包括列表和文本模板,是否继续操作?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (IDbCommand myCmd = ZYDBConnection.Instance.CreateCommand())
					{
						SetStatusText("正在删除已有数据...");
						ZYKBBuffer.Instance.DeleteRecords(0, myCmd);
						ZYKBBuffer.Instance.DeleteRecords(1, myCmd);
						ZYKBBuffer.Instance.DeleteRecords(2, myCmd);
						ZYKBBuffer.Instance.DeleteRecords(3, myCmd);
						foreach (ZYDBRecordBase item in zYKBObjectList)
						{
							item.DataState = DataRowState.Added;
						}
					}
					SetStatusText("正在保存新数据...");
					myProgress.Visible = true;
					ZYKBBuffer.Instance.UpdateDataBase(zYKBObjectList, SetProgress2);
					myProgress.Visible = false;
					cmdRefreshKB_Click(null, null);
				}
				break;
			}
			}
		}

		private bool GetTreeViewCommandEnabled(int CommandID)
		{
			switch (CommandID)
			{
			case 0:
				return tvwKB.SelectedNode != tvwKB.Nodes[0];
			case 11:
				if (DesignerMode == 0 || tvwKB.SelectedNode.Tag is KB_Item || tvwKB.SelectedNode == tvwKB.Nodes[0])
				{
					return false;
				}
				return tvwKB.SelectedKBList.EnableAddChild();
			case 1:
			case 12:
			case 13:
				if (tvwKB.SelectedNode.Tag is KB_Item)
				{
					return false;
				}
				return tvwKB.SelectedKBList.EnableAddChild();
			case 2:
				if (tvwKB.SelectedNode.Tag is KB_Item || tvwKB.SelectedNode == tvwKB.Nodes[0] || DesignerMode == 0)
				{
					return false;
				}
				if (tvwKB.SelectedKBList.EnableAddItem() && tvwKB.ShowKBItem)
				{
					return tvwKB.ShowNormalKBItem;
				}
				return false;
			case 3:
				if (tvwKB.SelectedNode.Tag is KB_Item || tvwKB.SelectedNode == tvwKB.Nodes[0] || DesignerMode == 1)
				{
					return false;
				}
				if (tvwKB.SelectedKBList.EnableAddItem() && tvwKB.ShowKBItem)
				{
					return tvwKB.ShowTemplateKBItem;
				}
				return false;
			case 4:
				return tvwKB.SelectedNode != tvwKB.Nodes[0];
			case 5:
			case 6:
				return tvwKB.SelectedNode != null && tvwKB.SelectedNode != tvwKB.Nodes[0] && tvwKB.SelectedNode.Tag is KB_List;
			case 7:
				return tvwKB.SelectedNode != null && tvwKB.SelectedNode != tvwKB.Nodes[0];
			case 8:
				if (StringCommon.HasContent(ZYKBBuffer.Instance.OwnerSection))
				{
					KB_List selectedKBList = tvwKB.SelectedKBList;
					if (selectedKBList != null)
					{
						return !ZYKBBuffer.Instance.HasBindKBSection(ZYKBBuffer.Instance.OwnerSection, selectedKBList.SEQ);
					}
				}
				return false;
			case 9:
				if (StringCommon.HasContent(ZYKBBuffer.Instance.OwnerSection))
				{
					KB_List selectedKBList = tvwKB.SelectedKBList;
					if (selectedKBList != null)
					{
						return ZYKBBuffer.Instance.HasBindKBSection(ZYKBBuffer.Instance.OwnerSection, selectedKBList.SEQ);
					}
				}
				return false;
			case 10:
				return tvwKB.SelectedNode == tvwKB.Nodes[0];
			case 14:
				return tvwKB.SelectedNode == tvwKB.Nodes[0];
			case 15:
				return tvwKB.SelectedNode == tvwKB.Nodes[0];
			case 111:
				if (tvwKB.SelectedNode.Tag is KB_Item || tvwKB.SelectedNode == tvwKB.Nodes[0] || DesignerMode == 1 || !ZYPublic.StandardMode)
				{
					return false;
				}
				if (tvwKB.SelectedKBList.EnableAddItem() && tvwKB.ShowKBItem)
				{
					return tvwKB.ShowTemplateKBItem;
				}
				return false;
			default:
				return false;
			}
		}

		private void myMenu_Popup(object sender, EventArgs e)
		{
			foreach (TreeViewMenuItem menuItem in myMenu.MenuItems)
			{
				menuItem.Visible = (iAuthrity == 1 && GetTreeViewCommandEnabled(menuItem.CommandID));
			}
		}

		private bool tbrKB_OnButtonClick(string strCommand, ZYToolBarGroup.ZYToolBarButton button)
		{
			switch (strCommand)
			{
			case "refreshkb":
				cmdRefreshKB_Click(null, null);
				break;
			case "savekb":
				cmdSaveKB_Click(null, null);
				break;
			}
			return true;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}
	}
}

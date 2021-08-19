using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       产程图设计器控件
	///       </summary>
	[ToolboxItem(true)]
	[ComVisible(false)]
	[ToolboxBitmap(typeof(FriedmanCurveDesignerControl))]
	[DCPublishAPI]
	public class FriedmanCurveDesignerControl : UserControl
	{
		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private GControl2 ctlFriedmanCurve;

		private PropertyGrid ctlProerty;

		private SplitContainer splitContainer1;

		private ToolStripDropDownButton btnViewMode;

		private ToolStripMenuItem btnNormalViewMode;

		private ToolStripMenuItem btnPageViewMode;

		private ToolStripMenuItem btnWidelyViewMode;

		private ToolStripButton btnDelete;

		private ToolStripButton btnViewXMLSource;

		private ToolStripButton btnCancel;

		private ToolStripButton btnOK;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripDropDownButton btnInsert;

		private ToolStripMenuItem mInsertHeaderLabel;

		private ToolStripMenuItem mInsertHeaderLine;

		private ToolStripMenuItem mInsertYAxis;

		private ToolStripMenuItem mInsertFooterLine;

		private ToolStripButton btnMovePre;

		private ToolStripButton btnMoveNext;

		private ToolStripButton btnPageSettings;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem mShowLocalPropertyName;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripMenuItem mCloneInsert;

		private ToolStripButton btnTreeView;

		private Splitter spTreeView;

		private TreeView tvwDOM;

		private ToolStripMenuItem mNewTimeZone;

		private ToolStripMenuItem menuInsertLabel;

		private string string_0 = null;

		private FriedmanCurveDocument friedmanCurveDocument_0 = null;

		private bool bool_0 = false;

		private FriedmanCurveControl friedmanCurveControl_0 = null;

		private bool bool_1 = false;

		private EventHandler eventHandler_0 = null;

		private EventHandler eventHandler_1 = null;

		/// <summary>
		///       主工具条
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStrip MainToolbar => toolStrip1;

		/// <summary>
		///       设计结果的XML字符串
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ResultConfigXML
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
		///       文档对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public FriedmanCurveDocument SourceDocument
		{
			get
			{
				return friedmanCurveDocument_0;
			}
			set
			{
				friedmanCurveDocument_0 = value;
			}
		}

		/// <summary>
		///       内容被修改标记
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Modified
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
		///       来源控件
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public FriedmanCurveControl SourceControl
		{
			get
			{
				return friedmanCurveControl_0;
			}
			set
			{
				friedmanCurveControl_0 = value;
			}
		}

		/// <summary>
		///       文档视图模式
		///       </summary>
		private FCDocumentViewMode ViewMode
		{
			get
			{
				return ctlFriedmanCurve.method_10();
			}
			set
			{
				if (ctlFriedmanCurve.method_10() != value)
				{
					ctlFriedmanCurve.method_11(value);
					if (value == FCDocumentViewMode.Normal || value == FCDocumentViewMode.FriedmanCurve)
					{
						ctlFriedmanCurve.BackColor = ctlFriedmanCurve.method_14().Config.PageBackColor;
					}
					else if (SourceControl == null)
					{
						ctlFriedmanCurve.BackColor = BackColor;
					}
					else
					{
						ctlFriedmanCurve.BackColor = SourceControl.BackColor;
					}
					ctlFriedmanCurve.method_28();
					ctlFriedmanCurve.Invalidate();
				}
			}
		}

		/// <summary>
		///       确定按钮点击事件
		///       </summary>
		public event EventHandler EventOKButtonClick
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
		///       取消按钮点击事件
		///       </summary>
		public event EventHandler EventCancelButtonClick
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.FriedmanCurveChart.FriedmanCurveDesignerControl));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnTreeView = new System.Windows.Forms.ToolStripButton();
			btnViewMode = new System.Windows.Forms.ToolStripDropDownButton();
			btnNormalViewMode = new System.Windows.Forms.ToolStripMenuItem();
			btnPageViewMode = new System.Windows.Forms.ToolStripMenuItem();
			btnWidelyViewMode = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			mShowLocalPropertyName = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnPageSettings = new System.Windows.Forms.ToolStripButton();
			btnInsert = new System.Windows.Forms.ToolStripDropDownButton();
			mInsertHeaderLabel = new System.Windows.Forms.ToolStripMenuItem();
			mInsertHeaderLine = new System.Windows.Forms.ToolStripMenuItem();
			mInsertYAxis = new System.Windows.Forms.ToolStripMenuItem();
			mInsertFooterLine = new System.Windows.Forms.ToolStripMenuItem();
			menuInsertLabel = new System.Windows.Forms.ToolStripMenuItem();
			mNewTimeZone = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			mCloneInsert = new System.Windows.Forms.ToolStripMenuItem();
			btnMovePre = new System.Windows.Forms.ToolStripButton();
			btnMoveNext = new System.Windows.Forms.ToolStripButton();
			btnDelete = new System.Windows.Forms.ToolStripButton();
			btnViewXMLSource = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			btnOK = new System.Windows.Forms.ToolStripButton();
			btnCancel = new System.Windows.Forms.ToolStripButton();
			ctlProerty = new System.Windows.Forms.PropertyGrid();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			ctlFriedmanCurve = new DCSoftDotfuscate.GControl2();
			spTreeView = new System.Windows.Forms.Splitter();
			tvwDOM = new System.Windows.Forms.TreeView();
			toolStrip1.SuspendLayout();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				btnTreeView,
				btnViewMode,
				toolStripSeparator1,
				btnPageSettings,
				btnInsert,
				btnMovePre,
				btnMoveNext,
				btnDelete,
				btnViewXMLSource,
				toolStripSeparator2,
				btnOK,
				btnCancel
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			btnTreeView.Checked = true;
			btnTreeView.CheckOnClick = true;
			btnTreeView.CheckState = System.Windows.Forms.CheckState.Checked;
			btnTreeView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnTreeView, "btnTreeView");
			btnTreeView.Name = "btnTreeView";
			btnTreeView.Click += new System.EventHandler(btnTreeView_Click);
			btnViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
			{
				btnNormalViewMode,
				btnPageViewMode,
				btnWidelyViewMode,
				toolStripSeparator3,
				mShowLocalPropertyName
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
			toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
			mShowLocalPropertyName.Name = "mShowLocalPropertyName";
			resources.ApplyResources(mShowLocalPropertyName, "mShowLocalPropertyName");
			mShowLocalPropertyName.Click += new System.EventHandler(mShowLocalPropertyName_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			resources.ApplyResources(btnPageSettings, "btnPageSettings");
			btnPageSettings.Name = "btnPageSettings";
			btnPageSettings.Click += new System.EventHandler(btnPageSettings_Click);
			btnInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8]
			{
				mInsertHeaderLabel,
				mInsertHeaderLine,
				mInsertYAxis,
				mInsertFooterLine,
				menuInsertLabel,
				mNewTimeZone,
				toolStripSeparator4,
				mCloneInsert
			});
			resources.ApplyResources(btnInsert, "btnInsert");
			btnInsert.Name = "btnInsert";
			mInsertHeaderLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(mInsertHeaderLabel, "mInsertHeaderLabel");
			mInsertHeaderLabel.Name = "mInsertHeaderLabel";
			mInsertHeaderLabel.Click += new System.EventHandler(mInsertHeaderLabel_Click);
			mInsertHeaderLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(mInsertHeaderLine, "mInsertHeaderLine");
			mInsertHeaderLine.Name = "mInsertHeaderLine";
			mInsertHeaderLine.Click += new System.EventHandler(mInsertHeaderLine_Click);
			mInsertYAxis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(mInsertYAxis, "mInsertYAxis");
			mInsertYAxis.Name = "mInsertYAxis";
			mInsertYAxis.Click += new System.EventHandler(mInsertYAxis_Click);
			mInsertFooterLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(mInsertFooterLine, "mInsertFooterLine");
			mInsertFooterLine.Name = "mInsertFooterLine";
			mInsertFooterLine.Click += new System.EventHandler(mInsertFooterLine_Click);
			menuInsertLabel.Name = "menuInsertLabel";
			resources.ApplyResources(menuInsertLabel, "menuInsertLabel");
			menuInsertLabel.Click += new System.EventHandler(menuInsertLabel_Click);
			mNewTimeZone.Name = "mNewTimeZone";
			resources.ApplyResources(mNewTimeZone, "mNewTimeZone");
			mNewTimeZone.Click += new System.EventHandler(mNewTimeZone_Click);
			toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
			mCloneInsert.Name = "mCloneInsert";
			resources.ApplyResources(mCloneInsert, "mCloneInsert");
			mCloneInsert.Click += new System.EventHandler(mCloneInsert_Click);
			resources.ApplyResources(btnMovePre, "btnMovePre");
			btnMovePre.Name = "btnMovePre";
			btnMovePre.Click += new System.EventHandler(btnMovePre_Click);
			resources.ApplyResources(btnMoveNext, "btnMoveNext");
			btnMoveNext.Name = "btnMoveNext";
			btnMoveNext.Click += new System.EventHandler(btnMoveNext_Click);
			resources.ApplyResources(btnDelete, "btnDelete");
			btnDelete.Name = "btnDelete";
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			resources.ApplyResources(btnViewXMLSource, "btnViewXMLSource");
			btnViewXMLSource.Name = "btnViewXMLSource";
			btnViewXMLSource.Click += new System.EventHandler(btnViewXMLSource_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(ctlProerty, "ctlProerty");
			ctlProerty.Name = "ctlProerty";
			ctlProerty.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			ctlProerty.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(ctlProerty_PropertyValueChanged);
			resources.ApplyResources(splitContainer1, "splitContainer1");
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(ctlFriedmanCurve);
			splitContainer1.Panel1.Controls.Add(spTreeView);
			splitContainer1.Panel1.Controls.Add(tvwDOM);
			splitContainer1.Panel2.Controls.Add(ctlProerty);
			resources.ApplyResources(ctlFriedmanCurve, "ctlFriedmanCurve");
			ctlFriedmanCurve.BackColor = System.Drawing.SystemColors.Window;
			ctlFriedmanCurve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			ctlFriedmanCurve.Name = "ctlFriedmanCurve";
			resources.ApplyResources(spTreeView, "spTreeView");
			spTreeView.Name = "spTreeView";
			spTreeView.TabStop = false;
			resources.ApplyResources(tvwDOM, "tvwDOM");
			tvwDOM.FullRowSelect = true;
			tvwDOM.HideSelection = false;
			tvwDOM.Name = "tvwDOM";
			tvwDOM.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(tvwDOM_AfterSelect);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(splitContainer1);
			base.Controls.Add(toolStrip1);
			base.Name = "FriedmanCurveDesignerControl";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public FriedmanCurveDesignerControl()
		{
			InitializeComponent();
		}

		/// <summary>
		///       控件加载时的处理
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			int num = 18;
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				FriedmanCurveDocument friedmanCurveDocument = null;
				friedmanCurveDocument = ((SourceDocument != null) ? SourceDocument.Clone() : new FriedmanCurveDocument());
				ctlFriedmanCurve.method_5(Enum19.const_1);
				ctlFriedmanCurve.method_15(friedmanCurveDocument);
				ctlFriedmanCurve.method_11(FCDocumentViewMode.FriedmanCurve);
				if (SourceControl != null)
				{
					ViewMode = SourceControl.ViewMode;
				}
				ctlFriedmanCurve.method_7(bool_4: false);
				ctlFriedmanCurve.method_35(GEnum23.const_2);
				method_0();
				ctlFriedmanCurve.method_61(method_1);
				ctlFriedmanCurve.method_14().SelectedObject = ctlFriedmanCurve.method_14();
				method_1(null, null);
				mShowLocalPropertyName.Checked = GClass360.smethod_0();
				if (!FriedmanCurveDocument.IsAssemblyObfuscation)
				{
					Text += "[未加密]";
				}
			}
		}

		private void method_0()
		{
			int num = 3;
			bool_1 = false;
			ctlFriedmanCurve.method_23();
			FriedmanCurveDocumentConfig config = ctlFriedmanCurve.method_14().Config;
			tvwDOM.Nodes.Clear();
			TreeNode treeNode = tvwDOM.Nodes.Add(DCFriedmanCurveStrings.DocumentConfig);
			treeNode.Tag = config;
			TreeNode treeNode2 = treeNode.Nodes.Add(DCFriedmanCurveStrings.FriedmanCurveZone);
			foreach (FriedmanCurveZoneInfo zone in config.Zones)
			{
				TreeNode treeNode3 = treeNode2.Nodes.Add(zone.Name);
				treeNode3.Tag = zone;
			}
			treeNode2 = treeNode.Nodes.Add(DCFriedmanCurveStrings.HeaderLabel);
			foreach (FCHeaderLabelInfo headerLabel in config.HeaderLabels)
			{
				TreeNode treeNode3 = treeNode2.Nodes.Add(headerLabel.Title);
				treeNode3.Tag = headerLabel;
			}
			treeNode2 = treeNode.Nodes.Add(DCFriedmanCurveStrings.HeaderTitleLine);
			foreach (FCTitleLineInfo headerLine in config.HeaderLines)
			{
				TreeNode treeNode3 = treeNode2.Nodes.Add(headerLine.Title);
				treeNode3.Tag = headerLine;
			}
			treeNode2 = treeNode.Nodes.Add(DCFriedmanCurveStrings.YAxis);
			foreach (FCYAxisInfo yAxisInfo in config.YAxisInfos)
			{
				TreeNode treeNode3 = treeNode2.Nodes.Add(yAxisInfo.Title);
				treeNode3.Tag = yAxisInfo;
			}
			treeNode2 = treeNode.Nodes.Add(DCFriedmanCurveStrings.FooterLine);
			foreach (FCTitleLineInfo footerLine in config.FooterLines)
			{
				TreeNode treeNode3 = treeNode2.Nodes.Add(footerLine.Title);
				treeNode3.Tag = footerLine;
			}
			treeNode2 = treeNode.Nodes.Add(DCFriedmanCurveStrings.DocumentLabel);
			foreach (DCFriedmanCurveLabel label in config.Labels)
			{
				string text = label.Text;
				if (string.IsNullOrEmpty(text))
				{
					if (!string.IsNullOrEmpty(label.ParameterName))
					{
						text = "[" + label.ParameterName + "]";
					}
					else if (label.Image != null && label.Image.HasContent)
					{
						text = "[image]";
					}
				}
				TreeNode treeNode3 = treeNode2.Nodes.Add(text);
				treeNode3.Tag = label;
			}
			method_2(tvwDOM.Nodes, ctlFriedmanCurve.method_14().SelectedObject);
			tvwDOM.ExpandAll();
			bool_1 = true;
		}

		private void method_1(object sender, EventArgs e)
		{
			object obj = ctlFriedmanCurve.method_14().SelectedObject;
			if (obj == null || obj == ctlFriedmanCurve.method_14())
			{
				obj = ctlFriedmanCurve.method_14().Config;
			}
			if (bool_1)
			{
				bool_1 = false;
				method_2(tvwDOM.Nodes, obj);
				bool_1 = true;
			}
			ctlProerty.SelectedObject = obj;
		}

		private void method_2(TreeNodeCollection treeNodeCollection_0, object object_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Tag == object_0)
				{
					tvwDOM.SelectedNode = item;
					ctlProerty.SelectedObject = item.Tag;
					item.EnsureVisible();
				}
				else if (item.Nodes.Count > 0)
				{
					method_2(item.Nodes, object_0);
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (Modified)
			{
				if (SourceDocument != null)
				{
					SourceDocument.Config = ctlFriedmanCurve.method_14().Config;
				}
				ResultConfigXML = ctlFriedmanCurve.method_14().ConfigXml;
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, null);
				}
			}
			else if (eventHandler_1 != null)
			{
				eventHandler_1(this, null);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, null);
			}
		}

		private void btnViewMode_DropDownOpening(object sender, EventArgs e)
		{
			btnPageViewMode.Checked = (ctlFriedmanCurve.method_10() == FCDocumentViewMode.Page);
			btnNormalViewMode.Checked = (ctlFriedmanCurve.method_10() == FCDocumentViewMode.Normal);
			btnWidelyViewMode.Checked = (ctlFriedmanCurve.method_10() == FCDocumentViewMode.FriedmanCurve);
		}

		private void btnNormalViewMode_Click(object sender, EventArgs e)
		{
			ViewMode = FCDocumentViewMode.Normal;
			ctlFriedmanCurve.method_7(bool_4: true);
		}

		private void btnPageViewMode_Click(object sender, EventArgs e)
		{
			ViewMode = FCDocumentViewMode.Page;
			ctlFriedmanCurve.method_7(bool_4: true);
		}

		private void btnWidelyViewMode_Click(object sender, EventArgs e)
		{
			ViewMode = FCDocumentViewMode.FriedmanCurve;
			ctlFriedmanCurve.method_7(bool_4: false);
		}

		private void ctlProerty_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
		{
			Modified = true;
			ctlFriedmanCurve.method_23();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			object selectedObject = ctlFriedmanCurve.method_14().SelectedObject;
			if (selectedObject is FriedmanCurveDocumentConfig)
			{
				return;
			}
			bool flag = false;
			FriedmanCurveDocumentConfig config = ctlFriedmanCurve.method_14().Config;
			if (selectedObject is FCHeaderLabelInfo)
			{
				config.HeaderLabels.Remove((FCHeaderLabelInfo)selectedObject);
				flag = true;
			}
			if (selectedObject is FCYAxisInfo)
			{
				config.YAxisInfos.Remove((FCYAxisInfo)selectedObject);
				flag = true;
			}
			if (selectedObject is FCTitleLineInfo)
			{
				FCTitleLineInfo item = (FCTitleLineInfo)selectedObject;
				if (config.HeaderLines.Contains(item))
				{
					config.HeaderLines.Remove(item);
					flag = true;
				}
				else if (config.FooterLines.Contains(item))
				{
					config.FooterLines.Remove(item);
					flag = true;
				}
			}
			if (selectedObject is DCFriedmanCurveImage)
			{
				DCFriedmanCurveImage item2 = (DCFriedmanCurveImage)selectedObject;
				if (config.Images.Contains(item2))
				{
					config.Images.Remove(item2);
					flag = true;
				}
			}
			if (selectedObject is DCFriedmanCurveLabel)
			{
				DCFriedmanCurveLabel item3 = (DCFriedmanCurveLabel)selectedObject;
				if (config.Labels.Contains(item3))
				{
					config.Labels.Remove(item3);
					flag = true;
				}
			}
			if (flag)
			{
				Modified = true;
				ctlFriedmanCurve.method_14().SelectedObject = null;
				ctlFriedmanCurve.Invalidate();
				method_1(null, null);
				method_0();
			}
		}

		private void mInsertHeaderLabel_Click(object sender, EventArgs e)
		{
			FCHeaderLabelInfo fCHeaderLabelInfo = new FCHeaderLabelInfo();
			fCHeaderLabelInfo.Title = mInsertHeaderLabel.Text;
			ctlFriedmanCurve.method_14().Config.HeaderLabels.Add(fCHeaderLabelInfo);
			ctlFriedmanCurve.method_14().SelectedObject = fCHeaderLabelInfo;
			ctlFriedmanCurve.Invalidate();
			method_1(null, null);
			method_0();
			Modified = true;
		}

		private void mInsertHeaderLine_Click(object sender, EventArgs e)
		{
			FCTitleLineInfo fCTitleLineInfo = new FCTitleLineInfo();
			fCTitleLineInfo.Title = mInsertHeaderLine.Text;
			fCTitleLineInfo.Name = "NewLine";
			ctlFriedmanCurve.method_14().Config.HeaderLines.Add(fCTitleLineInfo);
			ctlFriedmanCurve.method_14().SelectedObject = fCTitleLineInfo;
			ctlFriedmanCurve.Invalidate();
			method_1(null, null);
			method_0();
			Modified = true;
		}

		private void mInsertYAxis_Click(object sender, EventArgs e)
		{
			FCYAxisInfo fCYAxisInfo = new FCYAxisInfo();
			fCYAxisInfo.Title = mInsertYAxis.Text;
			fCYAxisInfo.Name = "NewValue";
			ctlFriedmanCurve.method_14().Config.YAxisInfos.Add(fCYAxisInfo);
			ctlFriedmanCurve.method_14().SelectedObject = fCYAxisInfo;
			ctlFriedmanCurve.Invalidate();
			method_1(null, null);
			method_0();
			Modified = true;
		}

		private void mInsertFooterLine_Click(object sender, EventArgs e)
		{
			FCTitleLineInfo fCTitleLineInfo = new FCTitleLineInfo();
			fCTitleLineInfo.Title = mInsertFooterLine.Text;
			fCTitleLineInfo.Name = "NewLine";
			ctlFriedmanCurve.method_14().Config.FooterLines.Add(fCTitleLineInfo);
			ctlFriedmanCurve.method_14().SelectedObject = fCTitleLineInfo;
			ctlFriedmanCurve.Invalidate();
			method_1(null, null);
			method_0();
			Modified = true;
		}

		private void btnMovePre_Click(object sender, EventArgs e)
		{
			method_3(bool_2: true);
		}

		private void method_3(bool bool_2)
		{
			object selectedObject = ctlFriedmanCurve.method_14().SelectedObject;
			FriedmanCurveDocumentConfig config = ctlFriedmanCurve.method_14().Config;
			if (selectedObject is FCHeaderLabelInfo)
			{
				FCHeaderLabelInfo object_ = (FCHeaderLabelInfo)selectedObject;
				if (method_4(config.HeaderLabels, object_, bool_2, null))
				{
					ctlFriedmanCurve.Invalidate();
				}
			}
			else if (selectedObject is FCTitleLineInfo)
			{
				FCTitleLineInfo fCTitleLineInfo = (FCTitleLineInfo)selectedObject;
				if (config.HeaderLines.Contains(fCTitleLineInfo))
				{
					if (method_4(config.HeaderLines, fCTitleLineInfo, bool_2, bool_2 ? null : config.FooterLines))
					{
						ctlFriedmanCurve.Invalidate();
					}
				}
				else if (config.FooterLines.Contains(fCTitleLineInfo) && method_4(config.FooterLines, fCTitleLineInfo, bool_2, bool_2 ? config.HeaderLines : null))
				{
					ctlFriedmanCurve.Invalidate();
				}
			}
			else if (selectedObject is FCYAxisInfo)
			{
				FCYAxisInfo object_2 = (FCYAxisInfo)selectedObject;
				if (method_4(config.YAxisInfos, object_2, bool_2, null))
				{
					ctlFriedmanCurve.Invalidate();
				}
			}
			else if (selectedObject is DCFriedmanCurveImage)
			{
				DCFriedmanCurveImage object_3 = (DCFriedmanCurveImage)selectedObject;
				if (method_4(config.Images, object_3, bool_2, null))
				{
					ctlFriedmanCurve.Invalidate();
				}
			}
		}

		private void btnMoveNext_Click(object sender, EventArgs e)
		{
			method_3(bool_2: false);
		}

		private bool method_4(IList ilist_0, object object_0, bool bool_2, IList ilist_1)
		{
			int num = ilist_0.IndexOf(object_0);
			if (num < 0)
			{
				return false;
			}
			if (bool_2)
			{
				if (num == 0)
				{
					if (ilist_1 != null)
					{
						ilist_0.RemoveAt(num);
						ilist_1.Add(object_0);
						method_0();
						ctlFriedmanCurve.method_23();
						Modified = true;
						return true;
					}
					MessageBox.Show(this, DCFriedmanCurveStrings.CannotMoveForward, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return false;
				}
				ilist_0.RemoveAt(num);
				ilist_0.Insert(num - 1, object_0);
				method_0();
				ctlFriedmanCurve.method_23();
				Modified = true;
				return true;
			}
			if (num == ilist_0.Count - 1)
			{
				if (ilist_1 != null)
				{
					ilist_0.RemoveAt(num);
					ilist_1.Insert(0, object_0);
					method_0();
					ctlFriedmanCurve.method_23();
					Modified = true;
					return true;
				}
				MessageBox.Show(this, DCFriedmanCurveStrings.CannotMoveNext, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return false;
			}
			ilist_0.RemoveAt(num);
			ilist_0.Insert(num + 1, object_0);
			method_0();
			ctlFriedmanCurve.method_23();
			Modified = true;
			return true;
		}

		private void btnViewXMLSource_Click(object sender, EventArgs e)
		{
			string configXml = ctlFriedmanCurve.method_14().ConfigXml;
			using (FCfrmConfigXML fCfrmConfigXML = new FCfrmConfigXML())
			{
				fCfrmConfigXML.XMLText = configXml;
				if (fCfrmConfigXML.ShowDialog(this) == DialogResult.OK)
				{
					ctlFriedmanCurve.method_14().ConfigXml = fCfrmConfigXML.XMLText;
					ctlFriedmanCurve.Invalidate();
					method_1(null, null);
					Modified = true;
					method_0();
				}
			}
		}

		private void btnPageSettings_Click(object sender, EventArgs e)
		{
			using (PageSetupDialog pageSetupDialog = new PageSetupDialog())
			{
				pageSetupDialog.PageSettings = new PageSettings();
				FriedmanCurveDocumentConfig config = ctlFriedmanCurve.method_14().Config;
				pageSetupDialog.EnableMetric = true;
				if (pageSetupDialog.ShowDialog(this) == DialogResult.OK)
				{
					if (config.PageSettings == null)
					{
						config.PageSettings = new FCDocumentPageSettings();
					}
					config.PageSettings.method_1(pageSetupDialog.PageSettings);
					ctlFriedmanCurve.method_23();
					Modified = true;
				}
			}
		}

		private void mShowLocalPropertyName_Click(object sender, EventArgs e)
		{
			mShowLocalPropertyName.Checked = !mShowLocalPropertyName.Checked;
			GClass360.smethod_1(mShowLocalPropertyName.Checked);
			ctlProerty.Refresh();
		}

		private void method_5(object sender, EventArgs e)
		{
			int num = 3;
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = DCFriedmanCurveStrings.ImageFilter;
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					XImageValue image = new XImageValue(openFileDialog.FileName);
					DCFriedmanCurveImage dCFriedmanCurveImage = new DCFriedmanCurveImage();
					FriedmanCurveDocumentConfig config = ctlFriedmanCurve.method_14().Config;
					dCFriedmanCurveImage.Name = "Image" + config.Images.Count;
					dCFriedmanCurveImage.Image = image;
					config.Images.Add(dCFriedmanCurveImage);
					ctlFriedmanCurve.method_14().SelectedObject = dCFriedmanCurveImage;
					ctlFriedmanCurve.Invalidate();
					method_1(null, null);
					method_0();
					Modified = true;
				}
			}
		}

		private void mCloneInsert_Click(object sender, EventArgs e)
		{
			object selectedObject = ctlFriedmanCurve.method_14().SelectedObject;
			if (selectedObject == null)
			{
				return;
			}
			object obj = null;
			if (selectedObject is FCTitleLineInfo)
			{
				FCTitleLineInfo fCTitleLineInfo = (FCTitleLineInfo)selectedObject;
				if (ctlFriedmanCurve.method_14().HeaderLines.Contains(fCTitleLineInfo))
				{
					FCTitleLineInfo fCTitleLineInfo2 = fCTitleLineInfo.Clone();
					ctlFriedmanCurve.method_14().HeaderLines.Add(fCTitleLineInfo2);
					obj = fCTitleLineInfo2;
				}
				else if (ctlFriedmanCurve.method_14().FooterLines.Contains(fCTitleLineInfo))
				{
					FCTitleLineInfo fCTitleLineInfo2 = fCTitleLineInfo.Clone();
					ctlFriedmanCurve.method_14().FooterLines.Add(fCTitleLineInfo2);
					obj = fCTitleLineInfo2;
				}
			}
			else if (selectedObject is FCHeaderLabelInfo)
			{
				FCHeaderLabelInfo fCHeaderLabelInfo = (FCHeaderLabelInfo)selectedObject;
				FCHeaderLabelInfo fCHeaderLabelInfo2 = fCHeaderLabelInfo.Clone();
				ctlFriedmanCurve.method_14().HeaderLabels.Add(fCHeaderLabelInfo2);
				obj = fCHeaderLabelInfo2;
			}
			else if (selectedObject is FCYAxisInfo)
			{
				FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)selectedObject;
				FCYAxisInfo fCYAxisInfo2 = fCYAxisInfo.Clone();
				ctlFriedmanCurve.method_14().YAxisInfos.Add(fCYAxisInfo2);
				obj = fCYAxisInfo2;
			}
			else if (selectedObject is FriedmanCurveZoneInfo)
			{
				FriedmanCurveZoneInfo friedmanCurveZoneInfo = (FriedmanCurveZoneInfo)selectedObject;
				FriedmanCurveZoneInfo friedmanCurveZoneInfo2 = friedmanCurveZoneInfo.Clone();
				friedmanCurveZoneInfo2.StartTime = friedmanCurveZoneInfo.EndTime.AddDays(1.0);
				friedmanCurveZoneInfo2.EndTime = friedmanCurveZoneInfo2.StartTime.AddDays(1.0);
				ctlFriedmanCurve.method_14().Config.Zones.Add(friedmanCurveZoneInfo2);
				obj = friedmanCurveZoneInfo2;
			}
			if (obj != null)
			{
				ctlFriedmanCurve.method_14().SelectedObject = obj;
				ctlFriedmanCurve.Invalidate();
				tvwDOM_AfterSelect(null, null);
				method_0();
				Modified = true;
			}
		}

		private void btnTreeView_Click(object sender, EventArgs e)
		{
			tvwDOM.Visible = btnTreeView.Checked;
			spTreeView.Visible = btnTreeView.Checked;
		}

		private void tvwDOM_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (!bool_1)
			{
				return;
			}
			bool_1 = false;
			if (tvwDOM.SelectedNode != null)
			{
				object tag = tvwDOM.SelectedNode.Tag;
				if (ctlFriedmanCurve.method_14().SelectedObject != tag)
				{
					ctlFriedmanCurve.method_14().SelectedObject = tag;
					ctlFriedmanCurve.Invalidate();
					ctlProerty.SelectedObject = tag;
				}
			}
			bool_1 = true;
		}

		private void mNewTimeZone_Click(object sender, EventArgs e)
		{
			FriedmanCurveZoneInfo friedmanCurveZoneInfo = new FriedmanCurveZoneInfo();
			friedmanCurveZoneInfo.StartTime = DateTime.Now.Date;
			friedmanCurveZoneInfo.EndTime = friedmanCurveZoneInfo.StartTime.AddDays(1.0);
			friedmanCurveZoneInfo.Name = "zone" + ctlFriedmanCurve.method_14().Config.Zones.Count;
			ctlFriedmanCurve.method_14().Config.Zones.Add(friedmanCurveZoneInfo);
			ctlFriedmanCurve.method_14().SelectedObject = friedmanCurveZoneInfo;
			method_0();
			method_2(tvwDOM.Nodes, friedmanCurveZoneInfo);
		}

		private void menuInsertLabel_Click(object sender, EventArgs e)
		{
			DCFriedmanCurveLabel dCFriedmanCurveLabel = new DCFriedmanCurveLabel();
			dCFriedmanCurveLabel.Text = DCFriedmanCurveStrings.DocumentLabel;
			ctlFriedmanCurve.method_14().Config.Labels.Add(dCFriedmanCurveLabel);
			ctlFriedmanCurve.method_14().SelectedObject = dCFriedmanCurveLabel;
			method_0();
			method_2(tvwDOM.Nodes, dCFriedmanCurveLabel);
		}
	}
}

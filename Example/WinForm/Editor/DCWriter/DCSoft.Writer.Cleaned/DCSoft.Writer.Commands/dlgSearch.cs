using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       搜索内容对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgSearch : Form
	{
		private SearchReplaceCommandArgs searchReplaceCommandArgs_0 = null;

		private WriterControl writerControl_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private Class53 class53_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtSearchString;

		private CheckBox chkReplace;

		private TextBox txtReplaceString;

		private GroupBox groupBox1;

		private RadioButton rdoDown;

		private RadioButton rdoUP;

		private Button btnSearch;

		private Button btnReplace;

		private Button btnReplaceAll;

		private Button btnCancel;

		private CheckBox chkIgnoreCase;

		private CheckBox chkSearchID;

		private CheckBox chkExcludeBackgroundText;

		/// <summary>
		///       命令参数对象
		///       </summary>
		public SearchReplaceCommandArgs CommandArgs
		{
			get
			{
				return searchReplaceCommandArgs_0;
			}
			set
			{
				searchReplaceCommandArgs_0 = value;
			}
		}

		/// <summary>
		///       编辑器控件对象
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
		///       文档对象
		///       </summary>
		public XTextDocument TextDocument
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       是否允许替换
		///       </summary>
		public bool EnableReplace
		{
			get
			{
				return btnReplace.Enabled;
			}
			set
			{
				btnReplace.Enabled = value;
				btnReplaceAll.Enabled = value;
				chkReplace.Enabled = value;
				txtReplaceString.Enabled = (chkReplace.Enabled && chkReplace.Checked);
				btnReplace.Visible = value;
				btnReplaceAll.Visible = value;
				chkReplace.Visible = value;
				txtReplaceString.Visible = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgSearch()
		{
			InitializeComponent();
		}

		private void dlgSearch_Load(object sender, EventArgs e)
		{
			if (WriterControl != null)
			{
				Text = WriterControl.DialogTitlePrefix + Text;
			}
		}

		/// <summary>
		///       窗体事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnActivated(EventArgs eventArgs_0)
		{
			base.OnActivated(eventArgs_0);
			if (WriterControl != null)
			{
				WriterControl.InnerViewControl.ForceShowCaret = true;
			}
		}

		/// <summary>
		///       窗体事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			base.OnLostFocus(eventArgs_0);
			if (WriterControl != null)
			{
				WriterControl.InnerViewControl.ForceShowCaret = false;
			}
		}

		public void method_0()
		{
			if (searchReplaceCommandArgs_0 == null)
			{
				searchReplaceCommandArgs_0 = new SearchReplaceCommandArgs();
			}
			txtSearchString.Text = searchReplaceCommandArgs_0.SearchString;
			chkReplace.Checked = searchReplaceCommandArgs_0.EnableReplaceString;
			if (WriterControl != null)
			{
				chkReplace.Enabled = !WriterControl.RuntimeReadonly;
			}
			txtReplaceString.Text = searchReplaceCommandArgs_0.ReplaceString;
			txtReplaceString.Enabled = (chkReplace.Enabled && chkReplace.Checked);
			rdoUP.Checked = !searchReplaceCommandArgs_0.Backward;
			rdoDown.Checked = searchReplaceCommandArgs_0.Backward;
			chkIgnoreCase.Checked = searchReplaceCommandArgs_0.IgnoreCase;
			method_3();
		}

		private void chkReplace_CheckedChanged(object sender, EventArgs e)
		{
			method_3();
		}

		private void method_1()
		{
			searchReplaceCommandArgs_0.SearchString = txtSearchString.Text;
			searchReplaceCommandArgs_0.EnableReplaceString = chkReplace.Checked;
			searchReplaceCommandArgs_0.ReplaceString = txtReplaceString.Text;
			searchReplaceCommandArgs_0.IgnoreCase = chkIgnoreCase.Checked;
			searchReplaceCommandArgs_0.SearchID = chkSearchID.Checked;
			searchReplaceCommandArgs_0.ExcludeBackgroundText = chkExcludeBackgroundText.Checked;
			if (rdoDown.Checked)
			{
				searchReplaceCommandArgs_0.Backward = true;
			}
			else if (rdoUP.Checked)
			{
				searchReplaceCommandArgs_0.Backward = false;
			}
		}

		private Class53 method_2()
		{
			method_1();
			XTextDocument xTextDocument = TextDocument;
			if (xTextDocument == null && WriterControl != null)
			{
				xTextDocument = WriterControl.Document;
			}
			if (xTextDocument == null)
			{
				return null;
			}
			if (class53_0 == null)
			{
				class53_0 = new Class53();
			}
			class53_0.imethod_5(xTextDocument);
			class53_0.imethod_1(bool_2: true);
			class53_0.imethod_3(this);
			return class53_0;
		}

		/// <summary>
		///       查找按钮事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			Class53 @class = method_2();
			if (@class != null)
			{
				int num = @class.imethod_11(searchReplaceCommandArgs_0, bool_2: true, -1);
				if (num < 0)
				{
					WriterControl.AppHost.UITools.ShowMessageBox(this, WriterStrings.CannotSearchSpecifyContent);
				}
				else if (WriterControl != null)
				{
				}
			}
		}

		/// <summary>
		///       替换按钮事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnReplace_Click(object sender, EventArgs e)
		{
			Class53 @class = method_2();
			if (@class == null)
			{
				return;
			}
			int num = @class.imethod_9(searchReplaceCommandArgs_0);
			if (num < 0)
			{
				switch (num)
				{
				case -1:
					WriterControl.AppHost.UITools.ShowMessageBox(this, WriterStrings.CannotSearchSpecifyContent);
					break;
				case -2:
					WriterControl.AppHost.UITools.ShowMessageBox(this, WriterStrings.FailReplace);
					break;
				}
			}
			else if (WriterControl != null)
			{
			}
		}

		private void txtSearchString_TextChanged(object sender, EventArgs e)
		{
			method_3();
		}

		private void method_3()
		{
			rdoDown.Enabled = !chkSearchID.Checked;
			rdoUP.Enabled = !chkSearchID.Checked;
			chkExcludeBackgroundText.Enabled = !chkSearchID.Checked;
			chkIgnoreCase.Enabled = !chkSearchID.Checked;
			bool flag = !string.IsNullOrEmpty(txtSearchString.Text);
			btnSearch.Enabled = flag;
			txtReplaceString.Enabled = (chkReplace.Checked && chkReplace.Enabled && !chkSearchID.Checked);
			btnReplace.Enabled = (flag && chkReplace.Checked && chkReplace.Enabled && !chkSearchID.Checked);
			btnReplaceAll.Enabled = (flag && chkReplace.Checked && chkReplace.Enabled && !chkSearchID.Checked);
		}

		private void btnReplaceAll_Click(object sender, EventArgs e)
		{
			Class53 @class = method_2();
			if (@class != null)
			{
				int num = @class.imethod_8(searchReplaceCommandArgs_0);
				if (num < 0)
				{
					WriterControl.AppHost.UITools.ShowMessageBox(this, WriterStrings.CannotSearchSpecifyContent);
				}
				else
				{
					WriterControl.AppHost.UITools.ShowMessageBox(this, string.Format(WriterStrings.PromptReplaceAllResult_Times, num));
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkSearchID_CheckedChanged(object sender, EventArgs e)
		{
			method_3();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgSearch));
			label1 = new System.Windows.Forms.Label();
			txtSearchString = new System.Windows.Forms.TextBox();
			chkReplace = new System.Windows.Forms.CheckBox();
			txtReplaceString = new System.Windows.Forms.TextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rdoDown = new System.Windows.Forms.RadioButton();
			rdoUP = new System.Windows.Forms.RadioButton();
			btnSearch = new System.Windows.Forms.Button();
			btnReplace = new System.Windows.Forms.Button();
			btnReplaceAll = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkIgnoreCase = new System.Windows.Forms.CheckBox();
			chkSearchID = new System.Windows.Forms.CheckBox();
			chkExcludeBackgroundText = new System.Windows.Forms.CheckBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtSearchString, "txtSearchString");
			txtSearchString.Name = "txtSearchString";
			txtSearchString.TextChanged += new System.EventHandler(txtSearchString_TextChanged);
			resources.ApplyResources(chkReplace, "chkReplace");
			chkReplace.Name = "chkReplace";
			chkReplace.UseVisualStyleBackColor = true;
			chkReplace.CheckedChanged += new System.EventHandler(chkReplace_CheckedChanged);
			resources.ApplyResources(txtReplaceString, "txtReplaceString");
			txtReplaceString.Name = "txtReplaceString";
			groupBox1.Controls.Add(rdoDown);
			groupBox1.Controls.Add(rdoUP);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(rdoDown, "rdoDown");
			rdoDown.Name = "rdoDown";
			rdoDown.TabStop = true;
			rdoDown.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoUP, "rdoUP");
			rdoUP.Name = "rdoUP";
			rdoUP.TabStop = true;
			rdoUP.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnSearch, "btnSearch");
			btnSearch.Name = "btnSearch";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += new System.EventHandler(btnSearch_Click);
			resources.ApplyResources(btnReplace, "btnReplace");
			btnReplace.Name = "btnReplace";
			btnReplace.UseVisualStyleBackColor = true;
			btnReplace.Click += new System.EventHandler(btnReplace_Click);
			resources.ApplyResources(btnReplaceAll, "btnReplaceAll");
			btnReplaceAll.Name = "btnReplaceAll";
			btnReplaceAll.UseVisualStyleBackColor = true;
			btnReplaceAll.Click += new System.EventHandler(btnReplaceAll_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(chkIgnoreCase, "chkIgnoreCase");
			chkIgnoreCase.Name = "chkIgnoreCase";
			chkIgnoreCase.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkSearchID, "chkSearchID");
			chkSearchID.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSearchID.Name = "chkSearchID";
			chkSearchID.UseVisualStyleBackColor = true;
			chkSearchID.CheckedChanged += new System.EventHandler(chkSearchID_CheckedChanged);
			resources.ApplyResources(chkExcludeBackgroundText, "chkExcludeBackgroundText");
			chkExcludeBackgroundText.Checked = true;
			chkExcludeBackgroundText.CheckState = System.Windows.Forms.CheckState.Checked;
			chkExcludeBackgroundText.Name = "chkExcludeBackgroundText";
			chkExcludeBackgroundText.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(chkExcludeBackgroundText);
			base.Controls.Add(chkSearchID);
			base.Controls.Add(chkIgnoreCase);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnReplaceAll);
			base.Controls.Add(btnReplace);
			base.Controls.Add(btnSearch);
			base.Controls.Add(groupBox1);
			base.Controls.Add(chkReplace);
			base.Controls.Add(txtReplaceString);
			base.Controls.Add(txtSearchString);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSearch";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgSearch_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

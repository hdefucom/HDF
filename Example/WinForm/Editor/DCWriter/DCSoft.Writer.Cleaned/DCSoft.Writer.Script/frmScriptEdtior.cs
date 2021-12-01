using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       脚本编辑窗口
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class frmScriptEdtior : Form
	{
		private ScriptLanguageType scriptLanguageType_0 = ScriptLanguageType.VBNET;

		private XTextDocument xtextDocument_0 = null;

		private bool bool_0 = false;

		private string string_0 = null;

		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private ToolStripButton btnSave;

		private StatusStrip statusStrip1;

		private TextBox txtScript;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton btnCompile;

		private TabControl myTabControl;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TextBox txtCompileResult;

		private ToolStripButton btnClose;

		private SplitContainer splitContainer1;

		private ListBox lstReference;

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
		///       文档对象
		///       </summary>
		public XTextDocument Document
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
		///       内容只读
		///       </summary>
		public bool Readonly
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
		///       编辑的脚本代码文本
		///       </summary>
		public string ScriptText
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
		///       初始化对象
		///       </summary>
		public frmScriptEdtior()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void frmScriptEdtior_Load(object sender, EventArgs e)
		{
			int num = 8;
			txtScript.Text = string_0;
			txtScript.Modified = false;
			btnSave.Enabled = !Readonly;
			txtScript.ReadOnly = Readonly;
			if (Readonly)
			{
				Text = Text + "[" + WriterStrings.Readonly + "]";
			}
			method_0(string_0);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string_0 = txtScript.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCompile_Click(object sender, EventArgs e)
		{
			IDocumentScriptEngine documentScriptEngine = Document.method_45();
			documentScriptEngine.ScriptText = txtScript.Text;
			if (documentScriptEngine.DebugCompile())
			{
				txtCompileResult.Text = "";
				Document.AppHost.UITools.ShowMessageBox(this, WriterStrings.ScriptCompileOK);
				method_0(txtScript.Text);
			}
			else
			{
				txtCompileResult.Text = documentScriptEngine.RuntimeScriptTextWithCompilerErrorMessage;
				myTabControl.SelectedIndex = 1;
				Document.AppHost.UITools.ShowWarringMessageBox(this, WriterStrings.ScriptCompileFail);
			}
		}

		private void frmScriptEdtior_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (txtScript.Modified && !Readonly && base.DialogResult == DialogResult.Cancel)
			{
				switch (MessageBox.Show(this, WriterStrings.QuerySave, WriterStrings.SystemAlert, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					string_0 = txtScript.Text;
					base.DialogResult = DialogResult.OK;
					break;
				case DialogResult.No:
					base.DialogResult = DialogResult.Cancel;
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void method_0(string string_1)
		{
			string pattern = "sub\\s(\\w+)\\s*\\(";
			new ArrayList();
			if (!string.IsNullOrEmpty(string_1) && Regex.IsMatch(string_1, pattern, RegexOptions.IgnoreCase))
			{
				lstReference.Items.Clear();
				foreach (Match item in Regex.Matches(string_1, pattern, RegexOptions.IgnoreCase))
				{
					if (item.Success && item.Groups.Count == 2)
					{
						lstReference.Items.Add(item.Groups[1]);
					}
				}
			}
		}

		private void lstReference_SelectedValueChanged(object sender, EventArgs e)
		{
			txtScript.Focus();
			Group group = (Group)lstReference.SelectedItem;
			txtScript.Select(group.Index, group.Length);
			txtScript.ScrollToCaret();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Script.frmScriptEdtior));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnSave = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnCompile = new System.Windows.Forms.ToolStripButton();
			btnClose = new System.Windows.Forms.ToolStripButton();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			txtScript = new System.Windows.Forms.TextBox();
			myTabControl = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			txtCompileResult = new System.Windows.Forms.TextBox();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			lstReference = new System.Windows.Forms.ListBox();
			toolStrip1.SuspendLayout();
			myTabControl.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				btnSave,
				toolStripSeparator1,
				btnCompile,
				btnClose
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			btnSave.AutoToolTip = false;
			resources.ApplyResources(btnSave, "btnSave");
			btnSave.Name = "btnSave";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			btnCompile.AutoToolTip = false;
			resources.ApplyResources(btnCompile, "btnCompile");
			btnCompile.Name = "btnCompile";
			btnCompile.Click += new System.EventHandler(btnCompile_Click);
			btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnClose.AutoToolTip = false;
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.Name = "btnClose";
			btnClose.Click += new System.EventHandler(btnClose_Click);
			resources.ApplyResources(statusStrip1, "statusStrip1");
			statusStrip1.Name = "statusStrip1";
			txtScript.AcceptsTab = true;
			txtScript.AllowDrop = true;
			resources.ApplyResources(txtScript, "txtScript");
			txtScript.Name = "txtScript";
			myTabControl.Controls.Add(tabPage1);
			myTabControl.Controls.Add(tabPage2);
			resources.ApplyResources(myTabControl, "myTabControl");
			myTabControl.Name = "myTabControl";
			myTabControl.SelectedIndex = 0;
			tabPage1.Controls.Add(txtScript);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			tabPage2.Controls.Add(txtCompileResult);
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			txtCompileResult.AcceptsTab = true;
			txtCompileResult.AllowDrop = true;
			resources.ApplyResources(txtCompileResult, "txtCompileResult");
			txtCompileResult.Name = "txtCompileResult";
			txtCompileResult.ReadOnly = true;
			resources.ApplyResources(splitContainer1, "splitContainer1");
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(lstReference);
			splitContainer1.Panel2.Controls.Add(myTabControl);
			resources.ApplyResources(lstReference, "lstReference");
			lstReference.FormattingEnabled = true;
			lstReference.Name = "lstReference";
			lstReference.Sorted = true;
			lstReference.SelectedValueChanged += new System.EventHandler(lstReference_SelectedValueChanged);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(splitContainer1);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(toolStrip1);
			base.MinimizeBox = false;
			base.Name = "frmScriptEdtior";
			base.ShowInTaskbar = false;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmScriptEdtior_FormClosing);
			base.Load += new System.EventHandler(frmScriptEdtior_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			myTabControl.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

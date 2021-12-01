using DCSoft.Writer.Script;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       VB脚本编辑器窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgVBScriptEditor : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstName;

		private TextBox txtScript;

		private Button btnOK;

		private Button btnCancel;

		private VBScriptItemList vbscriptItemList_0 = null;

		/// <summary>
		///       脚本集合
		///       </summary>
		public VBScriptItemList ScriptItems
		{
			get
			{
				return vbscriptItemList_0;
			}
			set
			{
				vbscriptItemList_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgVBScriptEditor));
			lstName = new System.Windows.Forms.ListBox();
			txtScript = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lstName, "lstName");
			lstName.FormattingEnabled = true;
			lstName.Items.AddRange(new object[21]
			{
				resources.GetString("lstName.Items"),
				resources.GetString("lstName.Items1"),
				resources.GetString("lstName.Items2"),
				resources.GetString("lstName.Items3"),
				resources.GetString("lstName.Items4"),
				resources.GetString("lstName.Items5"),
				resources.GetString("lstName.Items6"),
				resources.GetString("lstName.Items7"),
				resources.GetString("lstName.Items8"),
				resources.GetString("lstName.Items9"),
				resources.GetString("lstName.Items10"),
				resources.GetString("lstName.Items11"),
				resources.GetString("lstName.Items12"),
				resources.GetString("lstName.Items13"),
				resources.GetString("lstName.Items14"),
				resources.GetString("lstName.Items15"),
				resources.GetString("lstName.Items16"),
				resources.GetString("lstName.Items17"),
				resources.GetString("lstName.Items18"),
				resources.GetString("lstName.Items19"),
				resources.GetString("lstName.Items20")
			});
			lstName.Name = "lstName";
			lstName.SelectedIndexChanged += new System.EventHandler(lstName_SelectedIndexChanged);
			txtScript.AcceptsReturn = true;
			txtScript.AcceptsTab = true;
			resources.ApplyResources(txtScript, "txtScript");
			txtScript.Name = "txtScript";
			txtScript.TextChanged += new System.EventHandler(txtScript_TextChanged);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtScript);
			base.Controls.Add(lstName);
			base.MinimizeBox = false;
			base.Name = "dlgVBScriptEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgVBScriptEditor_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgVBScriptEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgVBScriptEditor_Load(object sender, EventArgs e)
		{
			if (vbscriptItemList_0 == null)
			{
				vbscriptItemList_0 = new VBScriptItemList();
			}
			lstName.SelectedIndex = 0;
		}

		private void lstName_SelectedIndexChanged(object sender, EventArgs e)
		{
			VBScriptItem vBScriptItem = vbscriptItemList_0[lstName.Text];
			if (vBScriptItem != null)
			{
				txtScript.Text = vBScriptItem.ScriptText;
			}
			else
			{
				txtScript.Text = "";
			}
		}

		private void txtScript_TextChanged(object sender, EventArgs e)
		{
			VBScriptItem vBScriptItem = vbscriptItemList_0[lstName.Text];
			if (vBScriptItem == null)
			{
				vBScriptItem = new VBScriptItem();
				vBScriptItem.Name = lstName.Text;
				vbscriptItemList_0.Add(vBScriptItem);
			}
			vBScriptItem.ScriptText = txtScript.Text;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

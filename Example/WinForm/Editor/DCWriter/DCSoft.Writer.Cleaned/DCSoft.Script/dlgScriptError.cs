using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Script
{
	/// <summary>
	///       脚本错误消息对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgScriptError : Form
	{
		private IContainer icontainer_0 = null;

		private ComboBox cboList;

		private TextBox txtMessage;

		private Button btnViewFullSource;

		private Button btnClose;

		private Button btnClearError;

		private XVBAEngine xvbaengine_0 = null;

		public XVBAEngine VBAEngine
		{
			get
			{
				return xvbaengine_0;
			}
			set
			{
				xvbaengine_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Script.dlgScriptError));
			cboList = new System.Windows.Forms.ComboBox();
			txtMessage = new System.Windows.Forms.TextBox();
			btnViewFullSource = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			btnClearError = new System.Windows.Forms.Button();
			SuspendLayout();
			cboList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboList.FormattingEnabled = true;
			resources.ApplyResources(cboList, "cboList");
			cboList.Name = "cboList";
			cboList.SelectedIndexChanged += new System.EventHandler(cboList_SelectedIndexChanged);
			resources.ApplyResources(txtMessage, "txtMessage");
			txtMessage.Name = "txtMessage";
			txtMessage.ReadOnly = true;
			resources.ApplyResources(btnViewFullSource, "btnViewFullSource");
			btnViewFullSource.Name = "btnViewFullSource";
			btnViewFullSource.UseVisualStyleBackColor = true;
			btnViewFullSource.Click += new System.EventHandler(btnViewFullSource_Click);
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.Name = "btnClose";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			resources.ApplyResources(btnClearError, "btnClearError");
			btnClearError.Name = "btnClearError";
			btnClearError.UseVisualStyleBackColor = true;
			btnClearError.Click += new System.EventHandler(btnClearError_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnClearError);
			base.Controls.Add(btnClose);
			base.Controls.Add(btnViewFullSource);
			base.Controls.Add(txtMessage);
			base.Controls.Add(cboList);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgScriptError";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgScriptError_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgScriptError()
		{
			InitializeComponent();
		}

		private void dlgScriptError_Load(object sender, EventArgs e)
		{
			if (xvbaengine_0 != null)
			{
				if (xvbaengine_0.Errors != null)
				{
					foreach (ScriptError error in xvbaengine_0.Errors)
					{
						cboList.Items.Add(error);
					}
				}
				if (cboList.Items.Count > 0)
				{
					cboList.SelectedIndex = cboList.Items.Count - 1;
					return;
				}
				cboList.Enabled = false;
				txtMessage.Text = ScriptStrings.NoScriptError;
			}
		}

		private void cboList_SelectedIndexChanged(object sender, EventArgs e)
		{
			int num = 11;
			ScriptError scriptError = cboList.SelectedItem as ScriptError;
			if (scriptError != null)
			{
				txtMessage.Text = scriptError.ToString() + Environment.NewLine + ScriptStrings.Time + ":" + scriptError.Time.ToString("yyyy-MM-dd HH:mm:ss.ff") + Environment.NewLine + ScriptStrings.Method + ":" + scriptError.MethodName + Environment.NewLine + ScriptStrings.Script + ":" + scriptError.ScriptText;
			}
		}

		private void btnViewFullSource_Click(object sender, EventArgs e)
		{
			if (VBAEngine != null)
			{
				using (frmFullScriptText frmFullScriptText = new frmFullScriptText())
				{
					frmFullScriptText.ScriptText = VBAEngine.RuntimeScriptTextWithCompilerErrorMessage;
					frmFullScriptText.ShowDialog(this);
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnClearError_Click(object sender, EventArgs e)
		{
			if (VBAEngine != null && VBAEngine.Errors != null)
			{
				VBAEngine.Errors.Clear();
			}
		}
	}
}

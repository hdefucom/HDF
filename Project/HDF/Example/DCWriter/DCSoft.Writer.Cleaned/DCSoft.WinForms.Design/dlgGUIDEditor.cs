using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       dlgGUIDEditor 的摘要说明。
	///       </summary>
	public class dlgGUIDEditor : Form
	{
		private Label label1;

		private TextBox txtText;

		private Button cmdGenerate;

		private Button cmdOK;

		private Button cmdCancel;

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private Container components = null;

		private Guid myInputValue = Guid.Empty;

		public Guid InputValue
		{
			get
			{
				return myInputValue;
			}
			set
			{
				myInputValue = value;
			}
		}

		public dlgGUIDEditor()
		{
			InitializeComponent();
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			base.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.Design.dlgGUIDEditor));
			label1 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			cmdGenerate = new System.Windows.Forms.Button();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AccessibleDescription = null;
			label1.AccessibleName = null;
			resources.ApplyResources(label1, "label1");
			label1.Font = null;
			label1.Name = "label1";
			txtText.AccessibleDescription = null;
			txtText.AccessibleName = null;
			resources.ApplyResources(txtText, "txtText");
			txtText.BackgroundImage = null;
			txtText.Font = null;
			txtText.Name = "txtText";
			cmdGenerate.AccessibleDescription = null;
			cmdGenerate.AccessibleName = null;
			resources.ApplyResources(cmdGenerate, "cmdGenerate");
			cmdGenerate.BackgroundImage = null;
			cmdGenerate.Font = null;
			cmdGenerate.Name = "cmdGenerate";
			cmdGenerate.Click += new System.EventHandler(cmdGenerate_Click);
			cmdOK.AccessibleDescription = null;
			cmdOK.AccessibleName = null;
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.BackgroundImage = null;
			cmdOK.Font = null;
			cmdOK.Name = "cmdOK";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.AccessibleDescription = null;
			cmdCancel.AccessibleName = null;
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.BackgroundImage = null;
			cmdCancel.Font = null;
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			BackgroundImage = null;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(cmdGenerate);
			base.Controls.Add(txtText);
			base.Controls.Add(label1);
			Font = null;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = null;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgGUIDEditor";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgGUIDEditor_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		private void dlgGUIDEditor_Load(object sender, EventArgs e)
		{
			txtText.Text = myInputValue.ToString("D");
		}

		private void cmdGenerate_Click(object sender, EventArgs e)
		{
			txtText.Text = Guid.NewGuid().ToString("D");
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			int num = 5;
			try
			{
				myInputValue = new Guid(txtText.Text.Trim());
				base.DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "错误的编号格式:" + ex.Message, "系统提示");
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

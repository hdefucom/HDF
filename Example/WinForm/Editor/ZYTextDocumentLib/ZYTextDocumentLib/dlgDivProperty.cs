using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class dlgDivProperty : Form
	{
		private Label label1;

		private TextBox txtName;

		private Label label2;

		private TextBox txtTitle;

		private CheckBox chkShowTitle;

		private Button cmdOK;

		public ZYTextDiv DivObject = null;

		private Button cmdCancel;

		private CheckBox chkCanHaveContent;

		private CheckBox chkTitleLine;

		private Container components = null;

		public dlgDivProperty()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtTitle = new System.Windows.Forms.TextBox();
			chkShowTitle = new System.Windows.Forms.CheckBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			chkCanHaveContent = new System.Windows.Forms.CheckBox();
			chkTitleLine = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(35, 17);
			label1.TabIndex = 0;
			label1.Text = "名称:";
			txtName.Location = new System.Drawing.Point(48, 16);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(160, 21);
			txtName.TabIndex = 1;
			txtName.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(35, 17);
			label2.TabIndex = 0;
			label2.Text = "标题:";
			txtTitle.Location = new System.Drawing.Point(48, 56);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new System.Drawing.Size(160, 21);
			txtTitle.TabIndex = 1;
			txtTitle.Text = "";
			chkShowTitle.Location = new System.Drawing.Point(8, 88);
			chkShowTitle.Name = "chkShowTitle";
			chkShowTitle.Size = new System.Drawing.Size(160, 24);
			chkShowTitle.TabIndex = 2;
			chkShowTitle.Text = "隐藏标题";
			cmdOK.Location = new System.Drawing.Point(184, 160);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 3;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Location = new System.Drawing.Point(272, 160);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 4;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			chkCanHaveContent.Location = new System.Drawing.Point(8, 112);
			chkCanHaveContent.Name = "chkCanHaveContent";
			chkCanHaveContent.Size = new System.Drawing.Size(160, 24);
			chkCanHaveContent.TabIndex = 5;
			chkCanHaveContent.Text = "不允许包含内容";
			chkTitleLine.Location = new System.Drawing.Point(8, 136);
			chkTitleLine.Name = "chkTitleLine";
			chkTitleLine.Size = new System.Drawing.Size(160, 24);
			chkTitleLine.TabIndex = 6;
			chkTitleLine.Text = "标题占据一行";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(354, 191);
			base.Controls.Add(chkTitleLine);
			base.Controls.Add(chkCanHaveContent);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(chkShowTitle);
			base.Controls.Add(txtName);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(txtTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDivProperty";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "文本块属性";
			base.Load += new System.EventHandler(dlgDivProperty_Load);
			ResumeLayout(false);
		}

		private void dlgDivProperty_Load(object sender, EventArgs e)
		{
			if (DivObject != null)
			{
				txtName.Text = DivObject.ID;
				txtTitle.Text = DivObject.Title;
				chkShowTitle.Checked = DivObject.HideTitle;
				chkCanHaveContent.Checked = DivObject.NoContent;
				chkTitleLine.Checked = DivObject.TitleLine;
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			if (DivObject != null)
			{
				DivObject.ID = txtName.Text.Trim();
				DivObject.Title = txtTitle.Text.Trim();
				DivObject.HideTitle = chkShowTitle.Checked;
				DivObject.NoContent = chkCanHaveContent.Checked;
				DivObject.TitleLine = chkTitleLine.Checked;
				DivObject.OwnerDocument.Modified = true;
			}
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

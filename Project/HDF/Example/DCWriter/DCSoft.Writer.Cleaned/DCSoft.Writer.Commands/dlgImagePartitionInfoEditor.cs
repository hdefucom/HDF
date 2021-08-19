using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgImagePartitionInfoEditor : Form
	{
		public string string_0;

		public int int_0;

		private IContainer icontainer_0 = null;

		private Label lblText;

		private Label lblValue;

		private TextBox txtText;

		private TextBox txtValue;

		private Button btnOK;

		private Button btnCancel;

		public dlgImagePartitionInfoEditor()
		{
			InitializeComponent();
			string_0 = "";
			int_0 = 0;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string_0 = txtText.Text;
			int_0 = Convert.ToInt32(txtValue.Text);
			base.DialogResult = DialogResult.OK;
			Close();
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
			lblText = new System.Windows.Forms.Label();
			lblValue = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			txtValue = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			lblText.AutoSize = true;
			lblText.Location = new System.Drawing.Point(12, 19);
			lblText.Name = "lblText";
			lblText.Size = new System.Drawing.Size(125, 12);
			lblText.TabIndex = 0;
			lblText.Text = "设置区域的文本信息：";
			lblValue.AutoSize = true;
			lblValue.Location = new System.Drawing.Point(12, 57);
			lblValue.Name = "lblValue";
			lblValue.Size = new System.Drawing.Size(125, 12);
			lblValue.TabIndex = 1;
			lblValue.Text = "设置区域的数值信息：";
			txtText.Location = new System.Drawing.Point(143, 16);
			txtText.Name = "txtText";
			txtText.Size = new System.Drawing.Size(100, 21);
			txtText.TabIndex = 2;
			txtValue.Location = new System.Drawing.Point(143, 52);
			txtValue.Name = "txtValue";
			txtValue.Size = new System.Drawing.Size(100, 21);
			txtValue.TabIndex = 3;
			txtValue.Text = "0";
			btnOK.Location = new System.Drawing.Point(27, 93);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "确定";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(132, 93);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(258, 130);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtValue);
			base.Controls.Add(txtText);
			base.Controls.Add(lblValue);
			base.Controls.Add(lblText);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgImagePartitionInfoEditor";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "请设置本图片区域的关联信息";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

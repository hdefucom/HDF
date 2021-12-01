using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgSpecifyPageIndex : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown txtValue;

		private Button btnOK;

		private Button btnCancel;

		public int InputValue
		{
			get
			{
				return (int)txtValue.Value;
			}
			set
			{
				txtValue.Value = value;
			}
		}

		public dlgSpecifyPageIndex()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgSpecifyPageIndex_Load(object sender, EventArgs e)
		{
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
			label1 = new System.Windows.Forms.Label();
			txtValue = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)txtValue).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 12);
			label1.TabIndex = 0;
			label1.Text = "请输入页码值：";
			txtValue.Location = new System.Drawing.Point(22, 33);
			txtValue.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			txtValue.Name = "txtValue";
			txtValue.Size = new System.Drawing.Size(139, 21);
			txtValue.TabIndex = 1;
			txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			btnOK.Location = new System.Drawing.Point(8, 78);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(103, 78);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(193, 113);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtValue);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSpecifyPageIndex";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "指定页码值";
			base.Load += new System.EventHandler(dlgSpecifyPageIndex_Load);
			((System.ComponentModel.ISupportInitialize)txtValue).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

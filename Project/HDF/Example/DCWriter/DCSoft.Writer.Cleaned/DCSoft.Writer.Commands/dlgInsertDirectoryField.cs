using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgInsertDirectoryField : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private ComboBox cboDisplayLevel;

		private CheckBox chkShowPageIndex;

		private Button btnOK;

		private Button btnCancel;

		private XTextDirectoryFieldElement xtextDirectoryFieldElement_0 = null;

		public XTextDirectoryFieldElement InputElement
		{
			get
			{
				return xtextDirectoryFieldElement_0;
			}
			set
			{
				xtextDirectoryFieldElement_0 = value;
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
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			cboDisplayLevel = new System.Windows.Forms.ComboBox();
			chkShowPageIndex = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 0;
			label1.Text = "编号：";
			txtID.Location = new System.Drawing.Point(71, 6);
			txtID.Name = "txtID";
			txtID.Size = new System.Drawing.Size(162, 21);
			txtID.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 52);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 12);
			label2.TabIndex = 2;
			label2.Text = "显示级别：";
			cboDisplayLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDisplayLevel.FormattingEnabled = true;
			cboDisplayLevel.Items.AddRange(new object[9]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			});
			cboDisplayLevel.Location = new System.Drawing.Point(71, 49);
			cboDisplayLevel.Name = "cboDisplayLevel";
			cboDisplayLevel.Size = new System.Drawing.Size(162, 20);
			cboDisplayLevel.TabIndex = 3;
			chkShowPageIndex.AutoSize = true;
			chkShowPageIndex.Location = new System.Drawing.Point(12, 92);
			chkShowPageIndex.Name = "chkShowPageIndex";
			chkShowPageIndex.Size = new System.Drawing.Size(72, 16);
			chkShowPageIndex.TabIndex = 4;
			chkShowPageIndex.Text = "显示页码";
			chkShowPageIndex.UseVisualStyleBackColor = true;
			btnOK.Location = new System.Drawing.Point(39, 132);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 5;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(137, 132);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(245, 167);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkShowPageIndex);
			base.Controls.Add(cboDisplayLevel);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertDirectoryField";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "插入目录";
			base.Load += new System.EventHandler(dlgInsertDirectoryField_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgInsertDirectoryField()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertDirectoryField_Load(object sender, EventArgs e)
		{
			if (xtextDirectoryFieldElement_0 != null)
			{
				txtID.Text = xtextDirectoryFieldElement_0.ID;
				cboDisplayLevel.SelectedIndex = xtextDirectoryFieldElement_0.DisplayLevel - 1;
				chkShowPageIndex.Checked = xtextDirectoryFieldElement_0.ShowPageIndex;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (xtextDirectoryFieldElement_0 != null)
			{
				xtextDirectoryFieldElement_0.ID = txtID.Text;
				xtextDirectoryFieldElement_0.DisplayLevel = cboDisplayLevel.SelectedIndex + 1;
				xtextDirectoryFieldElement_0.ShowPageIndex = chkShowPageIndex.Checked;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

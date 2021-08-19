using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       删除单元格窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgPromptDeleteCell : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoDeleteRow;

		private RadioButton rdoDeleteColumn;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       是否删除行
		///       </summary>
		public bool DeleteRow
		{
			get
			{
				return rdoDeleteRow.Checked;
			}
			set
			{
				rdoDeleteRow.Checked = value;
			}
		}

		/// <summary>
		///       是否删除列
		///       </summary>
		public bool DeleteColumn
		{
			get
			{
				return rdoDeleteColumn.Checked;
			}
			set
			{
				rdoDeleteColumn.Checked = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgPromptDeleteCell));
			rdoDeleteRow = new System.Windows.Forms.RadioButton();
			rdoDeleteColumn = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(rdoDeleteRow, "rdoDeleteRow");
			rdoDeleteRow.Checked = true;
			rdoDeleteRow.Name = "rdoDeleteRow";
			rdoDeleteRow.TabStop = true;
			rdoDeleteRow.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoDeleteColumn, "rdoDeleteColumn");
			rdoDeleteColumn.Name = "rdoDeleteColumn";
			rdoDeleteColumn.UseVisualStyleBackColor = true;
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
			base.Controls.Add(rdoDeleteColumn);
			base.Controls.Add(rdoDeleteRow);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPromptDeleteCell";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       对象初始化
		///       </summary>
		public dlgPromptDeleteCell()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
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

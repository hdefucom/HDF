using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       页码对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgPageIndex : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown txtPageIndex;

		private Button btnOK;

		private Button btnCancel;

		public int InputPageIndex
		{
			get
			{
				return (int)txtPageIndex.Value;
			}
			set
			{
				txtPageIndex.Value = value;
			}
		}

		public int InputMaxPageIndex
		{
			get
			{
				return (int)txtPageIndex.Maximum;
			}
			set
			{
				txtPageIndex.Maximum = value;
			}
		}

		public int InputMinPageIndex
		{
			get
			{
				return (int)txtPageIndex.Minimum;
			}
			set
			{
				txtPageIndex.Minimum = value;
			}
		}

		public dlgPageIndex()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPageIndex_Load(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.dlgPageIndex));
			label1 = new System.Windows.Forms.Label();
			txtPageIndex = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)txtPageIndex).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtPageIndex, "txtPageIndex");
			txtPageIndex.Name = "txtPageIndex";
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
			base.Controls.Add(txtPageIndex);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPageIndex";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPageIndex_Load);
			((System.ComponentModel.ISupportInitialize)txtPageIndex).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

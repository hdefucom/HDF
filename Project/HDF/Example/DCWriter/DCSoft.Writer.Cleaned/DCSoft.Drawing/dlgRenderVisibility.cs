using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Drawing
{
	/// <summary>
	///       可见性设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgRenderVisibility : Form
	{
		private IContainer icontainer_0 = null;

		private CheckBox chkPrint;

		private CheckBox chkPDF;

		private Button btnOK;

		private Button btnCancel;

		public RenderVisibility VisiblityValue
		{
			get
			{
				RenderVisibility renderVisibility = RenderVisibility.Hidden;
				if (chkPrint.Checked)
				{
					renderVisibility |= RenderVisibility.Print;
				}
				if (chkPDF.Checked)
				{
					renderVisibility |= RenderVisibility.PDF;
				}
				return renderVisibility;
			}
			set
			{
				chkPrint.Checked = ((value & RenderVisibility.Print) == RenderVisibility.Print);
				chkPDF.Checked = ((value & RenderVisibility.PDF) == RenderVisibility.PDF);
			}
		}

		public dlgRenderVisibility()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgRenderVisibility_Load(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Drawing.dlgRenderVisibility));
			chkPrint = new System.Windows.Forms.CheckBox();
			chkPDF = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(chkPrint, "chkPrint");
			chkPrint.Name = "chkPrint";
			chkPrint.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkPDF, "chkPDF");
			chkPDF.Name = "chkPDF";
			chkPDF.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkPDF);
			base.Controls.Add(chkPrint);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgRenderVisibility";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgRenderVisibility_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

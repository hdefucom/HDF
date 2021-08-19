using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	[ComVisible(false)]
	public class dlgFetalHeart : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private TextBox txtValue6;

		private TextBox txtValue5;

		private TextBox txtValue4;

		private TextBox txtValue3;

		private TextBox txtValue2;

		private TextBox txtValue1;

		private Panel panel1;

		public string Value1
		{
			get
			{
				return txtValue1.Text;
			}
			set
			{
				txtValue1.Text = value;
			}
		}

		public string Value2
		{
			get
			{
				return txtValue2.Text;
			}
			set
			{
				txtValue2.Text = value;
			}
		}

		public string Value3
		{
			get
			{
				return txtValue3.Text;
			}
			set
			{
				txtValue3.Text = value;
			}
		}

		public string Value4
		{
			get
			{
				return txtValue4.Text;
			}
			set
			{
				txtValue4.Text = value;
			}
		}

		public string Value5
		{
			get
			{
				return txtValue5.Text;
			}
			set
			{
				txtValue5.Text = value;
			}
		}

		public string Value6
		{
			get
			{
				return txtValue6.Text;
			}
			set
			{
				txtValue6.Text = value;
			}
		}

		public dlgFetalHeart()
		{
			InitializeComponent();
			txtValue1.GotFocus += txtValue1_GotFocus;
		}

		private void txtValue1_GotFocus(object sender, EventArgs e)
		{
			txtValue1.SelectAll();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.Medical.dlgFetalHeart));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			txtValue6 = new System.Windows.Forms.TextBox();
			txtValue5 = new System.Windows.Forms.TextBox();
			txtValue4 = new System.Windows.Forms.TextBox();
			txtValue3 = new System.Windows.Forms.TextBox();
			txtValue2 = new System.Windows.Forms.TextBox();
			txtValue1 = new System.Windows.Forms.TextBox();
			panel1 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(txtValue6, "txtValue6");
			txtValue6.Name = "txtValue6";
			resources.ApplyResources(txtValue5, "txtValue5");
			txtValue5.Name = "txtValue5";
			resources.ApplyResources(txtValue4, "txtValue4");
			txtValue4.Name = "txtValue4";
			resources.ApplyResources(txtValue3, "txtValue3");
			txtValue3.Name = "txtValue3";
			resources.ApplyResources(txtValue2, "txtValue2");
			txtValue2.Name = "txtValue2";
			resources.ApplyResources(txtValue1, "txtValue1");
			txtValue1.Name = "txtValue1";
			resources.ApplyResources(panel1, "panel1");
			panel1.Controls.Add(txtValue2);
			panel1.Controls.Add(txtValue6);
			panel1.Controls.Add(txtValue1);
			panel1.Controls.Add(txtValue5);
			panel1.Controls.Add(txtValue3);
			panel1.Controls.Add(txtValue4);
			panel1.Name = "panel1";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(panel1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFetalHeart";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}

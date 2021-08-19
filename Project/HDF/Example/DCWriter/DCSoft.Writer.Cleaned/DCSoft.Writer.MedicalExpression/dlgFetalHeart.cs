using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
{
	[ComVisible(false)]
	public class dlgFetalHeart : Form
	{
		private MedicalExpressionValueList medicalExpressionValueList_0 = null;

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

		public MedicalExpressionValueList InputValues
		{
			get
			{
				return medicalExpressionValueList_0;
			}
			set
			{
				medicalExpressionValueList_0 = value;
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
			medicalExpressionValueList_0 = new MedicalExpressionValueList();
			medicalExpressionValueList_0.Value1 = txtValue1.Text;
			medicalExpressionValueList_0.Value2 = txtValue2.Text;
			medicalExpressionValueList_0.Value3 = txtValue3.Text;
			medicalExpressionValueList_0.Value4 = txtValue4.Text;
			medicalExpressionValueList_0.Value5 = txtValue5.Text;
			medicalExpressionValueList_0.Value6 = txtValue6.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgFetalHeart_Load(object sender, EventArgs e)
		{
			if (medicalExpressionValueList_0 != null)
			{
				txtValue1.Text = medicalExpressionValueList_0.Value1;
				txtValue2.Text = medicalExpressionValueList_0.Value2;
				txtValue3.Text = medicalExpressionValueList_0.Value3;
				txtValue4.Text = medicalExpressionValueList_0.Value4;
				txtValue5.Text = medicalExpressionValueList_0.Value5;
				txtValue6.Text = medicalExpressionValueList_0.Value6;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgFetalHeart));
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
			base.Load += new System.EventHandler(dlgFetalHeart_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}

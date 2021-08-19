using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
{
	[ComVisible(false)]
	public class dlgLightPosition : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtValue7;

		private TextBox txtValue6;

		private TextBox txtValue5;

		private TextBox txtValue4;

		private TextBox txtValue3;

		private TextBox txtValue2;

		private TextBox txtValue1;

		private Button btnCancel;

		private Button btnOK;

		private TextBox txtValue8;

		private TextBox txtValue9;

		private MedicalExpressionValueList medicalExpressionValueList_0 = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgLightPosition));
			txtValue7 = new System.Windows.Forms.TextBox();
			txtValue6 = new System.Windows.Forms.TextBox();
			txtValue5 = new System.Windows.Forms.TextBox();
			txtValue4 = new System.Windows.Forms.TextBox();
			txtValue3 = new System.Windows.Forms.TextBox();
			txtValue2 = new System.Windows.Forms.TextBox();
			txtValue1 = new System.Windows.Forms.TextBox();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			txtValue8 = new System.Windows.Forms.TextBox();
			txtValue9 = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(txtValue7, "txtValue7");
			txtValue7.Name = "txtValue7";
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
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(txtValue8, "txtValue8");
			txtValue8.Name = "txtValue8";
			resources.ApplyResources(txtValue9, "txtValue9");
			txtValue9.Name = "txtValue9";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(txtValue9);
			base.Controls.Add(txtValue8);
			base.Controls.Add(txtValue7);
			base.Controls.Add(txtValue6);
			base.Controls.Add(txtValue5);
			base.Controls.Add(txtValue4);
			base.Controls.Add(txtValue3);
			base.Controls.Add(txtValue2);
			base.Controls.Add(txtValue1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgLightPosition";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgLightPosition_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgLightPosition()
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
			medicalExpressionValueList_0.Value7 = txtValue7.Text;
			medicalExpressionValueList_0.Value8 = txtValue8.Text;
			medicalExpressionValueList_0.Value9 = txtValue9.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgLightPosition_Load(object sender, EventArgs e)
		{
			if (medicalExpressionValueList_0 != null)
			{
				txtValue1.Text = medicalExpressionValueList_0.Value1;
				txtValue2.Text = medicalExpressionValueList_0.Value2;
				txtValue3.Text = medicalExpressionValueList_0.Value3;
				txtValue4.Text = medicalExpressionValueList_0.Value4;
				txtValue5.Text = medicalExpressionValueList_0.Value5;
				txtValue6.Text = medicalExpressionValueList_0.Value6;
				txtValue7.Text = medicalExpressionValueList_0.Value7;
				txtValue8.Text = medicalExpressionValueList_0.Value8;
				txtValue9.Text = medicalExpressionValueList_0.Value9;
			}
		}
	}
}

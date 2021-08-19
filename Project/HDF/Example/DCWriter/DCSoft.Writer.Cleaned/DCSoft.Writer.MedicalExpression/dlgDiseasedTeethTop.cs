using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
{
	/// <summary>
	///       病牙上牙牙位图表达式
	///       </summary>
	[ComVisible(false)]
	public class dlgDiseasedTeethTop : Form
	{
		private MedicalExpressionValueList medicalExpressionValueList_0 = null;

		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

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

		public dlgDiseasedTeethTop()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			txtValue1.Tag = false;
			txtValue1.GotFocus += txtValue1_GotFocus;
			txtValue1.MouseDown += txtValue1_MouseDown;
			txtValue2.Tag = false;
			txtValue2.GotFocus += txtValue2_GotFocus;
			txtValue2.MouseDown += txtValue2_MouseDown;
			txtValue3.Tag = false;
			txtValue3.GotFocus += txtValue3_GotFocus;
			txtValue3.MouseDown += txtValue3_MouseDown;
		}

		private void txtValue1_GotFocus(object sender, EventArgs e)
		{
			txtValue1.Tag = true;
			txtValue1.SelectAll();
		}

		private void txtValue1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)txtValue1.Tag)
			{
				txtValue1.SelectAll();
			}
			txtValue1.Tag = false;
		}

		private void txtValue2_GotFocus(object sender, EventArgs e)
		{
			txtValue2.Tag = true;
			txtValue2.SelectAll();
		}

		private void txtValue2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)txtValue2.Tag)
			{
				txtValue2.SelectAll();
			}
			txtValue2.Tag = false;
		}

		private void txtValue3_GotFocus(object sender, EventArgs e)
		{
			txtValue3.Tag = true;
			txtValue3.SelectAll();
		}

		private void txtValue3_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)txtValue3.Tag)
			{
				txtValue3.SelectAll();
			}
			txtValue3.Tag = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			medicalExpressionValueList_0 = new MedicalExpressionValueList();
			medicalExpressionValueList_0.Value1 = txtValue1.Text;
			medicalExpressionValueList_0.Value2 = txtValue2.Text;
			medicalExpressionValueList_0.Value3 = txtValue3.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgDiseasedTeethTop_Load(object sender, EventArgs e)
		{
			if (medicalExpressionValueList_0 != null)
			{
				txtValue1.Text = medicalExpressionValueList_0.Value1;
				txtValue2.Text = medicalExpressionValueList_0.Value2;
				txtValue3.Text = medicalExpressionValueList_0.Value3;
			}
		}

		private void txtValue1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int keyChar = e.KeyChar;
			if (keyChar < 48 || keyChar > 57)
			{
				if (keyChar != 8)
				{
					e.Handled = true;
				}
			}
			else if (keyChar == 48)
			{
				TextBox textBox = (TextBox)sender;
				if (textBox.Text == "")
				{
					e.Handled = true;
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgDiseasedTeethTop));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
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
			resources.ApplyResources(txtValue3, "txtValue3");
			txtValue3.Name = "txtValue3";
			txtValue3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtValue1_KeyPress);
			resources.ApplyResources(txtValue2, "txtValue2");
			txtValue2.Name = "txtValue2";
			txtValue2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtValue1_KeyPress);
			resources.ApplyResources(txtValue1, "txtValue1");
			txtValue1.Name = "txtValue1";
			txtValue1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtValue1_KeyPress);
			resources.ApplyResources(panel1, "panel1");
			panel1.Controls.Add(txtValue1);
			panel1.Controls.Add(txtValue2);
			panel1.Controls.Add(txtValue3);
			panel1.Name = "panel1";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(panel1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDiseasedTeethTop";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgDiseasedTeethTop_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
{
	/// <summary>
	///       PD牙位图
	///       </summary>
	[ComVisible(false)]
	public class dlgPDTeech : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private Label label6;

		private Label label5;

		private Label label1;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private TextBox textBox4;

		private TextBox textBox5;

		private TextBox textBox6;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgPDTeech));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			textBox4 = new System.Windows.Forms.TextBox();
			textBox5 = new System.Windows.Forms.TextBox();
			textBox6 = new System.Windows.Forms.TextBox();
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
			label6.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			label1.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			textBox1.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox1.Name = "textBox1";
			textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox6_KeyPress);
			textBox2.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(textBox2, "textBox2");
			textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox2.Name = "textBox2";
			textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox6_KeyPress);
			textBox3.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(textBox3, "textBox3");
			textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox3.Name = "textBox3";
			textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox6_KeyPress);
			textBox4.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(textBox4, "textBox4");
			textBox4.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox4.Name = "textBox4";
			textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox6_KeyPress);
			textBox5.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(textBox5, "textBox5");
			textBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox5.Name = "textBox5";
			textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox6_KeyPress);
			textBox6.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(textBox6, "textBox6");
			textBox6.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox6.Name = "textBox6";
			textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox6_KeyPress);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(textBox6);
			base.Controls.Add(textBox5);
			base.Controls.Add(textBox4);
			base.Controls.Add(textBox3);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPDTeech";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPDTeech_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgPDTeech()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			medicalExpressionValueList_0 = new MedicalExpressionValueList();
			medicalExpressionValueList_0.Value1 = textBox1.Text;
			medicalExpressionValueList_0.Value2 = textBox2.Text;
			medicalExpressionValueList_0.Value3 = textBox3.Text;
			medicalExpressionValueList_0.Value4 = textBox4.Text;
			medicalExpressionValueList_0.Value5 = textBox5.Text;
			medicalExpressionValueList_0.Value6 = textBox6.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgPDTeech_Load(object sender, EventArgs e)
		{
			int num = 1;
			if (medicalExpressionValueList_0 != null)
			{
				textBox1.Text = medicalExpressionValueList_0.Value1;
				textBox2.Text = medicalExpressionValueList_0.Value2;
				textBox3.Text = medicalExpressionValueList_0.Value3;
				textBox4.Text = medicalExpressionValueList_0.Value4;
				textBox5.Text = medicalExpressionValueList_0.Value5;
				textBox6.Text = medicalExpressionValueList_0.Value6;
				if (medicalExpressionValueList_0.Value1 == "Value1" && medicalExpressionValueList_0.Value2 == "Value2" && medicalExpressionValueList_0.Value3 == "Value3" && medicalExpressionValueList_0.Value4 == "Value4" && medicalExpressionValueList_0.Value5 == "Value5" && medicalExpressionValueList_0.Value6 == "Value6")
				{
					textBox1.Text = "";
					textBox2.Text = "";
					textBox3.Text = "";
					textBox4.Text = "";
					textBox5.Text = "";
					textBox6.Text = "";
				}
			}
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
	}
}

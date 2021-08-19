using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       输入医学表达式数值
	///       </summary>
	[ComVisible(false)]
	public class dlgFourValues1 : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox textBox1;

		private Label label2;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox3;

		private Label label4;

		private TextBox textBox4;

		private Label label5;

		private Label label6;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       A值
		///       </summary>
		public string Value1
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
			}
		}

		/// <summary>
		///       B值
		///       </summary>
		public string Value2
		{
			get
			{
				return textBox2.Text;
			}
			set
			{
				textBox2.Text = value;
			}
		}

		/// <summary>
		///       C值
		///       </summary>
		public string Value3
		{
			get
			{
				return textBox3.Text;
			}
			set
			{
				textBox3.Text = value;
			}
		}

		/// <summary>
		///       D值
		///       </summary>
		public string Value4
		{
			get
			{
				return textBox4.Text;
			}
			set
			{
				textBox4.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgFourValues1()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			textBox1.Tag = false;
			textBox1.GotFocus += textBox1_GotFocus;
			textBox1.MouseDown += textBox1_MouseDown;
			textBox2.Tag = false;
			textBox2.GotFocus += textBox2_GotFocus;
			textBox2.MouseDown += textBox2_MouseDown;
			textBox3.Tag = false;
			textBox3.GotFocus += textBox3_GotFocus;
			textBox3.MouseDown += textBox3_MouseDown;
			textBox4.Tag = false;
			textBox4.GotFocus += textBox4_GotFocus;
			textBox4.MouseDown += textBox4_MouseDown;
		}

		private void textBox1_GotFocus(object sender, EventArgs e)
		{
			textBox1.Tag = true;
			textBox1.SelectAll();
		}

		private void textBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)textBox1.Tag)
			{
				textBox1.SelectAll();
			}
			textBox1.Tag = false;
		}

		private void textBox2_GotFocus(object sender, EventArgs e)
		{
			textBox2.Tag = true;
			textBox2.SelectAll();
		}

		private void textBox2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)textBox2.Tag)
			{
				textBox2.SelectAll();
			}
			textBox2.Tag = false;
		}

		private void textBox3_GotFocus(object sender, EventArgs e)
		{
			textBox3.Tag = true;
			textBox3.SelectAll();
		}

		private void textBox3_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)textBox3.Tag)
			{
				textBox3.SelectAll();
			}
			textBox3.Tag = false;
		}

		private void textBox4_GotFocus(object sender, EventArgs e)
		{
			textBox4.Tag = true;
			textBox4.SelectAll();
		}

		private void textBox4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (bool)textBox4.Tag)
			{
				textBox4.SelectAll();
			}
			textBox4.Tag = false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.Medical.dlgFourValues1));
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.Name = "textBox1";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(textBox2, "textBox2");
			textBox2.Name = "textBox2";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(textBox3, "textBox3");
			textBox3.Name = "textBox3";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(textBox4, "textBox4");
			textBox4.Name = "textBox4";
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			label6.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
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
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(textBox4);
			base.Controls.Add(label4);
			base.Controls.Add(textBox3);
			base.Controls.Add(label3);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFourValues1";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

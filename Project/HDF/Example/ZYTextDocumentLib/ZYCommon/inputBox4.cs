using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class inputBox4 : Form
	{
		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Button button1;

		private Button button2;

		private TextBox txttop;

		private TextBox txtbottom;

		private TextBox txtleft;

		private TextBox txtright;

		private Label label5;

		private TextBox txttop2;

		private TextBox txtbottom2;

		private Label label6;

		private Container components = null;

		public inputBox4()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		public static string[] InputBox4()
		{
			inputBox4 inputBox = new inputBox4();
			if (inputBox.ShowDialog() == DialogResult.OK)
			{
				if (inputBox.txtleft.Text == "" && inputBox.txttop.Text == "" && inputBox.txttop2.Text == "" && inputBox.txtbottom.Text == "" && inputBox.txtbottom2.Text == "" && inputBox.txtright.Text == "")
				{
					return null;
				}
				return new string[4]
				{
					inputBox.txttop.Text + "～" + inputBox.txttop2.Text,
					inputBox.txtbottom.Text + "～" + inputBox.txtbottom2.Text,
					inputBox.txtleft.Text,
					inputBox.txtright.Text
				};
			}
			return null;
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			txttop = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtbottom = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtleft = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtright = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			txttop2 = new System.Windows.Forms.TextBox();
			txtbottom2 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.Location = new System.Drawing.Point(80, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 16);
			label1.TabIndex = 0;
			label1.Text = "上标";
			txttop.Location = new System.Drawing.Point(112, 8);
			txttop.Name = "txttop";
			txttop.Size = new System.Drawing.Size(32, 21);
			txttop.TabIndex = 2;
			txttop.Text = "";
			txttop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txttop_KeyPress);
			label2.Location = new System.Drawing.Point(80, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 16);
			label2.TabIndex = 2;
			label2.Text = "下标";
			txtbottom.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtbottom.Location = new System.Drawing.Point(112, 40);
			txtbottom.Name = "txtbottom";
			txtbottom.Size = new System.Drawing.Size(32, 21);
			txtbottom.TabIndex = 4;
			txtbottom.Text = "";
			txtbottom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtbottom_KeyPress);
			label3.Location = new System.Drawing.Point(0, 32);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(24, 16);
			label3.TabIndex = 4;
			label3.Text = "左";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			txtleft.Location = new System.Drawing.Point(24, 28);
			txtleft.Name = "txtleft";
			txtleft.Size = new System.Drawing.Size(56, 21);
			txtleft.TabIndex = 1;
			txtleft.Text = "";
			txtleft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtleft_KeyPress);
			label4.Location = new System.Drawing.Point(208, 32);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(24, 16);
			label4.TabIndex = 6;
			label4.Text = "右";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			txtright.Location = new System.Drawing.Point(232, 28);
			txtright.Name = "txtright";
			txtright.Size = new System.Drawing.Size(56, 21);
			txtright.TabIndex = 6;
			txtright.Text = "";
			txtright.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtright_KeyPress);
			button1.Location = new System.Drawing.Point(176, 72);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(48, 23);
			button1.TabIndex = 8;
			button1.Text = "确认";
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(232, 72);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(48, 23);
			button2.TabIndex = 9;
			button2.Text = "取消";
			button2.Click += new System.EventHandler(button2_Click);
			txttop2.Location = new System.Drawing.Point(168, 8);
			txttop2.Name = "txttop2";
			txttop2.Size = new System.Drawing.Size(32, 21);
			txttop2.TabIndex = 3;
			txttop2.Text = "";
			txttop2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txttop2_KeyPress);
			txtbottom2.Location = new System.Drawing.Point(168, 40);
			txtbottom2.Name = "txtbottom2";
			txtbottom2.Size = new System.Drawing.Size(32, 21);
			txtbottom2.TabIndex = 5;
			txtbottom2.Text = "";
			txtbottom2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtbottom2_KeyPress);
			label5.Location = new System.Drawing.Point(144, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(24, 23);
			label5.TabIndex = 12;
			label5.Text = "～";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.Location = new System.Drawing.Point(144, 40);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(24, 23);
			label6.TabIndex = 13;
			label6.Text = "～";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(328, 101);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(txtbottom2);
			base.Controls.Add(txttop2);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(txtright);
			base.Controls.Add(label4);
			base.Controls.Add(txtleft);
			base.Controls.Add(label3);
			base.Controls.Add(txtbottom);
			base.Controls.Add(label2);
			base.Controls.Add(txttop);
			base.Controls.Add(label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "inputBox4";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "插入公式";
			ResumeLayout(false);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void txtleft_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				txttop.Focus();
			}
		}

		private void txttop_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				txttop2.Focus();
			}
		}

		private void txttop2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				txtbottom.Focus();
			}
		}

		private void txtbottom_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				txtbottom2.Focus();
			}
		}

		private void txtbottom2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				txtright.Focus();
			}
		}

		private void txtright_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}

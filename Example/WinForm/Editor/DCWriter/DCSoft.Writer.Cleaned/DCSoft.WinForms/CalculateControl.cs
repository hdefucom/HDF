using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class CalculateControl : UserControl
	{
		public const int int_0 = 0;

		public const int int_1 = 1;

		public const int int_2 = 2;

		public const int int_3 = 3;

		public const int int_4 = 4;

		public const int int_5 = 5;

		public const int int_6 = 6;

		public const int int_7 = 7;

		public const int int_8 = 0;

		public const int int_9 = 1;

		private double double_0 = 0.0;

		private double double_1 = 0.0;

		private int int_10 = 0;

		private int int_11 = 0;

		private int int_12 = 0;

		private int int_13 = 0;

		private string string_0;

		private double double_2;

		private string string_1;

		private int int_14 = 0;

		private IContainer icontainer_0 = null;

		private Button buttonBack;

		private Button btn_add;

		private Button btn_dot;

		private Button btn_sign;

		private Button btn_0;

		private Button button22;

		private Button btn_rev;

		private Button btn_sub;

		private Button btn_3;

		private Button btn_2;

		private Button btn_1;

		private Button button16;

		private Button button15;

		private Button btn_mul;

		private Button btn_6;

		private Button btn_5;

		private Button btn_4;

		private Button btn_equ;

		private Button button10;

		private Button btn_sqr;

		private Button btn_div;

		private Button btn_9;

		private Button btn_8;

		private Button btn_7;

		private Button button4;

		private Button button_0;

		private Button button_1;

		private Label lblText;

		protected TextBox txtShow;

		public double InputValue
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
			}
		}

		public CalculateControl()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				txtShow.Text = InputValue.ToString();
			}
		}

		private void btn_1_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_2_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_3_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_4_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_5_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_6_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_7_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_8_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_9_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void btn_0_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				method_2();
				if (int_11 == 0)
				{
					double num = double.Parse(button.Tag.ToString());
					double_1 = double_1 * 10.0 + num;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					int_13++;
					double num = double.Parse(button.Tag.ToString()) / Math.Pow(10.0, int_13);
					double_1 += num;
					txtShow.Text = double_1.ToString();
				}
			}
			int_14++;
		}

		private void method_0(Button button_2)
		{
			int num = 4;
			string_0 = button_2.Text;
			if (int_14 == 0 && !double.TryParse(txtShow.Text, out double_1))
			{
				return;
			}
			switch (string_0)
			{
			case "%":
				if (int_10 != 0 && int_10 != 3)
				{
					method_1();
				}
				int_10 = 7;
				if (int_12 != 0)
				{
					if (double_1 != 0.0)
					{
						double_0 *= double_1;
					}
				}
				else
				{
					double_0 = double_1;
				}
				int_12++;
				double_1 = 0.0;
				txtShow.Text = double_0.ToString();
				int_11 = 0;
				break;
			case "/":
				if (int_10 != 0 && int_10 != 4)
				{
					method_1();
				}
				int_10 = 4;
				if (int_12 != 0)
				{
					if (double_1 != 0.0)
					{
						double_0 /= double_1;
					}
				}
				else
				{
					double_0 = double_1;
				}
				int_12++;
				double_1 = 0.0;
				txtShow.Text = double_0.ToString();
				int_11 = 0;
				break;
			case "*":
				if (int_10 != 0 && int_10 != 3)
				{
					method_1();
				}
				int_10 = 3;
				if (int_12 != 0)
				{
					if (double_1 != 0.0)
					{
						double_0 *= double_1;
					}
				}
				else
				{
					double_0 = double_1;
				}
				int_12++;
				double_1 = 0.0;
				txtShow.Text = double_0.ToString();
				int_11 = 0;
				break;
			case "+":
				if (int_10 != 0 && int_10 != 1)
				{
					method_1();
				}
				int_10 = 1;
				if (int_12 != 0)
				{
					double_0 += double_1;
				}
				else
				{
					double_0 = double_1;
				}
				int_12++;
				double_1 = 0.0;
				txtShow.Text = double_0.ToString();
				int_11 = 0;
				break;
			case "-":
				if (int_10 != 0 && int_10 != 2)
				{
					method_1();
				}
				int_10 = 2;
				if (int_12 != 0)
				{
					double_0 -= double_1;
				}
				else
				{
					double_0 = double_1;
				}
				int_12++;
				double_1 = 0.0;
				txtShow.Text = double_0.ToString();
				int_11 = 0;
				break;
			case "sqrt":
				if (int_10 != 0)
				{
					method_1();
				}
				if (double_1 > 0.0)
				{
					double_0 = Math.Sqrt(double_1);
				}
				else if (double_0 > 0.0)
				{
					double_0 = Math.Sqrt(double_0);
				}
				txtShow.Text = double_0.ToString();
				int_12++;
				double_1 = 0.0;
				int_11 = 0;
				break;
			case "1/x":
				if (int_10 != 0)
				{
					method_1();
				}
				if (double_1 != 0.0)
				{
					double_0 = 1.0 / double_1;
				}
				else
				{
					double_0 = 1.0 / double_0;
				}
				txtShow.Text = double_0.ToString();
				double_1 = 0.0;
				int_11 = 0;
				break;
			case ".":
				if (int_11 != 1)
				{
					int_11 = 1;
					int_13 = 0;
				}
				break;
			case "+/-":
				if (double_1 != 0.0)
				{
					double_1 = 0.0 - double_1;
					txtShow.Text = double_1.ToString();
				}
				else
				{
					double_0 = 0.0 - double_0;
					txtShow.Text = double_0.ToString();
				}
				int_11 = 0;
				break;
			case "CE":
				double_0 = 0.0;
				double_1 = 0.0;
				int_10 = 0;
				int_11 = 0;
				int_12 = 0;
				int_13 = 0;
				txtShow.Text = "0";
				int_14 = 0;
				break;
			case "c":
				double_0 = 0.0;
				double_1 = 0.0;
				int_10 = 0;
				int_11 = 0;
				int_12 = 0;
				int_13 = 0;
				txtShow.Text = "0";
				int_14 = 0;
				break;
			}
		}

		private void btn_sign_Click(object sender, EventArgs e)
		{
			method_0(btn_sign);
		}

		private void btn_dot_Click(object sender, EventArgs e)
		{
			method_0(btn_dot);
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			method_0(btn_add);
		}

		private void btn_equ_Click(object sender, EventArgs e)
		{
			method_1();
		}

		private void method_1()
		{
			int num = 10;
			if (int_12 == 0)
			{
				double_0 = 0.0;
				double_1 = 0.0;
				txtShow.Text = double_0.ToString();
				return;
			}
			switch (int_10)
			{
			default:
				return;
			case 5:
				return;
			case 1:
				double_0 += double_1;
				break;
			case 2:
				double_0 -= double_1;
				break;
			case 3:
				double_0 *= double_1;
				break;
			case 4:
				double_0 /= double_1;
				break;
			case 6:
				double_0 = Math.Sqrt(double_1);
				break;
			case 7:
				double_0 %= double_1;
				break;
			}
			txtShow.Text = (double.IsInfinity(double_0) ? "10000" : double_0.ToString());
			int_10 = 0;
			double_1 = double_0;
			int_11 = 0;
			double_0 = 0.0;
			int_12 = 0;
			int_14 = 0;
		}

		private void btn_sub_Click(object sender, EventArgs e)
		{
			method_0(btn_sub);
		}

		private void btn_mul_Click(object sender, EventArgs e)
		{
			method_0(btn_mul);
		}

		private void btn_div_Click(object sender, EventArgs e)
		{
			method_0(btn_div);
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			method_0(button_1);
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			method_0(button_0);
		}

		private void btn_sqr_Click(object sender, EventArgs e)
		{
			method_0(btn_sqr);
		}

		private void button15_Click(object sender, EventArgs e)
		{
			method_0(button15);
		}

		private void btn_rev_Click(object sender, EventArgs e)
		{
			method_0(btn_rev);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			lblText.Text = "";
			double_2 = 0.0;
			double_1 = 0.0;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (double_2 != 0.0)
			{
				txtShow.Text = double_2.ToString();
			}
			double_1 = 0.0;
		}

		private void button16_Click(object sender, EventArgs e)
		{
			int num = 16;
			if (txtShow.Text != "0")
			{
				double_2 = double_1;
				lblText.Text = "M";
				double_1 = 0.0;
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			double_2 += double_1;
			txtShow.Text = double_2.ToString();
			double_1 = 0.0;
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			int num = 2;
			if (txtShow.Text.Length > 0)
			{
				string_1 = txtShow.Text;
				txtShow.Text = string_1.Substring(0, string_1.Length - 1);
				double_1 = 0.0;
			}
			if (txtShow.Text.Length == 0)
			{
				txtShow.Text = "0";
				double_1 = 0.0;
			}
		}

		private void method_2()
		{
			if (int_14 == 0 && int_10 == 0)
			{
				double_1 = 0.0;
			}
		}

		private void txtShow_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void txtShow_TextChanged(object sender, EventArgs e)
		{
			if (txtShow.Text != "" || txtShow.Text != string.Empty)
			{
				try
				{
					double_1 = Convert.ToDouble(txtShow.Text);
					txtShow.BackColor = SystemColors.Control;
				}
				catch (Exception)
				{
					txtShow.BackColor = Color.Red;
					txtShow.Focus();
					double_1 = 0.0;
				}
			}
		}

		private void txtShow_KeyDown(object sender, KeyEventArgs e)
		{
			if (!char.IsNumber((char)e.KeyValue) && e.KeyValue != 13 && e.KeyValue != 8 && (e.KeyCode != Keys.V || !e.Control))
			{
				e.SuppressKeyPress = true;
			}
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			buttonBack = new System.Windows.Forms.Button();
			btn_add = new System.Windows.Forms.Button();
			btn_dot = new System.Windows.Forms.Button();
			btn_sign = new System.Windows.Forms.Button();
			btn_0 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			btn_rev = new System.Windows.Forms.Button();
			btn_sub = new System.Windows.Forms.Button();
			btn_3 = new System.Windows.Forms.Button();
			btn_2 = new System.Windows.Forms.Button();
			btn_1 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			btn_mul = new System.Windows.Forms.Button();
			btn_6 = new System.Windows.Forms.Button();
			btn_5 = new System.Windows.Forms.Button();
			btn_4 = new System.Windows.Forms.Button();
			btn_equ = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			btn_sqr = new System.Windows.Forms.Button();
			btn_div = new System.Windows.Forms.Button();
			btn_9 = new System.Windows.Forms.Button();
			btn_8 = new System.Windows.Forms.Button();
			btn_7 = new System.Windows.Forms.Button();
			txtShow = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			button_0 = new System.Windows.Forms.Button();
			button_1 = new System.Windows.Forms.Button();
			lblText = new System.Windows.Forms.Label();
			SuspendLayout();
			buttonBack.ForeColor = System.Drawing.Color.Red;
			buttonBack.Location = new System.Drawing.Point(60, 37);
			buttonBack.Name = "buttonBack";
			buttonBack.Size = new System.Drawing.Size(78, 23);
			buttonBack.TabIndex = 87;
			buttonBack.Text = "退格";
			buttonBack.Click += new System.EventHandler(buttonBack_Click);
			btn_add.ForeColor = System.Drawing.Color.Red;
			btn_add.Location = new System.Drawing.Point(169, 160);
			btn_add.Name = "btn_add";
			btn_add.Size = new System.Drawing.Size(33, 23);
			btn_add.TabIndex = 84;
			btn_add.Text = "+";
			btn_add.Click += new System.EventHandler(btn_add_Click);
			btn_dot.ForeColor = System.Drawing.Color.Blue;
			btn_dot.Location = new System.Drawing.Point(133, 160);
			btn_dot.Name = "btn_dot";
			btn_dot.Size = new System.Drawing.Size(33, 23);
			btn_dot.TabIndex = 83;
			btn_dot.Text = ".";
			btn_dot.Click += new System.EventHandler(btn_dot_Click);
			btn_sign.ForeColor = System.Drawing.Color.Blue;
			btn_sign.Location = new System.Drawing.Point(97, 160);
			btn_sign.Name = "btn_sign";
			btn_sign.Size = new System.Drawing.Size(33, 23);
			btn_sign.TabIndex = 82;
			btn_sign.Text = "+/-";
			btn_sign.Click += new System.EventHandler(btn_sign_Click);
			btn_0.ForeColor = System.Drawing.Color.Blue;
			btn_0.Location = new System.Drawing.Point(58, 160);
			btn_0.Name = "btn_0";
			btn_0.Size = new System.Drawing.Size(33, 23);
			btn_0.TabIndex = 81;
			btn_0.Tag = "0";
			btn_0.Text = "0";
			btn_0.Click += new System.EventHandler(btn_0_Click);
			button22.ForeColor = System.Drawing.Color.Red;
			button22.Location = new System.Drawing.Point(12, 160);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(30, 23);
			button22.TabIndex = 80;
			button22.Text = "M+";
			button22.Click += new System.EventHandler(button22_Click);
			btn_rev.ForeColor = System.Drawing.Color.Blue;
			btn_rev.Location = new System.Drawing.Point(205, 128);
			btn_rev.Name = "btn_rev";
			btn_rev.Size = new System.Drawing.Size(39, 23);
			btn_rev.TabIndex = 79;
			btn_rev.Text = "1/x";
			btn_rev.Click += new System.EventHandler(btn_rev_Click);
			btn_sub.ForeColor = System.Drawing.Color.Red;
			btn_sub.Location = new System.Drawing.Point(169, 128);
			btn_sub.Name = "btn_sub";
			btn_sub.Size = new System.Drawing.Size(33, 23);
			btn_sub.TabIndex = 78;
			btn_sub.Text = "-";
			btn_sub.Click += new System.EventHandler(btn_sub_Click);
			btn_3.ForeColor = System.Drawing.Color.Blue;
			btn_3.Location = new System.Drawing.Point(133, 128);
			btn_3.Name = "btn_3";
			btn_3.Size = new System.Drawing.Size(33, 23);
			btn_3.TabIndex = 77;
			btn_3.Tag = "3";
			btn_3.Text = "3";
			btn_3.Click += new System.EventHandler(btn_3_Click);
			btn_2.ForeColor = System.Drawing.Color.Blue;
			btn_2.Location = new System.Drawing.Point(97, 128);
			btn_2.Name = "btn_2";
			btn_2.Size = new System.Drawing.Size(33, 23);
			btn_2.TabIndex = 76;
			btn_2.Tag = "2";
			btn_2.Text = "2";
			btn_2.Click += new System.EventHandler(btn_2_Click);
			btn_1.ForeColor = System.Drawing.Color.Blue;
			btn_1.Location = new System.Drawing.Point(58, 128);
			btn_1.Name = "btn_1";
			btn_1.Size = new System.Drawing.Size(33, 23);
			btn_1.TabIndex = 75;
			btn_1.Tag = "1";
			btn_1.Text = "1";
			btn_1.Click += new System.EventHandler(btn_1_Click);
			button16.ForeColor = System.Drawing.Color.Red;
			button16.Location = new System.Drawing.Point(12, 128);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(30, 23);
			button16.TabIndex = 74;
			button16.Text = "MS";
			button16.Click += new System.EventHandler(button16_Click);
			button15.ForeColor = System.Drawing.Color.Blue;
			button15.Location = new System.Drawing.Point(205, 96);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(39, 23);
			button15.TabIndex = 73;
			button15.Text = "%";
			button15.Click += new System.EventHandler(button15_Click);
			btn_mul.ForeColor = System.Drawing.Color.Red;
			btn_mul.Location = new System.Drawing.Point(169, 96);
			btn_mul.Name = "btn_mul";
			btn_mul.Size = new System.Drawing.Size(33, 23);
			btn_mul.TabIndex = 72;
			btn_mul.Text = "*";
			btn_mul.Click += new System.EventHandler(btn_mul_Click);
			btn_6.ForeColor = System.Drawing.Color.Blue;
			btn_6.Location = new System.Drawing.Point(133, 96);
			btn_6.Name = "btn_6";
			btn_6.Size = new System.Drawing.Size(33, 23);
			btn_6.TabIndex = 71;
			btn_6.Tag = "6";
			btn_6.Text = "6";
			btn_6.Click += new System.EventHandler(btn_6_Click);
			btn_5.ForeColor = System.Drawing.Color.Blue;
			btn_5.Location = new System.Drawing.Point(97, 96);
			btn_5.Name = "btn_5";
			btn_5.Size = new System.Drawing.Size(33, 23);
			btn_5.TabIndex = 70;
			btn_5.Tag = "5";
			btn_5.Text = "5";
			btn_5.Click += new System.EventHandler(btn_5_Click);
			btn_4.ForeColor = System.Drawing.Color.Blue;
			btn_4.Location = new System.Drawing.Point(58, 96);
			btn_4.Name = "btn_4";
			btn_4.Size = new System.Drawing.Size(33, 23);
			btn_4.TabIndex = 69;
			btn_4.Tag = "4";
			btn_4.Text = "4";
			btn_4.Click += new System.EventHandler(btn_4_Click);
			btn_equ.ForeColor = System.Drawing.Color.Red;
			btn_equ.Location = new System.Drawing.Point(205, 160);
			btn_equ.Name = "btn_equ";
			btn_equ.Size = new System.Drawing.Size(39, 23);
			btn_equ.TabIndex = 85;
			btn_equ.Text = "=";
			btn_equ.Click += new System.EventHandler(btn_equ_Click);
			button10.ForeColor = System.Drawing.Color.Red;
			button10.Location = new System.Drawing.Point(12, 96);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(30, 23);
			button10.TabIndex = 68;
			button10.Text = "MR";
			button10.Click += new System.EventHandler(button10_Click);
			btn_sqr.ForeColor = System.Drawing.Color.Red;
			btn_sqr.Location = new System.Drawing.Point(205, 64);
			btn_sqr.Name = "btn_sqr";
			btn_sqr.Size = new System.Drawing.Size(39, 23);
			btn_sqr.TabIndex = 67;
			btn_sqr.Text = "sqrt";
			btn_sqr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_sqr.Click += new System.EventHandler(btn_sqr_Click);
			btn_div.ForeColor = System.Drawing.Color.Red;
			btn_div.Location = new System.Drawing.Point(169, 64);
			btn_div.Name = "btn_div";
			btn_div.Size = new System.Drawing.Size(33, 23);
			btn_div.TabIndex = 66;
			btn_div.Text = "/";
			btn_div.Click += new System.EventHandler(btn_div_Click);
			btn_9.ForeColor = System.Drawing.Color.Blue;
			btn_9.Location = new System.Drawing.Point(133, 64);
			btn_9.Name = "btn_9";
			btn_9.Size = new System.Drawing.Size(33, 23);
			btn_9.TabIndex = 65;
			btn_9.Tag = "9";
			btn_9.Text = "9";
			btn_9.Click += new System.EventHandler(btn_9_Click);
			btn_8.ForeColor = System.Drawing.Color.Blue;
			btn_8.Location = new System.Drawing.Point(97, 64);
			btn_8.Name = "btn_8";
			btn_8.Size = new System.Drawing.Size(33, 23);
			btn_8.TabIndex = 64;
			btn_8.Tag = "8";
			btn_8.Text = "8";
			btn_8.Click += new System.EventHandler(btn_8_Click);
			btn_7.ForeColor = System.Drawing.Color.Blue;
			btn_7.Location = new System.Drawing.Point(58, 64);
			btn_7.Name = "btn_7";
			btn_7.Size = new System.Drawing.Size(33, 23);
			btn_7.TabIndex = 63;
			btn_7.Tag = "7";
			btn_7.Text = "7";
			btn_7.Click += new System.EventHandler(btn_7_Click);
			txtShow.BackColor = System.Drawing.SystemColors.Control;
			txtShow.Location = new System.Drawing.Point(4, 10);
			txtShow.Name = "txtShow";
			txtShow.Size = new System.Drawing.Size(240, 21);
			txtShow.TabIndex = 59;
			txtShow.Text = "0";
			txtShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txtShow.TextChanged += new System.EventHandler(txtShow_TextChanged);
			txtShow.KeyDown += new System.Windows.Forms.KeyEventHandler(txtShow_KeyDown);
			txtShow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtShow_KeyPress);
			button4.ForeColor = System.Drawing.Color.Red;
			button4.Location = new System.Drawing.Point(12, 64);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(30, 23);
			button4.TabIndex = 62;
			button4.Text = "MC";
			button4.Click += new System.EventHandler(button4_Click);
			button_0.ForeColor = System.Drawing.Color.Red;
			button_0.Location = new System.Drawing.Point(205, 37);
			button_0.Name = "c";
			button_0.Size = new System.Drawing.Size(39, 23);
			button_0.TabIndex = 61;
			button_0.Text = "c";
			button_0.Click += new System.EventHandler(button_0_Click);
			button_1.ForeColor = System.Drawing.Color.Red;
			button_1.Location = new System.Drawing.Point(145, 37);
			button_1.Name = "ce";
			button_1.Size = new System.Drawing.Size(57, 23);
			button_1.TabIndex = 60;
			button_1.Text = "CE";
			button_1.Click += new System.EventHandler(button_1_Click);
			lblText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lblText.Location = new System.Drawing.Point(12, 34);
			lblText.Name = "lblText";
			lblText.Size = new System.Drawing.Size(30, 23);
			lblText.TabIndex = 86;
			lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(buttonBack);
			base.Controls.Add(btn_add);
			base.Controls.Add(btn_dot);
			base.Controls.Add(btn_sign);
			base.Controls.Add(btn_0);
			base.Controls.Add(button22);
			base.Controls.Add(btn_rev);
			base.Controls.Add(btn_sub);
			base.Controls.Add(btn_3);
			base.Controls.Add(btn_2);
			base.Controls.Add(btn_1);
			base.Controls.Add(button16);
			base.Controls.Add(button15);
			base.Controls.Add(btn_mul);
			base.Controls.Add(btn_6);
			base.Controls.Add(btn_5);
			base.Controls.Add(btn_4);
			base.Controls.Add(btn_equ);
			base.Controls.Add(button10);
			base.Controls.Add(btn_sqr);
			base.Controls.Add(btn_div);
			base.Controls.Add(btn_9);
			base.Controls.Add(btn_8);
			base.Controls.Add(btn_7);
			base.Controls.Add(txtShow);
			base.Controls.Add(button4);
			base.Controls.Add(button_0);
			base.Controls.Add(button_1);
			base.Controls.Add(lblText);
			base.Name = "CalculateControl";
			base.Size = new System.Drawing.Size(253, 192);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
{
	/// <summary>
	///       乳牙牙位图表达式
	///       </summary>
	[ComVisible(false)]
	public class dlgDeciduousTeech : Form
	{
		private MedicalExpressionValueList medicalExpressionValueList_0 = null;

		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private RichTextBox richTextBox16;

		private RichTextBox richTextBox15;

		private RichTextBox richTextBox14;

		private RichTextBox richTextBox13;

		private RichTextBox richTextBox12;

		private RichTextBox richTextBox5;

		private RichTextBox richTextBox4;

		private RichTextBox richTextBox3;

		private RichTextBox richTextBox2;

		private RichTextBox richTextBox1;

		private Label label15;

		private Label label9;

		private Label label8;

		private Label label7;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label textBox17;

		private Label textBox18;

		private Label textBox19;

		private Label textBox20;

		private Label textBox9;

		private Label textBox10;

		private Label textBox11;

		private Label textBox12;

		private Label textBox13;

		private Label textBox14;

		private Label textBox15;

		private Label textBox16;

		private Label textBox8;

		private Label textBox7;

		private Label textBox6;

		private Label textBox5;

		private Label textBox4;

		private Label textBox3;

		private Label textBox2;

		private Label textBox1;

		private Label label1;

		private Label label5;

		private Label label6;

		private Label textBox1P;

		private Label textBox1L;

		private Label textBox1B;

		private Label textBox1D;

		private Label textBox1O;

		private Label textBox1M;

		private Label textBox11P;

		private Label textBox11L;

		private Label textBox11B;

		private Label textBox11D;

		private Label textBox11O;

		private Label textBox11M;

		private Label textBox12P;

		private Label textBox12L;

		private Label textBox12B;

		private Label textBox12D;

		private Label textBox12O;

		private Label textBox12M;

		private Label textBox13P;

		private Label textBox13L;

		private Label textBox13B;

		private Label textBox13D;

		private Label textBox13O;

		private Label textBox13M;

		private Label textBox14P;

		private Label textBox14L;

		private Label textBox14B;

		private Label textBox14D;

		private Label textBox14O;

		private Label textBox14M;

		private Label textBox15P;

		private Label textBox15L;

		private Label textBox15B;

		private Label textBox15D;

		private Label textBox15O;

		private Label textBox15M;

		private Label textBox16P;

		private Label textBox16L;

		private Label textBox16B;

		private Label textBox16D;

		private Label textBox16O;

		private Label textBox16M;

		private Label textBox17P;

		private Label textBox17L;

		private Label textBox17B;

		private Label textBox17D;

		private Label textBox17O;

		private Label textBox17M;

		private Label textBox18P;

		private Label textBox18L;

		private Label textBox18B;

		private Label textBox18D;

		private Label textBox18O;

		private Label textBox18M;

		private Label textBox19P;

		private Label textBox19L;

		private Label textBox19B;

		private Label textBox19D;

		private Label textBox19O;

		private Label textBox19M;

		private Label textBox20P;

		private Label textBox20L;

		private Label textBox20B;

		private Label textBox20D;

		private Label textBox20O;

		private Label textBox20M;

		private Label textBox2M;

		private Label textBox2O;

		private Label textBox2D;

		private Label textBox2B;

		private Label textBox2L;

		private Label textBox2P;

		private Label textBox3M;

		private Label textBox3O;

		private Label textBox3D;

		private Label textBox3B;

		private Label textBox3L;

		private Label textBox3P;

		private Label textBox4M;

		private Label textBox4O;

		private Label textBox4D;

		private Label textBox4B;

		private Label textBox4L;

		private Label textBox4P;

		private Label textBox5M;

		private Label textBox5O;

		private Label textBox5D;

		private Label textBox5B;

		private Label textBox5L;

		private Label textBox5P;

		private Label textBox6M;

		private Label textBox6O;

		private Label textBox6D;

		private Label textBox6B;

		private Label textBox6L;

		private Label textBox6P;

		private Label textBox7M;

		private Label textBox7O;

		private Label textBox7D;

		private Label textBox7B;

		private Label textBox7L;

		private Label textBox7P;

		private Label textBox8M;

		private Label textBox8O;

		private Label textBox8D;

		private Label textBox8B;

		private Label textBox8L;

		private Label textBox8P;

		private Label textBox9M;

		private Label textBox9O;

		private Label textBox9D;

		private Label textBox9B;

		private Label textBox9L;

		private Label textBox9P;

		private Label textBox10M;

		private Label textBox10O;

		private Label textBox10D;

		private Label textBox10B;

		private Label textBox10L;

		private Label textBox10P;

		private Label label10;

		private Label label11;

		private RichTextBox richTextBox6;

		private RichTextBox richTextBox7;

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
		///       初始化对象
		///       </summary>
		public dlgDeciduousTeech()
		{
			InitializeComponent();
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

		private void method_0(object sender, MouseEventArgs e)
		{
			int num = 18;
			Label label = (Label)sender;
			string name = label.Name;
			string text = name.Replace("textBox", "");
			bool flag = false;
			if (name.EndsWith("M") || name.EndsWith("O") || name.EndsWith("D") || name.EndsWith("B") || name.EndsWith("L") || name.EndsWith("P"))
			{
				text = text.Substring(0, text.Length - 1);
				flag = true;
			}
			if (e.Button == MouseButtons.Left && (label.BackColor == SystemColors.ControlLightLight || label.BackColor == SystemColors.GradientInactiveCaption))
			{
				if (flag && !method_5("textBox" + text.ToString()))
				{
					method_4("textBox" + text.ToString(), bool_0: true);
				}
				label.BackColor = SystemColors.Highlight;
				method_1(text, bool_0: true);
			}
			else if (e.Button == MouseButtons.Left && label.BackColor == SystemColors.Highlight)
			{
				label.BackColor = method_3(name);
				method_1(text, bool_0: false);
				if (!name.EndsWith("M") && !name.EndsWith("O") && !name.EndsWith("D") && !name.EndsWith("B") && !name.EndsWith("L") && !name.EndsWith("P"))
				{
					method_4(name + "M", bool_0: false);
					method_4(name + "O", bool_0: false);
					method_4(name + "D", bool_0: false);
					method_4(name + "B", bool_0: false);
					method_4(name + "L", bool_0: false);
					method_4(name + "P", bool_0: false);
				}
			}
		}

		private void method_1(string string_0, bool bool_0)
		{
			int num = 6;
			int int_ = int.Parse(string_0);
			string value = method_6(int_);
			if (bool_0)
			{
				medicalExpressionValueList_0.SetValue("Value" + int_, value);
			}
			else
			{
				medicalExpressionValueList_0.SetValue("Value" + int_, "");
			}
		}

		private void method_2()
		{
			int num = 14;
			for (int i = 1; i <= 20; i++)
			{
				string value = medicalExpressionValueList_0.GetValue("Value" + i);
				if (!string.IsNullOrEmpty(value))
				{
					char[] array = value.Substring(1).ToCharArray();
					method_4("textBox" + i, bool_0: true);
					for (int j = 0; j < array.Length; j++)
					{
						method_4("textBox" + i + array[j], bool_0: true);
					}
				}
			}
		}

		private Color method_3(string string_0)
		{
			int num = 0;
			string text = "";
			text = ((!string_0.EndsWith("M") && !string_0.EndsWith("O") && !string_0.EndsWith("D") && !string_0.EndsWith("B") && !string_0.EndsWith("L") && !string_0.EndsWith("P")) ? string_0 : string_0.Substring(0, string_0.Length - 1));
			text = text.Replace("textBox", "");
			int result = 0;
			if (int.TryParse(text, out result))
			{
				if (result > 5 && result < 11)
				{
					result--;
				}
				if (result > 15 && result < 21)
				{
					result--;
				}
				if (result % 2 == 0)
				{
					return SystemColors.GradientInactiveCaption;
				}
				return SystemColors.ControlLightLight;
			}
			return SystemColors.ControlLightLight;
		}

		private void method_4(string string_0, bool bool_0)
		{
			foreach (Control control in base.Controls)
			{
				if (control.Name == string_0)
				{
					if (bool_0)
					{
						control.BackColor = SystemColors.Highlight;
					}
					else
					{
						control.BackColor = method_3(control.Name);
					}
				}
			}
		}

		private bool method_5(string string_0)
		{
			foreach (Control control in base.Controls)
			{
				if (control.Name == string_0)
				{
					if (control.BackColor == SystemColors.Highlight)
					{
						return true;
					}
					return false;
				}
			}
			return false;
		}

		private string method_6(int int_0)
		{
			int num = 13;
			string text = string.Empty;
			int num2 = 0;
			if (int_0 > 0 && int_0 < 6)
			{
				num2 = 6 - int_0;
			}
			else if (int_0 > 5 && int_0 < 11)
			{
				num2 = int_0 - 5;
			}
			else if (int_0 > 10 && int_0 < 16)
			{
				num2 = 16 - int_0;
			}
			else if (int_0 > 15 && int_0 < 21)
			{
				num2 = int_0 - 15;
			}
			switch (num2)
			{
			case 1:
				text = "Ⅰ";
				break;
			case 2:
				text = "Ⅱ";
				break;
			case 3:
				text = "Ⅲ";
				break;
			case 4:
				text = "Ⅳ";
				break;
			case 5:
				text = "Ⅴ";
				break;
			}
			if (method_5("textBox" + int_0 + "M"))
			{
				text += "M";
			}
			if (method_5("textBox" + int_0 + "O"))
			{
				text += "O";
			}
			if (method_5("textBox" + int_0 + "D"))
			{
				text += "D";
			}
			if (method_5("textBox" + int_0 + "B"))
			{
				text += "B";
			}
			if (method_5("textBox" + int_0 + "L"))
			{
				text += "L";
			}
			if (method_5("textBox" + int_0 + "P"))
			{
				text += "P";
			}
			return text;
		}

		private void dlgDeciduousTeech_Load(object sender, EventArgs e)
		{
			method_7();
			method_2();
		}

		private void method_7()
		{
			int num = 17;
			foreach (Control control in base.Controls)
			{
				if (control is Label && control.Name.StartsWith("textBox"))
				{
					control.MouseClick += method_0;
					control.Cursor = Cursors.Arrow;
					Label label = (Label)control;
					label.TextAlign = ContentAlignment.MiddleCenter;
					label.BorderStyle = BorderStyle.FixedSingle;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgDeciduousTeech));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			richTextBox16 = new System.Windows.Forms.RichTextBox();
			richTextBox15 = new System.Windows.Forms.RichTextBox();
			richTextBox14 = new System.Windows.Forms.RichTextBox();
			richTextBox13 = new System.Windows.Forms.RichTextBox();
			richTextBox12 = new System.Windows.Forms.RichTextBox();
			richTextBox5 = new System.Windows.Forms.RichTextBox();
			richTextBox4 = new System.Windows.Forms.RichTextBox();
			richTextBox3 = new System.Windows.Forms.RichTextBox();
			richTextBox2 = new System.Windows.Forms.RichTextBox();
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			label15 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.Label();
			textBox18 = new System.Windows.Forms.Label();
			textBox19 = new System.Windows.Forms.Label();
			textBox20 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.Label();
			textBox11 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.Label();
			textBox13 = new System.Windows.Forms.Label();
			textBox14 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			textBox1P = new System.Windows.Forms.Label();
			textBox1L = new System.Windows.Forms.Label();
			textBox1B = new System.Windows.Forms.Label();
			textBox1D = new System.Windows.Forms.Label();
			textBox1O = new System.Windows.Forms.Label();
			textBox1M = new System.Windows.Forms.Label();
			textBox11P = new System.Windows.Forms.Label();
			textBox11L = new System.Windows.Forms.Label();
			textBox11B = new System.Windows.Forms.Label();
			textBox11D = new System.Windows.Forms.Label();
			textBox11O = new System.Windows.Forms.Label();
			textBox11M = new System.Windows.Forms.Label();
			textBox12P = new System.Windows.Forms.Label();
			textBox12L = new System.Windows.Forms.Label();
			textBox12B = new System.Windows.Forms.Label();
			textBox12D = new System.Windows.Forms.Label();
			textBox12O = new System.Windows.Forms.Label();
			textBox12M = new System.Windows.Forms.Label();
			textBox13P = new System.Windows.Forms.Label();
			textBox13L = new System.Windows.Forms.Label();
			textBox13B = new System.Windows.Forms.Label();
			textBox13D = new System.Windows.Forms.Label();
			textBox13O = new System.Windows.Forms.Label();
			textBox13M = new System.Windows.Forms.Label();
			textBox14P = new System.Windows.Forms.Label();
			textBox14L = new System.Windows.Forms.Label();
			textBox14B = new System.Windows.Forms.Label();
			textBox14D = new System.Windows.Forms.Label();
			textBox14O = new System.Windows.Forms.Label();
			textBox14M = new System.Windows.Forms.Label();
			textBox15P = new System.Windows.Forms.Label();
			textBox15L = new System.Windows.Forms.Label();
			textBox15B = new System.Windows.Forms.Label();
			textBox15D = new System.Windows.Forms.Label();
			textBox15O = new System.Windows.Forms.Label();
			textBox15M = new System.Windows.Forms.Label();
			textBox16P = new System.Windows.Forms.Label();
			textBox16L = new System.Windows.Forms.Label();
			textBox16B = new System.Windows.Forms.Label();
			textBox16D = new System.Windows.Forms.Label();
			textBox16O = new System.Windows.Forms.Label();
			textBox16M = new System.Windows.Forms.Label();
			textBox17P = new System.Windows.Forms.Label();
			textBox17L = new System.Windows.Forms.Label();
			textBox17B = new System.Windows.Forms.Label();
			textBox17D = new System.Windows.Forms.Label();
			textBox17O = new System.Windows.Forms.Label();
			textBox17M = new System.Windows.Forms.Label();
			textBox18P = new System.Windows.Forms.Label();
			textBox18L = new System.Windows.Forms.Label();
			textBox18B = new System.Windows.Forms.Label();
			textBox18D = new System.Windows.Forms.Label();
			textBox18O = new System.Windows.Forms.Label();
			textBox18M = new System.Windows.Forms.Label();
			textBox19P = new System.Windows.Forms.Label();
			textBox19L = new System.Windows.Forms.Label();
			textBox19B = new System.Windows.Forms.Label();
			textBox19D = new System.Windows.Forms.Label();
			textBox19O = new System.Windows.Forms.Label();
			textBox19M = new System.Windows.Forms.Label();
			textBox20P = new System.Windows.Forms.Label();
			textBox20L = new System.Windows.Forms.Label();
			textBox20B = new System.Windows.Forms.Label();
			textBox20D = new System.Windows.Forms.Label();
			textBox20O = new System.Windows.Forms.Label();
			textBox20M = new System.Windows.Forms.Label();
			textBox2M = new System.Windows.Forms.Label();
			textBox2O = new System.Windows.Forms.Label();
			textBox2D = new System.Windows.Forms.Label();
			textBox2B = new System.Windows.Forms.Label();
			textBox2L = new System.Windows.Forms.Label();
			textBox2P = new System.Windows.Forms.Label();
			textBox3M = new System.Windows.Forms.Label();
			textBox3O = new System.Windows.Forms.Label();
			textBox3D = new System.Windows.Forms.Label();
			textBox3B = new System.Windows.Forms.Label();
			textBox3L = new System.Windows.Forms.Label();
			textBox3P = new System.Windows.Forms.Label();
			textBox4M = new System.Windows.Forms.Label();
			textBox4O = new System.Windows.Forms.Label();
			textBox4D = new System.Windows.Forms.Label();
			textBox4B = new System.Windows.Forms.Label();
			textBox4L = new System.Windows.Forms.Label();
			textBox4P = new System.Windows.Forms.Label();
			textBox5M = new System.Windows.Forms.Label();
			textBox5O = new System.Windows.Forms.Label();
			textBox5D = new System.Windows.Forms.Label();
			textBox5B = new System.Windows.Forms.Label();
			textBox5L = new System.Windows.Forms.Label();
			textBox5P = new System.Windows.Forms.Label();
			textBox6M = new System.Windows.Forms.Label();
			textBox6O = new System.Windows.Forms.Label();
			textBox6D = new System.Windows.Forms.Label();
			textBox6B = new System.Windows.Forms.Label();
			textBox6L = new System.Windows.Forms.Label();
			textBox6P = new System.Windows.Forms.Label();
			textBox7M = new System.Windows.Forms.Label();
			textBox7O = new System.Windows.Forms.Label();
			textBox7D = new System.Windows.Forms.Label();
			textBox7B = new System.Windows.Forms.Label();
			textBox7L = new System.Windows.Forms.Label();
			textBox7P = new System.Windows.Forms.Label();
			textBox8M = new System.Windows.Forms.Label();
			textBox8O = new System.Windows.Forms.Label();
			textBox8D = new System.Windows.Forms.Label();
			textBox8B = new System.Windows.Forms.Label();
			textBox8L = new System.Windows.Forms.Label();
			textBox8P = new System.Windows.Forms.Label();
			textBox9M = new System.Windows.Forms.Label();
			textBox9O = new System.Windows.Forms.Label();
			textBox9D = new System.Windows.Forms.Label();
			textBox9B = new System.Windows.Forms.Label();
			textBox9L = new System.Windows.Forms.Label();
			textBox9P = new System.Windows.Forms.Label();
			textBox10M = new System.Windows.Forms.Label();
			textBox10O = new System.Windows.Forms.Label();
			textBox10D = new System.Windows.Forms.Label();
			textBox10B = new System.Windows.Forms.Label();
			textBox10L = new System.Windows.Forms.Label();
			textBox10P = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			richTextBox6 = new System.Windows.Forms.RichTextBox();
			richTextBox7 = new System.Windows.Forms.RichTextBox();
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
			richTextBox16.BackColor = System.Drawing.SystemColors.Control;
			richTextBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox16.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox16, "richTextBox16");
			richTextBox16.Name = "richTextBox16";
			richTextBox16.ReadOnly = true;
			richTextBox15.BackColor = System.Drawing.SystemColors.Control;
			richTextBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox15.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox15, "richTextBox15");
			richTextBox15.Name = "richTextBox15";
			richTextBox15.ReadOnly = true;
			richTextBox14.BackColor = System.Drawing.SystemColors.Control;
			richTextBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox14.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox14, "richTextBox14");
			richTextBox14.Name = "richTextBox14";
			richTextBox14.ReadOnly = true;
			richTextBox13.BackColor = System.Drawing.SystemColors.Control;
			richTextBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox13.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox13, "richTextBox13");
			richTextBox13.Name = "richTextBox13";
			richTextBox13.ReadOnly = true;
			richTextBox12.BackColor = System.Drawing.SystemColors.Control;
			richTextBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox12.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox12, "richTextBox12");
			richTextBox12.Name = "richTextBox12";
			richTextBox12.ReadOnly = true;
			richTextBox5.BackColor = System.Drawing.SystemColors.Control;
			richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox5, "richTextBox5");
			richTextBox5.Name = "richTextBox5";
			richTextBox5.ReadOnly = true;
			richTextBox4.BackColor = System.Drawing.SystemColors.Control;
			richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox4.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox4, "richTextBox4");
			richTextBox4.Name = "richTextBox4";
			richTextBox4.ReadOnly = true;
			richTextBox3.BackColor = System.Drawing.SystemColors.Control;
			richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox3, "richTextBox3");
			richTextBox3.Name = "richTextBox3";
			richTextBox3.ReadOnly = true;
			richTextBox2.BackColor = System.Drawing.SystemColors.Control;
			richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox2, "richTextBox2");
			richTextBox2.Name = "richTextBox2";
			richTextBox2.ReadOnly = true;
			richTextBox1.BackColor = System.Drawing.SystemColors.Control;
			richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox1, "richTextBox1");
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			resources.ApplyResources(label15, "label15");
			label15.Name = "label15";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			label7.BackColor = System.Drawing.Color.LightGray;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			label4.BackColor = System.Drawing.Color.LightGray;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			label3.BackColor = System.Drawing.Color.LightGray;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			label2.BackColor = System.Drawing.Color.LightGray;
			label2.ForeColor = System.Drawing.SystemColors.ControlLight;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			textBox17.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17, "textBox17");
			textBox17.Name = "textBox17";
			textBox18.BackColor = System.Drawing.SystemColors.ControlLightLight;
			resources.ApplyResources(textBox18, "textBox18");
			textBox18.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox18.Name = "textBox18";
			textBox19.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19, "textBox19");
			textBox19.Name = "textBox19";
			textBox20.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20, "textBox20");
			textBox20.Name = "textBox20";
			textBox9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9, "textBox9");
			textBox9.Name = "textBox9";
			textBox10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10, "textBox10");
			textBox10.Name = "textBox10";
			textBox11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11, "textBox11");
			textBox11.Name = "textBox11";
			textBox12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12, "textBox12");
			textBox12.Name = "textBox12";
			textBox13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			resources.ApplyResources(textBox13, "textBox13");
			textBox13.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox13.Name = "textBox13";
			textBox14.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14, "textBox14");
			textBox14.Name = "textBox14";
			textBox15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15, "textBox15");
			textBox15.Name = "textBox15";
			textBox16.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16, "textBox16");
			textBox16.Name = "textBox16";
			textBox8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			resources.ApplyResources(textBox8, "textBox8");
			textBox8.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox8.Name = "textBox8";
			textBox7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7, "textBox7");
			textBox7.Name = "textBox7";
			textBox6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6, "textBox6");
			textBox6.Name = "textBox6";
			textBox5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5, "textBox5");
			textBox5.Name = "textBox5";
			textBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4, "textBox4");
			textBox4.Name = "textBox4";
			textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			resources.ApplyResources(textBox3, "textBox3");
			textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			textBox3.Name = "textBox3";
			textBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2, "textBox2");
			textBox2.Name = "textBox2";
			textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.Name = "textBox1";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			label6.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			textBox1P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1P, "textBox1P");
			textBox1P.Name = "textBox1P";
			textBox1L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1L, "textBox1L");
			textBox1L.Name = "textBox1L";
			textBox1B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1B, "textBox1B");
			textBox1B.Name = "textBox1B";
			textBox1D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1D, "textBox1D");
			textBox1D.Name = "textBox1D";
			textBox1O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1O, "textBox1O");
			textBox1O.Name = "textBox1O";
			textBox1M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1M, "textBox1M");
			textBox1M.Name = "textBox1M";
			textBox11P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11P, "textBox11P");
			textBox11P.Name = "textBox11P";
			textBox11L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11L, "textBox11L");
			textBox11L.Name = "textBox11L";
			textBox11B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11B, "textBox11B");
			textBox11B.Name = "textBox11B";
			textBox11D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11D, "textBox11D");
			textBox11D.Name = "textBox11D";
			textBox11O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11O, "textBox11O");
			textBox11O.Name = "textBox11O";
			textBox11M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox11M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11M, "textBox11M");
			textBox11M.Name = "textBox11M";
			textBox12P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12P, "textBox12P");
			textBox12P.Name = "textBox12P";
			textBox12L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12L, "textBox12L");
			textBox12L.Name = "textBox12L";
			textBox12B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12B, "textBox12B");
			textBox12B.Name = "textBox12B";
			textBox12D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12D, "textBox12D");
			textBox12D.Name = "textBox12D";
			textBox12O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12O, "textBox12O");
			textBox12O.Name = "textBox12O";
			textBox12M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox12M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12M, "textBox12M");
			textBox12M.Name = "textBox12M";
			textBox13P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox13P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13P, "textBox13P");
			textBox13P.Name = "textBox13P";
			textBox13L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox13L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13L, "textBox13L");
			textBox13L.Name = "textBox13L";
			textBox13B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox13B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13B, "textBox13B");
			textBox13B.Name = "textBox13B";
			textBox13D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox13D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13D, "textBox13D");
			textBox13D.Name = "textBox13D";
			textBox13O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox13O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13O, "textBox13O");
			textBox13O.Name = "textBox13O";
			textBox13M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox13M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13M, "textBox13M");
			textBox13M.Name = "textBox13M";
			textBox14P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14P, "textBox14P");
			textBox14P.Name = "textBox14P";
			textBox14L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14L, "textBox14L");
			textBox14L.Name = "textBox14L";
			textBox14B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14B, "textBox14B");
			textBox14B.Name = "textBox14B";
			textBox14D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14D, "textBox14D");
			textBox14D.Name = "textBox14D";
			textBox14O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14O, "textBox14O");
			textBox14O.Name = "textBox14O";
			textBox14M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox14M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14M, "textBox14M");
			textBox14M.Name = "textBox14M";
			textBox15P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15P, "textBox15P");
			textBox15P.Name = "textBox15P";
			textBox15L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15L, "textBox15L");
			textBox15L.Name = "textBox15L";
			textBox15B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15B, "textBox15B");
			textBox15B.Name = "textBox15B";
			textBox15D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15D, "textBox15D");
			textBox15D.Name = "textBox15D";
			textBox15O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15O, "textBox15O");
			textBox15O.Name = "textBox15O";
			textBox15M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox15M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15M, "textBox15M");
			textBox15M.Name = "textBox15M";
			textBox16P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16P, "textBox16P");
			textBox16P.Name = "textBox16P";
			textBox16L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16L, "textBox16L");
			textBox16L.Name = "textBox16L";
			textBox16B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16B, "textBox16B");
			textBox16B.Name = "textBox16B";
			textBox16D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16D, "textBox16D");
			textBox16D.Name = "textBox16D";
			textBox16O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16O, "textBox16O");
			textBox16O.Name = "textBox16O";
			textBox16M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox16M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16M, "textBox16M");
			textBox16M.Name = "textBox16M";
			textBox17P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17P, "textBox17P");
			textBox17P.Name = "textBox17P";
			textBox17L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17L, "textBox17L");
			textBox17L.Name = "textBox17L";
			textBox17B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17B, "textBox17B");
			textBox17B.Name = "textBox17B";
			textBox17D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17D, "textBox17D");
			textBox17D.Name = "textBox17D";
			textBox17O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17O, "textBox17O");
			textBox17O.Name = "textBox17O";
			textBox17M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox17M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17M, "textBox17M");
			textBox17M.Name = "textBox17M";
			textBox18P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox18P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18P, "textBox18P");
			textBox18P.Name = "textBox18P";
			textBox18L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox18L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18L, "textBox18L");
			textBox18L.Name = "textBox18L";
			textBox18B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox18B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18B, "textBox18B");
			textBox18B.Name = "textBox18B";
			textBox18D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox18D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18D, "textBox18D");
			textBox18D.Name = "textBox18D";
			textBox18O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox18O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18O, "textBox18O");
			textBox18O.Name = "textBox18O";
			textBox18M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox18M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18M, "textBox18M");
			textBox18M.Name = "textBox18M";
			textBox19P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19P, "textBox19P");
			textBox19P.Name = "textBox19P";
			textBox19L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19L, "textBox19L");
			textBox19L.Name = "textBox19L";
			textBox19B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19B, "textBox19B");
			textBox19B.Name = "textBox19B";
			textBox19D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19D, "textBox19D");
			textBox19D.Name = "textBox19D";
			textBox19O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19O, "textBox19O");
			textBox19O.Name = "textBox19O";
			textBox19M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox19M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19M, "textBox19M");
			textBox19M.Name = "textBox19M";
			textBox20P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20P, "textBox20P");
			textBox20P.Name = "textBox20P";
			textBox20L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20L, "textBox20L");
			textBox20L.Name = "textBox20L";
			textBox20B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20B, "textBox20B");
			textBox20B.Name = "textBox20B";
			textBox20D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20D, "textBox20D");
			textBox20D.Name = "textBox20D";
			textBox20O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20O, "textBox20O");
			textBox20O.Name = "textBox20O";
			textBox20M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox20M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20M, "textBox20M");
			textBox20M.Name = "textBox20M";
			textBox2M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2M, "textBox2M");
			textBox2M.Name = "textBox2M";
			textBox2O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2O, "textBox2O");
			textBox2O.Name = "textBox2O";
			textBox2D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2D, "textBox2D");
			textBox2D.Name = "textBox2D";
			textBox2B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2B, "textBox2B");
			textBox2B.Name = "textBox2B";
			textBox2L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2L, "textBox2L");
			textBox2L.Name = "textBox2L";
			textBox2P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox2P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2P, "textBox2P");
			textBox2P.Name = "textBox2P";
			textBox3M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3M, "textBox3M");
			textBox3M.Name = "textBox3M";
			textBox3O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3O, "textBox3O");
			textBox3O.Name = "textBox3O";
			textBox3D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3D, "textBox3D");
			textBox3D.Name = "textBox3D";
			textBox3B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3B, "textBox3B");
			textBox3B.Name = "textBox3B";
			textBox3L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3L, "textBox3L");
			textBox3L.Name = "textBox3L";
			textBox3P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3P, "textBox3P");
			textBox3P.Name = "textBox3P";
			textBox4M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4M, "textBox4M");
			textBox4M.Name = "textBox4M";
			textBox4O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4O, "textBox4O");
			textBox4O.Name = "textBox4O";
			textBox4D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4D, "textBox4D");
			textBox4D.Name = "textBox4D";
			textBox4B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4B, "textBox4B");
			textBox4B.Name = "textBox4B";
			textBox4L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4L, "textBox4L");
			textBox4L.Name = "textBox4L";
			textBox4P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox4P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4P, "textBox4P");
			textBox4P.Name = "textBox4P";
			textBox5M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5M, "textBox5M");
			textBox5M.Name = "textBox5M";
			textBox5O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5O, "textBox5O");
			textBox5O.Name = "textBox5O";
			textBox5D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5D, "textBox5D");
			textBox5D.Name = "textBox5D";
			textBox5B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5B, "textBox5B");
			textBox5B.Name = "textBox5B";
			textBox5L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5L, "textBox5L");
			textBox5L.Name = "textBox5L";
			textBox5P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5P, "textBox5P");
			textBox5P.Name = "textBox5P";
			textBox6M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6M, "textBox6M");
			textBox6M.Name = "textBox6M";
			textBox6O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6O, "textBox6O");
			textBox6O.Name = "textBox6O";
			textBox6D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6D, "textBox6D");
			textBox6D.Name = "textBox6D";
			textBox6B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6B, "textBox6B");
			textBox6B.Name = "textBox6B";
			textBox6L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6L, "textBox6L");
			textBox6L.Name = "textBox6L";
			textBox6P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6P, "textBox6P");
			textBox6P.Name = "textBox6P";
			textBox7M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7M, "textBox7M");
			textBox7M.Name = "textBox7M";
			textBox7O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7O, "textBox7O");
			textBox7O.Name = "textBox7O";
			textBox7D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7D, "textBox7D");
			textBox7D.Name = "textBox7D";
			textBox7B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7B, "textBox7B");
			textBox7B.Name = "textBox7B";
			textBox7L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7L, "textBox7L");
			textBox7L.Name = "textBox7L";
			textBox7P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox7P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7P, "textBox7P");
			textBox7P.Name = "textBox7P";
			textBox8M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8M, "textBox8M");
			textBox8M.Name = "textBox8M";
			textBox8O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8O, "textBox8O");
			textBox8O.Name = "textBox8O";
			textBox8D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8D, "textBox8D");
			textBox8D.Name = "textBox8D";
			textBox8B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8B, "textBox8B");
			textBox8B.Name = "textBox8B";
			textBox8L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8L, "textBox8L");
			textBox8L.Name = "textBox8L";
			textBox8P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8P, "textBox8P");
			textBox8P.Name = "textBox8P";
			textBox9M.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9M, "textBox9M");
			textBox9M.Name = "textBox9M";
			textBox9O.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9O, "textBox9O");
			textBox9O.Name = "textBox9O";
			textBox9D.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9D, "textBox9D");
			textBox9D.Name = "textBox9D";
			textBox9B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9B, "textBox9B");
			textBox9B.Name = "textBox9B";
			textBox9L.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9L, "textBox9L");
			textBox9L.Name = "textBox9L";
			textBox9P.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			textBox9P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9P, "textBox9P");
			textBox9P.Name = "textBox9P";
			textBox10M.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10M.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10M, "textBox10M");
			textBox10M.Name = "textBox10M";
			textBox10O.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10O.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10O, "textBox10O");
			textBox10O.Name = "textBox10O";
			textBox10D.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10D.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10D, "textBox10D");
			textBox10D.Name = "textBox10D";
			textBox10B.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10B.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10B, "textBox10B");
			textBox10B.Name = "textBox10B";
			textBox10L.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10L.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10L, "textBox10L");
			textBox10L.Name = "textBox10L";
			textBox10P.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox10P.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10P, "textBox10P");
			textBox10P.Name = "textBox10P";
			label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			richTextBox6.BackColor = System.Drawing.SystemColors.Control;
			richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox6.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox6, "richTextBox6");
			richTextBox6.Name = "richTextBox6";
			richTextBox6.ReadOnly = true;
			richTextBox7.BackColor = System.Drawing.SystemColors.Control;
			richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox7.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(richTextBox7, "richTextBox7");
			richTextBox7.Name = "richTextBox7";
			richTextBox7.ReadOnly = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(richTextBox7);
			base.Controls.Add(richTextBox6);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(textBox10M);
			base.Controls.Add(textBox10O);
			base.Controls.Add(textBox10D);
			base.Controls.Add(textBox10B);
			base.Controls.Add(textBox10L);
			base.Controls.Add(textBox10P);
			base.Controls.Add(textBox9M);
			base.Controls.Add(textBox9O);
			base.Controls.Add(textBox9D);
			base.Controls.Add(textBox9B);
			base.Controls.Add(textBox9L);
			base.Controls.Add(textBox9P);
			base.Controls.Add(textBox8M);
			base.Controls.Add(textBox8O);
			base.Controls.Add(textBox8D);
			base.Controls.Add(textBox8B);
			base.Controls.Add(textBox8L);
			base.Controls.Add(textBox8P);
			base.Controls.Add(textBox7M);
			base.Controls.Add(textBox7O);
			base.Controls.Add(textBox7D);
			base.Controls.Add(textBox7B);
			base.Controls.Add(textBox7L);
			base.Controls.Add(textBox7P);
			base.Controls.Add(textBox6M);
			base.Controls.Add(textBox6O);
			base.Controls.Add(textBox6D);
			base.Controls.Add(textBox6B);
			base.Controls.Add(textBox6L);
			base.Controls.Add(textBox6P);
			base.Controls.Add(textBox5M);
			base.Controls.Add(textBox5O);
			base.Controls.Add(textBox5D);
			base.Controls.Add(textBox5B);
			base.Controls.Add(textBox5L);
			base.Controls.Add(textBox5P);
			base.Controls.Add(textBox4M);
			base.Controls.Add(textBox4O);
			base.Controls.Add(textBox4D);
			base.Controls.Add(textBox4B);
			base.Controls.Add(textBox4L);
			base.Controls.Add(textBox4P);
			base.Controls.Add(textBox3M);
			base.Controls.Add(textBox3O);
			base.Controls.Add(textBox3D);
			base.Controls.Add(textBox3B);
			base.Controls.Add(textBox3L);
			base.Controls.Add(textBox3P);
			base.Controls.Add(textBox2M);
			base.Controls.Add(textBox2O);
			base.Controls.Add(textBox2D);
			base.Controls.Add(textBox2B);
			base.Controls.Add(textBox2L);
			base.Controls.Add(textBox2P);
			base.Controls.Add(textBox20P);
			base.Controls.Add(textBox20L);
			base.Controls.Add(textBox20B);
			base.Controls.Add(textBox20D);
			base.Controls.Add(textBox20O);
			base.Controls.Add(textBox20M);
			base.Controls.Add(textBox19P);
			base.Controls.Add(textBox19L);
			base.Controls.Add(textBox19B);
			base.Controls.Add(textBox19D);
			base.Controls.Add(textBox19O);
			base.Controls.Add(textBox19M);
			base.Controls.Add(textBox18P);
			base.Controls.Add(textBox18L);
			base.Controls.Add(textBox18B);
			base.Controls.Add(textBox18D);
			base.Controls.Add(textBox18O);
			base.Controls.Add(textBox18M);
			base.Controls.Add(textBox17P);
			base.Controls.Add(textBox17L);
			base.Controls.Add(textBox17B);
			base.Controls.Add(textBox17D);
			base.Controls.Add(textBox17O);
			base.Controls.Add(textBox17M);
			base.Controls.Add(textBox16P);
			base.Controls.Add(textBox16L);
			base.Controls.Add(textBox16B);
			base.Controls.Add(textBox16D);
			base.Controls.Add(textBox16O);
			base.Controls.Add(textBox16M);
			base.Controls.Add(textBox15P);
			base.Controls.Add(textBox15L);
			base.Controls.Add(textBox15B);
			base.Controls.Add(textBox15D);
			base.Controls.Add(textBox15O);
			base.Controls.Add(textBox15M);
			base.Controls.Add(textBox14P);
			base.Controls.Add(textBox14L);
			base.Controls.Add(textBox14B);
			base.Controls.Add(textBox14D);
			base.Controls.Add(textBox14O);
			base.Controls.Add(textBox14M);
			base.Controls.Add(textBox13P);
			base.Controls.Add(textBox13L);
			base.Controls.Add(textBox13B);
			base.Controls.Add(textBox13D);
			base.Controls.Add(textBox13O);
			base.Controls.Add(textBox13M);
			base.Controls.Add(textBox12P);
			base.Controls.Add(textBox12L);
			base.Controls.Add(textBox12B);
			base.Controls.Add(textBox12D);
			base.Controls.Add(textBox12O);
			base.Controls.Add(textBox12M);
			base.Controls.Add(textBox11P);
			base.Controls.Add(textBox11L);
			base.Controls.Add(textBox11B);
			base.Controls.Add(textBox11D);
			base.Controls.Add(textBox11O);
			base.Controls.Add(textBox11M);
			base.Controls.Add(textBox1M);
			base.Controls.Add(textBox1O);
			base.Controls.Add(textBox1D);
			base.Controls.Add(textBox1B);
			base.Controls.Add(textBox1L);
			base.Controls.Add(textBox1P);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(richTextBox16);
			base.Controls.Add(richTextBox15);
			base.Controls.Add(richTextBox14);
			base.Controls.Add(richTextBox13);
			base.Controls.Add(richTextBox12);
			base.Controls.Add(richTextBox5);
			base.Controls.Add(richTextBox4);
			base.Controls.Add(richTextBox3);
			base.Controls.Add(richTextBox2);
			base.Controls.Add(richTextBox1);
			base.Controls.Add(label15);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(textBox17);
			base.Controls.Add(textBox18);
			base.Controls.Add(textBox19);
			base.Controls.Add(textBox20);
			base.Controls.Add(textBox9);
			base.Controls.Add(textBox10);
			base.Controls.Add(textBox11);
			base.Controls.Add(textBox12);
			base.Controls.Add(textBox13);
			base.Controls.Add(textBox14);
			base.Controls.Add(textBox15);
			base.Controls.Add(textBox16);
			base.Controls.Add(textBox8);
			base.Controls.Add(textBox7);
			base.Controls.Add(textBox6);
			base.Controls.Add(textBox5);
			base.Controls.Add(textBox4);
			base.Controls.Add(textBox3);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(label5);
			base.Controls.Add(label6);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDeciduousTeech";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgDeciduousTeech_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

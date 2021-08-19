using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       乳牙牙位图表达式
	///       </summary>
	[ComVisible(false)]
	public class dlgDeciduousTeech : Form
	{
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

		private TextBox textBox17;

		private TextBox textBox18;

		private TextBox textBox19;

		private TextBox textBox20;

		private TextBox textBox9;

		private TextBox textBox10;

		private TextBox textBox11;

		private TextBox textBox12;

		private TextBox textBox13;

		private TextBox textBox14;

		private TextBox textBox15;

		private TextBox textBox16;

		private TextBox textBox8;

		private TextBox textBox7;

		private TextBox textBox6;

		private TextBox textBox5;

		private TextBox textBox4;

		private TextBox textBox3;

		private TextBox textBox2;

		private TextBox textBox1;

		private Label label1;

		private Label label5;

		private Label label6;

		/// <summary>
		///       第三磨牙
		///       </summary>
		public object RightTopValue1
		{
			get
			{
				return textBox1.Tag;
			}
			set
			{
				int num = 5;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "V")
					{
						textBox1.Tag = value;
						textBox1.BackColor = SystemColors.Control;
					}
					else
					{
						textBox1.Tag = value;
						textBox1.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox1.Tag = value;
					textBox1.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第二磨牙
		///       </summary>
		public object RightTopValue2
		{
			get
			{
				return textBox2.Tag;
			}
			set
			{
				int num = 7;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "IV")
					{
						textBox2.Tag = value;
						textBox2.BackColor = SystemColors.Control;
					}
					else
					{
						textBox2.Tag = value;
						textBox2.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox2.Tag = value;
					textBox2.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第一磨牙
		///       </summary>
		public object RightTopValue3
		{
			get
			{
				return textBox3.Tag;
			}
			set
			{
				int num = 8;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "III")
					{
						textBox3.Tag = value;
						textBox3.BackColor = SystemColors.Control;
					}
					else
					{
						textBox3.Tag = value;
						textBox3.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox3.Tag = value;
					textBox3.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第二前磨牙
		///       </summary>
		public object RightTopValue4
		{
			get
			{
				return textBox4.Tag;
			}
			set
			{
				int num = 12;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "II")
					{
						textBox4.Tag = value;
						textBox4.BackColor = SystemColors.Control;
					}
					else
					{
						textBox4.Tag = value;
						textBox4.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox4.Tag = value;
					textBox4.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第一前磨牙
		///       </summary>
		public object RightTopValue5
		{
			get
			{
				return textBox5.Tag;
			}
			set
			{
				int num = 5;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "I")
					{
						textBox5.Tag = value;
						textBox5.BackColor = SystemColors.Control;
					}
					else
					{
						textBox5.Tag = value;
						textBox5.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox5.Tag = value;
					textBox5.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       中切牙
		///       </summary>
		public object LeftTopValue1
		{
			get
			{
				return textBox6.Tag;
			}
			set
			{
				int num = 6;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "I")
					{
						textBox6.Tag = value;
						textBox6.BackColor = SystemColors.Control;
					}
					else
					{
						textBox6.Tag = value;
						textBox6.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox6.Tag = value;
					textBox6.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       侧切牙
		///       </summary>
		public object LeftTopValue2
		{
			get
			{
				return textBox7.Tag;
			}
			set
			{
				int num = 7;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "II")
					{
						textBox7.Tag = value;
						textBox7.BackColor = SystemColors.Control;
					}
					else
					{
						textBox7.Tag = value;
						textBox7.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox7.Tag = value;
					textBox7.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       尖牙
		///       </summary>
		public object LeftTopValue3
		{
			get
			{
				return textBox8.Tag;
			}
			set
			{
				int num = 11;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "III")
					{
						textBox8.Tag = value;
						textBox8.BackColor = SystemColors.Control;
					}
					else
					{
						textBox8.Tag = value;
						textBox8.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox8.Tag = value;
					textBox8.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第一前磨牙
		///       </summary>
		public object LeftTopValue4
		{
			get
			{
				return textBox9.Tag;
			}
			set
			{
				int num = 0;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "IV")
					{
						textBox9.Tag = value;
						textBox9.BackColor = SystemColors.Control;
					}
					else
					{
						textBox9.Tag = value;
						textBox9.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox9.Tag = value;
					textBox9.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第二前磨牙
		///       </summary>
		public object LeftTopValue5
		{
			get
			{
				return textBox10.Tag;
			}
			set
			{
				int num = 5;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "V")
					{
						textBox10.Tag = value;
						textBox10.BackColor = SystemColors.Control;
					}
					else
					{
						textBox10.Tag = value;
						textBox10.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox10.Tag = value;
					textBox10.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第三磨牙
		///       </summary>
		public object RightBottomValue1
		{
			get
			{
				return textBox11.Tag;
			}
			set
			{
				int num = 16;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "V")
					{
						textBox11.Tag = value;
						textBox11.BackColor = SystemColors.Control;
					}
					else
					{
						textBox11.Tag = value;
						textBox11.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox11.Tag = value;
					textBox11.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第二磨牙
		///       </summary>
		public object RightBottomValue2
		{
			get
			{
				return textBox12.Tag;
			}
			set
			{
				int num = 4;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "IV")
					{
						textBox12.Tag = value;
						textBox12.BackColor = SystemColors.Control;
					}
					else
					{
						textBox12.Tag = value;
						textBox12.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox12.Tag = value;
					textBox12.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第一磨牙
		///       </summary>
		public object RightBottomValue3
		{
			get
			{
				return textBox13.Tag;
			}
			set
			{
				int num = 19;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "III")
					{
						textBox13.Tag = value;
						textBox13.BackColor = SystemColors.Control;
					}
					else
					{
						textBox13.Tag = value;
						textBox13.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox13.Tag = value;
					textBox13.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第二前磨牙
		///       </summary>
		public object RightBottomValue4
		{
			get
			{
				return textBox14.Tag;
			}
			set
			{
				int num = 9;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "II")
					{
						textBox14.Tag = value;
						textBox14.BackColor = SystemColors.Control;
					}
					else
					{
						textBox14.Tag = value;
						textBox14.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox14.Tag = value;
					textBox14.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第一前磨牙
		///       </summary>
		public object RightBottomValue5
		{
			get
			{
				return textBox15.Tag;
			}
			set
			{
				int num = 13;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "I")
					{
						textBox15.Tag = value;
						textBox15.BackColor = SystemColors.Control;
					}
					else
					{
						textBox15.Tag = value;
						textBox15.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox15.Tag = value;
					textBox15.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       中切牙
		///       </summary>
		public object LeftBottomValue1
		{
			get
			{
				return textBox16.Tag;
			}
			set
			{
				int num = 12;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "I")
					{
						textBox16.Tag = value;
						textBox16.BackColor = SystemColors.Control;
					}
					else
					{
						textBox16.Tag = value;
						textBox16.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox16.Tag = value;
					textBox16.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       侧切牙
		///       </summary>
		public object LeftBottomValue2
		{
			get
			{
				return textBox17.Tag;
			}
			set
			{
				int num = 13;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "II")
					{
						textBox17.Tag = value;
						textBox17.BackColor = SystemColors.Control;
					}
					else
					{
						textBox17.Tag = value;
						textBox17.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox17.Tag = value;
					textBox17.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       尖牙
		///       </summary>
		public object LeftBottomValue3
		{
			get
			{
				return textBox18.Tag;
			}
			set
			{
				int num = 6;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "III")
					{
						textBox18.Tag = value;
						textBox18.BackColor = SystemColors.Control;
					}
					else
					{
						textBox18.Tag = value;
						textBox18.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox18.Tag = value;
					textBox18.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第一前磨牙
		///       </summary>
		public object LeftBottomValue4
		{
			get
			{
				return textBox19.Tag;
			}
			set
			{
				int num = 18;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "IV")
					{
						textBox19.Tag = value;
						textBox19.BackColor = SystemColors.Control;
					}
					else
					{
						textBox19.Tag = value;
						textBox19.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox19.Tag = value;
					textBox19.BackColor = SystemColors.Control;
				}
			}
		}

		/// <summary>
		///       第二前磨牙
		///       </summary>
		public object LeftBottomValue5
		{
			get
			{
				return textBox20.Tag;
			}
			set
			{
				int num = 14;
				if (!string.IsNullOrEmpty(Convert.ToString(value)))
				{
					if (Convert.ToString(value) == "V")
					{
						textBox20.Tag = value;
						textBox20.BackColor = SystemColors.Control;
					}
					else
					{
						textBox20.Tag = value;
						textBox20.BackColor = SystemColors.Highlight;
					}
				}
				else
				{
					textBox20.Tag = value;
					textBox20.BackColor = SystemColors.Control;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.Medical.dlgDeciduousTeech));
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
			textBox17 = new System.Windows.Forms.TextBox();
			textBox18 = new System.Windows.Forms.TextBox();
			textBox19 = new System.Windows.Forms.TextBox();
			textBox20 = new System.Windows.Forms.TextBox();
			textBox9 = new System.Windows.Forms.TextBox();
			textBox10 = new System.Windows.Forms.TextBox();
			textBox11 = new System.Windows.Forms.TextBox();
			textBox12 = new System.Windows.Forms.TextBox();
			textBox13 = new System.Windows.Forms.TextBox();
			textBox14 = new System.Windows.Forms.TextBox();
			textBox15 = new System.Windows.Forms.TextBox();
			textBox16 = new System.Windows.Forms.TextBox();
			textBox8 = new System.Windows.Forms.TextBox();
			textBox7 = new System.Windows.Forms.TextBox();
			textBox6 = new System.Windows.Forms.TextBox();
			textBox5 = new System.Windows.Forms.TextBox();
			textBox4 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
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
			textBox17.BackColor = System.Drawing.SystemColors.Control;
			textBox17.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox17, "textBox17");
			textBox17.Name = "textBox17";
			textBox17.ReadOnly = true;
			textBox17.TabStop = false;
			textBox17.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox17_MouseClick);
			textBox18.BackColor = System.Drawing.SystemColors.Control;
			textBox18.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox18, "textBox18");
			textBox18.Name = "textBox18";
			textBox18.ReadOnly = true;
			textBox18.TabStop = false;
			textBox18.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox18_MouseClick);
			textBox19.BackColor = System.Drawing.SystemColors.Control;
			textBox19.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox19, "textBox19");
			textBox19.Name = "textBox19";
			textBox19.ReadOnly = true;
			textBox19.TabStop = false;
			textBox19.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox19_MouseClick);
			textBox20.BackColor = System.Drawing.SystemColors.Control;
			textBox20.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox20, "textBox20");
			textBox20.Name = "textBox20";
			textBox20.ReadOnly = true;
			textBox20.TabStop = false;
			textBox20.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox20_MouseClick);
			textBox9.BackColor = System.Drawing.SystemColors.Control;
			textBox9.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox9, "textBox9");
			textBox9.Name = "textBox9";
			textBox9.ReadOnly = true;
			textBox9.TabStop = false;
			textBox9.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox9_MouseClick);
			textBox10.BackColor = System.Drawing.SystemColors.Control;
			textBox10.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox10, "textBox10");
			textBox10.Name = "textBox10";
			textBox10.ReadOnly = true;
			textBox10.TabStop = false;
			textBox10.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox10_MouseClick);
			textBox11.BackColor = System.Drawing.SystemColors.Control;
			textBox11.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox11, "textBox11");
			textBox11.Name = "textBox11";
			textBox11.ReadOnly = true;
			textBox11.TabStop = false;
			textBox11.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox11_MouseClick);
			textBox12.BackColor = System.Drawing.SystemColors.Control;
			textBox12.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox12, "textBox12");
			textBox12.Name = "textBox12";
			textBox12.ReadOnly = true;
			textBox12.TabStop = false;
			textBox12.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox12_MouseClick);
			textBox13.BackColor = System.Drawing.SystemColors.Control;
			textBox13.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox13, "textBox13");
			textBox13.Name = "textBox13";
			textBox13.ReadOnly = true;
			textBox13.TabStop = false;
			textBox13.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox13_MouseClick);
			textBox14.BackColor = System.Drawing.SystemColors.Control;
			textBox14.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox14, "textBox14");
			textBox14.Name = "textBox14";
			textBox14.ReadOnly = true;
			textBox14.TabStop = false;
			textBox14.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox14_MouseClick);
			textBox15.BackColor = System.Drawing.SystemColors.Control;
			textBox15.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox15, "textBox15");
			textBox15.Name = "textBox15";
			textBox15.ReadOnly = true;
			textBox15.TabStop = false;
			textBox15.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox15_MouseClick);
			textBox16.BackColor = System.Drawing.SystemColors.Control;
			textBox16.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox16, "textBox16");
			textBox16.Name = "textBox16";
			textBox16.ReadOnly = true;
			textBox16.TabStop = false;
			textBox16.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox16_MouseClick);
			textBox8.BackColor = System.Drawing.SystemColors.Control;
			textBox8.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox8, "textBox8");
			textBox8.Name = "textBox8";
			textBox8.ReadOnly = true;
			textBox8.TabStop = false;
			textBox8.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox8_MouseClick);
			textBox7.BackColor = System.Drawing.SystemColors.Control;
			textBox7.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox7, "textBox7");
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.TabStop = false;
			textBox7.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox7_MouseClick);
			textBox6.BackColor = System.Drawing.SystemColors.Control;
			textBox6.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox6, "textBox6");
			textBox6.Name = "textBox6";
			textBox6.ReadOnly = true;
			textBox6.TabStop = false;
			textBox6.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox6_MouseClick);
			textBox5.BackColor = System.Drawing.SystemColors.Control;
			textBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox5, "textBox5");
			textBox5.Name = "textBox5";
			textBox5.ReadOnly = true;
			textBox5.TabStop = false;
			textBox5.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox5_MouseClick);
			textBox4.BackColor = System.Drawing.SystemColors.Control;
			textBox4.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox4, "textBox4");
			textBox4.Name = "textBox4";
			textBox4.ReadOnly = true;
			textBox4.TabStop = false;
			textBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox4_MouseClick);
			textBox3.BackColor = System.Drawing.SystemColors.Control;
			textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox3, "textBox3");
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.TabStop = false;
			textBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox3_MouseClick);
			textBox2.BackColor = System.Drawing.SystemColors.Control;
			textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox2, "textBox2");
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.TabStop = false;
			textBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox2_MouseClick);
			textBox1.BackColor = System.Drawing.SystemColors.Control;
			textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.TabStop = false;
			textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox1_MouseClick);
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			label6.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
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
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDeciduousTeech()
		{
			InitializeComponent();
		}

		private void textBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox1.BackColor == SystemColors.Control)
			{
				RightTopValue1 = 15;
			}
			else if (e.Button == MouseButtons.Left && textBox1.BackColor == SystemColors.Highlight)
			{
				RightTopValue1 = null;
			}
		}

		private void textBox2_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox2.BackColor == SystemColors.Control)
			{
				RightTopValue2 = 14;
			}
			else if (e.Button == MouseButtons.Left && textBox2.BackColor == SystemColors.Highlight)
			{
				RightTopValue2 = null;
			}
		}

		private void textBox3_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox3.BackColor == SystemColors.Control)
			{
				RightTopValue3 = 13;
			}
			else if (e.Button == MouseButtons.Left && textBox3.BackColor == SystemColors.Highlight)
			{
				RightTopValue3 = null;
			}
		}

		private void textBox4_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox4.BackColor == SystemColors.Control)
			{
				RightTopValue4 = 12;
			}
			else if (e.Button == MouseButtons.Left && textBox4.BackColor == SystemColors.Highlight)
			{
				RightTopValue4 = null;
			}
		}

		private void textBox5_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox5.BackColor == SystemColors.Control)
			{
				RightTopValue5 = 11;
			}
			else if (e.Button == MouseButtons.Left && textBox5.BackColor == SystemColors.Highlight)
			{
				RightTopValue5 = null;
			}
		}

		private void textBox6_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox6.BackColor == SystemColors.Control)
			{
				LeftTopValue1 = 21;
			}
			else if (e.Button == MouseButtons.Left && textBox6.BackColor == SystemColors.Highlight)
			{
				LeftTopValue1 = null;
			}
		}

		private void textBox7_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox7.BackColor == SystemColors.Control)
			{
				LeftTopValue2 = 22;
			}
			else if (e.Button == MouseButtons.Left && textBox7.BackColor == SystemColors.Highlight)
			{
				LeftTopValue2 = null;
			}
		}

		private void textBox8_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox8.BackColor == SystemColors.Control)
			{
				LeftTopValue3 = 23;
			}
			else if (e.Button == MouseButtons.Left && textBox8.BackColor == SystemColors.Highlight)
			{
				LeftTopValue3 = null;
			}
		}

		private void textBox9_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox9.BackColor == SystemColors.Control)
			{
				LeftTopValue4 = 24;
			}
			else if (e.Button == MouseButtons.Left && textBox9.BackColor == SystemColors.Highlight)
			{
				LeftTopValue4 = null;
			}
		}

		private void textBox10_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox10.BackColor == SystemColors.Control)
			{
				LeftTopValue5 = 25;
			}
			else if (e.Button == MouseButtons.Left && textBox10.BackColor == SystemColors.Highlight)
			{
				LeftTopValue5 = null;
			}
		}

		private void textBox11_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox11.BackColor == SystemColors.Control)
			{
				RightBottomValue1 = 45;
			}
			else if (e.Button == MouseButtons.Left && textBox11.BackColor == SystemColors.Highlight)
			{
				RightBottomValue1 = null;
			}
		}

		private void textBox12_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox12.BackColor == SystemColors.Control)
			{
				RightBottomValue2 = 44;
			}
			else if (e.Button == MouseButtons.Left && textBox12.BackColor == SystemColors.Highlight)
			{
				RightBottomValue2 = null;
			}
		}

		private void textBox13_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox13.BackColor == SystemColors.Control)
			{
				RightBottomValue3 = 43;
			}
			else if (e.Button == MouseButtons.Left && textBox13.BackColor == SystemColors.Highlight)
			{
				RightBottomValue3 = null;
			}
		}

		private void textBox14_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox14.BackColor == SystemColors.Control)
			{
				RightBottomValue4 = 42;
			}
			else if (e.Button == MouseButtons.Left && textBox14.BackColor == SystemColors.Highlight)
			{
				RightBottomValue4 = null;
			}
		}

		private void textBox15_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox15.BackColor == SystemColors.Control)
			{
				RightBottomValue5 = 41;
			}
			else if (e.Button == MouseButtons.Left && textBox15.BackColor == SystemColors.Highlight)
			{
				RightBottomValue5 = null;
			}
		}

		private void textBox16_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox16.BackColor == SystemColors.Control)
			{
				LeftBottomValue1 = 31;
			}
			else if (e.Button == MouseButtons.Left && textBox16.BackColor == SystemColors.Highlight)
			{
				LeftBottomValue1 = null;
			}
		}

		private void textBox17_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox17.BackColor == SystemColors.Control)
			{
				LeftBottomValue2 = 32;
			}
			else if (e.Button == MouseButtons.Left && textBox17.BackColor == SystemColors.Highlight)
			{
				LeftBottomValue2 = null;
			}
		}

		private void textBox18_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox18.BackColor == SystemColors.Control)
			{
				LeftBottomValue3 = 33;
			}
			else if (e.Button == MouseButtons.Left && textBox18.BackColor == SystemColors.Highlight)
			{
				LeftBottomValue3 = null;
			}
		}

		private void textBox19_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox19.BackColor == SystemColors.Control)
			{
				LeftBottomValue4 = 34;
			}
			else if (e.Button == MouseButtons.Left && textBox19.BackColor == SystemColors.Highlight)
			{
				LeftBottomValue4 = null;
			}
		}

		private void textBox20_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && textBox20.BackColor == SystemColors.Control)
			{
				LeftBottomValue5 = 35;
			}
			else if (e.Button == MouseButtons.Left && textBox20.BackColor == SystemColors.Highlight)
			{
				LeftBottomValue5 = null;
			}
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
	}
}

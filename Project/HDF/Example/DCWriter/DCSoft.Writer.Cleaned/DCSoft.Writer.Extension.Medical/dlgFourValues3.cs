using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       月经史公式输入
	///       </summary>
	[ComVisible(false)]
	public class dlgFourValues3 : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private ComboBox txtValue2;

		private ComboBox txtValue3;

		private DateTimePicker txtValue1;

		private DateTimePicker txtValue4;

		private TextBox textBox1;

		private TextBox textBox2;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		/// <summary>
		///       初潮年龄
		///       </summary>
		public string Value1
		{
			get
			{
				if (checkBox1.Checked)
				{
					return txtValue1.Value.ToShortDateString();
				}
				return textBox1.Text;
			}
			set
			{
				DateTime result = default(DateTime);
				if (DateTime.TryParse(value.ToString(), out result))
				{
					txtValue1.Value = result;
					checkBox1.Checked = true;
				}
				else
				{
					textBox1.Text = value;
					checkBox1.Checked = false;
				}
			}
		}

		/// <summary>
		///       经期（天）
		///       </summary>
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

		/// <summary>
		///       周期（天）
		///       </summary>
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

		/// <summary>
		///       末次月经/绝经年龄
		///       </summary>
		public string Value4
		{
			get
			{
				if (checkBox2.Checked)
				{
					return txtValue4.Value.ToShortDateString();
				}
				return textBox2.Text;
			}
			set
			{
				DateTime result = default(DateTime);
				if (DateTime.TryParse(value.ToString(), out result))
				{
					txtValue4.Value = result;
					checkBox2.Checked = true;
				}
				else
				{
					textBox2.Text = value;
					checkBox2.Checked = false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.Medical.dlgFourValues3));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			txtValue2 = new System.Windows.Forms.ComboBox();
			txtValue3 = new System.Windows.Forms.ComboBox();
			txtValue1 = new System.Windows.Forms.DateTimePicker();
			txtValue4 = new System.Windows.Forms.DateTimePicker();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			checkBox2 = new System.Windows.Forms.CheckBox();
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
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			txtValue2.FormattingEnabled = true;
			txtValue2.Items.AddRange(new object[31]
			{
				resources.GetString("txtValue2.Items"),
				resources.GetString("txtValue2.Items1"),
				resources.GetString("txtValue2.Items2"),
				resources.GetString("txtValue2.Items3"),
				resources.GetString("txtValue2.Items4"),
				resources.GetString("txtValue2.Items5"),
				resources.GetString("txtValue2.Items6"),
				resources.GetString("txtValue2.Items7"),
				resources.GetString("txtValue2.Items8"),
				resources.GetString("txtValue2.Items9"),
				resources.GetString("txtValue2.Items10"),
				resources.GetString("txtValue2.Items11"),
				resources.GetString("txtValue2.Items12"),
				resources.GetString("txtValue2.Items13"),
				resources.GetString("txtValue2.Items14"),
				resources.GetString("txtValue2.Items15"),
				resources.GetString("txtValue2.Items16"),
				resources.GetString("txtValue2.Items17"),
				resources.GetString("txtValue2.Items18"),
				resources.GetString("txtValue2.Items19"),
				resources.GetString("txtValue2.Items20"),
				resources.GetString("txtValue2.Items21"),
				resources.GetString("txtValue2.Items22"),
				resources.GetString("txtValue2.Items23"),
				resources.GetString("txtValue2.Items24"),
				resources.GetString("txtValue2.Items25"),
				resources.GetString("txtValue2.Items26"),
				resources.GetString("txtValue2.Items27"),
				resources.GetString("txtValue2.Items28"),
				resources.GetString("txtValue2.Items29"),
				resources.GetString("txtValue2.Items30")
			});
			resources.ApplyResources(txtValue2, "txtValue2");
			txtValue2.Name = "txtValue2";
			txtValue3.FormattingEnabled = true;
			txtValue3.Items.AddRange(new object[31]
			{
				resources.GetString("txtValue3.Items"),
				resources.GetString("txtValue3.Items1"),
				resources.GetString("txtValue3.Items2"),
				resources.GetString("txtValue3.Items3"),
				resources.GetString("txtValue3.Items4"),
				resources.GetString("txtValue3.Items5"),
				resources.GetString("txtValue3.Items6"),
				resources.GetString("txtValue3.Items7"),
				resources.GetString("txtValue3.Items8"),
				resources.GetString("txtValue3.Items9"),
				resources.GetString("txtValue3.Items10"),
				resources.GetString("txtValue3.Items11"),
				resources.GetString("txtValue3.Items12"),
				resources.GetString("txtValue3.Items13"),
				resources.GetString("txtValue3.Items14"),
				resources.GetString("txtValue3.Items15"),
				resources.GetString("txtValue3.Items16"),
				resources.GetString("txtValue3.Items17"),
				resources.GetString("txtValue3.Items18"),
				resources.GetString("txtValue3.Items19"),
				resources.GetString("txtValue3.Items20"),
				resources.GetString("txtValue3.Items21"),
				resources.GetString("txtValue3.Items22"),
				resources.GetString("txtValue3.Items23"),
				resources.GetString("txtValue3.Items24"),
				resources.GetString("txtValue3.Items25"),
				resources.GetString("txtValue3.Items26"),
				resources.GetString("txtValue3.Items27"),
				resources.GetString("txtValue3.Items28"),
				resources.GetString("txtValue3.Items29"),
				resources.GetString("txtValue3.Items30")
			});
			resources.ApplyResources(txtValue3, "txtValue3");
			txtValue3.Name = "txtValue3";
			resources.ApplyResources(txtValue1, "txtValue1");
			txtValue1.Name = "txtValue1";
			resources.ApplyResources(txtValue4, "txtValue4");
			txtValue4.Name = "txtValue4";
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.Name = "textBox1";
			resources.ApplyResources(textBox2, "textBox2");
			textBox2.Name = "textBox2";
			resources.ApplyResources(checkBox1, "checkBox1");
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Name = "checkBox1";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			resources.ApplyResources(checkBox2, "checkBox2");
			checkBox2.Checked = true;
			checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox2.Name = "checkBox2";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(checkBox2);
			base.Controls.Add(checkBox1);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(txtValue4);
			base.Controls.Add(txtValue1);
			base.Controls.Add(txtValue3);
			base.Controls.Add(txtValue2);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(label5);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFourValues3";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgFourValues3()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			checkBox1.Checked = false;
			checkBox2.Checked = false;
			txtValue2.Tag = false;
			txtValue2.GotFocus += txtValue2_GotFocus;
			txtValue2.MouseDown += txtValue2_MouseDown;
			txtValue3.Tag = false;
			txtValue3.GotFocus += txtValue3_GotFocus;
			txtValue3.MouseDown += txtValue3_MouseDown;
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
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				txtValue1.Visible = true;
				txtValue1.Enabled = true;
				textBox1.Visible = false;
				textBox1.Enabled = false;
			}
			else
			{
				txtValue1.Visible = false;
				txtValue1.Enabled = false;
				textBox1.Visible = true;
				textBox1.Enabled = true;
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
			{
				txtValue4.Visible = true;
				txtValue4.Enabled = true;
				textBox2.Visible = false;
				textBox2.Enabled = false;
			}
			else
			{
				txtValue4.Visible = false;
				txtValue4.Enabled = false;
				textBox2.Visible = true;
				textBox2.Enabled = true;
			}
		}
	}
}

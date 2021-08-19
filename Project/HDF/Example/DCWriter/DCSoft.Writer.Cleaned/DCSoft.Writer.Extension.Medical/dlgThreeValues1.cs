using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       输入医学表达式值
	///       </summary>
	[ComVisible(false)]
	public class dlgThreeValues1 : Form
	{
		private IContainer icontainer_0 = null;

		private Label label3;

		private Label label2;

		private Label label1;

		private TextBox txtValue3;

		private TextBox txtValue2;

		private TextBox txtValue1;

		private Button btnCancel;

		private Button btnOK;

		private Label label5;

		private Label label4;

		/// <summary>
		///       A值
		///       </summary>
		public string Value1
		{
			get
			{
				return txtValue1.Text;
			}
			set
			{
				txtValue1.Text = value;
			}
		}

		/// <summary>
		///       B值
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
		///       C值
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.Medical.dlgThreeValues1));
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			txtValue3 = new System.Windows.Forms.TextBox();
			txtValue2 = new System.Windows.Forms.TextBox();
			txtValue1 = new System.Windows.Forms.TextBox();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			SuspendLayout();
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
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
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(label4);
			base.Controls.Add(label5);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(txtValue3);
			base.Controls.Add(txtValue2);
			base.Controls.Add(txtValue1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgThreeValues1";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgThreeValues1()
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
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

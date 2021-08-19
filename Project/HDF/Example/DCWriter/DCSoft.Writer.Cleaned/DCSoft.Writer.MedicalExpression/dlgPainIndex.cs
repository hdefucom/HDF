using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
{
	/// <summary>
	///       输入医学表达式数值
	///       </summary>
	[ComVisible(false)]
	public class dlgPainIndex : Form
	{
		private MedicalExpressionValueList medicalExpressionValueList_0 = null;

		private IContainer icontainer_0 = null;

		private TrackBar trackBar1;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label14;

		private Label label16;

		private Label label18;

		private Label label20;

		private Label label21;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label label27;

		private Label label28;

		private Label lbl0;

		private Label lbl1;

		private Label lbl2;

		private Label lbl3;

		private Label lbl4;

		private Label lbl5;

		private Label lbl6;

		private Label lbl7;

		private Label lbl8;

		private Label lbl9;

		private Label lbl10;

		private Button btnOK;

		private Button btnCancel;

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
		///       疼痛指数值
		///       </summary>
		public string PainIndexValue
		{
			get
			{
				return trackBar1.Value.ToString();
			}
			set
			{
				try
				{
					trackBar1.Value = int.Parse(value);
				}
				catch
				{
				}
			}
		}

		/// <summary>
		///       疼痛指数表达式
		///       </summary>
		public dlgPainIndex()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			medicalExpressionValueList_0.SetValue("Value1", PainIndexValue);
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgPainIndex_Load(object sender, EventArgs e)
		{
			PainIndexValue = InputValues.GetValue("Value1");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgPainIndex));
			trackBar1 = new System.Windows.Forms.TrackBar();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			lbl0 = new System.Windows.Forms.Label();
			lbl1 = new System.Windows.Forms.Label();
			lbl2 = new System.Windows.Forms.Label();
			lbl3 = new System.Windows.Forms.Label();
			lbl4 = new System.Windows.Forms.Label();
			lbl5 = new System.Windows.Forms.Label();
			lbl6 = new System.Windows.Forms.Label();
			lbl7 = new System.Windows.Forms.Label();
			lbl8 = new System.Windows.Forms.Label();
			lbl9 = new System.Windows.Forms.Label();
			lbl10 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			SuspendLayout();
			resources.ApplyResources(trackBar1, "trackBar1");
			trackBar1.Maximum = 100;
			trackBar1.Name = "trackBar1";
			trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			label1.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			label2.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			label3.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			label4.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			label5.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			label6.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			label7.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			label8.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			label9.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			label10.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			label11.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			label12.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			label14.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label14, "label14");
			label14.Name = "label14";
			label16.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label16, "label16");
			label16.Name = "label16";
			label18.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label18, "label18");
			label18.Name = "label18";
			label20.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label20, "label20");
			label20.Name = "label20";
			label21.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label21, "label21");
			label21.Name = "label21";
			label23.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label23, "label23");
			label23.Name = "label23";
			label24.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label24, "label24");
			label24.Name = "label24";
			label25.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label25, "label25");
			label25.Name = "label25";
			label27.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label27, "label27");
			label27.Name = "label27";
			label28.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(label28, "label28");
			label28.Name = "label28";
			lbl0.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(lbl0, "lbl0");
			lbl0.Name = "lbl0";
			resources.ApplyResources(lbl1, "lbl1");
			lbl1.BackColor = System.Drawing.Color.Transparent;
			lbl1.Name = "lbl1";
			resources.ApplyResources(lbl2, "lbl2");
			lbl2.BackColor = System.Drawing.Color.Transparent;
			lbl2.Name = "lbl2";
			resources.ApplyResources(lbl3, "lbl3");
			lbl3.BackColor = System.Drawing.Color.Transparent;
			lbl3.Name = "lbl3";
			resources.ApplyResources(lbl4, "lbl4");
			lbl4.BackColor = System.Drawing.Color.Transparent;
			lbl4.Name = "lbl4";
			resources.ApplyResources(lbl5, "lbl5");
			lbl5.BackColor = System.Drawing.Color.Transparent;
			lbl5.Name = "lbl5";
			resources.ApplyResources(lbl6, "lbl6");
			lbl6.BackColor = System.Drawing.Color.Transparent;
			lbl6.Name = "lbl6";
			resources.ApplyResources(lbl7, "lbl7");
			lbl7.BackColor = System.Drawing.Color.Transparent;
			lbl7.Name = "lbl7";
			resources.ApplyResources(lbl8, "lbl8");
			lbl8.BackColor = System.Drawing.Color.Transparent;
			lbl8.Name = "lbl8";
			resources.ApplyResources(lbl9, "lbl9");
			lbl9.BackColor = System.Drawing.Color.Transparent;
			lbl9.Name = "lbl9";
			resources.ApplyResources(lbl10, "lbl10");
			lbl10.BackColor = System.Drawing.Color.Transparent;
			lbl10.Name = "lbl10";
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
			base.Controls.Add(lbl10);
			base.Controls.Add(lbl9);
			base.Controls.Add(lbl8);
			base.Controls.Add(lbl7);
			base.Controls.Add(lbl6);
			base.Controls.Add(lbl5);
			base.Controls.Add(lbl4);
			base.Controls.Add(lbl3);
			base.Controls.Add(lbl2);
			base.Controls.Add(lbl1);
			base.Controls.Add(lbl0);
			base.Controls.Add(label28);
			base.Controls.Add(label27);
			base.Controls.Add(label25);
			base.Controls.Add(label24);
			base.Controls.Add(label23);
			base.Controls.Add(label21);
			base.Controls.Add(label20);
			base.Controls.Add(label18);
			base.Controls.Add(label16);
			base.Controls.Add(label14);
			base.Controls.Add(label12);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(trackBar1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPainIndex";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPainIndex_Load);
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

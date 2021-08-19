using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class dlgHRuleProperty : Form
	{
		private Label label1;

		private NumericUpDown txtWidth;

		private Label label2;

		private Button cmdColor;

		private Label label3;

		private ComboBox cboStyle;

		private Button cmdOK;

		private Button cmdCancel;

		public ZYTextHRule Rule = null;

		private Container components = null;

		public dlgHRuleProperty()
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

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			txtWidth = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			cmdColor = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			cboStyle = new System.Windows.Forms.ComboBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)txtWidth).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(24, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(66, 17);
			label1.TabIndex = 0;
			label1.Text = "线的宽度：";
			txtWidth.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			txtWidth.Location = new System.Drawing.Point(96, 24);
			txtWidth.Maximum = new decimal(new int[4]
			{
				12,
				0,
				0,
				0
			});
			txtWidth.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtWidth.Name = "txtWidth";
			txtWidth.Size = new System.Drawing.Size(136, 21);
			txtWidth.TabIndex = 1;
			txtWidth.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(24, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(66, 17);
			label2.TabIndex = 2;
			label2.Text = "线条颜色：";
			cmdColor.BackColor = System.Drawing.Color.White;
			cmdColor.Location = new System.Drawing.Point(96, 56);
			cmdColor.Name = "cmdColor";
			cmdColor.Size = new System.Drawing.Size(136, 23);
			cmdColor.TabIndex = 3;
			cmdColor.Click += new System.EventHandler(cmdColor_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(24, 88);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(66, 17);
			label3.TabIndex = 4;
			label3.Text = "线条样式：";
			cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboStyle.Enabled = false;
			cboStyle.Location = new System.Drawing.Point(96, 88);
			cboStyle.Name = "cboStyle";
			cboStyle.Size = new System.Drawing.Size(136, 20);
			cboStyle.TabIndex = 5;
			cmdOK.Location = new System.Drawing.Point(128, 120);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 6;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Location = new System.Drawing.Point(216, 120);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 7;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(298, 151);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(cboStyle);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(cmdColor);
			base.Controls.Add(txtWidth);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgHRuleProperty";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "水平线属性";
			base.Load += new System.EventHandler(dlgHRuleProperty_Load);
			((System.ComponentModel.ISupportInitialize)txtWidth).EndInit();
			ResumeLayout(false);
		}

		private void dlgHRuleProperty_Load(object sender, EventArgs e)
		{
			if (Rule != null)
			{
				txtWidth.Value = Rule.LineHeight;
				cmdColor.BackColor = Rule.ForeColor;
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (Rule != null)
			{
				Rule.ForeColor = cmdColor.BackColor;
				Rule.LineHeight = (int)txtWidth.Value;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdColor_Click(object sender, EventArgs e)
		{
			using (ColorDialog colorDialog = new ColorDialog())
			{
				colorDialog.Color = cmdColor.BackColor;
				if (colorDialog.ShowDialog(this) == DialogResult.OK)
				{
					cmdColor.BackColor = colorDialog.Color;
				}
			}
		}
	}
}

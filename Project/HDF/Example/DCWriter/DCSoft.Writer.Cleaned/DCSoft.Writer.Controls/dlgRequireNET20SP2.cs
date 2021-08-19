using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	[ComVisible(false)]
	[DCInternal]
	public class dlgRequireNET20SP2 : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox textBox1;

		private Button button1;

		private Timer timer_0;

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
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgRequireNET20SP2));
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			timer_0 = new System.Windows.Forms.Timer(icontainer_0);
			SuspendLayout();
			textBox1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			textBox1.Dock = System.Windows.Forms.DockStyle.Top;
			textBox1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.ForeColor = System.Drawing.Color.Red;
			textBox1.Location = new System.Drawing.Point(0, 0);
			textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(816, 103);
			textBox1.TabIndex = 0;
			textBox1.Text = resources.GetString("textBox1.Text");
			button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button1.Location = new System.Drawing.Point(346, 120);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "关闭(&C)";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			timer_0.Interval = 90000;
			timer_0.Tick += new System.EventHandler(timer_0_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
			base.ClientSize = new System.Drawing.Size(816, 155);
			base.Controls.Add(button1);
			base.Controls.Add(textBox1);
			Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgRequireNET20SP2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "系统警告";
			base.TopMost = true;
			base.Load += new System.EventHandler(dlgRequireNET20SP2_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgRequireNET20SP2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgRequireNET20SP2_Load(object sender, EventArgs e)
		{
			timer_0.Start();
			textBox1.SelectionStart = 0;
			textBox1.SelectionLength = 0;
		}
	}
}

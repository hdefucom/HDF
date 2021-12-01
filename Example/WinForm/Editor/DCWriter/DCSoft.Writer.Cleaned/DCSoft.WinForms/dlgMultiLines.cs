using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class dlgMultiLines : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtLines;

		private Button button1;

		public string InputText
		{
			get
			{
				return txtLines.Text;
			}
			set
			{
				txtLines.Text = value;
			}
		}

		public dlgMultiLines()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
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
			txtLines = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			txtLines.Dock = System.Windows.Forms.DockStyle.Top;
			txtLines.HideSelection = false;
			txtLines.Location = new System.Drawing.Point(0, 0);
			txtLines.MaxLength = 100000;
			txtLines.Multiline = true;
			txtLines.Name = "txtLines";
			txtLines.ReadOnly = true;
			txtLines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtLines.Size = new System.Drawing.Size(514, 278);
			txtLines.TabIndex = 0;
			txtLines.WordWrap = false;
			button1.Location = new System.Drawing.Point(292, 284);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(96, 23);
			button1.TabIndex = 1;
			button1.Text = "关闭";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(514, 313);
			base.Controls.Add(button1);
			base.Controls.Add(txtLines);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgMultiLines";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "系统提示";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

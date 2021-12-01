using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	[ComVisible(false)]
	public class dlgAxWriterControlDock : Form
	{
		/// <summary>
		///       Required designer variable.
		///       </summary>
		private IContainer components = null;

		private System.Windows.Forms.Timer timer1;

		private Panel panel1;

		private Label lblInfo;

		private Button btnClear;

		private static dlgAxWriterControlDock _Instance = null;

		private string _FirstTitle = null;

		public static dlgAxWriterControlDock Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new dlgAxWriterControlDock();
					_Instance.ShowInTaskbar = true;
					_Instance.Show();
					_Instance.Hide();
				}
				return _Instance;
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			timer1 = new System.Windows.Forms.Timer(components);
			panel1 = new System.Windows.Forms.Panel();
			lblInfo = new System.Windows.Forms.Label();
			btnClear = new System.Windows.Forms.Button();
			SuspendLayout();
			timer1.Interval = 5000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			panel1.Location = new System.Drawing.Point(286, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(181, 83);
			panel1.TabIndex = 0;
			lblInfo.AutoSize = true;
			lblInfo.Location = new System.Drawing.Point(12, 29);
			lblInfo.Name = "lblInfo";
			lblInfo.Size = new System.Drawing.Size(23, 12);
			lblInfo.TabIndex = 1;
			lblInfo.Text = "   ";
			btnClear.Location = new System.Drawing.Point(205, 24);
			btnClear.Name = "btnClear";
			btnClear.Size = new System.Drawing.Size(75, 23);
			btnClear.TabIndex = 2;
			btnClear.Text = "清空";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += new System.EventHandler(btnClear_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(319, 63);
			base.ControlBox = false;
			base.Controls.Add(btnClear);
			base.Controls.Add(lblInfo);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "dlgAxWriterControlDock";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "都昌编辑器控件容器";
			base.Load += new System.EventHandler(dlgAxWriterControlDock_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgAxWriterControlDock()
		{
			InitializeComponent();
			_FirstTitle = Text;
		}

		public static void RemoveControl(Control control_0)
		{
			Instance.InnerRemoveControl(control_0);
		}

		private void InnerRemoveControl(Control control_0)
		{
			int num = 1;
			if (control_0 != null && panel1.Controls.Contains(control_0))
			{
				panel1.Controls.Remove(control_0);
				lblInfo.Text = "共 " + panel1.Controls.Count + " 个控件.";
				Thread.Sleep(300);
				timer1.Start();
				base.WindowState = FormWindowState.Minimized;
			}
		}

		public static void AddControl(Control control_0)
		{
			Instance.InnerAddControl(control_0);
		}

		private void InnerAddControl(Control control_0)
		{
			int num = 12;
			if (!(control_0?.IsDisposed ?? true))
			{
				panel1.Controls.Add(control_0);
				lblInfo.Text = "共 " + panel1.Controls.Count + " 个控件.";
				Thread.Sleep(300);
				timer1.Start();
				base.WindowState = FormWindowState.Minimized;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			base.WindowState = FormWindowState.Minimized;
		}

		private void ClearControls()
		{
			int num = 7;
			List<Control> list = new List<Control>();
			foreach (Control control in panel1.Controls)
			{
				list.Add(control);
			}
			foreach (Control item in list)
			{
				try
				{
					panel1.Controls.Remove(item);
					GC.ReRegisterForFinalize(item);
					item.Dispose();
				}
				catch (Exception)
				{
				}
			}
			lblInfo.Text = "共 " + panel1.Controls.Count + " 个控件.";
		}

		private void dlgAxWriterControlDock_Load(object sender, EventArgs e)
		{
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearControls();
		}
	}
}

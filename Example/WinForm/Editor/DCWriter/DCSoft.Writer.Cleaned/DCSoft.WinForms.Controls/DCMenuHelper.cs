using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Controls
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class DCMenuHelper : Form
	{
		private Control control_0;

		private bool bool_0 = false;

		private IContainer icontainer_0 = null;

		private GControl4 office2007ColorPlate1;

		public bool Freeze
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public GControl4 ColorPlate => office2007ColorPlate1;

		public DCMenuHelper()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
		}

		public void method_0(Control control_1, int int_0, int int_1)
		{
			method_3(control_1, new Point(int_0, int_1));
		}

		private void method_1()
		{
			office2007ColorPlate1.method_21();
			office2007ColorPlate1.Size = new Size(office2007ColorPlate1.method_19().Width + 2, office2007ColorPlate1.method_19().Height + 2);
			base.Size = new Size(office2007ColorPlate1.method_19().Width + 5, office2007ColorPlate1.method_19().Height + 3);
		}

		public void method_2(Control control_1, Rectangle rectangle_0)
		{
			int num = 18;
			if (control_1 == null)
			{
				throw new ArgumentNullException("parent");
			}
			Point location = control_1.PointToScreen(new Point(rectangle_0.Left, rectangle_0.Bottom));
			method_1();
			Rectangle workingArea = Screen.GetWorkingArea(control_1);
			if (location.X + base.Width > workingArea.Right)
			{
				location.X = workingArea.Right - base.Width;
			}
			if (location.X < 0)
			{
				location.X = 0;
			}
			if (location.Y + base.Height > workingArea.Bottom)
			{
				location.Y = location.Y - rectangle_0.Height - base.Height;
			}
			if (location.Y < 0)
			{
				location.Y = 0;
			}
			control_0 = control_1;
			base.Owner = control_1.FindForm();
			base.Location = location;
			Show();
		}

		public void method_3(Control control_1, Point point_0)
		{
			int num = 2;
			if (control_1 == null)
			{
				throw new ArgumentNullException("parent");
			}
			control_0 = control_1;
			base.Location = control_1.PointToScreen(point_0);
			base.Owner = control_1.FindForm();
			method_1();
			if (base.Left < 0)
			{
				base.Left = 0;
			}
			else if (base.Right > Screen.PrimaryScreen.WorkingArea.Width)
			{
				base.Left = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 2;
			}
			Show();
		}

		public void method_4()
		{
			Hide();
			if (control_0 != null)
			{
				control_0.FindForm()?.BringToFront();
			}
		}

		private void DCMenuHelper_Deactivate(object sender, EventArgs e)
		{
			if (!ColorPlate.method_15() && !bool_0)
			{
				method_4();
			}
		}

		private void DCMenuHelper_Leave(object sender, EventArgs e)
		{
			if (!bool_0)
			{
				method_4();
			}
		}

		private void method_5(object sender, EventArgs e)
		{
			if (!bool_0)
			{
				method_4();
			}
		}

		private void DCMenuHelper_Shown(object sender, EventArgs e)
		{
		}

		private void method_6(object sender, GEventArgs6 e)
		{
			using (ColorDialog colorDialog = new ColorDialog())
			{
				colorDialog.Color = office2007ColorPlate1.method_10();
				Control owner = this;
				if (control_0 != null)
				{
					owner = control_0;
				}
				if (colorDialog.ShowDialog(owner) == DialogResult.OK)
				{
					e.method_1(colorDialog.Color);
				}
				else
				{
					e.method_3(bool_1: true);
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
			office2007ColorPlate1 = new DCSoftDotfuscate.GControl4();
			SuspendLayout();
			office2007ColorPlate1.Location = new System.Drawing.Point(0, 0);
			office2007ColorPlate1.Name = "office2007ColorPlate1";
			office2007ColorPlate1.method_11(System.Drawing.Color.Empty);
			office2007ColorPlate1.Size = new System.Drawing.Size(190, 215);
			office2007ColorPlate1.TabIndex = 0;
			office2007ColorPlate1.method_12(new System.EventHandler(method_5));
			office2007ColorPlate1.method_16(new DCSoftDotfuscate.GDelegate10(method_6));
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			base.ClientSize = new System.Drawing.Size(211, 222);
			base.ControlBox = false;
			base.Controls.Add(office2007ColorPlate1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "DCMenuHelper";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Deactivate += new System.EventHandler(DCMenuHelper_Deactivate);
			base.Shown += new System.EventHandler(DCMenuHelper_Shown);
			base.Leave += new System.EventHandler(DCMenuHelper_Leave);
			ResumeLayout(false);
		}
	}
}

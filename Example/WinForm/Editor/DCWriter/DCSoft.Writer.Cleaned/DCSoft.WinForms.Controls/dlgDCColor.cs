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
	public class dlgDCColor : Form
	{
		private IContainer icontainer_0 = null;

		private GControl4 office2007ColorPlate1;

		private Button btnOK;

		private Button btnCancel;

		private Color color_0 = Color.Empty;

		public GControl4 ColorPlate => office2007ColorPlate1;

		public Color ColorValue
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.Controls.dlgDCColor));
			office2007ColorPlate1 = new DCSoftDotfuscate.GControl4();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(office2007ColorPlate1, "office2007ColorPlate1");
			office2007ColorPlate1.Name = "office2007ColorPlate1";
			office2007ColorPlate1.method_11(System.Drawing.Color.Empty);
			office2007ColorPlate1.method_3(true);
			office2007ColorPlate1.method_12(new System.EventHandler(method_0));
			office2007ColorPlate1.method_16(new DCSoftDotfuscate.GDelegate10(method_1));
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this, "$this");
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(office2007ColorPlate1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDCColor";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			ResumeLayout(false);
		}

		public dlgDCColor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			office2007ColorPlate1.method_3(bool_3: true);
			office2007ColorPlate1.method_5(bool_3: false);
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			office2007ColorPlate1.method_21();
			office2007ColorPlate1.Size = new Size(office2007ColorPlate1.method_19().Width + 2, office2007ColorPlate1.method_19().Height + 2);
			office2007ColorPlate1.method_11(ColorValue);
		}

		private void method_0(object sender, EventArgs e)
		{
			color_0 = office2007ColorPlate1.method_10();
		}

		private void method_1(object sender, GEventArgs6 e)
		{
			using (ColorDialog colorDialog = new ColorDialog())
			{
				colorDialog.Color = office2007ColorPlate1.method_10();
				if (colorDialog.ShowDialog(this) == DialogResult.OK)
				{
					e.method_1(colorDialog.Color);
				}
				else
				{
					e.method_3(bool_1: true);
				}
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

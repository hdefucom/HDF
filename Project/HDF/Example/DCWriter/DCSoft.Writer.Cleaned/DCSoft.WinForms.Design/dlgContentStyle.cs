using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public class dlgContentStyle : Form
	{
		private IContainer icontainer_0 = null;

		private Label lblFont;

		private Button btnFont;

		private Label lblBorderBackground;

		private Button btnBorderBackground;

		public dlgContentStyle()
		{
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.Design.dlgContentStyle));
			lblFont = new System.Windows.Forms.Label();
			btnFont = new System.Windows.Forms.Button();
			lblBorderBackground = new System.Windows.Forms.Label();
			btnBorderBackground = new System.Windows.Forms.Button();
			SuspendLayout();
			lblFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(lblFont, "lblFont");
			lblFont.Name = "lblFont";
			resources.ApplyResources(btnFont, "btnFont");
			btnFont.Name = "btnFont";
			btnFont.UseVisualStyleBackColor = true;
			lblBorderBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(lblBorderBackground, "lblBorderBackground");
			lblBorderBackground.Name = "lblBorderBackground";
			resources.ApplyResources(btnBorderBackground, "btnBorderBackground");
			btnBorderBackground.Name = "btnBorderBackground";
			btnBorderBackground.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnBorderBackground);
			base.Controls.Add(btnFont);
			base.Controls.Add(lblBorderBackground);
			base.Controls.Add(lblFont);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgContentStyle";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
		}
	}
}

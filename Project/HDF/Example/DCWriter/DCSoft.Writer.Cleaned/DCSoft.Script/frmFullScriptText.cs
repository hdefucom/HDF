using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Script
{
	[ComVisible(false)]
	public class frmFullScriptText : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtScript;

		public string ScriptText
		{
			get
			{
				return txtScript.Text;
			}
			set
			{
				txtScript.Text = value;
			}
		}

		public frmFullScriptText()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Script.frmFullScriptText));
			txtScript = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(txtScript, "txtScript");
			txtScript.Name = "txtScript";
			txtScript.ReadOnly = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtScript);
			base.MinimizeBox = false;
			base.Name = "frmFullScriptText";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

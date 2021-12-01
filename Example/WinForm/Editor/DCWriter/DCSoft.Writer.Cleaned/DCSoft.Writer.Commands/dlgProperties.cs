using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档选项对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgProperties : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnOK;

		private PropertyGrid pgGridLine;

		private object object_0 = null;

		/// <summary>
		///       当前对象
		///       </summary>
		public object ObjectInstance
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgProperties));
			btnOK = new System.Windows.Forms.Button();
			pgGridLine = new System.Windows.Forms.PropertyGrid();
			SuspendLayout();
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(pgGridLine, "pgGridLine");
			pgGridLine.Name = "pgGridLine";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(pgGridLine);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgProperties";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgProperties_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgProperties()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgProperties_Load(object sender, EventArgs e)
		{
			pgGridLine.SelectedObject = ObjectInstance;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

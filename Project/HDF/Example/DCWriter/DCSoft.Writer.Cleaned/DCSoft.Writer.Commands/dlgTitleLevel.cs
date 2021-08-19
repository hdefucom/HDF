using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       标题层次窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgTitleLevel : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private ListBox lstLevel;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       标题等级
		///       </summary>
		public int TitleLevel
		{
			get
			{
				return lstLevel.SelectedIndex - 1;
			}
			set
			{
				if (value + 1 >= 0 && value + 1 < lstLevel.Items.Count)
				{
					lstLevel.SelectedIndex = value + 1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgTitleLevel));
			label1 = new System.Windows.Forms.Label();
			lstLevel = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(lstLevel, "lstLevel");
			lstLevel.FormattingEnabled = true;
			lstLevel.Items.AddRange(new object[9]
			{
				resources.GetString("lstLevel.Items"),
				resources.GetString("lstLevel.Items1"),
				resources.GetString("lstLevel.Items2"),
				resources.GetString("lstLevel.Items3"),
				resources.GetString("lstLevel.Items4"),
				resources.GetString("lstLevel.Items5"),
				resources.GetString("lstLevel.Items6"),
				resources.GetString("lstLevel.Items7"),
				resources.GetString("lstLevel.Items8")
			});
			lstLevel.Name = "lstLevel";
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
			base.Controls.Add(lstLevel);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTitleLevel";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgTitleLevel_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgTitleLevel()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgTitleLevel_Load(object sender, EventArgs e)
		{
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

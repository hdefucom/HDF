using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgStringList : Form
	{
		private IContainer icontainer_0 = null;

		private ComboBox cboItems;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       包含项的集合
		///       </summary>
		public ComboBox.ObjectCollection ListItems => cboItems.Items;

		/// <summary>
		///       选择的文本
		///       </summary>
		public string SelectedText
		{
			get
			{
				return cboItems.Text;
			}
			set
			{
				cboItems.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgStringList()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgStringList_Load(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgStringList));
			cboItems = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			cboItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			resources.ApplyResources(cboItems, "cboItems");
			cboItems.FormattingEnabled = true;
			cboItems.Name = "cboItems";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboItems);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgStringList";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgStringList_Load);
			ResumeLayout(false);
		}
	}
}

using DCSoft.Writer.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       编辑知识节点对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgEditKBEntry : Form
	{
		private KBEntry kbentry_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtText;

		private Label label3;

		private ComboBox cboOwnerLevel;

		private Label label4;

		private Button btnCancel;

		private Button btnOK;

		private DataGridView dgvItems;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		/// <summary>
		///       知识节点对象
		///       </summary>
		public KBEntry KBEntry
		{
			get
			{
				return kbentry_0;
			}
			set
			{
				kbentry_0 = value;
			}
		}

		/// <summary>
		///       知识节点编号是否只读
		///       </summary>
		public bool KBEntryIDReadonly
		{
			get
			{
				return txtID.ReadOnly;
			}
			set
			{
				txtID.ReadOnly = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgEditKBEntry()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgEditKBEntry_Load(object sender, EventArgs e)
		{
			if (KBEntry != null)
			{
				txtID.Text = KBEntry.ID;
				txtText.Text = KBEntry.Text;
				cboOwnerLevel.SelectedIndex = (int)KBEntry.OwnerLevel;
				if (KBEntry.ListItems != null)
				{
					foreach (ListItem listItem in KBEntry.ListItems)
					{
						dgvItems.Rows.Add(listItem.Text, listItem.Value);
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (KBEntry != null)
			{
				kbentry_0.ID = txtID.Text.Trim();
				kbentry_0.Text = txtText.Text.Trim();
				kbentry_0.OwnerLevel = (EntryOwnerLevel)cboOwnerLevel.SelectedIndex;
				kbentry_0.ListItems = new ListItemCollection();
				foreach (DataGridViewRow item in (IEnumerable)dgvItems.Rows)
				{
					if (item.Index != dgvItems.NewRowIndex)
					{
						ListItem listItem = new ListItem();
						listItem.Text = Convert.ToString(item.Cells[0].Value);
						listItem.Value = Convert.ToString(item.Cells[1].Value);
						kbentry_0.ListItems.Add(listItem);
					}
				}
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgEditKBEntry));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			cboOwnerLevel = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			dgvItems = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtText, "txtText");
			txtText.Name = "txtText";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboOwnerLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboOwnerLevel.FormattingEnabled = true;
			cboOwnerLevel.Items.AddRange(new object[3]
			{
				resources.GetString("cboOwnerLevel.Items"),
				resources.GetString("cboOwnerLevel.Items1"),
				resources.GetString("cboOwnerLevel.Items2")
			});
			resources.ApplyResources(cboOwnerLevel, "cboOwnerLevel");
			cboOwnerLevel.Name = "cboOwnerLevel";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvItems.Columns.AddRange(Column1, Column2);
			resources.ApplyResources(dgvItems, "dgvItems");
			dgvItems.Name = "dgvItems";
			dgvItems.RowTemplate.Height = 23;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvItems);
			base.Controls.Add(cboOwnerLevel);
			base.Controls.Add(txtText);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgEditKBEntry";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgEditKBEntry_Load);
			((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

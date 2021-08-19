using DCSoft.Writer.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       插入知识库节点
	///       </summary>
	[ComVisible(false)]
	public class dlgInsertKBEntryByContent : Form
	{
		private WriterAppHost writerAppHost_0 = WriterAppHost.Default;

		private KBEntry kbentry_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TreeView tvwKB;

		private Label label2;

		private TextBox txtID;

		private Label label3;

		private TextBox txtName;

		private Label label4;

		private DataGridView dgvItems;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private Button btnOK;

		private Button btnCancel;

		private ComboBox cboOwnerLevel;

		private Label label5;

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		public WriterAppHost AppHost
		{
			get
			{
				return writerAppHost_0;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       新增的知识库节点对象
		///       </summary>
		public KBEntry NewKBEntry
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
		///       初始化对象
		///       </summary>
		public dlgInsertKBEntryByContent()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertKBEntryByContent_Load(object sender, EventArgs e)
		{
			cboOwnerLevel.SelectedIndex = 0;
			AppHost.KBLibrary?.Fill(tvwKB);
			if (NewKBEntry != null)
			{
				txtID.Text = NewKBEntry.ID;
				txtName.Text = NewKBEntry.Text;
				if (NewKBEntry.ListItems.Count > 0)
				{
					foreach (ListItem listItem in NewKBEntry.ListItems)
					{
						dgvItems.Rows.Add(listItem.Text, listItem.Value);
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			KBEntry kBEntry = NewKBEntry;
			if (kBEntry == null)
			{
				kBEntry = new KBEntry();
			}
			kBEntry.ID = txtID.Text.Trim();
			kBEntry.Text = txtName.Text.Trim();
			kBEntry.RecordState = DataRowState.Added;
			kBEntry.OwnerLevel = (EntryOwnerLevel)cboOwnerLevel.SelectedIndex;
			kBEntry.ListItems = new ListItemCollection();
			foreach (DataGridViewRow item in (IEnumerable)dgvItems.Rows)
			{
				if (item.Index != dgvItems.NewRowIndex)
				{
					ListItem listItem = new ListItem();
					listItem.Text = Convert.ToString(item.Cells[0].Value);
					listItem.Value = Convert.ToString(item.Cells[1].Value);
					kBEntry.ListItems.Add(listItem);
				}
			}
			KBEntry kBEntry2 = null;
			if (tvwKB.SelectedNode != null)
			{
				kBEntry2 = (KBEntry)tvwKB.SelectedNode.Tag;
				if (kBEntry2 != null)
				{
					if (kBEntry2.SubEntries == null)
					{
						kBEntry2.SubEntries = new KBEntryList();
					}
					kBEntry2.SubEntries.Add(kBEntry);
					kBEntry.Parent = kBEntry2;
				}
			}
			else
			{
				AppHost.KBLibrary?.KBEntries.Add(kBEntry);
			}
			kbentry_0 = kBEntry;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgInsertKBEntryByContent));
			label1 = new System.Windows.Forms.Label();
			tvwKB = new System.Windows.Forms.TreeView();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			dgvItems = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			cboOwnerLevel = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			tvwKB.HideSelection = false;
			resources.ApplyResources(tvwKB, "tvwKB");
			tvwKB.Name = "tvwKB";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvItems.Columns.AddRange(Column1, Column2);
			resources.ApplyResources(dgvItems, "dgvItems");
			dgvItems.Name = "dgvItems";
			dgvItems.RowTemplate.Height = 23;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
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
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cboOwnerLevel);
			base.Controls.Add(label5);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvItems);
			base.Controls.Add(label4);
			base.Controls.Add(txtName);
			base.Controls.Add(label3);
			base.Controls.Add(txtID);
			base.Controls.Add(label2);
			base.Controls.Add(tvwKB);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertKBEntryByContent";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInsertKBEntryByContent_Load);
			((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

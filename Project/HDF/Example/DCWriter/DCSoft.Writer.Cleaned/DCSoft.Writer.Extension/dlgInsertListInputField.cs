using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       插入列表输入域
	///       </summary>
	[ComVisible(false)]
	public class dlgInsertListInputField : Form
	{
		private XTextInputFieldElement xtextInputFieldElement_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private bool bool_0 = false;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtName;

		private CheckBox chkUserEditable;

		private Label label3;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkMulitiSelect;

		private Button btnFixText;

		private CheckBox chkUserDeleteable;

		private DataGridView dgvDataSource;

		private CheckBox chkRepulsionForGroup;

		private DataGridViewTextBoxColumn dgvText;

		private DataGridViewTextBoxColumn dgvValue;

		private DataGridViewTextBoxColumn dgvRepulsionForGroup;

		/// <summary>
		///       输入域对象
		///       </summary>
		public XTextInputFieldElement FieldElement
		{
			get
			{
				return xtextInputFieldElement_0;
			}
			set
			{
				xtextInputFieldElement_0 = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       是否记录撤销操作信息
		///       </summary>
		public bool LogUndo
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

		public static bool smethod_0(XTextInputFieldElement xtextInputFieldElement_1)
		{
			if (xtextInputFieldElement_1 == null || xtextInputFieldElement_1.FieldSettings == null)
			{
				return false;
			}
			return xtextInputFieldElement_1.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInsertListInputField()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertListInputField_Load(object sender, EventArgs e)
		{
			if (xtextInputFieldElement_0 != null)
			{
				txtID.Text = xtextInputFieldElement_0.ID;
				txtName.Text = xtextInputFieldElement_0.Name;
				chkUserEditable.Checked = xtextInputFieldElement_0.UserEditable;
				chkUserDeleteable.Checked = xtextInputFieldElement_0.Deleteable;
				if (xtextInputFieldElement_0.FieldSettings != null)
				{
					chkMulitiSelect.Checked = xtextInputFieldElement_0.FieldSettings.MultiSelect;
					chkRepulsionForGroup.Checked = xtextInputFieldElement_0.FieldSettings.RepulsionForGroup;
				}
				if (xtextInputFieldElement_0.FieldSettings != null && xtextInputFieldElement_0.FieldSettings.ListSource != null && xtextInputFieldElement_0.FieldSettings.ListSource.Items != null)
				{
					dgvDataSource.Rows.Clear();
					foreach (ListItem item in xtextInputFieldElement_0.FieldSettings.ListSource.Items)
					{
						if (!string.IsNullOrEmpty(item.Text))
						{
							DataGridViewRow dataGridViewRow = new DataGridViewRow();
							DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
							dataGridViewTextBoxCell.Value = item.Text;
							dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
							DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
							dataGridViewTextBoxCell2.Value = item.Value;
							dataGridViewRow.Cells.Add(dataGridViewTextBoxCell2);
							DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
							dataGridViewTextBoxCell3.Value = item.Group;
							dataGridViewRow.Cells.Add(dataGridViewTextBoxCell3);
							dgvDataSource.Rows.Add(dataGridViewRow);
						}
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 15;
			XTextDocument xTextDocument = Document;
			if (xTextDocument == null && FieldElement != null)
			{
				xTextDocument = FieldElement.OwnerDocument;
			}
			if (xTextDocument != null)
			{
				if (xtextInputFieldElement_0 == null)
				{
					xtextInputFieldElement_0 = (XTextInputFieldElement)xTextDocument.CreateElementByType(typeof(XTextInputFieldElement));
				}
				bool flag = LogUndo && xTextDocument != null && xTextDocument.CanLogUndo;
				if (txtID.Text != xtextInputFieldElement_0.ID)
				{
					if (flag)
					{
						xTextDocument.UndoList.AddProperty("ID", txtID.Text, xtextInputFieldElement_0.ID, xtextInputFieldElement_0);
					}
					xtextInputFieldElement_0.ID = txtID.Text;
				}
				if (xtextInputFieldElement_0.Name != txtName.Text)
				{
					if (flag)
					{
						xTextDocument.UndoList.AddProperty("Name", txtName.Text, xtextInputFieldElement_0.Name, xtextInputFieldElement_0);
						xTextDocument.UndoList.AddProperty("BackgroundText", txtName.Text, xtextInputFieldElement_0.BackgroundText, xtextInputFieldElement_0);
					}
					xtextInputFieldElement_0.Name = txtName.Text;
					xtextInputFieldElement_0.BackgroundText = txtName.Text;
				}
				if (xtextInputFieldElement_0.UserEditable != chkUserEditable.Checked)
				{
					if (flag)
					{
						xTextDocument.UndoList.AddProperty("UserEditable", chkUserEditable.Checked, xtextInputFieldElement_0.UserEditable, xtextInputFieldElement_0);
					}
					xtextInputFieldElement_0.UserEditable = chkUserEditable.Checked;
				}
				if (xtextInputFieldElement_0.Deleteable != chkUserDeleteable.Checked)
				{
					if (flag)
					{
						xTextDocument.UndoList.AddProperty("Deleteable", chkUserDeleteable.Checked, xtextInputFieldElement_0.Deleteable, xtextInputFieldElement_0);
					}
					xtextInputFieldElement_0.Deleteable = chkUserDeleteable.Checked;
				}
				if (xtextInputFieldElement_0.FieldSettings == null)
				{
					xtextInputFieldElement_0.FieldSettings = new InputFieldSettings();
				}
				if (dgvDataSource.Rows.Count > 0)
				{
					method_0();
				}
				if (chkMulitiSelect.Checked)
				{
					xtextInputFieldElement_0.FieldSettings.MultiSelect = true;
				}
				else
				{
					xtextInputFieldElement_0.FieldSettings.MultiSelect = false;
				}
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void method_0()
		{
			if (xtextInputFieldElement_0.FieldSettings.ListSource == null)
			{
				xtextInputFieldElement_0.FieldSettings.ListSource = new ListSourceInfo();
			}
			if (xtextInputFieldElement_0.FieldSettings.ListSource.Items == null)
			{
				xtextInputFieldElement_0.FieldSettings.ListSource.Items = new ListItemCollection();
			}
			xtextInputFieldElement_0.FieldSettings.ListSource.Items = new ListItemCollection();
			xtextInputFieldElement_0.FieldSettings.RepulsionForGroup = chkRepulsionForGroup.Checked;
			for (int i = 0; i < dgvDataSource.Rows.Count - 1; i++)
			{
				ListItem listItem = new ListItem();
				object value = dgvDataSource.Rows[i].Cells[0].Value;
				if (value != null)
				{
					listItem.Text = value.ToString();
				}
				object value2 = dgvDataSource.Rows[i].Cells[1].Value;
				if (value2 != null)
				{
					listItem.Value = value2.ToString();
				}
				else
				{
					listItem.Value = listItem.Text;
				}
				object value3 = dgvDataSource.Rows[i].Cells[2].Value;
				if (value3 != null)
				{
					listItem.Group = value3.ToString();
				}
				xtextInputFieldElement_0.FieldSettings.ListSource.Items.Add(listItem);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnFixText_Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgInsertListInputField));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			chkUserEditable = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkMulitiSelect = new System.Windows.Forms.CheckBox();
			btnFixText = new System.Windows.Forms.Button();
			chkUserDeleteable = new System.Windows.Forms.CheckBox();
			dgvDataSource = new System.Windows.Forms.DataGridView();
			dgvText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			dgvValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			dgvRepulsionForGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			chkRepulsionForGroup = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)dgvDataSource).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(chkUserEditable, "chkUserEditable");
			chkUserEditable.Name = "chkUserEditable";
			chkUserEditable.UseVisualStyleBackColor = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(chkMulitiSelect, "chkMulitiSelect");
			chkMulitiSelect.Name = "chkMulitiSelect";
			chkMulitiSelect.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnFixText, "btnFixText");
			btnFixText.Name = "btnFixText";
			btnFixText.UseVisualStyleBackColor = true;
			btnFixText.Click += new System.EventHandler(btnFixText_Click);
			resources.ApplyResources(chkUserDeleteable, "chkUserDeleteable");
			chkUserDeleteable.Name = "chkUserDeleteable";
			chkUserDeleteable.UseVisualStyleBackColor = true;
			dgvDataSource.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dgvDataSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvDataSource.Columns.AddRange(dgvText, dgvValue, dgvRepulsionForGroup);
			resources.ApplyResources(dgvDataSource, "dgvDataSource");
			dgvDataSource.Name = "dgvDataSource";
			dgvDataSource.RowTemplate.Height = 23;
			resources.ApplyResources(dgvText, "dgvText");
			dgvText.Name = "dgvText";
			resources.ApplyResources(dgvValue, "dgvValue");
			dgvValue.Name = "dgvValue";
			resources.ApplyResources(dgvRepulsionForGroup, "dgvRepulsionForGroup");
			dgvRepulsionForGroup.Name = "dgvRepulsionForGroup";
			resources.ApplyResources(chkRepulsionForGroup, "chkRepulsionForGroup");
			chkRepulsionForGroup.Name = "chkRepulsionForGroup";
			chkRepulsionForGroup.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(chkRepulsionForGroup);
			base.Controls.Add(dgvDataSource);
			base.Controls.Add(chkUserDeleteable);
			base.Controls.Add(btnFixText);
			base.Controls.Add(chkMulitiSelect);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label3);
			base.Controls.Add(chkUserEditable);
			base.Controls.Add(txtName);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertListInputField";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInsertListInputField_Load);
			((System.ComponentModel.ISupportInitialize)dgvDataSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

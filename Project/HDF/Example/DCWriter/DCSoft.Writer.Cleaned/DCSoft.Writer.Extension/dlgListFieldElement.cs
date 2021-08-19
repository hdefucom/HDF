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
	///       下拉框
	///       </summary>
	[ComVisible(false)]
	public class dlgListFieldElement : Form
	{
		private XTextInputFieldElement xtextInputFieldElement_0;

		private IContainer icontainer_0 = null;

		private Button btnDeleteSourceData;

		private DataGridView dgvDataSource;

		private CheckBox chkMostSelect;

		private Button btnCancel;

		private Button btnOK;

		private CheckBox chkUserEditable;

		private CheckBox chkDeleteable;

		private CheckBox chkReadonly;

		private TextBox txtID;

		private Label label6;

		private TextBox txtBackgroundText;

		private Label label9;

		private TextBox txtToolTip;

		private Label label8;

		private TextBox txtName;

		private Label label16;

		private DataGridViewTextBoxColumn dgvText;

		private DataGridViewTextBoxColumn dgvValue;

		/// <summary>
		///       输入域对象
		///       </summary>
		public XTextInputFieldElement InputFieldElement
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
		///       初始化对象
		///       </summary>
		public dlgListFieldElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtID.Text))
			{
				xtextInputFieldElement_0.ID = txtID.Text;
			}
			if (!string.IsNullOrEmpty(txtName.Text))
			{
				xtextInputFieldElement_0.Name = txtName.Text;
			}
			if (!string.IsNullOrEmpty(txtToolTip.Text))
			{
				xtextInputFieldElement_0.ToolTip = txtToolTip.Text;
			}
			if (!string.IsNullOrEmpty(txtBackgroundText.Text))
			{
				xtextInputFieldElement_0.BackgroundText = txtBackgroundText.Text;
			}
			if (chkReadonly.Checked)
			{
				xtextInputFieldElement_0.ContentReadonly = ContentReadonlyState.False;
			}
			else
			{
				xtextInputFieldElement_0.ContentReadonly = ContentReadonlyState.Inherit;
			}
			if (chkDeleteable.Checked)
			{
				xtextInputFieldElement_0.Deleteable = true;
			}
			else
			{
				xtextInputFieldElement_0.Deleteable = false;
			}
			if (chkUserEditable.Checked)
			{
				xtextInputFieldElement_0.UserEditable = true;
			}
			else
			{
				xtextInputFieldElement_0.UserEditable = false;
			}
			if (xtextInputFieldElement_0.FieldSettings == null)
			{
				xtextInputFieldElement_0.FieldSettings = new InputFieldSettings();
			}
			if (dgvDataSource.Rows.Count > 0)
			{
				method_0();
			}
			if (chkMostSelect.Checked)
			{
				xtextInputFieldElement_0.FieldSettings.MultiSelect = true;
			}
			else
			{
				xtextInputFieldElement_0.FieldSettings.MultiSelect = false;
			}
			xtextInputFieldElement_0.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void method_0()
		{
			int num = 7;
			if (xtextInputFieldElement_0.FieldSettings.ListSource == null)
			{
				xtextInputFieldElement_0.FieldSettings.ListSource = new ListSourceInfo();
			}
			if (xtextInputFieldElement_0.FieldSettings.ListSource.Items == null)
			{
				xtextInputFieldElement_0.FieldSettings.ListSource.Items = new ListItemCollection();
			}
			for (int i = 0; i < dgvDataSource.Rows.Count - 1; i++)
			{
				ListItem listItem = new ListItem();
				object value = dgvDataSource.Rows[i].Cells["dgvText"].Value;
				if (value != null)
				{
					listItem.Text = value.ToString();
				}
				object value2 = dgvDataSource.Rows[i].Cells["dgvValue"].Value;
				if (value2 != null)
				{
					listItem.Value = value2.ToString();
				}
				xtextInputFieldElement_0.FieldSettings.ListSource.Items.Add(listItem);
			}
		}

		private void btnDeleteSourceData_Click(object sender, EventArgs e)
		{
			DataGridViewRow currentRow = dgvDataSource.CurrentRow;
			if (!(currentRow?.IsNewRow ?? true))
			{
				dgvDataSource.Rows.Remove(currentRow);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgListFieldElement_Load(object sender, EventArgs e)
		{
			if (xtextInputFieldElement_0 == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(xtextInputFieldElement_0.ID))
			{
				txtID.Text = xtextInputFieldElement_0.ID;
			}
			if (!string.IsNullOrEmpty(xtextInputFieldElement_0.Name))
			{
				txtName.Text = xtextInputFieldElement_0.Name;
			}
			if (!string.IsNullOrEmpty(xtextInputFieldElement_0.BackgroundText))
			{
				txtBackgroundText.Text = xtextInputFieldElement_0.BackgroundText;
			}
			if (!string.IsNullOrEmpty(xtextInputFieldElement_0.ToolTip))
			{
				txtToolTip.Text = xtextInputFieldElement_0.ToolTip;
			}
			if (xtextInputFieldElement_0.RuntimeContentReadonly)
			{
				chkReadonly.Checked = true;
			}
			else
			{
				chkReadonly.Checked = false;
			}
			if (xtextInputFieldElement_0.Deleteable)
			{
				chkDeleteable.Checked = true;
			}
			else
			{
				chkDeleteable.Checked = false;
			}
			if (xtextInputFieldElement_0.UserEditable)
			{
				chkUserEditable.Checked = true;
			}
			else
			{
				chkUserEditable.Checked = false;
			}
			if (xtextInputFieldElement_0.FieldSettings != null)
			{
				if (xtextInputFieldElement_0.FieldSettings.MultiSelect)
				{
					chkMostSelect.Checked = true;
				}
				else
				{
					chkMostSelect.Checked = false;
				}
				if (xtextInputFieldElement_0.FieldSettings.ListSource != null)
				{
					dgvDataSource.DataSource = xtextInputFieldElement_0.FieldSettings.ListSource;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgListFieldElement));
			btnDeleteSourceData = new System.Windows.Forms.Button();
			dgvDataSource = new System.Windows.Forms.DataGridView();
			dgvText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			dgvValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			chkMostSelect = new System.Windows.Forms.CheckBox();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			chkUserEditable = new System.Windows.Forms.CheckBox();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			chkReadonly = new System.Windows.Forms.CheckBox();
			txtID = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			txtBackgroundText = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			txtToolTip = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dgvDataSource).BeginInit();
			SuspendLayout();
			resources.ApplyResources(btnDeleteSourceData, "btnDeleteSourceData");
			btnDeleteSourceData.Name = "btnDeleteSourceData";
			btnDeleteSourceData.UseVisualStyleBackColor = true;
			btnDeleteSourceData.Click += new System.EventHandler(btnDeleteSourceData_Click);
			dgvDataSource.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dgvDataSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvDataSource.Columns.AddRange(dgvText, dgvValue);
			resources.ApplyResources(dgvDataSource, "dgvDataSource");
			dgvDataSource.Name = "dgvDataSource";
			dgvDataSource.RowTemplate.Height = 23;
			dgvText.DataPropertyName = "Text";
			resources.ApplyResources(dgvText, "dgvText");
			dgvText.Name = "dgvText";
			dgvValue.DataPropertyName = "Value";
			resources.ApplyResources(dgvValue, "dgvValue");
			dgvValue.Name = "dgvValue";
			resources.ApplyResources(chkMostSelect, "chkMostSelect");
			chkMostSelect.Name = "chkMostSelect";
			chkMostSelect.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(chkUserEditable, "chkUserEditable");
			chkUserEditable.Name = "chkUserEditable";
			chkUserEditable.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkReadonly, "chkReadonly");
			chkReadonly.Name = "chkReadonly";
			chkReadonly.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtBackgroundText, "txtBackgroundText");
			txtBackgroundText.Name = "txtBackgroundText";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(txtToolTip, "txtToolTip");
			txtToolTip.Name = "txtToolTip";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(label16, "label16");
			label16.Name = "label16";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnDeleteSourceData);
			base.Controls.Add(dgvDataSource);
			base.Controls.Add(chkMostSelect);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkUserEditable);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(chkReadonly);
			base.Controls.Add(txtID);
			base.Controls.Add(label6);
			base.Controls.Add(txtBackgroundText);
			base.Controls.Add(label9);
			base.Controls.Add(txtToolTip);
			base.Controls.Add(label8);
			base.Controls.Add(txtName);
			base.Controls.Add(label16);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "dlgListFieldElement";
			base.Load += new System.EventHandler(dlgListFieldElement_Load);
			((System.ComponentModel.ISupportInitialize)dgvDataSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

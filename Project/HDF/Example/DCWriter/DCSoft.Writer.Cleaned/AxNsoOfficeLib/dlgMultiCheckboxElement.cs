using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>
	                                                                    ///       下拉框
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class dlgMultiCheckboxElement : Form
	{
		private XTextInputFieldElement xtextInputFieldElement_0;

		private IContainer icontainer_0 = null;

		private Button btnDeleteSourceData;

		private DataGridView dgvDataSource;

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

		private CheckBox chkShowAsCheckbox;

		private CheckBox chkRequired;

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
		public dlgMultiCheckboxElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 2;
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
			xtextInputFieldElement_0.Elements.Clear();
			xtextInputFieldElement_0.SetAttribute("RadioButtonShowType", Convert.ToString(!chkShowAsCheckbox.Checked).ToLower());
			xtextInputFieldElement_0.SetAttribute("Requried", chkRequired.Checked.ToString().ToLower());
			if (dgvDataSource.Rows.Count > 0)
			{
				for (int i = 0; i < dgvDataSource.Rows.Count; i++)
				{
					if (i == dgvDataSource.NewRowIndex)
					{
						continue;
					}
					string text = Convert.ToString(dgvDataSource.Rows[i].Cells[0].Value);
					string checkedValue = Convert.ToString(dgvDataSource.Rows[i].Cells[1].Value);
					if (!string.IsNullOrEmpty(text))
					{
						XTextCheckBoxElement xTextCheckBoxElement = new XTextCheckBoxElement();
						xTextCheckBoxElement.Caption = text;
						xTextCheckBoxElement.CheckedValue = checkedValue;
						xTextCheckBoxElement.ID = xtextInputFieldElement_0.ID + "_" + i;
						xTextCheckBoxElement.Name = xtextInputFieldElement_0.Name;
						xTextCheckBoxElement.Requried = chkRequired.Checked;
						xTextCheckBoxElement.SetAttribute("MultiCheckboxItem", "1");
						if (chkShowAsCheckbox.Checked)
						{
							xTextCheckBoxElement.VisualStyle = CheckBoxVisualStyle.SystemDefault;
						}
						else
						{
							xTextCheckBoxElement.VisualStyle = CheckBoxVisualStyle.SystemRadioBox;
						}
						xtextInputFieldElement_0.Elements.Add(xTextCheckBoxElement);
					}
				}
			}
			xtextInputFieldElement_0.FieldSettings = null;
			base.DialogResult = DialogResult.OK;
			Close();
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

		private void dlgMultiCheckboxElement_Load(object sender, EventArgs e)
		{
			int num = 1;
			if (xtextInputFieldElement_0 != null)
			{
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
				chkShowAsCheckbox.Checked = (xtextInputFieldElement_0.GetAttribute("RadioButtonShowType") != "true");
				chkRequired.Checked = (xtextInputFieldElement_0.GetAttribute("Requried") == "true");
				bool flag = true;
				foreach (XTextElement element in xtextInputFieldElement_0.Elements)
				{
					if (element is XTextCheckBoxElement)
					{
						XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)element;
						dgvDataSource.Rows.Add(xTextCheckBoxElement.Caption, xTextCheckBoxElement.CheckedValue);
						if (flag)
						{
							flag = false;
						}
					}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxNsoOfficeLib.dlgMultiCheckboxElement));
			btnDeleteSourceData = new System.Windows.Forms.Button();
			dgvDataSource = new System.Windows.Forms.DataGridView();
			dgvText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			dgvValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			chkShowAsCheckbox = new System.Windows.Forms.CheckBox();
			chkRequired = new System.Windows.Forms.CheckBox();
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
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
			resources.ApplyResources(chkShowAsCheckbox, "chkShowAsCheckbox");
			chkShowAsCheckbox.Name = "chkShowAsCheckbox";
			chkShowAsCheckbox.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkRequired, "chkRequired");
			chkRequired.Name = "chkRequired";
			chkRequired.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnDeleteSourceData);
			base.Controls.Add(dgvDataSource);
			base.Controls.Add(chkShowAsCheckbox);
			base.Controls.Add(chkRequired);
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
			base.Name = "dlgMultiCheckboxElement";
			base.Load += new System.EventHandler(dlgMultiCheckboxElement_Load);
			((System.ComponentModel.ISupportInitialize)dgvDataSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

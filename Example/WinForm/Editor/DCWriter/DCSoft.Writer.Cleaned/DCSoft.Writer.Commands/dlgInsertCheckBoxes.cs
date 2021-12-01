using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       插入多个单选框、复选框
	///       </summary>
	[ComVisible(false)]
	public class dlgInsertCheckBoxes : Form
	{
		private XTextDocument xtextDocument_0 = null;

		private XTextElementList xtextElementList_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtName;

		private CheckBox chkCheckAlignLeft;

		private CheckBox chkDeleteable;

		private DataGridView dgvRows;

		private GroupBox groupBox1;

		private RadioButton rdoRadio;

		private Label label3;

		private ComboBox cboVisualStyle;

		private CheckBox chkMultiline;

		private Button btnOK;

		private Button btnCancel;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private RadioButton rdoCheckbox;

		private CheckBox chkRequired;

		private GroupBox groupBox2;

		/// <summary>
		///       操作的文档对象
		///       </summary>
		public XTextDocument OwnerDocument
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
		///       操作结果
		///       </summary>
		public XTextElementList ResultElements
		{
			get
			{
				return xtextElementList_0;
			}
			set
			{
				xtextElementList_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInsertCheckBoxes()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertCheckBoxes_Load(object sender, EventArgs e)
		{
			cboVisualStyle.SelectedIndex = 3;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 6;
			xtextElementList_0 = new XTextElementList();
			int num2 = 0;
			string text = txtName.Text.Trim();
			foreach (DataGridViewRow item in (IEnumerable)dgvRows.Rows)
			{
				if (item.Index != dgvRows.NewRowIndex)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = null;
					xTextCheckBoxElementBase = ((!rdoRadio.Checked) ? ((XTextCheckBoxElementBase)OwnerDocument.CreateElementByType(typeof(XTextCheckBoxElement))) : ((XTextCheckBoxElementBase)OwnerDocument.CreateElementByType(typeof(XTextRadioBoxElement))));
					if (xTextCheckBoxElementBase != null)
					{
						string text2 = Convert.ToString(item.Cells[0].Value);
						string text3 = Convert.ToString(item.Cells[1].Value);
						if (!string.IsNullOrEmpty(text2) || !string.IsNullOrEmpty(text3))
						{
							if (string.IsNullOrEmpty(text3))
							{
								text3 = text2;
							}
							xTextCheckBoxElementBase.Name = text;
							xTextCheckBoxElementBase.ID = text + "_" + num2;
							xTextCheckBoxElementBase.Caption = text2;
							xTextCheckBoxElementBase.CheckedValue = text3;
							xTextCheckBoxElementBase.Deleteable = chkDeleteable.Checked;
							xTextCheckBoxElementBase.Multiline = chkMultiline.Checked;
							xTextCheckBoxElementBase.CheckAlignLeft = chkCheckAlignLeft.Checked;
							xTextCheckBoxElementBase.VisualStyle = (CheckBoxVisualStyle)cboVisualStyle.SelectedIndex;
							xTextCheckBoxElementBase.Requried = chkRequired.Checked;
							xtextElementList_0.Add(xTextCheckBoxElementBase);
							num2++;
						}
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
			label1 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			chkCheckAlignLeft = new System.Windows.Forms.CheckBox();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			dgvRows = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rdoCheckbox = new System.Windows.Forms.RadioButton();
			rdoRadio = new System.Windows.Forms.RadioButton();
			label3 = new System.Windows.Forms.Label();
			cboVisualStyle = new System.Windows.Forms.ComboBox();
			chkMultiline = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkRequired = new System.Windows.Forms.CheckBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)dgvRows).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 0;
			label1.Text = "名称：";
			txtName.Location = new System.Drawing.Point(63, 6);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(249, 21);
			txtName.TabIndex = 1;
			chkCheckAlignLeft.AutoSize = true;
			chkCheckAlignLeft.Checked = true;
			chkCheckAlignLeft.CheckState = System.Windows.Forms.CheckState.Checked;
			chkCheckAlignLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkCheckAlignLeft.Location = new System.Drawing.Point(106, 112);
			chkCheckAlignLeft.Name = "chkCheckAlignLeft";
			chkCheckAlignLeft.Size = new System.Drawing.Size(96, 16);
			chkCheckAlignLeft.TabIndex = 7;
			chkCheckAlignLeft.Text = "勾选框左对齐";
			chkCheckAlignLeft.UseVisualStyleBackColor = true;
			chkDeleteable.AutoSize = true;
			chkDeleteable.Checked = true;
			chkDeleteable.CheckState = System.Windows.Forms.CheckState.Checked;
			chkDeleteable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkDeleteable.Location = new System.Drawing.Point(18, 112);
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.Size = new System.Drawing.Size(72, 16);
			chkDeleteable.TabIndex = 6;
			chkDeleteable.Text = "可以删除";
			chkDeleteable.UseVisualStyleBackColor = true;
			dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvRows.Columns.AddRange(Column1, Column2);
			dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
			dgvRows.Location = new System.Drawing.Point(3, 17);
			dgvRows.Name = "dgvRows";
			dgvRows.RowTemplate.Height = 23;
			dgvRows.Size = new System.Drawing.Size(292, 217);
			dgvRows.TabIndex = 10;
			Column1.HeaderText = "文本";
			Column1.Name = "Column1";
			Column1.Width = 120;
			Column2.HeaderText = "数值";
			Column2.Name = "Column2";
			groupBox1.Controls.Add(rdoCheckbox);
			groupBox1.Controls.Add(rdoRadio);
			groupBox1.Location = new System.Drawing.Point(14, 33);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(296, 43);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			groupBox1.Text = "类型";
			rdoCheckbox.AutoSize = true;
			rdoCheckbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			rdoCheckbox.Location = new System.Drawing.Point(129, 21);
			rdoCheckbox.Name = "rdoCheckbox";
			rdoCheckbox.Size = new System.Drawing.Size(59, 16);
			rdoCheckbox.TabIndex = 1;
			rdoCheckbox.Text = "复选框";
			rdoCheckbox.UseVisualStyleBackColor = true;
			rdoRadio.AutoSize = true;
			rdoRadio.Checked = true;
			rdoRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			rdoRadio.Location = new System.Drawing.Point(24, 21);
			rdoRadio.Name = "rdoRadio";
			rdoRadio.Size = new System.Drawing.Size(59, 16);
			rdoRadio.TabIndex = 1;
			rdoRadio.TabStop = true;
			rdoRadio.Text = "单选框";
			rdoRadio.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(22, 89);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(65, 12);
			label3.TabIndex = 4;
			label3.Text = "显示样式：";
			cboVisualStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboVisualStyle.FormattingEnabled = true;
			cboVisualStyle.Items.AddRange(new object[6]
			{
				"默认样式",
				"复选框样式 ",
				"单选框样式",
				"操作系统默认样式",
				"操作系统复选框样式",
				"操作系统单选框样式"
			});
			cboVisualStyle.Location = new System.Drawing.Point(93, 86);
			cboVisualStyle.Name = "cboVisualStyle";
			cboVisualStyle.Size = new System.Drawing.Size(217, 20);
			cboVisualStyle.TabIndex = 5;
			chkMultiline.AutoSize = true;
			chkMultiline.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkMultiline.Location = new System.Drawing.Point(216, 112);
			chkMultiline.Name = "chkMultiline";
			chkMultiline.Size = new System.Drawing.Size(72, 16);
			chkMultiline.TabIndex = 8;
			chkMultiline.Text = "文本多行";
			chkMultiline.UseVisualStyleBackColor = true;
			btnOK.Location = new System.Drawing.Point(114, 399);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 11;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(213, 399);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 12;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			chkRequired.AutoSize = true;
			chkRequired.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkRequired.Location = new System.Drawing.Point(18, 134);
			chkRequired.Name = "chkRequired";
			chkRequired.Size = new System.Drawing.Size(60, 16);
			chkRequired.TabIndex = 8;
			chkRequired.Text = "必勾项";
			chkRequired.UseVisualStyleBackColor = true;
			groupBox2.Controls.Add(dgvRows);
			groupBox2.Location = new System.Drawing.Point(14, 156);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(298, 237);
			groupBox2.TabIndex = 13;
			groupBox2.TabStop = false;
			groupBox2.Text = "项目";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(327, 430);
			base.Controls.Add(groupBox2);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboVisualStyle);
			base.Controls.Add(label3);
			base.Controls.Add(groupBox1);
			base.Controls.Add(chkRequired);
			base.Controls.Add(chkMultiline);
			base.Controls.Add(chkCheckAlignLeft);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(txtName);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertCheckBoxes";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "插入多个单选框/复选框";
			base.Load += new System.EventHandler(dlgInsertCheckBoxes_Load);
			((System.ComponentModel.ISupportInitialize)dgvRows).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

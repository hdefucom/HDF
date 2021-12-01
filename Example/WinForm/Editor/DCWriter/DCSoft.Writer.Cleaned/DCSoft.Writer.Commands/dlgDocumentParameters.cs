using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑文档参数对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgDocumentParameters : Form
	{
		private IContainer icontainer_0 = null;

		private DataGridView dgvParameters;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private Button btnOK;

		private Button btnCancel;

		private Button btnListParameterNames;

		private XTextDocument xtextDocument_0 = null;

		private DocumentParameterCollection documentParameterCollection_0 = null;

		/// <summary>
		///       编辑器文档对象
		///       </summary>
		public XTextDocument InputDocument
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
		///       文档参数列表
		///       </summary>
		public DocumentParameterCollection InputParameters
		{
			get
			{
				return documentParameterCollection_0;
			}
			set
			{
				documentParameterCollection_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgDocumentParameters));
			dgvParameters = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnListParameterNames = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)dgvParameters).BeginInit();
			SuspendLayout();
			dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvParameters.Columns.AddRange(Column1, Column2);
			resources.ApplyResources(dgvParameters, "dgvParameters");
			dgvParameters.Name = "dgvParameters";
			dgvParameters.RowTemplate.Height = 23;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnListParameterNames, "btnListParameterNames");
			btnListParameterNames.Name = "btnListParameterNames";
			btnListParameterNames.UseVisualStyleBackColor = true;
			btnListParameterNames.Click += new System.EventHandler(btnListParameterNames_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnListParameterNames);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvParameters);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDocumentParameters";
			base.Load += new System.EventHandler(dlgDocumentParameters_Load);
			((System.ComponentModel.ISupportInitialize)dgvParameters).EndInit();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDocumentParameters()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgDocumentParameters_Load(object sender, EventArgs e)
		{
			if (InputParameters != null)
			{
				foreach (DocumentParameter inputParameter in InputParameters)
				{
					dgvParameters.Rows.Add(inputParameter.Name, inputParameter.Value);
				}
			}
			btnListParameterNames.Enabled = (InputDocument != null);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (InputParameters == null)
			{
				InputParameters = new DocumentParameterCollection();
			}
			else
			{
				InputParameters.Clear();
			}
			foreach (DataGridViewRow item in (IEnumerable)dgvParameters.Rows)
			{
				if (item.Index != dgvParameters.NewRowIndex)
				{
					InputParameters.SetValue(Convert.ToString(item.Cells[0].Value), Convert.ToString(item.Cells[1].Value));
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnListParameterNames_Click(object sender, EventArgs e)
		{
			if (InputDocument == null)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (XTextInputFieldElementBase item in InputDocument.GetElementsByType(typeof(XTextInputFieldElementBase)))
			{
				if (item.ValueBinding != null && !string.IsNullOrEmpty(item.ValueBinding.DataSource) && !list.Contains(item.ValueBinding.DataSource))
				{
					list.Add(item.ValueBinding.DataSource);
				}
			}
			foreach (XTextCheckBoxElement item2 in InputDocument.GetElementsByType(typeof(XTextCheckBoxElement)))
			{
				if (item2.ValueBinding != null && !string.IsNullOrEmpty(item2.ValueBinding.DataSource) && !list.Contains(item2.ValueBinding.DataSource))
				{
					list.Add(item2.ValueBinding.DataSource);
				}
			}
			if (list.Count > 0)
			{
				foreach (DataGridViewRow item3 in (IEnumerable)dgvParameters.Rows)
				{
					for (int i = 0; i < list.Count; i++)
					{
						if (string.Compare(Convert.ToString(item3.Cells[0].Value), list[i], ignoreCase: true) == 0)
						{
							list.RemoveAt(i);
							break;
						}
					}
				}
				if (list.Count > 0)
				{
					foreach (string item4 in list)
					{
						dgvParameters.Rows.Add(item4, "");
					}
				}
			}
		}
	}
}

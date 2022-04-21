using DCSoft.Common;
using DCSoft.WinForms;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom.Design
{
	/// <summary>
	///       文档元素附加的属性对话框
	///       </summary>
	
	[ComVisible(false)]
	public class dlgAttributes : Form
	{
		private IContainer icontainer_0 = null;

		private DataGridView dgvAttributes;

		private Button btnOK;

		private Button btnCancel;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewButtonColumn Column3;

		private XAttributeList xattributeList_0 = null;

		/// <summary>
		///       属性列表
		///       </summary>
		public XAttributeList InputAttributes
		{
			get
			{
				return xattributeList_0;
			}
			set
			{
				xattributeList_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Dom.Design.dlgAttributes));
			dgvAttributes = new System.Windows.Forms.DataGridView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)dgvAttributes).BeginInit();
			SuspendLayout();
			dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvAttributes.Columns.AddRange(Column1, Column2, Column3);
			resources.ApplyResources(dgvAttributes, "dgvAttributes");
			dgvAttributes.Name = "dgvAttributes";
			dgvAttributes.RowTemplate.Height = 23;
			dgvAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvAttributes_CellContentClick);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(Column3, "Column3");
			Column3.Name = "Column3";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvAttributes);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgAttributes";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgAttributes_Load);
			((System.ComponentModel.ISupportInitialize)dgvAttributes).EndInit();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgAttributes()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgAttributes_Load(object sender, EventArgs e)
		{
			int num = 4;
			if (xattributeList_0 == null)
			{
				xattributeList_0 = new XAttributeList();
			}
			dgvAttributes.Rows.Clear();
			foreach (XAttribute item in xattributeList_0)
			{
				dgvAttributes.Rows.Add(item.Name, item.Value, "...");
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			xattributeList_0.Clear();
			foreach (DataGridViewRow item in (IEnumerable)dgvAttributes.Rows)
			{
				if (item.Index != dgvAttributes.NewRowIndex)
				{
					XAttribute xAttribute = new XAttribute();
					xAttribute.Name = Convert.ToString(item.Cells[0].Value);
					xAttribute.Value = Convert.ToString(item.Cells[1].Value);
					if (xAttribute.Name != null)
					{
						xAttribute.Name = xAttribute.Name.Trim();
					}
					if (!string.IsNullOrEmpty(xAttribute.Name))
					{
						xattributeList_0.Add(xAttribute);
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

		private void dgvAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 2)
			{
				using (dlgString dlgString = new dlgString())
				{
					dlgString.InputText = Convert.ToString(dgvAttributes.Rows[e.RowIndex].Cells[1].Value);
					if (dlgString.ShowDialog(this) == DialogResult.OK)
					{
						dgvAttributes.Rows[e.RowIndex].Cells[1].Value = dlgString.InputText;
					}
				}
			}
		}
	}
}

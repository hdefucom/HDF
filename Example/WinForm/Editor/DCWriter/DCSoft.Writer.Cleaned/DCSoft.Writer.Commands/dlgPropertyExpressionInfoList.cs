using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgPropertyExpressionInfoList : Form
	{
		private object object_0 = null;

		private PropertyExpressionInfoList propertyExpressionInfoList_0 = null;

		private IContainer icontainer_0 = null;

		private DataGridView dgvItems;

		private Button btnOK;

		private Button btnCancel;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewCheckBoxColumn Column3;

		/// <summary>
		///       表达式所属对象
		///       </summary>
		public object InputOwner
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		/// <summary>
		///       表达式信息列表
		///       </summary>
		public PropertyExpressionInfoList InputInfos
		{
			get
			{
				return propertyExpressionInfoList_0;
			}
			set
			{
				propertyExpressionInfoList_0 = value;
			}
		}

		public dlgPropertyExpressionInfoList()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPropertyExpressionInfoList_Load(object sender, EventArgs e)
		{
			int num = 3;
			if (propertyExpressionInfoList_0 == null)
			{
				propertyExpressionInfoList_0 = new PropertyExpressionInfoList();
			}
			if (object_0 == null)
			{
				return;
			}
			List<string> list = new List<string>();
			PropertyInfo[] properties = object_0.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (Attribute.GetCustomAttribute(propertyInfo, typeof(MemberExpressionableAttribute), inherit: false) != null)
				{
					list.Add(propertyInfo.Name);
				}
			}
			list.Sort();
			if (list.Contains("FormulaValue"))
			{
				list.Remove("FormulaValue");
				list.Insert(0, "FormulaValue");
			}
			foreach (string item2 in list)
			{
				PropertyExpressionInfo item = propertyExpressionInfoList_0.GetItem(item2);
				dgvItems.Rows.Add(item2, (item == null) ? "" : item.Expression, item?.AllowChainReaction ?? true);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (propertyExpressionInfoList_0 == null)
			{
				propertyExpressionInfoList_0 = new PropertyExpressionInfoList();
			}
			else
			{
				propertyExpressionInfoList_0.Clear();
			}
			foreach (DataGridViewRow item in (IEnumerable)dgvItems.Rows)
			{
				if (!item.IsNewRow)
				{
					propertyExpressionInfoList_0.SetValueExt(Convert.ToString(item.Cells[0].Value), Convert.ToString(item.Cells[1].Value), Convert.ToBoolean(item.Cells[2].Value));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgPropertyExpressionInfoList));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			dgvItems = new System.Windows.Forms.DataGridView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
			SuspendLayout();
			dgvItems.AllowUserToAddRows = false;
			dgvItems.AllowUserToDeleteRows = false;
			dgvItems.AllowUserToResizeRows = false;
			resources.ApplyResources(dgvItems, "dgvItems");
			dgvItems.BackgroundColor = System.Drawing.SystemColors.Control;
			dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvItems.Columns.AddRange(Column1, Column2, Column3);
			dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			dgvItems.Name = "dgvItems";
			dgvItems.RowHeadersVisible = false;
			dgvItems.RowTemplate.Height = 23;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			Column1.DefaultCellStyle = dataGridViewCellStyle;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(Column3, "Column3");
			Column3.Name = "Column3";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvItems);
			base.MinimizeBox = false;
			base.Name = "dlgPropertyExpressionInfoList";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPropertyExpressionInfoList_Load);
			((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
			ResumeLayout(false);
		}
	}
}

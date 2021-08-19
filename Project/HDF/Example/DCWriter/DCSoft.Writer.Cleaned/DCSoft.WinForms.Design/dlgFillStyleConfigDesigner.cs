using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public class dlgFillStyleConfigDesigner : Form
	{
		private GClass441 gclass441_0 = null;

		private IContainer icontainer_0 = null;

		private ListBox lstItems;

		private Button btnAdd;

		private Button btnRemove;

		private Button btnOK;

		private Button btnCancel;

		private Button btnEdit;

		private TextBox txtSettings;

		public GClass441 InputListItems
		{
			get
			{
				return gclass441_0;
			}
			set
			{
				gclass441_0 = value;
			}
		}

		public dlgFillStyleConfigDesigner()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgFillStyleConfigDesigner_Load(object sender, EventArgs e)
		{
			if (gclass441_0 == null)
			{
				gclass441_0 = new GClass441();
			}
			gclass441_0.method_3(lstItems);
			method_0();
		}

		private void method_0()
		{
			GClass441 gClass = new GClass441();
			foreach (GClass442 item in lstItems.Items)
			{
				gClass.Add(item);
			}
			txtSettings.Text = gClass.ToString();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			using (dlgFillStyleConfigItem dlgFillStyleConfigItem = new dlgFillStyleConfigItem())
			{
				if (dlgFillStyleConfigItem.ShowDialog(this) == DialogResult.OK)
				{
					GClass442 gClass = new GClass442();
					gClass.method_3(dlgFillStyleConfigItem.InputText);
					gClass.method_1(dlgFillStyleConfigItem.InputStyle);
					lstItems.Items.Add(gClass);
					method_0();
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (lstItems.SelectedItem != null)
			{
				GClass442 gClass = (GClass442)lstItems.SelectedItem;
				using (dlgFillStyleConfigItem dlgFillStyleConfigItem = new dlgFillStyleConfigItem())
				{
					dlgFillStyleConfigItem.InputText = gClass.method_2();
					dlgFillStyleConfigItem.InputStyle = gClass.method_0();
					if (dlgFillStyleConfigItem.ShowDialog(this) == DialogResult.OK)
					{
						gClass.method_3(dlgFillStyleConfigItem.InputText);
						gClass.method_1(dlgFillStyleConfigItem.InputStyle);
						lstItems.Refresh();
						method_0();
					}
				}
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (lstItems.SelectedIndex >= 0)
			{
				lstItems.Items.RemoveAt(lstItems.SelectedIndex);
				method_0();
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (InputListItems == null)
			{
				InputListItems = new GClass441();
			}
			InputListItems.Clear();
			foreach (GClass442 item in lstItems.Items)
			{
				InputListItems.Add(item);
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			btnEdit_Click(null, null);
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
			lstItems = new System.Windows.Forms.ListBox();
			btnAdd = new System.Windows.Forms.Button();
			btnRemove = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnEdit = new System.Windows.Forms.Button();
			txtSettings = new System.Windows.Forms.TextBox();
			SuspendLayout();
			lstItems.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 14;
			lstItems.Location = new System.Drawing.Point(0, 0);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(313, 270);
			lstItems.TabIndex = 0;
			lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(lstItems_MouseDoubleClick);
			btnAdd.Location = new System.Drawing.Point(319, 12);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(88, 23);
			btnAdd.TabIndex = 1;
			btnAdd.Text = "新增";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			btnRemove.Location = new System.Drawing.Point(319, 95);
			btnRemove.Name = "btnRemove";
			btnRemove.Size = new System.Drawing.Size(88, 23);
			btnRemove.TabIndex = 3;
			btnRemove.Text = "删除";
			btnRemove.UseVisualStyleBackColor = true;
			btnRemove.Click += new System.EventHandler(btnRemove_Click);
			btnOK.Location = new System.Drawing.Point(319, 163);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(88, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "确定(O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(319, 204);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(88, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnEdit.Location = new System.Drawing.Point(319, 54);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new System.Drawing.Size(88, 23);
			btnEdit.TabIndex = 2;
			btnEdit.Text = "修改";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += new System.EventHandler(btnEdit_Click);
			txtSettings.Location = new System.Drawing.Point(0, 276);
			txtSettings.Name = "txtSettings";
			txtSettings.ReadOnly = true;
			txtSettings.Size = new System.Drawing.Size(313, 21);
			txtSettings.TabIndex = 6;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(419, 303);
			base.Controls.Add(txtSettings);
			base.Controls.Add(btnEdit);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(btnRemove);
			base.Controls.Add(btnAdd);
			base.Controls.Add(lstItems);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFillStyleConfigDesigner";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "填充样式设置";
			base.Load += new System.EventHandler(dlgFillStyleConfigDesigner_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

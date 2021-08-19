using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design
{
	[ComVisible(false)]
	public class dlgComponentTypeLibrary : Form
	{
		private DCTypeDomDocument dctypeDomDocument_0 = new DCTypeDomDocument();

		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private ToolStripButton btnLoadAssembly;

		private ToolStripButton btnDelete;

		private ToolStripButton btnCancel;

		private ListView lvwAssembly;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private ColumnHeader columnHeader_3;

		private ToolStripButton btnOK;

		public DCTypeDomDocument ComponentDomInfo
		{
			get
			{
				return dctypeDomDocument_0;
			}
			set
			{
				dctypeDomDocument_0 = value;
			}
		}

		public dlgComponentTypeLibrary()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgComponentTypeLibrary_Load(object sender, EventArgs e)
		{
			method_0(ComponentDomInfo);
		}

		private void method_0(DCTypeDomDocument dctypeDomDocument_1)
		{
			lvwAssembly.Items.Clear();
			if (dctypeDomDocument_1 != null)
			{
				foreach (DCAssemblyInfo assembly in dctypeDomDocument_1.Assemblies)
				{
					ListViewItem listViewItem = new ListViewItem(assembly.Name);
					listViewItem.SubItems.Add(assembly.Version);
					listViewItem.SubItems.Add(assembly.Description);
					listViewItem.SubItems.Add(string.Format(DesignStrings.AssemblyContent_Types, assembly.Types.Count));
					listViewItem.Tag = assembly;
					lvwAssembly.Items.Add(listViewItem);
				}
			}
		}

		private void btnLoadAssembly_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = DesignStrings.AssemblyFilter;
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					Cursor = Cursors.WaitCursor;
					string fileName = openFileDialog.FileName;
					DCTypeDomDocument dCTypeDomDocument = new DCTypeDomDocument();
					foreach (ListViewItem item in lvwAssembly.Items)
					{
						dCTypeDomDocument.Assemblies.Add((DCAssemblyInfo)item.Tag);
					}
					DCAssemblyInfo dCAssemblyInfo = dCTypeDomDocument.LoadCrossDemain(fileName);
					if (dCAssemblyInfo != null)
					{
						dCTypeDomDocument.Sort();
						method_0(dCTypeDomDocument);
						foreach (ListViewItem item2 in lvwAssembly.Items)
						{
							if (item2.Tag == dCAssemblyInfo)
							{
								item2.Selected = true;
								item2.EnsureVisible();
							}
						}
					}
				}
			}
			Cursor = Cursors.Default;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (ComponentDomInfo == null)
			{
				ComponentDomInfo = new DCTypeDomDocument();
			}
			ComponentDomInfo.Assemblies.Clear();
			foreach (ListViewItem item in lvwAssembly.Items)
			{
				ComponentDomInfo.Assemblies.Add((DCAssemblyInfo)item.Tag);
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (lvwAssembly.SelectedItems.Count <= 0)
			{
				return;
			}
			for (int num = lvwAssembly.Items.Count - 1; num >= 0; num--)
			{
				if (lvwAssembly.Items[num].Selected)
				{
					lvwAssembly.Items.RemoveAt(num);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Design.dlgComponentTypeLibrary));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnLoadAssembly = new System.Windows.Forms.ToolStripButton();
			btnDelete = new System.Windows.Forms.ToolStripButton();
			btnCancel = new System.Windows.Forms.ToolStripButton();
			btnOK = new System.Windows.Forms.ToolStripButton();
			lvwAssembly = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			columnHeader_3 = new System.Windows.Forms.ColumnHeader();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				btnLoadAssembly,
				btnDelete,
				btnCancel,
				btnOK
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(653, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			btnLoadAssembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnLoadAssembly.Image = (System.Drawing.Image)resources.GetObject("btnLoadAssembly.Image");
			btnLoadAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnLoadAssembly.Name = "btnLoadAssembly";
			btnLoadAssembly.Size = new System.Drawing.Size(45, 22);
			btnLoadAssembly.Text = "添加...";
			btnLoadAssembly.Click += new System.EventHandler(btnLoadAssembly_Click);
			btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
			btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new System.Drawing.Size(36, 22);
			btnDelete.Text = "删除";
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
			btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(36, 22);
			btnCancel.Text = "取消";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnOK.Image = (System.Drawing.Image)resources.GetObject("btnOK.Image");
			btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(36, 22);
			btnOK.Text = "确定";
			btnOK.Click += new System.EventHandler(btnOK_Click);
			lvwAssembly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2,
				columnHeader_3
			});
			lvwAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
			lvwAssembly.FullRowSelect = true;
			lvwAssembly.GridLines = true;
			lvwAssembly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwAssembly.HideSelection = false;
			lvwAssembly.Location = new System.Drawing.Point(0, 25);
			lvwAssembly.Name = "lvwAssembly";
			lvwAssembly.Size = new System.Drawing.Size(653, 371);
			lvwAssembly.TabIndex = 1;
			lvwAssembly.UseCompatibleStateImageBehavior = false;
			lvwAssembly.View = System.Windows.Forms.View.Details;
			columnHeader_0.Text = "名称";
			columnHeader_0.Width = 169;
			columnHeader_1.Text = "版本号";
			columnHeader_1.Width = 74;
			columnHeader_2.Text = "说明";
			columnHeader_2.Width = 274;
			columnHeader_3.Text = "内容";
			columnHeader_3.Width = 90;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(653, 396);
			base.Controls.Add(lvwAssembly);
			base.Controls.Add(toolStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgComponentTypeLibrary";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "组件类型库";
			base.Load += new System.EventHandler(dlgComponentTypeLibrary_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

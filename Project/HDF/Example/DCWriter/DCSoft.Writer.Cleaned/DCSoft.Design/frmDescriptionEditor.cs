using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design
{
	/// <summary>
	///       描述性字符串资源编辑器
	///       </summary>
	[ComVisible(false)]
	public class frmDescriptionEditor : Form
	{
		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private DataGridView dgvStrings;

		private ToolStripButton btnSave;

		private ToolStripLabel toolStripLabel1;

		private ToolStripComboBox cboAssembly;

		private ToolStripButton btnLoadAssembly;

		private ToolStripSeparator toolStripSeparator1;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private string string_0 = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Design.frmDescriptionEditor));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			cboAssembly = new System.Windows.Forms.ToolStripComboBox();
			btnLoadAssembly = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnSave = new System.Windows.Forms.ToolStripButton();
			dgvStrings = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvStrings).BeginInit();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5]
			{
				toolStripLabel1,
				cboAssembly,
				btnLoadAssembly,
				toolStripSeparator1,
				btnSave
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(751, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			toolStripLabel1.Name = "toolStripLabel1";
			toolStripLabel1.Size = new System.Drawing.Size(80, 22);
			toolStripLabel1.Text = "当前程序集：";
			cboAssembly.AutoSize = false;
			cboAssembly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAssembly.Name = "cboAssembly";
			cboAssembly.Size = new System.Drawing.Size(300, 25);
			btnLoadAssembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnLoadAssembly.Image = (System.Drawing.Image)resources.GetObject("btnLoadAssembly.Image");
			btnLoadAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnLoadAssembly.Name = "btnLoadAssembly";
			btnLoadAssembly.Size = new System.Drawing.Size(36, 22);
			btnLoadAssembly.Text = "加载";
			btnLoadAssembly.Click += new System.EventHandler(btnLoadAssembly_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnSave.Image = (System.Drawing.Image)resources.GetObject("btnSave.Image");
			btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(84, 22);
			btnSave.Text = "保存资源文件";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			dgvStrings.AllowUserToAddRows = false;
			dgvStrings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStrings.Columns.AddRange(Column1, Column2);
			dgvStrings.Dock = System.Windows.Forms.DockStyle.Fill;
			dgvStrings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			dgvStrings.Location = new System.Drawing.Point(0, 25);
			dgvStrings.Name = "dgvStrings";
			dgvStrings.RowTemplate.Height = 23;
			dgvStrings.Size = new System.Drawing.Size(751, 334);
			dgvStrings.TabIndex = 3;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			Column1.DefaultCellStyle = dataGridViewCellStyle;
			Column1.HeaderText = "名称";
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column1.Width = 200;
			Column2.HeaderText = "文本";
			Column2.Name = "Column2";
			Column2.Width = 300;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(751, 359);
			base.Controls.Add(dgvStrings);
			base.Controls.Add(toolStrip1);
			base.Name = "frmDescriptionEditor";
			Text = "Description资源管理器";
			base.Load += new System.EventHandler(frmDescriptionEditor_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvStrings).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public frmDescriptionEditor()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int num = 10;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "资源文件(*.resx)|*.resx";
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.FileName = string_0;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					string_0 = saveFileDialog.FileName;
					ResXResourceWriter resXResourceWriter = new ResXResourceWriter(string_0);
					foreach (DataGridViewRow item in (IEnumerable)dgvStrings.Rows)
					{
						string name = Convert.ToString(item.Cells[0].Value);
						string value = Convert.ToString(item.Cells[1].Value);
						if (!string.IsNullOrEmpty(value))
						{
							resXResourceWriter.AddResource(name, value);
						}
					}
					resXResourceWriter.Close();
				}
			}
		}

		private void frmDescriptionEditor_Load(object sender, EventArgs e)
		{
			cboAssembly.ComboBox.DisplayMember = "FullName";
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly item in assemblies)
			{
				cboAssembly.Items.Add(item);
			}
		}

		private void btnLoadAssembly_Click(object sender, EventArgs e)
		{
			Assembly assembly = (Assembly)cboAssembly.SelectedItem;
			if (assembly != null)
			{
				dgvStrings.Rows.Clear();
				Dictionary<string, string> dictionary = GClass359.smethod_11(assembly);
				if (dictionary != null && dictionary.Count > 0)
				{
					foreach (string key in dictionary.Keys)
					{
						string text = dictionary[key];
						bool flag = false;
						foreach (DataGridViewRow item in (IEnumerable)dgvStrings.Rows)
						{
							if (string.Compare(Convert.ToString(item.Cells[0].Value), key, ignoreCase: true) == 0)
							{
								flag = true;
								item.Cells[1].Value = text;
								break;
							}
						}
						if (!flag)
						{
							dgvStrings.Rows.Add(key, text);
						}
					}
				}
			}
		}
	}
}

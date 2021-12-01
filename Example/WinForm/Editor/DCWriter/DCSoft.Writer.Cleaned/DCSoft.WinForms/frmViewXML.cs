using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace DCSoft.WinForms
{
	/// <summary>
	///       查看文档XML代码窗体
	///       </summary>
	[ComVisible(false)]
	public class frmViewXML : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtXML;

		private ToolStrip toolStrip1;

		private ToolStripButton btnSave;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripTextBox txtSearch;

		private ToolStripButton btnSearch;

		/// <summary>
		///       XML源代码
		///       </summary>
		public string XMLSource
		{
			get
			{
				return txtXML.Text;
			}
			set
			{
				txtXML.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public frmViewXML()
		{
			InitializeComponent();
		}

		private void frmViewXML_Load(object sender, EventArgs e)
		{
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int num = 13;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(txtXML.Text);
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "*.xml|*.xml";
					saveFileDialog.OverwritePrompt = true;
					saveFileDialog.CheckPathExists = true;
					if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						xmlDocument.Save(saveFileDialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtSearch.Text))
			{
				int num = txtXML.Text.IndexOf(txtSearch.Text);
				if (num >= 0)
				{
					txtXML.Select(num, txtSearch.Text.Length);
					txtXML.ScrollToCaret();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.frmViewXML));
			txtXML = new System.Windows.Forms.TextBox();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnSave = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			txtSearch = new System.Windows.Forms.ToolStripTextBox();
			btnSearch = new System.Windows.Forms.ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(txtXML, "txtXML");
			txtXML.Name = "txtXML";
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				btnSave,
				toolStripSeparator1,
				txtSearch,
				btnSearch
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			resources.ApplyResources(btnSave, "btnSave");
			btnSave.Name = "btnSave";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			txtSearch.Name = "txtSearch";
			resources.ApplyResources(txtSearch, "txtSearch");
			resources.ApplyResources(btnSearch, "btnSearch");
			btnSearch.Name = "btnSearch";
			btnSearch.Click += new System.EventHandler(btnSearch_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtXML);
			base.Controls.Add(toolStrip1);
			base.MinimizeBox = false;
			base.Name = "frmViewXML";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(frmViewXML_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

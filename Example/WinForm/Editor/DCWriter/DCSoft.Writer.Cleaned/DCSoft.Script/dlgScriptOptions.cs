using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Script
{
	[ComVisible(false)]
	public class dlgScriptOptions : Form
	{
		private IContainer icontainer_0 = null;

		private GroupBox groupBox1;

		private Button cmdDeleteAssembly;

		private Button cmdBrowseAdd;

		private Button cmdAddGACAssembly;

		private GroupBox groupBox2;

		private TextBox txtImports;

		private Button cmdOK;

		private Button cmdCancel;

		private ListView lvwAssembly;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private XVBAOptions xvbaoptions_0 = null;

		/// <summary>
		///       script options
		///       </summary>
		public XVBAOptions OptionsInstance
		{
			get
			{
				return xvbaoptions_0;
			}
			set
			{
				xvbaoptions_0 = value;
			}
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Script.dlgScriptOptions));
			groupBox1 = new System.Windows.Forms.GroupBox();
			lvwAssembly = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			cmdDeleteAssembly = new System.Windows.Forms.Button();
			cmdBrowseAdd = new System.Windows.Forms.Button();
			cmdAddGACAssembly = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			txtImports = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(lvwAssembly);
			groupBox1.Controls.Add(cmdDeleteAssembly);
			groupBox1.Controls.Add(cmdBrowseAdd);
			groupBox1.Controls.Add(cmdAddGACAssembly);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			lvwAssembly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2
			});
			lvwAssembly.FullRowSelect = true;
			lvwAssembly.GridLines = true;
			lvwAssembly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwAssembly.HideSelection = false;
			resources.ApplyResources(lvwAssembly, "lvwAssembly");
			lvwAssembly.MultiSelect = false;
			lvwAssembly.Name = "lvwAssembly";
			lvwAssembly.Sorting = System.Windows.Forms.SortOrder.Ascending;
			lvwAssembly.UseCompatibleStateImageBehavior = false;
			lvwAssembly.View = System.Windows.Forms.View.Details;
			resources.ApplyResources(columnHeader_0, "columnHeader1");
			resources.ApplyResources(columnHeader_1, "columnHeader2");
			resources.ApplyResources(columnHeader_2, "columnHeader3");
			resources.ApplyResources(cmdDeleteAssembly, "cmdDeleteAssembly");
			cmdDeleteAssembly.Name = "cmdDeleteAssembly";
			cmdDeleteAssembly.UseVisualStyleBackColor = true;
			cmdDeleteAssembly.Click += new System.EventHandler(cmdDeleteAssembly_Click);
			resources.ApplyResources(cmdBrowseAdd, "cmdBrowseAdd");
			cmdBrowseAdd.Name = "cmdBrowseAdd";
			cmdBrowseAdd.UseVisualStyleBackColor = true;
			cmdBrowseAdd.Click += new System.EventHandler(cmdBrowseAdd_Click);
			resources.ApplyResources(cmdAddGACAssembly, "cmdAddGACAssembly");
			cmdAddGACAssembly.Name = "cmdAddGACAssembly";
			cmdAddGACAssembly.UseVisualStyleBackColor = true;
			cmdAddGACAssembly.Click += new System.EventHandler(cmdAddGACAssembly_Click);
			groupBox2.Controls.Add(txtImports);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			txtImports.AcceptsReturn = true;
			resources.ApplyResources(txtImports, "txtImports");
			txtImports.Name = "txtImports";
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = true;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgScriptOptions";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgScriptOptions_Load);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
		}

		public dlgScriptOptions()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgScriptOptions_Load(object sender, EventArgs e)
		{
			if (xvbaoptions_0 != null)
			{
				foreach (DotNetAssemblyInfo referenceAssembly in xvbaoptions_0.ReferenceAssemblies)
				{
					DotNetAssemblyInfo dotNetAssemblyInfo2 = DotNetAssemblyInfoList.GlobalList[referenceAssembly.Name];
					if (dotNetAssemblyInfo2 != null && dotNetAssemblyInfo2.SourceStyle == referenceAssembly.SourceStyle)
					{
						referenceAssembly.FileName = DotNetAssemblyInfo.GetFileNameByCodeBase(dotNetAssemblyInfo2.CodeBase);
						referenceAssembly.Version = dotNetAssemblyInfo2.Version;
						referenceAssembly.RuntimeVersion = dotNetAssemblyInfo2.RuntimeVersion;
						referenceAssembly.Flags = dotNetAssemblyInfo2.Flags;
						referenceAssembly.CodeBase = dotNetAssemblyInfo2.CodeBase;
					}
					ListViewItem listViewItem = new ListViewItem(referenceAssembly.Name);
					listViewItem.SubItems.Add(referenceAssembly.VersionString);
					listViewItem.SubItems.Add(referenceAssembly.FileName);
					listViewItem.Tag = referenceAssembly;
					lvwAssembly.Items.Add(listViewItem);
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string importNamespace in xvbaoptions_0.ImportNamespaces)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(Environment.NewLine);
					}
					stringBuilder.Append(importNamespace);
				}
				txtImports.Text = stringBuilder.ToString();
			}
		}

		private void cmdAddGACAssembly_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			using (dlgBrowseGACAssembly dlgBrowseGACAssembly = new dlgBrowseGACAssembly())
			{
				if (dlgBrowseGACAssembly.ShowDialog(this) == DialogResult.OK)
				{
					Cursor = Cursors.Default;
					DotNetAssemblyInfo selectedAssembly = dlgBrowseGACAssembly.SelectedAssembly;
					ListViewItem listViewItem = new ListViewItem(selectedAssembly.Name);
					listViewItem.SubItems.Add(selectedAssembly.VersionString);
					listViewItem.SubItems.Add(selectedAssembly.FileName);
					listViewItem.Tag = selectedAssembly;
					lvwAssembly.Items.Add(listViewItem);
				}
			}
			Cursor = Cursors.Default;
		}

		private void cmdBrowseAdd_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				openFileDialog.Filter = ScriptStrings.AssemblyFileFilter;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					DotNetAssemblyInfo dotNetAssemblyInfo = DotNetAssemblyInfo.CreateByFileName(openFileDialog.FileName);
					ListViewItem listViewItem = new ListViewItem(dotNetAssemblyInfo.Name);
					listViewItem.SubItems.Add(dotNetAssemblyInfo.VersionString);
					listViewItem.SubItems.Add(dotNetAssemblyInfo.FileName);
					listViewItem.Tag = dotNetAssemblyInfo;
					lvwAssembly.Items.Add(listViewItem);
				}
			}
		}

		private void cmdDeleteAssembly_Click(object sender, EventArgs e)
		{
			if (lvwAssembly.SelectedItems.Count > 0)
			{
				lvwAssembly.Items.Remove(lvwAssembly.SelectedItems[0]);
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (xvbaoptions_0 == null)
			{
				return;
			}
			xvbaoptions_0.ImportNamespaces = new MyStringList();
			StringReader stringReader = new StringReader(txtImports.Text);
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				text = text.Trim();
				if (text.Length > 0 && !xvbaoptions_0.ImportNamespaces.Contains(text))
				{
					xvbaoptions_0.ImportNamespaces.Add(text);
				}
			}
			xvbaoptions_0.ReferenceAssemblies.Clear();
			foreach (ListViewItem item in lvwAssembly.Items)
			{
				xvbaoptions_0.ReferenceAssemblies.Add((DotNetAssemblyInfo)item.Tag);
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

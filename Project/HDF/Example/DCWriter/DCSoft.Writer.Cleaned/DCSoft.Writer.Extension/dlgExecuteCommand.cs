using DCSoft.Writer.Commands;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       执行命令
	///       </summary>
	[ComVisible(false)]
	public class dlgExecuteCommand : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private ListView lvwCommand;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private Label label2;

		private TextBox txtParameter;

		private Button btnOK;

		private Button btnCancel;

		private ColumnHeader columnHeader_3;

		private Panel panel1;

		private CheckBox chkShowUI;

		private CheckBox chkShowResult;

		private ToolStrip toolStrip1;

		private ToolStripButton tsBtnFileNew;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton tsBtnElementProperties;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton tsBtnDocumentOptions;

		private ToolStripButton tsBtnDevelopTools;

		private WriterCommandControler writerCommandControler_0 = null;

		private WriterAppHost writerAppHost_0 = WriterAppHost.Default;

		private string string_0 = null;

		private string string_1 = null;

		/// <summary>
		///       命令控制器
		///       </summary>
		public WriterCommandControler CmdControler
		{
			get
			{
				return writerCommandControler_0;
			}
			set
			{
				writerCommandControler_0 = value;
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		public WriterAppHost AppHost
		{
			get
			{
				return writerAppHost_0;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       编辑器命令名称
		///       </summary>
		public string CommandName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       编辑器命令参数
		///       </summary>
		public string CommandParameter
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       显示返回结果
		///       </summary>
		public bool ShowResult
		{
			get
			{
				return chkShowResult.Checked;
			}
			set
			{
				chkShowResult.Checked = value;
			}
		}

		/// <summary>
		///       是否显示设置界面
		///       </summary>
		public bool ShowUI
		{
			get
			{
				return chkShowUI.Checked;
			}
			set
			{
				chkShowUI.Checked = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgExecuteCommand));
			label1 = new System.Windows.Forms.Label();
			lvwCommand = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			columnHeader_3 = new System.Windows.Forms.ColumnHeader();
			label2 = new System.Windows.Forms.Label();
			txtParameter = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			chkShowUI = new System.Windows.Forms.CheckBox();
			chkShowResult = new System.Windows.Forms.CheckBox();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			tsBtnFileNew = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			tsBtnElementProperties = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			tsBtnDocumentOptions = new System.Windows.Forms.ToolStripButton();
			tsBtnDevelopTools = new System.Windows.Forms.ToolStripButton();
			panel1.SuspendLayout();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			lvwCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2,
				columnHeader_3
			});
			lvwCommand.FullRowSelect = true;
			lvwCommand.GridLines = true;
			lvwCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwCommand.HideSelection = false;
			resources.ApplyResources(lvwCommand, "lvwCommand");
			lvwCommand.Name = "lvwCommand";
			lvwCommand.UseCompatibleStateImageBehavior = false;
			lvwCommand.View = System.Windows.Forms.View.Details;
			resources.ApplyResources(columnHeader_0, "columnHeader1");
			resources.ApplyResources(columnHeader_1, "columnHeader2");
			resources.ApplyResources(columnHeader_2, "columnHeader3");
			resources.ApplyResources(columnHeader_3, "columnHeader4");
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtParameter, "txtParameter");
			txtParameter.Name = "txtParameter";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			panel1.Controls.Add(txtParameter);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			resources.ApplyResources(chkShowUI, "chkShowUI");
			chkShowUI.Checked = true;
			chkShowUI.CheckState = System.Windows.Forms.CheckState.Checked;
			chkShowUI.Name = "chkShowUI";
			chkShowUI.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkShowResult, "chkShowResult");
			chkShowResult.Name = "chkShowResult";
			chkShowResult.UseVisualStyleBackColor = true;
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6]
			{
				tsBtnFileNew,
				toolStripSeparator1,
				tsBtnElementProperties,
				toolStripSeparator2,
				tsBtnDocumentOptions,
				tsBtnDevelopTools
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			tsBtnFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(tsBtnFileNew, "tsBtnFileNew");
			tsBtnFileNew.Name = "tsBtnFileNew";
			tsBtnFileNew.Click += new System.EventHandler(tsBtnFileNew_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			tsBtnElementProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(tsBtnElementProperties, "tsBtnElementProperties");
			tsBtnElementProperties.Name = "tsBtnElementProperties";
			tsBtnElementProperties.Click += new System.EventHandler(tsBtnElementProperties_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			tsBtnDocumentOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(tsBtnDocumentOptions, "tsBtnDocumentOptions");
			tsBtnDocumentOptions.Name = "tsBtnDocumentOptions";
			tsBtnDocumentOptions.Click += new System.EventHandler(tsBtnDocumentOptions_Click);
			tsBtnDevelopTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(tsBtnDevelopTools, "tsBtnDevelopTools");
			tsBtnDevelopTools.Name = "tsBtnDevelopTools";
			tsBtnDevelopTools.Click += new System.EventHandler(tsBtnDevelopTools_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(lvwCommand);
			base.Controls.Add(toolStrip1);
			base.Controls.Add(chkShowResult);
			base.Controls.Add(chkShowUI);
			base.Controls.Add(panel1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgExecuteCommand";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgExecuteCommand_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgExecuteCommand()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgExecuteCommand_Load(object sender, EventArgs e)
		{
			WriterCommandList allCommands = AppHost.CommandContainer.AllCommands;
			ImageList imageList = new ImageList();
			lvwCommand.SmallImageList = imageList;
			foreach (WriterCommand item in allCommands)
			{
				ListViewItem listViewItem = new ListViewItem(item.Name);
				listViewItem.SubItems.Add((item.Module == null) ? "" : item.Module.Name);
				listViewItem.SubItems.Add(item.Description);
				if (writerCommandControler_0.IsCommandEnabled(item.Name))
				{
					listViewItem.SubItems.Add(WriterStrings.Enabled);
				}
				else
				{
					listViewItem.SubItems.Add(WriterStrings.Disable);
					listViewItem.ForeColor = Color.Gray;
				}
				if (item.ToolbarImage != null)
				{
					imageList.Images.Add(item.Name, item.ToolbarImage);
					listViewItem.ImageKey = item.Name;
				}
				lvwCommand.Items.Add(listViewItem);
				if (string.Compare(listViewItem.Text, string_0, ignoreCase: true) == 0)
				{
					listViewItem.Selected = true;
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lvwCommand.SelectedItems.Count > 0)
			{
				CommandName = lvwCommand.SelectedItems[0].Text;
				string_1 = txtParameter.Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void method_0(string string_2)
		{
			CommandName = string_2;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void tsBtnFileNew_Click(object sender, EventArgs e)
		{
			method_0("FileSaveAs");
		}

		private void tsBtnElementProperties_Click(object sender, EventArgs e)
		{
			method_0("ElementProperties");
		}

		private void tsBtnDocumentOptions_Click(object sender, EventArgs e)
		{
			method_0("DocumentOptions");
		}

		private void tsBtnDevelopTools_Click(object sender, EventArgs e)
		{
			method_0("DeveloperTools");
		}
	}
}

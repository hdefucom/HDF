using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands.Design
{
	/// <summary>
	///       编辑器命令选择对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgCommandNameEditor : Form
	{
		private IContainer icontainer_0 = null;

		private TreeView tvwCommand;

		private Button btnOK;

		private Button btnCancel;

		private TabControl myTabControl;

		private TabPage pageTreeView;

		private TabPage pageListView;

		private ListView lvwCommand;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private List<WriterCommandSimpleInfo> list_0 = null;

		private string string_0 = null;

		private WriterCommandSimpleInfo writerCommandSimpleInfo_0 = null;

		/// <summary>
		///       功能模块信息列表
		///       </summary>
		internal List<WriterCommandSimpleInfo> CommandInfos
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		/// <summary>
		///       编辑器名称名称
		///       </summary>
		public string InputCommandName
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

		public WriterCommandSimpleInfo SelectedCommandInfo => writerCommandSimpleInfo_0;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.Design.dlgCommandNameEditor));
			tvwCommand = new System.Windows.Forms.TreeView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			myTabControl = new System.Windows.Forms.TabControl();
			pageTreeView = new System.Windows.Forms.TabPage();
			pageListView = new System.Windows.Forms.TabPage();
			lvwCommand = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			myTabControl.SuspendLayout();
			pageTreeView.SuspendLayout();
			pageListView.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(tvwCommand, "tvwCommand");
			tvwCommand.HideSelection = false;
			tvwCommand.Name = "tvwCommand";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			myTabControl.Controls.Add(pageListView);
			myTabControl.Controls.Add(pageTreeView);
			resources.ApplyResources(myTabControl, "myTabControl");
			myTabControl.Name = "myTabControl";
			myTabControl.SelectedIndex = 0;
			pageTreeView.Controls.Add(tvwCommand);
			resources.ApplyResources(pageTreeView, "pageTreeView");
			pageTreeView.Name = "pageTreeView";
			pageTreeView.UseVisualStyleBackColor = true;
			pageListView.Controls.Add(lvwCommand);
			resources.ApplyResources(pageListView, "pageListView");
			pageListView.Name = "pageListView";
			pageListView.UseVisualStyleBackColor = true;
			lvwCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2]
			{
				columnHeader_0,
				columnHeader_1
			});
			resources.ApplyResources(lvwCommand, "lvwCommand");
			lvwCommand.FullRowSelect = true;
			lvwCommand.GridLines = true;
			lvwCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwCommand.HideSelection = false;
			lvwCommand.Name = "lvwCommand";
			lvwCommand.UseCompatibleStateImageBehavior = false;
			lvwCommand.View = System.Windows.Forms.View.Details;
			resources.ApplyResources(columnHeader_0, "columnHeader1");
			resources.ApplyResources(columnHeader_1, "columnHeader2");
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(myTabControl);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCommandNameEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCommandNameEditor_Load);
			myTabControl.ResumeLayout(false);
			pageTreeView.ResumeLayout(false);
			pageListView.ResumeLayout(false);
			ResumeLayout(false);
		}

		public static void smethod_0()
		{
			using (dlgCommandNameEditor dlgCommandNameEditor = new dlgCommandNameEditor())
			{
				dlgCommandNameEditor.CommandInfos = WriterCommandNameDlgEditor.smethod_1(dlgCommandNameEditor.GetType().Assembly.GetTypes());
				dlgCommandNameEditor.ShowDialog();
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCommandNameEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///       窗体加载事件处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			try
			{
				base.OnLoad(eventArgs_0);
				if (CommandInfos != null)
				{
					smethod_3(tvwCommand, CommandInfos);
					if (InputCommandName != null && InputCommandName.Length > 0)
					{
						foreach (TreeNode node in tvwCommand.Nodes)
						{
							foreach (TreeNode node2 in node.Nodes)
							{
								if (!(node2.Text == InputCommandName))
								{
									continue;
								}
								tvwCommand.SelectedNode = node2;
								node2.EnsureVisible();
								goto IL_011d;
							}
						}
					}
					if (tvwCommand.Nodes.Count > 0)
					{
						tvwCommand.Nodes[0].Expand();
					}
					goto IL_011d;
				}
				goto end_IL_0001;
				IL_011d:
				smethod_2(lvwCommand, CommandInfos);
				lvwCommand.Focus();
				lvwCommand.Select();
				if (!string.IsNullOrEmpty(InputCommandName))
				{
					foreach (ListViewItem item in lvwCommand.Items)
					{
						if (item.Text == InputCommandName)
						{
							item.Selected = true;
							item.EnsureVisible();
							break;
						}
					}
				}
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		internal static ImageList smethod_1(List<WriterCommandSimpleInfo> list_1)
		{
			ImageList imageList = new ImageList();
			imageList.Images.Add(GClass131.smethod_1(typeof(dlgCommandNameEditor).Assembly, "DCSoft.Writer.Commands.Images.CommandModule.bmp"));
			imageList.Images.Add(GClass131.smethod_1(typeof(dlgCommandNameEditor).Assembly, "DCSoft.Writer.Commands.Images.CommandDefault.bmp"));
			foreach (WriterCommandSimpleInfo item in list_1)
			{
				item.ImageIndex = -1;
				if (item.Image != null)
				{
					imageList.Images.Add(item.Image);
					item.ImageIndex = imageList.Images.Count - 1;
				}
				else
				{
					item.ImageIndex = 1;
				}
			}
			return imageList;
		}

		internal static void smethod_2(ListView listView_0, List<WriterCommandSimpleInfo> list_1)
		{
			listView_0.SmallImageList = smethod_1(list_1);
			foreach (WriterCommandSimpleInfo item in list_1)
			{
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = item.Name;
				listViewItem.SubItems.Add(item.ModuleName);
				listViewItem.ImageIndex = item.ImageIndex;
				listViewItem.Tag = item;
				listView_0.Items.Add(listViewItem);
			}
		}

		public static void smethod_3(TreeView treeView_0, List<WriterCommandSimpleInfo> list_1)
		{
			int num = 13;
			treeView_0.ImageList = smethod_1(list_1);
			foreach (WriterCommandSimpleInfo item in list_1)
			{
				TreeNode treeNode = null;
				string text = item.ModuleName;
				if (string.IsNullOrEmpty(text))
				{
					text = "_";
				}
				foreach (TreeNode node in treeView_0.Nodes)
				{
					if (node.Text == text)
					{
						treeNode = node;
						break;
					}
				}
				if (treeNode == null)
				{
					treeNode = new TreeNode(text);
					treeNode.ImageIndex = 0;
					treeNode.SelectedImageIndex = 0;
					if (text == "_")
					{
						treeView_0.Nodes.Insert(0, treeNode);
					}
					else
					{
						treeView_0.Nodes.Add(treeNode);
					}
				}
				TreeNode treeNode3 = new TreeNode(item.Name);
				treeNode3.ImageIndex = item.ImageIndex;
				treeNode3.SelectedImageIndex = treeNode3.ImageIndex;
				treeNode3.Tag = item;
				treeNode.Nodes.Add(treeNode3);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			InputCommandName = null;
			if (myTabControl.SelectedTab == pageListView)
			{
				if (lvwCommand.SelectedItems.Count > 0)
				{
					InputCommandName = lvwCommand.SelectedItems[0].Text;
					writerCommandSimpleInfo_0 = (lvwCommand.SelectedItems[0].Tag as WriterCommandSimpleInfo);
				}
			}
			else if (tvwCommand.SelectedNode != null && tvwCommand.SelectedNode.Level == 1)
			{
				InputCommandName = tvwCommand.SelectedNode.Text;
				writerCommandSimpleInfo_0 = (tvwCommand.SelectedNode.Tag as WriterCommandSimpleInfo);
			}
			if (!string.IsNullOrEmpty(InputCommandName))
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgCommandNameEditor_Load(object sender, EventArgs e)
		{
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       树状方式选择字符串的对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgTreeString : Form
	{
		private string string_0 = null;

		private List<string> list_0 = new List<string>();

		private ImageList imageList_0 = null;

		private char char_0 = '.';

		private IContainer icontainer_0 = null;

		private TreeView tvwStrings;

		private Button btnOK;

		private Button btnCancel;

		public string SelectedItem
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

		public List<string> ListItems
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

		public ImageList ItemImageLists
		{
			get
			{
				return imageList_0;
			}
			set
			{
				imageList_0 = value;
			}
		}

		/// <summary>
		///       各级项目之间的分隔字符
		///       </summary>
		public char ItemSplitChar
		{
			get
			{
				return char_0;
			}
			set
			{
				char_0 = value;
			}
		}

		public dlgTreeString()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgTreeString_Load(object sender, EventArgs e)
		{
			Fill(tvwStrings, imageList_0, list_0, SelectedItem, ItemSplitChar);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tvwStrings.SelectedNode != null)
			{
				SelectedItem = tvwStrings.SelectedNode.Name;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		public static void Fill(TreeView treeView_0, ImageList itemImageLists, IList listItems, string selectedItem, char itemSplitChar)
		{
			int num = 4;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			treeView_0.BeginUpdate();
			treeView_0.Nodes.Clear();
			treeView_0.ImageList = itemImageLists;
			if (listItems != null && listItems.Count > 0)
			{
				TreeNode treeNode = null;
				foreach (string listItem in listItems)
				{
					if (!string.IsNullOrEmpty(listItem))
					{
						string[] array = listItem.Split(itemSplitChar);
						TreeNodeCollection nodes = treeView_0.Nodes;
						for (int i = 0; i < array.Length; i++)
						{
							string text2 = array[i];
							TreeNode treeNode2 = null;
							foreach (TreeNode item in nodes)
							{
								if (item.Text == text2)
								{
									treeNode2 = item;
									break;
								}
							}
							if (treeNode2 == null)
							{
								treeNode2 = new TreeNode(text2);
								if (itemImageLists != null && i < itemImageLists.Images.Count)
								{
									treeNode2.ImageIndex = i;
									treeNode2.SelectedImageIndex = i;
								}
								treeNode2.Name = listItem;
								if (selectedItem != null && selectedItem == listItem)
								{
									treeNode = treeNode2;
								}
								nodes.Add(treeNode2);
							}
							nodes = treeNode2.Nodes;
						}
					}
				}
				treeView_0.ExpandAll();
				if (treeNode != null)
				{
					treeView_0.SelectedNode = treeNode;
					treeNode.EnsureVisible();
				}
			}
			treeView_0.EndUpdate();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgTreeString));
			tvwStrings = new System.Windows.Forms.TreeView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(tvwStrings, "tvwStrings");
			tvwStrings.HideSelection = false;
			tvwStrings.Name = "tvwStrings";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(tvwStrings);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTreeString";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgTreeString_Load);
			ResumeLayout(false);
		}
	}
}

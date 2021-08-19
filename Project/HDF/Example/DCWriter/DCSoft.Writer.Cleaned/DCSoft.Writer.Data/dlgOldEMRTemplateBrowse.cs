using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       支持旧版电子病历知识库的文件名浏览器
	///       </summary>
	[ComVisible(false)]
	public class dlgOldEMRTemplateBrowse : Form
	{
		private Dictionary<string, string> dictionary_0 = null;

		private string string_0 = null;

		private string string_1 = null;

		private IContainer icontainer_0 = null;

		private TreeView tvwTemplate;

		private Button btnOK;

		private Button btnCancel;

		private ImageList imageList_0;

		/// <summary>
		///       所有可选的文件名
		///       </summary>
		public Dictionary<string, string> FileNames
		{
			get
			{
				return dictionary_0;
			}
			set
			{
				dictionary_0 = value;
			}
		}

		/// <summary>
		///       选择的文件名
		///       </summary>
		public string SelectedFileName
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
		///       选择的文件编号
		///       </summary>
		public string SelectedFileID
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
		///       初始化对象
		///       </summary>
		public dlgOldEMRTemplateBrowse()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgOldEMRTemplateBrowse_Load(object sender, EventArgs e)
		{
			if (dictionary_0 != null)
			{
				List<string> list = new List<string>();
				list.AddRange(dictionary_0.Keys);
				list.Sort();
				foreach (string item in list)
				{
					string[] array = item.Split('.');
					TreeNodeCollection nodes = tvwTemplate.Nodes;
					for (int i = 0; i < array.Length; i++)
					{
						string text = array[i];
						TreeNode treeNode = null;
						foreach (TreeNode item2 in nodes)
						{
							if (item2.Text == text)
							{
								treeNode = item2;
								break;
							}
						}
						if (treeNode == null)
						{
							treeNode = new TreeNode(text);
							treeNode.ImageIndex = 0;
							treeNode.SelectedImageIndex = 0;
							nodes.Add(treeNode);
						}
						nodes = treeNode.Nodes;
						if (i == array.Length - 1)
						{
							treeNode.Tag = item;
							treeNode.Name = dictionary_0[item];
							treeNode.ImageIndex = 1;
							treeNode.SelectedImageIndex = 1;
							break;
						}
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvwTemplate.SelectedNode;
			if (selectedNode.ImageIndex == 1)
			{
				string_1 = selectedNode.Name;
				string_0 = (string)selectedNode.Tag;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tvwTemplate_DoubleClick(object sender, EventArgs e)
		{
			btnOK_Click(null, null);
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
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Data.dlgOldEMRTemplateBrowse));
			tvwTemplate = new System.Windows.Forms.TreeView();
			imageList_0 = new System.Windows.Forms.ImageList(icontainer_0);
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			tvwTemplate.HideSelection = false;
			resources.ApplyResources(tvwTemplate, "tvwTemplate");
			tvwTemplate.ImageList = imageList_0;
			tvwTemplate.Name = "tvwTemplate";
			tvwTemplate.DoubleClick += new System.EventHandler(tvwTemplate_DoubleClick);
			imageList_0.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList_0.TransparentColor = System.Drawing.Color.Red;
			imageList_0.Images.SetKeyName(0, "CommandFileOpen.bmp");
			imageList_0.Images.SetKeyName(1, "CommandFileNew.bmp");
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(tvwTemplate);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgOldEMRTemplateBrowse";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgOldEMRTemplateBrowse_Load);
			ResumeLayout(false);
		}
	}
}

using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class dlgBrowseWindowHandle : Form
	{
		private IntPtr intptr_0 = IntPtr.Zero;

		private IntPtr intptr_1 = IntPtr.Zero;

		private object object_0 = new object();

		private IContainer icontainer_0 = null;

		private TreeView tvwWin;

		private Button btnOK;

		private Button btnCancel;

		private ImageList imageList_0;

		private Button btnRefresh;

		private PictureBox pictureBox1;

		private Label label1;

		private TextBox txtHandle;

		/// <summary>
		///       根句柄
		///       </summary>
		public IntPtr RootWinHandle
		{
			get
			{
				return intptr_0;
			}
			set
			{
				intptr_0 = value;
			}
		}

		/// <summary>
		///       选中的句柄
		///       </summary>
		public IntPtr SelectedWinHandle
		{
			get
			{
				return intptr_1;
			}
			set
			{
				intptr_1 = value;
			}
		}

		public dlgBrowseWindowHandle()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseWindowHandle_Load(object sender, EventArgs e)
		{
			btnRefresh_Click(null, null);
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			tvwWin.Nodes.Clear();
			imageList_0.Images.Clear();
			imageList_0.Images.Add(pictureBox1.Image);
			IList list = null;
			if (RootWinHandle != IntPtr.Zero)
			{
				GClass244 gClass = new GClass244(RootWinHandle);
				if (gClass.method_37())
				{
					list = new ArrayList();
					list.Add(gClass);
				}
			}
			if (list == null)
			{
				list = GClass244.smethod_6();
			}
			method_0(tvwWin.Nodes, list);
		}

		private void method_0(TreeNodeCollection treeNodeCollection_0, IList ilist_0)
		{
			int num = 14;
			foreach (GClass244 item in ilist_0)
			{
				if (item.method_37() && item.method_12() && !(item.Handle == base.Handle))
				{
					string text = item.method_3();
					if (string.IsNullOrEmpty(text))
					{
						text = item.method_2();
						if (!string.IsNullOrEmpty(text))
						{
							text = "CLS:" + text;
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						text = "Hwnd:" + item.Handle;
					}
					TreeNode treeNode = new TreeNode(text);
					treeNode.Tag = item;
					if (item.method_24() != null)
					{
						Image image = item.method_24().ToBitmap();
						if (image != null)
						{
							imageList_0.Images.Add("icon" + item.Handle, image);
							treeNode.ImageKey = "icon" + item.Handle;
							treeNode.SelectedImageKey = treeNode.ImageKey;
						}
					}
					treeNodeCollection_0.Add(treeNode);
					if (item.method_39())
					{
						TreeNode treeNode2 = new TreeNode("...");
						treeNode2.Tag = object_0;
						treeNode.Nodes.Add(treeNode2);
					}
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tvwWin.SelectedNode != null)
			{
				GClass244 gClass = tvwWin.SelectedNode.Tag as GClass244;
				if (gClass != null)
				{
					intptr_1 = gClass.Handle;
					base.DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void tvwWin_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			if (node.FirstNode != null && node.FirstNode.Tag == object_0)
			{
				node.Nodes.Clear();
				GClass244 gClass = (GClass244)node.Tag;
				GClass244[] ilist_ = gClass.method_38();
				method_0(node.Nodes, ilist_);
			}
		}

		private void tvwWin_AfterSelect(object sender, TreeViewEventArgs e)
		{
			int num = 0;
			if (tvwWin.SelectedNode == null)
			{
				txtHandle.Text = "";
				return;
			}
			GClass244 gClass = tvwWin.SelectedNode.Tag as GClass244;
			if (gClass != null)
			{
				txtHandle.Text = gClass.Handle + "  HEX:" + gClass.Handle.ToString("X");
			}
			else
			{
				txtHandle.Text = "";
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
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgBrowseWindowHandle));
			tvwWin = new System.Windows.Forms.TreeView();
			imageList_0 = new System.Windows.Forms.ImageList(icontainer_0);
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnRefresh = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			txtHandle = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			tvwWin.Dock = System.Windows.Forms.DockStyle.Top;
			tvwWin.FullRowSelect = true;
			tvwWin.HideSelection = false;
			tvwWin.ImageIndex = 0;
			tvwWin.ImageList = imageList_0;
			tvwWin.Location = new System.Drawing.Point(0, 0);
			tvwWin.Name = "tvwWin";
			tvwWin.SelectedImageIndex = 0;
			tvwWin.Size = new System.Drawing.Size(374, 293);
			tvwWin.TabIndex = 0;
			tvwWin.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(tvwWin_BeforeExpand);
			tvwWin.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(tvwWin_AfterSelect);
			imageList_0.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			imageList_0.ImageSize = new System.Drawing.Size(16, 16);
			imageList_0.TransparentColor = System.Drawing.Color.Transparent;
			btnOK.Location = new System.Drawing.Point(153, 332);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(248, 332);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 1;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnRefresh.Location = new System.Drawing.Point(22, 332);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new System.Drawing.Size(75, 23);
			btnRefresh.TabIndex = 1;
			btnRefresh.Text = "刷新";
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(120, 325);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(27, 30);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			pictureBox1.Visible = false;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 303);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 3;
			label1.Text = "句柄：";
			txtHandle.Location = new System.Drawing.Point(68, 300);
			txtHandle.Name = "txtHandle";
			txtHandle.ReadOnly = true;
			txtHandle.Size = new System.Drawing.Size(294, 21);
			txtHandle.TabIndex = 4;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(374, 367);
			base.Controls.Add(txtHandle);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnRefresh);
			base.Controls.Add(btnOK);
			base.Controls.Add(tvwWin);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseWindowHandle";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "浏览窗体";
			base.Load += new System.EventHandler(dlgBrowseWindowHandle_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}

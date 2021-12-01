using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class dlgKBPath : Form
	{
		private Label lblInfo;

		private Button cmdOK;

		private Button cmdCancel;

		private ZYKBTreeView tvwKB;

		private KB_List mySelectedList = null;

		private Button cmdNew;

		private Container components = null;

		public KB_List SelectedList
		{
			get
			{
				return mySelectedList;
			}
			set
			{
				mySelectedList = value;
				tvwKB.SelectedKBList = value;
			}
		}

		public bool ShowNewButton
		{
			get
			{
				return cmdNew.Visible;
			}
			set
			{
				cmdNew.Visible = false;
			}
		}

		public dlgKBPath()
		{
			InitializeComponent();
			tvwKB.RootKBList = ZYKBBuffer.Instance.RootList;
			tvwKB.ShowKBItem = false;
			tvwKB.ResetContent();
			tvwKB.LabelEdit = true;
			base.DialogResult = DialogResult.Cancel;
			cmdOK.Click += cmdOK_Click;
			cmdCancel.Click += cmdCancel_Click;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(ZYTextDocumentLib.dlgKBPath));
			tvwKB = new ZYTextDocumentLib.ZYKBTreeView();
			lblInfo = new System.Windows.Forms.Label();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			cmdNew = new System.Windows.Forms.Button();
			SuspendLayout();
			tvwKB.BindControl = null;
			tvwKB.DoubleClickMode = false;
			tvwKB.HideSelection = false;
			tvwKB.Indent = 14;
			tvwKB.ItemHeight = 18;
			tvwKB.Location = new System.Drawing.Point(8, 32);
			tvwKB.Name = "tvwKB";
			tvwKB.RootKBList = null;
			tvwKB.SelectedKBList = null;
			tvwKB.ShowKBItem = false;
			tvwKB.ShowNormalKBItem = false;
			tvwKB.ShowSystemKBItem = false;
			tvwKB.ShowTemplateKBItem = false;
			tvwKB.Size = new System.Drawing.Size(416, 296);
			tvwKB.TabIndex = 0;
			lblInfo.AutoSize = true;
			lblInfo.Location = new System.Drawing.Point(8, 8);
			lblInfo.Name = "lblInfo";
			lblInfo.Size = new System.Drawing.Size(91, 17);
			lblInfo.TabIndex = 1;
			lblInfo.Text = "请选择一个节点";
			cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdOK.Location = new System.Drawing.Point(256, 336);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 2;
			cmdOK.Text = "确定(&O)";
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(344, 336);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			cmdNew.Image = (System.Drawing.Image)resourceManager.GetObject("cmdNew.Image");
			cmdNew.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdNew.Location = new System.Drawing.Point(8, 336);
			cmdNew.Name = "cmdNew";
			cmdNew.Size = new System.Drawing.Size(96, 23);
			cmdNew.TabIndex = 4;
			cmdNew.Text = "新增子节点";
			cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cmdNew.Click += new System.EventHandler(cmdNew_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(434, 367);
			base.Controls.Add(cmdNew);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(lblInfo);
			base.Controls.Add(tvwKB);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgKBPath";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "知识库路径";
			ResumeLayout(false);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			mySelectedList = tvwKB.SelectedKBList;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			mySelectedList = null;
			Close();
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{
			if (tvwKB.SelectedNode == null || tvwKB.SelectedKBList == null || tvwKB.SelectedKBList.HasItems())
			{
				return;
			}
			string text = dlgInputBox.InputBox("输入新节点的名称", "新增节点", "新增节点");
			if (!StringCommon.isBlankString(text))
			{
				KB_List kB_List = tvwKB.SelectedKBList.NewChildList(text);
				if (kB_List != null)
				{
					TreeNode treeNode = new TreeNode();
					tvwKB.SelectedNode.Nodes.Add(treeNode);
					treeNode.Tag = kB_List;
					tvwKB.RefreshNode(treeNode);
					tvwKB.Focus();
					treeNode.EnsureVisible();
					ZYKBTreeView.GlobalRefreshChileNode(tvwKB, tvwKB.SelectedKBList);
					tvwKB.SelectedNode = treeNode;
				}
				else
				{
					MessageBox.Show("此处不能新建列表元素");
				}
			}
		}
	}
}

namespace Miniblink.Demo
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("控件形式");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("窗体形式");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("透明窗体");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("表现形式", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("从本地目录加载");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("从嵌入资源加载");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("从ZIP文件中加载");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("其他资源加载方式", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("JS调用C#");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("C#调用JS");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("RunJs");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("JS交互", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("事件");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("拦截与修改");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("打印与截图");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("自宿主web服务器");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("开发者工具");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("文件下载");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("文件拖放");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("功能演示", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            this.button6 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(12, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(279, 55);
            this.button6.TabIndex = 5;
            this.button6.Text = "本封装源代码";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(12, 73);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点2";
            treeNode1.Tag = "ctrl_mode";
            treeNode1.Text = "控件形式";
            treeNode2.Name = "节点3";
            treeNode2.Tag = "frm_mode";
            treeNode2.Text = "窗体形式";
            treeNode3.Name = "节点4";
            treeNode3.Tag = "tran_mode";
            treeNode3.Text = "透明窗体";
            treeNode4.Name = "节点1";
            treeNode4.Text = "表现形式";
            treeNode5.Name = "节点2";
            treeNode5.Tag = "file_loader";
            treeNode5.Text = "从本地目录加载";
            treeNode6.Name = "节点3";
            treeNode6.Tag = "embed_loader";
            treeNode6.Text = "从嵌入资源加载";
            treeNode7.Name = "节点0";
            treeNode7.Tag = "zip_loader";
            treeNode7.Text = "从ZIP文件中加载";
            treeNode8.Name = "节点0";
            treeNode8.Text = "其他资源加载方式";
            treeNode9.Name = "节点1";
            treeNode9.Tag = "js_call_net";
            treeNode9.Text = "JS调用C#";
            treeNode10.Name = "节点2";
            treeNode10.Tag = "net_call_js";
            treeNode10.Text = "C#调用JS";
            treeNode11.Name = "节点2";
            treeNode11.Tag = "runjs";
            treeNode11.Text = "RunJs";
            treeNode12.Name = "节点0";
            treeNode12.Text = "JS交互";
            treeNode13.Name = "节点0";
            treeNode13.Tag = "events";
            treeNode13.Text = "事件";
            treeNode14.Name = "节点0";
            treeNode14.Tag = "hook";
            treeNode14.Text = "拦截与修改";
            treeNode15.Name = "节点0";
            treeNode15.Tag = "image";
            treeNode15.Text = "打印与截图";
            treeNode16.Name = "节点1";
            treeNode16.Tag = "web";
            treeNode16.Text = "自宿主web服务器";
            treeNode17.Name = "节点0";
            treeNode17.Tag = "dev_tools";
            treeNode17.Text = "开发者工具";
            treeNode18.Name = "节点0";
            treeNode18.Tag = "download";
            treeNode18.Text = "文件下载";
            treeNode19.Name = "节点0";
            treeNode19.Tag = "drop_file";
            treeNode19.Text = "文件拖放";
            treeNode20.Name = "节点0";
            treeNode20.Text = "功能演示";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.treeView1.Size = new System.Drawing.Size(279, 314);
            this.treeView1.TabIndex = 6;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 399);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NetMiniblink";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

		}

		#endregion
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TreeView treeView1;
    }
}
namespace DCSoft.Writer.WinFormDemo
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tvwMenu = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.pageDemo = new System.Windows.Forms.TabPage();
            this.pageCode = new System.Windows.Forms.TabPage();
            this.myWebBrowser = new System.Windows.Forms.WebBrowser();
            this.pageScene = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.IsShowTreeview = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenSln = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenVideo = new System.Windows.Forms.ToolStripButton();
            this.tsbReturnMainDestop = new System.Windows.Forms.ToolStripButton();
            this.tsbTraditionalChineseVersion = new System.Windows.Forms.ToolStripButton();
            this.tsbWeavingVersion = new System.Windows.Forms.ToolStripButton();
            this.tsbTibetanEdition = new System.Windows.Forms.ToolStripButton();
            this.myTabControl.SuspendLayout();
            this.pageCode.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwMenu
            // 
            this.tvwMenu.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tvwMenu, "tvwMenu");
            this.tvwMenu.HideSelection = false;
            this.tvwMenu.Name = "tvwMenu";
            this.tvwMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tvwmenu_AfterSelect);
            this.tvwMenu.DoubleClick += new System.EventHandler(this.Tvwmenu_DoubleClick);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.pageDemo);
            this.myTabControl.Controls.Add(this.pageCode);
            this.myTabControl.Controls.Add(this.pageScene);
            resources.ApplyResources(this.myTabControl, "myTabControl");
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.SelectedIndex = 0;
            // 
            // pageDemo
            // 
            resources.ApplyResources(this.pageDemo, "pageDemo");
            this.pageDemo.Name = "pageDemo";
            this.pageDemo.UseVisualStyleBackColor = true;
            // 
            // pageCode
            // 
            this.pageCode.Controls.Add(this.myWebBrowser);
            resources.ApplyResources(this.pageCode, "pageCode");
            this.pageCode.Name = "pageCode";
            this.pageCode.UseVisualStyleBackColor = true;
            // 
            // myWebBrowser
            // 
            resources.ApplyResources(this.myWebBrowser, "myWebBrowser");
            this.myWebBrowser.Name = "myWebBrowser";
            // 
            // pageScene
            // 
            resources.ApplyResources(this.pageScene, "pageScene");
            this.pageScene.Name = "pageScene";
            this.pageScene.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IsShowTreeview,
            this.tsbOpenSln,
            this.tsbOpenVideo,
            this.tsbReturnMainDestop,
            this.tsbTraditionalChineseVersion,
            this.tsbWeavingVersion,
            this.tsbTibetanEdition});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // IsShowTreeview
            // 
            this.IsShowTreeview.CheckOnClick = true;
            this.IsShowTreeview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.IsShowTreeview, "IsShowTreeview");
            this.IsShowTreeview.Name = "IsShowTreeview";
            this.IsShowTreeview.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbOpenSln
            // 
            resources.ApplyResources(this.tsbOpenSln, "tsbOpenSln");
            this.tsbOpenSln.Name = "tsbOpenSln";
            this.tsbOpenSln.Click += new System.EventHandler(this.tsbOpenSln_Click);
            // 
            // tsbOpenVideo
            // 
            this.tsbOpenVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbOpenVideo, "tsbOpenVideo");
            this.tsbOpenVideo.Name = "tsbOpenVideo";
            this.tsbOpenVideo.Click += new System.EventHandler(this.tsbOpenVideo_Click);
            // 
            // tsbReturnMainDestop
            // 
            this.tsbReturnMainDestop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbReturnMainDestop, "tsbReturnMainDestop");
            this.tsbReturnMainDestop.Name = "tsbReturnMainDestop";
            this.tsbReturnMainDestop.Click += new System.EventHandler(this.tsbReturnMainDestop_Click);
            // 
            // tsbTraditionalChineseVersion
            // 
            this.tsbTraditionalChineseVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbTraditionalChineseVersion, "tsbTraditionalChineseVersion");
            this.tsbTraditionalChineseVersion.Name = "tsbTraditionalChineseVersion";
            this.tsbTraditionalChineseVersion.Click += new System.EventHandler(this.tsbTraditionalChineseVersion_Click);
            // 
            // tsbWeavingVersion
            // 
            this.tsbWeavingVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbWeavingVersion, "tsbWeavingVersion");
            this.tsbWeavingVersion.Name = "tsbWeavingVersion";
            this.tsbWeavingVersion.Click += new System.EventHandler(this.tsbWeavingVersion_Click);
            // 
            // tsbTibetanEdition
            // 
            this.tsbTibetanEdition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbTibetanEdition, "tsbTibetanEdition");
            this.tsbTibetanEdition.Name = "tsbTibetanEdition";
            this.tsbTibetanEdition.Click += new System.EventHandler(this.tsbTibetanEdition_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTabControl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvwMenu);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.myTabControl.ResumeLayout(false);
            this.pageCode.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwMenu;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl myTabControl;
        private System.Windows.Forms.TabPage pageDemo;
        private System.Windows.Forms.TabPage pageCode;
        private System.Windows.Forms.WebBrowser myWebBrowser;
        private System.Windows.Forms.TabPage pageScene;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbReturnMainDestop;
        private System.Windows.Forms.ToolStripButton tsbOpenVideo;
        private System.Windows.Forms.ToolStripButton tsbOpenSln;
        private System.Windows.Forms.ToolStripButton tsbTraditionalChineseVersion;
        private System.Windows.Forms.ToolStripButton tsbWeavingVersion;
        private System.Windows.Forms.ToolStripButton tsbTibetanEdition;
        private System.Windows.Forms.ToolStripButton IsShowTreeview;
    }
}
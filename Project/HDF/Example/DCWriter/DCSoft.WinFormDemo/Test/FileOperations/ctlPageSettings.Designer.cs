namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    partial class ctlPageSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlPageSettings));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHeng = new System.Windows.Forms.ToolStripButton();
            this.btnZong = new System.Windows.Forms.ToolStripButton();
            this.btnPageSettings = new System.Windows.Forms.ToolStripButton();
            this.btnSwapMergin = new System.Windows.Forms.ToolStripButton();
            this.btnEditBackImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuNoBlankText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBlankText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBlankLine1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBlankLine2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBlankLineS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuNoWM = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTextWM = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImageWM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuNoBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPageBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBorderBody = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.btnHeaderFooterDifferentFirstPage = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton8,
            this.toolStripButton10,
            this.toolStripSeparator1,
            this.btnHeng,
            this.btnZong,
            this.btnPageSettings,
            this.btnSwapMergin,
            this.btnEditBackImage,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripSeparator3,
            this.btnHeaderFooterDifferentFirstPage});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // toolStripButton1
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton1, "FileNew");
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton2, "FileOpen");
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // toolStripButton8
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton8, "FilePageSettings");
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            this.toolStripButton8.Name = "toolStripButton8";
            // 
            // toolStripButton10
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton10, "FilePrint");
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton10, "toolStripButton10");
            this.toolStripButton10.Name = "toolStripButton10";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnHeng
            // 
            this.btnHeng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnHeng, "btnHeng");
            this.btnHeng.Name = "btnHeng";
            this.btnHeng.Click += new System.EventHandler(this.btnHeng_Click);
            // 
            // btnZong
            // 
            this.btnZong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnZong, "btnZong");
            this.btnZong.Name = "btnZong";
            this.btnZong.Click += new System.EventHandler(this.btnZong_Click);
            // 
            // btnPageSettings
            // 
            this.btnPageSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPageSettings, "btnPageSettings");
            this.btnPageSettings.Name = "btnPageSettings";
            this.btnPageSettings.Click += new System.EventHandler(this.btnPageSettings_Click);
            // 
            // btnSwapMergin
            // 
            this.btnSwapMergin.CheckOnClick = true;
            this.btnSwapMergin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSwapMergin, "btnSwapMergin");
            this.btnSwapMergin.Name = "btnSwapMergin";
            this.btnSwapMergin.Click += new System.EventHandler(this.btnSwapMergin_Click);
            // 
            // btnEditBackImage
            // 
            this.btnEditBackImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnEditBackImage, "btnEditBackImage");
            this.btnEditBackImage.Name = "btnEditBackImage";
            this.btnEditBackImage.Click += new System.EventHandler(this.btnEditBackImage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoToolTip = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNoBlankText,
            this.menuBlankText,
            this.menuBlankLine1,
            this.menuBlankLine2,
            this.menuBlankLineS});
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // menuNoBlankText
            // 
            this.menuNoBlankText.Name = "menuNoBlankText";
            resources.ApplyResources(this.menuNoBlankText, "menuNoBlankText");
            this.menuNoBlankText.Click += new System.EventHandler(this.menuNoBlankText_Click);
            // 
            // menuBlankText
            // 
            this.menuBlankText.Name = "menuBlankText";
            resources.ApplyResources(this.menuBlankText, "menuBlankText");
            this.menuBlankText.Click += new System.EventHandler(this.menuBlankText_Click);
            // 
            // menuBlankLine1
            // 
            this.menuBlankLine1.Name = "menuBlankLine1";
            resources.ApplyResources(this.menuBlankLine1, "menuBlankLine1");
            this.menuBlankLine1.Click += new System.EventHandler(this.menuBlankLine1_Click);
            // 
            // menuBlankLine2
            // 
            this.menuBlankLine2.Name = "menuBlankLine2";
            resources.ApplyResources(this.menuBlankLine2, "menuBlankLine2");
            this.menuBlankLine2.Click += new System.EventHandler(this.menuBlankLine2_Click);
            // 
            // menuBlankLineS
            // 
            this.menuBlankLineS.Name = "menuBlankLineS";
            resources.ApplyResources(this.menuBlankLineS, "menuBlankLineS");
            this.menuBlankLineS.Click += new System.EventHandler(this.menuBlankLineS_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoToolTip = false;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNoWM,
            this.menuTextWM,
            this.menuImageWM});
            resources.ApplyResources(this.toolStripDropDownButton2, "toolStripDropDownButton2");
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            // 
            // menuNoWM
            // 
            this.menuNoWM.Name = "menuNoWM";
            resources.ApplyResources(this.menuNoWM, "menuNoWM");
            this.menuNoWM.Click += new System.EventHandler(this.menuNoWM_Click);
            // 
            // menuTextWM
            // 
            this.menuTextWM.Name = "menuTextWM";
            resources.ApplyResources(this.menuTextWM, "menuTextWM");
            this.menuTextWM.Click += new System.EventHandler(this.menuTextWM_Click);
            // 
            // menuImageWM
            // 
            this.menuImageWM.Name = "menuImageWM";
            resources.ApplyResources(this.menuImageWM, "menuImageWM");
            this.menuImageWM.Click += new System.EventHandler(this.menuImageWM_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNoBorder,
            this.menuPageBorder,
            this.menuBorderBody});
            resources.ApplyResources(this.toolStripDropDownButton3, "toolStripDropDownButton3");
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            // 
            // menuNoBorder
            // 
            this.menuNoBorder.Name = "menuNoBorder";
            resources.ApplyResources(this.menuNoBorder, "menuNoBorder");
            this.menuNoBorder.Click += new System.EventHandler(this.menuNoBorder_Click);
            // 
            // menuPageBorder
            // 
            this.menuPageBorder.Name = "menuPageBorder";
            resources.ApplyResources(this.menuPageBorder, "menuPageBorder");
            this.menuPageBorder.Click += new System.EventHandler(this.menuPageBorder_Click);
            // 
            // menuBorderBody
            // 
            this.menuBorderBody.Name = "menuBorderBody";
            resources.ApplyResources(this.menuBorderBody, "menuBorderBody");
            this.menuBorderBody.Click += new System.EventHandler(this.menuBorderBody_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            // 
            // btnHeaderFooterDifferentFirstPage
            // 
            this.btnHeaderFooterDifferentFirstPage.CheckOnClick = true;
            this.btnHeaderFooterDifferentFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnHeaderFooterDifferentFirstPage, "btnHeaderFooterDifferentFirstPage");
            this.btnHeaderFooterDifferentFirstPage.Name = "btnHeaderFooterDifferentFirstPage";
            this.btnHeaderFooterDifferentFirstPage.Click += new System.EventHandler(this.btnHeaderFooterDifferentFirstPage_Click);
            // 
            // ctlPageSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "ctlPageSettings";
            this.Load += new System.EventHandler(this.frmFilterValue_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Controls.WriterControl myWriterControl;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton btnHeng;
        private System.Windows.Forms.ToolStripButton btnZong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem menuNoBlankText;
        private System.Windows.Forms.ToolStripMenuItem menuBlankText;
        private System.Windows.Forms.ToolStripMenuItem menuBlankLine1;
        private System.Windows.Forms.ToolStripMenuItem menuBlankLine2;
        private System.Windows.Forms.ToolStripMenuItem menuBlankLineS;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem menuNoWM;
        private System.Windows.Forms.ToolStripMenuItem menuTextWM;
        private System.Windows.Forms.ToolStripMenuItem menuImageWM;
        private System.Windows.Forms.ToolStripButton btnPageSettings;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem menuNoBorder;
        private System.Windows.Forms.ToolStripMenuItem menuPageBorder;
        private System.Windows.Forms.ToolStripMenuItem menuBorderBody;
        private System.Windows.Forms.ToolStripButton btnSwapMergin;
        private System.Windows.Forms.ToolStripButton btnEditBackImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnHeaderFooterDifferentFirstPage;
    }
}
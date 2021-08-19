namespace DCSoft.Writer.WinFormDemo.Test.ViewMode
{
    partial class ctlTestViewMode
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestViewMode));
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbJumpPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbShiftJumpPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbAutoLineWrapViewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbPageViewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbNormalViewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbCleanViewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbComplexViewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbFormViewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbReadViewMode = new System.Windows.Forms.ToolStripButton();
            this.myWriterCommandControler = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myWriterCommandControler)).BeginInit();
            this.SuspendLayout();
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myWriterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myWriterControl.Font = new System.Drawing.Font("宋体", 12F);
            this.myWriterControl.Location = new System.Drawing.Point(0, 0);
            this.myWriterControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            this.myWriterControl.Size = new System.Drawing.Size(741, 384);
            this.myWriterControl.TabIndex = 2;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbJumpPrint,
            this.tsbShiftJumpPrint,
            this.tsbAutoLineWrapViewMode,
            this.tsbPageViewMode,
            this.tsbNormalViewMode,
            this.tsbCleanViewMode,
            this.tsbComplexViewMode,
            this.tsbFormViewMode,
            this.tsbReadViewMode});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(741, 25);
            this.toolStripMain.TabIndex = 3;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tsbJumpPrint
            // 
            this.tsbJumpPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbJumpPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbJumpPrint.Image")));
            this.tsbJumpPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJumpPrint.Name = "tsbJumpPrint";
            this.tsbJumpPrint.Size = new System.Drawing.Size(36, 22);
            this.tsbJumpPrint.Text = "续打";
            this.tsbJumpPrint.Click += new System.EventHandler(this.tsbJumpPrint_Click);
            // 
            // tsbShiftJumpPrint
            // 
            this.tsbShiftJumpPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShiftJumpPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbShiftJumpPrint.Image")));
            this.tsbShiftJumpPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShiftJumpPrint.Name = "tsbShiftJumpPrint";
            this.tsbShiftJumpPrint.Size = new System.Drawing.Size(60, 22);
            this.tsbShiftJumpPrint.Text = "偏移续打";
            this.tsbShiftJumpPrint.Click += new System.EventHandler(this.tsbShiftJumpPrint_Click);
            // 
            // tsbAutoLineWrapViewMode
            // 
            this.tsbAutoLineWrapViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAutoLineWrapViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbAutoLineWrapViewMode.Image")));
            this.tsbAutoLineWrapViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutoLineWrapViewMode.Name = "tsbAutoLineWrapViewMode";
            this.tsbAutoLineWrapViewMode.Size = new System.Drawing.Size(108, 22);
            this.tsbAutoLineWrapViewMode.Text = "自动换行视图模式";
            this.tsbAutoLineWrapViewMode.Click += new System.EventHandler(this.tsbAutoLineWrapViewMode_Click);
            // 
            // tsbPageViewMode
            // 
            this.tsbPageViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPageViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbPageViewMode.Image")));
            this.tsbPageViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPageViewMode.Name = "tsbPageViewMode";
            this.tsbPageViewMode.Size = new System.Drawing.Size(84, 22);
            this.tsbPageViewMode.Text = "页面视图模式";
            this.tsbPageViewMode.Click += new System.EventHandler(this.tsbPageViewMode_Click);
            // 
            // tsbNormalViewMode
            // 
            this.tsbNormalViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNormalViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbNormalViewMode.Image")));
            this.tsbNormalViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNormalViewMode.Name = "tsbNormalViewMode";
            this.tsbNormalViewMode.Size = new System.Drawing.Size(84, 22);
            this.tsbNormalViewMode.Text = "普通视图模式";
            this.tsbNormalViewMode.Click += new System.EventHandler(this.tsbNormalViewMode_Click);
            // 
            // tsbCleanViewMode
            // 
            this.tsbCleanViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCleanViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbCleanViewMode.Image")));
            this.tsbCleanViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCleanViewMode.Name = "tsbCleanViewMode";
            this.tsbCleanViewMode.Size = new System.Drawing.Size(84, 22);
            this.tsbCleanViewMode.Text = "整洁视图模式";
            this.tsbCleanViewMode.Click += new System.EventHandler(this.tsbCleanViewMode_Click);
            // 
            // tsbComplexViewMode
            // 
            this.tsbComplexViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbComplexViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbComplexViewMode.Image")));
            this.tsbComplexViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComplexViewMode.Name = "tsbComplexViewMode";
            this.tsbComplexViewMode.Size = new System.Drawing.Size(84, 22);
            this.tsbComplexViewMode.Text = "复杂视图模式";
            this.tsbComplexViewMode.Click += new System.EventHandler(this.tsbComplexViewMode_Click);
            // 
            // tsbFormViewMode
            // 
            this.tsbFormViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFormViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbFormViewMode.Image")));
            this.tsbFormViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFormViewMode.Name = "tsbFormViewMode";
            this.tsbFormViewMode.Size = new System.Drawing.Size(84, 22);
            this.tsbFormViewMode.Text = "表单视图模式";
            this.tsbFormViewMode.Click += new System.EventHandler(this.tsbFormViewMode_Click);
            // 
            // tsbReadViewMode
            // 
            this.tsbReadViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReadViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbReadViewMode.Image")));
            this.tsbReadViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReadViewMode.Name = "tsbReadViewMode";
            this.tsbReadViewMode.Size = new System.Drawing.Size(84, 22);
            this.tsbReadViewMode.Text = "阅读视图模式";
            this.tsbReadViewMode.Click += new System.EventHandler(this.tsbReadViewMode_Click);
            // 
            // ctlTestViewMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.myWriterControl);
            this.Name = "ctlTestViewMode";
            this.Size = new System.Drawing.Size(741, 384);
            this.Load += new System.EventHandler(this.ctlTestViewMode_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myWriterCommandControler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsbJumpPrint;
        private System.Windows.Forms.ToolStripButton tsbShiftJumpPrint;
        private System.Windows.Forms.ToolStripButton tsbAutoLineWrapViewMode;
        private System.Windows.Forms.ToolStripButton tsbPageViewMode;
        private System.Windows.Forms.ToolStripButton tsbNormalViewMode;
        private System.Windows.Forms.ToolStripButton tsbCleanViewMode;
        private System.Windows.Forms.ToolStripButton tsbComplexViewMode;
        private System.Windows.Forms.ToolStripButton tsbFormViewMode;
        private System.Windows.Forms.ToolStripButton tsbReadViewMode;
        private Commands.WriterCommandControler myWriterCommandControler;
    }
}

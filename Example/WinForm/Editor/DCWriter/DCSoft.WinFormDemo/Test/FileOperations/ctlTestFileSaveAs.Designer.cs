namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    partial class ctlTestFileSaveAs
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
            this.menuStripctlTestFileSaveAs = new System.Windows.Forms.MenuStrip();
            this.tspMenuItemSaveDirectly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsapMenuItemSaveSpecifyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSaveStream = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSaveWriter = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSaveRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSaveRTFStream = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSaveHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSaveSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSavePageImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuItemSavePDF = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveImagePDF = new System.Windows.Forms.ToolStripMenuItem();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.mFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripctlTestFileSaveAs.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripctlTestFileSaveAs
            // 
            this.menuStripctlTestFileSaveAs.AllowMerge = false;
            this.menuStripctlTestFileSaveAs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFileOpen,
            this.tspMenuItemSaveDirectly,
            this.tsapMenuItemSaveSpecifyFile,
            this.tspMenuItemSaveStream,
            this.tspMenuItemSaveWriter,
            this.tspMenuItemSaveRTF,
            this.tspMenuItemSaveRTFStream,
            this.tspMenuItemSaveHtml,
            this.tspMenuItemSaveSelection,
            this.tspMenuItemSavePageImage,
            this.tspMenuItemSavePDF,
            this.btnSaveImagePDF});
            this.menuStripctlTestFileSaveAs.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStripctlTestFileSaveAs.Location = new System.Drawing.Point(0, 0);
            this.menuStripctlTestFileSaveAs.Name = "menuStripctlTestFileSaveAs";
            this.menuStripctlTestFileSaveAs.Size = new System.Drawing.Size(665, 46);
            this.menuStripctlTestFileSaveAs.TabIndex = 0;
            this.menuStripctlTestFileSaveAs.Text = "menuStrip1";
            // 
            // tspMenuItemSaveDirectly
            // 
            this.tspMenuItemSaveDirectly.Name = "tspMenuItemSaveDirectly";
            this.tspMenuItemSaveDirectly.Size = new System.Drawing.Size(68, 21);
            this.tspMenuItemSaveDirectly.Text = "直接保存";
            this.tspMenuItemSaveDirectly.Click += new System.EventHandler(this.tspMenuItemSaveDirectly_Click);
            // 
            // tsapMenuItemSaveSpecifyFile
            // 
            this.tsapMenuItemSaveSpecifyFile.Name = "tsapMenuItemSaveSpecifyFile";
            this.tsapMenuItemSaveSpecifyFile.Size = new System.Drawing.Size(104, 21);
            this.tsapMenuItemSaveSpecifyFile.Text = "保存到指定文件";
            this.tsapMenuItemSaveSpecifyFile.Click += new System.EventHandler(this.tsapMenuItemSaveSpecifyFile_Click);
            // 
            // tspMenuItemSaveStream
            // 
            this.tspMenuItemSaveStream.Name = "tspMenuItemSaveStream";
            this.tspMenuItemSaveStream.Size = new System.Drawing.Size(68, 21);
            this.tspMenuItemSaveStream.Text = "保存到流";
            this.tspMenuItemSaveStream.Click += new System.EventHandler(this.tspMenuItemSaveStream_Click);
            // 
            // tspMenuItemSaveWriter
            // 
            this.tspMenuItemSaveWriter.Name = "tspMenuItemSaveWriter";
            this.tspMenuItemSaveWriter.Size = new System.Drawing.Size(116, 21);
            this.tspMenuItemSaveWriter.Text = "保存到文本书写器";
            this.tspMenuItemSaveWriter.Click += new System.EventHandler(this.tspMenuItemSaveWriter_Click);
            // 
            // tspMenuItemSaveRTF
            // 
            this.tspMenuItemSaveRTF.Name = "tspMenuItemSaveRTF";
            this.tspMenuItemSaveRTF.Size = new System.Drawing.Size(101, 21);
            this.tspMenuItemSaveRTF.Text = "保存到RTF文件";
            this.tspMenuItemSaveRTF.Click += new System.EventHandler(this.tspMenuItemSaveRTF_Click);
            // 
            // tspMenuItemSaveRTFStream
            // 
            this.tspMenuItemSaveRTFStream.Name = "tspMenuItemSaveRTFStream";
            this.tspMenuItemSaveRTFStream.Size = new System.Drawing.Size(89, 21);
            this.tspMenuItemSaveRTFStream.Text = "保存到RTF流";
            this.tspMenuItemSaveRTFStream.Click += new System.EventHandler(this.tspMenuItemSaveRTFStream_Click);
            // 
            // tspMenuItemSaveHtml
            // 
            this.tspMenuItemSaveHtml.Name = "tspMenuItemSaveHtml";
            this.tspMenuItemSaveHtml.Size = new System.Drawing.Size(102, 21);
            this.tspMenuItemSaveHtml.Text = "保存HTML文件";
            this.tspMenuItemSaveHtml.Click += new System.EventHandler(this.tspMenuItemSaveHtml_Click);
            // 
            // tspMenuItemSaveSelection
            // 
            this.tspMenuItemSaveSelection.Name = "tspMenuItemSaveSelection";
            this.tspMenuItemSaveSelection.Size = new System.Drawing.Size(104, 21);
            this.tspMenuItemSaveSelection.Text = "保存选中的内容";
            this.tspMenuItemSaveSelection.Click += new System.EventHandler(this.tspMenuItemSaveSelection_Click);
            // 
            // tspMenuItemSavePageImage
            // 
            this.tspMenuItemSavePageImage.Name = "tspMenuItemSavePageImage";
            this.tspMenuItemSavePageImage.Size = new System.Drawing.Size(80, 21);
            this.tspMenuItemSavePageImage.Text = "保存成图片";
            this.tspMenuItemSavePageImage.Click += new System.EventHandler(this.tspMenuItemSavePageImage_Click);
            // 
            // tspMenuItemSavePDF
            // 
            this.tspMenuItemSavePDF.Name = "tspMenuItemSavePDF";
            this.tspMenuItemSavePDF.Size = new System.Drawing.Size(90, 21);
            this.tspMenuItemSavePDF.Text = "保存PDF文件";
            this.tspMenuItemSavePDF.Click += new System.EventHandler(this.tspMenuItemSavePDF_Click);
            // 
            // btnSaveImagePDF
            // 
            this.btnSaveImagePDF.Name = "btnSaveImagePDF";
            this.btnSaveImagePDF.Size = new System.Drawing.Size(114, 21);
            this.btnSaveImagePDF.Text = "保存图片PDF文件";
            this.btnSaveImagePDF.Click += new System.EventHandler(this.btnSaveImagePDF_Click);
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Gray;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myWriterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myWriterControl.Font = new System.Drawing.Font("宋体", 12F);
            this.myWriterControl.Location = new System.Drawing.Point(0, 46);
            this.myWriterControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            this.myWriterControl.Size = new System.Drawing.Size(665, 416);
            this.myWriterControl.TabIndex = 3;
            // 
            // mFileOpen
            // 
            this.mFileOpen.Name = "mFileOpen";
            this.mFileOpen.Size = new System.Drawing.Size(68, 21);
            this.mFileOpen.Text = "打开文件";
            this.mFileOpen.Click += new System.EventHandler(this.mFileOpen_Click);
            // 
            // ctlTestFileSaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.menuStripctlTestFileSaveAs);
            this.Name = "ctlTestFileSaveAs";
            this.Size = new System.Drawing.Size(665, 462);
            this.menuStripctlTestFileSaveAs.ResumeLayout(false);
            this.menuStripctlTestFileSaveAs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripctlTestFileSaveAs;
        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveDirectly;
        private System.Windows.Forms.ToolStripMenuItem tsapMenuItemSaveSpecifyFile;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveStream;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveWriter;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveRTF;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveRTFStream;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveHtml;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSaveSelection;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSavePageImage;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemSavePDF;
        private System.Windows.Forms.ToolStripMenuItem btnSaveImagePDF;
        private System.Windows.Forms.ToolStripMenuItem mFileOpen;
    }
}

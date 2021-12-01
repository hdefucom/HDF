namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    partial class ctlTestFileOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestFileOpen));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tspBtnbtnOpenSpecifyFile = new System.Windows.Forms.ToolStripButton();
            this.tspBtnOpenStream = new System.Windows.Forms.ToolStripButton();
            this.tspBtnOpenTextReader = new System.Windows.Forms.ToolStripButton();
            this.tspBtnOpenRTF = new System.Windows.Forms.ToolStripButton();
            this.tspBtnOpenRTFStream = new System.Windows.Forms.ToolStripButton();
            this.tspBtnOpenHtml = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOpenURL = new System.Windows.Forms.ToolStripButton();
            this.tspBbtnLoadReaderText = new System.Windows.Forms.ToolStripButton();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFileOpen,
            this.tspBtnbtnOpenSpecifyFile,
            this.tspBtnOpenStream,
            this.tspBtnOpenTextReader,
            this.tspBtnOpenRTF,
            this.tspBtnOpenRTFStream,
            this.tspBtnOpenHtml,
            this.tsBtnOpenURL,
            this.tspBbtnLoadReaderText});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(703, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFileOpen
            // 
            this.tsbFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileOpen.Image")));
            this.tsbFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileOpen.Name = "tsbFileOpen";
            this.tsbFileOpen.Size = new System.Drawing.Size(60, 22);
            this.tsbFileOpen.Text = "直接打开";
            this.tsbFileOpen.Click += new System.EventHandler(this.tsbFileOpen_Click);
            // 
            // tspBtnbtnOpenSpecifyFile
            // 
            this.tspBtnbtnOpenSpecifyFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnbtnOpenSpecifyFile.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnbtnOpenSpecifyFile.Image")));
            this.tspBtnbtnOpenSpecifyFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnbtnOpenSpecifyFile.Name = "tspBtnbtnOpenSpecifyFile";
            this.tspBtnbtnOpenSpecifyFile.Size = new System.Drawing.Size(84, 22);
            this.tspBtnbtnOpenSpecifyFile.Text = "打开指定文件";
            this.tspBtnbtnOpenSpecifyFile.Click += new System.EventHandler(this.tspBtnbtnOpenSpecifyFile_Click);
            // 
            // tspBtnOpenStream
            // 
            this.tspBtnOpenStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnOpenStream.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnOpenStream.Image")));
            this.tspBtnOpenStream.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnOpenStream.Name = "tspBtnOpenStream";
            this.tspBtnOpenStream.Size = new System.Drawing.Size(72, 22);
            this.tspBtnOpenStream.Text = "打开流文件";
            this.tspBtnOpenStream.Click += new System.EventHandler(this.tspBtnOpenStream_Click);
            // 
            // tspBtnOpenTextReader
            // 
            this.tspBtnOpenTextReader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnOpenTextReader.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnOpenTextReader.Image")));
            this.tspBtnOpenTextReader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnOpenTextReader.Name = "tspBtnOpenTextReader";
            this.tspBtnOpenTextReader.Size = new System.Drawing.Size(72, 22);
            this.tspBtnOpenTextReader.Text = "文本读取器";
            this.tspBtnOpenTextReader.Click += new System.EventHandler(this.tspBtnOpenTextReader_Click);
            // 
            // tspBtnOpenRTF
            // 
            this.tspBtnOpenRTF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnOpenRTF.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnOpenRTF.Image")));
            this.tspBtnOpenRTF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnOpenRTF.Name = "tspBtnOpenRTF";
            this.tspBtnOpenRTF.Size = new System.Drawing.Size(81, 22);
            this.tspBtnOpenRTF.Text = "打开RTF文件";
            this.tspBtnOpenRTF.Click += new System.EventHandler(this.tspBtnOpenRTF_Click);
            // 
            // tspBtnOpenRTFStream
            // 
            this.tspBtnOpenRTFStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnOpenRTFStream.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnOpenRTFStream.Image")));
            this.tspBtnOpenRTFStream.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnOpenRTFStream.Name = "tspBtnOpenRTFStream";
            this.tspBtnOpenRTFStream.Size = new System.Drawing.Size(69, 22);
            this.tspBtnOpenRTFStream.Text = "打开RTF流";
            this.tspBtnOpenRTFStream.Click += new System.EventHandler(this.tspBtnOpenRTFStream_Click);
            // 
            // tspBtnOpenHtml
            // 
            this.tspBtnOpenHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnOpenHtml.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnOpenHtml.Image")));
            this.tspBtnOpenHtml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnOpenHtml.Name = "tspBtnOpenHtml";
            this.tspBtnOpenHtml.Size = new System.Drawing.Size(94, 22);
            this.tspBtnOpenHtml.Text = "打开HTML文件";
            this.tspBtnOpenHtml.Click += new System.EventHandler(this.tspBtnOpenHtml_Click);
            // 
            // tsBtnOpenURL
            // 
            this.tsBtnOpenURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnOpenURL.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpenURL.Image")));
            this.tsBtnOpenURL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenURL.Name = "tsBtnOpenURL";
            this.tsBtnOpenURL.Size = new System.Drawing.Size(83, 22);
            this.tsBtnOpenURL.Text = "打开URL文件";
            this.tsBtnOpenURL.Click += new System.EventHandler(this.tsBtnOpenURL_Click);
            // 
            // tspBbtnLoadReaderText
            // 
            this.tspBbtnLoadReaderText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBbtnLoadReaderText.Image = ((System.Drawing.Image)(resources.GetObject("tspBbtnLoadReaderText.Image")));
            this.tspBbtnLoadReaderText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBbtnLoadReaderText.Name = "tspBbtnLoadReaderText";
            this.tspBbtnLoadReaderText.Size = new System.Drawing.Size(48, 22);
            this.tspBbtnLoadReaderText.Text = "加载流";
            this.tspBbtnLoadReaderText.Click += new System.EventHandler(this.tspBbtnLoadReaderText_Click);
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Gray;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myWriterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myWriterControl.Font = new System.Drawing.Font("宋体", 12F);
            this.myWriterControl.Location = new System.Drawing.Point(0, 25);
            this.myWriterControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            this.myWriterControl.Size = new System.Drawing.Size(703, 423);
            this.myWriterControl.TabIndex = 2;
            // 
            // ctlTestFileOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestFileOpen";
            this.Size = new System.Drawing.Size(703, 448);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFileOpen;
        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStripButton tspBtnbtnOpenSpecifyFile;
        private System.Windows.Forms.ToolStripButton tspBtnOpenStream;
        private System.Windows.Forms.ToolStripButton tspBtnOpenTextReader;
        private System.Windows.Forms.ToolStripButton tspBtnOpenRTF;
        private System.Windows.Forms.ToolStripButton tspBtnOpenRTFStream;
        private System.Windows.Forms.ToolStripButton tspBtnOpenHtml;
        private System.Windows.Forms.ToolStripButton tsBtnOpenURL;
        private System.Windows.Forms.ToolStripButton tspBbtnLoadReaderText;
    }
}

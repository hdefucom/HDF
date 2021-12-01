namespace DCSoft.Writer.WinFormDemo.Test.UI
{
    partial class ctlCustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCustomMessageBox));
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspStatusLabelPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspStatusLabelAbout = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetStdMessageBox = new System.Windows.Forms.ToolStripButton();
            this.btnSetCustomMessageBox = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myWriterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myWriterControl.Font = new System.Drawing.Font("宋体", 12F);
            this.myWriterControl.Location = new System.Drawing.Point(0, 25);
            this.myWriterControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.Size = new System.Drawing.Size(674, 377);
            this.myWriterControl.TabIndex = 8;
            this.myWriterControl.SelectionChanged += new DCSoft.Writer.WriterEventHandler(this.myWriterControl_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btnSetStdMessageBox,
            this.btnSetCustomMessageBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspStatusLabelStatus,
            this.tspStatusLabelPosition,
            this.tspStatusLabelAbout});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 26);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspStatusLabelStatus
            // 
            this.tspStatusLabelStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tspStatusLabelStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tspStatusLabelStatus.Name = "tspStatusLabelStatus";
            this.tspStatusLabelStatus.Size = new System.Drawing.Size(283, 21);
            this.tspStatusLabelStatus.Spring = true;
            this.tspStatusLabelStatus.Text = "状态";
            // 
            // tspStatusLabelPosition
            // 
            this.tspStatusLabelPosition.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tspStatusLabelPosition.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tspStatusLabelPosition.Name = "tspStatusLabelPosition";
            this.tspStatusLabelPosition.Size = new System.Drawing.Size(283, 21);
            this.tspStatusLabelPosition.Spring = true;
            this.tspStatusLabelPosition.Text = "位置";
            // 
            // tspStatusLabelAbout
            // 
            this.tspStatusLabelAbout.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tspStatusLabelAbout.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tspStatusLabelAbout.Name = "tspStatusLabelAbout";
            this.tspStatusLabelAbout.Size = new System.Drawing.Size(93, 21);
            this.tspStatusLabelAbout.Text = "DCWriter 演示";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "打开文件";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSetStdMessageBox
            // 
            this.btnSetStdMessageBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSetStdMessageBox.Image = ((System.Drawing.Image)(resources.GetObject("btnSetStdMessageBox.Image")));
            this.btnSetStdMessageBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetStdMessageBox.Name = "btnSetStdMessageBox";
            this.btnSetStdMessageBox.Size = new System.Drawing.Size(96, 22);
            this.btnSetStdMessageBox.Text = "使用标准消息框";
            this.btnSetStdMessageBox.Click += new System.EventHandler(this.btnSetStdMessageBox_Click);
            // 
            // btnSetCustomMessageBox
            // 
            this.btnSetCustomMessageBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSetCustomMessageBox.Image = ((System.Drawing.Image)(resources.GetObject("btnSetCustomMessageBox.Image")));
            this.btnSetCustomMessageBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetCustomMessageBox.Name = "btnSetCustomMessageBox";
            this.btnSetCustomMessageBox.Size = new System.Drawing.Size(108, 22);
            this.btnSetCustomMessageBox.Text = "使用自定义消息框";
            this.btnSetCustomMessageBox.Click += new System.EventHandler(this.btnSetCustomMessageBox_Click);
            // 
            // ctlCustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlCustomMessageBox";
            this.Size = new System.Drawing.Size(674, 428);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusLabelPosition;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusLabelAbout;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSetStdMessageBox;
        private System.Windows.Forms.ToolStripButton btnSetCustomMessageBox;
    }
}

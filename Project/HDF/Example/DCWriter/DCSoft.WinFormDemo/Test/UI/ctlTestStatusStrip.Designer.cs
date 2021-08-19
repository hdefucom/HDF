namespace DCSoft.Writer.WinFormDemo.Test.UI
{
    partial class ctlTestStatusStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestStatusStrip));
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSetRuleVisible = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspStatusLabelPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspStatusLabelAbout = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbSetBackgroundColor = new System.Windows.Forms.ToolStripButton();
            this.tsbPageBorderColor = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.tsbSetRuleVisible,
            this.tsbSetBackgroundColor,
            this.tsbPageBorderColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSetRuleVisible
            // 
            this.tsbSetRuleVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSetRuleVisible.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetRuleVisible.Image")));
            this.tsbSetRuleVisible.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetRuleVisible.Name = "tsbSetRuleVisible";
            this.tsbSetRuleVisible.Size = new System.Drawing.Size(60, 22);
            this.tsbSetRuleVisible.Text = "设置标尺";
            this.tsbSetRuleVisible.Click += new System.EventHandler(this.tsbSetRuleVisible_Click);
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
            // tsbSetBackgroundColor
            // 
            this.tsbSetBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSetBackgroundColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetBackgroundColor.Image")));
            this.tsbSetBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetBackgroundColor.Name = "tsbSetBackgroundColor";
            this.tsbSetBackgroundColor.Size = new System.Drawing.Size(72, 22);
            this.tsbSetBackgroundColor.Text = "设置背景色";
            this.tsbSetBackgroundColor.Click += new System.EventHandler(this.tsbSetBackgroundColor_Click);
            // 
            // tsbPageBorderColor
            // 
            this.tsbPageBorderColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPageBorderColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbPageBorderColor.Image")));
            this.tsbPageBorderColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPageBorderColor.Name = "tsbPageBorderColor";
            this.tsbPageBorderColor.Size = new System.Drawing.Size(108, 22);
            this.tsbPageBorderColor.Text = "编辑区域边界颜色";
            this.tsbPageBorderColor.Click += new System.EventHandler(this.tsbPageBorderColor_Click);
            // 
            // ctlTestStatusStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestStatusStrip";
            this.Size = new System.Drawing.Size(674, 428);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSetRuleVisible;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusLabelPosition;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusLabelAbout;
        private System.Windows.Forms.ToolStripButton tsbSetBackgroundColor;
        private System.Windows.Forms.ToolStripButton tsbPageBorderColor;
    }
}

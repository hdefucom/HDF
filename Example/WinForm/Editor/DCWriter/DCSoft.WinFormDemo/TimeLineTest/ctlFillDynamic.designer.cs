namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    partial class ctlFillDynamic
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlFillDynamic));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFillCrossThread = new System.Windows.Forms.ToolStripButton();
            this.btnStopThread = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDesigner = new System.Windows.Forms.ToolStripButton();
            this.myTemperatureChartControl = new DCSoft.TemperatureChart.TemperatureControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFillCrossThread,
            this.btnStopThread,
            this.toolStripSeparator4,
            this.btnDesigner});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(759, 24);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFillCrossThread
            // 
            this.btnFillCrossThread.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFillCrossThread.Image = ((System.Drawing.Image)(resources.GetObject("btnFillCrossThread.Image")));
            this.btnFillCrossThread.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillCrossThread.Name = "btnFillCrossThread";
            this.btnFillCrossThread.Size = new System.Drawing.Size(96, 21);
            this.btnFillCrossThread.Text = "跨线程实时填充";
            this.btnFillCrossThread.Click += new System.EventHandler(this.btnFillCrossThread_Click);
            // 
            // btnStopThread
            // 
            this.btnStopThread.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStopThread.Enabled = false;
            this.btnStopThread.Image = ((System.Drawing.Image)(resources.GetObject("btnStopThread.Image")));
            this.btnStopThread.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopThread.Name = "btnStopThread";
            this.btnStopThread.Size = new System.Drawing.Size(36, 21);
            this.btnStopThread.Text = "停止";
            this.btnStopThread.Click += new System.EventHandler(this.btnStopThread_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDesigner
            // 
            this.btnDesigner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDesigner.Image = ((System.Drawing.Image)(resources.GetObject("btnDesigner.Image")));
            this.btnDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(72, 21);
            this.btnDesigner.Text = "运行设计器";
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // myTemperatureChartControl
            // 
            this.myTemperatureChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTemperatureChartControl.Location = new System.Drawing.Point(0, 24);
            this.myTemperatureChartControl.Name = "myTemperatureChartControl";
            this.myTemperatureChartControl.Size = new System.Drawing.Size(759, 345);
            this.myTemperatureChartControl.TabIndex = 1;
            this.myTemperatureChartControl.ViewMode = DCSoft.TemperatureChart.DocumentViewMode.Timeline;
            // 
            // ctlFillDynamic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTemperatureChartControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlFillDynamic";
            this.Size = new System.Drawing.Size(759, 369);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private DCSoft.TemperatureChart.TemperatureControl myTemperatureChartControl;
        private System.Windows.Forms.ToolStripButton btnDesigner;
        private System.Windows.Forms.ToolStripButton btnFillCrossThread;
        private System.Windows.Forms.ToolStripButton btnStopThread;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}


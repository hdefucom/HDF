namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    partial class ctlTimeLineTimeZone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTimeLineTimeZone));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTestBoundsOper = new System.Windows.Forms.ToolStripButton();
            this.btnBoundsOper2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDesigner = new System.Windows.Forms.ToolStripButton();
            this.myTemperatureChartControl = new DCSoft.TemperatureChart.TemperatureControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBoundsOper2,
            this.btnTestBoundsOper,
            this.toolStripSeparator3,
            this.btnDesigner});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(759, 24);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTestBoundsOper
            // 
            this.btnTestBoundsOper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTestBoundsOper.Image = ((System.Drawing.Image)(resources.GetObject("btnTestBoundsOper.Image")));
            this.btnTestBoundsOper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestBoundsOper.Name = "btnTestBoundsOper";
            this.btnTestBoundsOper.Size = new System.Drawing.Size(72, 21);
            this.btnTestBoundsOper.Text = "围术期数据";
            this.btnTestBoundsOper.Click += new System.EventHandler(this.btnTestBoundsOper_Click);
            // 
            // btnBoundsOper2
            // 
            this.btnBoundsOper2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBoundsOper2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBoundsOper2.Image = ((System.Drawing.Image)(resources.GetObject("btnBoundsOper2.Image")));
            this.btnBoundsOper2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoundsOper2.Name = "btnBoundsOper2";
            this.btnBoundsOper2.Size = new System.Drawing.Size(84, 21);
            this.btnBoundsOper2.Text = "居民健康档案";
            this.btnBoundsOper2.Click += new System.EventHandler(this.btnBoundsOper2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
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
            // ctlTimeLineTimeZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTemperatureChartControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTimeLineTimeZone";
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTestBoundsOper;
        private System.Windows.Forms.ToolStripButton btnBoundsOper2;
    }
}


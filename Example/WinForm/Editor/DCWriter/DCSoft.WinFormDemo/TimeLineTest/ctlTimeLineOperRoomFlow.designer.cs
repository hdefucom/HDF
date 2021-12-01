namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    partial class ctlTimeLineOperRoomFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTimeLineOperRoomFlow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSchedule = new System.Windows.Forms.ToolStripButton();
            this.btnDesigner = new System.Windows.Forms.ToolStripButton();
            this.myTemperatureChartControl = new DCSoft.TemperatureChart.TemperatureControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSchedule,
            this.btnDesigner});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(759, 24);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSchedule
            // 
            this.btnSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(60, 21);
            this.btnSchedule.Text = "手术排程";
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
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
            // ctlTimeLineOperRoomFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTemperatureChartControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTimeLineOperRoomFlow";
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
        private System.Windows.Forms.ToolStripButton btnSchedule;
    }
}


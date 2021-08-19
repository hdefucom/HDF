namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    partial class ctlTimeLineNormal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTimeLineNormal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFill100000 = new System.Windows.Forms.ToolStripButton();
            this.btnFillSimple = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnLayout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveDataHtml = new System.Windows.Forms.ToolStripButton();
            this.btnDesigner = new System.Windows.Forms.ToolStripButton();
            this.btnCustomDesigner = new System.Windows.Forms.ToolStripButton();
            this.btnJump = new System.Windows.Forms.ToolStripButton();
            this.btnRegister = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.myTemperatureChartControl = new DCSoft.TemperatureChart.TemperatureControl();
            this.btnOpenDemo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFill100000,
            this.btnFillSimple,
            this.btnOpenDemo,
            this.toolStripSeparator4,
            this.btnShowConfig,
            this.toolStripButton1,
            this.btnLayout,
            this.toolStripSeparator2,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnSaveDataHtml,
            this.btnDesigner,
            this.btnCustomDesigner,
            this.btnJump,
            this.btnRegister});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(759, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFill100000
            // 
            this.btnFill100000.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFill100000.Image = ((System.Drawing.Image)(resources.GetObject("btnFill100000.Image")));
            this.btnFill100000.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFill100000.Name = "btnFill100000";
            this.btnFill100000.Size = new System.Drawing.Size(96, 21);
            this.btnFill100000.Text = "填充一万数据点";
            this.btnFill100000.Click += new System.EventHandler(this.btnFill100000_Click);
            // 
            // btnFillSimple
            // 
            this.btnFillSimple.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFillSimple.Image = ((System.Drawing.Image)(resources.GetObject("btnFillSimple.Image")));
            this.btnFillSimple.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillSimple.Name = "btnFillSimple";
            this.btnFillSimple.Size = new System.Drawing.Size(96, 21);
            this.btnFillSimple.Text = "填充百万数据点";
            this.btnFillSimple.Click += new System.EventHandler(this.btnFillSimple_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnShowConfig
            // 
            this.btnShowConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnShowConfig.Image")));
            this.btnShowConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowConfig.Name = "btnShowConfig";
            this.btnShowConfig.Size = new System.Drawing.Size(84, 21);
            this.btnShowConfig.Text = "显示配置文本";
            this.btnShowConfig.Click += new System.EventHandler(this.btnShowConfig_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 21);
            this.toolStripButton1.Text = "重新绘制";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnLayout
            // 
            this.btnLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnLayout.Image")));
            this.btnLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Size = new System.Drawing.Size(60, 21);
            this.btnLayout.Text = "重新排版";
            this.btnLayout.Click += new System.EventHandler(this.btnLayout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(85, 21);
            this.btnOpen.Text = "加载文件...";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 21);
            this.btnSave.Text = "保存文件...";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnSaveDataHtml
            // 
            this.btnSaveDataHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveDataHtml.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveDataHtml.Image")));
            this.btnSaveDataHtml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDataHtml.Name = "btnSaveDataHtml";
            this.btnSaveDataHtml.Size = new System.Drawing.Size(94, 21);
            this.btnSaveDataHtml.Text = "导出数据HTML";
            this.btnSaveDataHtml.Click += new System.EventHandler(this.btnSaveDataHtml_Click);
            // 
            // btnDesigner
            // 
            this.btnDesigner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDesigner.Image = ((System.Drawing.Image)(resources.GetObject("btnDesigner.Image")));
            this.btnDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(96, 21);
            this.btnDesigner.Text = "运行内置设计器";
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // btnCustomDesigner
            // 
            this.btnCustomDesigner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCustomDesigner.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomDesigner.Image")));
            this.btnCustomDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCustomDesigner.Name = "btnCustomDesigner";
            this.btnCustomDesigner.Size = new System.Drawing.Size(108, 21);
            this.btnCustomDesigner.Text = "运行自定义设计器";
            this.btnCustomDesigner.Click += new System.EventHandler(this.btnCustomDesigner_Click);
            // 
            // btnJump
            // 
            this.btnJump.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnJump.Image = ((System.Drawing.Image)(resources.GetObject("btnJump.Image")));
            this.btnJump.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(36, 21);
            this.btnJump.Text = "跳转";
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.Image")));
            this.btnRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(45, 21);
            this.btnRegister.Text = "注册...";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(759, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "DCTimeLine(都昌时间轴控件）是C#开发，是南京都昌信息科技有限公司自主研发的具有完全知识产权。公司网址 www.dcwriter.cn，联系邮箱2834" +
                "8092@qq.com.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // myTemperatureChartControl
            // 
            this.myTemperatureChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTemperatureChartControl.Location = new System.Drawing.Point(0, 88);
            this.myTemperatureChartControl.Name = "myTemperatureChartControl";
            this.myTemperatureChartControl.Size = new System.Drawing.Size(759, 281);
            this.myTemperatureChartControl.TabIndex = 1;
            this.myTemperatureChartControl.ViewMode = DCSoft.TemperatureChart.DocumentViewMode.Timeline;
            // 
            // btnOpenDemo
            // 
            this.btnOpenDemo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenDemo.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDemo.Image")));
            this.btnOpenDemo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDemo.Name = "btnOpenDemo";
            this.btnOpenDemo.Size = new System.Drawing.Size(84, 21);
            this.btnOpenDemo.Text = "打开演示文件";
            this.btnOpenDemo.Click += new System.EventHandler(this.btnOpenDemo_Click);
            // 
            // ctlTimeLineNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTemperatureChartControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "ctlTimeLineNormal";
            this.Size = new System.Drawing.Size(759, 369);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private DCSoft.TemperatureChart.TemperatureControl myTemperatureChartControl;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btnShowConfig;
        private System.Windows.Forms.ToolStripButton btnFillSimple;
        private System.Windows.Forms.ToolStripButton btnDesigner;
        private System.Windows.Forms.ToolStripButton btnJump;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRegister;
        private System.Windows.Forms.ToolStripButton btnSaveDataHtml;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnLayout;
        private System.Windows.Forms.ToolStripButton btnFill100000;
        private System.Windows.Forms.ToolStripButton btnCustomDesigner;
        private System.Windows.Forms.ToolStripButton btnOpenDemo;
    }
}


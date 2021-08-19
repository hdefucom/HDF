namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    partial class ctlTestSetCells
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestSetCells));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnUndo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnGetDate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnTableRowProperties = new System.Windows.Forms.ToolStripButton();
            this.myControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnSaveFile,
            this.toolStripBtnPrint,
            this.toolStripBtnUndo,
            this.toolStripBtnRedo,
            this.toolStripBtnGetDate,
            this.toolStripButton1,
            this.btnTableRowProperties});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripBtnSaveFile
            // 
            this.toolStripBtnSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripBtnSaveFile, "toolStripBtnSaveFile");
            this.toolStripBtnSaveFile.Name = "toolStripBtnSaveFile";
            this.toolStripBtnSaveFile.Click += new System.EventHandler(this.toolStripBtnSaveFile_Click);
            // 
            // toolStripBtnPrint
            // 
            this.toolStripBtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripBtnPrint, "toolStripBtnPrint");
            this.toolStripBtnPrint.Name = "toolStripBtnPrint";
            this.toolStripBtnPrint.Click += new System.EventHandler(this.toolStripBtnPrint_Click);
            // 
            // toolStripBtnUndo
            // 
            this.toolStripBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnUndo.Name = "toolStripBtnUndo";
            resources.ApplyResources(this.toolStripBtnUndo, "toolStripBtnUndo");
            this.toolStripBtnUndo.Click += new System.EventHandler(this.toolStripBtnUndo_Click);
            // 
            // toolStripBtnRedo
            // 
            this.toolStripBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripBtnRedo, "toolStripBtnRedo");
            this.toolStripBtnRedo.Name = "toolStripBtnRedo";
            this.toolStripBtnRedo.Click += new System.EventHandler(this.toolStripBtnRedo_Click);
            // 
            // toolStripBtnGetDate
            // 
            this.toolStripBtnGetDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripBtnGetDate, "toolStripBtnGetDate");
            this.toolStripBtnGetDate.Name = "toolStripBtnGetDate";
            this.toolStripBtnGetDate.Click += new System.EventHandler(this.toolStripBtnGetDate_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnTableRowProperties
            // 
            this.btnTableRowProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnTableRowProperties, "btnTableRowProperties");
            this.btnTableRowProperties.Name = "btnTableRowProperties";
            this.btnTableRowProperties.Click += new System.EventHandler(this.btnTableRowProperties_Click);
            // 
            // myControl
            // 
            this.myControl.AllowDrop = true;
            this.myControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.myControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myControl, "myControl");
            this.myControl.Name = "myControl";
            this.myControl.RuleVisible = true;
            // 
            // ctlTestSetCells
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestSetCells";
            this.Load += new System.EventHandler(this.ctlTestSetCells_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripBtnUndo;
        internal Controls.WriterControl myControl;
        private System.Windows.Forms.ToolStripButton toolStripBtnSaveFile;
        private System.Windows.Forms.ToolStripButton toolStripBtnPrint;
        private System.Windows.Forms.ToolStripButton toolStripBtnRedo;
        private System.Windows.Forms.ToolStripButton toolStripBtnGetDate;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnTableRowProperties;
    }
}

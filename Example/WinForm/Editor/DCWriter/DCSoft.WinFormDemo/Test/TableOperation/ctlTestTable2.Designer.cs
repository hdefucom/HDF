namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    partial class ctlTestTable2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestTable2));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpenDemoFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMirrorView = new System.Windows.Forms.ToolStripButton();
            this.btnNewPage = new System.Windows.Forms.ToolStripButton();
            this.btnSplitTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenDemoFile,
            this.toolStripSeparator1,
            this.btnMirrorView,
            this.btnNewPage,
            this.btnSplitTable,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // btnOpenDemoFile
            // 
            this.btnOpenDemoFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenDemoFile, "btnOpenDemoFile");
            this.btnOpenDemoFile.Name = "btnOpenDemoFile";
            this.btnOpenDemoFile.Click += new System.EventHandler(this.btnOpenDemoFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnMirrorView
            // 
            this.btnMirrorView.CheckOnClick = true;
            this.btnMirrorView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnMirrorView, "btnMirrorView");
            this.btnMirrorView.Name = "btnMirrorView";
            this.btnMirrorView.Click += new System.EventHandler(this.btnMirrorView_Click);
            // 
            // btnNewPage
            // 
            this.btnNewPage.CheckOnClick = true;
            this.btnNewPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnNewPage, "btnNewPage");
            this.btnNewPage.Name = "btnNewPage";
            this.btnNewPage.Click += new System.EventHandler(this.btnNewPage_Click);
            // 
            // btnSplitTable
            // 
            this.btnSplitTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSplitTable, "btnSplitTable");
            this.btnSplitTable.Name = "btnSplitTable";
            this.btnSplitTable.Click += new System.EventHandler(this.btnSplitTable_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            // 
            // ctlTestTable2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestTable2";
            this.Load += new System.EventHandler(this.frmFilterValue_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.WriterControl myWriterControl;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripButton btnOpenDemoFile;
        private System.Windows.Forms.ToolStripButton btnMirrorView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNewPage;
        private System.Windows.Forms.ToolStripButton btnSplitTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
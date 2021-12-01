namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    partial class ctlTestInjectCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestInjectCommand));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInsertImage = new System.Windows.Forms.ToolStripButton();
            this.btnInsertTable = new System.Windows.Forms.ToolStripButton();
            this.btnInsertTable2 = new System.Windows.Forms.ToolStripButton();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.btnInsertImage,
            this.btnInsertTable,
            this.btnInsertTable2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // toolStripButton1
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton1, "FileOpen");
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton2, "FileSave");
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton3, "ViewXMLSource");
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnInsertImage
            // 
            this.writerCommandControler1.SetCommandName(this.btnInsertImage, "InsertImage");
            resources.ApplyResources(this.btnInsertImage, "btnInsertImage");
            this.btnInsertImage.Name = "btnInsertImage";
            // 
            // btnInsertTable
            // 
            resources.ApplyResources(this.btnInsertTable, "btnInsertTable");
            this.btnInsertTable.Name = "btnInsertTable";
            this.btnInsertTable.Click += new System.EventHandler(this.btnInsertTable_Click);
            // 
            // btnInsertTable2
            // 
            resources.ApplyResources(this.btnInsertTable2, "btnInsertTable2");
            this.btnInsertTable2.Name = "btnInsertTable2";
            this.btnInsertTable2.Click += new System.EventHandler(this.btnInsertTable2_Click);
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            // 
            // ctlTestInjectCommand
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestInjectCommand";
            this.Load += new System.EventHandler(this.frmTestInjectCommand_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnInsertImage;
        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btnInsertTable;
        private System.Windows.Forms.ToolStripButton btnInsertTable2;
    }
}
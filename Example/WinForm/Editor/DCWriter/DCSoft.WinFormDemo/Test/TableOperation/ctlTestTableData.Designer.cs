namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    partial class ctlTestTableData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestTableData));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpenDemoFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnList = new System.Windows.Forms.ToolStripButton();
            this.btnInsertTableAndBindingDataTable = new System.Windows.Forms.ToolStripButton();
            this.btnBindingXML = new System.Windows.Forms.ToolStripButton();
            this.btnSortTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnLeftRightAndUpDown2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpDownAndLeftRight3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenDemoFile,
            this.toolStripSeparator1,
            this.btnList,
            this.btnInsertTableAndBindingDataTable,
            this.btnBindingXML,
            this.btnSortTable,
            this.toolStripButton1,
            this.toolStripDropDownButton1});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // btnOpenDemoFile
            // 
            this.writerCommandControler1.SetCommandName(this.btnOpenDemoFile, "FileNew");
            this.btnOpenDemoFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenDemoFile, "btnOpenDemoFile");
            this.btnOpenDemoFile.Name = "btnOpenDemoFile";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnList
            // 
            this.btnList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnInsertTableAndBindingDataTable
            // 
            this.btnInsertTableAndBindingDataTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnInsertTableAndBindingDataTable, "btnInsertTableAndBindingDataTable");
            this.btnInsertTableAndBindingDataTable.Name = "btnInsertTableAndBindingDataTable";
            this.btnInsertTableAndBindingDataTable.Click += new System.EventHandler(this.btnInsertTableAndBindingDataTable_Click);
            // 
            // btnBindingXML
            // 
            this.btnBindingXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnBindingXML, "btnBindingXML");
            this.btnBindingXML.Name = "btnBindingXML";
            this.btnBindingXML.Click += new System.EventHandler(this.btnBindingXML_Click);
            // 
            // btnSortTable
            // 
            this.btnSortTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSortTable, "btnSortTable");
            this.btnSortTable.Name = "btnSortTable";
            this.btnSortTable.Click += new System.EventHandler(this.btnSortTable_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLeftRightAndUpDown2,
            this.btnUpDownAndLeftRight3});
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // btnLeftRightAndUpDown2
            // 
            this.btnLeftRightAndUpDown2.Name = "btnLeftRightAndUpDown2";
            resources.ApplyResources(this.btnLeftRightAndUpDown2, "btnLeftRightAndUpDown2");
            this.btnLeftRightAndUpDown2.Click += new System.EventHandler(this.btnLeftRightAndUpDown2_Click);
            // 
            // btnUpDownAndLeftRight3
            // 
            this.btnUpDownAndLeftRight3.Name = "btnUpDownAndLeftRight3";
            resources.ApplyResources(this.btnUpDownAndLeftRight3, "btnUpDownAndLeftRight3");
            this.btnUpDownAndLeftRight3.Click += new System.EventHandler(this.btnUpDownAndLeftRight3_Click);
            // 
            // ctlTestTableData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestTableData";
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnInsertTableAndBindingDataTable;
        private System.Windows.Forms.ToolStripButton btnSortTable;
        private System.Windows.Forms.ToolStripButton btnList;
        private System.Windows.Forms.ToolStripButton btnBindingXML;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnLeftRightAndUpDown2;
        private System.Windows.Forms.ToolStripMenuItem btnUpDownAndLeftRight3;
    }
}
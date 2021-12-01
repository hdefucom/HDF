namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    partial class ctlTestExcludeKeywords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestExcludeKeywords));
            this.writerControl1 = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtExcludeKeywords = new System.Windows.Forms.ToolStripTextBox();
            this.btnSetValue = new System.Windows.Forms.ToolStripButton();
            this.btnDocumentValidate = new System.Windows.Forms.ToolStripButton();
            this.btnDocumentValueValidateWithCreateDocumentComments = new System.Windows.Forms.ToolStripButton();
            this.lvwItem = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // writerControl1
            // 
            this.writerControl1.BackColor = System.Drawing.Color.Gray;
            this.writerControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.writerControl1, "writerControl1");
            this.writerControl1.Name = "writerControl1";
            this.writerControl1.RuleVisible = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtExcludeKeywords,
            this.btnSetValue,
            this.btnDocumentValidate,
            this.btnDocumentValueValidateWithCreateDocumentComments});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // txtExcludeKeywords
            // 
            this.txtExcludeKeywords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExcludeKeywords.Name = "txtExcludeKeywords";
            resources.ApplyResources(this.txtExcludeKeywords, "txtExcludeKeywords");
            // 
            // btnSetValue
            // 
            this.btnSetValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSetValue, "btnSetValue");
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // btnDocumentValidate
            // 
            this.btnDocumentValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnDocumentValidate, "btnDocumentValidate");
            this.btnDocumentValidate.Name = "btnDocumentValidate";
            this.btnDocumentValidate.Click += new System.EventHandler(this.btnDocumentValidate_Click);
            // 
            // btnDocumentValueValidateWithCreateDocumentComments
            // 
            this.btnDocumentValueValidateWithCreateDocumentComments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnDocumentValueValidateWithCreateDocumentComments, "btnDocumentValueValidateWithCreateDocumentComments");
            this.btnDocumentValueValidateWithCreateDocumentComments.Name = "btnDocumentValueValidateWithCreateDocumentComments";
            this.btnDocumentValueValidateWithCreateDocumentComments.Click += new System.EventHandler(this.btnDocumentValueValidateWithCreateDocumentComments_Click);
            // 
            // lvwItem
            // 
            resources.ApplyResources(this.lvwItem, "lvwItem");
            this.lvwItem.FullRowSelect = true;
            this.lvwItem.HideSelection = false;
            this.lvwItem.Name = "lvwItem";
            this.lvwItem.UseCompatibleStateImageBehavior = false;
            this.lvwItem.View = System.Windows.Forms.View.List;
            this.lvwItem.Click += new System.EventHandler(this.lvwItem_Click);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // ctlTestExcludeKeywords
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.writerControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lvwItem);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestExcludeKeywords";
            this.Load += new System.EventHandler(this.frmTestExcludeKeywords_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtExcludeKeywords;
        private System.Windows.Forms.ToolStripButton btnSetValue;
        private System.Windows.Forms.ToolStripButton btnDocumentValidate;
        private Controls.WriterControl writerControl1;
        private System.Windows.Forms.ListView lvwItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton btnDocumentValueValidateWithCreateDocumentComments;
    }
}
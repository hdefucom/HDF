namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    partial class ctlTestCheckMRID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestCheckMRID));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboStyle = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cboDataObjectRange = new System.Windows.Forms.ToolStripComboBox();
            this.btnSpecifyLimit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.writerControl1 = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtMRID1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy1 = new System.Windows.Forms.ToolStripButton();
            this.btnPaste1 = new System.Windows.Forms.ToolStripButton();
            this.btnIsTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.writerControl2 = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtMRID2 = new System.Windows.Forms.ToolStripTextBox();
            this.btnCopy2 = new System.Windows.Forms.ToolStripButton();
            this.btnPaste2 = new System.Windows.Forms.ToolStripButton();
            this.btnInsertXML = new System.Windows.Forms.ToolStripButton();
            this.btnOpen2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboStyle,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.cboDataObjectRange,
            this.btnSpecifyLimit});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.Name = "cboStyle";
            resources.ApplyResources(this.cboStyle, "cboStyle");
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            resources.ApplyResources(this.toolStripLabel4, "toolStripLabel4");
            // 
            // cboDataObjectRange
            // 
            this.cboDataObjectRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataObjectRange.Items.AddRange(new object[] {
            resources.GetString("cboDataObjectRange.Items"),
            resources.GetString("cboDataObjectRange.Items1"),
            resources.GetString("cboDataObjectRange.Items2")});
            this.cboDataObjectRange.Name = "cboDataObjectRange";
            resources.ApplyResources(this.cboDataObjectRange, "cboDataObjectRange");
            this.cboDataObjectRange.SelectedIndexChanged += new System.EventHandler(this.cboDataObjectRange_SelectedIndexChanged);
            // 
            // btnSpecifyLimit
            // 
            this.btnSpecifyLimit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSpecifyLimit, "btnSpecifyLimit");
            this.btnSpecifyLimit.Name = "btnSpecifyLimit";
            this.btnSpecifyLimit.Click += new System.EventHandler(this.btnSpecifyLimit_Click);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.writerControl1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.writerControl2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
            // 
            // writerControl1
            // 
            this.writerControl1.BackColor = System.Drawing.Color.Silver;
            this.writerControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.writerControl1, "writerControl1");
            this.writerControl1.Name = "writerControl1";
            this.writerControl1.RuleVisible = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txtMRID1,
            this.toolStripSeparator1,
            this.btnCopy1,
            this.btnPaste1,
            this.btnIsTemplate,
            this.toolStripButton1});
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Name = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            // 
            // txtMRID1
            // 
            this.txtMRID1.Name = "txtMRID1";
            resources.ApplyResources(this.txtMRID1, "txtMRID1");
            this.txtMRID1.TextChanged += new System.EventHandler(this.txtMRID1_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnCopy1
            // 
            this.btnCopy1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnCopy1, "btnCopy1");
            this.btnCopy1.Name = "btnCopy1";
            this.btnCopy1.Click += new System.EventHandler(this.btnCopy1_Click);
            // 
            // btnPaste1
            // 
            this.btnPaste1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPaste1, "btnPaste1");
            this.btnPaste1.Name = "btnPaste1";
            this.btnPaste1.Click += new System.EventHandler(this.btnPaste1_Click);
            // 
            // btnIsTemplate
            // 
            this.btnIsTemplate.CheckOnClick = true;
            this.btnIsTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnIsTemplate, "btnIsTemplate");
            this.btnIsTemplate.Name = "btnIsTemplate";
            this.btnIsTemplate.Click += new System.EventHandler(this.btnIsTemplate_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // writerControl2
            // 
            this.writerControl2.BackColor = System.Drawing.Color.Silver;
            this.writerControl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.writerControl2, "writerControl2");
            this.writerControl2.Name = "writerControl2";
            this.writerControl2.RuleVisible = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.txtMRID2,
            this.btnCopy2,
            this.btnPaste2,
            this.btnInsertXML,
            this.btnOpen2});
            resources.ApplyResources(this.toolStrip3, "toolStrip3");
            this.toolStrip3.Name = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            resources.ApplyResources(this.toolStripLabel3, "toolStripLabel3");
            // 
            // txtMRID2
            // 
            this.txtMRID2.Name = "txtMRID2";
            resources.ApplyResources(this.txtMRID2, "txtMRID2");
            this.txtMRID2.TextChanged += new System.EventHandler(this.txtMRID2_TextChanged);
            // 
            // btnCopy2
            // 
            this.btnCopy2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnCopy2, "btnCopy2");
            this.btnCopy2.Name = "btnCopy2";
            this.btnCopy2.Click += new System.EventHandler(this.btnCopy2_Click);
            // 
            // btnPaste2
            // 
            this.btnPaste2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPaste2, "btnPaste2");
            this.btnPaste2.Name = "btnPaste2";
            this.btnPaste2.Click += new System.EventHandler(this.btnPaste2_Click);
            // 
            // btnInsertXML
            // 
            this.btnInsertXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnInsertXML, "btnInsertXML");
            this.btnInsertXML.Name = "btnInsertXML";
            this.btnInsertXML.Click += new System.EventHandler(this.btnInsertXML_Click);
            // 
            // btnOpen2
            // 
            this.btnOpen2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpen2, "btnOpen2");
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // ctlTestCheckMRID
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestCheckMRID";
            this.Load += new System.EventHandler(this.frmTestCheckMRID_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboStyle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.WriterControl writerControl1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtMRID1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCopy1;
        private System.Windows.Forms.ToolStripButton btnPaste1;
        private Controls.WriterControl writerControl2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtMRID2;
        private System.Windows.Forms.ToolStripButton btnCopy2;
        private System.Windows.Forms.ToolStripButton btnPaste2;
        private System.Windows.Forms.ToolStripButton btnIsTemplate;
        private System.Windows.Forms.ToolStripButton btnInsertXML;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnOpen2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cboDataObjectRange;
        private System.Windows.Forms.ToolStripButton btnSpecifyLimit;
    }
}
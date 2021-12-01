namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    partial class ctlFileFormatConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlFileFormatConvert));
            this.cboDestFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseDestFile = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtDestFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbDest = new System.Windows.Forms.GroupBox();
            this.cboSourceFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSourceFile = new System.Windows.Forms.Button();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDest.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDestFormat
            // 
            this.cboDestFormat.FormattingEnabled = true;
            this.cboDestFormat.Items.AddRange(new object[] {
            resources.GetString("cboDestFormat.Items"),
            resources.GetString("cboDestFormat.Items1"),
            resources.GetString("cboDestFormat.Items2"),
            resources.GetString("cboDestFormat.Items3"),
            resources.GetString("cboDestFormat.Items4"),
            resources.GetString("cboDestFormat.Items5")});
            resources.ApplyResources(this.cboDestFormat, "cboDestFormat");
            this.cboDestFormat.Name = "cboDestFormat";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnBrowseDestFile
            // 
            resources.ApplyResources(this.btnBrowseDestFile, "btnBrowseDestFile");
            this.btnBrowseDestFile.Name = "btnBrowseDestFile";
            this.btnBrowseDestFile.UseVisualStyleBackColor = true;
            this.btnBrowseDestFile.Click += new System.EventHandler(this.btnBrowseDestFile_Click);
            // 
            // btnRun
            // 
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtDestFile
            // 
            resources.ApplyResources(this.txtDestFile, "txtDestFile");
            this.txtDestFile.Name = "txtDestFile";
            this.txtDestFile.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // gbDest
            // 
            this.gbDest.Controls.Add(this.cboDestFormat);
            this.gbDest.Controls.Add(this.label3);
            this.gbDest.Controls.Add(this.btnBrowseDestFile);
            this.gbDest.Controls.Add(this.txtDestFile);
            this.gbDest.Controls.Add(this.label4);
            resources.ApplyResources(this.gbDest, "gbDest");
            this.gbDest.Name = "gbDest";
            this.gbDest.TabStop = false;
            // 
            // cboSourceFormat
            // 
            this.cboSourceFormat.FormattingEnabled = true;
            this.cboSourceFormat.Items.AddRange(new object[] {
            resources.GetString("cboSourceFormat.Items"),
            resources.GetString("cboSourceFormat.Items1"),
            resources.GetString("cboSourceFormat.Items2"),
            resources.GetString("cboSourceFormat.Items3")});
            resources.ApplyResources(this.cboSourceFormat, "cboSourceFormat");
            this.cboSourceFormat.Name = "cboSourceFormat";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnSourceFile
            // 
            resources.ApplyResources(this.btnSourceFile, "btnSourceFile");
            this.btnSourceFile.Name = "btnSourceFile";
            this.btnSourceFile.UseVisualStyleBackColor = true;
            this.btnSourceFile.Click += new System.EventHandler(this.btnSourceFile_Click);
            // 
            // txtSourceFile
            // 
            resources.ApplyResources(this.txtSourceFile, "txtSourceFile");
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.ReadOnly = true;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.cboSourceFormat);
            this.gbSource.Controls.Add(this.label2);
            this.gbSource.Controls.Add(this.btnSourceFile);
            this.gbSource.Controls.Add(this.txtSourceFile);
            this.gbSource.Controls.Add(this.label1);
            resources.ApplyResources(this.gbSource, "gbSource");
            this.gbSource.Name = "gbSource";
            this.gbSource.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ctlFileFormatConvert
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.gbDest);
            this.Controls.Add(this.gbSource);
            this.Name = "ctlFileFormatConvert";
            this.Load += new System.EventHandler(this.ctlFileFormatConvert_Load);
            this.gbDest.ResumeLayout(false);
            this.gbDest.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDestFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseDestFile;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtDestFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbDest;
        private System.Windows.Forms.ComboBox cboSourceFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSourceFile;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.Label label1;

    }
}
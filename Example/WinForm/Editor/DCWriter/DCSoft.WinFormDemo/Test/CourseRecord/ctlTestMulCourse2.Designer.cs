namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    partial class ctlTestMulCourse2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestMulCourse2));
            this.myViewControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoadSpecifyFile = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditRecord = new System.Windows.Forms.ToolStripButton();
            this.btnNewRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.mySplitContainer = new System.Windows.Forms.SplitContainer();
            this.myWriterControlExt = new DCSoft.Writer.Controls.WriterControlExt();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboCurrentUser = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboArea = new System.Windows.Forms.ToolStripComboBox();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.mySplitContainer.Panel1.SuspendLayout();
            this.mySplitContainer.Panel2.SuspendLayout();
            this.mySplitContainer.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // myViewControl
            // 
            this.myViewControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.myViewControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myViewControl, "myViewControl");
            this.myViewControl.Name = "myViewControl";
            this.myViewControl.PageBackColor = System.Drawing.Color.WhiteSmoke;
            this.myViewControl.Readonly = true;
            this.myViewControl.RuleVisible = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadSpecifyFile,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnEditRecord,
            this.btnNewRecord,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.btnCopy,
            this.toolStripButton3});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // btnLoadSpecifyFile
            // 
            this.btnLoadSpecifyFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnLoadSpecifyFile, "btnLoadSpecifyFile");
            this.btnLoadSpecifyFile.Name = "btnLoadSpecifyFile";
            this.btnLoadSpecifyFile.Click += new System.EventHandler(this.btnLoadSpecifyFile_Click);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnEditRecord
            // 
            resources.ApplyResources(this.btnEditRecord, "btnEditRecord");
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnNewRecord
            // 
            resources.ApplyResources(this.btnNewRecord, "btnNewRecord");
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButton1
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton1, "JumpPrintMode");
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton2, "FilePrint");
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            // 
            // toolStripButton3
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton3, "DocumentGridLine");
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // mySplitContainer
            // 
            this.mySplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.mySplitContainer, "mySplitContainer");
            this.mySplitContainer.Name = "mySplitContainer";
            // 
            // mySplitContainer.Panel1
            // 
            this.mySplitContainer.Panel1.Controls.Add(this.myViewControl);
            this.mySplitContainer.Panel1.Controls.Add(this.toolStrip1);
            // 
            // mySplitContainer.Panel2
            // 
            this.mySplitContainer.Panel2.Controls.Add(this.myWriterControlExt);
            this.mySplitContainer.Panel2.Controls.Add(this.toolStrip2);
            // 
            // myWriterControlExt
            // 
            this.myWriterControlExt.AutoSetDocumentDefaultFont = false;
            this.myWriterControlExt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.myWriterControlExt, "myWriterControlExt");
            this.myWriterControlExt.Name = "myWriterControlExt";
            this.myWriterControlExt.TrackListVisible = DCSoft.Writer.Controls.FunctionControlVisibility.Hide;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboCurrentUser,
            this.toolStripLabel2,
            this.cboArea,
            this.btnSave,
            this.btnCancel});
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Name = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // cboCurrentUser
            // 
            this.cboCurrentUser.Items.AddRange(new object[] {
            resources.GetString("cboCurrentUser.Items"),
            resources.GetString("cboCurrentUser.Items1"),
            resources.GetString("cboCurrentUser.Items2"),
            resources.GetString("cboCurrentUser.Items3"),
            resources.GetString("cboCurrentUser.Items4")});
            this.cboCurrentUser.Name = "cboCurrentUser";
            resources.ApplyResources(this.cboCurrentUser, "cboCurrentUser");
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            // 
            // cboArea
            // 
            this.cboArea.Items.AddRange(new object[] {
            resources.GetString("cboArea.Items"),
            resources.GetString("cboArea.Items1"),
            resources.GetString("cboArea.Items2"),
            resources.GetString("cboArea.Items3")});
            this.cboArea.Name = "cboArea";
            resources.ApplyResources(this.cboArea, "cboArea");
            this.cboArea.TextChanged += new System.EventHandler(this.cboArea_TextChanged);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctlTestMulCourse2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mySplitContainer);
            this.Name = "ctlTestMulCourse2";
            this.Load += new System.EventHandler(this.frmTestMulSection_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.mySplitContainer.Panel1.ResumeLayout(false);
            this.mySplitContainer.Panel1.PerformLayout();
            this.mySplitContainer.Panel2.ResumeLayout(false);
            this.mySplitContainer.Panel2.PerformLayout();
            this.mySplitContainer.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private Controls.WriterControl myViewControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNewRecord;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.SplitContainer mySplitContainer;
        private Controls.WriterControlExt myWriterControlExt;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboCurrentUser;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnEditRecord;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cboArea;
        private System.Windows.Forms.ToolStripButton btnLoadSpecifyFile;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}
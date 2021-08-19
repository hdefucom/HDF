namespace DCSoft.Writer.WinFormDemo.Test
{
    partial class frmEditOneDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditOneDocument));
            this.myWriterControlExt = new DCSoft.Writer.Controls.WriterControlExt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myWriterControlExt
            // 
            resources.ApplyResources(this.myWriterControlExt, "myWriterControlExt");
            this.myWriterControlExt.HeaderFooterReadonly = true;
            this.myWriterControlExt.Name = "myWriterControlExt";
            this.myWriterControlExt.TrackListVisible = DCSoft.Writer.Controls.FunctionControlVisibility.Hide;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // cboUser
            // 
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Items.AddRange(new object[] {
            resources.GetString("cboUser.Items"),
            resources.GetString("cboUser.Items1"),
            resources.GetString("cboUser.Items2")});
            resources.ApplyResources(this.cboUser, "cboUser");
            this.cboUser.Name = "cboUser";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmEditOneDocument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControlExt);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmEditOneDocument";
            this.Load += new System.EventHandler(this.frmEditOneDocument_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WriterControlExt myWriterControlExt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label label1;
    }
}
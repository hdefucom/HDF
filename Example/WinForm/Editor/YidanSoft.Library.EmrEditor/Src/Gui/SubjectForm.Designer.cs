namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    partial class SubjectForm
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
            this.flowLayoutPanelZZ = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelZZ
            // 
            this.flowLayoutPanelZZ.AutoSize = true;
            this.flowLayoutPanelZZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.flowLayoutPanelZZ.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelZZ.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanelZZ.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelZZ.Name = "flowLayoutPanelZZ";
            this.flowLayoutPanelZZ.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.flowLayoutPanelZZ.Size = new System.Drawing.Size(438, 15);
            this.flowLayoutPanelZZ.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(438, 1);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelName
            // 
            this.labelName.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(7, 6);
            this.labelName.Margin = new System.Windows.Forms.Padding(4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 18);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "主诉";
            // 
            // panel2
            // 
            this.panel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel2.Appearance.Options.UseBackColor = true;
            this.panel2.Appearance.Options.UseTextOptions = true;
            this.panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 29);
            this.panel2.TabIndex = 4;
            // 
            // SubjectForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(438, 135);
            this.Controls.Add(this.flowLayoutPanelZZ);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.SubjectForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubjectForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SubjectForm_FormClosed);
            this.Load += new System.EventHandler(this.SubjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelZZ;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.PanelControl panel2;

    }
}
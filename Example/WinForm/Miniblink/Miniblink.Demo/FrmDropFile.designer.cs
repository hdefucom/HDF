namespace Miniblink.Demo
{
    partial class FrmDropFile
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
            this.miniblinkBrowser1 = new Miniblink.MiniblinkBrowser();
            this.SuspendLayout();
            // 
            // miniblinkBrowser1
            // 
            this.miniblinkBrowser1.AllowDrop = true;
            this.miniblinkBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miniblinkBrowser1.BackColor = System.Drawing.Color.White;
            this.miniblinkBrowser1.Location = new System.Drawing.Point(40, 39);
            this.miniblinkBrowser1.MouseMoveOptimize = true;
            this.miniblinkBrowser1.Name = "miniblinkBrowser1";
            this.miniblinkBrowser1.ResourceCache = null;
            this.miniblinkBrowser1.Size = new System.Drawing.Size(439, 159);
            this.miniblinkBrowser1.TabIndex = 0;
            // 
            // FrmDropFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 246);
            this.Controls.Add(this.miniblinkBrowser1);
            this.Name = "FrmDropFile";
            this.Text = "FrmDropFile";
            this.Load += new System.EventHandler(this.FrmDropFile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Miniblink.MiniblinkBrowser miniblinkBrowser1;
    }
}
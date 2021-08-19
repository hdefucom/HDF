namespace Miniblink.Demo
{
    partial class FrmImage
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(0, 370);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(492, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打 印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnImage
            // 
            this.btnImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImage.Location = new System.Drawing.Point(0, 347);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(492, 23);
            this.btnImage.TabIndex = 1;
            this.btnImage.Text = "截 图";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // FrmImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 393);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnPrint);
            this.Name = "FrmImage";
            this.Text = "打印与截图";
            this.Load += new System.EventHandler(this.FrmImage_Load);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnImage, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImage;
    }
}
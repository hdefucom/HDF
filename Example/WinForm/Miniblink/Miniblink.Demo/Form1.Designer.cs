
namespace Miniblink.Demo
{
    partial class Form1
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
            this.miniblinkBrowser1.BackColor = System.Drawing.Color.White;
            this.miniblinkBrowser1.Location = new System.Drawing.Point(72, 93);
            this.miniblinkBrowser1.MouseMoveOptimize = true;
            this.miniblinkBrowser1.Name = "miniblinkBrowser1";
            this.miniblinkBrowser1.ResourceCache = null;
            this.miniblinkBrowser1.Size = new System.Drawing.Size(673, 312);
            this.miniblinkBrowser1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.miniblinkBrowser1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MiniblinkBrowser miniblinkBrowser1;
    }
}
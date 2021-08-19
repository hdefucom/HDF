namespace DCSoft.Writer.WinFormDemo
{
    partial class frmMDIChild
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
            this.myEditControl = new DCSoft.Writer.Controls.WriterControl();
            this.SuspendLayout();
            // 
            // myEditControl
            // 
            this.myEditControl.AllowDrop = true;
            this.myEditControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.myEditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myEditControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myEditControl.Location = new System.Drawing.Point(0, 0);
            this.myEditControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myEditControl.Name = "myEditControl";
            this.myEditControl.RuleVisible = true;
            this.myEditControl.Size = new System.Drawing.Size(707, 441);
            this.myEditControl.TabIndex = 5;
            // 
            // frmMDIChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 441);
            this.Controls.Add(this.myEditControl);
            this.Name = "frmMDIChild";
            this.Text = "MDI子窗体";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.WriterControl myEditControl;
    }
}
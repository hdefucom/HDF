namespace HDF.Test.Winform
{
    partial class Form3
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
            this.centerLayoutPanel1 = new GHIS.Ctrl.CenterLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.centerLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // centerLayoutPanel1
            // 
            this.centerLayoutPanel1.AutoScroll = true;
            this.centerLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(250, 23);
            this.centerLayoutPanel1.Controls.Add(this.button1);
            this.centerLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.centerLayoutPanel1.Name = "centerLayoutPanel1";
            this.centerLayoutPanel1.Size = new System.Drawing.Size(250, 151);
            this.centerLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 151);
            this.Controls.Add(this.centerLayoutPanel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.centerLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GHIS.Ctrl.CenterLayoutPanel centerLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}
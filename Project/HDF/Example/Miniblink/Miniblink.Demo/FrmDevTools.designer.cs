namespace Miniblink.Demo
{
    partial class FrmDevTools
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
            this.btnDevTools = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDevTools
            // 
            this.btnDevTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDevTools.Location = new System.Drawing.Point(0, 599);
            this.btnDevTools.Name = "btnDevTools";
            this.btnDevTools.Size = new System.Drawing.Size(828, 60);
            this.btnDevTools.TabIndex = 1;
            this.btnDevTools.Text = "打开开发者工具(程序路径不能有奇怪的字符)";
            this.btnDevTools.UseVisualStyleBackColor = true;
            this.btnDevTools.Click += new System.EventHandler(this.btnDevTools_Click);
            // 
            // FrmDevTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 659);
            this.Controls.Add(this.btnDevTools);
            this.Name = "FrmDevTools";
            this.Text = "开发者工具";
            this.Load += new System.EventHandler(this.FrmDevTools_Load);
            this.Controls.SetChildIndex(this.btnDevTools, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDevTools;
    }
}
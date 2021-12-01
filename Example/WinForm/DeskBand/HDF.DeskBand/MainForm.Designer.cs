
namespace HDF.DeskBand
{
    partial class MainForm
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
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.txt_Target = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_Fixed = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Key
            // 
            this.txt_Key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Key.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Key.Location = new System.Drawing.Point(0, 0);
            this.txt_Key.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Key.Multiline = true;
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(228, 26);
            this.txt_Key.TabIndex = 0;
            this.txt_Key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Key_KeyUp);
            // 
            // txt_Target
            // 
            this.txt_Target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Target.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Target.Location = new System.Drawing.Point(10, 46);
            this.txt_Target.Multiline = true;
            this.txt_Target.Name = "txt_Target";
            this.txt_Target.Size = new System.Drawing.Size(264, 205);
            this.txt_Target.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Key);
            this.panel1.Controls.Add(this.cb_Fixed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 26);
            this.panel1.TabIndex = 1;
            // 
            // cb_Fixed
            // 
            this.cb_Fixed.AutoSize = true;
            this.cb_Fixed.Dock = System.Windows.Forms.DockStyle.Right;
            this.cb_Fixed.Location = new System.Drawing.Point(228, 0);
            this.cb_Fixed.Name = "cb_Fixed";
            this.cb_Fixed.Size = new System.Drawing.Size(36, 26);
            this.cb_Fixed.TabIndex = 1;
            this.cb_Fixed.Text = "✈";
            this.cb_Fixed.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txt_Target);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Key;
        private System.Windows.Forms.TextBox txt_Target;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cb_Fixed;
    }
}
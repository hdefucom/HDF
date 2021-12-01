namespace TextRuler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.advancedTextEditor1 = new TextRuler.AdvancedTextEditorControl.AdvancedTextEditor();
            this.SuspendLayout();
            // 
            // advancedTextEditor1
            // 
            this.advancedTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedTextEditor1.Location = new System.Drawing.Point(0, 0);
            this.advancedTextEditor1.Name = "advancedTextEditor1";
            this.advancedTextEditor1.Size = new System.Drawing.Size(745, 562);
            this.advancedTextEditor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(745, 562);
            this.Controls.Add(this.advancedTextEditor1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Text Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal TextRuler.AdvancedTextEditorControl.AdvancedTextEditor advancedTextEditor1;



    }
}
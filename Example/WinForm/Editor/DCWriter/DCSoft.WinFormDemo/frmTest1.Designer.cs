namespace DCSoft.Writer.WinFormDemo
{
    partial class frmTest1
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
            this.components = new System.ComponentModel.Container();
            this.writerControl1 = new DCSoft.Writer.Controls.WriterControl();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.writerControl2 = new DCSoft.Writer.Controls.WriterControl();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // writerControl1
            // 
            this.writerControl1.AcceptsTab = false;
            this.writerControl1.BackColor = System.Drawing.Color.Silver;
            this.writerControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.writerControl1.Location = new System.Drawing.Point(12, 38);
            this.writerControl1.Name = "writerControl1";
            this.writerControl1.RuleVisible = true;
            this.writerControl1.Size = new System.Drawing.Size(749, 182);
            this.writerControl1.TabIndex = 0;
            this.writerControl1.DocumentLoad += new DCSoft.Writer.WriterEventHandler(this.writerControl1_DocumentLoad);
            // 
            // writerControl2
            // 
            this.writerControl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.writerControl2.Location = new System.Drawing.Point(22, 245);
            this.writerControl2.Name = "writerControl2";
            this.writerControl2.RuleVisible = true;
            this.writerControl2.Size = new System.Drawing.Size(733, 118);
            this.writerControl2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 388);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 6;
            // 
            // frmTest1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 476);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.writerControl2);
            this.Controls.Add(this.writerControl1);
            this.Name = "frmTest1";
            this.Text = "frmTest1";
            this.Load += new System.EventHandler(this.frmTest1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WriterControl writerControl1;
        private Commands.WriterCommandControler writerCommandControler1;
        private Controls.WriterControl writerControl2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
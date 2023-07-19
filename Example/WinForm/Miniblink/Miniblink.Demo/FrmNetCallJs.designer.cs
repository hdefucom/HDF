namespace Miniblink.Demo
{
    partial class FrmNetCallJs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFunc1 = new System.Windows.Forms.Button();
            this.btnFunc2 = new System.Windows.Forms.Button();
            this.btnFunc3 = new System.Windows.Forms.Button();
            this.btnFunc4 = new System.Windows.Forms.Button();
            this.btnFunc5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFunc5);
            this.panel1.Controls.Add(this.btnFunc4);
            this.panel1.Controls.Add(this.btnFunc3);
            this.panel1.Controls.Add(this.btnFunc2);
            this.panel1.Controls.Add(this.btnFunc1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 674);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnFunc1
            // 
            this.btnFunc1.Location = new System.Drawing.Point(12, 13);
            this.btnFunc1.Name = "btnFunc1";
            this.btnFunc1.Size = new System.Drawing.Size(75, 23);
            this.btnFunc1.TabIndex = 0;
            this.btnFunc1.Text = "func_1";
            this.btnFunc1.UseVisualStyleBackColor = true;
            this.btnFunc1.Click += new System.EventHandler(this.btnFunc1_Click);
            // 
            // btnFunc2
            // 
            this.btnFunc2.Location = new System.Drawing.Point(93, 13);
            this.btnFunc2.Name = "btnFunc2";
            this.btnFunc2.Size = new System.Drawing.Size(75, 23);
            this.btnFunc2.TabIndex = 1;
            this.btnFunc2.Text = "func_2";
            this.btnFunc2.UseVisualStyleBackColor = true;
            this.btnFunc2.Click += new System.EventHandler(this.btnFunc2_Click);
            // 
            // btnFunc3
            // 
            this.btnFunc3.Location = new System.Drawing.Point(174, 13);
            this.btnFunc3.Name = "btnFunc3";
            this.btnFunc3.Size = new System.Drawing.Size(75, 23);
            this.btnFunc3.TabIndex = 2;
            this.btnFunc3.Text = "func_3";
            this.btnFunc3.UseVisualStyleBackColor = true;
            this.btnFunc3.Click += new System.EventHandler(this.btnFunc3_Click);
            // 
            // btnFunc4
            // 
            this.btnFunc4.Location = new System.Drawing.Point(255, 13);
            this.btnFunc4.Name = "btnFunc4";
            this.btnFunc4.Size = new System.Drawing.Size(75, 23);
            this.btnFunc4.TabIndex = 3;
            this.btnFunc4.Text = "func_4";
            this.btnFunc4.UseVisualStyleBackColor = true;
            this.btnFunc4.Click += new System.EventHandler(this.btnFunc4_Click);
            // 
            // btnFunc5
            // 
            this.btnFunc5.Location = new System.Drawing.Point(336, 13);
            this.btnFunc5.Name = "btnFunc5";
            this.btnFunc5.Size = new System.Drawing.Size(75, 23);
            this.btnFunc5.TabIndex = 4;
            this.btnFunc5.Text = "func_5";
            this.btnFunc5.UseVisualStyleBackColor = true;
            this.btnFunc5.Click += new System.EventHandler(this.btnFunc5_Click);
            // 
            // FrmNetCallJs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 724);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNetCallJs";
            this.Text = "NET调用JS";
            this.Load += new System.EventHandler(this.FrmNetCallJs_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFunc1;
        private System.Windows.Forms.Button btnFunc2;
        private System.Windows.Forms.Button btnFunc3;
        private System.Windows.Forms.Button btnFunc4;
        private System.Windows.Forms.Button btnFunc5;
    }
}
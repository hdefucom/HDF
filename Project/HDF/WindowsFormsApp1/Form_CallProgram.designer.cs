namespace HDF.Framework.Test
{
    partial class Form_CallProgram
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
            this.lbl_Path = new System.Windows.Forms.Label();
            this.txt_Parameter = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Selection = new System.Windows.Forms.Button();
            this.lbl_Parameter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.Location = new System.Drawing.Point(12, 15);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(53, 12);
            this.lbl_Path.TabIndex = 6;
            this.lbl_Path.Text = "程序路径";
            // 
            // txt_Parameter
            // 
            this.txt_Parameter.Location = new System.Drawing.Point(47, 48);
            this.txt_Parameter.Name = "txt_Parameter";
            this.txt_Parameter.Size = new System.Drawing.Size(249, 21);
            this.txt_Parameter.TabIndex = 5;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(313, 46);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "启动";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Selection
            // 
            this.btn_Selection.Location = new System.Drawing.Point(313, 10);
            this.btn_Selection.Name = "btn_Selection";
            this.btn_Selection.Size = new System.Drawing.Size(75, 23);
            this.btn_Selection.TabIndex = 4;
            this.btn_Selection.Text = "浏览";
            this.btn_Selection.UseVisualStyleBackColor = true;
            this.btn_Selection.Click += new System.EventHandler(this.btn_Selection_Click);
            // 
            // lbl_Parameter
            // 
            this.lbl_Parameter.AutoSize = true;
            this.lbl_Parameter.Location = new System.Drawing.Point(12, 51);
            this.lbl_Parameter.Name = "lbl_Parameter";
            this.lbl_Parameter.Size = new System.Drawing.Size(29, 12);
            this.lbl_Parameter.TabIndex = 6;
            this.lbl_Parameter.Text = "参数";
            // 
            // Form_CallProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 81);
            this.Controls.Add(this.lbl_Parameter);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.txt_Parameter);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Selection);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form_CallProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_CallProgram";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.TextBox txt_Parameter;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Selection;
        private System.Windows.Forms.Label lbl_Parameter;
    }
}
namespace HDF.Windows.Tools.Other
{
    partial class GetWindowsInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_UpdataTitle = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Get = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "句柄";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "标题";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "名称";
            // 
            // btn_UpdataTitle
            // 
            this.btn_UpdataTitle.Location = new System.Drawing.Point(15, 129);
            this.btn_UpdataTitle.Name = "btn_UpdataTitle";
            this.btn_UpdataTitle.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdataTitle.TabIndex = 1;
            this.btn_UpdataTitle.Text = "修改标题";
            this.btn_UpdataTitle.UseVisualStyleBackColor = true;
            this.btn_UpdataTitle.Click += new System.EventHandler(this.btn_UpdataTitle_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(135, 102);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(61, 23);
            this.btn_Get.TabIndex = 1;
            this.btn_Get.Text = "获取";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Get_MouseDown);
            this.btn_Get.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_Get_MouseMove);
            this.btn_Get.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Get_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 161);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Get);
            this.Controls.Add(this.btn_UpdataTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "获取windows句柄";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button btn_UpdataTitle;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button btn_Get;

    }
}
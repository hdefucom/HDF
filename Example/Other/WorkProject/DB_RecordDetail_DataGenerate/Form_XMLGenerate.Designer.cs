namespace DB_RecordDetail_DataGenerate
{
    partial class Form_XMLGenerate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.btn_Init_CYPG = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Init_SSHL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Init_JBJL = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.Location = new System.Drawing.Point(25, 64);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(316, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(347, 102);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(41, 12);
            this.lbl_progress.TabIndex = 1;
            this.lbl_progress.Text = "label1";
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(25, 96);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(316, 23);
            this.pb_progress.TabIndex = 2;
            // 
            // btn_Init_CYPG
            // 
            this.btn_Init_CYPG.Location = new System.Drawing.Point(25, 33);
            this.btn_Init_CYPG.Name = "btn_Init_CYPG";
            this.btn_Init_CYPG.Size = new System.Drawing.Size(75, 23);
            this.btn_Init_CYPG.TabIndex = 0;
            this.btn_Init_CYPG.Text = "初始化";
            this.btn_Init_CYPG.UseVisualStyleBackColor = true;
            this.btn_Init_CYPG.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "出院评估与指导";
            // 
            // btn_Init_SSHL
            // 
            this.btn_Init_SSHL.Location = new System.Drawing.Point(139, 33);
            this.btn_Init_SSHL.Name = "btn_Init_SSHL";
            this.btn_Init_SSHL.Size = new System.Drawing.Size(75, 23);
            this.btn_Init_SSHL.TabIndex = 0;
            this.btn_Init_SSHL.Text = "初始化";
            this.btn_Init_SSHL.UseVisualStyleBackColor = true;
            this.btn_Init_SSHL.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "手术护理记录";
            // 
            // btn_Init_JBJL
            // 
            this.btn_Init_JBJL.Location = new System.Drawing.Point(252, 33);
            this.btn_Init_JBJL.Name = "btn_Init_JBJL";
            this.btn_Init_JBJL.Size = new System.Drawing.Size(75, 23);
            this.btn_Init_JBJL.TabIndex = 0;
            this.btn_Init_JBJL.Text = "初始化";
            this.btn_Init_JBJL.UseVisualStyleBackColor = true;
            this.btn_Init_JBJL.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "交接班记录";
            // 
            // Form_XMLGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 132);
            this.Controls.Add(this.pb_progress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.btn_Init_JBJL);
            this.Controls.Add(this.btn_Init_SSHL);
            this.Controls.Add(this.btn_Init_CYPG);
            this.Controls.Add(this.btn_Start);
            this.Name = "Form_XMLGenerate";
            this.Text = "XML生成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_XMLGenerate_FormClosing);
            this.Load += new System.EventHandler(this.Form_XMLGenerate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.Button btn_Init_CYPG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Init_SSHL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Init_JBJL;
        private System.Windows.Forms.Label label3;
    }
}


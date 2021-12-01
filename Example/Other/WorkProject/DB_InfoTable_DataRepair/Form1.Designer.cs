namespace DB_InfoTable_DataRepair
{
    partial class Form1
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
            this.dt_Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_RunByDate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dt_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Progress = new System.Windows.Forms.Label();
            this.btn_RunAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dt_Start
            // 
            this.dt_Start.Location = new System.Drawing.Point(97, 22);
            this.dt_Start.Name = "dt_Start";
            this.dt_Start.Size = new System.Drawing.Size(200, 21);
            this.dt_Start.TabIndex = 0;
            this.dt_Start.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始";
            // 
            // bt_RunByDate
            // 
            this.bt_RunByDate.Location = new System.Drawing.Point(55, 88);
            this.bt_RunByDate.Name = "bt_RunByDate";
            this.bt_RunByDate.Size = new System.Drawing.Size(75, 23);
            this.bt_RunByDate.TabIndex = 2;
            this.bt_RunByDate.Text = "按时间修复";
            this.bt_RunByDate.UseVisualStyleBackColor = true;
            this.bt_RunByDate.Click += new System.EventHandler(this.bt_RunByDate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 137);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(216, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // dt_End
            // 
            this.dt_End.Location = new System.Drawing.Point(97, 49);
            this.dt_End.Name = "dt_End";
            this.dt_End.Size = new System.Drawing.Size(200, 21);
            this.dt_End.TabIndex = 0;
            this.dt_End.Value = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束";
            // 
            // lbl_Progress
            // 
            this.lbl_Progress.AutoSize = true;
            this.lbl_Progress.Location = new System.Drawing.Point(240, 143);
            this.lbl_Progress.Name = "lbl_Progress";
            this.lbl_Progress.Size = new System.Drawing.Size(23, 12);
            this.lbl_Progress.TabIndex = 1;
            this.lbl_Progress.Text = "0/0";
            // 
            // btn_RunAll
            // 
            this.btn_RunAll.Location = new System.Drawing.Point(168, 88);
            this.btn_RunAll.Name = "btn_RunAll";
            this.btn_RunAll.Size = new System.Drawing.Size(129, 23);
            this.btn_RunAll.TabIndex = 2;
            this.btn_RunAll.Text = "单独修复缺失all数据";
            this.btn_RunAll.UseVisualStyleBackColor = true;
            this.btn_RunAll.Click += new System.EventHandler(this.btn_RunAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 168);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_RunAll);
            this.Controls.Add(this.bt_RunByDate);
            this.Controls.Add(this.lbl_Progress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_End);
            this.Controls.Add(this.dt_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_RunByDate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DateTimePicker dt_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Progress;
        private System.Windows.Forms.Button btn_RunAll;
    }
}


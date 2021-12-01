namespace DCSoft.Writer.WinFormDemo.Test.UserControls
{
    partial class ApplicationScenes
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.writerControlApply = new DCSoft.Writer.Controls.WriterControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.writerControlRecord = new DCSoft.Writer.Controls.WriterControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 398);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "功能说明";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 60);
            this.label5.TabIndex = 4;
            this.label5.Text = "会诊申请:\r\n演示了内科医生张三向外科填写会诊申请界面。\r\n\r\n会诊记录：\r\n演示了外科医生李四填写会诊记录的录入界面。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "该界面目前展示了两个功能：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "适用于场景如：\r\n会诊单   等类似需要单文档多个人同时编写的场景。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "基于容器方法SetContentLockByCurrentUser()";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "该界面用来展示基于用户的内容锁定";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.writerControlApply);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 9F);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "会诊申请";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // writerControlApply
            // 
            this.writerControlApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writerControlApply.Location = new System.Drawing.Point(3, 3);
            this.writerControlApply.Margin = new System.Windows.Forms.Padding(4);
            this.writerControlApply.Name = "writerControlApply";
            this.writerControlApply.Size = new System.Drawing.Size(676, 362);
            this.writerControlApply.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.writerControlRecord);
            this.tabPage3.Font = new System.Drawing.Font("宋体", 9F);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(682, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "会诊记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // writerControlRecord
            // 
            this.writerControlRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writerControlRecord.Location = new System.Drawing.Point(0, 0);
            this.writerControlRecord.Margin = new System.Windows.Forms.Padding(4);
            this.writerControlRecord.Name = "writerControlRecord";
            this.writerControlRecord.Size = new System.Drawing.Size(682, 368);
            this.writerControlRecord.TabIndex = 0;
            // 
            // ApplicationScenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ApplicationScenes";
            this.Size = new System.Drawing.Size(690, 398);
            this.Load += new System.EventHandler(this.ApplicationScenes_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DCSoft.Writer.Controls.WriterControl writerControlApply;
        private DCSoft.Writer.Controls.WriterControl writerControlRecord;

    }
}

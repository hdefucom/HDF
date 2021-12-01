namespace YidanSoft.Library.EmrEditor.Src.Print
{
    partial class PrintExPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBoxHeader = new System.Windows.Forms.CheckBox();
            this.checkBoxFooter = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // checkBoxHeader
            // 
            this.checkBoxHeader.AutoSize = true;
            this.checkBoxHeader.Checked = true;
            this.checkBoxHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHeader.Location = new System.Drawing.Point(192, 22);
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxHeader.Size = new System.Drawing.Size(72, 16);
            this.checkBoxHeader.TabIndex = 2;
            this.checkBoxHeader.Text = "打印页眉";
            this.checkBoxHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxHeader.UseVisualStyleBackColor = true;
            // 
            // checkBoxFooter
            // 
            this.checkBoxFooter.AutoSize = true;
            this.checkBoxFooter.Checked = true;
            this.checkBoxFooter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFooter.Location = new System.Drawing.Point(270, 22);
            this.checkBoxFooter.Name = "checkBoxFooter";
            this.checkBoxFooter.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFooter.TabIndex = 3;
            this.checkBoxFooter.Text = "打印页脚";
            this.checkBoxFooter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkBoxFooter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxHeader);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 47);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "高级设置";
            // 
            // PrintExPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PrintExPanel";
            this.Size = new System.Drawing.Size(501, 58);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.CheckBox checkBoxHeader;
        public System.Windows.Forms.CheckBox checkBoxFooter;
    }
}

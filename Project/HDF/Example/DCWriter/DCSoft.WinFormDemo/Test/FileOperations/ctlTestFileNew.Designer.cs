﻿namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    partial class ctlTestFileNew
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
            this.mspItems = new System.Windows.Forms.MenuStrip();
            this.tspMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.mspItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspItems
            // 
            this.mspItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspMenuItemNew});
            this.mspItems.Location = new System.Drawing.Point(0, 0);
            this.mspItems.Name = "mspItems";
            this.mspItems.Size = new System.Drawing.Size(553, 25);
            this.mspItems.TabIndex = 0;
            this.mspItems.Text = "menuStrip1";
            // 
            // tspMenuItemNew
            // 
            this.tspMenuItemNew.Name = "tspMenuItemNew";
            this.tspMenuItemNew.Size = new System.Drawing.Size(44, 21);
            this.tspMenuItemNew.Text = "新建";
            this.tspMenuItemNew.Click += new System.EventHandler(this.tspMenuItemNew_Click);
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Gray;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myWriterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myWriterControl.Font = new System.Drawing.Font("宋体", 12F);
            this.myWriterControl.Location = new System.Drawing.Point(0, 25);
            this.myWriterControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            this.myWriterControl.Size = new System.Drawing.Size(553, 408);
            this.myWriterControl.TabIndex = 2;
            // 
            // ctlTestFileNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.mspItems);
            this.Name = "ctlTestFileNew";
            this.Size = new System.Drawing.Size(553, 433);
            this.mspItems.ResumeLayout(false);
            this.mspItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspItems;
        private System.Windows.Forms.ToolStripMenuItem tspMenuItemNew;
        private Controls.WriterControl myWriterControl;

    }
}

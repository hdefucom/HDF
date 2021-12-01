
namespace HDF.DeskBand
{
    partial class MainControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Key
            // 
            this.txt_Key.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Key.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Key.Location = new System.Drawing.Point(0, 0);
            this.txt_Key.Multiline = true;
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(194, 40);
            this.txt_Key.TabIndex = 0;
            this.txt_Key.Text = "1231\r\n1231\r\n546\r\n65";
            this.txt_Key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainControl_KeyUp);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txt_Key);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(194, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Key;
    }
}

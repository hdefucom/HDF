namespace HDF.Test.Winform
{
    partial class Form3
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
            this.PageHeader = new AntdUI.PageHeader();
            this.chatList = new AntdUI.Chat.ChatList();
            this.testControl1 = new HDF.Test.Winform.TestControl();
            this.SuspendLayout();
            // 
            // PageHeader
            // 
            this.PageHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PageHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.PageHeader.FullBox = true;
            this.PageHeader.Location = new System.Drawing.Point(0, 0);
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ShowButton = true;
            this.PageHeader.ShowIcon = true;
            this.PageHeader.Size = new System.Drawing.Size(862, 42);
            this.PageHeader.SubText = "Demo";
            this.PageHeader.TabIndex = 27;
            this.PageHeader.Text = "PageHeader";
            // 
            // chatList
            // 
            this.chatList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chatList.Location = new System.Drawing.Point(0, 48);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(673, 256);
            this.chatList.TabIndex = 29;
            this.chatList.Text = "chatList";
            // 
            // testControl1
            // 
            this.testControl1.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.testControl1.Location = new System.Drawing.Point(366, 310);
            this.testControl1.MouseDownSliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.testControl1.MouseOverSliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.testControl1.Name = "testControl1";
            this.testControl1.Size = new System.Drawing.Size(36, 266);
            this.testControl1.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.testControl1.SliderHeight = 100;
            this.testControl1.SliderWidthPercent = 0.5D;
            this.testControl1.SmallChange = 1;
            this.testControl1.TabIndex = 30;
            this.testControl1.Value = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 588);
            this.Controls.Add(this.testControl1);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.PageHeader);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.PageHeader PageHeader;
        private AntdUI.Chat.ChatList chatList;
        private TestControl testControl1;
    }
}
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
            this.pageHeader1 = new AntdUI.PageHeader();
            this.PageHeader = new AntdUI.PageHeader();
            this.pageHeader2 = new AntdUI.PageHeader();
            this.chatList = new AntdUI.Chat.ChatList();
            this.SuspendLayout();
            // 
            // pageHeader1
            // 
            this.pageHeader1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pageHeader1.DividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pageHeader1.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageHeader1.Location = new System.Drawing.Point(12, 145);
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(657, 56);
            this.pageHeader1.SubText = "yyyyyyy";
            this.pageHeader1.TabIndex = 0;
            this.pageHeader1.Text = "AntdUI 1.9.12😊😂🤣❤️😍";
            // 
            // PageHeader
            // 
            this.PageHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.PageHeader.FullBox = true;
            this.PageHeader.Location = new System.Drawing.Point(28, 209);
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ShowButton = true;
            this.PageHeader.ShowIcon = true;
            this.PageHeader.Size = new System.Drawing.Size(744, 42);
            this.PageHeader.SubText = "Demo";
            this.PageHeader.TabIndex = 27;
            this.PageHeader.Text = "PageHeader";
            // 
            // pageHeader2
            // 
            this.pageHeader2.Location = new System.Drawing.Point(241, 53);
            this.pageHeader2.Name = "pageHeader2";
            this.pageHeader2.ShowButton = true;
            this.pageHeader2.Size = new System.Drawing.Size(389, 63);
            this.pageHeader2.TabIndex = 28;
            this.pageHeader2.Text = "pageHeader2";
            // 
            // chatList
            // 
            this.chatList.Location = new System.Drawing.Point(53, 279);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(673, 256);
            this.chatList.TabIndex = 29;
            this.chatList.Text = "chatList";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 588);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.pageHeader2);
            this.Controls.Add(this.PageHeader);
            this.Controls.Add(this.pageHeader1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.PageHeader PageHeader;
        private AntdUI.PageHeader pageHeader2;
        private AntdUI.Chat.ChatList chatList;
    }
}
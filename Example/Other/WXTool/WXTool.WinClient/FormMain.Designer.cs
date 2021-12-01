namespace WXTool.WinClient
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.注入微信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空消息记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取好友列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Msg = new System.Windows.Forms.TabPage();
            this.dgv_UserList = new System.Windows.Forms.DataGridView();
            this.tabPage_room = new System.Windows.Forms.TabPage();
            this.txt_Record = new System.Windows.Forms.TextBox();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.Col_wxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_wxcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Msg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注入微信ToolStripMenuItem,
            this.清空消息记录ToolStripMenuItem,
            this.清空日志ToolStripMenuItem,
            this.获取好友列表ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 注入微信ToolStripMenuItem
            // 
            this.注入微信ToolStripMenuItem.Name = "注入微信ToolStripMenuItem";
            this.注入微信ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.注入微信ToolStripMenuItem.Text = "注入微信";
            this.注入微信ToolStripMenuItem.Click += new System.EventHandler(this.注入微信ToolStripMenuItem_Click);
            // 
            // 清空消息记录ToolStripMenuItem
            // 
            this.清空消息记录ToolStripMenuItem.Name = "清空消息记录ToolStripMenuItem";
            this.清空消息记录ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.清空消息记录ToolStripMenuItem.Text = "清空消息记录";
            this.清空消息记录ToolStripMenuItem.Click += new System.EventHandler(this.清空消息记录ToolStripMenuItem_Click);
            // 
            // 清空日志ToolStripMenuItem
            // 
            this.清空日志ToolStripMenuItem.Name = "清空日志ToolStripMenuItem";
            this.清空日志ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.清空日志ToolStripMenuItem.Text = "清空日志";
            this.清空日志ToolStripMenuItem.Click += new System.EventHandler(this.清空日志ToolStripMenuItem_Click);
            // 
            // 获取好友列表ToolStripMenuItem
            // 
            this.获取好友列表ToolStripMenuItem.Name = "获取好友列表ToolStripMenuItem";
            this.获取好友列表ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.获取好友列表ToolStripMenuItem.Text = "获取好友列表";
            this.获取好友列表ToolStripMenuItem.Click += new System.EventHandler(this.获取好友列表ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.txt_Url);
            this.groupBox1.Controls.Add(this.lbl_Status);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(77, 47);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(65, 22);
            this.btn_Disconnect.TabIndex = 4;
            this.btn_Disconnect.Text = "断开";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(6, 47);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(65, 22);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_Url
            // 
            this.txt_Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Url.Location = new System.Drawing.Point(6, 20);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(339, 21);
            this.txt_Url.TabIndex = 6;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Status.ForeColor = System.Drawing.Color.Red;
            this.lbl_Status.Location = new System.Drawing.Point(157, 52);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(44, 12);
            this.lbl_Status.TabIndex = 5;
            this.lbl_Status.Text = "未连接";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 425);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Msg);
            this.tabControl1.Controls.Add(this.tabPage_room);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(351, 347);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage_Msg
            // 
            this.tabPage_Msg.Controls.Add(this.dgv_UserList);
            this.tabPage_Msg.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Msg.Name = "tabPage_Msg";
            this.tabPage_Msg.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Msg.Size = new System.Drawing.Size(343, 321);
            this.tabPage_Msg.TabIndex = 0;
            this.tabPage_Msg.Text = "消息";
            this.tabPage_Msg.UseVisualStyleBackColor = true;
            // 
            // dgv_UserList
            // 
            this.dgv_UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_wxid,
            this.Col_name,
            this.Col_wxcode,
            this.Col_remark});
            this.dgv_UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_UserList.Location = new System.Drawing.Point(3, 3);
            this.dgv_UserList.Name = "dgv_UserList";
            this.dgv_UserList.RowTemplate.Height = 23;
            this.dgv_UserList.Size = new System.Drawing.Size(337, 315);
            this.dgv_UserList.TabIndex = 0;
            // 
            // tabPage_room
            // 
            this.tabPage_room.Location = new System.Drawing.Point(4, 22);
            this.tabPage_room.Name = "tabPage_room";
            this.tabPage_room.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_room.Size = new System.Drawing.Size(343, 321);
            this.tabPage_room.TabIndex = 1;
            this.tabPage_room.Text = "群";
            this.tabPage_room.UseVisualStyleBackColor = true;
            // 
            // txt_Record
            // 
            this.txt_Record.BackColor = System.Drawing.Color.White;
            this.txt_Record.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_Record.Location = new System.Drawing.Point(0, 25);
            this.txt_Record.Multiline = true;
            this.txt_Record.Name = "txt_Record";
            this.txt_Record.ReadOnly = true;
            this.txt_Record.Size = new System.Drawing.Size(198, 425);
            this.txt_Record.TabIndex = 3;
            // 
            // txt_Log
            // 
            this.txt_Log.BackColor = System.Drawing.Color.White;
            this.txt_Log.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_Log.Location = new System.Drawing.Point(555, 25);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ReadOnly = true;
            this.txt_Log.Size = new System.Drawing.Size(245, 425);
            this.txt_Log.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(552, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 425);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(198, 25);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 425);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // Col_wxid
            // 
            this.Col_wxid.DataPropertyName = "wxid";
            this.Col_wxid.HeaderText = "wxid";
            this.Col_wxid.Name = "Col_wxid";
            // 
            // Col_name
            // 
            this.Col_name.DataPropertyName = "name";
            this.Col_name.HeaderText = "名称";
            this.Col_name.Name = "Col_name";
            // 
            // Col_wxcode
            // 
            this.Col_wxcode.DataPropertyName = "wxcode";
            this.Col_wxcode.HeaderText = "微信号";
            this.Col_wxcode.Name = "Col_wxcode";
            // 
            // Col_remark
            // 
            this.Col_remark.DataPropertyName = "remarks";
            this.Col_remark.HeaderText = "备注";
            this.Col_remark.Name = "Col_remark";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.txt_Record);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信助手     使用前请先注入微信";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Msg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 注入微信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空消息记录ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Record;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Msg;
        private System.Windows.Forms.TabPage tabPage_room;
        private System.Windows.Forms.ToolStripMenuItem 获取好友列表ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_UserList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_wxid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_wxcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_remark;
    }
}

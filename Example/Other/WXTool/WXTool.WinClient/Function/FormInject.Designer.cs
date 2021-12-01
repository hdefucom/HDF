namespace WXTool.WinClient.Function
{
    partial class FormInject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInject));
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Inject = new System.Windows.Forms.Button();
            this.button_Restart = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_DllList = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Info
            // 
            this.txt_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Info.Location = new System.Drawing.Point(3, 17);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.Size = new System.Drawing.Size(411, 172);
            this.txt_Info.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Info);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "微信信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Inject);
            this.panel1.Controls.Add(this.button_Restart);
            this.panel1.Controls.Add(this.button_Refresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 37);
            this.panel1.TabIndex = 2;
            // 
            // button_Inject
            // 
            this.button_Inject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Inject.Location = new System.Drawing.Point(342, 7);
            this.button_Inject.Name = "button_Inject";
            this.button_Inject.Size = new System.Drawing.Size(63, 23);
            this.button_Inject.TabIndex = 0;
            this.button_Inject.Text = "注入";
            this.button_Inject.UseVisualStyleBackColor = true;
            this.button_Inject.Click += new System.EventHandler(this.button_Inject_Click);
            // 
            // button_Restart
            // 
            this.button_Restart.Location = new System.Drawing.Point(72, 7);
            this.button_Restart.Name = "button_Restart";
            this.button_Restart.Size = new System.Drawing.Size(63, 23);
            this.button_Restart.TabIndex = 0;
            this.button_Restart.Text = "重启微信";
            this.button_Restart.UseVisualStyleBackColor = true;
            this.button_Restart.Click += new System.EventHandler(this.button_Restart_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(3, 7);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(63, 23);
            this.button_Refresh.TabIndex = 0;
            this.button_Refresh.Text = "刷新信息";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_DllList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 49);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择注入程序";
            // 
            // cb_DllList
            // 
            this.cb_DllList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DllList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DllList.FormattingEnabled = true;
            this.cb_DllList.Location = new System.Drawing.Point(12, 20);
            this.cb_DllList.Name = "cb_DllList";
            this.cb_DllList.Size = new System.Drawing.Size(393, 20);
            this.cb_DllList.TabIndex = 0;
            // 
            // FormInject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 278);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "微信注入";
            this.Load += new System.EventHandler(this.FormInject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_DllList;
        private System.Windows.Forms.Button button_Inject;
        private System.Windows.Forms.Button button_Restart;
    }
}
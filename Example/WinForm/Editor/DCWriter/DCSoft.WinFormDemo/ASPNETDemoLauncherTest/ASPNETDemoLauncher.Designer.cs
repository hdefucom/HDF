namespace DCSoft.Writer.WinFormDemo.ASPNETDemoLauncherTest
{
    partial class ASPNETDemoLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASPNETDemoLauncher));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnsolution = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnrode = new System.Windows.Forms.ToolStripButton();
            this.btnopenvideo = new System.Windows.Forms.ToolStripButton();
            this.btnopenDC = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGoogle = new System.Windows.Forms.ToolStripButton();
            this.btnFirefox = new System.Windows.Forms.ToolStripButton();
            this.btnUC = new System.Windows.Forms.ToolStripButton();
            this.btnQQ = new System.Windows.Forms.ToolStripButton();
            this.btnBaidu = new System.Windows.Forms.ToolStripButton();
            this.btnIE = new System.Windows.Forms.ToolStripButton();
            this.btn360 = new System.Windows.Forms.ToolStripButton();
            this.btnSafari = new System.Windows.Forms.ToolStripButton();
            this.btnOpera = new System.Windows.Forms.ToolStripButton();
            this.btnEdge = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbUrl = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnurlrf = new System.Windows.Forms.Button();
            this.btnhome = new System.Windows.Forms.Button();
            this.btngoforward = new System.Windows.Forms.Button();
            this.btngoback = new System.Windows.Forms.Button();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.process1 = new System.Diagnostics.Process();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(55, 55);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnsolution,
            this.btnOpen,
            this.btnrode,
            this.btnopenvideo,
            this.btnopenDC,
            this.btnAdd,
            this.toolStripSeparator2,
            this.btnGoogle,
            this.btnFirefox,
            this.btnUC,
            this.btnQQ,
            this.btnBaidu,
            this.btnIE,
            this.btn360,
            this.btnSafari,
            this.btnOpera,
            this.btnEdge});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1495, 62);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnsolution
            // 
            this.btnsolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnsolution.Image = ((System.Drawing.Image)(resources.GetObject("btnsolution.Image")));
            this.btnsolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsolution.Name = "btnsolution";
            this.btnsolution.Size = new System.Drawing.Size(59, 59);
            this.btnsolution.Text = "查看源代码";
            this.btnsolution.Click += new System.EventHandler(this.btnsolution_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 59);
            this.btnOpen.Text = "打开";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnrode
            // 
            this.btnrode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnrode.Image = ((System.Drawing.Image)(resources.GetObject("btnrode.Image")));
            this.btnrode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnrode.Name = "btnrode";
            this.btnrode.Size = new System.Drawing.Size(59, 59);
            this.btnrode.Text = "刷新";
            this.btnrode.Click += new System.EventHandler(this.btnrode_Click);
            // 
            // btnopenvideo
            // 
            this.btnopenvideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnopenvideo.Image = ((System.Drawing.Image)(resources.GetObject("btnopenvideo.Image")));
            this.btnopenvideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnopenvideo.Name = "btnopenvideo";
            this.btnopenvideo.Size = new System.Drawing.Size(59, 59);
            this.btnopenvideo.Text = "视频";
            this.btnopenvideo.Visible = false;
            this.btnopenvideo.Click += new System.EventHandler(this.btnopenvideo_Click);
            // 
            // btnopenDC
            // 
            this.btnopenDC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnopenDC.Image = ((System.Drawing.Image)(resources.GetObject("btnopenDC.Image")));
            this.btnopenDC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnopenDC.Name = "btnopenDC";
            this.btnopenDC.Size = new System.Drawing.Size(59, 59);
            this.btnopenDC.Text = "返回主界面";
            this.btnopenDC.Visible = false;
            this.btnopenDC.Click += new System.EventHandler(this.btnopenDC_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 59);
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 62);
            // 
            // btnGoogle
            // 
            this.btnGoogle.AutoSize = false;
            this.btnGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGoogle.Image = ((System.Drawing.Image)(resources.GetObject("btnGoogle.Image")));
            this.btnGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoogle.Name = "btnGoogle";
            this.btnGoogle.Size = new System.Drawing.Size(55, 55);
            this.btnGoogle.Text = "谷歌";
            this.btnGoogle.Click += new System.EventHandler(this.btnGoogle_Click);
            // 
            // btnFirefox
            // 
            this.btnFirefox.AutoSize = false;
            this.btnFirefox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirefox.Image = ((System.Drawing.Image)(resources.GetObject("btnFirefox.Image")));
            this.btnFirefox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirefox.Name = "btnFirefox";
            this.btnFirefox.Size = new System.Drawing.Size(55, 55);
            this.btnFirefox.Text = "火狐";
            this.btnFirefox.Click += new System.EventHandler(this.btnFirefox_Click);
            // 
            // btnUC
            // 
            this.btnUC.AutoSize = false;
            this.btnUC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUC.Image = ((System.Drawing.Image)(resources.GetObject("btnUC.Image")));
            this.btnUC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUC.Name = "btnUC";
            this.btnUC.Size = new System.Drawing.Size(55, 55);
            this.btnUC.Text = "UC";
            this.btnUC.Click += new System.EventHandler(this.btnUC_Click);
            // 
            // btnQQ
            // 
            this.btnQQ.AutoSize = false;
            this.btnQQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQQ.Image = ((System.Drawing.Image)(resources.GetObject("btnQQ.Image")));
            this.btnQQ.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnQQ.Name = "btnQQ";
            this.btnQQ.Size = new System.Drawing.Size(55, 55);
            this.btnQQ.Text = "QQ浏览器";
            this.btnQQ.Click += new System.EventHandler(this.btnQQ_Click);
            // 
            // btnBaidu
            // 
            this.btnBaidu.AutoSize = false;
            this.btnBaidu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBaidu.Image = ((System.Drawing.Image)(resources.GetObject("btnBaidu.Image")));
            this.btnBaidu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaidu.Name = "btnBaidu";
            this.btnBaidu.Size = new System.Drawing.Size(55, 55);
            this.btnBaidu.Text = "百度浏览器";
            this.btnBaidu.Click += new System.EventHandler(this.btnBaidu_Click);
            // 
            // btnIE
            // 
            this.btnIE.AutoSize = false;
            this.btnIE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIE.Image = ((System.Drawing.Image)(resources.GetObject("btnIE.Image")));
            this.btnIE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIE.Name = "btnIE";
            this.btnIE.Size = new System.Drawing.Size(55, 55);
            this.btnIE.Text = "IE";
            this.btnIE.Click += new System.EventHandler(this.btnIE_Click);
            // 
            // btn360
            // 
            this.btn360.AutoSize = false;
            this.btn360.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn360.Image = ((System.Drawing.Image)(resources.GetObject("btn360.Image")));
            this.btn360.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn360.Name = "btn360";
            this.btn360.Size = new System.Drawing.Size(55, 55);
            this.btn360.Text = "360";
            this.btn360.Click += new System.EventHandler(this.btn360_Click);
            // 
            // btnSafari
            // 
            this.btnSafari.AutoSize = false;
            this.btnSafari.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSafari.Image = ((System.Drawing.Image)(resources.GetObject("btnSafari.Image")));
            this.btnSafari.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSafari.Name = "btnSafari";
            this.btnSafari.Size = new System.Drawing.Size(55, 55);
            this.btnSafari.Text = "Safari";
            this.btnSafari.Click += new System.EventHandler(this.btnSafari_Click);
            // 
            // btnOpera
            // 
            this.btnOpera.AutoSize = false;
            this.btnOpera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpera.Image = ((System.Drawing.Image)(resources.GetObject("btnOpera.Image")));
            this.btnOpera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpera.Name = "btnOpera";
            this.btnOpera.Size = new System.Drawing.Size(55, 55);
            this.btnOpera.Text = "Opera";
            this.btnOpera.Click += new System.EventHandler(this.btnOpera_Click);
            // 
            // btnEdge
            // 
            this.btnEdge.AutoSize = false;
            this.btnEdge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdge.Image = ((System.Drawing.Image)(resources.GetObject("btnEdge.Image")));
            this.btnEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdge.Name = "btnEdge";
            this.btnEdge.Size = new System.Drawing.Size(55, 55);
            this.btnEdge.Text = "Edge";
            this.btnEdge.Click += new System.EventHandler(this.btnEdge_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.cmbUrl);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnurlrf);
            this.panel1.Controls.Add(this.btnhome);
            this.panel1.Controls.Add(this.btngoforward);
            this.panel1.Controls.Add(this.btngoback);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1495, 40);
            this.panel1.TabIndex = 4;
            // 
            // cmbUrl
            // 
            this.cmbUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUrl.FormattingEnabled = true;
            this.cmbUrl.Location = new System.Drawing.Point(86, 8);
            this.cmbUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbUrl.Name = "cmbUrl";
            this.cmbUrl.Size = new System.Drawing.Size(1323, 23);
            this.cmbUrl.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(86, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1323, 8);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(86, 32);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1323, 8);
            this.panel3.TabIndex = 10;
            // 
            // btnurlrf
            // 
            this.btnurlrf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnurlrf.BackgroundImage")));
            this.btnurlrf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnurlrf.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnurlrf.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnurlrf.Location = new System.Drawing.Point(1409, 0);
            this.btnurlrf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnurlrf.Name = "btnurlrf";
            this.btnurlrf.Size = new System.Drawing.Size(43, 40);
            this.btnurlrf.TabIndex = 1;
            this.btnurlrf.TabStop = false;
            this.btnurlrf.UseVisualStyleBackColor = true;
            this.btnurlrf.Click += new System.EventHandler(this.btnurlrf_Click);
            // 
            // btnhome
            // 
            this.btnhome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnhome.BackgroundImage")));
            this.btnhome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnhome.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnhome.Location = new System.Drawing.Point(1452, 0);
            this.btnhome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnhome.Name = "btnhome";
            this.btnhome.Size = new System.Drawing.Size(43, 40);
            this.btnhome.TabIndex = 5;
            this.btnhome.UseVisualStyleBackColor = true;
            this.btnhome.Click += new System.EventHandler(this.btnhome_Click);
            // 
            // btngoforward
            // 
            this.btngoforward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngoforward.BackgroundImage")));
            this.btngoforward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngoforward.Dock = System.Windows.Forms.DockStyle.Left;
            this.btngoforward.Location = new System.Drawing.Point(43, 0);
            this.btngoforward.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btngoforward.Name = "btngoforward";
            this.btngoforward.Size = new System.Drawing.Size(43, 40);
            this.btngoforward.TabIndex = 4;
            this.btngoforward.UseVisualStyleBackColor = true;
            this.btngoforward.Click += new System.EventHandler(this.btngoforward_Click);
            // 
            // btngoback
            // 
            this.btngoback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngoback.BackgroundImage")));
            this.btngoback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngoback.Dock = System.Windows.Forms.DockStyle.Left;
            this.btngoback.Location = new System.Drawing.Point(0, 0);
            this.btngoback.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btngoback.Name = "btngoback";
            this.btngoback.Size = new System.Drawing.Size(43, 40);
            this.btngoback.TabIndex = 3;
            this.btngoback.UseVisualStyleBackColor = true;
            this.btngoback.Click += new System.EventHandler(this.btngoback_Click);
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 102);
            this.wb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wb.MinimumSize = new System.Drawing.Size(27, 25);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(1495, 692);
            this.wb.TabIndex = 7;
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wb_ProgressChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 794);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1495, 26);
            this.panel4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(1042, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "南京都昌信息科技有限公司《互联网+电子病历编辑器》BS版编辑器";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBar1.ForeColor = System.Drawing.Color.Blue;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(728, 24);
            this.progressBar1.TabIndex = 0;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // ASPNETDemoLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ASPNETDemoLauncher";
            this.Size = new System.Drawing.Size(1495, 820);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnsolution;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnrode;
        private System.Windows.Forms.ToolStripButton btnopenvideo;
        private System.Windows.Forms.ToolStripButton btnopenDC;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGoogle;
        private System.Windows.Forms.ToolStripButton btnFirefox;
        private System.Windows.Forms.ToolStripButton btnUC;
        private System.Windows.Forms.ToolStripButton btnQQ;
        private System.Windows.Forms.ToolStripButton btnBaidu;
        private System.Windows.Forms.ToolStripButton btnIE;
        private System.Windows.Forms.ToolStripButton btn360;
        private System.Windows.Forms.ToolStripButton btnSafari;
        private System.Windows.Forms.ToolStripButton btnOpera;
        private System.Windows.Forms.ToolStripButton btnEdge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbUrl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnurlrf;
        private System.Windows.Forms.Button btnhome;
        private System.Windows.Forms.Button btngoforward;
        private System.Windows.Forms.Button btngoback;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

namespace DCSoft.Writer.WinFormDemo.CardListViewTest
{
    partial class ctlTestPatientListView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestPatientListView));
            this.lvwPatients = new DCSoft.WinForms.Controls.DCCardListViewControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFillSimple = new System.Windows.Forms.ToolStripButton();
            this.btnFillContent = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSetBackColor = new System.Windows.Forms.ToolStripButton();
            this.btnHighlight = new System.Windows.Forms.ToolStripButton();
            this.btnBlink = new System.Windows.Forms.ToolStripButton();
            this.btnPush = new System.Windows.Forms.ToolStripButton();
            this.btnEditCardConfigXML = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.myContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmViewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.myContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPatients
            // 
            this.lvwPatients.AutoScroll = true;
            this.lvwPatients.AutoScrollMinSize = new System.Drawing.Size(14, 10);
            this.lvwPatients.BackColor = System.Drawing.Color.Silver;
            this.lvwPatients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lvwPatients.CardBackColor = System.Drawing.Color.WhiteSmoke;
            this.lvwPatients.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvwPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPatients.Location = new System.Drawing.Point(0, 25);
            this.lvwPatients.Name = "lvwPatients";
            this.lvwPatients.Size = new System.Drawing.Size(819, 355);
            this.lvwPatients.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFillSimple,
            this.btnFillContent,
            this.btnRefresh,
            this.toolStripButton1,
            this.btnSetBackColor,
            this.btnHighlight,
            this.btnBlink,
            this.btnPush,
            this.btnEditCardConfigXML});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(819, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFillSimple
            // 
            this.btnFillSimple.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFillSimple.Image = ((System.Drawing.Image)(resources.GetObject("btnFillSimple.Image")));
            this.btnFillSimple.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillSimple.Name = "btnFillSimple";
            this.btnFillSimple.Size = new System.Drawing.Size(60, 22);
            this.btnFillSimple.Text = "快键填充";
            this.btnFillSimple.Click += new System.EventHandler(this.btnFillSimple_Click);
            // 
            // btnFillContent
            // 
            this.btnFillContent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFillContent.Image = ((System.Drawing.Image)(resources.GetObject("btnFillContent.Image")));
            this.btnFillContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillContent.Name = "btnFillContent";
            this.btnFillContent.Size = new System.Drawing.Size(84, 22);
            this.btnFillContent.Text = "填充内容刷新";
            this.btnFillContent.Click += new System.EventHandler(this.btnFillContent_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 22);
            this.btnRefresh.Text = "绑定数据源刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSetBackColor
            // 
            this.btnSetBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSetBackColor.Image = ((System.Drawing.Image)(resources.GetObject("btnSetBackColor.Image")));
            this.btnSetBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetBackColor.Name = "btnSetBackColor";
            this.btnSetBackColor.Size = new System.Drawing.Size(96, 22);
            this.btnSetBackColor.Text = "设置卡片背景色";
            this.btnSetBackColor.Click += new System.EventHandler(this.btnSetBackColor_Click);
            // 
            // btnHighlight
            // 
            this.btnHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHighlight.Image = ((System.Drawing.Image)(resources.GetObject("btnHighlight.Image")));
            this.btnHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(72, 22);
            this.btnHighlight.Text = "高亮度显示";
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // btnBlink
            // 
            this.btnBlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBlink.Image = ((System.Drawing.Image)(resources.GetObject("btnBlink.Image")));
            this.btnBlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBlink.Name = "btnBlink";
            this.btnBlink.Size = new System.Drawing.Size(36, 22);
            this.btnBlink.Text = "闪烁";
            this.btnBlink.Click += new System.EventHandler(this.btnBlink_Click);
            // 
            // btnPush
            // 
            this.btnPush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPush.Image = ((System.Drawing.Image)(resources.GetObject("btnPush.Image")));
            this.btnPush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(60, 22);
            this.btnPush.Text = "设置边框";
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnEditCardConfigXML
            // 
            this.btnEditCardConfigXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditCardConfigXML.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCardConfigXML.Image")));
            this.btnEditCardConfigXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCardConfigXML.Name = "btnEditCardConfigXML";
            this.btnEditCardConfigXML.Size = new System.Drawing.Size(110, 22);
            this.btnEditCardConfigXML.Text = "编辑卡片设置XML";
            this.btnEditCardConfigXML.Click += new System.EventHandler(this.btnEditCardConfigXML_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "查看配置";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // myContextMenu
            // 
            this.myContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmViewDetails,
            this.cmViewDoc,
            this.cmOut});
            this.myContextMenu.Name = "myContextMenu";
            this.myContextMenu.Size = new System.Drawing.Size(173, 70);
            // 
            // cmViewDetails
            // 
            this.cmViewDetails.Name = "cmViewDetails";
            this.cmViewDetails.Size = new System.Drawing.Size(172, 22);
            this.cmViewDetails.Text = "查看病人基本信息";
            this.cmViewDetails.Click += new System.EventHandler(this.cmViewDetails_Click);
            // 
            // cmViewDoc
            // 
            this.cmViewDoc.Name = "cmViewDoc";
            this.cmViewDoc.Size = new System.Drawing.Size(172, 22);
            this.cmViewDoc.Text = "查看病历";
            this.cmViewDoc.Click += new System.EventHandler(this.cmViewDoc_Click);
            // 
            // cmOut
            // 
            this.cmOut.Name = "cmOut";
            this.cmOut.Size = new System.Drawing.Size(172, 22);
            this.cmOut.Text = "病人出院";
            this.cmOut.Click += new System.EventHandler(this.cmOut_Click);
            // 
            // ctlTestPatientListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lvwPatients);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestPatientListView";
            this.Size = new System.Drawing.Size(819, 380);
            this.Load += new System.EventHandler(this.ctlTestPatientListView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.myContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForms.Controls.DCCardListViewControl lvwPatients;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnHighlight;
        private System.Windows.Forms.ToolStripButton btnBlink;
        private System.Windows.Forms.ContextMenuStrip myContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmViewDetails;
        private System.Windows.Forms.ToolStripMenuItem cmViewDoc;
        private System.Windows.Forms.ToolStripMenuItem cmOut;
        private System.Windows.Forms.ToolStripButton btnSetBackColor;
        private System.Windows.Forms.ToolStripButton btnPush;
        private System.Windows.Forms.ToolStripButton btnFillContent;
        private System.Windows.Forms.ToolStripButton btnEditCardConfigXML;
        private System.Windows.Forms.ToolStripButton btnFillSimple;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

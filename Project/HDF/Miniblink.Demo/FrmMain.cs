using System;
using System.Diagnostics;
using System.Windows.Forms;
using Miniblink;

namespace Miniblink.Demo
{
	public partial class FrmMain : Form
	{
        public FrmMain()
		{
			InitializeComponent();
            MiniblinkSetting.EnableHighDPISupport();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://gitee.com/aochulai/NetMiniblink");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            var form = e.Node.Tag as Form;
            if (form != null)
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
                form.Activate();
                return;
            }

            var tag = e.Node.Tag.ToString();

            switch (tag)
            {
                case "ctrl_mode":
                    form = new FrmControl();
                    break;
                case "frm_mode":
                    form = new FrmWindow();
                    break;
                case "tran_mode":
                    form = new FrmTransparent();
                    break;
                case "embed_loader":
                    form = new FrmEmbedLoad();
                    break;
                case "file_loader":
                    form = new FrmFileLoad();
                    break;
                case "zip_loader":
                    form = new FrmZipLoad();
                    break;
                case "net_call_js":
                    form = new FrmNetCallJs();
                    break;
                case "js_call_net":
                    form = new FrmJsCallNet();
                    break;
                case "runjs":
                    form = new FrmRunJs();
                    break;
                case "events":
                    form = new FrmEvents();
                    break;
                case "image":
                    form = new FrmImage();
                    break;
                case "web":
                    form = new FrmWeb();
                    break;
                case "dev_tools":
                    form = new FrmDevTools();
                    break;
                case "download":
                    form = new FrmDownload();
                    break;
                case "hook":
                    form = new FrmHook();
                    break;
                case "drop_file":
                    form = new FrmDropFile();
                    break;
            }

            if (form != null)
            {
                e.Node.Tag = form;
                form.Closed += (ss, ee) =>
                {
                    var self = (Form) ss;
                    ((TreeNode) self.Tag).Tag = tag;
                };
                form.Tag = e.Node;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
        }
    }
}

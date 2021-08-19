using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace DCSoft.Writer.WinFormDemo.ASPNETDemoLauncherTest
{
    public partial class ASPNETDemoLauncher : UserControl
    {
        public ASPNETDemoLauncher()
        {
            InitializeComponent();
            Frm_wb_Load();
        }
        //mytest
        string exeip;//浏览器名字
        BsnameId bsnameId = new BsnameId();
        string Filepath = "";
        //public static string DCSoftDemoCenterpath = "DCSoftDemoCenter1.0";
        //string srdps40 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Path.Combine(DCSoftDemoCenterpath,@"DCEditorWeb\10.0\WebDev.WebServer40.exe"));
        string srdps40 = Path.Combine(Environment.CurrentDirectory, @"10.0\WebDev.WebServer40.exe");
        string srdps20 = Path.Combine(Environment.CurrentDirectory, @"10.0\WebDev.WebServer20.exe");

        //string srdps20 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Path.Combine(DCSoftDemoCenterpath,@"DCEditorWeb\10.0\WebDev.WebServer20.exe"));
        List<string> filepathlist = new List<string>();
        int btnID = 0;
        String id;//WEB端口

        private void cmbUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbUrl.Text != "")
                {
                    try
                    {
                        cmbUrl.Items.Add(cmbUrl.Text);
                        wb.Url = new Uri(cmbUrl.Text);
                    }
                    catch { }
                }
            }
        }
        public string arguments = null;
        private void Frm_wb_Load()//object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //System.Diagnostics.Trace.Listeners.Clear();
            //System.Diagnostics.Trace.AutoFlush = true;
            //System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener("app4.log"));
            //System.Diagnostics.Trace.WriteLine(srdps20);

            //判断端口有没有被使用
            int port = 9989;
            bool blport;
            bool blbp = true;
            blport = PortInUse.PortInUseBl(port);//判断端口有没有被使用
            while (blport)
            {
                port += 1;
                blport = PortInUse.PortInUseBl(port);
                if (port > 65535 && blbp)
                {
                    port = 1;
                    blbp = false;
                }
            }
            //启动WebDev.WebServer40.exe
            id = port.ToString();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string netpath = Path.Combine(Environment.CurrentDirectory, @"DCSoft.ASPNETDemo");//fbd.SelectedPath asp.net文件地址
            //string netpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Path.Combine(DCSoftDemoCenterpath, @"DCEditorWeb\DCSoft.ASPNETDemo"));//fbd.SelectedPath asp.net文件地址
            //string netpath = Path.Combine(Environment.CurrentDirectory, "WebDemo");//fbd.SelectedPath asp.net文件地址
            string arguments = string.Format("/port:{0} \"/path:\"{1} /vpath:{2}", id, netpath, "/");//fbd.SelectedPath asp.net文件地址
            string ss = Directory.GetCurrentDirectory();
            System.Diagnostics.Trace.WriteLine(arguments);
            Process.Start(srdps20, arguments);//存在20,运行asp.net
            //*******
            var hklm = Microsoft.Win32.Registry.LocalMachine;
            var lmRun64 = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            var lmRun32 = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            //获取路径的方法
            string location64 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string fileName64 = System.IO.Path.GetFileName(location64);
            string location32 = this.GetType().Assembly.Location;
            string fileName32 = System.IO.Path.GetFileName(location32);
            if (lmRun64 != null)
            {
                string value64 = null;
                var xx = lmRun64.GetValue(fileName64);
                if (xx != null)
                {
                    value64 = Convert.ToString(lmRun64.GetValue(fileName64));
                }
                if (string.IsNullOrEmpty(value64))
                {
                    //lmRun64.SetValue("TemplateBrowser.exe", 0x2710); //设置webbrowser调用IE10内核打开
                    lmRun64.SetValue(fileName64, 0x2710); //设置webbrowser调用IE10内核打开
                    lmRun64.SetValue(fileName32, 0x2710); //设置webbrowser调用IE10内核打开
                }
            }

            if (lmRun32 != null)
            {
                string value32 = null;
                var xx = lmRun32.GetValue(fileName32);
                if (xx != null)
                {
                    value32 = Convert.ToString(lmRun32.GetValue(fileName32));
                }

                if (string.IsNullOrEmpty(value32))
                {
                    //lmRun32.SetValue("TemplateBrowser.exe", 0x2710); //设置webbrowser调用IE10内核打开
                    lmRun32.SetValue(fileName32, 0x2710); //设置webbrowser调用IE10内核打开
                    lmRun32.SetValue(fileName64, 0x2710); //设置webbrowser调用IE10内核打开
                }
            }

            //*******
            wb.Url = new Uri("http://localhost:" + id + "/");
            cmbUrl.Text = Convert.ToString(wb.Url);
            //string xmlname = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Path.Combine(DCSoftDemoCenterpath, @"DCEditorWeb\FilePath.xml"));
            string xmlname = Path.Combine(Environment.CurrentDirectory, @"FilePath.xml");
            if (XMLOperation.ReadXmlNodes(xmlname) != "")
            {
                string[] exexml = XMLOperation.ReadXmlNodes(xmlname).Split(',');
                foreach (string exeid in exexml)
                {
                    filepathlist.Add(exeid);
                }
            }
            foreach (string flph in filepathlist)
            {
                if (File.Exists(flph))
                {
                    ToolStripButton btnAdd2 = new ToolStripButton();
                    btnAdd2.Click += new EventHandler(btnAdd2_Click);
                    if (flph != "")
                    {
                        btnAdd2.Name = "btn" + Convert.ToString(btnID);
                        btnAdd2.Image = Icon.ExtractAssociatedIcon(flph).ToBitmap();
                        btnAdd2.ImageAlign = ContentAlignment.MiddleCenter;
                        btnID++;
                    }
                    this.toolStrip1.Items.Add(btnAdd2);
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void run()
        {

        }
        private void Frm_wb_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();

            foreach (System.Diagnostics.Process myProcess in myProcesses)
            {
                try
                {
                    if ("WebDev.WebServer40" == myProcess.ProcessName)
                        myProcess.Kill();//强制关闭该程序
                    if ("WebDev.WebServer20" == myProcess.ProcessName)
                        myProcess.Kill();//强制关闭该程序
                }
                catch { }
            }
        }
        private void btnGoogle_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdtoString("chrome");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btnFirefox_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdtoString("Firefox");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btnUC_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdtoString("UCBrowser");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btnQQ_Click(object sender, EventArgs e)
        {
            exeip = "";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Tencent\\QQBrowser", false))
            {
                if (key != null)//判断对象存在
                {
                    exeip = key.GetValue("Exe", "").ToString();//获取安装路径

                }

            }
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }
                else
                {
                    MessageBox.Show("注册表中没有此浏览器！请确认是否安装！");
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btnBaidu_Click(object sender, EventArgs e)
        {

        }
        private void btnIE_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdtoString("iexplore");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btn360_Click(object sender, EventArgs e)
        {
            exeip = "";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("HKEY_USERS\\S-1-5-21-2145859812-3201629969-2626182436-1001\\SOFTWARE\\360\\360se6\\Chrome", false))
            {
                if (key != null)//判断对象存在
                {
                    exeip = key.GetValue("last_install_path", "").ToString();//获取安装路径
                }
            }
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip + "360se6\\Application\\360se.exe", wb.Url.ToString());
                }
                else
                {
                    MessageBox.Show("注册表中没有此浏览器！请确认是否安装！");
                }
            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btnSafari_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdtoString("Safari");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }
        private void btnOpera_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdttoString("Opera");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip + "\\launcher.exe", wb.Url.ToString());
                }

            }
            catch
            {
                MessageBox.Show("注册表中没有此浏览器！请确认是否安装！");
            }
        }
        private void btnEdge_Click(object sender, EventArgs e)
        {
            exeip = "";
            exeip = bsnameId.BsnmIdtoString("MicrosoftEdge");
            try
            {
                if (exeip != "")
                {
                    System.Diagnostics.Process.Start(exeip, wb.Url.ToString());
                }

            }
            catch { MessageBox.Show("注册表中没有此浏览器！请确认是否安装！"); }
        }




        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            cmbUrl.Text = Convert.ToString(wb.Url);
        }

        private void cmb_url_SelectedIndexChanged(object sender, EventArgs e)
        {
            wb.Url = new Uri(cmbUrl.Text);
        }

        private void btnurlrf_Click(object sender, EventArgs e)
        {
            if (cmbUrl.Text != "")
            {
                wb.Url = new Uri(cmbUrl.Text);
            }
            else
            {
                cmbUrl.Text = Convert.ToString(wb.Url);
            }
        }

        private void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;

            if ((e.CurrentProgress > 0) && (e.MaximumProgress > 0))
            {
                progressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);//设置正在加载的文档总字节数
                progressBar1.Step = Convert.ToInt32(e.CurrentProgress);////获取已下载文档的字节数
                progressBar1.PerformStep();
            }

            else if (wb.ReadyState == WebBrowserReadyState.Complete)//加载完成后隐藏进度条
            {
                progressBar1.Value = 0;
                progressBar1.Visible = false;
            }

        }

        private void btngoback_Click(object sender, EventArgs e)
        {
            wb.GoBack();
        }

        private void btnrode_Click(object sender, EventArgs e)
        {
            wb.Url = new Uri(cmbUrl.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //判断端口有没有被使用
            int port = 9989;
            Boolean blport;
            Boolean blbp = true;
            blport = PortInUse.PortInUseBl(port);
            while (blport)
            {
                port += 1;
                blport = PortInUse.PortInUseBl(port);
                if (port > 65535 && blbp)
                {
                    port = 1;
                    blbp = false;
                }
            }
            String id = port.ToString();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                string arguments = string.Format("/port:{0} \"/path:\"{1} /vpath:{2}", id, fbd.SelectedPath, "/");//fbd.SelectedPath asp.net文件地址
                System.Diagnostics.Process.Start(srdps20, arguments);//存在20,运行asp.net
                wb.Url = new Uri("http://localhost:" + id + "/");
                cmbUrl.Text = Convert.ToString(wb.Url);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Filter = "|*.exe*";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Filepath = this.openFileDialog1.FileName;
                // 你的 处理文件路径代码 
            }
            //添加按钮
            if (Filepath != "")
            {
                bool btntrue = true;

                foreach (string a in filepathlist)
                {
                    if (a == Filepath)
                    {
                        btntrue = false;
                        MessageBox.Show("您已经添加过这个浏览器");
                    }
                }

                if (btntrue)
                {
                    if (Icon.ExtractAssociatedIcon(Filepath) != null)
                    {
                        ToolStripButton btnAdd2 = new ToolStripButton();
                        btnAdd2.Click += new EventHandler(btnAdd2_Click);
                        btnAdd2.Name = "btn" + Convert.ToString(btnID);

                        btnAdd2.Image = Icon.ExtractAssociatedIcon(Filepath).ToBitmap();
                        btnAdd2.ImageAlign = ContentAlignment.MiddleCenter;
                        this.toolStrip1.Items.Add(btnAdd2);
                        XMLOperation xmlOpr = new XMLOperation();

                        string xmlpath = Path.Combine(Environment.CurrentDirectory, @"DCEditorOnLine\FilePath.xml");
                        //string xmlpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Path.Combine(DCSoftDemoCenterpath,@"DCEditorOnLine\FilePath.xml"));
                        xmlOpr.WriteXmlNodes(xmlpath, Filepath);
                        filepathlist.Add(Filepath);
                        System.Diagnostics.Process.Start(Filepath, wb.Url.ToString());
                        btnID++;
                    }
                }
                Filepath = "";
            }

        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            string btnname = ((ToolStripButton)sender).Name;
            int id = Convert.ToInt32(btnname.Substring(3));
            try
            {
                System.Diagnostics.Process.Start(filepathlist[id], wb.Url.ToString());
            }
            catch
            {
                MessageBox.Show("未找到文件");
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            if (id != "")
            {
                wb.Url = new Uri("http://localhost:" + id + "/");
            }
        }

        private void btngoforward_Click(object sender, EventArgs e)
        {
            wb.GoForward();
        }

        private void btnopenvideo_Click(object sender, EventArgs e)
        {
            //打开视频
        }

        private void btnsolution_Click(object sender, EventArgs e)
        {
            //解决方案
            //string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Path.Combine(DCSoftDemoCenterpath, @"Start.exe"));

            string path = Path.Combine(Environment.CurrentDirectory, @"DCSoft.ApplicationStart.exe");
            System.Diagnostics.Process.Start(path, "ASPNETDemoLauncherCode");
        }

        private void btnopenDC_Click(object sender, EventArgs e)
        {
            //返回项目
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}

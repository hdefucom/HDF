using System;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;


namespace DCSoft.Writer.WinFormDemo
{
    /// <summary>
    /// XWriter 软件入口点
    /// </summary>
    public class StartApplication
    {
        /// <summary>
        /// 主函数
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            //DCSoft.WinForms.Native.SHStockIcons.SaveAll("d:\\temp"); return;
            //DCSoft.Writer.DCXmlFormat.DCXmlSerializeCodeGenerator.GenerateSourceCodeFile(
            //    typeof( DCSoft.Writer.Dom.XTextDocument),
            //    "DCSoft.Writer.DCXmlFormat",
            //    "DCXmlSerializer" ,
            //    @"E:\Source\DCSoft\08代码\DCSoft\DCSoft.Writer.Main\DCXmlFormat\DCWriterDomXmlWriter.cs");
            //return ;

            //DCSoft.Writer.DCWriterPublish.Start(); System.Windows.Forms.Application.Run(new frmTest1()); return;
            //System.Windows.Forms.Clipboard.SetText(HtmlAttributeBindingInfo.GetBindingPropertyNames(typeof(DCSoft.Writer.Dom.XTextInputFieldElement))); return;
            //DCSoft.Writer.Extension.VB6PackageCodeGenerator.Generate(typeof(DCSoft.Writer.Controls.AxWriterControl), @"E:\Source\DCSoft\08代码\DCSoft\DCSoft.Writer\Source\VB6Package\VBAxWriterControl.ctl"); return;
            //string txt = DCSoft.Common.FileHelper.LoadBase64StringFromFile(@"E:\Source\DCSoft\08代码\DCSoft\DCSoft.TemperatureChart\Source\DCTimeLine.bmp", true);
            //System.Windows.Forms.Clipboard.SetText(txt);
            //return;
            //System.Diagnostics.FileVersionInfo fi = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(DCSoft.Writer.Controls.AxWriterControl).Assembly.Location);
            //System.Console.WriteLine(fi.ToString());
            // 设置测试版使用的注册码
         
            //DCSoft.Writer.Controls.WriterControl.GlobalRegisterCode = "";

            //DCSoft.Writer.Serialization.XMLSerializeInfo.GenerateSourceCodeFile(
            //    @"E:\Source\DCSoft\08代码\DCSoft\DCSoft.Writer\Source\Main\Serialization\DCXml\DCXmlSerializer.cs",
            //    "DCSoft.Writer.Serialization.Xml",
            //    "DCXMLSerializer",
            //    typeof(DCSoft.Writer.Dom.XTextDocument),
            //    DCSoft.Writer.Serialization.Xml.MyXmlSerializeHelper.ElementTypes);
            //return;
            // 处理命令行
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith("lan=", StringComparison.CurrentCultureIgnoreCase))
                {
                    // 设置为指定语言
                    string lan = arg.Substring(4);
                    try
                    {
                        System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.GetCultureInfo(lan);
                        if (cul != null)
                        {
                            System.Threading.Thread.CurrentThread.CurrentCulture = cul;
                            System.Threading.Thread.CurrentThread.CurrentUICulture = cul;
                        }
                    }
                    catch (Exception ext)
                    {
                        MessageBox.Show(ext.Message);
                    }
                }
            }
            //Type t = typeof(DCSoft.Writer.Dom.XTextElementList);
            //return;
            //EMR.EMRFileSystem.OutputXML(@"E:\Source\DCSoft\08代码\DCSoft\DCSoft.Writer\DCSoft.Writer.Demo\Data\KBLibrary", false); return;
            //Application.Run(new Form1()); return;
            //EMR.EMRFileSystem.ConvertOldXML2NewXML(); return;
            //string txt = DCSoft.Common.StringConvertHelper.ToXMLEntry("袁永福的电子病历");
            //System.Diagnostics.Debug.WriteLine(txt);
            //MessageBox.Show(txt);
            //return;
            //new DCSoft.Writer.Extension.ExtensionStart().Start();
            //DCWriterPublish.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //new SourceGridTestLib.Form1().ShowDialog();
            //Application.Run(new Form2()); return;
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith("lan=", StringComparison.CurrentCultureIgnoreCase))
                {
                    // set language
                    string lang = arg.Substring(4).Trim();
                    CultureInfo cul = new CultureInfo(lang);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = cul;
                }
                //else if (arg.StartsWith("targethandle=", StringComparison.CurrentCultureIgnoreCase))
                //{
                //    //System.Diagnostics.Debugger.Break();
                //    string strHandle = arg.Substring("targethandle=".Length);
                //    int ptr = 0;
                //    if (Int32.TryParse(strHandle, out ptr))
                //    {
                //        DCSoft.Writer.Controls.dlgCrosssPrecessHost dlg = new Controls.dlgCrosssPrecessHost();
                //        DCSoft.Writer.Controls.WriterControlExt ctl = new Controls.WriterControlExt();
                //        //ctl.ExecuteCommand("LoadKBLibrary", false, @"E:\Source\DCSoft\08代码\DCSoft\DCSoft.Writer\DCSoft.Writer.Demo\WinFormDemo\kblibrary.xml");
                //        dlg.HostedControl = ctl;
                //        dlg.HostContainerHandle = new IntPtr(ptr);
                //        Application.Run(dlg);
                //        return;
                //    }
                //}
            }

            string msg = DCSoft.Writer.WriterUtils.CheckNET20SP2(false );
            if (msg != null)
            {
                MessageBox.Show(null, msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //EMR.DataHelper.CheckDBFileName();

            //foreach (string arg in System.Environment.GetCommandLineArgs())
            //{
            //    if (arg.StartsWith("lan=", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        //using (dlgFlash dlg = new dlgFlash())
            //        //{
            //        //    dlg.Show();
            //        //    dlg.Refresh();
            //        //    // 预先初始化一些数据
            //        //    DCSoft.Writer.WriterAppHost.PreloadSystem();
            //        //    dlg.Close();
            //        //}
            //        Application.Run(new frmMain());
            //        return;
            //        //// set language
            //        //string lang = arg.Substring(4).Trim();
            //        //CultureInfo cul = new CultureInfo(lang);
            //        //System.Threading.Thread.CurrentThread.CurrentUICulture = cul;
            //    }
            //}
            //Process instance = RunningInstance();
            //if (instance == null)
            //{
            //    using (dlgFlash dlg = new dlgFlash())
            //    {
            //        dlg.Show();
            //        dlg.Refresh();
            //        // 预先初始化一些数据
            //        DCSoft.Writer.WriterAppHost.PreloadSystem();
            //        dlg.Close();
            //    }

            //    //WLJ 添加 2016/4/6
            //    //Process instance = RunningInstance();
            //    //if (instance == null)
            //    //{
            //    //Form1 frm = new Form1();
            //    //Application.Run(new Form1());
            //    Application.Run(new frmMain());
            //}
            //else
            //{
            //    HandleRunningInstance(instance);
            //}
            //Application.Run(new frmTest1());

            //注释
            using (dlgFlash dlg = new dlgFlash())
            {
                dlg.Show();
                dlg.Refresh();
                // 预先初始化一些数据
                DCSoft.Writer.WriterAppHost.PreloadSystem();
                dlg.Close();
            }

            DCSoft.Writer.DCWriterPublish.Start();
            Application.Run(new frmMain());
            //Application.Run(new Form1()); //

            ////System.Windows.Forms.Application.Run(new frmTestEvent()); return;
            //Form demoForm = null;
            ////using (dlgStartOptions dlg = new dlgStartOptions())
            ////{
            ////    if (dlg.ShowDialog() == DialogResult.OK)
            ////    {
            ////        demoForm = dlg.DemoForm;
            ////    }
            ////    else
            ////    {
            ////        return;
            ////    }
            ////}
            //using (frmMain dlg = new frmMain())
            //{
            //    if (dlg.ShowDialog() == DialogResult.OK)
            //    {
            //        demoForm = dlg.DemoForm;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}


            ////using (Test.ctlTestSetCells dlg = new Test.ctlTestSetCells())
            ////{
            ////    if (dlg.ShowDialog() == DialogResult.OK)
            ////    {
            ////        demoForm = dlg.DemoForm;
            ////    }
            ////    else
            ////    {
            ////        return;
            ////    }
            ////}

            //if (demoForm != null)
            //{
            //    try
            //    {
            //        Application.Run(demoForm);
            //    }
            //    catch (Exception ext)
            //    {
            //        MessageBox.Show(" Error:" + ext.ToString());
            //    }
            //}
        }
        /// <summary>
        /// 对象不能实例化
        /// </summary>
        private StartApplication() { }

        private void ConvertFileFormat()
        {

        }
    }
}
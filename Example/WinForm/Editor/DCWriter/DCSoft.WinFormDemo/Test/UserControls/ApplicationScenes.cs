using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test.UserControls
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ApplicationScenes : UserControl
    {
        private string _DemoFilePath = string.Empty;
        public string DemoFilePath
        {
            get
            {
                //_DemoFilePath = Application.StartupPath + @"\DemoFile\南京都昌科技ST_会诊记录.xml";
                //return _DemoFilePath;
                if (string.IsNullOrEmpty(this._DemoFilePath) == true)
                {
                    return Application.StartupPath + @"\DemoFile\南京都昌科技ST_会诊记录.xml";
                }
                else
                {
                    string filePath = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\" + _DemoFilePath);
                    return filePath;
                }
            }
            set
            {
                if (value != null)
                {
                    this._DemoFilePath = value + ".xml";
                }
            }
        }

        public ApplicationScenes()
        {
            InitializeComponent();
        }
        public ApplicationScenes(object xxx)
        {
            InitializeComponent();
            DemoFilePath = Convert.ToString(xxx);
        }

        private void ApplicationScenes_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(DemoFilePath))
            {
                writerControlApply.LoadDocumentFromFile(DemoFilePath, "xml");
                writerControlRecord.LoadDocumentFromFile(DemoFilePath, "xml");
                writerControlApply.UserLoginByParameter("wang", "王五", 1);
                writerControlRecord.UserLoginByParameter("li", "李四", 1);
            }
            else
            {
                string diterctPath = Path.GetDirectoryName(DemoFilePath);
                System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.DemoFile.defaultApplicationScenarios.xml");
                //writerControlApply.LoadDocumentFromFile(DemoFilePath, "xml");
                //writerControlRecord.LoadDocumentFromFile(DemoFilePath, "xml");
                writerControlApply.LoadDocument(stream, "xml");
                stream.Close();
                stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.DemoFile.defaultApplicationScenarios.xml");
                writerControlRecord.LoadDocument(stream, "xml");
                stream.Close();
                writerControlApply.UserLoginByParameter("wang", "王五", 1);
                writerControlRecord.UserLoginByParameter("li", "李四", 1);
            }

        }

    }
}

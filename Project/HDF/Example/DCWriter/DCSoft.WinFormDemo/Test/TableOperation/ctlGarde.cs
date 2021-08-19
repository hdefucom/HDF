using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [ToolboxItem(false)]
    public partial class ctlGarde : UserControl
    {
        public ctlGarde()
        {
            InitializeComponent();
        }


        private void ctlGarde_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void OpenDemoFile(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "DemoFile2\\" + ((ToolStripMenuItem)sender).Text);
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, null);
            }
        }

    }
}
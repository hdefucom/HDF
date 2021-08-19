using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test.OtherOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestAxWriterControl : UserControl
    {
        public ctlTestAxWriterControl()
        {
            InitializeComponent();
            string txt = File.ReadAllText(Path.Combine(Application.StartupPath, "Test\\OtherOperation\\documentbase64.txt"));
            this.myWriterControl.AxContentBase64String = txt;

        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            this.myWriterControl.CommandControler = this.writerCommandControler1;
            this.writerCommandControler1.Start();
            //myWriterControl.CommandControler = writerCommandControler1;
            //myWriterControl.CommandControler.Start();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myWriterControl.LoadDocumentFromFile(dlg.FileName, null);
                    //byte[] bs = File.ReadAllBytes(dlg.FileName);
                    //bs = DCSoft.Writer.Controls.AxWriterControl.GZipCompress(bs);
                    //string base64 = Convert.ToBase64String(bs);
                    //myWriterControl.AxContentBase64String = base64;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            myWriterControl.CloseForPBWithoutDock();
            MessageBox.Show("aaa");
            myWriterControl.CloseForPBWithoutDock();
        }

        private void btnLoadBase64_Click(object sender, EventArgs e)
        {
            using (frmText dlg = new frmText())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myWriterControl.AxContentBase64String = dlg.InputText;
                }
            }
        }

        private void btnUnCompress_Click(object sender, EventArgs e)
        {
            using (frmText dlg = new frmText())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string base64 = dlg.InputText;
                    byte[] bs = AxWriterControl.InnerParseBase64String(base64);
                    if (bs != null)
                    {
                        using (SaveFileDialog dlg2 = new SaveFileDialog())
                        {
                            dlg2.Filter = "*.xml|*.xml";
                            dlg2.CheckPathExists = true;
                            dlg2.OverwritePrompt = true;
                            if (dlg2.ShowDialog(this) == DialogResult.OK)
                            {
                                System.IO.File.WriteAllBytes(dlg2.FileName, bs);
                            }
                        }
                    }
                }
            }
        }

        private void btnSaveBase64_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "*.txt|*.txt";
                dlg.OverwritePrompt = true;
                dlg.CheckPathExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, this.myWriterControl.AxContentBase64String , Encoding.Default );
                }
            }
        }

        private void btnTestPostBack_Click(object sender, EventArgs e)
        {
            string base64 = this.myWriterControl.SaveToAxContentBase64String();
            this.myWriterControl.ClearContent();
            MessageBox.Show("准备填充");
            XTextDocument doc = AxWriterControl.InnerLoadAxContentBase64String(base64);
            string base2 = AxWriterControl.SaveToAxContentBase64String(doc);
            myWriterControl.AxContentBase64String = base2;
        }
         
    }
}
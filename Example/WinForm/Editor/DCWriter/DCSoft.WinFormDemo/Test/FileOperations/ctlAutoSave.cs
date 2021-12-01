using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ctlAutoSave : UserControl
    {
        public ctlAutoSave()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            //myWriterControl.ViewMode = DCSoft.Printing.PageViewMode.Normal;
            myWriterControl.EventSaveFileContentForAutoSave += new WriterSaveFileContentEventHandler(
                myWriterControl_EventSaveFileContentForAutoSave);
            //myWriterControl.MouseClick += new MouseEventHandler(myWriterControl_MouseClick);
        }

        //void myWriterControl_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        myWriterControl.MoveToClientPosition(e.X, e.Y);
        //    }
        //}

        void myWriterControl_EventSaveFileContentForAutoSave(object eventSender, WriterSaveFileContentEventArgs args)
        {
            byte[] bs = args.BinaryContentToSave;
            string fileName = System.IO.Path.Combine(Application.StartupPath, "autosave.xml");
            System.IO.File.WriteAllBytes(fileName, bs);
            args.Handled = true;
            MessageBox.Show("自动保存到:" + fileName );
        }
          

        private void btnSetAutoSave_Click(object sender, EventArgs e)
        {
            int v = 0;
            if (int.TryParse(this.txtInterval.Text, out v))
            {
                myWriterControl.DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond = v;
            }
            else
            {
                myWriterControl.DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond = 0;
            }
            myWriterControl.ResetAutoSaveTask();
        }

    }
}
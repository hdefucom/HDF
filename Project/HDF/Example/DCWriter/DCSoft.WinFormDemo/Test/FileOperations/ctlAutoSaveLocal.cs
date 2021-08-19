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
    public partial class ctlAutoSaveLocal : UserControl
    {
        public ctlAutoSaveLocal()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();



            //btnStartLocalAutoSave_Click(null, null);
            
        } 

        private void btnStartLocalAutoSave_Click(object sender, EventArgs e)
        {
            // 10秒自动保存一次
            this.myWriterControl.DocumentOptions.BehaviorOptions.AutoSaveIntervalInSecond = 10;
            // 设置保存临时文件的目录
            this.myWriterControl.DocumentOptions.BehaviorOptions.LocalAutoSaveWorkDirectory 
                = System.IO.Path.Combine(Application.StartupPath, "AutoSave");
            // 启动基于本地文件系统的自动保存功能
            this.myWriterControl.StartLocalAutoSave();
            MessageBox.Show(this, "打开一个文件。自动保存时间间隔设置为10秒。只有被修改过的文件才会自动保存，若没有任何修改不触发自动保存。");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"程序将立即退出，请您在下次启动程序后再打开同样的文件。");
            //System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            //p.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = dlg.FileName;
                    if (this.myWriterControl.AutoSaveExists(fileName, true))
                    {
                        // 系统发现上次保存的临时文件，经过用户确认后加载临时文件
                        this.myWriterControl.AutoSaveLoadDocument(fileName);
                        //this.myWriterControl.Document.FileName = fileName;
                    }
                    else
                    {
                        // 直接加载文件
                        this.myWriterControl.LoadDocumentFromFile(fileName, null);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = myWriterControl.Document.FileName;
            if (string.IsNullOrEmpty(fileName) == false)
            {
                myWriterControl.SaveDocumentToFile(fileName , null );
                // 删除自动保存操作生成的临时文件
                this.myWriterControl.AutoSaveDelete(fileName);
            }
        }
         
    }
}
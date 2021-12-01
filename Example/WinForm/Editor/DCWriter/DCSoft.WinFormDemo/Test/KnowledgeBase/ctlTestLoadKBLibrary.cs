using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.KnowledgeBase
{
    [ToolboxItem(false)]
    public partial class ctlTestLoadKBLibrary : UserControl
    {
        public ctlTestLoadKBLibrary()
        {
            InitializeComponent();
        }

        private void frmTestLoadKBLibrary_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnLoadKBLibraryInstance_Click(object sender, EventArgs e)
        {
            // 加载知识库对象
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "kblibrary.xml");
            if (System.IO.File.Exists(fileName))
            {
                KBLibrary lib = new KBLibrary();
                lib.Load(fileName);
                myWriterControl.ExecuteCommand("LoadKBLibrary", false, lib);
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // 从文件加载知识库
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "kblibrary.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("LoadKBLibrary", false, fileName);
            }
        }

        private void btnLoadStream_Click(object sender, EventArgs e)
        {
            // 从文件流中加载知识库
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "kblibrary.xml");
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.Stream stream = new System.IO.FileStream(
                    fileName,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read))
                {
                    myWriterControl.ExecuteCommand("LoadKBLibrary", false, stream);
                }
            }
        }


        private void btnLoadTextReader_Click(object sender, EventArgs e)
        {
            // 从文本读取器中加载知识库
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "kblibrary.xml");
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.TextReader reader = new System.IO.StreamReader(
                    fileName,
                    System.Text.Encoding.UTF8,
                    true))
                {
                    myWriterControl.ExecuteCommand("LoadKBLibrary", false, reader);
                }
            }
        }

        private void btnCreateInstance_Click(object sender, EventArgs e)
        {
            // 动态创建知识库对象并加载知识库
            KBLibrary lib = new KBLibrary();
            lib.KBEntries = new KBEntryList();

            // 添加一个知识节点
            KBEntry entry = new KBEntry();
            entry.ID = "sex";
            entry.Text = "性别";
            // ListItems属性值默认为null，因此需要实例化
            entry.ListItems = new ListItemCollection();
            entry.ListItems.AddByTextValue("", "");
            entry.ListItems.AddByTextValue("男", "男");
            entry.ListItems.AddByTextValue("女", "女");
            lib.KBEntries.Add(entry);

            // 添加一个知识节点
            entry = new KBEntry();
            entry.ListItems = new ListItemCollection();
            entry.ID = "type";
            entry.Text = "病人类型";
            entry.ListItems = new ListItemCollection();
            entry.ListItems.AddByTextValue("门诊", "门诊");
            entry.ListItems.AddByTextValue("急诊", "急诊");
            entry.ListItems.AddByTextValue("转院", "转院");
            lib.KBEntries.Add(entry);

            myWriterControl.ExecuteCommand("LoadKBLibrary", false, lib);
        }

        private void btnLoadURL_Click(object sender, EventArgs e)
        {
            using (DCSoft.WinForms.Native.dlgInputUrl dlg = new WinForms.Native.dlgInputUrl())
            {
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    myWriterControl.ExecuteCommand("LoadKBLibrary", false, dlg.InputURL);
                }
            }
        }
    }
}
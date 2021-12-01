using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data ;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.KnowledgeBase
{
    [ToolboxItem(false)]
    public partial class ctlQueryKBEntries : UserControl
    {
        public ctlQueryKBEntries()
        {
            InitializeComponent();
        }

        private KBLibrary _lib = null;

        private void ctlQueryKBEntries_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "kblibrary.xml");
            if (System.IO.File.Exists(fileName))
            {
                _lib = new KBLibrary();
                _lib.Load(fileName);
            }
            //add by ld
            string newfilename = System.IO.Path.Combine(Application.StartupPath, @"DemoFile\自定义知识库节点.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, newfilename);
        }


        private void myWriterControl_QueryKBEntries(object sender, QueryKBEntriesEventArgs args)
        {
            if (this._lib != null)
            {
                if (string.IsNullOrEmpty(args.SpellCode))
                {
                    args.Result = _lib.KBEntries;
                }
                else
                {
                    args.Result = _lib.SearchKBEntries(args.SpellCode);
                }
            }
            else
            {
                args.Cancel = true;
            }
        }
    }
}
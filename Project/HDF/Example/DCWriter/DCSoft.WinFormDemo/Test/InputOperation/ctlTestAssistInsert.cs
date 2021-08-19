using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestAssistInsert : UserControl
    {
        public ctlTestAssistInsert()
        {
            InitializeComponent();
        }


        private void ctlTestAssistInsert_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.DocumentOptions.BehaviorOptions.AutoAssistInsertString = btnAutoAssist.Checked;
        }

        private void btnLoadAssistItems_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(
                    Application.StartupPath,
                    "DemoFile\\辅助快速录入项目.txt");
            myWriterControl.ExecuteCommand(StandardCommandNames.LoadGlobalAssistStringItemFromFile, false, fileName);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myWriterControl.ExecuteCommand(StandardCommandNames.LoadGlobalAssistStringItemFromFile, false, dlg.FileName);
                }
            }
        }

        private void btnAutoAssist_Click(object sender, EventArgs e)
        {
            myWriterControl.DocumentOptions.BehaviorOptions.AutoAssistInsertString = btnAutoAssist.Checked;
        }

        private void btnFillItemEvent_Click(object sender, EventArgs e)
        {
            myWriterControl.EventQueryAssistInputItems += new WriterQueryAssistInputItemsEventHandler(myWriterControl_EventQueryAssistInputItems);
        }

        void myWriterControl_EventQueryAssistInputItems(object eventSender, WriterQueryAssistInputItemsEventArgs args)
        {
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    if (string.IsNullOrEmpty(args.PreWord))
                    {
                        cmd.CommandText = "Select top 100 name  From  EMR_DOCEX   order by name";
                    }
                    else
                    {
                        cmd.CommandText = "Select top 100 name From  EMR_DOCEX   where name like '" + args.PreWord + "%'  order by name ";
                    }
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        args.Items.Add(Convert.ToString(reader.GetValue(0)));
                    }
                    reader.Close();
                }
            }
        }
         
    }
}
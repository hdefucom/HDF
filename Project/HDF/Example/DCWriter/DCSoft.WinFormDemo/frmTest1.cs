using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class frmTest1 : Form
    {
        public frmTest1()
        {
            InitializeComponent();
        }

        private void writerControl1_DocumentLoad(object sender, EventArgs e)
        {
            EMR.Model.EMR_Patients p = new EMR.Model.EMR_Patients();
            p.PA_ID = "0001";
            p.PA_NAME = "张三" ;

            writerControl1.SetDocumentParameterValue("EMR_Patients", p);
            writerControl1.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand(WriterCommandNames.UpdateViewForDataSource, false, null);
            writerControl1.SetDocumentParameterValue("EMR_Patients", null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand(WriterCommandNames.FileOpen, true, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void frmTest1_Load(object sender, EventArgs e)
        {
            this.writerControl1.CommandControler = this.writerCommandControler1;
            this.writerCommandControler1.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using System.IO;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            writerControl1.CommandControler = writerCommandControler1;
            writerControl1.CommandControler.Start();

        }

        private void btnLoadXML2_Click(object sender, EventArgs e)
        {
            string xml1 = null;
            using (StreamReader reader = new StreamReader("d:\\xml1.txt", Encoding.Default))
            {
                xml1 = reader.ReadToEnd();
            }
            string xml2 = null;
            using (StreamReader reader = new StreamReader("d:\\xml2.txt", Encoding.Default))
            {
                xml2 = reader.ReadToEnd();
            }
            writerControl1.ClearContent();
            writerControl1.ExecuteCommand("InsertXML", false, xml1);
            writerControl1.ClearContent();
            writerControl1.ExecuteCommand("InsertXML", false, xml2);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FilePrintPreviewCommandParameter cp = new FilePrintPreviewCommandParameter();
            cp.ZoomRate = PrintPreviewZoomRate.Zoom100;
            cp.Maximized = true;
            cp.IsTurnToPage = true;
            cp.TurnToPage = this.writerControl1.JumpPrint.PageIndex;
            this.writerControl1.ExecuteCommand("FilePrintPreview", true, cp);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("MoveToPage", false, 2);
            writerControl1.ExtViewMode = WriterControlExtViewMode.JumpPrint;
            writerControl1.JumpPrintPosition = 4500;

            //writerControl1.ExtViewMode = WriterControlExtViewMode.JumpPrint;
            //writerControl1.JumpPrintPosition = 2200;

            //double pagenumber = Math.Floor(writerControl1.JumpPrintPosition / this.writerControl1.Pages[0].Height);
            //writerControl1.ExecuteCommand("MoveToPage", false, (int)pagenumber+1);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    myWriter.SetDocumentParameterValue("PatientName", "张三");
        //    XTextInputFieldElement field = new XTextInputFieldElement();
        //    field.ValueBinding = new XDataBinding();
        //    field.ValueBinding.AutoUpdate = true;
        //    field.ValueBinding.DataSource = "PatientName";
        //    field.ValueBinding.Readonly = true;
        //    field.Readonly = true;
        //    object result = myWriter.ExecuteCommand("InsertInputField", false, field);
        //    System.Console.WriteLine(Convert.ToString(result));

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //myWriter.AppHost.CommandContainer.Modules.Add(new DCSoft.Writer.Extension.WriterCommandModuleExtension());
        //    myWriter.ExecuteCommand("InsertMedicalExpression", true, null);
        //}
    }
}

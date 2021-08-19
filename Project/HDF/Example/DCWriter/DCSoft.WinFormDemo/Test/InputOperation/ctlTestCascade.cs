using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;
using DCSoft.Writer;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestCascade : UserControl
    {
        public ctlTestCascade()
        {
            InitializeComponent();
        }

        private void frmTestCascade_Load(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine( 
                Application.StartupPath ,
                @"DemoFile\CascadeTemplate.xml");
            myWriterControlExt.ExecuteCommand("FileOpen", false, fileName);
            ElementEventTemplate eet = new ElementEventTemplate();
            eet.ContentChanged += new ContentChangedEventHandler(eet_ContentChanged);
            myWriterControlExt.InnerWriterControl.GlobalEventTemplates[typeof(XTextInputFieldElement)] = eet;

            ElementEventTemplate bodyEt = new ElementEventTemplate();
            bodyEt.ContentChanged += new ContentChangedEventHandler(bodyEt_ContentChanged);
            myWriterControlExt.InnerWriterControl.GlobalEventTemplates[typeof(XTextDocumentBodyElement)] = bodyEt;
        }

        void bodyEt_ContentChanged(object sender, ContentChangedEventArgs args)
        {
            
        }

        void eet_ContentChanged(object sender, ContentChangedEventArgs args)
        {
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            myWriterControlExt.ExecuteCommand("FileOpen", true, null);
        }

        private void btnViewXMLSource_Click(object sender, EventArgs e)
        {
            myWriterControlExt.ExecuteCommand("ViewXMLSource", true, null);
        }
         
    }
}

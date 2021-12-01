using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    [ToolboxItem(false)]
    public partial class ctlTestCheckMRID : UserControl
    {
        public ctlTestCheckMRID()
        {
            InitializeComponent();
        }



        private void frmTestCheckMRID_Load(object sender, EventArgs e)
        {
            foreach (object obj in Enum.GetValues(typeof(DCSoft.Writer.InsertDocumentWithCheckMRIDType)))
            {
                cboStyle.Items.Add(obj);
            }
            cboStyle.SelectedIndex = 0;
            cboDataObjectRange.SelectedIndex = 0;
            writerControl1.CreationDataFormats = WriterDataFormats.Text;
            this.writerControl1.AllowDragContent = true;
            this.writerControl1.AllowDrop = true;
            this.writerControl2.AllowDragContent = true;
            this.writerControl2.AllowDrop = true;
        }

        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertDocumentWithCheckMRIDType ct = (InsertDocumentWithCheckMRIDType)cboStyle.SelectedItem;
            writerControl1.DocumentOptions.BehaviorOptions.InsertDocumentWithCheckMRID = ct;
            writerControl2.DocumentOptions.BehaviorOptions.InsertDocumentWithCheckMRID = ct;
        }

        //private void btnSetMRID1_Click(object sender, EventArgs e)
        //{
        //    writerControl1.Document.Info.MRID = txtMRID1.Text;
        //}

        private void btnCopy1_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("Copy", true, null);
        }

        private void btnPaste1_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("Paste", true, null);
        }


        //private void btnSetMRID2_Click(object sender, EventArgs e)
        //{
        //    writerControl2.Document.Info.MRID = txtMRID2.Text;
        //}

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            writerControl2.ExecuteCommand("Copy", true, null);
        }

        private void btnPaste2_Click(object sender, EventArgs e)
        {
            writerControl2.ExecuteCommand("Paste", true, null);
        }

        private void txtMRID1_TextChanged(object sender, EventArgs e)
        {
            writerControl1.Document.Info.MRID = txtMRID1.Text;
        }

        private void txtMRID2_TextChanged(object sender, EventArgs e)
        {
            writerControl2.Document.Info.MRID = txtMRID2.Text;
        }

        private void btnIsTemplate_Click(object sender, EventArgs e)
        {
            writerControl1.Document.Info.IsTemplate = btnIsTemplate.Checked;
        }

        private void btnInsertXML_Click(object sender, EventArgs e)
        {
            string xml = writerControl1.Document.Selection.XMLText;
            writerControl2.ExecuteCommand("InsertXML", true , xml);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("FileOpen", true, null);
            writerControl1.Document.Info.MRID = txtMRID1.Text;
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            writerControl2.ExecuteCommand("FileOpen", true, null);
            writerControl2.Document.Info.MRID = txtMRID2.Text;
        }

        private void cboDataObjectRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            writerControl1.DataObjectRange = (WriterDataObjectRange)cboDataObjectRange.SelectedIndex;
            writerControl2.DataObjectRange = writerControl1.DataObjectRange;
        }

        private void btnSpecifyLimit_Click(object sender, EventArgs e)
        {
            writerControl2.DataObjectRange = WriterDataObjectRange.OS;
            writerControl2.DocumentOptions.BehaviorOptions.DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject = true;
            writerControl2.DocumentOptions.BehaviorOptions.InsertDocumentWithCheckMRID = InsertDocumentWithCheckMRIDType.PromptForbitWhenFail;
            writerControl2.AcceptDataFormats = WriterDataFormats.Text;
        }
    }
}

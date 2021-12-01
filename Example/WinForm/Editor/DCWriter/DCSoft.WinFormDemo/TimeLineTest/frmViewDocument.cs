using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    public partial class frmViewDocument : Form
    {
        public frmViewDocument()
        {
            InitializeComponent();
        }

        private string _DocumentName = null;
        /// <summary>
        /// 文档名称
        /// </summary>
        public string DocumentName
        {
            get { return _DocumentName; }
            set { _DocumentName = value; }
        }

        private void frmViewDocument_Load(object sender, EventArgs e)
        {
            if (File.Exists(this.DocumentName))
            {
                this.writerControl1.LoadDocumentFromFile(this.DocumentName, null);
                this.Text = Path.GetFileName(this.DocumentName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.writerControl1.SaveDocument(this.DocumentName, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test
{
    [System.ComponentModel.ToolboxItem( false )]
    public partial class frmEditOneDocument : Form
    {
        public frmEditOneDocument()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private string _FileName = null;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        private void frmEditOneDocument_Load(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty( this.FileName ) == false && System.IO.File.Exists(this.FileName))
            {
                myWriterControlExt.ExecuteCommand("FileOpen", false, this.FileName);
            }
            else
            {
                this.FileName = null;
                // 加载病程记录模板
                string tempFile = Path.Combine(
                    Application.StartupPath,
                    "DemoFile\\模板-病程记录.xml");
                myWriterControlExt.ExecuteCommand("FileOpen", false, tempFile);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (myWriterControlExt.Document.Attributes == null)
            {
                myWriterControlExt.Document.Attributes = new XAttributeList();
            }
            myWriterControlExt.Document.Attributes.SetValue("作者", cboUser.Text);
            if ( string.IsNullOrEmpty( this.FileName ))
            {
                this.FileName = System.IO.Path.Combine(
                    Application.StartupPath, 
                    "DemoFile\\病程记录" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒") + ".xml");
            }
            myWriterControlExt.ExecuteCommand("FileSave", false, this.FileName);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

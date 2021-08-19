using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class frmShowImage : Form
    {
        public frmShowImage()
        {
            InitializeComponent();
        }

        private string _ImageFileName = null;

        public string ImageFileName
        {
            get { return _ImageFileName; }
            set { _ImageFileName = value; }
        }
        private void frmShowImage_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this._ImageFileName))
            {
                this.Text = this.Text + this._ImageFileName;
                this.webBrowser1.Navigate(this._ImageFileName);
            }
        }
    }
}

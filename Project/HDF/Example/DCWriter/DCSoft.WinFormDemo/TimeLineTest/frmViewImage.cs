using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    public partial class frmViewImage : Form
    {
        public frmViewImage()
        {
            InitializeComponent();
        }

        private string _FileName = null;

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        private void frmViewImage_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(_FileName))
            {
                Image img = Image.FromFile(_FileName);
                panel1.BackgroundImage = img;
                panel1.AutoScroll = true;
                panel1.AutoScrollMinSize = new Size(img.Width, img.Height);
                this.Text = System.IO.Path.GetFileName(_FileName);
            }
        }
    }
}

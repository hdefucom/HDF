using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class dlgBrowseWebServices : Form
    {
        public dlgBrowseWebServices()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public string InputURL
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }

        public DCSoft.Writer.Controls.WebServiceServerType InputServerType
        {
            get
            {
                return (DCSoft.Writer.Controls.WebServiceServerType)this.cboType.SelectedIndex;
            }
            set
            {
                this.cboType.SelectedIndex = (int)value;
            }
        }

        private void dlgBrowseWebServices_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.FriedmanCurveTest
{
    public partial class dlgRegister : Form
    {
        public dlgRegister()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public string RegisterCode
        {
            get
            {
                return this.txtRegisterCode.Text;
            }
            set
            {
                txtRegisterCode.Text = value;
            }
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

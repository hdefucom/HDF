using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test
{
    public partial class dlgDataBindingDescriptorList : Form
    {
        public dlgDataBindingDescriptorList()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private FieldValueDescriptorList _InputDataBindingDescriptors = null;

        public FieldValueDescriptorList InputDataBindingDescriptors
        {
            get { return _InputDataBindingDescriptors; }
            set { _InputDataBindingDescriptors = value; }
        }

        private void dlgDataBindingDescriptorList_Load(object sender, EventArgs e)
        {
            myDataGridView.DataSource = this.InputDataBindingDescriptors;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

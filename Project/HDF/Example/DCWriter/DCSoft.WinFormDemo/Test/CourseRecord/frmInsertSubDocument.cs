using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    public partial class frmInsertSubDocumentTemplate : Form
    {
        ctlTestMulCourse6 ctl6 = null;
        public frmInsertSubDocumentTemplate(ctlTestMulCourse6 ctl)
        {
            InitializeComponent();
            this.ctl6 = ctl;
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ctl6.SubDocumentTime = this.dateTimePicker1.Value;
            this.ctl6.SubDocumentType = this.comboBox1.Text;
            this.ctl6.SubDocumentSign = this.comboBox2.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

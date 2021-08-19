using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test
{
    public partial class dlgDataTable : Form
    {
        public dlgDataTable()
        {
            InitializeComponent();
        }

        public System.Data.DataTable InputDataTable
        {
            get
            {
                return this.dataGridView1.DataSource as DataTable;
            }
            set
            {
                this.dataGridView1.DataSource = value;
            }
        }

        private void dlgDataTable_Load(object sender, EventArgs e)
        {

        }
    }
}

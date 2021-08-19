using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class dlgBrowseDOCEXTable : Form
    {
        public dlgBrowseDOCEXTable()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dlgBrowseDOCEXTable_Load(object sender, EventArgs e)
        {
            System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.Test.DOCEX.xml");
            DataTable table = new DataTable();
            table.ReadXml(stream);
            dgvData.DataSource = table;
        }

        private DataTable _SelectedDataTable = null;

        public DataTable SelectedDataTable
        {
            get { return _SelectedDataTable; }
            set { _SelectedDataTable = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SelectedDataTable = (DataTable)dgvData.DataSource;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

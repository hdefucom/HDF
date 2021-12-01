using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.WinFormDemo.EMR.Model;
using DCSoft.Writer.WinFormDemo.Test.TableOperation;

namespace DCSoft.Writer.WinFormDemo.Test
{
    public partial class frmShowData : Form
    {
        public frmShowData()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private DataTable _DataTable = null;

        public DataTable dateTable
        {
            get { return _DataTable; }
            set { _DataTable = value; }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDateFrm_Load(object sender, EventArgs e)
        {
            ctlTestSetCells  setcell=new ctlTestSetCells ();
            DataTable dt = dateTable;

            DgvPatients.DataSource = dateTable;
            
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}

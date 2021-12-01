using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.WinFormDemo.EMR.Model;
using DCSoft.Writer.WinFormDemo.EMR;

namespace DCSoft.Writer.WinFormDemo.Test
{
    public partial class dlgSelectPatients : Form
    {
       
        public dlgSelectPatients()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private EMR_Patients _EMR_Patients = null;

        public EMR_Patients EMR_Patients
        {
            get { return _EMR_Patients; }
            set { _EMR_Patients = value; }
        }


        public void getDate()
        {

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPatients.SelectedRows.Count > 0)
                {

                    string strid = DgvPatients.SelectedRows[0].Cells[0].Value.ToString();
                    string strName = DgvPatients.SelectedRows[0].Cells[1].Value.ToString();
                    string strSex = DgvPatients.SelectedRows[0].Cells[2].Value.ToString();
                    string strSapce = DgvPatients.SelectedRows[0].Cells[3].Value.ToString();
                    string strHome = DgvPatients.SelectedRows[0].Cells[4].Value.ToString();
                    EMR_Patients temp = new EMR_Patients();
                    temp.PA_ID = strid;
                    temp.PA_NAME = strName;
                    temp.PA_SEX = strSex;
                    temp.PA_PIH_PATIENT_SAPCE = strSapce;
                    temp.PA_HOMEPLACE = strHome;
                    _EMR_Patients = temp;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("没有选着数据！！");
                }
            }
            catch { }
        }

        private void SelectPatients_Load(object sender, EventArgs e)
        {
            DgvPatients.AutoGenerateColumns = false;
            List<EMR_Patients> list = EMRDataProvider.GetSelectDate(Utils.CreateConnection());
            DgvPatients.DataSource = list;
        }
    }
}

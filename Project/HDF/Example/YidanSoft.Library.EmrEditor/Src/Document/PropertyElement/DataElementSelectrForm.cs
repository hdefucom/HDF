using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.DataElement;

namespace YidanSoft.Library.EmrEditor.Src.Document.PropertyElement
{
    public partial class DataElementSelectrForm : Form
    {
        public object m_value;  //里面存放数据元的id

        /// <summary>
        /// 2019.06.26-hdf
        /// 新增病历模板编辑器功能，数据源字典，属性-选择数据源代码，窗体初始化查询进行筛选，筛选出所有S2,S3类型的数据元
        /// 
        /// 数据元查询类型，默认查询所有
        /// </summary>
        public string DataElementSelectrType = "ALL";


        public DataElementSelectrForm(object value)
        {
            InitializeComponent();
            m_value = value;
        }

        private void DataElementSelectrForm_Load(object sender, EventArgs e)
        {

            /// List<STD_DataElementEntity> dataElementList = STD_DataElementBiz.GetAllSTD_DataElementEntityList();

            /// 2019.06.26-hdf
            /// 新增功能，数据源字典，属性-选择数据源代码，窗体初始化查询进行筛选，筛选出所有S2,S3类型的数据元
            List<STD_DataElementEntity> dataElementList = new List<STD_DataElementEntity>();
            if (DataElementSelectrType == "ALL")
            {
                dataElementList = STD_DataElementBiz.GetAllSTD_DataElementEntityList();
            }
            else if (DataElementSelectrType == "S2S3")
            {
                dataElementList = STD_DataElementBiz.GetSTD_DataElementEntityListByValueType("S2","S3");
            }
            gcDataElement.DataSource = dataElementList;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            STD_DataElementEntity std_DataElementEntity = gridView1.GetFocusedRow() as STD_DataElementEntity;
            if (std_DataElementEntity != null)
            {
                m_value = std_DataElementEntity.DATAELEMENT_ID;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            STD_DataElementEntity std_DataElementEntity = gridView1.GetFocusedRow() as STD_DataElementEntity;
            if (std_DataElementEntity != null)
            {
                m_value = std_DataElementEntity.DATAELEMENT_ID;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}

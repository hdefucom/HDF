using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace YidanSoft.Library.EmrEditor.Src.DataElement
{
    public class STD_DataElement_Value_RangeBiz
    {
        private static DataTable m_STD_DataElement_Value_RangeDataTable;
        private static string ValueRange;


        public static DataTable GetSTD_DataElement_Value_RangeDataTableByValueRangeCode(string valueRangeCode)
        {
            if (m_STD_DataElement_Value_RangeDataTable != null && m_STD_DataElement_Value_RangeDataTable.Rows.Count > 0 && ValueRange == valueRangeCode)
            {
                return m_STD_DataElement_Value_RangeDataTable;
            }
            else
            {
                ValueRange = valueRangeCode;
                //2019.10.10-hdf：数据元字典增加品应五笔筛选功能
                string sql = @"select VALUE_RANGE_CODE,VALUE_RANGE_NAME,VALUE_CODE,VALUE_NAME,VALUE_TYPE,VALUE_DESC,VALUE_RANGE_CODE_MEMO,PY,WB 
                               from std_dataelement_value_range where VALUE_RANGE_CODE='" + valueRangeCode + "'";



                m_STD_DataElement_Value_RangeDataTable = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, System.Data.CommandType.Text);
                return m_STD_DataElement_Value_RangeDataTable;
            }
        }

        /// 2019.06.28-hdf
        /// LookUpEditor控件绑定数据
        /// 注释原因，控件直接绑定datatable，无法绑定List实体
        /// 
        /// <summary>
        /// 获取相应“值范围”的数据元枚举值实体
        /// </summary>
        /// <param name="valueRange">值范围</param>
        /// <returns></returns>
        //        public static List<STD_DataElement_Value_RangeEntity> GetSTD_DataElement_Value_RangeEntityListByValueRangeCode(string valueRangeCode)
        //        {
        //            if (m_STD_DataElement_Value_RangeEntityList != null && m_STD_DataElement_Value_RangeEntityList.Count > 0 && ValueRange == valueRangeCode)
        //            {
        //                return m_STD_DataElement_Value_RangeEntityList.Where(data => data.VALUE_RANGE_CODE == valueRangeCode).ToList();
        //            }
        //            else
        //            {
        //                ValueRange = valueRangeCode;
        //                m_STD_DataElement_Value_RangeEntityList = new List<STD_DataElement_Value_RangeEntity>();
        //                string sql = @"select VALUE_RANGE_CODE,VALUE_RANGE_NAME,VALUE_CODE,VALUE_NAME,VALUE_TYPE,VALUE_DESC,VALUE_RANGE_CODE_MEMO 
        //                               from std_dataelement_value_range where VALUE_RANGE_CODE='" + valueRangeCode + "'";

        //                DataTable dt = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, System.Data.CommandType.Text);
        //                if (dt != null && dt.Rows != null)
        //                {
        //                    foreach (DataRow item in dt.Rows)
        //                    {
        //                        STD_DataElement_Value_RangeEntity std_DataElement_Value_RangeEntity = new STD_DataElement_Value_RangeEntity();
        //                        std_DataElement_Value_RangeEntity.VALUE_RANGE_CODE = item["VALUE_RANGE_CODE"].ToString();
        //                        std_DataElement_Value_RangeEntity.VALUE_RANGE_NAME = item["VALUE_RANGE_NAME"].ToString();
        //                        std_DataElement_Value_RangeEntity.VALUE_CODE = item["VALUE_CODE"].ToString();
        //                        std_DataElement_Value_RangeEntity.VALUE_NAME = item["VALUE_NAME"].ToString();
        //                        std_DataElement_Value_RangeEntity.VALUE_TYPE = item["VALUE_TYPE"].ToString();

        //                        std_DataElement_Value_RangeEntity.VALUE_DESC = item["VALUE_DESC"].ToString();
        //                        std_DataElement_Value_RangeEntity.VALUE_RANGE_CODE_MEMO = item["VALUE_RANGE_CODE_MEMO"].ToString();

        //                        m_STD_DataElement_Value_RangeEntityList.Add(std_DataElement_Value_RangeEntity);
        //                    }
        //                }
        //            }
        //            return m_STD_DataElement_Value_RangeEntityList;
        //        }





    }
}

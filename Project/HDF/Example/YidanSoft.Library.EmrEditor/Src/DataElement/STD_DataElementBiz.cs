using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YidanSoft.Library.EmrEditor.Src.DataElement
{
    public class STD_DataElementBiz
    {

        private static List<STD_DataElementEntity> m_STD_DataElementEntityList;

        /// <summary>
        /// 获取电子病历的所有数据元
        /// </summary>
        /// <returns></returns>
        public static List<STD_DataElementEntity> GetAllSTD_DataElementEntityList()
        {
            if (m_STD_DataElementEntityList == null)
            {
                m_STD_DataElementEntityList = new List<STD_DataElementEntity>();
                string sql = @"select   DATAELEMENT_ID, DATASET_TYPE, DATASET_NAME, DATASET_SUB_NAME, DATA_INNER_CODE,
                     DATAELEMENT_CODE, DATAELEMENT_NAME, VALUE_TYPE, VALUE_FORMAT, VALUE_RANGE,
                    VERSION, VALUE_RANGE_COUNT 
                    from std_dataelement a  where a.dataset_type='电子病历基本数据集'";
                DataTable dt = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, System.Data.CommandType.Text);
                if (dt != null && dt.Rows != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        STD_DataElementEntity std_DataElementEntity = new STD_DataElementEntity();
                        std_DataElementEntity.DATAELEMENT_ID = item["DATAELEMENT_ID"].ToString();
                        std_DataElementEntity.DATASET_TYPE = item["DATASET_TYPE"].ToString();
                        std_DataElementEntity.DATASET_NAME = item["DATASET_NAME"].ToString();
                        std_DataElementEntity.DATASET_SUB_NAME = item["DATASET_SUB_NAME"].ToString();
                        std_DataElementEntity.DATA_INNER_CODE = item["DATA_INNER_CODE"].ToString();

                        std_DataElementEntity.DATAELEMENT_CODE = item["DATAELEMENT_CODE"].ToString();
                        std_DataElementEntity.DATAELEMENT_NAME = item["DATAELEMENT_NAME"].ToString();
                        std_DataElementEntity.VALUE_TYPE = item["VALUE_TYPE"].ToString();
                        std_DataElementEntity.VALUE_FORMAT = item["VALUE_FORMAT"].ToString();
                        std_DataElementEntity.VALUE_RANGE = item["VALUE_RANGE"].ToString();

                        std_DataElementEntity.VERSION = item["VERSION"].ToString();
                        std_DataElementEntity.VALUE_RANGE_COUNT = Convert.ToInt32(item["VALUE_RANGE_COUNT"]);
                        m_STD_DataElementEntityList.Add(std_DataElementEntity);
                    }
                }

            }
            return m_STD_DataElementEntityList;
        }

        /// <summary>
        /// 2019.06.26-hdf
        /// 新增病历模板编辑器功能，数据源字典，属性-选择数据源代码，窗体初始化查询进行筛选，筛选出所有S2,S3类型的数据元
        /// 
        /// 获取相应值类型的电子病历的数据元
        /// 可传多个数据元值类型参数
        /// </summary>
        /// <param name="valueType">数据元值类型</param>
        /// <returns></returns>
        public static List<STD_DataElementEntity> GetSTD_DataElementEntityListByValueType(params string[] valueType)
        {
            #region 注释原因：数据元字典列表缓存假如先查询限制条件的列表，之后获取无限制数据列表会读取缓存的有限制条件列表数据
            //            if (m_STD_DataElementEntityList != null && m_STD_DataElementEntityList.Count > 0)
            //            {
            //                //如果m_STD_DataElementEntityList缓存了则筛选相应数据元值类型的对象实体List
            //                return m_STD_DataElementEntityList.Where(dataElement => valueType.Contains(dataElement.VALUE_TYPE)).ToList();
            //            }
            //            else
            //            {
            //                m_STD_DataElementEntityList = new List<STD_DataElementEntity>();
            //                string sql = @"select   DATAELEMENT_ID, DATASET_TYPE, DATASET_NAME, DATASET_SUB_NAME, DATA_INNER_CODE,
            //                     DATAELEMENT_CODE, DATAELEMENT_NAME, VALUE_TYPE, VALUE_FORMAT, VALUE_RANGE,
            //                    VERSION, VALUE_RANGE_COUNT 
            //                    from std_dataelement a  where a.dataset_type='电子病历基本数据集'";

            //                //设置数据元值类型条件
            //                if (valueType.Length > 0 && valueType != null)
            //                {
            //                    sql += " and (";
            //                    for (int i = 0; i < valueType.Length; i++)
            //                    {
            //                        if (i > 0)
            //                        {
            //                            sql += " or ";
            //                        }
            //                        sql += "a.value_type='" + valueType[i] + "'";

            //                    }
            //                    sql += ") and a.value_range is not null";
            //                }

            //                DataTable dt = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, System.Data.CommandType.Text);
            //                if (dt != null && dt.Rows != null)
            //                {
            //                    foreach (DataRow item in dt.Rows)
            //                    {
            //                        STD_DataElementEntity std_DataElementEntity = new STD_DataElementEntity();
            //                        std_DataElementEntity.DATAELEMENT_ID = item["DATAELEMENT_ID"].ToString();
            //                        std_DataElementEntity.DATASET_TYPE = item["DATASET_TYPE"].ToString();
            //                        std_DataElementEntity.DATASET_NAME = item["DATASET_NAME"].ToString();
            //                        std_DataElementEntity.DATASET_SUB_NAME = item["DATASET_SUB_NAME"].ToString();
            //                        std_DataElementEntity.DATA_INNER_CODE = item["DATA_INNER_CODE"].ToString();

            //                        std_DataElementEntity.DATAELEMENT_CODE = item["DATAELEMENT_CODE"].ToString();
            //                        std_DataElementEntity.DATAELEMENT_NAME = item["DATAELEMENT_NAME"].ToString();
            //                        std_DataElementEntity.VALUE_TYPE = item["VALUE_TYPE"].ToString();
            //                        std_DataElementEntity.VALUE_FORMAT = item["VALUE_FORMAT"].ToString();
            //                        std_DataElementEntity.VALUE_RANGE = item["VALUE_RANGE"].ToString();

            //                        std_DataElementEntity.VERSION = item["VERSION"].ToString();
            //                        std_DataElementEntity.VALUE_RANGE_COUNT = Convert.ToInt32(item["VALUE_RANGE_COUNT"]);
            //                        m_STD_DataElementEntityList.Add(std_DataElementEntity);
            //                    }
            //                }

            //            }
            #endregion

            //假如缓存数据为空则重新查询所有数据出来，直接在缓存中筛选数据
            if (m_STD_DataElementEntityList == null)
            {
                m_STD_DataElementEntityList = GetAllSTD_DataElementEntityList();
            }
            return m_STD_DataElementEntityList.Where(dataElement => valueType.Contains(dataElement.VALUE_TYPE)).ToList();
        }

        /// <summary>
        /// 2019.07.15-hdf
        /// 添加原因：病历文书录入保存时需要保存病历元素，但是元素有数据元Id数据，没有数据元值范围编码数据，所以根据数据元Id查询你数据元值范围
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetSTD_DataElement_DATAELEMENTCODEById(string id)
        {
            if (id == "" || id == null) return "";
            string dataelement_code = "";
            if (m_STD_DataElementEntityList != null && m_STD_DataElementEntityList.Exists(e => e.DATA_INNER_CODE == id))
            {
                var query = from e in m_STD_DataElementEntityList
                            where e.DATA_INNER_CODE == id
                            select dataelement_code = e.DATAELEMENT_CODE;
            }
            else
            {
                string sql = "select dataelement_code from std_dataelement where dataelement_id='" + id + "'";
                dataelement_code = YiDanSqlHelper.YD_SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text).ToString();
            }
            return dataelement_code;
        }

        public static STD_DataElementEntity GetSTD_DataElementEntityById(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return new STD_DataElementEntity();
            }
            if (m_STD_DataElementEntityList != null)
            {
                return m_STD_DataElementEntityList.SingleOrDefault(a => a.DATAELEMENT_ID == id);
            }
            else
            {
                string sql = string.Format(@"select   DATAELEMENT_ID, DATASET_TYPE, DATASET_NAME, DATASET_SUB_NAME, DATA_INNER_CODE,
                     DATAELEMENT_CODE, DATAELEMENT_NAME, VALUE_TYPE, VALUE_FORMAT, VALUE_RANGE,
                    VERSION, VALUE_RANGE_COUNT 
                    from std_dataelement a  where a.DATAELEMENT_ID='{0}'", id);
                DataTable dt = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, System.Data.CommandType.Text);
                if (dt != null && dt.Rows != null)
                {
                    DataRow item = dt.Rows[0];
                    STD_DataElementEntity std_DataElementEntity = new STD_DataElementEntity();
                    std_DataElementEntity.DATAELEMENT_ID = item["DATAELEMENT_ID"].ToString();
                    std_DataElementEntity.DATASET_TYPE = item["DATASET_TYPE"].ToString();
                    std_DataElementEntity.DATASET_NAME = item["DATASET_NAME"].ToString();
                    std_DataElementEntity.DATASET_SUB_NAME = item["DATASET_SUB_NAME"].ToString();
                    std_DataElementEntity.DATA_INNER_CODE = item["DATA_INNER_CODE"].ToString();

                    std_DataElementEntity.DATAELEMENT_CODE = item["DATAELEMENT_CODE"].ToString();
                    std_DataElementEntity.DATAELEMENT_NAME = item["DATAELEMENT_NAME"].ToString();
                    std_DataElementEntity.VALUE_TYPE = item["VALUE_TYPE"].ToString();
                    std_DataElementEntity.VALUE_FORMAT = item["VALUE_FORMAT"].ToString();
                    std_DataElementEntity.VALUE_RANGE = item["VALUE_RANGE"].ToString();

                    std_DataElementEntity.VERSION = item["VERSION"].ToString();
                    std_DataElementEntity.VALUE_RANGE_COUNT = Convert.ToInt32(item["VALUE_RANGE_COUNT"]);
                    return std_DataElementEntity;

                }
                else
                {
                    return new STD_DataElementEntity();
                }
            }
        }

    }
}

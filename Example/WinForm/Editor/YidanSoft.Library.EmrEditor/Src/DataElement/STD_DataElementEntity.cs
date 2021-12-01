using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.DataElement
{
    public class STD_DataElementEntity
    {
        private string _DATAELEMENT_ID;
       
        /// <summary>
        /// 病历中数据元主键
        /// </summary>
        public string DATAELEMENT_ID
        {
            get { return _DATAELEMENT_ID; }
            set { _DATAELEMENT_ID = value; }
        }


        private string _DATASET_TYPE;
        /// <summary>
        /// 数据集类型
        /// </summary>
        public string DATASET_TYPE
        {
            get { return _DATASET_TYPE; }
            set { _DATASET_TYPE = value; }
        }

        private string _DATASET_NAME;
        /// <summary>
        /// 数据集名称
        /// </summary>
        public string DATASET_NAME
        {
            get { return _DATASET_NAME; }
            set { _DATASET_NAME = value; }
        }
        private string _DATASET_SUB_NAME;
        /// <summary>
        /// 数据集子集名称
        /// </summary>
        public string DATASET_SUB_NAME
        {
            get { return _DATASET_SUB_NAME; }
            set { _DATASET_SUB_NAME = value; }
        }
        private string _DATA_INNER_CODE;
        /// <summary>
        /// 数据元内部编码
        /// </summary>
        public string DATA_INNER_CODE
        {
            get { return _DATA_INNER_CODE; }
            set { _DATA_INNER_CODE = value; }
        }
        private string _DATAELEMENT_CODE;
        /// <summary>
        /// 数据元编码
        /// </summary>
        public string DATAELEMENT_CODE
        {
            get { return _DATAELEMENT_CODE; }
            set { _DATAELEMENT_CODE = value; }
        }
        private string _DATAELEMENT_NAME;
        /// <summary>
        /// 数据元名称
        /// </summary>
        public string DATAELEMENT_NAME
        {
            get { return _DATAELEMENT_NAME; }
            set { _DATAELEMENT_NAME = value; }
        }
        private string _DATAELEMENT_DESC;
        /// <summary>
        /// 数据元描述
        /// </summary>
        public string DATAELEMENT_DESC
        {
            get { return _DATAELEMENT_DESC; }
            set { _DATAELEMENT_DESC = value; }
        }
        private string _VALUE_TYPE;
        /// <summary>
        /// 值类型
        /// </summary>
        public string VALUE_TYPE
        {
            get { return _VALUE_TYPE; }
            set { _VALUE_TYPE = value; }
        }
        private string _VALUE_FORMAT;
        /// <summary>
        ///值格式 
        /// </summary>
        public string VALUE_FORMAT
        {
            get { return _VALUE_FORMAT; }
            set { _VALUE_FORMAT = value; }
        }
        private string _VALUE_RANGE;
        /// <summary>
        /// 值范围编码
        /// </summary>
        public string VALUE_RANGE
        {
            get { return _VALUE_RANGE; }
            set { _VALUE_RANGE = value; }
        }
        private string _VERSION;
        /// <summary>
        /// 版本
        /// </summary>
        public string VERSION
        {
            get { return _VERSION; }
            set { _VERSION = value; }
        }
        private string _VALUE_RANGE_MEMO;
        /// <summary>
        /// 值范围编码注释 无用
        /// </summary>
        public string VALUE_RANGE_MEMO
        {
            get { return _VALUE_RANGE_MEMO; }
            set { _VALUE_RANGE_MEMO = value; }
        }
        private int _VALUE_RANGE_COUNT;
        /// <summary>
        /// 值域记录条数粗略计算
        /// </summary>
        public int VALUE_RANGE_COUNT
        {
            get { return _VALUE_RANGE_COUNT; }
            set { _VALUE_RANGE_COUNT = value; }
        }
        
    }
}

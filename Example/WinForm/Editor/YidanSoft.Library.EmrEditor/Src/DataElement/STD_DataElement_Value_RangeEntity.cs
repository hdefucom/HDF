using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.DataElement
{
    public class STD_DataElement_Value_RangeEntity
    {
        private string _VALUE_RANGE_CODE;
        /// <summary>
        /// 值范围编码
        /// </summary>
        public string VALUE_RANGE_CODE
        {
            get { return _VALUE_RANGE_CODE; }
            set { _VALUE_RANGE_CODE = value; }
        }
        private string _VALUE_RANGE_NAME;
        /// <summary>
        /// 值范围名称
        /// </summary>
        public string VALUE_RANGE_NAME
        {
            get { return _VALUE_RANGE_NAME; }
            set { _VALUE_RANGE_NAME = value; }
        }
        private string _VALUE_CODE;
        /// <summary>
        /// 值编码
        /// </summary>
        public string VALUE_CODE
        {
            get { return _VALUE_CODE; }
            set { _VALUE_CODE = value; }
        }
        private string _VALUE_NAME;
        /// <summary>
        /// 值名称
        /// </summary>
        public string VALUE_NAME
        {
            get { return _VALUE_NAME; }
            set { _VALUE_NAME = value; }
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
        private string _VALUE_DESC;
        /// <summary>
        /// 值描述
        /// </summary>
        public string VALUE_DESC
        {
            get { return _VALUE_DESC; }
            set { _VALUE_DESC = value; }
        }
        private string _VALUE_RANGE_CODE_MEMO;
        /// <summary>
        /// 值范围编码描述
        /// </summary>
        public string VALUE_RANGE_CODE_MEMO
        {
            get { return _VALUE_RANGE_CODE_MEMO; }
            set { _VALUE_RANGE_CODE_MEMO = value; }
        }
    }
}

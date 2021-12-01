using System;
using System.Collections.Generic;
using System.Text;

namespace DCSoft.Writer.WinFormDemo.EMR
{
    /// <summary>
    /// 电子病历对象属性业务相关说明
    /// </summary>
    [AttributeUsage( AttributeTargets.Property )]
    public class EMRPropertyDescriptionAttribute : Attribute
    {
        public EMRPropertyDescriptionAttribute()
        {
        }

        private string _ListStyle = null;
        /// <summary>
        /// 列表属性说明
        /// </summary>
        public string ListStyle
        {
            get { return _ListStyle; }
            set { _ListStyle = value; }
        }

        private bool _ListOnly = false;
        /// <summary>
        /// 只是用下拉列表来读取数据，用户不能自由输入
        /// </summary>
        public bool ListOnly
        {
            get { return _ListOnly; }
            set { _ListOnly = value; }
        }

        private string _ListDisplayMember = null;
        /// <summary>
        /// 下拉列表中显示的文本成员名
        /// </summary>
        public string ListDisplayMember
        {
            get { return _ListDisplayMember; }
            set { _ListDisplayMember = value; }
        }

        private string _ListValueMember = null;
        /// <summary>
        /// 下拉列表中显示的数值成员名
        /// </summary>
        public string ListValueMember
        {
            get { return _ListValueMember; }
            set { _ListValueMember = value; }
        }
        private string _DisplayFormat = null;
        /// <summary>
        /// 显示格式 
        /// </summary>
        public string DisplayFormat
        {
            get { return _DisplayFormat; }
            set { _DisplayFormat = value; }
        }
    }
}

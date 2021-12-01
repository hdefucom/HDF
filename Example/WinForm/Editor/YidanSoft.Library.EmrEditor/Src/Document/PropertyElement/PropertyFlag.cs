using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyFlag : PropertyBase
    {
        ZYFlag _e;
        public PropertyFlag(object o)
            : base(o)
        {
            _e = (ZYFlag)o;
        }

        [Category("属性设置"), DisplayName("分组编码"), Description("在文书中成对出现，可提取2个括号内的内容")]
        public string GroupId
        {
            get { return _e.GroupID; }
            // set { _e.GroupID = value; }
        }


        [Category("数据元代码"), DisplayName("数据元代码")]
        [EditorAttribute(typeof(DataElementMultiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Code
        {
            get { return _e.Code; }
            set
            {
                _e.Code = value;
                _e.Name = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(_e.Code).DATAELEMENT_NAME;
            }
        }

        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return _e.Name; }
            set { _e.Name = value; }
        }

        /// <summary>
        /// Add by wwj 2013-08-01 在定位符的属性窗体中显示 是否可以删除的属性
        /// </summary>
        [Category("属性设置"), DisplayName("删除"), Description("病历书写时是否可以删除此元素")]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return _e.CanDelete; }
            set { _e.CanDelete = value; }
        }

        /// <summary>
        /// Add by wwj 2013-08-01 定位符显示的方向
        /// </summary>
        [Category("属性设置"), DisplayName("方向"), Description("定位符显示的方向")]
        public ZYFlagDirection Direction
        {
            get { return _e.Direction; }
           // set { _e.Direction = value; }
        }

        /// <summary>
        /// Add by wwj 2013-08-01 打印时是否保留空间
        /// </summary>
        [Category("属性设置"), DisplayName("打印时是否保留空间"), Description("打印时是否保留空间")]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool IsHoldSpaceWhenPrint
        {
            get { return _e.IsHoldSpaceWhenPrint; }
            set { _e.IsHoldSpaceWhenPrint = value; }
        }

       

    }
}

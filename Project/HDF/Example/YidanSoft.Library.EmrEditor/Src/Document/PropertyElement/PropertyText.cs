using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyText : PropertyBase
    {
        ZYText _e;
        public PropertyText(object o)
            : base(o)
        {
            _e = (ZYText)o;
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
            //set { _e.Name = value; } //add by myc 2014-07-14 注释原因：没有考虑名称为空时的异常处理
            set
            {
                if (string.IsNullOrEmpty(value)) //add by myc 2014-07-14 添加原因：名称为空时的默认处理，避免编辑器初始化元素出现异常
                {
                    _e.Name = "只读文本";
                }
                else
                {
                    _e.Name = value;
                }
            }
        }

        [Category("属性设置"), DisplayName("是否允许删除"), Description("设置改元素是否允许删除")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return _e.CanDelete; }
            set { _e.CanDelete = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyFormatNumber : PropertyBase
    {
        ZYFormatNumber _e;
        public PropertyFormatNumber(object e)
            : base(e)
        {
            _e = (ZYFormatNumber)e;
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

        [Category("属性设置"), DisplayName("当前值")]
        public decimal Value
        {
            get { return _e.Value; }
            set { _e.Value = value; }
        }
        [Category("属性设置"), DisplayName("长度")]
        public uint Length
        {
            get { return _e.Length; }
            set { _e.Length = value; }
        }
        [Category("属性设置"), DisplayName("小数位数")]
        public uint DecimalDigits
        {
            get { return _e.DecimalDigits; }
            set { _e.DecimalDigits = value; }
        }
        [Category("属性设置"), DisplayName("最大值")]
        public decimal MaxValue
        {
            get { return _e.MaxValue; }
            set { _e.MaxValue = value; }
        }
        [Category("属性设置"), DisplayName("最小值")]
        public decimal MinValue
        {
            get { return _e.MinValue; }
            set { _e.MinValue = value; }
        }
        [Category("属性设置"), DisplayName("必点项"), Description("必须用鼠标双击，以表示关注过此项。")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool MustClick
        {
            get { return _e.MustClick; }
            set { _e.MustClick = value; }
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

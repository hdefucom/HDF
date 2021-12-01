using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 牙齿检查的属性类 
    /// add by ywk 2012年11月27日16:45:58 
    /// </summary>
    public class PropertyToothCheck : PropertyBase
    {
        ZYToothCheck _e;
        public PropertyToothCheck(object o)
            : base(o)
        {
            _e = (ZYToothCheck)o;
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
        }


        [Category("属性设置"), DisplayName("必点项"), Description("必须用鼠标双击，以表示关注过此项。")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool MustClick
        {
            get { return _e.MustClick; }
            set { _e.MustClick = value; }
        }

        [Category("属性设置"), DisplayName("左上颚")]
        public string LeftUp
        {
            get { return _e.LeftUp; }
            set { _e.LeftUp = value; }
        }
        [Category("属性设置"), DisplayName("左下颚")]
        public string LeftDown
        {
            get { return _e.LeftDown; }
            set { _e.LeftDown = value; }
        }
        [Category("属性设置"), DisplayName("右上颚")]
        public string RightUp
        {
            get { return _e.RightUp; }
            set { _e.RightUp = value; }
        }

        [Category("属性设置"), DisplayName("右下颚")]
        public string RightDown
        {
            get { return _e.RightDown; }
            set { _e.RightDown = value; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyButton : PropertyBase
    {
                ZYButton e;
                public PropertyButton(object o) : base(o)
        {
            e = (ZYButton)o;
        }

        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return e.Name; }
            set { e.Name = value; }
        }


        [Category("属性设置"), DisplayName("打印")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool Print
        {
            get { return e.Print; }
            set { e.Print = value; }
        }

        [Category("属性设置"), DisplayName("事件")]
        [EditorAttribute(typeof(DropDownEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Event
        {
            get { return e.Event; }
            set { e.Event = value; }
        }

        [Category("属性设置"), DisplayName("删除"), Description("病历书写时是否可以删除此元素")]
        //[TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return e.CanDelete; }
            set { e.CanDelete = value; }
        }
    }

}

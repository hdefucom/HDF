using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyLookUpeditorElement : PropertyBase
    {
        ZYLookupEditor e;
        public PropertyLookUpeditorElement(object o)
            : base(o)
        {

            e = (ZYLookupEditor)o;
        }

        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return e.Name; }
            set { e.Name = value; }
        }

        [Category("属性设置"), DisplayName("是否多选")]
        public bool Multi
        {
            get { return e.Multi; }
            set { e.Multi = value; }

        }



        [Category("属性设置"), DisplayName("字典名称")]
        [EditorAttribute(typeof(DropDownWordBookEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string WordBook
        {
            get { return e.Wordbook; }
            set { e.Wordbook = value; }
        }

        [Category("属性设置"), DisplayName("是否允许删除"), Description("设置改元素是否允许删除")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return e.CanDelete; }
            set { e.CanDelete = value; }
        }
    }
}

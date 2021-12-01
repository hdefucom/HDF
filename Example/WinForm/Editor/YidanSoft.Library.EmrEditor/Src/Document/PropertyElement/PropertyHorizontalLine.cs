using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YidanSoft.Library.EmrEditor.Src.Document.PropertyElement;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyHorizontalLine : PropertyBase
    {
        ZYHorizontalLine e;
        public PropertyHorizontalLine(object o)
            : base(o)
        {
            e = (ZYHorizontalLine)o;
        }


        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return e.Name; }
        }


        [Category("属性设置"), DisplayName("线宽")]
        public uint LineHeight
        {
            get { return e.LineHeight; }
            set { e.LineHeight = value; }
        }

        [Category("属性设置"), DisplayName("线长(%)"), Description("相对于页面宽度的百分比")]
        [EditorAttribute(typeof(PercentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int Percent
        {
            get { return e.Percent; }
            set { e.Percent = value; }
        }

    }

}

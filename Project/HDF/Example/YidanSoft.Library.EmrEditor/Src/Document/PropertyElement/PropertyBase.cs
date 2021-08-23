using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyBase
    {
        ZYTextElement e = null;

        public PropertyBase(object o)
        {
            e = o as ZYTextElement;
        }

        [Category("元素类型"), DisplayName("类型")]
        [TypeConverter(typeof(ElementTypeConverter))]
        public ElementType Type
        {
            get { return e.Type; }
        }

        //[Category("元素类型"), DisplayName("值域代码")]
        //public string Code
        //{
        //    get { 
            
        //    }
        //}

    }
}

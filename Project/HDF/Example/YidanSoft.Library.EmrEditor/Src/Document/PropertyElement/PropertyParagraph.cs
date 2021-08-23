using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YidanSoft.Library.EmrEditor.Src.Document;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyParagraph
    {
        ZYTextParagraph _p;
        public PropertyParagraph(object o)
        {
            _p = (ZYTextParagraph)o;
        }

        [DisplayName("对齐方式"),Category("段落格式") ]
        [EditorAttribute(typeof(ParagraphEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(ParagraphConverter))]
        public ParagraphAlignConst Align
        {
            get { return _p.Align; }
            set { _p.Align = value; }
        }
    }
}

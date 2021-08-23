using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZYTextDocumentLib;
using System.ComponentModel;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document 
{
    public class PropertyImage
    {
        ZYTextImage _img;
        public PropertyImage(object o)
        {
            _img = (ZYTextImage)o;
        }


        [Category("图片设置"),DisplayName("图片来源")]
        [TypeConverter(typeof(BlankConverter))]
        public Image Image
        {
            get { return _img.Image; }
            set { _img.Image = value; }
        }
    }
}

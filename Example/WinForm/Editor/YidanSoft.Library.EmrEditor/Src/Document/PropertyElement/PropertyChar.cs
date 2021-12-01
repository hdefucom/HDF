using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyChar
    {
        ZYTextChar _c;
        public PropertyChar(object o)
        {
            _c = (ZYTextChar)o;
        }

        [Category("字体格式"), DisplayName("字体名称")]
        [EditorAttribute(typeof(FontEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string FontName
        {
            get { return _c.FontName; }
            set { _c.FontName = value; }
        }
        [Category("字体格式"), DisplayName("字号")]
        public float FontSize
        {
            get { return _c.FontSize; }
            set { _c.FontSize = value; }
        }
        [Category("字体格式"), DisplayName("颜色")]
        [TypeConverter(typeof(BlankConverter))]
        public Color ForeColor
        {
            get { return _c.ForeColor; }
            set { _c.ForeColor = value; }
        }

        [Category("字体格式"), DisplayName("粗体")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool FontBold
        {
            get { return _c.FontBold; }
            set { _c.FontBold = value; }
        }

        [Category("字体格式"), DisplayName("斜体")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool FontItalic
        {
            get { return _c.FontItalic; }
            set { _c.FontItalic = value; }
        }

        [Category("字体格式"), DisplayName("下划线")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool FontUnderLine
        {
            get { return _c.FontUnderLine; }
            set { _c.FontUnderLine = value; }
        }

        [Category("字体格式"), DisplayName("上下标")]
        [TypeConverter(typeof(TypeConverter))]
        [EditorAttribute(typeof(SupSubEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SupSub
        {
            get
            {
                if (_c.Sup)
                    return "上标";
                if (_c.Sub)
                    return "下标";
                return "无";
            }
            set
            {
                    _c.Sub = false;
                    _c.Sup = false;
                if (value == "上标")
                {
                    _c.Sup = true;
                }
                if (value == "下标")
                    _c.Sub = true;

            }
        }

    }
}

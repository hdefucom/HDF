using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YidanSoft.Library.EmrEditor.Src.Document;



internal class ParagraphConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return true;
    }
    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
    {
        switch ((ParagraphAlignConst)value)
        {
            case ParagraphAlignConst.Center:
                return "居中对齐";

            case ParagraphAlignConst.Disperse:
                return "分散对齐";

            case ParagraphAlignConst.Justify:
                return "两端对齐";

            case ParagraphAlignConst.Left:
                return "左对齐";

            case ParagraphAlignConst.Right:
                return "右对齐";

        }
        return "";
    }

}




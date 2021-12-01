using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Document;
using YidanSoft.Library.EmrEditor.Src.Document.Table;

internal class EnumConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return true;
    }
    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
    {
        if (value is Enum)
        {
            var f = value.GetType().GetField(value.ToString());
            var desc = (DescriptionAttribute)Attribute.GetCustomAttribute(f, typeof(DescriptionAttribute), false);
            if (desc == null)
                return "请设置";
            return desc.Description;
        }

        return "请设置";
    }

}
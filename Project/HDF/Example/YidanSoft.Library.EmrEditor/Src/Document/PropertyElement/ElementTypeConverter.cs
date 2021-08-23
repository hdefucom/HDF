using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YidanSoft.Library.EmrEditor.Src.Document;

internal class ElementTypeConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return true;
    }
    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
    {

        switch ((ElementType)value)
        {
            case ElementType.Button:
                return "按钮";
            case ElementType.CheckBox:
                return "复选框";
            case ElementType.FixedText:
                return "标签";
            case ElementType.FormatDatetime:
                return "格式化日期时间";
            case ElementType.FormatNumber:
                return "格式化数字";
            case ElementType.FormatString:
                return "格式化字符串";
            case ElementType.HaveNotElement:
                return "有无选";
            case ElementType.HorizontalLine:
                return "水平线";
            case ElementType.Macro:
                return "宏";
            case ElementType.MensesFormula:
                return "月经史公式";
                //新增的牙齿检查  add by ywk 2012年11月27日16:54:28 
            case ElementType.ToothCheck:
                return "牙齿检查";
                 
            case ElementType.MultiElement:
                return "多选";
            case ElementType.PromptText:
                return "录入提示";
            case ElementType.Replace:
                return "复用项目";
            case ElementType.SingleElement:
                return "单选";
            case ElementType.Template:
                return "子模板";
            case ElementType.Text:
                return "文本";
            case ElementType.PageEnd:
                return "分页符";
            case ElementType.Flag:
                return "定位符";
            case ElementType.LookUpEditor:
                return "数据选择字典";
            case ElementType.DataElementLookUpEditor:
                return "数据元选择控件";
            case ElementType.Diag:
                return "病人诊断";
            case ElementType.Subject:
                return "辅助决策";
            case ElementType.TableSum:
                return "表格合计";
        }

        return "";
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 文档元素属性对象 
    /// </summary>
    public class ZYAttribute
    {
        private string strName = null;
        /// <summary>
        /// 保存属性值的变量
        /// </summary>
        private object objValue = null;
        /// <summary>
        /// 属性默认值
        /// </summary>
        public object DefaultValue = null;
        /// <summary>
        /// 属性名
        /// </summary>
        public string Name
        {
            get { return strName; }
            set
            {
                strName = value;
                DefaultValue = GetDefaultValue(strName);
 #region bwy : 
                objValue = DefaultValue;
#endregion bwy : 
            }
        }

        /// <summary>
        /// 程序内部使用的设置属性对象的数值的接口
        /// </summary>
        /// <param name="v"></param>
        internal void SetValue(object v)
        {
            objValue = v;
        }

        public ZYAttribute Clone()
        {
            ZYAttribute NewAttribute = new ZYAttribute();
            NewAttribute.Name = strName;
            NewAttribute.objValue = objValue;
            NewAttribute.DefaultValue = this.DefaultValue;
            return NewAttribute;
        }

        /// <summary>
        /// 属性值
        /// </summary>
        public object Value
        {
            get
            {
                if (objValue == null)
                    return DefaultValue;
                else
                    return objValue;
            }
            set
            {
                objValue = value;
            }
        }

        /// <summary>
        /// 比较两个属性对象是否一致
        /// </summary>
        /// <param name="myAttr"></param>
        /// <returns></returns>
        public bool EqualsValue(ZYAttribute myAttr)
        {
            if (myAttr == null) return false;
            if (myAttr == this) return true;
            if (myAttr.Name != strName) return false;
            if (this.Value != null)
                return this.Value.Equals(myAttr.Value);
            else
                return (myAttr.Value == null);
        }

        /// <summary>
        /// 设置,返回表示数值的字符串
        /// </summary>
        public string ValueString
        {
            get
            {
                // 若默认值类型为布尔型则当数值为真则返回"1"否则返回空引用
                if (DefaultValue is bool)
                {
                    if ((bool)objValue == true)
                        return "1";
                    else
                        return null;
                }
                // 若默认值类型为颜色值则返回 #HHHHHH 格式的字符串
                if (DefaultValue is System.Drawing.Color)
                    return StringCommon.ColorToHtml((System.Drawing.Color)objValue);
                // 若值为空引用则返回空引用,否则返回该数值的默认的字符串表达方式
                if (objValue == null)
                    return null;
                else
                    return objValue.ToString();
            }
            set
            {
                try
                {
                    // 若默认值为布尔类型的则当参数为空引用时设置数值为真,否则设置为假
                    if (DefaultValue is bool)
                        objValue = (value != null);
                    // 若默认值为颜色类型则认为参数为 #HHHHHH 格式的字符串,将参数转换为颜色值
                    else if (DefaultValue is System.Drawing.Color)
                        objValue = StringCommon.ColorFromHtml(value, System.Drawing.Color.Black);
                    else if (DefaultValue is ParagraphAlignConst)
                        objValue = (ParagraphAlignConst)StringCommon.ToInt32Value(value, (int)DefaultValue);
                    // 若默认值为整数类型则将参数转换为整数,否则直接进行赋值
                    else if (DefaultValue is int)
                        objValue = StringCommon.ToInt32Value(value, (int)DefaultValue);
                    else if (DefaultValue is float)
                        objValue = Convert.ToSingle(value);
                    else
                        objValue = value;
                }
                catch
                {
                    objValue = DefaultValue;
                }
            }
        }

        /// <summary>
        /// Judge if object's value need to be save
        /// </summary>
        /// <returns>if need to save return true else return false</returns>
        public bool isNeedSave()
        {
            // if value is null reference then not need to save
            if (objValue == null)
                return false;
            // if value equals default value then not need to save
            //即使与默认值相等，也保存
            //if (objValue.Equals(DefaultValue))
            //    return false;
            // if value's type is boolean and value is true then save , else not need to save
            if (objValue is bool)
                return (bool)objValue;
            else
                return true;
            // at last , consider the value need to save
        }// End of function : isNeedSave 

        /// <summary>
        /// 获得属性默认值
        /// </summary>
        /// <param name="strName">属性名</param>
        /// <returns>获得属性值</returns>
        public static object GetDefaultValue(string strName)
        {
            switch (strName)
            {
                case ZYTextConst.c_FontName:
                    //return "宋体";
                    return ZYEditorControl.GetDefaultSettings(ZYTextConst.c_FontName);
                case ZYTextConst.c_FontSize:
                    //return (float)12;
                    return FontCommon.GetFontSizeByName( ZYEditorControl.GetDefaultSettings(ZYTextConst.c_FontSize));
                case ZYTextConst.c_FontBold:
                    return false;
                case ZYTextConst.c_FontItalic:
                    return false;
                case ZYTextConst.c_FontUnderLine:
                    return false;
                case ZYTextConst.c_ForeColor:
                    return System.Drawing.SystemColors.WindowText;
                case ZYTextConst.c_Sub:
                    return false;
                case ZYTextConst.c_Sup:
                    return false;
                //				case ZYTextConst.c_DeleteTime :
                //					return null;
                case ZYTextConst.c_Deleter:
                    return (int)-1;
                case ZYTextConst.c_Creator:
                    return (int)0;
                case ZYTextConst.c_SaveList:
                    return true;
                case ZYTextConst.c_Align:
                    return 0;
                case ZYTextConst.c_Source:
                    return "0000000000";
                case ZYTextConst.c_ListSource:
                    return "0000000000";
                case ZYTextConst.c_SaveInFile:
                    return false;
                case ZYTextConst.c_Multiple:
                    return false;
                case ZYTextConst.c_HideTitle:
                    return false;
                case ZYTextConst.c_Height:
                    return 1;
                case ZYTextConst.c_NoContent:
                    return false;
                case ZYTextConst.c_TitleLine:
                    return false;
                case ZYTextConst.c_TitleAlign:
                    return "left";
                //				case ZYTextConst.c_UnitSource:
                //					return -1 ;
                case ZYTextConst.c_CircleFont:
                    return false;
                case ZYTextConst.c_LineHeightMultiple:
                    return 1.0;//行高默认值，必须是浮点类型，不能为int类型，否则导入xml时会使带小数的行高失效
                default:
                    return null;
            }
        }
    }//public class ZYAttribute 
}

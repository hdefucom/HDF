using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyFixedText : PropertyBase
    {
        ZYFixedText _e;
        XmlDocument testdoc = new XmlDocument();
        public PropertyFixedText(object o)
            : base(o)
        {
            _e = (ZYFixedText)o;
        }
        [Category("数据元代码"), DisplayName("数据元代码")]
        [EditorAttribute(typeof(DataElementMultiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Code
        {
            get { return _e.Code; }
            set
            {
                _e.Code = value;
                _e.Name = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(_e.Code).DATAELEMENT_NAME;
            }
        }

        [Category("属性设置"), DisplayName("可替换名"), Description("用于与可替换项名称的匹配，如 显示名称为“主诉”,可替换名为“主诉内容”或“主因”")]
        public string Name
        {
            get { return _e.Name; }
            set { _e.Name = value; }
        }


        [Category("属性设置"), DisplayName("显示名"), Description("不能输入特殊字符，但可以输入空格，冒号。")]
        public string Text
        {
            get { return _e.Text; }
            set
            {
                //try
                //{
                //    string str = value.Replace(" ", "");
                //    str = str.Replace("：", "");
                //    str = str.Replace(":", "");
                //    Regex regex = new Regex("\\s+");
                //    str = regex.Replace(str, "");
                //    testdoc.CreateElement(str);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    return;
                //}
                //如果输入了全部是空的，就把“标签”这个值赋上去
                //add by ywk 二〇一三年五月三十日 19:38:32 
                if (string.IsNullOrEmpty(value))
                {
                    value = "标签";
                }
                _e.Text = value;
            }
        }

        [Category("属性设置"), DisplayName("打印")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool Print
        {
            get { return _e.Print; }
            set { _e.Print = value; }
        }

        [Category("属性设置"), DisplayName("层次")]
        public Level? Level
        {
            get { return _e.Level; }
            set { _e.Level = value; }
        }

        [Category("属性设置"), DisplayName("是否允许删除"), Description("设置改元素是否允许删除")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return _e.CanDelete; }
            set { _e.CanDelete = value; }
        }

        [Category("属性设置"), DisplayName("是否开启辅助决策"), Description("设置是否开启辅助决策弹出框")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool AssistDecision
        {
            get { return _e.AssistDecision; }
            set { _e.AssistDecision = value; }
        }

    }

    /// <summary>
    /// 后面的值对应于字号
    /// </summary>
    public enum Level
    {
        一级 = 1,
        二级,
        三级,
        四级,
        五级,
        六级,
        七级,
        八级,
        九级,
        十级
    }
}

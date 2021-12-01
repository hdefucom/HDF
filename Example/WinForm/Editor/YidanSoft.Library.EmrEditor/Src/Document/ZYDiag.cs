using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public enum DiagType
    {
        /// <summary>
        /// 西医诊断
        /// </summary>
        XiYiZhenDuan,
        
        /// <summary>
        /// 中医病
        /// </summary>
        ZhongYiBing,

        /// <summary>
        /// 中医证
        /// </summary>
        ZhongYiZheng
    }

    public class ZYDiag : ZYTextBlock
    {
        public ZYDiag()
        {
            this.Type = ElementType.Diag;
        }

        /// <summary>
        /// 诊断类型，默认西医诊断
        /// </summary>
        public DiagType DiagType = DiagType.XiYiZhenDuan;


        public List<string> DiagCodes = new List<string>();
        public List<string> DiagNames = new List<string>();


        public string DiagCodesValue
        {
            get
            {
                return string.Join(",", DiagCodes.ToArray());
            }
            set
            {
                DiagCodes = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
        public string DiagNameValue
        {
            get
            {
                return string.Join(",", DiagNames.ToArray());
            }
            set
            {
                DiagNames = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_Diag;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);

                //添加数据元代码功能，给导出导入xml添加code属性
                myElement.SetAttribute("code", this.Code);

                myElement.SetAttribute("diagcode", this.DiagCodesValue);
                myElement.SetAttribute("diagname", this.DiagNameValue);

                myElement.SetAttribute("diagtype", this.DiagType.ToString());

                //宏元素、格式化字符串添加插入换行符功能（软回车）
                //所以这三个元素不再用text储存文本，而是使用ChildElement储存字符换行元素
                //由于这三个元素都是继承ZyTextBlock，所以直接在父类的ToXML和FromXML方法内修改逻辑
                //myElement.InnerText = this.Text;
                base.ToXML(myElement);

                //return base.ToXML(myElement);
            }
            return false;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Attributes.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");

                //添加数据元代码功能，给导出导入xml添加code属性
                this.Code = myElement.GetAttribute("code");

                this.DiagCodesValue = myElement.GetAttribute("diagcode");
                this.DiagNameValue = myElement.GetAttribute("diagname");

                this.DiagType = (DiagType)Enum.Parse(DiagType.GetType(), myElement.GetAttribute("diagtype"));

                //宏元素、格式化字符串添加插入换行符功能（软回车）
                //所以这三个元素不再用text储存文本，而是使用ChildElement储存字符换行元素
                //由于这三个元素都是继承ZyTextBlock，所以直接在父类的ToXML和FromXML方法内修改逻辑
                //this.Text = myElement.InnerText;
                this.text = myElement.InnerText;//修改Text会把子元素也修改了，所以只能用text储存文本
                base.FromXML(myElement);

                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYSubject : ZYTextBlock
    {
        public ZYSubject()
        {
            this.Type = ElementType.Subject;
        }


        public override string GetXMLName()
        {
            return ZYTextConst.c_Subject;
        }

        public string valueText;

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);

                //添加数据元代码功能，给导出导入xml添加code属性
                myElement.SetAttribute("code", this.Code);

                //myElement.SetAttribute("valueText", this.valueText);

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

                //this.valueText = myElement.GetAttribute("valueText");

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

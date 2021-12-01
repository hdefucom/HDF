using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYMacro : ZYTextBlock
    {
        public ZYMacro()
        {
            this.Type = ElementType.Macro;
            //2019.8.13-hdf-宏元素修改成默认可以删除
            //this.CanDelete = false;//2019.07.10-hdf：默认不能删除
        }


        public override string GetXMLName()
        {
            return ZYTextConst.c_Macro;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));

                myElement.SetAttribute("name", this.Name);
                //2019.07.01-hdf
                //添加数据元代码功能，给导出导入xml添加code属性
                myElement.SetAttribute("code", this.Code);
                myElement.SetAttribute("candelete", this.CanDelete.ToString());//2019.07.10-hdf：添加是否能删除属性


                //2019.8.14-hdf：宏元素、格式化字符串添加插入换行符功能（软回车）
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
                //2019.07.01-hdf
                //添加数据元代码功能，给导出导入xml添加code属性
                this.Code = myElement.GetAttribute("code");


                //2019.07.10-hdf：添加是否能删除属性
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }

                //2019.8.14-hdf：宏元素、格式化字符串添加插入换行符功能（软回车）
                //所以这三个元素不再用text储存文本，而是使用ChildElement储存字符换行元素
                //由于这三个元素都是继承ZyTextBlock，所以直接在父类的ToXML和FromXML方法内修改逻辑
                //this.Text = myElement.InnerText;
                this.text = myElement.InnerText;//修改Text会把子元素也修改了，所以只能用text储存文本
                base.FromXML(myElement);

                //2019.8.13-hdf：宏元素暂时全部设置成可以删除
                this.CanDelete = true;

                return true;
            }
            return false;
        }
    }
}

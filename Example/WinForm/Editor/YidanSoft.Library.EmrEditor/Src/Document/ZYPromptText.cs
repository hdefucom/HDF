using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYPromptText : ZYTextBlock
    {
        public ZYPromptText()
        {
            this.Type = ElementType.PromptText;
        }

        string name = "";
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (this.Text.Length == 0)
                {
                    this.Text = value;
                }
            }
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_Helement;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                base.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);

                myElement.InnerText = this.Text;
                
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
                base.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");
                this.Text = myElement.InnerText;
                return true;
            }
            return false;
            //return (this as ZYTextElement).FromXML(myElement); //add by myc 2014-03-05 调用元素数据基础加载方法，必须加这个，因为元素创建或删除痕迹是在此方法内部进行判断的。
        }

        
    }
}

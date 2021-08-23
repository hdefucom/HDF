using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Xml;
using System.Collections;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYTemplate :ZYTextBlock
    {
        public ZYTemplate()
        {
        this.Type = ElementType.Template;
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_Template;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);

                myElement.InnerText = this.Text;
                return true;
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


                this.Text = myElement.InnerText;
                return true;
            }
            return false;
        }
    }
}

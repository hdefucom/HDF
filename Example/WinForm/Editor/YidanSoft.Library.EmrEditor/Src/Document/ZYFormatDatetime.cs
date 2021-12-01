using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Windows.Forms;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYFormatDatetime : ZYTextBlock
    {
        public ZYFormatDatetime()
        {

            this.FormatString = "yyyy年MM月dd日HH时mm分";
            this.Type = ElementType.FormatDatetime;
            this.Value = System.DateTime.Now;
        }

        String formatString;
        public String FormatString
        {
            get { return formatString; }
            set { 
                formatString = value;
                this.Text = _value.ToString(this.formatString.ToString());
            }
        }
         DateTime _value;
        public DateTime Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.Text = _value.ToString(this.formatString.ToString());
            }
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_FTimeElement;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                base.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));

                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("formatString", this.FormatString);
                myElement.InnerText = this.Text;
                return true;
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
                this.FormatString = myElement.GetAttribute("formatString");
                this.Text = myElement.InnerText;
                return true;
            }
            return false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYFormatNumber : ZYTextBlock
    {
        public ZYFormatNumber()
        {
            this.Type = ElementType.FormatNumber;
        }

        //长度、小数位数、值范围

        public decimal _value;
        public decimal Value
        {
            get{return _value;}
            set { _value = value; 
            this.Text = value.ToString();
            }
        }

        uint length = 4;
        public uint Length
        {
            get { return length; }
            set { length = value; }
        }

        uint decimalDigits;
        public uint DecimalDigits
        {
            get { return decimalDigits; }
            set { decimalDigits = value; }
        }

        decimal maxValue=9999;
        public decimal MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        decimal minValue;
        public decimal MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_FNumElement;
        }
        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                base.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);

                myElement.SetAttribute("maxvalue", this.MaxValue.ToString());
                myElement.SetAttribute("minvalue", this.MinValue.ToString());
                myElement.SetAttribute("length", this.Length.ToString());
                myElement.SetAttribute("decimalDigits", this.DecimalDigits.ToString());
                myElement.SetAttribute("value", this.Value.ToString());

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
                this.MaxValue = decimal.Parse(myElement.GetAttribute("maxvalue"));
                this.MinValue = decimal.Parse(myElement.GetAttribute("minvalue"));
                this.Length = uint.Parse(myElement.GetAttribute("length"));
                this.DecimalDigits = uint.Parse(myElement.GetAttribute("decimalDigits"));
                this.Value = decimal.Parse(myElement.GetAttribute("value"));

                this.Text = myElement.InnerText;
                return true;
            }
            return false;
        }

        

    }
}

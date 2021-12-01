using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYText : ZYTextBlock
    {
        public ZYText()
        {
            this.Type = ElementType.Text;
        }


        public override string GetXMLName()
        {
            return ZYTextConst.c_EMRText;
        }

        public override string Text
        {
            set
            {
                this.ChildElements.Clear();
                foreach (char myc in value)
                {
                    //if (myc == '\r')
                    //{
                    //    ZYTextLineEnd le = new ZYTextLineEnd();
                    //    le.Parent = this;
                    //    le.OwnerDocument = this.OwnerDocument;
                    //    this.ChildElements.Add(le);
                    //}
                    //else
                    //{
                        ZYTextChar c = new ZYTextChar();
                        c.Char = myc;

                        Attributes.CopyTo(c.Attributes);
                        c.UpdateAttrubute();

                        c.Parent = this;
                        c.OwnerDocument = this.OwnerDocument;
                        this.ChildElements.Add(c);
                    //}

                }
                text = value;
            }
        }
        public override bool ToXML(System.Xml.XmlElement myElement)
        {

            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("code",this.Code);//add by ck 2014-06-03
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
                //value应该在设置Attributes之前
                this.Attributes.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");
                this.Text = myElement.InnerText;
                this.Code = myElement.GetAttribute("code");//add by ck 2014-06-03
                return true;
            }
            return false;
        }

        public override System.Collections.ArrayList RefreshLine()
        {
            return base.RefreshLine();
        }
        public override bool RefreshView()
        {
            //return base.RefreshView();
            return true;
        }
    }
}

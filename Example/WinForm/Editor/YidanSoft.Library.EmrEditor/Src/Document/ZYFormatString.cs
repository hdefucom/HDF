using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Drawing;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYFormatString : ZYTextBlock
    {
        public ZYFormatString()
        {

            this.Type = ElementType.FormatString;
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

        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value == "" || value.Trim().Length > this.Length) return;
                this.ChildElements.Clear();
                foreach (char myc in value)
                {
                    ZYTextChar c = new ZYTextChar();
                    c.Char = myc;
                    Attributes.CopyTo(c.Attributes);
                    c.UpdateAttrubute();

                    c.Parent = this;
                    c.OwnerDocument = this.OwnerDocument;
                    this.ChildElements.Add(c);
                }
                text = value;
            }
        }

        uint length = 10;
        public uint Length
        {
            get { return length; }
            set { length = value; }
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_FStrElement;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                base.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));

                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("length", this.Length.ToString());

                //2019.8.14-hdf：宏元素、格式化字符串添加插入换行符功能（软回车）
                //所以这三个元素不再用text储存文本，而是使用ChildElement储存字符换行元素
                //由于这三个元素都是继承ZyTextBlock，所以直接在父类的ToXML和FromXML方法内修改逻辑
                //myElement.InnerText = this.Text;
                //base.ToXML(myElement);

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
                this.Length = uint.Parse(myElement.GetAttribute("length"));

                //2019.8.14-hdf：宏元素、格式化字符串添加插入换行符功能（软回车）
                //所以这三个元素不再用text储存文本，而是使用ChildElement储存字符换行元素
                //由于这三个元素都是继承ZyTextBlock，所以直接在父类的ToXML和FromXML方法内修改逻辑
                //this.Text = myElement.InnerText;
                this.text = myElement.InnerText;//修改Text会把子元素也修改了，所以只能用text储存文本
                //base.FromXML(myElement);

                return true;
            }
            return false;
        }
    }
}

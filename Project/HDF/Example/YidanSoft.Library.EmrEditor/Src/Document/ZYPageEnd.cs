using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYPageEnd : ZYElement
    {
        public ZYPageEnd()
        {
            this.Type = ElementType.PageEnd;
        }

        public override bool RefreshView()
        {
            if (!this.OwnerDocument.Info.Printing)
            {
                this.RefreshSize();

                if (!this.OwnerDocument.IsPrintImage)
                {
                    Point p1 = new Point(this.RealLeft, this.RealTop);
                    Font f = new Font("宋体", 10);
                    OwnerDocument.View.DrawLine(Color.SkyBlue, p1.X, p1.Y + this.Height / 2, p1.X + this.Width / 2 - 75, p1.Y + this.Height / 2);
                    OwnerDocument.View.DrawString("分页符", f, Color.SkyBlue, p1.X + this.Width / 2 - 65, p1.Y + 10);
                    OwnerDocument.View.DrawLine(Color.SkyBlue, p1.X + this.Width / 2 + 75, p1.Y + this.Height / 2, p1.X + this.Width, p1.Y + this.Height / 2);
                }
            }
            return true;
        }

        public override bool RefreshSize()
        {
            //计算宽高
            this.Width = this.OwnerDocument.Pages.StandardWidth-10;
            this.Height = (int)this.OwnerDocument.DefaultRowHeight;
            return true;
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_PageEnd;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                return true;
            }
            return false;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Name = myElement.GetAttribute("name");
                return true;
            }
            return false;
        }

        public override string ToEMRString()
        {
            //return "---------分页符---------\r\n";
            return "" ;
        }

    }
}

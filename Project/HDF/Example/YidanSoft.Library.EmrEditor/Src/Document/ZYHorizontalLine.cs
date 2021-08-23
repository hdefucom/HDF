using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYHorizontalLine : ZYElement
    {
        public ZYHorizontalLine()
        {
            this.Type = ElementType.HorizontalLine;
        }

        int percent = 100;
        public int Percent
        {
            get { return percent; }
            set {
                if (value > 100)
                    percent = 100;
                else
                percent = value; }
        }

        uint lineHeight =2;
        public uint LineHeight
        {
            get { return lineHeight; }
            set {
                if (value > this.OwnerDocument.DefaultRowHeight)
                {
                    value = (uint)this.OwnerDocument.DefaultRowHeight;
                }
                lineHeight = value; 
            }
        }

        public override bool RefreshView()
        {
            this.RefreshSize();

            //如果是选择打印，则判断是否在范围之内
            if (this.OwnerDocument.EnableSelectionPrint)
            {
                #region add by myc 2014-08-25 添加原因：处理宜昌中心医院打印选中元素时的页眉和页脚水平线打印与不打印问题
                if (this.OwnerDocument.GetOwnerRoot(this) is ZYDocumentHeader || this.OwnerDocument.GetOwnerRoot(this) is ZYDocumentFooter)
                {
                    Pen pen = new Pen(Color.Black);
                    pen.Width = this.LineHeight;

                    Point p11 = new Point(this.RealLeft, this.RealTop);
                    p11.Offset(0, (int)this.Height / 4); //add by myc 2014-07-18 添加原因：页眉区域水平线与上一个文档行间距缩小

                    Point p22 = new Point();
                    p22 = p11;
                    p22.Offset(Width, 0);

                    OwnerDocument.View.DrawLine(pen, p11.X, p11.Y, p22.X, p22.Y);
                    return true;
                } 
                #endregion
                
                
                int selstart = this.OwnerDocument.Content.SelectStart;
                int sellength = this.OwnerDocument.Content.SelectLength;
                int selend = selstart + sellength;
                if (selstart > selend)
                {
                    selstart = selstart + selend;
                    selend = selstart - selend;
                    selstart = selstart - selend;
                }
                
                //int index = this.OwnerDocument.Elements.IndexOf(this); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                int index = this.OwnerDocument.HBFElements.IndexOf(this); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                
                
                if (selstart <= index && index < selend)
                {
                    //打印
                }
                else
                {
                    //不打印
                    return true;
                }
            }

            Pen p = new Pen(Color.Black);
            p.Width = this.LineHeight;

            Point p1 = new Point(this.RealLeft, this.RealTop);
            //p1.Offset(0, (int)this.Height / 2);
            p1.Offset(0, (int)this.Height / 4); //add by myc 2014-07-18 添加原因：页眉区域水平线与上一个文档行间距缩小

            Point p2 = new Point();
            p2 = p1;
            p2.Offset(Width, 0);

            OwnerDocument.View.DrawLine(p,p1.X,p1.Y,p2.X,p2.Y);
            return true;
            //return base.RefreshView();
        }

        public override bool RefreshSize()
        {
            //计算宽高
            this.Width = (int)(this.OwnerDocument.Pages.StandardWidth*this.Percent)/100-10;
            this.Height = (int)this.OwnerDocument.DefaultRowHeight;
            return true;
            //return base.RefreshSize();
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_HorizontalLine;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("lineHeight", this.LineHeight.ToString());
                myElement.SetAttribute("percent", this.Percent.ToString());
                //return base.ToXML(myElement);
            }
            return false;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Name = myElement.GetAttribute("name");
                
                //this.LineHeight = uint.Parse(myElement.GetAttribute("lineHeight"));
                //this.Percent = int.Parse(myElement.GetAttribute("percent"));

                if (myElement.HasAttribute("lineHeight")) //add by myc 2014-07-07 添加原因：不存在lineHeight和percent属性时的处理
                {
                    this.LineHeight = uint.Parse(myElement.GetAttribute("lineHeight"));
                }
                if (myElement.HasAttribute("percent"))
                {
                    this.Percent = int.Parse(myElement.GetAttribute("percent"));
                }

                //this.Text = myElement.InnerText;
                return true;
            }
            return false;
        }

        public override string ToEMRString()
        {
            return "_____________________________________________________________________\r\n";
            //return base.ToEMRString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYMensesFormula : ZYElement
    {
        public ZYMensesFormula()
        {
            this.Type = ElementType.MensesFormula;
        }

        public string Last = "经期持续天数";
        public string Period = "周期";

        public string FirstAge = "初潮年龄";
        public string FinallyAgeOrdate = "末次月经日期（或绝经年龄）";

        public bool CanDelete = true;

        public override bool RefreshView()
        {
            this.RefreshSize();
            Rectangle rect = this.Bounds;
            //打印状态不绘制背景
            if (this.OwnerDocument.Info.Printing || this.OwnerDocument.OwnerControl.bolLockingUI)
            {
 
            }
            else
            {
                switch (ZYEditorControl.ElementStyle)
                {
                    case "下划线":
                        this.OwnerDocument.View.DrawLine(ZYEditorControl.ElementBackColor, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case "背景色":
                        this.OwnerDocument.View.FillRectangle(ZYEditorControl.ElementBackColor, rect);
                        break;
                }

            }

            //即使是只读状态，但如果它在激活区域中，视同编辑状态
            if (this.OwnerDocument.OwnerControl.ActiveEditArea != null)
            if (this.OwnerDocument.OwnerControl.ActiveEditArea.Top  <= this.RealTop && this.RealTop + this.Height <= this.OwnerDocument.OwnerControl.ActiveEditArea.End)
            {
                this.OwnerDocument.View.FillRectangle(ZYEditorControl.elementBackColor, this.Bounds);
            }

            //如果是选择打印，则判断是否在范围之内

            if (this.IsNeedPrint() )
            {
                //画之前设置居中对齐
                strFormat.Alignment = StringAlignment.Center;
                /*
                OwnerDocument.View.Graph.DrawString(this.Last, this.Font, Brushes.Black, this.Bounds, strFormat);

                //Rectangle rect = new Rectangle(this.Bounds.Location, this.Bounds.Size);
                rect.Offset(0, this.Height / 2);
                OwnerDocument.View.Graph.DrawLine(Pens.Black, rect.Left, rect.Top, rect.Right, rect.Top);
                OwnerDocument.View.Graph.DrawString(this.Period, this.Font, Brushes.Black, rect, strFormat);
                */


                StringAlignment strAlign = strFormat.LineAlignment;
                strFormat.LineAlignment = StringAlignment.Center; //垂直方向居中

                SizeF size3 = OwnerDocument.View.Graph.MeasureString(this.FirstAge, this.Font, int.MaxValue, strFormat);
                SizeF size4 = OwnerDocument.View.Graph.MeasureString(this.FinallyAgeOrdate, this.Font, int.MaxValue, strFormat);

                OwnerDocument.View.Graph.DrawString(FirstAge, this.Font, Brushes.Black, new RectangleF(this.Bounds.X, this.Bounds.Y, size3.Width, this.Height), strFormat);
                RectangleF rectangle = new RectangleF(this.Bounds.X, this.Bounds.Y, this.Bounds.Width - size3.Width - size4.Width, this.Bounds.Height / 2);
                rectangle.Offset((int)size3.Width, 0);
                OwnerDocument.View.Graph.DrawString(Last, this.Font, Brushes.Black, rectangle, strFormat);
                rectangle.Offset(0, this.Height / 2);
                OwnerDocument.View.Graph.DrawLine(Pens.Black, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
                OwnerDocument.View.Graph.DrawString(Period, this.Font, Brushes.Black, rectangle, strFormat);
                rectangle = new RectangleF(this.Bounds.X, this.Bounds.Y, size4.Width, this.Bounds.Height);
                rectangle.Offset(this.Width - size4.Width, 0);
                OwnerDocument.View.Graph.DrawString(FinallyAgeOrdate, this.Font, Brushes.Black, rectangle, strFormat);

                strFormat.LineAlignment = strAlign;

                //画完后取消居中对齐，否则可能画乱
                strFormat.Alignment = StringAlignment.Near;
            }
                return true;
                //return base.RefreshView();  
        }

        public override bool RefreshSize()
        {
            //计算宽高
            SizeF size1 = OwnerDocument.View.Graph.MeasureString(this.Last, this.Font, int.MaxValue, strFormat);
            SizeF size2 = OwnerDocument.View.Graph.MeasureString(this.Period, this.Font, int.MaxValue, strFormat);

            SizeF size3 = OwnerDocument.View.Graph.MeasureString(this.FirstAge, this.Font, int.MaxValue, strFormat);
            SizeF size4 = OwnerDocument.View.Graph.MeasureString(this.FinallyAgeOrdate, this.Font, int.MaxValue, strFormat);

            this.Width = (int)Math.Max(size1.Width, size2.Width) + 10 + Convert.ToInt32(size3.Width + size4.Width) + 2;
            this.Height = (int)size1.Height * 2;
            return true;
            //return base.RefreshSize();
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_MensesFormula;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myAttributes.ToXML(myElement);
                myElement.SetAttribute("mustclick", this.MustClick.ToString());
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("code", this.Code);
                myElement.SetAttribute("name", this.Name);


                myElement.SetAttribute("last", this.Last);
                myElement.SetAttribute("period", this.Period);

                myElement.SetAttribute("firstage", this.FirstAge);
                myElement.SetAttribute("finallyageordate", this.FinallyAgeOrdate);
                myElement.SetAttribute("candelete", this.CanDelete.ToString());

                //return base.ToXML(myElement);
            }
            return false;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.MustClick = myElement.GetAttribute("mustclick") != "" ? bool.Parse(myElement.GetAttribute("mustclick")) : false;
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Code = myElement.GetAttribute("code");
                this.Name = myElement.GetAttribute("name");
                this.Last = myElement.GetAttribute("last");
                this.Period = myElement.GetAttribute("period");

                this.FirstAge = myElement.GetAttribute("firstage");
                this.FinallyAgeOrdate = myElement.GetAttribute("finallyageordate");
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }

                myAttributes.FromXML(myElement);
                //this.Text = myElement.InnerText;
                //return true;
            }
            //return false;
            return base.FromXML(myElement); //add by myc 2014-03-05 调用元素数据基础加载方法，必须加这个，因为元素创建或删除痕迹是在此方法内部进行判断的。
        }
        public override string ToEMRString()
        {
            return " " + FirstAge.ToString() + " " + Last.ToString() + "/" + Period.ToString() + " " + FinallyAgeOrdate.ToString() + " ";
            //return base.ToEMRString();
        }

    }
}

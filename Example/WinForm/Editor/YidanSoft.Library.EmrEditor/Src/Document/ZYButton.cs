using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYButton : ZYElement //ZYTextBlock   
    {
        public ZYButton()
        {
            this.Type = ElementType.Button;
        }

        string myevent;
        public string Event
        {
            get { return myevent; }
            set { myevent = value; }
        }

        public bool Print = true;

        public override string GetXMLName()
        {
            return ZYTextConst.c_BtnElement;
        }

        /// <summary>
        /// 是否可以删除 Add By wwj 2012-03-29
        /// </summary>
        public bool CanDelete = true;

        public override bool RefreshView()
        {
            this.RefreshSize();
                Rectangle r = this.Bounds;
                Graphics g = this.OwnerDocument.View.Graph;
                int width = YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert(r.Width, GraphicsUnit.Document, GraphicsUnit.Pixel);
                int height = YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert(r.Height, GraphicsUnit.Document, GraphicsUnit.Pixel);
                r.Width = width;
                r.Height = height;

            //只有在设计，编辑状态 并且不打印状态时 才绘制背景 
            if (!this.OwnerDocument.Info.Printing  && (this.OwnerDocument.Info.DocumentModel == DocumentModel.Design || this.OwnerDocument.Info.DocumentModel == DocumentModel.Edit))
            {
                ControlPaint.DrawButton(g, r, ButtonState.Normal);
            }

            //即使是只读状态，但如果它在激活区域中，视同编辑状态
            else if (this.OwnerDocument.OwnerControl.ActiveEditArea != null)
                if (this.OwnerDocument.OwnerControl.ActiveEditArea.Top <= this.RealTop && this.RealTop + this.Height <= this.OwnerDocument.OwnerControl.ActiveEditArea.End)
                {
                    ControlPaint.DrawButton(g, r, ButtonState.Normal);
                }

            //如果是选择打印，则判断是否在范围之内
            if (this.IsNeedPrint() && this.Print
                || !this.OwnerDocument.Info.Printing && ( this.OwnerDocument.Info.DocumentModel == DocumentModel.Design || this.OwnerDocument.Info.DocumentModel == DocumentModel.Edit) //不是打印状态，并且是
                || !this.OwnerDocument.Info.Printing && (this.OwnerDocument.Info.DocumentModel == DocumentModel.Read || this.OwnerDocument.Info.DocumentModel == DocumentModel.Clear) &&  this.Print
                )
            {
                //OwnerDocument.View.Graph.DrawString(this.Name, this.Font, Brushes.Black, this.Bounds, strFormat); //add by myc 2014-06-25 注释原因：不能直接用Rectangle，改为点坐标，因为必须全部包含元素的高度才能绘制完整，避免字符顶部缺失一点点
                OwnerDocument.View.Graph.DrawString(this.Name, this.Font, Brushes.Black, this.Bounds.Left, this.Bounds.Top, strFormat);
            }
            return true;
            //return base.RefreshView();  
        }

        public override bool RefreshSize()
        {
            //计算宽高
            //按钮有名字为空的时候，所以要判断一下
            if (this.Name.Length > 0)
            {
                SizeF size1 = OwnerDocument.View.Graph.MeasureString(this.Name, this.Font, int.MaxValue, strFormat);

                this.Width = (int)size1.Width + 8;
                //this.Height = (int)size1.Height;  //add by myc 2014-06-25 注释原因：不能直接取整，改为上取整，因为必须全部包含元素的高度才能绘制完整，避免字符顶部缺失一点点
                this.Height = (int)Math.Ceiling(size1.Height);
            }
            else
            {
                this.Width = 124;
                this.Height = 66;
            }
            return true;
            //return base.RefreshSize();
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("event", this.Event);
                myElement.SetAttribute("print", this.Print.ToString());
                myElement.SetAttribute("candelete", this.CanDelete.ToString());

                myElement.InnerText = this.Event;
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

                this.Event = myElement.GetAttribute("event");
                if (myElement.HasAttribute("print"))
                {
                    this.Print = bool.Parse(myElement.GetAttribute("print"));
                }
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }
                return true;
            }
            return false;
        }

        public override string ToEMRString()
        {
            return this.Name;
            //return base.ToEMRString();
        }

    }
}

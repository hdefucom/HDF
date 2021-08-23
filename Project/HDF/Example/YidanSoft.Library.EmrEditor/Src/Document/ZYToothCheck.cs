using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 牙齿检查的处理类
    /// add by ywk 2012年11月27日12:03:15 
    /// </summary>
    public class ZYToothCheck : ZYElement
    {
        /// <summary>
        ///构造函数
        /// </summary>
        public ZYToothCheck()
        {
            this.Type = ElementType.ToothCheck;
        }
        #region 标示四个大部位 add by ywk
        public string LeftUp = "左上颚";
        public string LeftDown = "左下颚";
        public string RightUp = "右上颚";
        public string RightDown = "右下颚";
        #endregion

        public bool CanDelete = true;
        /// <summary>
        /// add by ywk 2012年12月13日8:57:53
        /// </summary>
        /// <returns></returns>
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
                        //this.OwnerDocument.View.FillRectangle(Color.LightGray, rect);
                        break;
                }

            }
            //即使是只读状态，但如果它在激活区域中，视同编辑状态
            if (this.OwnerDocument.OwnerControl.ActiveEditArea != null)
            {
                if (this.OwnerDocument.OwnerControl.ActiveEditArea.Top <= this.RealTop && this.RealTop + this.Height <= this.OwnerDocument.OwnerControl.ActiveEditArea.End)
                {
                    this.OwnerDocument.View.FillRectangle(ZYEditorControl.elementBackColor, this.Bounds);
                }
            }
            //如果是选择打印，则判断是否在范围之内
            if (this.IsNeedPrint())
            {
                //画之前设置居中对齐
                //strFormat.Alignment = StringAlignment.Far;
                //StringAlignment strAlign = strFormat.LineAlignment;
                //strFormat.LineAlignment = StringAlignment.Center; //垂直方向居中

                strFormat.Alignment = StringAlignment.Center;
                StringAlignment strAlign = strFormat.LineAlignment;
                strFormat.LineAlignment = StringAlignment.Center; //垂直方向居中


                int LineSize = 5;
                //先算出左上颚的所输文字的长度 
                SizeF sizeleftup = OwnerDocument.View.Graph.MeasureString(this.LeftUp, this.Font, int.MaxValue, strFormat);//左上大小
                SizeF sizeleftdown = OwnerDocument.View.Graph.MeasureString(this.LeftDown, this.Font, int.MaxValue, strFormat);//左下大小
                SizeF sizerightup = OwnerDocument.View.Graph.MeasureString(this.RightUp, this.Font, int.MaxValue, strFormat);//右上尺寸
                SizeF sizerightdown = OwnerDocument.View.Graph.MeasureString(this.RightDown, this.Font, int.MaxValue, strFormat);//右下尺寸
                Rectangle rectback = this.Bounds;//背景所在的矩形

                SizeF tmpsize = new SizeF();
                tmpsize.Width=Math.Max(sizeleftup.Width, sizeleftdown.Width);//竖线的横坐标应该取左上和左下中的最大值 
                tmpsize.Height = Math.Max(sizeleftup.Height, sizeleftdown.Height);//竖线的横坐标应该取左上和左下中的最大值 


                RectangleF rectangle = new RectangleF(this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height / 2);

                //  //再根据左上的宽度确定十字架的竖线的X坐标
                //左上
                OwnerDocument.View.Graph.DrawString
               (LeftUp, this.Font, Brushes.Black, new RectangleF(this.Bounds.X, this.Bounds.Y, sizeleftup.Width, (this.Height - LineSize) / 2), strFormat);
                //竖线
                OwnerDocument.View.Graph.DrawLine
                    (Pens.Black, this.Bounds.X + tmpsize.Width + LineSize, this.Bounds.Y, this.Bounds.X + tmpsize.Width + LineSize, this.Bounds.Y + this.Height);
                //OwnerDocument.View.Graph.DrawLine
                //  (Pens.Black, this.Bounds.Y + size1.Width + LineSize, this.Bounds.Y, D:\YidanSoft.Net\EMRNEW\EMREditor\EMREditor\YidanSoft.Library.EmrEditor\Src\Document\ZYFormatNumber.csthis.Bounds.Y + size1.Width + LineSize, this.Height);
                ///右上
                OwnerDocument.View.Graph.DrawString
                (RightUp, this.Font, Brushes.Black,
                 new RectangleF(this.Bounds.X + tmpsize.Width, this.Bounds.Y, sizerightup.Width + LineSize * 2,
                (this.Height - LineSize) / 2), strFormat);//+ size1.Width + LineSize * 2
                //横线
                OwnerDocument.View.Graph.DrawLine
                    (Pens.Black, this.Bounds.X, this.Bounds.Y +
                    (this.Height - LineSize) / 2, this.Bounds.X + this.Bounds.Width, this.Bounds.Y + (this.Height - LineSize) / 2);
              //  //左下
              //  OwnerDocument.View.Graph.DrawString
              //(LeftDown, this.Font, Brushes.Black, new RectangleF(this.Bounds.X,
              //    this.Bounds.Y + (this.Height - LineSize) / 2, sizeleftup.Width, this.Height / 2), strFormat);//(this.Height - LineSize) / 2 + LineSize


                //左下 add by myc 2014-09-01 上面的绘制左下宽度写错了
                OwnerDocument.View.Graph.DrawString
              (LeftDown, this.Font, Brushes.Black, new RectangleF(this.Bounds.X,
                  this.Bounds.Y + (this.Height - LineSize) / 2, sizeleftdown.Width, this.Height / 2), strFormat);//(this.Height - LineSize) / 2 + LineSize


                //右下
                OwnerDocument.View.Graph.DrawString
              (RightDown, this.Font, Brushes.Black,
               new RectangleF(this.Bounds.X + tmpsize.Width, this.Bounds.Y + (this.Height - LineSize) / 2, sizerightdown.Width + LineSize * 2,
              this.Height / 2), strFormat);



                strFormat.LineAlignment = strAlign;
                //画完后取消居中对齐，否则可能画乱
                strFormat.Alignment = StringAlignment.Near;
            }
            return true;
        }
        /// <summary>
        /// 刷新SIZE
        /// </summary>
        /// <returns></returns>
        public override bool RefreshSize()
        {
            //计算宽高
            SizeF size1 = OwnerDocument.View.Graph.MeasureString(this.LeftUp, this.Font, int.MaxValue, strFormat);
            SizeF size2 = OwnerDocument.View.Graph.MeasureString(this.LeftDown, this.Font, int.MaxValue, strFormat);

            SizeF size3 = OwnerDocument.View.Graph.MeasureString(this.RightUp, this.Font, int.MaxValue, strFormat);
            SizeF size4 = OwnerDocument.View.Graph.MeasureString(this.RightDown, this.Font, int.MaxValue, strFormat);

            //this.Width = (int)Math.Max(size1.Width, size2.Width) + 10 + Convert.ToInt32(size3.Width + size4.Width) + 2;
            this.Width = (int)Math.Max(size1.Width, size2.Width) + Convert.ToInt32(size3.Width + size4.Width);

            //this.Width = 20;
            //this.Width = (int)Math.Max(size1.Width, size3.Width) + Convert.ToInt32(size2.Width + size4.Width) - 12;
            ////this.Width = (int)Math.Max(size1.Width, size3.Width) + Convert.ToInt32(size2.Width+size3.Width);
            //this.Height = (int)size1.Height * 2 + 90;
            this.Height = (int)size1.Height * 2 + 20;
            return true;
            //return base.RefreshSize();
        }
        public override string GetXMLName()
        {
            return ZYTextConst.c_ToothCheck;
        }
        /// <summary>
        /// 将元素转为XML
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myAttributes.ToXML(myElement);
                myElement.SetAttribute("mustclick", this.MustClick.ToString());
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("code", this.Code);
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("leftup", this.LeftUp);
                myElement.SetAttribute("leftdown", this.LeftDown);
                myElement.SetAttribute("rightup", this.RightUp);
                myElement.SetAttribute("rightdown", this.RightDown);
                myElement.SetAttribute("candelete", this.CanDelete.ToString());
            }
            return false;
        }
        /// <summary>
        /// 从XML中将元素的节点值取到
        /// add by ywk 二〇一二年十一月二十七日 15:03:03
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.MustClick = myElement.GetAttribute("mustclick") != "" ? bool.Parse(myElement.GetAttribute("mustclick")) : false;
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Code = myElement.GetAttribute("code");
                this.Name = myElement.GetAttribute("name");
                this.LeftUp = myElement.GetAttribute("leftup");
                this.LeftDown = myElement.GetAttribute("leftdown");
                this.RightUp = myElement.GetAttribute("rightup");
                this.RightDown = myElement.GetAttribute("rightdown");
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }

                myAttributes.FromXML(myElement);//将自定义的属性加到XML节点的属性中去
                //return true;
            }
            //return false;
            return base.FromXML(myElement); //add by myc 2014-03-06 调用元素数据基础加载方法，必须加这个，因为元素创建或删除痕迹是在此方法内部进行判断的。
        }
        public override string ToEMRString()
        {
            return " " + LeftUp.ToString() + " " + LeftDown.ToString() + "/" + RightUp.ToString() + " " + RightDown.ToString() + " ";
        }
    }
}

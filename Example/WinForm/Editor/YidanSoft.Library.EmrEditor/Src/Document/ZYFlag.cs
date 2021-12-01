using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYFlag: ZYElement
    {
        /// <summary>
        /// 是否可以删除定位符 Add By wwj 2013-08-01
        /// </summary>
        public bool CanDelete = true;

        /// <summary>
        /// ZYFlag显示的方向 默认向Left
        /// Left  :  "]"
        /// Right :  "["
        /// </summary>
        public ZYFlagDirection Direction = ZYFlagDirection.Left;

        /// <summary>
        /// 打印的时候是否占据空间
        /// </summary>
        public bool IsHoldSpaceWhenPrint = true;

        /// <summary>
        /// 分组ID,定位符必须是左右一组，里面的内容可用于提取
        /// </summary>
        public string GroupID;

        public ZYFlag()
        {
            this.Type = ElementType.Flag;
        }

        Pen pen = Pens.Blue;

        public override bool RefreshView()
        {
            //this.RefreshSize();
            //画标识符]
            if (!this.OwnerDocument.Info.Printing)
            {
                Point A = new Point(this.RealLeft, this.RealTop);
                Point D = new Point(this.RealLeft, this.RealTop + this.Height);

                #region Modified By wwj 2013-08-01 将原先标示符由小旗子 改为 “]”或 “[”
                //OwnerDocument.View.DrawTriangle(A.X, A.Y, 0, this.Height / 2, this.Width, 0, Color.SkyBlue, Color.SkyBlue);
                //OwnerDocument.View.DrawLine(pen, A.X, A.Y, D.X, D.Y);
                this.Width = (int)myOwnerDocument.View.MeasureString(" ", this.Font).Width;

                int x = this.Width / 2;
                if (Direction == ZYFlagDirection.Left)
                {
                    //OwnerDocument.View.DrawLine(pen, A.X, A.Y, D.X + x, A.Y);
                    //OwnerDocument.View.DrawLine(pen, A.X, D.Y - 2, D.X + x, D.Y - 2);
                    //OwnerDocument.View.DrawLine(pen, D.X + x, A.Y, D.X + x, D.Y - 2);
                    OwnerDocument.View.DrawString("}", this.Font, Color.Blue, A.X - 6, A.Y);
                }
                else
                {
                    //OwnerDocument.View.DrawLine(pen, A.X + x - 1, A.Y, D.X + x * 2, A.Y);
                    //OwnerDocument.View.DrawLine(pen, A.X + x - 1, D.Y - 2, D.X + x * 2, D.Y - 2);
                    //OwnerDocument.View.DrawLine(pen, A.X + x, A.Y, A.X + x, D.Y - 2);
                    OwnerDocument.View.DrawString("{", this.Font, Color.Blue, A.X - 6, A.Y);
                } 
                #endregion
            }
            return true;
        }


        //private static System.Drawing.StringFormat myMeasureFormat = null;
        //public override bool RefreshSize()
        //{
        //    if (myMeasureFormat == null)
        //    {
        //        myMeasureFormat = new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic);
        //        myMeasureFormat.FormatFlags = System.Drawing.StringFormatFlags.FitBlackBox | System.Drawing.StringFormatFlags.MeasureTrailingSpaces;
        //    }

        //    if (myFont == null)
        //        myFont = myOwnerDocument.View._CreateFont
        //            ("宋体",
        //            this.FontSize,
        //            false,
        //            false,
        //            false);
        //    System.Drawing.SizeF CharSize = myOwnerDocument.View.Graph.MeasureString("_", myFont, 10000, myMeasureFormat);

        //    intWidth = (int)CharSize.Width;
        //    intHeight = (int)Math.Ceiling(myFont.GetHeight(myOwnerDocument.View.Graph));

        //    //计算宽高
        //    //this.Width = this.OwnerDocument.PixelToDocumentUnit(11)/2;
        //    //this.Height = this.OwnerDocument.DefaultRowHeight;
        //    return true;
        //}

        public override string GetXMLName()
        {
            return ZYTextConst.c_Flag;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("code", this.Code);

                //Add by wwj 2013-08-01
                myElement.SetAttribute("candelete", this.CanDelete.ToString());

                //Add by wwj 2013-08-01
                myElement.SetAttribute("direction", this.Direction.ToString());

                //Add by wwj 2013-08-01
                myElement.SetAttribute("isholdspacewhenprint", this.IsHoldSpaceWhenPrint.ToString());

                myElement.SetAttribute("groupid", this.GroupID);


                //2019.07.15-hdf
                //添加原因：选中定位符，调整字体大小后，定位符会变化，保存后定位符又还原成原来大小
                //字体属性是保存在myAttributes成员中，定位符的ToXML又没调用父类或myAttributes的ToXML、FromXML，所以无法保存字体属性
                //myAttributes.ToXML(myElement);//2019.8.6-hdf——注释原因：属性列表的一些属性值还是修改之前的值，会把对象的name,candelete等属性值修改掉
                if (myAttributes.Contains(ZYTextConst.c_FontSize))
                {
                    myElement.SetAttribute(ZYTextConst.c_FontSize, myAttributes.GetString(ZYTextConst.c_FontSize));
                }
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
                this.Code = myElement.GetAttribute("code");

                //Add by wwj 2013-08-01
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }

                //Add by wwj 2013-08-01
                if (myElement.HasAttribute("direction"))
                {
                    this.Direction = (ZYFlagDirection)Enum.Parse(typeof(ZYFlagDirection), myElement.GetAttribute("direction"));
                }

                //Add by wwj 2013-08-01
                if (myElement.HasAttribute("isholdspacewhenprint"))
                {
                    this.IsHoldSpaceWhenPrint = bool.Parse(myElement.GetAttribute("isholdspacewhenprint"));
                }

                if (myElement.HasAttribute("groupid"))
                {
                    this.GroupID =myElement.GetAttribute("groupid");
                }

                //2019.07.15-hdf
                //添加原因：选中定位符，调整字体大小后，定位符会变化，保存后定位符又还原成原来大小
                //字体属性是保存在myAttributes成员中，定位符的ToXML又没调用父类或myAttributes的ToXML、FromXML，所以无法保存字体属性
                //this.Attributes.FromXML(myElement);//2019.8.6-hdf——注释原因：属性列表的一些属性值还是修改之前的值，会把对象的name,candelete等属性值修改掉
                if (myElement.HasAttribute(ZYTextConst.c_FontSize))
                {
                    myAttributes.SetValue(ZYTextConst.c_FontSize, myElement.GetAttribute(ZYTextConst.c_FontSize));
                }

                return true;
            }
            return false;
        }

        public override string ToEMRString()
        {
            //return "§";
            return "";
        }
    }
}

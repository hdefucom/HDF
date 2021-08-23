using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYCheckBox : ZYElement
    {
        public ZYCheckBox()
        {
            this.Type = ElementType.CheckBox;
        }

        StringFormat strFormat = StringFormat.GenericTypographic;
        public bool Checked = false;
        public bool CanDelete = true;

        public override string GetXMLName()
        {
            return ZYTextConst.c_CheckBox;
        }

        public override bool RefreshView()
        {
            this.RefreshSize();

            //如果是选择打印，则判断是否在范围之内
            if (this.IsNeedPrint())
            {
                Rectangle r = this.Bounds;

                //OwnerDocument.View.Graph.DrawString("口" + this.Name, this.Font, Brushes.Black, r , strFormat); //add by myc 2014-06-25 注释原因：不能直接用Rectangle，改为点坐标，因为必须全部包含元素的高度才能绘制完整，避免字符顶部缺失一点点
                OwnerDocument.View.Graph.DrawString("口" + this.Name, this.Font, Brushes.Black, r.Left, r.Top, strFormat);
                Graphics g = this.OwnerDocument.View.Graph;

                //r.Width = 15;
                //r.Height = 15;
                //r.Offset(2, 0);

                //add by myc 2014-06-25 添加原因：实现复选框与字体大小同步
                SizeF size1 = OwnerDocument.View.Graph.MeasureString("口", this.Font, int.MaxValue, strFormat);
                int width = YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert((int)size1.Width, GraphicsUnit.Document, GraphicsUnit.Pixel);
                int height = YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert((int)size1.Height, GraphicsUnit.Document, GraphicsUnit.Pixel);
                r.Width = width;
                r.Height = height;

                if (this.Checked)
                {
                    ControlPaint.DrawCheckBox(g, r, ButtonState.Checked);
                }
                else
                {
                    ControlPaint.DrawCheckBox(g, r, ButtonState.Normal);
                }
            }

            return true;
            //return base.RefreshView();  
        }

        public override bool RefreshSize()
        {
            //计算宽高,多余一个字符用来画checkbox

            //SizeF size1 = OwnerDocument.View.Graph.MeasureString(this.Name+"口", this.Font, int.MaxValue, strFormat);
            SizeF size1 = OwnerDocument.View.Graph.MeasureString("口" + this.Name, this.Font, int.MaxValue, strFormat);

            this.Width = (int)size1.Width + 10;
            //this.Height = (int)size1.Height;
            this.Height = (int)Math.Ceiling(size1.Height); //add by myc 2014-06-24 注释原因：不能直接取整，改为上取整，因为必须全部包含元素的高度绘制才能完整
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
                myElement.SetAttribute("code", this.Code);
                myElement.SetAttribute("candelete", this.CanDelete.ToString());
                myElement.InnerText = this.Checked.ToString();
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
                this.Code = myElement.GetAttribute("code");
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }
                this.Checked  = bool.Parse(myElement.InnerText);
                //return true;
            }
            //return false;

            return base.FromXML(myElement); //add by myc 2014-03-05 调用元素数据基础加载方法，必须加这个，因为元素创建或删除痕迹是在此方法内部进行判断的。
        }

        public override string ToEMRString()
        {
            return this.Name; //this.Checked.ToString(); Modified by wwj 2013-02-01 解决复制checkbox时只记录Code值的问题
            //return base.ToEMRString();
        }

    }
}

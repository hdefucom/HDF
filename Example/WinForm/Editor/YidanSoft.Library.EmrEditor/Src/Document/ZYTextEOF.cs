using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYTextEOF : ZYTextElement
    {
        public ZYTextEOF()
        {
            
        }
        public override bool CanBeLineHead()
        {
            return true;
        }
        public override bool isNewLine()
        {
            return true;
        }
        public override bool isNewParagraph()
        {
            return true;
        }

        private System.Drawing.Font myFont = null;
        ///// <summary>
        ///// 字体大小
        ///// </summary>
        //public float FontSize
        //{
        //    get
        //    {
        //        return myAttributes.GetFloat(ZYTextConst.c_FontSize);
        //    }
        //    set
        //    {
        //        myAttributes.SetValue(ZYTextConst.c_FontSize, value);
        //        myFont = null;
        //    }
        //}

        public override string GetXMLName()
        {
            return ZYTextConst.c_PEOF;
        }
        public override string ToEMRString()
        {
            return "\r\n";
        }

        private static System.Drawing.StringFormat myMeasureFormat = null;
        #region add by myc 2014-07-17 注释原因：新版字体属性控制需要
        //public override bool RefreshSize()
        //{
        //    if (this.Parent != null && this == this.Parent.FirstElement)
        //    {
        //        if (myMeasureFormat == null)
        //        {
        //            myMeasureFormat = new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic);
        //            myMeasureFormat.FormatFlags = System.Drawing.StringFormatFlags.FitBlackBox | System.Drawing.StringFormatFlags.MeasureTrailingSpaces;
        //        }

        //        if (myFont == null)
        //            myFont = myOwnerDocument.View._CreateFont
        //                ("宋体",
        //                this.FontSize,
        //                false,
        //                false,
        //                false);
        //        System.Drawing.SizeF CharSize = myOwnerDocument.View.Graph.MeasureString("_", myFont, 10000, myMeasureFormat);

        //        intWidth = (int)CharSize.Width;
        //        intHeight = (int)Math.Ceiling(myFont.GetHeight(myOwnerDocument.View.Graph));
        //    }
        //    else
        //    {
        //        intWidth = myOwnerDocument.PixelToDocumentUnit(11);
        //        intHeight = myOwnerDocument.DefaultRowHeight;
        //        if (this.OwnerLine != null)
        //        {
        //            if (myOwnerDocument.DefaultRowHeight > this.OwnerLine.Height)
        //            {
        //                intHeight = this.OwnerLine.Height;
        //            }
        //        }
        //    }
        //    return true;
        //} 
        #endregion

        public override bool RefreshView()
        {
            if (myOwnerDocument.Info.Printing)
                return true;

            if (!myOwnerDocument.isNeedDraw(this))
                return true;

            RefreshSize();

            //int y = this.RealTop + (this.Height / 2);
            int y = this.RealTop + (this.Height * 3 / 4); //add by myc 2014-07-18 添加原因：回车符底端应该与文档行的底端对齐
            int x = this.RealLeft;


            if (myOwnerDocument.Info.ShowParagraphFlag)
                myOwnerDocument.View.DrawParagraphFlag(
                    x,
                    //回车符应该与前一个字符的底对齐
                    //this.RealTop + (this.Height/2) + myOwnerDocument.PixelToDocumentUnit(this.OwnerLine.LineSpacing),//加行距太难看了，回车符的位置都到字符的下边了
                    y,
                    GraphicsUnitConvert.GetRate(myOwnerDocument.DocumentGraphicsUnit, System.Drawing.GraphicsUnit.Pixel));
            return true;
        }




        #region 新版字体属性控制之回车符记录字体属性，但仅使用字号属性，其他供插入文本字符使用 add by myc 2014-07-17
        /// <summary>
        /// 字体。
        /// </summary>
        public string FontName
        {
            get 
            { 
                return myAttributes.GetString(ZYTextConst.c_FontName); 
            }
            set 
            { 
                myAttributes.SetValue(ZYTextConst.c_FontName, value); 
            }
        }

        /// <summary>
        /// 字号。
        /// </summary>
        public float FontSize
        {
            get
            {
                return myAttributes.GetFloat(ZYTextConst.c_FontSize);
            }
            set 
            { 
                myAttributes.SetValue(ZYTextConst.c_FontSize, value); 
                myFont = null; 
            }
        }

        /// <summary>
        /// 加粗。
        /// </summary>
        public bool FontBold
        {
            get
            { 
                return myAttributes.GetBool(ZYTextConst.c_FontBold); 
            }
            set 
            { 
                myAttributes.SetValue(ZYTextConst.c_FontBold, value);
            }
        }

        /// <summary>
        /// 斜体。
        /// </summary>
        public bool FontItalic
        {
            get 
            { 
                return myAttributes.GetBool(ZYTextConst.c_FontItalic);
            }
            set 
            { 
                myAttributes.SetValue(ZYTextConst.c_FontItalic, value);
            }
        } 

        /// <summary>
        /// 下划线。
        /// </summary>
        public bool FontUnderLine
        {
            get 
            { 
                return myAttributes.GetBool(ZYTextConst.c_FontUnderLine); 
            }
            set
            { 
                myAttributes.SetValue(ZYTextConst.c_FontUnderLine, value); 
            }
        }

        /// <summary>
        /// 文本颜色。
        /// </summary>
        public System.Drawing.Color ForeColor
        {
            get
            {
                return myAttributes.GetColor(ZYTextConst.c_ForeColor);
            }
            set
            {
                myAttributes.SetValue(ZYTextConst.c_ForeColor, value);
            }
        }

        /// <summary>
        /// 上标
        /// </summary>
        public bool Sup
        {
            get { return myAttributes.GetBool(ZYTextConst.c_Sup); }
            set { myAttributes.SetValue(ZYTextConst.c_Sup, value); }
        }
        /// <summary>
        /// 下标
        /// </summary>
        public bool Sub
        {
            get { return myAttributes.GetBool(ZYTextConst.c_Sub); }
            set { myAttributes.SetValue(ZYTextConst.c_Sub, value); }
        }

        public override bool RefreshSize()
        {
            try
            {
                if (myMeasureFormat == null)
                {
                    myMeasureFormat = new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic);
                    myMeasureFormat.FormatFlags = System.Drawing.StringFormatFlags.FitBlackBox | System.Drawing.StringFormatFlags.MeasureTrailingSpaces;
                }

                if (myFont == null)
                {
                    myFont = myOwnerDocument.View._CreateFont
                        ("宋体",
                        this.FontSize,
                        false,
                        false,
                        false);
                }
                else
                {
                    RefreshFont();
                }

                //System.Drawing.SizeF CharSize = myOwnerDocument.View.Graph.MeasureString("_", myFont, 10000, myMeasureFormat);
                System.Drawing.SizeF CharSize = myOwnerDocument.View.Graph.MeasureString("__", myFont, 10000, myMeasureFormat); //add by myc 2014-07-28

                intWidth = (int)CharSize.Width;
                intHeight = (int)Math.Ceiling(myFont.GetHeight(myOwnerDocument.View.Graph));
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 如果回车符的字体属性存在 ，但是发生了改变，需要执行重刷字体属性操作。
        /// </summary>
        private void RefreshFont()
        {
            try
            {
                if (myFont == null) return;
                if (myFont.FontFamily.Name != this.FontName
                    || myFont.Size != this.FontSize
                    || myFont.Bold != this.FontBold
                    || myFont.Italic != this.FontItalic
                    || myFont.Underline != this.FontUnderLine)
                {
                    myFont = myOwnerDocument.View._CreateFont
                        (this.FontName,
                        this.FontSize,
                        this.FontBold,
                        this.FontItalic,
                        this.FontUnderLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 绘制字符使用的字体对象，该对象是从文档对象中的字体列表中获得的。
        /// </summary>
        public System.Drawing.Font Font
        {
            get
            {
                if (myFont == null)
                    myFont = myOwnerDocument.View._CreateFont(this.FontName, this.FontSize, this.FontBold, this.FontItalic, this.FontUnderLine);
                return myFont;
            }
            set
            {
                this.FontName = value.Name;
                this.FontSize = value.Size;
                this.FontBold = value.Bold;
                this.FontItalic = value.Italic;
                this.FontUnderLine = value.Underline;
            }
        }
        #endregion


        #region 回车符字体属性导入导出Xml add by myc 2014-08-14
        /// <summary>
        /// 从XML节点加载回车符格式信息。
        /// </summary>
        /// <param name="myElement">指定的Xml元素节点。</param>
        /// <returns></returns>
        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            try
            {
                if (myElement == null) return false;
                if (myElement.Attributes.Count == 0)
                {
                    myElement.SetAttribute("fontname", "宋体");
                    myElement.SetAttribute("fontsize","10.5");
                }
                return myAttributes.FromXML(myElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 向XML节点保存回车符格式信息。
        /// </summary>
        /// <param name="myElement">指定的Xml元素节点。</param>
        /// <returns></returns>
        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            try
            {
                if (myElement == null) return false;
                return myAttributes.ToXML(myElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}

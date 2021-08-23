using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing.Printing;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
    /// <summary>
    /// 页面设置对象
    /// </summary>
    public class XPageSettings
    {
        private static XPageSettings myInstance = new XPageSettings();
        public static XPageSettings Instance
        {
            get { return myInstance; }
        }
        private XPaperSize myPaperSize = new XPaperSize();//System.Drawing.Printing.PaperKind.Custom, 776, 1068);
        /// <summary>
        /// 纸张大小
        /// </summary>
        public XPaperSize PaperSize
        {
            get { return myPaperSize; }
            set { myPaperSize = value; }
        }
        private System.Drawing.Printing.Margins myMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
        /// <summary>
        /// 页边距
        /// </summary>
        public System.Drawing.Printing.Margins Margins
        {
            get { return myMargins; }
            set { myMargins = value; }
        }
        private bool bolLandscape = false;
        /// <summary>
        /// 横向打印标记
        /// </summary>
        public bool Landscape
        {
            get { return bolLandscape; }
            set { bolLandscape = value; }
        }

        #region 页眉、页脚高度设置 Add by wwj 2012-02-16

        private int headerHeight;
        /// <summary>
        /// 页眉高度
        /// </summary>
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
        }

        private int footerHeight;
        /// <summary>
        /// 页脚高度
        /// </summary>
        public int FooterHeight
        {
            get { return footerHeight; }
            set { footerHeight = value; }
        }

        #endregion

        public XPageSettings Clone()
        {
            XPageSettings ps = new XPageSettings();
            ps.myPaperSize = new XPaperSize(myPaperSize.Kind, myPaperSize.Width, myPaperSize.Height);
            ps.myMargins = new System.Drawing.Printing.Margins(myMargins.Left, myMargins.Right, myMargins.Top, myMargins.Bottom);
            ps.bolLandscape = this.bolLandscape;

            return ps;
        }
        /// <summary>
        /// 设置或返回标准的页面设置对象
        /// </summary>
        public System.Drawing.Printing.PageSettings StdPageSettings
        {
            get
            {
                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                if (myPaperSize.Kind == System.Drawing.Printing.PaperKind.Custom)
                {
                    //纵向打印
                    //if (this.bolLandscape == false)
                    //{
                        ps.PaperSize = new System.Drawing.Printing.PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
                    //}
                    //    //横向打印
                    //else
                    //{
                    //    //mfb ps.PaperSize = new System.Drawing.Printing.PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
                    //    ps.PaperSize = new System.Drawing.Printing.PaperSize("Custom", myPaperSize.Height, myPaperSize.Width);
                    //}
                }
                else
                {
                    bool bolSet = false;
                    System.Drawing.Printing.PrinterSettings pst = new System.Drawing.Printing.PrinterSettings();
                    foreach (System.Drawing.Printing.PaperSize size in pst.PaperSizes)
                    {
                        if (size.Kind == myPaperSize.Kind)
                        {
                            ps.PaperSize = size;
                            bolSet = true;
                            break;
                        }
                    }
                    if (bolSet == false)
                    {
                        //if (this.bolLandscape == false)
                        //{
                            ps.PaperSize = new System.Drawing.Printing.PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
                        //}
                        //else
                        //{
                        //    //mfb ps.PaperSize = new System.Drawing.Printing.PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
                        //    ps.PaperSize = new System.Drawing.Printing.PaperSize("Custom", myPaperSize.Height, myPaperSize.Width);
                        //}
                    }
                }
                ps.Margins = this.myMargins;
                ps.Landscape = this.bolLandscape;

                return ps;
            }
            set
            {
                if (value != null)
                {
                    this.myMargins = value.Margins;
                    this.bolLandscape = value.Landscape;
                    this.myPaperSize = new XPaperSize(value.PaperSize);
                }
            }
        }

        public void ToXML(System.Xml.XmlElement myElement)
        {
            //page
            XmlElement page = myElement.OwnerDocument.CreateElement("page");
            page.SetAttribute("kind",this. PaperSize.Kind.ToString());
            page.SetAttribute("width", PaperSize.Width.ToString());
            page.SetAttribute("height", PaperSize.Height.ToString());
            myElement.AppendChild(page);
            //margins
            XmlElement margins = myElement.OwnerDocument.CreateElement("margins");
            margins.SetAttribute("left", Margins.Left.ToString());
            margins.SetAttribute("top", Margins.Top.ToString());
            margins.SetAttribute("right", Margins.Right.ToString());
            margins.SetAttribute("bottom", Margins.Bottom.ToString());
            myElement.AppendChild(margins);
            //纵横
            XmlElement landscape = myElement.OwnerDocument.CreateElement("landscape");
            landscape.SetAttribute("value", Landscape.ToString());
            myElement.AppendChild(landscape);
        }

        public void FromXml(System.Xml.XmlElement myElement)
        {
            XmlElement ele = (XmlElement)myElement.SelectSingleNode("page");
            //XPageSettings ps = new XPageSettings();
            
            this.PaperSize.Kind = (PaperKind)Enum.Parse(typeof(PaperKind), ele.GetAttribute("kind"));
            
            if (this.PaperSize.Kind == PaperKind.Custom)
            {
                this.PaperSize.Width = int.Parse(ele.GetAttribute("width"));
                this.PaperSize.Height = int.Parse(ele.GetAttribute("height"));
            }

        }
    }//public class XPageSettings
}

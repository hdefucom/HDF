using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using YidanSoft.Library.EmrEditor.Src.Document;
using YiDanCommon.YiDanService; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

namespace YidanSoft.Library.EmrEditor.Src.Print
{
    /// <summary>
    /// 打印页集合对象
    /// </summary>
    [Serializable]
    public class PrintPageCollection : System.Collections.CollectionBase
    {
        private int intTop = 0;
        private int intMinPageHeight = 100;

        private System.Drawing.Printing.PageSettings myPageSettings = new System.Drawing.Printing.PageSettings();

        
        private int intTopMargin = 30;
        private int intRightMargin = 20;
        private int intBottomMargin = 40;
        private int intLeftMargin = 20;

        private int intPaperWidth = 400;
        private int intPaperHeight = 400;

        /// <summary>
        /// 标准纸张的大小,自定义设置
        /// </summary>
        private System.Drawing.Printing.PaperKind intPaperKind = System.Drawing.Printing.PaperKind.B5;
            //System.Drawing.Printing.PaperKind.Custom;

        private bool bolLanscape = false;

        
        //		public void Reset()
        //		{
        //			using( Windows32.DeviceContexts dc = Windows32.DeviceContexts.CreateDisplayDC())
        //			{
        //				using( System.Drawing.Graphics g = dc.CreateGraphics())
        //				{
        //					Reset( g );
        //				}
        //			}
        //		}
        //		public void Reset( System.Drawing.Graphics g )
        //		{
        ////			intLeftMargin	= (int)( myPageSettings.Margins.Left	/ 100.0 * g.DpiX );
        ////			intTopMargin	= (int)( myPageSettings.Margins.Top		/ 100.0 * g.DpiX );
        ////			intRightMargin	= (int)( myPageSettings.Margins.Right   / 100.0 * g.DpiX );
        ////			intBottomMargin = (int)( myPageSettings.Margins.Bottom	/ 100.0 * g.DpiX );
        ////			this.intPaperWidth  = (int)( (double)827   / 100.0 * g.DpiX );
        ////			this.intPaperHeight = (int)( (double)1169  / 100.0 * g.DpiY );
        //			//this.intPaperWidth  = (int)( (double)myPageSettings.PaperSize.Width   / 100.0 * g.DpiX );
        //			//this.intPaperHeight = (int)( (double)myPageSettings.PaperSize.Height  / 100.0 * g.DpiY );
        //		}

        /// <summary>
        /// 自定义绘制页眉页脚
        /// </summary>
        protected bool bolCustomDrawHeadFooter = false;
        /// <summary>
        /// 自定义绘制页眉页脚
        /// </summary>
        public bool CustomDrawHeadFooter
        {
            get { return bolCustomDrawHeadFooter; }
            set { bolCustomDrawHeadFooter = value; }
        }

        private bool bolCustomPageSize = false;
        /// <summary>
        /// 是否自定义页面大小设置
        /// </summary>
        public bool CustomPageSize
        {
            get
            {
                return (bolCustomPageSize == true  || System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count == 0 || myPageSettings == null);
            }
            set { bolCustomPageSize = value; }
        }

        public PrintPageCollection()
        {
            this.PageSettings = new XPageSettings();
            ////myPageSettings.Landscape = true;
            //intPaperWidth = 400;
            //intPaperHeight = 400;
            //intLeftMargin = 30;
            //intTopMargin = 30;
            //intRightMargin = 30;
            //intBottomMargin = 30;
            ////myPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4" , 100 , 100 ) ;
            //this.UpdatePageSettings();
        }
        public System.Drawing.Rectangle PageBounds
        {
            get
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                    this.intLeftMargin,
                    this.intTopMargin,
                    this.intPaperWidth - this.intLeftMargin - this.intRightMargin,
                    this.intPaperHeight - this.intTopMargin - this.intBottomMargin);
                return rect;
            }
        }

        //private const double SizeRate = 1.0/3.0;//100.0 / 96 ;

        public XPaperSize PaperSize
        {
            get
            {
                XPaperSize size = null;
                if (this.intPaperKind != System.Drawing.Printing.PaperKind.Custom)
                {
                    size = XPaperSizeCollection.StdInstance[this.intPaperKind];
                    if (size != null)
                        return size;
                }
                double rate = XPaperSize.GetRate(this.intGraphicsUnit);

                size = new XPaperSize();
                size.Kind = this.intPaperKind;
                if (this.bolLanscape == false)
                {
                    size.Width = (int)(this.intPaperWidth * rate);
                    size.Height = (int)(this.intPaperHeight * rate);
                }
                else
                {
                    size.Width = (int)(this.intPaperHeight * rate);
                    size.Height = (int)(this.intPaperWidth * rate);
                }
                return size;
            }
            set
            {
                this.intPaperKind = value.Kind;
                XPaperSize size = null;
                if (value.Kind != System.Drawing.Printing.PaperKind.Custom)
                    size = XPaperSizeCollection.StdInstance[value.Kind];
                if (size == null)
                    size = value;
                double rate = XPaperSize.GetRate(this.intGraphicsUnit);
                if (this.bolLanscape == false)
                {
                    this.intPaperWidth = (int)(size.Width / rate);
                    this.intPaperHeight = (int)(size.Height / rate);
                }
                else
                {
                    this.intPaperWidth = (int)(size.Height / rate);
                    this.intPaperHeight = (int)(size.Width / rate);
                }
            }
        }
        /// <summary>
        /// 页面设置
        /// </summary>
        public XPageSettings PageSettings
        {
            get
            {
                //由于这里是新new了一个对象，在以后设置值时，已经不是原来的对象了，必须注意
                XPageSettings ps = new XPageSettings();
                double rate = XPaperSize.GetRate(this.intGraphicsUnit);
                ps.Margins = new System.Drawing.Printing.Margins(
                    (int)(this.intLeftMargin * rate),
                    (int)(this.intRightMargin * rate),
                    (int)(this.intTopMargin * rate),
                    (int)(this.intBottomMargin * rate));

                 // xll  删除查询医院sql语句
                 if (YD_SqlService.GetHospitalName().Contains("九江"))
                 {
                     ps.Margins = new System.Drawing.Printing.Margins(39,39,78,59);
                 }
               
                ps.Landscape = this.bolLanscape;
                ps.PaperSize = this.PaperSize;

                return ps;
            }
            set
            {
                double rate = XPaperSize.GetRate(this.intGraphicsUnit);

                this.intPaperKind = value.PaperSize.Kind;
                this.intLeftMargin = (int)(value.Margins.Left / rate);
                this.intTopMargin = (int)(value.Margins.Top / rate);
                this.intRightMargin = (int)(value.Margins.Right / rate);
                this.intBottomMargin = (int)(value.Margins.Bottom / rate);
                this.bolLanscape = value.Landscape;
                this.PaperSize = value.PaperSize;
            }
        }

        protected System.Drawing.Printing.PrinterSettings myPrinterSettings
            = new System.Drawing.Printing.PrinterSettings();
        /// <summary>
        /// 打印机设置
        /// </summary>
        public System.Drawing.Printing.PrinterSettings PrinterSettings
        {
            get { return myPrinterSettings; }
            set { myPrinterSettings = value; }
        }
        private System.Drawing.GraphicsUnit intGraphicsUnit
            = System.Drawing.GraphicsUnit.Document;
        /// <summary>
        /// 度量单位
        /// </summary>
        public System.Drawing.GraphicsUnit GraphicsUnit
        {
            get { return intGraphicsUnit; }
            set { intGraphicsUnit = value; }
        }
        /// <summary>
        /// 纸张宽度
         /// </summary>
        public int PaperWidth
        {
            get
            {  
                return intPaperWidth;
            }
            set
            {
                intPaperWidth = value;
            }
        }

        /// <summary>
        /// 纸张高度
        /// </summary>
        public int PaperHeight
        {
            get { return intPaperHeight; }
            set { intPaperHeight = value; }
        }

        /// <summary>
        /// 左页边距
        /// </summary>
        public int LeftMargin
        {
            get { return intLeftMargin; }
            set { intLeftMargin = value; }
        }
        /// <summary>
        /// 顶页边距
        /// </summary>
        public int TopMargin
        {
            get { return intTopMargin; }
            set { intTopMargin = value; }
        }
        /// <summary>
        /// 右页边距
        /// </summary>
        public int RightMargin
        {
            get { return intRightMargin; }
            set { intRightMargin = value; }
        }
        /// <summary>
        /// 底页边距
        /// </summary>
        public int BottomMargin
        {
            get { return intBottomMargin; }
            set { intBottomMargin = value; }
        }

        /// <summary>
        /// 最小页高
        /// </summary>
        public int MinPageHeight
        {
            get { return intMinPageHeight; }
            set { intMinPageHeight = value; }
        }
        /// <summary>
        /// 纸张类型
        /// </summary>
        public System.Drawing.Printing.PaperKind PaperKind
        {
            get { return intPaperKind; }
            set
            {
                intPaperKind = value;
                if (value != System.Drawing.Printing.PaperKind.Custom)
                {
                    XPaperSize size = XPaperSizeCollection.StdInstance[value];
                    if (size != null)
                    {
                        this.PaperSize = size;
                    }
                }
            }
        }
        /// <summary>
        /// 是否横向打印
        /// </summary>
        public bool Landscape
        {
            get { return this.bolLanscape; }
            set { this.bolLanscape = value; }
        }
        /// <summary>
        /// 标准显示宽
        /// </summary>
        public int StandardWidth
        {
            get 
            { 
                int width =  intPaperWidth - intLeftMargin - intRightMargin; 
                if(width < 0)
                    width =0;
                return width;
            }
        }

        /// <summary>
        /// 标准显示高
        /// </summary>
        public int StandardHeight
        {
            get
            {
                //int height = intPaperHeight - intTopMargin - intBottomMargin - intHeadHeight - intFooterHeight; //add by myc 2014-07-08 注释原因：新版页眉二期改版需要，标准显示高应该改为纸张高度减去上下页边距
                int height = intPaperHeight - intTopMargin - intBottomMargin; //add by myc 2014-07-08 添加原因：新版页眉二期改版需要，标准显示高应该改为纸张高度减去上下页边距
                if (height < 0)
                    height = 0;
                return height;
            }
        }

        /// <summary>
        /// 页眉高度
        /// </summary>
        protected int intHeadHeight = 0;
        /// <summary>
        /// 页眉高度
        /// </summary>
        public int HeadHeight
        {
            get { return intHeadHeight; }
            set { intHeadHeight = value; }
        }
        /// <summary>
        /// 页脚高度
        /// </summary>
        protected int intFooterHeight = 0;
        /// <summary>
        /// 页脚高度
        /// </summary>
        public int FooterHeight
        {
            get { return intFooterHeight; }
            set { intFooterHeight = value; }
        }
        /// <summary>
        /// 对象的顶端位置
        /// </summary>
        public int Top
        {
            get { return intTop; }
            set { intTop = value; }
        }
        /// <summary>
        /// 文档高度
        /// </summary>
        protected int intDocumentHeight = 0;
        /// <summary>
        /// 文档高度
        /// </summary>
        public int DocumentHeight
        {
            get { return intDocumentHeight; }
            set { intDocumentHeight = value; }
        }
        public bool ContainsTop(int vTop)
        {
            int iCount = intTop;
            foreach (PrintPage page in this)
            {
                iCount = iCount + page.Height;
                if (iCount > vTop)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获得从0开始的序号
        /// </summary>
        /// <param name="myPage"></param>
        /// <returns></returns>
        public int IndexOf(PrintPage myPage)
        {
            return this.InnerList.IndexOf(myPage);
        }

        /// <summary>
        /// 获得第一页
        /// </summary>
        public PrintPage FirstPage
        {
            get
            {
                if (this.Count > 0)
                    return this[0];
                else
                    return null;
            }
        }
        /// <summary>
        /// 获得最后一页
        /// </summary>
        public PrintPage LastPage
        {
            get
            {
                if (this.Count > 0)
                    return this[this.Count - 1];
                else
                    return null;
            }
        }


        
        
        
        /// <summary>
        /// 创建一个新页
        /// </summary>
        /// <returns></returns>
        public PrintPage NewPage()
        {
            #region add by myc 2014-07-04 添加原因：新版页眉二期改版之增加文档页时更新页眉区域根元素列表
            //OwnerDocument.RefreshLineForHeaderOrFooter(this.Count, OwnerDocument.RootDocumentElementsInHeader, 0);
            ////修正页眉高度，供建立页眉坐标系使用
            //if (OwnerDocument.RootDocumentElementsInHeader.Count > 0)
            //{
            //    //this.HeadHeight = (OwnerDocument.RootDocumentElementsInHeader[this.Count] as ZYTextContainer).Height;
            //}
            //#endregion

            //#region add by myc 2014-07-07 添加原因：新版页脚改版之增加文档页时更新页脚区域根元素列表
            //OwnerDocument.RefreshLineForHeaderOrFooter(this.Count, OwnerDocument.RootDocumentElementsInFooter, 2);
            ////修正页脚高度，供建立页脚坐标系使用
            //if (OwnerDocument.RootDocumentElementsInFooter.Count > 0)
            //{
            //    //this.FooterHeight = (OwnerDocument.RootDocumentElementsInFooter[this.Count] as ZYTextContainer).Height;
            //}
            #endregion
            
            PrintPage NewPage = new PrintPage();

            //add by myc 2014-07-08 注释原因：新版页眉二期改版（新版页脚）需要——>于 2014-07-25 修改实现页眉、正文和页脚统一管理
            //NewPage.HeaderHeight = OwnerDocument.RefreshLine(this.Count, OwnerDocument.RootDocumentElementsInHeader, 0);
            //NewPage.FooterHeight = OwnerDocument.RefreshLine(this.Count, OwnerDocument.RootDocumentElementsInFooter, 2);
            
            NewPage.FooterHeight = OwnerDocument.RefreshLineInFooter(this.Count);
            this.OwnerDocument.FooterHeightInYiChan = NewPage.FooterHeight; 
            NewPage.HeaderHeight = OwnerDocument.RefreshLineInHeader(this.Count);

            //myItems.Add( NewPage );
            NewPage.OwnerPages = this;
            //NewPage.Height = this.StandardHeight; //add by myc 2014-07-08 注释原因：新版页眉二期改版（新版页脚）需要
            NewPage.Width = this.StandardWidth;

            NewPage.Height = this.StandardHeight - NewPage.HeaderHeight - NewPage.FooterHeight; //add by myc 2014-07-08 添加原因：新版页眉二期改版（新版页脚）需要
            
            return NewPage;
        }

        /// <summary>
        /// 添加页对象
        /// </summary>
        /// <param name="myPage"></param>
        public void Add(PrintPage myPage)
        {
            if (!this.InnerList.Contains(myPage))
                this.InnerList.Add(myPage);
        }
        /// <summary>
        /// 删除指定页
        /// </summary>
        /// <param name="myPage"></param>
        public void Remove(PrintPage myPage)
        {
            this.InnerList.Remove(myPage);
        }

        /// <summary>
        /// 判断是否存在指定的页对象
        /// </summary>
        /// <param name="page">页对象</param>
        /// <returns>是否存在页对象</returns>
        public bool Contains(PrintPage page)
        {
            return this.List.Contains(page);
        }
        /// <summary>
        /// 获得最大的页宽
        /// </summary>
        /// <returns></returns>
        public int GetPageMaxWidth()
        {
            int MaxWidth = 0;
            foreach (PrintPage myPage in this)
            {
                if (myPage.Width > MaxWidth)
                    MaxWidth = myPage.Width;
            }
            return MaxWidth + intLeftMargin + intRightMargin;
        }

        /// <summary>
        /// 所有页面的高度
        /// </summary>
        public int Height
        {
            get
            {
                int intHeight = 0;
                foreach (PrintPage myPage in this)
                    intHeight += myPage.Height;
                return intHeight;
            }
        }
        /// <summary>
        /// 获得所有页身的高度和
        /// </summary>
        public int BodyHeight
        {
            get
            {
                int intHeight = 0;
                foreach (PrintPage myPage in this)
                    intHeight += (myPage.Height - intHeadHeight - intFooterHeight);
                return intHeight;
            }
        }
        /// <summary>
        /// 返回指定的从0开始的序号的页对象
        /// </summary>
        public PrintPage this[int index]
        {
            get { return (PrintPage)this.List[index]; }
        }
        /// <summary>
        /// 返回指定位置处的页面对象
        /// </summary>
        /// <param name="y">指定的垂直位置</param>
        /// <returns>页面对象</returns>
        public PrintPage GetPage(int y)
        {
            foreach (PrintPage page in this)
            {
                if (y >= page.ClientBounds.Top && y <= page.ClientBounds.Bottom)
                    return page;
            }
            return null;
        }



        #region add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        private ZYTextDocument ownerDocument;
        /// <summary>
        /// 当前打印页集合所属文档对象。
        /// </summary>
        public ZYTextDocument OwnerDocument
        {
            get { return ownerDocument; }
            set { ownerDocument = value; }
        } 
        #endregion

    }
}

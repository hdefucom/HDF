using System;
using YidanSoft.Library.EmrEditor.Src.Print;
using System.Drawing.Printing;
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Drawing;
using System.Drawing.Imaging;
//using XDesignerDom ;
//using XDesignerGUI ;

namespace XDesignerPrinting
{
    /// <summary>
    /// 打印报表的打印文档对象
    /// </summary>
    /// <remarks>本打印文档对象专门用于实现报表文档的打印输出</remarks>
    [System.ComponentModel.Browsable(false)]
    public class XPrintDocument : System.Drawing.Printing.PrintDocument
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public XPrintDocument()
        {

        }
        /// <summary>
        /// 供打印的文档对象
        /// </summary>
        protected IPageDocument myDocument = null;
        /// <summary>
        /// 供打印的文档对象
        /// </summary>
        public IPageDocument Document
        {
            get { return myDocument; }
            set { myDocument = value; }
        }
        /// <summary>
        /// 当前打印的页号
        /// </summary>
        protected int intPageIndex = 0;
        /// <summary>
        /// 当前打印的页号
        /// </summary>
        public int PageIndex
        {
            get { return intPageIndex; }
            //set{ intPageIndex = value;}
        }
        /// <summary>
        /// 是否允许选择打印
        /// </summary>
        protected bool bolEnableSelectionPrint = false;


        /// <summary>
        /// 是否允许续打
        /// </summary>
        protected bool bolEnableJumpPrint = false;
        /// <summary>
        /// 是否允许续打
        /// </summary>
        public bool EnableJumpPrint
        {
            get { return bolEnableJumpPrint; }
            set { bolEnableJumpPrint = value; }
        }
        /// <summary>
        /// 续打位置
        /// </summary>
        protected int intJumpPrintPosition = 100;
        /// <summary>
        /// 续打位置
        /// </summary>
        public int JumpPrintPosition
        {
            get { return intJumpPrintPosition; }
            set { intJumpPrintPosition = value; }
        }

        #region 选中区域打印 Add By wwj 2012-04-17  【注意：不同于上面的选择打印】

        /// <summary>
        /// 是否允许选中区域打印
        /// </summary>
        public bool EnableSelectAreaPrint
        {
            get { return bolEnableSelectAreaPrint; }
            set { bolEnableSelectAreaPrint = value; }
        }
        private bool bolEnableSelectAreaPrint = false;

        /// <summary>
        /// 选中区域打印左上角的坐标
        /// </summary>
        public Point SelectAreaPrintLeftTopPoint { get; set; }
        /// <summary>
        /// 选中区域打印右下角的坐标
        /// </summary>
        public Point SelectAreaPrintRightBottomPoint { get; set; }

        /// <summary>
        /// 是否开启第一页不打印页眉和页脚
        /// </summary>
        public bool IsOpenFirstPageHaveNotHeaderFooter
        {
            get { return m_IsOpenFirstPageHaveNotHeaderFooter; }
            set { m_IsOpenFirstPageHaveNotHeaderFooter = value; }
        }
        private bool m_IsOpenFirstPageHaveNotHeaderFooter = true;
        private bool m_IsFirstPageToPrint = true;//是否是打印的第一页
        #endregion

        /// <summary>
        /// 打印指定页
        /// </summary>
        private int intSpecialPageIndex = -1;
        /// <summary>
        /// 打印指定页
        /// </summary>
        /// <param name="vPageIndex">指定页号</param>
        public void PrintSpecialPage(int vPageIndex)
        {
            intSpecialPageIndex = vPageIndex;
            intPageIndex = vPageIndex;
            this.Print();
            intSpecialPageIndex = -1;
        }
        /// <summary>
        /// 打印第一页标记
        /// </summary>
        protected bool bolFirstPage = true;
        /// <summary>
        /// 已重载:开始打印文档
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            if (myDocument != null)
            {
                InitSelectAreaPoint();
                //this.DocumentName = myDocument.Title ;
                bolFirstPage = true;
                intPageIndex = GetStartPageIndex();
                if (intSpecialPageIndex >= 0)
                    intPageIndex = intSpecialPageIndex;
                this.PrinterSettings = myDocument.Pages.PrinterSettings;

            }
            else
                intPageIndex = 0;
            base.OnBeginPrint(e);
        }

        /// <summary>
        /// Add By wwj 2012-04-17 重新排序选中区域位置
        /// </summary>
        private void InitSelectAreaPoint()
        {
            if (bolEnableSelectAreaPrint)
            {
                Point tempPoint = SelectAreaPrintLeftTopPoint;
                if (SelectAreaPrintLeftTopPoint.Y > SelectAreaPrintRightBottomPoint.Y)
                {
                    SelectAreaPrintLeftTopPoint = SelectAreaPrintRightBottomPoint;
                    SelectAreaPrintRightBottomPoint = tempPoint;
                }
            }
        }

        /// <summary>
        /// 获得开始打印的页号
        /// </summary>
        /// <returns></returns>
        private int GetStartPageIndex()
        {
            if (bolEnableJumpPrint && intJumpPrintPosition > 0)
            {
                for (int iCount = 0; iCount < myDocument.Pages.Count; iCount++)
                {
                    if (myDocument.Pages[iCount].Bottom > intJumpPrintPosition)
                        return iCount;
                }
            }
            else if (bolEnableSelectAreaPrint)
            {
                for (int iCount = 0; iCount < myDocument.Pages.Count; iCount++)
                {
                    if (myDocument.Pages[iCount].Bottom > SelectAreaPrintLeftTopPoint.Y)
                        return iCount;
                }
            }
            return 0;
        }

        /// <summary>
        /// 已重载:查询页面设置
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnQueryPageSettings(System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            if (myDocument != null)
            {
                System.Drawing.Printing.PageSettings ps = myDocument.Pages.PageSettings.StdPageSettings;
                foreach (System.Drawing.Printing.PaperSize mySize in this.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperSize.PaperName == mySize.PaperName)
                    {
                        ps.PaperSize = mySize;
                        break;
                    }
                }
                e.PageSettings = ps;
                if (myDocument.Pages.PrinterSettings != null)
                    this.PrinterSettings = myDocument.Pages.PrinterSettings;
            }
            base.OnQueryPageSettings(e);
        }

        /// <summary>
        /// 已重载:打印一页内容
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (myDocument != null)
            {
                if (bolFirstPage)
                {
                    //					myDocument.Printing = true;
                    //					myDocument.Runtime = true;
                }
                bolFirstPage = false;
                if (intSpecialPageIndex >= 0 && intSpecialPageIndex < myDocument.Pages.Count)
                {
                    if (intPageIndex == intSpecialPageIndex)
                    {
                        InnerPrintPage(e);
                        e.HasMorePages = false;
                    }
                }
                else
                    InnerPrintPage(e);
            }
            intPageIndex++;
            base.OnPrintPage(e);
        }

        /// <summary>
        /// 内部的打印一页文档内容
        /// </summary>
        /// <param name="e">事件参数</param>
        protected void InnerPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (intPageIndex >= 0 && intPageIndex <= myDocument.Pages.Count)
            {
                PrintPage myPage = myDocument.Pages[intPageIndex];
                myDocument.PageIndex = intPageIndex;
                System.Drawing.Rectangle ClipRect = new System.Drawing.Rectangle(myPage.Left, myPage.Top, myPage.Width, myPage.Height);

                #region bwy : 续打
                bool bolJumpPrint = false;
                if (this.bolEnableJumpPrint && this.intJumpPrintPosition > 0)
                {
                    if (intJumpPrintPosition > myPage.Top && this.intJumpPrintPosition < myPage.Bottom)
                    {
                        int dy = intJumpPrintPosition - myPage.Top;
                        ClipRect.Offset(0, dy);
                        ClipRect.Height = ClipRect.Height - dy;
                        bolJumpPrint = true;
                    }
                }

                #endregion bwy :

                #region Add By wwj 2012-04-17 选中区域打印
                if (this.bolEnableSelectAreaPrint)
                {
                    if (this.SelectAreaPrintLeftTopPoint.Y > myPage.Top && this.SelectAreaPrintLeftTopPoint.Y < myPage.Bottom)
                    {
                        int dy = this.SelectAreaPrintLeftTopPoint.Y - myPage.Top;
                        ClipRect.Offset(0, dy);
                        int height1 = ClipRect.Height - dy;
                        int height2 = Math.Abs(SelectAreaPrintRightBottomPoint.Y - SelectAreaPrintLeftTopPoint.Y);
                        ClipRect.Height = Math.Min(height1, height2);
                    }
                    else if (this.SelectAreaPrintRightBottomPoint.Y > myPage.Top && this.SelectAreaPrintRightBottomPoint.Y < myPage.Bottom)
                    {
                        ClipRect.Offset(0, 0);
                        int height = this.SelectAreaPrintRightBottomPoint.Y - myPage.Top;
                        ClipRect.Height = height;
                    }
                }
                #endregion

                if (bolJumpPrint)
                {
                    PaintPage(myPage, e.Graphics, ClipRect, false, false); //myc 2014-11-04 正确的续打方式

                    #region add by myc 2014-08-25 添加原因：宜昌中心医院续打页眉页脚问题
                    //if (myDocument.Pages.IndexOf(myPage) == 0)
                    //{
                    //    //PaintPage(myPage, e.Graphics, ClipRect, false, true);
                    //    PaintPage(myPage, e.Graphics, ClipRect, false, (this.Document as ZYTextDocument).PrintFooter); //myc 2014-10-31 第一页默认不打印页眉
                    //}
                    //else
                    //{
                    //    //PaintPage(myPage, e.Graphics, ClipRect, true, true);
                    //    //myc 2014-10-31 第一页之外的文档页根据是否勾选页眉与页脚来决定是否打印
                    //    PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                    //} 
                    #endregion
                }
                //Add By wwj 2012-04-17 选中区域打印, 只打印选中区域所在的页面
                else if (this.bolEnableSelectAreaPrint)
                {
                    if ((this.SelectAreaPrintLeftTopPoint.Y > myPage.Top && this.SelectAreaPrintLeftTopPoint.Y < myPage.Bottom) || 
                        (this.SelectAreaPrintRightBottomPoint.Y > myPage.Top && this.SelectAreaPrintRightBottomPoint.Y < myPage.Bottom))
                    {
                        if (IsOpenFirstPageHaveNotHeaderFooter && m_IsFirstPageToPrint)//选中区域打印时，打印的第一页不打印页眉和页脚 2012-07-06 Add by wwj
                        {
                            bool? isOverPage = CheckSelectAreaIsOverPage();//选中区域是否跨页 Add by 2013-04-27
                            if (isOverPage == false)//如果不跨页，则根据页眉和页脚的设置打印 Add by 2013-04-27
                            {
                                PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                            }
                            else//如果跨页，则不打印第一页的页眉和页脚
                            {
                                PaintPage(myPage, e.Graphics, ClipRect, false, false);
                            }
                            
                            m_IsFirstPageToPrint = false;
                        }
                        else
                        {
                            PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                        }
                    }
                }
                else
                {
                    //PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                    if (this.bolEnableJumpPrint) //当前打印方式为续打 myc 2014-11-04 正确的续打方式
                    {
                        PaintPage(myPage, e.Graphics, ClipRect, true, true);
                    }
                    else
                    {
                        PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                    }
                }

                //Add By wwj 2012-04-17 选中区域打印, 选中区域外的页面不打印
                if (this.bolEnableSelectAreaPrint && this.SelectAreaPrintRightBottomPoint.Y > myPage.Top && this.SelectAreaPrintRightBottomPoint.Y < myPage.Bottom)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = (intPageIndex != myDocument.Pages.Count - 1);
                }
            }
            else
                e.HasMorePages = false;
        }

        /// <summary>
        /// 判断选中区域是否跨页 Add by wwj 2013-04-27
        /// 如果跨页----打印的第一页不打印页眉和页脚 
        /// 如果不跨页--打印的第一页根据设置的情况决定是否显示页眉和页脚 
        /// </summary>
        /// <returns>true: 跨页 false or Null: 不跨页</returns>
        private bool? CheckSelectAreaIsOverPage()
        {
            int pageStartIndex = -1;
            int pageEndIndex = -1;
            PrintPageCollection pageCollection = myDocument.Pages;
            foreach (PrintPage page in pageCollection)
            {
                if (this.SelectAreaPrintLeftTopPoint.Y >= page.Top && this.SelectAreaPrintLeftTopPoint.Y <= page.Bottom)
                {
                    pageStartIndex = page.PageIndex;
                }
                if (this.SelectAreaPrintRightBottomPoint.Y >= page.Top && this.SelectAreaPrintRightBottomPoint.Y <= page.Bottom)
                {
                    pageEndIndex = page.PageIndex;
                }
            }
            if (pageStartIndex != -1 && pageEndIndex != -1 && pageStartIndex == pageEndIndex)
            {
                return false;//选中区域没有跨页
            }
            else if (pageStartIndex != -1 && pageEndIndex != -1 && pageStartIndex != pageEndIndex)
            {
                return true;//选中区域跨页
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 打印指定页面
        /// </summary>
        /// <param name="myPage">页面对象</param>
        /// <param name="g">绘图操作对象</param>
        /// <param name="MainClipRect">主剪切矩形</param>
        /// <param name="PrintHead">是否打印页眉</param>
        /// <param name="PrintTail">是否打印页脚</param>
        protected void PaintPage(
            PrintPage myPage,
            System.Drawing.Graphics g,
            System.Drawing.Rectangle MainClipRect,
            bool DrawHead,
            bool DrawFooter)
        {
            DocumentPageDrawer drawer = new DocumentPageDrawer(myDocument, this.myDocument.Pages);
            drawer.DrawFooter = DrawFooter;
            drawer.DrawHead = DrawHead;
            drawer.DrawPage(myPage, g, MainClipRect, true);
        }
    }//public class DesignPrintDocument : System.Drawing.Printing.PrintDocument
}
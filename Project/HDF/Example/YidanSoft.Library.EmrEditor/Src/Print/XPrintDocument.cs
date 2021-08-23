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
    /// ��ӡ����Ĵ�ӡ�ĵ�����
    /// </summary>
    /// <remarks>����ӡ�ĵ�����ר������ʵ�ֱ����ĵ��Ĵ�ӡ���</remarks>
    [System.ComponentModel.Browsable(false)]
    public class XPrintDocument : System.Drawing.Printing.PrintDocument
    {
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public XPrintDocument()
        {

        }
        /// <summary>
        /// ����ӡ���ĵ�����
        /// </summary>
        protected IPageDocument myDocument = null;
        /// <summary>
        /// ����ӡ���ĵ�����
        /// </summary>
        public IPageDocument Document
        {
            get { return myDocument; }
            set { myDocument = value; }
        }
        /// <summary>
        /// ��ǰ��ӡ��ҳ��
        /// </summary>
        protected int intPageIndex = 0;
        /// <summary>
        /// ��ǰ��ӡ��ҳ��
        /// </summary>
        public int PageIndex
        {
            get { return intPageIndex; }
            //set{ intPageIndex = value;}
        }
        /// <summary>
        /// �Ƿ�����ѡ���ӡ
        /// </summary>
        protected bool bolEnableSelectionPrint = false;


        /// <summary>
        /// �Ƿ���������
        /// </summary>
        protected bool bolEnableJumpPrint = false;
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        public bool EnableJumpPrint
        {
            get { return bolEnableJumpPrint; }
            set { bolEnableJumpPrint = value; }
        }
        /// <summary>
        /// ����λ��
        /// </summary>
        protected int intJumpPrintPosition = 100;
        /// <summary>
        /// ����λ��
        /// </summary>
        public int JumpPrintPosition
        {
            get { return intJumpPrintPosition; }
            set { intJumpPrintPosition = value; }
        }

        #region ѡ�������ӡ Add By wwj 2012-04-17  ��ע�⣺��ͬ�������ѡ���ӡ��

        /// <summary>
        /// �Ƿ�����ѡ�������ӡ
        /// </summary>
        public bool EnableSelectAreaPrint
        {
            get { return bolEnableSelectAreaPrint; }
            set { bolEnableSelectAreaPrint = value; }
        }
        private bool bolEnableSelectAreaPrint = false;

        /// <summary>
        /// ѡ�������ӡ���Ͻǵ�����
        /// </summary>
        public Point SelectAreaPrintLeftTopPoint { get; set; }
        /// <summary>
        /// ѡ�������ӡ���½ǵ�����
        /// </summary>
        public Point SelectAreaPrintRightBottomPoint { get; set; }

        /// <summary>
        /// �Ƿ�����һҳ����ӡҳü��ҳ��
        /// </summary>
        public bool IsOpenFirstPageHaveNotHeaderFooter
        {
            get { return m_IsOpenFirstPageHaveNotHeaderFooter; }
            set { m_IsOpenFirstPageHaveNotHeaderFooter = value; }
        }
        private bool m_IsOpenFirstPageHaveNotHeaderFooter = true;
        private bool m_IsFirstPageToPrint = true;//�Ƿ��Ǵ�ӡ�ĵ�һҳ
        #endregion

        /// <summary>
        /// ��ӡָ��ҳ
        /// </summary>
        private int intSpecialPageIndex = -1;
        /// <summary>
        /// ��ӡָ��ҳ
        /// </summary>
        /// <param name="vPageIndex">ָ��ҳ��</param>
        public void PrintSpecialPage(int vPageIndex)
        {
            intSpecialPageIndex = vPageIndex;
            intPageIndex = vPageIndex;
            this.Print();
            intSpecialPageIndex = -1;
        }
        /// <summary>
        /// ��ӡ��һҳ���
        /// </summary>
        protected bool bolFirstPage = true;
        /// <summary>
        /// ������:��ʼ��ӡ�ĵ�
        /// </summary>
        /// <param name="e">�¼�����</param>
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
        /// Add By wwj 2012-04-17 ��������ѡ������λ��
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
        /// ��ÿ�ʼ��ӡ��ҳ��
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
        /// ������:��ѯҳ������
        /// </summary>
        /// <param name="e">�¼�����</param>
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
        /// ������:��ӡһҳ����
        /// </summary>
        /// <param name="e">�¼�����</param>
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
        /// �ڲ��Ĵ�ӡһҳ�ĵ�����
        /// </summary>
        /// <param name="e">�¼�����</param>
        protected void InnerPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (intPageIndex >= 0 && intPageIndex <= myDocument.Pages.Count)
            {
                PrintPage myPage = myDocument.Pages[intPageIndex];
                myDocument.PageIndex = intPageIndex;
                System.Drawing.Rectangle ClipRect = new System.Drawing.Rectangle(myPage.Left, myPage.Top, myPage.Width, myPage.Height);

                #region bwy : ����
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

                #region Add By wwj 2012-04-17 ѡ�������ӡ
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
                    PaintPage(myPage, e.Graphics, ClipRect, false, false); //myc 2014-11-04 ��ȷ������ʽ

                    #region add by myc 2014-08-25 ���ԭ���˲�����ҽԺ����ҳüҳ������
                    //if (myDocument.Pages.IndexOf(myPage) == 0)
                    //{
                    //    //PaintPage(myPage, e.Graphics, ClipRect, false, true);
                    //    PaintPage(myPage, e.Graphics, ClipRect, false, (this.Document as ZYTextDocument).PrintFooter); //myc 2014-10-31 ��һҳĬ�ϲ���ӡҳü
                    //}
                    //else
                    //{
                    //    //PaintPage(myPage, e.Graphics, ClipRect, true, true);
                    //    //myc 2014-10-31 ��һҳ֮����ĵ�ҳ�����Ƿ�ѡҳü��ҳ���������Ƿ��ӡ
                    //    PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                    //} 
                    #endregion
                }
                //Add By wwj 2012-04-17 ѡ�������ӡ, ֻ��ӡѡ���������ڵ�ҳ��
                else if (this.bolEnableSelectAreaPrint)
                {
                    if ((this.SelectAreaPrintLeftTopPoint.Y > myPage.Top && this.SelectAreaPrintLeftTopPoint.Y < myPage.Bottom) || 
                        (this.SelectAreaPrintRightBottomPoint.Y > myPage.Top && this.SelectAreaPrintRightBottomPoint.Y < myPage.Bottom))
                    {
                        if (IsOpenFirstPageHaveNotHeaderFooter && m_IsFirstPageToPrint)//ѡ�������ӡʱ����ӡ�ĵ�һҳ����ӡҳü��ҳ�� 2012-07-06 Add by wwj
                        {
                            bool? isOverPage = CheckSelectAreaIsOverPage();//ѡ�������Ƿ��ҳ Add by 2013-04-27
                            if (isOverPage == false)//�������ҳ�������ҳü��ҳ�ŵ����ô�ӡ Add by 2013-04-27
                            {
                                PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                            }
                            else//�����ҳ���򲻴�ӡ��һҳ��ҳü��ҳ��
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
                    if (this.bolEnableJumpPrint) //��ǰ��ӡ��ʽΪ���� myc 2014-11-04 ��ȷ������ʽ
                    {
                        PaintPage(myPage, e.Graphics, ClipRect, true, true);
                    }
                    else
                    {
                        PaintPage(myPage, e.Graphics, ClipRect, (this.Document as ZYTextDocument).PrintHeader, (this.Document as ZYTextDocument).PrintFooter);
                    }
                }

                //Add By wwj 2012-04-17 ѡ�������ӡ, ѡ���������ҳ�治��ӡ
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
        /// �ж�ѡ�������Ƿ��ҳ Add by wwj 2013-04-27
        /// �����ҳ----��ӡ�ĵ�һҳ����ӡҳü��ҳ�� 
        /// �������ҳ--��ӡ�ĵ�һҳ�������õ���������Ƿ���ʾҳü��ҳ�� 
        /// </summary>
        /// <returns>true: ��ҳ false or Null: ����ҳ</returns>
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
                return false;//ѡ������û�п�ҳ
            }
            else if (pageStartIndex != -1 && pageEndIndex != -1 && pageStartIndex != pageEndIndex)
            {
                return true;//ѡ�������ҳ
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��ӡָ��ҳ��
        /// </summary>
        /// <param name="myPage">ҳ�����</param>
        /// <param name="g">��ͼ��������</param>
        /// <param name="MainClipRect">�����о���</param>
        /// <param name="PrintHead">�Ƿ��ӡҳü</param>
        /// <param name="PrintTail">�Ƿ��ӡҳ��</param>
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
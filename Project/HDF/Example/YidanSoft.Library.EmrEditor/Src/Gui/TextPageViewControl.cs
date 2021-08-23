using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Win32API;
using YidanSoft.Library.EmrEditor.Src.Print;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Win32;
using YidanSoft.Library.EmrEditor.Src.Document;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 支持文本编辑的分页视图控件
    /// </summary>
    /// 
    [Serializable]
    public class TextPageViewControl : DocumentViewControl //PageScrollableControl
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public TextPageViewControl()
        {


            myCaret = new Win32Caret(this);
            #region bwy : from PageScrollableControl
            base.myTransform = new MultiPageTransform();
            myUpdateLock.BindControl = this;
            #endregion bwy :from PageScrollableControl
        }

        /// <summary>
        /// 是否正在锁定用户界面,不处理任何鼠标和键盘事件
        /// </summary>
        public bool bolLockingUI = false;

        #region bwy : from PageScrollableControl
        protected UpdateLock myUpdateLock = new UpdateLock();


        /// <summary>
        /// 禁止绘制用户界面，一般表示开始更新文档内容
        /// </summary>
        public void BeginUpdate()
        {
            myUpdateLock.BeginUpdate();
        }
        /// <summary>
        /// 允许绘制用户界面，一般表示文档更新完毕，可以绘制文档内容
        /// </summary>
        public void EndUpdate()
        {
            myUpdateLock.EndUpdate();
        }
        /// <summary>
        /// 文档正在更新中,不需要进行绘制用户界面
        /// </summary>
        public bool Updating
        {
            get { return myUpdateLock.Updating; }
        }

        /// <summary>
        /// 页面显示模式
        /// </summary>
        protected PageViewMode intViewMode = PageViewMode.Page;
        /// <summary>
        /// 页面显示模式
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public PageViewMode ViewMode
        {
            get { return intViewMode; }
            set { intViewMode = value; }
        }

        /// <summary>
        /// 当前页对象
        /// </summary>
        protected PrintPage myCurrentPage = null;
        /// <summary>
        /// 当前页对象
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public PrintPage CurrentPage
        {
            get { return myCurrentPage; }
            set
            {
                myCurrentPage = value;
                if (myCurrentPage != null)
                {
                    int y = myCurrentPage.ClientBounds.Top;
                    this.SetAutoScrollPosition(new System.Drawing.Point(this.AutoScrollPosition.X, y));
                }
            }
        }
        /// <summary>
        /// 更新当前页面对象
        /// </summary>
        /// <returns>操作是否改变了当前页面对象</returns>
        protected bool UpdateCurrentPage()
        {
            if (myPages != null)
            {
                MultiPageTransform trans = (MultiPageTransform)this.myTransform;

                PrintPage cpage = null;
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                    -this.AutoScrollPosition.X,
                    -this.AutoScrollPosition.Y,
                    this.ClientSize.Width,
                    this.ClientSize.Height);

                int MaxHeight = 0;
                foreach (PrintPage page in myPages)
                {
                    System.Drawing.Rectangle rect2 = System.Drawing.Rectangle.Intersect(page.ClientBounds, rect);
                    if (!rect2.IsEmpty)
                    {
                        if (MaxHeight < rect2.Height)
                        {
                            cpage = page;
                            MaxHeight = rect2.Height;
                        }
                    }
                }
                if (cpage != myCurrentPage)
                {
                    myCurrentPage = cpage;
                    
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// 当前页改变事件
        /// </summary>
        public event System.EventHandler CurrentPageChanged = null;
        /// <summary>
        /// 当前页改变事件处理
        /// </summary>
        protected virtual void OnCurrentPageChanged()
        {
            if (CurrentPageChanged != null)
                CurrentPageChanged(this, null);
        }
        /// <summary>
        /// 页面集合
        /// </summary>
        protected PrintPageCollection myPages = new PrintPageCollection();
        /// <summary>
        /// 页面集合
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public PrintPageCollection Pages
        {
            get { return myPages; }
            set { myPages = value; }
        }

        private System.Drawing.Printing.Margins myClientMargins = new System.Drawing.Printing.Margins();

        private System.Drawing.Size myClientPageSize = System.Drawing.Size.Empty;

        #region add by myc 2014-07-28 注释原因：重构并优化新版页眉、页脚与正文统一管理例程
        //protected override void RefreshScaleTransform()
        //{
        //    MultiPageTransform trans = (MultiPageTransform)this.myTransform;
        //    intGraphicsUnit = myPages.GraphicsUnit;
        //    trans.Rate = GraphicsUnitConvert.GetRate(intGraphicsUnit, System.Drawing.GraphicsUnit.Pixel);

        //    //float rate = ( float )( 1.0 / this.ClientToViewXRate );
        //    //trans.Pages = myPages ;
        //    //trans.Refresh( rate , this.intPageSpacing );
        //    System.Drawing.Point sp = this.AutoScrollPosition;
        //    trans.ClearSourceOffset();
        //    trans.OffsetSource(sp.X, sp.Y, true);


        //    //			myClientMargins = new System.Drawing.Printing.Margins(
        //    //				( int ) ( myPages.LeftMargin * rate ),
        //    //				( int ) ( myPages.RightMargin * rate ) ,
        //    //				( int ) ( myPages.TopMargin * rate ),
        //    //				( int ) ( myPages.BottomMargin * rate ));
        //    //
        //    //			myClientPageSize = new System.Drawing.Size( 
        //    //				( int) ( myPages.PaperWidth * rate ) ,
        //    //				( int ) ( myPages.PaperHeight * rate ));
        //} 
        #endregion

        //
        //		protected void RefreshScaleTransform1()
        //		{
        //			if( myPages == null )
        //				return ;
        //
        //			MultiPageTransform trans = ( MultiPageTransform ) this.myTransform ;
        //			intGraphicsUnit = myPages.GraphicsUnit ;
        //			trans.Rate = GraphicsUnitConvert.GetRate( intGraphicsUnit , System.Drawing.GraphicsUnit.Pixel );
        //			float rate = ( float )( 1.0 / this.ClientToViewXRate );
        //			trans.Pages = myPages ;
        //			trans.Refresh( rate , this.intPageSpacing );
        //			System.Drawing.Point sp = this.AutoScrollPosition ;
        //			trans.ClearSourceOffset();
        //			trans.OffsetSource( sp.X , sp.Y , true );
        //
        //			myClientMargins = new System.Drawing.Printing.Margins(
        //				( int ) ( myPages.LeftMargin * rate ),
        //				( int ) ( myPages.RightMargin * rate ) ,
        //				( int ) ( myPages.TopMargin * rate ),
        //				( int ) ( myPages.BottomMargin * rate ));
        //
        //			myClientPageSize = new System.Drawing.Size( 
        //				( int) ( myPages.PaperWidth * rate ) ,
        //				( int ) ( myPages.PaperHeight * rate ));
        //		}


        /// <summary>
        /// 分页坐标转换对象
        /// </summary>
        public MultiPageTransform PagesTransform
        {
            get { return (MultiPageTransform)this.myTransform; }
        }
        //
        //		private void UpdateTransform()
        //		{
        //			float rate = ( float )( 1.0 / this.ClientToViewXRate );
        //			MultiPageTransform trans = ( MultiPageTransform ) this.myTransform ;
        //			trans.Pages = myPages ;
        //			trans.Refresh( rate , this.intPageSpacing );
        //		}

        /// <summary>
        /// 根据分页信息更新页面排布
        /// </summary>
        public virtual void UpdatePages()
        {
            if (Common.StackTraceHelper.CheckRecursion())
                return;

            float rate = (float)(1.0 / this.ClientToViewXRate);
            System.Drawing.Size size = new System.Drawing.Size(
                (int)(myPages.PaperWidth * rate),
                (int)(myPages.PaperHeight * rate));

            System.Drawing.Size TotalSize = new System.Drawing.Size(
                size.Width + this.intPageSpacing * 2,
                (size.Height + this.intPageSpacing) * myPages.Count + this.intPageSpacing);

            if (this.AutoScrollMinSize.Equals(TotalSize) == false)
            {
                this.AutoScrollMinSize = TotalSize;
            }


            MultiPageTransform trans = (MultiPageTransform)this.myTransform;
            base.intGraphicsUnit = myPages.GraphicsUnit;

            trans.Pages = myPages;
            trans.Refresh(rate, this.intPageSpacing);

            myClientMargins = new System.Drawing.Printing.Margins(
                (int)(myPages.LeftMargin * rate),
                (int)(myPages.RightMargin * rate),
                (int)(myPages.TopMargin * rate),
                (int)(myPages.BottomMargin * rate));

            myClientPageSize = new System.Drawing.Size(
                (int)(myPages.PaperWidth * rate),
                (int)(myPages.PaperHeight * rate));

            int ClientWidth = this.ClientSize.Width;
            int x = 0;
            if (ClientWidth <= TotalSize.Width)
                x = this.intPageSpacing;
            else
            {
                x = (ClientWidth - TotalSize.Width) / 2 + intPageSpacing;
            }
            trans.OffsetSource(x, 0, false);

            this.RefreshScaleTransform();

            System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;

            for (int iCount = 0; iCount < myPages.Count; iCount++)
            {
                rect.X = x;
                rect.Y = (size.Height + this.intPageSpacing) * iCount + this.intPageSpacing;
                rect.Width = size.Width;
                rect.Height = size.Height;
                myPages[iCount].ClientBounds = rect;
            }
            this.UpdateCurrentPage();
        }


        /// <summary>
        /// 页背景色
        /// </summary>
        protected System.Drawing.Color intPageBackColor = System.Drawing.Color.White;
        /// <summary>
        /// 页背景色
        /// </summary>
        public System.Drawing.Color PageBackColor
        {
            get { return intPageBackColor; }
            set { intPageBackColor = value; }
        }

        ///// <summary>
        ///// 元素景色
        ///// </summary>
        //protected System.Drawing.Color elementBackColor = SystemColors.Control;
        ///// <summary>
        ///// 元素景色
        ///// </summary>
        //public System.Drawing.Color ElementBackColor
        //{
        //    get {
        //        if (this.bolLockingUI)
        //        {
        //            return Color.Transparent;
        //        }
        //        else
        //        {
        //            return elementBackColor;
        //        }
        //    }
        //    set { elementBackColor = value; }
        //}

        /// <summary>
        /// 处于页面视图模式时各个页面间的距离
        /// </summary>
        protected int intPageSpacing = 20;
        /// <summary>
        /// 处于页面视图模式时各个页面间的距离
        /// </summary>
        public int PageSpacing
        {
            get { return intPageSpacing; }
            set { intPageSpacing = value; }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public int PageCount
        {
            get
            {
                if (myPages != null)
                    return myPages.Count;
                else
                    return 0;
            }
        }

        #region 无效矩形区域控制代码群 ****************************************

        /// <summary>
        /// 无效矩形区域
        /// </summary>
        protected RectangleCounter myInvalidateRect = new RectangleCounter();
        /// <summary>
        /// 无效矩形区域
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public RectangleCounter InvalidateRect
        {
            get { return myInvalidateRect; }
        }

        /// <summary>
        /// 追加无效区域
        /// </summary>
        /// <param name="myRect"></param>
        public void AddInvalidateRect(System.Drawing.Rectangle myRect)
        {
            myInvalidateRect.Add(myRect);
        }
        /// <summary>
        /// 追加无效区域
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void AddInvalidateRect(int x, int y, int width, int height)
        {
            myInvalidateRect.Add(x, y, width, height);
        }

        /// <summary>
        /// 更新无效区域
        /// </summary>
        public void UpdateInvalidateRect()
        {
            if (myInvalidateRect.IsEmpty == false)
            {
                this.ViewInvalidate(this.myInvalidateRect.Value);
                this.myInvalidateRect.Clear();
            }
        }
        /// <summary>
        /// 使用视图坐标来声明无效区域,程序准备重新绘制无效文档
        /// </summary>
        /// <param name="ViewBounds">无效区域</param>
        public override void ViewInvalidate(System.Drawing.Rectangle ViewBounds)
        {
            //MultiPageTransform trans = this.myTransform as MultiPageTransform;
            //if (trans == null)
            //{
            //    base.ViewInvalidate(ViewBounds);
            //}
            //else
            //{
            //    foreach (SimpleRectangleTransform item in trans)
            //    {
            //        System.Drawing.Rectangle rect = System.Drawing.Rectangle.Intersect(item.DescRect, ViewBounds);
            //        if (!rect.IsEmpty)
            //        {
            //            rect = item.UnTransformRectangle(rect);
            //            this.Invalidate(rect);
            //        }
            //    }
            //}

            this.Invalidate();
        }

        #endregion

        /// <summary>
        /// 是否采用绝对的坐标转换
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public bool UseAbsTransformPoint
        {
            get { return ((MultiPageTransform)base.myTransform).UseAbsTransformPoint; }
            set { ((MultiPageTransform)base.myTransform).UseAbsTransformPoint = value; }
        }

        /// <summary>
        /// 设置或返回从0开始的当前页号
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public int PageIndex
        {
            get
            {
                if (myCurrentPage == null)
                    return 0;
                else
                    return myCurrentPage.Index;
            }
            set
            {
                MoveToPage(value);
            }
        }



        /// <summary>
        /// 跳到第一页
        /// </summary>
        public void FirstPage()
        {
            MoveToPage(0);
        }
        /// <summary>
        /// 跳到下一页
        /// </summary>
        public void NextPage()
        {
            if (myCurrentPage == null)
                MoveToPage(0);
            else
                MoveToPage(myCurrentPage.Index + 1);
        }
        /// <summary>
        /// 跳到上一页
        /// </summary>
        public void PrePage()
        {
            if (myCurrentPage == null)
                MoveToPage(0);
            else
                MoveToPage(myCurrentPage.Index - 1);
        }
        /// <summary>
        /// 跳到最后一页
        /// </summary>
        public void LastPage()
        {
            if (myPages != null)
                MoveToPage(myPages.Count - 1);
        }
        /// <summary>
        /// 跳到指定页
        /// </summary>
        /// <param name="PageIndex">从0开始的页号</param>
        public void MoveToPage(int PageIndex)
        {
            if (myPages != null && PageIndex >= 0 && PageIndex < myPages.Count)
            {
                PrintPage page = myPages[PageIndex];
                this.SetAutoScrollPosition(new System.Drawing.Point(0, page.ClientBounds.Top));
                myCurrentPage = page;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 页面滚动事件处理
        /// </summary>
        public override void OnScroll()
        {
            //Debug.WriteLine("override void OnScroll()开始");
            base.OnScroll();
            if (myPages != null)
            {
                PrintPage page = this.myCurrentPage;
                if (this.UpdateCurrentPage())
                {
                    using (System.Drawing.Graphics g = this.CreateGraphics())
                    {
                        DrawPageFrame(page, g, false, false);
                        DrawPageFrame(this.CurrentPage, g, true, false);
                    }
                    //					if( page == null)
                    //						rect = cpage.ClientBounds ;
                    //					else
                    //						rect = System.Drawing.Rectangle.Union( cpage.ClientBounds ,  myCurrentPage.ClientBounds );
                    this.OnCurrentPageChanged();
                }
            }
        }
        bool drawtopmargin = false;
        public bool DrawTopMargin
        {
            get { return drawtopmargin; }
            set { drawtopmargin = value; }
        }
        bool drawbottommargin = false;
        public bool DrawBottomMargin
        {
            get { return drawbottommargin; }
            set { drawbottommargin = value; }
        }
        /// <summary>
        /// 绘制页面框架
        /// </summary>
        /// <param name="myPage">页面对象</param>
        /// <param name="g">图形绘制对象</param>
        /// <param name="Focused">该页是否是当前页</param>
        /// <param name="FillBackGround">是否填充背景</param>
        protected void DrawPageFrame(
            PrintPage myPage,
            System.Drawing.Graphics g,
            bool Focused,
            bool FillBackGround)
        {
            if (myPage == null || myPages.Contains(myPage) == false)
                return;

            System.Drawing.Rectangle bounds = myPage.ClientBounds;
            bounds.Offset(this.AutoScrollPosition);

            PageFrameDrawer pfdraw = new PageFrameDrawer();
            pfdraw.BackColor = this.PageBackColor;
 #region bwy : 
            pfdraw.DrawTopMargin = this.drawtopmargin;
            pfdraw.DrawBottomMargin = this.drawbottommargin;
#endregion bwy : 
            pfdraw.DrawPageFrame(
                bounds,
                this.myClientMargins,
                g,
                System.Drawing.Rectangle.Empty,
                Focused,
                FillBackGround);
        }

        protected System.Drawing.Rectangle GetViewClipRectangle(System.Drawing.Rectangle rect)
        {
            double xrate = this.ClientToViewXRate;
            double yrate = this.ClientToViewYRate;
            rect.X = (int)(rect.X * xrate);
            rect.Y = (int)(rect.Y * yrate);
            rect.Width = (int)(rect.Width * xrate);
            rect.Height = (int)(rect.Height * yrate);
            return rect;
        }

        #region 绘制选中区域 Add by wwj 2012-04-17
        /// <summary>
        /// 根据指定坐标的位置获得选中的坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected Point GetSelectAreaPoint(int x, int y)
        {
            MultiPageTransform trans = (MultiPageTransform)this.myTransform;
            if (trans.ContainsSourcePoint(x, y))
            {
                Point p = this.myTransform.TransformPoint(x, y);
                return p;
            }
            return Point.Empty;
        }

        /// <summary>
        /// 绘制选中区域 Add by wwj 2012-04-17
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRectangle"></param>
        /// <param name="leftTopPoint"></param>
        /// <param name="rightBottomPoint"></param>
        /// <param name="FillColor"></param>
        protected void DrawSelectAreaPrint(System.Drawing.Graphics g, System.Drawing.Rectangle clipRectangle,
            Point leftTopPoint, Point rightBottomPoint, System.Drawing.Color FillColor)
        {
            MultiPageTransform trans = (MultiPageTransform)this.myTransform;

            //由于leftTopPoint代表鼠标按下的Location， rightBottomPoint代表鼠标弹起的location
            //所以需要重新调整leftTopPoint与rightBottomPoint的位置
            Point tempPoint = leftTopPoint;
            if (leftTopPoint.Y > rightBottomPoint.Y)
            {
                leftTopPoint = rightBottomPoint;
                rightBottomPoint = tempPoint;
            }
            tempPoint = rightBottomPoint;
            if (leftTopPoint.X > rightBottomPoint.X)
            {
                rightBottomPoint.X = leftTopPoint.X;
                leftTopPoint.X = tempPoint.X;
            }

            leftTopPoint = trans.UnTransformPoint(leftTopPoint);
            rightBottomPoint = trans.UnTransformPoint(rightBottomPoint);

            if (true)//表示整行选中
            {
                leftTopPoint.X = 0;
                rightBottomPoint.X = this.ClientSize.Width;
            }

            if (leftTopPoint != Point.Empty && rightBottomPoint != Point.Empty)
            {
                Rectangle rect = new Rectangle(leftTopPoint.X, leftTopPoint.Y, rightBottomPoint.X - leftTopPoint.X, rightBottomPoint.Y - leftTopPoint.Y);
                g.ResetClip();
                g.PageUnit = System.Drawing.GraphicsUnit.Pixel;
                g.ResetTransform();
                using (System.Drawing.SolidBrush b = new System.Drawing.SolidBrush(FillColor))
                {
                    g.FillRectangle(b, rect);
                }
            }
        }
        #endregion

        /// <summary>
        /// 根据指定坐标的位置获得续打位置
        /// </summary>
        /// <param name="x">X坐标值</param>
        /// <param name="y">Y坐标值</param>
        /// <returns>续打位置</returns>
        protected int GetJumpPrintPosition(int x, int y)
        {
            MultiPageTransform trans = (MultiPageTransform)this.myTransform;
            if (trans.ContainsSourcePoint(x, y))
            {
                int pos = this.myTransform.TransformPoint(x, y).Y;
                if (pos >= 0)
                    return pos;
            }
            return 0;
        }

        /// <summary>
        /// 绘制续打区域
        /// </summary>
        /// <param name="g">图形绘制对象</param>
        /// <param name="ClipRectangle">剪切矩形</param>
        /// <param name="Position">续打位置</param>
        /// <param name="FillColor">填充色</param>
        protected void DrawJumpPrintArea(
            System.Drawing.Graphics g,
            System.Drawing.Rectangle ClipRectangle,
            int Position,
            System.Drawing.Color FillColor)
        {
            MultiPageTransform trans = (MultiPageTransform)this.myTransform;
            int pos = trans.UnTransformY(Position);

            if (pos >= 0)
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                    0,
                    0,
                    this.ClientSize.Width,
                    pos);

                System.Drawing.Rectangle rect2 = ClipRectangle;
                if (ClipRectangle.IsEmpty)
                    rect2 = rect;
                else
                    rect2 = System.Drawing.Rectangle.Intersect(rect, rect2);
                if (!rect2.IsEmpty)
                {
                    g.ResetClip();
                    g.PageUnit = System.Drawing.GraphicsUnit.Pixel;
                    g.ResetTransform();
                    using (System.Drawing.SolidBrush b = new System.Drawing.SolidBrush(FillColor))
                    {
                        g.FillRectangle(b, rect2);
                    }
                    using (System.Drawing.Pen p =
                               new System.Drawing.Pen(System.Drawing.Color.Blue, 2))
                    {
                        g.DrawLine(
                            p,
                            0,
                            rect.Bottom - 1,
                            this.ClientSize.Width,
                            rect.Bottom - 1);
                    }
                }
            }
        }
        /// <summary>
        /// 已重载:绘制文档内容
        /// </summary>
        /// <param name="e">绘制事件参数</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (myUpdateLock.Updating)
                return;
            System.Drawing.Rectangle ClipRect = e.ClipRectangle;
            System.Drawing.Point sp = this.AutoScrollPosition;
            //int ax = - this.AutoScrollPosition.X ;
            //int ay = - this.AutoScrollPosition.Y ;
            
            //MultiPageTransform trans = (MultiPageTransform)this.myTransform; //注释原因：重构并优化新版页眉、页脚与正文统一管理例程 add by myc 2014-07-28
            
            this.RefreshScaleTransform();
            //
            //MultiPageTransform trans = (MultiPageTransform)this.myTransform;
            //    trans.ClearSourceOffset();
            //    trans.OffsetSource( sp.X , sp.Y , true );
            System.Drawing.Graphics g = e.Graphics;
            foreach (PrintPage myPage in myPages)
            {
                //xll 添加&& trans.Count>1条件  否则在新建页眉时会报错 2014-06-18 11:36
                //if (myPages.IndexOf(myPage) == myPages.Count - 1 && trans.Count > 1) //add by myc 2014-06-05 添加原因：表格跨页时，最后一页的坐标转换关系需要更正
                //if (myPages.IndexOf(myPage) == myPages.Count - 1) //add by myc 2014-06-05 添加原因：表格跨页时，最后一页的坐标转换关系需要更正
                
                #region 重构并优化新版页眉、页脚与正文统一管理例程之处理基本表格跨页 add by myc 2014-07-28
                //if (myPages.Count > 1 && myPages.IndexOf(myPage) == myPages.Count - 1)
                //{
                //    //新转换关系——>DescRect与ViewRect是一一对应的
                //    Rectangle newDescRect = new Rectangle(myPage.Left, myPage.Top, myPage.Width, myPage.Height + ZYTextDocument.PageBodyHeightIncrement);
                //    List<SimpleRectangleTransform> bodyTransforms = this.PagesTransform.GetHBFTransforms(1);
                //    //2014-07-29 务必注意SourceRect必须在DescRect之前调整——>不能颠倒顺序
                //    bodyTransforms[bodyTransforms.Count - 1].SourceRect = bodyTransforms[bodyTransforms.Count - 1].UnTransformRectangle(newDescRect);
                //    bodyTransforms[bodyTransforms.Count - 1].DescRect = newDescRect;
                //} 
                #endregion
                
                
                System.Drawing.Rectangle ClientBounds = myPage.ClientBounds;
                //add by myc 测试编辑区域矩形用
                //System.Drawing.Rectangle ClientBounds = new Rectangle(myPage.ClientBounds.Left,myPage.ClientBounds.Top,myPage.ClientBounds.Width,ClipRect.Height-40);
                ClientBounds.Offset(sp);
                if (ClientBounds.IntersectsWith(ClipRect))
                {
                    this.SetPageIndex(myPage.Index);

                    System.Drawing.Drawing2D.GraphicsState state = e.Graphics.Save();
                    e.Graphics.ResetTransform();
                    e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;

                    e.Graphics.ResetClip();

                    PageFrameDrawer pfdraw = new PageFrameDrawer();
                    pfdraw.BackColor = this.PageBackColor;
                    #region bwy :
                    pfdraw.DrawTopMargin = this.drawtopmargin;
                    pfdraw.DrawBottomMargin = this.drawbottommargin;
                    #endregion bwy :
                    pfdraw.DrawPageFrame(
                        ClientBounds,
                        this.myClientMargins,
                        e.Graphics,
                        ClipRect,
                        myPage == this.myCurrentPage,
                        true);

                    e.Graphics.Restore(state);


                    #region add by myc 2014-07-28 注释原因：重构并优化新版页眉、页脚与正文统一管理例程需要
                    //Rectangle rectFooter = new Rectangle();
                    //foreach (SimpleRectangleTransform item in trans)
                    //{
                    //    if (item.Visible && item.Tag == myPage)
                    //    {
                    //        System.Drawing.Rectangle rect = System.Drawing.Rectangle.Intersect(
                    //            e.ClipRectangle,
                    //            item.SourceRect);
                    //        if (!rect.IsEmpty)
                    //        {
                    //            TransformPaint(e, item);

                    //            if (item.Flag2 == 2)
                    //            {
                    //                rectFooter = item.DescRect;
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion




                    #region add by myc 2014-07-28 注释原因：重构并优化新版页眉、页脚与正文统一管理例程需要
                    for (int i = 0; i < 3; i++)
                    {
                        List<SimpleRectangleTransform> currTransforms = this.PagesTransform.GetHBFTransforms(i);
                        foreach (SimpleRectangleTransform item in currTransforms)
                        {
                            if (item.Visible && item.Tag == myPage)
                            {
                                System.Drawing.Rectangle rect = System.Drawing.Rectangle.Intersect(
                                    e.ClipRectangle,
                                    item.SourceRect);
                                if (!rect.IsEmpty)
                                {
                                    TransformPaint(e, item);
                                }
                            }
                        }
                    }
                    #endregion




                    #region 原处理页脚区域代码，这会覆盖下边距线的绘制 由myc注释2014-02-14 14:52
                    ////****************TODO 重新绘制页脚，解决表格延生到下面一页的BUG，此为折中方案，不好！！！！！！ Add by wwj 2012-05-31**************
                    //if (!rectFooter.IsEmpty)
                    //{
                    //    //Modified by wwj 2013-04-17 解决绘制页脚时背景色的问题
                    //    Brush backColorBrush = Brushes.White;
                    //    if (this.PageBackColor.A != 0)
                    //    {
                    //        backColorBrush = new System.Drawing.SolidBrush(this.PageBackColor);
                    //    }

                    //    ZYTextDocument emrDoc = ((ZYEditorControl)this).EMRDoc;
                    //    e.Graphics.FillRectangle(backColorBrush,
                    //        new Rectangle(0 - emrDoc.Pages.LeftMargin + 3,
                    //                        rectFooter.Top - 20,
                    //                        rectFooter.Width + emrDoc.Pages.LeftMargin + emrDoc.Pages.RightMargin - 8,
                    //                        rectFooter.Height + emrDoc.Pages.BottomMargin - 2 + 20));
                    //    ((ZYEditorControl)this).EMRDoc.DrawFooter(e.Graphics, rectFooter);
                    //}
                    ////***************************************************************************************************************************** 
                    #endregion

                }
            }
            base.OnPaint(e);


        }

        /// <summary>
        /// 控件大小发生改变时的处理
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnResize(EventArgs e)
        {
            this.UpdatePages();
            base.OnResize(e);
        }
        /// <summary>
        /// 设置当前页号
        /// </summary>
        /// <param name="index"></param>
        protected virtual void SetPageIndex(int index)
        {
        }
        /// <summary>
        /// 页面显示方式
        /// </summary>

        #endregion bwy :from PageScrollableControl

        #region 键盘操作代码群 ************************************************

        /// <summary>
        /// 获取或设置一个值，该值指示在控件中按 TAB 键时，是否在控件中键入一个 TAB 字符，而不是按选项卡的顺序将焦点移动到下一个控件。
        /// </summary>
        protected bool bolAcceptsTab = true;
        /// <summary>
        /// 获取或设置一个值，该值指示在控件中按 TAB 键时，是否在控件中键入一个 TAB 字符，而不是按选项卡的顺序将焦点移动到下一个控件。
        /// </summary>
        public bool AcceptsTab
        {
            get { return bolAcceptsTab; }
            set { bolAcceptsTab = value; }
        }

        private static System.Windows.Forms.Keys[] myInputKeys =
				{	
					System.Windows.Forms.Keys.Left ,
					System.Windows.Forms.Keys.Up ,
					System.Windows.Forms.Keys.Right ,
					System.Windows.Forms.Keys.Down ,
					System.Windows.Forms.Keys.Tab ,
					System.Windows.Forms.Keys.Enter ,
					System.Windows.Forms.Keys.ShiftKey  ,
					System.Windows.Forms.Keys.Control 
				};
        /// <summary>
        /// 重写键盘字符处理函数,保证控件能处理一些功能键
        /// </summary>
        /// <param name="keyData">按键数据</param>
        /// <returns>控件是否能处理按键数据</returns>
        /// 
 #region bwy : 
        //protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        //{
        //    if (keyData == System.Windows.Forms.Keys.Tab && bolAcceptsTab == false)
        //        return base.IsInputKey(keyData);
        //    for (int iCount = 0; iCount < myInputKeys.Length; iCount++)
        //    {
        //        int iKey = (int)myInputKeys[iCount];
        //        if ((iKey & (int)keyData) == iKey)
        //            return true;
        //    }
        //    return base.IsInputKey(keyData);
        //}
#endregion bwy : 

        #endregion

        #region 光标操作函数群 ************************************************

        /// <summary>
        /// 是否强制显示光标而不管控件是否获得输入焦点
        /// </summary>
        protected bool bolForceShowCaret = true;
        /// <summary>
        /// 是否强制显示光标而不管控件是否获得输入焦点
        /// </summary>
        public bool ForceShowCaret
        {
            get { return bolForceShowCaret; }
            set { bolForceShowCaret = value; }
        }

        /// <summary>
        /// 移动光标时是否自动滚动到光标区域
        /// </summary>
        protected bool bolMoveCaretWithScroll = true;
        /// <summary>
        /// 移动光标时是否自动滚动到光标区域
        /// </summary>
        public bool MoveCaretWithScroll
        {
            get { return bolMoveCaretWithScroll; }
            set { bolMoveCaretWithScroll = value; }
        }
        /// <summary>
        /// 当前是否处于插入模式,若处于插入模式,则光标比较细,否则处于改写模式,光标比较粗
        /// </summary>
        protected bool bolInsertMode = true;
        /// <summary>
        /// 当前是否处于插入模式,若处于插入模式,则光标比较细,否则处于改写模式,光标比较粗
        /// </summary>
        public virtual bool InsertMode
        {
            get { return bolInsertMode; }
            set { bolInsertMode = value; }
        }
        protected bool bolCaretCreated = false; // 光标已经创建标志
        /// <summary>
        /// 默认光标宽度
        /// </summary>
        public static int DefaultCaretWidth = 2;
        /// <summary>
        /// 默认的宽光标的宽度,应用于修改模式中的文本编辑器
        /// </summary>
        public static int DefaultBroadCaretWidth = 6;

        /// <summary>
        /// 光标控制对象
        /// </summary>
        protected Win32Caret myCaret = null;

        /// <summary>
        /// 当前光标位置
        /// </summary>
        public System.Drawing.Rectangle myCaretBounds = System.Drawing.Rectangle.Empty;

        /// <summary>
        /// 已重载:获得焦点,显示光标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (bolCaretCreated && myCaretBounds.IsEmpty == false && this.Focused)
            {
                myCaret.Create(0, myCaretBounds.Width, myCaretBounds.Height);
                myCaret.SetPos(myCaretBounds.X, myCaretBounds.Y);
                myCaret.Show();
            }
            base.OnGotFocus(e);
        }

        /// <summary>
        /// 已重载:失去焦点,隐藏光标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            if (bolCaretCreated)
                myCaret.Hide();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// 移动光标到新的光标区域
        /// </summary>
        /// <param name="vLeft">在视图中光标区域的左端位置</param>
        /// <param name="vTop">在视图中光标区域的顶端位置</param>
        /// <param name="vWidth">光标区域宽度</param>
        /// <param name="vHeight">光标区域高度</param>
        /// <returns>移动光标是否造成滚动</returns>
        public bool MoveCaretTo(int vLeft, int vTop, int vWidth, int vHeight)
        {
            if (this.Updating)
                return false;

            if (ForceShowCaret == false && this.Focused == false)
            {
                if (bolCaretCreated)
                    myCaret.Hide();
                return false;
            }

            int height = GraphicsUnitConvert.Convert(vHeight, this.GraphicsUnit, System.Drawing.GraphicsUnit.Pixel);

            if (vWidth > 0 && vHeight > 0)
            {
                bolCaretCreated = myCaret.Create(0, vWidth, height);
                if (bolCaretCreated)
                {
                    if (bolMoveCaretWithScroll)
                    {
                        //Modified by wwj 2011-11-24 移除自动判断的滚动条的逻辑
                        //this.ScrollToView(vLeft, vTop, vWidth, vHeight);
                    }
                    System.Drawing.Point p = this.ViewPointToClient(vLeft, vTop);

                    #region add by myc 2014-07-03 添加原因：新版页眉二期改版之光标定位——>已被注释 2014-07-24 页眉、正文和页脚统一管理需要
                    //if (ZYTextDocument.CurrentEditingArea == 0)
                    //{
                    //    for (int i = 0; i < ZYTextDocument.HeaderTransforms.Count; i++)
                    //    {
                    //        SimpleRectangleTransform headerTransform = ZYTextDocument.HeaderTransforms[i] as SimpleRectangleTransform;
                    //        //if (headerTransform.DescRect.Top <= vTop && headerTransform.DescRect.Top + headerTransform.DescRect.Height >= vTop + vHeight)
                    //        if(headerTransform.DescRect.Contains(vLeft, vTop))
                    //        {
                    //            p = headerTransform.UnTransformPoint(vLeft, vTop);
                    //            break;
                    //        }
                    //    }
                    //}
                    //else if (ZYTextDocument.CurrentEditingArea == 2) //add by myc 2014-07-07 添加原因：新版页脚之光标定位
                    //{
                    //    for (int i = 0; i < ZYTextDocument.FooterTransforms.Count; i++)
                    //    {
                    //        SimpleRectangleTransform footerTransform = ZYTextDocument.FooterTransforms[i] as SimpleRectangleTransform;
                    //        //if (footerTransform.DescRect.Top <= vTop && footerTransform.DescRect.Top + footerTransform.DescRect.Height >= vTop + vHeight)
                    //        if (footerTransform.DescRect.Contains(vLeft, vTop))
                    //        {
                    //            p = footerTransform.UnTransformPoint(vLeft, vTop);
                    //            break;
                    //        }
                    //    }
                    //}
                    #endregion

                    myCaret.SetPos(p.X, p.Y);
                    myCaret.Show();
                    if (Imm32.isImmOpen(this.Handle.ToInt32()))
                    {
                        Imm32.SetImmHalf(this.Handle.ToInt32()); //add by myc 2014-06-03 中文输入法设置半角状态
                        
                        Imm32.SetImmPos(this.Handle.ToInt32(), p.X, p.Y);
                    }
                    myCaretBounds = new System.Drawing.Rectangle(p.X, p.Y, vWidth, height);
                    if (bolMoveCaretWithScroll)
                    {
                        return true; 


                    }
                }
            }
            return false;
        }


        /// <summary>
        /// 针对文本编辑器的移动光标到指定位置
        /// </summary>
        /// <param name="vLeft">光标的左端区域</param>
        /// <param name="vBottom">光标的底端区域</param>
        /// <param name="vHeight">光标的高度</param>
        /// <returns>移动光标是否造成滚动</returns>
        public bool MoveTextCaretTo(int vLeft, int vBottom, int vHeight)
        {
            return MoveCaretTo(
                vLeft,
                vBottom - vHeight,
                (bolInsertMode ? DefaultCaretWidth : DefaultBroadCaretWidth),
                vHeight);
        }

        /// <summary>
        /// 隐藏光标
        /// </summary>
        public void HideOwnerCaret()
        {
            myCaret.Hide();
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextPageViewControl
            // 
            this.GraphicsUnit = System.Drawing.GraphicsUnit.Document;

            this.Name = "TextPageViewControl";
            this.ResumeLayout(false);

        }






        #region add by myc 2014-07-28 添加原因：重构并优化新版页眉、页脚与正文统一管理例程
        /// <summary>
        /// 滚动编辑器窗口时，对文档页眉、正文和页脚区域内的所有矩形坐标转换关系执行Scroll调整。
        /// </summary>
        protected override void RefreshScaleTransform()
        {
            try
            {
                intGraphicsUnit = myPages.GraphicsUnit;
                this.PagesTransform.Rate = GraphicsUnitConvert.GetRate(intGraphicsUnit, GraphicsUnit.Pixel);
                Point sp = this.AutoScrollPosition;
                this.PagesTransform.ClearSourceOffset();
                this.PagesTransform.OffsetSource(sp.X, sp.Y, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion








    }//public class TextPageViewControl : PageScrollableControl

    public enum PageViewMode
    {
        /// <summary>
        /// 普通方式
        /// </summary>
        Normal,
        /// <summary>
        /// 页面方式
        /// </summary>
        Page,
        /// <summary>
        /// 压缩页面方式
        /// </summary>
        CompressPage
    }
}

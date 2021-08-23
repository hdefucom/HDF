using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Document; //add by myc 2014-07-01 添加原因：新版页眉二期改版需要

namespace YidanSoft.Library.EmrEditor.Src.Print
{
    /// <summary>
    /// ReportPageTransform 的摘要说明。
    /// </summary>
    public class MultiPageTransform : MultiRectangleTransform
    {
        //public MultiPageTransform() //add by myc 2014-07-22 注释原因：新版页眉、正文和页脚统一管理坐标转换关系需要
        //{
        //}

        protected PrintPageCollection myPages = null;
        /// <summary>
        /// 页面集合
        /// </summary>
        public PrintPageCollection Pages
        {
            get { return myPages; }
            set { myPages = value; }
        }

        /// <summary>
        /// 根据页面位置添加矩形区域转换关系
        /// </summary>
        /// <param name="myTransform">转换列表</param>
        /// <param name="ForPrint">是否为打印进行填充</param>
        public void AddPage(PrintPage page, int PageTop, float ZoomRate)
        {
            System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;

            int leftmargin = (int)(myPages.LeftMargin * ZoomRate);
            int topmargin = (int)(myPages.TopMargin * ZoomRate);
            int rightmargin = (int)(myPages.RightMargin * ZoomRate);
            int bottommargin = (int)(myPages.BottomMargin * ZoomRate);
            int pagewidth = (int)(myPages.PaperWidth * ZoomRate);
            int pageheight = (int)(myPages.PaperHeight * ZoomRate);

            int Top = PageTop + topmargin;

            SimpleRectangleTransform item = null;
            //if (myPages.HeadHeight > 0) //add by myc 2014-07-08 注释原因：每一个文档页都应该有自己独立的页眉页脚高度
            if(page.HeaderHeight >= 0) //add by myc 2014-07-15 添加原因：页眉区域元素全部删除时也要维护记录的存在
            {
                item = new SimpleRectangleTransform();
                item.PageIndex = page.Index;
                item.Flag2 = 0;
                item.Tag = page;

                #region add by myc 2014-07-01 添加原因：新版页眉二期改版之所有文档页的页眉区域坐标系连续设置——>2014-07-24 注释原因：已采用页眉、正文和页脚统一管理方案实现
                int currHeaderTop = 0;
                //if (ZYTextDocument.HeaderTransforms.Count > 0)
                //{
                //    currHeaderTop = (ZYTextDocument.HeaderTransforms[ZYTextDocument.HeaderTransforms.Count - 1] as SimpleRectangleTransform).DescRect.Top
                //        + (ZYTextDocument.HeaderTransforms[ZYTextDocument.HeaderTransforms.Count - 1] as SimpleRectangleTransform).DescRect.Height;
                //} 
                if (editingAreaTransforms[0].Count > 0)
                {
                    currHeaderTop = (editingAreaTransforms[0][editingAreaTransforms[0].Count - 1] as SimpleRectangleTransform).DescRect.Top
                        + (editingAreaTransforms[0][editingAreaTransforms[0].Count - 1] as SimpleRectangleTransform).DescRect.Height;
                }
                #endregion

                item.DescRect = new System.Drawing.Rectangle(
                    0,
                    //0,
                    currHeaderTop, //add by myc 2014-07-01 添加原因：新版页眉二期改版需要
                    page.Width,
                    //myPages.HeadHeight
                    //(myPages.OwnerDocument.RootDocumentElementsInHeader[myPages.IndexOf(page)] as ZYDocumentHeader).Height //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    page.HeaderHeight
                    );

                Top = SetSourceRect(item, ZoomRate, leftmargin, Top);

                this.Add(item);

                //ZYTextDocument.HeaderTransforms.Add(item); //add by myc 2014-07-01 添加原因：新版页眉二期改版需要

                this.editingAreaTransforms[0].Add(item); //add by myc 2014-07-23 添加原因：重构并优化新版页眉、页脚与正文统一管理例程需要
            }

            item = new SimpleRectangleTransform();
            item.PageIndex = page.Index;
            item.Flag2 = 1;
            item.Tag = page;


            int currPageHeight = page.Height; //add by myc 2014-07-25 添加原因：增加currPageHeight是为了处理最后一个文档页矩形坐标系空间问题——>针对表格内的单元格拖拽，但是直接这么改又会导致插入Enter换页出现回车符跳跃问题
            if (myPages.IndexOf(page) == myPages.Count - 1)
            {
                currPageHeight = myPages.StandardHeight - page.HeaderHeight - page.FooterHeight;
            }
            item.DescRect = new System.Drawing.Rectangle(
                0,
                page.Top,
                //myPages.IndexOf(page) == 0 ? page.Top : page.Top + 20,
                //page.Top + myPages.OwnerDocument.PageTopIncrement[myPages.IndexOf(page)],
                page.Width,
                page.Height);
                //myPages.IndexOf(page) == myPages.Count - 1 ? page.Height : page.Height + 65);
                //currPageHeight);


            Top = SetSourceRect(item, ZoomRate, leftmargin, Top);

            this.Add(item);

            this.editingAreaTransforms[1].Add(item); //add by myc 2014-07-23 添加原因：重构并优化新版页眉、页脚与正文统一管理例程需要

            //if (myPages.FooterHeight > 0) //add by myc 2014-07-08 注释原因：每一个文档页都应该有自己独立的页眉页脚高度
            if (page.FooterHeight >= 0)  //add by myc 2014-07-15 添加原因：页脚区域元素全部删除时也要维护记录的存在
            {
                item = new SimpleRectangleTransform();
                item.PageIndex = page.Index;
                item.Flag2 = 2;
                item.Tag = page;

                #region add by myc 2014-07-07 添加原因：新版页脚改版之所有文档页的页脚区域坐标系连续设置——>2014-07-24 注释原因：已采用页眉、正文和页脚统一管理方案实现
                int currFooterTop = 0;
                //if (ZYTextDocument.FooterTransforms.Count > 0)
                //{
                //    currFooterTop = (ZYTextDocument.FooterTransforms[ZYTextDocument.FooterTransforms.Count - 1] as SimpleRectangleTransform).DescRect.Top
                //        + (ZYTextDocument.FooterTransforms[ZYTextDocument.FooterTransforms.Count - 1] as SimpleRectangleTransform).DescRect.Height;
                //}
                if (editingAreaTransforms[2].Count > 0)
                {
                    currFooterTop = (editingAreaTransforms[2][editingAreaTransforms[2].Count - 1] as SimpleRectangleTransform).DescRect.Top
                        + (editingAreaTransforms[2][editingAreaTransforms[2].Count - 1] as SimpleRectangleTransform).DescRect.Height;
                }
                #endregion



                item.DescRect = new System.Drawing.Rectangle(
                    0,
                    //myPages.DocumentHeight - myPages.FooterHeight, //add by myc 2014-06-26 注释原因：页眉目标矩形区域与页脚目标矩形区域都改为(0,0)坐标开始，便于后期页眉页脚区域内元素位置准确计算
                    //0,
                    currFooterTop, //add by myc 2014-07-07 添加原因：新版页脚改版需要
                    page.Width,
                    //myPages.FooterHeight
                    //(myPages.OwnerDocument.RootDocumentElementsInFooter[myPages.IndexOf(page)] as ZYDocumentFooter).Height //add by myc 2014-07-07 添加原因：新版页脚改版需要
                    page.FooterHeight
                    );
                SetSourceRect(item, ZoomRate, leftmargin, Top);
                rect = item.SourceRect;

                Top = PageTop + pageheight - bottommargin - rect.Height;
                item.SourceRect = new System.Drawing.Rectangle(leftmargin, Top, rect.Width, rect.Height);

                this.Add(item);

                //ZYTextDocument.FooterTransforms.Add(item); //add by myc 2014-07-07 添加原因：新版页脚改版需要

                this.editingAreaTransforms[2].Add(item); //add by myc 2014-07-23 添加原因：重构并优化新版页眉、页脚与正文统一管理例程需要
            }

        }

        public void Refresh(float ZoomRate, int PageSplitBlank)
        {
            int leftmargin = (int)(myPages.LeftMargin * ZoomRate);
            int pageheight = (int)(myPages.PaperHeight * ZoomRate);

            mySourceOffsetBack = System.Drawing.Point.Empty;
            this.Clear();
            int iCount = 0;


            #region add by myc 2014-07-24 注释原因：已采用页眉、正文和页脚统一管理方案实现
            //ZYTextDocument.HeaderTransforms.Clear(); //add by myc 2014-07-01 添加原因：新版页眉二期改版需要
            //ZYTextDocument.FooterTransforms.Clear(); //add by myc 2014-07-07 添加原因：新版页脚改版需要 
            #endregion

            for (int i = 0; i < 3; i++) //add by myc 2014-07-23 添加原因：重构并优化新版页眉、页脚与正文统一管理例程需要
            {
                editingAreaTransforms[i].Clear();
            }

            foreach (PrintPage page in myPages)
            {
                int PageTop = (pageheight + PageSplitBlank) * iCount + PageSplitBlank;
                iCount++;
                AddPage(page, PageTop, ZoomRate);

            }//foreach( PrintPage page in myDocument.Pages )
            //this.OffsetSource( leftmargin , 0 , false );
        }

        private int SetSourceRect(SimpleRectangleTransform item, float ZoomRate, int left, int Top)
        {
            System.Drawing.RectangleF rect = System.Drawing.Rectangle.Empty;
            rect.X = left;
            rect.Y = Top;
            rect.Width = (item.DescRectF.Width * ZoomRate);
            rect.Height = (item.DescRectF.Height * ZoomRate);
            item.SourceRectF = rect;
            return (int)Math.Ceiling(Top + rect.Height);
        }

        /// <summary>
        /// 是否使用绝对点左边转换模式
        /// </summary>
        protected bool bolUseAbsTransformPoint = false;
        /// <summary>
        /// 是否使用绝对点左边转换模式
        /// </summary>
        public bool UseAbsTransformPoint
        {
            get { return bolUseAbsTransformPoint; }
            set { bolUseAbsTransformPoint = value; }
        }
        public override System.Drawing.Point TransformPoint(int x, int y)
        {
            if (this.bolUseAbsTransformPoint)
            {
                return AbsTransformPoint(x, y);
            }
            else
            {
                return base.TransformPoint(x, y);
            }
        }

        public override bool ContainsSourcePoint(int x, int y)
        {
            if (this.bolUseAbsTransformPoint)
                return true;
            else
                return base.ContainsSourcePoint(x, y);
        }

        public System.Drawing.Point AbsTransformPoint(int x, int y)
        {
            SimpleRectangleTransform pre = null;
            SimpleRectangleTransform next = null;
            SimpleRectangleTransform cur = null;

            foreach (SimpleRectangleTransform item in this)
            {
                if (item.Enable == false)
                    continue;
                if (item.SourceRect.Contains(x, y))
                    return item.TransformPoint(x, y);

                if (y >= item.SourceRectF.Top && y <= item.SourceRectF.Bottom)
                {
                    cur = item;
                    break;
                }
                if (y < item.SourceRectF.Top)
                {
                    if (next == null || item.SourceRectF.Top < next.SourceRectF.Top)
                        next = item;
                }
                if (y > item.SourceRectF.Bottom)
                {
                    if (pre == null || item.SourceRectF.Bottom > pre.SourceRectF.Bottom)
                        pre = item;
                }
            }
            if (cur == null)
            {
                if (pre != null)
                    cur = pre;
                else
                    cur = next;
            }
            if (cur == null)
                return System.Drawing.Point.Empty;
            System.Drawing.Point p = new System.Drawing.Point(x, y);

            //p = Common.RectangleCommon.MoveInto(p, cur.SourceRect); //add by myc 2014-05-06 添加原因 修正拖拽水平拆分条下移表格最后一行时高度调整不正确问题

            return cur.TransformPoint(p);
        }


        #region 重构并优化新版页眉、页脚与正文统一管理例程 add by myc 2014-07-24——>update by 2014-07-28
        /// <summary>
        /// 编辑区内部原始和目标矩形转换关系列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的矩形区域坐标转换关系。
        /// </summary>
        private List<List<SimpleRectangleTransform>> editingAreaTransforms = new List<List<SimpleRectangleTransform>>();

        /// <summary>
        /// 构造函数中初始化编辑区内部原始和目标矩形转换关系列表的集合editingAreaTransforms。
        /// </summary>
        public MultiPageTransform()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    List<SimpleRectangleTransform> innerTranforms = new List<SimpleRectangleTransform>();
                    editingAreaTransforms.Add(innerTranforms);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定的文档区域内的所有矩形坐标转换关系。
        /// </summary>
        /// <param name="doucumentAreaFlag">标识指定的文档区域所属类别，分为文档页眉区（数值0代表）、文档正文区（数值1代表）和文档页脚区（数值2代表）。</param>
        /// <returns></returns>
        public List<SimpleRectangleTransform> GetHBFTransforms(int doucumentAreaFlag)
        {
            try
            {
                return editingAreaTransforms[doucumentAreaFlag];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 滚动编辑器窗口时，对文档页眉、正文和页脚区域内的所有矩形坐标转换关系执行Scroll调整。
        /// </summary>
        /// <param name="dx">水平滚动偏移量。</param>
        /// <param name="dy">垂直滚动偏移量。</param>
        /// <param name="Remark"></param>
        public override void OffsetSource(int dx, int dy, bool Remark)
        {
            try
            {
                if (Remark)
                    mySourceOffsetBack.Offset(dx, dy);
                for (int i = 0; i < 3; i++)
                {
                    List<SimpleRectangleTransform> currTransforms = this.GetHBFTransforms(i);
                    foreach (SimpleRectangleTransform item in currTransforms)
                    {
                        System.Drawing.Rectangle rect = item.SourceRect;
                        rect.Offset(dx, dy);
                        item.SourceRect = rect;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 滚动编辑器窗口时，对文档页眉、正文和页脚区域内的所有矩形坐标转换关系重置Scroll调整至默认状态。
        /// </summary>
        public override void ClearSourceOffset()
        {
            try
            {
                if (mySourceOffsetBack.IsEmpty == false)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        List<SimpleRectangleTransform> currTransforms = this.GetHBFTransforms(i);
                        foreach (SimpleRectangleTransform item in currTransforms)
                        {
                            System.Drawing.Rectangle rect = item.SourceRect;
                            rect.Offset(-mySourceOffsetBack.X, -mySourceOffsetBack.Y);
                            item.SourceRect = rect;
                        }
                    }
                }
                mySourceOffsetBack = System.Drawing.Point.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }//public class MultiPageTransform : MultiRectangleTransform
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
    /// <summary>
    /// 打印页对象
    /// </summary>
    public class PrintPage
    {
        /// <summary>
        /// 无作为的初始化对象
        /// </summary>
        public PrintPage()
        {
        }

        private System.Drawing.Printing.PrinterSettings myPageSettings = null;
        private int intHeight = 0;
        private int intWidth = 0;

        private PrintPageCollection myOwnerPages = null;

        //		/// <summary>
        //		/// 根据页面位置添加矩形区域转换关系
        //		/// </summary>
        //		/// <param name="myTransform">转换列表</param>
        //		/// <param name="ForPrint">是否为打印进行填充</param>
        //		public void FillTransform( MultiRectangleTransform myTransform , bool ForPrint )
        //		{
        //			System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty ;
        //			if( ForPrint )
        //				rect = new System.Drawing.Rectangle(
        //					myOwnerPages.LeftMargin ,
        //					myOwnerPages.TopMargin + myOwnerPages.HeadHeight , 
        //					this.Width , this.Height );
        //			else
        //				rect = this.BodyViewBounds ;
        //
        //			myTransform.Add( 
        //				rect ,
        //				new System.Drawing.Rectangle( 0 , this.Top , this.Width , this.Height )).Tag = this;
        //
        //			if( myOwnerPages.HeadHeight > 0 )
        //			{
        //				if( ForPrint )
        //					rect = new System.Drawing.Rectangle(
        //						myOwnerPages.LeftMargin , 
        //						myOwnerPages.TopMargin ,
        //						this.Width , 
        //						this.myOwnerPages.HeadHeight );
        //				else
        //					rect = this.HeadViewBounds ;
        //
        //				myTransform.Add( 
        //					rect , 
        //					new System.Drawing.Rectangle( 0 , 0 , this.Width , myOwnerPages.HeadHeight )).Tag = this ;
        //			}
        //			if( myOwnerPages.TailHeight > 0 )
        //			{
        //				if( ForPrint )
        //					rect = new System.Drawing.Rectangle(
        //						myOwnerPages.LeftMargin ,
        //						myOwnerPages.PaperHeight - myOwnerPages.BottomMargin - myOwnerPages.TailHeight  ,
        //						this.Width ,
        //						myOwnerPages.TailHeight );
        //				else
        //					rect = this.TailViewBounds ;
        //
        //				myTransform.Add(
        //					rect , 
        //					new System.Drawing.Rectangle( 0 , myOwnerPages.DocumentHeight - myOwnerPages.TailHeight , this.Width , myOwnerPages.TailHeight )).Tag = this ;
        //			}
        //		}

        //		/// <summary>
        //		/// 页面在控件视图区中的内容边框
        //		/// </summary>
        //		public System.Drawing.Rectangle ContentViewBounds
        //		{
        //			get
        //			{
        //				return new System.Drawing.Rectangle( 
        //					this.intViewLeft + myOwnerPages.LeftMargin ,
        //					this.intViewTop + myOwnerPages.TopMargin ,
        //					intWidth ,
        //					this.intHeight );
        //			}
        //		}
        //		 
        //		public System.Drawing.Rectangle HeadViewBounds
        //		{
        //			get
        //			{
        //				if( myOwnerPages.HeadHeight == 0 )
        //					return System.Drawing.Rectangle.Empty ;
        //				return new System.Drawing.Rectangle( 
        //					this.intViewLeft + myOwnerPages.LeftMargin , 
        //					this.intViewTop + myOwnerPages.TopMargin ,
        //					this.intWidth , 
        //					this.myOwnerPages.HeadHeight );
        //			}
        //		}
        //		public System.Drawing.Rectangle BodyViewBounds
        //		{
        //			get
        //			{
        //				return new System.Drawing.Rectangle( 
        //					this.intViewLeft + myOwnerPages.LeftMargin ,
        //					this.intViewTop + myOwnerPages.TopMargin + this.myOwnerPages.HeadHeight ,
        //					this.intWidth , 
        //					this.intHeight  );
        //			}
        //		}
        //		public System.Drawing.Rectangle TailViewBounds
        //		{
        //			get
        //			{
        //				if( myOwnerPages.FooterHeight  == 0 )
        //					return System.Drawing.Rectangle.Empty ;
        //				else
        //					return new System.Drawing.Rectangle(
        //						this.intViewLeft + myOwnerPages.LeftMargin , 
        //						this.intViewTop + myOwnerPages.PaperHeight - myOwnerPages.BottomMargin - myOwnerPages.FooterHeight ,
        //						this.intWidth , 
        //						this.myOwnerPages.FooterHeight  ) ;
        //			}
        //		}
        /// <summary>
        /// 页面对象在未分割的文档视图中的边框
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Rectangle Bounds
        {
            get
            {
                return new System.Drawing.Rectangle(0, this.Top, intWidth, intHeight);
            }
        }

        protected System.Drawing.Rectangle myClientBounds = System.Drawing.Rectangle.Empty;
        public System.Drawing.Rectangle ClientBounds
        {
            get { return myClientBounds; }
            set { myClientBounds = value; }
        }

        protected int intLeft = 0;
        public int Left
        {
            get { return intLeft; }
            set { intLeft = value; }
        }
        public int Right
        {
            get { return intLeft + intWidth; }
        }
        //		protected int intViewLeft = 0 ;
        //		public int ViewLeft
        //		{
        //			get{ return intViewLeft;}
        //			set{ intViewLeft = value;}
        //		}
        //
        //		protected int intViewTop = 0 ;
        //		public int ViewTop 
        //		{
        //			get{ return intViewTop ;}
        //			set{ intViewTop = value;}
        //		}
        //		public int ViewBottom
        //		{
        //			get{ return intViewTop + this.intHeight ;}
        //		}
        //		public System.Drawing.Rectangle ViewBounds
        //		{
        //			get
        //			{
        //				return new System.Drawing.Rectangle(
        //					intViewLeft , 
        //					intViewTop ,
        //					myOwnerPages.PaperWidth ,
        //					myOwnerPages.PaperHeight );
        //			}
        //		}

        /// <summary>
        /// 对象所属页面集合
        /// </summary>
        public PrintPageCollection OwnerPages
        {
            get { return myOwnerPages; }
            set
            {
                myOwnerPages = value;
                if (intHeight < myOwnerPages.MinPageHeight)
                    intHeight = myOwnerPages.MinPageHeight;
            }
        }

        /// <summary>
        /// 获得从1开始的页号
        /// </summary>
        public int PageIndex
        {
            get { return myOwnerPages.IndexOf(this) + 1; }
        }

        /// <summary>
        /// 获得打印页的顶端位置
        /// </summary>
        public int Top
        {
            get
            {
                int intTop = myOwnerPages.Top;
                foreach (PrintPage myPage in myOwnerPages)
                {
                    if (myPage == this)
                        break;
                    intTop += myPage.Height;
                }
                return intTop;
            }
        }
        //		public int ContentTop
        //		{
        //			get
        //			{
        //				int intTop = 0 ;
        //				foreach( PrintPage page in myOwnerPages )
        //				{
        //					if( page == this )
        //						break;
        //					intTop += page.ContentHeight ;
        //				}
        //				return intTop ;
        //			}
        //		}
        /// <summary>
        /// 设置,返回页面对象的底线
        /// </summary>
        public int Bottom
        {
            get { return this.Top + intHeight; }
            set { intHeight = value - this.Top; FixHeight(); }
        }
        /// <summary>
        /// 页面对象的宽度
        /// </summary>
        public int Width
        {
            get { return intWidth; }
            set { intWidth = value; }
        }
        /// <summary>
        /// 页高
        /// </summary>
        public int Height
        {
            get { return intHeight; }
            set { intHeight = value; FixHeight(); }
        }
        private void FixHeight()
        {
            if (intHeight < myOwnerPages.MinPageHeight)
                intHeight = myOwnerPages.MinPageHeight;
            if (intHeight > myOwnerPages.StandardHeight)
                intHeight = myOwnerPages.StandardHeight;
        }

        /// <summary>
        /// 当前页的打印机设置
        /// </summary>
        public System.Drawing.Printing.PrinterSettings PageSettings
        {
            get { return myPageSettings; }
            set { myPageSettings = value; }
        }

        /// <summary>
        /// 从0开始的页号
        /// </summary>
        public int Index
        {
            get { return myOwnerPages.IndexOf(this); }
        }


        #region add by myc 2014-07-08 添加原因：每一个文档（打印）页都应该有自己独立的页眉高度和页脚高度
        private int headerHeight = 0;
        /// <summary>
        /// 文档打印页的页眉高度。
        /// </summary>
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
        }

        private int footerHeight = 0;
        /// <summary>
        /// 文档打印页的页脚高度。
        /// </summary>
        public int FooterHeight
        {
            get { return footerHeight; }
            set { footerHeight = value; }
        }
        #endregion
    }
}

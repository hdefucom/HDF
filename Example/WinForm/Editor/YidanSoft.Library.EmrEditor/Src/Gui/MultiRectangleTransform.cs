using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 复合矩形区域坐标转换关系列表
    /// </summary>
    public class MultiRectangleTransform : TransformBase, System.Collections.ICollection
    {
        /// <summary>
        /// 无作为的初始化对象
        /// </summary>
        public MultiRectangleTransform()
        {
        }

        protected System.Collections.ArrayList myItems = new System.Collections.ArrayList();

        //		protected bool bolEnable = true;
        //		/// <summary>
        //		/// 对象是否可用
        //		/// </summary>
        //		public bool Enable
        //		{
        //			get{ return bolEnable ;}
        //			set{ bolEnable = value;}
        //		}
        //		protected int intOffsetX = 0 ;
        //		/// <summary>
        //		/// 横向位置修正量
        //		/// </summary>
        //		public int OffsetX
        //		{
        //			get{ return intOffsetX ;}
        //			set{ intOffsetX = value;}
        //		}
        //		protected int intOffsetY = 0 ;
        //		/// <summary>
        //		/// 纵向位置修正量
        //		/// </summary>
        //		public int OffsetY
        //		{
        //			get{ return intOffsetY ;}
        //			set{ intOffsetY = value;}
        //		}
        //		/// <summary>
        //		/// 位置修正量
        //		/// </summary>
        //		public System.Drawing.Point Offset
        //		{
        //			get
        //			{
        //				return new System.Drawing.Point( 
        //					this.intOffsetX ,
        //					this.intOffsetY ); 
        //			}
        //			set
        //			{
        //				this.intOffsetX = value.X ;
        //				this.intOffsetY = value.Y ;
        //			}
        //		}

        //		protected bool bolCheckEnable = false;
        //		/// <summary>
        //		/// 是否检查转换项目是否有效
        //		/// </summary>
        //		public bool CheckEnable
        //		{
        //			get{ return bolCheckEnable ;}
        //			set{ bolCheckEnable = value;}
        //		}
        protected double dblRate = 1;
        /// <summary>
        /// 缩放比例
        /// </summary>
        public double Rate
        {
            get { return dblRate; }
            set { dblRate = value; }
        }
        protected System.Drawing.Point mySourceOffsetBack = System.Drawing.Point.Empty;
        
        #region add by myc 2014-07-28 注释原因：重构并优化新版页眉、页脚与正文统一管理例程
        //public void OffsetSource(int dx, int dy, bool Remark)
        //{
        //    if (Remark)
        //        mySourceOffsetBack.Offset(dx, dy);
        //    foreach (SimpleRectangleTransform item in this)
        //    {
        //        System.Drawing.Rectangle rect = item.SourceRect;
        //        rect.Offset(dx, dy);
        //        item.SourceRect = rect;
        //    }
        //}
        //public void ClearSourceOffset()
        //{
        //    if (mySourceOffsetBack.IsEmpty == false)
        //    {
        //        foreach (SimpleRectangleTransform item in this)
        //        {
        //            System.Drawing.Rectangle rect = item.SourceRect;
        //            rect.Offset(-mySourceOffsetBack.X, -mySourceOffsetBack.Y);
        //            item.SourceRect = rect;
        //        }
        //    }
        //    mySourceOffsetBack = System.Drawing.Point.Empty;
        //}
        #endregion

        //		public void OffsetDesc( int dx , int dy )
        //		{
        //			foreach( SimpleRectangleTransform item in this )
        //			{
        //				System.Drawing.Rectangle rect = item.DescRect ;
        //				rect.Offset( dx , dy );
        //				item.DescRect = rect ;
        //			}
        //		}

        public System.Drawing.Rectangle SourceBounds
        {
            get
            {
                System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;
                foreach (SimpleRectangleTransform item in this)
                {
                    if (rect.IsEmpty)
                        rect = item.SourceRect;
                    else
                        rect = System.Drawing.Rectangle.Union(rect, item.SourceRect);
                }
                return rect;
            }
        }

        public System.Drawing.Rectangle DescBounds
        {
            get
            {
                System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;
                foreach (SimpleRectangleTransform item in this)
                {
                    if (rect.IsEmpty)
                        rect = item.DescRect;
                    else
                        rect = System.Drawing.Rectangle.Union(rect, item.DescRect);
                }
                return rect;
            }
        }

        /// <summary>
        /// 返回指定序号的转换对应关系
        /// </summary>
        public SimpleRectangleTransform this[int index]
        {
            get { return (SimpleRectangleTransform)myItems[index]; }
        }
        /// <summary>
        /// 获得具有指定原始区域矩形边框的转换对应关系,若未找到则返回空引用
        /// </summary>
        public SimpleRectangleTransform this[System.Drawing.Rectangle rect]
        {
            get
            {
                foreach (SimpleRectangleTransform item in this)
                {
                    if (item.SourceRect.Equals(rect))
                        return item;
                }
                return null;
            }
        }
        /// <summary>
        /// 获得指定点所在的对应关系
        /// </summary>
        public SimpleRectangleTransform this[int x, int y]
        {
            get
            {
                foreach (SimpleRectangleTransform item in this)
                {
                    if (item.SourceRect.Contains(x, y) && item.Enable)
                        return item;
                }
                return null;
            }
        }
        /// <summary>
        /// 获得指定点所在的对应关系
        /// </summary>
        public SimpleRectangleTransform this[System.Drawing.Point p]
        {
            get { return this[p.X, p.Y]; }
        }
        public int Add(SimpleRectangleTransform item)
        {
            return myItems.Add(item);
        }
        /// <summary>
        /// 添加一个转换关系
        /// </summary>
        /// <param name="SourceRect">原始区域矩形边框</param>
        /// <param name="DescRect">目标区域矩形边框</param>
        /// <remarks>新增的转换关系</remarks>
        public SimpleRectangleTransform Add(
            System.Drawing.Rectangle SourceRect,
            System.Drawing.Rectangle DescRect)
        {
            SimpleRectangleTransform NewItem = new SimpleRectangleTransform(SourceRect, DescRect);
            myItems.Add(NewItem);
            return NewItem;
        }
        /// <summary>
        /// 添加一个转换关系
        /// </summary>
        /// <param name="SourceLeft">原始区域边框左端位置</param>
        /// <param name="SourceTop">原始区域边框顶端位置</param>
        /// <param name="SourceWidth">原始区域边框宽度</param>
        /// <param name="SourceHeight">原始区域边框高度</param>
        /// <param name="DescLeft">目标区域边框左端位置</param>
        /// <param name="DescTop">目标区域边框顶端位置</param>
        /// <param name="DescWidth">目标区域边框宽度</param>
        /// <param name="DescHeight">目标区域边框高度</param>
        public SimpleRectangleTransform Add(
            int SourceLeft,
            int SourceTop,
            int SourceWidth,
            int SourceHeight,
            int DescLeft,
            int DescTop,
            int DescWidth,
            int DescHeight)
        {
            SimpleRectangleTransform NewItem = new SimpleRectangleTransform(
                new System.Drawing.Rectangle(SourceLeft, SourceTop, SourceWidth, SourceHeight),
                new System.Drawing.Rectangle(DescLeft, DescTop, DescWidth, DescHeight));
            myItems.Add(NewItem);
            return NewItem;
        }

        /// <summary>
        /// 判断指定坐标的点是否有相应的原始区域
        /// </summary>
        /// <param name="x">点X坐标</param>
        /// <param name="y">点Y坐标</param>
        /// <returns>是否有相应的原始区域</returns>
        public override bool ContainsSourcePoint(int x, int y)
        {
            return this[x, y] != null;
        }
        /// <summary>
        /// 判断指定坐标的点是否有相应的原始区域
        /// </summary>
        /// <param name="p">点坐标</param>
        /// <returns>是否有相应的原始区域</returns>
        public bool Contains(System.Drawing.Point p)
        {
            return this[p.X, p.Y] != null;
        }

        public int TransformY(int y)
        {
            foreach (SimpleRectangleTransform item in this)
            {
                if (item.Enable)
                {
                    System.Drawing.Rectangle rect = item.SourceRect;
                    if (y >= rect.Top && y <= rect.Bottom)
                    {
                        return item.TransformPoint(rect.Left, y).Y;
                    }
                }
            }
            return y;
        }
        public int UnTransformY(int y)
        {
            foreach (SimpleRectangleTransform item in this)
            {
                if (item.Enable)
                {
                    System.Drawing.Rectangle rect = item.DescRect;
                    if (y >= rect.Top && y <= rect.Bottom)
                    {
                        return item.UnTransformPoint(item.DescRect.Left, y).Y;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 将原始点根据命中的转换关系转换为目标区域中的点坐标,若未相应的转换关系则返回原始坐标值
        /// </summary>
        /// <param name="p">原始点坐标</param>
        /// <returns>处理后的目标点坐标</returns>
        public System.Drawing.Point Transform(System.Drawing.Point p)
        {
            return TransformPoint(p.X, p.Y);
        }

        public override System.Drawing.Point TransformPoint(int x, int y)
        {
            //Debug.WriteLine("this.myItems.Count " + this.myItems.Count+" "+DateTime.Now.Ticks);
            foreach (SimpleRectangleTransform item in this)
            {
                if (item.Enable && item.SourceRect.Contains(x, y))
                   return item.TransformPoint(x, y);
            }
            return System.Drawing.Point.Empty;
            //return new System.Drawing.Point( x , y );
        }


        public override System.Drawing.Size TransformSize(int w, int h)
        {
            return new System.Drawing.Size((int)(w * dblRate), (int)(h * dblRate));
        }
        public override System.Drawing.Size TransformSize(System.Drawing.Size vSize)
        {
            return new System.Drawing.Size((int)(vSize.Width * dblRate), (int)(vSize.Height * dblRate));
        }
        public override System.Drawing.SizeF TransformSizeF(float w, float h)
        {
            return new System.Drawing.SizeF((float)(w * dblRate), (float)(h * dblRate));
        }
        public override System.Drawing.SizeF TransformSizeF(System.Drawing.SizeF vSize)
        {
            return new System.Drawing.SizeF((float)(vSize.Width * dblRate), (float)(vSize.Height * dblRate));
        }

        public override System.Drawing.Point UnTransformPoint(int x, int y)
        {
            System.Drawing.Point p = System.Drawing.Point.Empty;
            foreach (SimpleRectangleTransform item in this)
            {
                if (item.Enable && item.DescRect.Contains(x, y))
                {
                    p = item.UnTransformPoint(x, y);
                    return p;
                }
            }
            return p;
        }

        public override System.Drawing.PointF TransformPointF(float x, float y)
        {
            foreach (SimpleRectangleTransform item in this)
            {
                if (item.SourceRectF.Contains(x, y) && item.Enable)
                    return item.TransformPointF(x, y);
            }
            return new System.Drawing.PointF(x, y);
        }

        public override System.Drawing.PointF UnTransformPointF(float x, float y)
        {
            System.Drawing.PointF p = System.Drawing.PointF.Empty;
            foreach (SimpleRectangleTransform item in this)
            {
                if (item.DescRectF.Contains(x, y) && item.Enable)
                {
                    p = item.UnTransformPointF(x, y);
                }
            }
            return p;
        }

        public override System.Drawing.Size UnTransformSize(int w, int h)
        {
            return new System.Drawing.Size((int)(w / dblRate), (int)(h / dblRate));
        }
        public override System.Drawing.Size UnTransformSize(System.Drawing.Size vSize)
        {
            return new System.Drawing.Size((int)(vSize.Width / dblRate), (int)(vSize.Height / dblRate));
        }
        public override System.Drawing.SizeF UnTransformSizeF(float w, float h)
        {
            return new System.Drawing.SizeF((float)(w / dblRate), (float)(h / dblRate));
        }
        public override System.Drawing.SizeF UnTransformSizeF(System.Drawing.SizeF vSize)
        {
            return new System.Drawing.SizeF((float)(vSize.Width / dblRate), (float)(vSize.Height / dblRate));
        }





        /// <summary>
        /// 当前转换关系项目
        /// </summary>
        protected SimpleRectangleTransform myCurrentItem = null;
        /// <summary>
        /// 当前转换关系项目
        /// </summary>
        public SimpleRectangleTransform CurrentItem
        {
            get { return myCurrentItem; }
        }

        //		/// <summary>
        //		/// 重新绘制所有的文档内容
        //		/// </summary>
        //		/// <param name="g">绘制图形的对象</param>
        //		public void RefreshView( System.Drawing.Graphics g )
        //		{
        //			System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty ;
        //			foreach( RectangleTransformItem item in this )
        //			{
        //				if( item.Visible )
        //				{
        //					if( rect.IsEmpty )
        //						rect = item.SourceRect ;
        //					else
        //						rect = System.Drawing.Rectangle.Union( rect , item.SourceRect );
        //				}
        //			}
        //			OnPaint( this , new System.Windows.Forms.PaintEventArgs( g , rect ));
        //		}

        //		/// <summary>
        //		/// 绘图事件对象
        //		/// </summary>
        //		public event System.Windows.Forms.PaintEventHandler Paint = null;
        //		/// <summary>
        //		/// 分解执行绘图操作命令
        //		/// </summary>
        //		/// <param name="Sender">操作来源</param>
        //		/// <param name="e">操作参数对象</param>
        //		/// <returns>分解后的操作参数对象集合</returns>
        //		public virtual void OnPaint( object Sender , System.Windows.Forms.PaintEventArgs e )
        //		{
        //			if( bolEnable == false ) return ;
        //			if( Paint == null )
        //				return ;
        //			System.Drawing.Rectangle ClipRect = e.ClipRectangle ;
        //			ClipRect.Offset( this.intOffsetX , this.intOffsetY );
        //			foreach( RectangleTransformItem item in this )
        //			{
        //				if( item.Visible )
        //				{
        //					System.Drawing.Rectangle rect = System.Drawing.Rectangle.Intersect( item.SourceRect , ClipRect );
        //					if(  ! rect.IsEmpty )
        //					{
        //						rect = item.Transform( rect );
        //						if( XDesignerCommon.RectangleCommon.PaintInvalidSize( rect.Width , rect.Height ))
        //						{
        //							System.Windows.Forms.PaintEventArgs e2 = 
        //								new System.Windows.Forms.PaintEventArgs( e.Graphics , rect );
        //							e2.Graphics.ResetClip();
        //							e2.Graphics.ResetTransform();
        //
        //							e2.Graphics.TranslateTransform(
        //								item.SourceRect.Left - item.DescRect.Left - intOffsetX  , 
        //								item.SourceRect.Top - item.DescRect.Top - intOffsetY );
        //
        //							e.Graphics.SetClip(
        //								new System.Drawing.Rectangle( rect.Left , rect.Top , rect.Width + 1 , rect.Height + 1) );
        //
        //							myCurrentItem = item ;
        //							Paint( Sender , e2 );
        //							e2.Graphics.ResetClip();
        //							e2.Graphics.ResetTransform();
        //						}
        //					}
        //				}
        //			}//foreach( RectangleTransformItem item in this.List )
        //		}//public virtual System.Collections.ArrayList OnPaint( object Sender , System.Windows.Forms.PaintEventArgs e )
        //
        //		public event System.Windows.Forms.MouseEventHandler MouseDown = null;
        //		public virtual void OnMouseDown( object Sender , System.Windows.Forms.MouseEventArgs e )
        //		{
        //			if( bolEnable == false ) return ;
        //			if( MouseDown == null )
        //				return ;
        //			int x = e.X + intOffsetX ;
        //			int y = e.Y + intOffsetY ;
        //			foreach( RectangleTransformItem item in this.List )
        //			{
        //				if( item.Enable )
        //				{
        //					if( item.SourceRect.Contains( x , y ))
        //					{
        //						System.Drawing.Point p = item.Transform( x , y );
        //						MouseDown( Sender , new System.Windows.Forms.MouseEventArgs( e.Button , e.Clicks , x , y , e.Delta ));
        //						break;
        //					}
        //				}
        //			}
        //		}

        public void Clear()
        {
            myItems.Clear();
        }

        #region ICollection 成员

        public bool IsSynchronized
        {
            get
            {
                return myItems.IsSynchronized;
            }
        }

        public int Count
        {
            get
            {
                return myItems.Count;
            }
        }

        public void CopyTo(Array array, int index)
        {
            myItems.CopyTo(array, index);
        }

        public object SyncRoot
        {
            get
            {
                return myItems.SyncRoot;
            }
        }

        #endregion

        #region IEnumerable 成员

        public System.Collections.IEnumerator GetEnumerator()
        {
            return myItems.GetEnumerator();
        }

        #endregion


        #region add by myc 2014-07-28 添加原因：重构并优化新版页眉、页脚与正文统一管理例程
        /// <summary>
        /// 滚动编辑器窗口时，对文档页眉、正文和页脚区域内的所有矩形坐标转换关系执行Scroll调整。
        /// </summary>
        /// <param name="dx">水平滚动偏移量。</param>
        /// <param name="dy">垂直滚动偏移量。</param>
        /// <param name="Remark"></param>
        public virtual void OffsetSource(int dx, int dy, bool Remark)
        {
            try
            {
                if (Remark)
                    mySourceOffsetBack.Offset(dx, dy);
                foreach (SimpleRectangleTransform item in this)
                {
                    System.Drawing.Rectangle rect = item.SourceRect;
                    rect.Offset(dx, dy);
                    item.SourceRect = rect;
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
        public virtual void ClearSourceOffset()
        {
            try
            {
                if (mySourceOffsetBack.IsEmpty == false)
                {
                    foreach (SimpleRectangleTransform item in this)
                    {
                        System.Drawing.Rectangle rect = item.SourceRect;
                        rect.Offset(-mySourceOffsetBack.X, -mySourceOffsetBack.Y);
                        item.SourceRect = rect;
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


    }//
}

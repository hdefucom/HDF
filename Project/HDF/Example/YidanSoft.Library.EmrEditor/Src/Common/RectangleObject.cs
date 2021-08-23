using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// 矩形对象
	/// </summary>
	public class RectangleObject
	{
		protected int intLeft		= 0 ;
		protected int intTop		= 0 ; 
		protected int intWidth		= 0 ;
		protected int intHeight		= 0 ;

		/// <summary>
		/// 左端位置
		/// </summary>
		public int Left
		{
			get{ return intLeft;}
			set{ intLeft = value;}
		}
		/// <summary>
		/// 顶端位置
		/// </summary>
		public int Top 
		{
			get{ return intTop ;}
			set{ intTop = value;}
		}
		/// <summary>
		/// 宽度
		/// </summary>
		public int Width
		{
			get{ return intWidth;}
			set{ intWidth = value;}
		}
		/// <summary>
		/// 高度
		/// </summary>
		public int Height
		{
			get{ return intHeight;}
			set{ intHeight = value;}
		}
		/// <summary>
		/// 右端位置
		/// </summary>
		public int Right
		{
			get{ return intLeft + intWidth ;}
			set{ intLeft = value - intWidth ;}
		}
		/// <summary>
		/// 底端位置
		/// </summary>
		public int Bottom
		{
			get{ return intTop + intHeight ;}
			set{ intTop = value - intHeight ;}
		}

		/// <summary>
		/// 对象数据是否为空
		/// </summary>
		/// <returns></returns>
		public bool isEmpty()
		{
			return intLeft == 0 && intTop == 0 && intWidth == 0 && intHeight == 0 ;
		}

		/// <summary>
		/// 移动对象的左上角位置而不改变对象大小
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void MoveTo( int x , int y)
		{
			intLeft = x ;
			intTop	= y ;
		}
		/// <summary>
		/// 移动对象的右下角位置而不改变对象大小
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void MoveTo2( int x , int y )
		{
			intLeft = x - intWidth ;
			intTop	= y - intHeight ;
		}

		/// <summary>
		/// 移动对象左上角指定的位移而不改变对象大小
		/// </summary>
		/// <param name="dx">横向偏移量</param>
		/// <param name="dy">纵向偏移量</param>
		public void MoveStep( int dx , int dy )
		{
			intLeft += dx ;
			intTop	+= dy ;
		}

		/// <summary>
		/// 设置对象的大小
		/// </summary>
		/// <param name="vWidth">对象的新宽度</param>
		/// <param name="vHeight">对象的新高度</param>
		public void ReSize( int vWidth , int vHeight)
		{
			intWidth	= vWidth;
			intHeight	= vHeight;
		}

		/// <summary>
		/// 根据两点坐标设置对象,本函数会判断两个点的坐标值大小关系,
		/// 以保证设置后的对象表示的矩形区域的两个对顶角为输入的两个点
		/// </summary>
		/// <param name="x1">第一个点的X坐标</param>
		/// <param name="y1">第一个点的Y坐标</param>
		/// <param name="x2">第二个点的X坐标</param>
		/// <param name="y2">第二个点的Y坐标</param>
		public void SetRect( int x1 , int y1 , int x2 , int y2)
		{
			if( x1 < x2)
			{
				intLeft		= x1 ;
				intWidth	= x2 - x1 ;
			}
			else
			{
				intLeft	= x2;
				intWidth= x1 - x2 ;
			}
			if( y1 < y2)
			{
				intTop	= y1;
				intHeight = y2 - y1 ;
			}
			else
			{
				intTop	= y2;
				intHeight= y1 - y2;
			}
		}

		public static System.Drawing.Rectangle ConvertToRectangle( System.Drawing.RectangleF rf)
		{
			return new System.Drawing.Rectangle( (int)rf.Left , (int)rf.Top , (int)rf.Width , (int)rf.Height );
		}

		/// <summary>
		/// 判断指定点是指定的矩形的那个顶点,返回-1:不是顶点 0:为左上点 1:右上点 2:右下点 3:左下点
		/// </summary>
		/// <param name="vRect">矩形对象</param>
		/// <param name="p">点对象</param>
		/// <returns>返回值</returns>
		public static int GetAcmeIndex( System.Drawing.Rectangle vRect , System.Drawing.Point p )
		{
			if( vRect.IsEmpty == false)
			{
				if( p.Y  == vRect.Y  )
				{
					if( p.X == vRect.X )
						return 0 ;
					if( p.X == vRect.Right )
						return 1 ;
				}
				else if( p.Y == vRect.Bottom )
				{
					if( p.X == vRect.Right )
						return 2 ;
					if( p.X == vRect.X )
						return 3 ;
				}
			}
			return -1 ;
		}

		/// <summary>
		/// 获得指定矩形指定顶端的坐标,矩形顶点编号为 0:为左上点 1:右上点 2:右下点 3:左下点
		/// </summary>
		/// <param name="vRect"></param>
		/// <param name="AcmeIndex"></param>
		/// <returns></returns>
		public static System.Drawing.Point GetAcmePos( System.Drawing.Rectangle vRect , int AcmeIndex )
		{
			switch( AcmeIndex )
			{
				case 0 :
					return vRect.Location ;
				case 1:
					return new System.Drawing.Point( vRect.Right  , vRect.Y  );
				case 2:
					return new System.Drawing.Point( vRect.Right , vRect.Bottom );
				case 3:
					return new System.Drawing.Point( vRect.X , vRect.Bottom );
			}
			return System.Drawing.Point.Empty ;
		}

		/// <summary>
		/// 根据两点坐标获得方框对象
		/// </summary>
		/// <param name="x1"></param>
		/// <param name="y1"></param>
		/// <param name="x2"></param>
		/// <param name="y2"></param>
		/// <returns></returns>
		public static System.Drawing.Rectangle GetRectangle( int x1 , int y1 , int x2 , int y2)
		{
			System.Drawing.Rectangle myRect = System.Drawing.Rectangle.Empty ;
			if( x1 < x2)
			{
				myRect.X 		= x1 ;
				myRect.Width 	= x2 - x1 ;
			}
			else
			{
				myRect.X 		= x2;
				myRect.Width	= x1 - x2 ;
			}
			if( y1 < y2)
			{
				myRect.Y 		= y1;
				myRect.Height	= y2 - y1 ;
			}
			else
			{
				myRect.Y 		= y2;
				myRect.Height	= y1 - y2;
			}
			if( myRect.Width < 1) myRect.Width = 1 ;
			if( myRect.Height < 1) myRect.Height = 1 ;
			return myRect ;
		}

		
		/// <summary>
		/// 根据两点坐标获得方框对象
		/// </summary>
		/// <param name="p1">第一个点的坐标</param>
		/// <param name="p2">第二个点的坐标</param>
		/// <returns></returns>
		public static System.Drawing.Rectangle GetRectangle( System.Drawing.Point p1 , System.Drawing.Point p2)
		{
			return GetRectangle( p1.X ,p1.Y , p2.X , p2.Y );
		}


		/// <summary>
		/// 判断对象是否包含了指定的矩形对象
		/// </summary>
		/// <param name="vRect">矩形对象</param>
		/// <returns>是否包含</returns>
		public bool Contains(System.Drawing.Rectangle vRect)
		{
			return (new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight)).Contains( vRect) ;
		}

		/// <summary>
		/// 判断对象是否包含了指定矩形区域
		/// </summary>
		/// <param name="x">矩形区域的左端位置</param>
		/// <param name="y">矩形区域的顶端位置</param>
		/// <param name="vWidth">矩形区域的宽度</param>
		/// <param name="vHeight">矩形区域的高度</param>
		/// <returns>是否包含</returns>
		public bool Contains( int x , int y , int vWidth , int vHeight)
		{
			System.Drawing.Rectangle r1 = new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			System.Drawing.Rectangle r2 = new System.Drawing.Rectangle( x , y , vWidth , vHeight);
			return r1.Contains(r2);
		}

		/// <summary>
		/// 判断对象是否包含了一个点
		/// </summary>
		/// <param name="x">指定点的X坐标</param>
		/// <param name="y">指定点的Y坐标</param>
		/// <returns>对象是否包含了指定点</returns>
		public bool Contains(int x , int y)
		{
			return ( x > intLeft && x < intLeft + intWidth && y > intTop && y < intTop + intHeight );
		}

		/// <summary>
		/// 判断是否和指定矩形对象相交
		/// </summary>
		/// <param name="vRect">矩形区域</param>
		/// <returns>是否相交</returns>
		public bool  IntersectsWith( System.Drawing.Rectangle vRect)
		{
			return ( new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight)).IntersectsWith( vRect);
		}
		/// <summary>
		/// 判断是否和指定矩形区域相交
		/// </summary>
		/// <param name="x">矩形区域的左端位置</param>
		/// <param name="y">矩形区域的顶端位置</param>
		/// <param name="vWidth">矩形区域的宽度</param>
		/// <param name="vHeight">矩形区域的高度</param>
		/// <returns>是否相交</returns>
		public bool IntersectsWith( int x , int y , int vWidth , int vHeight)
		{
			System.Drawing.Rectangle r1 = new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			System.Drawing.Rectangle r2 = new System.Drawing.Rectangle( x , y , vWidth , vHeight);
			return r1.IntersectsWith( r2);
		}
		/// <summary>
		/// 获得和指定矩形对象的相交区域对象
		/// </summary>
		/// <param name="vRect">矩形对象</param>
		/// <returns>相交的区域对象</returns>
		public System.Drawing.Rectangle Intersect( System.Drawing.Rectangle vRect)
		{
			System.Drawing.Rectangle myRect  =  new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			myRect.Intersect( vRect );
			return myRect ;
		}

		/// <summary>
		/// 获得和指定矩形区域对象的并集
		/// </summary>
		/// <param name="vRect">矩形区域</param>
		/// <returns>并集</returns>
		public System.Drawing.Rectangle Union( System.Drawing.Rectangle vRect)
		{
			System.Drawing.Rectangle myRect  =  new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			return System.Drawing.Rectangle.Union( myRect , vRect);
		}

		/// <summary>
		/// 获得和指定矩形区域对象的并集
		/// </summary>
		/// <param name="vRect">矩形区域对象</param>
		/// <returns>并集</returns>
		public System.Drawing.Rectangle Union( RectangleObject vRect)
		{
			if( vRect == null)
				return System.Drawing.Rectangle.Empty ;
			else
			{
				System.Drawing.Rectangle myRect  =  new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
				return System.Drawing.Rectangle.Union( vRect.InnerRect , myRect);
			}
		}

		/// <summary>
		/// 设置,返回表示矩形区域的对象
		/// </summary>
		public System.Drawing.Rectangle InnerRect
		{
			get{ return new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);}
			set
			{
				intLeft		= value.Left ;
				intTop		= value.Top ;
				intWidth	= value.Width ;
				intHeight	= value.Height ;
			}
		}

		public System.Drawing.Point GetBorderPoint( int iPos , int iSplit)
		{
			System.Drawing.Point myPoint = System.Drawing.Point.Empty ;
			if( iSplit <= 0)
				return myPoint ;
			// 修正参数,保证参数在 0 到 4倍的Split之间
			iPos %= ( iSplit * 4 );
			if( iPos < 0 )
				iPos += ( iSplit * 4 );
			// 计算坐标
			if( iPos >=0 && iPos < iSplit )
			{
				myPoint.X = intLeft + (intWidth * iPos) / iSplit ;
				myPoint.Y = intTop ;
			}
			else if ( iPos >= iSplit && iPos < iSplit * 2 )
			{
				myPoint.X = intLeft + intWidth ;
				myPoint.Y = intTop + ( intHeight * (iPos - iSplit) )/ iSplit ;
			}
			else if ( iPos >= iSplit * 2 && iPos < iSplit * 3 )
			{
				myPoint.X = intLeft + (intWidth * ( iSplit * 3 - iPos ))/iSplit;
				myPoint.Y = intTop + intHeight ;
			}
			else
			{
				myPoint.X = intLeft ;
				myPoint.Y = intTop + ( intHeight * ( iSplit * 4  - iPos ))/ iSplit ;
			}
			// 返回结果
			return myPoint ;
		}

		public RectangleObject()
		{
		}
	}
}

using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// ���ζ���
	/// </summary>
	public class RectangleObject
	{
		protected int intLeft		= 0 ;
		protected int intTop		= 0 ; 
		protected int intWidth		= 0 ;
		protected int intHeight		= 0 ;

		/// <summary>
		/// ���λ��
		/// </summary>
		public int Left
		{
			get{ return intLeft;}
			set{ intLeft = value;}
		}
		/// <summary>
		/// ����λ��
		/// </summary>
		public int Top 
		{
			get{ return intTop ;}
			set{ intTop = value;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public int Width
		{
			get{ return intWidth;}
			set{ intWidth = value;}
		}
		/// <summary>
		/// �߶�
		/// </summary>
		public int Height
		{
			get{ return intHeight;}
			set{ intHeight = value;}
		}
		/// <summary>
		/// �Ҷ�λ��
		/// </summary>
		public int Right
		{
			get{ return intLeft + intWidth ;}
			set{ intLeft = value - intWidth ;}
		}
		/// <summary>
		/// �׶�λ��
		/// </summary>
		public int Bottom
		{
			get{ return intTop + intHeight ;}
			set{ intTop = value - intHeight ;}
		}

		/// <summary>
		/// ���������Ƿ�Ϊ��
		/// </summary>
		/// <returns></returns>
		public bool isEmpty()
		{
			return intLeft == 0 && intTop == 0 && intWidth == 0 && intHeight == 0 ;
		}

		/// <summary>
		/// �ƶ���������Ͻ�λ�ö����ı�����С
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void MoveTo( int x , int y)
		{
			intLeft = x ;
			intTop	= y ;
		}
		/// <summary>
		/// �ƶ���������½�λ�ö����ı�����С
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void MoveTo2( int x , int y )
		{
			intLeft = x - intWidth ;
			intTop	= y - intHeight ;
		}

		/// <summary>
		/// �ƶ��������Ͻ�ָ����λ�ƶ����ı�����С
		/// </summary>
		/// <param name="dx">����ƫ����</param>
		/// <param name="dy">����ƫ����</param>
		public void MoveStep( int dx , int dy )
		{
			intLeft += dx ;
			intTop	+= dy ;
		}

		/// <summary>
		/// ���ö���Ĵ�С
		/// </summary>
		/// <param name="vWidth">������¿��</param>
		/// <param name="vHeight">������¸߶�</param>
		public void ReSize( int vWidth , int vHeight)
		{
			intWidth	= vWidth;
			intHeight	= vHeight;
		}

		/// <summary>
		/// ���������������ö���,���������ж������������ֵ��С��ϵ,
		/// �Ա�֤���ú�Ķ����ʾ�ľ�������������Զ���Ϊ�����������
		/// </summary>
		/// <param name="x1">��һ�����X����</param>
		/// <param name="y1">��һ�����Y����</param>
		/// <param name="x2">�ڶ������X����</param>
		/// <param name="y2">�ڶ������Y����</param>
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
		/// �ж�ָ������ָ���ľ��ε��Ǹ�����,����-1:���Ƕ��� 0:Ϊ���ϵ� 1:���ϵ� 2:���µ� 3:���µ�
		/// </summary>
		/// <param name="vRect">���ζ���</param>
		/// <param name="p">�����</param>
		/// <returns>����ֵ</returns>
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
		/// ���ָ������ָ�����˵�����,���ζ�����Ϊ 0:Ϊ���ϵ� 1:���ϵ� 2:���µ� 3:���µ�
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
		/// �������������÷������
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
		/// �������������÷������
		/// </summary>
		/// <param name="p1">��һ���������</param>
		/// <param name="p2">�ڶ����������</param>
		/// <returns></returns>
		public static System.Drawing.Rectangle GetRectangle( System.Drawing.Point p1 , System.Drawing.Point p2)
		{
			return GetRectangle( p1.X ,p1.Y , p2.X , p2.Y );
		}


		/// <summary>
		/// �ж϶����Ƿ������ָ���ľ��ζ���
		/// </summary>
		/// <param name="vRect">���ζ���</param>
		/// <returns>�Ƿ����</returns>
		public bool Contains(System.Drawing.Rectangle vRect)
		{
			return (new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight)).Contains( vRect) ;
		}

		/// <summary>
		/// �ж϶����Ƿ������ָ����������
		/// </summary>
		/// <param name="x">������������λ��</param>
		/// <param name="y">��������Ķ���λ��</param>
		/// <param name="vWidth">��������Ŀ��</param>
		/// <param name="vHeight">��������ĸ߶�</param>
		/// <returns>�Ƿ����</returns>
		public bool Contains( int x , int y , int vWidth , int vHeight)
		{
			System.Drawing.Rectangle r1 = new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			System.Drawing.Rectangle r2 = new System.Drawing.Rectangle( x , y , vWidth , vHeight);
			return r1.Contains(r2);
		}

		/// <summary>
		/// �ж϶����Ƿ������һ����
		/// </summary>
		/// <param name="x">ָ�����X����</param>
		/// <param name="y">ָ�����Y����</param>
		/// <returns>�����Ƿ������ָ����</returns>
		public bool Contains(int x , int y)
		{
			return ( x > intLeft && x < intLeft + intWidth && y > intTop && y < intTop + intHeight );
		}

		/// <summary>
		/// �ж��Ƿ��ָ�����ζ����ཻ
		/// </summary>
		/// <param name="vRect">��������</param>
		/// <returns>�Ƿ��ཻ</returns>
		public bool  IntersectsWith( System.Drawing.Rectangle vRect)
		{
			return ( new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight)).IntersectsWith( vRect);
		}
		/// <summary>
		/// �ж��Ƿ��ָ�����������ཻ
		/// </summary>
		/// <param name="x">������������λ��</param>
		/// <param name="y">��������Ķ���λ��</param>
		/// <param name="vWidth">��������Ŀ��</param>
		/// <param name="vHeight">��������ĸ߶�</param>
		/// <returns>�Ƿ��ཻ</returns>
		public bool IntersectsWith( int x , int y , int vWidth , int vHeight)
		{
			System.Drawing.Rectangle r1 = new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			System.Drawing.Rectangle r2 = new System.Drawing.Rectangle( x , y , vWidth , vHeight);
			return r1.IntersectsWith( r2);
		}
		/// <summary>
		/// ��ú�ָ�����ζ�����ཻ�������
		/// </summary>
		/// <param name="vRect">���ζ���</param>
		/// <returns>�ཻ���������</returns>
		public System.Drawing.Rectangle Intersect( System.Drawing.Rectangle vRect)
		{
			System.Drawing.Rectangle myRect  =  new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			myRect.Intersect( vRect );
			return myRect ;
		}

		/// <summary>
		/// ��ú�ָ�������������Ĳ���
		/// </summary>
		/// <param name="vRect">��������</param>
		/// <returns>����</returns>
		public System.Drawing.Rectangle Union( System.Drawing.Rectangle vRect)
		{
			System.Drawing.Rectangle myRect  =  new System.Drawing.Rectangle( intLeft , intTop , intWidth , intHeight);
			return System.Drawing.Rectangle.Union( myRect , vRect);
		}

		/// <summary>
		/// ��ú�ָ�������������Ĳ���
		/// </summary>
		/// <param name="vRect">�����������</param>
		/// <returns>����</returns>
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
		/// ����,���ر�ʾ��������Ķ���
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
			// ��������,��֤������ 0 �� 4����Split֮��
			iPos %= ( iSplit * 4 );
			if( iPos < 0 )
				iPos += ( iSplit * 4 );
			// ��������
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
			// ���ؽ��
			return myPoint ;
		}

		public RectangleObject()
		{
		}
	}
}

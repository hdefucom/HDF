using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// ������ʽ
	/// </summary>
	public enum PenStyle
	{
		/// <summary>
		/// The pen is solid.
		/// </summary>
		PS_SOLID            = 0 ,
		/// <summary>
		/// The pen is dashed. This style is valid only when the pen width is one or less in device units.
		/// </summary>
		PS_DASH             = 1 ,      /* -------  */
		/// <summary>
		/// The pen is dotted. This style is valid only when the pen width is one or less in device units.
		/// </summary>
		PS_DOT              = 2 ,      /* .......  */
		/// <summary>
		/// The pen has alternating dashes and dots. This style is valid only when the pen width is one or less in device units.
		/// </summary>
		PS_DASHDOT          = 3 ,      /* _._._._  */
		/// <summary>
		/// The pen has alternating dashes and double dots. This style is valid only when the pen width is one or less in device units.
		/// </summary>
		PS_DASHDOTDOT       = 4 ,      /* _.._.._  */
		/// <summary>
		/// The pen is invisible.
		/// </summary>
		PS_NULL             = 5 ,
		/// <summary>
		/// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle, the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen. This applies only to geometric pens.
		/// </summary>
		PS_INSIDEFRAME      = 6 
	}

	/// <summary>
	/// ����GDI�Ļ��ʶ���
	/// </summary>
	public class GDIPen : GDIObject
	{
		/// <summary>
		/// �յĻ��ʶ���
		/// </summary>
		public static readonly GDIPen NullPen = new GDIPen( PenStyle.PS_NULL , 1 , System.Drawing.Color.Black );

		/// <summary>
		/// ��ʼ��һ��ָ����ɫ�Ŀ��Ϊ1��ʵ�߻��ʶ���
		/// </summary>
		/// <param name="color">��ɫ</param>
		public GDIPen( System.Drawing.Color color ): this( PenStyle.PS_SOLID , 1 , color )
		{
		}
		/// <summary>
		/// ��ʼ�����󣬴���һ��ʵ�߻���
		/// </summary>
		/// <param name="width">�߿�</param>
		/// <param name="color">��ɫ</param>
		public GDIPen( int width , System.Drawing.Color color ) : this( PenStyle.PS_SOLID , width , color)
		{
		}
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="style">��������</param>
		/// <param name="width">�߿�</param>
		/// <param name="color">��ɫ</param>
		public GDIPen( PenStyle style , int width , System.Drawing.Color color )
		{
			intStyle = style ;
			this.intWidth = width ;
			this.intColor = color ;
			this.intHandle = CreatePen( ( int ) intStyle , intWidth , ColorToInt( color ));
		}

		private PenStyle intStyle = PenStyle.PS_SOLID  ;
		/// <summary>
		/// ������ʽ
		/// </summary>
		public PenStyle Style
		{
			get{ return intStyle ;}
			set
			{
				if( intStyle != value )
				{
					intStyle = value ;
					this.Dispose();
					this.intHandle = CreatePen( ( int ) intStyle , intWidth , ColorToInt( this.intColor ));
				}
			}
		}
		private int intWidth = 1 ;
		/// <summary>
		/// �������
		/// </summary>
		public int Width
		{
			get{ return intWidth ;}
		}
		private System.Drawing.Color intColor = System.Drawing.Color.Black ;
		/// <summary>
		/// ��ɫ
		/// </summary>
		public System.Drawing.Color Color
		{
			get{ return intColor ;}
			set
			{
				if( intColor != value )
				{
					intColor = value ;
					this.Dispose();
					this.intHandle = CreatePen( ( int ) intStyle , intWidth , ColorToInt( intColor ));
				}
			}
		}

		/// <summary>
		/// ��һ���豸�����Ļ����߶�
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <param name="x1">���X����</param>
		/// <param name="y1">���Y����</param>
		/// <param name="x2">�յ�X����</param>
		/// <param name="y2">�յ�Y����</param>
		public void DrawLine( IntPtr hdc , int x1 , int y1 , int x2 , int y2 )
		{
			IntPtr h = this.SelectTo( hdc );
			MoveToEx( hdc , x1 , y1 , 0 );
			LineTo( hdc , x2 , y2 );
			if( h.ToInt32() != 0 )
			{
				this.UnSelect( hdc , h );
			}
		}
		/// <summary>
		/// ��һ���豸�������ϻ��ƶ����߶�
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <param name="ps">������</param>
		public void DrawLines( IntPtr hdc , System.Drawing.Point[] ps )
		{
			IntPtr h = this.SelectTo( hdc );
			POINT[] ps2 = new POINT[ ps.Length ];
			for( int iCount = 0 ; iCount < ps.Length ; iCount ++ )
			{
				ps2[iCount].x = ps[ iCount ].X ;
				ps2[iCount].y = ps[ iCount ].Y ;
			}
			Polyline( hdc , ps2 , ps2.Length );
			if( h.ToInt32() != 0 )
			{
				this.UnSelect( hdc , h );
			}
		}

		/// <summary>
		/// ��һ���豸�����Ļ����߶�
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <param name="p1">�������</param>
		/// <param name="p2">�յ�����</param>
		public void DrawLine( IntPtr hdc , System.Drawing.Point p1 , System.Drawing.Point p2 )
		{
			DrawLine( hdc , p1.X , p1.Y , p2.X , p2.Y );
		}

		#region ����Win32API���� ******************************************************************
		
		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr CreatePen( int PenStyle , int Width , int Color );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern bool LineTo( System.IntPtr hDC , int X , int Y );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern bool Polyline( System.IntPtr hDC , POINT[] ps , int len );

		[StructLayout(LayoutKind.Sequential)]
		private struct POINT
		{
			public int x;
			public int y;
		}

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern bool MoveToEx ( System.IntPtr hDC , int X , int Y , int lpPoint );

		#endregion

 	}//public class GDIPen : GDIObject
}
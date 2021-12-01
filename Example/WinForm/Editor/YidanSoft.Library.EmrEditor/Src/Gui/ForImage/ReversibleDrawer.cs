using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// 绘制可逆图形的对象
	/// </summary>
	public class ReversibleDrawer : DeviceContextBase
	{
		/// <summary>
		/// 从一个窗体句柄创建一个对象
		/// </summary>
		/// <param name="hwnd">窗体句柄</param>
		/// <returns>创建的对象</returns>
		public static ReversibleDrawer FromHwnd( IntPtr hwnd )
		{
			ReversibleDrawer rd = new ReversibleDrawer();
			rd.InitFromHWnd( hwnd );
			return rd ;
		}
		/// <summary>
		/// 从一个设备上下文句柄创建对象
		/// </summary>
		/// <param name="hdc">设备上下文句柄</param>
		/// <returns>创建的对象</returns>
		public static ReversibleDrawer FromHDC( IntPtr hdc )
		{
			ReversibleDrawer rd = new ReversibleDrawer();
			rd.InitFromHDC( hdc );
			return rd ;
		}

		/// <summary>
		/// 从计算机屏幕上创建对象
		/// </summary>
		/// <returns>创建的对象</returns>
		public static ReversibleDrawer FromScreen()
		{
			ReversibleDrawer rd = new ReversibleDrawer();
			rd.InitFromHWnd( new IntPtr( 0 ) );
			return rd ;
		}

		/// <summary>
		/// 无作为的初始化对象
		/// </summary>
		private ReversibleDrawer()
		{
		}

		/// <summary>
		/// 根据图形对象初始化对象
		/// </summary>
		/// <param name="g">图形对象</param>
		public ReversibleDrawer( System.Drawing.Graphics g )
		{
			this.InitFromGraphics( g );
		}

		private int intLineWidth = 1 ;
		/// <summary>
		/// 线宽
		/// </summary>
		public int LineWidth
		{
			get
			{
				return intLineWidth ;
			}
			set
			{
				if( intLineWidth != value && value > 0 )
				{
					intLineWidth = value;
					myPen.Dispose();
					myPen = new GDIPen( intLineWidth , System.Drawing.Color.Black );
				}
			}
		}

		private int intOldReversible = 0 ;
		/// <summary>
		/// 开始进行可逆绘制
		/// </summary>
		public void BeginReversible()
		{
			intOldReversible = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_NOT );
		}
		/// <summary>
		/// 结束进行可逆绘制
		/// </summary>
		public void EndReversible()
		{
			SetROP2( this.intHDC , intOldReversible );
		}

		/// <summary>
		/// 绘制可逆线段
		/// </summary>
		/// <param name="x1">线段起点X坐标</param>
		/// <param name="y1">线段起点Y坐标</param>
		/// <param name="x2">线段终点X坐标</param>
		/// <param name="y2">>线段终点Y坐标</param>
		public void DrawLine( int x1 , int y1 , int x2 , int y2 )
		{
			int old = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_NOT );
			myPen.DrawLine( this.intHDC , x1 , y1 , x2 , y2 );
			SetROP2( intHDC , old );
		}

		/// <summary>
		/// 绘制多条可逆线段
		/// </summary>
		/// <param name="ps">线段的点数组</param>
		public void DrawLines( System.Drawing.Point[] ps )
		{
			int old = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_NOT );
			myPen.DrawLines( this.intHDC , ps ) ;
			SetROP2( intHDC , old );
		}

		/// <summary>
		/// 绘制可逆线段
		/// </summary>
		/// <param name="p1">线段起点坐标</param>
		/// <param name="p2">线段终点坐标</param>
		public void DrawLine( System.Drawing.Point p1 , System.Drawing.Point p2 )
		{
			DrawLine( p1.X , p1.Y , p2.X , p2.Y );
		}
		/// <summary>
		/// 绘制可逆矩形
		/// </summary>
		/// <param name="left">矩形左端位置</param>
		/// <param name="top">矩形顶端位置</param>
		/// <param name="width">矩形宽度</param>
		/// <param name="height">矩形高度</param>
		public void DrawRectangle( int left , int top , int width , int height )
		{
			int old = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_XORPEN );

			IntPtr oldb = this.SelectObject( StockObject.NULL_BRUSH );
			IntPtr oldp = this.SelectObject( myPen.Handle );

			Rectangle( intHDC , left , top , left + width , top + height );

			SelectObject( oldb );
			SelectObject( oldp );
			
			SetROP2( intHDC , old );
		}
		/// <summary>
		/// 绘制可逆矩形
		/// </summary>
		/// <param name="rect">矩形区域</param>
		public void DrawRectangle( System.Drawing.Rectangle rect )
		{
			DrawRectangle( rect.Left , rect.Top , rect.Width , rect.Height );
		}

		/// <summary>
		/// 填充可逆矩形
		/// </summary>
		/// <param name="left">矩形左端位置</param>
		/// <param name="top">矩形顶端位置</param>
		/// <param name="width">矩形宽度</param>
		/// <param name="height">矩形高度</param>
		public void FillRectangle( int left , int top , int width , int height )
		{
			RECT rc = new RECT();
			rc.left = left ;
			rc.top = top ;
			rc.right = left + width ;
			rc.bottom = top + height ;
			InvertRect( this.intHDC , ref rc );
		}
		/// <summary>
		/// 填充可逆矩形
		/// </summary>
		/// <param name="rect">矩形区域</param>
		public void FillRectangle( System.Drawing.Rectangle rect )
		{
			FillRectangle( rect.Left , rect.Top , rect.Width , rect.Height );
		}
		/// <summary>
		/// 销毁对象
		/// </summary>
		public override void Dispose()
		{
			base.Dispose ();
			if( myPen != null )
			{
				myPen.Dispose();
				myPen = null;
			}
		}
		/// <summary>
		/// 线条样式
		/// </summary>
		public PenStyle PenStyle
		{
			get{ return myPen.Style ;}
			set{ myPen.Style = value;}
		}
		/// <summary>
		/// 线条颜色
		/// </summary>
		public System.Drawing.Color PenColor
		{
			get{ return myPen.Color ;}
			set{ myPen.Color = value;}
		}

		#region 内部代码 ***********************************************************************

		private GDIPen myPen = new GDIPen( System.Drawing.Color.Black );

		/// <summary>
		/// 图形设备上下文字节运算掩码
		/// </summary>
		private enum DCRasterOperations
		{
			R2_BLACK            = 1   , /*  0       */
			R2_NOTMERGEPEN      = 2   , /* DPon     */
			R2_MASKNOTPEN       = 3   , /* DPna     */
			R2_NOTCOPYPEN       = 4   , /* PN       */
			R2_MASKPENNOT       = 5   , /* PDna     */
			R2_NOT              = 6   , /* Dn       */
			R2_XORPEN           = 7   , /* DPx      */
			R2_NOTMASKPEN       = 8   , /* DPan     */
			R2_MASKPEN          = 9   , /* DPa      */
			R2_NOTXORPEN        = 10  , /* DPxn     */
			R2_NOP              = 11  , /* D        */
			R2_MERGENOTPEN      = 12  , /* DPno     */
			R2_COPYPEN          = 13  , /* P        */
			R2_MERGEPENNOT      = 14  , /* PDno     */
			R2_MERGEPEN         = 15  , /* DPo      */
			R2_WHITE            = 16  , /*  1       */
			R2_LAST             = 16
		}

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern int SetROP2( System.IntPtr hDC , int DrawMode );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern bool LineTo( System.IntPtr hDC , int X , int Y );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern bool MoveToEx ( System.IntPtr hDC , int X , int Y , int lpPoint );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool Rectangle ( System.IntPtr hDC , int left , int top , int right , int bottom );

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		private static extern int InvertRect( IntPtr hdc , ref RECT vRect );

		[StructLayout(LayoutKind.Sequential)]
		private struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		#endregion

	}//public class ReversibleDrawer : DeviceContextBase
}
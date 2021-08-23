using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// ���ƿ���ͼ�εĶ���
	/// </summary>
	public class ReversibleDrawer : DeviceContextBase
	{
		/// <summary>
		/// ��һ������������һ������
		/// </summary>
		/// <param name="hwnd">������</param>
		/// <returns>�����Ķ���</returns>
		public static ReversibleDrawer FromHwnd( IntPtr hwnd )
		{
			ReversibleDrawer rd = new ReversibleDrawer();
			rd.InitFromHWnd( hwnd );
			return rd ;
		}
		/// <summary>
		/// ��һ���豸�����ľ����������
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <returns>�����Ķ���</returns>
		public static ReversibleDrawer FromHDC( IntPtr hdc )
		{
			ReversibleDrawer rd = new ReversibleDrawer();
			rd.InitFromHDC( hdc );
			return rd ;
		}

		/// <summary>
		/// �Ӽ������Ļ�ϴ�������
		/// </summary>
		/// <returns>�����Ķ���</returns>
		public static ReversibleDrawer FromScreen()
		{
			ReversibleDrawer rd = new ReversibleDrawer();
			rd.InitFromHWnd( new IntPtr( 0 ) );
			return rd ;
		}

		/// <summary>
		/// ����Ϊ�ĳ�ʼ������
		/// </summary>
		private ReversibleDrawer()
		{
		}

		/// <summary>
		/// ����ͼ�ζ����ʼ������
		/// </summary>
		/// <param name="g">ͼ�ζ���</param>
		public ReversibleDrawer( System.Drawing.Graphics g )
		{
			this.InitFromGraphics( g );
		}

		private int intLineWidth = 1 ;
		/// <summary>
		/// �߿�
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
		/// ��ʼ���п������
		/// </summary>
		public void BeginReversible()
		{
			intOldReversible = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_NOT );
		}
		/// <summary>
		/// �������п������
		/// </summary>
		public void EndReversible()
		{
			SetROP2( this.intHDC , intOldReversible );
		}

		/// <summary>
		/// ���ƿ����߶�
		/// </summary>
		/// <param name="x1">�߶����X����</param>
		/// <param name="y1">�߶����Y����</param>
		/// <param name="x2">�߶��յ�X����</param>
		/// <param name="y2">>�߶��յ�Y����</param>
		public void DrawLine( int x1 , int y1 , int x2 , int y2 )
		{
			int old = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_NOT );
			myPen.DrawLine( this.intHDC , x1 , y1 , x2 , y2 );
			SetROP2( intHDC , old );
		}

		/// <summary>
		/// ���ƶ��������߶�
		/// </summary>
		/// <param name="ps">�߶εĵ�����</param>
		public void DrawLines( System.Drawing.Point[] ps )
		{
			int old = SetROP2( this.intHDC , ( int ) DCRasterOperations.R2_NOT );
			myPen.DrawLines( this.intHDC , ps ) ;
			SetROP2( intHDC , old );
		}

		/// <summary>
		/// ���ƿ����߶�
		/// </summary>
		/// <param name="p1">�߶��������</param>
		/// <param name="p2">�߶��յ�����</param>
		public void DrawLine( System.Drawing.Point p1 , System.Drawing.Point p2 )
		{
			DrawLine( p1.X , p1.Y , p2.X , p2.Y );
		}
		/// <summary>
		/// ���ƿ������
		/// </summary>
		/// <param name="left">�������λ��</param>
		/// <param name="top">���ζ���λ��</param>
		/// <param name="width">���ο��</param>
		/// <param name="height">���θ߶�</param>
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
		/// ���ƿ������
		/// </summary>
		/// <param name="rect">��������</param>
		public void DrawRectangle( System.Drawing.Rectangle rect )
		{
			DrawRectangle( rect.Left , rect.Top , rect.Width , rect.Height );
		}

		/// <summary>
		/// ���������
		/// </summary>
		/// <param name="left">�������λ��</param>
		/// <param name="top">���ζ���λ��</param>
		/// <param name="width">���ο��</param>
		/// <param name="height">���θ߶�</param>
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
		/// ���������
		/// </summary>
		/// <param name="rect">��������</param>
		public void FillRectangle( System.Drawing.Rectangle rect )
		{
			FillRectangle( rect.Left , rect.Top , rect.Width , rect.Height );
		}
		/// <summary>
		/// ���ٶ���
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
		/// ������ʽ
		/// </summary>
		public PenStyle PenStyle
		{
			get{ return myPen.Style ;}
			set{ myPen.Style = value;}
		}
		/// <summary>
		/// ������ɫ
		/// </summary>
		public System.Drawing.Color PenColor
		{
			get{ return myPen.Color ;}
			set{ myPen.Color = value;}
		}

		#region �ڲ����� ***********************************************************************

		private GDIPen myPen = new GDIPen( System.Drawing.Color.Black );

		/// <summary>
		/// ͼ���豸�������ֽ���������
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
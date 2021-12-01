using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// �豸�����Ļ�������
	/// </summary>
	public class DeviceContextBase : System.IDisposable
	{
		/// <summary>
		/// ʹ��һ���豸�����ľ����ʼ������
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		protected void InitFromHDC( IntPtr hdc )
		{
			intHDC = hdc ;
			InitMode = 0 ;
		}
		/// <summary>
		/// ʹ��һ����������ʼ������
		/// </summary>
		/// <param name="hwnd">������</param>
		protected void InitFromHWnd( IntPtr hwnd )
		{
			intHwnd = hwnd ;
			intHDC = GetDC( hwnd );
			InitMode = 1;
		}
		/// <summary>
		/// ʹ��һ����ͼ�����ʼ������
		/// </summary>
		/// <param name="g">��ͼ����</param>
		protected void InitFromGraphics( System.Drawing.Graphics g )
		{
			intHDC = g.GetHdc() ;
			myGraphics = g ;
			InitMode = 2 ;
		}

		/// <summary>
		/// ʹ��һ���豸���Ƴ�ʼ������
		/// </summary>
		/// <param name="strDriver">�豸����</param>
		protected void InitFromDriverName( string strDriver )
		{
			intHDC =  CreateDC( strDriver , null , 0 , 0 );
			InitMode = 3 ;
		}

		/// <summary>
		/// ��ʼ��һ�����ݵ��豸������
		/// </summary>
		/// <param name="hdc">�����ľ��</param>
		protected void InitCompatibleDC( IntPtr hdc )
		{
			intHDC = CreateCompatibleDC( hdc );
			InitMode = 4 ;
		}

		/// <summary>
		/// �豸�����ľ��
		/// </summary>
		protected System.IntPtr intHDC = IntPtr.Zero ;
		private int InitMode = 0 ;
		private System.Drawing.Graphics myGraphics = null;
		private IntPtr intHwnd = IntPtr.Zero  ;

		/// <summary>
		/// �豸�����ľ��
		/// </summary>
		public IntPtr HDC
		{
			get{ return intHDC ;}
		}

		/// <summary>
		/// ���Ķ���
		/// </summary>
		public virtual void Dispose()
		{
			if( intHDC != IntPtr.Zero )
			{
				if( InitMode == 1 )
				{
					ReleaseDC( intHwnd , intHDC );
				}
				if( InitMode == 2 )
				{
					myGraphics.ReleaseHdc( intHDC );
				}
				if( InitMode == 3 )
				{
					DeleteDC( intHDC );
				}
				if( InitMode == 4 )
				{
					DeleteDC( intHDC );
				}
			}
			intHDC = IntPtr.Zero  ;
			intHwnd = IntPtr.Zero  ;
			InitMode = 0 ;
			myGraphics = null;
		}

		/// <summary>
		/// ѡ�����
		/// </summary>
		/// <param name="obj">�¶���ľ��</param>
		/// <returns>�滻�Ķ���ľ��</returns>
		public IntPtr SelectObject( IntPtr obj )
		{
			return SelectObject( this.intHDC , obj );
		}

		#region ����Win32API���� ******************************************************************

		[System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern bool DeleteDC(IntPtr hDC);

		[System.Runtime.InteropServices.DllImport("User32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[System.Runtime.InteropServices.DllImport("User32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern IntPtr GetDC(IntPtr hWnd);

		[System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern IntPtr CreateDC( string strDriver , string strDevice , int Output , int InitData );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SelectObject(System.IntPtr hDC, System.IntPtr hObject);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr CreateCompatibleDC(System.IntPtr hDC);

		#endregion

	}//public class DeviceContextBase : System.IDisposable
}
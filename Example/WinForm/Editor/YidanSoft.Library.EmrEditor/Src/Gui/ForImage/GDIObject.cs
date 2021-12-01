using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// GDI���������
	/// </summary>
	public abstract class GDIObject : System.IDisposable
	{
		/// <summary>
		/// ������
		/// </summary>
		protected System.IntPtr intHandle = IntPtr.Zero ;
		/// <summary>
		/// ������
		/// </summary>
		public System.IntPtr Handle
		{
			get{ return intHandle ;}
		}
		/// <summary>
		/// ���ٶ���
		/// </summary>
		public virtual void Dispose()
		{
			if( intHandle.ToInt32() != 0)
			{
				DeleteObject( intHandle );
				intHandle = IntPtr.Zero ;
			}
		}
		/// <summary>
		/// ѡ�����һ���豸������
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <returns>�滻�Ķ���ľ��</returns>
		public IntPtr SelectTo( IntPtr hdc )
		{
			return SelectObject( hdc , intHandle );
		}

		/// <summary>
		/// ѡ�����һ���豸������
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <returns>�滻�Ķ���ľ��</returns>
		public IntPtr SelectTo( int hdc )
		{
			return SelectObject( new IntPtr( hdc ) , intHandle );
		}

		/// <summary>
		/// ȡ��ѡ������豸������
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <param name="handle">�滻�Ķ���ľ��</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public bool UnSelect( IntPtr hdc , IntPtr handle )
		{
			IntPtr h = SelectObject( hdc , handle );
			return h == this.intHandle ;
		}

		/// <summary>
		/// ȡ��ѡ������豸������
		/// </summary>
		/// <param name="hdc">�豸�����ľ��</param>
		/// <param name="handle">�滻�Ķ���ľ��</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public bool UnSelect( int hdc , IntPtr handle )
		{
			IntPtr h = SelectObject( new IntPtr( hdc ) , handle );
			return h == this.intHandle ;
		}

		/// <summary>
		/// ����ɫֵת��Ϊ����ֵ
		/// </summary>
		/// <param name="color">��ɫֵ</param>
		/// <returns>����ֵ</returns>
		protected int ColorToInt(System.Drawing.Color color)
		{
			return (color.B << 16 | color.G << 8 | color.R);
		}

		/// <summary>
		/// ������ֵת��Ϊ��ɫֵ
		/// </summary>
		/// <param name="color">����ֵ</param>
		/// <returns>��ɫֵ</returns>
		protected System.Drawing.Color IntToColor(int color)
		{
			int b = (color >> 16) & 0xFF;
			int g = (color >> 8) & 0xFF;
			int r = (color) & 0xFF;
			return System.Drawing.Color.FromArgb(r, g, b);
		}

		#region ����Win32API���� ******************************************************************
		
		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern int DeleteObject(System.IntPtr hObject);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SelectObject(System.IntPtr hDC, System.IntPtr hObject);

		#endregion
	}//public abstract class BGDIObject : System.IDisposable
}
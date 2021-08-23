using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// GDI对象基础类
	/// </summary>
	public abstract class GDIObject : System.IDisposable
	{
		/// <summary>
		/// 对象句柄
		/// </summary>
		protected System.IntPtr intHandle = IntPtr.Zero ;
		/// <summary>
		/// 对象句柄
		/// </summary>
		public System.IntPtr Handle
		{
			get{ return intHandle ;}
		}
		/// <summary>
		/// 销毁对象
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
		/// 选择对象到一个设备上下文
		/// </summary>
		/// <param name="hdc">设备上下文句柄</param>
		/// <returns>替换的对象的句柄</returns>
		public IntPtr SelectTo( IntPtr hdc )
		{
			return SelectObject( hdc , intHandle );
		}

		/// <summary>
		/// 选择对象到一个设备上下文
		/// </summary>
		/// <param name="hdc">设备上下文句柄</param>
		/// <returns>替换的对象的句柄</returns>
		public IntPtr SelectTo( int hdc )
		{
			return SelectObject( new IntPtr( hdc ) , intHandle );
		}

		/// <summary>
		/// 取消选择对象到设备上下文
		/// </summary>
		/// <param name="hdc">设备上下文句柄</param>
		/// <param name="handle">替换的对象的句柄</param>
		/// <returns>操作是否成功</returns>
		public bool UnSelect( IntPtr hdc , IntPtr handle )
		{
			IntPtr h = SelectObject( hdc , handle );
			return h == this.intHandle ;
		}

		/// <summary>
		/// 取消选择对象到设备上下文
		/// </summary>
		/// <param name="hdc">设备上下文句柄</param>
		/// <param name="handle">替换的对象的句柄</param>
		/// <returns>操作是否成功</returns>
		public bool UnSelect( int hdc , IntPtr handle )
		{
			IntPtr h = SelectObject( new IntPtr( hdc ) , handle );
			return h == this.intHandle ;
		}

		/// <summary>
		/// 将颜色值转换为整数值
		/// </summary>
		/// <param name="color">颜色值</param>
		/// <returns>整数值</returns>
		protected int ColorToInt(System.Drawing.Color color)
		{
			return (color.B << 16 | color.G << 8 | color.R);
		}

		/// <summary>
		/// 将整数值转换为颜色值
		/// </summary>
		/// <param name="color">整数值</param>
		/// <returns>颜色值</returns>
		protected System.Drawing.Color IntToColor(int color)
		{
			int b = (color >> 16) & 0xFF;
			int g = (color >> 8) & 0xFF;
			int r = (color) & 0xFF;
			return System.Drawing.Color.FromArgb(r, g, b);
		}

		#region 声明Win32API函数 ******************************************************************
		
		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern int DeleteObject(System.IntPtr hObject);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SelectObject(System.IntPtr hDC, System.IntPtr hObject);

		#endregion
	}//public abstract class BGDIObject : System.IDisposable
}
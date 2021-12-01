using System;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
	/// <summary>
	/// 分页线信息
	/// </summary>
	public class PageLineInfo
	{
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="vFirstPos">第一个分页线位置</param>
		/// <param name="vLastPos">上一个分页线位置</param>
		public PageLineInfo( int vFirstPos , int vLastPos , int vPos , int vPageIndex )
		{
			intFirstPos = vFirstPos ;
			intLastPos = vLastPos ;
			intPos = vPos ;
			intPageIndex = vPageIndex ;
		}
		private int intMinPageHeight = 0 ;
		internal int MinPageHeight
		{
			get{ return intMinPageHeight ;}
			set{ intMinPageHeight = value;}
		}
		private int intPageIndex = 0 ;
		/// <summary>
		/// 当前处理的页号
		/// </summary>
		public int PageIndex
		{
			get{ return intPageIndex ;}
		}
		private int intFirstPos = 0 ;
		/// <summary>
		/// 第一个分页线位置
		/// </summary>
		public int FirstPos
		{
			get{ return intFirstPos ;}
		}

		private int intLastPos = 0 ;
		/// <summary>
		/// 上一个分页线位置
		/// </summary>
		public int LastPos
		{
			get{ return intLastPos ;}
		}

		public bool CanSet( int vPos )
		{
			if( vPos > intLastPos && vPos < intPos )
			{
				if( intMinPageHeight > 0 )
				{
					if( vPos - intLastPos < intMinPageHeight )
						return false;
				}
				return true;
			}
			return false ;
		}

		private int intPos = 0 ;
		/// <summary>
		/// 当前分页线位置
		/// </summary>
		public int Pos
		{
			get{ return intPos ;}
			set
			{
				if( value > intLastPos && value < intPos )
				{
					if( intMinPageHeight > 0 )
					{
						if( value - intLastPos < intMinPageHeight )
							return ;
					}
					intPos = value;
					bolModified = true;
				}
			}
		}
		private bool bolModified = false;
		/// <summary>
		/// 当前分页线位置是否改变标记
		/// </summary>
		public bool Modified
		{
			get{ return bolModified ;}
			set{ bolModified = value;}
		}
		/// <summary>
		/// 分页线是否在指定的区域中
		/// </summary>
		/// <param name="Top">顶端位置</param>
		/// <param name="Bottom">低端位置</param>
		/// <returns>是否在指定的区域中</returns>
		public bool Match( int Top , int Bottom )
		{
			return intPos >= Top && intPos < Bottom ;
		}
		/// <summary>
		/// 分页线是否在指定的区域中
		/// </summary>
		/// <param name="rect">区域矩形</param>
		/// <returns>是否在指定的区域中</returns>
		public bool Match( System.Drawing.Rectangle rect )
		{
			return intPos >= rect.Top && intPos < rect.Bottom ;
		}
	}//public class PageLineInfo
}
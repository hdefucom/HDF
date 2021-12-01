using System;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
	/// <summary>
	/// ��ҳ����Ϣ
	/// </summary>
	public class PageLineInfo
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="vFirstPos">��һ����ҳ��λ��</param>
		/// <param name="vLastPos">��һ����ҳ��λ��</param>
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
		/// ��ǰ�����ҳ��
		/// </summary>
		public int PageIndex
		{
			get{ return intPageIndex ;}
		}
		private int intFirstPos = 0 ;
		/// <summary>
		/// ��һ����ҳ��λ��
		/// </summary>
		public int FirstPos
		{
			get{ return intFirstPos ;}
		}

		private int intLastPos = 0 ;
		/// <summary>
		/// ��һ����ҳ��λ��
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
		/// ��ǰ��ҳ��λ��
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
		/// ��ǰ��ҳ��λ���Ƿ�ı���
		/// </summary>
		public bool Modified
		{
			get{ return bolModified ;}
			set{ bolModified = value;}
		}
		/// <summary>
		/// ��ҳ���Ƿ���ָ����������
		/// </summary>
		/// <param name="Top">����λ��</param>
		/// <param name="Bottom">�Ͷ�λ��</param>
		/// <returns>�Ƿ���ָ����������</returns>
		public bool Match( int Top , int Bottom )
		{
			return intPos >= Top && intPos < Bottom ;
		}
		/// <summary>
		/// ��ҳ���Ƿ���ָ����������
		/// </summary>
		/// <param name="rect">�������</param>
		/// <returns>�Ƿ���ָ����������</returns>
		public bool Match( System.Drawing.Rectangle rect )
		{
			return intPos >= rect.Top && intPos < rect.Bottom ;
		}
	}//public class PageLineInfo
}
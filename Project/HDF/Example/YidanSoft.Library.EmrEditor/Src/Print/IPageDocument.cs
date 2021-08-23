using System;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
	/// <summary>
	/// ֧�ַ�ҳ��ʾ���ĵ��ӿ�����
	/// </summary>
	public interface IPageDocument
	{
		/// <summary>
		/// �ĵ�ʹ�õĻ�ͼ��λ
		/// </summary>
		System.Drawing.GraphicsUnit DocumentGraphicsUnit
		{
			get ;
			set ;
		}
		/// <summary>
		/// ҳ����󼯺�
		/// </summary>
		PrintPageCollection Pages
		{
			get ;
			set ;
		}

		/// <summary>
		/// ��ǰ��ӡ��ҳ�����
		/// </summary>
		int PageIndex
		{
			get ;
			set ;
		}
		/// <summary>
		/// �����ĵ�
		/// </summary>
		/// <param name="g">ͼ�λ��ƶ���</param>
		/// <param name="ClipRectangle">���о���</param>
		void DrawDocument( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRectangle );
		/// <summary>
		/// ����ҳü
		/// </summary>
		/// <param name="g">ͼ�λ��ƶ���</param>
		/// <param name="ClipRectangle">���о���</param>
		void DrawHead( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRectangle );
		/// <summary>
		/// ����ҳ��
		/// </summary>
		/// <param name="g">ͼ�λ��ƶ���</param>
		/// <param name="ClipRectangle">���о���</param>
		void DrawFooter( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRectangle );
	}//public interface IPageDocument
}
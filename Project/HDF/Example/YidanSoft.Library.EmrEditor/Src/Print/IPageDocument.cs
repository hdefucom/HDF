using System;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
	/// <summary>
	/// 支持分页显示的文档接口类型
	/// </summary>
	public interface IPageDocument
	{
		/// <summary>
		/// 文档使用的绘图单位
		/// </summary>
		System.Drawing.GraphicsUnit DocumentGraphicsUnit
		{
			get ;
			set ;
		}
		/// <summary>
		/// 页面对象集合
		/// </summary>
		PrintPageCollection Pages
		{
			get ;
			set ;
		}

		/// <summary>
		/// 当前打印的页面序号
		/// </summary>
		int PageIndex
		{
			get ;
			set ;
		}
		/// <summary>
		/// 绘制文档
		/// </summary>
		/// <param name="g">图形绘制对象</param>
		/// <param name="ClipRectangle">剪切矩形</param>
		void DrawDocument( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRectangle );
		/// <summary>
		/// 绘制页眉
		/// </summary>
		/// <param name="g">图形绘制对象</param>
		/// <param name="ClipRectangle">剪切矩形</param>
		void DrawHead( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRectangle );
		/// <summary>
		/// 绘制页脚
		/// </summary>
		/// <param name="g">图形绘制对象</param>
		/// <param name="ClipRectangle">剪切矩形</param>
		void DrawFooter( System.Drawing.Graphics g , System.Drawing.Rectangle ClipRectangle );
	}//public interface IPageDocument
}
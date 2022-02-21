using DCSoft.Common;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表示文档中图像
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	
	public interface IDocumentImage
	{
		/// <summary>
		///       标记
		///       </summary>
		
		DocumentImageFlags ImageFlags
		{
			get;
		}

		/// <summary>
		///       获得对象推荐的大小
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>推荐的大小</returns>
		
		SizeF GetPreferredSize(DocumentPaintEventArgs args);

		/// <summary>
		///       绘制图片内容
		///       </summary>
		/// <param name="args">
		/// </param>
		
		void Draw(DocumentPaintEventArgs args);
	}
}

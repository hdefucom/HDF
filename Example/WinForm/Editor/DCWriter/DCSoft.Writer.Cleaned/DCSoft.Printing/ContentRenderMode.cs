using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public enum ContentRenderMode
	{
		/// <summary>
		///       在用户界面上绘制图形
		///       </summary>
		UIPaint,
		/// <summary>
		///       打印
		///       </summary>
		Print,
		/// <summary>
		///       已阅读模式绘制图形
		///       </summary>
		ReadPaint,
		/// <summary>
		///       生成元素图片
		///       </summary>
		GenerateElementImage
	}
}

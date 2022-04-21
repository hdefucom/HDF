using DCSoft.Common;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       支持分页显示的文档接口类型
	///       </summary>
	[ComVisible(false)]
	
	
	public interface IPageDocument
	{
		/// <summary>
		///       页面设置信息对象
		///       </summary>
		XPageSettings PageSettings
		{
			get;
			set;
		}

		/// <summary>
		///       文档使用的绘图单位
		///       </summary>
		[ComVisible(false)]
		GraphicsUnit DocumentGraphicsUnit
		{
			get;
			set;
		}

		/// <summary>
		///       页面对象集合
		///       </summary>
		PrintPageCollection Pages
		{
			get;
			set;
		}

		/// <summary>
		///       获得续打线位置
		///       </summary>
		/// <param name="pos">原始设置的续打线位置</param>
		/// <returns>修正后的续打线位置信息</returns>
		JumpPrintInfo GetJumpPrintInfo(float float_0);

		/// <summary>
		///       绘制文档内容
		///       </summary>
		/// <param name="args">事件参数</param>
		void DrawContent(PageDocumentPaintEventArgs args);
	}
}

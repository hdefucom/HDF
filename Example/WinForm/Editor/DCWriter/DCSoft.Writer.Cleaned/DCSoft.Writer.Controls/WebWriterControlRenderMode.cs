using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       WEB控件内容呈现模式
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public enum WebWriterControlRenderMode
	{
		/// <summary>
		///       已图片方式分页显示
		///       </summary>
		PageImage,
		/// <summary>
		///       正常的HTML方式
		///       </summary>
		NormalHtml,
		/// <summary>
		///       正常的HTML方式，带有换行设置
		///       </summary>
		NormalHtmlKeepLinebreak,
		/// <summary>
		///       分页预览HTML模式
		///       </summary>
		PagePreviewHtml,
		/// <summary>
		///       ActiveX控件的形式
		///       </summary>
		ActiveXControl,
		/// <summary>
		///       ActiveX的打印预览控件
		///       </summary>
		AxPrintPreviewControl,
		/// <summary>
		///       NsoControl形式
		///       </summary>
		NsoControl,
		/// <summary>
		///       可编辑的正常HTML方式
		///       </summary>
		NormalHtmlEditable
	}
}

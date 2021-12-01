using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页码信息类型
	///       </summary>
	[DocumentComment]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[ComVisible(true)]
	[Guid("3612109D-856D-47E7-96A9-1350245AB061")]
	public enum PageInfoValueType
	{
		/// <summary>
		///       从1开始计算的页码
		///       </summary>
		[DCDescription(typeof(PageInfoValueType), "PageIndex")]
		PageIndex,
		/// <summary>
		///       文档总页数
		///       </summary>
		[DCDescription(typeof(PageInfoValueType), "NumOfPages")]
		NumOfPages,
		/// <summary>
		///       在本文档中的从1开始计算的页码数
		///       </summary>
		/// <remarks>
		///       当在一个打印预览控件中显示多个文档，或者批量打印文档时，该页码数就是该页
		///       在文档中的页码数，而不是所有文档的文档页集合在一起时的页码数。
		///       </remarks>
		[DCDescription(typeof(PageInfoValueType), "LocalPageIndex")]
		LocalPageIndex,
		/// <summary>
		///       在本文档中的文档总页数
		///       </summary>
		[DCDescription(typeof(PageInfoValueType), "LocalNumOfPages")]
		LocalNumOfPages
	}
}

using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       比较两个表格行对象的接口
	///       </summary>
	[Guid("1BF4326F-88E9-48AD-8D8E-15571D01B09F")]
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(false)]
	public interface IDCTableRowComparer
	{
		[DispId(1)]
		int CompareTableRow(XTextTableRowElement row1, XTextTableRowElement row2);
	}
}

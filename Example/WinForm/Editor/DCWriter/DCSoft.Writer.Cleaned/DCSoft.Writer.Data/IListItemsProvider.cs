using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识库节点下拉列表项目提供者
	///       </summary>
	
	[ComVisible(false)]
	
	[Guid("00012345-6789-ABCD-EF01-234567890025")]
	public interface IListItemsProvider
	{
		/// <summary>
		///       获得列表项目
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>获得的列表项目集合</returns>
		ListItemCollection GetListItems(ListItemsEventArgs args);
	}
}

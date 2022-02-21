using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       用于获得列表项目的提供者接口
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	
	[ComVisible(false)]
	[Obsolete("!!!请使用WriterControl.OnQueryListItems事件")]
	[Guid("00012345-6789-ABCD-EF01-234567890026")]
	public interface IListSourceProvider
	{
		/// <summary>
		///       获得列表数据来源
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>列表数据</returns>
		object GetListSource(ListSourceEventArgs args);

		/// <summary>
		///       获得列表项目显示的文本
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>显示的文本</returns>
		string GetDisplayText(ListSourceEventArgs args);

		/// <summary>
		///       获得列表项目的后台文本值
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>后台文本值</returns>
		string GetValue(ListSourceEventArgs args);

		/// <summary>
		///       获得列表项目的附加数据
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>附加数据文本值</returns>
		string GetTag(ListSourceEventArgs args);
	}
}

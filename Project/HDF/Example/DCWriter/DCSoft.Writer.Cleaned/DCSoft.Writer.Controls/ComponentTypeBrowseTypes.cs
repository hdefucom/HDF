using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       浏览操作类型
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public enum ComponentTypeBrowseTypes
	{
		/// <summary>
		///       为承载控件而浏览类型
		///       </summary>
		ForControlHost,
		/// <summary>
		///       为设置数据源而浏览类型
		///       </summary>
		ForDataSource
	}
}

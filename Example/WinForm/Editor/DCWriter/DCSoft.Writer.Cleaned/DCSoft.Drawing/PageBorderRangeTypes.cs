using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       页面边框类型
	///       </summary>
	
	[ComVisible(true)]
	[Guid("E39AA355-DBDE-4B6F-9198-D2A3A21E4604")]
	public enum PageBorderRangeTypes
	{
		/// <summary>
		///       无页面边框
		///       </summary>
		None,
		/// <summary>
		///       页面边框
		///       </summary>
		Page,
		/// <summary>
		///       文档正文边框
		///       </summary>
		Body
	}
}

using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       分页文档区域部分类型
	///       </summary>
	[Guid("CB265D0A-2180-4DEE-AE49-4A9EE222F0C8")]
	[ComVisible(true)]
	
	public enum PageContentPartyStyle
	{
		/// <summary>
		///       页眉
		///       </summary>
		Header,
		/// <summary>
		///       页脚
		///       </summary>
		Footer,
		/// <summary>
		///       文档正文
		///       </summary>
		Body,
		/// <summary>
		///       标题行
		///       </summary>
		HeaderRows,
		/// <summary>
		///       首页页眉
		///       </summary>
		HeaderForFirstPage,
		/// <summary>
		///       首页页脚
		///       </summary>
		FooterForFirstPage
	}
}

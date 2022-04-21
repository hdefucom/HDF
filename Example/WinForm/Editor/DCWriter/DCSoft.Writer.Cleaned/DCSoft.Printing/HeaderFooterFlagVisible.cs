using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       页眉页脚标记显示模式
	///       </summary>
	
	[ComVisible(true)]
	[Guid("B7702430-5B2C-4A0F-A4F1-CF6CD6583F96")]
	public enum HeaderFooterFlagVisible
	{
		/// <summary>
		///       不显示
		///       </summary>
		None,
		/// <summary>
		///       只显示页眉
		///       </summary>
		Header,
		/// <summary>
		///       只显示页脚
		///       </summary>
		Footer,
		/// <summary>
		///       同时显示页眉和页脚
		///       </summary>
		HeaderFooter
	}
}

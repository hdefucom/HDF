using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       页面显示方式
	///       </summary>
	
	[ComVisible(true)]
	[Guid("281A2321-AC73-44B7-BD0E-D6031832B55F")]
	public enum PageViewMode
	{
		/// <summary>
		///       普通方式
		///       </summary>
		Normal,
		/// <summary>
		///       普通居中对齐模式
		///       </summary>
		NormalCenter,
		/// <summary>
		///       页面方式
		///       </summary>
		Page,
		/// <summary>
		///       压缩页面方式
		///       </summary>
		CompressPage,
		/// <summary>
		///       自动换行
		///       </summary>
		AutoLine
	}
}

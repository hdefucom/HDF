using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表示可以设置内容是否只读的接口
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	[DocumentComment]
	public interface IContentReadonlyable
	{
		/// <summary>
		///       内容只读性设置
		///       </summary>
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}
	}
}

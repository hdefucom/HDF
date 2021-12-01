using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       专供COM事件的无参数委托类型
	///       </summary>
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("1D5A0EC3-3661-41F3-9F4C-693114D4F3EB")]
	public delegate void ComVoidHandler();
}

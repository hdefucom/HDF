using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       元素可见性
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("6F0E093B-A161-4B1F-80A2-4DB4BE69C574")]
	
	public enum ElementVisibility
	{
		/// <summary>
		///       显示
		///       </summary>
		Visible,
		/// <summary>
		///       隐藏，但占据排版位置
		///       </summary>
		Hidden,
		/// <summary>
		///       隐藏，而且不占据排版位置
		///       </summary>
		None
	}
}

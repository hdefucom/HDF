using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       影响文档内容的方式
	///       </summary>
	
	[DocumentComment]
	[ComVisible(false)]
	[Guid("00012345-6789-ABCD-EF01-234567890063")]
	public enum ContentEffects
	{
		/// <summary>
		///       对文档内容没有任何修改，文档无需保存
		///       </summary>
		None,
		/// <summary>
		///       修改了文档内容，但还没有修改DOM结构。
		///       </summary>
		Content,
		/// <summary>
		///       只是影响到显示，不影响排版，重新绘制即可。
		///       </summary>
		Display,
		/// <summary>
		///       影响到文档的排版，需要重新排版重新绘制。
		///       </summary>
		Layout
	}
}

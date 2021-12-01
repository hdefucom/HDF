using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       文档内容对齐方式
	///        </summary>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("78F2DCA9-61DB-4498-B877-42A5B762B091")]
	public enum DocumentContentAlignment
	{
		/// <summary>
		///       左对齐
		///       </summary>
		Left,
		/// <summary>
		///       居中对齐
		///       </summary>
		Center,
		/// <summary>
		///       右对齐
		///       </summary>
		Right,
		/// <summary>
		///       两边对齐
		///       </summary>
		Justify,
		/// <summary>
		///       分散对齐
		///       </summary>
		Distribute
	}
}

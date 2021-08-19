using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       在文档中移动的单位
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-234567890090")]
	[DCPublishAPI]
	public enum MoveUnit
	{
		/// <summary>
		///       字符
		///       </summary>
		Character,
		/// <summary>
		///       单词
		///       </summary>
		Word,
		/// <summary>
		///       文本行
		///       </summary>
		Line,
		/// <summary>
		///       段落
		///       </summary>
		Paragraph,
		/// <summary>
		///       单元格
		///       </summary>
		Cell
	}
}

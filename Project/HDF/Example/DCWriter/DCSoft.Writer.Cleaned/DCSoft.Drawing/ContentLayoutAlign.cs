using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       布局对齐方式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	[Guid("21A1E44C-8A61-4060-9C2A-731DE391A7D6")]
	[ComVisible(true)]
	public enum ContentLayoutAlign
	{
		/// <summary>
		///       嵌入在文本中
		///       </summary>
		EmbedInText,
		/// <summary>
		///       文字四周围绕
		///       </summary>
		Surroundings
	}
}

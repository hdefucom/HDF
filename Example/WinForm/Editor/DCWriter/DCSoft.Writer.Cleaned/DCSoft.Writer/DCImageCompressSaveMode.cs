using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       图片的压缩存储模式
	///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	[Guid("EDB8DADE-CA21-4B15-8E97-0B78F6CF7CD8")]
	public enum DCImageCompressSaveMode
	{
		/// <summary>
		///       压缩存储
		///       </summary>
		[DCDescription(typeof(DCImageCompressSaveMode), "True")]
		True,
		/// <summary>
		///       不压缩存储
		///       </summary>
		[DCDescription(typeof(DCImageCompressSaveMode), "False")]
		False,
		/// <summary>
		///       提示用户选择
		///       </summary>
		[DCDescription(typeof(DCImageCompressSaveMode), "Prompt")]
		Prompt
	}
}

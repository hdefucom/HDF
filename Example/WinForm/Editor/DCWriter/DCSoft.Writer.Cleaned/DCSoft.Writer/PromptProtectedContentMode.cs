using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       受保护内容的提示方式
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	
	[Guid("A5BF86F0-CF22-4C9C-A900-9CE152F982ED")]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	public enum PromptProtectedContentMode
	{
		/// <summary>
		///       不提示
		///       </summary>
		[DCDescription(typeof(PromptProtectedContentMode), "None")]
		None,
		/// <summary>
		///       简单的提示
		///       </summary>
		[DCDescription(typeof(PromptProtectedContentMode), "Simple")]
		Simple,
		/// <summary>
		///       显示详细信息的提示
		///       </summary>
		[DCDescription(typeof(PromptProtectedContentMode), "Details")]
		Details,
		/// <summary>
		///       内容闪烁提示
		///       </summary>
		[DCDescription(typeof(PromptProtectedContentMode), "Flash")]
		Flash
	}
}

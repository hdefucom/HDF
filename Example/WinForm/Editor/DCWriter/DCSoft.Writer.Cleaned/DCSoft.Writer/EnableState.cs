using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       可用状态
	///       </summary>
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[Guid("CAD19059-056C-42B3-9348-79369F18A681")]
	
	
	[ComVisible(true)]
	public enum EnableState
	{
		/// <summary>
		///       默认状态
		///       </summary>
		[DCDescription(typeof(EnableState), "Default")]
		Default,
		/// <summary>
		///       可用状态
		///       </summary>
		[DCDescription(typeof(EnableState), "Enabled")]
		Enabled,
		/// <summary>
		///       无效状态
		///       </summary>
		[DCDescription(typeof(EnableState), "Disabled")]
		Disabled
	}
}

using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       布尔状态值
	///       </summary>
	[ComVisible(true)]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	[Guid("7207CB9B-6DB7-4910-A098-0674B0B47628")]
	
	public enum DCBooleanValueHasDefault
	{
		/// <summary>
		///       是
		///       </summary>
		[DCDescription(typeof(DCBooleanValueHasDefault), "True")]
		True,
		/// <summary>
		///       否
		///       </summary>
		[DCDescription(typeof(DCBooleanValueHasDefault), "False")]
		False,
		/// <summary>
		///       默认
		///       </summary>
		[DCDescription(typeof(DCBooleanValueHasDefault), "Default")]
		Default
	}
}

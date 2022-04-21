using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       内容视图加密方式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890067")]
	public enum ContentViewEncryptType
	{
		/// <summary>
		///       不加密
		///       </summary>
		[DCDescription(typeof(ContentViewEncryptType), "None")]
		None,
		/// <summary>
		///       部分加密,前面和后面一个字符不加密
		///       </summary>
		[DCDescription(typeof(ContentViewEncryptType), "Partial")]
		Partial,
		/// <summary>
		///       全部加密，所有内容加密
		///       </summary>
		[DCDescription(typeof(ContentViewEncryptType), "Both")]
		Both
	}
}

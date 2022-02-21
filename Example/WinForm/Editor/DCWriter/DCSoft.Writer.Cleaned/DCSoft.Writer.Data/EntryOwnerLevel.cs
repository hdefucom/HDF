using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       实体拥有者等级层次
	///       </summary>
	[DocumentComment]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[Guid("00012345-6789-ABCD-EF01-234567890022")]
	[ComVisible(true)]
	[DCDescription(typeof(EntryOwnerLevel), "EntryOwnerLevel")]
	
	public enum EntryOwnerLevel
	{
		/// <summary>
		///       全局的,数值为0
		///       </summary>
		[DCDescription(typeof(EntryOwnerLevel), "Global")]
		Global,
		/// <summary>
		///       部门级别的，数值为1
		///       </summary>
		[DCDescription(typeof(EntryOwnerLevel), "Department")]
		Department,
		/// <summary>
		///       用户私有的，数值为2
		///       </summary>
		[DCDescription(typeof(EntryOwnerLevel), "User")]
		User
	}
}

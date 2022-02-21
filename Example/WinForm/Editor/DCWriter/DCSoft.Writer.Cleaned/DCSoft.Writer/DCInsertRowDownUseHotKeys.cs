using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       使用快捷键在下面插入表格行的模式
	///       </summary>
	
	[ComVisible(true)]
	[Guid("461045B4-FE29-4A6C-9071-15474A9DA8EC")]
	[DocumentComment]
	public enum DCInsertRowDownUseHotKeys
	{
		/// <summary>
		///       禁止使用快捷键在下面插入表格行。
		///       </summary>
		Disable,
		/// <summary>
		///       只有是表格的最后一行才启用这种行为。
		///       </summary>
		EnableOnlyForLastRow,
		/// <summary>
		///       在所有状态下都启用这种行为。无论表格行是否是表格的最后一行都启用这种行为。
		///       </summary>
		EnableInAllCases
	}
}

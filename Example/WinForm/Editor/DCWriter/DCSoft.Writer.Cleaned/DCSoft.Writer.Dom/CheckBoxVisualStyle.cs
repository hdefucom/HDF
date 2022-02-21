using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       复选框显示样式
	///       </summary>
	[ComVisible(true)]
	
	[Guid("8E334872-D3CD-49A3-9A05-88F82D6347A8")]
	public enum CheckBoxVisualStyle
	{
		/// <summary>
		///       默认样式
		///       </summary>
		Default,
		/// <summary>
		///       复选框样式 
		///       </summary>
		CheckBox,
		/// <summary>
		///       单选框样式
		///       </summary>
		RadioBox,
		/// <summary>
		///       操作系统默认样式
		///       </summary>
		SystemDefault,
		/// <summary>
		///       操作系统复选框样式
		///       </summary>
		SystemCheckBox,
		/// <summary>
		///       操作系统单选框样式
		///       </summary>
		SystemRadioBox
	}
}

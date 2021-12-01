using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       输入域扩展标记文本类型
	///       </summary>
	[ComVisible(true)]
	[Guid("B4997EF2-64FF-49DE-92A5-742D69D382AB")]
	[DCPublishAPI]
	[DocumentComment]
	public enum InputFieldAdornTextType
	{
		/// <summary>
		///       无文本
		///       </summary>
		Default,
		/// <summary>
		///       数据源
		///       </summary>
		DataSource,
		/// <summary>
		///       提示文本
		///       </summary>
		ToolTip,
		/// <summary>
		///       数据校验结果信息
		///       </summary>
		ValidateMessage,
		/// <summary>
		///       元素编号
		///       </summary>
		ID,
		/// <summary>
		///       元素名称
		///       </summary>
		Name,
		/// <summary>
		///       切换焦点序号
		///       </summary>
		TabIndex,
		/// <summary>
		///       自定义
		///       </summary>
		Custom
	}
}

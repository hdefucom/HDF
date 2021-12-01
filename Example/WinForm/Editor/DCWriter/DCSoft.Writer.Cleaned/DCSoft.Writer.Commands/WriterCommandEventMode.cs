using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       执行动作参数类型
	///       </summary>
	[ComVisible(true)]
	[Guid("04879D62-EA70-47D2-8C0A-695E0EA258BD")]
	public enum WriterCommandEventMode
	{
		/// <summary>
		///       初始化用户界面控件
		///       </summary>
		InitalizeUIElement,
		/// <summary>
		///       更新用户界面控件
		///       </summary>
		UpdateUIElement,
		/// <summary>
		///       查询参数状态
		///       </summary>
		QueryState,
		/// <summary>
		///       查询命令激活状态
		///       </summary>
		QueryActive,
		/// <summary>
		///       开始执行动作
		///       </summary>
		BeforeExecute,
		/// <summary>
		///       执行动作
		///       </summary>
		Invoke,
		/// <summary>
		///       结束执行动作
		///       </summary>
		AfterExecute
	}
}

using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       提示文本内容样式
	///       </summary>
	[ComVisible(true)]
	[Guid("BB8ABE9E-A777-41BF-9A90-5C68F2871358")]
	public enum ToolTipContentType
	{
		/// <summary>
		///       未知类型
		///       </summary>
		Unknow,
		/// <summary>
		///       用户痕迹信息
		///       </summary>
		UserTrack,
		/// <summary>
		///       元素配置的提示信息
		///       </summary>
		ElementToolTip,
		/// <summary>
		///       校验结果提示信息
		///       </summary>
		ValidateResult
	}
}

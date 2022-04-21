using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       表单按钮样式
	///       </summary>
	[ComVisible(true)]
	
	[Guid("E0A60CF1-6D96-4462-AD04-DAF464C7EBCB")]
	public enum FormButtonStyle
	{
		/// <summary>
		///       无样式
		///       </summary>
		None,
		/// <summary>
		///       自动样式
		///       </summary>
		Auto,
		/// <summary>
		///       普通按钮样式
		///       </summary>
		Button,
		/// <summary>
		///       平面按钮模式
		///       </summary>
		FloatButton,
		/// <summary>
		///       下拉列表按钮样式
		///       </summary>
		ComboBoxButton,
		/// <summary>
		///       时间日期选择样式
		///       </summary>
		DateTimePicker
	}
}

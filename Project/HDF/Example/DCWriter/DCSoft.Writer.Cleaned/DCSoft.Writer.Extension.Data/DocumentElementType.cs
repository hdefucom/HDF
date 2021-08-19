using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       文档元素样式
	///       </summary>
	[ComVisible(false)]
	public enum DocumentElementType
	{
		/// <summary>
		///       输入域
		///       </summary>
		InputField,
		/// <summary>
		///       复选框
		///       </summary>
		CheckBox,
		/// <summary>
		///       单选框
		///       </summary>
		RadioBox
	}
}

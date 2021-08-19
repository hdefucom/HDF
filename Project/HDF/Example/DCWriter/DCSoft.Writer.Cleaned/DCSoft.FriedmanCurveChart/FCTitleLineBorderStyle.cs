using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       边框样式
	///       </summary>
	[ComVisible(false)]
	public enum FCTitleLineBorderStyle
	{
		/// <summary>
		///       无边框
		///       </summary>
		None,
		/// <summary>
		///       全边框
		///       </summary>
		Full,
		/// <summary>
		///       标题头没有边框，数据区有边框
		///       </summary>
		DataOnly
	}
}

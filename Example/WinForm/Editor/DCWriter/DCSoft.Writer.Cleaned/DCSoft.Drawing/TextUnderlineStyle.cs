using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       下划线样式
	///       </summary>
	
	[ComVisible(true)]
	[Guid("09CA6F4F-FE6A-4AA3-BB5E-5BFDAAD34BED")]
	public enum TextUnderlineStyle
	{
		/// <summary>
		///       无样式
		///       </summary>
		None,
		/// <summary>
		///       单下划线
		///       </summary>
		Single,
		/// <summary>
		///       粗线
		///       </summary>
		Thick,
		/// <summary>
		///       短划线
		///       </summary>
		Dash,
		/// <summary>
		///       虚线
		///       </summary>
		Dot,
		/// <summary>
		///       点划线
		///       </summary>
		DashDot,
		/// <summary>
		///       划点点线
		///       </summary>
		DashDotDot,
		/// <summary>
		///       双下划线
		///       </summary>
		Double,
		/// <summary>
		///       波浪线
		///       </summary>
		Wavy,
		/// <summary>
		///       双波浪线
		///       </summary>
		WavyDouble,
		/// <summary>
		///       粗波浪线
		///       </summary>
		WavyHeavy
	}
}

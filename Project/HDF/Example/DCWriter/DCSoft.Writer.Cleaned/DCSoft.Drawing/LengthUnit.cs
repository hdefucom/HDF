using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       长度单位
	///       </summary>
	[ComVisible(false)]
	public enum LengthUnit
	{
		/// <summary>
		///       文档单位
		///       </summary>
		Document,
		/// <summary>
		///       英尺单位
		///       </summary>
		Inch,
		/// <summary>
		///       毫米单位
		///       </summary>
		Millimeter,
		/// <summary>
		///       像素单位
		///       </summary>
		Pixel,
		/// <summary>
		///       点单位
		///       </summary>
		Point,
		/// <summary>
		///       厘米单位
		///       </summary>
		Centimerter,
		/// <summary>
		///       Twips单位
		///       </summary>
		Twips
	}
}

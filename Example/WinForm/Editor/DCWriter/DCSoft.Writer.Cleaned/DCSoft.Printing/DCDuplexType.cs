using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       指定的双面打印设置
	///       </summary>
	[Guid("39FB7D6F-4DE7-4364-83AB-DA01CBD9D368")]
	[ComVisible(true)]
	public enum DCDuplexType
	{
		/// <summary>
		///       未指定
		///       </summary>
		NoSpecify,
		/// <summary>
		///       打印机默认的双面打印设置。
		///       </summary>
		Default,
		/// <summary>
		///       双面水平打印。
		///       </summary>
		Horizontal,
		/// <summary>
		///       单面打印。
		///       </summary>
		Simplex,
		/// <summary>
		///       双面垂直打印。
		///       </summary>
		Vertical
	}
}

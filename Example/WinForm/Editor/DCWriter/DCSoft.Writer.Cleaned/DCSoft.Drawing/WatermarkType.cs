using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       水印类型
	///       </summary>
	[ComVisible(true)]
	[Guid("47CC1028-C10B-4105-84A6-E8A0AE488444")]
	
	
	public enum WatermarkType
	{
		/// <summary>
		///       无水印
		///       </summary>
		None,
		/// <summary>
		///       图片水印
		///       </summary>
		Image,
		/// <summary>
		///       文字水印
		///       </summary>
		Text
	}
}

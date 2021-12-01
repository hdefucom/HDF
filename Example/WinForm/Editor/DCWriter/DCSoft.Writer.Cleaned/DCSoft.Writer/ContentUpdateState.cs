using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       内容更新状态
	///       </summary>
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890066")]
	public enum ContentUpdateState
	{
		/// <summary>
		///       自动更新
		///       </summary>
		[DCDescription(typeof(ContentUpdateState), "AutoUpdate")]
		AutoUpdate,
		/// <summary>
		///       只更新一次
		///       </summary>
		[DCDescription(typeof(ContentUpdateState), "UpdateOne")]
		UpdateOne,
		/// <summary>
		///       内容更新过了，不再更新
		///       </summary>
		[DCDescription(typeof(ContentUpdateState), "Updated")]
		Updated
	}
}

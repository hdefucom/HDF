using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内容引用状态
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[Guid("F30838E4-0974-4EB7-98D9-170A6463CEFA")]
	[DocumentComment]
	[ComVisible(true)]
	
	public enum ContentReferenceState
	{
		/// <summary>
		///       禁止引用
		///       </summary>
		Disable,
		/// <summary>
		///       每次都自动更新。
		///       </summary>
		AutoUpdate,
		/// <summary>
		///       只更新一次，成功后不再更新。
		///       </summary>
		OnceUpdate,
		/// <summary>
		///       加载成功，不再更新。
		///       </summary>
		Loaded
	}
}

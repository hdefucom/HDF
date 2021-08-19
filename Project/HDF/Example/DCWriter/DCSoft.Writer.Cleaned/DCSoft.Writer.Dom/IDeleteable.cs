using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       对象能否被删除
	///       </summary>
	[DCInternal]
	[DocumentComment]
	[ComVisible(false)]
	public interface IDeleteable
	{
		/// <summary>
		///       对象能否被删除
		///       </summary>
		bool Deleteable
		{
			get;
			set;
		}
	}
}

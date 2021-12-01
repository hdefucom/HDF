using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DCContentLockInfo 的COM接口</summary>
	[Guid("678CD509-93EC-4184-B543-2247D344A688")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IDCContentLockInfo
	{
		/// <summary>属性AuthorisedUserIDList</summary>
		[DispId(2)]
		string AuthorisedUserIDList
		{
			get;
			set;
		}

		/// <summary>属性CreationTime</summary>
		[DispId(3)]
		DateTime CreationTime
		{
			get;
			set;
		}

		/// <summary>属性OwnerUserID</summary>
		[DispId(4)]
		string OwnerUserID
		{
			get;
			set;
		}
	}
}

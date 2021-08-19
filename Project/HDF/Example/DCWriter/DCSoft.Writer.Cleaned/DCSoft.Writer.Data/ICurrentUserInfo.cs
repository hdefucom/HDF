using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>CurrentUserInfo 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("49634361-A7BB-4BCB-9A43-75AEE9902914")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface ICurrentUserInfo
	{
		/// <summary>属性ClientName</summary>
		[DispId(2)]
		string ClientName
		{
			get;
			set;
		}

		/// <summary>属性Description</summary>
		[DispId(3)]
		string Description
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(4)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(5)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性PermissionLevel</summary>
		[DispId(6)]
		int PermissionLevel
		{
			get;
			set;
		}
	}
}

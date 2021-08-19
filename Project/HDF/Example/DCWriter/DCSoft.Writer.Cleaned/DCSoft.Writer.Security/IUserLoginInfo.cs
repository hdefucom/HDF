using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Security
{
	/// <summary>UserLoginInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("EC9EA1DA-11AF-4919-BB1A-C00D60CDE8C3")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IUserLoginInfo
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

		/// <summary>属性Name2</summary>
		[DispId(8)]
		string Name2
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

		/// <summary>属性Tag</summary>
		[DispId(7)]
		string Tag
		{
			get;
			set;
		}
	}
}

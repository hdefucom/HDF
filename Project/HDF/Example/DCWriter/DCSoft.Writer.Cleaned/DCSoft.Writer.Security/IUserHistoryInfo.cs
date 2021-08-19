using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Security
{
	/// <summary>UserHistoryInfo 的COM接口</summary>
	[ComVisible(true)]
	[Guid("FFA1C8D8-176B-40CE-9334-FD23534A9F12")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IUserHistoryInfo
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

		/// <summary>属性DisplaySavedTime</summary>
		[DispId(13)]
		DateTime DisplaySavedTime
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

		/// <summary>属性Index</summary>
		[DispId(5)]
		int Index
		{
			get;
			set;
		}

		/// <summary>属性IsEmptySaveTime</summary>
		[DispId(6)]
		bool IsEmptySaveTime
		{
			get;
		}

		/// <summary>属性Name</summary>
		[DispId(7)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Name2</summary>
		[DispId(12)]
		string Name2
		{
			get;
			set;
		}

		/// <summary>属性PermissionLevel</summary>
		[DispId(8)]
		int PermissionLevel
		{
			get;
			set;
		}

		/// <summary>属性SavedTime</summary>
		[DispId(9)]
		DateTime SavedTime
		{
			get;
			set;
		}

		/// <summary>属性SaveTimeString</summary>
		[DispId(10)]
		string SaveTimeString
		{
			get;
		}

		/// <summary>属性Tag</summary>
		[DispId(11)]
		string Tag
		{
			get;
			set;
		}
	}
}

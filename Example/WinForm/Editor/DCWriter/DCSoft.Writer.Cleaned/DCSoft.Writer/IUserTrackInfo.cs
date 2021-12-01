using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>UserTrackInfo 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("7D641D73-509A-4ABE-BCEA-55876B322AC9")]
	[Browsable(false)]
	public interface IUserTrackInfo
	{
		/// <summary>属性CommentText</summary>
		[DispId(9)]
		string CommentText
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(2)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性InfoType</summary>
		[DispId(3)]
		UserTrackType InfoType
		{
			get;
			set;
		}

		/// <summary>属性SaveTime</summary>
		[DispId(4)]
		DateTime SaveTime
		{
			get;
			set;
		}

		/// <summary>属性StdTitle</summary>
		[DispId(10)]
		string StdTitle
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(11)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性UserID</summary>
		[DispId(6)]
		string UserID
		{
			get;
			set;
		}

		/// <summary>属性UserName</summary>
		[DispId(7)]
		string UserName
		{
			get;
			set;
		}
	}
}

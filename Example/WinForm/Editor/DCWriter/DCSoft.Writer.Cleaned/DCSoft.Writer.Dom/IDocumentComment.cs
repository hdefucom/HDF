using DCSoft.Printing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentComment 的COM接口</summary>
	[Guid("2C48283C-903F-450B-9752-99E9220441C4")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IDocumentComment
	{
		/// <summary>属性Author</summary>
		[DispId(2)]
		string Author
		{
			get;
			set;
		}

		/// <summary>属性AuthorID</summary>
		[DispId(13)]
		string AuthorID
		{
			get;
			set;
		}

		/// <summary>属性BackColor</summary>
		[DispId(3)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性BindingUserTrack</summary>
		[DispId(12)]
		bool BindingUserTrack
		{
			get;
			set;
		}

		/// <summary>属性BorderColor</summary>
		[DispId(4)]
		Color BorderColor
		{
			get;
			set;
		}

		/// <summary>属性CreationTime</summary>
		[DispId(5)]
		DateTime CreationTime
		{
			get;
			set;
		}

		/// <summary>属性CreatorIndex</summary>
		[DispId(6)]
		int CreatorIndex
		{
			get;
			set;
		}

		/// <summary>属性ForeColor</summary>
		[DispId(7)]
		Color ForeColor
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(8)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性Index</summary>
		[DispId(9)]
		int Index
		{
			get;
			set;
		}

		/// <summary>属性OwnerPage</summary>
		[DispId(10)]
		PrintPage OwnerPage
		{
			get;
		}

		/// <summary>属性Text</summary>
		[DispId(11)]
		string Text
		{
			get;
			set;
		}
	}
}

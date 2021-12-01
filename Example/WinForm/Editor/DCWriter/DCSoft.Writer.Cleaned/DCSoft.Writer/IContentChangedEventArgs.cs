using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ContentChangedEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("8CF6FF56-F492-4F52-AD84-6F49CF569AB7")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IContentChangedEventArgs
	{
		/// <summary>属性CancelBubble</summary>
		[DispId(2)]
		bool CancelBubble
		{
			get;
			set;
		}

		/// <summary>属性DeletedElements</summary>
		[DispId(3)]
		XTextElementList DeletedElements
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(4)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(5)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(6)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性EventSource</summary>
		[DispId(11)]
		ContentChangedEventSource EventSource
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(7)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性InsertedElements</summary>
		[DispId(8)]
		XTextElementList InsertedElements
		{
			get;
			set;
		}

		/// <summary>属性LoadingDocument</summary>
		[DispId(9)]
		bool LoadingDocument
		{
			get;
			set;
		}

		/// <summary>属性OnlyStyleChanged</summary>
		[DispId(12)]
		bool OnlyStyleChanged
		{
			get;
			set;
		}

		/// <summary>属性Tag</summary>
		[DispId(10)]
		object Tag
		{
			get;
			set;
		}
	}
}

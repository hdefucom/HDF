using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ContentChangingEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[Guid("61FB9A1D-AB49-4AFC-BCCC-0216AA64C328")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IContentChangingEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性CancelBubble</summary>
		[DispId(3)]
		bool CancelBubble
		{
			get;
			set;
		}

		/// <summary>属性DeletingElements</summary>
		[DispId(4)]
		XTextElementList DeletingElements
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(5)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(6)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(7)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(8)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性InsertingElements</summary>
		[DispId(9)]
		XTextElementList InsertingElements
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

		/// <summary>方法GetContainerNewText</summary>
		[DispId(11)]
		string GetContainerNewText();
	}
}

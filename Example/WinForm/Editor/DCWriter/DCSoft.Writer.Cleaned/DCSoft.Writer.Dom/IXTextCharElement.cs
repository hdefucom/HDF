using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextCharElement 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("A453153D-9B11-42B7-B978-175D9E5A30D1")]
	public interface IXTextCharElement
	{
		/// <summary>属性CharValue</summary>
		[DispId(5)]
		char CharValue
		{
			get;
			set;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(6)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(7)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性NextElement</summary>
		[DispId(8)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(9)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(10)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(11)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(12)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(13)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(14)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(15)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(16)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(17)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(18)]
		int ViewIndex
		{
			get;
		}

		/// <summary>方法CreateContentDocument</summary>
		[DispId(2)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(3)]
		void EditorRefreshView();

		/// <summary>方法Select</summary>
		[DispId(4)]
		bool Select();
	}
}

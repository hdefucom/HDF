using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementPaintEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("BFB16C0A-B8AE-4ECA-AACE-BE43493221F5")]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IElementPaintEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性CancelBubble</summary>
		[DispId(11)]
		bool CancelBubble
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ForCreateImage</summary>
		[DispId(5)]
		bool ForCreateImage
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(6)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(10)]
		int PageIndex
		{
			get;
		}

		/// <summary>属性RenderMode</summary>
		[DispId(7)]
		DocumentRenderMode RenderMode
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(8)]
		RuntimeDocumentContentStyle Style
		{
			get;
			set;
		}
	}
}

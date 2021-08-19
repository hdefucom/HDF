using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementCancelEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("84568825-E006-4F84-83A5-4A60E996B332")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IElementCancelEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性CancelBubble</summary>
		[DispId(7)]
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

		/// <summary>属性Handled</summary>
		[DispId(5)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(6)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}

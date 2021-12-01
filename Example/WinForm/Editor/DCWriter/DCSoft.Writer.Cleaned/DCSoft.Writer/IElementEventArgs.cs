using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementEventArgs 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("E480A97E-8DB9-45AF-8207-31C19D079B93")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IElementEventArgs
	{
		/// <summary>属性CancelBubble</summary>
		[DispId(6)]
		bool CancelBubble
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(4)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(5)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}

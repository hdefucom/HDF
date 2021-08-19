using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementKeyEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("20769745-CCC7-4AC4-B98A-25FDFB237B29")]
	[Browsable(false)]
	public interface IElementKeyEventArgs
	{
		/// <summary>属性Alt</summary>
		[DispId(2)]
		bool Alt
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

		/// <summary>属性Control</summary>
		[DispId(3)]
		bool Control
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

		/// <summary>属性Handled</summary>
		[DispId(6)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性KeyCharValue</summary>
		[DispId(7)]
		int KeyCharValue
		{
			get;
		}

		/// <summary>属性KeyCodeValue</summary>
		[DispId(8)]
		int KeyCodeValue
		{
			get;
		}

		/// <summary>属性Shift</summary>
		[DispId(9)]
		bool Shift
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(10)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}

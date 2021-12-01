using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementValidatingEventArgs 的COM接口</summary>
	[Browsable(false)]
	[Guid("449CBD6E-6383-4D0B-8F5D-6FD44067E790")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IElementValidatingEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(8)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性CancelBubble</summary>
		[DispId(9)]
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

		/// <summary>属性Message</summary>
		[DispId(5)]
		string Message
		{
			get;
			set;
		}

		/// <summary>属性ResultLevel</summary>
		[DispId(10)]
		ValueValidateLevel ResultLevel
		{
			get;
			set;
		}

		/// <summary>属性ResultState</summary>
		[DispId(6)]
		ElementValidatingState ResultState
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(7)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}

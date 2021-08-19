using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>CanInsertElementEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("516F05E8-587A-41B4-8DB4-E219BDE0228C")]
	public interface ICanInsertElementEventArgs
	{
		/// <summary>属性Container</summary>
		[DispId(2)]
		XTextContainerElement Container
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性ElementType</summary>
		[DispId(4)]
		Type ElementType
		{
			get;
		}

		/// <summary>属性Flags</summary>
		[DispId(10)]
		DomAccessFlags Flags
		{
			get;
			set;
		}

		/// <summary>属性Index</summary>
		[DispId(6)]
		int Index
		{
			get;
		}

		/// <summary>属性Message</summary>
		[DispId(7)]
		string Message
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(8)]
		bool Result
		{
			get;
			set;
		}

		/// <summary>属性SetMessage</summary>
		[DispId(9)]
		bool SetMessage
		{
			get;
			set;
		}
	}
}

using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementQueryStateEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("BE39D42D-7CC5-4108-BE75-ECD43B32B170")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IElementQueryStateEventArgs
	{
		/// <summary>属性AccessFlags</summary>
		[DispId(2)]
		DomAccessFlags AccessFlags
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

		/// <summary>属性ContentReadonly</summary>
		[DispId(3)]
		bool ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(4)]
		bool Deleteable
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

		/// <summary>属性Handled</summary>
		[DispId(7)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Message</summary>
		[DispId(10)]
		string Message
		{
			get;
			set;
		}

		/// <summary>属性PropertyReadonly</summary>
		[DispId(8)]
		bool PropertyReadonly
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(9)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}

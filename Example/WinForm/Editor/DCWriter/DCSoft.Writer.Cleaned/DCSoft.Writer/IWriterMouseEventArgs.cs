using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterMouseEventArgs 的COM接口</summary>
	[Browsable(false)]
	[Guid("6D63CD6E-F5BB-498C-9DD0-092238DDC8B1")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IWriterMouseEventArgs
	{
		/// <summary>属性ButtonValue</summary>
		[DispId(2)]
		int ButtonValue
		{
			get;
		}

		/// <summary>属性Clicks</summary>
		[DispId(3)]
		int Clicks
		{
			get;
		}

		/// <summary>属性Delta</summary>
		[DispId(4)]
		int Delta
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(5)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性HasLeftButton</summary>
		[DispId(9)]
		bool HasLeftButton
		{
			get;
		}

		/// <summary>属性HasRightButton</summary>
		[DispId(10)]
		bool HasRightButton
		{
			get;
		}

		/// <summary>属性HoverElement</summary>
		[DispId(11)]
		XTextElement HoverElement
		{
			get;
		}

		/// <summary>属性ScreenX</summary>
		[DispId(12)]
		int ScreenX
		{
			get;
		}

		/// <summary>属性ScreenY</summary>
		[DispId(13)]
		int ScreenY
		{
			get;
		}

		/// <summary>属性X</summary>
		[DispId(7)]
		int X
		{
			get;
		}

		/// <summary>属性Y</summary>
		[DispId(8)]
		int Y
		{
			get;
		}
	}
}

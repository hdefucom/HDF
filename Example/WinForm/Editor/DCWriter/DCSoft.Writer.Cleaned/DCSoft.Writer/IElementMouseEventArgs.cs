using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>ElementMouseEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("73B53D58-5AB7-4C9E-BBE3-B5C03CEDF98A")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IElementMouseEventArgs
	{
		/// <summary>属性Button</summary>
		[DispId(15)]
		MouseButtons Button
		{
			get;
			set;
		}

		/// <summary>属性ButtonValue</summary>
		[DispId(2)]
		int ButtonValue
		{
			get;
		}

		/// <summary>属性CancelBubble</summary>
		[DispId(16)]
		bool CancelBubble
		{
			get;
			set;
		}

		/// <summary>属性Clicks</summary>
		[DispId(3)]
		int Clicks
		{
			get;
			set;
		}

		/// <summary>属性Delta</summary>
		[DispId(4)]
		int Delta
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

		/// <summary>属性DocumentX</summary>
		[DispId(6)]
		float DocumentX
		{
			get;
			set;
		}

		/// <summary>属性DocumentY</summary>
		[DispId(7)]
		float DocumentY
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(8)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ElementClientX</summary>
		[DispId(9)]
		float ElementClientX
		{
			get;
			set;
		}

		/// <summary>属性ElementClientY</summary>
		[DispId(10)]
		float ElementClientY
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(11)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性HasLeftButton</summary>
		[DispId(13)]
		bool HasLeftButton
		{
			get;
		}

		/// <summary>属性HasRightButton</summary>
		[DispId(14)]
		bool HasRightButton
		{
			get;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(12)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}

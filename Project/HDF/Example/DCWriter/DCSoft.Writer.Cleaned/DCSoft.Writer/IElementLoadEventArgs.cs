using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementLoadEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("F78AE1CA-23D7-4456-B38A-88F6685D8A41")]
	public interface IElementLoadEventArgs
	{
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

		/// <summary>属性Format</summary>
		[DispId(4)]
		string Format
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

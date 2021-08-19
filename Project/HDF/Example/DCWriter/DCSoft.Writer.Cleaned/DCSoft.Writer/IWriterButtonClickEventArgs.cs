using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterButtonClickEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("B4CCCC57-E596-49A8-B628-45A2251B04E1")]
	public interface IWriterButtonClickEventArgs
	{
		/// <summary>属性ButtonElement</summary>
		[DispId(2)]
		XTextButtonElement ButtonElement
		{
			get;
		}

		/// <summary>属性CommandName</summary>
		[DispId(5)]
		string CommandName
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(6)]
		bool Handled
		{
			get;
			set;
		}
	}
}

using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>CommandErrorEventArgs 的COM接口</summary>
	[Browsable(false)]
	[Guid("929F98CD-60F4-4940-85C7-C07B84A22B08")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICommandErrorEventArgs
	{
		/// <summary>属性CommandName</summary>
		[DispId(2)]
		string CommandName
		{
			get;
			set;
		}

		/// <summary>属性CommmandParameter</summary>
		[DispId(3)]
		object CommmandParameter
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

		/// <summary>属性Message</summary>
		[DispId(5)]
		string Message
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

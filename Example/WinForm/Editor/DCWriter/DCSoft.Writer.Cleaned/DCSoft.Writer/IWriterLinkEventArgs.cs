using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterLinkEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("F3DFCF56-6C01-4B7B-81A2-1F83605AF4CD")]
	public interface IWriterLinkEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性Reference</summary>
		[DispId(4)]
		string Reference
		{
			get;
		}

		/// <summary>属性Target</summary>
		[DispId(5)]
		string Target
		{
			get;
		}
	}
}

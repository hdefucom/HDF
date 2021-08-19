using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterSectionElementCancelEventArgs 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("298B6B79-9E81-4B20-9D0C-ADB858DB425C")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWriterSectionElementCancelEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性SectionElement</summary>
		[DispId(4)]
		XTextSectionElement SectionElement
		{
			get;
		}
	}
}

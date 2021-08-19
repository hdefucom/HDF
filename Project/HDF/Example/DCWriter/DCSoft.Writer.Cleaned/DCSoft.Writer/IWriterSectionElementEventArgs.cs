using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterSectionElementEventArgs 的COM接口</summary>
	[Guid("C1C74C2E-2455-4273-89F5-C66326B7BEC0")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IWriterSectionElementEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性SectionElement</summary>
		[DispId(3)]
		XTextSectionElement SectionElement
		{
			get;
		}
	}
}

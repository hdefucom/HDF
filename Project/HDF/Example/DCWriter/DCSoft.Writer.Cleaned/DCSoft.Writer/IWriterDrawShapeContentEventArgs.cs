using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterDrawShapeContentEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("B6973757-A464-4AED-8C69-D1859AA4EDDC")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IWriterDrawShapeContentEventArgs
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

		/// <summary>属性Graphics</summary>
		[DispId(4)]
		DCGraphics Graphics
		{
			get;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(5)]
		int PageIndex
		{
			get;
		}

		/// <summary>属性ShapeElement</summary>
		[DispId(6)]
		XTextCustomShapeElement ShapeElement
		{
			get;
		}

		/// <summary>属性Sytle</summary>
		[DispId(7)]
		RuntimeDocumentContentStyle Sytle
		{
			get;
		}
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxWriterPrintPreviewControl 事件的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("6FEE3DDC-D761-46E5-8FBC-E9C3658CCBBD")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Browsable(false)]
	public interface IAxWriterPrintPreviewControlComEvents
	{
		/// <summary> ComPrintCompleted 事件</summary>
		[DispId(12340)]
		void ComPrintCompleted();
	}
}

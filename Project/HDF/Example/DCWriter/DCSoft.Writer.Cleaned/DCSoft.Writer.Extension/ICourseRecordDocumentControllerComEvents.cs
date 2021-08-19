using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>CourseRecordDocumentController 事件的COM接口</summary>
	[Browsable(false)]
	[Guid("D9D124CA-C208-4089-9DF2-3858F01D217F")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICourseRecordDocumentControllerComEvents
	{
		/// <summary> BeforeRecordDeleted 事件</summary>
		[DispId(12340)]
		void BeforeRecordDeleted([MarshalAs(UnmanagedType.AsAny)] object sender, WriterCancelEventArgs e);

		/// <summary> CurrentRecordChanged 事件</summary>
		[DispId(12341)]
		void CurrentRecordChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);
	}
}

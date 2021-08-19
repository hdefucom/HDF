using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseRecordDocumentController 事件的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Guid("38138D28-31D1-42BB-8BF0-0103723BAF78")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface ISectionCourseRecordDocumentControllerComEvents
	{
		/// <summary> BeforeRecordDeleted 事件</summary>
		[DispId(12340)]
		void BeforeRecordDeleted([MarshalAs(UnmanagedType.AsAny)] object sender, WriterCancelEventArgs e);

		/// <summary> CurrentRecordChanged 事件</summary>
		[DispId(12341)]
		void CurrentRecordChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);
	}
}

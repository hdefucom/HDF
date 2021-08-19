using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseDocumentInfo 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("82DB5BD1-9921-4810-AFC3-01E9B6472B8F")]
	public interface ISectionCourseDocumentInfo
	{
		/// <summary>属性Files</summary>
		[DispId(2)]
		SectionCourseFileInfoList Files
		{
			get;
			set;
		}
	}
}

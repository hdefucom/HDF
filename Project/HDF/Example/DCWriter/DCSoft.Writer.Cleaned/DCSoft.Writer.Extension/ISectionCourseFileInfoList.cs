using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseFileInfoList 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("8805D1DB-070D-4BD5-B62F-38594F568BD0")]
	public interface ISectionCourseFileInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(4)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(5)]
		SectionCourseFileInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(SectionCourseFileInfo item);
	}
}

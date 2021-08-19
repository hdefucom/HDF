using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseFileInfo 的COM接口</summary>
	[Guid("E9B5F906-6776-419C-8466-FFBCEE754CB4")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface ISectionCourseFileInfo
	{
		/// <summary>属性FileName</summary>
		[DispId(2)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(3)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(4)]
		float Top
		{
			get;
			set;
		}
	}
}

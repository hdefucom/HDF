using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>SpecifyPageIndexInfo 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("B552FEBF-3035-42DF-8FA5-FEC99E4EF75B")]
	public interface ISpecifyPageIndexInfo
	{
		/// <summary>属性RawPageIndex</summary>
		[DispId(2)]
		int RawPageIndex
		{
			get;
			set;
		}

		/// <summary>属性SpecifyPageIndex</summary>
		[DispId(3)]
		int SpecifyPageIndex
		{
			get;
			set;
		}
	}
}

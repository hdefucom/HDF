using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>CurrentDepartmentInfo 的COM接口</summary>
	[Guid("B9C0BC20-EBAF-4C3E-B134-DF1BC5DC9D38")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ICurrentDepartmentInfo
	{
		/// <summary>属性ID</summary>
		[DispId(2)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(3)]
		string Name
		{
			get;
			set;
		}
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>PointClass 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("98A8EC16-75B4-4A6E-B9E0-23301294D02A")]
	[Browsable(false)]
	public interface IPointClass
	{
		/// <summary>属性IsEmpty</summary>
		[DispId(2)]
		bool IsEmpty
		{
			get;
		}

		/// <summary>属性X</summary>
		[DispId(3)]
		int X
		{
			get;
			set;
		}

		/// <summary>属性Y</summary>
		[DispId(4)]
		int Y
		{
			get;
			set;
		}
	}
}

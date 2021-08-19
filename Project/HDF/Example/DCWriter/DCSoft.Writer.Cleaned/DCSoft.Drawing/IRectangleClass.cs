using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>RectangleClass 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("D38AE7A1-FCE0-4997-879F-A40598505C28")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IRectangleClass
	{
		/// <summary>属性Height</summary>
		[DispId(2)]
		int Height
		{
			get;
			set;
		}

		/// <summary>属性IsEmpty</summary>
		[DispId(3)]
		bool IsEmpty
		{
			get;
		}

		/// <summary>属性Left</summary>
		[DispId(4)]
		int Left
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(5)]
		int Top
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(6)]
		int Width
		{
			get;
			set;
		}
	}
}

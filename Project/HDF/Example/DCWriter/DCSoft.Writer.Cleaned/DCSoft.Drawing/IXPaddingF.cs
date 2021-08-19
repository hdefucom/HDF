using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>XPaddingF 的COM接口</summary>
	[Guid("E58F8274-ABFF-411D-9A29-4250E643F9DF")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXPaddingF
	{
		/// <summary>属性Bottom</summary>
		[DispId(2)]
		float Bottom
		{
			get;
			set;
		}

		/// <summary>属性Left</summary>
		[DispId(3)]
		float Left
		{
			get;
			set;
		}

		/// <summary>属性Right</summary>
		[DispId(4)]
		float Right
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(5)]
		float Top
		{
			get;
			set;
		}
	}
}

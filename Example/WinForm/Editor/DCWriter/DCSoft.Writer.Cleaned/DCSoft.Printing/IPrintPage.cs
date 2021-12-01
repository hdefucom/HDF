using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>PrintPage 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("256E102A-6B33-40D3-866C-BC62AA737012")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPrintPage
	{
		/// <summary>属性GlobalIndex</summary>
		[DispId(2)]
		int GlobalIndex
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

		/// <summary>属性Left</summary>
		[DispId(4)]
		float Left
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(5)]
		int PageIndex
		{
			get;
		}

		/// <summary>属性Top</summary>
		[DispId(6)]
		float Top
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(7)]
		float Width
		{
			get;
			set;
		}
	}
}

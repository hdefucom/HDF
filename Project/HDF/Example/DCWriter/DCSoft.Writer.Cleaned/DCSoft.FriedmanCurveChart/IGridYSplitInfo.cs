using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>GridYSplitInfo 的COM接口</summary>
	[Guid("C30D0706-CC80-4C6E-84EE-23BE829EF861")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IGridYSplitInfo
	{
		/// <summary>属性GridYSplitNum</summary>
		[DispId(2)]
		int GridYSplitNum
		{
			get;
			set;
		}

		/// <summary>属性GridYSpaceNum</summary>
		[DispId(3)]
		int GridYSpaceNum
		{
			get;
			set;
		}

		/// <summary>属性ThickLineWidth</summary>
		[DispId(4)]
		float ThickLineWidth
		{
			get;
			set;
		}

		/// <summary>属性ThinLineWidth</summary>
		[DispId(5)]
		float ThinLineWidth
		{
			get;
			set;
		}
	}
}

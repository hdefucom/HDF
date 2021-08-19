using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>GridYSplitInfo 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("C71145F0-8B67-4ADE-A49E-4F9221E58910")]
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

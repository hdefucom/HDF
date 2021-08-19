using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>FriedmanCurveZoneEventArgs 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("6FE6AA73-08D3-4527-B680-E0E96DCE0970")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IFriedmanCurveZoneEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		FriedmanCurveDocument Document
		{
			get;
		}

		/// <summary>属性Zone</summary>
		[DispId(3)]
		FriedmanCurveZoneInfo Zone
		{
			get;
		}
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>DocumentLinkClickEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("D926FB73-F85E-47F4-ACF8-209C93C55E4B")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDocumentLinkClickEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		FriedmanCurveDocument Document
		{
			get;
		}

		/// <summary>属性Link</summary>
		[DispId(3)]
		string Link
		{
			get;
		}

		/// <summary>属性LinkTarget</summary>
		[DispId(4)]
		string LinkTarget
		{
			get;
		}

		/// <summary>属性ValuePoint</summary>
		[DispId(5)]
		FCValuePoint ValuePoint
		{
			get;
		}
	}
}

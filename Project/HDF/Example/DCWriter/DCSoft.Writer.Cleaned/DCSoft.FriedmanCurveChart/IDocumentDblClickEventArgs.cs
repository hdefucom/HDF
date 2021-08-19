using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>DocumentDblClickEventArgs 的COM接口</summary>
	[Guid("E6DF76D8-C0B5-4EB7-9855-25E08E4AA8DC")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IDocumentDblClickEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		FriedmanCurveDocument Document
		{
			get;
		}
	}
}

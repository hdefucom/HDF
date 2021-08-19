using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>DocumentLinkClickEventArgs 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("6230462B-B784-46BF-9830-7C946DE59543")]
	[ComVisible(true)]
	public interface IDocumentLinkClickEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		TemperatureDocument Document
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
		ValuePoint ValuePoint
		{
			get;
		}
	}
}

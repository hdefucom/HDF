using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>DocumentDblClickEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("D6B269B6-99CF-4005-9FF0-B73BA7A9EB1A")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDocumentDblClickEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		TemperatureDocument Document
		{
			get;
		}
	}
}

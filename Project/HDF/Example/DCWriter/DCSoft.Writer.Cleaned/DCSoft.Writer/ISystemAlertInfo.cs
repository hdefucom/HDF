using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>SystemAlertInfo 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("AE1A9ED0-0194-4A97-A116-5A4A508995DD")]
	public interface ISystemAlertInfo
	{
		/// <summary>属性Message</summary>
		[DispId(2)]
		string Message
		{
			get;
			set;
		}
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DCWriterPublish 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("DBF2070E-C5B3-4377-A6C9-48C497152539")]
	public interface IDCWriterPublish
	{
		/// <summary>方法StartSystem</summary>
		[DispId(2)]
		void StartSystem();
	}
}

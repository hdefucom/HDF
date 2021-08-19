using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>LocalConfig 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("BE183319-C54A-4B39-97C4-2D38075CBF77")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ILocalConfig
	{
		/// <summary>属性OldWhitespaceWidth</summary>
		[DispId(2)]
		bool OldWhitespaceWidth
		{
			get;
			set;
		}
	}
}

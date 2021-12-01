using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>StatusTextChangedEventArgs 的COM接口</summary>
	[Browsable(false)]
	[Guid("AEF26CE0-0989-4320-A3F0-4FD86FBB179B")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IStatusTextChangedEventArgs
	{
		/// <summary>属性StatusText</summary>
		[DispId(2)]
		string StatusText
		{
			get;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(3)]
		WriterControl WriterControl
		{
			get;
		}
	}
}

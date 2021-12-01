using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>CustomCommandEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("7F39B85E-DD00-43E7-8A0D-4E81D7422599")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface ICustomCommandEventArgs
	{
		/// <summary>属性CommandName</summary>
		[DispId(2)]
		string CommandName
		{
			get;
		}
	}
}

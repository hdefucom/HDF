using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>ListSourceEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("D277A42C-60D7-4E35-B466-2AEE388EA5FF")]
	[Browsable(false)]
	public interface IListSourceEventArgs
	{
		/// <summary>属性Host</summary>
		[DispId(2)]
		WriterAppHost Host
		{
			get;
			set;
		}

		/// <summary>属性Info</summary>
		[DispId(3)]
		ListSourceInfo Info
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(4)]
		object Value
		{
			get;
			set;
		}
	}
}

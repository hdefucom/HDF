using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>ListItemsEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("F9A4A830-6319-4333-A52E-A370ADA50848")]
	[ComVisible(true)]
	public interface IListItemsEventArgs
	{
		/// <summary>属性Host</summary>
		[DispId(2)]
		WriterAppHost Host
		{
			get;
			set;
		}

		/// <summary>属性KBEntry</summary>
		[DispId(3)]
		KBEntry KBEntry
		{
			get;
			set;
		}

		/// <summary>属性SourceName</summary>
		[DispId(4)]
		string SourceName
		{
			get;
			set;
		}
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XAttribute 的COM接口</summary>
	[Browsable(false)]
	[Guid("1AECE4DB-7387-44DD-836F-D8CD8A6AAB3B")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXAttribute
	{
		/// <summary>属性Name</summary>
		[DispId(2)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(3)]
		string Value
		{
			get;
			set;
		}
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>PrintPageCollection 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("D88C776B-B1B2-4661-9DD6-0F38C83ED776")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IPrintPageCollection
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(9)]
		PrintPage this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Contains</summary>
		[DispId(2)]
		bool Contains(PrintPage item);

		/// <summary>方法ContainsTop</summary>
		[DispId(3)]
		bool ContainsTop(int vTop);
	}
}

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>PrintPageResultList 的COM接口</summary>
	[Guid("38D382F0-615B-4246-9CFB-A3DB63398ADD")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPrintPageResultList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		PrintPageResult this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(PrintPageResult item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(PrintPageResult item);

		/// <summary>方法IndexOf</summary>
		[DispId(5)]
		int IndexOf(PrintPageResult item);
	}
}

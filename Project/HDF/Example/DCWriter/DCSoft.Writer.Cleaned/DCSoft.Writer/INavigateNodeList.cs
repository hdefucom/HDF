using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>NavigateNodeList 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("2609A1FB-AA59-4BC3-81D7-823A18BBFF44")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface INavigateNodeList
	{
		/// <summary>属性Count</summary>
		[DispId(7)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(8)]
		NavigateNode this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(NavigateNode item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法ComGetItem</summary>
		[DispId(9)]
		NavigateNode ComGetItem(int index);

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(NavigateNode item);

		/// <summary>方法RemoveAt</summary>
		[DispId(6)]
		void RemoveAt(int index);
	}
}

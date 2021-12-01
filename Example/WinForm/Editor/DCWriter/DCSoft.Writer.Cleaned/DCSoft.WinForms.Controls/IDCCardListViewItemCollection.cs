using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>DCCardListViewItemCollection 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("1CABB64D-C108-4149-953C-9B6CB505AC5B")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDCCardListViewItemCollection
	{
		/// <summary>属性Count</summary>
		[DispId(8)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(9)]
		DCCardListViewItem this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(DCCardListViewItem item);

		/// <summary>方法AddNewItem</summary>
		[DispId(3)]
		DCCardListViewItem AddNewItem();

		/// <summary>方法Clear</summary>
		[DispId(4)]
		void Clear();

		/// <summary>方法IndexOf</summary>
		[DispId(5)]
		int IndexOf(DCCardListViewItem item);

		/// <summary>方法Remove</summary>
		[DispId(6)]
		bool Remove(DCCardListViewItem item);

		/// <summary>方法RemoveAt</summary>
		[DispId(7)]
		void RemoveAt(int index);
	}
}

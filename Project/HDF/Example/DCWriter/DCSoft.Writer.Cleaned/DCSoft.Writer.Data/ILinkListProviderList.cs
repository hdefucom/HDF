using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>LinkListProviderList 的COM接口</summary>
	[Guid("36702F82-E65E-4F65-8CE8-8A9F8BF7CC5C")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface ILinkListProviderList
	{
		/// <summary>属性Count</summary>
		[DispId(10)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(11)]
		LinkListProvider this[int index]
		{
			get;
			set;
		}

		/// <summary>属性Names</summary>
		[DispId(12)]
		string[] Names
		{
			get;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(LinkListProvider item);

		/// <summary>方法Contains</summary>
		[DispId(3)]
		bool Contains(LinkListProvider item);

		/// <summary>方法ContainsName</summary>
		[DispId(4)]
		bool ContainsName(string name);

		/// <summary>方法GetEnabledProvider</summary>
		[DispId(5)]
		LinkListProvider GetEnabledProvider(string name);

		/// <summary>方法Insert</summary>
		[DispId(7)]
		void Insert(int index, LinkListProvider item);

		/// <summary>方法Remove</summary>
		[DispId(8)]
		bool Remove(LinkListProvider item);

		/// <summary>方法RemoveAt</summary>
		[DispId(9)]
		void RemoveAt(int index);
	}
}

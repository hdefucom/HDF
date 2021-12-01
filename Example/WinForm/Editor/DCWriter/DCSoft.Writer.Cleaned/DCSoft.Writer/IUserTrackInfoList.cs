using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>UserTrackInfoList 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("41CAB7D0-1773-4965-9193-62F421392D66")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IUserTrackInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性Current</summary>
		[DispId(14)]
		UserTrackInfo Current
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		UserTrackInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(UserTrackInfo item);

		/// <summary>方法ComGetItem</summary>
		[DispId(15)]
		UserTrackInfo ComGetItem(int index);

		/// <summary>方法Contains</summary>
		[DispId(3)]
		bool Contains(UserTrackInfo item);

		/// <summary>方法Refresh</summary>
		[DispId(13)]
		void Refresh();

		/// <summary>方法Remove</summary>
		[DispId(7)]
		bool Remove(UserTrackInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(8)]
		void RemoveAt(int index);
	}
}

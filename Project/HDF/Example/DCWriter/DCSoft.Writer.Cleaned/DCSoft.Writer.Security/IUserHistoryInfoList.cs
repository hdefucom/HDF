using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Security
{
	/// <summary>UserHistoryInfoList 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("35D44AE6-80B3-4C34-B57E-5E03370CB20E")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IUserHistoryInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(5)]
		int Count
		{
			get;
		}

		/// <summary>属性CurrentIndex</summary>
		[DispId(6)]
		int CurrentIndex
		{
			get;
		}

		/// <summary>属性CurrentInfo</summary>
		[DispId(7)]
		UserHistoryInfo CurrentInfo
		{
			get;
		}

		/// <summary>属性CurrentPermissionLevel</summary>
		[DispId(8)]
		int CurrentPermissionLevel
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(9)]
		UserHistoryInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(10)]
		void Add(UserHistoryInfo item);

		/// <summary>方法ComGetItem</summary>
		[DispId(11)]
		UserHistoryInfo ComGetItem(int index);
	}
}

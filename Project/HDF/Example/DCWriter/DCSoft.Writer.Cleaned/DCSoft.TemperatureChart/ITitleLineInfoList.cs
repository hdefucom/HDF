using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>TitleLineInfoList 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("3390A48C-7862-41D2-86FB-11BBC7210616")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ITitleLineInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(7)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(8)]
		TitleLineInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(TitleLineInfo item);

		/// <summary>方法GetItemByName</summary>
		[DispId(3)]
		TitleLineInfo GetItemByName(string name);

		/// <summary>方法IndexOf</summary>
		[DispId(4)]
		int IndexOf(TitleLineInfo item);

		/// <summary>方法Remove</summary>
		[DispId(5)]
		bool Remove(TitleLineInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(6)]
		void RemoveAt(int index);
	}
}

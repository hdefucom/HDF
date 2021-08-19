using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>YAxisInfoList 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("95A5DA6C-2BEC-40AF-8398-A173672AADE8")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IYAxisInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		YAxisInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(YAxisInfo item);

		/// <summary>方法GetItemByName</summary>
		[DispId(8)]
		YAxisInfo GetItemByName(string name);

		/// <summary>方法IndexOf</summary>
		[DispId(3)]
		int IndexOf(YAxisInfo item);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(YAxisInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}

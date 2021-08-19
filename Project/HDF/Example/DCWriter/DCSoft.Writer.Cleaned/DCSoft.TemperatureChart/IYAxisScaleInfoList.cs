using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>YAxisScaleInfoList 的COM接口</summary>
	[Guid("D9B3B999-7104-4BE1-9064-44C63D1F7260")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IYAxisScaleInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		YAxisScaleInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(YAxisScaleInfo item);

		/// <summary>方法IndexOf</summary>
		[DispId(3)]
		int IndexOf(YAxisScaleInfo item);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(YAxisScaleInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}

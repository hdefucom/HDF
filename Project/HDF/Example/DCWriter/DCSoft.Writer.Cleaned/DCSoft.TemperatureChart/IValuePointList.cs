using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>ValuePointList 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("24B36CE2-9E2A-4DFD-AC8E-350456662E07")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IValuePointList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		ValuePoint this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(ValuePoint item);

		/// <summary>方法AddByTimeText</summary>
		[DispId(8)]
		ValuePoint AddByTimeText(DateTime dateTime_0, string Text);

		/// <summary>方法AddByTimeValue</summary>
		[DispId(9)]
		ValuePoint AddByTimeValue(DateTime dateTime_0, float Value);

		/// <summary>方法AddByTimeValueLandernValue</summary>
		[DispId(10)]
		ValuePoint AddByTimeValueLandernValue(DateTime dateTime_0, float Value, float landernValue);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(ValuePoint item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}

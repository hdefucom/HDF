using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>ValuePointList 的COM接口</summary>
	[Guid("7771567A-E957-4C69-8DF5-64C9BEA547BC")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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
		FCValuePoint this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(FCValuePoint item);

		/// <summary>方法AddByTimeText</summary>
		[DispId(8)]
		FCValuePoint AddByTimeText(DateTime dateTime_0, string Text);

		/// <summary>方法AddByTimeValue</summary>
		[DispId(9)]
		FCValuePoint AddByTimeValue(DateTime dateTime_0, float Value);

		/// <summary>方法AddByTimeValueLandernValue</summary>
		[DispId(10)]
		FCValuePoint AddByTimeValueLandernValue(DateTime dateTime_0, float Value, float landernValue);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(FCValuePoint item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}
